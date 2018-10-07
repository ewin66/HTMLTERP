using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;


namespace MLTERP
{
    /// <summary>
    /// 仓库主从表列表页面
    /// </summary>
    public partial class frmAPBaseUIWHForm : frmAPBaseTool
    {
        public frmAPBaseUIWHForm()
        {
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// 查询条件
        /// </summary>
        private string _HTDataConditionStr = string.Empty;
        /// <summary>
        /// 查询条件
        /// </summary>
        public string HTDataConditionStr
        {
            get
            {
                return _HTDataConditionStr;
            }
            set
            {
                _HTDataConditionStr = value;
            }
        }
       // private bool _IsPostBack = true;
        private bool _IsPostBack = false;
        /// <summary>
        /// 初始化查询控制
        /// </summary>
        public bool IsPostBack
        {
            get
            {
                return _IsPostBack;
            }
            set
            {
                _IsPostBack = value;
            }
        }
        /// <summary>
        /// 数据列表
        /// </summary>
        private GridView _HTDataList = new GridView();
        /// <summary>
        /// 数据列表
        /// </summary>
        public GridView HTDataList
        {
            get
            {
                return _HTDataList;
            }
            set
            {
                _HTDataList = value;
            }
        }
        #endregion

        #region 控件显示
        /// <summary>
        /// 新增按钮
        /// </summary>
        private bool _btnInsertVisible = true;
        /// <summary>
        ///  新增按钮
        /// </summary>
        public bool btnInsertVisible
        {
            get
            {
                return _btnInsertVisible;
            }
            set
            {
                _btnInsertVisible = value;
            }
        }

        /// <summary>
        /// 修改按钮
        /// </summary>
        private bool _btnUpdateVisible = true;
        /// <summary>
        ///  修改按钮
        /// </summary>
        public bool btnUpdateVisible
        {
            get
            {
                return _btnUpdateVisible;
            }
            set
            {
                _btnUpdateVisible = value;
            }
        }


        /// <summary>
        ///删除按钮
        /// </summary>
        private bool _btnDeleteVisible = true;
        /// <summary>
        ///  删除按钮
        /// </summary>
        public bool btnDeleteVisible
        {
            get
            {
                return _btnDeleteVisible;
            }
            set
            {
                _btnDeleteVisible = value;
            }
        }



        /// <summary>
        ///复制
        /// </summary>
        private bool _btnInsertExistVisible = true;
        /// <summary>
        ///  复制
        /// </summary>
        public bool btnInsertExistVisible
        {
            get
            {
                return _btnInsertExistVisible;
            }
            set
            {
                _btnInsertExistVisible = value;
            }
        }

        /// <summary>
        ///提交按钮
        /// </summary>
        private bool _btnSubmitVisible = false;
        /// <summary>
        ///  提交按钮
        /// </summary>
        public bool btnSubmitVisible
        {
            get
            {
                return _btnSubmitVisible;
            }
            set
            {
                _btnSubmitVisible = value;
            }
        }
        /// <summary>
        ///撤销提交按钮
        /// </summary>
        private bool _btnSubmitCancelVisible = false;
        /// <summary>
        ///  撤销提交按钮
        /// </summary>
        public bool btnSubmitCancelVisible
        {
            get
            {
                return _btnSubmitCancelVisible;
            }
            set
            {
                _btnSubmitCancelVisible = value;
            }
        }


        /// <summary>
        ///打印组件
        /// </summary>
        private bool _btnPrintVisible = true;
        /// <summary>
        ///  打印组件
        /// </summary>
        public bool btnPrintVisible
        {
            get
            {
                return _btnPrintVisible;
            }
            set
            {
                _btnPrintVisible = value;
            }
        }

        /// <summary>
        ///连续新增
        /// </summary>
        private bool _ContinueInsert = false;
        /// <summary>
        ///  连续新增
        /// </summary>
        public bool ContinueInsert
        {
            get
            {
                return _ContinueInsert;
            }
            set
            {
                _ContinueInsert = value;
            }
        }
          #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public virtual void GetCondtion()
        {
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public virtual void BindGrid()
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        public virtual void EntityDelete()
        {
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public virtual void IniData()
        {
        }

        /// <summary>
        /// 通用窗体加载方法，如果不要使用，则重写，一般不要修改
        /// </summary>
        public virtual void IniFormLoadBefore()
        {

            if (_HTDataList.Columns.Count != 0)
            {
                ProcessGrid.BindGridColumn(_HTDataList, this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(_HTDataList, this.FormListAID, this.FormListBID);//设置列UI
                this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
                gridViewBindEventA1(_HTDataList);
                //_HTDataList.DoubleClick += new EventHandler(btnBrowse_Click);
                _HTDataList.GridControl.DoubleClick += new EventHandler(btnBrowse_Click);
            }

            ProcessGrid.SetGridReadOnly(_HTDataList,true);
            ProcessGrid.SetGridUIListDefault(_HTDataList);
            FCommon.AddDBLog(this.Text, "查询", " ", "");
            if (IsPostBack)
            {
                btnQuery_Click(null, null);
            }

            SetToolButtonVisible();
        }

        /// <summary>
        /// 通用窗体加载方法，如果不要使用，则重写，一般不要修改
        /// </summary>
        public virtual void IniFormLoadBehind()
        {
        }

        /// <summary>
        ///通用 重新设置实体1，如果不要使用，则重写，一般不要修改
        /// </summary>
        public virtual void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            HTDataID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            HTDataSubmitFlag = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SubmitFlag"]));
            HTDataDelFlag = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DelFlag"]));

            SetToolButtonStatus(HTDataSubmitFlag, HTDataDelFlag);
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 转向目标页
        /// </summary>
        public void NavigateWin(string p_FormClassName, string p_ParentID, FormStatus p_MFormStatus)
        {
            MDIForm.ContextMenuOpenForm(FUISourceObject.GetResultArrayList(FUISourceObject.SourceForm, this), p_FormClassName, this.FormListAID, this.FormListBID, this.SubmitFlag, this.AuditFlag, p_ParentID, p_MFormStatus);
        }
        #endregion

        #region 按钮虚方法定义
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnQuery_Click(object sender, EventArgs e)
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

        /// <summary>
        /// 浏览事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择记录");
                    return;
                }
                //this.NavigateWin(this.Name + "Edit", HTDataID.ToString(), FormStatus.查询);
                this.BaseFocusLabel.Focus();
                LoadIOFormWin(HTDataID, FormStatus.查询);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 新增事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                //this.NavigateWin(this.Name + "Edit", HTDataID.ToString(), FormStatus.新增);

                this.BaseFocusLabel.Focus();
                LoadIOFormWin(HTDataID, FormStatus.新增);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnUpdate_Click(object sender, EventArgs e)
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
                    this.ShowMessage("请选择记录");
                    return;
                }
                if (!HTSubmitCheck(FormStatus.修改))
                {
                    return;
                }

                this.BaseFocusLabel.Focus();
                LoadIOFormWin(HTDataID, FormStatus.修改);
                //this.NavigateWin(this.Name + "Edit", HTDataID.ToString(), FormStatus.修改);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDelete_Click(object sender, EventArgs e)
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
                    this.ShowMessage("请选择记录");
                    return;
                }
                if (!HTSubmitCheck(FormStatus.删除))
                {
                    return;
                }

                if (DialogResult.Yes != ShowConfirmMessage("删除为不可恢复操作，确认删除本条记录？"))
                {
                    return;
                }

                EntityDelete();//调用虚方法

                FCommon.AddDBLog(this.Text, "删除", "ID:" + HTDataID, "");
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 导出列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.ToExcelSelectColumn(_HTDataList);
                FCommon.AddDBLog(this.Text, "导出列表", "", "");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 按钮状态设置方法
        /// <summary>
        /// 设置操作按钮可显示
        /// </summary>
        public void SetToolButtonVisible()
        {
            ButtonItem p_Insert = ToolBarItemGet(-1, ToolButtonName.btnInsert.ToString());
            ButtonItem p_Update = ToolBarItemGet(-1, ToolButtonName.btnUpdate.ToString());
            ButtonItem p_Delete = ToolBarItemGet(-1, ToolButtonName.btnDelete.ToString());
            ButtonItem p_InsertExis = ToolBarItemGet(-1, ToolButtonName.btnInsertExist.ToString());

            ButtonItem p_Submit = ToolBarItemGet(-1, ToolButtonName.btnSubmit.ToString());
            ButtonItem p_SubmitCancel = ToolBarItemGet(-1, ToolButtonName.btnSubmitCancel.ToString());

            ButtonItem p_Preview = ToolBarItemGet(-1, ToolButtonName.btnPreview.ToString());
            ButtonItem p_Print = ToolBarItemGet(-1, ToolButtonName.btnPrint.ToString());
            ButtonItem p_Design = ToolBarItemGet(-1, ToolButtonName.btnDesign.ToString());
            ComboBoxItem p_PrintFile = ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());



            p_Insert.Visible = _btnInsertVisible;
            p_Delete.Visible = _btnDeleteVisible;
            p_Update.Visible = _btnUpdateVisible;
            p_InsertExis.Visible = _btnInsertExistVisible;

            p_Submit.Visible = _btnSubmitVisible;
            p_SubmitCancel.Visible = _btnSubmitCancelVisible;

            p_Preview.Visible = _btnPrintVisible;
            p_Print.Visible = _btnPrintVisible;
            p_Design.Visible = _btnPrintVisible;
            p_PrintFile.Visible = _btnPrintVisible;



            BaseToolBar.Refresh();
        }

