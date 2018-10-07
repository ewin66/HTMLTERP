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
    public partial class frmCheckOperation : frmAPBaseUIForm
    {
        public frmCheckOperation()
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
           
            if (ChkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            }

            //if (!Common.CheckLookUpEditBlank(drpQVendorID))
            //{
             //   tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            //}
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }

            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID ="+SysString.ToDBString(drpSaleOPID.EditValue.ToString());
            }
            tempStr += " AND DZTypeID="+SysString.ToDBString(FormListAID);
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            CheckOperationRule rule = new CheckOperationRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CheckOperationRule rule = new CheckOperationRule();
            CheckOperation entity = EntityGet();
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
            ProcessGrid.BindGridColumn(gridView1, this.FormID);
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);
            txtQMakeDateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQMakeDateE.DateTime = DateTime.Now;
            //Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
            this.HTDataTableName = "Finance_CheckOperation";
            this.HTDataList = gridView1;
            Common.BindOP(drpSaleOPID, true);
            BindVendor();
            //new VendorProc(drpQVendorID);

        }
        /// <summary>
        /// 绑定客户
        /// </summary>
        private void BindVendor()
        {
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            //Common.BindVendorByDZTypeID(drpQVendorID, this.FormListAID, true);
            //switch (FormListAID)
            //{
            //    case (int)EnumDZType.采购:
            //        Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
            //        lblVendor.Text = "供应商";
            //        break;
            //    case (int)EnumDZType.加工:
            //        Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
            //        lblVendor.Text = "加工厂";
            //        break;
            //    case (int)EnumDZType.销售:
            //        Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            //        lblVendor.Text = "客户";
            //        break;

            //}
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckOperation EntityGet()
        {
            CheckOperation entity = new CheckOperation();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        #region 快速查询
        private void txtMakeOPName_EditValueChanged(object sender, EventArgs e)
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

        private void drpQVendorID_EditValueChanged(object sender, EventArgs e)
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
    }
}