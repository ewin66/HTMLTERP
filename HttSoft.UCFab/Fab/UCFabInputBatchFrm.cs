using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;

namespace HttSoft.UCFab
{
    /// <summary>
    /// ����¼�봰��
    /// </summary>
    public partial class UCFabInputBatchFrm : Form
    {
        public UCFabInputBatchFrm()
        {
            InitializeComponent();
        }


        #region ����
       


        /// <summary>
        /// ȷ��״̬
        /// </summary>
        private bool m_UCOKFlag = false;
        /// <summary>
        /// ȷ��״̬
        /// </summary>
        public bool UCOKFlag
        {
            get
            {
                return m_UCOKFlag;
            }
            set
            {
                m_UCOKFlag = value;
            }
        }


        /// <summary>
        /// ƥ��
        /// </summary>
        private int m_UCFabCount = 0;
        /// <summary>
        /// ����
        /// </summary>
        public int UCFabCount
        {
            get
            {
                return m_UCFabCount;
            }
            set
            {
                m_UCFabCount = value;
            }
        }

        /// <summary>
        /// ÿƥ����
        /// </summary>
        private decimal m_UCFabPerQty = 0m;
        /// <summary>
        /// ÿƥ����
        /// </summary>
        public decimal UCFabPerQty
        {
            get
            {
                return m_UCFabPerQty;
            }
            set
            {
                m_UCFabPerQty = value;
            }
        }
        #endregion

        #region ��������
        #region ��ʾ��Ϣ

        /// <summary>
        /// ��ʾ������ʾ��Ϣ
        /// </summary>
        /// <param name="p_Message">������Ϣ����</param>
        public void ShowMessage(string p_Message)
        {
            MessageBox.Show(p_Message, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// ��ʾ��ʾ��Ϣ
        /// </summary>
        /// <param name="p_Message">��ʾ��Ϣ����</param>
        public void ShowInfoMessage(string p_Message)
        {
            MessageBox.Show(p_Message, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ��ʾȷ����Ϣ
        /// </summary>
        /// <param name="p_Message">ѯ����Ϣ</param>
        /// <returns></returns>
        public DialogResult ShowConfirmMessage(string p_Message)
        {
            return MessageBox.Show(p_Message, "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion


        #endregion



        #region �Զ��巨����
        /// <summary>
        /// У�������Ƿ���ȷ
        /// </summary>
        /// <returns></returns>
        bool CheckCorrect()
        {
            if(SysConvert.ToInt32(txtFabCount.Text.Trim())<=0)
            {
                this.ShowMessage("������ƥ��");
                txtFabCount.Focus();
                return false;
            }

            if (SysConvert.ToDecimal(txtPerQty.Text.Trim()) <= 0)
            {
                this.ShowMessage("������ÿƥ����");
                txtPerQty.Focus();
                return false;
            }
            return true;
        }
        #endregion


        #region ��ť�¼�
        /// <summary>
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCorrect())
                {
                    return;
                }
                UCFabCount = SysConvert.ToInt32(txtFabCount.Text.Trim());
                UCFabPerQty = SysConvert.ToDecimal(txtPerQty.Text.Trim());
                UCOKFlag = true;
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                UCOKFlag = false;
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
}