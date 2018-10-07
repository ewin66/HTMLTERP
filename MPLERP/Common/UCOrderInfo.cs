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
    /*������ɹ��������Ϣ
     */
    public partial class UCOrderInfo : UserControl
    {
        public UCOrderInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 1/2:����/�ɹ���
        /// </summary>
        public int OrderTypeID = 1;//

        /// <summary>
        /// ��ͬ��
        /// </summary>
        public string OrderNo = string.Empty;

        /// <summary>
        /// ���ݳ�ʼ��
        /// </summary>
        public void IniData()
        {
            try
            {
                lblError.Visible = false;
               

                string sql = string.Empty;
                if (OrderTypeID == 1)//����
                {
                    sql = "exec USP1_GetSaleOrderRelInfo " + SysString.ToDBString(OrderNo);

                }
                else//�ɹ���
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
                    lblError.Text = "�޵���";
                    lblError.Visible = true;
                }
            }
            catch (Exception E)
            {
                lblError.Text = "���ݴ����쳣";
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
