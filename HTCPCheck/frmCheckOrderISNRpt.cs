using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
//using HttSoft.HTCPCheck.Data;
//using HttSoft.HTCPCheck.DataCtl;
using HttSoft.HTERP.Sys;
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTCPCheck.DataCtl;

namespace HTCPCheck
{
    public partial class frmCheckOrderISNRpt : frmAPBaseUIRpt
    {
        public frmCheckOrderISNRpt()
        {
            InitializeComponent();
        }
        int[] IDS = new int[] { };

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            //
            if (txtSO.Text.Trim() != string.Empty)
            {
                tempStr += " AND CompactNo LIKE " + SysString.ToDBString("%" + txtSO.Text.Trim() + "%");
            }
            if (txtJarNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtJarNum.Text.Trim() + "%");
            }
          

            if (chkReqDate.Checked)
            {
                tempStr += " AND CheckDate BETWEEN" + SysString.ToDBString(txtReqDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtReqDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            if (ChkNoInWH.Checked)//ֻ��ѯδ��������
            {
                tempStr += " AND ISNULL(InWHFlag,0)=0 ";
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            CheckOrderISNRule rule = new CheckOrderISNRule();

            gridView1.Columns["CheckFlag"].OptionsColumn.ReadOnly = false;
            gridView1.Columns["CheckFlag"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["CheckFlag"].OptionsColumn.AllowFocus = true;
            HTDataConditionStr += " ORDER BY JarNum, Seq ASC";//JarNumCount
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("CheckFlag", "0 CheckFlag"));

            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            //BProductCheckRule rule = new BProductCheckRule();
            //BProductCheck entity = EntityGet();
            //rule.RDelete(entity);
        }

        /// <summary>
        /// ���ö�λ���ݼ�״̬
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Chk_CheckOrderISN";
            this.HTDataList = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };
            //IsPostBack = false;



            txtReqDateS.DateTime = DateTime.Now.AddDays(-30);
            txtReqDateE.DateTime = DateTime.Now;

            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;

            ProcessGrid.SetGridEdit(gridView1, "CheckFlag", true);

         


            //����������
            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "��ѡ���", true, btnLoad_Click);    //��ѡ�������

