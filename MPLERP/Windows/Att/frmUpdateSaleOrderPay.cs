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
    public partial class frmUpdateSaleOrderPay : BaseForm
    {
        public frmUpdateSaleOrderPay()
        {
            InitializeComponent();
        }

        private string m_FormNo;
        public string FormNo
        {
            get
            {
                return m_FormNo;
            }
            set
            {
                m_FormNo = value;
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

        private decimal m_Amount;
        public decimal Amount
        {
            get
            {
                return m_Amount;
            }
            set
            {
                m_Amount = value;
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
                Common.BindPayStepType(drpPayStepType, true);
                lbShow.Text = "合同号："+m_FormNo;
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void BindGrid()
        {
           
            string sql = "SELECT * FROM Sale_SaleOrderCapDts WHERE MainID=" + SysString.ToDBString(m_ID);
            DataTable dt = SysUtils.Fill(sql);
            int count = dt.Rows.Count;
            for (int i = 0; i < 5 - count; i++)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
          
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkCorrectDts())
                {
                    return;
                }
                SaleOrderCapDtsRule rule = new SaleOrderCapDtsRule();
                SaleOrderCapDts[] entityDts = GetEntityDts();
                rule.RAdd(m_ID,entityDts);
                this.ShowInfoMessage("保存成功");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private bool checkCorrectDts()
        {
            decimal PayPer = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "PayStepTypeID")) != string.Empty)
                {
                   
                    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "PayPer")) == string.Empty)
                    {
                        this.ShowMessage("请输入价格比例");
                        return false;
                    }
                    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "PayLimitDate")) == string.Empty)
                    {
                        this.ShowMessage("请输入限定日期");
                        return false;
                    }
                    PayPer += SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "PayPer"));
                }
            }
            if(PayPer!=1)
            {
                  this.ShowMessage("价格比例之和不为1，请检查");
                  return false;
            }
            return true;
        }

        private SaleOrderCapDts[] GetEntityDts()
        {
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "PayStepTypeID")) != string.Empty)
                {
                    Num++;
                }
            }
            SaleOrderCapDts[] entityDts = new SaleOrderCapDts[Num];
            Num = 0;
            for (int j = 0; j < gridView1.RowCount; j++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(j, "PayStepTypeID")) != string.Empty)
                {
                    entityDts[Num] = new SaleOrderCapDts();
                    entityDts[Num].CapName = SysConvert.ToString(gridView1.GetRowCellValue(j, "CapName"));
                    entityDts[Num].PayStepTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(j, "PayStepTypeID"));
                    entityDts[Num].PayPer = SysConvert.ToDecimal(gridView1.GetRowCellValue(j, "PayPer"));
                    entityDts[Num].PayLimitDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(j, "PayLimitDate"));
                    entityDts[Num].PayAmount = entityDts[Num].PayPer * m_Amount;
                    entityDts[Num].Remark = SysConvert.ToString(gridView1.GetRowCellValue(j, "Remark"));
                    Num++;
                }
            }
            return entityDts;

        }











    }

}