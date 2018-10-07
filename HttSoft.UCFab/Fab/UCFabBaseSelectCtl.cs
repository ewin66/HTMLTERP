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
    /// ���ܣ���ѡ�뵥  �����û��ؼ�
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-29
    /// </summary>
    public partial class UCFabBaseSelectCtl : UCFabBase
    {
        public UCFabBaseSelectCtl()
        {
            InitializeComponent();
        }

        #region ����
        /// <summary>
        /// ������;������ʽ�õ�
        /// </summary>
        private int m_UCColumnCount = 4;
        /// <summary>
        /// ������;������ʽ�õ�
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


        #region ȫ���¼�
        public UCFabSelectCancel UCFabSelect_CancelOne;
        #endregion

        #region �鷽��
        #region �ⲿ���÷���


        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public virtual void UCAct()
        {
        }


        /// <summary>
        /// ȡ��һ��
        /// </summary>
        public virtual void UCCancelOne(string p_ISN)
        {
            UCFabSelect_CancelOne(p_ISN);
        }
       
        #endregion
        #endregion
    }
}
