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


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFileID.Text.Trim() == "")
            {
                this.ShowMessage("������ģ�����");
                txtFileID.Focus();
                return false;
            }
            if (txtFileName.Text.Trim() == "")
            {
                this.ShowMessage("������ģ������");
                txtFileName.Focus();
                return false;
            }
            if (HTFormStatus == FormStatus.����)
            {
                if (txtFilePath.Text.Trim() == "")
                {
                    ShowMessage("��ѡ��ģ���ļ�");
                    txtFilePath.Focus();
                    return false;
                }
                if (!SysFile.CheckFileExit(txtFilePath.Text.Trim()))
                {
                    ShowMessage("ģ���ļ�û���ҵ�" + Environment.NewLine + "·����" + txtFilePath.Text.Trim());
                    txtFilePath.Focus();
                    return false;
                }
            }
            if (HTFormStatus == FormStatus.�޸�)
            {
                if (txtFilePath.Text.Trim() != "")
                {
                    if (!SysFile.CheckFileExit(txtFilePath.Text.Trim()))
                    {
                        ShowMessage("ģ���ļ�û���ҵ�" + Environment.NewLine + "·����" + txtFilePath.Text.Trim());
                        txtFilePath.Focus();
                        return false;
                    }
                }
            }         

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            ReportFileModelRule rule = new ReportFileModelRule();
            ReportFileModel entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ReportFileModelRule rule = new ReportFileModelRule();
            ReportFileModel entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
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
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ReportFileModelRule rule = new ReportFileModelRule();
            ReportFileModel entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
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
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_ReportFileModel";
            //
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ReportFileModel EntityGet()
        {
            ReportFileModel entity = new ReportFileModel();
            entity.ID = HTDataID;
            entity.SelectByID();

            if (HTFormStatus == FormStatus.����)
            {
                entity.Context = HttSoft.WinUIBase.FastReport.ConvertToBinaryByPath(txtFilePath.Text.Trim());
            }
            if (HTFormStatus == FormStatus.�޸�)
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