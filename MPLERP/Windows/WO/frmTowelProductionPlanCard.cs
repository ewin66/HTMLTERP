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


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
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
        /// 绑定Grid
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

            if (StepID == (int)EnumWOType.缝边)
            {
                e.Appearance.BackColor = Color.LightPink;
            }
            else if (StepID == (int)EnumWOType.检验)
            {
                e.Appearance.BackColor = Color.LightSkyBlue;
            }
            else if (StepID == (int)EnumWOType.包装)
            {
                e.Appearance.BackColor = Color.Gray;
            }
            else if (StepID == (int)EnumWOType.完成)
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
            else if (StepID == (int)EnumWOType.结束)
            {
                e.Appearance.BackColor = Color.LightGray;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            TowelProductionPlanRule rule = new TowelProductionPlanRule();
            TowelProductionPlan entity = EntityGet();
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
            this.HTDataTableName = "WO_TowelProductionPlan";
            this.HTDataList = gridView1;

            this.HTQryContainer = groupControlQuery;

            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1);
            txtOrderDateE.DateTime = DateTime.Now;

            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.内销客户 }, true);

            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "开卡", false, btnCard_Click);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "删除", false, btnDel_Click);

            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
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

        #region 自定义方法
        /// <summary>
        /// 获得实体
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
        /// 开卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCard_Click(object sender, EventArgs e)
        {
            try
            {
                int DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                int cardNums = 0;//开卡数量
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
                        entity.KBFlag = entityOld.KBFlag;//拷边标志

                        entity.SubSeq = GetMaxSubSeq(entity.MainID, entity.ItemCode, entity.ColorNum);
                        //entity.CardNo = txtCardNo.Text.Trim();
                        //entity.CardQty = SysConvert.ToDecimal(txtCardQty.Text.Trim());
                        //entity.CardTime = DateTime.Now;
                        //entity.StepID = (int)EnumWOType.剪片;//开卡的时候默认为第一站剪片

                        rule.RAdd(entity);

                    }

                    GetCondtion();
                    BindGrid();
                }
                else
                {
                    this.ShowInfoMessage("请选择数据");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除该数据", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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
                this.ShowInfoMessage("源数据不可删除");
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
        /// 获得最大SubSeq
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
                    entity.StepID = 1;// (int)EnumWOType.剪前检验;//保存卡号的时候就默认 第一道工序
                }

                rule.RUpdate(entity);
                this.ShowInfoMessage("保存成功");

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