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

namespace MLTERP
{
    public partial class frmSaleOrder : frmAPBaseUIForm
    {
        public frmSaleOrder()
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

            if (chkReqDate.Checked)
            {
                tempStr += " AND ReqDate BETWEEN " + SysString.ToDBString(txtReqDateS.DateTime) + " AND " + SysString.ToDBString(txtReqDateE.DateTime);
            }

            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }

            if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }

            if (txtCustomerCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND CustomerCode LIKE " + SysString.ToDBString("%" + txtCustomerCode.Text.Trim() + "%");
            }

            if (SysConvert.ToString(drpOrderTypeID.EditValue) != string.Empty)
            {
                tempStr += " AND OrderTypeID=" + SysString.ToDBString(SysConvert.ToInt32(drpOrderTypeID.EditValue));
            }

            if (SysConvert.ToString(drpOrderLevelID.EditValue) != string.Empty)
            {
                tempStr += " AND OrderLevelID=" + SysString.ToDBString(SysConvert.ToInt32(drpOrderLevelID.EditValue));
            }

            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }

            if (txtMWeightS.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWeight>" + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }

            if (txtMWeightE.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWeight<" + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }

            if (txtMWidth.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWidth=" + SysString.ToDBString(txtMWidth.Text.Trim());
            }

            if (txtItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }

            if (txtVColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND VColorNum LIKE " + SysString.ToDBString("%" + txtVColorNum.Text.Trim() + "%");
            }

            if (txtVColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND VColorName LIKE " + SysString.ToDBString("%" + txtVColorName.Text.Trim() + "%");
            }

            if (chkSubmitFlag.Checked)
            {
                tempStr += " AND SubmitFlag=1";
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
            }

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//���۶���ҵ��Աֻ�鿴�Լ��ĵĶ���
            {
                tempStr += " AND SaleOPID IN(" + WCommon.GetStructureMemberOPStr() + ")";
            }
            if (chkNoShow.Checked)
            {
                tempStr += " AND ISNULL(Qty,0)*0.8>ISNULL(TotalRecQty,0)";
            }

            //if (ProductParamSet.GetIntValueByID(5421) == (int)YesOrNo.Yes)//��������
            //{
            tempStr += " AND ISNULL(FAID,0)=1";
            // }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            SaleOrderRule rule = new SaleOrderRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("FormStatusName", "'' FormStatusName").Replace("ReceiveAmount", "0.0 ReceiveAmount"));
            SaleOrderStatusProc.ProcColorStatusName(dt);
            ProcDataSourceQty(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();

            string sql = "SELECT COUNT( ID)  FROM UV1_Sale_SaleOrderDts WHERE 1=1";
            sql += HTDataConditionStr + " GROUP BY ID";
            DataTable dtSO = SysUtils.Fill(sql);
            if (dtSO.Rows.Count > 0)
            {
                lbCount.Text = "���ۺ�ͬ����" + dtSO.Rows[0][0].ToString();
            }
            else
            {
                lbCount.Text = "���ۺ�ͬ����0";
            }

            if (ProductParamSet.GetIntValueByID(5418) == (int)YesOrNo.Yes)//���»�ǩ��־
            {
                sql = "UPDATE Sale_SaleOrder SET HQFlag=1 WHERE FormNo IN (SELECT  ISNULL(FileProt2,'') FROM Data_WinListAttachFile WHERE FileProt1=" + SysString.ToDBString(this.Text) + ")";
                SysUtils.ExecuteNonQuery(sql);
            }

        }

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


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SaleOrder";
            this.HTDataList = gridView1;

            this.HTQryContainer = groupControlQuery;

            Common.BindOrderType(drpOrderTypeID, true);
            Common.BindOrderLevel(drpOrderLevelID, true);

            //if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//��֯�ṹ��ϵ����
            //{
            //    Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            //}
            //else
            //{
            //    Common.BindOPID(drpSaleOPID, true);
            //}

            DevMethod.BindOP(drpSaleOPID, new int[] { (int)EnumOPDep.ҵ�� }, true);

            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-2).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            txtReqDateS.DateTime = DateTime.Now.AddMonths(-2).Date;
            txtReqDateE.DateTime = DateTime.Now.Date;
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-2).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            this.ToolBarItemAdd(32, "btnUpdateOrderStep", "�޸ĺ�ͬվ��", true, UpdateOrderStepToolStripMenuItem_Click, eShortcut.None);
            this.ToolBarItemAdd(32, "btnUpdateOrderStatus", "�޸ĺ�ͬ״̬", true, UpdateOrderStatusToolStripMenuItem_Click, eShortcut.None);
            this.ToolBarItemAdd(32, "btnCancelOrder", "����", true, btnCancelOrder_Click, eShortcut.None);
            this.ToolBarItemAdd(32, "btnCancelCancelOrder_Click", "ȡ������", true, btnCancelCancelOrder_Click, eShortcut.None);

            if (ProductParamSet.GetIntValueByID(5417) == (int)YesOrNo.Yes)//��֯�ṹ��ϵ����
            {
                chkNoShow.Visible = true;
                chkNoShow.Checked = true;
                chkOrderDate.Checked = false;
            }
            //this.ToolBarItemAdd(32, "btnSOProcess", "��������", true, btnSOProcess_Click, eShortcut.None);
            //Common.BindVendor(drpVendorID, new int[] {(int)EnumVendorType.�ͻ� }, true);
            //new VendorProc(drpVendorID);

            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);

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
            //if (FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.���3))
            //{
            //    lbItemVendorID.Visible = true;
            //    txtItemVendorID.Visible = true;
            //}
            //else
            //{
            //    lbItemVendorID.Visible = false;
            //    txtItemVendorID.Visible = false;
            //}

            //if (FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��7))
            //{
            //    lbVendor.Visible = true;
            //    drpSaleOPID.Visible = true;
            //}
            //else
            //{
            //    lbVendor.Visible = false;
            //    drpSaleOPID.Visible = false;
            //}
        }

        /// <summary>
        ///ͨ�� ��������ʵ��1�������Ҫʹ�ã�����д��һ�㲻Ҫ�޸�
        /// </summary>
        public override void gridViewRowChanged1(object sender)
        {
            base.gridViewRowChanged1(sender);

            //ucOrderInfo1.OrderTypeID = 1;
            //ucOrderInfo1.OrderNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormNo"));
            //ucOrderInfo1.IniData();
        }

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

                //if (e.Column.FieldName == "FormNo")
                //{
                //    if(SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle,"CapFlag"))==1)
                //    {
                //        e.Appearance.BackColor = Color.LightBlue;
                //    }
                //}

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
                frm.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frm.OrderStatusName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormStatusName"));
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
                sql += ",CancelReason =''";// +SysString.ToDBString(txtCancelOrderDes.Text.Trim());
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







    }
}