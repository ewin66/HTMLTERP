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
    public partial class frmVendorTrackRecord : frmAPBaseUISin
    {
        public frmVendorTrackRecord()
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

            if (chkFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }

            if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }

            if (!Common.CheckLookUpEditBlank(drpSaleOPID))
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
                //tempStr += " AND VendorID IN (SELECT VendorID FROM Data_Vendor WHERE InSaleOP="+SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue))+" )";
            }
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//销售订单业务员只查看自己的的订单
            {
                tempStr += " AND SaleOPID IN(" + WCommon.GetStructureMemberOPStr() + ")";
            }

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//销售订单业务员只查看自己的的订单
            {
                tempStr += " AND SaleOPID IN(" + WCommon.GetStructureMemberOPStr() + ")";
            }
            //if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核2))
            //{
            //    tempStr += " AND VendorID IN(SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID) + ")";
            //}
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            VendorTrackRecordRule rule = new VendorTrackRecordRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            VendorTrackRecordRule rule = new VendorTrackRecordRule();
            VendorTrackRecord entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Att_VendorTrackRecord";
            this.HTDataList = gridView1;

            this.HTQryContainer = groupControlQuery;


            txtFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;

            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//组织结构体系启用
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private VendorTrackRecord EntityGet()
        {
            VendorTrackRecord entity = new VendorTrackRecord();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}