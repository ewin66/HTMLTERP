using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using DevComponents.DotNetBar;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;

namespace HttSoft.WinUIBase
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public partial class frmAPBaseCondition : frmAPBaseTool
    {
        public frmAPBaseCondition()
        {
            InitializeComponent();
        }

        #region 属性

        /// <summary>
        /// 默认查询数组 ConType,FieldName,QType
        /// </summary>
        private ArrayList _HTDataQueryFieldDefault = new ArrayList();
        /// <summary>
        /// 默认查询数组 ConType,FieldName,QType
        /// </summary>
        public ArrayList HTDataQueryFieldDefault
        {
            get
            {
                return _HTDataQueryFieldDefault;
            }
            set
            {
                _HTDataQueryFieldDefault = value;
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
        /// 执行查询标志
        /// </summary>
        private bool _HTExcuteQueryEventFlag = false;
        /// <summary>
        /// 执行查询标志
        /// </summary>
        public bool HTExcuteQueryEventFlag
        {
            get
            {
                return _HTExcuteQueryEventFlag;
            }
            set
            {
                _HTExcuteQueryEventFlag = value;
            }
        }

        /// <summary>
        /// 父窗体数据列表
        /// </summary>
        private GridView _HTParentDataList = new GridView();
        /// <summary>
        /// 父窗体数据列表
        /// </summary>
        public GridView HTParentDataList
        {
            get
            {
                return _HTParentDataList;
            }
            set
            {
                _HTParentDataList = value;
            }
        }

        /// <summary>
        /// 上次查询条件
        /// </summary>
        private DataTable _HTPreQueryDataSource;
        /// <summary>
        /// 上次查询条件
        /// </summary>
        public DataTable HTPreQueryDataSource
        {
            get
            {
                return _HTPreQueryDataSource;
            }
            set
            {
                _HTPreQueryDataSource = value;
            }
        }
        #endregion

        #region 自定义方法
        string[] saveQueryTypeArray = new string[] { "=", "包含", ">=", "<=" };
        /// <summary>
        /// 获得查询条件
        /// </summary>
        private void GetCondition()
        {
            _HTDataConditionStr = "";
            string tempConditionStr = string.Empty;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string conType = SysConvert.ToString(gridView1.GetRowCellValue(i, "ConType"));
                string cFieldName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColFieldName"));
                string cQtype = SysConvert.ToString(gridView1.GetRowCellValue(i, "QType"));
                string cQV1 = SysConvert.ToString(gridView1.GetRowCellValue(i, "QV1"));
                if (cFieldName != string.Empty && cQtype != string.Empty && cQV1 != string.Empty)
                {
                    if (tempConditionStr != string.Empty)
                    {
                        if (conType == "或")
                        {
                            tempConditionStr += " OR ";

                        }
                        else//与
                        {
                            tempConditionStr += " AND ";
                        }
                    }
                    tempConditionStr += " " + cFieldName + " ";
                    switch (cQtype)
                    {
                        case "=":
                            tempConditionStr += cQtype + " " + SysString.ToDBString(cQV1);
                            break;
                        case "包含":
                            tempConditionStr += " LIKE " + SysString.ToDBString("%" + cQV1 + "%");
                            break;
                        default:
                            goto case "=";
                    }
                }
            }

            if (tempConditionStr != string.Empty)
            {
                tempConditionStr = " AND (" + tempConditionStr + ")";
            }
            _HTDataConditionStr = tempConditionStr;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void IniData()
        {
            //处理查询方式数据源 BEGIN
            DataTable dtQueryType = new DataTable();
            dtQueryType.Columns.Add(new DataColumn("Name", typeof(string)));
            for (int i = 0; i < saveQueryTypeArray.Length; i++)
            {
                DataRow dr = dtQueryType.NewRow();
                dr["Name"] = saveQueryTypeArray[i];
                dtQueryType.Rows.Add(dr);
            }
            FCommon.LoadDropRepositoryComb(drpQType, dtQueryType, "Name", true);
            //处理查询方式数据源 END


            //绑定查询字段数据源 BEGIN
            drpColFieldName.ShowHeader = false;
            drpColFieldName.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(drpColFieldName, new int[] { 0, 100 }, new string[] { "FieldName", "Caption" }, new string[] { "", "" }, new bool[] { false, true });
            DataTable dtParentQueryFiled = GetParentQueryFiled();
            FCommon.LoadDropRepositoryLookUP(drpColFieldName, dtParentQueryFiled, "Caption", "FieldName", false);//查询数据     
            //绑定查询字段数据源 END       

            BindGrid(GetGridSource());//处理Grid

            if (_HTDataQueryFieldDefault.Count != 0)
            {
                for (int i = 0; i < _HTDataQueryFieldDefault.Count; i++)
                {
                    if (gridView1.RowCount <= i || dtParentQueryFiled.Rows.Count <= i)//溢出，异常退出循环
                    {
                        break;
                    }
                    string[] tempA = (string[])_HTDataQueryFieldDefault[i];//默认数组

                    gridView1.SetRowCellValue(i, "ConType", tempA[0]);
                    gridView1.SetRowCellValue(i, "ColFieldName", tempA[1]);
                    gridView1.SetRowCellValue(i, "QType", tempA[2]);
                }
            }
            else
            {
                //初始化前5行数据
                for (int i = 0; i < 5; i++)//初始化5行
                {
                    if (gridView1.RowCount <= i || dtParentQueryFiled.Rows.Count <= i)//溢出，异常退出循环
                    {
                        break;
                    }
                    gridView1.SetRowCellValue(i, "ColFieldName", dtParentQueryFiled.Rows[i]["FieldName"].ToString());
                    gridView1.SetRowCellValue(i, "QType", "=");
                }
            }
        }

        /// <summary>
        /// 获得查询字段数据源表
        /// </summary>
        /// <returns></returns>
        private DataTable GetParentQueryFiled()
        {
            DataTable dtSource = new DataTable();            
            dtSource.Columns.Add(new DataColumn("FieldName", typeof(string)));
            dtSource.Columns.Add(new DataColumn("Caption", typeof(string)));
            //dtSource.Columns.Add(new DataColumn("dbtype", typeof(Type)));
            bool findFlag;
            for (int vi = 0; vi < _HTParentDataList.Columns.Count; vi++)
            {
                findFlag = false;
                for (int i = 0; i < _HTParentDataList.Columns.Count; i++)//遍历所有列
                {
                    if (_HTParentDataList.Columns[i].VisibleIndex == vi && _HTParentDataList.Columns[i].FieldName != string.Empty)//找到了 根据页面布局列绑定
                    {
                        DataRow dr = dtSource.NewRow();
                        dr["Fieldname"] = _HTParentDataList.Columns[i].FieldName;
                        dr["Caption"] = _HTParentDataList.Columns[i].Caption;
                        dtSource.Rows.Add(dr);
                        findFlag = true;
                        break;
                    }
                }
                if (!findFlag)//没有找到列，结束
                {
                    break;
                }
            }
           
            return dtSource;
        }

        /// <summary>
        /// 获得Grid数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetGridSource()
        {
            DataTable dtSource = new DataTable();
            dtSource.Columns.Add(new DataColumn("ConType", typeof(string)));//连接方式
            dtSource.Columns.Add(new DataColumn("ColFieldName", typeof(string)));
            //dtSource.Columns.Add(new DataColumn("ColName", typeof(string)));
            dtSource.Columns.Add(new DataColumn("QType", typeof(string)));
            dtSource.Columns.Add(new DataColumn("QV1", typeof(string)));
            dtSource.Columns.Add(new DataColumn("QV2", typeof(string)));

            for (int i = 0; i < 18; i++)
            {
                dtSource.Rows.Add(dtSource.NewRow());
            }
            foreach (DataRow dr in dtSource.Rows)
            {
                dr["ConType"] = "与";
            }
            
            return dtSource;
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        /// <param name="p_Dt"></param>
        private void BindGrid(DataTable p_Dt )
        {
            gridView1.GridControl.DataSource = p_Dt;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// 设置列编辑控件
        /// </summary>
        private void SetColumsEdit()
        {
            string cFieldName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColFieldName"));
            DevExpress.XtraEditors.Repository.RepositoryItem editItem = txtItemQV;
            if (cFieldName != string.Empty)//
            {
                if (_HTParentDataList.Columns[cFieldName].ColumnType == typeof(DateTime))
                {
                    editItem = txtItemDateQV;
                }
            }
            gridView1.Columns["QV1"].ColumnEdit = editItem;
            gridView1.Columns["QV2"].ColumnEdit = editItem;
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
                this.BaseFocusLabel.Focus();
                GetCondition();
                _HTExcuteQueryEventFlag = true;
                this.Close();
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
            this.ToolBarItemAdd(22, ToolButtonName.btnQuery.ToString(), "筛选", false, btnQuery_Click, eShortcut.F5);
            this.ToolBarItemAdd(7, ToolButtonName.btnClose.ToString(), "退出", true, btnClose_Click); 
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
        private void frmAPBaseCondition_Load(object sender, EventArgs e)
        {
            try
            {
                IniData();

                ToolIniCreateBar2();//加载靠右控件

                this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
                gridViewBindEventA1(gridView1);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        ///通用 重新设置实体1，如果不要使用，则重写，一般不要修改
        /// </summary>
        public virtual void gridViewRowChanged1(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                SetColumsEdit();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 其它事件
        /// <summary>
        /// 选择查询列离开
        /// </summary>
        private void drpColFieldName_Leave(object sender, EventArgs e)
        {
            try
            {
                BaseFocusLabel.Focus();
                SetColumsEdit();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

       
    }
}