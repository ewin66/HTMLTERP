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
    public partial class frmSampleSOEdit : frmAPBaseUIFormEdit
    {
        public frmSampleSOEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请双击生成单号");
                txtFormNo.Focus();
                return false;
            }
            if (SysConvert.ToString(drpVendorID.EditValue)=="")
            {
                this.ShowMessage("请选择客户");
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
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            SampleSODtsRule rule = new SampleSODtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            SampleSORule rule = new SampleSORule();
            SampleSO entity = EntityGet();
            SampleSODts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            SampleSORule rule = new SampleSORule();
            SampleSO entity = EntityGet();
            SampleSODts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            SampleSO entity = new SampleSO();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  			txtAppOPID.Text = entity.AppOPID.ToString(); 
            //txtSaleOPID.Text = entity.SaleOPID.ToString(); 
            drpDepID.Text = entity.DepID.ToString(); 
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpVendorID.EditValue = entity.VendorID;
  			drpSaleGroup.Text = entity.SaleGroup.ToString(); 
            //txtVendorID.Text = entity.VendorID.ToString(); 
  			txtMakeOPID.Text = entity.MakeOPID.ToString(); 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtRemark.Text = entity.Remark.ToString(); 
  			
  			
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
            SampleSORule rule = new SampleSORule();
            SampleSO entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            ProductCommon.FormNoCtlEditSet(txtFormNo, "Dev_SampleSO", "FormNo", p_Flag);
            
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormDate.DateTime = DateTime.Now.Date;

            txtMakeOPName.Text = FParamConfig.LoginName;
            txtAppOPID.Text = FParamConfig.LoginName;
            txtFormNo_DoubleClick(null,null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_SampleSO";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode"};//数据明细校验必须录入字段

            //Common.BindCLS(drpepID, "Data_OP", "SDep", true);
            Common.BindCLS(drpSaleGroup, "Sale", "SaleGroup", true);
            Common.BindCLS(drpGridDesignType, "Dev_SampleSODts", "DesignType", true);
            Common.BindDep(drpDepID);
            Common.BindVendorName(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc2(drpVendorID);
            //Common.BindOPID(drpSaleOPID, true);

            Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);

            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载产品", false, btnLoad_Click);
            
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SampleSO EntityGet()
        {
            SampleSO entity = new SampleSO();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.AppOPID = txtAppOPID.Text.Trim(); 
  			//entity.SaleOPID = txtSaleOPID.Text.Trim(); 
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.DepID = SysConvert.ToInt32(drpDepID.Text.Trim()); 
  			entity.SaleGroup = drpSaleGroup.Text.Trim(); 
            //entity.VendorID = txtVendorID.Text.Trim(); 
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
  			entity.MakeOPID = txtMakeOPID.Text.Trim(); 
  			entity.MakeOPName = txtMakeOPName.Text.Trim(); 
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.Remark = txtRemark.Text.Trim(); 
  			 
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SampleSODts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            SampleSODts[] entitydts = new SampleSODts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new SampleSODts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); ;
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].MWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth")); 
  			 		entitydts[index].MWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight")); 
  			 		entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit")); 
  			 		entitydts[index].DesignNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DesignNo")); 
  			 		entitydts[index].DesignType = SysConvert.ToString(gridView1.GetRowCellValue(i, "DesignType")); 
  			 		entitydts[index].VendorItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorItemCode")); 
  			 		entitydts[index].BFabirPZ = SysConvert.ToString(gridView1.GetRowCellValue(i, "BFabirPZ")); 
  			 		entitydts[index].XHXPZ = SysConvert.ToString(gridView1.GetRowCellValue(i, "XHXPZ")); 
  			 		entitydts[index].BFabricColor = SysConvert.ToString(gridView1.GetRowCellValue(i, "BFabricColor")); 
  			 		entitydts[index].XHXColor = SysConvert.ToString(gridView1.GetRowCellValue(i, "XHXColor")); 
  			 		entitydts[index].XHXType = SysConvert.ToString(gridView1.GetRowCellValue(i, "XHXType")); 
  			 		entitydts[index].XHMWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "XHMWidth")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region 加载产品
        /// <summary>
        /// 加载
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
        /// 双击产品编码加载产品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
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
                    //gridViewRowChanged1(gridView1);

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
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));

                }
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

        #region 其它事件
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    ProductCommon.FormNoIniSet(txtFormNo, "Dev_SampleSO", "FormNo");
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.打样指示单单号);
                    //ProductCommon.FormNoIniSet(txtFormNo, "Sale_SaleOrder", "FormNo", 0);
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