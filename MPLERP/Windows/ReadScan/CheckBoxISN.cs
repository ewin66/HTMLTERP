using System;
using System.Collections.Generic;
using System.Text;
using HttSoft.Framework;
using System.Data;
using System.Windows.Forms;

namespace MLTERP
{
    public static class CheckBoxISN
    {
        //条码校验分以下几种
        /*
         1：条码是否有效
         2：条码是否入库
         3：条码是否入库
         4：条码是否出库
         5：条码是否已经打包
         6：条码是否被拆分
         7：
         8： 
         9： 
         10： 
         11： 
        */
        /// <summary>
        /// 条码是否有效
        /// </summary>
        /// <param name="p_ISN"></param>
        /// <returns></returns>
        public static bool CheckUse(string p_ISN)
        {
            string sql = "SELECT ID,CFFlag FROM WO_Fabric WHERE ISN=" + SysString.ToDBString(p_ISN);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 1)
            {
                MessageBox.Show("提示", "条码不存在请检查", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (SysConvert.ToInt32(dt.Rows[0]["CFFlag"]) == 1)
                {
                    MessageBox.Show("提示", "条码已经被拆分请检查", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 条码是否入库
        /// </summary>
        /// <param name="p_ISN"></param>
        /// <returns></returns>
        public static bool CheckInWH(string p_ISN)
        {
            string sql = "SELECT ID,CFFlag FROM WO_Fabric WHERE ISN=" + SysString.ToDBString(p_ISN);
            sql += " AND Status=1 AND ISNULL(CFFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("提示", "条码未入库请检查", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        /// <summary>
        /// 条码是否出库
        /// </summary>
        /// <param name="p_ISN"></param>
        /// <returns></returns>
        public static bool CheckOutWH(string p_ISN)
        {
            string sql = "SELECT ID,CFFlag FROM WO_Fabric WHERE ISN=" + SysString.ToDBString(p_ISN);
            sql += " AND Status=2 AND ISNULL(CFFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("提示", "条码未出库请检查", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        /// <summary>
        /// 条码是否打包
        /// </summary>
        /// <param name="p_ISN"></param>
        /// <returns></returns>
        public static bool CheckPackISN(string p_ISN)
        {
            string sql = "SELECT ID,CFFlag FROM WO_Fabric WHERE ISN=" + SysString.ToDBString(p_ISN);
            sql += " AND ISNULL(PackFlag,0)=1";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("提示", "条码已经打包请检查" + p_ISN, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 条码是否拆分
        /// </summary>
        /// <param name="p_ISN"></param>
        /// <returns></returns>
        public static bool CheckISNCF(string p_ISN)
        {
            string sql = "SELECT ID,CFFlag FROM WO_Fabric WHERE ISN=" + SysString.ToDBString(p_ISN);
            sql += " AND ISNULL(CFFlag,0)=1";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
