using System;
using System.Drawing;
using System.Data;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using System.Windows.Forms;


namespace MLTERP
{
    /// <summary>
    /// 仓库审核颜色处理类
    /// </summary>
    public class WHCheckStatusProc
    {
        private static bool m_ColorIniFlag = false;//颜色是否初始化标志
        public static bool ColorIniFlag
        {
            get
            {
                if (!m_ColorIniFlag)//如果没有初始化则进行初始化颜色
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
        /// 初始化颜色
        /// </summary>
        private static void ColorIniProc()
        {
            string sql = "SELECT ID,Name,ColorStr FROM Enum_WHCheckStatus WHERE ID>=0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            ColorStatusID = new int[dt.Rows.Count];
            ColorStatusName = new string[dt.Rows.Count];
            ColorStatusColor = new Color[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ColorStatusID[i] = SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
                ColorStatusName[i] = dt.Rows[i]["Name"].ToString();
                string[] tempstr = dt.Rows[i]["ColorStr"].ToString().Split(',');
                if (tempstr.Length == 3)//长度为3
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
        /// 初始化控件颜色
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
        /// 设置Grid行颜色
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
}
