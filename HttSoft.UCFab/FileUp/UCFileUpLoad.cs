using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.Framework;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;

namespace HttSoft.UCFab
{
    /// <summary>
    /// �ļ��ϴ��ؼ�
    /// </summary>
    public partial class UCFileUpLoad : UCFabBase
    {
        public UCFileUpLoad()
        {
            InitializeComponent();
        }


        #region ����
        /// <summary>
        /// ����ID
        /// </summary>
        private int m_UCWinListID = 0;
        /// <summary>
        /// ����ID
        /// </summary>
        public int UCWinListID
        {
            get
            {
                return m_UCWinListID;
            }
            set
            {
                m_UCWinListID = value;
            }
        }


        /// <summary>
        /// ����ID(�������ID ,���ں���һ�����ݻ�Ҫ���ٶ����������ʾ)
        /// </summary>
        private int[] m_UCReplaceWinListID = new int[] { };
        /// <summary>
        /// ����ID
        /// </summary>
        public int[] UCReplaceWinListID
        {
            get
            {
                return m_UCReplaceWinListID;
            }
            set
            {
                m_UCReplaceWinListID = value;
            }
        }


        /// <summary>
        /// �������
        /// </summary>
        private int m_UCHeadType = 0;
        /// <summary>
        /// �������
        /// </summary>
        public int UCHeadType
        {
            get
            {
                return m_UCHeadType;
            }
            set
            {
                m_UCHeadType = value;
            }
        }

        /// <summary>
        /// ����С��
        /// </summary>
        private int m_UCSubType = 0;
        /// <summary>
        /// ����С��
        /// </summary>
        public int UCSubType
        {
            get
            {
                return m_UCSubType;
            }
            set
            {
                m_UCSubType = value;
            }
        }

        /// <summary>
        /// ��������ID
        /// </summary>
        private int m_UCHTDateID = 0;
        /// <summary>
        /// ��������ID
        /// </summary>
        public int UCHTDateID
        {
            get
            {
                return m_UCHTDateID;
            }
            set
            {
                m_UCHTDateID = value;
            }
        }


        /// <summary>
        /// ��������Seq
        /// </summary>
        private int m_UCHTDateSeq = 0;
        /// <summary>
        /// ��������Seq
        /// </summary>
        public int UCHTDateSeq
        {
            get
            {
                return m_UCHTDateSeq;
            }
            set
            {
                m_UCHTDateSeq = value;
            }
        }

        /// <summary>
        /// ����һ
        /// </summary>
        private string m_UCFileProt1 = "";
        /// <summary>
        /// ����һ (��Ŵ������)
        /// </summary>
        public string UCFileProt1
        {
            get
            {
                return m_UCFileProt1;
            }
            set
            {
                m_UCFileProt1 = value;
            }
        }


        /// <summary>
        /// ������
        /// </summary>
        private string m_UCFileProt2 = "";
        /// <summary>
        /// ������ (��Ŵ��嵥��)
        /// </summary>
        public string UCFileProt2
        {
            get
            {
                return m_UCFileProt2;
            }
            set
            {
                m_UCFileProt2 = value;
            }
        }

        /// <summary>
        /// �ϴ���
        /// </summary>
        private string m_UCUploadOPID = "";
        /// <summary>
        /// �ϴ���
        /// </summary>
        public string UCUploadOPID
        {
            get
            {
                return m_UCUploadOPID;
            }
            set
            {
                m_UCUploadOPID = value;
            }
        }

        /// <summary>
        /// �ϴ���
        /// </summary>
        private string m_UCUploadOPName = "";
        /// <summary>
        /// �ϴ���
        /// </summary>
        public string UCUploadOPName
        {
            get
            {
                return m_UCUploadOPName;
            }
            set
            {
                m_UCUploadOPName = value;
            }
        }
        /// <summary>
        /// �ϴ��˵�½ID
        /// </summary>
        private int m_UCLoginLogID = 0;
        /// <summary>
        /// �ϴ��˵�½ID
        /// </summary>
        public int UCLoginLogID
        {
            get
            {
                return m_UCLoginLogID;
            }
            set
            {
                m_UCLoginLogID = value;
            }
        }


        /// <summary>
        /// ����Ա��־
        /// </summary>
        private bool m_UCMangerFlag = false;
        /// <summary>
        /// ����Ա��־
        /// </summary>
        public bool UCMangerFlag
        {
            get
            {
                return m_UCMangerFlag;
            }
            set
            {
                m_UCMangerFlag = value;
            }
        }

        #endregion

