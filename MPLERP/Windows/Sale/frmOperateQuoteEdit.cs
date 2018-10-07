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
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：客户报价
    /// </summary>
    public partial class frmOperateQuoteEdit : frmAPBaseUIFormEdit
    {
        public frmOperateQuoteEdit()
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

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择客户");
                drpVendorID.Focus();
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
            OperateQuoteDtsRule rule = new OperateQuoteDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            OperateQuoteRule rule = new OperateQuoteRule();
            OperateQuote entity = EntityGet();
            OperateQuoteDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            OperateQuoteRule rule = new OperateQuoteRule();
            OperateQuote entity = EntityGet();
            OperateQuoteDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            OperateQuote entity = new OperateQuote();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.Code;

  			txtCode.Text = entity.Code.ToString(); 
  			drpVendorID.EditValue = entity.VendorID; 
  			txtQuoteDate.DateTime = entity.QuoteDate; 
  			drpQuoteOPID.EditValue = entity.QuoteOPID;
            drpVendorOPID.EditValue = entity.VendorOPID;
            drpCompanyTypeID.EditValue = entity.CompanyTypeID;
            drpCurrencyID.EditValue = entity.CurrencyID; 
  			txtRate.Text = entity.Rate.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            txtMakeOPID.Text = Common.GetOPName(entity.MakeOPID.ToString());
            txtMakeDate.DateTime = entity.MakeDate;
            drpYarnTypeID1.EditValue = entity.YarnTypeID;
            drpYarnStatus1.EditValue = entity.YarnStatus;
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
            OperateQuoteRule rule = new OperateQuoteRule();
            OperateQuote entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            ProcessCtl.ProcControlEdit(new Control[] { txtCode,txtMakeDate,txtMakeOPID}, false);
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtQuoteDate.Text = DateTime.Now.Date.ToShortDateString();
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);
            txtMakeDate.Text = DateTime.Now.Date.ToShortDateString();

            drpCompanyTypeID.EditValue = 1;
            drpCurrencyID.EditValue = (int)EnumCurrency.人民币;//人民币
     

            txtCode_DoubleClick(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_OperateQuote";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode"};//数据明细校验必须录入字段

            Common.BindOPID(drpQuoteOPID, true);//报价人
            Common.BindCurrency(drpCurrencyID, true);//币种
            Common.BindCompanyType(drpCompanyTypeID, true);//绑定公司别
            //Common.BindVendorSaleOPID(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);//绑定客户跟单         
            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[3] { "ItemCode", "ItemName", "ItemStd" }, drpItemCode, txtItemName, new int[] { (int)EnumItemType.面料 }, "", "ItemModel", true, true);
            Common.BindCLS(drpYarnStatus, "Sale", "YarnType", true);//纱线形态
            Common.BindYarnType(drpYarnTypeID1, true);//纱线类型
            Common.BindCLS(drpYarnStatus1, "Sale", "YarnType", true);//纱线形态

            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);


            string p_Conidion = string.Empty;
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                SetPosCondition = " AND VendorID in(Select VendorID FROM UV1_Data_VendorInSaleOP WHERE InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                SetPosCondition += "  OR DtsInSaleOP=" + SysString.ToDBString(FParamConfig.LoginID) + ")";

                p_Conidion = " AND ( ";
                p_Conidion += " InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                p_Conidion += " OR ID in (Select MainID From Data_VendorInSaleOP where InSaleOP= " + SysString.ToDBString(FParamConfig.LoginID) + ")";
                p_Conidion += ")";

            }
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, p_Conidion, true);//客户
            new VendorProc(drpVendorID, p_Conidion);

            SetTabIndex(0,groupControlMainten);
        }
        /// <summary>
        /// 重新设置实体1
        /// </summary>
        private void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;

            string itemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemCode"]));
            if (itemCode != "")
            {
                SetStorgeQty(itemCode);
            }

        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OperateQuote EntityGet()
        {
            OperateQuote entity = new OperateQuote();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.Code = txtCode.Text.Trim(); 
  			entity.VendorID =SysConvert.ToString( drpVendorID.EditValue); 
  			entity.QuoteDate = txtQuoteDate.DateTime.Date;
            entity.QuoteOPID =SysConvert.ToString( drpQuoteOPID.EditValue);
            entity.VendorOPID = SysConvert.ToString(drpVendorOPID.EditValue);
  			entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue); 
  			entity.CurrencyID = SysConvert.ToInt32(drpCurrencyID.EditValue); 
  			entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.YarnStatus = SysConvert.ToString(drpYarnStatus1.EditValue);
            entity.YarnTypeID = SysConvert.ToInt32(drpYarnTypeID1.EditValue);
            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = txtMakeDate.DateTime.Date;
            }
            
  			 
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OperateQuoteDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            OperateQuoteDts[] entitydts = new OperateQuoteDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new OperateQuoteDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].SalePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SalePrice")); 
  		
                    //entitydts[index].YarnStatus = SysConvert.ToString(gridView1.GetRowCellValue(i, "YarnStatus")); 
                    entitydts[index].YarnStatus = SysConvert.ToString(drpYarnStatus1.EditValue);
  			 		entitydts[index].WhitePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "WhitePrice")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
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

        #region 其它事件
        //双击生成单号
        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    //txtCode.Text = rule.RGetFormNo((int)FormNoControlEnum.客户报价单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 设置一个库存
        /// </summary>
        private void SetStorgeQty(string p_ItemCode)
        {
            string sql = string.Empty;
            DataTable dt;
            decimal tqty = 0;
            string tstr = string.Empty;

            sql = "SELECT WHID,SectionID,Sum(FreeQty) SQty,ColorName,JarNum,ColorNum FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//查询色纱库存
            sql += " AND ISNULL(ISJK,0)=0";
            //sql += " AND WHTypeID=" + (int)WHType.色纱 + " AND ISNULL(ISJK,0)=0";
            sql += " GROUP BY WHID,SectionID,ColorNum,JarNum,ColorName ORDER BY SQty DESC";
            dt = SysUtils.Fill(sql);
            tqty = 0;
            tstr = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                tqty += SysConvert.ToDecimal(dr["SQty"]);
                tstr += Environment.NewLine + "库区：" + "" + " " + dr["SectionID"].ToString() + " 颜色：" + dr["ColorName"].ToString() + " 色号：" + dr["ColorNum"].ToString() + "   缸号：" + dr["JarNum"].ToString() + "   数量：" + SysConvert.ToDecimal(dr["SQty"]) + "KG";
            }
            tstr = "库存合计:" + tqty.ToString() + "KG" + tstr;//明细：
            txtWHStorgeQty.Text = tstr;


            sql = "SELECT WHID,Sum(FreeQty) SQty,ColorName,JarNum,ColorNum FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//查询色纱库存
            sql += " AND ISNULL(ISJK,0)=1";
            //sql += " AND WHTypeID=" + (int)WHType.色纱 + " AND ISNULL(ISJK,0)=1";//寄库
            sql += " GROUP BY WHID,ColorNum,JarNum,ColorName ORDER BY SQty DESC";
            dt = SysUtils.Fill(sql);
            tqty = 0;
            tstr = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                tqty += SysConvert.ToDecimal(dr["SQty"]);
                tstr += Environment.NewLine + "仓库：" + "" + " 颜色：" + dr["ColorName"].ToString() + " 色号：" + dr["ColorNum"].ToString() + "   缸号：" + dr["JarNum"].ToString() + "   数量：" + SysConvert.ToDecimal(dr["SQty"]) + "KG";
            }
            tstr = "库存合计:" + tqty.ToString() + "KG" + tstr;//明细：
            txtWHJKStorgeQty.Text = tstr;
        }
       
        /// <summary>
        /// 客户改变绑定相对应的客户担当
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                    {
                        Common.BindVendorSaleOPID(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpItemCode_Leave(object sender, EventArgs e)
        {
            try
            {
                string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ItemCode"]));
                SetStorgeQty(itemCode);
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

     


    }
}