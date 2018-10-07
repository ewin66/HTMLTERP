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
    /// 功能：加载码单 简洁第一列
    /// 用于绘画时的第一列文字显示，便于后续修改
    /// 作者：陈加海
    /// 日期：2014-5-10
    /// </summary>
    public partial class UCFabLTileSimpleFirstColumn : UCFabBase
    {
        public UCFabLTileSimpleFirstColumn()
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

        private void UCFabLTileSimpleFirstColumn_Load(object sender, EventArgs e)
        {
            try
            {
                //lblColIndex.Text = UCColIndex.ToString();
                lblInfo1.Text = UCRowIndex.ToString();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}
