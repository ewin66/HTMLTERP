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
    /// 输入数据
    /// </summary>
    public partial class InputForm : BaseForm
    {
        public InputForm()
        {
            InitializeComponent();
        }

        
        public string ZContext = string.Empty;//刷入的条码内容
        public string ZInputInfo = string.Empty;//刷入的条码提示信息
        public string ZTitle = string.Empty;//窗体标题
        public DialogResult ZResult = DialogResult.No;//窗体返回结果
        public Type ZInputType = typeof(string);
        public bool ZCheckValue = false;
        public decimal ZMaxValue = 0;
        public decimal ZMinValue = 0;

        public bool CheckCorrect()
        {
            if (txtInput.Text == string.Empty)
            {
                this.ShowMessage("请输入内容");
                return false;
            }
            if (ZInputType == typeof(decimal))
            {
                if (!SysConvert.IsDecimal(txtInput.Text.Trim()))
                {
                    this.ShowMessage("请输入正确的内容 小数");
                    return false;
                }
            }
            if (ZInputType == typeof(int))
            {
                if (!SysConvert.IsInt32(txtInput.Text.Trim()))
                {
                    this.ShowMessage("请输入正确的内容 整数");
                    return false;
                }
            }
            if (ZCheckValue)//校验数值范围
            {
                if (SysConvert.ToDecimal(txtInput.Text.Trim()) > ZMaxValue || SysConvert.ToDecimal(txtInput.Text.Trim()) < ZMinValue)
                {
                    this.ShowMessage("请输入正确的内容 范围："+ZMinValue.ToString()+"  ---  "+ZMaxValue.ToString());
                    return false;
                }
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCorrect())//验证不通过
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
                if (e.KeyCode == Keys.Enter)//输入条码了
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