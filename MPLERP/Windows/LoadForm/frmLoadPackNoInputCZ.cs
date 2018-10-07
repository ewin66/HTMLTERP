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
    /// 系统出库录入码单明细
    /// </summary>
    public partial class frmLoadPackNoInputCZ :BaseForm
    {
        public frmLoadPackNoInputCZ()
        {
            InitializeComponent();
        }

        #region 属性

        /// <summary>
        /// 保存标志
        /// </summary>
        bool m_SaveFlag = false;
        /// <summary>
        /// 保存标志
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
        /// 修改标志
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
        #region 自定义方法

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
        /// 获得实体
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



        #region 窗体事件
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列
                ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//设置列UI


                int ReportID=Common.BindReport(drpReport, this.FormID, false);
                txtQty.Focus();//聚焦称重数据

                drpReport.EditValue = ReportID;
               

                BindGrid();

              
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

       
        #endregion


        #region 按钮事件
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnSave.Focus();
                if (m_PackType == (int)EnumPackType.仓库单据)
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
               // this.ShowInfoMessage("保存成功！");
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
                btnPrintAbount((int)ReportPrintType.预览);
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
                btnPrintAbount((int)ReportPrintType.设计);
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
                btnPrintAbount((int)ReportPrintType.打印);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 打印共用条码
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();

            int tempReportID = SysConvert.ToInt32(drpReport.EditValue);
            if (tempReportID == 1)
            {
                this.ShowMessage("请选择报表模板");
                return false;
            }


            int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
            if (ID == 0)
            {
                this.ShowMessage("请选择需要打印的数据！");
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