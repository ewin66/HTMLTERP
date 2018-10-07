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
using DevExpress.XtraGrid.Views.Base;



namespace MLTERP
{
    public partial class frmLoadMLYL : BaseForm
    {
        public frmLoadMLYL()
        {
            InitializeComponent();
        }

        private string m_Code;
        public string Code
        {
            get
            {
                return m_Code;
            }
            set
            {
                m_Code = value;
            }
        }

        private string m_Name;
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        /// <summary>
        /// ¥∞ÃÂº”‘ÿ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                m_Code = "";
                m_Name = "";
                BindGrid();

            }
            catch (Exception E)
            {
               
            }
        }

        private void BindGrid()
        {
            string sql = "SELECT * FROM Data_MLYL WHERE UseableFlag=1 ";
            if (txtName.Text.Trim() != "")
            {
                sql += " AND Name LIKE " + SysString.ToDBString("%" + txtName.Text.Trim() + "%");
            }
            gridView1.GridControl.DataSource = SysUtils.Fill(sql);
            gridView1.GridControl.Show();
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception E)
            {
                
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
               
                string Code = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Code"));
                string Name = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name"));
                m_Code = Code;
                m_Name = Name;
                this.Close();

            }
            catch (Exception E)
            {

            }
        }

        


    }

}