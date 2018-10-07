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
    /// <summary>
    /// ���ܣ�����������
    /// 
    /// </summary>
    public partial class frmJYOrderEdit : frmAPBaseUIFormEdit
    {
        public frmJYOrderEdit()
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
            ////ѡ���������ݲ�Ϊ��
            //if (SysConvert.ToString(drpVendorID.EditValue) == string.Empty)
            //{
            //    this.ShowMessage("��ѡ��ͻ�");
            //    drpVendorID.Focus();
            //    return false;
            //}
            if (SysConvert.ToString(drpSaleOPID.EditValue) == string.Empty)
            {
                this.ShowMessage("��ѡ��ҵ��Ա");
                drpSaleOPID.Focus();
                return false;
            }

            //if (SysConvert.ToInt32(drpJYType.EditValue) == 0)
            //{
            //    this.ShowMessage("��ѡ������");
            //    drpJYType.Focus();
            //    return false;
            //}
  

            if (!this.CheckCorrectDts())
            {
                return false;
            }
            //if (!this.CheckSOCorrect())// ������롢��ɫ�Ƿ��ظ�
            //{
            //    return false;
            //}
            return true;
        }
        /// <summary>
        /// ���鶩���Ƿ��ظ�(ͬһƷ�֡���ɫ������ֻ������һ��)
        /// </summary>
        /// <returns></returns>
        private bool CheckSOCorrect()
        {
            //if (ParamConfig.LoginCompanyName == "KMERP")
            //{

            //}
            //else
            //{
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //    {
            //        if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
            //        {
            //            for (int j = 0; j < gridView1.RowCount; j++)
            //            {
            //                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
            //                {
            //                    if (i != j && SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ItemCode")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorNum")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorName")))             //&&SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "MWeight"))&&SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "MWidth"))
            //                    {
            //                        this.ShowInfoMessage("��" + SysConvert.ToString(SysConvert.ToInt32(i + 1)) + "���������" + SysConvert.ToString(SysConvert.ToInt32(j + 1)) + "�������ظ�,��Ʒ���.ɫ��.��ɫһ��,��������±���");
            //                        return false;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            return true;
        }

        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            JYOrderDtsRule rule = new JYOrderDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// ��������ʾ�ؼ�
        /// </summary>
        /// <param name="dtSource">����Դ</param>
        /// <param name="inputUnit">ת����λ</param>
        /// <param name="inputConvertXS">ת��ϵ��</param>
        void BindUCFabView(DataTable dtSource, string inputUnit, decimal inputConvertXS)
        {
            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//ת��ΪĬ�ϵ�λģʽ����,Ŀǰ֧��ת��Ϊ����ģʽ
            //{
            //    ucFabView1.UCQtyConvertMode = true;
            //    ucFabView1.UCQtyConvertModeInputUnit = inputUnit;
            //    ucFabView1.UCQtyConvertModeInputConvertXS = inputConvertXS;
            //}
            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6402)))//��Ʒ�ֿⲻʹ���뵥ģʽ
            //{
            //    //6402 6404�����������õ�
            //    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6404)))//��Ʒ�ֿ����֧��¼���뵥
            //    {
                    ucFabView1.UCColumnISNHide = true;//����������
            //    }
            //}
            ucFabView1.UCDataSource = dtSource;
            ucFabView1.UCAct();
        }



        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            JYOrderRule rule = new JYOrderRule();
            JYOrder entity = EntityGet();
            JYOrderDts[] entitydts = EntityDtsGet();

            decimal totalqty = 0m;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalqty += SysConvert.ToDecimal(entitydts[i].Qty);
            }
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
            JYOrderRule rule = new JYOrderRule();
            JYOrder entity = EntityGet();
            JYOrderDts[] entitydts = EntityDtsGet();

            decimal totalqty = 0m;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalqty += SysConvert.ToDecimal(entitydts[i].Qty);
            }
            entity.TotalQty = totalqty;


            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            JYOrder entity = new JYOrder();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtTotalQty.Text = entity.TotalQty.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpVendorID.EditValue = entity.VendorID;

            drpJYType.EditValue = entity.JYTypeID;
  			
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
            JYOrderRule rule = new JYOrderRule();
            JYOrder entity = EntityGet();
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
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);//�Զ����ɵ���
            txtMakeOPName.Text = FParamConfig.LoginName;


        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_JYOrder";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode","Qty"};//������ϸУ�����¼���ֶ�
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);//�󶨿ͻ��б�
            new VendorProc(drpVendorID);
            Common.BindOP(drpSaleOPID, true);
            //Common.BindJYType(drpJYType, true);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "���ز�Ʒ", false, btnLoad_Click);//��������

            Common.BindVendor(drpGridVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);//�󶨿ͻ��б�


            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
        }


        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                if (view.FocusedRowHandle >= 0)
                {
                    int ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
                    string sql = string.Empty;

                    string inputUnit = string.Empty;
                    decimal inputConvertXS = 0;
                    //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//ת��ΪĬ�ϵ�λģʽ����,Ŀǰ֧��ת��Ϊ����ģʽ
                    //{
                    //    inputUnit = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "InputUnit"));
                    //    inputConvertXS = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "InputConvertXS"));
                    //}


                        sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,'' ItemModel,'' JarNum,InputQty FROM Sale_JYOrderDtsInputPack WHERE DID= " + SysString.ToDBString(ID);
                        DataTable dt = SysUtils.Fill(sql);

                        BindUCFabView(dt, inputUnit, inputConvertXS);
                 
                }

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
        private JYOrder EntityGet()
        {
            JYOrder entity = new JYOrder();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.MakeOPName = txtMakeOPName.Text.Trim(); 
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);

            entity.JYTypeID = SysConvert.ToInt32(drpJYType.EditValue);

            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private JYOrderDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            JYOrderDts[] entitydts = new JYOrderDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new JYOrderDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].VendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID"));//�ͻ�                    
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight"));
                    entitydts[index].Width = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Width")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        private void groupControlMainten_Paint(object sender, PaintEventArgs e)
        {

        }

        #region �����¼�
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
            string[] arr = str.Split(',');
            int index = checkRowSet();
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV1_Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    //gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) > 0)
                    {
                        gridView1.SetRowCellValue(i, "Width", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "Width", DBNull.Value);
                    }

                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) > 0)
                    {
                        gridView1.SetRowCellValue(i, "Weight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "Weight", DBNull.Value);
                    }

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
        #endregion

        /// <summary>
        /// ˫��ƥ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToGBDetail_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (this.HTDataSubmitFlag == 0)//δ�ύ״̬������༭�뵥
                {
                    if (HTDataID == 0)
                    {
                        this.ShowMessage("�뱣�浥�ݺ�����ϸ��");
                        return;
                    }
                    int PackFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PackFlag"));
                    int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                    int MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MainID"));
                    int Seq = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Seq"));
                    decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Qty"));

                    if (ID > 0)
                    {
                        frmLoadJYOrderInput frm = new frmLoadJYOrderInput();
                        //frm.PackType = (int)EnumPackType.�ֿⵥ��;
                        frm.ID = ID;
                        frm.MainID = MainID;
                        frm.Seq = Seq;
                        frm.Qty = Qty;
                        if (PackFlag == 1)//���뵥��ϸ
                        {
                            frm.UpdateFlag = true;
                        }
                        frm.ShowDialog();
                        if (frm.SaveFlag)//���������ˢ������
                        {
                            BindGridDts();
                            ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { ID.ToString() });
                            //gridViewRowChanged2(gridView1);
                        }
                    }

                }
                else//�ύ״̬
                {
                    this.ShowMessage("�������ύ��������༭�뵥");
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

       

       


    }
}