        #region �ⲿ���÷���
        public void UCAct()
        {
            if (UCWinListID == 0 || UCHTDateID == 0)
            {
                this.ShowMessage("���ݴ�����󣬲���������κβ���");
                btnDeleteFlie.Enabled = false;
                btnFileAdd.Enabled = false;
                btnFileUpdate.Enabled = false;
                btnLoadFile.Enabled = false;
                btnOpenFile.Enabled = false;
                return;
            }
            BindGrid();
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ��������ϸ
        /// </summary>
        public void BindGrid()
        {
            string conditonstr = string.Empty;
            conditonstr += " AND WinListID=" + UCWinListID;
            conditonstr += " AND HeadType=" + UCHeadType;
            conditonstr += " AND SubType=" + UCSubType;
            conditonstr += " AND HTDataID=" + UCHTDateID;

            string filedNameStr = string.Empty;
            filedNameStr = "ID,FileTitle,FileName,FileSize,UploadTime,UploadOPName,UploadOPID,FileExe,Remark";

            WinListAttachFileRule rule = new WinListAttachFileRule();
            DataTable dt = rule.RShow(conditonstr + " ORDER BY ID", filedNameStr);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// �ļ�ɾ��У��
        /// </summary>
        /// <returns></returns>
        bool CheckCorrectDelete()
        {
            bool tempDeleteNoLimite = SysConvert.ToBoolean(UCFileUPParamSet.GetIntValueByID(7203));//�ļ�������ļ�ɾ��Ȩ�޲�������
            int tempDeleteHours = UCFileUPParamSet.GetIntValueByID(7204);//�ļ�������ļ�ɾ�������ڶ���Сʱ�ڣ������ǹ���Ա
            if (tempDeleteHours == 0)
            {
                tempDeleteHours = 24;//Ĭ��24Сʱ
            }

            if (!tempDeleteNoLimite)//���Ʊ��˻����Ա
            {
                if (!UCMangerFlag)//������ǹ���Ա
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UploadOPID")) != UCUploadOPID)
                    {
                        this.ShowMessage("�ϴ��˲��Ǳ��ˣ�������ɾ��");
                        return false;
                    }
                }
            }

            if (tempDeleteHours > 0)//У��ɾ��ʱЧ��
            {
                DateTime uploadTime = SysConvert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UploadTime"));
                TimeSpan ts = UCFileUPParamSet.ServerTime - uploadTime;
                if (ts.TotalHours > tempDeleteHours)
                {
                    this.ShowMessage("����ʱЧ��("+tempDeleteHours+"Сʱ)��������ɾ��");
                    return false;
                }
            }
            return true;

        }
        #endregion

        #region ��ť�¼�
        /// <summary>
        /// �ļ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileAdd_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog2.Filter = "�����ļ�(*)|*";
                openFileDialog2.ShowDialog();
                if (openFileDialog2.FileName != string.Empty)
                {
                    string filenamerount = openFileDialog2.FileName;
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(filenamerount);
                    string fileExec = System.IO.Path.GetExtension(filenamerount);
                    decimal fileSize = WinListAttachFileRule.FileSize(filenamerount);
                    fileSize = SysConvert.ToDecimal(fileSize / 1024, 2);
                    int SysFileSize = 10 * 1024;//10M����
                    if (fileSize > SysFileSize)
                    {
                        ShowMessage("�ļ��ϴ���С���ܳ���" + SysFileSize + "KB");
                        return;
                    }
                    byte[] p_File = WinListAttachFileRule.ConvertToBinaryByPath(filenamerount);
                    WinListAttachFileRule rule = new WinListAttachFileRule();
                    rule.RAdd(p_File, UCWinListID, UCHeadType, UCSubType, UCHTDateID, UCHTDateSeq, fileName, "", fileExec, "", UCFileProt1, UCFileProt2, fileSize, UCUploadOPID, UCUploadOPName, UCLoginLogID);
                    BindGrid();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �ļ��޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileUpdate_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �ļ�ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFlie_Click(object sender, EventArgs e)
        {
            try
            {
               

               
                if (saveFileID == 0)
                {
                    this.ShowMessage("û���ļ�");
                    return;
                }

                if (!CheckCorrectDelete())
                {
                    return;
                }
                if (DialogResult.Yes != ShowConfirmMessage("ɾ��Ϊ���ɻָ�������ȷ��ɾ��"))
                {
                    return;
                }

                WinListAttachFileRule.DeleteFile(saveFileID);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileID == 0)
                {
                    this.ShowMessage("û���ļ�");
                    return;
                }

                this.saveFileDialog2.Filter = "�����ļ�(*" + saveFileExe + ")|*" + saveFileExe;
                this.saveFileDialog2.FileName = saveFileName;
                if (this.saveFileDialog2.ShowDialog() == DialogResult.Cancel) return;
                System.IO.File.WriteAllBytes(saveFileDialog2.FileName, WinListAttachFileRule.ReadFileContext(saveFileID));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        /// <summary>
        /// ���ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            FileStream fStream = null;
            try
            {

                string TemplateFileRoute = Application.StartupPath;//ģ���ļ�·��
                
                if (saveFileID == 0)
                {
                    this.ShowMessage("û���ļ�");
                    return;
                }

                string name = saveFileName + saveFileExe;
                byte[] file = null;
                if (Directory.Exists(TemplateFileRoute + "/Temp") == false)//��������ھʹ���file�ļ���
                {
                    Directory.CreateDirectory(TemplateFileRoute + "/Temp");
                }
                string filePath = TemplateFileRoute + "\\Temp\\" + name;//�ļ�·��
                string sql = " SELECT FileContext FROM Data_WinListAttachFile WHERE ID = " + saveFileID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    file = (byte[])dt.Rows[0]["FileContext"];
                }

                fStream = File.Create(filePath, file.Length);
                fStream.Write(file, 0, file.Length);//������ת�����ļ�
                fStream.Close();
                System.Diagnostics.Process.Start(filePath);


            }
            catch //(Exception ex)
            {
            }
            finally
            {
                fStream.Close();
            }
        }
        #endregion

        #region �ؼ��¼�
        /// <summary>
        /// �ؼ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFileUpLoad_Load(object sender, EventArgs e)
        {
            try
            {
                IniUCPicture();

                new HttSoft.FrameFunc.ProUI().ProcUI(this);
                gridView1.RowCellStyle += new RowCellStyleEventHandler(_HTDataDts_RowCellStyle);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
        #region �����¼�
        int saveFileID = 0;
        string saveFileName = string.Empty;
        string saveFileExe = string.Empty;
        /// <summary>
        /// ���иı��¼�
        /// </summary>
        /// <param name="sender"></param>
        private void gridViewRowChanged3(object sender)
        {
            try
            {
                ColumnView view = sender as ColumnView;

                saveFileID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
                saveFileName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "FileName"));
                saveFileExe = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "FileExe"));
                string tempExe = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "FileExe")).ToLower();
                
