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
    public partial class frmRecPayEdit : frmAPBaseUIFormEdit
    {
        public frmRecPayEdit()
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
            //if (SysConvert.ToInt32(drpRecPayType.EditValue) == 0)
            //{
            //    this.ShowMessage("请选择收付款类型");
            //    drpRecPayType.Focus();
            //    return false;
            //}

            //if (Common.CheckLookUpEditBlank(drpVendorID))
            //{
            //    this.ShowMessage("请选择往来单位");
            //    drpVendorID.Focus();
            //    return false;
            //}
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
            RecPayHXDtsRule rule = new RecPayHXDtsRule();
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
            // RecPayHXDts[] entitydts = EntityDtsGet();
            //decimal TotalCheckAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalCheckAmount+=SysConvert.ToDecimal(entitydts[i].DCheckAmount);
            //}
            //entity.TotalCheckAmount=TotalCheckAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity);//entitydts
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            RecPayRule rule = new RecPayRule();
            RecPay entity = EntityGet();
            //RecPayHXDts[] entitydts = EntityDtsGet();
            //decimal TotalCheckAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalCheckAmount+=SysConvert.ToDecimal(entitydts[i].DCheckAmount);
            //}
            //entity.TotalCheckAmount=TotalCheckAmount;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity);//entitydts
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            RecPay entity = new RecPay();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();


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
            txtSJAmount.Text = entity.SJAmount.ToString();
            txtHTDtsAmount.Text = entity.ExAmount.ToString();

            txtNoHXAmount.Text = entity.NoHXAmount.ToString();

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

            BindGridInvoiceDts();
            BindGridHTDts();
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
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2, gridView3 };
            this.HTCheckDataField = new string[] { "InvoiceOperationID", "InvoiceNo" };//数据明细校验必须录入字段
            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);
            Common.BindCLS(txtMoneyType, "Finance_RecPay", "MoneyType", true);
            Common.BindCLS(txtExMethod, "Finance_RecPay", "ExMethod", true);
            Common.BindPayStepType(drpPayStepType, true);

            txtHXQMakeDateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtHXQMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindOP(drpHXQSaleOPID, true);
            Common.BindRecPayType(drpRecPayType, true);
            if (this.FormListAID == (int)EnumRecPayType.收款)
            {
                DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.内销客户, (int)EnumVendorType.外销客户 }, true);
            }
            else if (this.FormListAID == (int)EnumRecPayType.付款)
            {
                DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.染厂, (int)EnumVendorType.其他加工厂, (int)EnumVendorType.加工户, (int)EnumVendorType.供应商 }, true);

            }
            else
            {
                Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.染厂, (int)EnumVendorType.工厂, (int)EnumVendorType.检测机构, (int)EnumVendorType.快递公司, (int)EnumVendorType.物流公司, (int)EnumVendorType.供应商 }, true);
            }




            this.gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);//绑定GridView2事件
            gridViewBindEventA2(gridView2);


            this.gridViewBaseRowChangedA3 += new gridViewBaseRowChangedA(gridViewRowChanged3);//绑定GridView2事件
            gridViewBindEventA3(gridView3);

        }

        #endregion

        #region 自定义方法

        void gridViewRowChanged2(object sender)
        {
            ColumnView view = sender as ColumnView;

            saveInvoiceID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            txtHXInvoiceNo.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["InvoiceNO"]));
            txtHXDtsAmount.Text = (SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["TotalAmount"])) -
                SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["PayAmount"]))).ToString();

        }

        void gridViewRowChanged3(object sender)
        {
            ColumnView view = sender as ColumnView;

            saveHTDtsID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));


        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        public string GetCondtioInvoiceDt()
        {
            string tempStr = string.Empty;
            if (txtHXQInvoiceNO.Text.Trim() != "")//查询d
            {
                tempStr = " AND InvoiceNO LIKE " + SysString.ToDBString("%" + txtHXQInvoiceNO.Text.Trim() + "%");
            }
            if (chkHXQMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtHXQMakeDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtHXQMakeDateE.DateTime.ToString("yyyy-MM-dd"));
            }
            //if (!Common.CheckLookUpEditBlank(drpVendorID))
            //{
            //    tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            //}
            else//没有客户所有都不筛选出
            {
                tempStr += " AND 1=0";
            }

            if (SysConvert.ToString(drpHXQSaleOPID.EditValue) != string.Empty)
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(drpHXQSaleOPID.EditValue.ToString());
            }
            tempStr += " AND SubmitFlag=1";
            tempStr += " AND DZTypeID IN(SELECT ID FROM Enum_DZType WHERE RecPayTypeID=" + SysString.ToDBString(SysConvert.ToInt32(drpRecPayType.EditValue)) + ")";//对账类型和收付款类型表是关联的
            if (chkHXOnlyNOFinish.Checked)
            {
                tempStr += " AND ISNULL(TotalAmount,0)<>ISNULL(PayAmount,0)";//查询数据不等
            }
            return tempStr;

        }
        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public void BindGridInvoiceDts()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            DataTable dt = rule.RShowPay(GetCondtioInvoiceDt() + " ORDER BY FormDate", ProcessGrid.GetQueryField(gridView2).Replace("NOHXAmount", "0.00 NOHXAmount"));
            foreach (DataRow dr in dt.Rows)
            {
                dr["NOHXAmount"] = SysConvert.ToDecimal(dr["TotalAmount"]) - SysConvert.ToDecimal(dr["PayAmount"]);
            }
            DataTable dtDts = dt;

            gridView2.GridControl.DataSource = dtDts;
            gridView2.GridControl.Show();
        }



        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public void BindGridHTDts()
        {
            RecPayHTDtsRule rule = new RecPayHTDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + this.HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView3).Replace("VFormNo", "'' VFormNo"));
            foreach (DataRow dr in dt.Rows)
            {
                dr["VFormNo"] = GetVOrderFormNo(dr["HTNo"].ToString());
            }
            DataTable dtDts = dt;

            gridView3.GridControl.DataSource = dtDts;
            gridView3.GridControl.Show();
        }


        private string GetVOrderFormNo(string p_FormNo)
        {
            string VFormNo = "";
            if (p_FormNo != "")
            {
                string sql = "SELECT CustomerCode FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(p_FormNo);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    VFormNo = SysConvert.ToString(dt.Rows[0][0]);
                }
            }
            return VFormNo;

        }


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
            entity.ExMethod = txtExMethod.Text.Trim();
            entity.ExOP = txtExOP.Text.Trim();
            entity.MoneyType = txtMoneyType.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.HTNo = txtHTNo.Text.Trim();
            entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim());
            entity.RecPayTypeID = SysConvert.ToInt32(drpRecPayType.EditValue);// this.FormListAID;
            entity.ExAmount = SysConvert.ToDecimal(txtExAmount.Text.Trim());
            entity.SJAmount = SysConvert.ToDecimal(txtSJAmount.Text.Trim());
            entity.PayStepTypeID = SysConvert.ToInt32(drpPayStepType.EditValue);
            entity.NoHXAmount = entity.ExAmount - entity.HXAmount;



            return entity;
        }

        #endregion




        #region 其它事件
        /// <summary>
        /// 检索发票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHXQuery_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridInvoiceDts();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



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
            string sql = "SELECT InSaleOP FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                string OPID = SysConvert.ToString(dt.Rows[0][0]);
                if (OPID != string.Empty)
                {
                    sql = "SELECT OPName,Phone FROM Data_OP WHERE OPID=" + SysString.ToDBString(OPID);
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
                            Context += entity.TaregtInfo + "你好！";
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
                RecPay entity = new RecPay();
                entity.ID = HTDataID;
                entity.SelectByID();
                if (entity.ReadFlag == 1)
                {
                    this.ShowMessage("该单据已阅，不能撤销");
                    return;
                }
                RecPayRule rule = new RecPayRule();
                rule.RSubmit(HTDataID, 0);

                FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 核销操作按钮事件
        /// <summary>
        /// 核销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHXExcute_Click(object sender, EventArgs e)
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
                    this.ShowMessage("请定位主记录");
                    return;
                }
                if (HTDataSubmitFlag != (int)YesOrNo.Yes)
                {
                    this.ShowMessage("单据未提交，不能操作");
                    return;
                }

                if (saveInvoiceID == 0)
                {
                    this.ShowMessage("请选择发票记录");
                    return;
                }
                if (SysConvert.ToDecimal(txtHXDtsAmount.Text.Trim()) == 0)
                {
                    this.ShowMessage("请输入核销金额");
                    txtHXDtsAmount.Focus();
                    return;
                }

                RecPayRule rule = new RecPayRule();
                RecPay entity = EntityGet();

                rule.RHX(entity, saveInvoiceID, SysConvert.ToDecimal(txtHXDtsAmount.Text.Trim()));

                FCommon.AddDBLog(this.Text, "核销", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 撤销核销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHXCancelExcute_Click(object sender, EventArgs e)
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
                    this.ShowMessage("请定位主记录");
                    return;
                }
                int dtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                if (dtsID == 0)
                {
                    this.ShowMessage("请选择核销记录");
                    return;
                }

                if (DialogResult.Yes != ShowConfirmMessage("确认撤销核销本条记录？"))
                {
                    return;
                }

                RecPayRule rule = new RecPayRule();
                RecPay entity = EntityGet();

                rule.RHXCancel(entity, dtsID);


                FCommon.AddDBLog(this.Text, "撤销核销", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 合同关联操作按钮
        /// <summary>
        /// 合同检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHTSearch_Click(object sender, EventArgs e)
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
                    this.ShowMessage("请定位主记录");
                    return;
                }
                if (HTDataSubmitFlag != (int)YesOrNo.Yes)
                {
                    this.ShowMessage("单据未提交，不能操作");
                    return;
                }

                if (SysConvert.ToInt32(drpRecPayType.EditValue) == (int)EnumRecPayType.收款)//加载销售合同
                {
                    frmLoadOrder frm = new frmLoadOrder();

                    string sql = string.Empty;
                    frm.NoLoadCondition = sql;
                    frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);

                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.OrderID != null && frm.OrderID.Length != 0)
                    {
                        for (int i = 0; i < frm.OrderID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.OrderID[i]);
                            break;//只加载一个合同号
                        }
                        setItemNewsSaleHT(str);
                    }
                }
                else if (SysConvert.ToInt32(drpRecPayType.EditValue) == (int)EnumRecPayType.付款)//加载采购合同
                {
                    frmLoadItemBuy frm = new frmLoadItemBuy();
                    frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
                    string sql = string.Empty;

                    frm.NoLoadCondition = sql;
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
                    {
                        for (int i = 0; i < frm.ItemBuyID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.ItemBuyID[i]);
                            break;//只加载一个合同号
                        }
                        setItemNewsBuyHT(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #region 加载合同数据
        /// <summary>
        /// 设置合同数据
        /// </summary>
        /// <param name="p_Str"></param>
        private void setItemNewsSaleHT(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    txtHTDtsHTNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    txtHTItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                    txtHTGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                }
            }
        }

        /// <summary>
        /// 加载采购单信息
        /// </summary>
        /// <param name="p_Str"></param>
        private void setItemNewsBuyHT(string p_Str)
        {
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//只有一行明细数据
                {
                    txtHTDtsHTNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    txtHTItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                    txtHTGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                }
            }
        }
        #endregion
        /// <summary>
        /// 合同关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHTExcute_Click(object sender, EventArgs e)
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
                    this.ShowMessage("请定位主记录");
                    return;
                }
                if (HTDataSubmitFlag != (int)YesOrNo.Yes)
                {
                    this.ShowMessage("单据未提交，不能操作");
                    return;
                }

                if (txtHTDtsHTNo.Text == "")
                {
                    this.ShowMessage("请检索关联合同号");
                    return;
                }
                if (SysConvert.ToDecimal(txtHTDtsAmount.Text.Trim()) == 0)
                {
                    this.ShowMessage("请输入关联金额");
                    txtHTDtsAmount.Focus();
                    return;
                }

                RecPayRule rule = new RecPayRule();
                RecPay entity = EntityGet();

                rule.RHT(entity, txtHTDtsHTNo.Text.Trim(), txtHTItemCode.Text.Trim(), txtHTGoodsCode.Text.Trim(), SysConvert.ToDecimal(txtHTDtsAmount.Text.Trim()), this.FormListAID);

                FCommon.AddDBLog(this.Text, "合同关联", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);

                SetCapFlag(1);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void SetCapFlag(int p_Flag)
        {
            string sql = "UPDATE Sale_SaleOrderDts SET CapFlag=" + p_Flag;
            sql += " WHERE MainID IN (SELECT ID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(txtHTDtsHTNo.Text.Trim()) + ")";
            sql += " AND ItemCode=" + SysString.ToDBString(txtHTItemCode.Text.Trim());
            SysUtils.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 合同取消关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHTExcuteCancel_Click(object sender, EventArgs e)
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
                    this.ShowMessage("请定位主记录");
                    return;
                }


                if (saveHTDtsID == 0)
                {
                    this.ShowMessage("请选择合同关联记录");
                    return;
                }
                if (DialogResult.Yes != ShowConfirmMessage("确认撤销关联本条记录？"))
                {
                    return;
                }

                RecPayRule rule = new RecPayRule();
                RecPay entity = EntityGet();

                rule.RHTCancel(entity, saveHTDtsID);

                FCommon.AddDBLog(this.Text, "取消合同关联", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);

                SetCapFlag(0);

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
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
                }

                else if (SysConvert.ToInt32(drpRecPayType.EditValue) == (int)EnumRecPayType.付款)
                {
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.染厂, (int)EnumVendorType.其他加工厂, (int)EnumVendorType.检测机构, (int)EnumVendorType.快递公司, (int)EnumVendorType.物流公司, (int)EnumVendorType.供应商, (int)EnumVendorType.织厂 }, true);
                }

                else
                {
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.染厂, (int)EnumVendorType.工厂, (int)EnumVendorType.检测机构, (int)EnumVendorType.快递公司, (int)EnumVendorType.物流公司, (int)EnumVendorType.供应商 }, true);
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


    }
}