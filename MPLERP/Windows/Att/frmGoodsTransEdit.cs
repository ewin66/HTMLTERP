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
/// <summary>
/// ���ܣ��Ұ�������ѯ
/// ���ߣ�����÷
/// ���ڣ�2012-05-02
/// ����������                ˵���� ����ʱ�����ذ󶨻�δ��
/// </summary>
namespace MLTERP
{
    public partial class frmGoodsTransEdit : frmAPBaseUIFormEdit
    {
        public frmGoodsTransEdit()
        {
            InitializeComponent();
        }
        int saveNoLoadCheckDayNum = 0;//δ���رȶ���������ֹ����ʱ�������ϵͳ����

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
                this.ShowMessage("��������������");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpTransComID.EditValue) == "")
            {
                this.ShowMessage("��ѡ���ͻ���λ");
                drpTransComID.Focus();
                return false;
            }

            
            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ���ջ���λ");
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
            GoodsTransDtsRule rule = new GoodsTransDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            GoodsTransRule rule = new GoodsTransRule();
            GoodsTrans entity = EntityGet();
            GoodsTransDts[] entitydts = EntityDtsGet();
            decimal totalpieceqty = 0;
            decimal totalqty = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalpieceqty += entitydts[i].PieceQty;
                totalqty += entitydts[i].Qty;
            }
            entity.TotalPieceQty = totalpieceqty;
            entity.TotalQty = totalqty;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            GoodsTransRule rule = new GoodsTransRule();
            GoodsTrans entity = EntityGet();
            GoodsTransDts[] entitydts = EntityDtsGet();
            decimal totalpieceqty = 0;
            decimal totalqty = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalpieceqty += entitydts[i].PieceQty;
                totalqty += entitydts[i].Qty;
            }
            entity.TotalPieceQty = totalpieceqty;
            entity.TotalQty = totalqty;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            GoodsTrans entity = new GoodsTrans();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
            txtSendNo.Text = entity.SendNo.ToString();
            drpTransComID.EditValue = entity.TransComID;
  			txtTransFee.Text = entity.TransFee.ToString(); 
  			txtRLFee.Text = entity.RLFee.ToString();
            txtShopID.Text = entity.ShopID;
  			txtTHFee.Text = entity.THFee.ToString(); 
  			txtTHAddress.Text = entity.THAddress.ToString();
            drpVendorID.EditValue = entity.VendorID;
  			txtRecAddress.Text = entity.RecAddress.ToString();
            drpYSFlag.EditValue = entity.YSFlag;
            txtYSTime.Text = entity.YSTime.ToString();
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtFLC.Text = entity.FLC.ToString(); 
  			txtFSHSJD.Text = entity.FDT.ToString(); 
  			txtFSHSJD.Text = entity.FSHSJD.ToString(); 
  			txtFHWZZ.Text = entity.FHWZZ.ToString();
            drpFDTJ.EditValue = entity.FDTJ;
            drpFDT.EditValue = entity.FDT;
            drpFHDFlag.EditValue = entity.FHDFlag;
  			txtFHDDate.DateTime = entity.FHDDate;
            drpJSFlag.EditValue = entity.JSFlag;
  			txtJSDate.DateTime = entity.JSDate; 
  			txtJSFee.Text = entity.JSFee.ToString(); 
  			txtJSRemark.Text = entity.JSRemark.ToString();
            txtOtherFee.Text = entity.OtherFee.ToString();
            txtTotalAmount.Text = entity.TotalAmount.ToString();
            txtSJFHDate.DateTime = entity.SJFHDate;
            txtTotalPieceQty.Text = entity.TotalPieceQty.ToString();
            txtQty.Text = entity.TotalQty.ToString();
  			
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
            GoodsTransRule rule = new GoodsTransRule();
            GoodsTrans entity = EntityGet();
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
            txtFormNo_DoubleClick(null, null);
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFHDDate.DateTime = DateTime.Now.Date;
            txtJSDate.DateTime = DateTime.Now.Date;
            txtSJFHDate.DateTime = DateTime.Now.Date;
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Att_GoodsTrans";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode","GoodsCode"};//������ϸУ�����¼���ֶ�
            Common.BindVendor(drpTransComID, new int[] { (int)EnumVendorType.��ݹ�˾ }, true);
            new VendorProc(drpTransComID);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.���� }, true);
            new VendorProc(drpVendorID);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, btnLoad_Click);
            //Common.BindEnumUnit(txtResUnit, true);

            Common.BindCLS(txtResUnit, "Data_Item", "ItemUnitFab", true);

            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.δ�������ݱȶ�����);
            drpVendorID_EditValueChanged(null, null);
            

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
                //if (SysConvert.ToString(drpVendorID.EditValue) == string.Empty)
                //{
                //    this.ShowMessage("��ѡ���ջ���λ");
                //    drpVendorID.Focus();
                //    return;
                //}
                frmLoadFHForm frm = new frmLoadFHForm();
                frm.WL = true;
                string sql = string.Empty;
                sql += " AND SendCode+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(SendNo+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_Attn_GoodsTransDts";
                
                if (saveNoLoadCheckDayNum != 0)
                {
                    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
                }
                sql += ")";
                sql += " AND FormNo+ItemCode+ColorNum+ColorName NOT IN(SELECT ISNULL(SendNo+ItemCode+ColorNum+ColorName,'') OrderFormNo FROM UV1_Attn_GoodsTransDts";

                if (saveNoLoadCheckDayNum != 0)
                {
                    sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
                }
                sql += ")";
                frm.NoLoadCondition = sql;
                //frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
                frm.ShowDialog();
                string str = string.Empty;
                if (frm.FHFormID != null && frm.FHFormID.Length != 0)
                {
                    SetGridView1();
                    for (int i = 0; i < frm.FHFormID.Length; i++)
                    {
                        if (str != string.Empty)
                        {
                            str += ",";
                        }
                        str += SysConvert.ToString(frm.FHFormID[i]);
                    }
                    setItemNews(str);


                }
            }

            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void SetGridView1()
        {
            string sql = "SELECT * FROM Att_GoodsTransDts  WHERE 1=0";
            DataTable dt = SysUtils.Fill(sql);
            Common.AddDtRow(dt, 100);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private void setItemNews(string p_Str)
        {
            string[] fhformid = p_Str.Split(',');
            for (int i = 0; i < fhformid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_FHFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(fhformid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "Unti", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToInt32(dt.Rows[0]["PieceQty"]));
                    gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    gridView1.SetRowCellValue(i, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsOrderFormNo"]));
                    txtSendNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);

                }
            }
        }
        
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private GoodsTrans EntityGet()
        {
            GoodsTrans entity = new GoodsTrans();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
            entity.SendNo = txtSendNo.Text.Trim();
            entity.TransComID =SysConvert.ToString(drpTransComID.EditValue);
  			entity.TransFee = SysConvert.ToDecimal(txtTransFee.Text.Trim()); 
  			entity.RLFee = SysConvert.ToDecimal(txtRLFee.Text.Trim());
  			entity.THFee = SysConvert.ToDecimal(txtTHFee.Text.Trim()); 
  			entity.THAddress = txtTHAddress.Text.Trim();
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
  			entity.RecAddress = txtRecAddress.Text.Trim(); 
  			entity.YSFlag = SysConvert.ToInt32(drpYSFlag.EditValue);
            entity.YSTime = SysConvert.ToDecimal(txtYSTime.Text.Trim());
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.FLC = SysConvert.ToInt32(txtFLC.Text.Trim()); 
  			entity.FDT = SysConvert.ToInt32(drpFDT.EditValue); 
  			entity.FSHSJD = txtFSHSJD.Text.Trim(); 
  			entity.FHWZZ = SysConvert.ToDecimal(txtFHWZZ.Text.Trim()); 
  			entity.FDTJ = SysConvert.ToInt32(drpFDTJ.EditValue); 
  			entity.FHDFlag = SysConvert.ToInt32(drpFHDFlag.EditValue); 
  			entity.FHDDate = txtFHDDate.DateTime.Date; 
  			entity.JSFlag = SysConvert.ToInt32(drpJSFlag.EditValue); 
  			entity.JSDate = txtJSDate.DateTime.Date; 
  			entity.JSFee = SysConvert.ToDecimal(txtJSFee.Text.Trim()); 
  			entity.JSRemark = txtJSRemark.Text.Trim();
            entity.ShopID = txtShopID.Text.Trim();
            entity.OtherFee =SysConvert.ToDecimal(txtOtherFee.Text.Trim());
            entity.TotalAmount = entity.OtherFee + entity.THFee + entity.RLFee + entity.TransFee;
            entity.SJFHDate = txtSJFHDate.DateTime.Date;
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private GoodsTransDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            GoodsTransDts[] entitydts = new GoodsTransDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new GoodsTransDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].Unti = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unti"));

                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].MWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region ��������
        /// <summary>
        /// ������������
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
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��������);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtresItemCode_DoubleClick(object sender, EventArgs e)
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
                        setItemNews2(str);
                    }




                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void setItemNews2(string str)
        {
            string[] arr = str.Split(',');
            int index = checkRowSet();
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV1_Data_ItemGB WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    

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

        

        /// <summary>
        /// �õ��ջ���ַ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {
                    Common.BindVendorAddress(txtRecAddress, SysConvert.ToString(drpVendorID.EditValue), true);
                }
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion
        
        /// <summary>
        /// ƥ�䷢����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linShowYFormNo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    if (txtSendNo.Text.Trim() == "")
                    {
                        this.ShowMessage("�������ͻ�����");
                        txtSendNo.Focus();
                        return;
                    }
                    string sql = "SELECT ID FROM Att_GoodsTrans WHERE SendNo="+SysString.ToDBString(txtSendNo.Text.Trim());
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        this.ShowMessage("��������"+txtSendNo.Text.Trim()+"�Ѵ����������������ظ�ƥ�䣡");
                        return;
                    }
                    sql = "SELECT *  FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(txtSendNo.Text.Trim());
                    sql += " AND FHTypeID=" + SysString.ToDBString((int)EnumFHType.����);
                    sql += " AND ISNULL(SubmitFlag,0)<>0";
                    dt = SysUtils.Fill(sql);
                    sql = "SELECT * FROM UV1_WH_IOFormDts WHERE FormNo="+SysString.ToDBString(txtSendNo.Text.Trim());
                    sql += " AND ISNULL(SubmitFlag,0)<>0";
                    sql += " AND FHTypeID=" + SysString.ToDBString((int)EnumFHType.����);
                    DataTable dt2 = SysUtils.Fill(sql);
                    if (dt.Rows.Count == 0&&dt2.Rows.Count==0)
                    {
                        this.ShowMessage("�������Ų����ڣ�����");
                        return;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                        txtRecAddress.Text = SysConvert.ToString(dt.Rows[0]["Address"]);
                        txtQty.Text = dt.Rows[0]["TotalQty"].ToString();
                        gridView1.GridControl.DataSource = dt;
                        gridView1.GridControl.Show();
                    }

                    if (dt.Rows.Count == 0 && dt2.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            gridView1.SetRowCellValue(i, "ItemCode",SysConvert.ToString(dt2.Rows[i]["ItemCode"]));
                            gridView1.SetRowCellValue(i, "GoodsCode", SysConvert.ToString(dt2.Rows[i]["GoodsCode"]));
                            gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(dt2.Rows[i]["Qty"]));
                            gridView1.SetRowCellValue(i, "Unit", SysConvert.ToString(dt2.Rows[i]["Unit"]));
                            gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt2.Rows[i]["ColorNum"]));
                            gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt2.Rows[i]["ColorName"]));
                            gridView1.SetRowCellValue(i, "MWidth", SysConvert.ToDecimal(dt2.Rows[i]["MWidth"]));
                            gridView1.SetRowCellValue(i, "MWeight", SysConvert.ToDecimal(dt2.Rows[i]["MWeight"]));
                            gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt2.Rows[i]["ItemName"]));
                            gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToInt32(dt2.Rows[i]["PieceQty"]));
                            gridView1.SetRowCellValue(i, "WeightUnit", SysConvert.ToString(dt2.Rows[i]["WeightUnit"]));
                        }
                        drpVendorID.EditValue = SysConvert.ToString(dt2.Rows[0]["VendorID"]);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

        #region �����¼�

        #endregion


    }
}