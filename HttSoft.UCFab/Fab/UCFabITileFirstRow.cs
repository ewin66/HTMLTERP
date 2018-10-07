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
    /// ���ܣ�¼���뵥 ������һ��
    /// ���ڻ滭ʱ�ĵ�һ��������ʾ�����ں����޸�
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-31
    /// </summary>
    public partial class UCFabITileFirstRow : UCFabBase
    {
        public UCFabITileFirstRow()
        {
            InitializeComponent();
        }


        #region ����
        /// <summary>
        /// �к�
        /// </summary>
        private int m_UCColIndex = 1;
        /// <summary>
        /// �к�
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

        private void UCFabITileFirstRow_Load(object sender, EventArgs e)
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