        /// <summary>
        /// 设置操作按钮状态
        /// </summary>
        public void SetToolButtonStatus(int p_FormSubmitFlag, int p_DelFlag)
        {
            bool p_SubmitFlag = this.SubmitFlag;
            bool p_AuditFlag = this.AuditFlag;
            ButtonItem p_Insert = ToolBarItemGet(-1, ToolButtonName.btnInsert.ToString());
            ButtonItem p_Update = ToolBarItemGet(-1, ToolButtonName.btnUpdate.ToString());
            ButtonItem p_Delete = ToolBarItemGet(-1, ToolButtonName.btnDelete.ToString());
            ButtonItem p_Save = ToolBarItemGet(-1, ToolButtonName.btnSave.ToString());
            ButtonItem p_Drop = ToolBarItemGet(-1, ToolButtonName.btnCancel.ToString());
            ButtonItem p_Submit = ToolBarItemGet(-1, ToolButtonName.btnSubmit.ToString());
            ButtonItem p_CancelSubmit = ToolBarItemGet(-1, ToolButtonName.btnSubmitCancel.ToString());
            ButtonItem p_AuditPass = ToolBarItemGet(-1, ToolButtonName.btnAudit.ToString());
            ButtonItem p_AuditRefuse = ToolBarItemGet(-1, ToolButtonName.btnAuditCancel.ToString());
            //ButtonItem p_FormCancel = ToolBarItemGet(-1, ToolButtonName.btnFormCancel.ToString());
            //ButtonItem p_FormRestore = ToolBarItemGet(-1, ToolButtonName.btnFormRestore.ToString());


            if (!p_AuditFlag)//不需要审核
            {
                p_AuditPass.Visible = false;
                p_AuditRefuse.Visible = false;
            }
            if (!p_SubmitFlag)//不需要提交
            {
                p_Submit.Visible = false;
                p_CancelSubmit.Visible = false;
            }

            p_Update.Enabled = false;
            p_Delete.Enabled = false;
            //p_FormCancel.Enabled = false;
            //p_FormRestore.Enabled = false;


            switch (p_FormSubmitFlag)//当前单据状态
            {
                case (int)ConfirmFlag.未提交:
                    if (p_SubmitFlag)//需要提交 如果不需要提交的话就不存在未提交状态的可能
                    {
                        p_Update.Enabled = true;
                        p_Delete.Enabled = true;

                        p_Submit.Enabled = true;
                        p_CancelSubmit.Enabled = false;
                        p_AuditPass.Enabled = false;
                        p_AuditRefuse.Enabled = false;
                    }
                    else
                    {
                        p_Update.Enabled = true;
                        p_Delete.Enabled = true;
                    }
                    break;
                case (int)ConfirmFlag.已提交://已提交，可以撤销提交,可以被审核

                    p_Submit.Enabled = false;
                    p_CancelSubmit.Enabled = true;
                    p_AuditPass.Enabled = true;
                    p_AuditRefuse.Enabled = true;
                    break;
                case (int)ConfirmFlag.审核通过://审核通过只能出现审核拒绝
                    if (p_AuditFlag)//需要审核
                    {
                        p_Submit.Enabled = false;
                        p_CancelSubmit.Enabled = false;
                        p_AuditPass.Enabled = false;
                        p_AuditRefuse.Enabled = true;
                    }
                    else//不需要审核
                    {
                        if (p_SubmitFlag)//需要提交
                        {
                            p_Submit.Enabled = false;
                            p_CancelSubmit.Enabled = true;
                        }
                        else//不需要提交
                        {
                            p_Update.Enabled = true;
                            p_Delete.Enabled = true;
                        }
                    }
                    break;
                case (int)ConfirmFlag.审核拒绝://审核拒绝出现审核通过或者可以更新

                    p_Submit.Enabled = false;
                    p_CancelSubmit.Enabled = false;
                    p_AuditPass.Enabled = true;
                    p_AuditRefuse.Enabled = false;

                    p_Update.Enabled = true;
                    p_Delete.Enabled = true;
                    break;
            }

            BaseToolBar.Refresh();
        }

