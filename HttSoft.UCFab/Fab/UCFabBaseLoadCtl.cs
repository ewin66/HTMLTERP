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
    /// ���ܣ����������뵥 �뵥  �����û��ؼ�
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-29
    /// </summary>
    public partial class UCFabBaseLoadCtl : UCFabBase
    {
        public UCFabBaseLoadCtl()
        {
            InitializeComponent();
        }


        #region ȫ�ֱ���
        /// <summary>
        /// ��ƥ����¼�
        /// </summary>
        public UCFabSelectCancel UCEventKPClick;
        #endregion

        #region ����


        /// <summary>
        /// ����ƥ��־
        /// </summary>
        private bool m_UCAllowKPFlag = false;
        /// <summary>
        /// ����ƥ��־
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

        /// <summary>
        /// ��ǰ�۽��к�
        /// </summary>
        private int m_UCCurrnetFocusIndex = -1;
        /// <summary>
        /// ��ǰ�۽��к�
        /// </summary>
        public int UCCurrnetFocusIndex
        {
            get
            {
                UCSetCurrectIndex();//���õ�ǰ�к�
                return m_UCCurrnetFocusIndex;
            }
            set
            {
                m_UCCurrnetFocusIndex = value;
            }
        }


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
        /// ȫѡ
        /// </summary>
        public virtual void UCSelectAll()
        {            
        }

        /// <summary>
        /// ��ѡ
        /// </summary>
        public virtual void UCSelectFan()
        {            
        }


        /// <summary>
        /// ��ƥ����
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
        /// ȡ��һ��ѡ��ⲿ����
        /// </summary>
        /// <param name="p_ISN"></param>
        public virtual void UCCancelOne(string p_ISN)
        {
        }

        /// <summary>
        /// ���õ�ǰ�۽��к�
        /// </summary>
        public virtual void UCSetCurrectIndex()
        {
        }

        #endregion
        #endregion


      


    }
}
