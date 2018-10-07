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
    /// 标准进度控件进度元控件 基类
    /// 陈加海
    /// 2014.5.24
    /// </summary>
    public partial class UCStatusBarStandItemBase : UCFabBase
    {
        public UCStatusBarStandItemBase()
        {
            InitializeComponent();
        }


        #region 属性
        /// <summary>
        /// 宽度
        /// </summary>
        private int m_UCContextWidth = 0;
        /// <summary>
        /// 宽度
        /// </summary>
        public int UCContextWidth
        {
            get
            {
                return m_UCContextWidth;
            }
            set
            {
                m_UCContextWidth = value;               
                UCSetContextWidth(value);
            }
        }


        /// <summary>
        /// 高度
        /// </summary>
        private int m_UCContextHeight = 0;
        /// <summary>
        /// 高度
        /// </summary>
        public int UCContextHeight
        {
            get
            {
                return m_UCContextHeight;
            }
            set
            {
                m_UCContextHeight = value;

                UCSetContextHeight(value);
            }
        }


        /// <summary>
        /// 背景色
        /// </summary>
        private Color m_UCBackColor = Color.White;
        /// <summary>
        /// 背景色
        /// </summary>
        public Color UCBackColor
        {
            get
            {
                return m_UCBackColor;
            }
            set
            {
                m_UCBackColor = value;
                UCSetBackColor(value);
            }
        }



        /// <summary>
        /// 边框颜色
        /// </summary>
        private Color m_UCBorderColor = Color.Blue;
        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color UCBorderColor
        {
            get
            {
                return m_UCBorderColor;
            }
            set
            {
                m_UCBorderColor = value;
            }
        }

        /// <summary>
        /// 内容
        /// </summary>
        private string m_UCContext = "";
        /// <summary>
        /// 内容
        /// </summary>
        public string UCContext
        {
            get
            {
                return m_UCContext;
            }
            set
            {
                m_UCContext = value;
                UCSetContext(value);
            }
        }
        #endregion 


        #region 虚方法，重写方法
        /// <summary>
        /// 设置内容宽度
        /// </summary>
        /// <param name="p_Value"></param>
        public virtual void UCSetContextWidth(int p_Value)
        {
        }


        /// <summary>
        /// 设置内容高度
        /// </summary>
        /// <param name="p_Value"></param>
        public virtual void UCSetContextHeight(int p_Value)
        {
        }

        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <param name="p_Value"></param>
        public virtual void UCSetBackColor(Color p_Value)
        {
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="p_Value"></param>
        public virtual void UCSetContext(string p_Value)
        {
        }
        #endregion
    }
}
