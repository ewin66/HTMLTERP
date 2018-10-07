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
    public partial class frmShipment : frmAPBaseUIForm
    {
        public frmShipment()
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
            if (txtCode.Text.Trim() != "")
            {
                tempStr += " AND Code LIKE " + SysString.ToDBString("%" + txtCode.Text.Trim() + "%");
            }
            if (chkShipDate.Checked)
            {
                tempStr += " AND ShipDate BETWEEN " + SysString.ToDBString(txtQShipDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQShipDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (SysConvert.ToString(drpQSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(SysConvert.ToString(drpQSaleOPID.EditValue));
            }
            if (SysConvert.ToString(drpQShipTypeID.EditValue) != "")
            {
                tempStr += " AND ShipTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQShipTypeID.EditValue));
            }
            if (SysConvert.ToString(drpQCompanyTypeID.EditValue) != "")
            {
                tempStr += " AND CompanyTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQCompanyTypeID.EditValue));
            }

            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                tempStr += " AND VendorID in(Select VendorID FROM UV1_Data_VendorInSaleOP WHERE InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                tempStr += "  OR DtsInSaleOP=" + SysString.ToDBString(FParamConfig.LoginID) + ")";
            }
            if (txtQItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
         
            tempStr += " ORDER BY Code DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ShipmentRule rule = new ShipmentRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ShipmentRule rule = new ShipmentRule();
            Shipment entity = EntityGet();
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
            this.HTDataTableName = "Sale_Shipment";
            this.HTDataList = gridView1;


            txtQShipDateE.DateTime = DateTime.Now.Date;
            txtQShipDateS.DateTime = DateTime.Now.Date.AddDays(0 - ParamConfig.QueryDayNum);

            this.btnSubmitCancelVisible = false;
            this.btnSubmitVisible = false;
            this.btnUpdateVisible = false;
            this.btnDeleteVisible = false;

            Common.BindCompanyType(drpQCompanyTypeID, true);//绑定公司别
            Common.BindOPID(drpQSaleOPID, true);//业务员
            Common.BindSubType(drpQShipTypeID, 6, true);//绑定发货类型


            ///客户参照相关，只查看自己的客户
            string p_Conidion = string.Empty;
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                p_Conidion = " AND ( ";
                p_Conidion += " InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                p_Conidion += " OR ID in (Select MainID From Data_VendorInSaleOP where InSaleOP= " + SysString.ToDBString(FParamConfig.LoginID) + ")";
                p_Conidion += ")";

            }
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, p_Conidion, true);//客户
            new VendorProc(drpQVendorID, p_Conidion);



            txtCode_EditValueChanged(null,null);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Shipment EntityGet()
        {
            Shipment entity = new Shipment();
            entity.ID = HTDataID;      
            return entity;
        }
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_EditValueChanged(object sender, EventArgs e)
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

        private void txtQItemCode_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                txtQItemName.Text = "";
                txtQItemStd.Text = "";
                //txtQItemModel.Text = "";
                string sql = "SELECT ItemName,ItemStd,ItemAttnCode FROM Data_Item WHERE 1=1 AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text.Trim());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    txtQItemName.Text = dt.Rows[0]["ItemName"].ToString();
                    txtQItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
                    //txtQItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
                }
                txtCode_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }

      
    }
}