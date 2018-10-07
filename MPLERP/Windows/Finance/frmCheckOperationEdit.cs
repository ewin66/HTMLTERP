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
    public partial class frmCheckOperationEdit : frmAPBaseUIFormEdit
    {
        public frmCheckOperationEdit()
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
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入开票单号");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择供应商/客户");
                drpVendorID.Focus();
                return false;
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) == "")
            {
                this.ShowMessage("请选择业务员");
                drpSaleOPID.Focus();
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
            CheckOperationDtsRule rule = new CheckOperationDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            CheckOperationRule rule = new CheckOperationRule();
            CheckOperation entity = EntityGet();
            CheckOperationDts[] entitydts = EntityDtsGet();
            decimal TotalCheckAmount = 0;
            decimal TotalCheckQty = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalCheckAmount+=SysConvert.ToDecimal(entitydts[i].DCheckAmount);
                TotalCheckQty += SysConvert.ToDecimal(entitydts[i].DCheckQty);
            }
            entity.TotalQty = TotalCheckQty;
            entity.TotalCheckAmount=TotalCheckAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CheckOperationRule rule = new CheckOperationRule();
            CheckOperation entity = EntityGet();
            CheckOperationDts[] entitydts = EntityDtsGet();
            decimal TotalCheckAmount = 0;
            decimal TotalCheckQty = 0;
            for (int i = 0; i < entitydts.Length; i++)
            {
                TotalCheckAmount+=SysConvert.ToDecimal(entitydts[i].DCheckAmount);
                TotalCheckQty += SysConvert.ToDecimal(entitydts[i].DCheckQty);
            }
            entity.TotalCheckAmount=TotalCheckAmount;
            entity.TotalQty = TotalCheckQty;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            CheckOperation entity = new CheckOperation();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtOrderCode.Text = entity.OrderCode.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate;
            drpVendorID.EditValue = entity.VendorID;
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtDVendorCon.Text = entity.DVendorCon.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
  			txtTotalAmount.Text = entity.TotalAmount.ToString(); 
  			txtTotalCheckAmount.Text = entity.TotalCheckAmount.ToString();
            txtTotalCheckQty.Text = entity.TotalQty.ToString();
            drpDZType.EditValue = entity.DZTypeID;
  			
  			
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
            CheckOperationRule rule = new CheckOperationRule();
            CheckOperation entity = EntityGet();
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
         
             txtMakeDate.DateTime = DateTime.Now;
             drpDZType.EditValue = FormListAID;
             txtFormNo_DoubleClick(null, null);
             drpSaleOPID.EditValue = FParamConfig.LoginID;


        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI
            //Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
            Common.BindDZType(drpDZType, true);
            this.HTDataTableName = "Finance_CheckOperation";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "DLOADID", "DLOADSEQ", "DCheckQty" };//数据明细校验必须录入字段
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载数据", false, btnLoad_Click);
            Common.BindOP(drpSaleOPID, true);
            new VendorProc(drpVendorID);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckOperation EntityGet()
        {
            CheckOperation entity = new CheckOperation();
            entity.ID = HTDataID;
            entity.SelectByID();
            
  			entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.OrderCode = txtOrderCode.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
  			entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.FormDate = DateTime.Now.Date;
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.DVendorCon = txtDVendorCon.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
  			entity.TotalAmount = SysConvert.ToDecimal(txtTotalAmount.Text.Trim()); 
  			entity.TotalCheckAmount = SysConvert.ToDecimal(txtTotalCheckAmount.Text.Trim());
            entity.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
  			 
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckOperationDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            CheckOperationDts[] entitydts = new CheckOperationDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new CheckOperationDts();
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
                    
                    entitydts[index].DLOADID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADID")); 
  			 		entitydts[index].DLOADSEQ = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADSEQ")); 
  			 		entitydts[index].DLOADNO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLOADNO"));
                    entitydts[index].DLOADDtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DLOADDtsID")); 
  			 		entitydts[index].DCheckQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DCheckQty")); 
  			 		entitydts[index].DCheckSinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "DCheckSinglePrice"));
                    entitydts[index].DCheckAmount = entitydts[index].DCheckQty * entitydts[index].DCheckSinglePrice;
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion



        #region 其它事件
        /// <summary>
        /// 双击加载单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.对账单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 加载
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (Common.CheckLookUpEditBlank(drpVendorID))
                    {
                        this.ShowMessage("请选择"+lblVendor.Text.ToString());
                        return;
                    }
                    if (SysConvert.ToInt32(drpDZType.EditValue) == 0)
                    {
                        this.ShowMessage("请选择对账类型");
                        return;
                    }
                    
                    frmLoadIOForm frm = new frmLoadIOForm();
                    frm.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
                    frm.HTLoadConditionStr = " AND ISNULL(DZFlag,0)=0" + " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));//只查询未对账
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.DtsID != null && frm.DtsID.Length != 0)
                    {
                        for (int i = 0; i < frm.DtsID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.DtsID[i]);
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

        private void setItemNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WH_IOFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(i, "DLOADID", SysConvert.ToString(dt.Rows[0]["ID"]));
                    gridView1.SetRowCellValue(i, "DLOADSEQ", SysConvert.ToString(dt.Rows[0]["Seq"]));
                    gridView1.SetRowCellValue(i, "DLOADNO", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "DLOADDtsID", SysConvert.ToString(dt.Rows[0]["DtsID"]));

                    gridView1.SetRowCellValue(i, "FormNM", SysConvert.ToString(dt.Rows[0]["FormNM"]));
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(i, "WHFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(i, "WHFormDate", SysConvert.ToString(dt.Rows[0]["FormDate"]));
                    gridView1.SetRowCellValue(i, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    if (SysConvert.ToString(dt.Rows[0]["Qty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "Qty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                        gridView1.SetRowCellValue(i, "DCheckQty", SysConvert.ToString(dt.Rows[0]["Qty"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["SinglePrice"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "SinglePrice", SysConvert.ToString(dt.Rows[0]["SinglePrice"]));
                        gridView1.SetRowCellValue(i, "DCheckSinglePrice", SysConvert.ToString(dt.Rows[0]["SinglePrice"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["Amount"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "Amount", SysConvert.ToString(dt.Rows[0]["Amount"]));
                        gridView1.SetRowCellValue(i, "DCheckAmount", SysConvert.ToString(dt.Rows[0]["Amount"]));
                    }
                    if (SysConvert.ToString(dt.Rows[0]["PieceQty"]) != string.Empty)
                    {
                        gridView1.SetRowCellValue(i, "PieceQty", SysConvert.ToString(dt.Rows[0]["PieceQty"]));
                    }
                   

                }
            }
        }

        /// <summary>
        /// 根据对账类型取得客户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpDZType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpDZType.EditValue) != 0)
                {
                    int DZType = SysConvert.ToInt32(drpDZType.EditValue);
                    Common.BindVendorByDZTypeID(drpVendorID, DZType,true);
                    //switch (DZType)
                    //{
                    //    case (int)EnumDZType.采购:
                    //        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
                    //        lblVendor.Text = "供应商";
                    //        break;
                    //    case (int)EnumDZType.加工:
                    //        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
                    //        lblVendor.Text = "加工厂";
                    //        break;
                    //    case (int)EnumDZType.销售:
                    //        Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
                    //        lblVendor.Text = "客户";
                    //        break;

                    //}
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region 提交、撤销提交处理
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                CheckOperationRule rule = new CheckOperationRule();
                rule.RSubmit(HTDataID, 1);

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 撤销提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmitCancel_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                CheckOperationRule rule = new CheckOperationRule();
                rule.RSubmit(HTDataID,0);

                FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
        


    }
}