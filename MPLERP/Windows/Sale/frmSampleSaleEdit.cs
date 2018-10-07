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
using DevExpress.XtraGrid.Views.Base;

namespace MLTERP
{
    public partial class frmSampleSaleEdit : frmAPBaseUIFormEdit
    {
        public frmSampleSaleEdit()
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
                this.ShowMessage("��˫�����ɵ���");
                txtFormNo.Focus();
                return false;
            }
            if (drpVendorID.Text.Trim() == "")
            {
                this.ShowMessage("��ѡ��ͻ�");
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
            SampleSaleDtsRule rule = new SampleSaleDtsRule();
            DataTable dtDts = rule.RShowDts(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            SampleSaleRule rule = new SampleSaleRule();
            SampleSale entity = EntityGet();
            SampleSaleDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            SampleSaleRule rule = new SampleSaleRule();
            SampleSale entity = EntityGet();
            SampleSaleDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            SampleSale entity = new SampleSale();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            drpMakeOPID.EditValue = entity.MakeOPID;
            //txtMakeOPID.Text = entity.MakeOPID.ToString(); 
            txtMakeDate.DateTime = entity.MakeDate;
            drpSampleType.EditValue = entity.SampleType;
            //txtSampleType.Text = entity.SampleType.ToString(); 
            drpVendorID.EditValue = entity.VendorID;
            //txtVendorID.Text = entity.VendorID.ToString(); 
            txtReqDate.DateTime = entity.ReqDate;
            drpSaleOPID.EditValue = entity.SaleOPID;
            //txtSaleOPID.Text = entity.SaleOPID.ToString(); 
            txtRemark.Text = entity.Remark.ToString();
            txtPickUp.Text = entity.PickUp.ToString();
            txtAddress.Text = entity.Address.ToString();
            drpPayMothodFlag.EditValue = entity.PayMethodFlag;


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
            SampleSaleRule rule = new SampleSaleRule();
            SampleSale entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            if (p_Flag)//����༭״̬������ɫ��ѡ��
            {
                BindGridColor();
            }

        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtReqDate.DateTime = DateTime.Now.Date;
            drpMakeOPID.EditValue = FParamConfig.LoginID;
            txtFormNo_DoubleClick(null, null);
            txtPickUp.Text = "���";
            drpSaleOPID.Text = FParamConfig.LoginID;


        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SampleSale";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode", "Unit" };//������ϸУ�����¼���ֶ�
            //  this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "������Ϣ", false, btnLoad_Click);
            Common.BindSampleType(drpSampleType, true);

            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            //Common.BindVendorID(drpVendorID, true);
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.ҵ�� }, true);
            Common.BindOP(drpMakeOPID, true);
            Common.BindCLS(txtPickUp, "Sale_SampleSale", "PickUp", true);
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);

            Common.BindCLS(restxtunit, "Data_Item", "ItemUnitFab", true);

        }
        /// <summary>
        /// ��ʼ��ˢ������(�������ʱ���û�ˢ�°�ťʱ����)
        /// </summary>
        public override void IniRefreshData()
        {


            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.ҵ�� }, true);
            Common.BindPayMethod(drpPayMothodFlag, true);
            DevMethod.BindItem(drpItemCode, true);

        }
        private void gridViewRowChanged1(object sender)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                string GoodsCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "GoodsCode"));
                string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorName"));

                BindGridColor();
                this.gridView1.Focus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SampleSale EntityGet()
        {
            SampleSale entity = new SampleSale();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = SysConvert.ToString(drpMakeOPID.EditValue);
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.SampleType = SysConvert.ToInt32(drpSampleType.EditValue);
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.ReqDate = txtReqDate.DateTime.Date;
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.PayMethodFlag = SysConvert.ToInt32(drpPayMothodFlag.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            entity.PickUp = txtPickUp.Text.Trim();
            entity.Address = txtAddress.Text.Trim();
            //entity.PayMethodFlag = SysConvert.ToInt32(drpPayMothodFlag.EditValue);


            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SampleSaleDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            SampleSaleDts[] entitydts = new SampleSaleDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new SampleSaleDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum"));
                    entitydts[index].Flower = SysConvert.ToString(gridView1.GetRowCellValue(i, "Flower"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")) * SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].DRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DRemark"));
                    entitydts[index].DDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "DDate"));



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
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��Ʒ���۵���);
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
                    gridViewRowChanged1(gridView1);

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
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "FK", SysConvert.ToString(dt.Rows[0]["FK"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "Needle", SysConvert.ToString(dt.Rows[0]["Needle"]));

                }
            }
        }
        #endregion
        /// <summary>
        /// �������б��ڵ���ɫ�ؼ�
        /// </summary>
        void BindGridColor()
        {
            if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)//�������޸ģ�����ɫ��ɫ��
            {
                string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                Common.BindItemColor(drpGridColorNum, drpGridColorName, itemCode, true);//�������ϰ�ɫ��ɫ��
            }
        }
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "ItemCode")
                {
                    string itemCode = SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "ItemCode"));
                    if (itemCode != string.Empty)
                    {
                        string[] itemA = Common.GetItemArrayByCode(itemCode);
                        if (itemA.Length > 0)
                        {
                            gridView1.SetRowCellValue(e.RowHandle, "ItemName", itemA[1]);
                            gridView1.SetRowCellValue(e.RowHandle, "ItemStd", itemA[2]);
                            gridView1.SetRowCellValue(e.RowHandle, "ItemModel", itemA[3]);
                        }
                        BindGridColor();
                    }
                }
                if (e.Column.FieldName == "ColorNum")//ɫ�Ÿı䣬������ֵɫ��
                {
                    ColumnView view = sender as ColumnView;
                    string itemcode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                    string colornum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                    view.SetRowCellValue(view.FocusedRowHandle, "ColorName", Common.GetItemColorNameByColorNum(itemcode, colornum));
                }


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

    }
}