using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Text;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;
using System.Collections;
using System.Windows.Forms;


namespace MLTERP
{
    /// <summary>
    /// 功能：仓库平面图处理
    /// 作者：陈加海
    /// 日期：2007-11-22
    /// </summary>
    class WHPlaneProc
    {
        #region 类内参数
        static int m_MinPixel = 10;//每单元坐标的像素数
        static int m_LabelPixel = 5;//每单元坐标的像素数
        static int m_DelLabel = 0;//Label的相对位置
        //static int m_HeightLabel = 2;//Label的高度
        static DataTable m_StorgeData = new DataTable();

        static string WHID = string.Empty;//仓库库编码
        static string SectionID = string.Empty;//仓库区编码
        #endregion

        #region 外部调用方法

        #region 位相关
        /// <summary>
        /// 调用仓库
        /// </summary>
        public static void CallWH1(string p_WHID, GroupControl p_Parent, ToolTip p_Tip)
        {
            string sql = "SELECT SBitID,WeightMax,PosY,PosX,SizeWidth,SizeHeight FROM WH_SBit WHERE WHID=" + SysString.ToDBString(p_WHID) + " AND SizeWidth>0 AND SizeHeight>0 ORDER BY SBitID";
            DataTable dt = SysUtils.Fill(sql);
            ArrayList sbitParm = new ArrayList();
            foreach (DataRow dr in dt.Rows)
            {
                sbitParm.Add(new string[] { dr["PosX"].ToString(), dr["PosY"].ToString(), dr["SizeWidth"].ToString(), dr["SizeHeight"].ToString()
                , dr["SBitID"].ToString(), dr["WeightMax"].ToString()});//int p_X, int p_Y, int p_Width, int p_Height, string p_Caption, string p_MaxWeight
            }

                        GroupParentClear(p_Parent);
            m_StorgeData = GetStorge(p_WHID);
            CreateSBit(p_Parent, sbitParm, p_Tip);
        }
        #endregion

        /// <summary>
        /// 调用仓库
        /// </summary>
        public static void CallWH(string p_WHID, GroupControl p_Parent, ToolTip p_Tip)
        {
            string sql = "SELECT WHPicID,PosX,PosY,SizeWidth,SizeHeight FROM WH_WHPic WHERE WHID=" + SysString.ToDBString(p_WHID) + " AND SizeWidth>0 AND SizeHeight>0 ORDER BY WHPicID ";
            DataTable dtPic = SysUtils.Fill(sql);//平面分类表

            sql = "SELECT WHPicID,SectionID,WeightMax,PosY,PosX,SizeWidth,SizeHeight FROM WH_Section WHERE WHID=" + SysString.ToDBString(p_WHID) + " AND SizeWidth>0 AND SizeHeight>0 ORDER BY WHPicID,SectionID";
            DataTable dtSection = SysUtils.Fill(sql);//平面区表

            ArrayList wpicParm = new ArrayList();
            ArrayList wpicParm2 = new ArrayList();

            foreach (DataRow dr in dtPic.Rows)
            {
                ArrayList sectionParm = new ArrayList();//平面区位表
                foreach (DataRow drSection in dtSection.Rows)
                {
                    if (dr["WHPicID"].ToString().ToUpper() == drSection["WHPicID"].ToString().ToUpper())//找到一致的数据
                    {
                        sectionParm.Add(new string[]{drSection["PosX"].ToString(), drSection["PosY"].ToString(), drSection["SizeWidth"].ToString(), drSection["SizeHeight"].ToString()
														, drSection["SectionID"].ToString(), drSection["WeightMax"].ToString()});
                    }
                }

                wpicParm.Add(new string[] { dr["PosX"].ToString(), dr["PosY"].ToString(), dr["SizeWidth"].ToString(), dr["SizeHeight"].ToString()
											  , dr["WHPicID"].ToString()});//int p_X, int p_Y, int p_Width, int p_Height, string p_Caption, string p_MaxWeight
                wpicParm2.Add(sectionParm);
            }

            WHID = p_WHID;
            GroupParentClear(p_Parent);
            m_StorgeData = GetStorge(p_WHID);
            CreatePanel(p_Parent, wpicParm, wpicParm2, p_Tip);

        }


        /// <summary>
        /// 调用一个区位
        /// </summary>
        public static void CallSBit()
        {
        }
        #endregion

        #region 系统根方法
        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="p_Parent"></param>
        private static void GroupParentClear(GroupControl p_Parent)
        {
            for (int i = p_Parent.Controls.Count - 1; i >= 0; i--)
            {
                p_Parent.Controls.Remove(p_Parent.Controls[i]);
            }
        }

