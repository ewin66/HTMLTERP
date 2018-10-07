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
    public partial class UCPictureShowFrm : Form
    {
        #region 全局变量


        //private string m_HTDataID = string.Empty;
        //public string HTDataID
        //{
        //    get
        //    {
        //        return m_HTDataID;
        //    }
        //    set
        //    {
        //        m_HTDataID = value;
        //    }
        //}

        //private int m_PicIndex =0;
        //public int PicIndex
        //{
        //    get
        //    {
        //        return m_PicIndex;
        //    }
        //    set
        //    {
        //        m_PicIndex = value;
        //    }
        //}
        public Image img;

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

        public UCPictureShowFrm()
        {
            InitializeComponent();
        }
        #region 窗体事件
        private void frmStylePic_Load(object sender, EventArgs e)
        {
            try
            {
                BindPic();
            }
            catch (Exception E)
            {
                //this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="p_Pic"></param>
        /// <param name="p_PictureTypeID"></param>
        private void BindPic()
        {
            picSample.Image = img;
        }

        #endregion


        #region 其它事件

        private void cmiDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (picSample.Image != null)
                {
                    saveFileDialog1.FileName = "pic.jpg";
                    saveFileDialog1.Title = "图片下载";
                    if (saveFileDialog1.FileName != string.Empty && saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string outpath = saveFileDialog1.FileName;
                        System.IO.FileStream fs = new System.IO.FileStream(outpath, System.IO.FileMode.Create);
                        byte[] imageByte = UCTemplatePic.ImageToByte(picSample.Image);
                        for (int i = 0; i < imageByte.Length; i++)
                        {
                            fs.WriteByte(imageByte[i]);
                        }
                        fs.Close();
                        ShowInfoMessage("文件下载成功");
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (picSample.Image != null)
                {
                    cmiDownload.Enabled = true;
                }
                else
                {
                    cmiDownload.Enabled = false;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 图片控制事件

        Image saveStandImage = null;
        int saveZoomNum = 0;

        /// <summary>
        /// 图片放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPicBigger_Click(object sender, EventArgs e)
        {
            try
            {
                if (picSample.Image == null)
                {
                    return;
                }
                if (saveStandImage == null)
                {
                    saveStandImage = picSample.Image;
                }
                if (saveZoomNum < 30)//最多放大4倍,限制下，防止溢出
                {
                    saveZoomNum++;
                }
                picSample.Image = UCTemplatePic.ZoomImage(saveStandImage, saveZoomNum * 0.1m + 1m);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 图片缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPicSmaller_Click(object sender, EventArgs e)
        {
            try
            {
                if (picSample.Image == null)
                {
                    return;
                }
                if (saveStandImage == null)
                {
                    saveStandImage = picSample.Image;
                }

                decimal zoonNum = saveZoomNum * 0.1m + 1m;
                if (zoonNum <= 0)
                {
                    return;
                }
                else
                {
                    saveZoomNum--;
                }
                picSample.Image = UCTemplatePic.ZoomImage(saveStandImage, zoonNum);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 原始图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPicYuan_Click(object sender, EventArgs e)
        {
            try
            {
                if (picSample.Image == null)
                {
                    return;
                }
                if (saveStandImage == null)
                {
                    saveStandImage = picSample.Image;                    
                }
                saveZoomNum = 0;
                picSample.Image = saveStandImage;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
}