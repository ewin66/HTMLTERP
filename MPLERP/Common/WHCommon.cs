using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HttSoft.Framework;
using HttSoft.MLTERP.Sys;
using System.Drawing;


namespace MLTERP
{
    class WHCommon
    {
        #region ��ɫ����
        /// <summary>
        /// ���������ɫ
        /// </summary>
        public static Color GetWHColor(int p_WHQtyID)
        {
            string p_StepID = ((int)WHStep.���).ToString();

            switch (p_WHQtyID)
            {
                case (int)WHQtyPos.����:
                    p_StepID = ((int)WHStep.���).ToString();
                    break;
                case (int)WHQtyPos.����:
                    p_StepID = ((int)WHStep.����).ToString();
                    break;
                case (int)WHQtyPos.��ʱ����ʱ��:
                    p_StepID = ((int)WHStep.������).ToString();
                    break;
            }

            Color outcolor = GetColorByStep(p_StepID);
            return outcolor;
        }





        /// <summary>
        /// ��ɫ��ʼ����־
        /// </summary>
        private static bool StepColorIniFlag = false;
        /// <summary>
        /// ��ɫ��
        /// </summary>
        public static DataTable StepColorDt;
        /// <summary>
        /// ��ɫ��ʼ��
        /// </summary>
        public static void StepColorIni()
        {
            if (!StepColorIniFlag)
            {
                StepColorDt = SysUtils.Fill("SELECT ColorStr,StepID FROM Data_Step WHERE StepTypeID=80");
            }
            StepColorIniFlag = true;
        }
        /// <summary>
        /// ����STEPID�����ɫ
        /// </summary>
        /// <param name="p_StepID"></param>
        /// <returns></returns>
        public static Color GetColorByStep(string p_StepID)
        {
            Color outcolor = Color.White;
            if (!StepColorIniFlag)
            {
                StepColorIni();
            }
            foreach (DataRow dr in StepColorDt.Rows)
            {
                if (p_StepID == dr["StepID"].ToString())
                {
                    string[] colorrgb = dr["ColorStr"].ToString().Split(',');
                    if (colorrgb.Length == 3)
                    {
                        outcolor = Color.FromArgb(SysConvert.ToInt32(colorrgb[0]), SysConvert.ToInt32(colorrgb[1]), SysConvert.ToInt32(colorrgb[2]));
                    }
                    break;
                }
            }

            return outcolor;
        }

        #endregion
    }


    class WHAlarmCommon
    {
        #region ��ɫ����
        /// <summary>
        /// ���������ɫ����Ԥ��
        /// </summary>
        /// <param name="curQty">��ǰ�������</param>
        /// <param name="alarMQty">���ÿ����</param>
        /// <param name="alarmPer">��ȫ�ٷֱ�</param>
        /// <returns></returns>
        public static Color GetWHColorLow(decimal curQty, decimal alarMQty, int alarmPer)
        {
            string p_StepID = "";
            if (curQty <= alarMQty)
            {
                p_StepID = ((int)WHStep.��ȫ��浽�ﾯʾ).ToString();
            }
            else if (curQty <= alarMQty * (1m + alarmPer / 100m))//Ԥ��
            {
                p_StepID = ((int)WHStep.��ȫ�����ǰԤ��).ToString();
            }


            Color outcolor = GetColorByStep(p_StepID);
            return outcolor;
        }

        /// <summary>
        /// ���������ɫ����Ԥ��
        /// </summary>
        public static Color GetWHColorHigh(decimal curQty, decimal alarMQty, int alarmPer)
        {
            string p_StepID = "";
            if (curQty >= alarMQty)
            {
                p_StepID = ((int)WHStep.��ȫ��浽�ﾯʾ).ToString();
            }
            else if (curQty >= alarMQty * (1m - alarmPer / 100m))//Ԥ��
            {
                p_StepID = ((int)WHStep.��ȫ�����ǰԤ��).ToString();
            }


            Color outcolor = GetColorByStep(p_StepID);
            return outcolor;
        }





        /// <summary>
        /// ��ɫ��ʼ����־
        /// </summary>
        private static bool StepColorIniFlag = false;
        /// <summary>
        /// ��ɫ��
        /// </summary>
        public static DataTable StepColorDt;
        /// <summary>
        /// ��ɫ��ʼ��
        /// </summary>
        public static void StepColorIni()
        {
            if (!StepColorIniFlag)
            {
                StepColorDt = SysUtils.Fill("SELECT ColorStr,StepID FROM Data_Step WHERE StepTypeID=81");
            }
            StepColorIniFlag = true;
        }
        /// <summary>
        /// ����STEPID�����ɫ
        /// </summary>
        /// <param name="p_StepID"></param>
        /// <returns></returns>
        public static Color GetColorByStep(string p_StepID)
        {
            Color outcolor = Color.White;
            if (!StepColorIniFlag)
            {
                StepColorIni();
            }
            foreach (DataRow dr in StepColorDt.Rows)
            {
                if (p_StepID == dr["StepID"].ToString())
                {
                    string[] colorrgb = dr["ColorStr"].ToString().Split(',');
                    if (colorrgb.Length == 3)
                    {
                        outcolor = Color.FromArgb(SysConvert.ToInt32(colorrgb[0]), SysConvert.ToInt32(colorrgb[1]), SysConvert.ToInt32(colorrgb[2]));
                    }
                    break;
                }
            }

            return outcolor;
        }

        #endregion
    }
}
