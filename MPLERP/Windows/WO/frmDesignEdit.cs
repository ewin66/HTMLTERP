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
    public partial class frmDesignEdit : frmAPBaseUIFormEdit
    {
        public frmDesignEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
           

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
            DesignDtsRule rule = new DesignDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            DesignRule rule = new DesignRule();
            Design entity = EntityGet();
            DesignDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            DesignRule rule = new DesignRule();
            Design entity = EntityGet();
            DesignDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            Design entity = new Design();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.Code;

  			drpCompanyTypeID.EditValue = entity.CompanyTypeID; 
  			txtCode.Text = entity.Code.ToString(); 
  			drpItemCode.EditValue = entity.ItemCode; 
  			txtItemName.Text = entity.ItemName.ToString(); 
  			txtItemStd.Text = entity.ItemStd.ToString(); 
  			txtQty.Text = entity.Qty.ToString(); 
  			txtMakeOPID.Text =Common.GetOPName( entity.MakeOPID.ToString()); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtPlanCode.Text=entity.PlanCode;
            txtSOID.Text=entity.SOID;

            txtXinXian.Text = entity.XinXian;
            txtYaXian.Text = entity.YaXian;
            txtFuXian.Text = entity.FuXian;
            txtGYRemark.Text = entity.GYRemark;
            txtPJiaoZhong.Text = entity.PJiaoZhong.ToString();
            txtPJiaoChang.Text = entity.PJiaoChang.ToString();
            txtPRemark.Text = entity.PRemark;
            txtSJiaoChang.Text = entity.SJiaoChang.ToString ();
            txtSJiaoZhong.Text = entity.SJiaoZhong.ToString();
            txtSRemark.Text = entity.SRemark;

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
            DesignRule rule = new DesignRule();
            Design entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { txtCode,txtMakeDate,txtMakeOPID}, false);
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);
            txtMakeDate.DateTime = DateTime.Now.Date;
          
            txtQty.Text = Common.TrimZero(txtQty.Text);
            txtSJiaoChang.Text = Common.TrimZero(txtSJiaoChang.Text);
            txtSJiaoZhong.Text = Common.TrimZero(txtSJiaoZhong.Text);
            txtPJiaoChang.Text = Common.TrimZero(txtPJiaoChang.Text);
            txtPJiaoZhong.Text = Common.TrimZero(txtPJiaoZhong.Text);

            drpCompanyTypeID.EditValue = 1;

            txtCode_DoubleClick(null,null);

        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_Design";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ItemCode" };//数据明细校验必须录入字段
            Common.BindCompanyType(drpCompanyTypeID, true);//绑定公司别

            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[3] { "ItemCode", "ItemName", "ItemStd" }, drpDtsItemCode, txtDtsItemName, new int[] { (int)EnumItemType.面料 }, "", "ItemModel", true, true);
            new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, new int[] { (int)EnumItemType.面料 }, true, true);
            this.ToolBarItemAdd(28, "btnLoad", "加载", false, btnCheckLoad_Click);
            frmDesignEdit frm = new frmDesignEdit();
            SetTabIndex(0,groupControlMainten);
         
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Design EntityGet()
        {
            Design entity = new Design();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue); 
  			entity.Code = txtCode.Text.Trim(); 
  			entity.ItemCode =SysConvert.ToString(drpItemCode.EditValue); 
  			entity.ItemName = txtItemName.Text.Trim(); 
  			entity.ItemStd = txtItemStd.Text.Trim(); 
  			entity.Qty = SysConvert.ToDecimal(txtQty.Text.Trim());
            entity.MakeOPID = FParamConfig.LoginID;
            entity.ItemModel = txtItemModel.Text.Trim();
            entity.SOID = txtSOID.Text.Trim();
            entity.PlanCode = txtPlanCode.Text.Trim();
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.Remark = txtRemark.Text.Trim();

            entity.XinXian = txtXinXian.Text.Trim();
            entity.YaXian = txtYaXian.Text.Trim();
            entity.FuXian = txtFuXian.Text.Trim();
            entity.GYRemark = txtGYRemark.Text.Trim();
            entity.PJiaoChang = SysConvert.ToDecimal(txtPJiaoChang.Text.Trim());
            entity.PJiaoZhong = SysConvert.ToDecimal(txtPJiaoZhong.Text.Trim());
            entity.PRemark = txtPRemark.Text.Trim();
            entity.SJiaoChang = SysConvert.ToDecimal(txtSJiaoChang.Text.Trim());
            entity.SJiaoZhong = SysConvert.ToDecimal(txtSJiaoZhong.Text.Trim());
            entity.SRemark = txtSRemark.Text.Trim();
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private DesignDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            DesignDts[] entitydts = new DesignDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new DesignDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();
                    
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].proportion = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "proportion")); 
  			 		entitydts[index].SH = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SH")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion
        /// <summary>
        ///生成生产工艺单号
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
                    //txtCode.Text = rule.RGetFormNo((int)FormNoControlEnum.生产工艺单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

     
        #region 其它事件
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
            frmSOPlanLoad frm = new frmSOPlanLoad();
        
            frm.ShowDialog();
            if (frm.HTLoadData.Count != 0)
            {
                string listStr = ((string[])frm.HTLoadData[0])[0];

                //明细数据
                string sql = "SELECT * FROM UV1_WO_SOPlan WHERE 1=1 AND ID IN (" + listStr+")";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        txtSOID.Text = dt.Rows[i]["SO"].ToString();
                        txtPlanCode.Text = dt.Rows[i]["Code"].ToString();
                        txtQty.Text = dt.Rows[i]["Qty"].ToString();
                        drpItemCode.EditValue = dt.Rows[i]["ItemCode"].ToString();
                        drpCompanyTypeID.EditValue = SysConvert.ToInt32(dt.Rows[i]["CompanyTypeID"].ToString());
                    }
                }

            }

        }

        /// <summary>
        /// 合计比例是否超过100%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtproportion_Leave(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    decimal BL = 0.00m;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (SysConvert.ToString(SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "proportion"))) != "")
                        {
                            BL += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "proportion"));
                        }
                    }
                    if (BL > 100.00m)
                    {
                        this.ShowMessage("比例合计已超过100%，请检查！");
                        return;
                    }
                }

            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 根据损耗计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSH_Leave(object sender, EventArgs e)
        {
            try
            {
                BaseFocusLabel.Focus();
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    decimal sh = 0.00m;
                    decimal total = 0.00m;
                    decimal qty = 0.00m;
                    decimal bl = 0.00m;
                    sh = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SH"));
                    bl = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "proportion"));
                    total = SysConvert.ToDecimal(txtQty.Text.Trim());
                    qty = total * bl * 0.01m * (1 + sh * 0.01m);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", qty);

                }
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
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
                //FastReport.ReportRun(tempReportID, (int)ReportPrintType.设计, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion



    }
}