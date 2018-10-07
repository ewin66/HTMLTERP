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
    /// ���ܣ��뵥�鿴  �����û��ؼ�
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-29
    /// </summary>
    public partial class UCFabBaseViewCtl : UCFabBase
    {
        public UCFabBaseViewCtl()
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
        /// ����ת��ģʽ
        /// </summary>
        private bool m_UCQtyConvertMode = false;
        /// <summary>
        /// ����ת��ģʽ
        /// </summary>
        public bool UCQtyConvertMode
        {
            get
            {
                return m_UCQtyConvertMode;
            }
            set
            {
                m_UCQtyConvertMode = value;
            }
        }

        /// <summary>
        /// ����ת��ģʽ:ת��Ŀ�굥λ
        /// </summary>
        private string m_UCQtyConvertModeInputUnit = string.Empty;
        /// <summary>
        /// ����ת��ģʽ:ת��Ŀ�굥λ
        /// </summary>
        public string UCQtyConvertModeInputUnit
        {
            get
            {
                return m_UCQtyConvertModeInputUnit;
            }
            set
            {
                m_UCQtyConvertModeInputUnit = value;
            }
        }

        /// <summary>
        /// ����ת��ģʽ:ת��Ŀ�굥λ
        /// </summary>
        private decimal m_UCQtyConvertModeInputConvertXS = 0;
        /// <summary>
        /// ����ת��ģʽ:ת��Ŀ��ϵ��
        /// </summary>
        public decimal UCQtyConvertModeInputConvertXS
        {
            get
            {
                return m_UCQtyConvertModeInputConvertXS;
            }
            set
            {
                m_UCQtyConvertModeInputConvertXS = value;
            }
        }


        /// <summary>
        /// ���������ر�־
        /// </summary>
        private bool m_UCColumnISNHide = false;
        /// <summary>
        /// ���������ر�־
        /// ���������¼����뵥��ϸ����ʾ����
        /// </summary>
        public bool UCColumnISNHide
        {
            get
            {
                return m_UCColumnISNHide;
            }
            set
            {
                m_UCColumnISNHide = value;
            }
        }

        /// <summary>
        /// �����������Ƿ�����
        /// </summary>
        private bool m_UCColumnYard = false;
        /// <summary>
        /// �����������Ƿ�����
        /// </summary>
        public bool UCColumnYard
        {
            get
            {
                return m_UCColumnYard;
            }
            set
            {
                m_UCColumnYard = value;
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
    }
}
