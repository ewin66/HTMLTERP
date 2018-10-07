using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HttSoft.Framework;
using HttSoft.FrameFunc;

namespace HTERP
{


    /// <summary>
    /// Ԥ��ƽ̨������
    /// </summary>
    public class SysAlarmParamSet
    {
        /// <summary>
        /// Ԥ��ƽ̨������
        /// </summary>
        static DataTable m_SysAlarmParamSetDt;
        /// <summary>
        /// Ԥ��ƽ̨������
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
                    sql = "SELECT * FROM Sys_ParamSet WHERE ID BETWEEN 8000 AND  8100";//ϵͳ������
                    m_SysAlarmParamSetDt = SysUtils.Fill(sql);
                }
                return m_SysAlarmParamSetDt;
            }
        }


        /// <summary>
        /// �����������ֵID
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns>����ֵ</returns>
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
    /// Ԥ��ƽ̨������
    /// �¼Ӻ�
    /// 2014-5-10
    /// </summary>
    public class SysAlarmCommon
    {
        #region Ԥ��ƽ̨���ñ�����
        /// <summary>
        /// Ԥ��ƽ̨���ñ�
        /// </summary>
        static DataTable m_SysAlarmSetDt;
        /// <summary>
        /// Ԥ��ƽ̨���ñ�
        /// </summary>
        public static DataTable SysAlarmSetDt
        {
            get
            {
                if (m_SysAlarmSetDt == null)
                {
                    string sql = string.Empty;
                    sql = "SELECT * FROM Sys_StandardAlarm WHERE 1=1 AND CheckOPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += " AND UseFlag=1";//�����ʺ�Ԥ��������
                    m_SysAlarmSetDt = SysUtils.Fill(sql);//�������ѵĻ�����Ϣ
                }
                return m_SysAlarmSetDt;
            }
        }
        #endregion
        /// <summary>
        /// ��ʼ��
        /// </summary>
        public static void AlarmMsgIni(System.Windows.Forms.Timer timerAlarm)
        {

            bool useFlag = SysConvert.ToBoolean(SysAlarmParamSet.GetIntValueByID(8001));//ϵͳԤ��ƽ̨����
            if (useFlag && SysAlarmSetDt.Rows.Count!=0)//���ò��Ҵ��û���������Ϣ��
            {
                int checkSecondes = SysAlarmParamSet.GetIntValueByID(8002);//ϵͳԤ��ƽ̨��ʱ���ʱ��(��λ:��)

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
        /// Ԥ�����ڼ���
        /// </summary>
        /// <param name="MessageTable"></param>
        /// <param name="ShowMessageFormAlarm"></param>
        public static bool AlarmWinAct(DataTable MessageTable, MessageFormAlarm ShowMessageFormAlarm,frmMainFunc mdiForm)
        {
            bool showFlag = false;//�Ƿ���ʾ��־
            if (MessageTable.Rows.Count != 0)
            {

                if (ShowMessageFormAlarm == null)
                {
                    ShowMessageFormAlarm = MessageFormAlarm.Instance;
                }

                ShowMessageFormAlarm.Msg = MessageTable;
                ShowMessageFormAlarm.MDIForm = mdiForm;



                int formWidth = SysAlarmParamSet.GetIntValueByID(8003);//ϵͳԤ�����ڿ��
                int formHeight = SysAlarmParamSet.GetIntValueByID(8004);//ϵͳԤ�����ڸ߶�
                if (formWidth <= 0)
                {
                    formWidth = 300;
                }
                if (formHeight <= 0)
                {
                    formHeight = 600;
                }
                ShowMessageFormAlarm.WidthMax = formWidth;//��������Ŀ��
                ShowMessageFormAlarm.HeightMax = formHeight;//��������ĸ߶�
                ShowMessageFormAlarm.ScrollShow();
                ShowMessageFormAlarm.ScrollShow();
                showFlag = true;
            }
            return showFlag;
        }


       
        /// <summary>
        /// ��ȡ�Զ���������
        /// </summary>
        /// <param name="MessageTable">������Ϣ��</param>
        /// <param name="AlarmShowTimes">�Ѿ���ʾ����</param>
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

            GetStandAlarmData(MessageTable, SysAlarmSetDt, AlarmShowTimes);//���Ԥ��������ʾ����
        }


        /// <summary>
        /// ���Ԥ��������ʾ����
        /// </summary>
        /// <param name="dtShow"></param>
        /// <param name="dtsource"></param>
        private static void GetStandAlarmData(DataTable dtShow, DataTable dtsource,int AlarmShowTimes)
        {
            dtShow.Clear();
            foreach (DataRow dr in dtsource.Rows)//���õĻ�����Ϣ
            {
                if (SysConvert.ToInt32(dr["DayShowTimes"]) != 0)
                {
                    if (SysConvert.ToInt32(dr["DayShowTimes"]) <= AlarmShowTimes)//����Ԥ����ʾ����
                    {
                        continue;//���β�ִ�м�������������Ԥ��
                    }
                }
                string sql = string.Empty;
                sql = "SELECT ";
                if (SysConvert.ToInt32(dr["DShowCount"]) != 0)//��ʾ��������
                {
                    sql += " TOP " + dr["DShowCount"].ToString();
                }
                sql+= " " + dr["QryFieldName"].ToString();//�����ֶ���
                sql += " FROM " + dr["QryTableName"].ToString();//��������
                sql+= " WHERE 1=1 " + dr["LoadCondition"].ToString();//�Ѿ��ύû�����
                DataTable dt = SysUtils.Fill(sql);


                string[] feildnames = dr["ShowFieldName"].ToString().Split(',');//��ʾ�ֶ���
                string[] captions = dr["ShowFieldNameCn"].ToString().Split(',');//��ʾ����
                foreach (DataRow drdts in dt.Rows)
                {
                    string showname = string.Empty;
                    for (int i = 0; i < feildnames.Length; i++)
                    {
                        if (feildnames[i] != string.Empty)
                        {
                            if (captions[i].ToString() != string.Empty && drdts[feildnames[i]].ToString()!=string.Empty)//�б�����ֵ���ۼӱ���
                            {
                                showname += captions[i].ToString() + ":";
                            }

                            showname += drdts[feildnames[i]].ToString() + " ";//�ۼ�ֵ
                        }
                    }
                    string links = string.Empty;
                    DataRow drnew = dtShow.NewRow();
                    drnew["Name"] = showname;//��ʾ����
                    drnew["LinkName"] = dr["FormClassName"].ToString() + "," + dr["FormListAID"].ToString() + "," + dr["FormListBID"].ToString() + "," + drdts[dr["PKFieldName"].ToString()].ToString();//��������
                    dtShow.Rows.Add(drnew);
                }
            }
        }

        
    }
}
