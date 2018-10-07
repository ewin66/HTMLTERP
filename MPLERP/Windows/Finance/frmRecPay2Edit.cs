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
    public partial class frmRecPay2Edit : frmAPBaseUIFormEdit
    {
        public frmRecPay2Edit()
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
            if (SysConvert.ToInt32(drpRecPayType.EditValue) == 0)
            {
                this.ShowMessage("��ѡ���ո�������");
                drpRecPayType.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��������λ");
                drpVendorID.Focus();
                return false;
            }
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
            RecPayDtsRule rule = new RecPayDtsRule();
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
            RecPayDts[] entitydts = EntityDtsGet();
            //decimal TotalCheckAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalCheckAmount+=SysConvert.ToDecimal(entitydts[i].DCheckAmount);
            //}
            //entity.TotalCheckAmount=TotalCheckAmount;
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);//entitydts
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            RecPayRule rule = new RecPayRule();
            RecPay entity = EntityGet();
            RecPayDts[] entitydts = EntityDtsGet();
            //decimal TotalCheckAmount = 0;
            //for (int i = 0; i < entitydts.Length; i++)
            //{
            //    TotalCheckAmount+=SysConvert.ToDecimal(entitydts[i].DCheckAmount);
            //}
            //entity.TotalCheckAmount=TotalCheckAmount;
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);//entitydts
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            RecPay entity = new RecPay();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			
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
            txtNoHXAmount.Text = entity.NoHXAmount.ToString();

            txtPreAmount.Text = entity.PreAmount.ToString();
            txtSaleAmount.Text = entity.SaleAmount.ToString();
            txtYJAmount.Text = entity.YJAmount.ToString();
            txtLeftAmount.Text = entity.LeftAmount.ToString();
            txtOtherAmount.Text = entity.OtherAmount.ToString();
            txtSJAmount.Text = entity.SJAmount.ToString();

            ChkNoAmount.EditValue = entity.NoAmountFlag;

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



            string sql = string.Empty;
            sql = "SELECT ID,CLSNM FROM Data_CLS WHERE CLSListID IN(SELECT ID FROM Data_CLSList  WHERE 1=1";
            sql += " AND CLSA='Finance_CostRecord' AND CLSB='CostType')";
            sql += " AND ISNULL(DelFlag,0)=0";
            sql += " ORDER BY CLSIDC,CLSNM";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    gridView1.SetRowCellValue(i, "Project", SysConvert.ToString(dt.Rows[i]["CLSNM"]));
                }
            }
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
            //this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2, gridView3 };
            this.HTCheckDataField = new string[] { "Project" };//������ϸУ�����¼���ֶ�
            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, btnLoad_Click);
            Common.BindCLS(txtMoneyType, "Finance_RecPay", "MoneyType", true);
            Common.BindCLS(txtExMethod, "Finance_RecPay", "ExMethod", true);
            Common.BindPayStepType(drpPayStepType, true);
            Common.BindOP(drpSaleOPID, true);
            if (FParamConfig.LoginHTFlag)
            {
                btnGs.Visible = true;
            }
            Common.BindRecPayType(drpRecPayType, true);
            if (this.FormListAID == (int)EnumRecPayType.�տ�)
            {
                DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            }
            else if (this.FormListAID == (int)EnumRecPayType.����)
            {
                DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��ݹ�˾, (int)EnumVendorType.������˾, (int)EnumVendorType.��Ӧ�� }, true);
            }
            else
            {
                DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��ݹ�˾, (int)EnumVendorType.������˾, (int)EnumVendorType.��Ӧ�� }, true);
            }
            //new VendorProc(drpVendorID);



         
        }

        #endregion

        #region �Զ��巽�� 
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
            entity.ExMethod=txtExMethod.Text.Trim();
            entity.ExOP = txtExOP.Text.Trim();
            entity.MoneyType = txtMoneyType.Text.Trim();
  			entity.Remark = txtRemark.Text.Trim();
            entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim());
            entity.RecPayTypeID = SysConvert.ToInt32(drpRecPayType.EditValue);// this.FormListAID;
            entity.ExAmount = SysConvert.ToDecimal(txtExAmount.Text.Trim());
            entity.PayStepTypeID = SysConvert.ToInt32(drpPayStepType.EditValue);
            entity.NoHXAmount = entity.ExAmount - entity.HXAmount;

            entity.PreAmount = SysConvert.ToDecimal(txtPreAmount.Text.Trim());//�˻����
            entity.SaleAmount = SysConvert.ToDecimal(txtSaleAmount.Text.Trim());//���۽��
            entity.YJAmount = SysConvert.ToDecimal(txtYJAmount.Text.Trim());//Ӷ��
            entity.LeftAmount = entity.PreAmount + entity.SaleAmount - entity.ExAmount + entity.YJAmount;//��ĩ���=�ʺ����+���۽��-�տ���+Ӷ��

            entity.SJAmount = SysConvert.ToDecimal(txtSJAmount.Text.Trim());//ʵ�ʵ��˽��
            entity.OtherAmount = SysConvert.ToDecimal(txtOtherAmount.Text.Trim());//�������

            entity.NoAmountFlag = SysConvert.ToInt32(ChkNoAmount.EditValue);
  			 
            
            return entity;
        }


        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private RecPayDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            RecPayDts[] entitydts = new RecPayDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new RecPayDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].Project = SysConvert.ToString(gridView1.GetRowCellValue(i, "Project"));
                    entitydts[index].Amount = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Amount"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

      


        #region �����¼�
       
        


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
            string sql = "SELECT InSaleOP FROM Data_Vendor WHERE VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                string OPID=SysConvert.ToString(dt.Rows[0][0]);
                if (OPID != string.Empty)
                {
                    sql = "SELECT OPName,Phone FROM Data_OP WHERE OPID="+SysString.ToDBString(OPID);
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
                            Context += entity.TaregtInfo+"��ã�";
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

                RecPayRule rule = new RecPayRule();
                rule.RSubmit(HTDataID,0);

                FCommon.AddDBLog(this.Text, FormStatus.�����ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
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
                    DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
                }

                else if (SysConvert.ToInt32(drpRecPayType.EditValue) == (int)EnumRecPayType.����)
                {
                    DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��ݹ�˾, (int)EnumVendorType.������˾, (int)EnumVendorType.��Ӧ�� }, true);
                }
                
                else
                {
                    DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��ݹ�˾, (int)EnumVendorType.������˾, (int)EnumVendorType.��Ӧ�� }, true);
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

        private void groupControlMainten_Paint(object sender, PaintEventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            label24.Visible = true;
        }

        private void label24_Click_1(object sender, EventArgs e)
        {
            label24.Visible = false;
        }


    }
}