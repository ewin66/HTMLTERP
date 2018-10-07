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
    public partial class frmItemTestFormEdit : frmAPBaseUIFormEdit
    {
        public frmItemTestFormEdit()
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
                this.ShowMessage("请输入单号");
                txtFormNo.Focus();
                return false;
            }


            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择受检单位");
                drpVendorID.Focus();
                return false;
            }

            //if (txtBGType.Text.Trim() == "")
            //{
            //    this.ShowMessage("请选择报告类型");
            //    txtBGType.Focus();
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
            ItemTestFormDtsRule rule = new ItemTestFormDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            ItemTestFormRule rule = new ItemTestFormRule();
            ItemTestForm entity = EntityGet();
            ItemTestFormDts[] entitydts = EntityDtsGet();
          
            //decimal TFree = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TFree += entitydts[i].TFree;
            //}
            //entity.TestFee = TFree;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ItemTestFormRule rule = new ItemTestFormRule();
            ItemTestForm entity = EntityGet();
            ItemTestFormDts[] entitydts = EntityDtsGet();
            //decimal TFree = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TFree += entitydts[i].TFree;
            //}
            //entity.TestFee = TFree;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            ItemTestForm entity = new ItemTestForm();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
  			txtFormNo.Text = entity.FormNo.ToString();
            txtShopID.Text = entity.ShopID.ToString();
  			txtSendDate.DateTime = entity.SendDate; 
  			txtRecDate.DateTime = entity.RecDate; 
  			txtBGNo.Text = entity.BGNo.ToString(); 
  			txtItemCode.Text = entity.ItemCode.ToString(); 
  			txtGoodsCode.Text = entity.GoodsCode.ToString(); 
  			txtColorNum.Text = entity.ColorNum.ToString(); 
  			txtColorName.Text = entity.ColorName.ToString(); 
  			txtItemName.Text = entity.ItemName.ToString();
            drpFormStatus.EditValue = entity.FormStatus; 
  			txtTestFee.Text = entity.TestFee.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            drpCheckComID.EditValue = entity.CheckComID;
            SetTestContext(chkLamp1, entity.TestContext);
            drpYCheckComID.EditValue = entity.YCheckComID;
            txtFormXZ.Text = entity.FormXZ;
            txtBGType.Text = entity.BGType.ToString();
            drpVendorID.EditValue = SysConvert.ToString(entity.VendorID);
            drpVendorID2.EditValue = SysConvert.ToString(entity.VendorID2);
            drpVendorID3.EditValue = SysConvert.ToString(entity.VendorID3);
            drpVendorID4.EditValue = SysConvert.ToString(entity.VendorID4);
            txtOrderQty.Text = entity.OrderQty.ToString();
            txtDLoadID.Text = entity.DLoadID.ToString();
            txtItemModel.Text = entity.ItemModel.ToString();
            txtItemStd.Text = entity.ItemStd.ToString();
            txtKDForm.Text = entity.KDForm.ToString();
            txtUsed.Text = entity.Used.ToString();
            txtHTNo.Text = entity.HTNo.ToString();
            txtYBGNo.Text = entity.YBGNo;
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            txtItemClass.Text = entity.ItemClass.ToString();
            txtFPNO.Text = entity.FPNO.ToString();
            txtFPDate.DateTime = entity.FPDate;
            drpJYOpName.EditValue = entity.JYOPName.ToString();
           
            if (entity.JSFlag == 1)
            {
                chkJSFlag.Checked = true;
            }
            else
            {
                chkJSFlag.Checked = false;
            }
            txtJSFree.Text = entity.JSFree.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;

            if (!findFlag)
            {
               
            }

            BindGridDts();
        }

        /// <summary>
        /// 设置所属公司类型
        /// </summary>
        private void SetTestContext(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList, string p_CheckValus)
        {
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                p_CheckList.SetItemCheckState(i, CheckState.Unchecked);
            }
            string[] VenodrTypes = p_CheckValus.Split(',');

            foreach (string dr in VenodrTypes)
            {
                for (int i = 0; i < p_CheckList.ItemCount; i++)
                {
                    if (dr == p_CheckList.GetItemValue(i).ToString())//
                    {
                        p_CheckList.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ItemTestFormRule rule = new ItemTestFormRule();
            ItemTestForm entity = EntityGet();
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
            txtSendDate.DateTime = DateTime.Now.Date;
            txtRecDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtFPDate.DateTime = DateTime.Now.Date;
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Att_ItemTestForm";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "CheckItem" };//数据明细校验必须录入字段
           
            Common.BindCLS(drpFormStatus, "Att_ItemTestForm", "FormStatus", true);
            Common.BindCSBGItem(chkLamp1, true);
           

            Common.BindCLS(txtBGType, "Attn_ItemTestForm", "BGType", true);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载合同", false, btnLoad_Click);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载产品", false, btnCPLoad_Click);
        }
        public override void IniRefreshData()
        {
            Common.BindVendor(drpCheckComID, new int[] { (int)EnumVendorType.检测机构 }, true);

            Common.BindVendor(drpYCheckComID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpYCheckComID);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);

            Common.BindVendor(drpVendorID2, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID2);

            Common.BindVendor(drpVendorID3, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID3);

            Common.BindVendor(drpVendorID4, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID4);
            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.业务部 }, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemTestForm EntityGet()
        {
            ItemTestForm entity = new ItemTestForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
            entity.MakeDate = DateTime.Now.Date;
            entity.ShopID = SysConvert.ToString(txtShopID.Text.Trim());
            entity.FormDate = DateTime.Now.Date;
  			entity.SendDate = txtSendDate.DateTime.Date; 
  			entity.RecDate = txtRecDate.DateTime.Date; 
  			entity.BGNo = txtBGNo.Text.Trim(); 
  			entity.ItemCode = txtItemCode.Text.Trim(); 
  			entity.GoodsCode = txtGoodsCode.Text.Trim(); 
  			entity.ColorNum = txtColorNum.Text.Trim(); 
  			entity.ColorName = txtColorName.Text.Trim(); 
  			entity.ItemName = txtItemName.Text.Trim();
            entity.CheckComID = SysConvert.ToString(drpCheckComID.EditValue);
            entity.FormStatus = SysConvert.ToString(drpFormStatus.EditValue);
  			entity.TestFee = SysConvert.ToDecimal(txtTestFee.Text.Trim());
            entity.TestContext = GetCheckCSItem(chkLamp1);
  			entity.YBGNo = txtYBGNo.Text.Trim(); 
  			entity.YCheckComID =SysConvert.ToString(drpYCheckComID.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            entity.FormXZ = txtFormXZ.Text.Trim();
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.VendorID2 = SysConvert.ToString(drpVendorID2.EditValue);
            entity.VendorID3 = SysConvert.ToString(drpVendorID3.EditValue);
            entity.VendorID4 = SysConvert.ToString(drpVendorID4.EditValue);
            entity.JSFree = SysConvert.ToDecimal(txtJSFree.Text.Trim());
            entity.JSFlag = SysConvert.ToInt32(chkJSFlag.Checked);
            entity.ItemModel = txtItemModel.Text.Trim();
            entity.ItemStd = txtItemStd.Text.Trim();
            entity.Used = txtUsed.Text.Trim();
            entity.KDForm = txtKDForm.Text.Trim(); 
            entity.HTNo = txtHTNo.Text.Trim();
            entity.DLoadID = SysConvert.ToInt32(txtDLoadID.Text.Trim());
            entity.BGType = txtBGType.Text.Trim();
            entity.OrderQty = txtOrderQty.Text.Trim();
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);
            entity.ItemClass = txtItemClass.Text.Trim();
            entity.FPNO = txtFPNO.Text.Trim();
            entity.FPDate = txtFPDate.DateTime.Date;
            entity.JYOPName = SysConvert.ToString(drpJYOpName.EditValue);
            
            if (entity.JSFlag == 1)
            {
                entity.JSDate = DateTime.Now.Date;
            }
            return entity;
        }


        /// <summary>
        /// 获取测试内容
        /// </summary>
        /// <param name="p_CheckList"></param>
        /// <returns></returns>
        private string GetCheckCSItem(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList)
        {
            string MLLB = string.Empty;
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                if (p_CheckList.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (MLLB == string.Empty)
                    {
                        MLLB += p_CheckList.GetItemValue(i).ToString();
                    }
                    else
                    {
                        MLLB += "," + p_CheckList.GetItemValue(i).ToString();
                    }

                }
            }
            return MLLB;
        }
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemTestFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            ItemTestFormDts[] entitydts = new ItemTestFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new ItemTestFormDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    
                    entitydts[index].Sort = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "Sort")); 
  			 		entitydts[index].CheckItem = SysConvert.ToString(gridView1.GetRowCellValue(i, "CheckItem")); 
  			 		entitydts[index].CheckUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "CheckUnit")); 
  			 		entitydts[index].TecReq = SysConvert.ToString(gridView1.GetRowCellValue(i, "TecReq")); 
  			 		entitydts[index].CheckResult = SysConvert.ToString(gridView1.GetRowCellValue(i, "CheckResult")); 
  			 		entitydts[index].PJ = SysConvert.ToString(gridView1.GetRowCellValue(i, "PJ"));
                    entitydts[index].TFree = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "TFree")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

     
        /// <summary>
        /// 双击生成测试单号
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
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.检验单号);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 产品编码回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 双击产品编码弹出挂板信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frmLoadItemGB frm = new frmLoadItemGB();
                frm.ShowDialog();
                string str = string.Empty;
                if (frm.GBID != null && frm.GBID.Length != 0)
                {
                    if (frm.GBID.Length > 1)
                    {
                        this.ShowMessage("请只选择一条挂板信息");
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
                   
                }
                setItemNews(str);
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
                txtGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                txtColorNum.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                txtColorName.Text = SysConvert.ToString(dt.Rows[0]["ColorName"]);
                txtItemName.Text = SysConvert.ToString(dt.Rows[0]["ItemName"]);
               

            }
        }

        private void chkLamp1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                string outstr = string.Empty;
                string outValue = string.Empty;
                for (int i = 0; i < chkLamp1.ItemCount; i++)
                {
                    if (chkLamp1.GetItemCheckState(i) == CheckState.Checked)
                    {
                        if (outstr != string.Empty)
                        {
                            outstr += ",";
                            outValue += ",";
                        }
                        outstr += chkLamp1.GetItemText(i).ToString();
                        outValue += chkLamp1.GetItemValue(i).ToString();
                    }
                }
                drpLamp1.EditValue = outstr;
                Common.BindCheckItem(resdrpCheckItem, outValue, true);
                if (outValue != "")
                {
                    SetGrid(outValue);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 根据测试内容得到测试项目
        /// </summary>
        /// <param name="p_outValue"></param>
        private void SetGrid(string p_outValue)
        {
            string sql = "SELECT 0 ID,0 MainID,0 Seq,null Sort,'' CheckResult,'' PJ,DtsName CheckItem,DW CheckUnit,JSYQ TecReq,CSFree TFree FROM UV1_Data_CSBGItemDts WHERE ID IN(" + p_outValue + ")";
            DataTable dt = SysUtils.Fill(sql);
            if(dt.Rows.Count>0)
            {
                gridView1.GridControl.DataSource=dt;
                gridView1.GridControl.Show();
            }
            
        }

        private void resdrpCheckItem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BaseFocusLabel.Focus();
                string chkCheckItem = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CheckItem"));
                string sql = "SELECT DW,JSYQ,CSFree FROM Data_CSBGItemDts WHERE Name=" + SysString.ToDBString(chkCheckItem);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CheckUnit", SysConvert.ToString(dt.Rows[0]["DW"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TecReq", SysConvert.ToString(dt.Rows[0]["JSYQ"]));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TFree", SysConvert.ToDecimal(dt.Rows[0]["CSFree"]));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        #region 其它事件

        /// <summary>
        /// 匹配原报告编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linShowYFormNo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (txtYBGNo.Text.Trim() == "")
                    {
                        this.ShowMessage("请输入原报告编号");
                        txtYBGNo.Focus();
                        return;
                    }
                    string sql = "SELECT * FROM UV1_Att_ItemTestFormDts WHERE MainID IN(SELECT ID FROM Att_ItemTestForm WHERE BGNo=" + SysString.ToDBString(txtYBGNo.Text.Trim()) + ")";
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        SetTestContext(chkLamp1, SysConvert.ToString(dt.Rows[0]["TestContext"]));
                        gridView1.GridControl.DataSource = dt;
                        gridView1.GridControl.Show();
                    }
                    else
                    {
                        this.ShowMessage("原报告编号不存在，请检查");
                        txtYBGNo.Text = "";
                        txtYBGNo.Focus();

                    }
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

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核1))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                ItemTestFormRule rule = new ItemTestFormRule();
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

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核1))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                ItemTestFormRule rule = new ItemTestFormRule();
                rule.RSubmit(HTDataID, 0);

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);

            }
        }
        #endregion

        #region 加载合同

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLoad_Click(object sender, EventArgs e)
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

                txtHTNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                txtDLoadID.Text = SysConvert.ToString(dt.Rows[0]["DtsID"]);
                txtItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                txtItemModel.Text = SysConvert.ToString(dt.Rows[0]["ItemModel"]);
                txtItemName.Text = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                txtItemStd.Text = SysConvert.ToString(dt.Rows[0]["ItemStd"]);
                txtGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                txtColorNum.Text = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                txtColorName.Text = SysConvert.ToString(dt.Rows[0]["ColorName"]);
               


            }

        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        private void btnCPLoad_Click(object sender, EventArgs e)
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
                        setCPItemNews(str);
                    }


                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setCPItemNews(string str)
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
                    txtGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                    

                }
            }
        }
       
        #endregion

        private void drpCheckComID_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (SysConvert.ToString(drpCheckComID.EditValue) != string.Empty)
                {

                    Common.BindVendorContact(drpJYOpName, SysConvert.ToString(drpCheckComID.EditValue), true);
                   
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       


    }
}