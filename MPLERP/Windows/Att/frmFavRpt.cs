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
    public partial class frmFavRpt : frmAPBaseUIRpt
    {
        public frmFavRpt()
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
            if (txtGBCode.Text.Trim() != "")
            {
                tempStr += " AND GBCode LIKE "+SysString.ToDBString("%"+txtGBCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtVendorID.Text.Trim() != "")
            {
                tempStr += " AND CM LIKE "+SysString.ToDBString("%"+txtVendorID.Text.Trim()+"%");
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if(txtColorName.Text.Trim()!="")
            {
                tempStr+=" AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            tempStr += " AND SaleOPID="+SysString.ToDBString(FParamConfig.LoginID);
            tempStr += " AND ISNULL(CancelFlag,0)=0 ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "SELECT * FROM UV1_Sale_FavItemGB WHERE 1=1";
            sql += HTDataConditionStr;
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_LYGL";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID,new int[]{(int)EnumVendorType.客户},true);
            new VendorProc(drpVendorID);
            btnQuery_Click(null, null);
           

        }

      

        #endregion


        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGBCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch(Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToGBDetail_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                string sql = "UPDATE Sale_FavItemGB SET CancelFlag=1 WHERE ID="+SysString.ToDBString(ID);
                SysUtils.ExecuteNonQuery(sql);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

      

       
       
        

    }
}