        #endregion

        #region  创建Bar默认按钮
        /// <summary>
        /// 创建Bar默认按钮
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(22, ToolButtonName.btnQuery.ToString(), "查询", false, btnQuery_Click, eShortcut.F5);
            this.ToolBarItemAdd(13, ToolButtonName.btnBrowse.ToString(), "浏览", false, btnBrowse_Click, eShortcut.CtrlB);
            this.ToolBarItemAdd(1, ToolButtonName.btnInsert.ToString(), "新增", true, btnInsert_Click, eShortcut.F1);
            this.ToolBarItemAdd(2, ToolButtonName.btnUpdate.ToString(), "修改", false, btnUpdate_Click, eShortcut.F2);
            this.ToolBarItemAdd(3, ToolButtonName.btnDelete.ToString(), "删除", false, btnDelete_Click, eShortcut.F3);
            this.ToolBarItemAdd(29, ToolButtonName.btnSubmit.ToString(), "提交", true, btnSubmit_Click);
            this.ToolBarItemAdd(30, ToolButtonName.btnSubmitCancel.ToString(), "撤消提交", false, btnSubmitCancel_Click);
            //this.ToolBarItemAdd(26, ToolButtonName.btnAudit.ToString(), "审核通过", false, btnAudit_Click);
            //this.ToolBarItemAdd(27, ToolButtonName.btnAuditCancel.ToString(), "审核拒绝", false, btnAuditCancel_Click);
            this.ToolBarItemAdd(32, ToolButtonName.btnToExcel.ToString(), "导出列表", true, btnToExcel_Click, eShortcut.F9);
            //this.ToolBarItemAdd(13, ToolButtonName.btnPreview.ToString(), "预览", true, btnPreview_Click);
            //this.ToolBarItemAdd(12, ToolButtonName.btnPrint.ToString(), "打印", false, btnPrint_Click);
            //this.ToolBarItemAdd(28, ToolButtonName.btnDesign.ToString(), "设计", false, btnDesign_Click);
        }

