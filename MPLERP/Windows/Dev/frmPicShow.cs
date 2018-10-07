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
    public partial class frmPicShow : Form
    {
        public frmPicShow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 挂板ID
        /// </summary>
        private int m_GBID;
        public int GBID
        {
            get
            {
                return m_GBID;
            }
            set
            {
                m_GBID = value;
            }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPicShow_Load(object sender, EventArgs e)
        {
            try
            {
                IniUCPicture();
                BindImage();
               
            }
            catch (Exception E)
            {
               // this.ShowMessage(E.Message);
            }
        }

        #region 自定义方法
        void BindImage()
        {
            string sql = "SELECT GBPic FROM Data_ItemGB WHERE ID=" + SysString.ToDBString(m_GBID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                List<Image> lstimage = new List<Image>();
                byte[] picdata=(byte[])dt.Rows[0][0];
                if (picdata.Length > 10)
                {
                    lstimage.Add(TemplatePic.ByteToImage(picdata));
                }
                ucPictureView1.UCDataLstImage = lstimage;
            }
            else
            {
                List<Image> lstimage = new List<Image>();
                ucPictureView1.UCDataLstImage = lstimage;
            }
            this.Text = "图片查看";//[" + GBCode + "]";


          
        }


        /// <summary>
        /// 初始化图片控件
        /// </summary>
        void IniUCPicture()
        {
            ucPictureView1.UCReadOnly = true;
            ucPictureView1.UCInputPictureMultiFlag = false;//单图模式
            ucPictureView1.UCInputMainType = 2;//图片模式
            ucPictureView1.UCInputDBSaveType = 1;//同一数据只有Update  

            ucPictureView1.UCDBMainIDFieldName = "";
            ucPictureView1.UCDBRemarkFieldName = "";
            ucPictureView1.UCDBTableName = "Data_ItemGB";
            ucPictureView1.UCDBPicFieldName = "GBPic";
            ucPictureView1.UCDBSmallPicFieldName = "GBPic2";
            ucPictureView1.UCDataID = 0;
            ucPictureView1.UCAct();
        }
        #endregion

    }
}