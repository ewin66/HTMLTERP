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
    /// ���ܣ��ֿ�ƽ��ͼ����
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2007-11-22
    /// </summary>
    class WHPlaneProc
    {
        #region ���ڲ���
        static int m_MinPixel = 10;//ÿ��Ԫ�����������
        static int m_LabelPixel = 5;//ÿ��Ԫ�����������
        static int m_DelLabel = 0;//Label�����λ��
        //static int m_HeightLabel = 2;//Label�ĸ߶�
        static DataTable m_StorgeData = new DataTable();

        static string WHID = string.Empty;//�ֿ�����
        static string SectionID = string.Empty;//�ֿ�������
        #endregion

        #region �ⲿ���÷���

        #region λ���
        /// <summary>
        /// ���òֿ�
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
        /// ���òֿ�
        /// </summary>
        public static void CallWH(string p_WHID, GroupControl p_Parent, ToolTip p_Tip)
        {
            string sql = "SELECT WHPicID,PosX,PosY,SizeWidth,SizeHeight FROM WH_WHPic WHERE WHID=" + SysString.ToDBString(p_WHID) + " AND SizeWidth>0 AND SizeHeight>0 ORDER BY WHPicID ";
            DataTable dtPic = SysUtils.Fill(sql);//ƽ������

            sql = "SELECT WHPicID,SectionID,WeightMax,PosY,PosX,SizeWidth,SizeHeight FROM WH_Section WHERE WHID=" + SysString.ToDBString(p_WHID) + " AND SizeWidth>0 AND SizeHeight>0 ORDER BY WHPicID,SectionID";
            DataTable dtSection = SysUtils.Fill(sql);//ƽ������

            ArrayList wpicParm = new ArrayList();
            ArrayList wpicParm2 = new ArrayList();

            foreach (DataRow dr in dtPic.Rows)
            {
                ArrayList sectionParm = new ArrayList();//ƽ����λ��
                foreach (DataRow drSection in dtSection.Rows)
                {
                    if (dr["WHPicID"].ToString().ToUpper() == drSection["WHPicID"].ToString().ToUpper())//�ҵ�һ�µ�����
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
        /// ����һ����λ
        /// </summary>
        public static void CallSBit()
        {
        }
        #endregion

        #region ϵͳ������
        /// <summary>
        /// ���
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
        /// �����ܵ�������ͼ
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
        /// ����
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
        /// ����
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
            tempTip = "����ţ�" + wm.ToString() + "KG" + " �Ѵ�ţ�" + tempTip + "KG" + " ���ɴ�ţ�" + (wm - SysConvert.ToDecimal(tempTip)).ToString() + "KG";
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
        /// ˫����ʾ�����ϸ��Ϣ
        /// </summary>
        private static void lbl_DoubleClick(object sender, System.EventArgs e)
        {
            //frmLoadWHStorge frm = new frmLoadWHStorge();
            //frm.WHID = WHID;
            ////frm.SectionID = SectionID;

            //frm.ShowDialog();

        }

        /// <summary>
        /// ���ؿ����������
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
        /// ��ÿ������
        /// </summary>
        /// <param name="p_WHID"></param>
        /// <returns></returns>
        private static DataTable GetStorge(string p_WHID)
        {
            string sql = "SELECT SectionID,SUM(Qty) SQty FROM WH_Storge WHERE WHID=" + SysString.ToDBString(p_WHID) + " GROUP BY SectionID ORDER BY SectionID";//SELECT Batch,ItemCode,Qty,SBitID
            DataTable dt = SysUtils.Fill(sql);
            return dt;
        }



        #region λ���
        /// <summary>
        /// ����
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
        /// ����
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
        /// ���ؿ����������
        /// </summary>
        private static string LoadWHStorgeLotQty(string p_SBitID)
        {
            string outstr = string.Empty;
            ArrayList al = new ArrayList();//��ʱArrayList
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

            string[,] lastA = new string[al.Count, 3];//�������

            for (int i = 0; i < al.Count; i++)//��������
            {
                string[] tempa = (string[])al[i];
                lastA[i, 0] = tempa[0];
                lastA[i, 1] = tempa[1];
                lastA[i, 2] = tempa[2];
            }

            int moveIndex = 0;
            string curBatch = string.Empty;
            string[] tempMoveA = new string[] { "", "", "" };

            //�������������ŵ����ݵ����BEGIN
            for (int i = 0; i < al.Count; i++)
            {
                curBatch = lastA[i, 0].ToUpper();
                moveIndex = i;

            }
            //�������������ŵ����ݵ����EN

            //��������������һ��BEGIN
            for (int i = 0; i < al.Count; i++)
            {
                curBatch = lastA[i, 0].ToUpper();
                moveIndex = i;

                for (int j = i + 1; j < al.Count; j++)
                {
                    if (lastA[j, 2].ToUpper() == curBatch)//�ҵ��ٽ�����������
                    {
                        moveIndex = j;
                        break;
                    }
                }
                if (moveIndex != i && moveIndex != i + 1)//��Ҫ�ƶ���������������
                {
                    for (int k = 0; k < 3; k++)//����һ�������ƶ�����ʱ��
                    {
                        tempMoveA[k] = lastA[i + 1, k];
                    }
                    for (int k = 0; k < 3; k++)//���ٽ����������ƶ�����һ��
                    {
                        lastA[i + 1, k] = lastA[moveIndex, k];
                    }
                    for (int k = 0; k < 3; k++)//����ʱ�������ƶ����ڽ�������;
                    {
                        lastA[moveIndex, k] = tempMoveA[k];
                    }
                }
            }
            //��������������һ��END

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
        /// ��ÿ������
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
