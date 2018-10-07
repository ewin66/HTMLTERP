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
    public partial class frmVendorDesEdit : frmAPBaseUIFormEdit
    {
        public frmVendorDesEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]

        public string[] itemstr ={"长大衣","短大衣","套装","裙子","裤子","其他" };
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入色卡编号");
            //    txtCode.Focus();
            //    return false;
            //}
  

            if (!this.CheckCorrectDts())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            VendorDesDtsRule rule = new VendorDesDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            VendorDesRule rule = new VendorDesRule();
            VendorDes entity = EntityGet();
            VendorDesDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            VendorDesRule rule = new VendorDesRule();
            VendorDes entity = EntityGet();
            VendorDesDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            VendorDes entity = new VendorDes();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.VendorID;
  			
  			drpVendorID.EditValue= entity.VendorID.ToString(); 
  			txtCHBrand.Text = entity.CHBrand.ToString(); 
  			txtENBrand.Text = entity.ENBrand.ToString();

            if (entity.Tel.ToString() != "")
            {
                string[] telstr = entity.Tel.Split('$');
                txtTel1.Text = telstr[0].ToString();
                txtTel2.Text = telstr[1].ToString();
                txtTel3.Text = telstr[2].ToString();
            }
            else
            {
                txtTel1.Text = "";
                txtTel2.Text = "";
                txtTel3.Text ="";
            }

            if (entity.Fax.ToString() != "")
            {

                string[] faxstr = entity.Fax.Split('$');
                txtFax1.Text = faxstr[0].ToString();
                txtFax2.Text = faxstr[1].ToString();
            }
            else
            {
                txtFax1.Text ="";
                txtFax2.Text ="";
            }

            if (entity.Contact.ToString() != "")
            {

                string[] contactstr = entity.Contact.Split('$');
                txtContact1.Text = contactstr[0].ToString();
                txtContact2.Text = contactstr[1].ToString();
                txtContact3.Text = contactstr[2].ToString();
            }
            else
            {
                txtContact1.Text ="";
                txtContact2.Text ="";
                txtContact3.Text ="";
            }
            txtMakeDate.DateTime = entity.MakeDate;
  			txtwww.Text = entity.www.ToString(); 
  			txtAddress.Text = entity.Address.ToString();
            txtFormOPName.Text = entity.FormOPName.ToString();
            drpSaleOP.EditValue = entity.SaleOPID.ToString();

            

            if (entity.PF == 1)
            {
                chkPF.Checked = true;
            }
            else
            {
                chkPF.Checked = false;
            }

            if (entity.LS == 1)
            {
                chkls.Checked = true;
            }
            else
            {
                chkls.Checked = false;
            }

            if(entity.PFANDLS==1)
            {
                chkPFANDLS.Checked=true;
            }
            else
            {
                chkPFANDLS.Checked=false;
            }

            if (entity.ZY == 1)
            {
                chkZY.Checked = true;
            }
            else
            {
                chkZY.Checked = false;
            }

            if (entity.DL == 1)
            {
                chkDL.Checked = true;
            }
            else
            {
                chkDL.Checked = false;
            }
            
            txtLSBL.Text = entity.LSBL.ToString();
            txtPFBL.Text = entity.PFBL.ToString();

            if (entity.WF == 1)
            {
                chkWF.Checked = true;
            }
            else
            {
                chkWF.Checked = false;
            }

            if (entity.ZX == 1)
            {
                chkZX.Checked = true;
            }
            else
            {
                chkZX.Checked = false;
            }

  			
  			txtPVendorName.Text = entity.PVendorName.ToString(); 
  			txtPVendorAddress.Text = entity.PVendorAddress.ToString();

            if (entity.ContactTel.ToString() != "")
            {
                string[] contacttelstr = entity.ContactTel.Split('$');
                txtContactTel1.Text = contacttelstr[0].ToString();
                txtContactTel2.Text = contacttelstr[1].ToString();
                txtContactTel3.Text = contacttelstr[2].ToString();
            }
            else
            {
                txtContactTel1.Text = "";
                txtContactTel2.Text ="";
                txtContactTel3.Text ="";
            }

            txtage1.Text = entity.age1.ToString();
            txtage2.Text = entity.age2.ToString();
            txtFPrice1.Text = entity.Fprice1.ToString();
            txtFPrice2.Text = entity.Fprice1.ToString();
            txtFPrice3.Text = entity.Fprice1.ToString();
            txtFPrice4.Text = entity.Fprice4.ToString();

            txtJJ.Text = entity.JJ.ToString();
            txtSJFG.Text = entity.SJFG.ToString();

            txtMPrice1.Text = entity.MPrice1.ToString();
            txtMPrice2.Text = entity.MPrice2.ToString();
            txtMPrice3.Text = entity.MPrice3.ToString();
            txtMPrice4.Text = entity.MPrice4.ToString();

            txtCG1.Text = entity.CG1.ToString();
            txtCG2.Text = entity.CG2.ToString();
            txtCG3.Text = entity.CG3.ToString();
            txtCG4.Text = entity.CG4.ToString();
  			
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            VendorDesRule rule = new VendorDesRule();
            VendorDes entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
             base.IniInsertSet();
             btnAdd_Click(null, null);
             txtMakeDate.DateTime = DateTime.Now.Date;
             //drpSaleOP.EditValue = FParamConfig.LoginID;
             txtFormOPName.Text = FParamConfig.LoginName;
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_VendorDes";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ITEM" };//数据明细校验必须录入字段
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户}, true);
            
            new VendorProc(drpVendorID);
            Common.BindOP(drpSaleOP, true);
           
            

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private VendorDes EntityGet()
        {
            VendorDes entity = new VendorDes();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.VendorName = drpVendorID.Text.ToString();
  			entity.CHBrand = txtCHBrand.Text.Trim(); 
  			entity.ENBrand = txtENBrand.Text.Trim(); 
  			entity.Tel = txtTel1.Text.Trim()+"$"+txtTel2.Text.Trim()+"$"+txtTel3.Text.Trim(); 
  			entity.Fax = txtFax1.Text.Trim()+"$"+txtFax2.Text.Trim(); 
  			entity.Contact = txtContact1.Text.Trim()+"$"+txtContact2.Text.Trim()+"$"+txtContact3.Text.Trim(); 
  			entity.www = txtwww.Text.Trim(); 
  			entity.Address = txtAddress.Text.Trim(); 
  			
  			entity.PF = SysConvert.ToInt32(chkPF.Checked); 
  			entity.LS = SysConvert.ToInt32(chkls.Checked); 
  			entity.PFANDLS = SysConvert.ToInt32(chkPFANDLS.Checked); 
  			entity.PFBL = txtPFBL.Text.Trim(); 
  			entity.LSBL = txtLSBL.Text.Trim(); 
  			entity.WF = SysConvert.ToInt32(chkWF.Checked); 
  			entity.ZX = SysConvert.ToInt32(chkZX.Checked);
            entity.ZY = SysConvert.ToInt32(chkZY.Checked);
            entity.DL = SysConvert.ToInt32(chkDL.Checked);
  			entity.PVendorName = txtPVendorName.Text.Trim(); 
  			entity.PVendorAddress = txtPVendorAddress.Text.Trim(); 
  			entity.ContactTel = txtContactTel1.Text.Trim()+"$"+txtContactTel2.Text.Trim()+"$"+txtContactTel3.Text.Trim();
            entity.age1 = SysConvert.ToInt32(txtage1.Text.Trim());
            entity.age2 = SysConvert.ToInt32(txtage2.Text.Trim());
            entity.Fprice1 = SysConvert.ToDecimal(txtFPrice1.Text.Trim());
            entity.Fprice2 = SysConvert.ToDecimal(txtFPrice2.Text.Trim());
            entity.Fprice3 = SysConvert.ToDecimal(txtFPrice3.Text.Trim());
            entity.Fprice4 = SysConvert.ToDecimal(txtFPrice4.Text.Trim());
            entity.SJFG = txtSJFG.Text.Trim();
            entity.CG1 = txtCG1.Text.Trim();
            entity.CG2 = txtCG2.Text.Trim();
            entity.CG3 = txtCG3.Text.Trim();
            entity.CG4 = txtCG4.Text.Trim();
            entity.MPrice1 = txtMPrice1.Text.Trim();
            entity.MPrice2 = txtMPrice2.Text.Trim();
            entity.MPrice3 = txtMPrice3.Text.Trim();
            entity.MPrice4 = txtMPrice4.Text.Trim();
            entity.JJ = txtJJ.Text.Trim();
            entity.FormDate = DateTime.Now.Date;
            entity.MakeDate = txtMakeDate.DateTime;
            entity.SaleOPID = SysConvert.ToString(drpSaleOP.EditValue);
            if (entity.FormOPName == "")
            {
                entity.FormOPName = Common.GetOPName(drpSaleOP.EditValue.ToString());
            }
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private VendorDesDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            VendorDesDts[] entitydts = new VendorDesDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new VendorDesDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID")); 
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                        entitydts[index].SelectByID();
                    }
                    else//新增
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }
                    
                    entitydts[index].DCDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "DCDate")); 
  			 		entitydts[index].Address = SysConvert.ToString(gridView1.GetRowCellValue(i, "Address")); 
  			 		entitydts[index].LeftBrand = SysConvert.ToString(gridView1.GetRowCellValue(i, "LeftBrand")); 
  			 		entitydts[index].RightBrand = SysConvert.ToString(gridView1.GetRowCellValue(i, "RightBrand")); 
  			 		entitydts[index].TopBrand = SysConvert.ToString(gridView1.GetRowCellValue(i, "TopBrand")); 
  			 		entitydts[index].ButtBrand = SysConvert.ToString(gridView1.GetRowCellValue(i, "ButtBrand")); 
  			 		entitydts[index].ITEM = SysConvert.ToString(gridView1.GetRowCellValue(i, "ITEM")); 
  			 		entitydts[index].ItemPrice = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemPrice")); 
  			 		entitydts[index].CFBL = SysConvert.ToString(gridView1.GetRowCellValue(i, "CFBL")); 
  			 		entitydts[index].LB = SysConvert.ToString(gridView1.GetRowCellValue(i, "LB")); 
  			 		entitydts[index].SX = SysConvert.ToString(gridView1.GetRowCellValue(i, "SX")); 
  			 		entitydts[index].AddPS = SysConvert.ToString(gridView1.GetRowCellValue(i, "AddPS")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        /// <summary>
        /// 增加营销点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int RowIndex = GetRowIndex();
                for (int i = 0; i < itemstr.Length; i++)
                {
                    gridView1.SetRowCellValue(i + RowIndex, "ITEM", itemstr[i].ToString());
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private int GetRowIndex()
        {
            int rowindex = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ITEM")) == "")
                {
                    rowindex = i;
                    return rowindex;
                }
            }
            return rowindex;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
               if(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle,"ITEM"))==itemstr[0].ToString())
               {
                    e.Appearance.BackColor=Color.Salmon;
               }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {
                    string sql = "SELECT * FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        txtContact1.Text = SysConvert.ToString(dt.Rows[0]["Contact"]);
                        txtTel1.Text = SysConvert.ToString(dt.Rows[0]["Tel"]);
                        txtFax1.Text = SysConvert.ToString(dt.Rows[0]["Fax"]);
                        txtAddress.Text = SysConvert.ToString(dt.Rows[0]["Address"]);
                        drpSaleOP.EditValue = SysConvert.ToString(dt.Rows[0]["InSaleOP"]);

                        txtCHBrand.Text = SysConvert.ToString(dt.Rows[0]["CHBrand"]);
                        txtENBrand.Text = SysConvert.ToString(dt.Rows[0]["ENBrand"]);
                        txtMPrice1.Text = SysConvert.ToString(dt.Rows[0]["MPrice1"]);
                        txtMPrice2.Text = SysConvert.ToString(dt.Rows[0]["MPrice2"]);
                        txtMPrice3.Text = SysConvert.ToString(dt.Rows[0]["MPrice3"]);
                        txtMPrice4.Text = SysConvert.ToString(dt.Rows[0]["MPrice4"]);
                        txtage1.Text = SysConvert.ToString(dt.Rows[0]["age1"]);
                        txtage2.Text = SysConvert.ToString(dt.Rows[0]["age2"]);
                        txtSJFG.Text = SysConvert.ToString(dt.Rows[0]["SJFG"]);
                        if (SysConvert.ToInt32(dt.Rows[0]["PF"]) == 1)
                        {
                            chkPF.Checked = true;
                        }
                        else
                        {
                            chkPF.Checked = false;
                        }

                        if (SysConvert.ToInt32(dt.Rows[0]["DL"]) == 1)
                        {
                            chkDL.Checked = true;
                        }
                        else
                        {
                            chkDL.Checked = false;
                        }

                        if (SysConvert.ToInt32(dt.Rows[0]["ZY"]) == 1)
                        {
                            chkZY.Checked = true;
                        }
                        else
                        {
                            chkZY.Checked = false;
                        }

                        gridView1.SetRowCellValue(0, "Address", SysConvert.ToString(dt.Rows[0]["MainSale"]));
                    }

                    sql = "SELECT * FROM Data_VendorNews WHERE MainID IN (SELECT ID FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue)) + ")";
                    dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            gridView1.SetRowCellValue(i, "Item", SysConvert.ToString(dt.Rows[i]["Item"]));
                            gridView1.SetRowCellValue(i, "ItemPrice", SysConvert.ToString(dt.Rows[i]["ItemPrice"]));

                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       



        #region 其它事件

        #endregion


    }
}