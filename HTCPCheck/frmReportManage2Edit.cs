using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
//using HttSoft.MLTERP.Data;
//using HttSoft.MLTERP.DataCtl;
//using HttSoft.MLTERP.Sys;
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;

namespace HTCPCheck
{
    public partial class frmReportManage2Edit : frmAPBaseUIFormEdit
    {
        public frmReportManage2Edit()
        {
            InitializeComponent();
        }

        #region ȫ�ֱ���
        public string OLDModelType = "";
        #endregion

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (Common.CheckLookUpEditBlank(drpParentID))
            {
                this.ShowMessage("��ѡ��ģ��");
                drpParentID.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpWinListID))
            {
                this.ShowMessage("��ѡ����");
                drpWinListID.Focus();
                return false;
            }
            if (txtReportName.Text.Trim() == "")
            {
                this.ShowMessage("�����뱨������");
                txtReportName.Focus();
                return false;
            }
            if (drpReportModelType.EditValue.ToString() == "")
            {
                this.ShowMessage("������ģ������");
                drpReportModelType.Focus();
                return false;
            }
            else
            {
                if ((drpReportModelType.EditValue.ToString() == "ʹ��ϵͳģ��") && Common.CheckLookUpEditBlank(drpReportModel))
                {
                    this.ShowMessage("������ϵͳģ��");
                    drpReportModel.Focus();
                    return false;
                }
                if ((drpReportModelType.EditValue.ToString() == "ʹ�ñ����ļ�") && txtFilePath.Text.Trim() == "")
                {
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

                }

            }
            if (!this.CheckCorrectDts())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            ReportManageDtsRule rule = new ReportManageDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            ReportManageRule rule = new ReportManageRule();
            ReportManage entity = EntityGet();
            ReportFile entityFile = new ReportFile();
            ReportFileModel entityFileModel = new ReportFileModel();
            if (drpReportModelType.EditValue.ToString() == "ʹ��ϵͳģ��")
            {
                entityFileModel.ID = SysConvert.ToInt32(drpReportModel.EditValue);
                entityFileModel.SelectByID();
                entityFile.Context = entityFileModel.Context;
                entityFile.FileName = txtFileName.Text.Trim();
            }
            if (drpReportModelType.EditValue.ToString() == "ʹ�ñ����ļ�")
            {
                entityFile.Context = HttSoft.WinUIBase.FastReport.ConvertToBinaryByPath(txtFilePath.Text.Trim());
                entityFile.FileName = txtFileName.Text.Trim();
            }
            ReportManageDts[] entitydts = EntityDtsGet();
            //entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts, entityFile);

            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ReportManageRule rule = new ReportManageRule();
            ReportManage entity = EntityGet();
            ReportManageDts[] entitydts = EntityDtsGet();
            ReportFile entityFile = new ReportFile();
            ReportFileModel entityFileModel = new ReportFileModel();
            if (drpReportModelType.EditValue.ToString() == "ʹ��ϵͳģ��")
            {
                entityFile.FileID = HTDataID;
                entityFile.SelectByCode();
                entityFileModel.ID = SysConvert.ToInt32(drpReportModel.EditValue);
                entityFileModel.SelectByID();
                if (OLDModelType != drpReportModel.EditValue.ToString())
                {
                    entityFile.Context = entityFileModel.Context;
                }
                entityFile.FileName = txtFileName.Text.Trim();
            }
            if (drpReportModelType.EditValue.ToString() == "ʹ�ñ����ļ�")
            {
                entityFile.FileID = HTDataID;
                entityFile.SelectByCode();
                if (HTFormStatus == FormStatus.����)
                {
                    entityFile.Context = HttSoft.WinUIBase.FastReport.ConvertToBinaryByPath(txtFilePath.Text.Trim());
                }
                if (HTFormStatus == FormStatus.�޸�)
                {
                    if (txtFilePath.Text.Trim() != "")
                    {
                        entityFile.Context = HttSoft.WinUIBase.FastReport.ConvertToBinaryByPath(txtFilePath.Text.Trim());
                    }
                }
                entityFile.FileName = txtFileName.Text.Trim();
            }
            //entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts, entityFile);

        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            ReportManage entity = new ReportManage();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();


            drpParentID.EditValue = entity.ParentID; 
  			drpWinListID.EditValue = entity.MenuID;
            txtWinListID.Text = entity.WinListID.ToString(); 
  			txtSeq.Text = entity.Seq.ToString();
            txtFileName.Text = entity.FileName.ToString();
  			txtReportName.Text = entity.ReportName.ToString(); 
            drpReportModelType.Text = entity.ModelType.ToString();
            drpReportModel.EditValue = entity.ModelID;  
  			txtRemark.Text = entity.Remark.ToString();
            txtHeadTypeID.Text = entity.HeadTypeID.ToString();
            txtSubTypeID.Text = entity.SubTypeID.ToString();
            OLDModelType = entity.ModelID.ToString();
            txtWinID.Text = entity.WinID.ToString();
           // HTDataSubmitFlag = entity.SubmitFlag;
            //HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ReportManageRule rule = new ReportManageRule();
            ReportManage entity = EntityGet();
            //FastReport.DeleteFile(entity.FileName);
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            //���ɱ����ļ���
            //FormNoControlRule rule = new FormNoControlRule();
            //txtFileName.Text = rule.RGetFormNo("Data_ReportManage", "FileName") + ".fr3";
            drpReportModelType.EditValue = "ʹ��ϵͳģ��";
            
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_ReportManage";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "DataSourceName" };//������ϸУ�����¼���ֶ�

