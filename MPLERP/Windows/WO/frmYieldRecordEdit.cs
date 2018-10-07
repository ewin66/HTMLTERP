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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace MLTERP
{
    public partial class frmYieldRecordEdit : frmAPBaseUIFormEdit
    {
        public frmYieldRecordEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入色卡编号");
            //    txtCode.Focus();
            //    return false;
            //}
  

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
            YieldRecordDtsRule rule = new YieldRecordDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            YieldRecordRule rule = new YieldRecordRule();
            YieldRecord entity = EntityGet();
            YieldRecordDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            YieldRecordRule rule = new YieldRecordRule();
            YieldRecord entity = EntityGet();
            YieldRecordDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            YieldRecord entity = new YieldRecord();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  			txtProcessTypeID.Text = entity.ProcessTypeID.ToString(); 
  			txtMakeOPID.Text = entity.MakeOPID.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			
  			
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            YieldRecordRule rule = new YieldRecordRule();
            YieldRecord entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);

            ProductCommon.FormNoCtlEditSet(txtFormNo, "WO_YieldRecord", "FormNo", 0, p_Flag);
            
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
             base.IniInsertSet();

             txtFormDate.DateTime = DateTime.Now.Date;
          
             txtMakeDate.DateTime = DateTime.Now.Date;
             txtFormNo_DoubleClick(null, null);
             txtMakeOPName.Text = FParamConfig.LoginName;
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_YieldRecord";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode"};//数据明细校验必须录入字段

            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);

            this.ToolBarItemAdd(28, "btnCheckLoad", "加载", false, btnCheckLoad_Click);

        }

        #endregion


        /// <summary>
        ///通用 重新设置实体1，如果不要使用，则重写，一般不要修改
        /// </summary>
        public virtual void gridViewRowChanged1(object sender)
        {
            this.BaseFocusLabel.Focus();

            ColumnView view = sender as ColumnView;
            string OrderFormNo = SysConvert.ToString(view.GetFocusedRowCellValue("DtsOrderFormNo"));//订单号
            string ProcessFormNo = SysConvert.ToString(view.GetFocusedRowCellValue("DtsProcessFormNo"));//生产单号
            decimal qty = 0;
            //Common.BindSCJarNum(drpJarNum, DtsSO, ReViewCode, true);
            //  

            //HTDataDtsID = Common.GetCellValueInt(gridView1, view.FocusedRowHandle, "ID");
            Reflash(view.FocusedRowHandle);


        }
        private void Reflash(int p_RowHandler)
        {
            string DtsProcessFormNo = SysConvert.ToString(gridView1.GetRowCellValue(p_RowHandler, "DtsProcessFormNo"));//订单号
            decimal qty = 0;
            if (DtsProcessFormNo != "")
            {
                DataTable dt = (DataTable)gridView1.GridControl.DataSource;
                if (dt.Rows.Count == 0)
                {
                    return;
                }


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (SysConvert.ToString(dt.Rows[i]["DtsProcessFormNo"]) == DtsProcessFormNo && SysConvert.ToInt32(dt.Rows[i]["ID"]) == 0)
                    {
                        qty += SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                    }
                }



                string sql = "SELECT SUM(Qty) Qty From UV1_WO_YieldRecordDts WHERE DtsProcessFormNo=" + SysString.ToDBString(DtsProcessFormNo);
                DataTable sqldt = SysUtils.Fill(sql);
                if (sqldt.Rows.Count != 0)
                {
                    qty += SysConvert.ToDecimal(sqldt.Rows[0][0]);
                }

                string sql2 = "Select  SUM(Qty) Qty From UV1_WO_FabricProcessDts where FormNo=" + SysString.ToDBString(DtsProcessFormNo);
                DataTable dt2 = SysUtils.Fill(sql2);
                decimal qty2 = 0;
                if (dt2.Rows.Count != 0)
                {
                    qty2 = SysConvert.ToDecimal(dt2.Rows[0][0]);

                }

                decimal WQty = qty2 - qty;
                txtContractTerms.Text = "织造单号：" + DtsProcessFormNo + "   预计织胚量：" + qty2.ToString() + Environment.NewLine + "已织胚量：" + qty.ToString() + "KG   未织胚量：" + WQty.ToString();

            }
        }

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private YieldRecord EntityGet()
        {
            YieldRecord entity = new YieldRecord();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.ProcessTypeID = SysConvert.ToInt32(txtProcessTypeID.Text.Trim()); 
  			
  			entity.Remark = txtRemark.Text.Trim();

            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = DateTime.Now.Date;
                entity.MakeOPName = FParamConfig.LoginName;
             }
  			 
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private YieldRecordDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            YieldRecordDts[] entitydts = new YieldRecordDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new YieldRecordDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID")); 
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                        entitydts[index].SelectByID();
                    }
                    else//新增
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }
                    
                    entitydts[index].DtsOrderFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsOrderFormNo")); 
  			 		entitydts[index].DtsProcessFormNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "DtsProcessFormNo")); 
  			 		entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")); 
  			 		entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")); 
  			 		entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")); 
  			 		entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel")); 
  			 		entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")); 
  			 		entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		entitydts[index].MachineNo = SysConvert.ToString(gridView1.GetRowCellValue(i, "MachineNo")); 
  			 		entitydts[index].WorkOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "WorkOPID"));
                    entitydts[index].DVendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "DVendorID")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion


        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                
                    ProductCommon.FormNoIniSet(txtFormNo, "WO_YieldRecord", "FormNo", 0);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 其它事件
        /// <summary>
        /// 加载织造单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    frmLoadWOProcess frm = new frmLoadWOProcess();
                    frm.ProcessTypeID = (int)EnumProcessType.织造加工单;
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
                        }
                        WHLoadFabricProcessFormSetWH(str);

                    }
              
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 加载染布加工单信息
        /// </summary>
        /// <param name="p_Str"></param>
        private void WHLoadFabricProcessFormSetWH( string p_Str)
        {
            int setRowID = gridView1.FocusedRowHandle;//设置数据行号
            string[] itembuyid = p_Str.Split(',');
            for (int i = 0; i < itembuyid.Length; i++)
            {
                string sql = "SELECT * FROM  UV1_WO_FabricProcessDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(itembuyid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {

                    gridView1.SetRowCellValue(setRowID, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(setRowID, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(setRowID, "ItemStd", SysConvert.ToString(dt.Rows[0]["ItemStd"]));
                    gridView1.SetRowCellValue(setRowID, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    gridView1.SetRowCellValue(setRowID, "ColorNum", SysConvert.ToString(dt.Rows[0]["ColorNum"]));
                    gridView1.SetRowCellValue(setRowID, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));


                    gridView1.SetRowCellValue(setRowID, "DtsProcessFormNo", SysConvert.ToString(dt.Rows[0]["FormNo"]));
                    gridView1.SetRowCellValue(setRowID, "DtsOrderFormNo", SysConvert.ToString(dt.Rows[0]["DtsSO"]));
                    gridView1.SetRowCellValue(setRowID, "DVendorID", SysConvert.ToString(dt.Rows[0]["DVendorID"]));

               

                    setRowID++;
                }
            }
        }
        #endregion


    }
}