            //this.ToolBarItemAdd(28, "btnZToExcel", "�������鱨��", false, btnZToExcel_Click);
            //this.ToolBarItemAdd(28, "btnZToNewExcel", "�µ������鱨��", false, btnZToNewExcel_Click);

            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);

            btnPrintVisible = true;
        }


        /// <summary>
        ///ͨ�� ��������ʵ��1�������Ҫʹ�ã�����д��һ�㲻Ҫ�޸�
        /// </summary>
        public override void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            int p_ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));

            string sql = "select * from Chk_CheckOrderISNFault where MainID=" + p_ID;
            DataTable dt = SysUtils.Fill(sql);

            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }


        #endregion

        #region ��ѡ���
        /// <summary>
        /// ��ѡ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                //frmShowWH frm = new frmShowWH();
                //frm.ShowDialog();
                //string WHID = string.Empty;
                //string Section = string.Empty;
                //if (frm.ZResult == DialogResult.OK)
                //{
                //    WHID = frm.WHID;
                //    Section = frm.Section;
                //}
                //else
                //{
                //    this.ShowMessage("����ȡ��");
                //    return;
                //}

                //BProductCheckRule rule = new BProductCheckRule();
                //rule.RSubmitInWH(GetCheckItem(), WHID, Section);

                //this.ShowInfoMessage("��ⵥ���ɳɹ���");
                //btnQuery_Click(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �Զ��巽��



        private List<CheckOrderISN> GetCheckItem()
        {
            this.BaseFocusLabel.Focus();
            List<CheckOrderISN> list = new List<CheckOrderISN>();
            DataTable dt = gridView1.GridControl.DataSource as DataTable;
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (SysConvert.ToInt32(dr["CheckFlag"]) == 1)
                    {
                        CheckOrderISN entity = new CheckOrderISN();
                        entity.ID = SysConvert.ToInt32(dr["DID"]);
                        entity.SelectByID();
                        if (entity.StatusID <= (int)EnumBoxStatus.δ���)
                        {
                            list.Add(entity);
                        }
                    }
                }
            }

            return list;
        }
        #endregion


        private void drpCheckFlag_CheckedChanged(object sender, EventArgs e)
        {
            //CheckEdit chk = sender as CheckEdit;
            //if (chk.Checked)
            //{
            //    int ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));

            //    BProductCheckDts entity = new BProductCheckDts();
            //    entity.ID = ID;
            //    entity.SelectByID();
            //    if (entity.StatusID > (int)EnumISNStatus.��ʼ)
            //    {
            //        chk.Checked = false;
            //        this.ShowMessage("��ƥ�Ѿ���⣬����");
            //    }

            //}
        }

        private void tooltz_Click(object sender, EventArgs e)
        {

            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.ɾ��))
            {
                this.ShowMessage("��û�д˲���Ȩ��");
                return;
            }
            frmChecking frm = new frmChecking();
         
            //frm.WPFabricID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));
            //frm.WPPackOrderDtsID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
            //frm.WPFMFlag = true;
            frm.ShowDialog();
        }

        private void toolcj_Click(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.ɾ��))
            {
                this.ShowMessage("��û�д˲���Ȩ��");
                return;
            }

            //frmCDCJ frm = new frmCDCJ();
            //frm.ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));
            //frm.PackID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
            //frm.ShowDialog();
        }

        public override void btnDesign_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 0)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return;
            }

            DataTable[] dt = GetPrintSource();
            if (dt != null)
            {
                dt[0].TableName = "Main";
                dt[1].TableName = "Dts";
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.���, dt);
             
            }
        }

        public override void btnPreview_Click(object sender, EventArgs e)
        {

            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 0)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return;
            }
            DataTable[] dt = GetPrintSource();
            if (dt != null)
            {
                dt[0].TableName = "Main";
                dt[1].TableName = "Dts";
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.Ԥ��, dt);
            }


        }

        public override void btnPrint_Click(object sender, EventArgs e)
        {
            #region


            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 0)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return;
            }

            DataTable[] dt = GetPrintSource();
            if (dt != null)
            {
                dt[0].TableName = "Main";
                dt[1].TableName = "Dts";
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.��ӡ, dt);
            }

            #endregion

        }

        #region ������ӡ���鱨��

        #endregion

        #region  �����Զ�����
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //if (e.Column.FieldName == "YM")//�޸�ԭ��
                //{

                //    int DID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));

                //    CheckOrderISNRule rule = new CheckOrderISNRule();
                //    CheckOrderISN entity = new CheckOrderISN();
                //    entity.ID = DID;
                //    entity.SelectByID();

                //    if (SysConvert.ToDecimal(gridView1.GetFocusedRowCellValue("YM")) != entity.YM)
                //    {
                //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                //        {
                //            this.ShowMessage("��û�д˲���Ȩ��");
                //            return;
                //        }

                //        entity.YM = SysConvert.ToDecimal(gridView1.GetFocusedRowCellValue("YM"));
                //        rule.RUpdate(entity);

                //    }
                //}
                //if (e.Column.FieldName == "CheckFlag")
                //{
                //    if (SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("CheckFlag")) == 1)
                //    {
                //        int ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                //        for (int i = 0; i < gridView1.RowCount; i++)
                //        {
                //            if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "CheckFlag")) == 1)
                //            {
                //                if (ID != SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")))
                //                {
                //                    this.ShowMessage("�빴ѡͬһ�׺ţ�");
                //                    gridView1.SetFocusedRowCellValue("CheckFlag", 0);
                //                }
                //            }
                //        }
                //    }


                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.ɾ��))
            {
                this.ShowMessage("��û�д˲���Ȩ��");
                return;
            }

            if (MessageBox.Show("ȷ��Ҫɾ����ƥ����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            int ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));

            CheckOrderISN entity = new CheckOrderISN();
            entity.ID = ID;
            entity.SelectByID();
            if (entity.StatusID > (int)EnumBoxStatus.δ���)
            {

                this.ShowMessage("��ƥ�Ѿ���⣬����");
                return;
            }

            //if (entity.KF25 == 1)
            //{
            //    this.ShowMessage("��ƥ�����ݲ���ɾ��");
            //    return;
            //}

            //if (entity.KF22 == 1)
            //{
            //    this.ShowMessage("�˻������޸ĵ����ݲ���ɾ��");
            //    return;
            //}

            CheckOrderISNRule rule = new CheckOrderISNRule();
            rule.RDelete(entity);

            btnQuery_Click(null, null);

        }

        #region ����EXcel


        /// <summary>
        /// ����EXcel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnZToNewExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string CompactNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CompactNo"));
                string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorName"));
                string JarNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JarNum"));

                string OtherSO = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OtherSO"));

                string p_ExportFile = string.Empty;
                CheckOrderISNRule rule = new CheckOrderISNRule();
                GetCondtion();
                HTDataConditionStr += " AND CompactNo=" + SysString.ToDBString(CompactNo) + " AND ColorName=" + SysString.ToDBString(ColorName) + " AND JarNum=" + SysString.ToDBString(JarNum) + " AND Seq>0 " + " AND ISNULL(OtherSO,'')=" + SysString.ToDBString(OtherSO);
                HTDataConditionStr += " ORDER BY CompactNo,JarNum, JarNumCount ASC";//
                //DataTable dttem = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("CheckFlag", "0 CheckFlag").Replace("PF", "0.00 PF"));

                //TemplateExcel.JYToExcel(dttem, out p_ExportFile);

                //this.OpenFileNoConfirm(p_ExportFile);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ����EXcel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnZToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string CompactNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CompactNo"));
                string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorName"));
                string JarNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JarNum"));
                string OtherSO = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OtherSO"));

                DataTable dt = gridView1.GridControl.DataSource as DataTable;
                if (dt != null)
                {
                    dt.AcceptChanges();

                    string p_ExportFile = string.Empty;
                    DataRow[] item = dt.Select(" ISNULL(CompactNo,'')=" + SysString.ToDBString(CompactNo) + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(ColorName) + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(JarNum) + " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(ItemCode) + " AND ISNULL(OtherSO,'')=" + SysString.ToDBString(OtherSO) + " AND CheckFlag=1");
                    DataTable dttem = dt.Clone();
                    dttem.TableName = "Main";
                    foreach (DataRow dr in item)
                    {
                        dttem.ImportRow(dr);
                    }
                    //TemplateExcel.JYToExcel(dttem, out p_ExportFile);

                    //this.OpenFileNoConfirm(p_ExportFile);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region ��ȡӦ��ӡ������Դ

        private DataTable[] GetPrintSource()
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string ID = string.Empty;
                string DID = string.Empty;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "CheckFlag")) == 1)
                    {
                       

                        if (ID != string.Empty)
                        {
                            ID += ",";
                        }
                        ID += SysConvert.ToString(gridView1.GetRowCellValue(i, "ID"));
                        //if (DID != string.Empty)
                        //{
                        //    DID += ",";
                        //}
                        //DID += SysConvert.ToString(gridView1.GetRowCellValue(i, "DID"));

                    }
                    if (i == gridView1.RowCount - 1)
                    {
                        if (ID != string.Empty)
                        {
                            ID = "(" + ID + ")";
                        }
                        //if (DID != string.Empty)
                        //{
                        //    DID = "(" + DID + ")";
                        //}
                    }
                }

                string sql = "SELECT * FROM Chk_CheckOrderISN WHERE 1=1";
                if (ID != string.Empty)
                {
                    sql += " AND ID IN " + ID;
                }
                else
                {
                    return new DataTable[] { };
                }
                DataTable dt = SysUtils.Fill(sql);
                sql = "SELECT * FROM Chk_CheckOrderISNFault WHERE 1=1";
                if (ID != string.Empty)
                {
                    sql += " AND MainID IN " + ID;
                }
                else
                {
                    return new DataTable[] { };
                }
                //if (DID != string.Empty)
                //{
                //    sql += " AND DID IN " + DID;
                //}
                //else
                //{
                //    return new DataTable[] { };
                //}
                DataTable dt2 = SysUtils.Fill(sql);

                return new DataTable[] { dt, dt2 };
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
                return new DataTable[] { };
            }

        }
        #endregion

        private void tool4_Click(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.ɾ��))
            {
                this.ShowMessage("��û�д˲���Ȩ��");
                return;
            }

            if (MessageBox.Show("�޸ĵ�������ȷ�ϲ����Ѿ���ƥ�����ݣ���ƥ��������޷����޸ģ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            //frmModifyCompact frm = new frmModifyCompact();
            //frm.ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("DID"));
            //frm.ShowDialog();

        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
                    {
                        if (chkSelectAll.Checked)
                        {
                            gridView1.SetRowCellValue(i, "CheckFlag", 1);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, "CheckFlag", 0);
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

    }
}