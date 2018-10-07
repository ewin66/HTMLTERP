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
    /// <summary>
    /// ϵͳ����¼���뵥��ϸ
    /// </summary>
    public partial class frmLoadPackNoInputCZ :BaseForm
    {
        public frmLoadPackNoInputCZ()
        {
            InitializeComponent();
        }

        #region ����

        /// <summary>
        /// �����־
        /// </summary>
        bool m_SaveFlag = false;
        /// <summary>
        /// �����־
        /// </summary>
        public bool SaveFlag
        {
            get
            {
                return m_SaveFlag;
            }
        }

        bool m_UpdateFlag = false;
        /// <summary>
        /// �޸ı�־
        /// </summary>
        public bool UpdateFlag
        {
            set
            {
                m_UpdateFlag = value;
            }
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
        #endregion
        #region �Զ��巽��

        private void BindGrid()
        {
            string sql = "Select * from WH_IOFormDtsInputPack where 1=1";
            sql += " AND DID=" + m_ID;
            DataTable dt = SysUtils.Fill(sql);

            Common.AddDtRow(dt, 150);

            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private IOFormDtsInputPack[] GetEntityDts()
        {
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {

                if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i,"Qty")) > 0)
                {
                    Num++;
                }
            }
            IOFormDtsInputPack[] entityDts = new IOFormDtsInputPack[Num];
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")) > 0)
                {
                    entityDts[index] = new IOFormDtsInputPack();
                    entityDts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entityDts[index].SelectByID();
                    entityDts[index].MainID = m_MainID;
                    entityDts[index].Seq = m_Seq;
                    entityDts[index].DID = m_ID;
                    //entityDts[index].SubSeq = SysConvert.ToInt32(ucFabInput1.UCDataSource.Rows[i]["SubSeq"]); ;
                    entityDts[index].SubSeq = i + 1;
                    entityDts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    index++;
                }
            }

            return entityDts;
        }
        #endregion



        #region �����¼�
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessGrid.BindGridColumn(gridView1, this.FormID);//����
                ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//������UI


                int ReportID=Common.BindReport(drpReport, this.FormID, false);
                txtQty.Focus();//�۽���������

                drpReport.EditValue = ReportID;
               

                BindGrid();

              
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

       
        #endregion


        #region ��ť�¼�
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnSave.Focus();
                if (m_PackType == (int)EnumPackType.�ֿⵥ��)
                {

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")) == 0 && SysConvert.ToDecimal(txtQty.Text.Trim())!=0)
                        {
                            decimal a = Math.Round(SysConvert.ToDecimal(txtQty.Text.Trim()),1, MidpointRounding.AwayFromZero);
                            gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(a));
                            break;
                        }
                    }


                    IOFormDtsInputPackRule rule = new IOFormDtsInputPackRule();
                    IOFormDtsInputPack[] entityDts = GetEntityDts();
                    rule.RSave(m_ID, m_MainID, m_Seq, entityDts, m_UpdateFlag);

                    m_SaveFlag = true;
                    
                }
                else
                {

                }
               // this.ShowInfoMessage("����ɹ���");
                btnSave.BackColor = Color.Green;
                this.txtQty.Text = "";
                this.txtQty.Focus();
                BindGrid();
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void btnPreReview_Click(object sender, EventArgs e)
        {
            try
            {

                //base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.Ԥ��);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {

                //base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.���);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrintAbount((int)ReportPrintType.��ӡ);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ��ӡ��������
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();

            int tempReportID = SysConvert.ToInt32(drpReport.EditValue);
            if (tempReportID == 1)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }


            int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
            if (ID == 0)
            {
                this.ShowMessage("��ѡ����Ҫ��ӡ�����ݣ�");
                return false;
            }

            string sql = "SELECT * FROM UV1_WH_IOFormDtsInputPack WHERE ID=" + SysString.ToDBString(ID);
            DataTable dt = SysUtils.Fill(sql);

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dt);
            return true;
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave_Click(null, null);
                    
                }
               

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void frmLoadPackNoCZ_Activated(object sender, EventArgs e)
        {
            txtQty.Focus();
        }

      




    }
}