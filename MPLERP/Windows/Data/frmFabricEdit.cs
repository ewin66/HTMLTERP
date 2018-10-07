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
    /// ���ܣ����͹���
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-18
    /// ����������
    /// </summary>
    public partial class frmFabricEdit : frmAPBaseUISinEdit
    {
        public frmFabricEdit()
        {
            InitializeComponent();
          //  this.BaseToolBar.Visible = false;
        }

        int SaveID = 0;
      
        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtISN.Text.Trim() == "")
            {
                this.ShowMessage("������ISN");
                txtISN.Focus();
                return false;
            }

            if (SysConvert.ToString(drpItemCode.EditValue)==string.Empty)
            {
                this.ShowMessage("��ѡ������");
                drpItemCode.Focus();
                return false;
            }          
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            FabricRule rule = new FabricRule();
            Fabric entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            FabricRule rule = new FabricRule();
            Fabric entity = EntityGet();

            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            Fabric entity = new Fabric();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtISN.Text = entity.ISN.ToString();
            drpItemCode.EditValue = entity.ItemCode.ToString();
            txtColorName.Text = entity.ColorName.ToString();
            txtColorNum.Text = entity.ColorNum.ToString();
            txtJarNum.Text = entity.JarNum.ToString();
            drpFlowerType.EditValue = entity.FlowerType.ToString();
            txtRemark.Text = entity.Remark.ToString();
             
           
            if (!findFlag)
            {
               
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FabricRule rule = new FabricRule();
            Fabric entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_Fabric";
            new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, txtItemModel, new int[] { (int)EnumItemType.���� }, true, true);
            this.BaseToolBar.Visible = false;

            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.ȫ�� }, true);//�ͻ�

            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//����UI��
            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);

            Common.BindFastReportList(drpReportItem, FormID, this.FormListAID);
            //
        }

        private void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            SaveID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
            txtPNum.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "PNum"));
            txtISN.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ISN"));
            drpVendorID.EditValue = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "VendorID"));
            drpItemCode.EditValue = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
            txtItemName.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemName"));
            txtItemStd.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemStd"));
            txtStyleNo.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "StyleNo"));
            txtColorName.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorName"));
            txtColorNum.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
            txtJarNum.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "JarNum"));
            txtMF.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "MF"));
        }


        public override void IniInsertSet()
        {
            //drpUseableFlag.EditValue = 1;
            
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Fabric EntityGet()
        {
            Fabric entity = new Fabric();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.ISN = txtISN.Text.Trim();//����
            entity.PNum = txtPNum.Text.Trim();
            entity.MakeOPName = ParamConfig.LoginName;
            entity.MakeDate = SysConvert.ToDateTime(txtMakeDate.DateTime);
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.StyleNo = txtStyleNo.Text.Trim(); 
            entity.ItemCode = SysConvert.ToString(drpItemCode.EditValue);
            entity.ItemName = txtItemName.Text.Trim();
            entity.ItemStd = txtItemStd.Text.Trim();
            entity.ColorName = txtColorName.Text.Trim();
            entity.ColorNum = txtColorNum.Text.Trim();
            entity.FlowerType = SysConvert.ToString(drpFlowerType.EditValue);
            entity.JarNum = txtJarNum.Text.Trim();
  			entity.Remark = txtRemark.Text.Trim(); //��ע
            entity.MF = txtMF.Text.Trim();
            entity.Length = SysConvert.ToDecimal(txtLength.Text.Trim());
            entity.Weight = SysConvert.ToDecimal(txtWeight.Text.Trim());
            entity.Shop = SysConvert.ToString(drpShop.EditValue);
            entity.JTNum = SysConvert.ToString(drpJTNum.EditValue);

             
  			
            return entity;
        }
        #endregion

        private void btnAddO_Click(object sender, EventArgs e)
        {
            txtPNum_DoubleClick(null, null);
            txtLength.Text = "";
            txtWeight.Text = "";
            txtMakeDate.DateTime = DateTime.Now;
            txtCheckDate.DateTime = DateTime.Now;
        }

        private void txtPNum_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnSaveO_Click(object sender, EventArgs e)
        {
            FabricRule rule = new FabricRule();
            Fabric entity = EntityGet();
            rule.RAdd(entity); 
        }

        private void btnUpdateO_Click(object sender, EventArgs e)
        {
            FabricRule rule = new FabricRule();
            Fabric entity = EntityGet();

            rule.RUpdate(entity);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            FabricRule rule = new FabricRule();
            Fabric entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            try
            {
                //   base.btnPreview_Click(sender, e);
                if (this.SaveID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }
                string sql = "SELECT * FROM UV1_Buy_YarnCompactJar WHERE ID=" + SaveID;
                DataTable dt = SysUtils.Fill(sql);
                int tempReportID = SysConvert.ToInt32(drpReportItem.EditValue);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.��ӡ, dt);
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
        private void btnDesign_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (SaveID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }
                string sql = "SELECT * FROM UV1_Buy_YarnCompactJar WHERE ID=" + SaveID;
                DataTable dt = SysUtils.Fill(sql);
                int tempReportID = SysConvert.ToInt32(drpReportItem.EditValue);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.���, dt);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// Ԥ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (SaveID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }
                string sql = "SELECT * FROM UV1_Buy_YarnCompactJar WHERE ID=" + SaveID;
                DataTable dt = SysUtils.Fill(sql);
                int tempReportID = SysConvert.ToInt32(drpReportItem.EditValue);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }

                HttSoft.WinUIBase.FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.Ԥ��, dt);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
    }
}