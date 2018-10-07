using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HttSoft.UCFab
{
    /// <summary>
    /// 功能：拍照
    /// 作者：陈加海
    /// 日期：2014-4-29
    /// </summary>
    public partial class UCPictureVideoCamerFrm : Form
    {
        public UCPictureVideoCamerFrm()
        {
            InitializeComponent();
        }
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

        public bool pzflag = false;
        public string pzfileName = string.Empty;
        UCVideo video;

        private void btnCam_Click(object sender, EventArgs e)
        {
            try
            {
                //FileInfo fi = new FileInfo(Application.StartupPath + @"\zp.bmp");
                //if (fi.Exists)
                //{
                //    fi.Delete();
                //}
                pzfileName = Application.StartupPath + @"\Temp\zp" + DateTime.Now.ToString("HHmmss") + ".bmp";
                video.GrabImage(pictureBox1.Handle, pzfileName);
                pzflag = true;
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        private void UCPictureVideoCamerFrm_Load(object sender, EventArgs e)
        {
            try
            {
                video = new UCVideo(pictureBox1.Handle, pictureBox1.Width, pictureBox1.Height);
                video.StartWebCam();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void UCPictureVideoCamerFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                video.CloseWebcam();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}