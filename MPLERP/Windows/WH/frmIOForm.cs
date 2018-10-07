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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：出入库列表
    /// </summary>
    public partial class frmIOForm :frmAPBaseUIWHForm// frmAPBaseUIForm //frmAPBaseUIWHForm
    {
        public frmIOForm()
        {
            InitializeComponent();
        }

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
            if (SysConvert.ToString(drpQWHTypeID.EditValue) != "")
            {
                tempStr += " AND WHTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQWHTypeID.EditValue));
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
          
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }

            if (txtQItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }
            if (txtQColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (txtQColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtQColorName.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != "")
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQBatch.Text.Trim() != "")
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtQBatch.Text.Trim() + "%");
            }
            if (txtQVendorBatch.Text.Trim() != "")
            {
                tempStr += " AND VendorBatch LIKE " + SysString.ToDBString("%" + txtQVendorBatch.Text.Trim() + "%");
            }
            if (txtQFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtQFormNo.Text.Trim() + "%");
            }
           

            switch (drpQSubmitFlagType.SelectedIndex)
            {
                case 1://已提交
                    tempStr += " AND isnull(SubmitFlag,0) =1";
                    break;
                case 2://未提交
                    tempStr += " AND isnull(SubmitFlag,0) =0";
                    break;
            }
            switch (drpQDelFlagType.SelectedIndex)
            {
                case 1://未删除
                    tempStr += " AND isnull(DelFlag,0) =0";
                    break;
                case 2://已删除
                    tempStr += " AND isnull(DelFlag,0) =1";
                    break;
            }




            tempStr += Common.GetWHRightCondition();

            if (this.FormListAID != 0)
            {
                tempStr += " AND HeadType=" + this.FormListAID;
            }
            if (this.FormListBID != 0)
            {
                tempStr += " AND SubType=" + this.FormListBID;
            }

            //tempStr += " AND HeadType in( Select ID From Enum_FormList WHERE WHFormTypeID=" + SysString.ToDBString(this.FormListAID)+")";

            if (chkQFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQFormDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQFormDateE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }


            if (SysConvert.ToString(drpQCompanyTypeID.EditValue) != "")
            {
                tempStr += " AND CompanyTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQCompanyTypeID.EditValue));
            }



           // tempStr += "";
            // FParamConfig.LoginID
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                tempStr += " AND DutyOP in (SELECT OPID FROM  Data_OPSaleGroup WHERE SaleGroupID IN(SELECT SaleGroupID FROM Data_OPSaleGroup WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID) + "))";
            }


            tempStr += " Order By FormDate DESC ";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            //IOFormRule rule = new IOFormRule();


            string ConditionAttn = " AND HeadType=" + this.FormListAID;
            ConditionAttn += " AND SubType in(Select ID FROM  Enum_FormList WHERE IsShow=1 )";
            //ConditionAttn += " AND WHID in(Select WHID FROM  WH_WH WHERE isnull(IsJK,0)=0 )";//2012-2-23caoxg





            //gridView2.GridControl.DataSource = rule.RShow(ConditionAttn + HTDataConditionStr, ProcessGrid.GetQueryField(gridView2));
            //gridView2.GridControl.Show();


            IOFormDtsRule rule = new IOFormDtsRule();
           

            //gridView2.GridControl.DataSource = rule.RShow(ConditionAttn + HTDataConditionStr, ProcessGrid.GetQueryField(gridView2));
            DataTable dt = rule.RShow(ConditionAttn + HTDataConditionStr, ProcessGrid.GetQueryField(gridView2).Replace("MakeOPName", "''MakeOPName"));
            ProductMakeOP(dt);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
           
        }

        /// <summary>
        ///  色纱入库——显示订单经办人的姓名
        /// </summary>
        private void ProductMakeOP(DataTable p_Dt)
        {
            //经办人
            foreach (DataRow dr in p_Dt.Rows)
            {
                string sqlMakeOP = "SELECT MakeOPName FROM UV1_Buy_ColorCompact WHERE 1=1 AND CODE =" + SysString.ToDBString(dr["DtsSo"].ToString()) + "GROUP BY MakeOPName"; 
                DataTable dtMakeOP = SysUtils.Fill(sqlMakeOP);
                if (dtMakeOP.Rows.Count != 0)
                {


                    dr["MakeOPName"] = SysConvert.ToString(dtMakeOP.Rows[0]["MakeOPName"]);

                }
            }

        }









        /// <summary>
        /// 绑定Grid
        /// </summary>
        private void BindGridDts()
        {
            IOFormDtsRule rule = new IOFormDtsRule();
            gridView2.GridControl.DataSource = rule.RShow(HTDataID, ProcessGrid.GetQueryField(gridView2));
            gridView2.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView2, new string[] { "ID" }, new string[] { tempID.ToString() });
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView2;

            ProcessGrid.BindGridColumn(gridView2, this.FormID);//绑定列
            ProcessGrid.SetGridColumnUI(gridView2, this.FormListAID, this.FormListBID);//设置列UI
            switch (FormListAID)
            {
                //case (int)WHFormList.坯纱入库单:
                //    //label12.Text = "纱线成份";
                //    //label13.Text = "纱线支数";
                //    break;
                //case (int)WHFormList.色纱入库单:
                //    //label12.Text = "纱线成份";
                //    //label13.Text = "纱线支数";
                //    break;
                //case (int)WHFormList.色纱出库单://20100518
                //    //label12.Text = "纱线成份";
                //    //label13.Text = "纱线支数";
                //    break;
                case (int)WHFormList.入库:
                   // this.Name = "frmInWH";
                    //label12.Text = "纱线成份";
                    //label13.Text = "纱线支数";
                    break;
                case (int)WHFormList.出库:
                   // this.Name = "frmOutWH";
                    //label6.Text = "加工厂/客户";
                    break;
                case (int)WHFormList.期初入库:
                   // this.Name = "frmDefaultWH";
                    break;
                case (int)WHFormList.移库:
                  //  this.Name = "frmMoveWH";
                    break;
                case (int)WHFormList.盘点:
                  // this.Name = "frmCheckWH";
                    break;
            }

            //drpQWHFormTypeID.SelectedIndex = this.FormListAID;

            txtQFormDateS.DateTime = DateTime.Now.AddDays(0 - ParamConfig.QueryDayNum);
            txtQFormDateE.DateTime = DateTime.Now.Date;

            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂 }, true);//客户 
            Common.BindCompanyType(drpQCompanyTypeID, true);

            Common.BindWHType(drpQWHTypeID, false);
            Common.BindWH(drpQWHID, true);
            Common.BindCompanyType(drpGridCompanyTypeID, false);//公司别
            Common.BindWHType(drpGridSubType, false);//仓库类型
            Common.BindWH(drpGridWHID, false);//仓库
            //new ItemProcLookUp(drpQItemCode, new int[] { 1 }, true, true);//(int)ItemType.纱线
            //this.SaveItemType = Common.GetItemTypeByFormListID(this.FormListAID);//获得单据主类型

            new ItemProcLookUp(drpQItemCode, Common.GetItemTypeByFormListID(this.FormListAID), true, true);//(int)ItemType.纱线

           // btnQuery_Click(null, null);

            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView2);
            SetTabIndex(0, groupControlQuery);
            new VendorProc(drpQVendorID);

            this.IsPostBack = false;
            //btnInsertVisible = false; //隐藏新建按钮
            //btnInsertExistVisible = false;//隐藏复制按钮
            //btnDeleteVisible = false;//隐藏删除按钮
            txtQFormNo_EditValueChanged(null,null);
        }
        
        



        /// <summary>
        ///通用 重新设置实体1，如果不要使用，则重写，一般不要修改
        /// </summary>
        public override void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            HTDataID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            HTDataSubmitFlag = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SubmitFlag"]));
            HTDataDelFlag = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DelFlag"]));

            //SetToolButtonStatus(HTDataSubmitFlag, HTDataDelFlag);

            //BindGridDts();
        }


        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        #region 按钮
        ///// <summary>
        ///// 查询
        ///// </summary>
        //public override void btnQuery_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnQuery_Click(sender, e);
        //        this.GetCondtion();
        //        this.BindGrid();
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        ///// <summary>
        ///// 浏览
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnBrowse_Click(sender, e);
        //        this.BaseFocusLabel.Focus();
        //        LoadIOFormWin(HTDataID, FormStatus.查询);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// 提交
        ///// </summary>
        //public override void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.审核1))
        //        //{
        //        //    this.ShowMessage("你没有此操作权限");
        //        //    return;
        //        //}

        //        //IOFormRule rule = new IOFormRule();
        //        //IOForm entity = new IOForm();
        //        //entity.ID = HTDataID;
        //        //entity.SelectByID();

        //        //rule.RSubmit(this.HTDataID, (int)ConfirmFlag.已提交, Common.GetFormListTopTypeByFormListID(entity.HeadType), entity.ID, entity.SubType);//入库/出库
        //        //FCommon.AddDBLog(this.Text, "提交", "ID:" + HTDataID.ToString(), "");
        //        //SetPosStatus(this.HTDataID);

        //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
        //        {
        //            this.ShowMessage("你没有此操作权限");
        //            return;
        //        }

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }
        //        //if (!HTSubmitCheck(FormStatus.提交))
        //        //{
        //        //    return;
        //        //}

        //        //HTSubmit(HTDataTableName, HTDataID.ToString());


        //        IOFormRule rule = new IOFormRule();
        //        rule.RSubmit(HTDataID, (int)ConfirmFlag.已提交);

        //        FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
        //        this.SetPosStatus(HTDataID);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        ///// <summary>
        ///// 撤销提交
        ///// </summary>
        //public override void btnSubmitCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.审核1))
        //        //{
        //        //    this.ShowMessage("你没有此操作权限");
        //        //    return;
        //        //}
        //        //IOFormRule rule = new IOFormRule();
        //        //IOForm entity = new IOForm();
        //        //entity.ID = this.HTDataID;
        //        //entity.SelectByID();
        //        //rule.RSubmit(this.HTDataID, (int)ConfirmFlag.未提交, Common.GetFormListTopTypeByFormListID(entity.HeadType), entity.ID, entity.SubType);
        //        //FCommon.AddDBLog(this.Text, "撤销提交", "ID:" + HTDataID.ToString(), "");
        //        //SetPosStatus(this.HTDataID);

        //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
        //        {
        //            this.ShowMessage("你没有此操作权限");
        //            return;
        //        }

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }
        //        //if (!HTSubmitCheck(FormStatus.提交))
        //        //{
        //        //    return;
        //        //}

        //        //HTSubmit(HTDataTableName, HTDataID.ToString());


        //        IOFormRule rule = new IOFormRule();
        //        rule.RSubmit(HTDataID, (int)ConfirmFlag.未提交);

        //        FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
        //        this.SetPosStatus(HTDataID);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        ///// <summary>
        ///// 审核通过
        ///// </summary>
        //public override void btnAudit_Click(object sender, EventArgs e)
        //{
        //    base.btnAudit_Click(sender, e);
        //}
        ///// <summary>
        ///// 审核拒绝
        ///// </summary>
        //public override void btnAuditCancel_Click(object sender, EventArgs e)
        //{
        //    base.btnAuditCancel_Click(sender, e);
        //}

        ///// <summary>
        ///// 新增
        ///// </summary>
        //public override void btnInsert_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnInsert_Click(sender, e);
        //        this.BaseFocusLabel.Focus();
        //        LoadIOFormWin(HTDataID, FormStatus.新增);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //public override void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnUpdate_Click(sender, e);
        //        this.BaseFocusLabel.Focus();
        //        LoadIOFormWin(HTDataID, FormStatus.修改);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnDelete_Click(sender, e);
        //        this.BaseFocusLabel.Focus();
        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }
        //        if (DialogResult.Yes != this.ShowConfirmMessage("删除为不可恢复操作，确定删除"))
        //        {
        //            return;
        //        }

        //        IOForm entity = new IOForm();
        //        entity.ID = HTDataID;
        //        IOFormRule rule = new IOFormRule();
        //        rule.RDelete(entity);
        //        btnQuery_Click(null, null);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        ///// <summary>
        ///// 转Excel
        ///// </summary>
        //public override void btnToExcel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnToExcel_Click(sender, e);
        //        this.ToExcel((GridView)gridControlDetail.MainView);
        //        FCommon.AddDBLog(this.Text, "导出报表", "", "");
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        #endregion

        #region 加载仓库单据
        /// <summary>
        /// 加载仓库单据
        /// </summary>
        /// <param name="p_IOFormID"></param>
        private void LoadIOFormWin(int p_IOFormID, FormStatus p_FormStatus)
        {
            string sql = "SELECT HeadType,SubType FROM WH_IOForm WHERE ID=" + SysString.ToDBString(p_IOFormID);
            DataTable dt = SysUtils.Fill(sql);
            int headtype = 0;
            int subtype = 0;
            int toptypeid = 0;
            string formClassName = string.Empty;
            if (dt.Rows.Count != 0)//
            {
                headtype = SysConvert.ToInt32(dt.Rows[0]["HeadType"]);
                subtype = SysConvert.ToInt32(dt.Rows[0]["SubType"]);

            }
            else
            {
                headtype = this.FormListAID;
            }

            toptypeid = Common.GetFormListTopTypeByFormListID(this.FormListAID);
            switch (toptypeid)
            {
                case (int)WHFormList.入库:
                    formClassName = "frmInWHEdit";
                    //this.RightFormID = this.GetFormIDByClassName("frmInWHEdit");
                    break;
                case (int)WHFormList.出库:
                    formClassName = "frmOutWHEdit";
                    break;
                //case (int)WHFormList.形态转换:
                //    formClassName = "frmTurnForm";
                //    break;
                case (int)WHFormList.期初入库:
                    formClassName = "frmDefaultInWHEdit";
                    //headtype = this.FormListAID;
                    break;

                case (int)WHFormList.盘点:
                    formClassName = "frmCheckWHEdit";
                    //headtype = this.FormListAID;
                    break;
                case (int)WHFormList.移库:
                    formClassName = "frmMoveWHEdit";
                    //headtype = this.FormListAID;
                    break;
            }
            if (formClassName != string.Empty)
            {
                MDIForm.ContextMenuOpenForm(null,formClassName, headtype, 0, p_IOFormID.ToString(), p_FormStatus);
            }
        }
        #endregion

        #region 其他事件
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQFormNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetCondtion();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void txtQItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtQItemName.Text = "";
                txtQItemStd.Text = "";
                //txtQItemModel.Text = "";
                string sql = "SELECT ItemName,ItemStd,ItemAttnCode FROM Data_Item WHERE 1=1 AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text.Trim());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    txtQItemName.Text = dt.Rows[0]["ItemName"].ToString();
                    txtQItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
                    //txtQItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
                }
                txtQFormNo_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }
    }
}