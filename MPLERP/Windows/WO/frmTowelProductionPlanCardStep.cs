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
    public partial class frmTowelProductionPlanCardStep : frmAPBaseUIRpt
    {
        public frmTowelProductionPlanCardStep()
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
            tempStr += " and StepID = " + this.FormListAID;  //工序为当前工序
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
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView4 };
            this.HTQryContainer = groupControlQuery;

            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1);
            txtOrderDateE.DateTime = DateTime.Now;

            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.内销客户 }, true);

            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "开卡", false, btnCard_Click);
            //this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "删除", false, btnDel_Click);

            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(HTDataList);

            btnQuery_Click(null, null);

            DevMethod.BindOP2(drpMakeOPID, true);
            drpMakeOPID.EditValue = FParamConfig.LoginID;
            DevMethod.BindOP2(drpProOPID);

            txtCardTime.DateTime = DateTime.Now;
            txtRecDate.DateTime = DateTime.Now;
            if (this.FormListAID == (int)EnumWOType.剪片)//如果是第一道工序 就不显示退回上一站按钮
            {
                btnBack.Visible = false;
            }
            if (this.FormListAID == (int)EnumWOType.完成)//完成 就不显示下一站
            {
                BtnNext.Text = "完成";
            }
            if (this.FormListAID == (int)EnumWOType.结束)//完成 就不显示下一站
            {
                btnSave.Visible = false;//保存
                BtnNext.Visible = false;//下一站
                btnUpdate.Visible = false;//修改产量
                groupControl2.Visible = false;//产量信息
                groupControlDataList.Dock = DockStyle.Fill;
            }


        }
        /// <summary>
        /// 行改变
        /// </summary>
        /// <param name="sender"></param>
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

                //1
                #region 换行将该工序里存的值赋值
                int MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(view.FocusedRowHandle, "MainID"));
                int DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(view.FocusedRowHandle, "DtsID"));
                int SubSeq = SysConvert.ToInt32(gridView1.GetRowCellValue(view.FocusedRowHandle, "SubSeq"));
                int StepID = SysConvert.ToInt32(gridView1.GetRowCellValue(view.FocusedRowHandle, "StepID"));
                int ID = 0;

                string sql = " select * from WO_TowelProductionPlanDtsStep where 1=1 ";
                sql += " and MainID = " + MainID;
                sql += " and DtsID = " + DtsID;
                sql += " and SubSeq = " + SubSeq;
                if (this.FormListAID == (int)EnumWOType.结束)//结束 可以查看 完成状态下输入的数据
                {
                    sql += " and StepID = " + (SysConvert.ToInt32(StepID) - 1);
                }
                else
                {
                    sql += " and StepID = " + StepID;
                }
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                }

                TowelProductionPlanDtsStep entity = new TowelProductionPlanDtsStep();
                TowelProductionPlanDtsStepRule rule = new TowelProductionPlanDtsStepRule();
                entity.ID = ID;
                entity.SelectByID();
                txtRecQty.Text = entity.RecQty.ToString();
                txtRecDate.DateTime = SysConvert.ToDateTime(entity.RecDate);
                txtZPQty.Text = entity.ZPQty.ToString();
                txtCPQty.Text = entity.CPQty.ToString();
                drpMakeOPID.EditValue = SysConvert.ToString(entity.MakeOPID);
                //drpProOPID.EditValue = SysConvert.ToString(entity.ProOPID);
                txtRemark.Text = entity.Remark.ToString();

                if (ID <= 0)
                {
                    txtRecDate.DateTime = DateTime.Now;
                }
                #endregion

                //2绑定产量表
                string sqlA = " select * from WO_TowelProductionPlanDtsStepProducts where 1=1 ";
                sqlA += " and MainID = " + MainID;
                sqlA += " and DtsID = " + DtsID;
                sqlA += " and SubSeq = " + SubSeq;
                sqlA += " and StepID = " + StepID;
                DataTable dtA = SysUtils.Fill(sqlA);
                if (dtA.Rows.Count > 0)
                {
                    gridView4.GridControl.DataSource = dtA;
                    gridView4.GridControl.Show();
                }
                else//没有保存的值grid 就默认为空
                {
                    //Common.AddDtRow(gridView4.GridControl.DataSource as DataTable, 150);
                    dtA.Clear();
                    Common.AddDtRow(dtA, 150);
                    gridView4.GridControl.DataSource = dtA;
                    gridView4.GridControl.Show();
                }

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
                        entity.StepID = (int)EnumWOType.剪片;//开卡的时候默认为第一站剪片

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
            if (MessageBox.Show("确定要删除该卡", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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

        /// <summary>
        /// 保存  保存当前站输入的信息 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                int MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MainID"));
                int DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                int SubSeq = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SubSeq"));
                int StepID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "StepID"));
                int ID = 0;

                //保存卡号等信息
                #region 保存卡号等信息
                string sql = " select * from WO_TowelProductionPlanDtsStep where 1=1 ";
                sql += " and MainID = " + MainID;
                sql += " and DtsID = " + DtsID;
                sql += " and SubSeq = " + SubSeq;
                sql += " and StepID = " + StepID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                }

                TowelProductionPlanDtsStep entity = new TowelProductionPlanDtsStep();
                TowelProductionPlanDtsStepRule rule = new TowelProductionPlanDtsStepRule();
                entity.ID = ID;
                entity.SelectByID();

                entity.MainID = MainID;
                entity.DtsID = DtsID;
                entity.SubSeq = SubSeq;
                entity.StepID = this.FormListAID;//站别为当前 FormListAID
                entity.CardNo = SysConvert.ToString(txtCardNo.Text.Trim());
                entity.RecQty = SysConvert.ToDecimal(txtRecQty.Text.Trim());
                entity.RecDate = SysConvert.ToDateTime(txtRecDate.DateTime);
                entity.ZPQty = SysConvert.ToDecimal(txtZPQty.Text.Trim());
                entity.CPQty = SysConvert.ToDecimal(txtCPQty.Text.Trim());
                entity.MakeOPID = SysConvert.ToString(drpMakeOPID.EditValue);
                //entity.ProOPID = SysConvert.ToString(drpProOPID.EditValue);
                entity.Remark = SysConvert.ToString(txtRemark.Text.Trim());

                if (SysConvert.ToDecimal(entity.RecQty) == 0)
                {
                    this.ShowInfoMessage("请输入收到数量");
                    txtRecQty.Focus();
                    return;
                }

                if (entity.ID > 0)
                {
                    rule.RUpdate(entity);
                    //this.ShowInfoMessage("保存成功");
                }
                else
                {
                    rule.RAdd(entity);
                    //this.ShowInfoMessage("保存成功");
                }
                #endregion


                //2
                #region 保存工人产量表
                TowelProductionPlanDtsStepProducts ProductsEntity = new TowelProductionPlanDtsStepProducts();
                TowelProductionPlanDtsStepProductsRule ProductsRule = new TowelProductionPlanDtsStepProductsRule();
                int ProductsID = 0;
                string sqlA = " select * from WO_TowelProductionPlanDtsStepProducts where 1=1 ";
                sqlA += " and MainID = " + MainID;
                sqlA += " and DtsID = " + DtsID;
                sqlA += " and SubSeq = " + SubSeq;
                sqlA += " and StepID = " + StepID;
                DataTable dtA = SysUtils.Fill(sqlA);
                if (dtA.Rows.Count > 0)
                {

                    for (int i = 0; i < dtA.Rows.Count; i++)
                    {
                        ProductsID = SysConvert.ToInt32(dtA.Rows[i]["ID"]);
                        ProductsEntity.ID = ProductsID;
                        ProductsEntity.SelectByID();
                        ProductsRule.RDelete(ProductsEntity);//删除现有
                    }

                }
                TowelProductionPlanDtsStepProducts[] EntityProducts = EntityProductsGet(MainID, DtsID, SubSeq, StepID, entity.CardNo);
                ProductsRule.RAdd(EntityProducts);
                #endregion

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
        /// <summary>
        /// 进入下一站  更新当前站完成日期 将站别+1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                int MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MainID"));
                int DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                int SubSeq = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SubSeq"));
                int StepID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "StepID"));
                int KBFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KBFlag"));
                int ID = 0;

                string sql = " select * from WO_TowelProductionPlanDtsStep where 1=1 ";
                sql += " and MainID = " + MainID;
                sql += " and DtsID = " + DtsID;
                sql += " and SubSeq = " + SubSeq;
                sql += " and StepID = " + StepID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    TowelProductionPlanDtsStep entityStep = new TowelProductionPlanDtsStep();
                    TowelProductionPlanDtsStepRule Steprule = new TowelProductionPlanDtsStepRule();
                    entityStep.ID = ID;
                    entityStep.SelectByID();

                    decimal QtyAll = SysConvert.ToDecimal(entityStep.ZPQty) + SysConvert.ToDecimal(entityStep.CPQty);
                    if (QtyAll <= 0)
                    {
                        this.ShowInfoMessage("请输入正品数、次品数");
                        txtZPQty.Focus();
                        return;
                    }

                    entityStep.CompleteDate = DateTime.Now;
                    Steprule.RUpdate(entityStep);
                }
                else
                {
                    this.ShowInfoMessage("请先保存数据");
                    return;
                }


                TowelProductionPlanDts entity = new TowelProductionPlanDts();
                TowelProductionPlanDtsRule rule = new TowelProductionPlanDtsRule();
                entity.ID = DtsID;
                entity.SelectByID();

                if (this.FormListAID == (int)EnumWOType.剪片)//在剪片这一站需要判断是否要拷边
                {
                    if (KBFlag == 1)//拷边标志=1  需要拷边 加一站
                    {
                        entity.StepID = StepID + 1;
                    }
                    else
                    {
                        entity.StepID = StepID + 2;
                    }
                }
                else
                {
                    entity.StepID = StepID + 1;
                }


                rule.RUpdate(entity);

                GetCondtion();
                BindGrid();
                ProcessGrid.GridViewFocus(gridView1, new string[] { "DtsID" }, new string[] { DtsID.ToString() });

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 退回上一站  删除本站保存的信息  将站别-1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {

                this.BaseFocusLabel.Focus();
                int MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MainID"));
                int DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                int SubSeq = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SubSeq"));
                int StepID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "StepID"));
                int KBFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KBFlag"));
                int ID = 0;

                //1
                #region 删除卡号信息
                string sql = " select * from WO_TowelProductionPlanDtsStep where 1=1 ";
                sql += " and MainID = " + MainID;
                sql += " and DtsID = " + DtsID;
                sql += " and SubSeq = " + SubSeq;
                sql += " and StepID = " + StepID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    TowelProductionPlanDtsStep entityStep = new TowelProductionPlanDtsStep();
                    TowelProductionPlanDtsStepRule Steprule = new TowelProductionPlanDtsStepRule();
                    entityStep.ID = ID;
                    entityStep.SelectByID();
                    Steprule.RDelete(entityStep);
                }
                #endregion

                //2
                #region 删除工人产量信息
                sql = " select * from WO_TowelProductionPlanDtsStepProducts where 1=1 ";
                sql += " and MainID = " + MainID;
                sql += " and DtsID = " + DtsID;
                sql += " and SubSeq = " + SubSeq;
                sql += " and StepID = " + StepID;
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    sql = " delete from WO_TowelProductionPlanDtsStepProducts where 1=1 ";
                    sql += " and MainID = " + MainID;
                    sql += " and DtsID = " + DtsID;
                    sql += " and SubSeq = " + SubSeq;
                    sql += " and StepID = " + StepID;
                    SysUtils.ExecuteNonQuery(sql);
                }
                #endregion

                //3站别-
                TowelProductionPlanDts entity = new TowelProductionPlanDts();
                TowelProductionPlanDtsRule rule = new TowelProductionPlanDtsRule();
                entity.ID = DtsID;
                entity.SelectByID();
                if (entity.StepID > 1)//如果站别大于1 
                {
                    if (this.FormListAID == (int)EnumWOType.拷边 || this.FormListAID == (int)EnumWOType.缝边)
                    {
                        if (KBFlag == 1)//拷边的 退一站 否则退两站
                        {
                            entity.StepID = StepID - 1;
                        }
                        else
                        {
                            entity.StepID = StepID - 2;
                        }
                    }
                    else
                    {
                        entity.StepID = StepID - 1;
                    }

                }
                rule.RUpdate(entity);

                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }


        /// <summary>
        /// 获得工人产量实体
        /// </summary>
        /// <returns></returns>
        private TowelProductionPlanDtsStepProducts[] EntityProductsGet(int p_MainID, int p_DtsID, int p_SubSeq, int p_StepID, string p_CardNo)
        {
            //int index = GetDataCompleteNum();
            int index = 0;
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                if (SysConvert.ToString(gridView4.GetRowCellValue(i, "ProOPID")) != "")
                {
                    index++;
                }
            }

            TowelProductionPlanDtsStepProducts[] entitydts = new TowelProductionPlanDtsStepProducts[index];
            index = 0;
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                if (SysConvert.ToString(gridView4.GetRowCellValue(i, "ProOPID")) != "")
                {
                    entitydts[index] = new TowelProductionPlanDtsStepProducts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView4.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = p_MainID;
                    entitydts[index].DtsID = p_DtsID;
                    entitydts[index].SubSeq = p_SubSeq;
                    entitydts[index].StepID = p_StepID;
                    entitydts[index].Seq = i + 1;

                    entitydts[index].CardNo = p_CardNo;
                    entitydts[index].ProOPID = SysConvert.ToString(gridView4.GetRowCellValue(i, "ProOPID"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView4.GetRowCellValue(i, "Qty"));
                    entitydts[index].Remark = SysConvert.ToString(gridView4.GetRowCellValue(i, "Remark"));

                    entitydts[index].RecQty = SysConvert.ToDecimal(gridView4.GetRowCellValue(i, "RecQty"));
                    entitydts[index].CQty = SysConvert.ToDecimal(gridView4.GetRowCellValue(i, "CQty"));

                    entitydts[index].MLDefect = SysConvert.ToDecimal(gridView4.GetRowCellValue(i, "MLDefect"));
                    entitydts[index].RSDefect = SysConvert.ToDecimal(gridView4.GetRowCellValue(i, "RSDefect"));
                    entitydts[index].FRDefect = SysConvert.ToDecimal(gridView4.GetRowCellValue(i, "CQty"));
                    entitydts[index].OtherDefect = SysConvert.ToDecimal(gridView4.GetRowCellValue(i, "OtherDefect"));

                    entitydts[index].JarNum = SysConvert.ToString(gridView4.GetRowCellValue(i, "JarNum"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView4.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView4.GetRowCellValue(i, "MWeight"));
                    entitydts[index].SeCha = SysConvert.ToString(gridView4.GetRowCellValue(i, "SeCha"));
                    entitydts[index].SeLaoDu = SysConvert.ToString(gridView4.GetRowCellValue(i, "SeLaoDu"));
                    entitydts[index].XiShuiXing = SysConvert.ToString(gridView4.GetRowCellValue(i, "XiShuiXing"));
                    entitydts[index].Conclusion = SysConvert.ToString(gridView4.GetRowCellValue(i, "Conclusion"));

                    entitydts[index].WorkStartTime = SysConvert.ToDateTime(gridView4.GetRowCellValue(i, "WorkStartTime"));
                    entitydts[index].WorkingHours = SysConvert.ToDecimal(gridView4.GetRowCellValue(i, "WorkingHours"));


                    index++;
                }
            }
            return entitydts;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                int MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MainID"));
                int DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                int SubSeq = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SubSeq"));
                int StepID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "StepID"));

                string sql = " select * from WO_TowelProductionPlanDtsStepProducts where 1=1 ";
                sql += " and MainID = " + MainID;
                sql += " and DtsID = " + DtsID;
                sql += " and SubSeq = " + SubSeq;
                sql += " and StepID = " + StepID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count <= 0)
                {
                    this.ShowInfoMessage("请选择数据");
                    return;
                }
                Common.AddDtRow(dt, 150);
                gridView4.GridControl.DataSource = dt;
                gridView4.GridControl.Show();


                //if (dt.Rows.Count > 0)
                //{
                //    gridView4.GridControl.DataSource = dt;
                //    gridView4.GridControl.Show();
                //}
                //else
                //{
                //    //Common.AddDtRow(gridView4.GridControl.DataSource as DataTable, 150);
                //    dt.Clear();
                //    Common.AddDtRow(dt, 150);
                //    gridView4.GridControl.DataSource = dt;
                //    gridView4.GridControl.Show();
                //}

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


    }
}