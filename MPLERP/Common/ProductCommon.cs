using System;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.Data;
using HttSoft.MLTERP.DataCtl;
using System.Windows.Forms;
using System.Drawing;
using HttSoft.MLTERP.Sys;


namespace MLTERP
{

    

    /// <summary>
    /// 产品共用类
    /// 陈加海
    /// 2014.4.17
    /// </summary>
    public class ProductCommon
    {

        #region  FormNo 单号界面操作
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
            FormNoIniSet( p_Txt,  p_CLSA,  p_CLSB,0);
        }
        /// <summary>
        /// 设置单号值
        /// </summary>
        /// <param name="p_Txt"></param>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        /// <param name="p_SubTypeID"></param>
        public static void FormNoIniSet(TextEdit p_Txt,string p_CLSA,string p_CLSB,int p_SubTypeID)
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


        #region JG加工扣料控制相关

        /// <summary>
        /// 初始化扣料按钮是否可见
        /// </summary>
        /// <param name="btnKL">扣料按钮</param>
        /// <param name="p_SaleProcedureID">加工单类型</param>
        public static void JGButtonIni(DevExpress.XtraEditors.SimpleButton btnKL,int p_SaleProcedureID)
        {
            btnKL.Visible = false;
            string sql = string.Empty;
            sql = "SELECT JGUseFlag FROM Enum_SaleProcedure WHERE ID=" + p_SaleProcedureID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (SysConvert.ToBoolean(SysConvert.ToInt32((dt.Rows[0]["JGUseFlag"]))))
                {
                    btnKL.Visible = true;
                }
            }
        }

        /// <summary>
        /// 扣料按钮状态设置
        /// </summary>
        /// <param name="p_FrmStatus">单据状态</param>
        /// <param name="p_SubmitFlag">提交状态</param>
        /// <param name="p_DataID">数据ID</param>
        /// <param name="btnKL">扣料按钮</param>
        public static void JGButtonStatusSet(FormStatus p_FrmStatus, int p_SubmitFlag, int p_DataID, DevExpress.XtraEditors.SimpleButton btnKL)
        {
            if (btnKL.Visible)//可见再处理
            {
                //if (p_FrmStatus == FormStatus.查询 && p_SubmitFlag == 1)//提交查询状态才可以操作扣料
                //{
                //    btnKL.Enabled = true;
                //}
                //else
                //{
                //    btnKL.Enabled = false;
                //}

                string sql = string.Empty;//寻找是否已有扣料数据
                sql = "SELECT ID,SubmitFlag,FormNo FROM WO_FabricWHOutForm WHERE MainID=" + p_DataID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    if (SysConvert.ToBoolean(SysConvert.ToInt32(dt.Rows[0]["SubmitFlag"])))//扣料且提交
                    {
                        btnKL.Appearance.BackColor = Color.FromArgb(255, 255, 192);
                        btnKL.Appearance.BackColor2 = Color.Yellow;

                    }
                    else//扣料单生成但未提交
                    {
                        btnKL.Appearance.BackColor = Color.FromArgb(255, 255, 192);
                        btnKL.Appearance.BackColor2 = Color.White;
                    }
                }
                else//未生成扣料单
                {
                    btnKL.Appearance.BackColor = Color.White;
                    btnKL.Appearance.BackColor2 = Color.White;
                }
            }
        }

        /// <summary>
        /// 打开扣料窗口
        /// </summary>
        /// <param name="p_SaleProcedureID"></param>
        public static void JGOpenKLForm(int p_SaleProcedureID,int p_HTDataID,string p_HTFormNo)
        {
            string sql = string.Empty;
            sql = "SELECT JGUseFlag,JGItemTypeID,JGWHIDDefault,JGFormListID FROM Enum_SaleProcedure WHERE ID=" + p_SaleProcedureID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (SysConvert.ToBoolean(SysConvert.ToInt32((dt.Rows[0]["JGUseFlag"]))))//启用
                {
                    switch (SysConvert.ToInt32(dt.Rows[0]["JGItemTypeID"]))
                    {
                        case (int)EnumItemType.纱线:
                            frmBuckleMaterial frm = new frmBuckleMaterial();
                            frm.PackFlag = false;//不需要码单
                            frm.FormNo = p_HTFormNo;//单号
                            frm.WHItemTypeID = SysConvert.ToInt32(dt.Rows[0]["JGItemTypeID"]);//物料类型
                            frm.WHFormListAID = Common.GetFormListIDBySubTypeID(SysConvert.ToInt32(dt.Rows[0]["JGFormListID"]));//主类型
                            frm.WHFormListBID = SysConvert.ToInt32(dt.Rows[0]["JGFormListID"]);//子类型
                            frm.MainID = p_HTDataID;
                            frm.WHID = SysConvert.ToString(dt.Rows[0]["JGWHIDDefault"]);//扣料库别
                            frm.ShowDialog();
                            break;
                        case (int)EnumItemType.坯布:
                            frmFabricBuckleMaterial frmFabric = new frmFabricBuckleMaterial();
                            frmFabric.PackFlag = true;//需要码单
                            frmFabric.WHItemTypeID = SysConvert.ToInt32(dt.Rows[0]["JGItemTypeID"]);//物料类型
                            frmFabric.FormNo = p_HTFormNo;//单号
                            frmFabric.WHFormListAID = Common.GetFormListIDBySubTypeID(SysConvert.ToInt32(dt.Rows[0]["JGFormListID"]));//主类型
                            frmFabric.WHFormListBID = SysConvert.ToInt32(dt.Rows[0]["JGFormListID"]);//子类型
                            frmFabric.MainID = p_HTDataID;
                            frmFabric.WHID = SysConvert.ToString(dt.Rows[0]["JGWHIDDefault"]);//扣料库别
                            frmFabric.ShowDialog();
                            break;
                        case (int)EnumItemType.面料:
                            goto case (int)EnumItemType.坯布;
                    }
                }
            }
           
        }
        #endregion


        #region  UnitConvert 单位模式换算相关
        /// <summary>
        /// 换算为基础单位数量并返回基础单位
        /// (订单录入使用)
        /// </summary>
        /// <param name="p_SourceUnit"></param>
        /// <param name="p_Qty"></param>
        /// <param name="o_BaseUnit"></param>
        /// <returns></returns>
        public static decimal UnitConvertValueBaseUnit(string p_SourceUnit,decimal p_Qty,out string o_BaseUnit)
        {
            decimal outdec = p_Qty;
            o_BaseUnit = p_SourceUnit;
            if (p_SourceUnit != string.Empty)
            {
                string sql = string.Empty;
                sql = "SELECT * FROM Enum_Unit WHERE Name=" + SysString.ToDBString(p_SourceUnit);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    if (SysConvert.ToString(dt.Rows[0]["BaseUnit"]) != string.Empty)//基础单位
                    {
                        o_BaseUnit = SysConvert.ToString(dt.Rows[0]["BaseUnit"]);
                        string fomula = SysConvert.ToString(dt.Rows[0]["Formula"]);//换算为基础单位的公式
                        if (fomula != string.Empty)//公式不为空，开始换算
                        {
                            outdec = SysConvert.ToDecimal(SysConvert.ToExpressions(p_Qty.ToString() + fomula), 2);
                        }
                    }
                    else//没有基础单位，则不用换算
                    {
                        //不执行操作
                    }
                }
                else
                {
                    throw new Exception("单位在基础资料--计量单位换算公式定义中不存在，不能操作");
                }
            }
            else
            {
                throw new Exception("没有选择单位，不能操作");
            }

            return outdec;
        }

        /// <summary>
        /// 米转换为公斤算法
        /// 第一种算法 （简易）
        /// </summary>
        /// <param name="p_Qty">米数</param>
        /// <param name="p_MWidth">门幅</param>
        /// <param name="p_MWeight">克重</param>
        /// <returns>公斤数</returns>
        public static decimal UnitConvertMiToKG1ST(decimal p_Qty, decimal p_MWidth, decimal p_MWeight)
        {
            /*算法说明 数量*门幅*克重/1000/100
            */
            decimal outdec = p_Qty;


            outdec = p_Qty * (p_MWidth / 100m) * (p_MWeight / 1000m);//数量*门幅*克重
            return outdec;
        }

        /// <summary>
        /// 米转换为公斤算法
        /// 第二种算法(明炜用)
        /// </summary>
        /// <param name="p_Qty">米数</param>
        /// <param name="p_MWidth">门幅</param>
        /// <param name="p_MWeight">克重</param>
        /// <returns>公斤数</returns>
        public static decimal UnitConvertMiToKG2ND(decimal p_Qty,decimal p_MWidth,decimal p_MWeight)
        {
            /*算法说明 由下单米数转化为公斤数公式说明如下：      首先，用1000除以克重再除以门幅得到一个参数 A     该系数再乘以100。
                    特别注意，当系数扩大100倍后，若整数部分小于10，
                                            1.十分位为0，则只取该整数      例子： 0.0502 ——> 5
                                             2.十分位不为0，则该数为保留一位有效数字   例子： 0.0512——> 5.1 不要四舍五入
                                若整数部分大于等于10，则只取整数部分。  例子：0.1025——>10 
             米数除以A 得到结果
            */
            decimal outdec = p_Qty;

            decimal xsA = 0;//系数
            if (p_MWidth != 0 && p_MWeight != 0)
            {
                xsA = (1000m / (p_MWidth * p_MWeight)) * 100m;
                if (xsA >= 10)
                {
                    xsA = SysConvert.ToDecimal(xsA, 0);//取整
                }
                else//小于10
                {
                    if (xsA.ToString().Length >= 3)//小数至少有1位
                    {
                        xsA = SysConvert.ToDecimal(SysConvert.ToDecimal(xsA.ToString().Substring(0,3)), 1);//取1位小数
                    }
                    else
                    {
                        xsA = SysConvert.ToDecimal(xsA, 0);//取整
                    }
                }
            }
            if (xsA != 0)
            {
                outdec = p_Qty / xsA;
            }
            return outdec;
        }


        /// <summary>
        /// 单位换算系数自己录入
        /// 第十种算法(宏康用)
        /// </summary>
        /// <param name="p_Qty">米数</param>
        /// <param name="p_XS">系数</param>
        /// <returns>转换后数量</returns>
        public static decimal UnitConvertMiToUnit10Ten(decimal p_Qty, decimal p_XS)
        {
            /*算法说明
             数量除以系数 得到结果
            */
            decimal outdec = p_Qty;

         
            if (p_XS != 0)
            {
                outdec = p_Qty * p_XS;
            }
            return outdec;
        }

        /// <summary>
        /// 基础单位数量换算为非基础单位数量
        /// (发货单/出库单使用)
        /// </summary>
        /// <param name="p_BaseUnit">基础单位</param>
        /// <param name="p_BaseQty">基础数量</param>
        /// <param name="p_InputUnit">录入单位</param>
        /// <param name="p_InputConvertXS">录入转换系数</param>
        /// <returns></returns>
        public static decimal UnitConvertValueAnyUnit(string p_BaseUnit, decimal p_BaseQty, string p_InputUnit,decimal p_InputConvertXS)
        {
            decimal outdec = p_BaseQty;
            if (p_BaseUnit != string.Empty || p_InputUnit!=string.Empty)
            {
                if (p_InputConvertXS != 0)
                {
                    outdec = SysConvert.ToDecimal(p_BaseQty / p_InputConvertXS, 2);
                }
                //string sql = string.Empty;
                //sql = "SELECT * FROM Enum_Unit WHERE Name=" + SysString.ToDBString(p_SourceUnit);
                //DataTable dt = SysUtils.Fill(sql);
                //if (dt.Rows.Count != 0)
                //{
                //    if (SysConvert.ToString(dt.Rows[0]["BaseUnit"]) != string.Empty)//基础单位
                //    {
                //        o_BaseUnit = SysConvert.ToString(dt.Rows[0]["BaseUnit"]);
                //        string fomula = SysConvert.ToString(dt.Rows[0]["Formula"]);//换算为基础单位的公式
                //        if (fomula != string.Empty)//公式不为空，开始换算
                //        {
                //            outdec = SysConvert.ToDecimal(SysConvert.ToExpressions(p_Qty.ToString() + fomula), 2);
                //        }
                //    }
                //    else//没有基础单位，则不用换算
                //    {
                //        //不执行操作
                //    }
                //}
                //else
                //{
                //    throw new Exception("单位在基础资料--计量单位换算公式定义中不存在，不能操作");
                //}
            }
            else
            {
                throw new Exception("没有选择单位，不能操作");
            }

            return outdec;
        }
        #endregion


        #region ItemControl 物品控制相关
        /// <summary>
        /// 根据物品编号获得物料类型
        /// </summary>
        /// <param name="p_ItemCode"></param>
        /// <returns></returns>
        public static int ItemControlGetFabricType(string p_ItemCode)
        {
            int outi = 0;
            string sql = string.Empty;
            sql = "SELECT FabricTypeID FROM Data_Item WHERE ItemCode="+SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outi = SysConvert.ToInt32(dt.Rows[0]["FabricTypeID"]);
            }

            return outi;
        }
        #endregion

    }
}
