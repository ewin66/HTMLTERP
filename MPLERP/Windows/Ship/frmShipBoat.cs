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
    public partial class frmShipBoat : frmAPBaseUIForm
    {
        public frmShipBoat()
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
            if (!Common.CheckLookUpEditBlank(drpQCompanyTypeID))
            {
                tempStr += " AND CompanyTypeID = " + SysString.ToDBString(drpQCompanyTypeID.EditValue.ToString());
            }
            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(drpQVendorID.EditValue.ToString());
            }
            if (txtQIvoiceNo.Text.Trim() != "")
            {
                tempStr += " AND IvoiceNo LIKE " + SysString.ToDBString("%" + txtQIvoiceNo.Text.Trim() + "%");
            }
            if (txtQLCNo.Text.Trim() != "")
            {
                tempStr += " AND LCNo LIKE " + SysString.ToDBString("%" + txtQLCNo.Text.Trim() + "%");
            }
            if (txtQModel.Text.Trim() != "")
            {
                tempStr += " AND Model LIKE " + SysString.ToDBString("%" + txtQModel.Text.Trim() + "%");
            }
            if (txtQSaleNo.Text.Trim() != "")
            {
                tempStr += " AND SaleNo LIKE " + SysString.ToDBString("%" + txtQSaleNo.Text.Trim() + "%");
            }
            if (chkShipDate.Checked) 
            {
                tempStr += " AND ShipDate BETWEEN " + SysString.ToDBString(txtQShipDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQShipDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            tempStr += " AND FormListAID=" + SysString.ToDBString(this.FormListAID);
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ShipBoatRule rule = new ShipBoatRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ShipBoatRule rule = new ShipBoatRule();
            ShipBoat entity = EntityGet();
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
            this.HTDataTableName = "Ship_ShipBoat";
            this.HTDataList = gridView1;

            txtQShipDateS.DateTime = DateTime.Now.AddDays(0 - ParamConfig.QueryDayNum);
            txtQShipDateE.DateTime = DateTime.Now.Date;

            Common.BindCompanyType(drpQCompanyTypeID, true);
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpQVendorID);

        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ShipBoat EntityGet()
        {
            ShipBoat entity = new ShipBoat();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}