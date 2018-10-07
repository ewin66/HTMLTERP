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
        #region 颜色处理
        /// <summary>
        /// 获得配置颜色
        /// </summary>
        public static Color GetWHColor(int p_WHQtyID)
        {
            string p_StepID = ((int)WHStep.入库).ToString();

            switch (p_WHQtyID)
            {
                case (int)WHQtyPos.增加:
                    p_StepID = ((int)WHStep.入库).ToString();
                    break;
                case (int)WHQtyPos.减少:
                    p_StepID = ((int)WHStep.出库).ToString();
                    break;
                case (int)WHQtyPos.有时增有时减:
                    p_StepID = ((int)WHStep.入库出库).ToString();
                    break;
            }

            Color outcolor = GetColorByStep(p_StepID);
            return outcolor;
        }





        /// <summary>
        /// 颜色初始化标志
        /// </summary>
        private static bool StepColorIniFlag = false;
        /// <summary>
        /// 颜色表
        /// </summary>
        public static DataTable StepColorDt;
        /// <summary>
        /// 颜色初始化
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
        /// 根据STEPID获得颜色
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
        #region 颜色处理
        /// <summary>
        /// 获得配置颜色超低预警
        /// </summary>
        /// <param name="curQty">当前库存数量</param>
        /// <param name="alarMQty">设置库存量</param>
        /// <param name="alarmPer">安全百分比</param>
        /// <returns></returns>
        public static Color GetWHColorLow(decimal curQty, decimal alarMQty, int alarmPer)
        {
            string p_StepID = "";
            if (curQty <= alarMQty)
            {
                p_StepID = ((int)WHStep.安全库存到达警示).ToString();
            }
            else if (curQty <= alarMQty * (1m + alarmPer / 100m))//预警
            {
                p_StepID = ((int)WHStep.安全库存提前预警).ToString();
            }


            Color outcolor = GetColorByStep(p_StepID);
            return outcolor;
        }

        /// <summary>
        /// 获得配置颜色超高预警
        /// </summary>
        public static Color GetWHColorHigh(decimal curQty, decimal alarMQty, int alarmPer)
        {
            string p_StepID = "";
            if (curQty >= alarMQty)
            {
                p_StepID = ((int)WHStep.安全库存到达警示).ToString();
            }
            else if (curQty >= alarMQty * (1m - alarmPer / 100m))//预警
            {
                p_StepID = ((int)WHStep.安全库存提前预警).ToString();
            }


            Color outcolor = GetColorByStep(p_StepID);
            return outcolor;
        }





        /// <summary>
        /// 颜色初始化标志
        /// </summary>
        private static bool StepColorIniFlag = false;
        /// <summary>
        /// 颜色表
        /// </summary>
        public static DataTable StepColorDt;
        /// <summary>
        /// 颜色初始化
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
        /// 根据STEPID获得颜色
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
