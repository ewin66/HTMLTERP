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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Grid;

namespace MLTERP
{
    /// <summary>
    /// ���۶���(����)
    /// </summary>
    public partial class frmDomesticSaleOrder : frmAPBaseUIForm
    {
        public frmDomesticSaleOrder()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (txtVendorAttn.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorAttn LIKE " + SysString.ToDBString("%" + txtVendorAttn.Text.Trim() + "%");
            }
            if (txtSaleOPName.Text.Trim() != string.Empty)
            {
                tempStr += " AND SaleOPName LIKE " + SysString.ToDBString("%" + txtSaleOPName.Text.Trim() + "%");
            }
            if (chkOrderDate.Checked)
            {
                tempStr += " AND OrderDate BETWEEN " + SysString.ToDBString(txtOrderDateS.DateTime) + " AND " + SysString.ToDBString(txtOrderDateE.DateTime);
            }
            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }
            if (txtCustomerCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND CustomerCode LIKE " + SysString.ToDBString("%" + txtCustomerCode.Text.Trim() + "%");
            }
            if (chkSelf.Checked)//ֻ�鿴�Լ�����
            {
                tempStr += " and MakeOPID = " + SysString.ToDBString(FParamConfig.LoginID);
            }

            //tempStr += " AND ISNULL(FAID,0)=0";
            tempStr += " AND ISNULL(FAID,0) = " + this.FormListAID; //0 ���۶���   1 ��������
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            SaleOrderRule rule = new SaleOrderRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("FormStatusName", "'' FormStatusName").Replace("FaHuoStatusName", "'' FaHuoStatusName").Replace("NoFaPieceQty", "(ISNULL(PieceQty,0) - ISNULL(TotalRecPieceQty,0))  NoFaPieceQty").Replace("NoFaWeight", "(ISNULL(Weight,0) - ISNULL(TotalRecWeight,0))  NoFaWeight").Replace("NoFaQty", "(ISNULL(Qty,0)-ISNULL(TotalRecQty,0))  NoFaQty").Replace("NoFaYard", "(ISNULL(Yard,0)-ISNULL(TotalRecYard,0))  NoFaYard"));
            //ProFaHuoStatusName(dt);
            //SaleOrderStatusProc.ProcColorStatusName(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();

            //string sql = "SELECT COUNT( ID)  FROM UV1_Sale_SaleOrderDts WHERE 1=1";
            //sql += HTDataConditionStr + " GROUP BY ID";
            //DataTable dtSO = SysUtils.Fill(sql);
            //if (dtSO.Rows.Count > 0)
            //{
            //    lbCount.Text = "���ۺ�ͬ����" + dtSO.Rows[0][0].ToString();
            //}
            //else
            //{
            //    lbCount.Text = "���ۺ�ͬ����0";
            //}

            //if (ProductParamSet.GetIntValueByID(5418) == (int)YesOrNo.Yes)//���»�ǩ��־
            //{
            //    sql = "UPDATE Sale_SaleOrder SET HQFlag=1 WHERE FormNo IN (SELECT  ISNULL(FileProt2,'') FROM Data_WinListAttachFile WHERE FileProt1=" + SysString.ToDBString(this.Text) + ")";
            //    SysUtils.ExecuteNonQuery(sql);
            //}

        }
        /// <summary>
        /// ������״̬
        /// </summary>
        /// <param name="p_dt"></param>
        //void ProFaHuoStatusName(DataTable p_dt)
        //{
        //    if (p_dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in p_dt.Rows)
        //        {
        //            string sql = "SELECT SUM(Qty) Qty,SUM(TotalRecQty) TotalRecQty FROM Sale_SaleOrderDts WHERE MainID = " + SysString.ToDBString(dr["ID"].ToString());
        //            DataTable dt = SysUtils.Fill(sql);
        //            if (dt.Rows.Count > 0)
        //            {
        //                decimal qty = SysConvert.ToDecimal(dt.Rows[0]["Qty"]) - SysConvert.ToDecimal(dt.Rows[0]["TotalRecQty"]);
        //                if (qty > 0 && qty != SysConvert.ToDecimal(dt.Rows[0]["Qty"]))
        //                {
        //                    dr["FaHuoStatusName"] = "���ַ���";
        //                }
        //                if (qty == SysConvert.ToDecimal(dt.Rows[0]["Qty"]))
        //                {
        //                    dr["FaHuoStatusName"] = "δ����";
        //                }
        //                if (qty < 0)
        //                {
        //                    dr["FaHuoStatusName"] = "��������";
        //                }
        //                if (qty == 0)
        //                {
        //                    dr["FaHuoStatusName"] = "ȫ������";
        //                }
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            SaleOrderRule rule = new SaleOrderRule();
            SaleOrder entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ö�λ���ݼ�״̬
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        public override void IniFormLoadBehind()
        {
            base.IniFormLoadBehind();
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "HKFlag", "BGJFlag" }, true);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SaleOrder";
            this.HTDataList = gridView1;
            //this.HTDataDtsAttach = new GridView[] { gridView4 };
            this.HTQryContainer = groupControlQuery;
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-2).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-2).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            //this.ToolBarItemAdd(32, "btnUpdateOrderStep", "�޸ĺ�ͬվ��", true, UpdateOrderStepToolStripMenuItem_Click, eShortcut.None);
            this.ToolBarItemAdd(32, "btnUpdateOrderStatus", "�޸ĺ�ͬ״̬", true, UpdateOrderStatusToolStripMenuItem_Click, eShortcut.None);
            //  this.ToolBarItemAdd(32, "btnCancelOrder", "����", true, btnCancelOrder_Click, eShortcut.None);
            //   this.ToolBarItemAdd(32, "btnCancelCancelOrder_Click", "ȡ������", true, btnCancelCancelOrder_Click, eShortcut.None);

            if (ProductParamSet.GetIntValueByID(5417) == (int)YesOrNo.Yes)//��֯�ṹ��ϵ����
            {
                chkOrderDate.Checked = false;
            }
            if (SaleOrderStepProc.ColorIniFlag)
            {
                ucStatusBarStand1.UCDataSource = SaleOrderStepProc.ColorStatusDt;
                ucStatusBarStand1.UCAct();
            }
            if (SaleOrderStatusProc.ColorIniFlag)
            {
                ucStatusBarStand2.UCDataSource = SaleOrderStatusProc.ColorStatusDt;
                ucStatusBarStand2.UCAct();
            }
        }

        ///// <summary>
        /////ͨ�� ��������ʵ��1�������Ҫʹ�ã�����д��һ�㲻Ҫ�޸�
        ///// </summary>
        //public override void gridViewRowChanged1(object sender)
        //{
        //    base.gridViewRowChanged1(sender);
        //    GridView view = sender as GridView;
        //    int ID = SysConvert.ToInt32(view.GetFocusedRowCellValue("ID"));
        //    SaleOrderDtsRule rule = new SaleOrderDtsRule();
        //    DataTable dt = rule.RShow(" AND MainID = " + ID, ProcessGrid.GetQueryField(gridView4).Replace("NoFaPieceQty", "(ISNULL(PieceQty,0) - ISNULL(TotalRecPieceQty,0))  NoFaPieceQty").Replace("NoFaWeight", "(ISNULL(Weight,0) - ISNULL(TotalRecWeight,0))  NoFaWeight").Replace("NoFaQty", "(ISNULL(Qty,0)-ISNULL(TotalRecQty,0))  NoFaQty"));
        //    gridView4.GridControl.DataSource = dt;
        //    gridView4.GridControl.Show();

        //}

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ��������ԴǷ��
        /// </summary>
        /// <param name="dt"></param>
        void ProcDataSourceQty(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["RemainQty"] = SysConvert.ToDecimal(dr["Qty"]) - SysConvert.ToDecimal(dr["TotalRecQty"]);
                if (SysConvert.ToDecimal(dr["Qty"]) != 0)
                {
                    dr["RemainRate"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dr["RemainQty"]) / SysConvert.ToDecimal(dr["Qty"]), 3);
                }

                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6426)))//������ѯ�鿴ʵ�ʳ�����
                {
                    dr["ReceiveAmount"] = GetReceiveAmount(SysConvert.ToInt32(dr["DtsID"]));
                }
            }
        }

        private decimal GetReceiveAmount(int p_ID)
        {
            decimal Amount = 0;
            string sql = "SELECT SUM(Amount) FROM UV1_WH_IOFormDts WHERE LoadDtsID=" + SysString.ToDBString(p_ID);
            sql += " AND SubType IN (1201,181) AND SubmitFlag>0";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                Amount = SysConvert.ToDecimal(dt.Rows[0][0]);
            }
            return Amount;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SaleOrder EntityGet()
        {
            SaleOrder entity = new SaleOrder();
            entity.ID = HTDataID;
            return entity;
        }



        #endregion


        #region �����¼�
        /// <summary>
        /// ��ɫ�仯 ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void _HTDataDts_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                base._HTDataDts_RowCellStyle(sender, e);
                if (e.Column.FieldName == "FormStatusName")
                {
                    e.Appearance.BackColor = SaleOrderStatusProc.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "FormStatusName")));
                }
                if (e.Column.FieldName == "OrderStepName")
                {
                    e.Appearance.BackColor = SaleOrderStepProc.GetGridRowBackColor(SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "OrderStepID")));
                }
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "CancelFlag")) == 1)
                {
                    e.Appearance.BackColor = Color.DarkGray;
                }

                if (e.Column.FieldName == "ReceiveAmount")
                {
                    e.Appearance.BackColor = Color.BurlyWood;
                }
                if (e.Column.FieldName == "BGJFlag")
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "BGJString")) == "����Ҫ" || SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "BGJString")) == "")
                    {
                        e.Appearance.BackColor = Color.Pink;
                    }
                }
                if (e.Column.FieldName == "HKFlag")
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "HKString")) == "����Ҫ" || SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "HKString")) == "")
                    {
                        e.Appearance.BackColor = Color.Pink;
                    }
                }
                if (e.Column.FieldName == "NoFaQty" || e.Column.FieldName == "NoFaPieceQty" || e.Column.FieldName == "NoFaWeight")
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// �޸ĺ�ͬվ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateOrderStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��2))
                {
                    this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                    return;
                }
                frmUpdateOrderStep frm = new frmUpdateOrderStep();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(580, 280);
                frm.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frm.OrderStepID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderStepID"));
                frm.ShowDialog();
                btnQuery_Click(null, null);
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { frm.ID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �޸ĺ�ͬ״̬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateOrderStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��3))
                {
                    this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                    return;
                }
                frmUpdateOrderStatus frm = new frmUpdateOrderStatus();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(580, 280);
                frm.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                frm.OrderStatusName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "StatusName"));
                frm.ShowDialog();
                btnQuery_Click(null, null);
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { frm.ID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��3))
                {
                    this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                    return;
                }
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CancelFlag")) == 1)
                {
                    this.ShowMessage("�˶����ѳ�����");
                    return;
                }
                frmCancelOrder frm = new frmCancelOrder();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(580, 280);
                frm.OrdeFormNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormNo"));
                frm.ShowDialog();
                btnQuery_Click(null, null);
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "FormNo" }, new string[1] { frm.OrdeFormNo.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��3))
                {
                    this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                    return;
                }
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CancelFlag")) == 0)
                {
                    this.ShowMessage("�˶���δ����������ȡ����");
                    return;
                }
                string FormNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormNo"));
                string sql = "UPDATE Sale_SaleOrder SET CancelFlag =0";
                sql += ",CancelReason =''";
                sql += " WHERE FormNo=" + SysString.ToDBString(FormNo);
                SysUtils.ExecuteNonQuery(sql);
                btnQuery_Click(null, null);
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "FormNo" }, new string[1] { FormNo });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// �鿴��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSOProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string fno = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormNo"));
                if (fno != string.Empty)
                {
                    frmLoadSOProcess frm = new frmLoadSOProcess();
                    frm.FormNo = fno;
                    frm.FormDataID = HTDataID;
                    frm.ShowDialog();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        #endregion

        private void txtFormNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnQuery_Click(null, null);
                }
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "HKFlag")
            {
                int RowHandle = e.RowHandle;
                if (SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "HKString")) == "����Ҫ" || SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "HKString")) == "")
                {
                    btnQuery_Click(null, null);
                    gridView1.FocusedRowHandle = RowHandle;
                    return;
                }
                int ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                int HKFlag = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("HKFlag"));
                SaleOrder entity = new SaleOrder();
                entity.ID = ID;
                entity.SelectByID();
                entity.HKFlag = HKFlag;
                entity.HKDate = DateTime.Now;
                SaleOrderRule rule = new SaleOrderRule();
                rule.RUpdate(entity);
                btnQuery_Click(null, null);
                gridView1.FocusedRowHandle = RowHandle;
            }
            if (e.Column.FieldName == "BGJFlag")
            {
                int RowHandle = e.RowHandle;
                if (SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "BGJString")) == "����Ҫ" || SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "BGJString")) == "")
                {
                    btnQuery_Click(null, null);
                    gridView1.FocusedRowHandle = RowHandle;
                    return;
                }
                int ID = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                int BGJFlag = SysConvert.ToInt32(gridView1.GetFocusedRowCellValue("BGJFlag"));
                SaleOrder entity = new SaleOrder();
                entity.ID = ID;
                entity.SelectByID();
                entity.BGJFlag = BGJFlag;
                entity.BGJDate = DateTime.Now;
                SaleOrderRule rule = new SaleOrderRule();
                rule.RUpdate(entity);
                btnQuery_Click(null, null);
                gridView1.FocusedRowHandle = RowHandle;
            }
        }

        private void btnHYVendor_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��2))
                {
                    this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                    return;
                }
                frmUpdateOrderWL frm = new frmUpdateOrderWL();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(580, 280);
                frm.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frm.WLVendorID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "WLVendorID"));
                frm.WLFormNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "WLFormNo"));
                frm.ShowDialog();
                btnQuery_Click(null, null);
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { frm.ID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        private void gridView4_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "NoFaQty" || e.Column.FieldName == "NoFaPieceQty" || e.Column.FieldName == "NoFaWeight" || e.Column.FieldName == "NoFaYard")
            {
                e.Appearance.BackColor = Color.Red;
            }
        }
    }
}