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
    /// 功能：产品管理
    /// 作者：章文强
    /// 日期：2012-04-18
    /// 操作：新增
    /// </summary>
    public partial class frmDevItem : frmAPBaseUIForm
    {
        public frmDevItem()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]

        private string ItemClassArray = string.Empty;

        /// <summary>
        /// 查询条件
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtVendorID.Text.Trim() != "")
            {
                tempStr += " AND VendorID LIKE "+SysString.ToDBString("%"+txtVendorID.Text.Trim()+"%");
            }

            if (txtMWeightS.Text.Trim() != "")
            {
                tempStr += " AND MWeight >="+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }

            if (txtMWeightE.Text.Trim() != "")
            {
                tempStr += " AND MWeight <="+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }

            if (txtMLDL.Text.Trim() != "")
            {
                tempStr += " AND MLDLCode LIKE "+SysString.ToDBString("%"+txtMLDL.Text.Trim()+"%");
            }

            if (txtMLLB.Text.Trim() != "")
            {
                tempStr += " AND MLLBCode LIKE "+SysString.ToDBString("%"+txtMLLB.Text.Trim()+"%");
            }

            if (txtItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE "+SysString.ToDBString("%"+txtItemStd.Text.Trim()+"%");
            }

            if (txtItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");
            }

            if (SysConvert.ToString(drpPFlag.EditValue) != "")
            {
                tempStr += " AND ISNULL(PFlag,0)="+SysString.ToDBString(SysConvert.ToInt32(drpPFlag.EditValue));
            }

            if (SysConvert.ToString(drpUseable.EditValue) != "")
            {
                tempStr += " AND ISNULL(UseableFlag,0)="+SysString.ToDBString(SysConvert.ToInt32(drpUseable.EditValue));
            }

            if (SysConvert.ToString(drpXFlag.EditValue) != "")
            {
                tempStr += " AND ISNULL(XFlag,0)="+SysString.ToDBString(SysConvert.ToInt32(drpXFlag.EditValue));
            }
           
            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE "+SysString.ToDBString("%"+txtItemModel.Text.Trim()+"%");
            }
            tempStr += " AND ISNULL(FabricTypeID,0) IN(0,1)";
            tempStr += " ORDER BY ID DESC";
            HTDataConditionStr = tempStr;
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = " AND ItemTypeID=" + SysString.ToDBString((int)EnumItemType.面料);
            if (ItemClassArray != "-1" && ItemClassArray!="")
            {
                sql += " AND ItemClassID IN(" + ItemClassArray + ")";
            }
            ItemRule rule = new ItemRule();
            gridView1.GridControl.DataSource = rule.RShow(sql+HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ItemRule rule = new ItemRule();
            Item entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Item";
            this.HTDataList = gridView1;
            this.HTQryContainer = groupControlQuery;
            ProcessTreeList.BindTreeColumn(treeList1, this.FormID);//绑定列				
            ProcessTreeList.SetTreeColumnUI(treeList1);//设置列UI
            IsPostBack = false;
            //btnQuery_Click(null, null);
            txtItemDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtItemDateE.DateTime = DateTime.Now.Date;
            Common.BindItemClass(drpQItemClass,(int)EnumItemType.面料, true);
        }

        /// <summary>
        /// 通用窗体加载方法，如果不要使用，则重写，一般不要修改
        /// </summary>
        public override void IniFormLoadBehind()
        {
            BindTreeList();
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

        #region 树形结构
        /// <summary>
        /// 绑定Grid数据
        /// </summary>
        private void BindTreeList()
        {
            treeList1.Nodes.Clear();
            DataTable dt = this.GetTreeListTable();
            ProcessTreeList.BindTreeList(dt, treeList1, "ID", "ParentID", 1, true);
        }

        /// <summary>
        /// 组装TreeList表
        /// </summary>
        /// <returns></returns>
        private DataTable GetTreeListTable()
        {
            string sql = "SELECT ID,Code,Name FROM Enum_ItemType ";
            sql += "WHERE ID=" +SysString.ToDBString((int)EnumItemType.面料);
            DataTable dtitemtype = SysUtils.Fill(sql);

            sql = "SELECT ID,Code,Name,ParentID,ItemTypeID FROM Data_ItemClass";
            sql += " WHERE ItemTypeID=" + SysString.ToDBString((int)EnumItemType.面料);
            DataTable dtitemclass = SysUtils.Fill(sql);
            for (int i = 0; i < dtitemclass.Rows.Count; i++)//将dtitemclass中ParentID为0的ID替换掉
            {
                if (dtitemclass.Rows[i]["ParentID"].ToString() == "0")
                {
                    dtitemclass.Rows[i]["ParentID"] = (int)EnumItemType.面料;
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

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {

                if (treeList1.FocusedNode != null)
                {

                    int ID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                    if (ID != (int)EnumItemType.面料)
                    {
                        drpQItemClass.EditValue = SysConvert.ToInt32(ID);
                     
                    }
                    else
                    {
                        drpQItemClass.EditValue = 0;
                    }
                    drpItemClass_EditValueChanged(null, null);
                    GetCondtion();
                    BindGrid();
                }





            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void txtItemCode_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnQuery_Click(null, null);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

    }
}