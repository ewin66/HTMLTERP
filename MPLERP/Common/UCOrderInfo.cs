using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;

namespace MLTERP
{
    /*订单或采购单相关信息
     */
    public partial class UCOrderInfo : UserControl
    {
        public UCOrderInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 1/2:订单/采购单
        /// </summary>
        public int OrderTypeID = 1;//

        /// <summary>
        /// 合同号
        /// </summary>
        public string OrderNo = string.Empty;

        /// <summary>
        /// 数据初始化
        /// </summary>
        public void IniData()
        {
            try
            {
                lblError.Visible = false;
               

                string sql = string.Empty;
                if (OrderTypeID == 1)//订单
                {
                    sql = "exec USP1_GetSaleOrderRelInfo " + SysString.ToDBString(OrderNo);

                }
                else//采购单
                {
                    sql = "exec USP1_GetBuyOrderRelInfo " + SysString.ToDBString(OrderNo);
                }
                DataTable dt = SysUtils.Fill(sql);
                gridView1.GridControl.DataSource = dt;
                gridView1.GridControl.Show();

                if (OrderNo != string.Empty)
                {
                    gridControlDetail.Visible = true;
                }
                else
                {
                    gridControlDetail.Visible = false;
                    lblError.Text = "无单号";
                    lblError.Visible = true;
                }
            }
            catch (Exception E)
            {
                lblError.Text = "数据处理异常";
                lblError.Visible = true;
                gridControlDetail.Visible = false;
                SysFile.WriteFrameworkLog(E.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "ContexDesc")).Contains("."))
            {
                e.Appearance.BackColor = Color.LightBlue;
            }
        }


    }
}