        /// <summary>
        /// 创建总的区分类图
        /// </summary>
        /// <param name="p_Parent"></param>
        /// <param name="p_SectionParam"></param>
        /// <param name="p_SBitParam"></param>
        private static void CreatePanel(GroupControl p_Parent, ArrayList p_WHPicParam, ArrayList p_WHPicParam2, ToolTip p_Tip)
        {
            for (int i = 0; i < p_WHPicParam.Count; i++)
            {
                string[] tempa = (string[])p_WHPicParam[i];
                CreateOnePanel(p_Parent, SysConvert.ToInt32(tempa[0]), SysConvert.ToInt32(tempa[1]), SysConvert.ToInt32(tempa[2]), SysConvert.ToInt32(tempa[3]),
                    tempa[4], (ArrayList)p_WHPicParam2[i], p_Tip);
            }
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="p_Parent"></param>
        /// <param name="p_X"></param>
        /// <param name="p_Y"></param>
        /// <param name="p_Caption"></param>
        /// <param name="p_Value"></param>
        /// <param name="p_SectionParam"></param>
        private static void CreateOnePanel(GroupControl p_Parent, int p_X, int p_Y, int p_Width, int p_Height, string p_Caption, ArrayList p_SectionParam, ToolTip p_Tip)
        {
            GroupControl whpicGroup = new GroupControl();
            whpicGroup.Text = p_Caption;
            whpicGroup.Tag = p_Caption;
            whpicGroup.Left = p_X * m_MinPixel;
            whpicGroup.Top = p_Y * m_MinPixel;
            whpicGroup.Width = p_Width * m_MinPixel;
            whpicGroup.Height = p_Height * m_MinPixel;
            whpicGroup.AutoScroll = true;
            whpicGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            p_Parent.Controls.Add(whpicGroup);

            for (int i = 0; i < p_SectionParam.Count; i++)
            {
                string[] tempa = (string[])p_SectionParam[i];
                CreateOneSection(whpicGroup, SysConvert.ToInt32(tempa[0]), SysConvert.ToInt32(tempa[1]), SysConvert.ToInt32(tempa[2]), SysConvert.ToInt32(tempa[3]),
                    tempa[4], tempa[5], p_Tip);
            }

        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="p_Parent"></param>
        /// <param name="p_X"></param>
        /// <param name="p_Y"></param>
        /// <param name="p_Width"></param>
        /// <param name="p_Height"></param>
        /// <param name="p_Caption"></param>
        /// <param name="p_Value"></param>
        private static void CreateOneSection(GroupControl p_Parent, int p_X, int p_Y, int p_Width, int p_Height, string p_Caption, string p_MaxWeight, ToolTip p_Tip)
        {

            ProgressBarControl sectionBar = new ProgressBarControl();
            sectionBar.Tag = p_MaxWeight;
            sectionBar.Left = p_X * m_MinPixel;
            sectionBar.Top = (p_Y + m_DelLabel) * m_MinPixel;
            sectionBar.Width = p_Width * m_MinPixel;
            sectionBar.Height = (p_Height - m_DelLabel) * m_MinPixel;

            //			sectionBar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            //			sectionBar.Properties.EndColor = System.Drawing.Color.Cornsilk;
            //			sectionBar.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;

            sectionBar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            sectionBar.Properties.EndColor = Color.BurlyWood;//System.Drawing.Color.Cornsilk;
            sectionBar.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;

            sectionBar.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            sectionBar.Properties.LookAndFeel.UseWindowsXPTheme = false;
            sectionBar.Properties.ShowTitle = false;
            sectionBar.Properties.StartColor = System.Drawing.Color.BurlyWood;

            string tempTip = LoadWHStorgeQty(p_Caption).ToString();

            //SectionID = p_Caption;

            decimal wm = SysConvert.ToDecimal(p_MaxWeight);
            decimal ex = SysConvert.ToDecimal(tempTip);
            decimal per = 0;
            if (wm == 0)
            {
                if (ex != 0)
                {
                    per = 100;
                }
                else
                {
                    per = 0;
                }
            }
            else
            {
                per = SysConvert.ToDecimal((ex / wm) * 100, 0);
            }

            sectionBar.Text = SysConvert.ToInt32(per).ToString();

            //tempTip = tempTip+"/"+p_MaxWeight.ToString();
            tempTip = "最大存放：" + wm.ToString() + "KG" + " 已存放：" + tempTip + "KG" + " 还可存放：" + (wm - SysConvert.ToDecimal(tempTip)).ToString() + "KG";
            p_Tip.SetToolTip(sectionBar, tempTip);

            p_Parent.Controls.Add(sectionBar);
            Label lbl = new Label();
            lbl.DoubleClick += new System.EventHandler(lbl_DoubleClick);
            lbl.Left = m_DelLabel * m_MinPixel;
            lbl.Top = m_DelLabel * m_MinPixel + m_LabelPixel;
            lbl.Width = p_Width * m_MinPixel;
            lbl.Height = p_Height * m_MinPixel;//m_HeightLabel * m_MinPixel;
            lbl.Text = p_Caption;
            lbl.BackColor = Color.Transparent;
            lbl.Text += Environment.NewLine + per.ToString() + "%";

         
            p_Tip.SetToolTip(lbl, tempTip);

            

            sectionBar.Controls.Add(lbl);

           

            //lbl.DoubleClick += new EventHandler(lbl_DoubleClick);
           

            //Label lbl = new Label();
            //lbl.Left = p_X * m_MinPixel;
            //lbl.Top = p_Y * m_MinPixel + m_LabelPixel;
            //lbl.Width = p_Width * m_MinPixel;
            //lbl.Height = m_HeightLabel * m_MinPixel;
            //lbl.Text = p_Caption;
            //lbl.BackColor = Color.Transparent;
            //p_Parent.Controls.Add(lbl);
        }

        /// <summary>
        /// 双击显示库存详细信息
        /// </summary>
        private static void lbl_DoubleClick(object sender, System.EventArgs e)
        {
            //frmLoadWHStorge frm = new frmLoadWHStorge();
            //frm.WHID = WHID;
            ////frm.SectionID = SectionID;

            //frm.ShowDialog();

        }

        /// <summary>
        /// 加载库存批号数量
        /// </summary>
        private static decimal LoadWHStorgeQty(string p_SectionID)
        {
            decimal outd = 0;
            foreach (DataRow dr in m_StorgeData.Rows)
            {
                if (dr["SectionID"].ToString().ToUpper() == p_SectionID.ToUpper())
                {
                    outd = SysConvert.ToDecimal(dr["SQty"]);
                    break;
                }
            }

            return outd;
        }

        /// <summary>
        /// 获得库存数据
        /// </summary>
        /// <param name="p_WHID"></param>
        /// <returns></returns>
        private static DataTable GetStorge(string p_WHID)
        {
            string sql = "SELECT SectionID,SUM(Qty) SQty FROM WH_Storge WHERE WHID=" + SysString.ToDBString(p_WHID) + " GROUP BY SectionID ORDER BY SectionID";//SELECT Batch,ItemCode,Qty,SBitID
            DataTable dt = SysUtils.Fill(sql);
            return dt;
        }



        #region 位相关
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="p_Parent"></param>
        /// <param name="p_SBitParam"></param>
        /// <param name="p_Tip"></param>
        private static void CreateSBit(GroupControl p_Parent, ArrayList p_SBitParam, ToolTip p_Tip)
        {
            for (int i = 0; i < p_SBitParam.Count; i++)
            {
                string[] tempa = (string[])p_SBitParam[i];
                CreateOneSBit(p_Parent, SysConvert.ToInt32(tempa[0]), SysConvert.ToInt32(tempa[1]), SysConvert.ToInt32(tempa[2]), SysConvert.ToInt32(tempa[3]),
                    tempa[4], tempa[5], p_Tip);
            }
        }       

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="p_Parent"></param>
        /// <param name="p_X"></param>
        /// <param name="p_Y"></param>
        /// <param name="p_Width"></param>
        /// <param name="p_Height"></param>
        /// <param name="p_Caption"></param>
        /// <param name="p_Value"></param>
        private static void CreateOneSBit(GroupControl p_Parent, int p_X, int p_Y, int p_Width, int p_Height, string p_Caption, string p_MaxWeight, ToolTip p_Tip)
        {

            ProgressBarControl sbitBar = new ProgressBarControl();
            sbitBar.Tag = p_MaxWeight;
            sbitBar.Left = p_X * m_MinPixel;
            sbitBar.Top = (p_Y + m_DelLabel) * m_MinPixel;
            sbitBar.Width = p_Width * m_MinPixel;
            sbitBar.Height = (p_Height - m_DelLabel) * m_MinPixel;

            sbitBar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            sbitBar.Properties.EndColor = System.Drawing.Color.Cornsilk;
            sbitBar.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            sbitBar.Properties.LookAndFeel.UseWindowsXPTheme = false;
            sbitBar.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            sbitBar.Properties.ShowTitle = false;
            sbitBar.Properties.StartColor = System.Drawing.Color.BurlyWood;
            sbitBar.Text = "100";
            string tempTip = LoadWHStorgeLotQty(p_Caption);
            p_Tip.SetToolTip(sbitBar, tempTip);

            p_Parent.Controls.Add(sbitBar);
            Label lbl = new Label();
            lbl.Left = m_DelLabel * m_MinPixel;
            lbl.Top = m_DelLabel * m_MinPixel + m_LabelPixel;
            lbl.Width = p_Width * m_MinPixel;
            lbl.Height = p_Height * m_MinPixel;//m_HeightLabel * m_MinPixel;
            lbl.Text = p_Caption;
            lbl.BackColor = Color.Transparent;
            lbl.Text += Environment.NewLine + tempTip;


            p_Tip.SetToolTip(lbl, tempTip);

            sbitBar.Controls.Add(lbl);

            //Label lbl = new Label();
            //lbl.Left = p_X * m_MinPixel;
            //lbl.Top = p_Y * m_MinPixel + m_LabelPixel;
            //lbl.Width = p_Width * m_MinPixel;
            //lbl.Height = m_HeightLabel * m_MinPixel;
            //lbl.Text = p_Caption;
            //lbl.BackColor = Color.Transparent;
            //p_Parent.Controls.Add(lbl);
        }

        /// <summary>
        /// 加载库存批号数量
        /// </summary>
        private static string LoadWHStorgeLotQty(string p_SBitID)
        {
            string outstr = string.Empty;
            ArrayList al = new ArrayList();//临时ArrayList
            foreach (DataRow dr in m_StorgeData.Rows)
            {
                if (dr["SBitID"].ToString().ToUpper() == p_SBitID.ToUpper())
                {
                    string[] tempa = new string[] { dr["Batch"].ToString(), dr["Qty"].ToString(), dr["SBitCellID"].ToString() };
                    al.Add(tempa);

                    //if (outstr != string.Empty)
                    //{
                    //    outstr += "  ";
                    //}
                    //outstr += dr["Batch"].ToString() + "("+dr["Qty"].ToString()+")";
                }
            }

            string[,] lastA = new string[al.Count, 3];//最终序号

            for (int i = 0; i < al.Count; i++)//复制数据
            {
                string[] tempa = (string[])al[i];
                lastA[i, 0] = tempa[0];
                lastA[i, 1] = tempa[1];
                lastA[i, 2] = tempa[2];
            }

            int moveIndex = 0;
            string curBatch = string.Empty;
            string[] tempMoveA = new string[] { "", "", "" };

            //整理无相邻批号的数据到最后BEGIN
            for (int i = 0; i < al.Count; i++)
            {
                curBatch = lastA[i, 0].ToUpper();
                moveIndex = i;

            }
            //整理无相邻批号的数据到最后EN

            //整理相邻批号在一起BEGIN
            for (int i = 0; i < al.Count; i++)
            {
                curBatch = lastA[i, 0].ToUpper();
                moveIndex = i;

                for (int j = i + 1; j < al.Count; j++)
                {
                    if (lastA[j, 2].ToUpper() == curBatch)//找到临近的批号数据
                    {
                        moveIndex = j;
                        break;
                    }
                }
                if (moveIndex != i && moveIndex != i + 1)//需要移动到相邻批号数据
                {
                    for (int k = 0; k < 3; k++)//把下一行数据移动到临时行
                    {
                        tempMoveA[k] = lastA[i + 1, k];
                    }
                    for (int k = 0; k < 3; k++)//把临近批号数据移动到下一行
                    {
                        lastA[i + 1, k] = lastA[moveIndex, k];
                    }
                    for (int k = 0; k < 3; k++)//把临时行数据移动到邻近批号行;
                    {
                        lastA[moveIndex, k] = tempMoveA[k];
                    }
                }
            }
            //整理相邻批号在一起END

            for (int i = 0; i < al.Count; i++)
            {
                if (outstr != string.Empty)
                {
                    outstr += "  ";
                }
                outstr += lastA[i, 0] + "(" + lastA[i, 1] + ")";
            }
            return outstr;
        }
        #endregion

        /// <summary>
        /// 获得库存数据
        /// </summary>
        /// <param name="p_WHID"></param>
        /// <returns></returns>
        private static DataTable GetStorge1(string p_WHID)
        {
            string sql = "SELECT Batch,ItemCode,Qty,SBitID,SBitCellID FROM WH_Storge WHERE WHID=" + SysString.ToDBString(p_WHID) + " ORDER BY SBitID,SBitCellID";
            DataTable dt = SysUtils.Fill(sql);
            return dt;
        }
        #endregion
    }
}
