using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmLoadPack :BaseForm
    {
        public frmLoadPack()
        {
            InitializeComponent();
        }

        private string m_PackStr;
        public string PackStr
        {
            get
            {
                return m_PackStr;
            }
            set
            {
                m_PackStr = value;
            }
        }

        private string m_YPackStr;
        public string YPackStr
        {
            get
            {
                return m_YPackStr;
            }
            set
            {
                m_YPackStr = value;
            }
        }

        private decimal m_Qty;
        public decimal Qty
        {
            get
            {
                return m_Qty;
            }
            set
            {
                m_Qty = value;
            }
        }

        private int m_Num;
        public int Num
        {
            get
            {
                return m_Num;
            }
            set
            {
                m_Num = value;
            }
        }

        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Qty", typeof(decimal));
                dt.Columns.Add("Seq", typeof(int));
                for (int i = 0; i < 150; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Qty"] = DBNull.Value;
                    dr["Seq"] =i+1;
                    dt.Rows.Add(dr);
                }
                gridView1.GridControl.DataSource = dt;
                gridView1.GridControl.Show();
                decimal Qty = 0;
                if (m_YPackStr != "")
                {
                    string[] str=m_YPackStr.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        gridView1.SetRowCellValue(i, "Qty", str[i].ToString());
                        Qty += SysConvert.ToDecimal(str[i].ToString());
                    }
                    lbCount.Text = Qty.ToString();
                }
                
             
            }
            catch (Exception E)
            {
               
            }

        }

       

        private void txtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal Qty = 0;
                m_PackStr = "";
                m_Qty = 0;
                m_Num = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")) != 0)
                    {
                        Qty += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                        if (m_PackStr != "")
                        {
                            m_PackStr += ",";
                        }
                        string[] QtyStr = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")).ToString().Split('.');
                        if (QtyStr.Length == 1)
                        {
                            m_PackStr += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")).ToString("f1");
                        }
                        else
                        {
                            m_PackStr += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")).ToString();
                        }
                        m_Num++;
                    }
                }
                lbCount.Text = Qty.ToString();
                m_Qty = Qty;
            }
            catch (Exception E)
            {
                
            }
        }

       

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    
                    //txtQty_Leave(null, null);
                    //this.Close();
                    //模拟点击向下箭头
                    this.BaseFocusLabel.Focus();
                    SendKeys.Send("{DOWN}");
                }
            }
            catch (Exception E)
            {

            }
        }

        private void frmLoadPack_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                
                txtQty_Leave(null, null);
            }
            catch (Exception E)
            {

            }
        }

       
    }
}