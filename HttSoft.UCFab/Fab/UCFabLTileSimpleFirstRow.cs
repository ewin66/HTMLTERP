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
    /// 功能：加载码单 简洁第一行
    /// 用于绘画时的第一行文字显示，便于后续修改
    /// 作者：陈加海
    /// 日期：2014-5-10
    /// </summary>
    public partial class UCFabLTileSimpleFirstRow : UCFabBase
    {
        public UCFabLTileSimpleFirstRow()
        {
            InitializeComponent();
        }



        #region 属性
        /// <summary>
        /// 列号
        /// </summary>
        private int m_UCColIndex = 1;
        /// <summary>
        /// 列号
        /// </summary>
        public int UCColIndex
        {
            get
            {
                return m_UCColIndex;
            }
            set
            {
                m_UCColIndex = value;
            }
        }
        #endregion
        private void UCFabLTileSimpleFirstRow_Load(object sender, EventArgs e)
        {
            try
            {
                lblColIndex.Text = UCColIndex.ToString();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}
