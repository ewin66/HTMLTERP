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
    /// <summary>
    /// �ֿ����
    /// </summary>
    public partial class frmWHEdit : frmAPBaseUIFormEdit
    {
        public frmWHEdit()
        {
            InitializeComponent();
        }

        public int maxrow = 150;

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtWHID.Text.Trim() == "")
            {
                this.ShowMessage("������ֿ���");
                txtWHID.Focus();
                return false;
            }
            if (txtWHNM.Text.Trim() == "")
            {
                this.ShowMessage("������ֿ�����");
                txtWHNM.Focus();
                return false;
            }

            if (!this.CheckCorrectDts())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {

            SectionRule rule = new SectionRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
            {
                Common.AddDtRow(dtDts, 300);
            }

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();


            BindGridWHPic();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            WHRule rule = new WHRule();
            WH entity = EntityGet();
            Section[] entitydts = EntityDtsGet();

            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            WHRule rule = new WHRule();
            WH entity = EntityGet();
            Section[] entitydts = EntityDtsGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            WH entity = new WH();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.WHID;
            txtWHID.Text = entity.WHID.ToString();
            //drpCompanyTypeID.EditValue = entity.CompanyTypeID;
            txtWHNM.Text = entity.WHNM.ToString();
            txtWHStartDate.DateTime = entity.WHStartDate;
            drpIsUseable.EditValue = entity.IsUseable;
            drpWHPosMethodID.EditValue = entity.WHPosMethodID;
            drpISJK.EditValue = entity.ISJK;
            //drpNegativeFlag.EditValue = entity.NegativeFlag;
            //drpZeroExitFlag.EditValue = entity.ZeroExitFlag;
            //txtItemUnit.Text = entity.ItemUnit.ToString();
            txtRemark.Text = entity.Remark.ToString();
            //txtWHtel.Text = entity.WHTel.ToString();
            //drpISOth.EditValue = entity.ISOth;
            //txtWHAddress.Text = entity.WHAddress;
            //txtWHAttn.Text = entity.WHAttn.ToString();
            drpWHCalMethodID.EditValue = entity.WHCalMethodID;
            drpWHType.EditValue = SysConvert.ToInt32(entity.WHType.ToString());
            HTDataDelFlag = entity.DelFlag;
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
            WHRule rule = new WHRule();
            WH entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            //ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            txtWHPicIDP.Properties.ReadOnly = false;
            txtPosXP.Properties.ReadOnly = false;
            txtPosYP.Properties.ReadOnly = false;
            txtSizeWidthP.Properties.ReadOnly = false;
            txtSizeHeightP.Properties.ReadOnly = false;
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtWHStartDate.DateTime = DateTime.Now.Date;
            drpIsUseable.EditValue = 1;
            //drpCompanyTypeID.EditValue = 1;
            drpWHType.EditValue = (int)EnumWHType.���ϲֿ�;
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_WH";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[2] { gridView3, gridView1 };
            this.HTCheckDataField = new string[] { "SectionID" };//������ϸУ�����¼���ֶ�,"WHISN"
            ProcessGrid.BindGridColumn(gridView1, this.FormID);
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);
            ProcessGrid.BindGridColumn(gridView3, this.FormID);
            ProcessGrid.SetGridColumnUI(gridView3, this.FormListAID, this.FormListBID);
            //Common.BindCompanyType(drpCompanyTypeID, false);
            Common.BindWHPosMethod(drpWHPosMethodID, false);
            Common.BindWHCalMethod(drpWHCalMethodID, false);


            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);
            this.gridViewBaseRowChangedA3 += new gridViewBaseRowChangedA(gridViewRowChanged3);
            gridViewBindEventA3(gridView3);//��GridView3�¼�
            Common.BindWHType(drpWHType, true);
            SetTabIndex(0, groupControlMainten);


        }

        /// <summary>
        /// ͨ�ô�����ط����������Ҫʹ�ã�����д��һ�㲻Ҫ�޸�
        /// </summary>
        public override void IniFormLoadBefore()
        {
            //base.IniFormLoadBefore();
            //maxrow = FParamConfig.GridRowNum;
            //FParamConfig.GridRowNum = 300;
        }
        public override void IniFormLoadBehind()
        {
            //base.IniFormLoadBehind();
            //FParamConfig.GridRowNum = 150;
        }

        ///// <summary>
        /////ͨ�� ��������ʵ��
        ///// </summary>
        //private void gridViewRowChanged2(object sender)
        //{
        //    try
        //    {
        //        ColumnView view = sender as ColumnView;
        //        txtWHIDP.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "WHID"));
        //        txtWHPicIDP.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "WHPicID"));
        //        txtPosXP.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "PosX"));
        //        txtPosYP.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "PosY"));
        //        txtSizeWidthP.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SizeWidth"));
        //        txtSizeHeightP.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SizeHeight"));

        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WH EntityGet()
        {
            WH entity = new WH();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.WHID = txtWHID.Text.Trim();
            entity.WHNM = txtWHNM.Text.Trim();
            entity.WHStartDate = txtWHStartDate.DateTime.Date;
            entity.IsUseable = SysConvert.ToInt32(drpIsUseable.EditValue);
            entity.WHPosMethodID = SysConvert.ToInt32(drpWHPosMethodID.EditValue);
            entity.ISJK = SysConvert.ToInt32(drpISJK.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            entity.WHCalMethodID = SysConvert.ToInt32(drpWHCalMethodID.EditValue);
            entity.WHType = drpWHType.EditValue.ToString();

            return entity;
        }
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SBit GetEntitySBit()
        {
            SBit entity = new SBit();
            entity.SBitID = SysConvert.ToString(gridView3.GetFocusedRowCellValue("SBitID"));
            entity.SelectByID();
            entity.MainID = HTDataID;
            entity.SBitID = txtSBit.Text.Trim();
            entity.SectionID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SectionID"));
            entity.WHID = txtWHIDBit.Text.Trim();
            entity.IsUseable = SysConvert.ToInt32(drpIsUseableBit.EditValue);
            entity.Remark = txtRemarkBit.Text.Trim();
            return entity;
        }
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Section[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            Section[] entitydts = new Section[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new Section();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].WHID = SysConvert.ToString(gridView1.GetRowCellValue(i, "WHID"));
                    entitydts[index].WHID = txtWHID.Text.Trim();
                    entitydts[index].SectionID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SectionID"));
                    entitydts[index].IsUseable = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "IsUseable"));
                    entitydts[index].WeightMax = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "WeightMax"));
                    entitydts[index].BulkMax = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "BulkMax"));
                    entitydts[index].PosX = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PosX"));
                    entitydts[index].PosY = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PosY"));
                    entitydts[index].SizeWidth = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SizeWidth"));
                    entitydts[index].SizeHeight = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SizeHeight"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].WHISN = SysConvert.ToString(gridView1.GetRowCellValue(i, "WHISN"));


                    index++;
                }
            }
            return entitydts;
        }

        #endregion



        #region �����¼�

        #endregion



        #region ���������
        private void btnInsertWHPic_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWHPicIDP.Text.Trim() == "")
                {
                    this.ShowMessage("������������");
                    txtWHPicIDP.Focus();
                    return;
                }
                WHPicRule rule = new WHPicRule();
                WHPic entity = this.GetEntityWHPic();
                rule.RAdd(entity);

                BindGridWHPic();


                FCommon.AddDBLog(this.Text, "����������", "ID:" + entity.WHPicID, "");

                ProcessGrid.GridViewFocus(gridView2, new string[1] { "WHPicID" }, new string[1] { entity.WHPicID });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnUpdateWHPic_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWHPicIDP.Text.Trim() == "")
                {
                    this.ShowMessage("������������");
                    txtWHPicIDP.Focus();
                    return;
                }
                WHPicRule rule = new WHPicRule();
                WHPic entity = this.GetEntityWHPic();
                rule.RUpdate(entity);

                FCommon.AddDBLog(this.Text, "���������", "ID:" + entity.WHPicID, "��ID:" + entity.WHPicID);

                BindGridWHPic();

                ProcessGrid.GridViewFocus(gridView2, new string[1] { "WHPicID" }, new string[1] { entity.WHPicID });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnDeleteWHPic_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWHPicIDP.Text.Trim() == "")
                {
                    this.ShowMessage("��ѡ��Ҫɾ���ļ�¼");
                    return;
                }
                if (DialogResult.Yes != this.ShowConfirmMessage("ȷ��Ҫɾ������¼��"))
                {
                    return;
                }

                WHPicRule rule = new WHPicRule();
                WHPic entity = new WHPic();
                entity.MainID = HTDataID;
                entity.WHPicID = txtWHPicIDP.Text.Trim();

                rule.RDelete(entity);

                FCommon.AddDBLog(this.Text, "������ɾ��", "ID:" + entity.WHPicID, "");
                BindGridWHPic();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WHPic GetEntityWHPic()
        {
            WHPic entity = new WHPic();
            entity.MainID = HTDataID;
            entity.WHID = txtWHID.Text.Trim();
            entity.WHPicID = SysConvert.ToString(txtWHPicIDP.Text.Trim());
            entity.PosX = SysConvert.ToInt32(txtPosXP.Text.Trim());
            entity.PosY = SysConvert.ToInt32(txtPosYP.Text.Trim());
            entity.SizeWidth = SysConvert.ToInt32(txtSizeWidthP.Text.Trim());
            entity.SizeHeight = SysConvert.ToInt32(txtSizeHeightP.Text.Trim());
            return entity;
        }


        /// <summary>
        /// �󶨲ֿ�������
        /// </summary>
        private void BindGridWHPic()
        {
            WHPicRule rule = new WHPicRule();
            gridView2.GridControl.DataSource = rule.RShow(" AND MainID=" + SysString.ToDBString(HTDataID), ProcessGrid.GetQueryField(gridView2));
            gridView2.GridControl.Show();

            txtWHID_EditValueChanged(null, null);
        }
        #endregion


        #region �ֿ��Ÿı�󶨶�Ӧ��������
        /// <summary>
        /// �ֿ�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWHID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Common.BindWHPicID(drpGridWHPicID, txtWHID.Text.Trim(), true);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        /// <summary>
        /// ����λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertBit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCorrectBit())
                {
                    return;
                }
                SBitRule rule = new SBitRule();
                SBit entity = this.GetEntitySBit();


                if (SysConvert.ToInt32(drpWHPosMethodID.EditValue) == 1 || SysConvert.ToInt32(drpWHPosMethodID.EditValue) == 2)
                {
                    this.ShowMessage("����λ�ò�����λ�޷�����");
                    return;
                }
                else
                {
                    rule.RAdd(entity);

                }
                FCommon.AddDBLog(this.Text, "λ����", "ID:" + entity.SBitID, "");

                BindGridSBit();
                // ProcessGrid.GridViewFocus(gridView1, new string[1] { "WHID" }, new string[1] { entity.WHID });
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "SectionID" }, new string[1] { entity.SectionID });
                ProcessGrid.GridViewFocus(gridView3, new string[1] { "SBitID" }, new string[1] { entity.SBitID });
                //				Common.AddDBLog(this.Text,OPType.����,"ID:"+entity.SBitID.ToString(),"λ");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// �󶨲ֿ�λ
        /// </summary>
        private void BindGridSBit()
        {
            if (gridView1.RowCount > 0)
            {
                SBitRule rule = new SBitRule();
                string Str = string.Empty;
                Str = " AND WHID=" + SysString.ToDBString(txtWHID.Text.Trim());
                Str += " AND SectionID=" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SectionID")));
                gridView3.GridControl.DataSource = rule.RShow(Str, ProcessGrid.GetQueryField(gridView3));

                gridView3.GridControl.Show();
                txtWHIDBit.Text = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "WHID"));
                txtSectionIDBit.Text = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SectionID"));
            }
        }
        /// <summary>
        /// �ֿ�λ��������У��
        /// </summary>
        /// <returns>true/false</returns>
        private bool CheckCorrectBit()
        {
            if (txtWHIDBit.Text.Trim() == "")
            {
                this.ShowMessage("������ֿ�λ����");
                txtWHIDBit.Focus();
                return false;
            }
            if (txtSectionIDBit.Text.Trim() == "")
            {
                this.ShowMessage("������������");
                txtSectionIDBit.Focus();
                return false;
            }
            if (txtSBit.Text.Trim() == "")
            {
                this.ShowMessage("������λ����");
                txtSBit.Focus();
                return false;
            }
            if (SysConvert.ToString(drpIsUseableBit.EditValue) == "")
            {
                this.ShowMessage("��ѡ���Ƿ����");
                drpIsUseableBit.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// ��������ʵ��2
        /// </summary>
        private void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            ProcessGrid.SetFormValue(this, view);
            txtWHIDBit.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WHID"]));
            txtSectionIDBit.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SectionID"]));
            this.BindGridSBit();
        }
        /// <summary>
        /// ����λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateBit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSBit.Text.Trim() == "")
                {
                    this.ShowMessage("��ѡ��Ҫ�޸ĵļ�¼");
                    return;
                }
                if (!CheckCorrectBit())
                {
                    return;
                }
                SBitRule rule = new SBitRule();
                SBit entity = this.GetEntitySBit();
                string OLDSBitID = SysConvert.ToString(gridView3.GetFocusedRowCellValue("SBitID"));
                //entity.MainID = HTDataID;
                //entity.WHID = txtWHID.Text.Trim();
                //entity.SectionID = txtSectionIDBit.Text.Trim();
                //entity.SBitID = txtSBit.Text.Trim();
                rule.RUpdate(entity, OLDSBitID);

                FCommon.AddDBLog(this.Text, "λ����", "ID:" + entity.SBitID, "New ID:" + entity.SBitID);
                BindGridSBit();
                //ProcessGrid.GridViewFocus(gridView1, new string[1] { "WHID" }, new string[1] { entity.WHID });
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "SectionID" }, new string[1] { entity.SectionID });
                ProcessGrid.GridViewFocus(gridView3, new string[1] { "SBitID" }, new string[1] { entity.SBitID });
                //				Common.AddDBLog(this.Text,OPType.����,"ID:"+entity.OldSBitID.ToString(),"λ");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ��������ʵ��2
        /// </summary>
        private void gridViewRowChanged3(object sender)
        {
            ColumnView view = sender as ColumnView;
            ProcessGrid.SetFormValue(this, view);
            //txtWHIDBit.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WHID"]));
            //txtSectionIDBit.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SectionID"]));
            //txtSBitTemp.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SBitID"]));
            txtWHIDBit.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WHID"]));
            txtSectionIDBit.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SectionID"]));

            drpIsUseableBit.EditValue = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["IsUseable"]));
            txtSBit.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SBitID"]));
            txtRemarkBit.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Remark"]));

        }
        /// <summary>
        /// ɾ��λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteBit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSBit.Text.Trim() == "")
                {
                    this.ShowMessage("��ѡ��Ҫɾ���ļ�¼");
                    return;
                }

                if (DialogResult.Yes != this.ShowConfirmMessage("ȷ��Ҫɾ������¼��"))
                {
                    return;
                }

                SBitRule rule = new SBitRule();
                SBit entity = new SBit();
                entity.MainID = HTDataID;
                entity.WHID = txtWHID.Text.Trim();
                entity.SectionID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SectionID").ToString();
                entity.SBitID = txtSBit.Text.Trim();
                //entity.OldSBitID = txtSBit.Text.Trim();

                rule.RDelete(entity);

                FCommon.AddDBLog(this.Text, "λɾ��", "ID:" + entity.SBitID, "");

                string tempwhid = entity.WHID;
                BindGridSBit();

                ProcessGrid.GridViewFocus(gridView1, new string[1] { "SectionID" }, new string[1] { entity.WHID });
                ProcessGrid.GridViewFocus(gridView3, new string[1] { "SBitID" }, new string[1] { entity.SectionID });
                //				GridViewFocus(gridView3,new string[1]{"SBitID"},new string[1]{entity.SBitID});
                //				Common.AddDBLog(this.Text,OPType.ɾ��,"ID:"+entity.OldSBitID.ToString(),"λ");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        bool Print(int ReportPrintType)
        {
            if (HTDataID == 0)
            {
                this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                return false;
            }

            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 0)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }
            string SectionID = SysConvert.ToString(gridView1.GetFocusedRowCellValue("SectionID"));
            if (SectionID != string.Empty)
            {
                string sql = "SELECT * FROM WH_WH WHERE ID =" + SysString.ToDBString(HTDataID);
                DataTable dtMain = SysUtils.Fill(sql);
                dtMain.TableName = "Main";
                sql = "SELECT * FROM WH_SBit WHERE SectionID =" + SysString.ToDBString(SectionID);
                sql += " AND MainID =" + SysConvert.ToString(HTDataID);
                DataTable dt = SysUtils.Fill(sql);
                dt.TableName = "Dts";
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, ReportPrintType, new DataTable[] { dtMain, dt });
            }
            else
            {
                this.ShowMessage("��ѡ����Ҫ��ӡ����");
                return false;
            }
            return true;
        }
        public override void btnPrint_Click(object sender, EventArgs e)
        {
            Print((int)ReportPrintType.��ӡ);
            //base.btnPrint_Click(sender, e);
        }
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            Print((int)ReportPrintType.Ԥ��);
            //base.btnPreview_Click(sender, e);
        }
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            Print((int)ReportPrintType.���);
            //base.btnDesign_Click(sender, e);
        }


    }
}