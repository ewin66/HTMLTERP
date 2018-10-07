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
    /// 基本页面：保存明细i----只有保存
    /// </summary>
    public partial class frmAPBaseUISaveEdit : frmAPBaseTool
    {
        /// <summary>
        /// 基本页面：报表
        /// </summary>
        public frmAPBaseUISaveEdit()
        {
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// 父窗体单据ID
        /// </summary>
        private int _DataID = 0;
        /// <summary>
        /// 父窗体单据ID
        /// </summary>
        public int DataID
        {
            get
            {
                return _DataID;
            }
            set
            {
                _DataID = value;
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
        /// 新增、修改列表
        /// </summary>
        private int _doStatus = 0;
        /// <summary>
        /// 新增、修改列表
        /// </summary>
        public int doStatus
        {
            get
            {
                return _doStatus;
            }
            set
            {
                _doStatus = value;
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
        /// 新增
        /// </summary>
        public virtual int EntityAdd()
        {
            return 0;
        }
        /// <summary>
        /// 修改
        /// </summary>
        public virtual void EntityUpdate()
        {
        }


        /// <summary>
        /// 父窗体
        /// </summary>
        private frmAPBaseUIForm _HTParentForm;
        /// <summary>
        /// 父窗体
        /// </summary>
        public frmAPBaseUIForm HTParentForm
        {
            get
            {
                return _HTParentForm;
            }
            set
            {
                _HTParentForm = value;
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

        #endregion

        #region  创建Bar默认按钮
        /// <summary>
        /// 创建Bar默认按钮
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(4, ToolButtonName.btnSave.ToString(), "保存", false, btnSave_Click, eShortcut.F4);
            this.ToolBarItemAdd(3, ToolButtonName.btnDelete.ToString(), "删除", false, btnDelete_Click, eShortcut.F3);
            this.ToolBarItemAdd(7, ToolButtonName.btnClose.ToString(), "退出", true, btnClose_Click);
        }

        /// <summary>
        /// 创建Bar默认按钮(靠右按钮)
        /// </summary>
        public override void ToolIniCreateBar2()
        {
            this.ToolBarItemAdd2(6, ToolButtonName.btnRefresh.ToString(), "刷新", false, btnRefresh_Click, eShortcut.F6);
            this.ToolBarItemAdd2(35, ToolButtonName.btnHelp.ToString(), "帮助", false, btnHelp_Click, eShortcut.F11);

        }

        /// <summary>
        /// 设置操作按钮可显示
        /// </summary>
        public void SetToolButtonVisible()
        {
            ButtonItem p_Delete = ToolBarItemGet(-1, ToolButtonName.btnDelete.ToString());
            p_Delete.Visible = _btnDeleteVisible;
            BaseToolBar.Refresh();
        }

        #endregion

        #region 自定义虚方法定义[需要修改]

        /// <summary>
        /// 数据校验
        /// </summary>
        public virtual bool CheckCorrect()
        {
            return true;
        }

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
        /// 设置
        /// </summary>
        public virtual void EntitySet()
        {
        }

        /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            this.HTDataID = p_ID;
            //this.HTDataID = SysConvert.ToInt32(this.SetToolButtonPosStatus(this.HTDataID.ToString(), HTDataTableName));//设置单据张数导航定位状态

            EntitySet();
            //this.HTSubmitFlagTextGetSet();

            //this.SetFormStatus(FormStatus.查询);
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
            }
            for (int i = 0; i < _HTDataDtsAttach.Length; i++)
            {
                ProcessGrid.BindGridColumn(_HTDataDtsAttach[i], this.FormID);//绑定列
                ProcessGrid.SetGridColumnUI(_HTDataDtsAttach[i], this.FormListAID, this.FormListBID);//设置列UI
               // ProcessGrid.SetGridManDefault(_HTDataDtsAttach[i]);
            }

           // ProcessGrid.SetGridReadOnly(_HTDataList, false);
            //ProcessGrid.SetGridUIListDefault(_HTDataList);
            SetToolButtonVisible();
            btnQuery_Click(null, null);
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
                    this.IniRefreshData();
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

        #region 按钮事件
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
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BaseFocusLabel.Focus();

                if (_doStatus == 1)
                {
                    if (!CheckCorrect())
                    {
                        return;
                    }
                    int tempID = EntityAdd();
                    FCommon.AddDBLog(this.Text, "新增", "ID:" + tempID.ToString(), "");
                    this.HTDataID = tempID;
                }
                else if (_doStatus == 2)
                {
                    if (!CheckCorrect())
                    {
                        return;
                    }
                    EntityUpdate();
                    FCommon.AddDBLog(this.Text, "修改", "ID:" + HTDataID.ToString(), "");
                }

                SetPosStatus(HTDataID);
                RefreshParentData();//刷新父窗体数据

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

                if (DialogResult.Yes != ShowConfirmMessage("删除为不可恢复操作，确认删除本条记录？"))
                {
                    return;
                }

                EntityDelete();//调用虚方法

                FCommon.AddDBLog(this.Text, "删除", "ID:" + HTDataID, "");

                IniData();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region 自定义事件
        /// <summary>
        /// 刷新父窗体数据
        /// </summary>
        public virtual void RefreshParentData()
        {
            if (_HTParentForm != null)
            {
                _HTParentForm.RefreshData(_DataID);
            }
        }

       
        #endregion
    }
}