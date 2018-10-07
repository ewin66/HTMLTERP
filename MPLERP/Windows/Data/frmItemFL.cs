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
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 物品管理
    /// </summary>
    public partial class frmItemFL : frmAPBaseUISin
    {
        public frmItemFL()
        {
            InitializeComponent();
        }

        #region 全局变量
        //private int SaveItemClassID = 0;
        private string ItemClassArray = string.Empty;
        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtQItemCode.Text.Trim() != "")//查询
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemName.Text.Trim() != "")//查询
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
            //if (this.FormListAID == 1)
            //{
            //    tempStr += " AND ItemCode='1'";
            //}
            //tempStr += " AND isnull(DelFlag,0)=0";
            
            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            tempStr += " ORDER BY ItemCode,ItemName,ID";
           
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = " AND ItemTypeID=" + SysString.ToDBString(FormListAID);
            if (ItemClassArray != "-1")
            {
                sql += " AND ItemClassID IN(" + ItemClassArray + ")";
            }
            ItemRule rule = new ItemRule();
            gridView1.GridControl.DataSource = rule.RShowView(sql + HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ItemRule rule = new ItemRule();
            Item entity = EntityGet();
            entity.SelectByID();
         
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Item";
            this.HTDataList = gridView1;

            txtQMakeDateE.DateTime = DateTime.Now.Date;
            txtQMakeDateS.DateTime = DateTime.Now.Date.AddDays(0 - ParamConfig.QueryDayNum);

            ProcessTreeList.BindTreeColumn(treeList1, this.FormID);//绑定列				
            ProcessTreeList.SetTreeColumnUI(treeList1);//设置列UI

            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI
            ProcessGrid.SetGridEdit(gridView1, new string[] { "ItemName","ItemCode","ItemStd"}, true);//临时让其处于可编辑状态
            

            Common.BindItemClass(drpQItemClass, this.FormListAID, true);
            BindTreeList();
        }

        /// <summary>
        /// 同步物料信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSameItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                string ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                ItemRule rule = new ItemRule();
                //rule.RSame(ItemCode);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        ///导出 按制单时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnDaoItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkMakeDate.Checked)
                {

                  
                    DataTable dt = (DataTable)gridView1.GridControl.DataSource;
                    string exportfile = string.Empty;
                    string strDate = txtQMakeDateS.DateTime.ToString("yyyy-MM-dd") + "至" + txtQMakeDateE.DateTime.ToString("yyyy-MM-dd");

                    TemplateExcel.ItemFileToExcel(dt, strDate, out exportfile);
                    this.OpenFileNoConfirm(exportfile);
                    FCommon.AddDBLog(this.Text, "导出报表", "", "");
                }
                else
                {
                    this.ShowMessage("请选择要制单日期！");
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
        private Item EntityGet()
        {
            Item entity = new Item();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        #region treelist事件
        /// <summary>
        /// treelist事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
              
                if (treeList1.FocusedNode != null)
                {

                    int ID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                    if (ID != this.FormListAID)
                    {
                        drpQItemClass.EditValue = SysConvert.ToInt32(ID);
                    }
                    else
                    {
                        drpQItemClass.EditValue = 0;
                    }

                    BindGrid();
                }





            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 绑定Grid数据
        /// </summary>
        private void BindTreeList()
        {
            treeList1.Nodes.Clear();
            DataTable dt = this.GetTreeListTable();
            ProcessTreeList.BindTreeList(dt, treeList1, "ID", "ParentID", 18, true);
        }

        /// <summary>
        /// 组装TreeList表
        /// </summary>
        /// <returns></returns>
        private DataTable GetTreeListTable()
        {
            string sql = "SELECT ID,Code,Name FROM Enum_ItemType ";
            sql += "WHERE ID=" + this.FormListAID.ToString();
            DataTable dtitemtype = SysUtils.Fill(sql);

            sql = "SELECT ID,Code,Name,ParentID,ItemTypeID FROM Data_ItemClass";
            sql += " WHERE ItemTypeID=" + SysString.ToDBString(FormListAID);
            DataTable dtitemclass = SysUtils.Fill(sql);
            for (int i = 0; i < dtitemclass.Rows.Count; i++)//将dtitemclass中ParentID为0的ID替换掉
            {
                if (dtitemclass.Rows[i]["ParentID"].ToString() == "0")
                {
                    dtitemclass.Rows[i]["ParentID"] = FormListAID;
                }
            }
            for (int i = 0; i < dtitemtype.Rows.Count; i++)
            {
                DataRow dr = dtitemclass.NewRow();
                dr["ID"] = dtitemtype.Rows[i]["ID"].ToString();
                dr["Code"] = dtitemtype.Rows[i]["Code"].ToString();
                dr["Name"] = dtitemtype.Rows[i]["Name"].ToString();
                dr["ParentID"] = "0";

                dtitemclass.Rows.Add(dr);
            }
            return dtitemclass;

        }

        /// <summary>
        /// 获得ItemClass字符串
        /// </summary>
        private void drpItemClass_EditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                //DataTable dt = SysUtils.Fill("exec USP1_Data_ItemClass_SubClass " + SysString.ToDBString(SaveItemClassID));
                DataTable dt = SysUtils.Fill("exec USP1_Data_ItemClass_SubClass " + SysString.ToDBString(SysConvert.ToString(drpQItemClass.EditValue)));
                if (dt.Rows.Count != 0)
                {
                    ItemClassArray = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQItemCode_EditValueChanged(object sender, EventArgs e)
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

    
    }
}