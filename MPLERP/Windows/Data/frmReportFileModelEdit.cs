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
    public partial class frmReportFileModelEdit : frmAPBaseUISinEdit
    {
        public frmReportFileModelEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFileID.Text.Trim() == "")
            {
                this.ShowMessage("请输入模板编码");
                txtFileID.Focus();
                return false;
            }
            if (txtFileName.Text.Trim() == "")
            {
                this.ShowMessage("请输入模板名称");
                txtFileName.Focus();
                return false;
            }
            if (HTFormStatus == FormStatus.新增)
            {
                if (txtFilePath.Text.Trim() == "")
                {
                    ShowMessage("请选择模板文件");
                    txtFilePath.Focus();
                    return false;
                }
                if (!SysFile.CheckFileExit(txtFilePath.Text.Trim()))
                {
                    ShowMessage("模板文件没有找到" + Environment.NewLine + "路径：" + txtFilePath.Text.Trim());
                    txtFilePath.Focus();
                    return false;
                }
            }
            if (HTFormStatus == FormStatus.修改)
            {
                if (txtFilePath.Text.Trim() != "")
                {
                    if (!SysFile.CheckFileExit(txtFilePath.Text.Trim()))
                    {
                        ShowMessage("模板文件没有找到" + Environment.NewLine + "路径：" + txtFilePath.Text.Trim());
                        txtFilePath.Focus();
                        return false;
                    }
                }
            }         

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            ReportFileModelRule rule = new ReportFileModelRule();
            ReportFileModel entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ReportFileModelRule rule = new ReportFileModelRule();
            ReportFileModel entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            ReportFileModel entity = new ReportFileModel();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtFileID.Text = entity.FileID.ToString();
            txtFileType.Text = entity.FileType.ToString();
            txtFileName.Text = entity.FileName.ToString();
            txtFileExec.Text = entity.FileExec.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtUploadTime.DateTime = entity.UploadTime;
            txtSeq.Text = entity.Seq.ToString();
            txtMFlag.Text = entity.MFlag.ToString();
            if (txtUploadTime.DateTime == SystemConfiguration.DateTimeDefaultValue)
            {
                txtUploadTime.Text = "";
            }

            if (!findFlag)
            {

            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ReportFileModelRule rule = new ReportFileModelRule();
            ReportFileModel entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { txtUploadTime }, false);
        }

        public override void IniInsertSet()
        {
            txtUploadTime.DateTime = DateTime.Now.Date;
        }
        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_ReportFileModel";
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ReportFileModel EntityGet()
        {
            ReportFileModel entity = new ReportFileModel();
            entity.ID = HTDataID;
            entity.SelectByID();

            if (HTFormStatus == FormStatus.新增)
            {
                entity.Context = HttSoft.WinUIBase.FastReport.ConvertToBinaryByPath(txtFilePath.Text.Trim());
            }
            if (HTFormStatus == FormStatus.修改)
            {
                if (txtFilePath.Text.Trim() != "")
                {
                    entity.Context = HttSoft.WinUIBase.FastReport.ConvertToBinaryByPath(txtFilePath.Text.Trim());
                }
            }
            entity.FileID = SysConvert.ToInt32(txtFileID.Text.Trim());
            entity.FileType = SysConvert.ToInt32(txtFileType.Text.Trim());
            entity.FileName = txtFileName.Text.Trim();
            entity.FileExec = txtFileExec.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();

            entity.Seq = SysConvert.ToInt32(txtSeq.Text.Trim());
            entity.MFlag = SysConvert.ToInt32(txtMFlag.Text.Trim());
            if (txtUploadTime.DateTime != SystemConfiguration.DateTimeDefaultValue && txtUploadTime.Text != "")
            {
                entity.UploadTime = txtUploadTime.DateTime.Date;
            }
            return entity;
        }
        #endregion

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "(*.fr3)|*.fr3";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != string.Empty)
                {
                    txtFilePath.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

      
    }
}