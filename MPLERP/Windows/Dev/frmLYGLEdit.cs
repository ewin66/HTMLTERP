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
    public partial class frmLYGLEdit : frmAPBaseUIFormEdit
    {
        public frmLYGLEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("������ɫ�����");
            //    txtCode.Focus();
            //    return false;
            //}
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("��˫�����ɵ���");
                txtFormNo.Focus();
                return false;
            }
            if (SysConvert.ToString(drpVendorID.EditValue) == ""&&txtLYVendorName.Text.Trim()=="")
            {
                this.ShowMessage("��ѡ�������ͻ�");
                drpVendorID.Focus();
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
            LYGLDtsRule rule = new LYGLDtsRule();
            DataTable dtDts = rule.RShowDts(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            LYGLRule rule = new LYGLRule();
            LYGL entity = EntityGet();
            LYGLDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            LYGLRule rule = new LYGLRule();
            LYGL entity = EntityGet();
            LYGLDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            LYGL entity = new LYGL();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtMakeOPName.Text = entity.MakeOPName;
            txtPostCode.Text = entity.PostCode;
            drpPostComID.EditValue = entity.PostComID;
            txtRecName.Text = entity.RecName;
            txtRecPhone.Text = entity.RecPhone;
            txtRemark.Text = entity.Remark;
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpVendorID.EditValue = entity.VendorID;
            txtLYVendorName.Text = entity.LYVendorName.ToString();

            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
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
            LYGLRule rule = new LYGLRule();
            LYGL entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Dev_LYGL", "FormNo", 0, p_Flag);
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_LYGL";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "GBCode" };//������ϸУ�����¼���ֶ�
            Common.BindDOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            new VendorProc(drpVendorID);
            Common.BindVendor(drpPostComID, new int[] { (int)EnumVendorType.��ݹ�˾ }, true);
            new VendorProc(drpPostComID);
            Common.BindCLS(txtSaleQYSource, "Dev_LYGLDts", "SaleQYSource", true);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, btnLoad_Click);
            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "���عҰ���¼��", false, btnLoadIO_Click);

        }

        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadItemGB frm = new frmLoadItemGB();
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID != null && frm.GBID.Length != 0)
                    {

                        for (int i = 0; i < frm.GBID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.GBID[i]);
                        }
                        setItemNews(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void btnLoadIO_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadGBJCLR frm = new frmLoadGBJCLR();
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID != null && frm.GBID.Length != 0)
                    {

                        for (int i = 0; i < frm.GBID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.GBID[i]);
                        }
                        setItemNewsJCLR(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        

        private void setItemNews(string str)
        {
            string[] arr = str.Split(',');
            int index = gridView1.FocusedRowHandle;
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV1_Data_ItemGB WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    //gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GBCode", SysConvert.ToString(dt.Rows[0]["GBCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    if (SysConvert.ToString(dt.Rows[0]["MWidth"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWidth", DBNull.Value);
                    }
                    if (SysConvert.ToString(dt.Rows[0]["MWeight"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWeight", DBNull.Value);
                    }
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));

                }
                length++;
            }
        }

        private void setItemNewsJCLR(string str)
        {
            string[] arr = str.Split(',');
            int index = gridView1.FocusedRowHandle;
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV2_Dev_GBJCLRDts WHERE DevDtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    //gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GBCode", SysConvert.ToString(dt.Rows[0]["GBCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    if (SysConvert.ToString(dt.Rows[0]["MWidth"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWidth", DBNull.Value);
                    }
                    if (SysConvert.ToString(dt.Rows[0]["MWeight"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "MWeight", DBNull.Value);
                    }
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));

                }
                length++;
            }
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private LYGL EntityGet()
        {
            LYGL entity = new LYGL();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.FormDate = DateTime.Now.Date;
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            entity.PostComID = SysConvert.ToString(drpPostComID.EditValue);
            entity.PostCode = txtPostCode.Text.Trim();
            entity.RecName = txtRecName.Text.Trim();
            entity.RecPhone = txtRecPhone.Text.Trim();
            entity.LYVendorName = txtLYVendorName.Text.Trim();


            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private LYGLDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            LYGLDts[] entitydts = new LYGLDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new LYGLDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;

                    entitydts[index].GBCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GBCode"));
                    entitydts[index].JQDesc = SysConvert.ToString(gridView1.GetRowCellValue(i, "JQDesc"));
                    entitydts[index].PBFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PBFlag"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].SalePriceDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "SalePriceDate"));
                    entitydts[index].SalePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SalePrice"));
                    entitydts[index].SaleQYSource = SysConvert.ToString(gridView1.GetRowCellValue(i, "SaleQYSource"));

                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].MWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].JYFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "JYFlag"));
                    index++;
                }
            }
            return entitydts;
        }

        #endregion



        #region �����¼�
        /// <summary>
        /// ˫���õ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��������);
                    ProductCommon.FormNoIniSet(txtFormNo, "Dev_LYGL", "FormNo",0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ����ɨ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScanCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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
                int rowHand = GetRowHand(ScanCode);
                if (rowHand < 0)
                {
                    return;
                }
                else
                {
                    string sql = "SELECT ColorNum,ColorName,MWidth,MWeight,WeightUnit,GoodsCode,ItemName,ItemCode FROM UV1_Data_ItemGB WHERE GBCode=" + SysString.ToDBString(ScanCode);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(rowHand, "GBCode", ScanCode);
                        gridView1.SetRowCellValue(rowHand, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                        gridView1.SetRowCellValue(rowHand, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                        gridView1.SetRowCellValue(rowHand, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                        gridView1.SetRowCellValue(rowHand, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                        gridView1.SetRowCellValue(rowHand, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                        gridView1.SetRowCellValue(rowHand, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                        gridView1.SetRowCellValue(rowHand, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                        gridView1.SetRowCellValue(rowHand, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    }

                }

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

        private void frmLYGLEdit_Load(object sender, EventArgs e)
        {

        }
        #endregion


        #region ������ӡ

        /// <summary>
        /// ��ӡ��������
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            if (HTDataID == 0)
            {
                this.ShowMessage("���ȱ������ݺ��ӡ");
                return false;
            }
            string IDStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "JYFlag")) == 1)
                {
                    if (IDStr != "")
                    {
                        IDStr += ",";
                    }
                    IDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DtsID"));
                }
            }

            if (IDStr == "")
            {
                this.ShowMessage("û��������Ҫ��ӡ");
                return false;
            }


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


            FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { IDStr });
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

                btnPrintAbount((int)ReportPrintType.Ԥ��);


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

                btnPrintAbount((int)ReportPrintType.��ӡ);

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
                //base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.���);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

    }
      


}
