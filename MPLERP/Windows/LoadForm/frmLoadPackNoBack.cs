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
    public partial class frmLoadPackNoBack :BaseForm
    {
        public frmLoadPackNoBack()
        {
            InitializeComponent();
        }

        private int m_PackType;
        public int PackType
        {
            get
            {
                return m_PackType;
            }
            set
            {
                m_PackType = value;
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

        private int m_MainID;
        public int MainID
        {
            get
            {
                return m_MainID;
            }
            set
            {
                m_MainID = value;
            }
        }

        private int m_Seq;
        public int Seq
        {
            get
            {
                return m_Seq;
            }
            set
            {
                m_Seq = value;
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


        
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {

                string sql = "EXEC USP1_WH_PackBox "+m_ID;
                DataTable dt = SysUtils.Fill(sql);
                SetGrid(dt);
                if (dt.Rows.Count == 0)
                {
                    Common.AddDtRow(dt, 15);
                }
                gridView1.GridControl.DataSource = dt;
                gridView1.GridControl.Show();
                lbCount.Text = Qty.ToString();
               
 
            }
            catch (Exception E)
            {
               
            }

        }

        private void SetGrid(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if(SysConvert.ToDecimal(dr["Qty1"])==0)
                {
                    dr["Qty1"]=DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty2"]) == 0)
                {
                    dr["Qty2"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty3"]) == 0)
                {
                    dr["Qty3"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty4"]) == 0)
                {
                    dr["Qty4"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty5"]) == 0)
                {
                    dr["Qty5"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty6"]) == 0)
                {
                    dr["Qty6"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty7"]) == 0)
                {
                    dr["Qty7"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty8"]) == 0)
                {
                    dr["Qty8"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty9"]) == 0)
                {
                    dr["Qty9"] = DBNull.Value;
                }
                if (SysConvert.ToDecimal(dr["Qty10"]) == 0)
                {
                    dr["Qty10"] = DBNull.Value;
                }
            }
        }

       

        private void txtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal Qtyt = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty1")) > 0)
                    {
                        Qtyt += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty1")) + SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty2"))
                        + SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty3")) + SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty4"))
                        + SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty5")) + SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty6"))
                        + SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty7")) + SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty8"))
                        + SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty9")) + SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty10"));

                    }
                }

                lbCount.Text = Qtyt.ToString();
            }
            catch (Exception E)
            {
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)gridView1.GridControl.DataSource;
                Common.AddDtRow(dt,dt.Rows.Count+1);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_PackType == (int)EnumPackType.仓库单据)
                {
                    IOFormDtsPackRule rule = new IOFormDtsPackRule();
                    IOFormDtsPack[] entityDts = GetEntityDts();
                    //rule.RAdd(m_ID, m_MainID, m_Seq, entityDts);
                }
                else
                {

                }
                this.ShowConfirmMessage("保存成功！");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private IOFormDtsPack[] GetEntityDts()
        {
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"+j.ToString())) > 0)
                    {
                        Num++;
                    }
                }
            }
            IOFormDtsPack[] entityDts=new IOFormDtsPack[Num];
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty" + j.ToString())) > 0)
                    {
                        entityDts[index] = new IOFormDtsPack();
                        entityDts[index].MainID = m_MainID;
                        entityDts[index].Seq = m_Seq;
                        entityDts[index].DID = m_ID;
                        entityDts[index].SubSeq = index + 1; ;
                        entityDts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty" + j.ToString()));
                        index++;
                    }
                }
            }

            return entityDts;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = Color.Silver;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnPL_Click(object sender, EventArgs e)
        {
            try
            {
                frmPLEdit frm = new frmPLEdit();
                frm.ShowDialog();
                if (frm.PieceQty > 0)
                {
                    decimal PQty = frm.Qty / (decimal)frm.PieceQty;
                    int Row=0;
                    int Row2 = 0;
                    if (frm.PieceQty <= 10)
                    {
                        Row = 1;
                    }
                    else
                    {
                        if (frm.PieceQty % 10 == 0)
                        {
                            Row = (frm.PieceQty / 10) ;
                        }
                        else
                        {
                            Row = (frm.PieceQty / 10) + 1;
                        }
                    }
                    if (Row > 15)
                    {

                        Common.AddDtRow((DataTable)gridView1.GridControl.DataSource, Row);
                    }

                    Row2 = (frm.PieceQty % 10);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (i < Row - 1)
                        {
                            gridView1.SetRowCellValue(i, "Qty1", PQty);
                            gridView1.SetRowCellValue(i, "Qty2", PQty);
                            gridView1.SetRowCellValue(i, "Qty3", PQty);
                            gridView1.SetRowCellValue(i, "Qty4", PQty);
                            gridView1.SetRowCellValue(i, "Qty5", PQty);
                            gridView1.SetRowCellValue(i, "Qty6", PQty);
                            gridView1.SetRowCellValue(i, "Qty7", PQty);
                            gridView1.SetRowCellValue(i, "Qty8", PQty);
                            gridView1.SetRowCellValue(i, "Qty9", PQty);
                            gridView1.SetRowCellValue(i, "Qty10", PQty);
                        }
                        else if (i == Row - 1)
                        {
                            for (int j = 1; j < 10; j++)
                            {
                                if (j <= Row2)
                                {
                                    gridView1.SetRowCellValue(i, "Qty" + j.ToString(), PQty);
                                }
                            }
                        }
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