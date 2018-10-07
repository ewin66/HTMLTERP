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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmSaleOrderProgress : frmAPBaseUIRpt
    {
        public frmSaleOrderProgress()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if(chkOrderDate.Checked)
            {
                tempStr+=" AND OrderDate BETWEEN "+SysString.ToDBString(txtOrderDateS.DateTime)+" AND "+SysString.ToDBString(txtOrderDateE.DateTime);
            }

            if(chkReqDate.Checked)
            {
                tempStr+=" AND ReqDate BETWEEN "+SysString.ToDBString(txtReqDateS.DateTime)+" AND "+SysString.ToDBString(txtReqDateE.DateTime);
            }

            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }

            if(txtVendorID.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VendorAttn LIKE "+SysString.ToDBString("%"+txtVendorID.Text.Trim()+"%");
            }
            
            if(txtCustomerCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND CustomerCode LIKE "+SysString.ToDBString("%"+txtCustomerCode.Text.Trim()+"%");
            }

            if(SysConvert.ToString(drpOrderTypeID.EditValue)!=string.Empty)
            {
                tempStr+=" AND OrderTypeID="+SysString.ToDBString(SysConvert.ToInt32(drpOrderTypeID.EditValue));
            }

            if(SysConvert.ToString(drpOrderLevelID.EditValue)!=string.Empty)
            {
                tempStr+=" AND OrderLevelID="+SysString.ToDBString(SysConvert.ToInt32(drpOrderLevelID.EditValue));
            }

            if(txtItemCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if(txtGoodsCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if(txtColorNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if(txtColorName.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            if(txtMWeightS.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND MWeight>"+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }

            if(txtMWeightE.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND MWeight<"+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }

            if(txtMWidth.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND MWidth="+SysString.ToDBString(txtMWidth.Text.Trim());
            }

            if(txtItemName.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ItemName LIKE "+SysString.ToDBString("%"+txtItemName.Text.Trim()+"%");
            }

            if(txtVColorNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VColorNum LIKE "+SysString.ToDBString("%"+txtVColorNum.Text.Trim()+"%");
            }

            if(txtVColorName.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VColorName LIKE "+SysString.ToDBString("%"+txtVColorName.Text.Trim()+"%");
            }

            if(chkSubmitFlag.Checked)
            {
                tempStr+=" AND SubmitFlag=1";
            }
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核2))
            {
                tempStr += " AND VendorID IN(SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID) + ")";
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            SaleOrderRule rule = new SaleOrderRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("FormStatusName", "'' FormStatusName"));
            SaleOrderStatusProc.ProcColorStatusName(dt);
            ProcDataSourceQty(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();

            string sql = "SELECT distinct ID  FROM UV1_Sale_SaleOrderDts WHERE 1=1";
            sql += HTDataConditionStr;
            dt = SysUtils.Fill(sql);
            lbCount.Text = "销售合同数："+dt.Rows.Count.ToString();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            SaleOrderRule rule = new SaleOrderRule();
            SaleOrder entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SaleOrder";
            this.HTDataList = gridView1;
            Common.BindOrderType(drpOrderTypeID, true);
            Common.BindOrderLevel(drpOrderLevelID,true);
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            txtReqDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtReqDateE.DateTime = DateTime.Now.Date;
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            if (SaleOrderStepProc.ColorIniFlag)
            {
                ucStatusBarStand1.UCDataSource = SaleOrderStepProc.ColorStatusDt;
                ucStatusBarStand1.UCAct();
            }

            if (SaleOrderStatusProc.ColorIniFlag)
            {
                ucStatusBarStand2.UCDataSource = SaleOrderStatusProc.ColorStatusDt;
                ucStatusBarStand2.UCAct();
            }
            btnQuery_Click(null, null);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 处理数据源欠数
        /// </summary>
        /// <param name="dt"></param>
        void ProcDataSourceQty(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["RemainQty"] = SysConvert.ToDecimal(dr["Qty"]) - SysConvert.ToDecimal(dr["TotalRecQty"]);
                if (SysConvert.ToDecimal(dr["Qty"]) != 0)
                {
                    dr["RemainRate"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dr["RemainQty"]) / SysConvert.ToDecimal(dr["Qty"]), 3);
                }
            }
        }


        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SaleOrder EntityGet()
        {
            SaleOrder entity = new SaleOrder();
            entity.ID = HTDataID;      
            return entity;
        }


        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region 其它事件
       




        /// <summary>
        /// 颜色变化 方法重载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void _HTDataDts_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                base._HTDataDts_RowCellStyle(sender, e);
                if (e.Column.FieldName == "FormStatusName")
                {
                    e.Appearance.BackColor = SaleOrderStatusProc.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "FormStatusName")));
                }
                if (e.Column.FieldName == "OrderStepName")
                {
                    e.Appearance.BackColor = SaleOrderStepProc.GetGridRowBackColor(SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "OrderStepID")));
                }
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "CancelFlag")) == 1)
                {
                    e.Appearance.BackColor = Color.DarkGray;
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