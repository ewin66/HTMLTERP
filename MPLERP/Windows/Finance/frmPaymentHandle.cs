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
using DevComponents.DotNetBar;

namespace MLTERP
{
    public partial class frmPaymentHandle : frmAPBaseUIForm
    {
        public frmPaymentHandle()
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
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
           
            if (txtSaleOPName.Text.Trim() != string.Empty)
            {
                tempStr += " AND SaleOPName LIKE " + SysString.ToDBString("%" + txtSaleOPName.Text.Trim() + "%");
            }
            if (txtVendorAttn.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorAttn LIKE " + SysString.ToDBString("%" + txtVendorAttn.Text.Trim() + "%");
            }
            if (chkFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }

            //if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            //{
            //    tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            //}


            if (checkSef.Checked && !FParamConfig.LoginHTFlag)
            {
                tempStr += " AND MakeOPID=" + SysString.ToDBString(FParamConfig.LoginName);
            }
            tempStr += " ORDER BY FormNo Desc";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            PaymentHandleRule rule = new PaymentHandleRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            PaymentHandleRule rule = new PaymentHandleRule();
            PaymentHandle entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_PaymentHandle";
            this.HTDataList = gridView1;
            txtFormDateS.DateTime = DateTime.Now.AddDays(-30).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;
            this.ToolBarItemAdd(26, "btnLoad", "已阅", true, btnLoad_Click);
        }

        #endregion
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                this.ShowMessage("没有此权限，请联系管理员");
                return;
            }
            ButtonItem btn = (ButtonItem)sender;
            PaymentHandleRule rule = new PaymentHandleRule();
            PaymentHandle entity = new PaymentHandle();
            entity.ID = HTDataID;
            entity.SelectByID();
            if (btn.Text == "撤销已阅")
            {
                if (entity.ReadFlag == 0)
                {
                    this.ShowMessage("该单据还未阅，无需撤销");
                    return;
                }
                entity.ReadFlag = 0;
                rule.RUpdate(entity);
            }
            if (btn.Text == "已阅")
            {
                if (entity.ReadFlag == 1)
                {
                    this.ShowMessage("该单据已阅，无需再阅");
                    return;
                }
                entity.ReadFlag = 1;
                rule.RUpdate(entity);
            }
            btnQuery_Click(null, null);
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { entity.ID.ToString() });

        }
        public override void gridViewRowChanged1(object sender)
        {
            base.gridViewRowChanged1(sender);
            int ReadFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ReadFlag"));
            if (ReadFlag == 1)
            {
                this.ToolBarItemSet(-1, "btnLoad", "撤销已阅", true, 27);
            }
            else
            {
                this.ToolBarItemSet(-1, "btnLoad", "已阅", true, 26);
            }
        }
        public override void _HTDataDts_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //base._HTDataDts_RowCellStyle(sender, e);
            if (SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "ReadFlag")) == 1)
            {
                e.Appearance.BackColor = Color.Pink;
            }
        }
        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private PaymentHandle EntityGet()
        {
            PaymentHandle entity = new PaymentHandle();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}