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

namespace MLTERP
{
    /// <summary>
    /// 功能：剪样单管理
    /// 
    /// </summary>
    public partial class frmJYOrderEdit : frmAPBaseUIFormEdit
    {
        public frmJYOrderEdit()
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
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请双击生成单号");
                txtFormNo.Focus();
                return false;
            }
            ////选择下拉数据不为空
            //if (SysConvert.ToString(drpVendorID.EditValue) == string.Empty)
            //{
            //    this.ShowMessage("请选择客户");
            //    drpVendorID.Focus();
            //    return false;
            //}
            if (SysConvert.ToString(drpSaleOPID.EditValue) == string.Empty)
            {
                this.ShowMessage("请选择业务员");
                drpSaleOPID.Focus();
                return false;
            }

            //if (SysConvert.ToInt32(drpJYType.EditValue) == 0)
            //{
            //    this.ShowMessage("请选择类型");
            //    drpJYType.Focus();
            //    return false;
            //}
  

            if (!this.CheckCorrectDts())
            {
                return false;
            }
            //if (!this.CheckSOCorrect())// 检验编码、颜色是否重复
            //{
            //    return false;
            //}
            return true;
        }
        /// <summary>
        /// 检验订单是否重复(同一品种、颜色的数据只能输入一条)
        /// </summary>
        /// <returns></returns>
        private bool CheckSOCorrect()
        {
            //if (ParamConfig.LoginCompanyName == "KMERP")
            //{

            //}
            //else
            //{
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //    {
            //        if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
            //        {
            //            for (int j = 0; j < gridView1.RowCount; j++)
            //            {
            //                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) != string.Empty)
            //                {
            //                    if (i != j && SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ItemCode")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorNum")) && SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "ColorName")))             //&&SysConvert.ToString(gridView1.GetRowCellValue(i, "MWeight")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "MWeight"))&&SysConvert.ToString(gridView1.GetRowCellValue(i, "MWidth")) == SysConvert.ToString(gridView1.GetRowCellValue(j, "MWidth"))
            //                    {
            //                        this.ShowInfoMessage("第" + SysConvert.ToString(SysConvert.ToInt32(i + 1)) + "行数据与第" + SysConvert.ToString(SysConvert.ToInt32(j + 1)) + "行数据重复,产品编号.色号.颜色一致,请检查后重新保存");
            //                        return false;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            return true;
        }

        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            JYOrderDtsRule rule = new JYOrderDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// 绑定面料显示控件
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name="inputUnit">转换单位</param>
        /// <param name="inputConvertXS">转换系数</param>
        void BindUCFabView(DataTable dtSource, string inputUnit, decimal inputConvertXS)
        {
            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//转换为默认单位模式开启,目前支持转换为公斤模式
            //{
            //    ucFabView1.UCQtyConvertMode = true;
            //    ucFabView1.UCQtyConvertModeInputUnit = inputUnit;
            //    ucFabView1.UCQtyConvertModeInputConvertXS = inputConvertXS;
            //}
            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6402)))//成品仓库不使用码单模式
            //{
            //    //6402 6404必须相左设置的
            //    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6404)))//成品仓库出库支持录入码单
            //    {
                    ucFabView1.UCColumnISNHide = true;//隐藏条码列
            //    }
            //}
            ucFabView1.UCDataSource = dtSource;
            ucFabView1.UCAct();
        }



        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            JYOrderRule rule = new JYOrderRule();
            JYOrder entity = EntityGet();
            JYOrderDts[] entitydts = EntityDtsGet();

            decimal totalqty = 0m;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalqty += SysConvert.ToDecimal(entitydts[i].Qty);
            }
            entity.TotalQty = totalqty;

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            JYOrderRule rule = new JYOrderRule();
            JYOrder entity = EntityGet();
            JYOrderDts[] entitydts = EntityDtsGet();

            decimal totalqty = 0m;
            for (int i = 0; i < entitydts.Length; i++)
            {
                totalqty += SysConvert.ToDecimal(entitydts[i].Qty);
            }
            entity.TotalQty = totalqty;


            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            JYOrder entity = new JYOrder();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtTotalQty.Text = entity.TotalQty.ToString();
            drpSaleOPID.EditValue = entity.SaleOPID;
            drpVendorID.EditValue = entity.VendorID;

            drpJYType.EditValue = entity.JYTypeID;
  			
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
            JYOrderRule rule = new JYOrderRule();
            JYOrder entity = EntityGet();
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
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);//自动生成单号
            txtMakeOPName.Text = FParamConfig.LoginName;


        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_JYOrder";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"ItemCode","Qty"};//数据明细校验必须录入字段
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);//绑定客户列表
            new VendorProc(drpVendorID);
            Common.BindOP(drpSaleOPID, true);
            //Common.BindJYType(drpJYType, true);
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载产品", false, btnLoad_Click);//加载面料

            Common.BindVendor(drpGridVendorID, new int[] { (int)EnumVendorType.客户 }, true);//绑定客户列表


            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);
        }


        private void gridViewRowChanged2(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                if (view.FocusedRowHandle >= 0)
                {
                    int ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
                    string sql = string.Empty;

                    string inputUnit = string.Empty;
                    decimal inputConvertXS = 0;
                    //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//转换为默认单位模式开启,目前支持转换为公斤模式
                    //{
                    //    inputUnit = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "InputUnit"));
                    //    inputConvertXS = SysConvert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "InputConvertXS"));
                    //}


                        sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,'' ItemModel,'' JarNum,InputQty FROM Sale_JYOrderDtsInputPack WHERE DID= " + SysString.ToDBString(ID);
                        DataTable dt = SysUtils.Fill(sql);

                        BindUCFabView(dt, inputUnit, inputConvertXS);
                 
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
        private JYOrder EntityGet()
        {
            JYOrder entity = new JYOrder();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.MakeOPName = txtMakeOPName.Text.Trim(); 
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.TotalQty = SysConvert.ToDecimal(txtTotalQty.Text.Trim());
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.SaleOPID = SysConvert.ToString(drpSaleOPID.EditValue);

            entity.JYTypeID = SysConvert.ToInt32(drpJYType.EditValue);

            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private JYOrderDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            JYOrderDts[] entitydts = new JYOrderDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new JYOrderDts();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].VendorID = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorID"));//客户                    
                    entitydts[index].ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode"));
                    entitydts[index].ItemName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName"));
                    entitydts[index].ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemModel"));
                    entitydts[index].ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd"));
                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum")); 
  			 		entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty")); 
  			 		entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")); 
  			 		entitydts[index].Weight = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Weight"));
                    entitydts[index].Width = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Width")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        private void groupControlMainten_Paint(object sender, PaintEventArgs e)
        {

        }

        #region 其它事件
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.剪样单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }


        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                restxtItemCode_DoubleClick(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 双击产品编码加载产品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {

                    
                    frmLoadFabric frm = new frmLoadFabric();
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID != null && frm.GBID.Length != 0)
                    {
                        for (int i = 0; i < frm.GBID.Length; i++)
                        {
                            if (str != string.Empty)
                           
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.GBID[i]);
                        }
                        setItemNews(str);
                        
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void setItemNews(string str)
        {
            string[] arr = str.Split(',');
            int index = checkRowSet();
            int length = 0;
            for (int i = index; i < arr.Length + index; i++)
            {
                string sql = "SELECT * FROM UV1_Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(arr[length]));
                DataTable dt = SysUtils.Fill(sql);

                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(i, "ItemCode", SysConvert.ToString(dt.Rows[0]["ItemCode"]));
                    gridView1.SetRowCellValue(i, "ItemName", SysConvert.ToString(dt.Rows[0]["ItemName"]));
                    gridView1.SetRowCellValue(i, "ItemModel", SysConvert.ToString(dt.Rows[0]["ItemModel"]));
                    //gridView1.SetRowCellValue(i, "ColorName", SysConvert.ToString(dt.Rows[0]["ColorName"]));
                    if (SysConvert.ToDecimal(dt.Rows[0]["MWidth"]) > 0)
                    {
                        gridView1.SetRowCellValue(i, "Width", SysConvert.ToDecimal(dt.Rows[0]["MWidth"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "Width", DBNull.Value);
                    }

                    if (SysConvert.ToDecimal(dt.Rows[0]["MWeight"]) > 0)
                    {
                        gridView1.SetRowCellValue(i, "Weight", SysConvert.ToDecimal(dt.Rows[0]["MWeight"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "Weight", DBNull.Value);
                    }

                }
                length++;
            }
        }

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

        /// <summary>
        /// 双击匹数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToGBDetail_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (this.HTDataSubmitFlag == 0)//未提交状态才允许编辑码单
                {
                    if (HTDataID == 0)
                    {
                        this.ShowMessage("请保存单据后设置细码");
                        return;
                    }
                    int PackFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PackFlag"));
                    int ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                    int MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MainID"));
                    int Seq = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Seq"));
                    decimal Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Qty"));

                    if (ID > 0)
                    {
                        frmLoadJYOrderInput frm = new frmLoadJYOrderInput();
                        //frm.PackType = (int)EnumPackType.仓库单据;
                        frm.ID = ID;
                        frm.MainID = MainID;
                        frm.Seq = Seq;
                        frm.Qty = Qty;
                        if (PackFlag == 1)//有码单明细
                        {
                            frm.UpdateFlag = true;
                        }
                        frm.ShowDialog();
                        if (frm.SaveFlag)//如果保存则刷新数据
                        {
                            BindGridDts();
                            ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { ID.ToString() });
                            //gridViewRowChanged2(gridView1);
                        }
                    }

                }
                else//提交状态
                {
                    this.ShowMessage("单据已提交，不允许编辑码单");
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

       

       


    }
}