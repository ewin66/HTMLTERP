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
using System.Collections;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：移库管理
    /// </summary>
    public partial class frmMoveWHEdit : frmAPBaseUIFormEdit
    {
        public frmMoveWHEdit()
        {
            InitializeComponent();
        }


        #region 全局变量

        private DataTable[] dtPack = new DataTable[150];//码单信息表
        private int PreRowID = -1;//初始行号
        private int CurRowID = -1;//当前行号

        int saveLoadFormType = 0;//加载单据类型
        int saveFillDataType = 0;//回填数据类型

        string saveTHLoadFormListIDStr = string.Empty;

        //private int DtsID = 0;
        //private int DtsSeq = 0;
        #endregion

        #region 全局变量
        int HeadType = 7;//移库
        #endregion


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入单号");
                txtFormNo.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpSubType))
            {
                this.ShowMessage("请选择单据类型");
                drpSubType.Focus();
                return false;
            }
            if (!this.CheckCorrectDts())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            IOFormDtsRule rule = new IOFormDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            IOFormDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            GetMaDanDetail(CurRowID);
            ArrayList List = new ArrayList();
            GetMadanDts(List);
            rule.RAdd2(entity, entitydts, List);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            IOFormDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            GetMaDanDetail(CurRowID);
            ArrayList List = new ArrayList();
            GetMadanDts(List);
            rule.RUpdate(entity, entitydts, List);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.FormNo;

            txtFormIOFormID.Text = entity.FromIOFormID.ToString();
            txtFormNo.Text = entity.FormNo.ToString();
            txtHeadType.Text = this.HeadType.ToString();
            drpSubType.EditValue = SysConvert.ToInt32(entity.SubType);
            drpVendorID.EditValue = entity.VendorID.ToString();
            txtFormDate.DateTime = entity.FormDate;
            drpWHID.EditValue = entity.WHID.ToString();
            //drpWHTypeID.EditValue = SysConvert.ToInt32(entity.WHTypeID);
            txtOutDep.Text = entity.OutDep.ToString();
            txtWHOP.Text = entity.WHOP.ToString();
            txtPassOP.Text = entity.PassOP.ToString();
            drpDutyOP.EditValue = entity.SaleOPID.ToString();
            txtRemark.Text = entity.Remark.ToString();


            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {

            }

            BindGridDts();
            SetIOFormDetail();
            BindPack();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            //drpWHTypeID.EditValue = Common.GetWHTypeByFormListID(this.FormListAID);

            txtFormDate.DateTime = DateTime.Now.Date;
            //drpWHTypeID.Properties.ReadOnly = true;

        }



        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[2] { gridView2, gridView3 };
            this.HTCheckDataField = new string[] { "ItemCode", "SectionID", "ToWHID", "ToSectionID", "Qty" };//数据明细校验必须录入字段

            //this.RightFormID = this.GetFormIDByClassName("frmIOForm");

            this.ToolBarItemAdd(28, "btnLoadStorge", "加载库存", false, btnLoadStorge_Click);

            //Common.BindWHType(drpWHTypeID, false);

            Common.BindWHBySubType(drpWHID, this.FormListAID, true);
            Common.BindWHBySubType(drpItemWHID, this.FormListAID, true);
            //Common.BindWH(drpWHID, true);
            //Common.BindWH(drpItemWHID, true);
            Common.BindSubType(drpSubType, FormListAID, true);//绑定SubType   
            //this.ToolBarItemAdd(28, "btnCheckLoad", "加载库存", false, btnCheckLoad_Click);
            Common.BindOP(drpDutyOP, true);
            SetTabIndex(0, groupControlMainten);
            new VendorProc(drpVendorID);
            Common.BindSubType(drpSubType, this.FormListAID, true);
            //Common.BindEnumUnit(RestxtUnit, true);

            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
            PreRowID = gridView1.FocusedRowHandle;
            CurRowID = gridView1.FocusedRowHandle;
            gridView2.OptionsBehavior.ShowEditorOnMouseUp = false;
            gridView3.OptionsBehavior.ShowEditorOnMouseUp = false;
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);

        }

        /// <summary>
        /// 通用窗体加载方法，如果不要使用，则重写，一般不要修改
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridColumnReadOnly(gridView2, new string[] { "BoxNo", "Qty", "Weight", "GoodsLevel" }, true);
            ProcessGrid.SetGridColumnReadOnly(gridView3, new string[] { "BoxNo", "Qty", "Weight", "GoodsLevel" }, true);
        }



        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                if (view.FocusedRowHandle >= 0)
                {
                    CurRowID = view.FocusedRowHandle;
                    GetMaDanDetail(PreRowID);
                    PreRowID = CurRowID;
                    BindPack();
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void gridViewRowChanged1(object sender)
        {
            BaseFocusLabel.Focus();
            ColumnView view = sender as ColumnView;
            ProcessGrid.SetFormValue(this, view);
            string WHID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WHID"]));
            string SectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SectionID"]));
            string SBitID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SBitID"]));
            string ItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemCode"]));
            string GoodsCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["GoodsCode"]));
            string ColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorNum"]));
            string ColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorName"]));
            string Batch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Batch"));
            string VendorBatch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "VendorBatch"));
            string VendorID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "VendorID"));
            string DtsSO = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "SO"));
            string ItemUnit = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "Unit"));
            string JarNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "JarNum"));
            decimal MWidth = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWidth"));
            decimal MWeight = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "MWeight"));
            chkAll.Checked = false;
            chkAny.Checked = false;
            #region 查找仓库结算类型
            string sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(WHID);//获得仓库结算类型字段
            DataTable dt = SysUtils.Fill(sql);
            string FieldNamestr = string.Empty;
            if (dt.Rows.Count != 0)
            {
                FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
            }
            #endregion
            sql = "SELECT *,0 SelectFlag FROM UV1_WH_PackBox WHERE 1=1";
            sql += " AND WHID=" + SysString.ToDBString(WHID);
            sql += " AND SectionID=" + SysString.ToDBString(SectionID);
            sql += " AND SBitID=" + SysString.ToDBString(SBitID);
            int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
            if (FieldNamestr != string.Empty)
            {
                string[] FieldName = FieldNamestr.Split('+');
                for (int i = 0; i < FieldName.Length; i++)
                {
                    string sqlFieldName = "SELECT ID FROM Enum_WHCalMethodFieldName WHERE Name=" + SysString.ToDBString(FieldName[i]);//找到库存结算字段对应的ID
                    DataTable dtFieldName = SysUtils.Fill(sqlFieldName);
                    if (dtFieldName.Rows.Count != 0 && dtFieldName.Rows[0]["ID"].ToString() != "")
                    {
                        CalFieldName = SysConvert.ToInt32(dtFieldName.Rows[0]["ID"]);
                    }
                    switch (CalFieldName)
                    {
                        case (int)WHCalMethodFieldName.ItemCode://产品编码
                            sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(ItemCode);
                            break;
                        case (int)WHCalMethodFieldName.ColorNum://色号
                            sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(ColorNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorName://颜色
                            sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(ColorName);
                            break;
                        case (int)WHCalMethodFieldName.Batch:   //批号
                            sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(Batch);
                            break;
                        case (int)WHCalMethodFieldName.VendorBatch:  //客户批号
                            sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(VendorBatch);
                            break;
                        case (int)WHCalMethodFieldName.VendorID://客户
                            sql += " AND ISNULL(DtsVendorID,'')=" + SysString.ToDBString(VendorID);
                            break;
                        case (int)WHCalMethodFieldName.JarNum:  //缸号
                            sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(JarNum);
                            break;
                        case (int)WHCalMethodFieldName.Unit:  //缸号
                            sql += " AND ISNULL(Unit,'')=" + SysString.ToDBString(ItemUnit);
                            break;
                        case (int)WHCalMethodFieldName.MWidth://门幅
                            sql += " AND ISNULL(MWidth,0)=" + SysString.ToDBString(MWidth);
                            break;
                        case (int)WHCalMethodFieldName.MWeight://克重
                            sql += " AND ISNULL(MWeight,0)=" + SysString.ToDBString(MWeight);
                            break;

                        default:
                            throw new Exception("结算异常，结算定义的字段底层未对应：" + CalFieldName + ",请联系管理员");
                    }
                }
            }
            sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.入库);
            sql += " AND (ISNULL(Qty,0)>0 OR ISNULL(Weight,0)>0)";
            DataTable dt1 = SysUtils.Fill(sql);
            gridView3.GridControl.DataSource = dt1;
            gridView3.GridControl.Show();
            //this.BindGrid3(WHID, SectionID, ItemCode, GoodsCode, ColorNum, ColorName);
        }

        //private void BindGrid3(string WHID, string SectionID, string ItemCode, string GoodsCode, string ColorNum, string ColorName)
        //{
        //    string sql = "SELECT *,0 SelectFlag FROM WH_PackBox WHERE 1=1";
        //    sql += " AND WHID=" + SysString.ToDBString(WHID);
        //    sql += " AND SectionID=" + SysString.ToDBString(SectionID);
        //    sql += " AND ItemCode=" + SysString.ToDBString(ItemCode);
        //    sql += " AND GoodsCode=" + SysString.ToDBString(GoodsCode);
        //    sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
        //    sql += " AND ColorName=" + SysString.ToDBString(ColorName);
        //    sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.入库);
        //    DataTable dt = SysUtils.Fill(sql);
        //    gridView3.GridControl.DataSource = dt;
        //    gridView3.GridControl.Show();
        //}


        /// <summary>
        /// 获取码单信息
        /// </summary>
        private void GetMaDanDetail(int p_RowID)
        {
            BaseFocusLabel.Focus();
            if (SysConvert.ToString(gridView1.GetRowCellValue(PreRowID, "ItemCode")) != string.Empty)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    dtPack[p_RowID].Rows[i]["MainID"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["MainID"]));
                    dtPack[p_RowID].Rows[i]["Seq"] = SysConvert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns["Seq"]));
                    dtPack[p_RowID].Rows[i]["SubSeq"] = PreRowID + 1;
                    dtPack[p_RowID].Rows[i]["BoxNo"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["BoxNo"]));
                    dtPack[p_RowID].Rows[i]["GoodsLevel"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["GoodsLevel"]));
                    if (SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Qty"])) == 0)
                    {
                        dtPack[p_RowID].Rows[i]["Qty"] = DBNull.Value;
                    }
                    else
                    {
                        dtPack[p_RowID].Rows[i]["Qty"] = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Qty"]));
                    }
                    if (SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Weight"])) == 0)
                    {
                        dtPack[p_RowID].Rows[i]["Weight"] = DBNull.Value;
                    }
                    else
                    {
                        dtPack[p_RowID].Rows[i]["Weight"] = SysConvert.ToDecimal(gridView2.GetRowCellValue(i, gridView2.Columns["Weight"]));
                    }
                    dtPack[p_RowID].Rows[i]["Remark"] = SysConvert.ToString(gridView2.GetRowCellValue(i, gridView2.Columns["Remark"]));
                }
            }
        }


        /// <summary>
        /// 绑定码单
        /// </summary>
        private void BindPack()
        {
            if (CurRowID >= 0)
            {
                DataTable dt = dtPack[CurRowID];
                gridView2.GridControl.DataSource = dt;
                gridView2.GridControl.Show();
            }
        }


        /// <summary>
        /// 得到码单的数据
        /// </summary>
        /// <param name="List"></param>
        private void GetMadanDts(ArrayList List)
        {
            BaseFocusLabel.Focus();
            for (int j = 0; j < gridView1.RowCount; j++)//
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(j, "ItemCode")) != string.Empty)
                {
                    for (int m = 0; m < dtPack[j].Rows.Count; m++)//码单循环
                    {

                        if ((dtPack[j].Rows[m]["PackNo"].ToString() != string.Empty || SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]) != 0) || SysConvert.ToDecimal(dtPack[j].Rows[m]["Weight"]) != 0)
                        {
                            IOFormDtsPack entity = new IOFormDtsPack();
                            entity.MainID = HTDataID;
                            entity.Seq = j + 1;
                            entity.SubSeq = m + 1;

                            entity.BoxNo = dtPack[j].Rows[m]["BoxNo"].ToString();
                            entity.Qty = SysConvert.ToDecimal(dtPack[j].Rows[m]["Qty"]);
                            entity.Weight = SysConvert.ToDecimal(dtPack[j].Rows[m]["Weight"]);
                            entity.GoodsLevel = SysConvert.ToString(dtPack[j].Rows[m]["GoodsLevel"]);
                            entity.Remark = SysConvert.ToString(dtPack[j].Rows[m]["Remark"]);
                            List.Add(entity);

                        }
                    }
                }
            }
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FromIOFormID = SysConvert.ToInt32(txtFormIOFormID.Text.Trim());
            entity.FormNo = txtFormNo.Text.Trim();
            //entity.HeadType = SysConvert.ToInt32(txtHeadType.Text.Trim());
            entity.HeadType = this.FormListAID;
            entity.SubType = SysConvert.ToInt32(drpSubType.EditValue);

            entity.FormDate = txtFormDate.DateTime.Date;
            //entity.WHID = SysConvert.ToString(drpWHID.EditValue);
            //entity.WHTypeID = SysConvert.ToInt32(drpWHTypeID.EditValue);

            entity.OutDep = txtOutDep.Text.Trim();
            entity.WHOP = txtWHOP.Text.Trim();
            entity.PassOP = txtPassOP.Text.Trim();
            entity.DutyOP = SysConvert.ToString(drpDutyOP.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpDutyOP.EditValue);
            entity.Remark = txtRemark.Text.Trim();

            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = DateTime.Now.Date;
            }


            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOFormDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            IOFormDts[] entitydts = new IOFormDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new IOFormDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].WHID = SysConvert.ToString(gridView1.GetRowCellValue(i, "WHID"));
                    entitydts[index].SectionID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SectionID"));
                    entitydts[index].SBitID = SysConvert.ToString(gridView1.GetRowCellValue(i, "SBitID"));
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch"));
                    entitydts[index].VendorBatch = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorBatch"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum"));

                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].SinglePrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "SinglePrice"));
                    entitydts[index].Unit = SysConvert.ToString(gridView1.GetRowCellValue(i, "Unit"));
                    if (entitydts[index].Unit == "RMB/KG")
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Weight;
                    }
                    if (entitydts[index].Unit == "RMB/M")
                    {
                        entitydts[index].Amount = entitydts[index].SinglePrice * entitydts[index].Qty;
                    }
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].DLCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "DLCode"));
                    entitydts[index].GoodsCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsCode"));
                    entitydts[index].GoodsLevel = SysConvert.ToString(gridView1.GetRowCellValue(i, "GoodsLevel"));
                    entitydts[index].VColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorNum"));
                    entitydts[index].VColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "VColorName"));
                    entitydts[index].VItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "VItemCode"));
                    entitydts[index].ToWHID = SysConvert.ToString(gridView1.GetRowCellValue(i, "ToWHID"));
                    entitydts[index].ToSectionID = SysConvert.ToString(gridView1.GetRowCellValue(i, "ToSectionID"));
                    entitydts[index].ToSBitID = SysConvert.ToString(gridView1.GetRowCellValue(i, "ToSBitID"));
                    entitydts[index].MWidth = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth"));
                    entitydts[index].MWeight = SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight"));
                    entitydts[index].WeightUnit = SysConvert.ToString(gridView1.GetRowCellValue(i, "WeightUnit"));
                    entitydts[index].DtsVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsVendorID"));
                    entitydts[index].DtsSO = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSO"));
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo"));
                    entitydts[index].DtsSaleOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsSaleOPID"));
                    entitydts[index].MLType = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MLType"));
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region 其它事件
        /// <summary>
        /// 双击生成单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetWHFormNo(this.FormListAID, SysConvert.ToInt32(drpSubType.EditValue), SysConvert.ToString(drpWHID.EditValue));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion



        #region 提交、撤销提交处理
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }
                IOFormRule rule = new IOFormRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.已提交);

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 撤销提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnSubmitCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }
                IOFormRule rule = new IOFormRule();
                rule.RSubmit(HTDataID, (int)ConfirmFlag.未提交);

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + HTDataID, "");
                this.SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region 绑定相关
        /// <summary>
        /// 入库类型改变绑定不同的客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpSubType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtFormNo_DoubleClick(null, null);
                Common.BindSBit(drpSBitID, SysConvert.ToString(drpSubType.EditValue), false);
                Common.BindWHByFormList(drpItemWHID, SysConvert.ToInt32(drpSubType.EditValue), false);
                string sql = "SELECT * FROM Enum_FormList WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    saveLoadFormType = SysConvert.ToInt32(dt.Rows[0]["LoadFormTypeID"]);
                    saveFillDataType = SysConvert.ToInt32(dt.Rows[0]["FillDataTypeID"]);
                    saveTHLoadFormListIDStr = SysConvert.ToString(dt.Rows[0]["THLoadFormListIDStr"]);
                    if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)//编辑状态下
                    {
                        if (dt.Rows[0]["DefaultWHID"].ToString() != string.Empty)
                        {
                            drpWHID.EditValue = dt.Rows[0]["DefaultWHID"].ToString();
                        }
                    }
                }
                else
                {
                    saveLoadFormType = 0;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region 加载库存
        /// <summary>
        /// 加载库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLoadStorge_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    if (Common.CheckLookUpEditBlank(drpSubType))
                    {
                        this.ShowMessage("请选择单据类型");
                        return;
                    }

                    if (SysConvert.ToString(drpWHID.EditValue) == "")
                    {
                        this.ShowMessage("请选择仓库");
                        drpWHID.Focus();
                        return;
                    }
                    frmLoadStorge frm = new frmLoadStorge();
                    frm.SubType = SysConvert.ToString(drpSubType.EditValue);
                    //frm.WHID = SysConvert.ToString(drpWHID.EditValue);
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.StorgeID != null && frm.StorgeID.Length != 0)
                    {

                        for (int i = 0; i < frm.StorgeID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.StorgeID[i]);
                        }
                        SetWH(str);
                        gridViewRowChanged1(gridView1);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 双击产品编码加载库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnLoadStorge_Click(null, null);

                //if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                //{
                //    if (SysConvert.ToString(drpWHID.EditValue) == "")
                //    {
                //        this.ShowMessage("请选择仓库类型");
                //        drpWHID.Focus();
                //        return;
                //    }
                //    frmLoadStorge frm = new frmLoadStorge();
                //    frm.WHID = SysConvert.ToString(drpWHID.EditValue);
                //    frm.ShowDialog();
                //    string str = string.Empty;
                //    if (frm.StorgeID != null && frm.StorgeID.Length != 0)
                //    {

                //        for (int i = 0; i < frm.StorgeID.Length; i++)
                //        {
                //            if (str != string.Empty)
                //            {
                //                str += ",";
                //            }
                //            str += SysConvert.ToString(frm.StorgeID[i]);
                //        }
                //        SetWH(str);

                //    }


                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 加载库存信息
        /// </summary>
        /// <param name="p_Str"></param>
        private void SetWH(string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WH_Storge WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    gridView1.SetRowCellValue(setRowID, "WHID", SysConvert.ToString(dt.Rows[0]["WHID"]));
                    gridView1.SetRowCellValue(setRowID, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                    gridView1.SetRowCellValue(setRowID, "SBitID", SysConvert.ToString(dt.Rows[0]["SBitID"]));
                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsCode", SysConvert.ToString(dt.Rows[0]["GoodsCode"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    gridView1.SetRowCellValue(setRowID, "DLCode", SysConvert.ToString(dt.Rows[0]["MLDLCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "VColorNum", SysConvert.ToString(dt.Rows[0]["VColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "VColorName", SysConvert.ToString(dt.Rows[0]["VColorName"]));
                    gridView1.SetRowCellValue(setRowID, "VItemCode", SysConvert.ToString(dt.Rows[0]["VItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "MWidth", SysConvert.ToString(dt.Rows[0]["MWidth"]));
                    gridView1.SetRowCellValue(setRowID, "MWeight", SysConvert.ToString(dt.Rows[0]["MWeight"]));
                    gridView1.SetRowCellValue(setRowID, "WeightUnit", SysConvert.ToString(dt.Rows[0]["WeightUnit"]));
                    gridView1.SetRowCellValue(setRowID, "GoodsLevel", SysConvert.ToString(dt.Rows[0]["GoodsLevel"]));
                    gridView1.SetRowCellValue(setRowID, "JarNum", SysConvert.ToString(dt.Rows[0]["JarNum"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "PieceQty", SysConvert.ToDecimal(dt.Rows[0]["PieceQty"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "PieceQty", DBNull.Value);
                    }

                    if (SysConvert.ToDecimal(dt.Rows[0]["Qty"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", SysConvert.ToDecimal(dt.Rows[0]["Qty"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "Qty", DBNull.Value);
                    }
                    if (SysConvert.ToDecimal(dt.Rows[0]["Weight"]) != 0)
                    {
                        gridView1.SetRowCellValue(setRowID, "Weight", SysConvert.ToDecimal(dt.Rows[0]["Weight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(setRowID, "Weight", DBNull.Value);
                    }
                    gridView1.SetRowCellValue(setRowID, "Unit", SysConvert.ToString(dt.Rows[0]["Unit"]));
                    gridView1.SetRowCellValue(setRowID, "DtsVendorID", SysConvert.ToString(dt.Rows[0]["VendorID"]));//库存客户
                    gridView1.SetRowCellValue(setRowID, "DtsSO", SysConvert.ToString(dt.Rows[0]["SO"]));//库存关联单号
                    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["OrderFormNo"]));//库存合同号
                    gridView1.SetRowCellValue(setRowID, "DtsSaleOPID", SysConvert.ToString(dt.Rows[0]["DutyOPID"]));//库存业务
                    gridView1.SetRowCellValue(setRowID, "MLType", SysConvert.ToInt32(dt.Rows[0]["MLType"]));
                    setRowID++;
                }
            }
        }


        #endregion

        #region 重载事件（打印相关）
        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnPreview_Click(sender, e);
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }

                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.转PDF, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnPrint_Click(sender, e);

                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.打印, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        /// <summary>
        /// 设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnDesign_Click(sender, e);
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交3))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                HttSoft.WinUIBase.FastReport.ReportRun(tempReportID, (int)ReportPrintType.设计, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion

        #region 其它事件
        private int checkRowSet()
        {
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == string.Empty)
                {
                    index = i;
                    return index;
                }
            }
            return index;

        }
        #endregion

        #region 码单设置

        /// <summary>
        /// 给码单明细赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    BaseFocusLabel.Focus();
                    MDStorgeSelectChange_Event(gridView3.FocusedRowHandle);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 加载库存码单选择改变行
        /// </summary>
        void MDStorgeSelectChange_Event(int rowID)
        {
            DataTable dtStorgePack = (DataTable)gridView3.GridControl.DataSource;

            if (SysConvert.ToString(dtStorgePack.Rows[rowID]["BoxNo"]) != string.Empty)
            {
                string BoxNo = SysConvert.ToString(dtStorgePack.Rows[rowID]["BoxNo"]);
                decimal Qty = SysConvert.ToDecimal(dtStorgePack.Rows[rowID]["Qty"]);
                decimal Weight = SysConvert.ToDecimal(dtStorgePack.Rows[rowID]["Weight"]);
                string GoodsLevel = SysConvert.ToString(dtStorgePack.Rows[rowID]["GoodsLevel"]);
                if (SysConvert.ToInt32(dtStorgePack.Rows[rowID]["SelectFlag"]) == 1)
                {
                    SetGrid2(BoxNo, Qty, Weight, GoodsLevel);
                }
                else
                {
                    SetGrid2Del(BoxNo);

                }
            }
        }


        /// <summary>
        /// 设置，判断条码是否存在，如不存在，则可赋值
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="Qty"></param>
        private void SetGrid2(string BoxNo, decimal Qty, decimal Weight, string GoodsLevel)
        {
            bool findFlag = false;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) == BoxNo)
                {
                    findFlag = true;
                }
            }
            if (findFlag)
            {
                return;
            }
            DataTable dtPackSource = (DataTable)gridView2.GridControl.DataSource;
            for (int i = 0; i < dtPackSource.Rows.Count; i++)
            {
                if (SysConvert.ToString(dtPackSource.Rows[i]["BoxNo"]) == string.Empty)
                {
                    dtPackSource.Rows[i]["BoxNo"] = BoxNo;
                    dtPackSource.Rows[i]["Qty"] = Qty;
                    dtPackSource.Rows[i]["Weight"] = Weight;
                    dtPackSource.Rows[i]["GoodsLevel"] = GoodsLevel;
                    SetGrid1Qty();
                    return;
                }
            }
            //没有赋值成功，说明行不足
            dtPackSource.Rows.Add(dtPackSource.NewRow());
            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["BoxNo"] = BoxNo;
            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["Qty"] = Qty;
            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["Weight"] = Weight;
            dtPackSource.Rows[dtPackSource.Rows.Count - 1]["GoodsLevel"] = GoodsLevel;

            SetGrid1Qty();
        }

        /// <summary>
        /// 设置，判断条码是否存在，如存在，则可删除
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="Qty"></param>
        private void SetGrid2Del(string BoxNo)
        {
            bool findFlag = false;
            int findIndex = -1;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) == BoxNo)
                {
                    findIndex = i;
                    findFlag = true;
                }
            }
            if (!findFlag)
            {
                return;
            }
            DataTable dtPackSource = (DataTable)gridView2.GridControl.DataSource;
            dtPackSource.Rows.RemoveAt(findIndex);

            SetGrid1Qty();
        }

        /// <summary>
        /// 设置Grid1Qty数量
        /// </summary>
        void SetGrid1Qty()
        {
            int pieceQty = 0;
            decimal qty = 0;
            decimal weight = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "BoxNo")) != string.Empty)
                {
                    pieceQty++;
                    qty += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Qty"));
                    weight += SysConvert.ToDecimal(gridView2.GetRowCellValue(i, "Weight"));
                }
                else//如果不是连续行，自动跳出循环，提高效率
                {
                    break;
                }
            }
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PieceQty", pieceQty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", qty);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Weight", weight);
        }

        private void SetIOFormDetail()
        {

            #region
            int TempID = -1;
            int PSeq = -1;
            int j = 0;//控制gridview的行号
            string sql = string.Empty;
            sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=0";
            DataTable dt = SysUtils.Fill(sql);
            for (int i = 0; i < 150; i++)
            {
                dtPack[i] = dt.Clone();
            }
            DataTable dtVirtual = (DataTable)gridView1.GridControl.DataSource;
            foreach (DataRow dr in dtVirtual.Rows)
            {
                if (dr["ItemCode"].ToString() != string.Empty)
                {
                    if (dr["Seq"].ToString() == string.Empty)
                    {
                        PSeq = j;
                    }
                    else
                    {
                        PSeq = SysConvert.ToInt32(dr["Seq"].ToString()) - 1;
                    }

                    if (this.HTFormStatus == FormStatus.新增)
                    {
                        sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=0";
                        TempID = SysUtils.Fill(sql).Rows.Count;
                        dtPack[PSeq] = SysUtils.Fill(sql);
                        j++;
                    }
                    else
                    {
                        sql = " SELECT " + ProcessGrid.GetQueryField(gridView2) + " FROM WH_IOFormDtsPack WHERE 1=1";
                        sql += " AND MainID=" + SysString.ToDBString(dr["MainID"].ToString());
                        sql += " AND Seq=" + SysString.ToDBString(dr["Seq"].ToString());

                        dtPack[PSeq] = SysUtils.Fill(sql);
                    }
                }
            }
            for (int i = 0; i < 150; i++)
            {
                Common.AddDtRow(dtPack[i], 50);
            }
            #endregion
        }
        #endregion

        #region 全选 反选
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        if (SysConvert.ToString(gridView3.GetRowCellValue(i, "BoxNo")) != string.Empty)
                        {
                            if (chkAll.Checked)
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 1);
                                MDStorgeSelectChange_Event(i);
                            }
                            else
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 0);
                                MDStorgeSelectChange_Event(i);
                            }


                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAny_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        if (SysConvert.ToString(gridView3.GetRowCellValue(i, "BoxNo")) != string.Empty)
                        {
                            if (SysConvert.ToInt32(gridView3.GetRowCellValue(i, "SelectFlag")) == 0)
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 1);
                                MDStorgeSelectChange_Event(i);
                            }
                            else
                            {
                                gridView3.SetRowCellValue(i, "SelectFlag", 0);
                                MDStorgeSelectChange_Event(i);
                            }
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

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SBitID")
            {
                string SBitID = SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "SBitID"));
                string sql = "SELECT * FROM WH_SBit WHERE SBitID =" + SysString.ToDBString(SBitID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "WHID", SysConvert.ToString(dt.Rows[0]["WHID"]));
                    gridView1.SetRowCellValue(e.RowHandle, "SectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                }
            }
            if (e.Column.FieldName == "ToSBitID")
            {
                string ToSBitID = SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "ToSBitID"));
                string sql = "SELECT * FROM WH_SBit WHERE SBitID =" + SysString.ToDBString(ToSBitID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "ToWHID", SysConvert.ToString(dt.Rows[0]["WHID"]));
                    gridView1.SetRowCellValue(e.RowHandle, "ToSectionID", SysConvert.ToString(dt.Rows[0]["SectionID"]));
                }
            }
        }

    }
}