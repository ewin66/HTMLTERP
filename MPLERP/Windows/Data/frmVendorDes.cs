using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmVendorDes : frmAPBaseUIForm
    {
        public frmVendorDes()
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
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID ="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核2))
            {
                tempStr += " AND VendorID IN(SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(FParamConfig.LoginID) + ")";
            }
            if (txtENBrand.Text.Trim() != "")
            {
                tempStr += " AND ENBrand LIKE "+SysString.ToDBString("%"+txtENBrand.Text.Trim()+"%");
            }

            if (txtCHBrand.Text.Trim() != "")
            {
                tempStr += " AND CHBrand LIKE "+SysString.ToDBString("%"+txtCHBrand.Text.Trim()+"%");
            }

            if (txtContact.Text.Trim() != "")
            {
                tempStr += " AND Contact LIKE "+SysString.ToDBString("%"+txtContact.Text.Trim()+"%");
            }

            if (chkCG.Checked)
            {
                tempStr += " AND MLCGDate BETWEEN "+SysString.ToDBString(txtMLCGDateS.DateTime)+" AND "+SysString.ToDBString(txtMLCGDateE.DateTime);
            }

            if (chkDH.Checked)
            {
                tempStr += " AND DHHDate BETWEEN "+SysString.ToDBString(txtDHDateS.DateTime)+" AND "+SysString.ToDBString(txtDHDateE.DateTime);
            }

            if (SysConvert.ToString(drpSaleOP.EditValue) != "")
            {
                tempStr += " AND SaleOPID="+SysString.ToDBString(drpSaleOP.EditValue.ToString());
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            VendorDesRule rule = new VendorDesRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            VendorDesRule rule = new VendorDesRule();
            VendorDes entity = EntityGet();
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
            this.HTDataTableName = "Data_VendorDes";
            this.HTDataList = gridView1;
            txtDHDateS.DateTime = DateTime.Now;
            txtDHDateE.DateTime = DateTime.Now;
            txtMLCGDateS.DateTime = DateTime.Now.Date;
            txtMLCGDateE.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpVendorID, new int[] {(int)EnumVendorType.客户},true);
            new VendorProc(drpVendorID);
            Common.BindOP(drpSaleOP, true);
            

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private VendorDes EntityGet()
        {
            VendorDes entity = new VendorDes();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVendorName_EditValueChanged(object sender, EventArgs e)
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