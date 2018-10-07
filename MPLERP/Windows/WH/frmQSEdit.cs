using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmQSEdit : frmAPBaseUISinEdit
    {
        public frmQSEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入标题");
            //    txtTitle.Focus();
            //    return false;
            //}  
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择单位！");
                drpVendorID.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            QSRule rule = new QSRule();
            QS entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            QSRule rule = new QSRule();
            QS entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            QS entity = new QS();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            drpVendorID.EditValue = entity.VendorID;
            txtFormDate.DateTime = entity.FormDate;
  			txtItemCode.Text = entity.ItemCode.ToString(); 
  			txtGoodsCode.Text = entity.GoodsCode.ToString(); 
  			txtColorNum.Text = entity.ColorNum.ToString(); 
  			txtColorName.Text = entity.ColorName.ToString(); 
  			txtQty.Text = entity.Qty.ToString(); 
  			txtSinglePrice.Text = entity.SinglePrice.ToString(); 
  			txtAmount.Text = entity.Amount.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            txtOrderFormNo.Text = entity.OrderFormNo.ToString();
            txtRemark2.Text = entity.Remark2;
            drpUnit.EditValue = entity.Unit;
            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            QSRule rule = new QSRule();
            QS entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_QS";
            //Common.BindEnumUnit(drpUnit, true);

            Common.BindCLS(drpUnit, "Data_Item", "ItemUnitFab", true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂 }, true);
            new VendorProc(drpVendorID);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoadWH_Click); //btnLoad_Click);
            //
        }

        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
        }

        #region 加载合同
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (SysConvert.ToString(drpVendorID.EditValue) == "")
                    {
                        this.ShowMessage("请选择单位");
                        drpVendorID.Focus();
                        return;
                    }
                    frmLoadOrder frm = new frmLoadOrder();

                    frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);


                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.OrderID != null && frm.OrderID.Length != 0)
                    {
                        //SetGridView1();// 防止一个采购单出现两个合同的数据
                        for (int i = 0; i < frm.OrderID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.OrderID[i]);
                        }
                        setItemNews(str);

                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[0]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    txtItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                    txtGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                    txtColorNum.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                    txtColorName.Text = SysConvert.ToString(dt.Rows[0]["ColorName"]);
                    txtOrderFormNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    //gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    //gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    //gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    //gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    //gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    //gridView1.SetRowCellValue(i, "DtsOrderNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));



                }
            }
        }

        #endregion

        #region 加载未开票信息
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnLoadWH_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (SysConvert.ToString(drpVendorID.EditValue) == "")
                    {
                        this.ShowMessage("请选择单位");
                        drpVendorID.Focus();
                        return;
                    }
                    frmLoadIOForm frm = new frmLoadIOForm();
                    frm.DZTypeID = (int)EnumDZType.销售;
                    string tempConditionStr =" AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                    tempConditionStr += " AND  ABS(ISNULL(InvoiceQty,0))<>ISNULL(Qty,0) ";
                    frm.HTLoadConditionStr = tempConditionStr;//只查询未开票部分数据
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.DtsID != null && frm.DtsID.Length != 0)
                    {
                        
                        for (int i = 0; i < frm.DtsID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.DtsID[i]);
                        }
                        setItemByWH(str);

                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemByWH(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
           
            string sql = "SELECT * FROM  UV1_WH_IOFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[0]));
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {
                txtItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                txtGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                txtColorNum.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                txtColorName.Text = SysConvert.ToString(dt.Rows[0]["ColorName"]);
                txtOrderFormNo.Text = SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]);
            }
            
        
        }

        #endregion


        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private QS EntityGet()
        {
            QS entity = new QS();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
  			entity.ItemCode = txtItemCode.Text.Trim(); 
  			entity.GoodsCode = txtGoodsCode.Text.Trim(); 
  			entity.ColorNum = txtColorNum.Text.Trim(); 
  			entity.ColorName = txtColorName.Text.Trim(); 
  			entity.Qty = SysConvert.ToDecimal(txtQty.Text.Trim()); 
  			entity.SinglePrice = SysConvert.ToDecimal(txtSinglePrice.Text.Trim()); 
  			entity.Amount = SysConvert.ToDecimal(txtAmount.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.FormDate = txtFormDate.DateTime;
            entity.OrderFormNo = txtOrderFormNo.Text.Trim();
            entity.Remark2 = txtRemark2.Text.Trim();
            entity.Unit = SysConvert.ToString(drpUnit.EditValue);
            return entity;
        }
        #endregion
    }
}