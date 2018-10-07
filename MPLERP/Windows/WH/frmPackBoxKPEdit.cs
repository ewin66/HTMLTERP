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

namespace MLTERP
{
    public partial class frmPackBoxKPEdit : frmAPBaseUIFormEdit
    {
        public frmPackBoxKPEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("�����뵥��");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��ҵ��Ա");
                drpSaleOPID.Focus();
                return false;
            }

            if (SysConvert.ToString(txtKPOPID.EditValue) == "")
            {
                this.ShowMessage("��ѡ��ƥ��Ա");
                txtKPOPID.Focus();
                return false;
            }

            if (!CheckPackNo())
            {
                return false;
            }

            if (SysConvert.ToDecimal(txtTargetQty.Text.Trim()) >= SysConvert.ToDecimal(txtQty.Text.Trim()) && SysConvert.ToDecimal(txtQty.Text.Trim()) != 0 && SysConvert.ToDecimal(txtTargetQty.Text.Trim()) != 0)
            {
                this.ShowMessage("Ŀ����������ӦС����������������������");
                return false;
            }
            if (SysConvert.ToDecimal(txtTargetWeight.Text.Trim()) >= SysConvert.ToDecimal(txtWeight.Text.Trim()) && SysConvert.ToDecimal(txtWeight.Text.Trim()) != 0 && SysConvert.ToDecimal(txtTargetWeight.Text.Trim()) != 0)
            {
                this.ShowMessage("Ŀ�����빫����ӦС�����빫����������������");
                return false;
            }
            if (SysConvert.ToDecimal(txtTargetYard.Text.Trim()) >= SysConvert.ToDecimal(txtYard.Text.Trim()) && SysConvert.ToDecimal(txtYard.Text.Trim()) != 0 && SysConvert.ToDecimal(txtTargetYard.Text.Trim()) != 0)
            {
                this.ShowMessage("Ŀ����������ӦС����������������������");
                return false;
            }
            return true;
        }

        /// <summary>
        /// �ж������Ƿ��ܿ�ƥ
        /// </summary>
        /// <returns></returns>
        private bool CheckPackNo()
        {
            string sql = "SELECT BoxNo,BoxStatusID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(txtBoxNo.Text.Trim());
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                if (SysConvert.ToInt32(dt.Rows[0]["BoxStatusID"]) != (int)EnumBoxStatus.���)
                {
                    this.ShowMessage("����[" + txtBoxNo.Text.Trim() + "]���������״̬������");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                this.ShowMessage("����[" + txtBoxNo.Text.Trim() + "]�����ڣ�����");
                return false;
            }
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            PackBoxKPRule rule = new PackBoxKPRule();
            PackBoxKP entity = EntityGet();
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            PackBoxKPRule rule = new PackBoxKPRule();
            PackBoxKP entity = EntityGet();
            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            PackBoxKP entity = new PackBoxKP();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormNo.Text = entity.FormNo.ToString();
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;

            drpVendorID.EditValue = entity.VendorID;
            txtKPQXDesc.Text = entity.KPQXDesc.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            txtKPOPID.EditValue = entity.KPOPID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtBoxNo.Text = entity.BoxNo.ToString();
            txtQty.Text = entity.Qty.ToString();
            txtTargetBoxNo.Text = entity.TargetBoxNo.ToString();
            txtTargetQty.Text = entity.TargetQty.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            txtColorName.Text = entity.ColorName.ToString();
            txtColorNO.Text = entity.ColorNO.ToString();
            txtWeight.Text = entity.Weight.ToString();
            txtTargetWeight.Text = entity.TargetWeight.ToString();
            txtYard.Text = entity.Yard.ToString();
            txtTargetYard.Text = entity.TargetYard.ToString();
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }
            BindGrid();
        }


        /// <summary>
        /// ��Grids
        /// </summary>
        private void BindGrid()
        {
            PackBoxKPDtsRule rule = new PackBoxKPDtsRule();
            gridView1.GridControl.DataSource = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            PackBoxKPRule rule = new PackBoxKPRule();
            PackBoxKP entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            txtQty.Properties.ReadOnly = true;
            txtWeight.Properties.ReadOnly = true;
            txtYard.Properties.ReadOnly = true;
            txtTargetBoxNo.Properties.ReadOnly = true;
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_PackBoxKP";
            this.HTDataDts = this.gridView1;
            Common.BindOP(drpSaleOPID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            new VendorProc(drpVendorID);
            Common.BindOP(drpSaleOPID, true);
            Common.BindOP(txtKPOPID, true);
        }

        public override void IniInsertSet()
        {
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            drpSaleOPID.EditValue = FParamConfig.LoginID;
            txtMakeOPName.Text = FParamConfig.LoginName;
        
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private PackBoxKP EntityGet()
        {
            PackBoxKP entity = new PackBoxKP();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = txtMakeOPName.Text.Trim();
            entity.MakeDate = txtMakeDate.DateTime.Date;
            entity.FormDate = DateTime.Now.Date;
            entity.VendorID = drpVendorID.EditValue.ToString();
            entity.KPQXDesc = txtKPQXDesc.Text.Trim();
            entity.SaleOPID = drpSaleOPID.EditValue.ToString();
            entity.KPOPID = SysConvert.ToString(txtKPOPID.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            entity.BoxNo = txtBoxNo.Text.Trim();
            entity.Qty = SysConvert.ToDecimal(txtQty.Text.Trim());
            entity.TargetBoxNo = txtTargetBoxNo.Text.Trim();
            entity.TargetQty = SysConvert.ToDecimal(txtTargetQty.Text.Trim());
            entity.Weight = SysConvert.ToDecimal(txtWeight.Text.Trim());
            entity.TargetWeight = SysConvert.ToDecimal(txtTargetWeight.Text.Trim());
            entity.Yard = SysConvert.ToDecimal(txtYard.Text.Trim());
            entity.TargetYard = SysConvert.ToDecimal(txtTargetYard.Text.Trim());
            entity.ColorNO = SysConvert.ToString(txtColorNO.Text.Trim());
            entity.ColorName = SysConvert.ToString(txtColorName.Text.Trim());
            return entity;
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

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.�ύ1))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                PackBoxKPRule rule = new PackBoxKPRule();
                rule.RSubmit(HTDataID, 1);

                FCommon.AddDBLog(this.Text, FormStatus.�ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
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

                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.�ύ1))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }
                //sc �����ύǰ�ж�ϸ���Ƿ��Ѿ�����
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string sql = "SELECT BoxStatusID FROM WH_PackBox WHERE BoxNo = " + SysString.ToDBString(SysConvert.ToString((gridView1.GetRowCellValue(i, "BoxNo"))));
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        if (SysConvert.ToInt32(dt.Rows[0]["BoxStatusID"]) == (int)EnumBoxStatus.����)
                        {
                            this.ShowMessage("��ϸ��:" + SysConvert.ToString((gridView1.GetRowCellValue(i, "BoxNo"))) + "  �ѳ��⣬���ɳ����ύ!");
                            return;
                        }
                    }
                }

                PackBoxKPRule rule = new PackBoxKPRule();
                rule.RSubmit(HTDataID, 0);

                FCommon.AddDBLog(this.Text, FormStatus.�����ύ.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);

            }
        }
        #endregion

        #region �����¼�
        /// <summary>
        /// ˫�����ɵ���
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
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��ƥ����);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        ///// <summary>
        ///// ����Ÿı�
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void txtBoxNo_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
        //        {
        //            FormNoControlRule rule = new FormNoControlRule();
        //            txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��ƥ����);
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        private void txtBoxNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                    {
                        string sql = "SELECT Qty,Weight,Yard,ColorNum ,ColorName FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(txtBoxNo.Text.Trim());
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            txtQty.Text = dt.Rows[0]["Qty"].ToString();
                            txtWeight.Text = dt.Rows[0]["Weight"].ToString();
                            txtYard.Text = dt.Rows[0]["Yard"].ToString();
                            txtColorNO.Text = dt.Rows[0]["ColorNum"].ToString();
                            txtColorName.Text = dt.Rows[0]["ColorName"].ToString();
                        }
                        else
                        {
                            txtQty.Text = "";
                            txtWeight.Text = "";
                            txtYard.Text = "";
                            txtColorNO.Text = "";
                            txtColorName.Text = "";
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

    }
}