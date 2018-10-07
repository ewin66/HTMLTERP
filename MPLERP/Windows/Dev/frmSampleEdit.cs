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
    /// formlistAID=1 FormlistBID=1  ���� SO��
    /// formlistAID=1 FormlistBID=2  ���� ƥ��
    /// formlistAID=2 FormlistBID=1  ��� SO��
    /// formlistAID=2 FormlistBID=2  ��� ƥ��
    /// </summary>
    public partial class frmSampleEdit : frmAPBaseUIFormEdit
    {
        public frmSampleEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (drpSFormNo.EditValue== "")
            {
                this.ShowMessage("��ѡ������");
                drpSFormNo.Focus();
                return false;
            }
            if (drpSampleType.EditValue == "")
            {
                this.ShowMessage("��ѡ���������");
                drpSampleType.Focus();
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
            SampleDtsRule rule = new SampleDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            SampleRule rule = new SampleRule();
            Sample entity = EntityGet();
            SampleDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            SampleRule rule = new SampleRule();
            Sample entity = EntityGet();
            SampleDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            Sample entity = new Sample();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            txtFormNo.Text = entity.FormNo.ToString();
            drpSFormNo.EditValue = entity.SFormNo.ToString();//�������Ÿ�����
            txtFormDate.DateTime = entity.FormDate;
            drpSampleType.EditValue = entity.SampleType;
            drpSOType.EditValue = entity.SOType;
            drpFactoryID.EditValue = entity.FactoryID.ToString();
            txtReqDate.DateTime = entity.ReqDate;
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            txtPBItemCode.Text = entity.PBItemCode.ToString();
            txtPBDensity.Text = entity.PBDensity.ToString();
            txtPBMWidth.Text = entity.PBMWidth.ToString();
            txtPBMWeight.Text = entity.PBMWeight.ToString();
            drpFactoryID2.EditValue = entity.FactoryID2.ToString();
            txtCPItemCode.Text = entity.CPItemCode.ToString();
            txtCPDensity.Text = entity.CPDensity.ToString();
            txtCPMWidth.Text = entity.CPMWidth.ToString();
            txtAllMWidth.Text = entity.AllMWidth.ToString();
            txtCPMWeight.Text = entity.CPMWeight.ToString();
            drpFactoryID3.Text = entity.FactoryID3.ToString();
            drpLightSource.EditValue = entity.LightSource.ToString();
            drpLightSource2.EditValue = entity.LightSource2.ToString();
            drpLightSource3.EditValue = entity.LightSource3.ToString();
            txtPrintingMethod.Text = entity.PrintingMethod.ToString();
            drpTecReq.Text = entity.TecReq.ToString();
            txtPBQty.Text = entity.PBQty.ToString();
            txtBCPSampleQty.Text = entity.BCPSampleQty.ToString();
            txtPBSampleQty.Text = entity.PBSampleQty.ToString();
            txtMakeOPID.Text = entity.MakeOPID.ToString();
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            txtRemark.Text = entity.Remark.ToString();
            drpGenDan.EditValue = entity.GenDan.ToString();
            drpVendorOPID.EditValue = entity.VendorOPID.ToString();

            txtCPItemName.Text = entity.CPItemName.ToString();
            txtCPItemStd.Text = entity.CPItemStd.ToString();
            txtSO.Text = entity.SO.ToString();

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
            SampleRule rule = new SampleRule();
            Sample entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);


            //ProcessCtl.ProcControlEdit(new Control[] { drpSOType, drpSampleType }, false);���ò�������
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.Text = DateTime.Now.ToShortDateString();
            txtReqDate.Text = DateTime.Now.AddDays(10).ToShortDateString();
            txtMakeDate.Text = DateTime.Now.ToShortDateString();
            txtMakeOPID.Text = FParamConfig.LoginID;
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtFormNo_DoubleClick(null, null);

            // drpSampleType.EditValue = FormListBID;
            drpSOType.EditValue = FormListAID;
        }
        public override void IniRefreshData()
        {
            Common.BindCLS(restxtunit, "Data_Item", "ItemUnitFab", true);
            Common.BindOP(drpSaleOPID, (int)EnumOPDep.ҵ��, true);
            Common.BindOP(drpGenDan, (int)EnumOPDep.������, true);
            DevMethod.BindVendor(drpFactoryID, (int)EnumVendorType.�ͻ�, true);//�ͻ�
            DevMethod.BindVendor(drpFactoryID2, new int[] { (int)EnumVendorType.֯��, (int)EnumVendorType.��Ӧ�� }, true);//֯��ӹ�������Ӧ��
            DevMethod.BindVendor(drpFactoryID3, (int)EnumVendorType.Ⱦ��, true);//Ⱦ��
            Common.BindCLS(drpTecReq, "Dev_Sample", "TecReq", true);
            Common.BindSampleType(drpSampleType, true);
        }
        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_Sample";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ColorNum","ColorName" };//������ϸУ�����¼���ֶ�
            // Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);//ҵ��Ա
            
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "���ز�Ʒ", false, btnLoad_Click);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "���غ�ͬ", false, btnSOLoad_Click);
            // Common.BindSOType(drpSOType, true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Sample EntityGet()
        {
            Sample entity = new Sample();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.SFormNo = SysConvert.ToString(drpSFormNo.EditValue);
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.SampleType = SysConvert.ToInt32(drpSampleType.EditValue);
            entity.SOType = SysConvert.ToInt32(drpSOType.EditValue);
            entity.FactoryID = SysConvert.ToString(drpFactoryID.EditValue);
            entity.ReqDate = txtReqDate.DateTime.Date;
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.PBItemCode = txtPBItemCode.Text.Trim();
            entity.PBDensity = txtPBDensity.Text.Trim();
            entity.PBMWidth = txtPBMWidth.Text.Trim();
            entity.PBMWeight = txtPBMWeight.Text.Trim();
            entity.FactoryID2 = SysConvert.ToString(drpFactoryID2.EditValue);
            entity.CPItemCode = txtCPItemCode.Text.Trim();
            entity.CPDensity = txtCPDensity.Text.Trim();
            entity.CPMWidth = txtCPMWidth.Text.Trim();
            entity.AllMWidth = txtAllMWidth.Text.Trim();//��Ч�ŷ�
            entity.CPMWeight = txtCPMWeight.Text.Trim();
            entity.FactoryID3 = SysConvert.ToString(drpFactoryID3.EditValue);
            entity.LightSource = SysConvert.ToString(drpLightSource.EditValue);
            entity.LightSource2 = SysConvert.ToString(drpLightSource2.EditValue);
            entity.LightSource3 = SysConvert.ToString(drpLightSource3.EditValue);
            entity.PrintingMethod = txtPrintingMethod.Text.Trim();
            entity.TecReq = drpTecReq.Text.Trim();
            entity.PBQty = SysConvert.ToDecimal(txtPBQty.Text.Trim());
            entity.BCPSampleQty = SysConvert.ToDecimal(txtBCPSampleQty.Text.Trim());
            entity.PBSampleQty = SysConvert.ToDecimal(txtPBSampleQty.Text.Trim());
            entity.MakeOPID = txtMakeOPID.Text.Trim();
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.Remark = txtRemark.Text.Trim();
            entity.GenDan = SysConvert.ToString(drpGenDan.EditValue);
            entity.VendorOPID = SysConvert.ToString(drpVendorOPID.EditValue);
            entity.CPItemName = txtCPItemName.Text.Trim();
            entity.CPItemStd = txtCPItemStd.Text.Trim();
            entity.SO = txtSO.Text.Trim();
            


            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SampleDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            SampleDts[] entitydts = new SampleDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new SampleDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID"));
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//�Ѵ��ڱ�ʾ�޸�
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                        entitydts[index].SelectByID();
                    }
                    else//����
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }

                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].TPQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TPQty"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].FlowerType = SysConvert.ToString(gridView1.GetRowCellValue(i, "FlowerType"));
                    entitydts[index].EventStatus = "������";

                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));


                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    ProductCommon.FormNoIniSet(txtFormNo, "Dev_Sample", "FormNo", 0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void txtBCPSampleQty_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void drpFactoryID_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (SysConvert.ToString(drpFactoryID.EditValue) != string.Empty)
                {

                    Common.BindVendorContact(drpVendorOPID, SysConvert.ToString(drpFactoryID.EditValue), true);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        #region �����¼�
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                restxtItemCode_DoubleClick(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ˫����Ʒ������ز�Ʒ��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadFabric frm = new frmLoadFabric();
                    frm.SelectItemType = SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5413)); //0����ʾֻ֧�ּ��ز�Ʒ  1����ʾֻ֧��ѡ����ز�Ʒ��������  2:��ʾ����


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

        private void setItemNews(string str)
        {
            string[] gbid = str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    txtCPItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemModel"]);
                    txtCPItemName.Text = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                    txtCPItemStd.Text = SysConvert.ToString(dt.Rows[0]["ItemStd"]);
                    txtCPMWeight.Text = SysConvert.ToString(dt.Rows[0]["MWeight"]);
                    txtCPMWidth.Text = SysConvert.ToString(dt.Rows[0]["MWidth"]);
                    txtCPDensity.Text = SysConvert.ToString(dt.Rows[0]["Needle"]);

                }
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSOLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {

                    frmLoadOrder frm = new frmLoadOrder();
                    frm.CheckFlag2 = 1;

                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.OrderID != null && frm.OrderID.Length != 0)
                    {
                        
                        for (int i = 0; i < frm.OrderID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.OrderID[i]);
                        }
                        setItemNews2(str);

                    }

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews2(string p_Str)
        {
            string[] orderid = p_Str.Split(',');

            string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[0]));
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {

                txtSO.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);


                txtCPItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemModel"]);
                txtCPItemName.Text = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                txtCPItemStd.Text = SysConvert.ToString(dt.Rows[0]["ItemStd"]);
                txtCPDensity.Text = SysConvert.ToString(dt.Rows[0]["Needle"]);
                txtCPMWidth.Text = SysConvert.ToString(dt.Rows[0]["MWidth"]);
                txtCPMWeight.Text = SysConvert.ToString(dt.Rows[0]["MWeight"]);



            }

        }
        #endregion


    }
}