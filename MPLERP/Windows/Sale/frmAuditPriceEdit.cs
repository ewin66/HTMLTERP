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
    public partial class frmAuditPriceEdit : frmAPBaseUIFormEdit
    {
        public frmAuditPriceEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("请双击生成单号");
                txtCode.Focus();
                return false;
            }

            if (!this.CheckCorrectDts())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            AuditPriceDtsRule rule = new AuditPriceDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            AuditPriceRule rule = new AuditPriceRule();
            AuditPrice entity = EntityGet();
            AuditPriceDts[] entitydts = EntityDtsGet();
            decimal ItemAmount = 0.00m;//计算原料总额
            for (int i = 0; i < entitydts.Length; i++)
            {
                ItemAmount += entitydts[i].Amount;   
            }
            entity.ItemAmount = ItemAmount;
            entity.PPrice = ItemAmount + entity.OthAmount;//原坯绞纱价格=原料总额+加工费
            entity.SPrice = entity.PPrice + entity.ColorAmount;//原色绞纱价格=坯绞纱价格+染色费
            entity.STPrice = entity.SPrice * (1 + entity.DTSHAmount / 100) + entity.DTAmount;//色筒纱价格=色绞纱价格*（1+倒筒损耗）+倒筒费

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            AuditPriceRule rule = new AuditPriceRule();
            AuditPrice entity = EntityGet();
            AuditPriceDts[] entitydts = EntityDtsGet();
            decimal ItemAmount = 0.00m;//计算原料总额
            for (int i = 0; i < entitydts.Length; i++)
            {
                ItemAmount += entitydts[i].Amount;
            }
            entity.ItemAmount = ItemAmount;
            entity.PPrice = ItemAmount + entity.OthAmount;//原坯绞纱价格=原料总额+加工费
            entity.SPrice = entity.PPrice + entity.ColorAmount;//原色绞纱价格=坯绞纱价格+染色费
            entity.STPrice = entity.SPrice * (1 + entity.DTSHAmount / 100) + entity.DTAmount;//色筒纱价格=色绞纱价格*（1+倒筒损耗）+倒筒费
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            AuditPrice entity = new AuditPrice();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.Code;

            txtCode.Text = entity.Code.ToString(); 
  			txtProductCode.Text = entity.ProductCode.ToString();
            drpItemCode.EditValue = entity.ItemCode; 
  			txtItemName.Text = entity.ItemName.ToString(); 
  			txtItemStd.Text = entity.ItemStd.ToString(); 
  			txtItemModel.Text = entity.ItemModel.ToString(); 
  			txtProductName.Text = entity.ProductName.ToString(); 
  			txtEquipment.Text = entity.Equipment.ToString(); 
  			txtProductGY.Text = entity.ProductGY.ToString(); 
  			txtProductRSGY.Text = entity.ProductRSGY.ToString(); 
  			txtMakeOPID.Text =Common.GetOPName( entity.MakeOPID.ToString()); 
  			txtMakeDate.DateTime = entity.MakeDate;
            drpJSOPID.EditValue = entity.JSOPID;
            drpSHOPID.EditValue = entity.SHOPID;
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtPPrice.Text = entity.PPrice.ToString(); 
  			txtPDatetime.DateTime = entity.PDatetime; 
  			txtSPrice.Text = entity.SPrice.ToString(); 
  			txtSDatetime.DateTime = entity.SDatetime;
            drpCompanyTypeID.EditValue = entity.CompanyTypeID;

            txtItemAmount.Text = entity.ItemAmount.ToString();
            txtOthAmount.Text = entity.OthAmount.ToString();
            txtColorAmount.Text = entity.ColorAmount.ToString();
            txtDTAmount.Text = entity.DTAmount.ToString();
            txtDTSHAmount.Text = entity.DTSHAmount.ToString();
            txtSTPrice.Text = entity.STPrice.ToString();

  			
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            AuditPriceRule rule = new AuditPriceRule();
            AuditPrice entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { txtCode, txtMakeOPID, txtMakeDate }, false);
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);
            txtMakeDate.Text = DateTime.Now.Date.ToShortDateString();
            txtPDatetime.Text = DateTime.Now.Date.ToShortDateString();
            txtSDatetime.Text = DateTime.Now.Date.ToShortDateString();
            drpCompanyTypeID.EditValue = 1;
            txtPPrice.Text = "";
            txtSPrice.Text = "";
            txtProductRSGY.Text = "A.染  毛/尼龙" + Environment.NewLine + "B.染  腈纶"+Environment.NewLine
                + "C.染  棉" + Environment.NewLine +"D.其他方法  ( 请说明 ) :";
            txtCode_DoubleClick(null, null);
            txtDTAmount.Text = "2";
            txtDTSHAmount.Text = "3";
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_AuditPrice";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode"};//数据明细校验必须录入字段
            Common.BindCompanyType(drpCompanyTypeID, true);//绑定公司别

            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[3] { "ItemCode", "ItemName", "ItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.面料 }, "", "ItemModel", true, true);
            new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, new int[] { (int)EnumItemType.面料 }, true, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.全部, (int)EnumVendorType.工厂 }, true);

            Common.BindOPID(drpSHOPID, true);
            Common.BindOPID(drpJSOPID, true);
            SetTabIndex(0, groupControlMainten);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private AuditPrice EntityGet()
        {
            AuditPrice entity = new AuditPrice();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();
            entity.ProductCode = txtProductCode.Text.Trim();
            entity.ItemCode = SysConvert.ToString(drpItemCode.EditValue);  
  			entity.ItemName = txtItemName.Text.Trim(); 
  			entity.ItemStd = txtItemStd.Text.Trim(); 
  			entity.ItemModel = txtItemModel.Text.Trim(); 
  			entity.ProductName = txtProductName.Text.Trim(); 
  			entity.Equipment = txtEquipment.Text.Trim(); 
  			entity.ProductGY = txtProductGY.Text.Trim(); 
  			entity.ProductRSGY = txtProductRSGY.Text.Trim();
            if (this.HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = txtMakeDate.DateTime.Date;
            }
            entity.JSOPID = SysConvert.ToString(drpJSOPID.EditValue);
            entity.SHOPID = SysConvert.ToString(drpSHOPID.EditValue);
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.PPrice = SysConvert.ToDecimal(txtPPrice.Text.Trim()); 
  			entity.PDatetime = txtPDatetime.DateTime.Date; 
  			entity.SPrice = SysConvert.ToDecimal(txtSPrice.Text.Trim()); 
  			entity.SDatetime = txtSDatetime.DateTime.Date;
            entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue);
            entity.ItemAmount = SysConvert.ToDecimal(txtItemAmount.Text.Trim());
            entity.OthAmount = SysConvert.ToDecimal(txtOthAmount.Text.Trim());
            entity.ColorAmount = SysConvert.ToDecimal(txtColorAmount.Text.Trim());
            entity.DTAmount = SysConvert.ToDecimal(txtDTAmount.Text.Trim());
            entity.DTSHAmount = SysConvert.ToDecimal(txtDTSHAmount.Text.Trim());
            entity.STPrice = SysConvert.ToDecimal(txtSTPrice.Text.Trim());
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private AuditPriceDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            AuditPriceDts[] entitydts = new AuditPriceDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new AuditPriceDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].Price = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Price")); 
  			 		entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount")); 
  			 		entitydts[index].VendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID")); 
  			 		entitydts[index].Percentage = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Percentage")); 
  			 		entitydts[index].Loss = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Loss")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion
 

        #region 其它事件
        /// <summary>
        /// 计算相关价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOthAmount_EditValueChanged(object sender, EventArgs e)
        {
             try
            {
                txtSTPrice.Text = "";
                txtSPrice.Text = "";
                txtPPrice.Text = "";
                if (txtItemAmount.Text.Trim() != "")
                {
                    decimal ItemAmount = SysConvert.ToDecimal(txtItemAmount.Text.Trim());
                    decimal OthAmount = SysConvert.ToDecimal(txtOthAmount.Text.Trim());
                    decimal ColorAmount = SysConvert.ToDecimal(txtColorAmount.Text.Trim());
                    decimal DTSHAmount = SysConvert.ToDecimal(txtDTSHAmount.Text.Trim());
                    decimal DTAmount = SysConvert.ToDecimal(txtDTAmount.Text.Trim());
                    txtPPrice.Text = SysConvert.ToString(ItemAmount+OthAmount);
                    txtSPrice.Text = SysConvert.ToString(SysConvert.ToDecimal(txtPPrice.Text.Trim()) + ColorAmount);
                    txtSTPrice.Text = SysConvert.ToString(SysConvert.ToDecimal(txtSPrice.Text.Trim())*(1+DTSHAmount/100)+DTAmount);//色筒纱价格=色绞纱价格*（1+倒筒损耗）+倒筒费
               
                }
             }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 生成核价单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    //txtCode.Text = rule.RGetFormNo((int)FormNoControlEnum.核价单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();

                decimal ItemAmount = 0.00m;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "Price")) != "")
                    {
                        decimal Price = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Price"));
                        decimal Loss = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Loss"));
                        decimal Per = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Percentage"));
                        decimal DtsAmount = SysConvert.ToDecimal(Price * (SysConvert.ToDecimal(Per) / 100) * (1 + SysConvert.ToDecimal(Loss) / 100), 2);

                        gridView1.SetRowCellValue(i, "Amount", DtsAmount);
                        ItemAmount += DtsAmount;

                    }
                }
                txtItemAmount.Text = ItemAmount.ToString("f2");

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 复制单据时产生当前日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMakeDate_DoubleClick(object sender, EventArgs e)
        {
            if (HTFormStatus == FormStatus.新增)
            {
                txtMakeDate.DateTime = DateTime.Now.Date;
            }
        }

        #endregion

        #region 重载事件（打印相关）
        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //base.btnPreview_Click(sender, e);
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.预览, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //base.btnPrint_Click(sender, e);

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.打印, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        /// <summary>
        /// 设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                //base.btnDesign_Click(sender, e);
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交3))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.设计, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion

     

      
    }
}