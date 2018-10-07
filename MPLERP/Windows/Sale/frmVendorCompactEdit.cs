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
using System.Collections;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmVendorCompactEdit : frmAPBaseUIFormEdit
    {
        public frmVendorCompactEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCompactNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入合同号");
                txtCompactNo.Focus();
                return false;
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) == "")
            {
                this.ShowMessage("请选择业务员");
                drpSaleOPID.Focus();
                return false;
            }
            if (SysConvert.ToString(drpVendorID.EditValue)== "")
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
            VendorCompactDtsRule rule = new VendorCompactDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            VendorCompactRule rule = new VendorCompactRule();
            VendorCompact entity = EntityGet();
            VendorCompactDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            VendorCompactRule rule = new VendorCompactRule();
            VendorCompact entity = EntityGet();
            VendorCompactDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            VendorCompact entity = new VendorCompact();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.CompactNo;
  			txtSOID.Text = entity.SOID.ToString(); 
  			txtCompactNo.Text = entity.CompactNo.ToString();
            txtVendorSO.Text = entity.VendorSO;
  			txtWriteDate.DateTime = entity.WriteDate; 
  			drpWriteAddress.EditValue = entity.WriteAddress.ToString(); 
  			txtAname.Text = entity.Aname.ToString(); 
  			txtAaddress.Text = entity.Aaddress.ToString(); 
  			txtAtel.Text = entity.Atel.ToString(); 
  			txtAfax.Text = entity.Afax.ToString(); 
  			txtBname.Text = entity.Bname.ToString(); 
  			txtBaddress.Text = entity.Baddress.ToString(); 
  			txtBtel.Text = entity.Btel.ToString(); 
  			txtBfax.Text = entity.Bfax.ToString(); 
  			txtTotalAmount.Text = entity.TotalAmount.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			drpVendorID.EditValue = entity.VendorID;
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpVendorOPID.EditValue = entity.VendorOPID;
            drpCompanyTypeID.EditValue = entity.CompanyTypeID;
            drpCurrencyID.EditValue = entity.CurrencyID; 
  			txtRate.Text = entity.Rate.ToString(); 
  			txtTotalQty.Text = entity.TotalQty.ToString();
            txtMakeOPID.Text = Common.GetOPName(entity.MakeOPID.ToString());
            txtMakeDate.DateTime = entity.MakeDate;
            txtTerms.Text = entity.Terms;
            drpPayMethod.EditValue = entity.PayMethod;           
            if (entity.NeedDate != SystemConfiguration.DateTimeDefaultValue && SysConvert.ToString(entity.NeedDate) != "")
            {
                txtNeedDate.DateTime = entity.NeedDate;
            }
            else
            {
                txtNeedDate.Text = "";
            }

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
            VendorCompactRule rule = new VendorCompactRule();
            VendorCompact entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            //ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            //ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            ProcessCtl.ProcControlEdit(new Control[] { txtCompactNo,txtSOID,txtTotalAmount,txtTotalQty,txtMakeDate,txtMakeOPID }, false);
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtWriteDate.Text = DateTime.Now.Date.ToShortDateString();
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);
            txtMakeDate.Text = DateTime.Now.Date.ToShortDateString();
            txtNeedDate.Text = "";


            drpCurrencyID.EditValue = (int)EnumCurrency.人民币;//人民币
            //drpWriteAddress.Text = "常州武进";
            drpCompanyTypeID.EditValue = 1;//公司别

        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_VendorCompact";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode"};//数据明细校验必须录入字段

            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[3] { "ItemCode", "ItemName", "ItemStd" }, drpItemcode, txtItemName, new int[] { (int)EnumItemType.面料 }, "", "ItemModel", true, true);


            Common.BindOP(drpSaleOPID, (int)EnumOPDep.业务部, true);
            Common.BindCurrency(drpCurrencyID, true);//币种
            Common.BindCompanyType(drpCompanyTypeID, true);//绑定公司别
            Common.BindCLS(drpYarnStatus, "Sale", "YarnType", true);//纱线形态
            Common.BindCLS(drpEditionNo, "Sale_SODts", "EditionNo", true);//确认版别
            Common.BindYarnType(drpYarnTypeID, true);//纱类
            Common.BindCLS(drpItemUnit, "Item", "ItemUnit", true);//计量单位

            Common.BindCLS(drpWriteAddress,"Sale_VendorCompact","WriteAdress",true);//合同签订地址

            string p_Conidion = string.Empty;
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                //SetPosCondition = " AND SaleOPID=" + SysString.ToDBString(FParamConfig.LoginID);

                SetPosCondition = " AND VendorID in(Select VendorID FROM UV1_Data_VendorInSaleOP WHERE InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                SetPosCondition += "  OR DtsInSaleOP=" + SysString.ToDBString(FParamConfig.LoginID) + ")";


                p_Conidion = " AND ( ";
                p_Conidion += " InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                p_Conidion += " OR ID in (Select MainID From Data_VendorInSaleOP where InSaleOP= " + SysString.ToDBString(FParamConfig.LoginID) + ")";
                p_Conidion += ")";
            }

            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, p_Conidion, true);//客户
            new VendorProc(drpVendorID, p_Conidion);

            this.ToolBarItemAdd(28, "btnCheckLoad", "加载", false, btnCheckLoad_Click);

            SetTabIndex(0, groupControlMainten);


        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private VendorCompact EntityGet()
        {
            VendorCompact entity = new VendorCompact();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.SOID = txtSOID.Text.Trim();
            entity.CompactNo = txtCompactNo.Text.Trim();
            entity.VendorSO=txtVendorSO.Text.Trim();
            entity.WriteDate = txtWriteDate.DateTime.Date;
            entity.WriteAddress = SysConvert.ToString(drpWriteAddress.EditValue);
            entity.Aname = txtAname.Text.Trim();
            entity.Aaddress = txtAaddress.Text.Trim();
            entity.Atel = txtAtel.Text.Trim();
            entity.Afax = txtAfax.Text.Trim();
            entity.Bname = txtBname.Text.Trim();
            entity.Baddress = txtBaddress.Text.Trim();
            entity.Btel = txtBtel.Text.Trim();
            entity.Bfax = txtBfax.Text.Trim();
            entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.VendorOPID = SysConvert.ToString(drpVendorOPID.EditValue);
            entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue);
            entity.CurrencyID = SysConvert.ToInt32(drpCurrencyID.EditValue);
            entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim());
            entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());

            entity.PayMethod = SysConvert.ToString(drpPayMethod.EditValue);
        
            if (txtNeedDate.DateTime.Date != SystemConfiguration.DateTimeDefaultValue && txtNeedDate.Text.Trim() != "")
            {
                entity.NeedDate = txtNeedDate.DateTime.Date;
            }

            entity.Terms = txtTerms.Text.Trim();
            entity.TotalAmountEn = Common.RMBToString(SysConvert.ToDouble(txtTotalAmount.Text.Trim()));

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
        private VendorCompactDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            VendorCompactDts[] entitydts = new VendorCompactDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new VendorCompactDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].YarnTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "YarnTypeID")); 
  			 		entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].UnitPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "UnitPrice")); 
  			 		entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		entitydts[index].YarnStatus = SysConvert.ToString(gridView1.GetRowCellValue(i, "YarnStatus")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].DesignNO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DesignNO")); 
  			 		entitydts[index].EditionNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "EditionNo"));
                    entitydts[index].ItemUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemUnit")); 
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

      
        #region 其它事件
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
        //加载订单
        private void btnCheckLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    SOLoad();
                  
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
     
        #region oldcode
       // 加载订单
        private void SOLoad()
        {
            
            //frmSODtsLoad frm = new frmSODtsLoad();
            //frm.ShowDialog();
            //if (frm.HTLoadData.Count != 0)
            //{
            //    string[] listID = ((string[])frm.HTLoadData[0]);
            //    listID=listID[0].Split(',');
            //    int soID = SysConvert.ToInt32(listID[0]);
            //    SO entity = new SO();
            //    entity.ID = soID;
            //    entity.SelectByID();
            //    txtSOID.Text = entity.SOID;
            //    txtCompactNo.Text = entity.SOID;//合同号和订单号相同
            //    txtVendorSO.Text = entity.VendorSO;
            //    txtRate.Text = entity.Rate.ToString();
            //    drpVendorID.EditValue = entity.VendorID;
            //    drpSaleOPID.EditValue = entity.SaleOPID;
            //    drpVendorOPID.EditValue = entity.VendorOPID;
            //    drpCompanyTypeID.EditValue = entity.CompanyTypeID;
            //    drpCurrencyID.EditValue = entity.CurrencyID;
            //    txtTotalQty.Text = entity.TotalQty.ToString();
            //    txtTotalAmount.Text = entity.TotalAmount.ToString();
            //    txtNeedDate.DateTime = entity.NeedDate;
            //    drpPayMethod.EditValue = entity.PayMethod;
            //    //明细数据
            //    string sql = "SELECT * FROM Sale_SODts WHERE MainID=" + SysString.ToDBString(soID);
            //    DataTable dt = SysUtils.Fill(sql);
            //    if (dt.Rows.Count != 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemCode", dt.Rows[i]["DtsItemCode"].ToString());
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemName", dt.Rows[i]["DtsItemName"].ToString());
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemStd", dt.Rows[i]["DtsItemStd"].ToString());
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemModel", dt.Rows[i]["DtsItemModel"].ToString());
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "Qty", SysConvert.ToInt32(dt.Rows[i]["Qty"].ToString()));
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "UnitPrice", SysConvert.ToInt32(dt.Rows[i]["UnitPrice"].ToString()));
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "Amount", dt.Rows[i]["Amount"].ToString());
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "YarnStatus", dt.Rows[i]["YarnStatus"].ToString());
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ColorNum", dt.Rows[i]["ColorNum"].ToString());
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ColorName", dt.Rows[i]["ColorName"].ToString());
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "DesignNO", dt.Rows[i]["DesignNO"].ToString());
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "EditionNo", dt.Rows[i]["EditionNo"].ToString());
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemUnit", entity.ItemUnit);
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "YarnTypeID", SysConvert.ToInt32(dt.Rows[i]["YarnTypeID"].ToString()));
            //        }
            //    }



            //}

        } 
        #endregion
        //公司别改变带入相关信息
        private void drpCompanyTypeID_EditValueChanged(object sender, EventArgs e)
        {
             try
            {
                CompanyType entity = new CompanyType();
                entity.ID = SysConvert.ToInt32(drpCompanyTypeID.EditValue);
                entity.SelectByID();
                txtAname.Text = entity.AllName;
                txtAaddress.Text = entity.Address;
                txtAfax.Text = entity.Fax;
                txtAtel.Text = entity.Tel;
             
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        
        }
        //客户改变带入相关信息
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM Data_Vendor WHERE VendorID="+SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if(dt.Rows.Count!=0)
                {
                    txtBname.Text = dt.Rows[0]["VendorName"].ToString();
                    txtBaddress.Text=dt.Rows[0]["Address"].ToString();
                    txtBfax.Text=dt.Rows[0]["Fax"].ToString();
                    txtBtel.Text = dt.Rows[0]["Tel"].ToString();
                }
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    Common.BindVendorSaleOPID(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);
                }
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        //单价数量离开计算金额
        private void txtUnitPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal TotalQty = 0.0m;
                decimal TotalMoney = 0.0m;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "Qty")) != "")
                    {
                        decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                        decimal DtsUnitPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "UnitPrice"));
                        decimal DtsAmount = SysConvert.ToDecimal(Qty * DtsUnitPrice, 2);

                        gridView1.SetRowCellValue(i, "Amount", DtsAmount);

                        TotalQty += Qty;
                        TotalMoney += DtsAmount;
                    }
                }

                txtTotalQty.Text = SysConvert.ToString(TotalQty);
                txtTotalAmount.Text = SysConvert.ToString(TotalMoney);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
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

         //<summary>
         //设计
         //</summary>
         //<param name="sender"></param>
         //<param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnDesign_Click(sender, e);
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

        /// <summary>
        /// 币种改变自动带出汇率和合同条款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpCurrencyID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ParamSetRule rule = new ParamSetRule();
                if (SysConvert.ToInt32(drpCurrencyID.EditValue) == (int)EnumCurrency.人民币)
                {
                    //txtTerms.Text = rule.RShowStrByCode((int)ParamSetEnum.中文合同条款);
                }
                else
                {
                    //txtTerms.Text = rule.RShowStrByCode((int)ParamSetEnum.英文合同条款);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

    }
}