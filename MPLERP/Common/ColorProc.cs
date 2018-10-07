using System;
using System.Drawing;
using System.Data;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using System.Windows.Forms;
using HttSoft.MLTERP.Sys;

namespace MLTERP
{
    #region �ɹ�״̬��ɫ������
    /// <summary>
    /// �ɹ�״̬��ɫ������
    /// </summary>
    class ItemBuyStatusProc
    {
        private static bool m_ColorIniFlag = false;//��ɫ�Ƿ��ʼ����־
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }

        public static int DayNum = 0;//Ԥ������
        public static decimal FinishPer = 0m;//��ɰٷ���
        public static decimal StartFinishQty = 0m;//����������ʼͳ��,������������������ֱ�ӱ�ʾ���

        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;

        public static DataTable ColorStatusDt;
        /// <summary>
        /// ��ʼ����ɫ
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Name,ColorStr,DayNum,FinishPer,StartFinishQty FROM Enum_ItemBuyStatus WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
            ColorStatusDt = dt;
            if (dt.Rows.Count != 0)
            {
                DayNum = SysConvert.ToInt32(dt.Rows[0]["DayNum"]);
                FinishPer = SysConvert.ToDecimal(dt.Rows[0]["FinishPer"]);
                StartFinishQty = SysConvert.ToDecimal(dt.Rows[0]["StartFinishQty"]);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//����Ϊ3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// ��ʼ���ؼ���ɫ
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }


