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
    /// ���ܣ����� �������ȱ�
    /// ���ߣ�Standy
    /// ���ڣ�2015-5-15
    /// </summary>
    public partial class UCSOProcessOneBase : UCFabBase
    {
        public UCSOProcessOneBase()
        {
            InitializeComponent();
        }



        #region ����


        /// <summary>
        /// �������
        /// </summary>
        private int m_UCStepIndex = 0;
        /// <summary>
        /// �������
        /// </summary>
        public int UCStepIndex
        {
            get
            {
                return m_UCStepIndex;
            }
            set
            {
                m_UCStepIndex = value;
            }
        }



        /// <summary>
        /// ��ǰ�����Ƿ����������
        /// </summary>
        private bool m_UCStepIncludeFlag = false;
        /// <summary>
        /// ��ǰ�����Ƿ����������
        /// </summary>
        public bool UCStepIncludeFlag
        {
            get
            {
                return m_UCStepIncludeFlag;
            }
            set
            {
                m_UCStepIncludeFlag = value;
            }
        }



        /// <summary>
        /// վ��ID
        /// </summary>
        private int m_UCStepID = 0;
        /// <summary>
        /// վ��ID
        /// </summary>
        public int UCStepID
        {
            set
            {
                m_UCStepID = value;
            }
            get
            {
                return m_UCStepID;
            }
        }



        /// <summary>
        /// ������ֵ
        /// </summary>
        DataRow m_UCSettingDr;
        /// <summary>
        /// ������ֵ
        /// </summary>
        public DataRow UCSettingDr
        {
            set
            {
                m_UCSettingDr = value;
            }
            get
            {
                return m_UCSettingDr;
            }
        }


        /// <summary>
        /// ����Դ
        /// </summary>
        DataRow[] m_UCDataSource = new DataRow[] { };
        /// <summary>
        /// ����Դ
        /// ����Դ����0/1/2/3/4:ѡ���־/BoxNo/���/����/�׺�
        /// </summary>
        public DataRow[] UCDataSource
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


        /// <summary>
        /// ��ʼ��
        /// </summary>
        public virtual void UCIni()
        {
        }

        #endregion

        #region �ؼ�����
        /// <summary>
        /// �ؼ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSOProcessOneBase_Load(object sender, EventArgs e)
        {
            try
            {
                //UCAct();
                UCIni();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        #endregion
    }
}
