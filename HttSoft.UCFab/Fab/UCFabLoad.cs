using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;

namespace HttSoft.UCFab
{
    /// <summary>
    /// 功能：加载面料调用控件  总控件
    /// 作者：陈加海
    /// 日期：2014-3-28
    /// </summary>
    public partial class UCFabLoad : UCFabBase
    {
        public UCFabLoad()
        {
            InitializeComponent();
        }

        #region 全局变量
        /// <summary>
        /// 开匹点击事件
        /// </summary>
        public UCFabSelectCancel UCEventKPClick;
        #endregion


        #region 属性
        /// <summary>
        /// 允许开匹标志
        /// </summary>
        private bool m_UCAllowKPFlag = false;
        /// <summary>
        /// 允许开匹标志
        /// </summary>
        public bool UCAllowKPFlag
        {
            get
            {
                return m_UCAllowKPFlag;
            }
            set
            {
                m_UCAllowKPFlag = value;
            }
        }


        /// <summary>
        /// 数据源
        /// </summary>
        DataTable m_UCDataSource = new DataTable();
        /// <summary>
        /// 数据源
        /// 数据源，列0/1/2/3/4:选择标志/BoxNo/卷号/数量/缸号
        /// </summary>
        public DataTable UCDataSource
        {
            set
            {
                m_UCDataSource = value;
                m_UCDataSource.ColumnChanged += new DataColumnChangeEventHandler(UCDataSourceOnColumnChanged);
            }
        }

        /// <summary>
        /// 数据源列值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void UCDataSourceOnColumnChanged(Object sender, DataColumnChangeEventArgs args)
        {
            if (args.Column.ColumnName == "SelectFlag")//选择列值改变的情况下绑定选择项
            {
                UCFabBaseSelectCtl ucfbsc = UCFindSelectCtl();
                if (ucfbsc != null)
                {
                    m_UCDataSource.AcceptChanges();
                    DataTable dt = UCSelectDataSource;//实际是重新执行已选数据
                    if (radgViewType.SelectedIndex == 0)
                    {
                        ucfbsc.UCAct();//后续如果选择项是多模式的情况下将重新处理调用
                    }
                }
            }
        }


        /// <summary>
        /// 选择的数据源
        /// </summary>
        DataTable m_UCSelecDataSource;
        /// <summary>
        /// 获取选择的数据源
        /// </summary>
        public DataTable UCSelectDataSource
        {
            get
            {
                if (m_UCSelecDataSource == null)
                {
                    m_UCSelecDataSource = m_UCDataSource.Clone();
                }
                else
                {
                    m_UCSelecDataSource.Rows.Clear();
                }

                DataRow[] drA = m_UCDataSource.Select("SelectFlag=1");//寻找选择的代码
                for (int i = 0; i < drA.Length; i++)
                {
                    DataRow outdr = m_UCSelecDataSource.NewRow();
                    for (int j = 0; j < m_UCSelecDataSource.Columns.Count; j++)//循环复制
                    {
                        outdr[j] = drA[i][j];
                    }
                    m_UCSelecDataSource.Rows.Add(outdr);
                }
                return m_UCSelecDataSource;
            }
        }


        bool m_UCActFlag = false;//是否执行过标志，未执行的改变值不执行

        #endregion


        #region 外部调用方法
        ///// <summary>
        ///// 初始化数据源结构
        ///// </summary>
        //public void IniDataSourceStruct()
        //{
        //    m_UCDataSource.Columns.Add(new DataColumn("SelectFlag", typeof(int)));//选择
        //    m_UCDataSource.Columns.Add(new DataColumn("BoxNo", typeof(string)));//条码
        //    m_UCDataSource.Columns.Add(new DataColumn("SubSeq", typeof(string)));//卷号
        //    m_UCDataSource.Columns.Add(new DataColumn("Qty", typeof(decimal)));//数量
        //    m_UCDataSource.Columns.Add(new DataColumn("JarNum", typeof(string)));//缸号
        //    m_UCDataSource.Columns.Add(new DataColumn("ItemModel", typeof(string)));//品名
        //}



        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public void UCAct()
        {
            UCActLoad();
            UCActSelect();

            m_UCActFlag = true;
        }



        /// <summary>
        /// 执行开匹后重新绘画
        /// </summary>
        public void UCActKP(DataTable dtNew)
        {
            DataTable dtOld = m_UCDataSource.Copy();

            foreach (DataRow drNew in dtNew.Rows)
            {
                drNew["SelectFlag"] = 0;
            }

            string isnSelect = string.Empty;
            DataRow[] drOldA = dtOld.Select("SelectFlag=1");
            for (int i = 0; i < drOldA.Length; i++)
            {
                if (isnSelect != string.Empty)
                {
                    isnSelect += ",";
                }
                isnSelect += SysString.ToDBString(drOldA[i]["BoxNo"].ToString());
            }
            if (isnSelect != string.Empty)//如果有已选
            {
                DataRow[] drA = dtNew.Select("BoxNo IN(" + isnSelect + ")");
                for (int i = 0; i < drA.Length; i++)//遍历选择项，改变标志
                {
                    drA[i]["SelectFlag"] = 1;
                }
            }

            UCDataSource = dtNew;
            UCAct();
        }


       
        #endregion

