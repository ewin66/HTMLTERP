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
    /// 功能：加载面料码单 码单  基类用户控件
    /// 作者：陈加海
    /// 日期：2014-3-29
    /// </summary>
    public partial class UCFabBaseLoadCtl : UCFabBase
    {
        public UCFabBaseLoadCtl()
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

        /// <summary>
        /// 当前聚焦行号
        /// </summary>
        private int m_UCCurrnetFocusIndex = -1;
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
        /// 全选
        /// </summary>
        public virtual void UCSelectAll()
        {            
        }

        /// <summary>
        /// 反选
        /// </summary>
        public virtual void UCSelectFan()
        {            
        }


        /// <summary>
        /// 开匹方法
        /// </summary>
        public virtual void UCKP(string p_ISN)
        {
            //this.ShowInfoMessage(p_ISN);
            if (UCEventKPClick != null)
            {
                UCEventKPClick(p_ISN);
            }
        }



        /// <summary>
        /// 取消一个选项，外部调用
        /// </summary>
        /// <param name="p_ISN"></param>
        public virtual void UCCancelOne(string p_ISN)
        {
        }

        /// <summary>
        /// 设置当前聚焦行号
        /// </summary>
        public virtual void UCSetCurrectIndex()
        {
        }

        #endregion
        #endregion


      


    }
}
