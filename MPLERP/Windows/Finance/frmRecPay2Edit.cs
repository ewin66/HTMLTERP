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
    public partial class frmRecPay2Edit : frmAPBaseUIFormEdit
    {
        public frmRecPay2Edit()
        {
            InitializeComponent();
        }


        #region 全局变量
        int saveInvoiceID = 0;//发票ID
        int saveHTDtsID = 0;//合同明细ID
        #endregion
        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入色卡编号");
            //    txtCode.Focus();
            //    return false;
            //}
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入单号");
                txtFormNo.Focus();
                return false;
            }
            if (SysConvert.ToInt32(drpRecPayType.EditValue) == 0)
            {
                this.ShowMessage("请选择收付款类型");
                drpRecPayType.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择往来单位");
                drpVendorID.Focus();
                return false;
            }
            //if (Common.CheckLookUpEditBlank(drpPayStepType))
            //{
            //    this.ShowMessage("请选择收付款阶段");
            //    drpVendorID.Focus();
            //    return false;
            //}


            if (SysConvert.ToDecimal(txtExAmount.Text.Trim()) == 0)
            {
                this.ShowMessage("请输入金额");
                txtExAmount.Focus();
                return false;
            }

          

            //if (!this.CheckCorrectDts())
            //{
            //    return false;
            //}

            return true;
        }


        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            RecPayDtsRule rule = new RecPayDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }



        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            RecPayRule rule = new RecPayRule();
            RecPay entity = EntityGet();
            RecPayDts[] entitydts = EntityDtsGet();
            //decimal TotalCheckAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalCheckAmount+=SysConvert.ToDecimal(entitydts[i].DCheckAmount);
            //}
            //entity.TotalCheckAmount=TotalCheckAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);//entitydts
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            RecPayRule rule = new RecPayRule();
            RecPay entity = EntityGet();
            RecPayDts[] entitydts = EntityDtsGet();
            //decimal TotalCheckAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalCheckAmount+=SysConvert.ToDecimal(entitydts[i].DCheckAmount);
            //}
            //entity.TotalCheckAmount=TotalCheckAmount;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);//entitydts
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            RecPay entity = new RecPay();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			
  			txtFormNo.Text = entity.FormNo.ToString();  
  			txtMakeDate.DateTime = entity.MakeDate;
            drpVendorID.EditValue = entity.VendorID;
  			txtRemark.Text = entity.Remark.ToString();
            txtExBank.Text = entity.ExBank.ToString();
            txtExDate.DateTime = entity.ExDate;
            txtExMethod.Text = entity.ExMethod.ToString();
            txtExOP.Text = entity.ExOP.ToString();
            txtExAmount.Text = entity.ExAmount.ToString();
            txtMoneyType.Text = entity.MoneyType.ToString();
            txtRate.Text = entity.Rate.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            drpPayStepType.EditValue = entity.PayStepTypeID;
            txtHXAmount.Text = entity.HXAmount.ToString();
            txtHTNo.Text = entity.HTNo.ToString();
            txtHTGCode.Text = entity.HTGoodsCode.ToString();
            drpRecPayType.EditValue = entity.RecPayTypeID;
            txtNoHXAmount.Text = entity.NoHXAmount.ToString();

            txtPreAmount.Text = entity.PreAmount.ToString();
            txtSaleAmount.Text = entity.SaleAmount.ToString();
            txtYJAmount.Text = entity.YJAmount.ToString();
            txtLeftAmount.Text = entity.LeftAmount.ToString();
            txtOtherAmount.Text = entity.OtherAmount.ToString();
            txtSJAmount.Text = entity.SJAmount.ToString();

            ChkNoAmount.EditValue = entity.NoAmountFlag;

            if (entity.HXFlag == (int)YesOrNo.Yes)
            {
                txtHXFlag.Text = "已核销完";
            }
            else
            {
                txtHXFlag.Text = "未核销完";
            }
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
            RecPayRule rule = new RecPayRule();
            RecPay entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            base.IniInsertSet();
            if (this.FormListAID != 0)
            {
                drpRecPayType.EditValue = this.FormListAID;//收付款类型
            }
            txtMakeDate.DateTime = DateTime.Now;
            txtFormNo_DoubleClick(null, null);
            txtExDate.DateTime = DateTime.Now.Date;
            txtMoneyType.Text = "RMB";



            string sql = string.Empty;
            sql = "SELECT ID,CLSNM FROM Data_CLS WHERE CLSListID IN(SELECT ID FROM Data_CLSList  WHERE 1=1";
            sql += " AND CLSA='Finance_CostRecord' AND CLSB='CostType')";
            sql += " AND ISNULL(DelFlag,0)=0";
            sql += " ORDER BY CLSIDC,CLSNM";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    gridView1.SetRowCellValue(i, "Project", SysConvert.ToString(dt.Rows[i]["CLSNM"]));
                }
            }
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI
            this.HTDataTableName = "Finance_RecPay";
            this.HTDataDts = gridView1;
            //this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2, gridView3 };
            this.HTCheckDataField = new string[] { "Project" };//数据明细校验必须录入字段
            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);
            Common.BindCLS(txtMoneyType, "Finance_RecPay", "MoneyType", true);
            Common.BindCLS(txtExMethod, "Finance_RecPay", "ExMethod", true);
            Common.BindPayStepType(drpPayStepType, true);
            Common.BindOP(drpSaleOPID, true);
            if (FParamConfig.LoginHTFlag)
            {
                btnGs.Visible = true;
            }
            Common.BindRecPayType(drpRecPayType, true);
            if (this.FormListAID == (int)EnumRecPayType.收款)
            {
                DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            }
            else if (this.FormListAID == (int)EnumRecPayType.付款)
            {
                DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.染厂, (int)EnumVendorType.工厂, (int)EnumVendorType.检测机构, (int)EnumVendorType.快递公司, (int)EnumVendorType.物流公司, (int)EnumVendorType.供应商 }, true);
            }
            else
            {
                DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.染厂, (int)EnumVendorType.工厂, (int)EnumVendorType.检测机构, (int)EnumVendorType.快递公司, (int)EnumVendorType.物流公司, (int)EnumVendorType.供应商 }, true);
            }
            //new VendorProc(drpVendorID);



         
        }

        #endregion

        #region 自定义方法 
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private RecPay EntityGet()
        {
            RecPay entity = new RecPay();
            entity.ID = HTDataID;
            entity.SelectByID();
            
  			entity.FormNo = txtFormNo.Text.Trim(); 
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
  			entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.ExBank = txtExBank.Text.Trim();
            entity.ExDate = txtExDate.DateTime;
            entity.ExMethod=txtExMethod.Text.Trim();
            entity.ExOP = txtExOP.Text.Trim();
            entity.MoneyType = txtMoneyType.Text.Trim();
  			entity.Remark = txtRemark.Text.Trim();
            entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim());
            entity.RecPayTypeID = SysConvert.ToInt32(drpRecPayType.EditValue);// this.FormListAID;
            entity.ExAmount = SysConvert.ToDecimal(txtExAmount.Text.Trim());
            entity.PayStepTypeID = SysConvert.ToInt32(drpPayStepType.EditValue);
            entity.NoHXAmount = entity.ExAmount - entity.HXAmount;

            entity.PreAmount = SysConvert.ToDecimal(txtPreAmount.Text.Trim());//账户金额
            entity.SaleAmount = SysConvert.ToDecimal(txtSaleAmount.Text.Trim());//销售金额
            entity.YJAmount = SysConvert.ToDecimal(txtYJAmount.Text.Trim());//佣金
            entity.LeftAmount = entity.PreAmount + entity.SaleAmount - entity.ExAmount + entity.YJAmount;//期末金额=帐号余额+销售金额-收款金额+佣金

            entity.SJAmount = SysConvert.ToDecimal(txtSJAmount.Text.Trim());//实际到账金额
            entity.OtherAmount = SysConvert.ToDecimal(txtOtherAmount.Text.Trim());//其他金额

            entity.NoAmountFlag = SysConvert.ToInt32(ChkNoAmount.EditValue);
  			 
            
            return entity;
        }


        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private RecPayDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            RecPayDts[] entitydts = new RecPayDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new RecPayDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].Project = SysConvert.ToString(gridView1.GetRowCellValue(i, "Project"));
                    entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

      


        #region 其它事件
       
        


        /// <summary>
        /// 单号生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.收付款单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region 提交、撤销提交处理
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                RecPayRule rule = new RecPayRule();
                rule.RSubmit(HTDataID, 1);

                //RAddNews();


                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 增加
        /// </summary>
        private void RAddNews()
        {
            string sql = "SELECT InSaleOP FROM Data_Vendor WHERE VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                string OPID=SysConvert.ToString(dt.Rows[0][0]);
                if (OPID != string.Empty)
                {
                    sql = "SELECT OPName,Phone FROM Data_OP WHERE OPID="+SysString.ToDBString(OPID);
                    dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        string tel = SysConvert.ToString(dt.Rows[0]["Phone"]);
                        if (tel.Length == 11)
                        {
                            MSGMainRule rule = new MSGMainRule();
                            MSGMain entity = new MSGMain();
                            entity.FormDate = DateTime.Now;
                            entity.InsertTime = DateTime.Now;
                            entity.MSGSourceID = (int)EnumMSGSource.收付款;
                            entity.SendPhone = "13916054226";
                            entity.TargetPhone = tel;
                            entity.TaregtInfo = SysConvert.ToString(dt.Rows[0]["OPName"]);
                            entity.SendTime = DateTime.Now;
                            string Context = "";
                            Context += entity.TaregtInfo+"你好！";
                            Context += Common.GetVendorNameByVendorID(drpVendorID.EditValue.ToString());
                            Context += "已来款，来款金额是：";
                            Context += txtExAmount.Text.Trim();
                            Context += "请查看   上海德奕纺织品有限公司";
                            entity.Context = Context;
                            entity.SendDesc = "来源：收付款，单号：" + txtFormNo.Text.Trim();
                            entity.SendInfo += ",发件人：上海德奕纺织品有限公司";
                            entity.DID = HTDataID;
                            rule.RAdd(entity);
                            this.ShowInfoMessage("短信已发送给业务员！");
                            
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 撤销提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmitCancel_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                RecPayRule rule = new RecPayRule();
                rule.RSubmit(HTDataID,0);

                FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

     
    

        private void drpRecPayType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpRecPayType.EditValue) == (int)EnumRecPayType.收款)
                {
                    DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
                }

                else if (SysConvert.ToInt32(drpRecPayType.EditValue) == (int)EnumRecPayType.付款)
                {
                    DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.染厂, (int)EnumVendorType.工厂, (int)EnumVendorType.检测机构, (int)EnumVendorType.快递公司, (int)EnumVendorType.物流公司, (int)EnumVendorType.供应商 }, true);
                }
                
                else
                {
                    DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.染厂, (int)EnumVendorType.工厂, (int)EnumVendorType.检测机构, (int)EnumVendorType.快递公司, (int)EnumVendorType.物流公司, (int)EnumVendorType.供应商 }, true);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void frmRecPayEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    RecPay entity = new RecPay();
                    entity.ID = HTDataID;
                    entity.SelectByID();
                    if (entity.SubmitFlag == 0)
                    {
                        if (DialogResult.Yes != ShowConfirmMessage(this.Text + Environment.NewLine + "没有提交单据,是否确认关闭窗体"))
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void groupControlMainten_Paint(object sender, PaintEventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            label24.Visible = true;
        }

        private void label24_Click_1(object sender, EventArgs e)
        {
            label24.Visible = false;
        }


    }
}