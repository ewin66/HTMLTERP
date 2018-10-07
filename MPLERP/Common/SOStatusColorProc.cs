using System;
using System.Drawing;
using System.Data;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using System.Windows.Forms;

namespace MLTERP
{
    #region ������ɫ������
    /// <summary>
	/// ������ɫ������
	/// </summary>
    public class SOStatusColorProc
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
            string sql = "SELECT ID,Name,ColorStr FROM Enum_SOStatus WHERE ID<>0 ORDER BY ID";
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

    #region ɫ����ɫ������
    /// <summary>
    /// ɫ����ɫ������
    /// </summary>
    public class SOColorStatusColorProc
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
            string sql = "SELECT ID,Name,ColorStr FROM Enum_SOColorStatus WHERE ID<>0 ORDER BY Code";
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
        /// ɫ��״̬
        /// </summary>
        /// <param name="p_Dt">���ݱ�</param>
        public static void ProcTecStatus(DataTable p_Dt)
        {
            foreach (DataRow dr in p_Dt.Rows)
            {
                if (dr["SOStatus"].ToString() == "")
                {
                    dr["SOStatus"] = ColorStatusName[1];
                }
            }
        }

        /// <summary>
        /// �����ɫ
        /// </summary>
        /// <param name="p_Dt1">����ʱ��</param>
        /// <param name="p_Dt2">����ʱ��</param>
        /// <returns>true/false</returns>
        public static Color GetGridRowBackColor(string p_str)
        {
            if (p_str == "����Ⱦ��")
            {
                return GetGridRowBackColor(2);
            }
            else if (p_str == "У��")
            {
                return GetGridRowBackColor(3);
            }
            else if (p_str == "�ش�")
            {
                return GetGridRowBackColor(4);
            }
            else if (p_str == "OK")
            {
                return GetGridRowBackColor(5);
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

    #region �����¿��˱���Ԥ���ں�ʵ�ʽ��ڴ�����
     public class SOCheckRptColorProc
    {
         /// <summary>
         /// �����ɫ
         /// </summary>
         /// <param name="p_YDate"></param>
         /// <param name="p_SDate"></param>
         /// <returns></returns>
         public static Color GetGridRowBackColor(string p_YDate,string p_SDate)
         {
             DateTime yDate = SysConvert.ToDateTime(p_YDate).Date;
             DateTime sDate = DateTime.Now.Date;
             if (p_SDate != string.Empty)
             {
                 sDate = SysConvert.ToDateTime(p_SDate).Date;
             }
             if (yDate < sDate)
             {
                 return Color.Yellow;
             }
             return Color.White;
         }
    }
    #endregion
}
