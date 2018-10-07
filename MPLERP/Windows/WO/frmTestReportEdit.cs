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
    public partial class frmTestReportEdit : frmAPBaseUIFormEdit
    {
        public frmTestReportEdit()
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
            TestReportDtsRule rule = new TestReportDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            TestReportRule rule = new TestReportRule();
            TestReport entity = EntityGet();
            TestReportDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            TestReportRule rule = new TestReportRule();
            TestReport entity = EntityGet();
            TestReportDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            TestReport entity = new TestReport();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.FormDate;
  			txtOrderFormNo.Text = entity.OrderFormNo.ToString(); 
  			txtItemCode.Text = entity.ItemCode.ToString(); 
  			txtItemName.Text = entity.ItemName.ToString(); 
  			txtItemStd.Text = entity.ItemStd.ToString(); 
  			txtItemModel.Text = entity.ItemModel.ToString(); 
  			txtColorNum.Text = entity.ColorNum.ToString(); 
  			txtColorName.Text = entity.ColorName.ToString(); 
  			drpSaleOPID.Text = entity.SaleOPID.ToString();
            drpTestOPID.Text = entity.TestOPID.ToString(); 
  			txtItemSource.Text = entity.ItemSource.ToString(); 
  			txtSXShrinkageJX.Text = entity.SXShrinkageJX.ToString(); 
  			txtSXShrinkageWX.Text = entity.SXShrinkageWX.ToString(); 
  			txtYTShrinkageJX.Text = entity.YTShrinkageJX.ToString(); 
  			txtYTShrinkageWX.Text = entity.YTShrinkageWX.ToString(); 
  			txtMakeOPID.Text = entity.MakeOPID.ToString(); 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtCheckOPID.Text = entity.CheckOPID.ToString(); 
  			txtCheckDate.DateTime = entity.CheckDate; 
  			
  			
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
            TestReportRule rule = new TestReportRule();
            TestReport entity = EntityGet();
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
            txtFormDate.Text = DateTime.Now.ToShortDateString();
            txtMakeDate.Text = DateTime.Now.ToShortDateString();
            txtCheckDate.Text = DateTime.Now.ToShortDateString();
            txtMakeOPID.Text = FParamConfig.LoginID;
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_TestReport";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "TProject" };//数据明细校验必须录入字段
           
            //Common.BindOPID(drpTestOPID, "Sale_SaleOrder", "SaleOPID", true);//测试员
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载合同", false, btnSaleLoad_Click);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载产品", false, btnLoad_Click);
           
        }
        public override void IniRefreshData()
        {
            Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);//业务员
            Common.BindOP(drpTestOPID, true);//测试员
        }


        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private TestReport EntityGet()
        {
            TestReport entity = new TestReport();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.OrderFormNo = txtOrderFormNo.Text.Trim(); 
  			entity.ItemCode = txtItemCode.Text.Trim(); 
  			entity.ItemName = txtItemName.Text.Trim(); 
  			entity.ItemStd = txtItemStd.Text.Trim(); 
  			entity.ItemModel = txtItemModel.Text.Trim(); 
  			entity.ColorNum = txtColorNum.Text.Trim(); 
  			entity.ColorName = txtColorName.Text.Trim(); 
  			entity.SaleOPID = drpSaleOPID.Text.Trim();
            entity.TestOPID = drpTestOPID.Text.Trim(); 
  			entity.ItemSource = txtItemSource.Text.Trim(); 
  			entity.SXShrinkageJX = SysConvert.ToDecimal(txtSXShrinkageJX.Text.Trim()); 
  			entity.SXShrinkageWX = SysConvert.ToDecimal(txtSXShrinkageWX.Text.Trim()); 
  			entity.YTShrinkageJX = SysConvert.ToDecimal(txtYTShrinkageJX.Text.Trim()); 
  			entity.YTShrinkageWX = SysConvert.ToDecimal(txtYTShrinkageWX.Text.Trim()); 
  			entity.MakeOPID = txtMakeOPID.Text.Trim(); 
  			entity.MakeOPName = txtMakeOPName.Text.Trim(); 
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.CheckOPID = txtCheckOPID.Text.Trim(); 
  			entity.CheckDate = txtCheckDate.DateTime.Date; 
  			 
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private TestReportDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            TestReportDts[] entitydts = new TestReportDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new TestReportDts();
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
                    
                    entitydts[index].TProject = SysConvert.ToString(gridView1.GetRowCellValue(i, "TProject")); 
  			 		entitydts[index].EvaluationGrade = SysConvert.ToString(gridView1.GetRowCellValue(i, "EvaluationGrade")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
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
                if (HTFormStatus == FormStatus.新增)
                {
                    ProductCommon.FormNoIniSet(txtFormNo, "WO_TestReport", "FormNo", 0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 其它事件
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
                    frm.SelectItemType = SysConvert.ToInt32(ProductParamSet.GetIntValueByID(5413)); //0：表示只支持加载产品  1：表示只支持选择加载产品或者坯布  2:表示坯布


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
                    txtItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                    txtItemModel.Text = SysConvert.ToString(dt.Rows[0]["ItemModel"]);
                    txtItemName.Text = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                    txtItemStd.Text = SysConvert.ToString(dt.Rows[0]["ItemStd"]);

                }
            }
        }
        #endregion
        #region 加载合同

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSaleLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {

                    frmLoadOrder frm = new frmLoadOrder();
                    frm.CheckFlag2 = 1;

                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.OrderID != null && frm.OrderID.Length != 0)
                    {
                        //SetGridView1();// 防止一个采购单出现两个合同的数据
                        for (int i = 0; i < frm.OrderID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.OrderID[i]);
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

        private void setItemNews2(string p_Str)
        {
            string[] orderid = p_Str.Split(',');

            string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[0]));
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {

                txtOrderFormNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
               
                txtItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                txtItemModel.Text = SysConvert.ToString(dt.Rows[0]["ItemModel"]);
                txtItemName.Text = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                txtItemStd.Text = SysConvert.ToString(dt.Rows[0]["ItemStd"]);
                
                txtColorNum.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                txtColorName.Text = SysConvert.ToString(dt.Rows[0]["ColorName"]);



            }

        }
        #endregion

    }
}