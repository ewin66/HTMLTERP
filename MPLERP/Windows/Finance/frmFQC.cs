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
    public partial class frmFQC : frmAPBaseUIForm
    {
        public frmFQC()
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
            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += "  AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            tempStr += " AND RecPayTypeID=" + this.FormListAID;
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            FQCRule rule = new FQCRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FQCRule rule = new FQCRule();
            FQC entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_FQC";
            this.HTDataList = gridView1;
            if (this.FormListAID == (int)EnumRecPayType.收款)
            {
                Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            }
            else
            {
                Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.检测机构, (int)EnumVendorType.快递公司, (int)EnumVendorType.物流公司, (int)EnumVendorType.供应商 }, true);
            }
            new VendorProc(drpVendorID);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FQC EntityGet()
        {
            FQC entity = new FQC();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

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
    }
}