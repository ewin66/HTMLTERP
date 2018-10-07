using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmCapInvoiceAmount : frmAPBaseLoad
    {
        public frmCapInvoiceAmount()
        {
            InitializeComponent();
        }

        private string m_VendorID;
        public string VendorID
        {
            get
            {
                return m_VendorID;
            }
            set
            {
                m_VendorID = value;
            }
        }

        private string m_Makedates;
        public string Makedates
        {
            get
            {
                return m_Makedates;
            }
            set
            {
                m_Makedates = value;
            }
        }

        private string m_Makedatee;
        public string Makedatee
        {
            get
            {
                return m_Makedatee;
            }
            set
            {
                m_Makedatee = value;
            }
        }

        private decimal m_Totalamount;
        public decimal Totalamount
        {
            get
            {
                return m_Totalamount;
            }
            set
            {
                m_Totalamount = value;
            }
        }

        private int m_CapFlag;
        public int CapFlag
        {
            get
            {
                return m_CapFlag;
            }
            set
            {
                m_CapFlag = value;
            }
        }

        #region 自定义虚方法定义[需要修改]
       
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "SELECT KPName,MakeDate,ItemCode,GoodsCode,DInvoiceSinglePrice,SUM(DInvoiceQty) DInvoiceQty,SUM(DInvoiceAmount) DInvoiceAmount FROM UV1_Finance_InvoiceOperationDts WHERE SubmitFlag=1 ";
            sql += " AND KPType=" + (int)EnumKPType.正常开票;
            sql += " AND VendorID=" + SysString.ToDBString(m_VendorID);
            sql += " AND MakeDate BETWEEN " + SysString.ToDBString(m_Makedates) + " AND " + SysString.ToDBString(m_Makedatee);
            sql += " GROUP BY KPName,MakeDate,ItemCode,GoodsCode,DInvoiceSinglePrice";
            DataTable dt = SysUtils.Fill(sql);

            sql = "SELECT KPName,MakeDate,ItemCode,GoodsCode,SinglePrice,SUM(Qty) Qty,SUM(Amount) Amount from UV1_Finance_InvoiceYOperationDts WHERE SubmitFlag=1 ";
            sql += " AND KPType=" + (int)EnumKPType.预开票;
            sql += " AND VendorID=" + SysString.ToDBString(m_VendorID);
            sql += " AND MakeDate BETWEEN " + SysString.ToDBString(m_Makedates) + " AND " + SysString.ToDBString(m_Makedatee);
            sql += " GROUP BY KPName,MakeDate,ItemCode,GoodsCode,SinglePrice";
            DataTable dt2 = SysUtils.Fill(sql);

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["KPName"] = dt2.Rows[i]["KPName"];
                dr["MakeDate"] = dt2.Rows[i]["MakeDate"];
                dr["ItemCode"] = dt2.Rows[i]["ItemCode"];
                dr["GoodsCode"] = dt2.Rows[i]["GoodsCode"];
                dr["DInvoiceQty"] = dt2.Rows[i]["Qty"];
                dr["DInvoiceSinglePrice"] = dt2.Rows[i]["SinglePrice"];
                dr["DInvoiceAmount"] = dt2.Rows[i]["Amount"];
                dt.Rows.Add(dr);
            }

            sql = "SELECT ExDate,ExAmount FROM Finance_RecPay WHERE SubmitFlag=1 ";
            sql += " AND VendorID=" + SysString.ToDBString(m_VendorID);
            sql += " AND ExDate BETWEEN " + SysString.ToDBString(m_Makedates) + " AND " + SysString.ToDBString(m_Makedatee);
            DataTable dt3 = SysUtils.Fill(sql);
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                if (m_CapFlag == (int)EnumRecPayType.付款)
                {
                    dr["KPName"] = "付款";
                }
                else
                {
                    dr["KPName"] = "收款";
                }
                dr["MakeDate"] = dt3.Rows[i]["ExDate"];
                dr["DInvoiceAmount"] = 0 - SysConvert.ToDecimal(dt3.Rows[i]["ExAmount"]);
                dt.Rows.Add(dr);
            }

            sql = "SELECT * FROM Finance_BVendorAmount WHERE VendorID=" + SysString.ToDBString(m_VendorID);
            DataTable dt4 = SysUtils.Fill(sql);
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["KPName"] = "期初金额";
                dr["MakeDate"] = dt4.Rows[i]["UpdateDate"];
                dr["DInvoiceAmount"] = SysConvert.ToDecimal(dt4.Rows[i]["BAmount"]);
                dt.Rows.Add(dr);
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "MakeDate Asc";
            DataTable dto = dv.ToTable();
            if (dto.Rows.Count > 0)
            {
               
                DataRow drS = dto.NewRow();
                drS["KPName"] = "合计";
               
                drS["DInvoiceAmount"] = Totalamount;
                dto.Rows.Add(drS);
            }
            gridView1.GridControl.DataSource = dto;
            gridView1.GridControl.Show();

        }




        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_CapPlan";
            this.HTDataList = gridView1;
            btnQuery_Click(null, null);
           

        }

        #endregion

     
        
    }
}