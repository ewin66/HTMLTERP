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
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmRecPayEdit : frmAPBaseUIFormEdit
    {
        public frmRecPayEdit()
        {
            InitializeComponent();
        }


        #region ȫ�ֱ���
        int saveInvoiceID = 0;//��ƱID
        int saveHTDtsID = 0;//��ͬ��ϸID
        #endregion
        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("������ɫ�����");
            //    txtCode.Focus();
            //    return false;
            //}
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("�����뵥��");
                txtFormNo.Focus();
                return false;
            }
            //if (SysConvert.ToInt32(drpRecPayType.EditValue) == 0)
            //{
            //    this.ShowMessage("��ѡ���ո�������");
            //    drpRecPayType.Focus();
            //    return false;
            //}

            //if (Common.CheckLookUpEditBlank(drpVendorID))
            //{
            //    this.ShowMessage("��ѡ��������λ");
            //    drpVendorID.Focus();
            //    return false;
            //}
            //if (Common.CheckLookUpEditBlank(drpPayStepType))
            //{
            //    this.ShowMessage("��ѡ���ո���׶�");
            //    drpVendorID.Focus();
            //    return false;
            //}


            if (SysConvert.ToDecimal(txtExAmount.Text.Trim()) == 0)
            {
                this.ShowMessage("��������");
                txtExAmount.Focus();
                return false;
            }



            //if (!this.CheckCorrectDts())
            //{
            //    return false;
            //}

            return true;
        }


        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            RecPayHXDtsRule rule = new RecPayHXDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }



        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            RecPayRule rule = new RecPayRule();
            RecPay entity = EntityGet();
            // RecPayHXDts[] entitydts = EntityDtsGet();
            //decimal TotalCheckAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalCheckAmount+=SysConvert.ToDecimal(entitydts[i].DCheckAmount);
            //}
            //entity.TotalCheckAmount=TotalCheckAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity);//entitydts
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            RecPayRule rule = new RecPayRule();
            RecPay entity = EntityGet();
            //RecPayHXDts[] entitydts = EntityDtsGet();
            //decimal TotalCheckAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalCheckAmount+=SysConvert.ToDecimal(entitydts[i].DCheckAmount);
            //}
            //entity.TotalCheckAmount=TotalCheckAmount;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity);//entitydts
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            RecPay entity = new RecPay();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();


            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeDate.DateTime = entity.MakeDate;
            drpVendorID.EditValue = entity.VendorID;
            txtRemark.Text = entity.Remark.ToString();
            txtExBank.Text = entity.ExBank.ToString();
            txtExDate.DateTime = entity.ExDate;
            txtExMethod.Text = entity.ExMethod.ToString();
            txtExOP.Text = entity.ExOP.ToString();
            txtExAmount.Text = entity.ExAmount.ToString();
            txtMoneyType.Text = entity.MoneyType.ToString();
            txtRate.Text = entity.Rate.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            drpPayStepType.EditValue = entity.PayStepTypeID;
            txtHXAmount.Text = entity.HXAmount.ToString();
            txtHTNo.Text = entity.HTNo.ToString();
            txtHTGCode.Text = entity.HTGoodsCode.ToString();
            drpRecPayType.EditValue = entity.RecPayTypeID;
            txtSJAmount.Text = entity.SJAmount.ToString();
            txtHTDtsAmount.Text = entity.ExAmount.ToString();

            txtNoHXAmount.Text = entity.NoHXAmount.ToString();

            if (entity.HXFlag == (int)YesOrNo.Yes)
            {
                txtHXFlag.Text = "�Ѻ�����";
            }
            else
            {
                txtHXFlag.Text = "δ������";
            }
            if (!findFlag)
            {

            }

            BindGridDts();

            BindGridInvoiceDts();
            BindGridHTDts();
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            RecPayRule rule = new RecPayRule();
            RecPay entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            base.IniInsertSet();
            if (this.FormListAID != 0)
            {
                drpRecPayType.EditValue = this.FormListAID;//�ո�������
            }
            txtMakeDate.DateTime = DateTime.Now;
            txtFormNo_DoubleClick(null, null);
            txtExDate.DateTime = DateTime.Now.Date;
            txtMoneyType.Text = "RMB";


        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//������UI
            this.HTDataTableName = "Finance_RecPay";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2, gridView3 };
            this.HTCheckDataField = new string[] { "InvoiceOperationID", "InvoiceNo" };//������ϸУ�����¼���ֶ�
            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, btnLoad_Click);
            Common.BindCLS(txtMoneyType, "Finance_RecPay", "MoneyType", true);
            Common.BindCLS(txtExMethod, "Finance_RecPay", "ExMethod", true);
            Common.BindPayStepType(drpPayStepType, true);

            txtHXQMakeDateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtHXQMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindOP(drpHXQSaleOPID, true);
            Common.BindRecPayType(drpRecPayType, true);
            if (this.FormListAID == (int)EnumRecPayType.�տ�)
            {
                DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�����ͻ�, (int)EnumVendorType.�����ͻ� }, true);
            }
            else if (this.FormListAID == (int)EnumRecPayType.����)
            {
                DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.�����ӹ���, (int)EnumVendorType.�ӹ���, (int)EnumVendorType.��Ӧ�� }, true);

            }
            else
            {
                Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��ݹ�˾, (int)EnumVendorType.������˾, (int)EnumVendorType.��Ӧ�� }, true);
            }




            this.gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);//��GridView2�¼�
            gridViewBindEventA2(gridView2);


            this.gridViewBaseRowChangedA3 += new gridViewBaseRowChangedA(gridViewRowChanged3);//��GridView2�¼�
            gridViewBindEventA3(gridView3);

        }

        #endregion

        #region �Զ��巽��

        void gridViewRowChanged2(object sender)
        {
            ColumnView view = sender as ColumnView;

            saveInvoiceID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            txtHXInvoiceNo.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["InvoiceNO"]));
            txtHXDtsAmount.Text = (SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["TotalAmount"])) -
                SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["PayAmount"]))).ToString();

        }

        void gridViewRowChanged3(object sender)
        {
            ColumnView view = sender as ColumnView;

            saveHTDtsID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));


        }

        /// <summary>
        /// ��Grid
        /// </summary>
        public string GetCondtioInvoiceDt()
        {
            string tempStr = string.Empty;
            if (txtHXQInvoiceNO.Text.Trim() != "")//��ѯd
            {
                tempStr = " AND InvoiceNO LIKE " + SysString.ToDBString("%" + txtHXQInvoiceNO.Text.Trim() + "%");
            }
            if (chkHXQMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtHXQMakeDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtHXQMakeDateE.DateTime.ToString("yyyy-MM-dd"));
            }
            //if (!Common.CheckLookUpEditBlank(drpVendorID))
            //{
            //    tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            //}
            else//û�пͻ����ж���ɸѡ��
            {
                tempStr += " AND 1=0";
            }

            if (SysConvert.ToString(drpHXQSaleOPID.EditValue) != string.Empty)
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(drpHXQSaleOPID.EditValue.ToString());
            }
            tempStr += " AND SubmitFlag=1";
            tempStr += " AND DZTypeID IN(SELECT ID FROM Enum_DZType WHERE RecPayTypeID=" + SysString.ToDBString(SysConvert.ToInt32(drpRecPayType.EditValue)) + ")";//�������ͺ��ո������ͱ��ǹ�����
            if (chkHXOnlyNOFinish.Checked)
            {
                tempStr += " AND ISNULL(TotalAmount,0)<>ISNULL(PayAmount,0)";//��ѯ���ݲ���
            }
            return tempStr;

        }
        /// <summary>
        /// ��������ϸ
        /// </summary>
        public void BindGridInvoiceDts()
        {
            InvoiceOperationRule rule = new InvoiceOperationRule();
            DataTable dt = rule.RShowPay(GetCondtioInvoiceDt() + " ORDER BY FormDate", ProcessGrid.GetQueryField(gridView2).Replace("NOHXAmount", "0.00 NOHXAmount"));
            foreach (DataRow dr in dt.Rows)
            {
                dr["NOHXAmount"] = SysConvert.ToDecimal(dr["TotalAmount"]) - SysConvert.ToDecimal(dr["PayAmount"]);
            }
            DataTable dtDts = dt;

            gridView2.GridControl.DataSource = dtDts;
            gridView2.GridControl.Show();
        }



        /// <summary>
        /// ��������ϸ
        /// </summary>
        public void BindGridHTDts()
        {
            RecPayHTDtsRule rule = new RecPayHTDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + this.HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView3).Replace("VFormNo", "'' VFormNo"));
            foreach (DataRow dr in dt.Rows)
            {
                dr["VFormNo"] = GetVOrderFormNo(dr["HTNo"].ToString());
            }
            DataTable dtDts = dt;

            gridView3.GridControl.DataSource = dtDts;
            gridView3.GridControl.Show();
        }


        private string GetVOrderFormNo(string p_FormNo)
        {
            string VFormNo = "";
            if (p_FormNo != "")
            {
                string sql = "SELECT CustomerCode FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(p_FormNo);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    VFormNo = SysConvert.ToString(dt.Rows[0][0]);
                }
            }
            return VFormNo;

        }


        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private RecPay EntityGet()
        {
            RecPay entity = new RecPay();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.ExBank = txtExBank.Text.Trim();
            entity.ExDate = txtExDate.DateTime;
            entity.ExMethod = txtExMethod.Text.Trim();
            entity.ExOP = txtExOP.Text.Trim();
            entity.MoneyType = txtMoneyType.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.HTNo = txtHTNo.Text.Trim();
            entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim());
            entity.RecPayTypeID = SysConvert.ToInt32(drpRecPayType.EditValue);// this.FormListAID;
            entity.ExAmount = SysConvert.ToDecimal(txtExAmount.Text.Trim());
            entity.SJAmount = SysConvert.ToDecimal(txtSJAmount.Text.Trim());
            entity.PayStepTypeID = SysConvert.ToInt32(drpPayStepType.EditValue);
            entity.NoHXAmount = entity.ExAmount - entity.HXAmount;



            return entity;
        }

        #endregion




        #region �����¼�
        /// <summary>
        /// ������Ʊ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHXQuery_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridInvoiceDts();
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
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.�ո����);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region �ύ�������ύ����
        /// <summary>
        /// �ύ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                RecPayRule rule = new RecPayRule();
                rule.RSubmit(HTDataID, 1);

                //RAddNews();


                FCommon.AddDBLog(this.Text, FormStatus.�ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        private void RAddNews()
        {
            string sql = "SELECT InSaleOP FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                string OPID = SysConvert.ToString(dt.Rows[0][0]);
                if (OPID != string.Empty)
                {
                    sql = "SELECT OPName,Phone FROM Data_OP WHERE OPID=" + SysString.ToDBString(OPID);
                    dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        string tel = SysConvert.ToString(dt.Rows[0]["Phone"]);
                        if (tel.Length == 11)
                        {
                            MSGMainRule rule = new MSGMainRule();
                            MSGMain entity = new MSGMain();
                            entity.FormDate = DateTime.Now;
                            entity.InsertTime = DateTime.Now;
                            entity.MSGSourceID = (int)EnumMSGSource.�ո���;
                            entity.SendPhone = "13916054226";
                            entity.TargetPhone = tel;
                            entity.TaregtInfo = SysConvert.ToString(dt.Rows[0]["OPName"]);
                            entity.SendTime = DateTime.Now;
                            string Context = "";
                            Context += entity.TaregtInfo + "��ã�";
                            Context += Common.GetVendorNameByVendorID(drpVendorID.EditValue.ToString());
                            Context += "������������ǣ�";
                            Context += txtExAmount.Text.Trim();
                            Context += "��鿴   �Ϻ����ȷ�֯Ʒ���޹�˾";
                            entity.Context = Context;
                            entity.SendDesc = "��Դ���ո�����ţ�" + txtFormNo.Text.Trim();
                            entity.SendInfo += ",�����ˣ��Ϻ����ȷ�֯Ʒ���޹�˾";
                            entity.DID = HTDataID;
                            rule.RAdd(entity);
                            this.ShowInfoMessage("�����ѷ��͸�ҵ��Ա��");

                        }

                    }
                }
            }
        }

        /// <summary>
        /// �����ύ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmitCancel_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }
                RecPay entity = new RecPay();
                entity.ID = HTDataID;
                entity.SelectByID();
                if (entity.ReadFlag == 1)
                {
                    this.ShowMessage("�õ������ģ����ܳ���");
                    return;
                }
                RecPayRule rule = new RecPayRule();
                rule.RSubmit(HTDataID, 0);

                FCommon.AddDBLog(this.Text, FormStatus.�����ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region ����������ť�¼�
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHXExcute_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("�붨λ����¼");
                    return;
                }
                if (HTDataSubmitFlag != (int)YesOrNo.Yes)
                {
                    this.ShowMessage("����δ�ύ�����ܲ���");
                    return;
                }

                if (saveInvoiceID == 0)
                {
                    this.ShowMessage("��ѡ��Ʊ��¼");
                    return;
                }
                if (SysConvert.ToDecimal(txtHXDtsAmount.Text.Trim()) == 0)
                {
                    this.ShowMessage("������������");
                    txtHXDtsAmount.Focus();
                    return;
                }

                RecPayRule rule = new RecPayRule();
                RecPay entity = EntityGet();

                rule.RHX(entity, saveInvoiceID, SysConvert.ToDecimal(txtHXDtsAmount.Text.Trim()));

                FCommon.AddDBLog(this.Text, "����", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);

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
        private void btnHXCancelExcute_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("�붨λ����¼");
                    return;
                }
                int dtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                if (dtsID == 0)
                {
                    this.ShowMessage("��ѡ�������¼");
                    return;
                }

                if (DialogResult.Yes != ShowConfirmMessage("ȷ�ϳ�������������¼��"))
                {
                    return;
                }

                RecPayRule rule = new RecPayRule();
                RecPay entity = EntityGet();

                rule.RHXCancel(entity, dtsID);


                FCommon.AddDBLog(this.Text, "��������", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region ��ͬ����������ť
        /// <summary>
        /// ��ͬ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHTSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("�붨λ����¼");
                    return;
                }
                if (HTDataSubmitFlag != (int)YesOrNo.Yes)
                {
                    this.ShowMessage("����δ�ύ�����ܲ���");
                    return;
                }

                if (SysConvert.ToInt32(drpRecPayType.EditValue) == (int)EnumRecPayType.�տ�)//�������ۺ�ͬ
                {
                    frmLoadOrder frm = new frmLoadOrder();

                    string sql = string.Empty;
                    frm.NoLoadCondition = sql;
                    frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);

                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.OrderID != null && frm.OrderID.Length != 0)
                    {
                        for (int i = 0; i < frm.OrderID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.OrderID[i]);
                            break;//ֻ����һ����ͬ��
                        }
                        setItemNewsSaleHT(str);
                    }
                }
                else if (SysConvert.ToInt32(drpRecPayType.EditValue) == (int)EnumRecPayType.����)//���زɹ���ͬ
                {
                    frmLoadItemBuy frm = new frmLoadItemBuy();
                    frm.VendorID = SysConvert.ToString(drpVendorID.EditValue);
                    string sql = string.Empty;

                    frm.NoLoadCondition = sql;
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.ItemBuyID != null && frm.ItemBuyID.Length != 0)
                    {
                        for (int i = 0; i < frm.ItemBuyID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.ItemBuyID[i]);
                            break;//ֻ����һ����ͬ��
                        }
                        setItemNewsBuyHT(str);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #region ���غ�ͬ����
        /// <summary>
        /// ���ú�ͬ����
        /// </summary>
        /// <param name="p_Str"></param>
        private void setItemNewsSaleHT(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            for (int i = 0; i < orderid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    txtHTDtsHTNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    txtHTItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                    txtHTGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                }
            }
        }

        /// <summary>
        /// ���زɹ�����Ϣ
        /// </summary>
        /// <param name="p_Str"></param>
        private void setItemNewsBuyHT(string p_Str)
        {
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_Buy_ItemBuyFormDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)//ֻ��һ����ϸ����
                {
                    txtHTDtsHTNo.Text = SysConvert.ToString(dt.Rows[0]["FormNo"]);
                    txtHTItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                    txtHTGoodsCode.Text = SysConvert.ToString(dt.Rows[0]["GoodsCode"]);
                }
            }
        }
        #endregion
        /// <summary>
        /// ��ͬ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHTExcute_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("�붨λ����¼");
                    return;
                }
                if (HTDataSubmitFlag != (int)YesOrNo.Yes)
                {
                    this.ShowMessage("����δ�ύ�����ܲ���");
                    return;
                }

                if (txtHTDtsHTNo.Text == "")
                {
                    this.ShowMessage("�����������ͬ��");
                    return;
                }
                if (SysConvert.ToDecimal(txtHTDtsAmount.Text.Trim()) == 0)
                {
                    this.ShowMessage("������������");
                    txtHTDtsAmount.Focus();
                    return;
                }

                RecPayRule rule = new RecPayRule();
                RecPay entity = EntityGet();

                rule.RHT(entity, txtHTDtsHTNo.Text.Trim(), txtHTItemCode.Text.Trim(), txtHTGoodsCode.Text.Trim(), SysConvert.ToDecimal(txtHTDtsAmount.Text.Trim()), this.FormListAID);

                FCommon.AddDBLog(this.Text, "��ͬ����", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);

                SetCapFlag(1);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void SetCapFlag(int p_Flag)
        {
            string sql = "UPDATE Sale_SaleOrderDts SET CapFlag=" + p_Flag;
            sql += " WHERE MainID IN (SELECT ID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(txtHTDtsHTNo.Text.Trim()) + ")";
            sql += " AND ItemCode=" + SysString.ToDBString(txtHTItemCode.Text.Trim());
            SysUtils.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// ��ͬȡ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHTExcuteCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("�붨λ����¼");
                    return;
                }


                if (saveHTDtsID == 0)
                {
                    this.ShowMessage("��ѡ���ͬ������¼");
                    return;
                }
                if (DialogResult.Yes != ShowConfirmMessage("ȷ�ϳ�������������¼��"))
                {
                    return;
                }

                RecPayRule rule = new RecPayRule();
                RecPay entity = EntityGet();

                rule.RHTCancel(entity, saveHTDtsID);

                FCommon.AddDBLog(this.Text, "ȡ����ͬ����", "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);

                SetCapFlag(0);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void drpRecPayType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpRecPayType.EditValue) == (int)EnumRecPayType.�տ�)
                {
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
                }

                else if (SysConvert.ToInt32(drpRecPayType.EditValue) == (int)EnumRecPayType.����)
                {
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.�����ӹ���, (int)EnumVendorType.������, (int)EnumVendorType.��ݹ�˾, (int)EnumVendorType.������˾, (int)EnumVendorType.��Ӧ��, (int)EnumVendorType.֯�� }, true);
                }

                else
                {
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��ݹ�˾, (int)EnumVendorType.������˾, (int)EnumVendorType.��Ӧ�� }, true);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void frmRecPayEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HTDataID > 0)
                {
                    RecPay entity = new RecPay();
                    entity.ID = HTDataID;
                    entity.SelectByID();
                    if (entity.SubmitFlag == 0)
                    {
                        if (DialogResult.Yes != ShowConfirmMessage(this.Text + Environment.NewLine + "û���ύ����,�Ƿ�ȷ�Ϲرմ���"))
                        {
                            e.Cancel = true;
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