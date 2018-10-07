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
    /// <summary>
    /// 功能：期初入库管理
    /// </summary>
    public partial class frmDefaultInWHEdit : frmAPBaseUIWHFormEdit
    {
        public frmDefaultInWHEdit()
        {
            InitializeComponent();
        }



        #region 全局变量
        int HeadType = 0;
        #endregion


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入单号");
                txtFormNo.Focus();
                return false;
            }
            if (SysConvert.ToString(drpWHTypeID.EditValue) == "")
            {
                this.ShowMessage("请选择仓库类型");
                drpWHTypeID.Focus();
                return false;
            }
            if (SysConvert.ToString(drpSubType.EditValue) == "")
            {
                this.ShowMessage("请选择入库类型");
                drpSubType.Focus();
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
            IOFormDtsRule rule = new IOFormDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            IOFormDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            IOFormDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();


            HTDataFormNo = entity.FormNo;

            txtFormIOFormID.Text = entity.FromIOFormID.ToString();
            drpCompanyTypeID.EditValue = SysConvert.ToInt32(entity.CompanyTypeID);
            txtFormNo.Text = entity.FormNo.ToString();
            //txtHeadType.Text = entity.HeadType.ToString();
            txtHeadType.Text = this.HeadType.ToString();
            drpSubType.EditValue = SysConvert.ToInt32(entity.SubType);
            drpVendorID.EditValue = entity.VendorID.ToString();
            txtFormDate.DateTime = entity.FormDate;
            drpWHID.EditValue = entity.WHID.ToString();
            drpWHTypeID.EditValue = SysConvert.ToInt32(entity.WHTypeID);
      
            txtOutDep.Text = entity.OutDep.ToString();
            //txtInDep.Text = entity.InDep.ToString();
            txtWHOP.Text = entity.WHOP.ToString();
            txtPassOP.Text = entity.PassOP.ToString();
            drpDutyOP.EditValue = entity.DutyOP.ToString();
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
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
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
            drpWHTypeID.EditValue = Common.GetWHTypeByFormListID(this.FormListAID);

            //if (Common.GetWHTypeByFormListID(this.FormListAID) == 0)
            //{
            //    Common.BindSubType(drpSubType, FormListAID, true);//绑定SubType              
            //}

            txtFormDate.DateTime = DateTime.Now.Date;


            drpWHTypeID.Properties.ReadOnly = true;

            drpCompanyTypeID.EditValue = 1;
           
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode" };//数据明细校验必须录入字段

            this.RightFormID = this.GetFormIDByClassName("frmIOForm");

            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[] { "ItemCode", "ItemName", "ItemStd" }, drpGridItemCode, txtGridItemName, new int[] { 1 }, "", "ItemModel", true, true);

            Common.BindWHType(drpWHTypeID, false);
            Common.BindWH(drpWHID,this.FormListBID, true);

            Common.BindCompanyType(drpCompanyTypeID, true);
            Common.BindOPID(drpDutyOP, true);
            Common.BindCLS(drpGridYarnStatus, "Sale", "YarnType", true);//纱线形态
            Common.BindYarnType(drpYarnTypeID, true);//纱类
            Common.BindCLS(drpUnit, "Item", "ItemUnit", true);//计量单位
            this.SetPosCondition = " AND HeadType=" + this.FormListAID;
            this.SetPosCondition += " AND SubType in(Select ID FROM  Enum_FormList WHERE IsShow=1 )";
            this.SetPosCondition += " AND WHID in(Select WHID FROM  WH_WH WHERE IsJK=0 )";


            SetTabIndex(0, groupControlMainten);
            new VendorProc(drpVendorID);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FromIOFormID = SysConvert.ToInt32(txtFormIOFormID.Text.Trim());
            entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue);
            entity.FormNo = txtFormNo.Text.Trim();
            entity.HeadType = SysConvert.ToInt32(txtHeadType.Text.Trim());
            entity.HeadType = this.HeadType;
            entity.SubType = SysConvert.ToInt32(drpSubType.EditValue);
            entity.VendorID =SysConvert.ToString(drpVendorID.EditValue);
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            entity.WHTypeID = SysConvert.ToInt32(drpWHTypeID.EditValue);
           
            entity.OutDep = txtOutDep.Text.Trim();
            //entity.InDep = txtInDep.Text.Trim();
            entity.WHOP = txtWHOP.Text.Trim();
            entity.PassOP = txtPassOP.Text.Trim();
            entity.DutyOP =SysConvert.ToString(drpDutyOP.EditValue);
            entity.Remark = txtRemark.Text.Trim();


            if (HTFormStatus == FormStatus.新增)
            {
                // entity.MakeOPID = FParamConfig.LoginID;
               // entity.MakeDate = DateTime.Now.Date;
            }


            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            IOFormDts[] entitydts = new IOFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new IOFormDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].WHTypeID = SysConvert.ToInt32(drpWHTypeID.EditValue);

                    entitydts[index].CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue);//公司类型
               
                    entitydts[index].WHID = SysConvert.ToString(drpWHID.EditValue);
                    entitydts[index].SectionID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SectionID"));
                    entitydts[index].SBitID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SBitID"));
                    entitydts[index].DtsVendorID = SysConvert.ToString(drpVendorID.EditValue);
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch"));
                    entitydts[index].VendorBatch = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorBatch"));
                    entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    //entitydts[index].DesignNO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DesignNO"));
             
              
                    entitydts[index].YarnStatus = SysConvert.ToString(gridView1.GetRowCellValue(i, "YarnStatus"));
                    //entitydts[index].YarnTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "YarnTypeID"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount"));
                    entitydts[index].WAmount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "WAmount"));
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                   
                    entitydts[index].DtsSaleOPID = SysConvert.ToString(drpDutyOP.EditValue);
                    //entitydts[index].PackNum = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PackNum"));
               
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
           


                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region 其它事件
        /// <summary>
        /// 双击生成单号
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
                    txtFormNo.Text = rule.RGetWHFormNo(this.FormListAID, SysConvert.ToInt32(drpSubType.EditValue), SysConvert.ToString(drpWHID.EditValue));
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
                //if (!HTSubmitCheck(FormStatus.提交))
                //{
                //    return;
                //}

                //HTSubmit(HTDataTableName, HTDataID.ToString());

              
                IOFormRule rule = new IOFormRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.已提交);
              
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
                //if (!HTSubmitCheck(FormStatus.提交))
                //{
                //    return;
                //}

                //HTSubmit(HTDataTableName, HTDataID.ToString());


                IOFormRule rule = new IOFormRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.未提交);

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
        #endregion


        #region 绑定相关
        /// <summary>
        /// 入库类型改变绑定不同的客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpSubType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    txtFormNo_DoubleClick(sender, e);
                }

                string sql = "SELECT WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(SysConvert.ToString(drpSubType.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    drpWHTypeID.EditValue = SysConvert.ToInt32(dt.Rows[0][0]);
                }

                if (SysConvert.ToInt32(drpSubType.EditValue) == (int)WHFormList.期初入库)
                {
                }
                   new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[] { "ItemCode", "ItemName", "ItemStd" }, drpGridItemCode, txtGridItemName, new int[] { (int)EnumItemType.面料 }, "", "ItemModel", true, true);
              
                //Common.BindVendorByFormListID(drpVendorID, SysConvert.ToInt32(drpSubType.EditValue), true);//设置客户
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 仓库类型改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpWHTypeID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //this.HeadType = GetHeadType(SysConvert.ToInt32(drpWHTypeID.EditValue));
                this.HeadType = 9;
                Common.BindSubType(drpSubType, HeadType, true);//绑定SubType              

                //this.FormListTopType = Common.GetFormListTopTypeByFormListID(formtype);//获得单据的上一级单据类型
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        /// <summary>
        /// 得到HeadType
        /// </summary>
        /// <param name="p_WHType"></param>
        /// <returns></returns>
        private int GetHeadType(int p_WHType)
        {

            string sql = "SELECT ID From Enum_FormList WHERE WHTypeID=" + SysString.ToDBString(p_WHType);
            sql += " AND WHQtyPosID=1 AND ParentID in(1,2)";//入库

            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                return SysConvert.ToInt32(dt.Rows[0]["ID"]);
            }
            else
            {
                return 0;
            }

        }
        #endregion


        /// <summary>
        /// 双击加载相关单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGridDtsSO_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT WHSpeciaTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(SysConvert.ToString( drpSubType.EditValue));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 仓库改变绑定区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpWHID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Common.BindSection(drpCSectionID, SysConvert.ToString(drpWHID.EditValue), false);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 重载事件（打印相关）
        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnPreview_Click(sender, e);
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.转PDF, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnPrint_Click(sender, e);

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.打印, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        /// <summary>
        /// 设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnDesign_Click(sender, e);
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交3))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.设计, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion    
        /// <summary>
        /// 标重净重金额计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemQty_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal Qty = 0;
                decimal Price = 0;
                decimal Amount = 0;
                decimal Weight = 0;
                decimal WAmount = 0;
                Price = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SinglePrice"));
                Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Qty"));

                Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Weight"));
                Amount = Qty * Price;

                WAmount = Weight * Price;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Amount", Amount);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "WAmount", WAmount);

                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "DiffWeight", (Weight - Qty));

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpCSectionID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                Common.BindSBit(drpCSBitID, SysConvert.ToString(drpWHID.EditValue), SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SectionID")), false);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

    }
}