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
    public partial class frmColorCardEdit : frmAPBaseUIFormEdit
    {
        public frmColorCardEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
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
            ColorCardDtsRule rule = new ColorCardDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            ColorCardRule rule = new ColorCardRule();
            ColorCard entity = EntityGet();
            ColorCardDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ColorCardRule rule = new ColorCardRule();
            ColorCard entity = EntityGet();
            ColorCardDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            ColorCard entity = new ColorCard();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNO.Text = entity.FormNO.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  			txtReqDate.DateTime = entity.ReqDate;
            drpSaleOPID.EditValue = entity.SaleOPID.ToString(); 
  			drpVendorID.EditValue = entity.VendorID.ToString();
            drpShopID.EditValue = entity.ShopID.ToString(); 
  			txtMakeOPID.Text = entity.MakeOPID.ToString(); 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtCheckOPID.Text = entity.CheckOPID.ToString(); 
  			txtCheckDate.DateTime = entity.CheckDate; 
  			txtRemark.Text = entity.Remark.ToString();
            drpSampleType.EditValue = entity.SampleType;
            chkFirstLightSource.Text = entity.FirstLightSource;
            chkSencondLightSource.Text = entity.SencondLightSource;
            drpVendorOPID.EditValue = entity.VendorOPID;
            drpFactoryOPID.EditValue = entity.FactoryOPID;
            txtHG.Text = entity.HG;
            txtFactoryID.Text = entity.FactoryID;
  			
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
            ColorCardRule rule = new ColorCardRule();
            ColorCard entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { drpSampleType, txtMakeOPID, txtMakeOPName, txtMakeDate }, false);
            //ProcessGrid.SetGridColumnReadOnly(gridView1, new string[] { "FinishDate", "JYDate" });

            ProductCommon.FormNoCtlEditSet(txtFormNO, "Dev_ColorCard", "FormNo", 0, p_Flag);

            //1: L/D样    2：S/O样
            if (this.FormListAID == 1)
            {
                label14.Visible = false;
                txtHG.Visible = false;
            }
            else if (this.FormListAID == 2)
            {
                label14.Visible = true;
                txtHG.Visible = true;
            }
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtReqDate.DateTime = DateTime.Now.Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            drpSampleType.EditValue = this.FormListAID;
            txtMakeOPID.Text = FParamConfig.LoginID;
            txtMakeOPName.Text = FParamConfig.LoginName;

            txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_ColorCard";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode" };//数据明细校验必须录入字段
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户},true);
            Common.BindVendor(drpShopID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.染厂,(int)EnumVendorType.其他加工厂 }, true);

            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//组织结构体系启用
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }

            Common.BindOP(drpGYOPID, true);

            Common.BindColorSampleType(drpSampleType, true);
            new PopContainerUtil(chkFirstLightSource, Common.BindLightSource);   //主灯光源
            new PopContainerUtil(chkSencondLightSource, Common.BindLightSource);   //副灯光源

            this.ToolBarItemAdd(28, "btnkLoadItem", "加载产品", false, btnkLoadItem_Click);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ColorCard EntityGet()
        {
            ColorCard entity = new ColorCard();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNO = txtFormNO.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.ReqDate = txtReqDate.DateTime.Date;
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.ShopID = SysConvert.ToString(drpShopID.EditValue);
  			entity.MakeOPID = txtMakeOPID.Text.Trim(); 
  			entity.MakeOPName = txtMakeOPName.Text.Trim(); 
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.CheckOPID = txtCheckOPID.Text.Trim(); 
  			entity.CheckDate = txtCheckDate.DateTime.Date; 
  			entity.Remark = txtRemark.Text.Trim();
            entity.SampleType = SysConvert.ToInt32(drpSampleType.EditValue);
            entity.FirstLightSource = SysConvert.ToString(chkFirstLightSource.Text);
            entity.SencondLightSource = SysConvert.ToString(chkSencondLightSource.Text);
            entity.VendorOPID = SysConvert.ToString(drpVendorOPID.EditValue);
            entity.FactoryOPID = SysConvert.ToString(drpFactoryOPID.EditValue);
            entity.HG = txtHG.Text.Trim();

            entity.FactoryID = txtFactoryID.Text.Trim();

            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ColorCardDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ColorCardDts[] entitydts = new ColorCardDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ColorCardDts();
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
                        entitydts[index].ColorCardStatusID = 1;


                    } 
                    if (entitydts[index].ColorCardStatusID <= 0)
                    {
                        entitydts[index].ColorCardStatusID = 1;
                    }
                    
  			 		entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth")) != 0m)
                    {
                        entitydts[index].MWidth = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWidth"));

                    }
                    if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight")) != 0m)
                    {
                        entitydts[index].MWeight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "MWeight"));
                    }
  			 		entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit")); 
  			 		entitydts[index].Season = SysConvert.ToString(gridView1.GetRowCellValue(i, "Season")); 
  			 		entitydts[index].DesignNO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DesignNO")); 
  			 		entitydts[index].VendorNO = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorNO")); 
  			 		entitydts[index].DesignEdition = SysConvert.ToString(gridView1.GetRowCellValue(i, "DesignEdition")); 
  			 		entitydts[index].OKEdition = SysConvert.ToString(gridView1.GetRowCellValue(i, "OKEdition")); 
                    //entitydts[index].FirstFinish = SysConvert.ToString(gridView1.GetRowCellValue(i, "FirstFinish")); 
                    //entitydts[index].FirstRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "FirstRemark")); 
                    //entitydts[index].SecondFinish = SysConvert.ToString(gridView1.GetRowCellValue(i, "SecondFinish")); 
                    //entitydts[index].SecondRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "SecondRemark")); 
                    //entitydts[index].ThirdFinish = SysConvert.ToString(gridView1.GetRowCellValue(i, "ThirdFinish")); 
                    //entitydts[index].ThirdRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "ThirdRemark")); 
  			 		entitydts[index].FreeStr1 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr1")); 
  			 		entitydts[index].FreeStr2 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr2")); 
  			 		entitydts[index].FreeStr3 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr3")); 
  			 		entitydts[index].FreeStr4 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr4")); 
  			 		entitydts[index].FreeStr5 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr5")); 
  			 		entitydts[index].FreeDate1 = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FreeDate1")); 
  			 		entitydts[index].FreeDate2 = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FreeDate2")); 
  			 		entitydts[index].FreeDate3 = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FreeDate3")); 
  			 		entitydts[index].FreeDate4 = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FreeDate4")); 
  			 		entitydts[index].FreeDate5 = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FreeDate5")); 
  			 		entitydts[index].DtsRemark = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsRemark"));
                    entitydts[index].MWidth2 = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth2"));

                    entitydts[index].FinishDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "FinishDate"));
                    entitydts[index].JYDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "JYDate"));
                    entitydts[index].HGBack = SysConvert.ToString(gridView1.GetRowCellValue(i, "HGBack"));
                    entitydts[index].GYOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "GYOPID"));
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }


      

        #endregion

 


        #region 其它事件
        /// <summary>
        /// 双击生成采购单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    ProductCommon.FormNoIniSet(txtFormNO, "Dev_ColorCard", "FormNo");
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.销售合同采购单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion
        #region 加载产品

        public void btnkLoadItem_Click(object sender, EventArgs e)
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
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) > 0)
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWidth", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWidth", DBNull.Value);
                    }
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWidth2", SysConvert.ToString(dt.Rows[0]["FK"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) > 0)
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWeight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "MWeight", DBNull.Value);
                    }
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle + i, "Unit", SysConvert.ToString(dt.Rows[0]["ItemUnit"]));

                }
            }
        }

           #endregion  

        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            {
                Common.BindVendorContact(drpVendorOPID, SysConvert.ToString(drpVendorID.EditValue), true);
            }
        }

        private void drpShopID_EditValueChanged(object sender, EventArgs e)
        {
            if (SysConvert.ToString(drpShopID.EditValue) != string.Empty)
            {
                Common.BindVendorContact(drpFactoryOPID, SysConvert.ToString(drpShopID.EditValue), true);
            }
        }

    }
}