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
    /// 功能：已选码单  基类用户控件
    /// 作者：陈加海
    /// 日期：2014-3-29
    /// </summary>
    public partial class UCFabBaseSelectCtl : UCFabBase
    {
        public UCFabBaseSelectCtl()
        {
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// 列数量;磁贴形式用到
        /// </summary>
        private int m_UCColumnCount = 4;
        /// <summary>
        /// 列数量;磁贴形式用到
        /// </summary>
        public int UCColumnCount
        {
            get
            {
                return m_UCColumnCount;
            }
            set
            {
                m_UCColumnCount = value;
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
            }
            get
            {
                return m_UCDataSource;
            }
        }
        #endregion


        #region 全局事件
        public UCFabSelectCancel UCFabSelect_CancelOne;
        #endregion

        #region 虚方法
        #region 外部调用方法


        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public virtual void UCAct()
        {
        }


        /// <summary>
        /// 取消一行
        /// </summary>
        public virtual void UCCancelOne(string p_ISN)
        {
            UCFabSelect_CancelOne(p_ISN);
        }
       
        #endregion
        #endregion
    }
}
