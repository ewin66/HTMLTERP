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
    public partial class frmSOPlanEdit : frmAPBaseUISinEdit
    {
        public frmSOPlanEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtQty.Text.Trim() == "")
            {
                this.ShowMessage("请输入生产数量");
                txtQty.Focus();
                return false;
            }            

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            SOPlanRule rule = new SOPlanRule();
            SOPlan entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            SOPlanRule rule = new SOPlanRule();
            SOPlan entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            SOPlan entity = new SOPlan();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.Code;

            drpCompanyTypeID.EditValue =entity.CompanyTypeID; 
  			txtCode.Text = entity.Code.ToString(); 
  			drpVendorID.EditValue = entity.VendorID.ToString(); 
  			txtInDate.DateTime = entity.InDate;
            if (entity.NeedDate != SystemConfiguration.DateTimeDefaultValue && SysConvert.ToString(entity.NeedDate) != "")
            {
                txtNeedDate.DateTime = entity.NeedDate;
            }
            else
            {
                txtNeedDate.Text = "";
            }
  			txtSO.Text = entity.SO.ToString(); 
  			drpItemCode.EditValue = entity.ItemCode.ToString(); 
  			txtItemName.Text = entity.ItemName.ToString(); 
  			txtItemStd.Text = entity.ItemStd.ToString(); 
  			txtItemModel.Text = entity.ItemModel.ToString(); 
  			txtCompactQty.Text = entity.CompactQty.ToString(); 
  			txtQty.Text = entity.Qty.ToString();
            drpItemUnit.EditValue = entity.ItemUnit;
            txtMakeOPID.Text = Common.GetOPName(entity.MakeOPID.ToString());
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtRemark.Text = entity.Remark.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            SOPlanRule rule = new SOPlanRule();
            SOPlan entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { txtCode,txtMakeDate,txtMakeOPID}, false);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_SOPlan";
            //
            //Common.BindCompanyType(drpCompanyTypeID, true);//绑定公司别
            //Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.全部 }, true);//客户
            //new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, txtItemModel, new int[] {  (int)EnumItemType.面料 }, true, true);
           
            this.ToolBarItemAdd(28, "btnLoad", "加载", false, btnCheckLoad_Click);

            SetTabIndex(0, groupControlMainten);

        }


        /// <summary>
        /// 初始化刷新数据(窗体加载时或用户刷新按钮时调用)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindCompanyType(drpCompanyTypeID, true);//绑定公司别
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.全部 }, true);//客户
            new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, txtItemModel, new int[] { (int)EnumItemType.面料 }, true, true);
        }
        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);
            txtNeedDate.Text = "";
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtInDate.DateTime = DateTime.Now.Date;
            txtCompactQty.Text = Common.TrimZero(txtCompactQty.Text);
            txtQty.Text = Common.TrimZero(txtQty.Text);

            drpCompanyTypeID.EditValue = 1;
            drpItemUnit.EditValue = "KG";
            
            txtCode_DoubleClick(null,null);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SOPlan EntityGet()
        {
            SOPlan entity = new SOPlan();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue); 
  			entity.Code = txtCode.Text.Trim(); 
  			entity.VendorID =SysConvert.ToString(drpVendorID.EditValue); 
  			entity.InDate = txtInDate.DateTime.Date;

            if (txtNeedDate.DateTime.Date != SystemConfiguration.DateTimeDefaultValue && txtNeedDate.Text.Trim() != "")
            {
                entity.NeedDate = txtNeedDate.DateTime.Date;
            }
  			entity.SO = txtSO.Text.Trim(); 
  			entity.ItemCode =SysConvert.ToString(drpItemCode.EditValue); 
  			entity.ItemName = txtItemName.Text.Trim(); 
  			entity.ItemStd = txtItemStd.Text.Trim(); 
  			entity.ItemModel = txtItemModel.Text.Trim(); 
  			entity.CompactQty = SysConvert.ToDecimal(txtCompactQty.Text.Trim()); 
  			entity.Qty = SysConvert.ToDecimal(txtQty.Text.Trim());
            entity.ItemUnit = SysConvert.ToString(drpItemUnit.EditValue);
            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = txtMakeDate.DateTime.Date;
            }
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }

        /// <summary>
        /// 加载订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    SODtsLoad();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        //加载订单
        private void SODtsLoad()
        {
            //frmSODtsLoad frm = new frmSODtsLoad();
            //frm.LoadFormID = this.GetFormIDByClassName("frmSOPlanEdit");
            //frm.ShowDialog();
            //if (frm.HTLoadData.Count != 0)
            //{
            //    string listStr = ((string[])frm.HTLoadData[2])[0];

            //    //明细数据
            //    string sql = "SELECT SOID,DtsItemCode,VendorID,CompanyTypeID,SUM(Qty)Qty,ItemUnit FROM UV1_Sale_SODts WHERE 1=1 AND " + listStr + " Group by SOID,DtsItemCode,VendorID,CompanyTypeID,ItemUnit ";
            //    DataTable dt = SysUtils.Fill(sql);
            //    if (dt.Rows.Count != 0)
            //    {
            //        txtSO.Text = dt.Rows[0]["SOID"].ToString();
            //        drpItemCode.EditValue = dt.Rows[0]["DtsItemCode"].ToString();
            //        txtCompactQty.Text = dt.Rows[0]["Qty"].ToString();
            //        drpCompanyTypeID.EditValue = SysConvert.ToInt32(dt.Rows[0]["CompanyTypeID"].ToString());
            //        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"].ToString());
            //        drpItemUnit.EditValue = SysConvert.ToString(dt.Rows[0]["ItemUnit"].ToString());
            //    }

            //}

        }
        /// <summary>
        /// 生成单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    //txtCode.Text = rule.RGetFormNo((int)FormNoControlEnum.生产通知单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

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
                //base.btnPreview_Click(sender, e);
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
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.预览, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
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
                //base.btnPrint_Click(sender, e);

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
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.打印, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
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
                //base.btnDesign_Click(sender, e);
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
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.设计, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion

        private void drpItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string itemCode = SysConvert.ToString(drpItemCode.EditValue);

                SetStorgeQty(itemCode);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 设置一个库存
        /// </summary>
        private void SetStorgeQty(string p_ItemCode)
        {
            string sql = string.Empty;
            DataTable dt;
            decimal tqty = 0;
            string tstr = string.Empty;

            sql = "SELECT WHID,SectionID,Sum(FreeQty) SQty,ColorName,JarNum,ColorNum FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//查询色纱库存
            sql += " AND ISNULL(ISJK,0)=0";
            //sql += " AND WHTypeID=" + (int)WHType.色纱 + " AND ISNULL(ISJK,0)=0";
            sql += " GROUP BY WHID,SectionID,ColorNum,JarNum,ColorName ORDER BY SQty DESC";
            dt = SysUtils.Fill(sql);
            tqty = 0;
            tstr = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                tqty += SysConvert.ToDecimal(dr["SQty"]);
                tstr += Environment.NewLine + "库区：" + Common.GetWHNM(dr["WHID"].ToString()) + " " + dr["SectionID"].ToString() + " 颜色：" + dr["ColorName"].ToString() + " 色号：" + dr["ColorNum"].ToString() + "   缸号：" + dr["JarNum"].ToString() + "   数量：" + SysConvert.ToDecimal(dr["SQty"]) + "KG";
            }
            tstr = "库存合计:" + tqty.ToString() + "KG" + tstr;//明细：
            txtWHStorgeQty.Text = tstr;


            sql = "SELECT WHID,Sum(FreeQty) SQty,ColorName,JarNum,ColorNum FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//查询色纱库存
            sql += " AND ISNULL(ISJK,0)=1";
            //sql += " AND WHTypeID=" + (int)WHType.色纱 + " AND ISNULL(ISJK,0)=1";//寄库
            sql += " GROUP BY WHID,ColorNum,JarNum,ColorName ORDER BY SQty DESC";
            dt = SysUtils.Fill(sql);
            tqty = 0;
            tstr = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                tqty += SysConvert.ToDecimal(dr["SQty"]);
                tstr += Environment.NewLine + "仓库：" + "" + " 颜色：" + dr["ColorName"].ToString() + " 色号：" + dr["ColorNum"].ToString() + "   缸号：" + dr["JarNum"].ToString() + "   数量：" + SysConvert.ToDecimal(dr["SQty"]) + "KG";
            }
            tstr = "库存合计:" + tqty.ToString() + "KG" + tstr;//明细：
            txtWHJKStorgeQty.Text = tstr;
        }


     
    }
}