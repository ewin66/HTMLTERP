using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using DevExpress.XtraGrid.Views.Base;



namespace MLTERP
{
    public partial class frmGBAdd : BaseForm
    {
        public frmGBAdd()
        {
            InitializeComponent();
        }

        

        private int m_ID;
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        private int m_DID=0;
        public int DID
        {
            get
            {
                return m_DID;
            }
            set
            {
                m_DID = value;
            }
        }

       
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                IniUCPicture();
                EntitySet();
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void EntitySet()
        {
           

            if (m_DID == 0)
            {
                Item entity = new Item();
                entity.ID = m_ID;
                entity.SelectByID();
                drpGBDate.DateTime = DateTime.Now.Date;
                txtGBItemName.Text = entity.ItemName;
                txtGMWeight.Text = entity.MWeight.ToString();
                txtGMWidth.Text = entity.MWidth.ToString();
                drpGBStatusID.EditValue = (int)EnumGBStatus.在库;
                txtGBCode_DoubleClick(null, null);
            }
            else
            {
                ItemGB entityGB=new ItemGB();
                entityGB.ID=m_DID;
                entityGB.SelectByID();
                drpGBDate.DateTime = entityGB.GBDate;

                List<Image> lstimage = new List<Image>();
                if (entityGB.GBPic.Length > 10)
                {
                    lstimage.Add(TemplatePic.ByteToImage(entityGB.GBPic));
                    ucPictureInput1.UCDataLstImage = lstimage;
                }
                txtGBCode.Text = entityGB.GBCode;
                txtColorNum.Text = entityGB.ColorNum;
                txtColorName.Text = entityGB.ColorName;
                txtDRemark.Text = entityGB.Remark;
                txtGBItemName.Text = entityGB.ItemName;
                txtGMWeight.Text = entityGB.MWeight.ToString();
                txtGMWidth.Text = entityGB.MWidth.ToString();
                drpGBStatusID.EditValue = entityGB.GBStatusID;
            }

            Common.BindGBColorNum(txtColorNum, m_ID, true);
            Common.BindGBColorName(txtColorName, m_ID, true);

          
        }


        /// <summary>
        /// 初始化图片控件
        /// </summary>
        void IniUCPicture()
        {
            ucPictureInput1.UCReadOnly = false;
            ucPictureInput1.UCInputPictureMultiFlag = false;//单图模式
            ucPictureInput1.UCInputMainType = 2;//主模式
            ucPictureInput1.UCInputDBSaveType = 1;//同一数据只有Update  

            ucPictureInput1.UCDBMainIDFieldName = "";
            ucPictureInput1.UCDBRemarkFieldName = "";
            ucPictureInput1.UCDBTableName = "Data_ItemGB";
            ucPictureInput1.UCDBPicFieldName = "GBPic";
            ucPictureInput1.UCDBSmallPicFieldName = "GBPic2";
            ucPictureInput1.UCDataID = 0;

            ucPictureInput1.UCUIPicWidth = 700;
            ucPictureInput1.UCUIPicHeight = 700;
            ucPictureInput1.UCAct();
        }


        //private void btnPicNewBrowsing_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (m_ID == 0)
        //        {
        //            this.ShowMessage("请先保存数据");
        //            return;
        //        }


        //        openFileDialog1.Filter = "JPG文件(*.jpg)|*.jpg|GIF文件(*.gif)|*.gif|BMP文件(*.bmp)|*.bmp|全部文件(*.*)|*.*";
        //        if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
        //        {
        //            string filenamerount = openFileDialog1.FileName;
        //            img1.Image = Image.FromFile(filenamerount);
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        private ItemGB GetItemGB()
        {
            ItemGB entity = new ItemGB();
            entity.ID = m_DID;
            entity.SelectByID();
            entity.MainID = m_ID;
            if (entity.Seq == 0)
            {
                entity.Seq = GetMaxSeq(m_ID);
            }
            entity.ColorName = txtColorName.Text.Trim();
            entity.ColorNum = txtColorNum.Text.Trim();
            entity.GBCode = txtGBCode.Text.Trim();
            entity.XY = SysConvert.ToInt32(drpXY.EditValue);
            entity.GBStatusID =SysConvert.ToInt32(drpGBStatusID.EditValue);


            if (ucPictureInput1.UCDataLstImage.Count > 0)
            {
                entity.GBPic = TemplatePic.ImageToByte(ucPictureInput1.UCDataLstImage[0]);
                if (ucPictureInput1.UCDataLstSmallImage.Count > 0)
                {
                    entity.GBPic2 = TemplatePic.ImageToByte(ucPictureInput1.UCDataLstSmallImage[0]);
                }
            }
            else
            {
                entity.GBPic = new byte[2];
                entity.GBPic2 = new byte[2];
            }
            entity.Remark = txtDRemark.Text.Trim();
            entity.GBDate = drpGBDate.DateTime.Date;
            entity.MWidth = txtGMWidth.Text.Trim();
            entity.MWeight = txtGMWeight.Text.Trim();
            entity.ItemName = txtGBItemName.Text.Trim();
            return entity;
        }

        private int GetMaxSeq(int m_ID)
        {
            int MaxSeq =1;
            string sql = "SELECT Max(Seq) FROM Data_ItemGB WHERE MainID="+SysString.ToDBString(m_ID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                MaxSeq = SysConvert.ToInt32(dt.Rows[0][0]) + 1;

            }
            return MaxSeq;
        }

        private void txtGBCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormNoControlRule frule = new FormNoControlRule();
                txtGBCode.Text = frule.RGetFormNo((int)FormNoControlEnum.挂板单号);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtColorNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtColorNum.Text.Trim() != "")
            //    {
            //        txtColorName.Text = GetColorName(txtColorNum.Text.Trim());
            //    }
            //}
            //catch (Exception E)
            //{
            //    this.ShowMessage(E.Message);
            //}
        }

        private void txtColorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtColorName.Text.Trim() != "")
            //    {
            //        txtColorNum.Text = GetColorNum(txtColorName.Text.Trim());
            //    }
            //}
            //catch (Exception E)
            //{
            //    this.ShowMessage(E.Message);
            //}
        }
        

        //private string GetColorName(string p_ColorNum)
        //{
        //    string ColorName = "";
        //    string sql = "SELECT ColorName FROM Data_ItemColorDts WHERE MainID=" + SysString.ToDBString(m_ID);
        //    sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //    DataTable dt = SysUtils.Fill(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        ColorName = SysConvert.ToString(dt.Rows[0][0]);
        //    }
        //    return ColorName;
        //}

        //private string GetColorNum(string p_ColorName)
        //{
        //    string ColorNum = "";
        //    string sql = "SELECT ColorNum FROM Data_ItemColorDts WHERE MainID=" + SysString.ToDBString(m_ID);
        //    sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //    DataTable dt = SysUtils.Fill(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        ColorNum = SysConvert.ToString(dt.Rows[0][0]);
        //    }
        //    return ColorNum;
        //}

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ItemGBRule rule = new ItemGBRule();
                ItemGB entity = GetItemGB();
                if (m_DID == 0)
                {
                    rule.RAdd(entity);
                    m_DID= entity.ID;
                }
                else
                {
                    rule.RUpdate(entity);
                }
                this.ShowInfoMessage("保存成功！");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       


    }

}