            //��ģ��
            Common.BindParentForm(drpParentID, 0, false);
            Common.BindReportSource(drpReportSource, true);

            //�󶨱���ģ��
            Common.BindReportModel(drpReportModel, true);

            drpReportModelType_EditValueChanged(null, null);

            ProccessCommon.SetXTraTabColor(xtraTabControl1, this.BackColor);//���ñ���ɫ
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ReportManage EntityGet()
        {
            ReportManage entity = new ReportManage();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.ParentID = SysConvert.ToInt32(drpParentID.EditValue);//���ڵ�ID
            entity.MenuID = SysConvert.ToInt32(drpWinListID.EditValue);//�˵�ID
            entity.WinListID = SysConvert.ToInt32(txtWinListID.Text.Trim());
            entity.WinID = SysConvert.ToInt32(txtWinID.Text.Trim());//����ID Enum_WinForm
  			entity.Seq = SysConvert.ToInt32(txtSeq.Text.Trim()); 
  			entity.ReportName = txtReportName.Text.Trim();
            entity.HeadTypeID = SysConvert.ToInt32(txtHeadTypeID.Text.Trim());//�������
            entity.SubTypeID = SysConvert.ToInt32(txtSubTypeID.Text.Trim()); //����С��
  			entity.FileName = txtFileName.Text.Trim();

            //if (saveFileID == 0)
            if (entity.FileID == 0)
            {
                //���ɱ����ļ���
                //FormNoControlRule rule = new FormNoControlRule();
                //entity.FileName = rule.RGetFormNo((int)FormNoControlEnum.������ˮ��) + ".frx";
            }


            entity.ModelType = drpReportModelType.EditValue.ToString();
            entity.ModelID = SysConvert.ToInt32(drpReportModel.EditValue);
            entity.Url = "\\Report\\"; 
  			entity.Remark = txtRemark.Text.Trim();
            entity.MDate = DateTime.Now;
            entity.MUser = FParamConfig.LoginID;

            OLDModelType = entity.ModelID.ToString();
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ReportManageDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ReportManageDts[] entitydts = new ReportManageDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ReportManageDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].DataSourceName = SysConvert.ToString(gridView1.GetRowCellValue(i, "DataSourceName")); 
  			 		entitydts[index].SqlName = SysConvert.ToString(gridView1.GetRowCellValue(i, "SqlName")); 
  			 		entitydts[index].SqlStr = SysConvert.ToString(gridView1.GetRowCellValue(i, "SqlStr")); 
  			 		entitydts[index].QueryName = SysConvert.ToString(gridView1.GetRowCellValue(i, "QueryName")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].SqlFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SqlFlag"));
                    entitydts[index].SourceType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SourceType"));
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region �����¼�

        /// <summary>
        /// ����ģ�������Ӧ�Ĵ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpParentID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Common.CheckLookUpEditBlank(drpParentID))
                {
                    Common.BindWinList(drpWinListID, SysConvert.ToInt32(drpParentID.EditValue), false);
                }
                else
                {
                    drpWinListID.Properties.DataSource = null;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        /// <summary>
        /// ��ȡ����Ĵ���С��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpWinListID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string ClassName="";
                string WinListID = "";
                if (!Common.CheckLookUpEditBlank(drpWinListID))
                {
                    string sql = "select HeadTypeID,SubTypeID,ClassName,WinListID " +
                         " from UV1_Sys_WindowMenu " +
                         " where ID = " + SysString.ToDBString(drpWinListID.EditValue.ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        txtHeadTypeID.Text = dt.Rows[0]["HeadTypeID"].ToString();
                        txtSubTypeID.Text = dt.Rows[0]["SubTypeID"].ToString();
                        ClassName = dt.Rows[0]["ClassName"].ToString() + "Edit";
                        WinListID = dt.Rows[0]["WinListID"].ToString();
                        txtWinID.Text = dt.Rows[0]["WinListID"].ToString();
                    }
                    sql = " SELECT ID FROM Enum_WinList WHERE ClassName=" + SysString.ToDBString(ClassName);
                    DataTable dt2 = SysUtils.Fill(sql);
                    if (dt2.Rows.Count > 0)
                    {
                        txtWinListID.Text = dt2.Rows[0]["ID"].ToString();
                    }
                    else
                    {
                        txtWinListID.Text = WinListID;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void drpReportModelType_EditValueChanged(object sender, EventArgs e)
        {
            if (drpReportModelType.EditValue.ToString() == "ʹ��ϵͳģ��")
            {
                drpReportModel.Properties.ReadOnly = false;
                txtFilePath.Text = "";
                txtFilePath.Properties.ReadOnly = true;
                btnFileBrowse.Enabled = false;
            }
            else
            {
                drpReportModel.EditValue = null;
                drpReportModel.Properties.ReadOnly = true;
                txtFilePath.Properties.ReadOnly = false;
                btnFileBrowse.Enabled = true;
            }
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "(*.frx)|*.frx|(*.fr3)|*.fr3|(*.*)|*.*";
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
        #endregion   

    }
}