        /// <summary>
        /// 创建Bar默认按钮(靠右按钮)
        /// </summary>
        public override void ToolIniCreateBar2()
        {
            this.ToolBarItemAdd2(35, ToolButtonName.btnHelp.ToString(), "帮助", false, btnHelp_Click, eShortcut.F11);

        }
        #endregion

        #region 窗体事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAPBaseUIForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (FormID != 0)
                {
                    IniData();
                    ToolIniCreateBar2();//加载靠右控件
                    IniFormLoadBefore();
                    IniFormLoadBehind();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
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
                    break;
                case (int)WHFormList.出库:
                    formClassName = "frmOutWHEdit";
                    break;
                //case (int)WHFormList.形态转换:
                //    formClassName = "frmTurnForm";
                //    break;
                case (int)WHFormList.期初入库:
                    formClassName = "frmDefaultInWHEdit";
                    headtype = this.FormListAID;
                    break;

                case (int)WHFormList.盘点:
                    formClassName = "frmCheckWHEdit";
                    headtype = this.FormListAID;
                    break;
                case (int)WHFormList.移库:
                    formClassName = "frmMoveWHEdit";
                    headtype = this.FormListAID;
                    break;
            }
            if (formClassName != string.Empty)
            {
                MDIForm.ContextMenuOpenForm(FUISourceObject.GetResultArrayList(FUISourceObject.SourceForm, this), formClassName, headtype, 0, p_IOFormID.ToString(), p_FormStatus);
            }
        }
        #endregion
    }
}