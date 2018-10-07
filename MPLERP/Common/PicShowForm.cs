using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;

namespace MLTERP
{

    public partial class PicShowForm : BaseForm
    {
        public PicShowForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 要显示的图片
        /// </summary>
        Image _ProImage;
        public Image ProImage
        {
            set
            {
                _ProImage = value;
            }
        }

        private void PicShowForm_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBoxStandPic.Image = _ProImage;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 图片放大
        /// </summary>
        private void btnPicBigger_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBoxStandPic.Image == null)
                {
                    return;
                }
                if (saveStandImage == null)
                {
                    saveStandImage = pictureBoxStandPic.Image;
                }

                saveZoomNum++;
                pictureBoxStandPic.Image = TemplatePic.ZoomImage(saveStandImage, saveZoomNum * 0.1m + 1m);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 图片缩小
        /// </summary>
        private void btnPicSmaller_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBoxStandPic.Image == null)
                {
                    return;
                }
                if (saveStandImage == null)
                {
                    saveStandImage = pictureBoxStandPic.Image;
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
                pictureBoxStandPic.Image = TemplatePic.ZoomImage(saveStandImage, zoonNum);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 原始图片
        /// </summary>
        private void btnPicYuan_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBoxStandPic.Image == null)
                {
                    return;
                }
                if (saveStandImage == null)
                {
                    saveStandImage = pictureBoxStandPic.Image;
                }
                saveZoomNum = 0;
                pictureBoxStandPic.Image = TemplatePic.ZoomImage(saveStandImage, saveZoomNum * 0.1m + 1m);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        Image saveStandImage = null;
        int saveZoomNum = 0;
    }
}