        #region 内部方法
        /// <summary>
        /// 加载控件
        /// </summary>
        void UCActLoad()
        {
            int colCount = UCFabParamSet.GetIntValueByID(6012);//码单选择磁贴模式每行磁贴数
            if (colCount <= 0)
            {
                colCount = 5;
            }
            if (radgOPType.SelectedIndex == 2)//简洁模式
            {
                colCount = UCFabParamSet.GetIntValueByID(6013);//码单选择简洁模式每行磁贴数
                if (colCount <= 0)
                {
                    colCount = 10;
                }
            }
            
            
            //加载展示控件BEGIN
            RemoveUserCtl(panGroupTopRight);
            //panGroupTopRight.Controls.Clear();
            UCFabBaseLoadCtl ucflbc = CreateFabLoadControl();
            ucflbc.UCDataSource = m_UCDataSource;
            ucflbc.UCColumnCount = colCount;
            ucflbc.UCAllowKPFlag = UCAllowKPFlag;
            if (UCAllowKPFlag)
            {
                ucflbc.UCEventKPClick += new UCFabSelectCancel(UCEventKPClick);
            }
            ucflbc.Dock = DockStyle.Fill;
            panGroupTopRight.Controls.Add(ucflbc);

            ucflbc.UCAct();
            //加载展示控件END
        }

        

        /// <summary>
        /// 已选控件
        /// </summary>
        void UCActSelect()
        {
            int colCount = UCFabParamSet.GetIntValueByID(6002);//码单显示横向模式列数
            if (colCount <= 0)
            {
                colCount = 10;
            }
            //加载结果展示控件BEGIN
            panGroupTopLeft.Controls.Clear();
            UCFabBaseSelectCtl ucfbsc = CreateFabSelectControl();
            ucfbsc.UCDataSource = UCSelectDataSource;
            ucfbsc.UCColumnCount = colCount;// 10;
            ucfbsc.UCFabSelect_CancelOne += new UCFabSelectCancel(ucSelect_CancelOne);
            ucfbsc.Dock = DockStyle.Fill;
            panGroupTopLeft.Controls.Add(ucfbsc);
            ucfbsc.UCAct();
            //加载结果展示控件END
        }

        /// <summary>
        /// 取消一个已勾选码单
        /// </summary>
        /// <param name="p_ISN"></param>
        private void ucSelect_CancelOne(string p_ISN)
        {
            UCFabBaseLoadCtl uc = UCFindLoadCtl();
            if (uc != null)
            {
                uc.UCCancelOne(p_ISN);
            }
        }

        /// <summary>
        /// 寻找加载用户控件
        /// </summary>
        /// <returns></returns>
        UCFabBaseLoadCtl UCFindLoadCtl()
        {
            foreach (Control ctl in panGroupTopRight.Controls)
            {
                if (ctl is UCFabBaseLoadCtl)
                {
                    return (UCFabBaseLoadCtl)ctl;
                }
            }
            return null;
        }


        /// <summary>
        /// 寻找加载已选显示控件
        /// </summary>
        /// <returns></returns>
        UCFabBaseSelectCtl UCFindSelectCtl()
        {
            foreach (Control ctl in panGroupTopLeft.Controls)
            {
                if (ctl is UCFabBaseSelectCtl)
                {
                    return (UCFabBaseSelectCtl)ctl;
                }
            }
            return null;
        }

        /// <summary>
        /// 创建加载检索控件
        /// </summary>
        UCFabBaseLoadCtl CreateFabLoadControl()
        {
            UCFabBaseLoadCtl ucfbc;
            switch (radgOPType.SelectedIndex)
            {
                case 0:
                    ucfbc = new UCFabLTileGroup();
                    break;
                case 1:
                    ucfbc = new UCFabLGridView();
                    break;
                case 2:
                    ucfbc = new UCFabLTileSimpleGroup();
                    break;
                default:
                    goto case 0;
            }
            ucfbc.Name = "ucfblc";
            return ucfbc;
        }


        /// <summary>
        /// 创建选择结果控件
        /// </summary>
        UCFabBaseSelectCtl CreateFabSelectControl()
        {
            UCFabBaseSelectCtl ucfbsc;
            switch (radgViewType.SelectedIndex)
            {
                case 0:
                    ucfbsc = new UCFabSVHori();
                    break;               
                case 1:
                    ucfbsc = new UCFabSGridView();
                    break;               
                default:
                    goto case 0;
            }
            ucfbsc.Name = "ucfbsc";
            return ucfbsc;
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                UCFabBaseLoadCtl uc = UCFindLoadCtl();
                if (uc != null)
                {
                    uc.UCSelectAll();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFan_Click(object sender, EventArgs e)
        {
            try
            {
                UCFabBaseLoadCtl uc = UCFindLoadCtl();
                if (uc != null)
                {
                    uc.UCSelectFan();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 控件加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabLoad_Load(object sender, EventArgs e)
        {
            try
            {
                int vmodelIndex = UCFabParamSet.GetIntValueByID(6001);//码单显示模式默认序号
                if (vmodelIndex > 0 && vmodelIndex < radgViewType.Properties.Items.Count)
                {
                    radgViewType.SelectedIndex = vmodelIndex;
                }

                int modelIndex = UCFabParamSet.GetIntValueByID(6011);//码单选择模式默认序号
                if (modelIndex > 0 && modelIndex < radgOPType.Properties.Items.Count)
                {
                    radgOPType.SelectedIndex = modelIndex;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 其它事件
        /// <summary>
        /// 加载模式改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radgOPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_UCActFlag)
                {
                    UCActLoad();
                    panGroupTopRight.Focus();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 显示模式改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radgViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_UCActFlag)
                {
                    UCActSelect();
                    panGroupTopLeft.Focus();
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
