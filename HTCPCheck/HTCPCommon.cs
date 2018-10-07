using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using HttSoft.HTCPCheck.DataCtl;
using System.Collections;
using HttSoft.Framework;
using System.Data;

namespace HTCPCheck
{
    /// <summary>
    /// 目的: 定义通用方法
    /// 作者: 陈加海
    /// 创建日期: 2014.5.6
    /// </summary>
    public class HTCPCommon
    {
        #region 单号界面操作
        /// <summary>
        /// 设置控件是否只读
        /// </summary>
        /// <param name="p_Txt"></param>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        /// <param name="p_SubTypeID"></param>
        public static void FormNoCtlEditSet(TextEdit p_Txt, string p_CLSA, string p_CLSB, bool p_Flag)
        {
            FormNoCtlEditSet(p_Txt, p_CLSA, p_CLSB, 0, p_Flag);
        }



        /// <summary>
        /// 设置控件是否只读
        /// </summary>
        /// <param name="p_Txt"></param>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        /// <param name="p_SubTypeID"></param>
        public static void FormNoCtlEditSet(TextEdit p_Txt, string p_CLSA, string p_CLSB, int p_SubTypeID, bool p_Flag)
        {

            FNORelRule frule = new FNORelRule();
            if (frule.RGetFormNoControlEditFlag(p_CLSA, p_CLSB, p_SubTypeID))//可编辑
            {
                p_Txt.Properties.ReadOnly = !p_Flag;
            }
            else//不可编辑
            {
                p_Txt.Properties.ReadOnly = true;
            }
        }


        /// <summary>
        /// 设置单号值
        /// </summary>
        /// <param name="p_Txt"></param>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        public static void FormNoIniSet(TextEdit p_Txt, string p_CLSA, string p_CLSB)
        {
            FormNoIniSet(p_Txt, p_CLSA, p_CLSB, 0);
        }
        /// <summary>
        /// 设置单号值
        /// </summary>
        /// <param name="p_Txt"></param>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        /// <param name="p_SubTypeID"></param>
        public static void FormNoIniSet(TextEdit p_Txt, string p_CLSA, string p_CLSB, int p_SubTypeID)
        {
            FNORelRule frule = new FNORelRule();
            if (frule.RGetFormNoControlEditFlag(p_CLSA, p_CLSB, p_SubTypeID))//如果自行编辑
            {
            }
            else//如果不自行编辑
            {
                FormNoControlRule rule = new FormNoControlRule();
                string formcode = rule.RGetFormNo(p_CLSA, p_CLSB, p_SubTypeID);
                if (formcode != string.Empty)
                {
                    p_Txt.Text = formcode;
                }
            }
        }
        #endregion



        #region 检验获取通用信息方法(如果要用产品，必须参数化方可)

        /// <summary>
        /// 根据合同号获取合同信息
        /// </summary>
        /// <param name="p_CompactNo">合同号</param>
        /// <returns>返回ArrayList 0/1:客户/交期</returns>
        public static ArrayList GetCompactInfoByCompactNo(string p_CompactNo)
        {
            ArrayList al = new ArrayList();
            string sql = string.Empty;
            sql = "SELECT VendorID,ReqDate FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(p_CompactNo);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                al.Add(dt.Rows[0]["VendorID"].ToString());
                al.Add(SysConvert.ToDateTime(dt.Rows[0]["ReqDate"]));
            }

            return al;
        }

        #endregion
    }


    
}
