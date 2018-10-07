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
    /// 功能：录入码单 磁贴第一列
    /// 用于绘画时的第一列文字显示，便于后续修改
    /// 作者：陈加海
    /// 日期：2014-3-31
    /// </summary>
    public partial class UCFabITileFirstColumn : UCFabBase
    {
        public UCFabITileFirstColumn()
        {
            InitializeComponent();
        }


        #region 属性
        /// <summary>
        /// 行号
        /// </summary>
        private int m_UCRowIndex = 1;
        /// <summary>
        /// 行号
        /// </summary>
        public int UCRowIndex
        {
            get
            {
                return m_UCRowIndex;
            }
            set
            {
                m_UCRowIndex = value;
            }
        }
        #endregion

        private void UCFabITileFirstColumn_Load(object sender, EventArgs e)
        {
            try
            {
                lblRowIndex.Text = UCRowIndex.ToString();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}