        #region ����״̬����
        /// <summary>
        /// ����״̬����
        /// </summary>
        /// <param name="p_Dt">���ݱ�</param>
        public static void ProcColorStatusName(DataTable p_Dt)
        {

            decimal qty;
            decimal inwhqty;
            DateTime dt1;
            DateTime dt2;
            string statusname = string.Empty;
            foreach (DataRow dr in p_Dt.Rows)
            {
                qty = SysConvert.ToDecimal(dr["Qty"]);
                inwhqty = SysConvert.ToDecimal(dr["TotalRecQty"]);
                dt1 = SysConvert.ToDateTime(dr["ReqDate"]);
                dt2 = SysConvert.ToDateTime(dr["ReceivedDate"]);

                if (SysConvert.ToInt32(dr["StatusFlag"]) == 1)
                {
                    dr["FormStatusName"] = dr["StatusName"];
                }
                else
                {
                    if (inwhqty >= qty *SysConvert.ToDecimal(0.8) || (qty < StartFinishQty && inwhqty > 0))//�г����ٷֱ����������
                    {
                        if (dt1 < dt2)
                        {
                            statusname = ColorStatusName[4];//��ʱ���
                        }
                        else//��ʱ���
                        {
                            statusname = ColorStatusName[2];
                        }
                    }
                    else
                    {
                        DateTime chkTime = dt1;

                        TimeSpan ts = DateTime.Now - chkTime;
                        if (ts.Days > 0)//�Ѿ�����
                        {
                            statusname = ColorStatusName[3];
                        }
                        else if (ts.Days > 0 - DayNum)//Ԥ��
                        {
                            statusname = ColorStatusName[1];
                        }
                        else
                        {
                            statusname = ColorStatusName[0];
                        }


                    }

                    dr["FormStatusName"] = statusname;
                }
            }
        }
        #endregion
    }
    #endregion


    #region ɫ������վ����ɫ������
    /// <summary>
    /// ɫ������վ����ɫ������
    /// </summary>
    class ColorCardStatusProc
    {
        private static bool m_ColorIniFlag = false;//��ɫ�Ƿ��ʼ����־
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }


        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;

        public static DataTable ColorStatusDt;
        /// <summary>
        /// ��ʼ����ɫ
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Name,ColorStr FROM Enum_ColorCardStatus WHERE ID<>0  ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusDt = dt;

            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//����Ϊ3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// ��ʼ���ؼ���ɫ
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }



    }
    #endregion

    #region ���۶���״̬��ɫ������
    /// <summary>
    /// ���۶���״̬��ɫ������
    /// </summary>
    class SaleOrderStatusProc
    {
        private static bool m_ColorIniFlag = false;//��ɫ�Ƿ��ʼ����־
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }

        public static int DayNum = 0;//Ԥ������
        public static decimal FinishPer = 0m;//��ɰٷ���
        public static decimal StartFinishQty = 0m;//����������ʼͳ��,������������������ֱ�ӱ�ʾ���

        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;


        public static DataTable ColorStatusDt;
        /// <summary>
        /// ��ʼ����ɫ
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Name,ColorStr,DayNum,FinishPer,StartFinishQty FROM Enum_OrderStatus WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
            ColorStatusDt = dt;
            if (dt.Rows.Count != 0)
            {
                DayNum = SysConvert.ToInt32(dt.Rows[0]["DayNum"]);
                FinishPer = SysConvert.ToDecimal(dt.Rows[0]["FinishPer"]);
                StartFinishQty = SysConvert.ToDecimal(dt.Rows[0]["StartFinishQty"]);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//����Ϊ3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// ��ʼ���ؼ���ɫ
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }


        #region ����״̬����
        /// <summary>
        /// ����״̬����
        /// </summary>
        /// <param name="p_Dt">���ݱ�</param>
        public static void ProcColorStatusName(DataTable p_Dt)
        {

            decimal qty;
            decimal inwhqty;
            DateTime dt1;
            DateTime dt2;
            string statusname = string.Empty;
            foreach (DataRow dr in p_Dt.Rows)
            {
                if (SysConvert.ToInt32(dr["StatusFlag"]) == 1)
                {
                    dr["FormStatusName"] = dr["StatusName"];
                }
                else
                {

                    qty = SysConvert.ToDecimal(dr["Qty"]);
                    inwhqty = SysConvert.ToDecimal(dr["TotalRecQty"]);
                    dt1 = SysConvert.ToDateTime(dr["DtsReqDate"]);
                    dt2 = SysConvert.ToDateTime(dr["ReceivedDate"]);


                    if (inwhqty >= qty * FinishPer || (qty < StartFinishQty && inwhqty > 0))//�г����ٷֱ����������
                    {
                        if (dt1 < dt2)
                        {
                            statusname = ColorStatusName[4];//��ʱ���
                        }
                        else//��ʱ���
                        {
                            statusname = ColorStatusName[2];
                        }
                    }
                    else
                    {
                        DateTime chkTime = dt1;

                        TimeSpan ts = DateTime.Now - chkTime;
                        if (ts.Days > 0)//�Ѿ�����
                        {
                            statusname = ColorStatusName[3];
                        }
                        else if (ts.Days > 0 - DayNum)//Ԥ��
                        {
                            statusname = ColorStatusName[1];
                        }
                        else
                        {
                            statusname = ColorStatusName[0];
                        }


                    }

                    dr["FormStatusName"] = statusname;
                }
                
            }
            
        }
        #endregion
    }
    #endregion

    #region ���۶���վ����ɫ������
    /// <summary>
    /// ���۶���վ����ɫ������
    /// </summary>
    class SaleOrderStepProc
    {
        private static bool m_ColorIniFlag = false;//��ɫ�Ƿ��ʼ����־
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }

     
        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;

        public static DataTable ColorStatusDt;
        /// <summary>
        /// ��ʼ����ɫ
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Name,ColorStr FROM Enum_OrderStep WHERE ID<>0  AND ShowFlag=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusDt = dt;

            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//����Ϊ3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// ��ʼ���ؼ���ɫ
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }


     
    }
    #endregion

    #region �ֿ���ɫ������
    /// <summary>
    /// �ֿ���ɫ������
    /// </summary>
    public class WHIOStatusProc
    {
        private static bool m_ColorIniFlag = false;//��ɫ�Ƿ��ʼ����־
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }

        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;
        /// <summary>
        /// ��ʼ����ɫ
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,ColorCaption,ColorStr FROM Enum_WHQtyPos WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["ColorCaption"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//����Ϊ3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }
            }
        }
        /// <summary>
        /// ��ʼ���ؼ���ɫ
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }


        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }
    }
    #endregion

    #region ��Ʒ�����ѯ��ɫ������
    /// <summary>
    /// ��Ʒ�����ѯ��ɫ������
    /// </summary>
    class PackBoxStatusProc
    {
        private static bool m_ColorIniFlag = false;//��ɫ�Ƿ��ʼ����־
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }


        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;
        /// <summary>
        /// ��ʼ����ɫ
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Code,Name,ColorStr FROM Enum_BoxStatus WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
       
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//����Ϊ3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// ��ʼ���ؼ���ɫ
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }


        
    }
    #endregion

    #region �Ұ��ѯ��ɫ������
    /// <summary>
    /// �Ұ��ѯ��ɫ������
    /// </summary>
    class ItemGBQuery
    {
        private static bool m_ColorIniFlag = false;//��ɫ�Ƿ��ʼ����־
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }


        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;
        /// <summary>
        /// ��ʼ����ɫ
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Code,Name,ColorStr FROM Enum_GBStatus WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//����Ϊ3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// ��ʼ���ؼ���ɫ
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }



    }
    #endregion

    #region �Ұ����״̬��ɫ������
    /// <summary>
    /// �ɹ�״̬��ɫ������
    /// </summary>
    class GBDYStatusProc
    {
        private static bool m_ColorIniFlag = false;//��ɫ�Ƿ��ʼ����־
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }

       
        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;
        /// <summary>
        /// ��ʼ����ɫ
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Name,ColorStr FROM Enum_DYStatus WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//����Ϊ3
                {
                    ColorStatusColor[i] = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    ColorStatusColor[i] = Color.White;
                }

            }
        }

        /// <summary>
        /// ��ʼ���ؼ���ɫ
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }


       
    }
    #endregion

    #region ������״̬��ɫ������
    /// <summary>
    /// �ɹ�״̬��ɫ������
    /// </summary>
    class FHFormStatusProc
    {
        private static bool m_ColorIniFlag = false;//��ɫ�Ƿ��ʼ����־
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }


        private static int[] ColorStatusID;
        public static string[] ColorStatusName;
        public static Color[] ColorStatusColor;
        /// <summary>
        /// ��ʼ����ɫ
        /// </summary>
        private static void ColorIniProc()
        {
          
            ColorStatusID = new int[2];
            ColorStatusName = new string[2];
            ColorStatusColor = new Color[2];

            ColorStatusID[0] = 0;
            ColorStatusID[1]=1;

            ColorStatusName[0] = "δ����";
            ColorStatusName[1] = "�ѷ���";

            ColorStatusColor[0] = Color.FromArgb(255,255,255);
            ColorStatusColor[1] = Color.FromArgb(255, 128, 255);

            
        }

        /// <summary>
        /// ��ʼ���ؼ���ɫ
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }



    }
    #endregion

    #region ���Ԥ��״̬��ɫ������
    /// <summary>
    /// ���Ԥ��״̬��ɫ������
    /// </summary>
    class StorgeAlarmStatusProc
    {
        private static bool m_ColorIniFlag = false;//��ɫ�Ƿ��ʼ����־
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//���û�г�ʼ������г�ʼ����ɫ
                {
                    ColorIniProc();
                    m_ColorIniFlag = true;
                }
                return m_ColorIniFlag;
            }
        }


        private static int[] ColorStatusID;
        private static string[] ColorStatusName;
        private static Color[] ColorStatusColor;
        /// <summary>
        /// ��ʼ����ɫ
        /// </summary>
        private static void ColorIniProc()
        {

            ColorStatusID = new int[3];
            ColorStatusName = new string[3];
            ColorStatusColor = new Color[3];

            ColorStatusID[0] = 0;
            ColorStatusID[1] = 1;
            ColorStatusID[2] = 2;

            ColorStatusName[0] = "����";
            ColorStatusName[1] = "������Ԥ��";
            ColorStatusName[2] = "������Ԥ��";

            ColorStatusColor[0] = Color.FromArgb(255, 255, 255);
            ColorStatusColor[1] = Color.FromArgb(255, 128, 255);
            ColorStatusColor[2] = Color.FromArgb(192, 192, 0);

        }

        /// <summary>
        /// ��ʼ���ؼ���ɫ
        /// </summary>
        /// <param name="p_TxtColor"></param>
        public static void ColorIniTextBox(TextBox[] p_TxtColor)
        {
            for (int i = 0; i < p_TxtColor.Length; i++)
            {
                if (ColorStatusID.Length > i)
                {
                    p_TxtColor[i].Text = ColorStatusName[i];
                    p_TxtColor[i].BackColor = ColorStatusColor[i];

                }
                else
                {
                    p_TxtColor[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        /// <param name="p_Dt1"></param>
        /// <param name="p_Dt2"></param>
        /// <param name="p_RecQty"></param>
        /// <returns></returns>
        public static Color GetGridRowBackColor(string p_StatusName)
        {
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                if (p_StatusName == ColorStatusName[i])
                {
                    return GetGridRowBackColor(ColorStatusID[i]);
                }
            }

            return GetGridRowBackColor(1);
        }

        /// <summary>
        /// ����Grid����ɫ
        /// </summary>
        public static Color GetGridRowBackColor(int p_ColorStatusID)
        {
            int findsort = -1;
            for (int i = 0; i < ColorStatusID.Length; i++)
            {
                if (ColorStatusID[i] == p_ColorStatusID)
                {
                    findsort = i;
                    break;
                }
            }
            if (findsort != -1)
            {
                return ColorStatusColor[findsort];
            }
            return Color.White;
        }



    }
    #endregion
}
