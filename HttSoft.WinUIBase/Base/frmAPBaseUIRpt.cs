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

namespace HttSoft.WinUIBase
{
    /// <summary>
    /// 基本页面：报表
    /// </summary>
    public partial class frmAPBaseUIRpt : frmAPBaseTool
    {
        /// <summary>
        /// 基本页面：报表
        /// </summary>
        public frmAPBaseUIRpt()
        {
            InitializeComponent();
        }

        #region 属性

        /// <summary>
        /// 初始化查询控制
        /// </summary>
        //private bool _IsPostBack = true;
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
        /// 明细数据校验数组
        /// </summary>
        private string[] _HTCheckDataField = new string[] { };
        /// <summary>
        /// 明细数据校验数组
        /// </summary>
        public string[] HTCheckDataField
        {
            get
            {
                return _HTCheckDataField;
            }
            set
            {
                _HTCheckDataField = value;
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
                _HTDataList.IndicatorWidth = 30;
                this._HTDataList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView_CustomDrawRowIndicator);         
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

        #region 控件显示
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

        #endregion

        #region  创建Bar默认按钮
        /// <summary>
        /// 创建Bar默认按钮
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(22, ToolButtonName.btnQuery.ToString(), "查询", false, btnQuery_Click, eShortcut.F5);
            this.ToolBarItemAdd(32, ToolButtonName.btnToExcel.ToString(), "导出列表", true, btnToExcel_Click, eShortcut.F9);
            this.ToolBarItemAdd(13, ToolButtonName.btnPreview.ToString(), "预览", true, btnPreview_Click, eShortcut.F7);
            this.ToolBarItemAdd(12, ToolButtonName.btnPrint.ToString(), "打印", false, btnPrint_Click, eShortcut.F8);
            this.ToolBarItemAdd(28, ToolButtonName.btnDesign.ToString(), "设计", false, btnDesign_Click);
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
        /// 数据校验
        /// </summary>
        public virtual bool CheckCorrect()
        {
            return true;
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

        #region 自定义方法

        /// <summary>
        /// 校验数据明细
        /// </summary>
        /// <param name="p_FieldStr"></param>
        /// <returns></returns>
        public bool CheckCorrectDts()
        {
            return CheckCorrectDts(_HTCheckDataField);
        }
        /// <summary>
        /// 校验数据明细
        /// </summary>
        /// <param name="p_FieldStr"></param>
        /// <param name="p_FieldCaption"></param>
        /// <returns></returns>
        public bool CheckCorrectDts(string[] p_FieldStr)
        {
            return CheckCorrectDts(_HTDataList, p_FieldStr);
        }



        /// <summary>
        /// 获得数据明细完整记录数
        /// </summary>
        /// <param name="p_FieldStr"></param>
        /// <returns></returns>
        public int GetDataCompleteNum()
        {
            return GetDataCompleteNum(_HTCheckDataField);
        }

        /// <summary>
        /// 获得数据明细完整记录数
        /// </summary>
        /// <param name="p_FieldStr"></param>
        /// <returns></returns>
        public int GetDataCompleteNum(string[] p_FieldStr)
        {
            return GetDataCompleteNum(_HTDataList, p_FieldStr);
        }



        /// <summary>
        /// 校验数据明细是否完整
        /// </summary>
        /// <param name="p_RowI"></param>
        /// <returns></returns>
        public bool CheckDataCompleteDts(int p_RowI)
        {
            return CheckDataCompleteDts(_HTCheckDataField, p_RowI);
        }

        /// <summary>
        /// 校验数据明细是否完整
        /// </summary>
        /// <param name="p_FieldStr"></param>
        /// <param name="p_RowI"></param>
        /// <returns></returns>
        public bool CheckDataCompleteDts(string[] p_FieldStr, int p_RowI)
        {
            return CheckDataCompleteDts(_HTDataList, _HTCheckDataField, p_RowI); ;
        }
        #endregion
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
            }
            for (int i = 0; i < _HTDataDtsAttach.Length; i++)
            {
                ProcessGrid.BindGridColumn(_HTDataDtsAttach[i], this.FormID);//绑定列
                ProcessGrid.SetGridColumnUI(_HTDataDtsAttach[i], this.FormListAID, this.FormListBID);//设置列UI
                //ProcessGrid.SetGridManDefault(_HTDataDtsAttach[i]);---2010.8.5调整
                ProcessGrid.SetGridUIListDefault(_HTDataDtsAttach[i]);
            }

            ProcessGrid.SetGridReadOnly(_HTDataList, false);
            ProcessGrid.SetGridUIListDefault(_HTDataList);
            FCommon.AddDBLog(this.Text, "查询", " ", "");
            if (IsPostBack)
            {
                btnQuery_Click(null, null);
            }
        }
        /// <summary>
        /// 设置GridView不同行的颜色不同
        /// 虚方法的目的是便于界面重写单独的颜色变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void _HTDataDts_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
            //HTDataSubmitFlag = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SubmitFlag"]));
            //HTDataDelFlag = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DelFlag"]));
        }
        #endregion

        #region 按钮状态设置方法

        /// <summary>
        /// 设置操作按钮可显示
        /// </summary>
        //public void SetToolButtonVisible()
        //{
        //    ButtonItem p_Query = ToolBarItemGet(-1, ToolButtonName.btnQuery.ToString());

        //    ButtonItem p_ToExcel = ToolBarItemGet(-1, ToolButtonName.btnToExcel.ToString());

        //    ButtonItem p_Preview = ToolBarItemGet(-1, ToolButtonName.btnPreview.ToString());
        //    ButtonItem p_Print = ToolBarItemGet(-1, ToolButtonName.btnPrint.ToString());
        //    ButtonItem p_Design = ToolBarItemGet(-1, ToolButtonName.btnDesign.ToString());
        //    ComboBoxItem p_PrintFile = ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());

        //    p_Query.Visible = _btnQueryVisible;


        //    p_ToExcel.Visible = _btnToExcelVisible;

        //    p_Preview.Visible = _btnPrintVisible;
        //    p_Print.Visible = _btnPrintVisible;
        //    p_Design.Visible = _btnPrintVisible;
        //    p_PrintFile.Visible = _btnPrintVisible;

        //    BaseToolBar.Refresh();
        //}
        #endregion

        #region 窗体事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAPBaseUIRpt_Load(object sender, EventArgs e)
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
                    //SetToolButtonVisible();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 按钮事件
        public override void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCorrect())
                {
                    return;
                }
                this.GetCondtion();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.ToExcel(HTDataList);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 右键处理相关
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


        /// <summary>
        /// 增加右键
        /// </summary>
        /// <param name="p_Caption">标题</param>
        /// <param name="p_Eve">事件</param>
        public void HTAPAddContextMenuSecond(string p_Caption, System.EventHandler p_Eve)
        {
            HTAPAddContextMenu(this.cMenuSecond, p_Caption, p_Eve);
        }

        /// <summary>
        /// 设置右键
        /// </summary>
        /// <param name="p_Ctl">控件</param>
        public void HTAPSetContextMenuSecond(Control p_Ctl)
        {
            p_Ctl.ContextMenuStrip = this.cMenuSecond;
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