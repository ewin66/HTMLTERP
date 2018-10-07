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
    public partial class frmInvoiceOperation : frmAPBaseUIForm
    {
        public frmInvoiceOperation()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim()!= "")//查询d
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (ChkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != string.Empty)
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString()) ;
            }
            if (!Common.CheckLookUpEditBlank(drpKPType))
            {
                tempStr +=" AND KPType="+SysString.ToDBString(SysConvert.ToInt32(drpKPType.EditValue));
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }
            tempStr += " AND DZTypeID="+SysString.ToDBString(FormListAID);
            //tempStr += " AND KPType="+SysString.ToDBString((int)EnumKPType.正常开票);
            //tempStr += " ORDER BY FormNo DESC";

            HTDataConditionStr = tempStr;

        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            DataTable dt = rule.RShow(HTDataConditionStr + " AND KPType=" + SysString.ToDBString((int)EnumKPType.正常开票) + " ORDER BY ID,Seq", ProcessGrid.GetQueryField(gridView1).Replace("NoHXAmount", "0.00 NoHXAmount"));
            string sql = "SELECT * FROM UV1_Finance_InvoiceYOperationDts WHERE 1=1";
            sql += HTDataConditionStr + " AND KPType=" + SysString.ToDBString((int)EnumKPType.预开票);
            sql += " ORDER BY ID,Seq";
            DataTable Ydt=SysUtils.Fill(sql);
            for (int i = 0; i < Ydt.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = SysConvert.ToInt32(Ydt.Rows[i]["ID"]);
                dr["Seq"] = SysConvert.ToInt32(Ydt.Rows[i]["Seq"]);
                dr["SubmitFlag"] = SysConvert.ToInt32(Ydt.Rows[i]["SubmitFlag"]);
                dr["MakeOPID"] = SysConvert.ToString(Ydt.Rows[i]["MakeOPID"]);

                dr["MakeOPID"] = SysConvert.ToString(Ydt.Rows[i]["MakeOPID"]);
                dr["FormNo"] = SysConvert.ToString(Ydt.Rows[i]["FormNo"]);
                dr["KPName"] = SysConvert.ToString(Ydt.Rows[i]["KPName"]);
                dr["VendorName"] = SysConvert.ToString(Ydt.Rows[i]["VendorAttn"]);
                dr["VendorID"] = SysConvert.ToString(Ydt.Rows[i]["VendorID"]);
                dr["InvoiceNO"] = SysConvert.ToString(Ydt.Rows[i]["InvoiceNO"]);
                dr["ItemCode"] = SysConvert.ToString(Ydt.Rows[i]["ItemCode"]);
                dr["GoodsCode"] = SysConvert.ToString(Ydt.Rows[i]["GoodsCode"]);
                dr["ColorNum"] = SysConvert.ToString(Ydt.Rows[i]["ColorNum"]);
                dr["ColorName"] = SysConvert.ToString(Ydt.Rows[i]["ColorName"]);
                dr["DInvoiceQty"] = SysConvert.ToDecimal(Ydt.Rows[i]["Qty"]);
                dr["DInvoiceSinglePrice"] = SysConvert.ToDecimal(Ydt.Rows[i]["SinglePrice"]);
                dr["DInvoiceAmount"] = SysConvert.ToDecimal(Ydt.Rows[i]["Amount"]);
                dr["DInvoiceTaxAmount"] = SysConvert.ToDecimal(Ydt.Rows[i]["DInvoiceTaxAmount"]);
                dr["TotalAmount"] = SysConvert.ToDecimal(Ydt.Rows[i]["TotalAmount"]);
                dr["PayAmount"] = SysConvert.ToDecimal(Ydt.Rows[i]["PayAmount"]);
                dt.Rows.Add(dr);
            }
            foreach (DataRow dr in dt.Rows)
            {
                dr["NoHXAmount"] = SysConvert.ToDecimal(dr["TotalAmount"]) - SysConvert.ToDecimal(dr["PayAmount"]);
                if (SysConvert.ToInt32(dr["Seq"]) > 1)
                {
                    dr["NoHXAmount"] = DBNull.Value;
                    dr["TotalAmount"] = DBNull.Value;
                    dr["PayAmount"] = DBNull.Value;
                }
            }
            DataView dv = dt.DefaultView;
            dv.Sort = "FormNo DESC";
            DataTable dto = dv.ToTable();
            gridView1.GridControl.DataSource = dto;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            InvoiceOperation entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_InvoiceOperation";
            this.HTDataList = gridView1;

            txtQMakeDateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindOP(drpSaleOPID, true);
            Common.BindKPType(drpKPType, true);

            //Common.BindVendorByDZTypeID(drpQVendorID, this.FormListAID, true);
            //new VendorProc(drpQVendorID);
            DevMethod.BindVendorByDZTypeID(drpQVendorID, this.FormListAID, true);//2015.4.8 CX UPDATE
        }


        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private InvoiceOperation EntityGet()
        {
            InvoiceOperation entity = new InvoiceOperation();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
        #region 快速查询
        private void txtMakeOPName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                int Seq = SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle,"Seq"));
                if (Seq == 1)
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        
    }
}