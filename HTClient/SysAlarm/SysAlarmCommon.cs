using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HttSoft.Framework;
using HttSoft.FrameFunc;

namespace HTERP
{


    /// <summary>
    /// 预警平台参数类
    /// </summary>
    public class SysAlarmParamSet
    {
        /// <summary>
        /// 预警平台参数类
        /// </summary>
        static DataTable m_SysAlarmParamSetDt;
        /// <summary>
        /// 预警平台参数类
        /// </summary>
        public static DataTable SysAlarmParamSetDt
        {
            set
            {
                m_SysAlarmParamSetDt = value;
            }
            get
            {
                if (m_SysAlarmParamSetDt == null)
                {
                    string sql = string.Empty;
                    sql = "SELECT * FROM Sys_ParamSet WHERE ID BETWEEN 8000 AND  8100";//系统参数类
                    m_SysAlarmParamSetDt = SysUtils.Fill(sql);
                }
                return m_SysAlarmParamSetDt;
            }
        }


        /// <summary>
        /// 获得整数参数值ID
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns>参数值</returns>
        public static int GetIntValueByID(int p_ID)
        {
            int outI = 0;
            DataRow[] drA = SysAlarmParamSetDt.Select("ID=" + p_ID.ToString());
            if (drA.Length == 1)
            {
                outI = SysConvert.ToInt32(drA[0]["SetValueInt"]);
            }

            return outI;
        }



    }

    /// <summary>
    /// 预警平台共用类
    /// 陈加海
    /// 2014-5-10
    /// </summary>
    public class SysAlarmCommon
    {
        #region 预警平台配置表属性
        /// <summary>
        /// 预警平台配置表
        /// </summary>
        static DataTable m_SysAlarmSetDt;
        /// <summary>
        /// 预警平台配置表
        /// </summary>
        public static DataTable SysAlarmSetDt
        {
            get
            {
                if (m_SysAlarmSetDt == null)
                {
                    string sql = string.Empty;
                    sql = "SELECT * FROM Sys_StandardAlarm WHERE 1=1 AND CheckOPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += " AND UseFlag=1";//检索适合预警的数据
                    m_SysAlarmSetDt = SysUtils.Fill(sql);//设置提醒的基本信息
                }
                return m_SysAlarmSetDt;
            }
        }
        #endregion
        /// <summary>
        /// 初始化
        /// </summary>
        public static void AlarmMsgIni(System.Windows.Forms.Timer timerAlarm)
        {

            bool useFlag = SysConvert.ToBoolean(SysAlarmParamSet.GetIntValueByID(8001));//系统预警平台启用
            if (useFlag && SysAlarmSetDt.Rows.Count!=0)//启用并且此用户有配置信息表
            {
                int checkSecondes = SysAlarmParamSet.GetIntValueByID(8002);//系统预警平台定时监测时长(单位:秒)

                timerAlarm.Enabled = true;
                if (checkSecondes != 0)
                {
                    timerAlarm.Interval = checkSecondes * 1000;
                }
                else
                {
                    timerAlarm.Interval = 2000;
                }                
            }
            else
            {
                timerAlarm.Enabled = false;
            }
        }

