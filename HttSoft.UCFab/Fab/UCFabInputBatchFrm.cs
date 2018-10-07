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
    /// 批量录入窗体
    /// </summary>
    public partial class UCFabInputBatchFrm : Form
    {
        public UCFabInputBatchFrm()
        {
            InitializeComponent();
        }


        #region 属性
       


        /// <summary>
        /// 确定状态
        /// </summary>
        private bool m_UCOKFlag = false;
        /// <summary>
        /// 确定状态
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
        /// 匹数
        /// </summary>
        private int m_UCFabCount = 0;
        /// <summary>
        /// 卷数
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
        /// 每匹数量
        /// </summary>
        private decimal m_UCFabPerQty = 0m;
        /// <summary>
        /// 每匹数量
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

        #region 公共方法
        #region 提示信息

        /// <summary>
        /// 显示错误提示信息
        /// </summary>
        /// <param name="p_Message">错误信息内容</param>
        public void ShowMessage(string p_Message)
        {
            MessageBox.Show(p_Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="p_Message">提示信息内容</param>
        public void ShowInfoMessage(string p_Message)
        {
            MessageBox.Show(p_Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示确认信息
        /// </summary>
        /// <param name="p_Message">询问信息</param>
        /// <returns></returns>
        public DialogResult ShowConfirmMessage(string p_Message)
        {
            return MessageBox.Show(p_Message, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion


        #endregion



        #region 自定义法方法
        /// <summary>
        /// 校验输入是否正确
        /// </summary>
        /// <returns></returns>
        bool CheckCorrect()
        {
            if(SysConvert.ToInt32(txtFabCount.Text.Trim())<=0)
            {
                this.ShowMessage("请输入匹数");
                txtFabCount.Focus();
                return false;
            }

            if (SysConvert.ToDecimal(txtPerQty.Text.Trim()) <= 0)
            {
                this.ShowMessage("请输入每匹数量");
                txtPerQty.Focus();
                return false;
            }
            return true;
        }
        #endregion


        #region 按钮事件
        /// <summary>
        /// 确定
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
        /// 取消
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