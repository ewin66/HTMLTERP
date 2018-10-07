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
using DevExpress.XtraGrid.Views.Base;
using MLTERP.Windows.WO;
using HttSoft.MLTERP.Sys.Enum;

namespace MLTERP
{
    public partial class frmTowelProductionPlanCard : frmAPBaseUIRpt
    {
        public frmTowelProductionPlanCard()
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
            //

            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " and VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }

            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }


            if (txtItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }
            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }
            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }


            if (chkOrderDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtOrderDateS.DateTime) + " AND " + SysString.ToDBString(txtOrderDateE.DateTime);
            }
            tempStr += " and SubmitFlag = 1";
            tempStr += " order by MainID ,Seq,SubSeq  ";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            TowelProductionPlanRule rule = new TowelProductionPlanRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        public override void _HTDataDts_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            base._HTDataDts_RowCellStyle(sender, e);
            int StepID = SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "StepID"));

            if (StepID == (int)EnumWOType.���)
            {
                e.Appearance.BackColor = Color.LightPink;
            }
            else if (StepID == (int)EnumWOType.����)
            {
                e.Appearance.BackColor = Color.LightSkyBlue;
            }
            else if (StepID == (int)EnumWOType.��װ)
            {
                e.Appearance.BackColor = Color.Gray;
            }
            else if (StepID == (int)EnumWOType.���)
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
            else if (StepID == (int)EnumWOType.����)
            {
                e.Appearance.BackColor = Color.LightGray;
            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            TowelProductionPlanRule rule = new TowelProductionPlanRule();
            TowelProductionPlan entity = EntityGet();
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
            this.HTDataTableName = "WO_TowelProductionPlan";
            this.HTDataList = gridView1;

            this.HTQryContainer = groupControlQuery;

            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1);
            txtOrderDateE.DateTime = DateTime.Now;

            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�����ͻ� }, true);

            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "����", false, btnCard_Click);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "ɾ��", false, btnDel_Click);

            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(HTDataList);

            btnQuery_Click(null, null);

            txtCardTime.DateTime = DateTime.Now;

        }

        public void gridViewRowChanged1(object sender)
        {
            try
            {
                ColumnView view = sender as ColumnView;
                txtFormNo2.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "FormNo"));
                txtItemCode2.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemCode"));
                txtItemModel2.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ItemModel"));
                txtColorNum2.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "ColorNum"));
                txtCardNo.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "CardNo"));
                txtCardQty.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "CardQty"));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private TowelProductionPlan EntityGet()
        {
            TowelProductionPlan entity = new TowelProductionPlan();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCard_Click(object sender, EventArgs e)
        {
            try
            {
                int DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                int cardNums = 0;//��������
                if (DtsID != 0)
                {
                    frmTowelProductionPlanCardNums frm = new frmTowelProductionPlanCardNums();
                    frm.ShowDialog();
                    cardNums = frm.CardNums;

                    for (int i = 0; i < cardNums; i++)
                    {
                        TowelProductionPlanDts entityOld = new TowelProductionPlanDts();
                        entityOld.ID = DtsID;
                        entityOld.SelectByID();

                        TowelProductionPlanDts entity = new TowelProductionPlanDts();
                        TowelProductionPlanDtsRule rule = new TowelProductionPlanDtsRule();

                        entity.MainID = entityOld.MainID;
                        entity.ItemCode = entityOld.ItemCode;
                        entity.ItemModel = entityOld.ItemModel;
                        entity.ItemName = entityOld.ItemName;
                        entity.ItemStd = entityOld.ItemStd;
                        entity.ColorNum = entityOld.ColorNum;
                        entity.ColorName = entityOld.ColorName;
                        entity.PieceQty = entityOld.PieceQty;
                        entity.Qty = entityOld.Qty;
                        entity.Unit = entityOld.Unit;
                        entity.SinglePrice = entityOld.SinglePrice;
                        entity.Amount = entityOld.Amount;
                        entity.Batch = entityOld.Batch;
                        entity.Remark = entityOld.Remark;
                        entity.DtsSO = entityOld.DtsSO;
                        entity.LoadDtsID = entityOld.LoadDtsID;
                        entity.KBFlag = entityOld.KBFlag;//���߱�־

                        entity.SubSeq = GetMaxSubSeq(entity.MainID, entity.ItemCode, entity.ColorNum);
                        //entity.CardNo = txtCardNo.Text.Trim();
                        //entity.CardQty = SysConvert.ToDecimal(txtCardQty.Text.Trim());
                        //entity.CardTime = DateTime.Now;
                        //entity.StepID = (int)EnumWOType.��Ƭ;//������ʱ��Ĭ��Ϊ��һվ��Ƭ

                        rule.RAdd(entity);

                    }

                    GetCondtion();
                    BindGrid();
                }
                else
                {
                    this.ShowInfoMessage("��ѡ������");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ȷ��Ҫɾ��������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
            TowelProductionPlanDts entity = new TowelProductionPlanDts();
            TowelProductionPlanDtsRule rule = new TowelProductionPlanDtsRule();
            entity.ID = DtsID;
            entity.SelectByID();

            if (entity.SubSeq == 1)
            {
                this.ShowInfoMessage("Դ���ݲ���ɾ��");
                return;
            }
            else
            {
                rule.RDelete(entity);
            }

            GetCondtion();
            BindGrid();

        }
        /// <summary>
        /// ������SubSeq
        /// </summary>
        /// <param name="p_MainID"></param>
        /// <returns></returns>
        private int GetMaxSubSeq(int p_MainID, string p_ItemCode, string p_ColorNum)
        {
            string sql = " select Max(SubSeq)SubSeq from WO_TowelProductionPlanDts where MainID = " + p_MainID;
            sql += " and ItemCode = " + SysString.ToDBString(p_ItemCode);
            sql += " and ColorNum = " + SysString.ToDBString(p_ColorNum);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dt.Rows[0]["SubSeq"]) + 1;
            }
            else
            {
                return 0;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                int DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                TowelProductionPlanDts entity = new TowelProductionPlanDts();
                TowelProductionPlanDtsRule rule = new TowelProductionPlanDtsRule();
                entity.ID = DtsID;
                entity.SelectByID();

                entity.CardNo = txtCardNo.Text.Trim();
                entity.CardQty = SysConvert.ToDecimal(txtCardQty.Text.Trim());
                entity.CardTime = SysConvert.ToDateTime(txtCardTime.DateTime);
                entity.CardOPID = FParamConfig.LoginID;
                entity.CardOPName = FParamConfig.LoginName;
                if (entity.CardNo != "")
                {
                    entity.StepID = 1;// (int)EnumWOType.��ǰ����;//���濨�ŵ�ʱ���Ĭ�� ��һ������
                }

                rule.RUpdate(entity);
                this.ShowInfoMessage("����ɹ�");

                GetCondtion();
                BindGrid();
                ProcessGrid.GridViewFocus(gridView1, new string[] { "DtsID" }, new string[] { DtsID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }


        }



    }
}