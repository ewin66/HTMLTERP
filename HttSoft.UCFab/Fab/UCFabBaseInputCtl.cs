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
    /// 功能：录入码单控件  基类用户控件
    /// 作者：陈加海
    /// 日期：2014-3-29
    /// </summary>
    public partial class UCFabBaseInputCtl : UCFabBase
    {
        public UCFabBaseInputCtl()
        {
            InitializeComponent();
        }


        #region 属性
        /// <summary>
        /// 列数量;磁贴形式用到
        /// </summary>
        private int m_UCColumnCount = 5;
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
        /// 卷号是否显示标志；横向模式用到
        /// </summary>
        private bool m_UCVolumeNumberShowFlag = true;
        /// <summary>
        /// 卷号是否显示标志；横向模式用到
        /// </summary>
        public bool UCVolumeNumberShowFlag
        {
            get
            {
                return m_UCVolumeNumberShowFlag;
            }
            set
            {
                m_UCVolumeNumberShowFlag = value;
            }
        }


        /// <summary>
        /// 录入格子数量
        /// </summary>
        private int m_UCInputCount = 10;
        /// <summary>
        /// 录入格子数量
        /// </summary>
        public int UCInputCount
        {
            get
            {
                return m_UCInputCount;
            }
            set
            {
                m_UCInputCount = value;
            }
        }


        /// <summary>
        /// 当前聚焦行号
        /// </summary>
        private int m_UCCurrnetFocusIndex = 0;
        /// <summary>
        /// 当前聚焦行号
        /// </summary>
        public int UCCurrnetFocusIndex
        {
            get
            {
                UCSetCurrectIndex();//设置当前行号
                return m_UCCurrnetFocusIndex;
            }
            set
            {
                m_UCCurrnetFocusIndex = value;
            }
        }


        /// <summary>
        /// 数据源
        /// </summary>
        DataTable m_UCDataSource = new DataTable();
        /// <summary>
        /// 数据源
        /// 数据源，列0/1/2/3/4/5:选择标志/BoxNo/卷号/米数/公斤数/缸号
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
        #region 外部调用方法


        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public virtual void UCAct()
        {
        }

        /// <summary>
        /// 执行重新赋值，用在批量录入时
        /// </summary>
        public virtual void UCBind()
        {
        }

        /// <summary>
        /// 设置当前聚焦行号
        /// </summary>
        public virtual void UCSetCurrectIndex()
        {
        }

        /// <summary>
        /// 录入格子数量改变
        /// </summary>
        public virtual void UCInputCountChanged()
        {
            UCFabCommon.RemoveInputBankRow(UCDataSource);//清除录入数据源中空行

            UCAct();//执行重绘
        }


        /// <summary>
        /// 删除一个选项，外部调用
        /// </summary>
        /// <param name="p_ISN"></param>
        public virtual void UCDeleteOne(string p_ISN)
        {
        }
        #endregion
        #endregion
    }
}
