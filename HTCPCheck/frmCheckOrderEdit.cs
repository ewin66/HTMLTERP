using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
//using HttSoft.HTCheck.Data;
//using HttSoft.HTCheck.DataCtl;
//using HttSoft.HTCheck.Sys;
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;
using HttSoft.HTCPCheck.DataCtl;
using HttSoft.HTCPCheck.Data;

namespace HTCPCheck
{
    public partial class frmCheckOrderEdit : frmAPBaseUIFormEdit
    {
        public frmCheckOrderEdit()
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
            CheckOrderDtsRule rule = new CheckOrderDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            CheckOrderRule rule = new CheckOrderRule();
            CheckOrder entity = EntityGet();
            CheckOrderDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CheckOrderRule rule = new CheckOrderRule();
            CheckOrder entity = EntityGet();
            CheckOrderDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            CheckOrder entity = new CheckOrder();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            txtFormNo.Text = entity.FormNo.ToString();
            txtFormDate.DateTime = entity.FormDate;
            txtAutoCreateFlag.Text = entity.AutoCreateFlag.ToString();
            txtSaleProcedureID.Text = entity.SaleProcedureID.ToString();
            txtSaleProcedureFormNo.Text = entity.SaleProcedureFormNo.ToString();
            txtVendorID.Text = entity.VendorID.ToString();
            txtItemCode.Text = entity.ItemCode.ToString();
            txtItemName.Text = entity.ItemName.ToString();
            txtItemStd.Text = entity.ItemStd.ToString();
            txtItemModel.Text = entity.ItemModel.ToString();
            txtMWidth.Text = entity.MWidth.ToString();
            txtMWeight.Text = entity.MWeight.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtMakeOPID.Text = entity.MakeOPID.ToString();
            txtMakeOPName.Text = entity.MakeOPName.ToString();
            txtMakeDate.DateTime = entity.MakeDate;


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
            CheckOrderRule rule = new CheckOrderRule();
            CheckOrder entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { txtFormNo }, false);
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            base.IniInsertSet();
            txtFormDate.DateTime = DateTime.Now;
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtMakeDate.DateTime = DateTime.Now;
            txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Chk_CheckOrder";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "ColorNum" };//数据明细校验必须录入字段
            this.ToolBarItemAdd(28, "btnLoadItem", "加载产品", true, btnLoadItem_Click);
        }
        /// <summary>
        /// 加载产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLoadItem_Click(object sender, EventArgs e)
        {
            try
            {
                //frmLoadItem frm = new frmLoadItem();
                //frm.ShowDialog();
                //string str = string.Empty;
                //if (frm.GBID != null && frm.GBID.Length != 0)
                //{
                //    for (int i = 0; i < frm.GBID.Length; i++)
                //    {
                //        if (str != string.Empty)
                //        {
                //            str += ",";
                //        }
                //        str += SysConvert.ToString(frm.GBID[i]);
                //    }
                //}
                //string sql = " SELECT * FROM  Data_Item WHERE ID IN ( " + str + " )";
                //DataTable dt = SysUtils.Fill(sql);
                //int index = Common.GetNewRow(gridView1, "ItemCode");
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        txtItemCode.Text = dr["ItemCode"].ToString();
                //        txtItemName.Text = dr["ItemName"].ToString();
                //        txtItemStd.Text = dr["ItemStd"].ToString();
                //        txtItemModel.Text = dr["ItemModel"].ToString();
                //        txtMWidth.Text=dr["MWidth"].ToString();
                //        txtMWeight.Text = dr["MWeight"].ToString();
                //    }
                //}
                

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
        private CheckOrder EntityGet()
        {
            CheckOrder entity = new CheckOrder();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.FormNo = txtFormNo.Text.Trim();
            entity.FormDate = txtFormDate.DateTime.Date;
            entity.AutoCreateFlag = SysConvert.ToInt32(txtAutoCreateFlag.Text.Trim());
            entity.SaleProcedureID = SysConvert.ToInt32(txtSaleProcedureID.Text.Trim());
            entity.SaleProcedureFormNo = txtSaleProcedureFormNo.Text.Trim();
            entity.VendorID = txtVendorID.Text.Trim();
            entity.ItemCode = txtItemCode.Text.Trim();
            entity.ItemName = txtItemName.Text.Trim();
            entity.ItemStd = txtItemStd.Text.Trim();
            entity.ItemModel = txtItemModel.Text.Trim();
            entity.MWidth = txtMWidth.Text.Trim();
            entity.MWeight = txtMWeight.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();

            if (HTFormStatus == FormStatus.新增)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeOPName = FParamConfig.LoginName;
                entity.MakeDate = DateTime.Now;
            }


            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckOrderDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            CheckOrderDts[] entitydts = new CheckOrderDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new CheckOrderDts();
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

                    entitydts[index].ColorNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorNum"));
                    entitydts[index].ColorName = SysConvert.ToString(gridView1.GetRowCellValue(i, "ColorName"));
                    entitydts[index].Batch = SysConvert.ToString(gridView1.GetRowCellValue(i, "Batch"));
                    entitydts[index].VendorBatch = SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorBatch"));
                    entitydts[index].JarNum = SysConvert.ToString(gridView1.GetRowCellValue(i, "JarNum"));
                    entitydts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
                    entitydts[index].PieceQty = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PieceQty"));
                    entitydts[index].CheckQty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "CheckQty"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));


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
                FormNoControlRule rule = new FormNoControlRule();
                txtFormNo.Text = rule.RGetFormNo("Chk_CheckOrder", "FormNo");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #region 其它事件

        #endregion


    }
}