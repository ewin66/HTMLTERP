using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HttSoft.UCFab
{

    /// <summary>
    /// 功能：基类 订单显示基类
    /// 作者：Standy
    /// 日期：2015-5-15
    /// </summary>
    public partial class UCSOProcessSOBase : UCFabBase
    {
        public UCSOProcessSOBase()
        {
            InitializeComponent();
        }


        #region 属性

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
            }
            get
            {
                return m_UCDataSource;
            }
        }

        #endregion

        #region 虚方法

        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public virtual void UCAct()
        {
        }

        #endregion

        #region 控件加载
        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSOProcessSOBase_Load(object sender, EventArgs e)
        {
            try
            {
                UCAct();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        #endregion
    }
}