        /// <summary>
        /// 预警窗口激活
        /// </summary>
        /// <param name="MessageTable"></param>
        /// <param name="ShowMessageFormAlarm"></param>
        public static bool AlarmWinAct(DataTable MessageTable, MessageFormAlarm ShowMessageFormAlarm,frmMainFunc mdiForm)
        {
            bool showFlag = false;//是否显示标志
            if (MessageTable.Rows.Count != 0)
            {

                if (ShowMessageFormAlarm == null)
                {
                    ShowMessageFormAlarm = MessageFormAlarm.Instance;
                }

                ShowMessageFormAlarm.Msg = MessageTable;
                ShowMessageFormAlarm.MDIForm = mdiForm;



                int formWidth = SysAlarmParamSet.GetIntValueByID(8003);//系统预警窗口宽度
                int formHeight = SysAlarmParamSet.GetIntValueByID(8004);//系统预警窗口高度
                if (formWidth <= 0)
                {
                    formWidth = 300;
                }
                if (formHeight <= 0)
                {
                    formHeight = 600;
                }
                ShowMessageFormAlarm.WidthMax = formWidth;//窗体滚动的宽度
                ShowMessageFormAlarm.HeightMax = formHeight;//窗体滚动的高度
                ShowMessageFormAlarm.ScrollShow();
                ShowMessageFormAlarm.ScrollShow();
                showFlag = true;
            }
            return showFlag;
        }


       
        /// <summary>
        /// 获取自动弹出窗体
        /// </summary>
        /// <param name="MessageTable">检索信息表</param>
        /// <param name="AlarmShowTimes">已经显示次数</param>
        public static void GetMessageTable(DataTable MessageTable, int AlarmShowTimes)
        {
            if (MessageTable == null)
            {
                MessageTable = new DataTable();
            }
            if (!MessageTable.Columns.Contains("Name"))
            {
                MessageTable.Columns.Add("Name", typeof(string));
            }
            if (!MessageTable.Columns.Contains("LinkName"))
            {
                MessageTable.Columns.Add("LinkName", typeof(string));
            }

            GetStandAlarmData(MessageTable, SysAlarmSetDt, AlarmShowTimes);//获得预警窗体显示数据
        }


        /// <summary>
        /// 获得预警窗体显示数据
        /// </summary>
        /// <param name="dtShow"></param>
        /// <param name="dtsource"></param>
        private static void GetStandAlarmData(DataTable dtShow, DataTable dtsource,int AlarmShowTimes)
        {
            dtShow.Clear();
            foreach (DataRow dr in dtsource.Rows)//配置的基本信息
            {
                if (SysConvert.ToInt32(dr["DayShowTimes"]) != 0)
                {
                    if (SysConvert.ToInt32(dr["DayShowTimes"]) <= AlarmShowTimes)//大于预警显示次数
                    {
                        continue;//本次不执行继续检索，不再预警
                    }
                }
                string sql = string.Empty;
                sql = "SELECT ";
                if (SysConvert.ToInt32(dr["DShowCount"]) != 0)//显示检索条数
                {
                    sql += " TOP " + dr["DShowCount"].ToString();
                }
                sql+= " " + dr["QryFieldName"].ToString();//检索字段名
                sql += " FROM " + dr["QryTableName"].ToString();//检索表名
                sql+= " WHERE 1=1 " + dr["LoadCondition"].ToString();//已经提交没有审核
                DataTable dt = SysUtils.Fill(sql);


                string[] feildnames = dr["ShowFieldName"].ToString().Split(',');//显示字段名
                string[] captions = dr["ShowFieldNameCn"].ToString().Split(',');//显示表名
                foreach (DataRow drdts in dt.Rows)
                {
                    string showname = string.Empty;
                    for (int i = 0; i < feildnames.Length; i++)
                    {
                        if (feildnames[i] != string.Empty)
                        {
                            if (captions[i].ToString() != string.Empty && drdts[feildnames[i]].ToString()!=string.Empty)//有标题有值再累加标题
                            {
                                showname += captions[i].ToString() + ":";
                            }

                            showname += drdts[feildnames[i]].ToString() + " ";//累加值
                        }
                    }
                    string links = string.Empty;
                    DataRow drnew = dtShow.NewRow();
                    drnew["Name"] = showname;//显示名字
                    drnew["LinkName"] = dr["FormClassName"].ToString() + "," + dr["FormListAID"].ToString() + "," + dr["FormListBID"].ToString() + "," + drdts[dr["PKFieldName"].ToString()].ToString();//联接名字
                    dtShow.Rows.Add(drnew);
                }
            }
        }

        
    }
}
