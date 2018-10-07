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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmFLBuyForm : frmAPBaseUIForm
    {
        public frmFLBuyForm()
        {
            InitializeComponent();
        }


        int saveNoLoadCheckDayNum = 0;//未加载比对天数，防止随着时间的推移系统变慢

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtOrderDateS.DateTime) + " AND " + SysString.ToDBString(txtOrderDateE.DateTime);
            }

            if (chkReqDate.Checked)
            {
                tempStr += " AND ReqDate BETWEEN " + SysString.ToDBString(txtReqDateS.DateTime) + " AND " + SysString.ToDBString(txtReqDateE.DateTime);
            }

            if (txtVendorID.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorAttn LIKE " + SysString.ToDBString("%" + txtVendorID.Text.Trim() + "%");
            }


            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }

            if (txtMWeightS.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWeight>" + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }

            if (txtMWeightE.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWeight<" + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }

            if (txtMWidth.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWidth=" + SysString.ToDBString(txtMWidth.Text.Trim());
            }

            if (txtItemName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");
            }

            if (txtVColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND VColorNum LIKE " + SysString.ToDBString("%" + txtVColorNum.Text.Trim() + "%");
            }

            if (txtVColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND VColorName LIKE " + SysString.ToDBString("%" + txtVColorName.Text.Trim() + "%");
            }

            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE "+SysString.ToDBString("%"+txtItemModel.Text.Trim()+"%");
            }

            if (chkSubmitFlag.Checked)
            {
                tempStr += " AND SubmitFlag=1";
            }

            if(txtDtsSO.Text.Trim()!=string.Empty)
            {
                tempStr += " AND DtsSO LIKE " + SysString.ToDBString("%"+txtDtsSO.Text.Trim()+"%"); ;
            }
            tempStr += " AND MLType="+SysString.ToDBString(this.FormListAID);
            //tempStr += " Order by FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ItemBuyFormRule rule = new ItemBuyFormRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("FormStatusName", "'' FormStatusName"));

            ItemBuyStatusProc.ProcColorStatusName(dt);
            ProcDataSourceQty(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();

            string sql = "SELECT distinct ID  FROM UV1_Buy_ItemBuyFormDts WHERE 1=1";
            sql += HTDataConditionStr;
            dt = SysUtils.Fill(sql);
            lbCount.Text = "采购单数：" + dt.Rows.Count.ToString();
          
        }

       
        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ItemBuyFormRule rule = new ItemBuyFormRule();
            ItemBuyForm entity = EntityGet();
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
            this.HTDataTableName = "Buy_ItemBuyForm";
            this.HTDataList = gridView1;
            this.HTQryContainer = groupControlQuery;
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            txtReqDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtReqDateE.DateTime = DateTime.Now.Date;
         
            if (ItemBuyStatusProc.ColorIniFlag)
            {
                ucStatusBarStand1.UCDataSource = ItemBuyStatusProc.ColorStatusDt;
                ucStatusBarStand1.UCAct();
            }
            Common.BindVendor(drpVendorID, new int[] {(int)EnumVendorType.供应商 }, true);
            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
            this.ToolBarItemAdd(32, "btnUpdateOrderStatus", "修改合同状态", true, UpdateOrderStatusToolStripMenuItem_Click, eShortcut.F9);
        }

        /// <summary>
        ///通用 重新设置实体1，如果不要使用，则重写，一般不要修改
        /// </summary>
        public override void gridViewRowChanged1(object sender)
        {
            base.gridViewRowChanged1(sender);

            ucOrderInfo1.OrderTypeID = 2;
            ucOrderInfo1.OrderNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormNo"));
            ucOrderInfo1.IniData();
        }

        /// <summary>
        /// 修改合同状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateOrderStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限3))
                {
                    this.ShowMessage("没有此权限，请联系管理员");
                    return;
                }
                frmUpdateBuyFormStatus frm = new frmUpdateBuyFormStatus();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(580, 280);
                frm.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frm.OrderStatusName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormStatusName"));
                frm.ShowDialog();
                btnQuery_Click(null, null);
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { frm.ID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemBuyForm EntityGet()
        {
            ItemBuyForm entity = new ItemBuyForm();
            entity.ID = HTDataID;      
            return entity;
        }

        /// <summary>
        /// 处理数据源欠数
        /// </summary>
        /// <param name="dt"></param>
        void ProcDataSourceQty(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["RemainQty"] = SysConvert.ToDecimal(dr["Qty"]) - SysConvert.ToDecimal(dr["TotalRecQty"]);
                if(SysConvert.ToDecimal(dr["Qty"]) !=0)
                {
                    dr["RemainRate"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dr["RemainQty"]) / SysConvert.ToDecimal(dr["Qty"]), 3);
                }
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
                    e.Appearance.BackColor = ItemBuyStatusProc.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "FormStatusName")));
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