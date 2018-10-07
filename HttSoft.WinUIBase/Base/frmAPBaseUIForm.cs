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

using System.Collections;

namespace HttSoft.WinUIBase
{
    /// <summary>
    /// 主从表列表页面
    /// </summary>
    public partial class frmAPBaseUIForm : frmAPBaseTool
    {
        public frmAPBaseUIForm()
        {
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// 初始化查询控制
        /// </summary>
        private bool _IsPostBack = true;
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

        /// <summary>
        /// 进阶查询条件
        /// </summary>
        private string _HTDataConditionAdvanceStr = string.Empty;
        /// <summary>
        /// 进阶查询条件
        /// </summary>
        public string HTDataConditionAdvanceStr
        {
            get
            {
                return _HTDataConditionAdvanceStr;
            }
            set
            {
                _HTDataConditionAdvanceStr = value;
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

        /// <summary>
        /// 查询条件容器
        /// </summary>
        private Control _HTQryContainer;
        /// <summary>
        /// 查询条件容器
        /// </summary>
        public Control HTQryContainer
        {
            get
            {
                return _HTQryContainer;
            }
            set
            {
                _HTQryContainer = value;
            }
        }

        /// <summary>
        /// 强制查询方法1/2/3 如果非0则具有优先级
        /// 统业务数据默认检索方式0/1/2/3:未设置/回车检索/值改变检索/不检索
        /// </summary>
        private int _HTQryStrongType = 0;

        /// <summary>
        /// 强制查询方法1/2/3 如果非0则具有优先级
        /// 统业务数据默认检索方式0/1/2/3:未设置/回车检索/值改变检索/不检索
        /// </summary>
        public int HTQryStrongType
        {
            get
            {
                return _HTQryStrongType;
            }
            set
            {
                _HTQryStrongType = value;
            }
        }
        /// <summary>
        /// 单据明细附表
        /// </summary>
        private GridView[] _HTDataDtsAttach = new GridView[0] { };
        /// <summary>
        /// 单据明细附表
        /// </summary>
        public GridView[] HTDataDtsAttach
        {
            get
            {
                return _HTDataDtsAttach;
            }
            set
            {
                _HTDataDtsAttach = value;
                for (int i = 0; i < _HTDataDtsAttach.Length; i++)
                {
                    _HTDataDtsAttach[i].IndicatorWidth = 30;
                    this._HTDataDtsAttach[i].CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView_CustomDrawRowIndicator);
                }
            }
        }
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
        /// 查询按钮
        /// </summary>
        private bool _btnQueryVisible = true;
        /// <summary>
        ///  查询按钮
        /// </summary>
        public bool btnQueryVisible
        {
            get
            {
                return _btnQueryVisible;
            }
            set
            {
                _btnQueryVisible = value;
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
        ///更多查询
        /// </summary>
        private bool _btnQueryAdvanceVisible = true;
        /// <summary>
        ///  更多查询
        /// </summary>
        public bool btnQueryAdvanceVisible
        {
            get
            {
                return _btnQueryAdvanceVisible;
            }
            set
            {
                _btnQueryAdvanceVisible = value;
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
        ///浏览
        /// </summary>
        private bool _btnBrowseVisible = true;
        /// <summary>
        ///  浏览
        /// </summary>
        public bool btnBrowseVisible
        {
            get
            {
                return _btnBrowseVisible;
            }
            set
            {
                _btnBrowseVisible = value;
            }
        }

        /// <summary>
        ///提交按钮
        /// </summary>
        private bool _btnSubmitVisible = true;
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
        private bool _btnSubmitCancelVisible = true;
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
        ///审核按钮
        /// </summary>
        private bool _btnAuditVisible = false;
        /// <summary>
        ///  审核按钮
        /// </summary>
        public bool btnAuditVisible
        {
            get
            {
                return _btnAuditVisible;
            }
            set
            {
                _btnAuditVisible = value;
            }
        }
        /// <summary>
        ///撤销审核按钮
        /// </summary>
        private bool _btnAuditCancelVisible = false;
        /// <summary>
        ///  撤销审核按钮
        /// </summary>
        public bool btnAuditCancelVisible
        {
            get
            {
                return _btnAuditCancelVisible;
            }
            set
            {
                _btnAuditCancelVisible = value;
            }
        }

        /// <summary>
        ///打印组件
        /// </summary>
        private bool _btnPrintVisible = false;
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
        ///导出
        /// </summary>
        private bool _btnToExcelVisible = true;
        /// <summary>
        ///  导出
        /// </summary>
        public bool btnToExcelVisible
        {
            get
            {
                return _btnToExcelVisible;
            }
            set
            {
                _btnToExcelVisible = value;
            }
        }

        #endregion

        #region 是否是制单人
        /// <summary>
        /// 是否是制单人
        /// </summary>
        private bool _IsMakeOPID = false;
        /// <summary>
        ///  是否是制单人
        /// </summary>
        public bool IsMakeOPID
        {
            get
            {
                return _IsMakeOPID;
            }
            set
            {
                _IsMakeOPID = value;
            }
        }

        private bool IsMake()
        {

            if (_IsMakeOPID == true)
            {
                string sql = "";
                sql = " SELECT MakeOPID FROM " + HTDataTableName + " WHERE ID=" + HTDataID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    sql = " SELECT DefaultFlag FROM Data_OP WHERE OPID = " + SysString.ToDBString(FParamConfig.LoginID);
                    DataTable dt2 = SysUtils.Fill(sql);
                    if (dt2.Rows.Count != 0)
                    {
                        if (SysConvert.ToInt32(dt2.Rows[0]["DefaultFlag"].ToString()) == 1)
                        {
                            return true;
                        }
                    }
                    if (dt.Rows[0]["MakeOPID"].ToString() == FParamConfig.LoginID)
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }
        #endregion

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
        /// 绑定检索条件方法
        /// </summary>
        public virtual void IniQryMethod()
        {
            BindQryMethod(_HTQryContainer, GetCondtion, BindGrid, this, _HTQryStrongType);
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

                _HTDataList.RowCellStyle += new RowCellStyleEventHandler(_HTDataDts_RowCellStyle);

                //_HTDataList.DoubleClick += new EventHandler(btnBrowse_Click);
                _HTDataList.GridControl.DoubleClick += new EventHandler(btnBrowse_Click);
            }

            for (int i = 0; i < _HTDataDtsAttach.Length; i++)
            {
                ProcessGrid.BindGridColumn(_HTDataDtsAttach[i], this.FormID);//绑定列
                ProcessGrid.SetGridColumnUI(_HTDataDtsAttach[i], this.FormListAID, this.FormListBID);//设置列UI
                ProcessGrid.SetGridManDefault(_HTDataDtsAttach[i]);
            }
            ProcessGrid.SetGridUIListDefault(_HTDataList);
            if (SysConvert.ToBoolean(WinUIParamSet.GetIntValueByID(8011)))//系统编辑单据列表数据允许复制
            {

                ProcessGrid.SetGridReadOnly(_HTDataList, false);
            }
            else
            {
                ProcessGrid.SetGridReadOnly(_HTDataList, true);
            }

            SetToolButtonVisible();
            if (IsPostBack)
            {
                btnQuery_Click(null, null);
            }
            _HTDataList.GridControl.ContextMenuStrip = cMenuFirst;
            this.ContextMenuStrip = cMenuFirst;
            FCommon.AddDBLog(this.Text, "查询", " ", "");
        }

        /// <summary>
        /// 设置GridView不同行的颜色不同
        /// 虚方法的目的是便于界面重写单独的颜色变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void _HTDataDts_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    if (e.RowHandle % 2 == 0)
                    {
                        e.Appearance.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.White;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
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

        /// <summary>
        /// 外部窗体初始化数据
        /// </summary>
        /// <param name="p_OpenSourceID">打开窗体源实体ID</param>
        /// <param name="p_TargetID">打开窗体目标实体ID</param>
        public override void OutIniDataStrong(ArrayList p_SourceObject, string p_OpenSourceID, string p_TargetID, FormStatus p_MFormStatus)//右键菜单打开代码
        {
            try//赋值，父窗体，防止非查询结果集窗体
            {
                if (p_SourceObject != null)
                {
                    for (int i = 0; i < p_SourceObject.Count; i++)
                    {
                        switch (SysConvert.ToString(((ArrayList)p_SourceObject[i])[0]))
                        {
                            case FUISourceObject.SourceQueryCondition://查询条件刷新
                                _HTDataConditionStr = SysConvert.ToString(((ArrayList)p_SourceObject[i])[1]);
                                this.BindGrid();
                                break;


                        }
                    }
                }
            }
            catch
            {
            }
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


        /// <summary>
        /// 刷新数据(刷新数据方式，可重写)
        /// </summary>
        /// <param name="p_DataID">数据ID</param>
        public virtual void RefreshData(int p_DataID)//,FormStatus p_Status/// <param name="p_Status">状态</param>
        {
            if (_HTDataList.Columns.Count != 0)
            {
                this.BindGrid();
                ProcessGrid.GridViewFocus(HTDataList, new string[] { "ID" }, new string[] { p_DataID.ToString() });
            }
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
        /// 更多查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnQueryAdvance_Click(object sender, EventArgs e)
        {
            try
            {
                frmAPBaseCondition frm = new frmAPBaseCondition();
                frm.HTParentDataList = _HTDataList;
                frm.ShowDialog();
                if (frm.HTExcuteQueryEventFlag)//查询标志
                {
                    _HTDataConditionAdvanceStr = frm.HTDataConditionStr;//进阶查询条件
                    this.GetCondtion();//获得界面查询条件
                    _HTDataConditionStr = _HTDataConditionAdvanceStr + _HTDataConditionStr;//进阶查询条件
                    this.BindGrid();//绑定数据
                }
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
                this.NavigateWin(this.Name + "Edit", HTDataID.ToString(), FormStatus.查询);
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

                this.NavigateWin(this.Name + "Edit", HTDataID.ToString(), FormStatus.新增);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 新增已存在事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnInsertExist_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                this.NavigateWin(this.Name + "Edit", HTDataID.ToString(), FormStatus.新增已存在);


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
                if (IsMake() != true)
                {
                    this.ShowMessage("你没有此操作该单据权限");
                    return;
                }
                if (!HTSubmitCheck(FormStatus.修改))
                {
                    return;
                }
                this.NavigateWin(this.Name + "Edit", HTDataID.ToString(), FormStatus.修改);
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
                if (IsMake() != true)
                {
                    this.ShowMessage("你没有此操作该单据权限");
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

        /// <summary>
        /// FastReport预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                DataTable dt = null;
                dt = WCommon.PrintDataTable(_HTDataList);
                if (dt.Rows.Count != 0)
                {
                    FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.预览, dt);
                }
                else
                {
                    this.ShowMessage("请选择要导出的数据");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// FastReport打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                DataTable dt = null;
                dt = WCommon.PrintDataTable(_HTDataList);
             
                if (dt.Rows.Count != 0)
                {
                    FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.打印, dt);
                }
                else
                {
                    this.ShowMessage("请选择要导出的数据");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// FastReports设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交3))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                DataTable dt = null;
                dt = WCommon.PrintDataTable(_HTDataList);
              
                if (dt.Rows.Count != 0)
                {
                    FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.设计, dt);
                }
                else
                {
                    this.ShowMessage("请选择要导出的数据");
                }
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
            ButtonItem p_Query = ToolBarItemGet(-1, ToolButtonName.btnQuery.ToString());
            ButtonItem p_Insert = ToolBarItemGet(-1, ToolButtonName.btnInsert.ToString());
            ButtonItem p_Update = ToolBarItemGet(-1, ToolButtonName.btnUpdate.ToString());
            ButtonItem p_Delete = ToolBarItemGet(-1, ToolButtonName.btnDelete.ToString());
            ButtonItem p_InsertExis = ToolBarItemGet(-1, ToolButtonName.btnInsertExist.ToString());
            ButtonItem p_Browse = ToolBarItemGet(-1, ToolButtonName.btnBrowse.ToString());
            ButtonItem p_QueryAdvance = ToolBarItemGet(-1, ToolButtonName.btnQueryAdvance.ToString());

            ButtonItem p_Submit = ToolBarItemGet(-1, ToolButtonName.btnSubmit.ToString());
            ButtonItem p_SubmitCancel = ToolBarItemGet(-1, ToolButtonName.btnSubmitCancel.ToString());

            ButtonItem p_Audit = ToolBarItemGet(-1, ToolButtonName.btnAudit.ToString());
            ButtonItem p_AuditCancel = ToolBarItemGet(-1, ToolButtonName.btnAuditCancel.ToString());

            ButtonItem p_ToExcel = ToolBarItemGet(-1, ToolButtonName.btnToExcel.ToString());

            ButtonItem p_Preview = ToolBarItemGet(-1, ToolButtonName.btnPreview.ToString());
            ButtonItem p_Print = ToolBarItemGet(-1, ToolButtonName.btnPrint.ToString());
            ButtonItem p_Design = ToolBarItemGet(-1, ToolButtonName.btnDesign.ToString());
            ComboBoxItem p_PrintFile = ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());


            p_ToExcel.Visible = _btnToExcelVisible;

            p_Preview.Visible = _btnPrintVisible;
            p_Print.Visible = _btnPrintVisible;
            p_Design.Visible = _btnPrintVisible;
            p_PrintFile.Visible = _btnPrintVisible;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            p_Query.Visible = _btnQueryVisible;
            p_QueryAdvance.Visible = _btnQueryAdvanceVisible;

            p_Insert.Visible = _btnInsertVisible;
            p_Delete.Visible = _btnDeleteVisible;
            p_Update.Visible = _btnUpdateVisible;
            p_InsertExis.Visible = _btnInsertExistVisible;

            p_Browse.Visible = _btnBrowseVisible;

            p_Submit.Visible = _btnSubmitVisible;
            p_SubmitCancel.Visible = _btnSubmitCancelVisible;

            p_Audit.Visible = _btnAuditVisible;
            p_AuditCancel.Visible = _btnAuditCancelVisible;

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

        /// <summary>
        /// 增加一列行序号
        /// </summary>
        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                if (e.Info.IsRowIndicator)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region  创建Bar默认按钮
        /// <summary>
        /// 创建Bar默认按钮
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(57, ToolButtonName.btnQuery.ToString(), "查询", false, btnQuery_Click, eShortcut.F5);
            //this.ToolBarItemAdd(59, ToolButtonName.btnQueryAdvance.ToString(), "更多查询", false, btnQueryAdvance_Click);
            this.ToolBarItemAdd(60, ToolButtonName.btnBrowse.ToString(), "浏览", false, btnBrowse_Click, eShortcut.CtrlB);
            this.ToolBarItemAdd(54, ToolButtonName.btnInsert.ToString(), "新增", true, btnInsert_Click, eShortcut.F1);
            this.ToolBarItemAdd(55, ToolButtonName.btnUpdate.ToString(), "修改", false, btnUpdate_Click, eShortcut.F2);
            //this.ToolBarItemAdd(3, ToolButtonName.btnDelete.ToString(), "删除", false, btnDelete_Click, eShortcut.F3);
            //this.ToolBarItemAdd(29, ToolButtonName.btnSubmit.ToString(), "提交", true, btnSubmit_Click);
            // this.ToolBarItemAdd(30, ToolButtonName.btnSubmitCancel.ToString(), "撤消提交", false, btnSubmitCancel_Click);
            // this.ToolBarItemAdd(26, ToolButtonName.btnAudit.ToString(), "审核通过", false, btnAudit_Click);
            //this.ToolBarItemAdd(27, ToolButtonName.btnAuditCancel.ToString(), "审核拒绝", false, btnAuditCancel_Click);
            this.ToolBarItemAdd(41, ToolButtonName.btnInsertExist.ToString(), "复制", true, btnInsertExist_Click, eShortcut.CtrlIns);
            this.ToolBarItemAdd(58, ToolButtonName.btnToExcel.ToString(), "导出列表", true, btnToExcel_Click, eShortcut.F9);
            this.ToolBarItemAdd(56, ToolButtonName.btnPreview.ToString(), "预览", true, btnPreview_Click, eShortcut.F7);
            this.ToolBarItemAdd(46, ToolButtonName.btnPrint.ToString(), "打印", false, btnPrint_Click, eShortcut.F8);
            this.ToolBarItemAdd(39, ToolButtonName.btnDesign.ToString(), "设计", false, btnDesign_Click);
            this.ToolBarCItemAdd(ToolButtonName.drpPrintFile.ToString(), 120);
            BindReport(ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString()));
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
                    IniQryMethod();//绑定检索方法
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

        #region 右键菜单
        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemView_Click(object sender, EventArgs e)
        {
            try
            {
                btnBrowse_Click(sender, e);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 增加右键
        /// </summary>
        /// <param name="p_Caption">标题</param>
        /// <param name="p_Eve">事件</param>
        public void HTAPAddContextMenuFirst(string p_Caption, System.EventHandler p_Eve)
        {
            HTAPAddContextMenu(this.cMenuFirst, p_Caption, p_Eve);
        }

        /// <summary>
        /// 设置右键
        /// </summary>
        /// <param name="p_Ctl">控件</param>
        public void HTAPSetContextMenuFirst(Control p_Ctl)
        {
            p_Ctl.ContextMenuStrip = this.cMenuFirst;
        }
        #endregion

        #region 打印组件事件

        /// <summary>
        /// 绑定报表名称
        /// </summary>
        public virtual void BindReport(DevComponents.DotNetBar.ComboBoxItem p_DrpID)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             {
            if (FormID != 0)
            {
                string sql = "SELECT ReportName,ID FROM dbo.Data_ReportManage where ";//WinListID = " +  FormID.ToString() + "

                sql += " WinID=" + this.FormID;
                sql += " AND HeadTypeID=" + this.FormListAID;
                sql += " AND SubTypeID=" + this.FormListBID;
                sql += " ORDER BY Seq";
                DataTable dt = SysUtils.Fill(sql);
                FCommon.LoadDropDNBarComb(p_DrpID, dt, "ID", "ReportName", true);
                if (dt.Rows.Count > 0)
                {
                    p_DrpID.SelectedIndex = 1;
                }
            }
        }
        #endregion  

    }
}