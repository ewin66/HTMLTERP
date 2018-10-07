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
using System.Collections;
using DevComponents.DotNetBar;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 　
    /// </summary>
    public partial class frmCheckFormEdit : frmAPBaseUIFormEdit
    {
        public frmCheckFormEdit()
        {
            InitializeComponent();
        }

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtVendorName.Text.Trim() == "")
            {
                this.ShowMessage("请输入客户");
                txtVendorName.Focus();
                return false;
            }
            if (SysConvert.ToInt32(drpDataDHID.EditValue) == 0)
            {
                this.ShowMessage("请选择展会");
                drpDataDHID.Focus();
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
            CheckFormDtsRule rule = new CheckFormDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
            lbCount.Text = dtDts.Rows.Count.ToString();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            CheckFormRule rule = new CheckFormRule();
            CheckForm entity = EntityGet();
            CheckFormDts[] entitydts = EntityDtsGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

       

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CheckFormRule rule = new CheckFormRule();
            CheckForm entity = EntityGet();  
            CheckFormDts[] entitydts = EntityDtsGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {

            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);

            CheckForm entity = new CheckForm();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            
            txtFormCode.Text = entity.FormCode.ToString();
            txtFormDate.DateTime = entity.FormDate;
            drpDataDHID.EditValue = entity.DataDHID;
            if (entity.DVendorName == "")
            {
                txtVendorName.Text = Common.GetVendorNameByVendorID(entity.DVendorID);
            }
            else
            {
                txtVendorName.Text = entity.DVendorName.ToString();
            }
            txtVendorID.Text = entity.DVendorID.ToString();
            txtRemark.Text = entity.DRemark.ToString();
            drpBJHB.EditValue = entity.BJHB;
            txtBJHL.Text = entity.BJHL.ToString();
            txtAddress.Text = entity.Address.ToString();
            txtTel.Text = entity.Tel.ToString();
            txtConOPName.Text = entity.ConOPName.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID.ToString();
            drpLevel.EditValue = entity.LevelID;
            if (txtBJHL.Text == "0")
            {
                txtBJHL.Text = "1";
            }
            if (entity.DYFlag == 1)
            {
                chkDYFlag.Checked = true;
            }
            else
            {
                chkDYFlag.Checked = false;
            }

            //if (entity.SubmitFlag == 0)
            //{
            //    label8.Text = "进行中";
            //}
            //else
            //{
            //    label8.Text = "已完成";
            //}
            HTDataSubmitFlag = entity.SubmitFlag;
            BindGridDts();
            lblTime.Text = "扫描时间:" + SysConvert.ToString(gridView1.GetRowCellValue(gridView1.RowCount - 1, "AddTime"));

        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CheckFormRule rule = new CheckFormRule();
            CheckForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);


            //ProcessCtl.ProcControlEdit(new Control[] { txtTotalAmount, txtTotalQty, txtTotalAmount2, txtMakeOPID }, false);
            txtISN.Properties.ReadOnly = false;
            chkScanCancel.Properties.ReadOnly = false;
        }

        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormCode_DoubleClick(null, null);
            txtFormDate.Text = System.DateTime.Now.ToString();
            drpDataDHID.EditValue = GetDefaultDH();
            drpVendorID.EditValue = "";
            txtRemark.Text = "";
            drpBJHB.SelectedIndex = 0;
        }

        private int GetDefaultDH()
        {
            string sql = "SELECT ID FROM ADH_DataDH ORDER BY ID DESC";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// 初始化刷新数据(状体加载时或用户刷新按钮时调用) 代码移动 2009-10-31 standy
        /// </summary>
        public override void IniRefreshData()
        {
 
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "ADH_CheckForm"; 
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ISN"};//数据明细校验必须录入字段
            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindCurrency(drpBJHB, false);
            new VendorProc(drpVendorID);
            Common.BindDHID(drpDataDHID, this.FormListAID, false);
            Common.BindOP(drpSaleOPID, true);
            Common.BindADHLevel(drpLevel, true);
            SetTabIndex(0, groupControlMainten); 
            txtFormCode_DoubleClick(null, null);

            //针对同一个页面不同的菜单上下翻页的设置
            this.SetPosCondition = " AND FormTypeID=" + FormListAID;
        }
        /// <summary>
        /// 重新设置实体1
        /// </summary>
        private void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            string itemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemCode"]));

            //SetStorgeQty(itemCode);//显示库存信息 


            if (SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ISN")) != "")//显示图片
            {
                if (GetPicByCode(SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ISN"))) != null)
                {
                    picSample.Image = TemplatePic.ByteToImage(GetPicByCode(SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ISN"))));
                }
            }
        }

        private byte[] GetPicByCode(string p_Code)
        {
            string sql = "SELECT GBPic FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(p_Code);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return (byte[])dt.Rows[0][0];
            }
            return null;
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckForm EntityGet()
        {
            CheckForm entity = new CheckForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormCode = txtFormCode.Text.Trim();
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.DataDHID = SysConvert.ToInt32(drpDataDHID.EditValue);
            entity.DVendorID = txtVendorID.Text.Trim(); //SysConvert.ToString(drpVendorID.EditValue);
            entity.DVendorName = txtVendorName.Text.Trim();
            entity.DRemark = txtRemark.Text.Trim();
            entity.BJHB = SysConvert.ToString(drpBJHB.EditValue);
            entity.BJHL = SysConvert.ToDecimal(txtBJHL.Text);
            entity.FormTypeID = FormListAID;//得到单据类型
            entity.ConOPName = txtConOPName.Text.Trim();
            entity.Tel = txtTel.Text.Trim();
            entity.Address = txtAddress.Text.Trim();
            entity.DYFlag = SysConvert.ToInt32(chkDYFlag.Checked);
            entity.LevelID = SysConvert.ToInt32(drpLevel.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);

            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            CheckFormDts[] entitydts = new CheckFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new CheckFormDts(); 
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].ISN = SysConvert.ToString(gridView1.GetRowCellValue(i, "ISN"));
                    //entitydts[index].DataGradeID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DataGradeID"));
                    //entitydts[index].SOQtyDesc = SysConvert.ToString(gridView1.GetRowCellValue(i, "SOQtyDesc"));
                    //entitydts[index].SODateDesc = SysConvert.ToString(gridView1.GetRowCellValue(i, "SODateDesc"));
                    entitydts[index].YPQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "YPQty"));
                    entitydts[index].YSQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "YSQty"));
                    //entitydts[index].FreeStr1 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr1"));
                    //entitydts[index].FreeStr2 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr2"));
                    //entitydts[index].FreeStr3 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr3"));
                    //entitydts[index].FreeStr4 = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr4"));
                    entitydts[index].AddTime = System.DateTime.Now;
                    entitydts[index].JYFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "JYFlag"));
                    entitydts[index].DYFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DYFlag"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    index++;
                }
            }
            return entitydts;
        }
 
        #endregion

        private void txtFormCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormNoControlRule rule = new FormNoControlRule();
                txtFormCode.Text = rule.RGetFormNo((int)FormNoControlEnum.样品报价单号);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void txtISN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (this.HTDataID != 0 && txtISN.Text.Trim() != string.Empty)
                {

                    if (e.KeyCode == Keys.Enter)
                    {
                        CheckFormRule rule = new CheckFormRule();
                        if (!chkScanCancel.Checked)
                        {

                            rule.RScan(this.HTDataID, txtISN.Text.Trim(), 1, SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToInt32(drpDataDHID.EditValue), System.DateTime.Now);
                            lbCount.Text = SysConvert.ToInt32((SysConvert.ToInt32(lbCount.Text) - 1)).ToString();
                         
                        }
                        else
                        {
                            rule.RScanCancel(this.HTDataID, txtISN.Text.Trim());
                            lbCount.Text = SysConvert.ToInt32((SysConvert.ToInt32(lbCount.Text) + 1)).ToString();
                        }
                        BindGridDts();
                        lblTime.Text = "扫描时间:" + SysConvert.ToString(gridView1.GetRowCellValue(gridView1.RowCount - 1, "AddTime"));
                        //gridView1.SetRowCellValue(gridView1.FocusedRowHandle+gridView1.RowCount-1, "AddTime", System.DateTime.Now.ToString());
                        ProcessGrid.GridViewFocus(gridView1, new string[1] { "GBCode" }, new string[1] { txtISN.Text.Trim() });
                        txtISN.Text = "";
                        txtISN.Focus();
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
                txtISN.Text = "";
                txtISN.Focus();
            }
        }

        private void drpBJHB_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                string pName = drpBJHB.Text.Trim();
                if (drpBJHB.Text != string.Empty)
                {
                    sql = "SELECT Rate FROM Data_Currency WHERE Name=" + SysString.ToDBString(pName);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        txtBJHL.Text = dt.Rows[0]["Rate"].ToString();
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtVendorID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtVendorID.Text.Trim() == "")
                    {
                        this.ShowMessage("请输入客户代码");
                        txtVendorID.Focus();
                        return;
                    }
                    txtVendorName.Text = Common.GetVendorNameByVendorID(txtVendorID.Text.Trim());
                    txtVendorName.Focus();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       


        ///// <summary>
        ///// 设置一个库存
        ///// </summary>
        //private void SetStorgeQty(string p_ItemCode)
        //{
        //    string sql = string.Empty;
        //    DataTable dt;
        //    decimal tqty = 0;
        //    string tstr = string.Empty;

        //    sql = "SELECT WHID,SectionID,Sum(FreeQty) SQty,ColorName,JarNum,ColorNum FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//查询色纱库存
        //    //sql += " AND ISNULL(ISJK,0)=0";
        //    sql += " GROUP BY WHID,SectionID,ColorNum,JarNum,ColorName ORDER BY SQty DESC";
        //    dt = SysUtils.Fill(sql);
        //    tqty = 0;
        //    tstr = string.Empty;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        tqty += SysConvert.ToDecimal(dr["SQty"]);
        //        tstr += Environment.NewLine + "库区：" + "" + " " + dr["SectionID"].ToString() + " 颜色：" + dr["ColorName"].ToString() + " 色号：" + dr["ColorNum"].ToString() + "   缸号：" + dr["JarNum"].ToString() + "   数量：" + SysConvert.ToDecimal(dr["SQty"]) + "KG";
        //    }
        //    tstr = "面料库存合计:" + tqty.ToString() + "KG" + tstr;//明细：



        //    decimal tqtyY = 0;
        //    string tstrY = string.Empty;
        //    //sql = "Select * from UV1_Data_ItemDts where ItemCode=" + SysString.ToDBString(p_ItemCode);
        //    //sql += " AND ISNULL(DtsItemCode,'')<>''";//明细数据不为空
        //    //dt = SysUtils.Fill(sql);
        //    //if (dt.Rows.Count != 0)
        //    //{
        //    //    for (int i = 0; i < dt.Rows.Count; i++)
        //    //    {
        //    //        sql = "SELECT WHID,SectionID,ItemCode,ItemName,ItemStd,ItemModel,Sum(FreeQty) SQty,ColorName,JarNum,ColorNum FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["DtsItemCode"]));//查询色纱库存
        //    //        //sql += " AND ISNULL(ISJK,0)=0";
        //    //        sql += " GROUP BY WHID,SectionID,ItemCode,ItemName,ItemStd,ItemModel,ColorNum,JarNum,ColorName ORDER BY SQty DESC";
        //    //        DataTable dtT = SysUtils.Fill(sql);
        //    //        foreach (DataRow dr in dtT.Rows)
        //    //        {
        //    //            tqtyY += SysConvert.ToDecimal(dr["SQty"]);
        //    //            tstrY += Environment.NewLine + "库区：" + "" + " " + dr["SectionID"].ToString() + " 原料：" + dr["ItemCode"].ToString() + " " + dr["ItemModel"].ToString() + " " + dr["ItemStd"].ToString() + " " + dr["ItemName"].ToString();
        //    //            tstrY += " 颜色：" + dr["ColorName"].ToString() + " 色号：" + dr["ColorNum"].ToString() + "   缸号：" + dr["JarNum"].ToString() + "   数量：" + SysConvert.ToDecimal(dr["SQty"]) + "KG";
        //    //        }
        //    //    }
        //    //    tstrY = "原料库存合计:" + tqtyY.ToString() + "KG" + tstrY;//明细：
        //    //}

        //    txtWHStorgeQty.Text = tstr + Environment.NewLine + tstrY;

        //}

 
    }
}