                if (tempExe == ".jpg" || tempExe == ".gif" || tempExe == ".bmp")//�����ͼƬ
                {
                    bool autoshowPic = SysConvert.ToBoolean(UCFileUPParamSet.GetIntValueByID(7206));
                    if (autoshowPic)//�Զ���ʾͼƬ
                    {
                        groupControlBRight.Visible = true;
                        PictureSet(saveFileID);
                    }
                    else
                    {
                        groupControlBRight.Visible = false;
                    }
                }
                else
                {
                    groupControlBRight.Visible = false;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            gridViewRowChanged3(sender);
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            gridViewRowChanged3(sender);
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            gridViewRowChanged3(sender);
        }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        void PictureSet(int p_FileID)
        {
            if (groupControlBRight.Visible)//ͼƬ���ؼ��ɼ�
            {
                ucPictureView1.UCDataID = p_FileID;
                ucPictureView1.UCAct();
            }
        }

        /// <summary>
        /// ��ʼ��ͼƬ�ؼ�
        /// </summary>
        void IniUCPicture()
        {
            ucPictureView1.UCReadOnly = true;
            ucPictureView1.UCInputPictureMultiFlag = false;//��ͼģʽ
            ucPictureView1.UCInputMainType = 1;//���ݿ�ģʽ
            ucPictureView1.UCInputDBSaveType = 1;//ͬһ����ֻ��Update  

            ucPictureView1.UCDBMainIDFieldName = "";
            ucPictureView1.UCDBRemarkFieldName = "";
            ucPictureView1.UCDBTableName = "Data_WinListAttachFile";
            ucPictureView1.UCDBPicFieldName = "FileContext";
            ucPictureView1.UCDBSmallPicFieldName = "";
            ucPictureView1.UCDataID = 0;
            ucPictureView1.UCAct();
        }
        #endregion


        #region ���ݱ����ʽ
        /// <summary>
        /// ����GridView��ͬ�е���ɫ��ͬ
        /// �鷽����Ŀ���Ǳ��ڽ�����д��������ɫ�仯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void _HTDataDts_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    if (e.RowHandle % 2 == 0)
                    {
                        e.Appearance.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.White;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion



    }
}
