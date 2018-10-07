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
    public partial class frmProductCheckEdit : frmAPBaseUIFormEdit
    {
        public frmProductCheckEdit()
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
                this.ShowMessage("�����뵥��");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpShopID.EditValue) == "")
            {
                this.ShowMessage("��ѡ�������λ");
                drpShopID.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��������λ");
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
            ProductCheckDtsRule rule = new ProductCheckDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            ProductCheckRule rule = new ProductCheckRule();
            ProductCheck entity = EntityGet();
            ProductCheckDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            ProductCheckRule rule = new ProductCheckRule();
            ProductCheck entity = EntityGet();
            ProductCheckDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            ProductCheck entity = new ProductCheck();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString();
            drpShopID.EditValue = entity.ShopID;
  			txtFormDate.DateTime = entity.FormDate;
            drpCheckOPID.EditValue = entity.CheckOPID;
  			txtBuyFormNo.Text = entity.BuyFormNo.ToString();
            drpVendorID.EditValue = entity.VendorID;
  			txtRemark.Text = entity.Remark.ToString();
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
            ProductCheckRule rule = new ProductCheckRule();
            ProductCheck entity = EntityGet();
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
           
            txtFormDate.DateTime = DateTime.Now;
            drpCheckOPID.EditValue = FParamConfig.LoginID;
            txtFormNo_DoubleClick(null, null);
            base.IniInsertSet();

        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.���� }, true);
            new VendorProc(drpVendorID);
            Common.BindVendor(drpShopID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            new VendorProc(drpShopID);
            //Common.BindEnumUnit(txtUnit, true);

            Common.BindCLS(txtUnit, "Data_Item", "ItemUnitFab", true);
            Common.BindOP(drpCheckOPID, true);
            this.HTDataTableName = "Att_ProductCheck";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode"};//������ϸУ�����¼���ֶ�
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, btnLoad_Click);
            

        }


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

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ProductCheck EntityGet()
        {
            ProductCheck entity = new ProductCheck();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
            entity.MakeDate = DateTime.Now.Date;
            entity.CheckOPID = SysConvert.ToString(drpCheckOPID.EditValue);
            entity.ShopID = SysConvert.ToString(drpShopID.EditValue);
  			entity.FormDate = txtFormDate.DateTime.Date;
            entity.CheOPID = SysConvert.ToString(drpCheckOPID.EditValue);
  			entity.BuyFormNo = txtBuyFormNo.Text.Trim();
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
  			entity.Remark = txtRemark.Text.Trim(); 
  			 
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ProductCheckDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ProductCheckDts[] entitydts = new ProductCheckDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ProductCheckDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;

                    entitydts[index].PS = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PS")); 
  			 		entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum")); 
  			 		entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName")); 
  			 		entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode")); 
  			 		entitydts[index].RecQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "RecQty")); 
  			 		entitydts[index].CheckGQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckGQty")); 
  			 		entitydts[index].CheckQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckQty"));
                    entitydts[index].CheckCQty = entitydts[index].CheckQty - entitydts[index].RecQty; 
  			 		entitydts[index].CheckQQty1 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckQQty1")); 
  			 		entitydts[index].CheckQQty2 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckQQty2")); 
  			 		entitydts[index].CheckQQty3 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckQQty3")); 
  			 		entitydts[index].CheckQQty4 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckQQty4")); 
  			 		entitydts[index].CheckQQty5 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckQQty5")); 
  			 		entitydts[index].CheckQQty6 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckQQty6")); 
  			 		entitydts[index].CheckQQty7 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckQQty7")); 
  			 		entitydts[index].CheckQQty8 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckQQty8")); 
  			 		entitydts[index].CheckQQty9 = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckQQty9")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].MWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit")); 
  			 		 
                    
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
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��Ʒ���鵥��);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void restxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadItemBuy frm = new frmLoadItemBuy();
                    frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
                    {
                        
                        for (int i = 0; i < frm.ItemBuyID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.ItemBuyID[i]);
                        }
                        SetGrid(str);

                    }




                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ���زɹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void SetGrid(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//���������к�
            string[] itembuyid = p_Str.Split(',');
            int index = checkRowSet();
            int length = 0;
            for (int i = index; i < itembuyid.Length+index; i++)
            {
                string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[length]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    if (i == 0)
                    {
                        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["ShopID"]);
                    }
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(i, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(i, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));

                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));

                    drpShopID.EditValue = SysConvert.ToString(dt.Rows[0]["DVendorID"]);
                    drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["ShopID"]);
                    txtBuyFormNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    
                }
                length++;
            }
        }

        private int checkRowSet()
        {
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == string.Empty)
                {
                    index = i;
                    return index;
                }
            }
            return index;

        }

       
     


        #region �����¼�
       
        #endregion


    }
}