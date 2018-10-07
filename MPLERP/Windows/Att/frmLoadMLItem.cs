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
    public partial class frmLoadMLItem : BaseForm
    {
        public frmLoadMLItem()
        {
            InitializeComponent();
        }

        private DataTable m_dt;
        public DataTable dt
        {
            get
            {
                return m_dt;
            }
            set
            {
                m_dt = value;
            }
        }

        private int m_ID;
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

     
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                m_ID = 0;
                BindGrid();

            }
            catch (Exception E)
            {
               
            }
        }

        private void BindGrid()
        {
          
            gridView1.GridControl.DataSource =m_dt;
            gridView1.GridControl.Show();
        }

       
        /// <summary>
        /// 转入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                if (ID != 0)
                {
                    m_ID = ID;
                    btnClose_Click(null, null);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
            
        }

      

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        


    }

}