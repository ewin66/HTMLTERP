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
    public partial class UCFabITileFirstColumn : UCFabBase
    {
        public UCFabITileFirstColumn()
        {
            InitializeComponent();
        }


        #region ����
        /// <summary>
        /// �к�
        /// </summary>
        private int m_UCRowIndex = 1;
        /// <summary>
        /// �к�
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
