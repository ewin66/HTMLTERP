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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ�������б�
    /// </summary>
    public partial class frmIOForm :frmAPBaseUIWHForm// frmAPBaseUIForm //frmAPBaseUIWHForm
    {
        public frmIOForm()
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
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
            if (SysConvert.ToString(drpQWHTypeID.EditValue) != "")
            {
                tempStr += " AND WHTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQWHTypeID.EditValue));
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
          
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }

            if (txtQItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }
            if (txtQColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (txtQColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtQColorName.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != "")
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQBatch.Text.Trim() != "")
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtQBatch.Text.Trim() + "%");
            }
            if (txtQVendorBatch.Text.Trim() != "")
            {
                tempStr += " AND VendorBatch LIKE " + SysString.ToDBString("%" + txtQVendorBatch.Text.Trim() + "%");
            }
            if (txtQFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtQFormNo.Text.Trim() + "%");
            }
           

            switch (drpQSubmitFlagType.SelectedIndex)
            {
                case 1://���ύ
                    tempStr += " AND isnull(SubmitFlag,0) =1";
                    break;
                case 2://δ�ύ
                    tempStr += " AND isnull(SubmitFlag,0) =0";
                    break;
            }
            switch (drpQDelFlagType.SelectedIndex)
            {
                case 1://δɾ��
                    tempStr += " AND isnull(DelFlag,0) =0";
                    break;
                case 2://��ɾ��
                    tempStr += " AND isnull(DelFlag,0) =1";
                    break;
            }




            tempStr += Common.GetWHRightCondition();

            if (this.FormListAID != 0)
            {
                tempStr += " AND HeadType=" + this.FormListAID;
            }
            if (this.FormListBID != 0)
            {
                tempStr += " AND SubType=" + this.FormListBID;
            }

            //tempStr += " AND HeadType in( Select ID From Enum_FormList WHERE WHFormTypeID=" + SysString.ToDBString(this.FormListAID)+")";

            if (chkQFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQFormDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQFormDateE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }


            if (SysConvert.ToString(drpQCompanyTypeID.EditValue) != "")
            {
                tempStr += " AND CompanyTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQCompanyTypeID.EditValue));
            }



           // tempStr += "";
            // FParamConfig.LoginID
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��0))
            {
                tempStr += " AND DutyOP in (SELECT OPID FROM  Data_OPSaleGroup WHERE SaleGroupID IN(SELECT SaleGroupID FROM Data_OPSaleGroup WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID) + "))";
            }


            tempStr += " Order By FormDate DESC ";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            //IOFormRule rule = new IOFormRule();


            string ConditionAttn = " AND HeadType=" + this.FormListAID;
            ConditionAttn += " AND SubType in(Select ID FROM  Enum_FormList WHERE IsShow=1 )";
            //ConditionAttn += " AND WHID in(Select WHID FROM  WH_WH WHERE isnull(IsJK,0)=0 )";//2012-2-23caoxg





            //gridView2.GridControl.DataSource = rule.RShow(ConditionAttn + HTDataConditionStr, ProcessGrid.GetQueryField(gridView2));
            //gridView2.GridControl.Show();


            IOFormDtsRule rule = new IOFormDtsRule();
           

            //gridView2.GridControl.DataSource = rule.RShow(ConditionAttn + HTDataConditionStr, ProcessGrid.GetQueryField(gridView2));
            DataTable dt = rule.RShow(ConditionAttn + HTDataConditionStr, ProcessGrid.GetQueryField(gridView2).Replace("MakeOPName", "''MakeOPName"));
            ProductMakeOP(dt);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
           
        }

        /// <summary>
        ///  ɫɴ��⡪����ʾ���������˵�����
        /// </summary>
        private void ProductMakeOP(DataTable p_Dt)
        {
            //������
            foreach (DataRow dr in p_Dt.Rows)
            {
                string sqlMakeOP = "SELECT MakeOPName FROM UV1_Buy_ColorCompact WHERE 1=1 AND CODE =" + SysString.ToDBString(dr["DtsSo"].ToString()) + "GROUP BY MakeOPName"; 
                DataTable dtMakeOP = SysUtils.Fill(sqlMakeOP);
                if (dtMakeOP.Rows.Count != 0)
                {


                    dr["MakeOPName"] = SysConvert.ToString(dtMakeOP.Rows[0]["MakeOPName"]);

                }
            }

        }









        /// <summary>
        /// ��Grid
        /// </summary>
        private void BindGridDts()
        {
            IOFormDtsRule rule = new IOFormDtsRule();
            gridView2.GridControl.DataSource = rule.RShow(HTDataID, ProcessGrid.GetQueryField(gridView2));
            gridView2.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
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
            ProcessGrid.GridViewFocus(gridView2, new string[] { "ID" }, new string[] { tempID.ToString() });
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView2;

            ProcessGrid.BindGridColumn(gridView2, this.FormID);//����
            ProcessGrid.SetGridColumnUI(gridView2, this.FormListAID, this.FormListBID);//������UI
            switch (FormListAID)
            {
                //case (int)WHFormList.��ɴ��ⵥ:
                //    //label12.Text = "ɴ�߳ɷ�";
                //    //label13.Text = "ɴ��֧��";
                //    break;
                //case (int)WHFormList.ɫɴ��ⵥ:
                //    //label12.Text = "ɴ�߳ɷ�";
                //    //label13.Text = "ɴ��֧��";
                //    break;
                //case (int)WHFormList.ɫɴ���ⵥ://20100518
                //    //label12.Text = "ɴ�߳ɷ�";
                //    //label13.Text = "ɴ��֧��";
                //    break;
                case (int)WHFormList.���:
                   // this.Name = "frmInWH";
                    //label12.Text = "ɴ�߳ɷ�";
                    //label13.Text = "ɴ��֧��";
                    break;
                case (int)WHFormList.����:
                   // this.Name = "frmOutWH";
                    //label6.Text = "�ӹ���/�ͻ�";
                    break;
                case (int)WHFormList.�ڳ����:
                   // this.Name = "frmDefaultWH";
                    break;
                case (int)WHFormList.�ƿ�:
                  //  this.Name = "frmMoveWH";
                    break;
                case (int)WHFormList.�̵�:
                  // this.Name = "frmCheckWH";
                    break;
            }

            //drpQWHFormTypeID.SelectedIndex = this.FormListAID;

            txtQFormDateS.DateTime = DateTime.Now.AddDays(0 - ParamConfig.QueryDayNum);
            txtQFormDateE.DateTime = DateTime.Now.Date;

            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.���� }, true);//�ͻ� 
            Common.BindCompanyType(drpQCompanyTypeID, true);

            Common.BindWHType(drpQWHTypeID, false);
            Common.BindWH(drpQWHID, true);
            Common.BindCompanyType(drpGridCompanyTypeID, false);//��˾��
            Common.BindWHType(drpGridSubType, false);//�ֿ�����
            Common.BindWH(drpGridWHID, false);//�ֿ�
            //new ItemProcLookUp(drpQItemCode, new int[] { 1 }, true, true);//(int)ItemType.ɴ��
            //this.SaveItemType = Common.GetItemTypeByFormListID(this.FormListAID);//��õ���������

            new ItemProcLookUp(drpQItemCode, Common.GetItemTypeByFormListID(this.FormListAID), true, true);//(int)ItemType.ɴ��

           // btnQuery_Click(null, null);

            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView2);
            SetTabIndex(0, groupControlQuery);
            new VendorProc(drpQVendorID);

            this.IsPostBack = false;
            //btnInsertVisible = false; //�����½���ť
            //btnInsertExistVisible = false;//���ظ��ư�ť
            //btnDeleteVisible = false;//����ɾ����ť
            txtQFormNo_EditValueChanged(null,null);
        }
        
        



        /// <summary>
        ///ͨ�� ��������ʵ��1�������Ҫʹ�ã�����д��һ�㲻Ҫ�޸�
        /// </summary>
        public override void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            HTDataID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            HTDataSubmitFlag = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SubmitFlag"]));
            HTDataDelFlag = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DelFlag"]));

            //SetToolButtonStatus(HTDataSubmitFlag, HTDataDelFlag);

            //BindGridDts();
        }


        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        #region ��ť
        ///// <summary>
        ///// ��ѯ
        ///// </summary>
        //public override void btnQuery_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnQuery_Click(sender, e);
        //        this.GetCondtion();
        //        this.BindGrid();
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        ///// <summary>
        ///// ���
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnBrowse_Click(sender, e);
        //        this.BaseFocusLabel.Focus();
        //        LoadIOFormWin(HTDataID, FormStatus.��ѯ);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// �ύ
        ///// </summary>
        //public override void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.���1))
        //        //{
        //        //    this.ShowMessage("��û�д˲���Ȩ��");
        //        //    return;
        //        //}

        //        //IOFormRule rule = new IOFormRule();
        //        //IOForm entity = new IOForm();
        //        //entity.ID = HTDataID;
        //        //entity.SelectByID();

        //        //rule.RSubmit(this.HTDataID, (int)ConfirmFlag.���ύ, Common.GetFormListTopTypeByFormListID(entity.HeadType), entity.ID, entity.SubType);//���/����
        //        //FCommon.AddDBLog(this.Text, "�ύ", "ID:" + HTDataID.ToString(), "");
        //        //SetPosStatus(this.HTDataID);

        //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
        //        {
        //            this.ShowMessage("��û�д˲���Ȩ��");
        //            return;
        //        }

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
        //            return;
        //        }
        //        //if (!HTSubmitCheck(FormStatus.�ύ))
        //        //{
        //        //    return;
        //        //}

        //        //HTSubmit(HTDataTableName, HTDataID.ToString());


        //        IOFormRule rule = new IOFormRule();
        //        rule.RSubmit(HTDataID, (int)ConfirmFlag.���ύ);

        //        FCommon.AddDBLog(this.Text, FormStatus.�ύ.ToString(), "ID:" + HTDataID, "");
        //        this.SetPosStatus(HTDataID);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        ///// <summary>
        ///// �����ύ
        ///// </summary>
        //public override void btnSubmitCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.���1))
        //        //{
        //        //    this.ShowMessage("��û�д˲���Ȩ��");
        //        //    return;
        //        //}
        //        //IOFormRule rule = new IOFormRule();
        //        //IOForm entity = new IOForm();
        //        //entity.ID = this.HTDataID;
        //        //entity.SelectByID();
        //        //rule.RSubmit(this.HTDataID, (int)ConfirmFlag.δ�ύ, Common.GetFormListTopTypeByFormListID(entity.HeadType), entity.ID, entity.SubType);
        //        //FCommon.AddDBLog(this.Text, "�����ύ", "ID:" + HTDataID.ToString(), "");
        //        //SetPosStatus(this.HTDataID);

        //        if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
        //        {
        //            this.ShowMessage("��û�д˲���Ȩ��");
        //            return;
        //        }

        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
        //            return;
        //        }
        //        //if (!HTSubmitCheck(FormStatus.�ύ))
        //        //{
        //        //    return;
        //        //}

        //        //HTSubmit(HTDataTableName, HTDataID.ToString());


        //        IOFormRule rule = new IOFormRule();
        //        rule.RSubmit(HTDataID, (int)ConfirmFlag.δ�ύ);

        //        FCommon.AddDBLog(this.Text, FormStatus.�ύ.ToString(), "ID:" + HTDataID, "");
        //        this.SetPosStatus(HTDataID);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        ///// <summary>
        ///// ���ͨ��
        ///// </summary>
        //public override void btnAudit_Click(object sender, EventArgs e)
        //{
        //    base.btnAudit_Click(sender, e);
        //}
        ///// <summary>
        ///// ��˾ܾ�
        ///// </summary>
        //public override void btnAuditCancel_Click(object sender, EventArgs e)
        //{
        //    base.btnAuditCancel_Click(sender, e);
        //}

        ///// <summary>
        ///// ����
        ///// </summary>
        //public override void btnInsert_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnInsert_Click(sender, e);
        //        this.BaseFocusLabel.Focus();
        //        LoadIOFormWin(HTDataID, FormStatus.����);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //public override void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnUpdate_Click(sender, e);
        //        this.BaseFocusLabel.Focus();
        //        LoadIOFormWin(HTDataID, FormStatus.�޸�);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// ɾ��
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void btnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnDelete_Click(sender, e);
        //        this.BaseFocusLabel.Focus();
        //        if (HTDataID == 0)
        //        {
        //            this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
        //            return;
        //        }
        //        if (DialogResult.Yes != this.ShowConfirmMessage("ɾ��Ϊ���ɻָ�������ȷ��ɾ��"))
        //        {
        //            return;
        //        }

        //        IOForm entity = new IOForm();
        //        entity.ID = HTDataID;
        //        IOFormRule rule = new IOFormRule();
        //        rule.RDelete(entity);
        //        btnQuery_Click(null, null);
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        ///// <summary>
        ///// תExcel
        ///// </summary>
        //public override void btnToExcel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //base.btnToExcel_Click(sender, e);
        //        this.ToExcel((GridView)gridControlDetail.MainView);
        //        FCommon.AddDBLog(this.Text, "��������", "", "");
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}
        #endregion

        #region ���زֿⵥ��
        /// <summary>
        /// ���زֿⵥ��
        /// </summary>
        /// <param name="p_IOFormID"></param>
        private void LoadIOFormWin(int p_IOFormID, FormStatus p_FormStatus)
        {
            string sql = "SELECT HeadType,SubType FROM WH_IOForm WHERE ID=" + SysString.ToDBString(p_IOFormID);
            DataTable dt = SysUtils.Fill(sql);
            int headtype = 0;
            int subtype = 0;
            int toptypeid = 0;
            string formClassName = string.Empty;
            if (dt.Rows.Count != 0)//
            {
                headtype = SysConvert.ToInt32(dt.Rows[0]["HeadType"]);
                subtype = SysConvert.ToInt32(dt.Rows[0]["SubType"]);

            }
            else
            {
                headtype = this.FormListAID;
            }

            toptypeid = Common.GetFormListTopTypeByFormListID(this.FormListAID);
            switch (toptypeid)
            {
                case (int)WHFormList.���:
                    formClassName = "frmInWHEdit";
                    //this.RightFormID = this.GetFormIDByClassName("frmInWHEdit");
                    break;
                case (int)WHFormList.����:
                    formClassName = "frmOutWHEdit";
                    break;
                //case (int)WHFormList.��̬ת��:
                //    formClassName = "frmTurnForm";
                //    break;
                case (int)WHFormList.�ڳ����:
                    formClassName = "frmDefaultInWHEdit";
                    //headtype = this.FormListAID;
                    break;

                case (int)WHFormList.�̵�:
                    formClassName = "frmCheckWHEdit";
                    //headtype = this.FormListAID;
                    break;
                case (int)WHFormList.�ƿ�:
                    formClassName = "frmMoveWHEdit";
                    //headtype = this.FormListAID;
                    break;
            }
            if (formClassName != string.Empty)
            {
                MDIForm.ContextMenuOpenForm(null,formClassName, headtype, 0, p_IOFormID.ToString(), p_FormStatus);
            }
        }
        #endregion

        #region �����¼�
        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQFormNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetCondtion();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void txtQItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtQItemName.Text = "";
                txtQItemStd.Text = "";
                //txtQItemModel.Text = "";
                string sql = "SELECT ItemName,ItemStd,ItemAttnCode FROM Data_Item WHERE 1=1 AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text.Trim());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    txtQItemName.Text = dt.Rows[0]["ItemName"].ToString();
                    txtQItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
                    //txtQItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
                }
                txtQFormNo_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }
    }
}