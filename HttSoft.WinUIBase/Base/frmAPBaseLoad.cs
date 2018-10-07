using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
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
    public partial class frmAPBaseLoad : frmAPBaseTool
    {
        public frmAPBaseLoad()
        {
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// 加载查询条件
        /// </summary>
        private string _HTLoadConditionStr = string.Empty;
        /// <summary>
        /// 加载查询条件
        /// </summary>
        public string HTLoadConditionStr
        {
            get
            {
                return _HTLoadConditionStr;
            }
            set
            {
                _HTLoadConditionStr = value;
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
        /// 初始化查询控制
        /// </summary>
        //private bool _IsPostBack = true;
        private bool _IsPostBack = false;
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
        /// 返回值属性
        /// </summary>
        private ArrayList _HTLoadData = new ArrayList();
        /// <summary>
        /// 返回值属性
        /// </summary>
        public ArrayList HTLoadData
        {
            get
            {
                return _HTLoadData;
            }
            set
            {
                _HTLoadData = value;
            }
        }

        /// <summary>
        /// 返回值属性
        /// </summary>
        private ArrayList _HTLoadDataSeq = new ArrayList();
        /// <summary>
        /// 返回值属性
        /// </summary>
        public ArrayList HTLoadDataSeq
        {
            get
            {
                return _HTLoadDataSeq;
            }
            set
            {
                _HTLoadDataSeq = value;
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
        /// 加载数据
        /// </summary>
        public virtual void LoadData()
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
                _HTDataList.RowCellStyle += new RowCellStyleEventHandler(_HTDataDts_RowCellStyle);
                _HTDataList.GridControl.DoubleClick += new EventHandler(btnLoad_Click);
                _HTDataList.OptionsBehavior.ShowEditorOnMouseUp = false;
            }

            for (int i = 0; i < _HTDataDtsAttach.Length; i++)
            {
                ProcessGrid.BindGridColumn(_HTDataDtsAttach[i], this.FormID);//绑定列
                ProcessGrid.SetGridColumnUI(_HTDataDtsAttach[i], this.FormListAID, this.FormListBID);//设置列UI
                ProcessGrid.SetGridManDefault(_HTDataDtsAttach[i]);
                _HTDataDtsAttach[i].OptionsBehavior.ShowEditorOnMouseUp = false;
            }

            ProcessGrid.SetGridReadOnly(_HTDataList, true);
            ProcessGrid.SetGridUIListDefault(_HTDataList);
            //btnQuery_Click(null, null);


        }

        /// <summary>
        /// 设置编辑页面的连续行的颜色不同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _HTDataDts_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
        #endregion


        #region  创建Bar默认按钮
        /// <summary>
        /// 创建Bar默认按钮
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(22, ToolButtonName.btnQuery.ToString(), "查询", false, btnQuery_Click, eShortcut.F5);
            this.ToolBarItemAdd(32, ToolButtonName.btnLoad.ToString(), "加载", true, btnLoad_Click);
        }

        /// <summary>
        /// 创建Bar默认按钮(靠右按钮)
        /// </summary>
        public override void ToolIniCreateBar2()
        {
            this.ToolBarItemAdd2(35, ToolButtonName.btnHelp.ToString(), "帮助", false, btnHelp_Click, eShortcut.F11);

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
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {

                LoadData();
                if (this._HTLoadData.Count == 0)
                {
                    this.ShowMessage("请选择要加载的记录");
                    return;
                }
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 窗体事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAPBaseLoad_Load(object sender, EventArgs e)
        {
            try
            {
                if (FormID != 0)
                {
                    IniData();
                    IniQryMethod();
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

    }
}