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
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ�������¼
    /// 
    /// </summary>
    public partial class frmFlowerTypeContolEdit : frmAPBaseUIFormEdit
    {
        public frmFlowerTypeContolEdit()
        {
            InitializeComponent();
        }

        int saveSeq = 0;

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("�����뻨��������");
                txtCode.Focus();
                return false;
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
            FlowerTypeContolDtsRule rule = new FlowerTypeContolDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            FlowerTypeContolRule rule = new FlowerTypeContolRule();
            FlowerTypeContol entity = EntityGet();
            FlowerTypeContolDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            //rule.RAdd(entity, entitydts);
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            FlowerTypeContolRule rule = new FlowerTypeContolRule();
            FlowerTypeContol entity = EntityGet();
            FlowerTypeContolDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            FlowerTypeContol entity = new FlowerTypeContol();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			 
  			txtCode.Text = entity.Code.ToString(); 
  			 
  			txtRemark.Text = entity.Remark.ToString();
            txtName.Text = entity.Name.ToString();
            {
               
            }

            BindGridDts();
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FlowerTypeContolRule rule = new FlowerTypeContolRule();
            FlowerTypeContol entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProcessCtl.ProcControlEdit(groupControl1, true);
            
            //ProcessCtl.ProcControlEdit(new Control[] { txtCode,txtMakeDate,txtMakeOPID}, false);
            
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            //txtMakeDate.DateTime = DateTime.Now.Date;
            //txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);
            //drpRecordOPID.EditValue = FParamConfig.LoginID;
            //txtRecordDate.DateTime = DateTime.Now.Date;

            //drpCompanyTypeID.EditValue = 1;

            //txtCode_DoubleClick(null,null);

           
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_FlowerTypeContol";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ColorCode" };//������ϸУ�����¼���ֶ�

            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//����UI��
            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);

            txtDHX.Enabled = true;
            txtDMS.Enabled = true;
            txtDJBBM.Enabled = true;
            txtDYS.Enabled = true;
            txtDML.Enabled = true;
            txtDSize.Enabled = true;
            txtJZ.Enabled = true;
            SetTabIndex(0, groupControlMainten);
      
        }

        #endregion

        private void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            saveSeq = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "Seq"));
            txtDHX.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorCode"));
            txtDMS.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Freestr1"));
            txtDJBBM.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Freestr2"));
            txtDYS.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Freestr3"));
            txtDML.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Freestr4"));
            txtDSize.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Freestr5"));
            txtJZ.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Freestr6"));
        }

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FlowerTypeContol EntityGet()
        {
            FlowerTypeContol entity = new FlowerTypeContol();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            
  			entity.Code = txtCode.Text.Trim();
            entity.Name = txtName.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FlowerTypeContolDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            FlowerTypeContolDts[] entitydts = new FlowerTypeContolDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new FlowerTypeContolDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].ColorCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorCode"));
                    entitydts[index].Freestr1 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr1"));
                    entitydts[index].Freestr2 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr2"));
                    entitydts[index].Freestr3 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr3"));
                    entitydts[index].Freestr4 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr4"));
                    entitydts[index].Freestr5 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr5"));
                    entitydts[index].Freestr6 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr6"));
                    entitydts[index].Freestr7 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr7"));
                    entitydts[index].Freestr8 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr8"));
                    entitydts[index].Freestr9 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr9"));
                    entitydts[index].Freestr10 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr10"));
                    entitydts[index].Freestr11 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr11"));
                    entitydts[index].Freestr12 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr12"));
                    entitydts[index].Freestr13 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr13"));
                    entitydts[index].Freestr14 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr14"));
                    entitydts[index].Freestr15 = SysConvert.ToString(gridView1.GetRowCellValue(i, "Freestr15")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

      

        #region �����¼�
        /// <summary>
        /// ������������Զ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    //txtCode.Text = rule.RGetFormNo((int)FormNoControlEnum.�����������);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void btnSaveD_Click_1(object sender, EventArgs e)
        {
            FlowerTypeContolDts entity = new FlowerTypeContolDts();
            entity.MainID = HTDataID;
            string sql = " SELECT MAX(Seq) from Data_FlowerTypeContolDts where MainID=" + entity.MainID;
            DataTable dt = SysUtils.Fill(sql);
            entity.Seq = SysConvert.ToInt32(dt.Rows[0][0]) + 1;
            entity.ColorCode = txtDHX.Text.Trim();
            entity.Freestr1 = txtDMS.Text.Trim();
            entity.Freestr2 = txtDJBBM.Text.Trim();
            entity.Freestr3 = txtDYS.Text.Trim();
            entity.Freestr4 = txtDML.Text.Trim();
            entity.Freestr5 = txtDSize.Text.Trim();
            entity.Freestr6 = txtJZ.Text.Trim();

            FlowerTypeContolDtsRule rule = new FlowerTypeContolDtsRule();
            rule.RAdd(entity);
            BindGridDts();
 
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            FlowerTypeContolDts entity = new FlowerTypeContolDts();
            entity.MainID = HTDataID;
            entity.Seq = saveSeq;
            FlowerTypeContolDtsRule rule = new FlowerTypeContolDtsRule();
            rule.RDelete(entity);
            BindGridDts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDHX.Text = "";
            txtDMS.Text = "";
            txtDJBBM.Text = "";
            txtDYS.Text = "";
            txtDML.Text = "";
            txtDSize.Text = "";
            txtJZ.Text = "";
            txtDHX.Enabled = true;
            txtDMS.Enabled = true;
            txtDJBBM.Enabled = true;
            txtDYS.Enabled = true;
            txtDML.Enabled = true;
            txtDSize.Enabled = true;
            txtJZ.Enabled = true;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            FlowerTypeContolDts entity = new FlowerTypeContolDts();
            entity.MainID = HTDataID;
            entity.Seq = saveSeq;
            entity.ColorCode = txtDHX.Text.Trim();
            entity.Freestr1 = txtDMS.Text.Trim();
            entity.Freestr2 = txtDJBBM.Text.Trim();
            entity.Freestr3 = txtDYS.Text.Trim();
            entity.Freestr4 = txtDML.Text.Trim();
            entity.Freestr5 = txtDSize.Text.Trim();
            entity.Freestr6 = txtJZ.Text.Trim();
            FlowerTypeContolDtsRule rule = new FlowerTypeContolDtsRule();
            rule.RUpdate(entity);
            BindGridDts();
        } 

        #region �����¼�����ӡ��أ�
        ///// <summary>
        ///// ���
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnPreview_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnPreview_Click(sender, e);
        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
        //            return;
        //        }

        //        DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
        //        int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
        //        if (tempReportID == 0)
        //        {
        //            this.ShowMessage("��ѡ�񱨱�ģ��");
        //            return;
        //        }
        //        FastReportX.ReportRun(tempReportID, (int)ReportPrintType.Ԥ��, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
        //    }
        //    catch
        //    {
        //    }
        //}
        ///// <summary>
        ///// ��ӡ
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnPrint_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnPrint_Click(sender, e);

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
        //            return;
        //        }

        //        DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
        //        int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
        //        if (tempReportID == 0)
        //        {
        //            this.ShowMessage("��ѡ�񱨱�ģ��");
        //            return;
        //        }
        //        FastReportX.ReportRun(tempReportID, (int)ReportPrintType.��ӡ, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
        //    }
        //    catch
        //    {
        //    }
        //}

        ///// <summary>
        ///// ���
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnDesign_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnDesign_Click(sender, e);
        //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.�ύ3))
        //        {
        //            this.ShowMessage("��û�д˲���Ȩ��");
        //            return;
        //        }
        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
        //            return;
        //        }

        //        DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
        //        int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
        //        if (tempReportID == 0)
        //        {
        //            this.ShowMessage("��ѡ�񱨱�ģ��");
        //            return;
        //        }
        //        FastReportX.ReportRun(tempReportID, (int)ReportPrintType.���, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
        //    }
        //    catch
        //    {
        //    }
        //}

        #endregion
    }
}