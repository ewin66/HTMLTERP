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
    public partial class frmVendorCompact : frmAPBaseUIForm
    {
        public frmVendorCompact()
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
            if (txtQSOID.Text.Trim() != "")
            {
                tempStr += " AND SOID LIKE " + SysString.ToDBString("%" + txtQSOID.Text.Trim() + "%");
            }
            if(txtQCompactNo.Text.Trim()!="")
            {
                tempStr += " AND CompactNo LIKE " + SysString.ToDBString("%" + txtQCompactNo.Text.Trim() + "%");
            }
            if(SysConvert.ToString(drpQCompanyTypeID.EditValue)!="")
            {
                tempStr += " AND CompanyTypeID =" + SysString.ToDBString(SysConvert.ToString(drpQCompanyTypeID.EditValue));
            }
            if(SysConvert.ToString(drpQVendorID.EditValue)!="")
            {
                tempStr += " AND VendorID ="+SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (chkWriteDate.Checked)
            {
                tempStr += " AND WriteDate BETWEEN " + SysString.ToDBString(txtQWriteDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQWriteDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }


            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                tempStr += " AND VendorID in(Select VendorID FROM UV1_Data_VendorInSaleOP WHERE InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                tempStr += "  OR DtsInSaleOP=" + SysString.ToDBString(FParamConfig.LoginID) + ")";
            }
            tempStr += " ORDER BY WriteDate DESC";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            VendorCompactRule rule = new VendorCompactRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            VendorCompactRule rule = new VendorCompactRule();
            VendorCompact entity = EntityGet();
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
            this.HTDataTableName = "Sale_VendorCompact";
            this.HTDataList = gridView1;

            txtQWriteDateE.DateTime = DateTime.Now.Date;
            txtQWriteDateS.DateTime = DateTime.Now.Date.AddDays(0 - ParamConfig.QueryDayNum);

            this.btnSubmitCancelVisible = false;
            this.btnSubmitVisible = false;
            this.btnUpdateVisible = false;
            this.btnDeleteVisible = false;
            Common.BindCompanyType(drpQCompanyTypeID, true);//绑定公司别
        
            ///客户参照相关，只查看自己的客户
            string p_Conidion = string.Empty;
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
            {
                //p_Conidion = " AND InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                p_Conidion = " AND ( ";
                p_Conidion += " InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID);
                p_Conidion += " OR ID in (Select MainID From Data_VendorInSaleOP where InSaleOP= " + SysString.ToDBString(FParamConfig.LoginID) + ")";
                p_Conidion += ")";

            }
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, p_Conidion, true);//客户
            new VendorProc(drpQVendorID, p_Conidion);

            txtQCompactNo_EditValueChanged(null,null);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private VendorCompact EntityGet()
        {
            VendorCompact entity = new VendorCompact();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void txtQCompactNo_EditValueChanged(object sender, EventArgs e)
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
    }
}