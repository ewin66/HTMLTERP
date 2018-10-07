using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.FrameFunc;
using HttSoft.Framework;


namespace MLTERP
{
    /// <summary>
    /// ��������
    /// </summary>
    public partial class InputForm : BaseForm
    {
        public InputForm()
        {
            InitializeComponent();
        }

        
        public string ZContext = string.Empty;//ˢ�����������
        public string ZInputInfo = string.Empty;//ˢ���������ʾ��Ϣ
        public string ZTitle = string.Empty;//�������
        public DialogResult ZResult = DialogResult.No;//���巵�ؽ��
        public Type ZInputType = typeof(string);
        public bool ZCheckValue = false;
        public decimal ZMaxValue = 0;
        public decimal ZMinValue = 0;

        public bool CheckCorrect()
        {
            if (txtInput.Text == string.Empty)
            {
                this.ShowMessage("����������");
                return false;
            }
            if (ZInputType == typeof(decimal))
            {
                if (!SysConvert.IsDecimal(txtInput.Text.Trim()))
                {
                    this.ShowMessage("��������ȷ������ С��");
                    return false;
                }
            }
            if (ZInputType == typeof(int))
            {
                if (!SysConvert.IsInt32(txtInput.Text.Trim()))
                {
                    this.ShowMessage("��������ȷ������ ����");
                    return false;
                }
            }
            if (ZCheckValue)//У����ֵ��Χ
            {
                if (SysConvert.ToDecimal(txtInput.Text.Trim()) > ZMaxValue || SysConvert.ToDecimal(txtInput.Text.Trim()) < ZMinValue)
                {
                    this.ShowMessage("��������ȷ������ ��Χ��"+ZMinValue.ToString()+"  ---  "+ZMaxValue.ToString());
                    return false;
                }
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCorrect())//��֤��ͨ��
                {
                    return;
                }
                ZContext = txtInput.Text.Trim();
                ZResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (ZInputInfo != string.Empty)
                {
                    this.lblAlertInfo.Text = ZInputInfo;
                }
                if (this.ZTitle != string.Empty)
                {
                    this.Text = ZTitle;
                }
                txtInput.Focus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void InputForm_Activated(object sender, EventArgs e)
        {
            try
            {
                txtInput.Focus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }	
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//����������
                {
                    btnOK_Click(sender, e);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}