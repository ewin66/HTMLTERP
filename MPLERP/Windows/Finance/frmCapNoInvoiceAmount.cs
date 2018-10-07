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
    public partial class frmCapNoInvoiceAmount : frmAPBaseLoad
    {
        public frmCapNoInvoiceAmount()
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

        #region �Զ����鷽������[��Ҫ�޸�]
       
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {



            string sql = "SELECT '����' KPName,* FROM UV1_WH_IOFormDts WHERE 1=1";
            sql += " AND SubmitFlag=1";
            sql += " AND SubType IN(SELECT ID FROM Enum_FormList WHERE DZFlag=" + (int)EnumDZFlag.������ + ")";
            sql += " AND VendorID=" + SysString.ToDBString(m_VendorID);
            sql += " AND FormDate BETWEEN " + SysString.ToDBString(m_Makedates) + " AND " + SysString.ToDBString(m_Makedatee);
            sql += " AND DtsID NOT IN(SELECT ISNULL(DLOADDtsID,0) FROM UV1_Finance_InvoiceOperationDts WHERE SubmitFlag=1)";
            DataTable dt3 = SysUtils.Fill(sql);
            foreach (DataRow dr in dt3.Rows)
            {
                dr["Qty"] = SysConvert.ToDecimal(dr["Qty"]) + SysConvert.ToDecimal(dr["YQQty"]);
                dr["Amount"] = SysConvert.ToDecimal(dr["Qty"]) * SysConvert.ToDecimal(dr["SinglePrice"]);
            }



            sql = "SELECT * FROM UV1_WH_IOFormDts WHERE 1=1";
            sql += " AND SubmitFlag=1";
            sql += " AND SubType IN(SELECT ID FROM Enum_FormList WHERE DZFlag=" + (int)EnumDZFlag.���ʸ� + ")";
            sql += " AND VendorID=" + SysString.ToDBString(m_VendorID);
            sql += " AND FormDate BETWEEN " + SysString.ToDBString(m_Makedates) + " AND " + SysString.ToDBString(m_Makedatee);
            sql += " AND DtsID NOT IN(SELECT ISNULL(DLOADDtsID,0) FROM UV1_Finance_InvoiceOperationDts WHERE SubmitFlag=1)";
            DataTable dt4 = SysUtils.Fill(sql);
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                DataRow dr = dt3.NewRow();
                dr["KPName"] = "�����˻�";
                dr["FormDate"] = dt4.Rows[i]["FormDate"];
                dr["ItemCode"] = dt4.Rows[i]["ItemCode"];
                dr["SinglePrice"] = dt4.Rows[i]["SinglePrice"];
                dr["GoodsCode"] = dt4.Rows[i]["GoodsCode"];
                dr["Qty"] = 0 - SysConvert.ToDecimal(dt4.Rows[i]["Qty"]) - SysConvert.ToDecimal(dt4.Rows[i]["YQQty"]);
                dr["Amount"] = SysConvert.ToDecimal(dr["Qty"])*SysConvert.ToDecimal(dr["SinglePrice"]);
                dt3.Rows.Add(dr);
            }

            sql = "SELECT KPName,MakeDate,ItemCode,GoodsCode,Qty,Amount,SinglePrice from UV1_Finance_InvoiceYOperationDts WHERE SubmitFlag=1 ";
            sql += " AND KPType=" + (int)EnumKPType.Ԥ��Ʊ;
            sql += " AND VendorID=" + SysString.ToDBString(m_VendorID);
            sql += " AND MakeDate BETWEEN " + SysString.ToDBString(m_Makedates) + " AND " + SysString.ToDBString(m_Makedatee);
            sql += " AND DtsID NOT IN (SELECT ISNULL(DLOADID,0) FROM UV2_Finance_InvoiceOperationDts WHERE DLOADNO='Ԥ��Ʊ')";
            DataTable dt5 = SysUtils.Fill(sql);
            for (int j = 0; j < dt5.Rows.Count; j++)
            {
                DataRow dr = dt3.NewRow();
                dr["KPName"] = "Ԥ��Ʊ";
                dr["FormDate"] = dt5.Rows[j]["MakeDate"];
                dr["ItemCode"] = dt5.Rows[j]["ItemCode"];
                dr["GoodsCode"] = dt5.Rows[j]["GoodsCode"];
                dr["SinglePrice"] = dt5.Rows[j]["SinglePrice"];
                dr["Qty"] = 0 - SysConvert.ToDecimal(dt5.Rows[j]["Qty"]);
                dr["Amount"] = 0 - SysConvert.ToDecimal(dt5.Rows[j]["Amount"]);
                dt3.Rows.Add(dr);
            }


            DataView dv = dt3.DefaultView;
            dv.Sort = "FormDate Asc";
            DataTable dto = dv.ToTable();
            gridView1.GridControl.DataSource = dto;
            gridView1.GridControl.Show();

        }




        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
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