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
    public partial class frmDYGLEdit : frmAPBaseUISinEdit
    {
        public frmDYGLEdit()
        {
            InitializeComponent();
        }

        private string m_LY;
        public string LY
        {
            get
            {
                return m_LY;
            }
            set
            {
                m_LY = value;
            }
        }

        private int m_DtsID;
        public int DtsID
        {
            get
            {
                return m_DtsID;
            }
            set
            {
                m_DtsID = value;
            }
        }

        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("���������");
            //    txtTitle.Focus();
            //    return false;
            //}  
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("��˫�����ɵ���");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��ͻ�");
                drpVendorID.Focus();
                return false;
            }

            if (txtShopID.Text.Trim() == "")
            {
                this.ShowMessage("�����볧��");
                txtShopID.Focus();
                return false;
            }

            if (drpDYXZ.Text.Trim() == string.Empty)
            {
                this.ShowMessage("����������");
                drpDYXZ.Focus();
                return false;
            }

            if (drpDYXZ.Text.Trim() != "��ɫ")
            {
                if (SysConvert.ToDecimal(txtQty.Text)==0)
                {
                    this.ShowMessage("����������");
                    txtQty.Focus();
                    return false;
                }
            }

            #region 2013/3/21�ͻ���С��˵Ҫȥ����У��
            //if (HTDataID > 0)
            //{
            //    DYGL entity = new DYGL();
            //    entity.ID = HTDataID;
            //    entity.SelectByID();
            //    if (entity.DYStatusID == (int)EnumDYStatus.�����)
            //    {
            //        this.ShowMessage("��������ɣ������޸ģ�");
            //        return false;
            //    }
            //}
            #endregion



            string sql = "SELECT ItemCode FROM Data_Item WHERE GoodsCode=" + SysString.ToDBString(txtGoodsCode.Text.Trim());
            sql += " AND VendorID=" + SysString.ToDBString(txtShopID.Text.Trim());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 0)
            {
                this.ShowMessage("Ѱ�Ҳ�����Ʒ�����鳧�����Ʒ���Ƿ�������ȷ");
                return false;
            }


            if (txtRelFormNo.Text.Trim() != string.Empty)
            {
                sql = "SELECT ID FROM Sale_DYGL WHERE FormNo=" + SysString.ToDBString(txtRelFormNo.Text.Trim()) + " AND ID<>" + this.HTDataID;
                DataTable dt2 = SysUtils.Fill(sql);
                if (dt2.Rows.Count == 0)
                {

                    this.ShowMessage("��ɫ����δ�ҵ��������Ƿ�������ȷ");
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            //txtShopID_Leave(null, null);
            DYGLRule rule = new DYGLRule();
            DYGL entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            if (txtItemCode.Text.Trim() == "")
            {
                this.ShowMessage("�������Ʒ����");
                txtItemCode.Focus();
                return;
            }
            //txtShopID_Leave(null, null);
            DYGLRule rule = new DYGLRule();
            DYGL entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
           
            DYGL entity = new DYGL();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString(); 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			drpVendorID.EditValue = entity.VendorID.ToString(); 
  			drpSaleOPID.EditValue = entity.SaleOPID.ToString(); 
  			txtItemCode.Text = entity.GBCode.ToString(); 
  			txtItemCode.Text = entity.ItemCode.ToString(); 
  			txtColorNum.Text = entity.ColorNum.ToString(); 
  			txtColorName.Text = entity.ColorName.ToString(); 
  			txtShopID.Text = entity.ShopID.ToString(); 
  			drpDYXZ.EditValue = entity.DYXZ.ToString(); 
  			txtQty.Text =entity.Qty.ToString(); 
  			txtPYRequest.Text = entity.PYRequest.ToString(); 
  			drpDYStatusID.EditValue = entity.DYStatusID; 
  			txtSinglePrice.Text = entity.SinglePrice.ToString();
            drpDYXZ.Text = entity.DYXZ.ToString();
  			txtPYReqDate.DateTime = entity.PYReqDate;
            txtFormDesc.Text = entity.FormDesc.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            txtGBCode.Text = entity.GBCode.ToString();
            drpVendorID2.EditValue = entity.VendorID2.ToString();
            txtGoodsCode.Text = entity.GoodsCode.ToString();
            txtUnit.Text = entity.Unit.ToString();
            //txtSJDate.DateTime = entity.SJDate;
            txtDYPrice.Text = entity.DYPrice.ToString();

            txtVItemCode.Text = entity.VItemCode.ToString();
            txtVColorNum.Text = entity.VColorNum.ToString();
            txtVColorName.Text = entity.VColorName.ToString();


            txtDSLeiXin.Text = entity.DSLeiXin;
            txtQRColorName.Text=entity.QRColorName;
            if (entity.QRDate != SystemConfiguration.DateTimeDefaultValue)
            {
                txtQRDate.DateTime=entity.QRDate.Date;
            }
            else
            {
                txtQRDate.Text = "";
            }

            txtRelFormNo.Text=entity.RelFormNo;
            txtMWidth.Text = entity.MWidth.ToString();
            txtMWeight.Text = entity.MWeight.ToString();
            
            //BindGrid();
            if (!findFlag)
            {
              
            }
        }

        private void BindGrid()
        {
            string sql = "SELECT *,0 SelectFlag FROM WH_Storge WHERE 1=1";
            sql += " AND ItemCode="+SysString.ToDBString(txtItemCode.Text.Trim());
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            DYGLRule rule = new DYGLRule();
            DYGL entity = EntityGet();
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
            this.HTDataTableName = "Sale_DYGL";
            //this.HTDataDts = gridView1;
            Common.BindDOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            Common.BindVendor(drpVendorID2, new int[] { (int)EnumVendorType.���� }, true);
            new VendorProc(drpVendorID);
            new VendorProc(drpVendorID2);
            Common.BindCLS(drpDYXZ, "Sale_DYGL", "DYXZ", true);
            Common.BindDYStatus(drpDYStatusID, true);
            //Common.BindEnumUnit(txtUnit, true);
            Common.BindCLS(txtUnit, "Data_Item", "ItemUnitFab", true);

            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, btnLoad_Click);
            this.ToolBarItemAdd(28, ToolButtonName.btnSave.ToString(), "�鿴���", false, btnQuery_Click);
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            if (m_LY == "�Ұ�����")
            {
                SetDYByGBJC();
            }
        }

        private void SetDYByGBJC()
        {
           
            HTFormStatus = FormStatus.����;
            IniInsertSet();
           
        }


        public void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemCode.Text.Trim() != "")
                {
                    BindGrid();
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
                txtItemCode_DoubleClick(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        public override void IniInsertSet()
        {

            txtWeightUnit.Text = "g/m";
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtPYReqDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtQRDate.Text = "";
            if (m_DtsID != 0)
            {
                string sql = "SELECT * FROM UV2_Dev_GBJCDts WHERE DtsID=" + SysString.ToDBString(m_DtsID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    txtGBCode.Text = SysConvert.ToString(dt.Rows[0]["GBCode"]);
                    txtColorNum.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                    txtColorName.Text = SysConvert.ToString(dt.Rows[0]["ColorName"]);
                    drpVendorID2.EditValue = SysConvert.ToString(dt.Rows[0]["VendorCode"]);
                    txtGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                    txtShopID.Text = SysConvert.ToString(dt.Rows[0]["VendorCode"]);
                    txtItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                }
            }
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private DYGL EntityGet()
        {
            DYGL entity = new DYGL();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID; 
  			entity.MakeOPName = txtMakeOPName.Text.Trim(); 
  			entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.GBCode = SysConvert.ToString(txtGBCode.Text.Trim());
  			entity.ItemCode = txtItemCode.Text.Trim(); 
  			entity.ColorNum = txtColorNum.Text.Trim(); 
  			entity.ColorName = txtColorName.Text.Trim(); 
  			entity.ShopID = txtShopID.Text.Trim();
            entity.DYXZ = SysConvert.ToString(drpDYXZ.Text.Trim()); 
  			entity.Qty = SysConvert.ToDecimal(txtQty.Text.Trim()); 
  			entity.PYRequest = txtPYRequest.Text.Trim(); 
  			entity.DYStatusID = SysConvert.ToInt32(drpDYStatusID.EditValue); 
  			entity.SinglePrice = SysConvert.ToDecimal(txtSinglePrice.Text.Trim()); 
  			entity.PYReqDate = txtPYReqDate.DateTime.Date;
            entity.Remark = txtRemark.Text.Trim();
  			entity.FormDesc = txtFormDesc.Text.Trim();
            entity.VendorID2 = SysConvert.ToString(drpVendorID2.EditValue);
            entity.GoodsCode = txtGoodsCode.Text.Trim();
            entity.Amount = entity.SinglePrice * entity.Qty;
            entity.Unit = txtUnit.Text.Trim();
            entity.DYPrice = SysConvert.ToDecimal(txtDYPrice.Text.Trim());
            entity.VItemCode = txtVItemCode.Text.Trim();
            entity.VColorNum = txtVColorNum.Text.Trim();
            entity.VColorName = txtVColorName.Text.Trim();
            //entity.SJDate = txtSJDate.DateTime;
            entity.DSLeiXin = txtDSLeiXin.Text.Trim();
            entity.QRColorName = txtQRColorName.Text.Trim();
            if (txtQRDate.Text != string.Empty)
            {
                entity.QRDate = txtQRDate.DateTime.Date;
            }
            else
            {
                entity.QRDate = SystemConfiguration.DateTimeDefaultValue;
            }

            entity.RelFormNo = txtRelFormNo.Text.Trim();
            entity.MWidth = SysConvert.ToDecimal(txtMWidth.Text.Trim());
            entity.MWeight = SysConvert.ToDecimal(txtMWeight.Text.Trim());
            entity.WeightUnit = txtWeightUnit.Text.Trim();

            if (SysConvert.ToInt32(drpDYStatusID.EditValue) == (int)EnumDYStatus.�����)
            {
                entity.FormDate = DateTime.Now.Date;
            }
            if(SysConvert.ToString(drpVendorID2.EditValue)=="")
            {
                entity.VendorID2=txtShopID.Text.Trim();
            }
            return entity;
        }
        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               
                FormNoControlRule rule = new FormNoControlRule();
                txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��������);
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtGBCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string gbcode = txtGBCode.Text.Trim();
                    if (gbcode == "")
                    {
                        this.ShowMessage("��ɨ������");
                        return;
                    }
                    string sql = "SELECT * FROM UV1_Data_ItemGB WHERE GBCode="+SysString.ToDBString(gbcode);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        this.ShowMessage("ɨ������벻����");
                        txtGBCode.Text = "";
                        return;
                    }
                   
                    txtItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                    txtGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                    txtShopID.Text = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                    txtColorNum.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                    txtColorName.Text = SysConvert.ToString(dt.Rows[0]["ColorName"]);
                    txtMWidth.Text = SysConvert.ToString(dt.Rows[0]["MWidth"]);
                    txtMWeight.Text = SysConvert.ToString(dt.Rows[0]["MWeight"]);
                    txtWeightUnit.Text = SysConvert.ToString(dt.Rows[0]["WeightUnit"]);
                    btnQuery_Click(null, null);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtShopID_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtGoodsCode.Text.Trim() != "" && txtShopID.Text.Trim() != "")
                {
                    string sql = "SELECT ItemCode FROM Data_Item WHERE GoodsCode="+SysString.ToDBString(txtGoodsCode.Text.Trim());
                    sql += " AND VendorID="+SysString.ToDBString(txtShopID.Text.Trim());
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        this.ShowMessage("Ѱ�Ҳ�����Ʒ�����鳧�����Ʒ���Ƿ�������ȷ");
                    }
                    if(dt.Rows.Count==1)
                    {
                        txtItemCode.Text=SysConvert.ToString(dt.Rows[0][0]);
                        btnQuery_Click(null, null);
                    }
                    if(dt.Rows.Count>1)
                    {
                        this.ShowMessage("ͬ����-��Ʒ�����������Ʒ���ݣ�����");
                    }
                    return;

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtItemCode_DoubleClick(object sender, EventArgs e)
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
                        if(frm.GBID.Length>1)
                        {
                            this.ShowMessage("��ֻ����һ���Ұ���Ϣ");
                            return;
                        }
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
                    btnQuery_Click(null, null);




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
            string sql = "SELECT * FROM UV1_Data_ItemGB WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(arr[0]));
            DataTable dt = SysUtils.Fill(sql);

            if (dt.Rows.Count > 0)
            {
                txtItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                txtGBCode.Text = SysConvert.ToString(dt.Rows[0]["GBCode"]);
                txtGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                txtColorNum.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                txtColorName.Text = SysConvert.ToString(dt.Rows[0]["ColorName"]);
                drpVendorID2.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                txtShopID.Text = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                txtMWidth.Text = SysConvert.ToString(dt.Rows[0]["MWidth"]);
                txtMWeight.Text = SysConvert.ToString(dt.Rows[0]["MWeight"]);
                txtWeightUnit.Text = SysConvert.ToString(dt.Rows[0]["WeightUnit"]);

            }
        }

        /// <summary>
        /// ѡ�����ɫ����ɫ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"ColorNum"));
                string ColorName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorName"));
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag")) == 1)
                {
                    txtColorNum.Text = ColorNum;
                    txtColorName.Text = ColorName;
                }
                else
                {
                    txtColorNum.Text = "";
                    txtColorName.Text = "";
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// �����Ʒ�����õ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnQuery_Click(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtShopID_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                btnQuery_Click(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #region ���ݱ����óɷ�
        private void txtItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtItemCode.Text != string.Empty)
                {
                    txtItemName.Text = Common.GetItemNameByCode(txtItemCode.Text);
                }
                else
                {
                    txtItemName.Text = "";
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion



    }
}