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
    public partial class frmPackBoxKP : frmAPBaseUIForm
    {
        public frmPackBoxKP()
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
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
           
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }
            if (SysConvert.ToString(drpSaleOPName.EditValue) != "")
            {
                tempStr += " AND SaleOPID = " + SysString.ToDBString(SysConvert.ToString(drpSaleOPName.EditValue));
            }
            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
        
            }

            if(SysConvert.ToString(drpKPOPID.EditValue)!="")
            {
                tempStr+= " AND KPOPID="+SysString.ToDBString(drpKPOPID.EditValue.ToString());
            }

            if (txtBoxNo.Text.Trim() != "")
            {
                tempStr += " AND BoxNo LIKE "+SysString.ToDBString("%"+txtBoxNo.Text.Trim()+"%");
            }
            
            if(txtItemCode.Text.Trim()!="")
            {
                tempStr+=" AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if(txtColorName.Text.Trim()!="")
            {
                tempStr+=" AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            PackBoxKPRule rule = new PackBoxKPRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            PackBoxKPRule rule = new PackBoxKPRule();
            PackBoxKP entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_PackBoxKP";
            this.HTDataList = gridView1;
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindDOP(drpSaleOPName, true);
            Common.BindOP(drpKPOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private PackBoxKP EntityGet()
        {
            PackBoxKP entity = new PackBoxKP();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

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
    }
}