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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Grid;

namespace MLTERP
{
    /// <summary>
    /// 功能：客户管理
    /// 作者：章文强
    /// 日期：2012-04-18
    /// 操作：新增
    /// </summary>
    public partial class frmVendor : frmAPBaseUIForm
    {
        public frmVendor()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]

        /// <summary>
        /// 查询条件
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtVendorName.Text.Trim() != "")//查询。
            {
                tempStr = " AND VendorName LIKE " + SysString.ToDBString("%" + txtVendorName.Text.Trim() + "%");
            }
            if (txtVendorID.Text.Trim() != "")
            {
                tempStr = " AND VendorID LIKE " + SysString.ToDBString("%" + txtVendorID.Text.Trim() + "%");
            }
            if (txtTelPhone.Text.Trim() != "")
            {
                tempStr = " AND Tel LIKE " + SysString.ToDBString("%" + txtTelPhone.Text.Trim() + "%");
            }
            if (txtTelPerson.Text.Trim() != "")
            {
                tempStr = " AND Contact LIKE " + SysString.ToDBString("%" + txtTelPerson.Text.Trim() + "%");
            }
            if (txtArea.Text.Trim() != "")
            {
                tempStr = " AND Area LIKE " + SysString.ToDBString("%" + txtArea.Text.Trim() + "%");
            }

            tempStr += " AND ( VendorTypeID IN(0," + SysString.ToDBString(FormListAID) + ") OR";
            tempStr += " VendorID IN(SELECT VendorID FROM Data_VendorTypeDts WHERE VendorTypeID IN(0," + SysString.ToDBString(FormListAID) + "))";
            tempStr += ")";
            //if (FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核2)&&!FParamConfig.LoginHTFlag)
            //{
            //    tempStr+="AND InSaleOP="+SysString.ToDBString(FParamConfig.LoginID);
            //}

            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))//查询所有客户信息
            {
                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//销售订单业务员只查看自己的的订单
                {
                    tempStr += " AND InSaleOP IN(" + WCommon.GetStructureMemberOPStr() + ")";
                }
            }


            tempStr += " ORDER BY ID";
            HTDataConditionStr = tempStr;
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            VendorRule rule = new VendorRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("AddFlag", "0 AddFlag"));
            //if (FormListAID == (int)EnumVendorType.工厂)
            //{
            //    SetGrid(dt);
            //}
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
            gridViewRowChanged1(gridView1);
        }

        private void SetGrid(DataTable dt)
        {
            //foreach (DataRow dr in dt.Rows)
            //{
            //    string sql = "SELECT * FROM Data_VendorAdd WHERE VendorID="+SysString.ToDBString(dr["VendorID"].ToString());
            //    if (SysUtils.Fill(sql).Rows.Count > 0)
            //    {
            //        dr["AddFlag"] = 1;
            //    }
            //    else
            //    {
            //        dr["AddFlag"] = 0;
            //    }
            //}
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            VendorRule rule = new VendorRule();
            Vendor entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Vendor";
            this.HTDataList = gridView1;
            //if (FormListAID == (int)EnumVendorType.工厂)
            //{
            //    this.ToolBarItemAdd(32, "btnAddVendor", "工厂进阶信息", true, btnAddVendor_Click, eShortcut.F9);
            //}
            Common.BindCLS(drpVendorLevel, "Data_Vendor", "VendorLevel", true);
            btnQuery_Click(null, null);

            this.ToolBarItemAdd(32, "btnDealSaleOPID", "处理归属业务员", true, btnDealSaleOPID_Click);
            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);
            this.ToolBarItemAdd(32, "btnDeal", "获取字段", true, btnDeal_Click);
        }

        public void btnDeal_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }
        /// <summary>
        /// 处理客户归属业务员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDealSaleOPID_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    int p_ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));

                    Vendor entity = new Vendor();
                    entity.ID = p_ID;
                    entity.SelectByID();

                    if (entity.InSaleOP != "")
                    {
                        string sql = "Select * from Data_VendorSaleOP where OPID=" + SysString.ToDBString(entity.InSaleOP);
                        sql += " AND MainID=" + entity.ID;
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count == 0)
                        {
                            VendorSaleOPRule rule = new VendorSaleOPRule();
                            VendorSaleOP entityOP = new VendorSaleOP();
                            entityOP.MainID = entity.ID;
                            entityOP.OPID = entity.InSaleOP;
                            entityOP.Remark = "自动添加";
                            rule.RAdd(entityOP);
                        }
                    }
                }

                this.ShowInfoMessage("处理完成！");

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 工厂进阶信息添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            try
            {

                frmVendorAdd frm = new frmVendorAdd();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(580, 280);
                frm.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frm.VendorID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VendorID"));
                frm.ShowDialog();
                txtName_EditValueChanged(null, null);
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { frm.ID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核3))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                this.ToExcelSelectColumn(gridView1);
                FCommon.AddDBLog(this.Text, "导出列表", "导出人" + FParamConfig.LoginName, "导出时间:" + DateTime.Now.Date.ToShortDateString());
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
        private Vendor EntityGet()
        {
            Vendor entity = new Vendor();
            entity.ID = HTDataID;
            return entity;
        }

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        public override void gridViewRowChanged1(object sender)
        {
            base.gridViewRowChanged1(sender);
            //this.BaseFocusLabel.Focus();
            GridView view = sender as GridView;
            int id = SysConvert.ToInt32(view.GetFocusedRowCellValue("ID"));
            string sql = "SELECT * FROM Data_VendorAddress WHERE MainID =" + id;
            DataTable dt = SysUtils.Fill(sql);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
            //gridView1.Focus();
        }
        #endregion


    }
}