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
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;
using DevComponents.DotNetBar;

namespace MLTERP
{
    public partial class frmWHfrmPayment : frmAPBaseTool
    {
        private string m_OrderFormNo = string.Empty;
        public string OrderFormNo
        {
            get
            {
                return m_OrderFormNo;
            }
            set
            {
                m_OrderFormNo = value;
            }
        }

        private string m_VendorID = string.Empty;
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

        private DataTable dtGrid;
        public frmWHfrmPayment()
        {
            InitializeComponent();
        }
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(4, ToolButtonName.btnSave.ToString(), "保存", false, btnSave_Click, eShortcut.F4);
            this.ToolBarLItemAdd(ToolButtonName.lblFormStatus.ToString(), Color.Red);
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string p_Message = string.Empty;
                if (!Check(out p_Message))
                {
                    this.ShowMessage(p_Message);
                    return;
                }
                PaymentHandleRule rule = new PaymentHandleRule();
                PaymentHandle[] Entity = EntityDtsGet();
                rule.RSave(m_OrderFormNo, Entity);
                this.ShowInfoMessage("保存成功");
                frmWHfrmPayment_Load(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void frmWHfrmPayment_Load(object sender, EventArgs e)
        {
            Common.BindCLS(drpType, "Finance_PaymentHandle", "Type", true);
            BindGrid();
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);
            ProcessGrid.SetGridEdit(gridView1, new[] { "FormNo" }, false);
            dtGrid = (DataTable)gridView1.GridControl.DataSource;
        }
        public void BindGrid()
        {
            PaymentHandleRule rule = new PaymentHandleRule();
            DataTable dt = rule.RShow(" AND OrderFormNo =" + SysString.ToDBString(m_OrderFormNo), ProcessGrid.GetQueryField(gridView1));
            Common.AddDtRow(dt, 20);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }
        public PaymentHandle[] EntityDtsGet()
        {
            int index = dtGrid.Select("ISNULL(Type,'')<>''").Length;
            if (index < 1)
            {
                this.ShowMessage("请先填写附加类型再保存");
            }
            PaymentHandle[] entitydts = new PaymentHandle[index];
            index = 0;
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                if (SysConvert.ToString((dtGrid.Rows[i]["Type"])) != "")
                {
                    entitydts[index] = new PaymentHandle();
                    if (SysConvert.ToInt32(dtGrid.Rows[i]["ID"]) != 0)
                    {
                        entitydts[index].ID = SysConvert.ToInt32(dtGrid.Rows[i]["ID"]);
                    }
                    entitydts[index].SelectByID();
                    entitydts[index].FormNo = SysConvert.ToString(dtGrid.Rows[i]["FormNo"]);
                    if (SysConvert.ToString(dtGrid.Rows[i]["FormDate"]) != "")
                    {
                        entitydts[index].FormDate = SysConvert.ToDateTime(dtGrid.Rows[i]["FormDate"]);
                    }
                    else
                    {
                        entitydts[index].FormDate = DateTime.Now;
                    }
                    entitydts[index].Amount = SysConvert.ToDecimal(dtGrid.Rows[i]["Amount"]);
                    entitydts[index].Currency = SysConvert.ToString(dtGrid.Rows[i]["Currency"]);
                    if (SysConvert.ToString(dtGrid.Rows[i]["MakeDate"]) != "")
                    {
                        entitydts[index].MakeDate = SysConvert.ToDateTime(dtGrid.Rows[i]["MakeDate"]);
                    }
                    else
                    {
                        entitydts[index].MakeDate = DateTime.Now;
                    }
                    if (SysConvert.ToString(dtGrid.Rows[i]["MakeOPID"]) != "")
                    {
                        entitydts[index].MakeOPID = SysConvert.ToString(dtGrid.Rows[i]["MakeOPID"]);
                    }
                    else
                    {
                        entitydts[index].MakeOPID = FParamConfig.LoginID;
                    }
                    entitydts[index].OrderFormNo = m_OrderFormNo;
                    entitydts[index].PayMethod = SysConvert.ToString(dtGrid.Rows[i]["PayMethod"]);
                    entitydts[index].Qty = SysConvert.ToDecimal(dtGrid.Rows[i]["Qty"]);
                    entitydts[index].Remark = SysConvert.ToString(dtGrid.Rows[i]["Remark"]);
                    if (SysConvert.ToString(dtGrid.Rows[i]["SaleOPID"]) != "")
                    {
                        entitydts[index].SaleOPID = SysConvert.ToString(dtGrid.Rows[i]["SaleOPID"]);
                    }
                    else
                    {
                        entitydts[index].SaleOPID = FParamConfig.LoginID;
                    }
                    if (SysConvert.ToString(dtGrid.Rows[i]["SubmitFlag"]) != "")
                    {
                        entitydts[index].SubmitFlag = SysConvert.ToInt32(dtGrid.Rows[i]["SubmitFlag"]);
                    }
                    else
                    {
                        entitydts[index].SubmitFlag = 1;
                    }
                    entitydts[index].Type = SysConvert.ToString(dtGrid.Rows[i]["Type"]);
                    entitydts[index].Unit = SysConvert.ToString(dtGrid.Rows[i]["Unit"]);
                    if (SysConvert.ToString(dtGrid.Rows[i]["VendorID"]) != "")
                    {
                        entitydts[index].VendorID = SysConvert.ToString(dtGrid.Rows[i]["VendorID"]);
                    }
                    else
                    {
                        entitydts[index].VendorID = m_VendorID;
                    }
                    index++;
                }
            }
            return entitydts;
        }
        private bool Check(out string p_Message)
        {
            bool chk = true;
            p_Message = string.Empty;
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                if (SysConvert.ToDecimal(dtGrid.Rows[i]["Amount"]) != 0)
                {
                    if (SysConvert.ToString(dtGrid.Rows[i]["Type"]) == "")
                    {
                        p_Message = "第" + i.ToString() + "行，未输入费用类型！";
                        chk = false;
                        return chk;
                    }
                }
            }
            int index = dtGrid.Select("ISNULL(Type,'')<>''").Length;
            if (index < 1)
            {
                p_Message = "没有输入任何数据，请先输入数据再保存！";
                chk = false;
                return chk;
            }
            return chk;
        }

    }
}
