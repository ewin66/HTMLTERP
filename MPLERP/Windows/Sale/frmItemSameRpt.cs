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
    public partial class frmItemSameRpt : frmAPBaseUIRpt
    {
        public frmItemSameRpt()
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
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                string sql="";
                if (txtSameType.Text.Trim() == "订单")
                {
                    sql = "EXEC USP1_VendorSameRpt " + SysString.ToDBString(drpVendorID.EditValue.ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }

                if (txtSameType.Text.Trim() == "借出")
                {
                    sql = "EXEC USP1_VendorSameRpt2 " + SysString.ToDBString(drpVendorID.EditValue.ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }

                if (txtSameType.Text.Trim() == "留样")
                {
                    sql = "EXEC USP1_VendorSameRpt3 " + SysString.ToDBString(drpVendorID.EditValue.ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }

                if (txtSameType.Text.Trim() == "调样")
                {
                    sql = "EXEC USP1_VendorSameRpt4 " + SysString.ToDBString(drpVendorID.EditValue.ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }

                if (txtSameType.Text.Trim() == "报价")
                {
                    sql = "EXEC USP1_VendorSameRpt5 " + SysString.ToDBString(drpVendorID.EditValue.ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }
                
                  
                
               

            }
        }

        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_DYGL";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);
        }

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
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private DYGL EntityGet()
        {
            DYGL entity = new DYGL();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "SamePre")
                {
                    if (SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "SameQty")) > 0)
                    {
                        e.Appearance.BackColor = Color.Plum;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
    }
}