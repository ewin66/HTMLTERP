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
    public partial class frmLoadYarnItem : frmAPBaseLoad
    {
        public frmLoadYarnItem()
        {
            InitializeComponent();
        }

        #region 全局变量
        //private int SaveItemClassID = 0;
        private string ItemClassArray = string.Empty;
        public int ItemTypeID = (int)EnumItemType.纱线;
        public int[] IdDts;
        public string QryCon = "";
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
            if (QryCon != "")
            {
                tempStr += QryCon;
            }
            //if (chkMakeDate.Checked)
            //{
            //    tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            //}
            tempStr += " ORDER BY ItemCode,ItemName,ID";
           
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = " AND ItemTypeID=" + SysString.ToDBString((int)EnumItemType.纱线);
            if (ItemClassArray != "-1" && ItemClassArray!="")
            {
                sql += " AND ItemClassID IN(" + ItemClassArray + ")";
            }
            ItemRule rule = new ItemRule();
            gridView1.GridControl.DataSource = rule.RShowView(sql + HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace(",SelFlag",",0 SelFlag"));
            gridView1.GridControl.Show();
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
            //this.ToolBarItemAdd(28, "btnSameItem", "同步物料", false, btnSameItem_Click);
            //this.ToolBarItemAdd(29, "btnDaoItem", "导出", false, btnDaoItem_Click);

            //if (FormListAID == (int)EnumItemType.原料)
            //{
            //    gridColumnItemCode.Caption = "原料编码";
            //    gridColumnItemName.Caption = "原料名称";
            //    gridColumnItemStd.Caption = "原料规格";
            //    gridColumnItemModel.Caption = "原料品名";
            //    gridColumnItemClassName.Caption = "原料类型";
            //}
            //else if (FormListAID == (int)EnumItemType.纱线)
            //{
            //    gridColumnItemCode.Caption = "纱线编码";
            //    gridColumnItemName.Caption = "纱线成份";
            //    gridColumnItemStd.Caption = "纱线支数";
            //    gridColumnItemModel.Caption = "纱线品名";
            //    gridColumnItemClassName.Caption = "纱线类型";
            //}


            Common.BindItemClass(drpQItemClass, (int)EnumItemType.纱线, true);
            BindTreeList();
            btnQuery_Click(null, null);
        }
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelFlag" }, true);
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
                    if (ID != (int)EnumItemType.纱线)
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
            ProcessTreeList.BindTreeList(dt, treeList1, "ID", "ParentID", 7, true);
        }

        /// <summary>
        /// 组装TreeList表
        /// </summary>
        /// <returns></returns>
        private DataTable GetTreeListTable()
        {
            string sql = "SELECT ID,Code,Name FROM Enum_ItemType ";
            sql += "WHERE ID=" + (int)EnumItemType.纱线;
            DataTable dtitemtype = SysUtils.Fill(sql);

            sql = "SELECT ID,Code,Name,ParentID,ItemTypeID FROM Data_ItemClass";
            sql += " WHERE ItemTypeID=" + SysString.ToDBString((int)EnumItemType.纱线);
            DataTable dtitemclass = SysUtils.Fill(sql);
            for (int i = 0; i < dtitemclass.Rows.Count; i++)//将dtitemclass中ParentID为0的ID替换掉
            {
                if (dtitemclass.Rows[i]["ParentID"].ToString() == "0")
                {
                    dtitemclass.Rows[i]["ParentID"] = (int)EnumItemType.纱线;
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

        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();
            IdDts = GetStorgeArray();
            if (IdDts.Length == 0)
            {
                this.ShowMessage("没有选择任何数据");
                return;
            }
            else if (IdDts.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("选择加载的数据行数为：" + IdDts.Length.ToString() + Environment.NewLine + "超过100行，加载速度可能会很慢，确认加载吗？"))
                {
                    return;
                }
            }

            for (int i = 0; i < IdDts.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(IdDts[i]));
            }
        }
        /// <summary>
        /// 获取选择的ID数组
        /// </summary>
        /// <returns></returns>
        private int[] GetStorgeArray()
        {
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelFlag")) == 1)
                {
                    index++;
                }
            }
            int[] tempstorge = new int[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelFlag")) == 1)
                {
                    tempstorge[index] = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    index++;
                }
            }
            return tempstorge;
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (chkAll.Checked)
                    {
                        gridView1.SetRowCellValue(i, "SelFlag", 1);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "SelFlag", 0);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}