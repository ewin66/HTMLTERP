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
    /// ��׼���ȿؼ�����Ԫ�ؼ� ����
    /// �¼Ӻ�
    /// 2014.5.24
    /// </summary>
    public partial class UCStatusBarStandItemBase : UCFabBase
    {
        public UCStatusBarStandItemBase()
        {
            InitializeComponent();
        }


        #region ����
        /// <summary>
        /// ���
        /// </summary>
        private int m_UCContextWidth = 0;
        /// <summary>
        /// ���
        /// </summary>
        public int UCContextWidth
        {
            get
            {
                return m_UCContextWidth;
            }
            set
            {
                m_UCContextWidth = value;               
                UCSetContextWidth(value);
            }
        }


        /// <summary>
        /// �߶�
        /// </summary>
        private int m_UCContextHeight = 0;
        /// <summary>
        /// �߶�
        /// </summary>
        public int UCContextHeight
        {
            get
            {
                return m_UCContextHeight;
            }
            set
            {
                m_UCContextHeight = value;

                UCSetContextHeight(value);
            }
        }


        /// <summary>
        /// ����ɫ
        /// </summary>
        private Color m_UCBackColor = Color.White;
        /// <summary>
        /// ����ɫ
        /// </summary>
        public Color UCBackColor
        {
            get
            {
                return m_UCBackColor;
            }
            set
            {
                m_UCBackColor = value;
                UCSetBackColor(value);
            }
        }



        /// <summary>
        /// �߿���ɫ
        /// </summary>
        private Color m_UCBorderColor = Color.Blue;
        /// <summary>
        /// �߿���ɫ
        /// </summary>
        public Color UCBorderColor
        {
            get
            {
                return m_UCBorderColor;
            }
            set
            {
                m_UCBorderColor = value;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        private string m_UCContext = "";
        /// <summary>
        /// ����
        /// </summary>
        public string UCContext
        {
            get
            {
                return m_UCContext;
            }
            set
            {
                m_UCContext = value;
                UCSetContext(value);
            }
        }
        #endregion 


        #region �鷽������д����
        /// <summary>
        /// �������ݿ��
        /// </summary>
        /// <param name="p_Value"></param>
        public virtual void UCSetContextWidth(int p_Value)
        {
        }


        /// <summary>
        /// �������ݸ߶�
        /// </summary>
        /// <param name="p_Value"></param>
        public virtual void UCSetContextHeight(int p_Value)
        {
        }

        /// <summary>
        /// ���ñ���ɫ
        /// </summary>
        /// <param name="p_Value"></param>
        public virtual void UCSetBackColor(Color p_Value)
        {
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="p_Value"></param>
        public virtual void UCSetContext(string p_Value)
        {
        }
        #endregion
    }
}
