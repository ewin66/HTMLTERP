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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmPLEdit :BaseForm
    {
        public frmPLEdit()
        {
            InitializeComponent();
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

        private int m_PieceQty;
        public int PieceQty
        {
            get
            {
                return m_PieceQty;
            }
            set
            {
                m_PieceQty = value;
            }
        }

     


        
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {

               
               
 
            }
            catch (Exception E)
            {
               
            }

        }

     

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                if (SysConvert.ToDecimal(txtQty.Text.Trim()) <= 0)
                {
                    this.ShowMessage("清输入数量");
                    return;
                }

                if (SysConvert.ToInt32(txtPieceQty.Text.Trim()) <= 0)
                {
                    this.ShowMessage("清输入匹数");
                    return;
                }

                m_PieceQty = SysConvert.ToInt32(txtPieceQty.Text.Trim());
                m_Qty = SysConvert.ToInt32(txtQty.Text.Trim());
                this.Close();



            }
            catch (Exception E)
            {

            }
        }








    }
}