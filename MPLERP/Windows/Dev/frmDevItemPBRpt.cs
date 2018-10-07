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
    public partial class frmDevItemPBRpt : frmAPBaseUIRpt
    {
        public frmDevItemPBRpt()
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

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }

            if (txtItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");
            }

            if (txtItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtItemStd.Text.Trim() + "%");
            }

            if (txtPBItemModel.Text.Trim() != "")
            {
               tempStr += " AND( PBItemModel LIKE " + SysString.ToDBString("%" + txtPBItemModel.Text.Trim() + "%")
                    + " Or PBItemCode like " + SysString.ToDBString("%" + txtPBItemModel.Text.Trim() + "%")   +")";
            }

            tempStr += " ORDER BY ItemCode Desc,PBItemModel Desc";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>



        public override void BindGrid()
        {
            string sql = "select * from UV1_Data_PBItem  where 1=1 ";
             sql += HTDataConditionStr;
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }
        public override void IniData()
        {
            HTDataList = gridView1;
            btnQuery_Click(null, null);

        }

        #endregion

        private void txtPBItemModel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnQuery_Click(null, null);
                    
                }
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }

       







    }
}