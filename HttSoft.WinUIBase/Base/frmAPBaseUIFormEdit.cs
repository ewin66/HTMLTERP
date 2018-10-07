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
    /// 主从表编辑页面
    /// </summary>
    public partial class frmAPBaseUIFormEdit : frmAPBaseToolEdit
    {
        public frmAPBaseUIFormEdit()
        {
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// 旧数据ID
        /// </summary>
        private int _HTDataOldID = 0;
        /// <summary>
        /// 旧数据ID
        /// </summary>
        public int HTDataOldID
        {
            get
            {
                return _HTDataOldID;
            }
            set
            {
                _HTDataOldID = value;
            }
        }

        /// <summary>
        /// 打开源窗体查询结果集
        /// </summary>
        private GridView _HTDataQueryResult;
        /// <summary>
        /// 打开源窗体查询结果集
        /// </summary>
        public GridView HTDataQueryResult
        {
            get
            {
                return _HTDataQueryResult;
            }
            set
            {
                _HTDataQueryResult = value;
            }
        }


        /// <summary>
        /// 单据明细
        /// </summary>
        private GridView _HTDataDts = new GridView();
        /// <summary>
        /// 单据明细
        /// </summary>
        public GridView HTDataDts
        {
            get
            {
                return _HTDataDts;
            }
            set
            {
                _HTDataDts = value;
                _HTDataDts.IndicatorWidth = 30;
                this._HTDataDts.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView_CustomDrawRowIndicator);
            }
        }


        /// <summary>
        /// 单据明细是否追加到默认行
        /// </summary>
        private bool _HTDataAddFlag = true;
        /// <summary>
        /// 单据明细是否追加到默认行
        /// </summary>
        public bool HTDataAddFlag
        {
            get
            {
                return _HTDataAddFlag;
            }
            set
            {
                _HTDataAddFlag = value;
            }
        }

        /// <summary>
        /// 单据打印数据源启用标志
        /// </summary>
        private bool _HTPrintDataSourceFlag = false;
        /// <summary>
        /// 单据打印数据源启用标志
        /// </summary>
        public bool HTPrintDataSourceFlag
        {
            get
            {
                return _HTPrintDataSourceFlag;
            }
            set
            {
                _HTPrintDataSourceFlag = value;
            }
        }

        /// <summary>
        /// 单据打印数据源
        /// </summary>
        private DataTable[] _HTPrintDataSource = new DataTable[0];
        /// <summary>
        /// 单据打印数据源
        /// </summary>
        public DataTable[] HTPrintDataSource
        {
            get
            {
                return _HTPrintDataSource;
            }
            set
            {
                _HTPrintDataSource = value;
            }
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
        /// 定位条件
        /// </summary>
        private string _SetPosCondition = string.Empty;
        /// <summary>
        /// 定位条件
        /// </summary>
        public string SetPosCondition
        {
            get
            {
                return _SetPosCondition;
            }
            set
            {
                _SetPosCondition = value;
            }
        }


        /// <summary>
        /// Grid删除行是否显示提示确认框，默认弹出
        /// </summary>
        private bool _HTGridDelShowConfirmFlag = true;
        /// <summary>
        /// Grid删除行是否显示提示确认框，默认弹出
        /// </summary>
        public bool HTGridDelShowConfirmFlag
        {
            get
            {
                return _HTGridDelShowConfirmFlag;
            }
            set
            {
                _HTGridDelShowConfirmFlag = value;
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

        ///// <summary>
        /////打印组件
        ///// </summary>
        //private bool _btnPrintVisible = true;
        ///// <summary>
        /////  打印组件
        ///// </summary>
        //public bool btnPrintVisible
        //{
        //    get
        //    {
        //        return _btnPrintVisible;
        //    }
        //    set
        //    {
        //        _btnPrintVisible = value;
        //    }
        //}

        /// <summary>
        ///预览
        /// </summary>
        private bool _btnPreviewVisible = true;
        /// <summary>
        ///  预览
        /// </summary>
        public bool btnPreviewVisible
        {
            get
            {
                return _btnPreviewVisible;
            }
            set
            {
                _btnPreviewVisible = value;
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
        ///设计
        /// </summary>
        private bool _btnDesignVisible = true;
        /// <summary>
        ///  设计
        /// </summary>
        public bool btnDesignVisible
        {
            get
            {
                return _btnDesignVisible;
            }
            set
            {
                _btnDesignVisible = value;
            }
        }
        /// <summary>
        ///打印组件
        /// </summary>
        private bool _btnPrintFileVisible = true;
        /// <summary>
        ///  打印组件
        /// </summary>
        public bool btnPrintFileVisible
        {
            get
            {
                return _btnPrintFileVisible;
            }
            set
            {
                _btnPrintFileVisible = value;
            }
        }




        /// <summary>
        ///Grid右键进阶按钮显示标志
        /// </summary>
        private bool _HTGridCmenuAdvanceFlag = true;
        /// <summary>
        ///Grid右键进阶按钮显示标志
        /// </summary>
        public bool HTGridCmenuAdvanceFlag
        {
            get
            {
                return _HTGridCmenuAdvanceFlag;
            }
            set
            {
                _HTGridCmenuAdvanceFlag = value;
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
        /// 第一个Grid增行
        /// </summary>
        public virtual void GridFirstCtlAddRow()
        {
        }

        /// <summary>
        /// 第一个Grid删行
        /// </summary>
        public virtual void GridFirstCtlDelRow()
        {
        }

        /// <summary>
        /// 第一个Grid上移
        /// </summary>
        public virtual void GridFirstCtlMoveUp()
        {
        }

        /// <summary>
        /// 第一个Grid下移
        /// </summary>
        public virtual void GridFirstCtlMoveDown()
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
        /// 绑定Grid
        /// </summary>
        public virtual void BindGridDts()
        {
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
        /// 删除
        /// </summary>
        public virtual void EntityDelete()
        {
        }

        /// <summary>
        /// 设置
        /// </summary>
        public virtual void EntitySet()
        {
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public virtual void SetInputStatus(bool p_Flag)
        {
        }

        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public virtual void IniInsertSet()
        {

        }

        /// <summary>
        /// 新增单据初始化控件数据   执行完IniInsertSet再执行
        /// </summary>
        public virtual void IniInsertSetLast()
        {
            ProcessFormUI.SetFormInsertCtl(this, HTBaseUIDBRead);
        }

        /// <summary>
        /// 新增已存在单据初始化控件数据(哪些值需要设置的设定一下) 默认调用新增单据初始化方法
        /// 如果某个页面不需要调用新增初始化可以重写此方法
        /// </summary>
        public virtual void IniInsertExistSet()
        {
            IniInsertSet();
        }



        /// <summary>
        /// 编辑单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public virtual void IniUpdateSet()
        {

        }

        /// <summary>
        /// 编辑单据初始化控件数据 执行完IniUpdateSet再执行
        /// </summary>
        public virtual void IniUpdateSetLast()
        {

            ProcessFormUI.SetFormEditCtl(this, HTBaseUIDBRead);
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

            if (HTDataDts.Columns.Count != 0)
            {
                ProcessGrid.BindGridColumn(_HTDataDts, this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(_HTDataDts, this.FormListAID, this.FormListBID);//设置列UI
                ProcessGrid.SetGridManDefault(_HTDataDts);

                _HTDataDts.RowCellStyle += new RowCellStyleEventHandler(_HTDataDts_RowCellStyle);
                new GridViewOPCMenuProc(this, _HTDataDts, HTGridCmenuAdvanceFlag);
                //_HTDataDts.GridControl.ContextMenuStrip = this.cMenuFirst;
            }

            for (int i = 0; i < _HTDataDtsAttach.Length; i++)
            {
                ProcessGrid.BindGridColumn(_HTDataDtsAttach[i], this.FormID);//绑定列
                ProcessGrid.SetGridColumnUI(_HTDataDtsAttach[i], this.FormListAID, this.FormListBID);//设置列UI
                ProcessGrid.SetGridManDefault(_HTDataDtsAttach[i]);

                _HTDataDtsAttach[i].RowCellStyle += new RowCellStyleEventHandler(frmAPBaseUIFormEdit_RowCellStyle);
                new GridViewOPCMenuProc(this, _HTDataDtsAttach[i], HTGridCmenuAdvanceFlag);
                switch (i + 1)
                {
                    case 1:
                        _HTDataDtsAttach[i].GridControl.ContextMenuStrip = this.cMenuSecond;
                        break;
                    case 2:
                        _HTDataDtsAttach[i].GridControl.ContextMenuStrip = this.cMenuThird;
                        break;
                    case 3:
                        _HTDataDtsAttach[i].GridControl.ContextMenuStrip = this.cMenuFourth;
                        break;
                    case 4:
                        _HTDataDtsAttach[i].GridControl.ContextMenuStrip = this.cMenuFifth;
                        break;
                    case 5:
                        _HTDataDtsAttach[i].GridControl.ContextMenuStrip = this.cMenuSixth;
                        break;
                }
            }
            SetToolButtonVisible();

        }

        /// <summary>
        /// 设置编辑页面的连续行的颜色不同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _HTDataDts_RowCellStyle(object sender, RowCellStyleEventArgs e)
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

        public void frmAPBaseUIFormEdit_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
                            case FUISourceObject.SourceForm://数据源Form
                                HTParentForm = (frmAPBaseUIForm)((ArrayList)p_SourceObject[i])[1];

                                if (HTParentForm != null)
                                {
                                    if (HTParentForm.HTDataList != null && HTParentForm.HTDataList.GridControl != null && HTParentForm.HTDataList.GridControl.DataSource != null)
                                    {
                                        _HTDataQueryResult = HTParentForm.HTDataList;
                                    }
                                    else
                                    {
                                        _HTDataQueryResult = null;
                                    }
                                }
                                else
                                {
                                    _HTDataQueryResult = null;
                                }

                                break;
                            case FUISourceObject.SourceGridView://数据源Grid
                                _HTDataQueryResult = (GridView)((ArrayList)p_SourceObject[i])[1];
                                break;


                        }
                    }
                }
            }
            catch
            {
            }


            if (p_OpenSourceID != string.Empty && p_OpenSourceID != HTDataID.ToString())
            {
                HTDataID = SysConvert.ToInt32(p_OpenSourceID);
                //EntitySet();

                SetPosStatus(HTDataID);
            }
            HTFormStatus = p_MFormStatus;
            switch (p_MFormStatus)
            {
                case FormStatus.新增:
                    btnInsert_Click(null, null);
                    break;
                case FormStatus.新增已存在:
                    btnInsertExist_Click(null, null);
                    break;
                case FormStatus.修改:
                    btnUpdate_Click(null, null);
                    break;
                default:
                    SetFormStatus(p_MFormStatus);
                    break;
            }
        }

        /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            this.HTDataID = p_ID;
            this.HTDataID = SysConvert.ToInt32(this.SetToolButtonPosStatus(this.HTDataID.ToString(), HTDataTableName));//设置单据张数导航定位状态

            EntitySet();
            FileSetButtonFileNumber();//设置文件数
            this.HTSubmitFlagTextGetSet();

            this.SetFormStatus(FormStatus.查询);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 设置Form操作状态下控件状态
        /// </summary>
        /// <param name="p_status">Form状态</param>
        public void SetFormStatus(FormStatus p_status)
        {
            HTFormStatus = p_status;
            //设置操作按钮状态
            this.SetToolButtonStatus(HTFormStatus, this.HTDataSubmitFlag, this.HTDataDelFlag);//, HTDataSubmitFlag, HTDataDelFlag

            SetInputStatus(false);

            switch (HTFormStatus)
            {

                case FormStatus.查询:
                    break;
                case FormStatus.新增:
                    SetInputStatus(true);


                    if (HTDataDts.Columns.Count != 0)
                    {
                        if (HTDataAddFlag)
                        {
                            WCommon.AddDtRow((DataTable)HTDataDts.GridControl.DataSource, FParamConfig.GridRowNum - ((DataTable)HTDataDts.GridControl.DataSource).Rows.Count);
                        }
                    }

                    for (int i = 0; i < _HTDataDtsAttach.Length; i++)
                    {
                        if (_HTDataDtsAttach[i].GridControl.DataSource != null)
                        {
                            if (HTDataAddFlag)
                            {
                                WCommon.AddDtRow((DataTable)_HTDataDtsAttach[i].GridControl.DataSource, FParamConfig.GridRowNum);
                            }

                        }
                    }

                    break;
                case FormStatus.修改:
                    SetInputStatus(true);

                    if (HTDataDts.Columns.Count != 0)
                    {
                        if (HTDataAddFlag)
                        {
                            WCommon.AddDtRow((DataTable)HTDataDts.GridControl.DataSource, FParamConfig.GridRowNum - ((DataTable)HTDataDts.GridControl.DataSource).Rows.Count);
                        }
                    }

                    for (int i = 0; i < _HTDataDtsAttach.Length; i++)
                    {
                        if (_HTDataDtsAttach[i].GridControl.DataSource != null)
                        {
                            if (HTDataAddFlag)
                            {
                                WCommon.AddDtRow((DataTable)_HTDataDtsAttach[i].GridControl.DataSource, FParamConfig.GridRowNum);
                            }

                        }
                    }
                    break;
                case FormStatus.放弃:
                    goto case FormStatus.查询;
            }
        }


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
            return CheckCorrectDts(_HTDataDts, p_FieldStr);
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
            return GetDataCompleteNum(_HTDataDts, p_FieldStr);
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
            return CheckDataCompleteDts(_HTDataDts, _HTCheckDataField, p_RowI); ;
        }


        #endregion

        #region 按钮虚方法定义

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

                _HTDataOldID = HTDataID;
                HTDataID = 0;
                this.EntitySet();
                FileSetButtonFileNumber();//设置文件数
                SetFormStatus(FormStatus.新增);
                this.HTSubmitFlagTextGetSet();
                IniInsertSet();
                IniInsertSetLast();
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

                this.EntitySet();
                _HTDataOldID = HTDataID;
                HTDataID = 0;
                SetFormStatus(FormStatus.新增);
                FileSetButtonFileNumber();//设置文件数
                this.HTSubmitFlagTextGetSet();

                IniInsertExistSet();//----2013-4-23 取消注释
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

                _HTDataOldID = HTDataID;
                this.EntitySet();
                SetFormStatus(FormStatus.修改);
                IniUpdateSet();
                IniUpdateSetLast();
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
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.删除))
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
                FileDeleteDataFile();//文件删除
                FCommon.AddDBLog(this.Text, "删除", "ID:" + HTDataID, "");
                //this.EntitySet();
                SetPosStatus(0);
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
                if (this.HTFormStatus == FormStatus.新增)
                {
                    if (!CheckCorrect())
                    {
                        return;
                    }
                    int tempID = EntityAdd();
                    FCommon.AddDBLog(this.Text, "新增", "ID:" + tempID.ToString(), "");
                    this.HTDataID = tempID;

                }
                else if (this.HTFormStatus == FormStatus.修改)
                {
                    if (!HTSubmitCheck(FormStatus.修改))
                    {
                        return;
                    }

                    if (!CheckCorrect())
                    {
                        return;
                    }
                    EntityUpdate();
                    FCommon.AddDBLog(this.Text, "修改", "ID:" + HTDataID.ToString(), "");
                }

                SetFormStatus(FormStatus.查询);
                //EntitySet();
                SetPosStatus(HTDataID);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 放弃事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes != this.ShowConfirmMessage("确定要放弃保存数据？"))
                {
                    return;
                }
                SetFormStatus(FormStatus.放弃);
                HTDataID = _HTDataOldID;
                //EntitySet();
                SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 增行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    bool findFlag = false;
                    if (_HTDataDts.GridControl.ContainsFocus || _HTDataDtsAttach.Length == 0)//主表获得焦点
                    {
                        if (_HTDataDts.GridControl.DataSource != null)
                        {
                            GridFirstCtlAddRow();

                            WCommon.DataTableAddRow((DataTable)_HTDataDts.GridControl.DataSource, _HTDataDts.FocusedRowHandle);
                        }
                        findFlag = true;
                    }
                    else//从表获得焦点
                    {
                        for (int i = 0; i < _HTDataDtsAttach.Length; i++)
                        {
                            if (_HTDataDtsAttach[i].GridControl.ContainsFocus)//获得焦点
                            {
                                if (_HTDataDtsAttach[i].GridControl.DataSource != null)
                                {
                                    WCommon.DataTableAddRow((DataTable)_HTDataDtsAttach[i].GridControl.DataSource, _HTDataDtsAttach[i].FocusedRowHandle);
                                }
                                findFlag = true;
                                break;
                            }
                        }
                    }
                    if (!findFlag)
                    {
                        this.ShowInfoMessage("请聚焦到数据列表再进行增行操作");
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 删行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (_HTGridDelShowConfirmFlag)
                    {
                        if (DialogResult.Yes != this.ShowConfirmMessage("确实要删除该行"))
                        {
                            return;
                        }
                    }
                    bool findFlag = false;
                    if (_HTDataDts.GridControl.ContainsFocus || _HTDataDtsAttach.Length == 0)//主表获得焦点
                    {
                        if (_HTDataDts.GridControl.DataSource != null)
                        {
                            GridFirstCtlDelRow();
                            WCommon.DelDtRow((DataTable)_HTDataDts.GridControl.DataSource, _HTDataDts.FocusedRowHandle);
                        }
                        findFlag = true;
                    }
                    else//从表获得焦点
                    {
                        for (int i = 0; i < _HTDataDtsAttach.Length; i++)
                        {
                            if (_HTDataDtsAttach[i].GridControl.ContainsFocus)//获得焦点
                            {
                                if (_HTDataDtsAttach[i].GridControl.DataSource != null)
                                {
                                    //this.BaseFocusLabel.Focus();
                                    WCommon.DelDtRow((DataTable)_HTDataDtsAttach[i].GridControl.DataSource, _HTDataDtsAttach[i].FocusedRowHandle);
                                }
                                findFlag = true;
                                break;
                            }
                        }
                    }
                    if (!findFlag)
                    {
                        this.ShowInfoMessage("请聚焦到数据列表再进行删行操作");
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 上移事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    bool findFlag = false;
                    if (_HTDataDts.GridControl.ContainsFocus || _HTDataDtsAttach.Length == 0)//主表获得焦点
                    {
                        if (_HTDataDts.GridControl.DataSource != null)
                        {
                            GridFirstCtlMoveUp();
                            WCommon.DataTableUpRow((DataTable)_HTDataDts.GridControl.DataSource, HTDataDts.FocusedRowHandle);
                            if (_HTDataDts.FocusedRowHandle > 0)
                            {
                                _HTDataDts.FocusedRowHandle = _HTDataDts.FocusedRowHandle - 1;
                            }
                        }
                        findFlag = true;
                    }
                    else//从表获得焦点
                    {
                        for (int i = 0; i < _HTDataDtsAttach.Length; i++)
                        {
                            if (_HTDataDtsAttach[i].GridControl.ContainsFocus)//获得焦点
                            {
                                if (_HTDataDtsAttach[i].GridControl.DataSource != null)
                                {
                                    WCommon.DataTableUpRow((DataTable)_HTDataDtsAttach[i].GridControl.DataSource, _HTDataDtsAttach[i].FocusedRowHandle);
                                    if (_HTDataDtsAttach[i].FocusedRowHandle > 0)
                                    {
                                        _HTDataDtsAttach[i].FocusedRowHandle = _HTDataDtsAttach[i].FocusedRowHandle - 1;
                                    }
                                }
                                findFlag = true;
                                break;
                            }
                        }
                    }
                    if (!findFlag)
                    {
                        this.ShowInfoMessage("请聚焦到数据列表再进行上移操作");
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 下移事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    bool findFlag = false;
                    if (_HTDataDts.GridControl.ContainsFocus || _HTDataDtsAttach.Length == 0)//主表获得焦点
                    {
                        if (_HTDataDts.GridControl.DataSource != null)
                        {
                            GridFirstCtlMoveDown();
                            WCommon.DataTableDownRow((DataTable)_HTDataDts.GridControl.DataSource, HTDataDts.FocusedRowHandle);
                            if (_HTDataDts.FocusedRowHandle + 1 < _HTDataDts.RowCount)
                            {
                                _HTDataDts.FocusedRowHandle = _HTDataDts.FocusedRowHandle + 1;
                            }
                        }
                        findFlag = true;
                    }
                    else//从表获得焦点
                    {
                        for (int i = 0; i < _HTDataDtsAttach.Length; i++)
                        {
                            if (_HTDataDtsAttach[i].GridControl.ContainsFocus)//获得焦点
                            {
                                if (_HTDataDtsAttach[i].GridControl.DataSource != null)
                                {
                                    WCommon.DataTableDownRow((DataTable)_HTDataDtsAttach[i].GridControl.DataSource, _HTDataDtsAttach[i].FocusedRowHandle);
                                    if (_HTDataDtsAttach[i].FocusedRowHandle + 1 < _HTDataDtsAttach[i].RowCount)
                                    {
                                        _HTDataDtsAttach[i].FocusedRowHandle = _HTDataDtsAttach[i].FocusedRowHandle + 1;
                                    }
                                }
                                findFlag = true;
                                break;
                            }
                        }
                    }
                    if (!findFlag)
                    {
                        this.ShowInfoMessage("请聚焦到数据列表再进行下移操作");
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
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

                base.btnDesign_Click(sender, e);
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                if (ci.SelectedItem == null)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }

                if (!_HTPrintDataSourceFlag)
                {
                    FastReport.ReportRun(tempReportID, (int)ReportPrintType.设计, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
                }
                else
                {
                    FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.设计, _HTPrintDataSource[0]);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnPreview_Click(sender, e);
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                if (ci.SelectedItem == null)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                if (!_HTPrintDataSourceFlag)
                {
                    FastReport.ReportRun(tempReportID, (int)ReportPrintType.预览, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
                }
                else
                {
                    FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.预览, _HTPrintDataSource[0]);
                }
                // FastReport.ReportRun(tempReportID, (int)ReportPrintType.预览, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
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
                base.btnPrint_Click(sender, e);
                //if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交3))
                //{
                //    this.ShowMessage("你没有此操作权限");
                //    return;
                //}
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                if (ci.SelectedItem == null)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                if (!_HTPrintDataSourceFlag)
                {
                    FastReport.ReportRun(tempReportID, (int)ReportPrintType.打印, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
                }
                else
                {
                    FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.打印, _HTPrintDataSource[0]);
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
            ButtonItem p_Insert = ToolBarItemGet(-1, ToolButtonName.btnInsert.ToString());
            ButtonItem p_Update = ToolBarItemGet(-1, ToolButtonName.btnUpdate.ToString());
            ButtonItem p_Delete = ToolBarItemGet(-1, ToolButtonName.btnDelete.ToString());
            ButtonItem p_InsertExis = ToolBarItemGet(-1, ToolButtonName.btnInsertExist.ToString());


            ButtonItem p_Preview = ToolBarItemGet(-1, ToolButtonName.btnPreview.ToString());
            ButtonItem p_Print = ToolBarItemGet(-1, ToolButtonName.btnPrint.ToString());
            ButtonItem p_Design = ToolBarItemGet(-1, ToolButtonName.btnDesign.ToString());
            ComboBoxItem p_PrintFile = ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());

            //p_Preview.Visible = _btnPrintVisible;
            //p_Print.Visible = _btnPrintVisible;
            //p_Design.Visible = _btnPrintVisible;
            //p_PrintFile.Visible = _btnPrintVisible;

            p_Preview.Visible = _btnPreviewVisible;
            p_Print.Visible = _btnPrintVisible;
            p_Design.Visible = _btnDesignVisible;
            p_PrintFile.Visible = _btnPrintFileVisible;



            p_Insert.Visible = _btnInsertVisible;
            p_Delete.Visible = _btnDeleteVisible;
            p_Update.Visible = _btnUpdateVisible;
            p_InsertExis.Visible = _btnInsertExistVisible;




            BaseToolBar.Refresh();
        }

        /// <summary>
        /// 设置操作按钮状态
        /// </summary>
        public void SetToolButtonStatus(FormStatus p_Status, int p_FormSubmitFlag, int p_DelFlag)
        {
            this.HTFormStatus = p_Status;
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
            ButtonItem p_FormCancel = ToolBarItemGet(-1, ToolButtonName.btnFormCancel.ToString());
            ButtonItem p_FormRestore = ToolBarItemGet(-1, ToolButtonName.btnFormRestore.ToString());

            ButtonItem p_AddRow = ToolBarItemGet(-1, ToolButtonName.btnAddRow.ToString());
            ButtonItem p_DelRow = ToolBarItemGet(-1, ToolButtonName.btnDelRow.ToString());


            ButtonItem p_First = ToolBarItemGet(-1, ToolButtonName.btnFirst.ToString());
            ButtonItem p_Pre = ToolBarItemGet(-1, ToolButtonName.btnPre.ToString());
            ButtonItem p_Next = ToolBarItemGet(-1, ToolButtonName.btnNext.ToString());
            ButtonItem p_Last = ToolBarItemGet(-1, ToolButtonName.btnLast.ToString());

            p_First.Enabled = false;
            p_Pre.Enabled = false;
            p_Next.Enabled = false;
            p_Last.Enabled = false;



            p_Insert.Enabled = false;
            p_Update.Enabled = false;
            p_Delete.Enabled = false;

            p_Save.Enabled = false;
            p_Drop.Enabled = false;

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

            p_FormCancel.Enabled = false;
            p_FormRestore.Enabled = false;

            p_AddRow.Enabled = false;
            p_DelRow.Enabled = false;

            switch (p_Status)
            {
                case FormStatus.查询:
                    this.HTDataID = SysConvert.ToInt32(this.SetToolButtonPosStatus(this.HTDataID.ToString(), HTDataTableName));//设置单据张数导航定位状态

                    if (p_DelFlag == 0)
                    {
                        p_FormCancel.Enabled = true;
                    }
                    else
                    {
                        p_FormRestore.Enabled = true;
                    }

                    p_Insert.Enabled = true;
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
                            p_AuditRefuse.Enabled = false;
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
                            p_CancelSubmit.Enabled = true;
                            p_AuditPass.Enabled = true;
                            p_AuditRefuse.Enabled = false;

                            p_Update.Enabled = false;
                            p_Delete.Enabled = false;
                            break;
                    }

                    break;
                case FormStatus.新增:
                    p_Save.Enabled = true;
                    p_Drop.Enabled = true;

                    p_AddRow.Enabled = true;
                    p_DelRow.Enabled = true;


                    p_Submit.Enabled = false;
                    p_CancelSubmit.Enabled = false;
                    p_AuditPass.Enabled = false;
                    p_AuditRefuse.Enabled = false;
                    break;
                case FormStatus.修改:
                    p_Save.Enabled = true;
                    p_Drop.Enabled = true;

                    p_AddRow.Enabled = true;
                    p_DelRow.Enabled = true;


                    p_Submit.Enabled = false;
                    p_CancelSubmit.Enabled = false;
                    p_AuditPass.Enabled = false;
                    p_AuditRefuse.Enabled = false;
                    break;
                case FormStatus.放弃:
                    goto case FormStatus.查询;
            }


            BaseToolBar.Refresh();
        }

        /// <summary>
        /// 设置单据张数导航定位状态
        /// </summary>
        /// <param name="p_First">首张</param>
        /// <param name="p_Prev">前张</param>
        /// <param name="p_Next">下张</param>
        /// <param name="p_Last">末张</param>
        /// <param name="p_HeadType">单据大类</param>
        /// <param name="p_IOFormID">单据ID</param>
        public virtual string SetToolButtonPosStatus(string p_IDValue, string p_TableName)
        {
            return SetToolButtonPosStatus(p_IDValue, p_TableName, "ID", "");
        }


        /// <summary>
        /// 设置单据张数导航定位状态
        /// </summary>
        /// <param name="p_First">首张</param>
        /// <param name="p_Prev">前张</param>
        /// <param name="p_Next">下张</param>
        /// <param name="p_Last">末张</param>
        /// <param name="p_IOFormID">单据ID</param>
        /// <param name="p_TableName">查询表名</param>
        /// <param name="p_HeadType">单据大类</param>
        /// <param name="p_SubType">单据小类</param>
        /// <returns>单据ID</returns>
        public string SetToolButtonPosStatus(string p_IDValue, string p_TableName, string p_IDFieldName, string p_Condition)
        {
            string outstr = p_IDValue;

            p_Condition = _SetPosCondition;//查询条件


            ButtonItem p_First = ToolBarItemGet(-1, ToolButtonName.btnFirst.ToString());
            ButtonItem p_Prev = ToolBarItemGet(-1, ToolButtonName.btnPre.ToString());
            ButtonItem p_Next = ToolBarItemGet(-1, ToolButtonName.btnNext.ToString());
            ButtonItem p_Last = ToolBarItemGet(-1, ToolButtonName.btnLast.ToString());



            p_First.Tag = "";
            p_First.Enabled = true;
            p_Prev.Tag = "";
            p_Prev.Enabled = true;
            p_Next.Tag = "";
            p_Next.Enabled = true;
            p_Last.Tag = "";
            p_Last.Enabled = true;

            if (HTDataQueryResult == null)//查询结果集为空
            {
                string sql = string.Empty;
                //string tempstr = string.Empty;

                sql = "SELECT TOP 1 " + p_IDFieldName + " FROM " + p_TableName + " WHERE  isnull(DelFlag,0)=0 " + p_Condition + " ORDER BY " + p_IDFieldName + " ASC";//首张
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    p_First.Tag = SysConvert.ToString(dt.Rows[0][0].ToString());
                }

                sql = "SELECT TOP 1 " + p_IDFieldName + " FROM " + p_TableName + " WHERE isnull(DelFlag,0)=0 " + p_Condition + " ORDER BY " + p_IDFieldName + " DESC";//末张
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    p_Last.Tag = SysConvert.ToString(dt.Rows[0][0].ToString());
                }

                if (p_IDValue == "" || p_IDValue == "0")//如果定位的是0则自动载入末张
                {
                    p_IDValue = SysConvert.ToString(p_Last.Tag);
                    outstr = p_IDValue;
                }

                sql = "SELECT TOP 1 " + p_IDFieldName + " FROM " + p_TableName + " WHERE " + p_IDFieldName + " >" + SysString.ToDBString(p_IDValue) + " AND isnull(DelFlag,0)=0 " + p_Condition + " ORDER BY " + p_IDFieldName + " ASC";//下张
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    p_Next.Tag = SysConvert.ToString(dt.Rows[0][0].ToString());
                }

                sql = "SELECT TOP 1 " + p_IDFieldName + " FROM " + p_TableName + " WHERE " + p_IDFieldName + "<" + SysString.ToDBString(p_IDValue) + " AND isnull(DelFlag,0)=0 " + p_Condition + " ORDER BY " + p_IDFieldName + " DESC";//上张
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    p_Prev.Tag = SysConvert.ToString(dt.Rows[0][0].ToString());
                }
            }
            else//查询结果集不为空
            {
                int curRowID = SetToolButtonPosStatusQueryResutCurRowID(_HTDataQueryResult, p_IDValue, p_IDFieldName);
                p_First.Tag = SetToolButtonPosStatusQueryResutFirstID(_HTDataQueryResult, curRowID, p_IDValue, p_IDFieldName);
                p_Prev.Tag = SetToolButtonPosStatusQueryResutPrevID(_HTDataQueryResult, curRowID, p_IDValue, p_IDFieldName);
                p_Next.Tag = SetToolButtonPosStatusQueryResutNextID(_HTDataQueryResult, curRowID, p_IDValue, p_IDFieldName);
                p_Last.Tag = SetToolButtonPosStatusQueryResutLastID(_HTDataQueryResult, curRowID, p_IDValue, p_IDFieldName);
                if (p_IDValue == "" || p_IDValue == "0")//如果定位的是0则自动载入末张
                {
                    p_IDValue = SysConvert.ToString(p_Last.Tag);
                    outstr = p_IDValue;
                }
            }


            if (SysConvert.ToString(p_First.Tag) == p_IDValue || SysConvert.ToString(p_First.Tag) == "" || SysConvert.ToString(p_First.Tag) == "0")
            {
                p_First.Enabled = false;
            }

            if (SysConvert.ToString(p_Prev.Tag) == p_IDValue || SysConvert.ToString(p_Prev.Tag) == "" || SysConvert.ToString(p_Prev.Tag) == "0")
            {
                p_Prev.Enabled = false;
            }

            if (SysConvert.ToString(p_Next.Tag) == p_IDValue || SysConvert.ToString(p_Next.Tag) == "" || SysConvert.ToString(p_Next.Tag) == "0")
            {
                p_Next.Enabled = false;
            }

            if (SysConvert.ToString(p_Last.Tag) == p_IDValue || SysConvert.ToString(p_Last.Tag) == "" || SysConvert.ToString(p_Last.Tag) == "0")
            {
                p_Last.Enabled = false;
            }

            BaseToolBar.Refresh();
            return outstr;
        }

        #region  SetToolButtonPosStatus 老方法备份
        /// <summary>
        /// 设置单据张数导航定位状态
        /// </summary>
        /// <param name="p_First">首张</param>
        /// <param name="p_Prev">前张</param>
        /// <param name="p_Next">下张</param>
        /// <param name="p_Last">末张</param>
        /// <param name="p_IOFormID">单据ID</param>
        /// <param name="p_TableName">查询表名</param>
        /// <param name="p_HeadType">单据大类</param>
        /// <param name="p_SubType">单据小类</param>
        /// <returns>单据ID</returns>
        public string SetToolButtonPosStatusBG(string p_IDValue, string p_TableName, string p_IDFieldName, string p_Condition)
        {
            string outstr = p_IDValue;

            p_Condition = _SetPosCondition;//查询条件


            ButtonItem p_First = ToolBarItemGet(-1, ToolButtonName.btnFirst.ToString());
            ButtonItem p_Prev = ToolBarItemGet(-1, ToolButtonName.btnPre.ToString());
            ButtonItem p_Next = ToolBarItemGet(-1, ToolButtonName.btnNext.ToString());
            ButtonItem p_Last = ToolBarItemGet(-1, ToolButtonName.btnLast.ToString());

            p_First.Tag = "";
            p_First.Enabled = true;
            p_Prev.Tag = "";
            p_Prev.Enabled = true;
            p_Next.Tag = "";
            p_Next.Enabled = true;
            p_Last.Tag = "";
            p_Last.Enabled = true;

            string sql = string.Empty;
            //string tempstr = string.Empty;

            sql = "SELECT TOP 1 " + p_IDFieldName + " FROM " + p_TableName + " WHERE isnull(DelFlag,0)=0 " + p_Condition + " ORDER BY " + p_IDFieldName + " ASC";//首张
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                p_First.Tag = SysConvert.ToString(dt.Rows[0][0].ToString());
            }

            sql = "SELECT TOP 1 " + p_IDFieldName + " FROM " + p_TableName + " WHERE isnull(DelFlag,0)=0 " + p_Condition + " ORDER BY " + p_IDFieldName + " DESC";//末张
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                p_Last.Tag = SysConvert.ToString(dt.Rows[0][0].ToString());
            }

            if (p_IDValue == "" || p_IDValue == "0")//如果定位的是0则自动载入末张
            {
                p_IDValue = SysConvert.ToString(p_Last.Tag);
                outstr = p_IDValue;
            }

            sql = "SELECT TOP 1 " + p_IDFieldName + " FROM " + p_TableName + " WHERE " + p_IDFieldName + " >" + SysString.ToDBString(p_IDValue) + " AND isnull(DelFlag,0)=0 " + p_Condition + " ORDER BY " + p_IDFieldName + " ASC";//下张
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                p_Next.Tag = SysConvert.ToString(dt.Rows[0][0].ToString());
            }

            sql = "SELECT TOP 1 " + p_IDFieldName + " FROM " + p_TableName + " WHERE " + p_IDFieldName + "<" + SysString.ToDBString(p_IDValue) + " AND isnull(DelFlag,0)=0 " + p_Condition + " ORDER BY " + p_IDFieldName + " DESC";//上张
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                p_Prev.Tag = SysConvert.ToString(dt.Rows[0][0].ToString());
            }

            if (SysConvert.ToString(p_First.Tag) == p_IDValue || SysConvert.ToString(p_First.Tag) == "" || SysConvert.ToString(p_First.Tag) == "0")
            {
                p_First.Enabled = false;
            }

            if (SysConvert.ToString(p_Prev.Tag) == p_IDValue || SysConvert.ToString(p_Prev.Tag) == "" || SysConvert.ToString(p_Prev.Tag) == "0")
            {
                p_Prev.Enabled = false;
            }

            if (SysConvert.ToString(p_Next.Tag) == p_IDValue || SysConvert.ToString(p_Next.Tag) == "" || SysConvert.ToString(p_Next.Tag) == "0")
            {
                p_Next.Enabled = false;
            }

            if (SysConvert.ToString(p_Last.Tag) == p_IDValue || SysConvert.ToString(p_Last.Tag) == "" || SysConvert.ToString(p_Last.Tag) == "0")
            {
                p_Last.Enabled = false;
            }

            BaseToolBar.Refresh();
            return outstr;
        }
        #endregion


        #endregion

        #region 导航按钮事件

        /// <summary>
        /// 首张
        /// </summary>
        public override void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                SetPosStatus(SysConvert.ToInt32(this.ToolBarItemGet(-1, ToolButtonName.btnFirst.ToString()).Tag));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 上张
        /// </summary>
        public override void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                SetPosStatus(SysConvert.ToInt32(this.ToolBarItemGet(-1, ToolButtonName.btnPre.ToString()).Tag));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 下张
        /// </summary>
        public override void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                SetPosStatus(SysConvert.ToInt32(this.ToolBarItemGet(-1, ToolButtonName.btnNext.ToString()).Tag));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 末张
        /// </summary>
        public override void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                SetPosStatus(SysConvert.ToInt32(this.ToolBarItemGet(-1, ToolButtonName.btnLast.ToString()).Tag));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 工具栏初始化
        /// <summary>
        /// 创建Bar默认按钮
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(54, ToolButtonName.btnInsert.ToString(), "新增", false, btnInsert_Click, eShortcut.F1);
            this.ToolBarItemAdd(55, ToolButtonName.btnUpdate.ToString(), "修改", false, btnUpdate_Click, eShortcut.F2);
            this.ToolBarItemAdd(44, ToolButtonName.btnDelete.ToString(), "删除", false, btnDelete_Click, eShortcut.F3);
            this.ToolBarItemAdd(37, ToolButtonName.btnSave.ToString(), "保存", false, btnSave_Click, eShortcut.F4);
            this.ToolBarItemAdd(40, ToolButtonName.btnCancel.ToString(), "放弃", false, btnCancel_Click);
            this.ToolBarItemAdd(51, ToolButtonName.btnSubmit.ToString(), "提交", true, btnSubmit_Click);
            this.ToolBarItemAdd(38, ToolButtonName.btnSubmitCancel.ToString(), "撤消提交", false, btnSubmitCancel_Click);
            this.ToolBarItemAdd(47, ToolButtonName.btnAudit.ToString(), "审核通过", false, btnAudit_Click);
            this.ToolBarItemAdd(48, ToolButtonName.btnAuditCancel.ToString(), "审核拒绝", false, btnAuditCancel_Click);
            //this.ToolBarItemAdd(21, ToolButtonName.btnFormCancel.ToString(), "取消单据", false, btnFormCancel_Click);
            //this.ToolBarItemAdd(19, ToolButtonName.btnFormRestore.ToString(), "恢复单据", false, btnFormRestore_Click);
            this.ToolBarItemAdd(49, ToolButtonName.btnFirst.ToString(), "首页", true, btnFirst_Click);
            this.ToolBarItemAdd(45, ToolButtonName.btnPre.ToString(), "上页", false, btnPre_Click);
            this.ToolBarItemAdd(53, ToolButtonName.btnNext.ToString(), "下页", false, btnNext_Click);
            this.ToolBarItemAdd(43, ToolButtonName.btnLast.ToString(), "末页", false, btnLast_Click);

            this.ToolBarItemAdd(41, ToolButtonName.btnInsertExist.ToString(), "复制", true, btnInsertExist_Click, eShortcut.CtrlIns);
            this.ToolBarItemAdd(56, ToolButtonName.btnPreview.ToString(), "预览", true, btnPreview_Click, eShortcut.F7);
            this.ToolBarItemAdd(39, ToolButtonName.btnPrint.ToString(), "打印", false, btnPrint_Click, eShortcut.F8);
            this.ToolBarItemAdd(46, ToolButtonName.btnDesign.ToString(), "设计", false, btnDesign_Click);
            //this.ToolBarItemAdd(25, ToolButtonName.btnToExcel.ToString(), "转EXCEL", btnToExcel_Click);
            this.ToolBarCItemAdd(ToolButtonName.drpPrintFile.ToString(), 120);
            this.ToolBarLItemAdd(ToolButtonName.lblFormStatus.ToString(), Color.Red);

            BindReport(ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString()));




        }

        /// <summary>
        /// 创建Bar默认按钮(靠右按钮)
        /// </summary>
        public override void ToolIniCreateBar2()
        {
            //this.ToolBarItemAdd2(9, ToolButtonName.btnAddRow.ToString(), "增行", false, btnAddRow_Click, eShortcut.ShiftF1);
            //this.ToolBarItemAdd2(8, ToolButtonName.btnDelRow.ToString(), "删行", false, btnDelRow_Click, eShortcut.ShiftF2);
            //this.ToolBarItemAdd2(33, ToolButtonName.btnMoveUp.ToString(), "上移", false, btnMoveUp_Click, eShortcut.ShiftF3);
            //this.ToolBarItemAdd2(34, ToolButtonName.btnMoveDown.ToString(), "下移", false, btnMoveDown_Click, eShortcut.ShiftF4);
            this.ToolBarItemAdd2(52, "btnFile", "文件", false, btnFile_Click, eShortcut.F8);
            this.ToolBarItemAdd2(50, ToolButtonName.btnRefresh.ToString(), "刷新", false, btnRefresh_Click, eShortcut.F6);
            this.ToolBarItemAdd2(36, ToolButtonName.btnHelp.ToString(), "帮助", false, btnHelp_Click, eShortcut.F11);
        }

        /// <summary>
        /// 绑定报表名称
        /// </summary>
        public virtual void BindReport(DevComponents.DotNetBar.ComboBoxItem p_DrpID)
        {
            if (FormID != 0)
            {
                string sql = "SELECT ReportName,ID FROM dbo.Data_ReportManage where ";//WinListID = " +  FormID.ToString() + "
                if (this.RightFormID != 0)
                {
                    sql += " WinListID=" + this.RightFormID;
                }
                else
                {
                    sql += " WinListID=" + this.FormID;
                }
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

        #region 窗体事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAPBaseUIFormEdit_Load(object sender, EventArgs e)
        {
            try
            {
                if (FormID != 0)
                {
                    this.RightFormID = this.GetFormIDByClassName(this.Name.Replace("Edit", ""));
                    string tempStr = HTGetFormCaption(this.Name.Replace("Edit", ""));
                    if (tempStr != string.Empty)
                    {
                        this.Text = tempStr + "明细";
                    }

                    IniData();
                   
                    this.IniRefreshData();

                    ToolIniCreateBar2();//加载靠右控件

                    IniFormLoadBefore();//此处才执行赋值HTDataDts.ViewCaption

                    if (HTDataDts != null)//2014/6/6 处理验证配置必输项功能
                    {
                        string[] checkfiledNameA = GetHTCheckDataField(SysConvert.ToInt32(HTDataDts.ViewCaption));
                        if (checkfiledNameA.Length != 0)//如果有配置值的话
                        {
                            HTCheckDataField = checkfiledNameA;
                        }
                    }

                    IniFormLoadBehind();

                    if (this.HTDataID != 0 || HTFormStatus != FormStatus.查询)//弹出窗口的情况下刷新数据及按钮状态
                    {
                        FormStatus tempFormStatus = HTFormStatus;
                        switch (tempFormStatus)
                        {
                            case FormStatus.新增:
                                //EntitySet();
                                ////SetPosStatus(HTDataID);
                                //SetFormStatus(HTFormStatus);
                                btnInsert_Click(sender, e);
                                break;
                            case FormStatus.新增已存在:
                                btnInsertExist_Click(sender, e);
                                break;
                            case FormStatus.修改:
                                //EntitySet();
                                SetPosStatus(HTDataID);
                                SetFormStatus(tempFormStatus);
                                _HTDataOldID = HTDataID;
                                break;
                            default:
                                //EntitySet();
                                SetPosStatus(HTDataID);
                                SetFormStatus(tempFormStatus);
                                break;
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAPBaseUIFormEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (DialogResult.Yes != ShowConfirmMessage(this.Text + Environment.NewLine + "没有保存数据,是否确认关闭窗体"))
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 其它事件

        #endregion

        #region 右键处理相关
        /// <summary>
        /// 增加右键
        /// </summary>
        /// <param name="p_Caption">标题</param>
        /// <param name="p_Eve">事件</param>
        public void HTAPAddContextMenuFirst(string p_Caption, System.EventHandler p_Eve)
        {
            //HTAPAddContextMenu(this.cMenuFirst, p_Caption, p_Eve);

            HTAPAddContextMenuFirst(p_Caption, p_Eve, _HTDataDts.GridControl);
        }

        /// <summary>
        /// 增加右键
        /// </summary>
        /// <param name="p_Caption">标题</param>
        /// <param name="p_Eve">事件</param>
        public void HTAPAddContextMenuFirst(string p_Caption, System.EventHandler p_Eve, Control p_Ctl)
        {
            //HTAPAddContextMenu(this.cMenuFirst, p_Caption, p_Eve);

            if (p_Ctl == _HTDataDts.GridControl)
            {
                HTAPAddContextMenu(this.cMenuFirst, p_Caption, p_Eve);
            }
            for (int i = 0; i < _HTDataDtsAttach.Length; i++)
            {
                if (p_Ctl == _HTDataDtsAttach[i].GridControl)
                {
                    switch (i + 1)
                    {
                        case 1:
                            HTAPAddContextMenu(this.cMenuSecond, p_Caption, p_Eve);
                            break;
                        case 2:
                            HTAPAddContextMenu(this.cMenuThird, p_Caption, p_Eve);
                            break;
                        case 3:
                            HTAPAddContextMenu(this.cMenuFourth, p_Caption, p_Eve);
                            break;
                        case 4:
                            HTAPAddContextMenu(this.cMenuFifth, p_Caption, p_Eve);
                            break;
                        case 5:
                            HTAPAddContextMenu(this.cMenuSixth, p_Caption, p_Eve);
                            break;
                    }
                }
            }

        }


        /// <summary>
        /// 设置右键
        /// </summary>
        /// <param name="p_Ctl">控件</param>
        public void HTAPSetContextMenuFirst(Control p_Ctl)
        {
            //p_Ctl.ContextMenuStrip = this.cMenuFirst;

            if (p_Ctl == _HTDataDts.GridControl)
            {
                p_Ctl.ContextMenuStrip = this.cMenuFirst;
            }

            for (int i = 0; i < _HTDataDtsAttach.Length; i++)
            {
                if (p_Ctl == _HTDataDtsAttach[i].GridControl)
                {
                    switch (i + 1)
                    {
                        case 1:
                            _HTDataDtsAttach[i].GridControl.ContextMenuStrip = this.cMenuSecond;
                            break;
                        case 2:
                            _HTDataDtsAttach[i].GridControl.ContextMenuStrip = this.cMenuThird;
                            break;
                        case 3:
                            _HTDataDtsAttach[i].GridControl.ContextMenuStrip = this.cMenuFourth;
                            break;
                        case 4:
                            _HTDataDtsAttach[i].GridControl.ContextMenuStrip = this.cMenuFifth;
                            break;
                        case 5:
                            _HTDataDtsAttach[i].GridControl.ContextMenuStrip = this.cMenuSixth;
                            break;
                    }
                }
            }

        }
        #endregion

        /// <summary>
        /// 刷新数据(刷新数据方式，可重写)
        /// </summary>
        /// <param name="p_DataID">数据ID</param>
        public virtual void RefreshData(int p_DataID)//,FormStatus p_Status/// <param name="p_Status">状态</param>
        {
            this.EntitySet();
            FileSetButtonFileNumber();//设置文件数
        }

        #region 增行删行事件

        #region cMenuFirst---HTDataDts
        /// <summary>
        /// 增行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void cMenuAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    GridFirstCtlAddRow();

                    //BaseFocusLabel.Focus();
                    WCommon.DataTableAddRow((DataTable)_HTDataDts.GridControl.DataSource, _HTDataDts.FocusedRowHandle);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 删行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void cMenuDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (_HTGridDelShowConfirmFlag)
                    {
                        if (DialogResult.Yes != this.ShowConfirmMessage("确实要删除该行"))
                        {
                            return;
                        }
                    }
                    GridFirstCtlDelRow();

                    //BaseFocusLabel.Focus();
                    WCommon.DelDtRow((DataTable)_HTDataDts.GridControl.DataSource, _HTDataDts.FocusedRowHandle);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void cMenuMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (_HTDataDts.GridControl.DataSource != null)
                {
                    GridFirstCtlMoveUp();
                    WCommon.DataTableUpRow((DataTable)_HTDataDts.GridControl.DataSource, _HTDataDts.FocusedRowHandle);
                    if (_HTDataDts.FocusedRowHandle > 0)
                    {
                        _HTDataDts.FocusedRowHandle = _HTDataDts.FocusedRowHandle - 1;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void cMenuMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (_HTDataDts.GridControl.DataSource != null)
                {
                    GridFirstCtlMoveDown();

                    WCommon.DataTableDownRow((DataTable)_HTDataDts.GridControl.DataSource, HTDataDts.FocusedRowHandle);
                    if (_HTDataDts.FocusedRowHandle + 1 < _HTDataDts.RowCount)
                    {
                        _HTDataDts.FocusedRowHandle = _HTDataDts.FocusedRowHandle + 1;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region cMenuSecond----_HTDataDtsAttach[0]
        /// <summary>
        /// 增行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuAddRow2_Click(object sender, EventArgs e)
        {
            cMenuAddRowAttach(0);
        }
        /// <summary>
        /// 删行----2010-7-30zfc处理改成虚方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void cMenuDelRow2_Click(object sender, EventArgs e)
        {
            cMenuDelRowAttach(0);
        }

        private void cMenuMoveUp2_Click(object sender, EventArgs e)
        {
            cMenuMoveUpAttach(0);
        }

        private void cMenuMoveDown2_Click(object sender, EventArgs e)
        {
            cMenuMoveDownAttach(0);
        }


        #endregion

        #region cMenuThird----_HTDataDtsAttach[1]
        /// <summary>
        /// 增行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuAddRow3_Click(object sender, EventArgs e)
        {
            cMenuAddRowAttach(1);
        }
        private void cMenuDelRow3_Click(object sender, EventArgs e)
        {
            cMenuDelRowAttach(1);
        }

        private void cMenuMoveUp3_Click(object sender, EventArgs e)
        {
            cMenuMoveUpAttach(1);
        }

        private void cMenuMoveDown3_Click(object sender, EventArgs e)
        {
            cMenuMoveDownAttach(1);
        }
        #endregion

        #region cMenuFourth----_HTDataDtsAttach[2]
        private void cMenuAddRow4_Click(object sender, EventArgs e)
        {
            cMenuAddRowAttach(2);
        }

        private void cMenuDelRow4_Click(object sender, EventArgs e)
        {
            cMenuDelRowAttach(2);
        }

        private void cMenuMoveUp4_Click(object sender, EventArgs e)
        {
            cMenuMoveUpAttach(2);
        }

        private void cMenuMoveDown4_Click(object sender, EventArgs e)
        {
            cMenuMoveDownAttach(2);
        }
        #endregion

        #region cMenuFifth----_HTDataDtsAttach[3]
        private void cMenuAddRow5_Click(object sender, EventArgs e)
        {
            cMenuAddRowAttach(3);
        }

        private void cMenuDelRow5_Click(object sender, EventArgs e)
        {
            cMenuDelRowAttach(3);
        }

        private void cMenuMoveUp5_Click(object sender, EventArgs e)
        {
            cMenuMoveUpAttach(3);
        }

        private void cMenuMoveDown5_Click(object sender, EventArgs e)
        {
            cMenuMoveDownAttach(3);
        }
        #endregion

        #region cMenuSixth----_HTDataDtsAttach[4]
        private void cMenuAddRow6_Click(object sender, EventArgs e)
        {
            cMenuAddRowAttach(4);
        }

        private void cMenuDelRow6_Click(object sender, EventArgs e)
        {
            cMenuDelRowAttach(4);
        }

        private void cMenuMoveUp6_Click(object sender, EventArgs e)
        {
            cMenuMoveUpAttach(4);
        }

        private void cMenuMoveDown6_Click(object sender, EventArgs e)
        {
            cMenuMoveDownAttach(4);
        }
        #endregion

        #region  明细GridView增行通用方法------_HTDataDtsAttach
        /// <summary>
        /// 增行
        /// </summary>
        /// <param name="p_Index"></param>
        private void cMenuAddRowAttach(int p_Index)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    //BaseFocusLabel.Focus();
                    WCommon.DataTableAddRow((DataTable)_HTDataDtsAttach[p_Index].GridControl.DataSource, _HTDataDtsAttach[p_Index].FocusedRowHandle);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 删行
        /// </summary>
        /// <param name="p_Index"></param>
        private void cMenuDelRowAttach(int p_Index)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    //BaseFocusLabel.Focus();
                    if (DialogResult.Yes != this.ShowConfirmMessage("确实要删除该行"))
                    {
                        return;
                    }
                    WCommon.DelDtRow((DataTable)_HTDataDtsAttach[p_Index].GridControl.DataSource, _HTDataDtsAttach[p_Index].FocusedRowHandle);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="p_Index"></param>
        private void cMenuMoveUpAttach(int p_Index)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (_HTDataDtsAttach[p_Index].GridControl.DataSource != null)
                    {
                        WCommon.DataTableUpRow((DataTable)_HTDataDtsAttach[p_Index].GridControl.DataSource, _HTDataDtsAttach[p_Index].FocusedRowHandle);
                        if (_HTDataDtsAttach[p_Index].FocusedRowHandle > 0)
                        {
                            _HTDataDtsAttach[p_Index].FocusedRowHandle = _HTDataDtsAttach[p_Index].FocusedRowHandle - 1;
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="p_Index"></param>
        private void cMenuMoveDownAttach(int p_Index)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (_HTDataDtsAttach[p_Index].GridControl.DataSource != null)
                    {
                        WCommon.DataTableDownRow((DataTable)_HTDataDtsAttach[p_Index].GridControl.DataSource, _HTDataDtsAttach[p_Index].FocusedRowHandle);
                        if (_HTDataDtsAttach[p_Index].FocusedRowHandle + 1 < _HTDataDtsAttach[p_Index].RowCount)
                        {
                            _HTDataDtsAttach[p_Index].FocusedRowHandle = _HTDataDtsAttach[p_Index].FocusedRowHandle + 1;
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #endregion









    }
}