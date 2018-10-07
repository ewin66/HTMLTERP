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
    /// ���ܣ�¼���뵥�ؼ�  �����û��ؼ�
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-29
    /// </summary>
    public partial class UCFabBaseInputCtl : UCFabBase
    {
        public UCFabBaseInputCtl()
        {
            InitializeComponent();
        }


        #region ����
        /// <summary>
        /// ������;������ʽ�õ�
        /// </summary>
        private int m_UCColumnCount = 5;
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
        /// ����Ƿ���ʾ��־������ģʽ�õ�
        /// </summary>
        private bool m_UCVolumeNumberShowFlag = true;
        /// <summary>
        /// ����Ƿ���ʾ��־������ģʽ�õ�
        /// </summary>
        public bool UCVolumeNumberShowFlag
        {
            get
            {
                return m_UCVolumeNumberShowFlag;
            }
            set
            {
                m_UCVolumeNumberShowFlag = value;
            }
        }


        /// <summary>
        /// ¼���������
        /// </summary>
        private int m_UCInputCount = 10;
        /// <summary>
        /// ¼���������
        /// </summary>
        public int UCInputCount
        {
            get
            {
                return m_UCInputCount;
            }
            set
            {
                m_UCInputCount = value;
            }
        }


        /// <summary>
        /// ��ǰ�۽��к�
        /// </summary>
        private int m_UCCurrnetFocusIndex = 0;
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


        /// <summary>
        /// ����Դ
        /// </summary>
        DataTable m_UCDataSource = new DataTable();
        /// <summary>
        /// ����Դ
        /// ����Դ����0/1/2/3/4/5:ѡ���־/BoxNo/���/����/������/�׺�
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
        #region �ⲿ���÷���


        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public virtual void UCAct()
        {
        }

        /// <summary>
        /// ִ�����¸�ֵ����������¼��ʱ
        /// </summary>
        public virtual void UCBind()
        {
        }

        /// <summary>
        /// ���õ�ǰ�۽��к�
        /// </summary>
        public virtual void UCSetCurrectIndex()
        {
        }

        /// <summary>
        /// ¼����������ı�
        /// </summary>
        public virtual void UCInputCountChanged()
        {
            UCFabCommon.RemoveInputBankRow(UCDataSource);//���¼������Դ�п���

            UCAct();//ִ���ػ�
        }


        /// <summary>
        /// ɾ��һ��ѡ��ⲿ����
        /// </summary>
        /// <param name="p_ISN"></param>
        public virtual void UCDeleteOne(string p_ISN)
        {
        }
        #endregion
        #endregion
    }
}
