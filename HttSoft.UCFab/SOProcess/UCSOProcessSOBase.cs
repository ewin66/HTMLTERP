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
    /// ���ܣ����� ������ʾ����
    /// ���ߣ�Standy
    /// ���ڣ�2015-5-15
    /// </summary>
    public partial class UCSOProcessSOBase : UCFabBase
    {
        public UCSOProcessSOBase()
        {
            InitializeComponent();
        }


        #region ����

        /// <summary>
        /// ����Դ
        /// </summary>
        DataTable m_UCDataSource = new DataTable();
        /// <summary>
        /// ����Դ
        /// ����Դ����0/1/2/3/4:ѡ���־/BoxNo/���/����/�׺�
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

        #region �鷽��

        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public virtual void UCAct()
        {
        }

        #endregion

        #region �ؼ�����
        /// <summary>
        /// �ؼ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSOProcessSOBase_Load(object sender, EventArgs e)
        {
            try
            {
                UCAct();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        #endregion
    }
}
