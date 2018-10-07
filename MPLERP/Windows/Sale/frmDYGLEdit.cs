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

        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入标题");
            //    txtTitle.Focus();
            //    return false;
            //}  
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请双击生成单号");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择客户");
                drpVendorID.Focus();
                return false;
            }

            if (txtShopID.Text.Trim() == "")
            {
                this.ShowMessage("请输入厂码");
                txtShopID.Focus();
                return false;
            }

            if (drpDYXZ.Text.Trim() == string.Empty)
            {
                this.ShowMessage("请输入性质");
                drpDYXZ.Focus();
                return false;
            }

            if (drpDYXZ.Text.Trim() != "打色")
            {
                if (SysConvert.ToDecimal(txtQty.Text)==0)
                {
                    this.ShowMessage("请输入数量");
                    txtQty.Focus();
                    return false;
                }
            }

            #region 2013/3/21客户和小章说要去掉此校验
            //if (HTDataID > 0)
            //{
            //    DYGL entity = new DYGL();
            //    entity.ID = HTDataID;
            //    entity.SelectByID();
            //    if (entity.DYStatusID == (int)EnumDYStatus.已完成)
            //    {
            //        this.ShowMessage("调样已完成，不能修改！");
            //        return false;
            //    }
            //}
            #endregion



            string sql = "SELECT ItemCode FROM Data_Item WHERE GoodsCode=" + SysString.ToDBString(txtGoodsCode.Text.Trim());
            sql += " AND VendorID=" + SysString.ToDBString(txtShopID.Text.Trim());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 0)
            {
                this.ShowMessage("寻找不到产品，请检查厂码和商品码是否输入正确");
                return false;
            }


            if (txtRelFormNo.Text.Trim() != string.Empty)
            {
                sql = "SELECT ID FROM Sale_DYGL WHERE FormNo=" + SysString.ToDBString(txtRelFormNo.Text.Trim()) + " AND ID<>" + this.HTDataID;
                DataTable dt2 = SysUtils.Fill(sql);
                if (dt2.Rows.Count == 0)
                {

                    this.ShowMessage("打色单号未找到，请检查是否输入正确");
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// 新增
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
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            if (txtItemCode.Text.Trim() == "")
            {
                this.ShowMessage("请输入产品编码");
                txtItemCode.Focus();
                return;
            }
            //txtShopID_Leave(null, null);
            DYGLRule rule = new DYGLRule();
            DYGL entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
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
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            DYGLRule rule = new DYGLRule();
            DYGL entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_DYGL";
            //this.HTDataDts = gridView1;
            Common.BindDOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindVendor(drpVendorID2, new int[] { (int)EnumVendorType.工厂 }, true);
            new VendorProc(drpVendorID);
            new VendorProc(drpVendorID2);
            Common.BindCLS(drpDYXZ, "Sale_DYGL", "DYXZ", true);
            Common.BindDYStatus(drpDYStatusID, true);
            //Common.BindEnumUnit(txtUnit, true);
            Common.BindCLS(txtUnit, "Data_Item", "ItemUnitFab", true);

            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);
            this.ToolBarItemAdd(28, ToolButtonName.btnSave.ToString(), "查看库存", false, btnQuery_Click);
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            if (m_LY == "挂板借出单")
            {
                SetDYByGBJC();
            }
        }

        private void SetDYByGBJC()
        {
           
            HTFormStatus = FormStatus.新增;
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
        /// 加载
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

        #region 自定义方法
        /// <summary>
        /// 获得实体
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

            if (SysConvert.ToInt32(drpDYStatusID.EditValue) == (int)EnumDYStatus.已完成)
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
                txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.调样单号);
                
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
                        this.ShowMessage("请扫描条码");
                        return;
                    }
                    string sql = "SELECT * FROM UV1_Data_ItemGB WHERE GBCode="+SysString.ToDBString(gbcode);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        this.ShowMessage("扫描的条码不存在");
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
                        this.ShowMessage("寻找不到产品，请检查厂码和商品码是否输入正确");
                    }
                    if(dt.Rows.Count==1)
                    {
                        txtItemCode.Text=SysConvert.ToString(dt.Rows[0][0]);
                        btnQuery_Click(null, null);
                    }
                    if(dt.Rows.Count>1)
                    {
                        this.ShowMessage("同厂码-商品码存在两条产品数据，请检查");
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
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    frmLoadItemGB frm = new frmLoadItemGB();
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID != null && frm.GBID.Length != 0)
                    {
                        if(frm.GBID.Length>1)
                        {
                            this.ShowMessage("请只加载一条挂板信息");
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
        /// 选择带出色号颜色
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
        /// 输入产品编码后得到库存
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
        #region 根据编码获得成份
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