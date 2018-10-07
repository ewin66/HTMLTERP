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
    /// ���ܣ��Ұ���������
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-20
    /// ����������
    /// </summary>
    public partial class frmGBJCLREdit : frmAPBaseUIFormEdit
    {
        public frmGBJCLREdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("�����뵥��");
                txtFormNo.Focus();
                return false;
            }

            //if (drpVendorID.Text == "")
            //{
            //    this.ShowMessage("��ѡ��ͻ�");
            //    drpVendorID.Focus();
            //    return false;
            //}


            return true;
        }
        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            GBJCLRRule rule = new GBJCLRRule();
            GBJCLR entity = EntityGet();
            // GBJCLRDts[] entityDts = EntityDtsGet();
            rule.RAdd(entity);
            return entity.ID;

        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            GBJCLRRule rule = new GBJCLRRule();
            GBJCLR entity = EntityGet();
            //GBJCLRDts[] entityDts = EntityDtsGet();
            rule.RUpdate(entity);
        }



        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            GBJCLR entity = new GBJCLR();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpVendorID.EditValue = entity.VendorID;
            txtRemark.Text = entity.Remark.ToString();
            txtMakeOPName.Text = entity.MakeOPName;
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }
            BindGrid();
        }


        private void BindGrid()
        {
            GBJCLRDtsRule rule = new GBJCLRDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();




        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            GBJCLRRule rule = new GBJCLRRule();
            GBJCLR entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataDts, new string[] { "SelectFlag" }, true);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_GBJCLR";
            this.HTDataDts = gridView1;
            Common.BindGBStatus(repGBStatus, true);
            Common.BindDOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            new VendorProc(drpVendorID);
            Common.BindGBStatus2(drpGBStatusID, true);
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);
        }

        private void gridViewRowChanged1(object sender)
        {
            BaseFocusLabel.Focus();
            ColumnView view = sender as ColumnView;
            ProcessGrid.SetFormValue(this, view);
            string GBCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["GBCode"]));

            byte[] pic = GetPic(GBCode);
            if (pic != null)
            {
                img1.Image = TemplatePic.ByteToImage(pic);
            }
            else
            {
                img1.Image = null;
            }
            GetItemLabel(GBCode);

            string sql = "SELECT JCTime,VendorAttn FROM UV1_Dev_GBJCLRDts WHERE GBCode=" + SysString.ToDBString(GBCode);
            sql += " ORDER BY JCTime DESC";
            DataTable dt = SysUtils.Fill(sql);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();

        }

        private void GetItemLabel(string GBCode)
        {
            string sql = "SELECT * FROM UV1_Data_ItemGB WHERE GBCode=" + SysString.ToDBString(GBCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                lbItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                lbGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                lbVendorID.Text = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                lbColorNum.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                lbColorName.Text = SysConvert.ToString(dt.Rows[0]["ColorName"]);
            }
        }

        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtFormNo_DoubleClick(null, null);
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private GBJCLR EntityGet()
        {
            GBJCLR entity = new GBJCLR();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = DateTime.Now.Date;
            entity.Remark = txtRemark.Text.Trim();
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
            entity.MakeDate = txtMakeDate.DateTime;
            if (this.HTFormStatus == FormStatus.����) //���������Ұ���ҳ�� �䵥������FormListID��zjh 2013.11.14
            {
                entity.FormListID = this.FormListAID;
            }
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private GBJCLRDts[] EntityDtsGet()
        {
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) != string.Empty)
                {
                    Num++;
                }
            }
            GBJCLRDts[] entitydts = new GBJCLRDts[Num];
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) != string.Empty)
                {
                    entitydts[index] = new GBJCLRDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); ;
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;


                    entitydts[index].GBCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode"));//�Ұ����� 
                    entitydts[index].GBStatusID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "GBStatusID"));//�Ұ�״̬
                    entitydts[index].JCTime = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "JCTime"));//���ʱ��
                    entitydts[index].GHTime = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "GHTime"));//�黹ʱ��
                    entitydts[index].GHOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "GHOPID"));//�黹������
                    entitydts[index].LYFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "LYFlag"));//������־
                    entitydts[index].LYVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "LYVendorID"));//�����ͻ�����
                    entitydts[index].LYVendorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "LYVendorName"));//�����ͻ�����

                    index++;

                }
            }
            return entitydts;
        }



        #endregion

        #region ����ɨ�����
        /// <summary>
        /// ɨ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScanCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (HTFormStatus != FormStatus.��ѯ)
                    {
                        this.ShowMessage("���ȱ�����ɨ��");
                        txtScanCode.Text = string.Empty;
                        return;
                    }

                    if (HTDataSubmitFlag != (int)YesOrNo.No)
                    {
                        this.ShowMessage("ֻ��δ�ύ������ɨ��");
                        txtScanCode.Text = string.Empty;
                        return;
                    }

                    string ScanCode = txtScanCode.Text.Trim();
                    txtScanCode.Text = string.Empty;
                    if (ScanCode == string.Empty)
                    {
                        this.ShowMessage("��ɨ��Ұ�������");
                        return;
                    }
                    if (!checkScanCode(ScanCode))
                    {
                        this.ShowMessage("�Ұ������벻���ڣ����������ɨ��");
                        return;
                    }
                    if (!CheckDouble(ScanCode))
                    {
                        this.ShowMessage("�����ظ�ɨ��");
                        return;
                    }
                    //if (!checkSameGB(ScanCode)) //�����Ǳ����������������ظ�ɨ�裬sc 2013.12.18
                    //{
                    //    return;
                    //}
                    //if (!checkScanStatus(ScanCode))
                    //{
                    //    return;
                    //}

                    //������ϸ����
                    GBJCLRDts entity = new GBJCLRDts();
                    GBJCLRDtsRule rule = new GBJCLRDtsRule();
                    entity.MainID = this.HTDataID;
                    entity.Seq = SelectSeq(HTDataID);
                    entity.GBCode = ScanCode;//�Ұ����� 
                    entity.GBStatusID = (int)EnumGBStatus.���;//�Ұ�״̬
                    entity.JCTime = DateTime.Now.Date;//���ʱ��
                    entity.GHOPID = "";//�黹������
                    entity.LYVendorID = "";//�����ͻ�����
                    entity.LYVendorName = "";//�����ͻ�����
                    rule.RAdd(entity);
                    BindGrid();
                    ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { ScanCode });
                    txtScanCode.Focus();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ��������õ�ͼƬ
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        private byte[] GetPic(string p_Code)
        {
            string sql = "SELECT GBPic FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_Code);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return (byte[])dt.Rows[0]["GBPic"];
            }
            else
            {
                return null;
            }
        }
        private int GetGBStatus(string p_ScanCode)
        {
            string sql = "SELECT GBStatusID FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_ScanCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }
        private bool CheckDouble(string p_ScanCode)
        {
            string sql = "select * from Dev_GBJCLRDts where MainID=" + this.HTDataID + " and GBCode='" + p_ScanCode + "'";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
        private int SelectSeq(int id)
        {
            string sql = "select max(Seq) from Dev_GBJCLRDts where MainID=" + id + "";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count < 1)
            {
                return 1;
            }
            else
            {
                return SysConvert.ToInt32(dt.Rows[0][0]) + 1;
            }
        }
        /// <summary>
        /// �õ�ɨ�赽�ĸ�ֵ��
        /// </summary>
        /// <param name="p_ScanCode"></param>
        /// <returns></returns>
        private int GetRowHand(string p_ScanCode)
        {
            int rowHand = -1;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) == p_ScanCode)
                {
                    return rowHand;
                }
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode")) == string.Empty)
                {
                    rowHand = i;
                    return rowHand;
                }
            }
            return -1;
        }

        /// <summary>
        /// У��Ұ��������Ƿ����
        /// </summary>
        /// <param name="p_ScanCode"></param>
        /// <returns></returns>
        private bool checkScanCode(string p_ScanCode)
        {
            string sql = "SELECT GBCode FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_ScanCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// У��Ұ�״̬
        /// </summary>
        /// <param name="p_ScanCode"></param>
        /// <returns></returns>
        private bool checkScanStatus(string p_ScanCode)
        {
            string sql = "SELECT GBStatusID FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_ScanCode);
            DataTable dt = SysUtils.Fill(sql);
            int GBStatusID = SysConvert.ToInt32(dt.Rows[0][0]);
            switch (GBStatusID)
            {
                case (int)EnumGBStatus.��ʧ:
                    this.ShowMessage("�Ұ�[" + p_ScanCode + "]���ڶ�ʧ״̬�����ܽ��");
                    return false;
                case (int)EnumGBStatus.�黹:
                    return true;
                case (int)EnumGBStatus.���:
                    this.ShowMessage("�Ұ�[" + p_ScanCode + "]�Ѵ��ڽ��״̬�����ܽ��");
                    return false;
                case (int)EnumGBStatus.����:
                    this.ShowMessage("�Ұ�[" + p_ScanCode + "]�Ѵ�������״̬�����ܽ��");
                    return false;
                case (int)EnumGBStatus.�ڿ�:
                    return true;

            }
            return true;
        }


        private bool checkSameGB(string p_ScanCode)
        {
            string sql = "SELECT ID FROM UV2_Dev_GBJCLRDts WHERE GBCode=" + SysString.ToDBString(p_ScanCode);
            DataTable dt = new DataTable();
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                this.ShowMessage("�Ұ�[" + p_ScanCode + "]���н��¼�룬�����ظ�����");
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// ˫����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.�Ұ���¼�뵥��);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �ύ/�����ύ
        /// <summary>
        /// �ύ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                GBJCLRRule rule = new GBJCLRRule();
                rule.RSubmit(HTDataID, 1);

                FCommon.AddDBLog(this.Text, FormStatus.�ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// �����ύ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmitCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                GBJCLRRule rule = new GBJCLRRule();
                rule.RSubmit(HTDataID, 0);

                FCommon.AddDBLog(this.Text, FormStatus.�ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region ��ӡ

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpGBStatusID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID != 0)
                {
                    string sql = "SELECT * FROM Dev_GBJCLRDts WHERE MainID=" + SysConvert.ToInt32(HTDataID);
                    if (SysConvert.ToInt32(drpGBStatusID.EditValue) != 0)
                    {
                        sql += " AND GBStatusID=" + SysString.ToDBString(SysConvert.ToInt32(drpGBStatusID.EditValue));
                    }
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ��ӡ��������
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 1)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }
            string sql = "SELECT * FROM UV2_Dev_GBJCLRDts WHERE 1=1";
            if (SysConvert.ToInt32(drpGBStatusID.EditValue) != 0)
            {
                sql += " AND GBStatusID=" + SysString.ToDBString(SysConvert.ToInt32(drpGBStatusID.EditValue));
            }
            sql += " AND MainID=" + SysConvert.ToInt32(HTDataID);

            DataTable dt = SysUtils.Fill(sql);

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dt);

            return true;
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                // base.btnPreview_Click(sender, e);
                if (HTDataID != 0)
                {
                    btnPrintAbount((int)ReportPrintType.Ԥ��);
                }


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                //base.btnPrint_Click(sender, e);
                if (HTDataID != 0)
                {
                    btnPrintAbount((int)ReportPrintType.��ӡ);
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID != 0)
                {
                    //base.btnDesign_Click(sender, e);
                    btnPrintAbount((int)ReportPrintType.���);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion


        private void btnLYVendor_Click(object sender, EventArgs e)
        {
            try
            {
                string GBIDStr = "";
                this.BaseFocusLabel.Focus();
                frmUpdateLYLRVendor frm = new frmUpdateLYLRVendor();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                    {

                        if (GBIDStr != "")
                        {
                            GBIDStr += "or";
                        }
                        GBIDStr += " (MainID = " + SysConvert.ToString(gridView1.GetRowCellValue(i, "MainID"));
                        GBIDStr += " AND";
                        GBIDStr += " Seq = " + SysConvert.ToString(gridView1.GetRowCellValue(i, "Seq")) + ")";
                    }
                }
                frm.GBCode = GBIDStr;
                frm.ShowDialog();
                BindGrid();

                ProcessGrid.GridViewFocus(gridView1, new string[] { "GBCode" }, new string[] { GBIDStr });

                //ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { frm.GBCode.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)//��������ͻ�����sc 2013.11.13
        {
            IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
            try
            {
                sqlTrans.OpenTrans();
                this.BaseFocusLabel.Focus();
                string sql = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                    {

                        sql = "Update Dev_GBJCLRDts set LYVendorID = '',LYVendorName = '' ";
                        sql += "WHERE (MainID = " + SysConvert.ToString(gridView1.GetRowCellValue(i, "MainID"));
                        sql += " AND";
                        sql += " Seq = " + SysConvert.ToString(gridView1.GetRowCellValue(i, "Seq")) + ")";
                        sqlTrans.ExecuteNonQuery(sql);
                    }

                }
                sqlTrans.CommitTrans();

                BindGrid();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void frmGBJCLREdit_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    GBJCLR entity = new GBJCLR();
                    entity.ID = HTDataID;
                    entity.SelectByID();
                    //if (entity.SubmitFlag == 0)
                    //{
                    //    if (DialogResult.Yes != ShowConfirmMessage(this.Text + Environment.NewLine + "û���ύ����,�Ƿ�ȷ�Ϲرմ���"))
                    //  {
                    //    e.Cancel = true;
                    //  }
                    //}
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }




    }
}