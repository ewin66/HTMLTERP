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
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：设计师管理
    /// 作者：章文强
    /// 日期：2012-04-18
    /// 操作：新增
    /// </summary>
    public partial class frmVDsignerEdit : frmAPBaseUISinEdit
    {
        public frmVDsignerEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("请输入姓名");
                txtName.Focus();
                return false;
            }

                     
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            VDsignerRule rule = new VDsignerRule();
            VDsigner entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            VDsignerRule rule = new VDsignerRule();
            VDsigner entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            VDsigner entity = new VDsigner();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtName.Text = entity.Name.ToString();
            txtOlder.Text = entity.Older.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtTel.Text = entity.Tel.ToString();
            txtMobile.Text = entity.Mobile.ToString();
            txtHHis.Text = entity.HHis.ToString();
            drpUseableFlag.EditValue = entity.UseableFlag;
            drpSendMSGFlag.EditValue = entity.SendMSGFlag;
            txtCompanyName.Text = entity.CompanyName.ToString();
            
            if (!findFlag)
            {
               
            }
            BindPic();
        }

        private void BindPic()
        {
            string sql = "SELECT * FROM Data_VDsignerFile WHERE MainID="+SysString.ToDBString(HTDataID);
            sql += " ORDER BY Seq";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (SysConvert.ToInt32(dt.Rows[i]["FileTypeID"]) == i+1)
                    {
                        switch (i+1)
                        {
                            case 1:
                                img1.Image = TemplatePic.ByteToImage((byte[])dt.Rows[i]["Context"]);
                                break;
                            case 2:
                                img2.Image = TemplatePic.ByteToImage((byte[])dt.Rows[i]["Context"]);
                                break;
                            case 3:
                                img3.Image = TemplatePic.ByteToImage((byte[])dt.Rows[i]["Context"]);
                                break;
                            case 4:
                                img4.Image = TemplatePic.ByteToImage((byte[])dt.Rows[i]["Context"]);
                                break;
                            case 5:
                                img5.Image = TemplatePic.ByteToImage((byte[])dt.Rows[i]["Context"]);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            VDsignerRule rule = new VDsignerRule();
            VDsigner entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_VDsigner";
            Common.BindPicNum(drpPicNum, true);
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private VDsigner EntityGet()
        {
            VDsigner entity = new VDsigner();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Name = txtName.Text.Trim();
            entity.Older = txtOlder.Text.Trim();
            entity.Tel = txtTel.Text.Trim();
            entity.Mobile = txtMobile.Text.Trim();
            entity.HHis = txtHHis.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.SendMSGFlag = SysConvert.ToInt32(drpSendMSGFlag.EditValue);
            entity.UseableFlag = SysConvert.ToInt32(drpUseableFlag.EditValue);
            entity.CompanyName = txtCompanyName.Text.Trim();
            return entity;
        }
        #endregion

        #region 处理图片
        private void btnPicNewBrowsing_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("请先保存数据");
                    return;
                }
                if (SysConvert.ToString(drpPicNum.EditValue) == "")
                {
                    this.ShowMessage("请选择上传图片类型");
                    drpPicNum.Focus();
                    return;
                }

                openFileDialog1.Filter = "JPG文件(*.jpg)|*.jpg|GIF文件(*.gif)|*.gif|BMP文件(*.bmp)|*.bmp|全部文件(*.*)|*.*";
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    int PicNum = SysConvert.ToInt32(drpPicNum.EditValue);
                    string filenamerount = openFileDialog1.FileName;
                    switch (PicNum)
                    {
                        case 1:
                            
                            img1.Image = Image.FromFile(filenamerount);
                            break;
                        case 2:
                            
                            img2.Image = Image.FromFile(filenamerount);
                            break;
                        case 3:
                            
                            img3.Image = Image.FromFile(filenamerount);
                            break;
                        case 4:
                            
                            img4.Image = Image.FromFile(filenamerount);
                            break;
                        case 5:
                            
                            img5.Image = Image.FromFile(filenamerount);
                            break;
                        default:
                            break;
                    }
                    

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void btnPicSave_Click(object sender, EventArgs e)
        {
            if (HTDataID != 0)
            {
                if (SysConvert.ToInt32(drpPicNum.EditValue) == 0)
                {
                    this.ShowMessage("请选择图片存放位置");
                    drpPicNum.Focus();
                    return;
                }
                VDsignerFileRule rule = new VDsignerFileRule();
                VDsignerFile entity = GetSVDsignerFile();
                rule.RSave(entity, HTDataID);
                this.ShowMessage("图片存放成功");
                BindPic();
            }
            else
            {
                this.ShowMessage("请先保存基础资料");
                return;
            }
        }

        private VDsignerFile GetSVDsignerFile()
        {
            VDsignerFile entity = new VDsignerFile();
            int picNum = SysConvert.ToInt32(drpPicNum.EditValue);
            switch (picNum)
            {
                case 1:
                    if (img1.Image != null)
                    {

                        entity.Context = TemplatePic.ImageToByte(img1.Image);
                        entity.FileTypeID = picNum;
                        entity.FileLength = SysConvert.ToDecimal(img1.Image.Width);
                        entity.UploadOPID = FParamConfig.LoginID;
                        entity.UploadTime = DateTime.Now.Date;
                       
                    }
                    break;
                case 2:
                    if (img2.Image != null)
                    {

                        entity.Context = TemplatePic.ImageToByte(img2.Image);
                        entity.FileTypeID = picNum;
                        entity.FileLength = SysConvert.ToDecimal(img2.Image.Width);
                        entity.UploadOPID = FParamConfig.LoginID;
                        entity.UploadTime = DateTime.Now.Date;
                        
                    }
                    break;
                case 3:
                    if (img3.Image != null)
                    {

                        entity.Context = TemplatePic.ImageToByte(img3.Image);
                        entity.FileTypeID = picNum;
                        entity.FileLength = SysConvert.ToDecimal(img3.Image.Width);
                        entity.UploadOPID = FParamConfig.LoginID;
                        entity.UploadTime = DateTime.Now.Date;
                       
                    }
                    break;
                case 4:
                    if (img4.Image != null)
                    {

                        entity.Context = TemplatePic.ImageToByte(img4.Image);
                        entity.FileTypeID = picNum;
                        entity.FileLength = SysConvert.ToDecimal(img4.Image.Width);
                        entity.UploadOPID = FParamConfig.LoginID;
                        entity.UploadTime = DateTime.Now.Date;
                       
                    }
                    break;
                case 5:
                    if (img5.Image != null)
                    {

                        entity.Context = TemplatePic.ImageToByte(img5.Image);
                        entity.FileTypeID = picNum;
                        entity.FileLength = SysConvert.ToDecimal(img5.Image.Width);
                        entity.UploadOPID = FParamConfig.LoginID;
                        entity.UploadTime = DateTime.Now.Date;
                        
                    }
                    break;
                default:
                    break;
            }
            return entity;

        }

        private VDsignerFile[] GetVDsignerFile()
        {

            int Num = 0;
            byte[] pic;
            for (int i = 1; i < 6; i++)
            {
                switch (i)
                {
                    case 1:
                        if (img1.Image != null)
                        {
                            Num++;
                        }
                        break;
                    case 2:
                        if (img2.Image != null)
                        {
                            Num++;
                        }
                        break;
                    case 3:
                        if (img3.Image != null)
                        {
                            Num++;
                        }
                        break;
                    case 4:
                        if (img4.Image != null)
                        {
                            Num++;
                        }
                        break;
                    case 5:
                        if (img5.Image != null)
                        {
                            Num++;
                        }
                        break;
                    default:
                        break;
                }
            }
            VDsignerFile[] entityDts=new VDsignerFile[Num];
            int index = 0;
            for (int i = 1; i < 6; i++)
            {
               
                switch (i)
                {
                    case 1:
                        if (img1.Image != null)
                        {
                            entityDts[index] = new VDsignerFile();
                            entityDts[index].MainID = HTDataID;
                            entityDts[index].Seq = i;
                            entityDts[index].SelectByID();
                            entityDts[index].Context = TemplatePic.ImageToByte(img1.Image);
                            entityDts[index].FileTypeID = i;
                            entityDts[index].FileLength = SysConvert.ToDecimal(img1.Image.Width);
                            entityDts[index].UploadOPID = FParamConfig.LoginID;
                            entityDts[index].UploadTime = DateTime.Now.Date;
                            index++;
                        }
                        break;
                    case 2:
                        if (img2.Image != null)
                        {
                            entityDts[index] = new VDsignerFile();
                            entityDts[index].MainID = HTDataID;
                            entityDts[index].Seq = i;
                            entityDts[index].SelectByID();
                            entityDts[index].Context = TemplatePic.ImageToByte(img2.Image);
                            entityDts[index].FileTypeID = i;
                            entityDts[index].FileLength = SysConvert.ToDecimal(img2.Image.Width);
                            entityDts[index].UploadOPID = FParamConfig.LoginID;
                            entityDts[index].UploadTime = DateTime.Now.Date;
                            index++;
                        }
                        break;
                    case 3:
                        if (img3.Image != null)
                        {
                            entityDts[index] = new VDsignerFile();
                            entityDts[index].MainID = HTDataID;
                            entityDts[index].Seq = i;
                            entityDts[index].SelectByID();
                            entityDts[index].Context = TemplatePic.ImageToByte(img3.Image);
                            entityDts[index].FileTypeID = i;
                            entityDts[index].FileLength = SysConvert.ToDecimal(img3.Image.Width);
                            entityDts[index].UploadOPID = FParamConfig.LoginID;
                            entityDts[index].UploadTime = DateTime.Now.Date;
                            index++;
                        }
                        break;
                    case 4:
                        if (img4.Image != null)
                        {
                            entityDts[index] = new VDsignerFile();
                            entityDts[index].MainID = HTDataID;
                            entityDts[index].Seq = i;
                            entityDts[index].SelectByID();
                            entityDts[index].Context = TemplatePic.ImageToByte(img4.Image);
                            entityDts[index].FileTypeID = i;
                            entityDts[index].FileLength = SysConvert.ToDecimal(img4.Image.Width);
                            entityDts[index].UploadOPID = FParamConfig.LoginID;
                            entityDts[index].UploadTime = DateTime.Now.Date;
                            index++;
                        }
                        break;
                    case 5:
                        if (img5.Image != null)
                        {
                            entityDts[index] = new VDsignerFile();
                            entityDts[index].MainID = HTDataID;
                            entityDts[index].Seq = i;
                            entityDts[index].SelectByID();
                            entityDts[index].Context = TemplatePic.ImageToByte(img5.Image);
                            entityDts[index].FileTypeID = i;
                            entityDts[index].FileLength = SysConvert.ToDecimal(img5.Image.Width);
                            entityDts[index].UploadOPID = FParamConfig.LoginID;
                            entityDts[index].UploadTime = DateTime.Now.Date;
                            index++;
                        }
                        break;
                    default:
                        break;
                }
            }

            return entityDts;
        }

    }
}