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
    /// 标准进度控件进度元控件
    /// 陈加海
    /// 2014.4.18
    /// </summary>
    public partial class UCStatusBarStandOne : UCStatusBarStandItemBase
    {
        public UCStatusBarStandOne()
        {
            InitializeComponent();
        }

        

        #region 虚方法，重写方法
        /// <summary>
        /// 设置内容宽度
        /// </summary>
        /// <param name="p_Value"></param>
        public override void UCSetContextWidth(int p_Value)
        {
            if (p_Value != 0)
            {
                this.Width = p_Value;
            }
            else
            {
                this.Width = 60;
            }
        }


        /// <summary>
        /// 设置内容高度
        /// </summary>
        /// <param name="p_Value"></param>
        public override void UCSetContextHeight(int p_Value)
        {
            if (p_Value != 0)
            {
                this.Height = p_Value;
            }
            else
            {
                this.Height = 16;
            }
        }

        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <param name="p_Value"></param>
        public override void UCSetBackColor(Color p_Value)
        {
            txtColorSOStatus1.BackColor = p_Value;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="p_Value"></param>
        public override void UCSetContext(string p_Value)
        {
            txtColorSOStatus1.Text = p_Value;
        }
        #endregion
    }
}
