using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.FrameFunc;
using HttSoft.Framework;

namespace MLTERP
{

    /// <summary>
    /// 功能：加载纱线
    /// 作者：陈中品
    /// 日期：2007.7.16
    /// </summary>
    public partial class frmLoadItem : BaseForm
    {
        public frmLoadItem()
        {
            InitializeComponent();
        }

        #region 属性
        private int[] m_ItemTypeThis = new int[0];//物品类型
        public int[] ItemTypeThis
        {
            get
            {
                return m_ItemTypeThis;
            }
            set
            {
                m_ItemTypeThis = value;
            }
        }
        private string m_ItemCode = string.Empty;//纱线编码
        public string ItemCode
        {
            get
            {
                return m_ItemCode;
            }
        }
        private string m_ItemName = string.Empty;//纱线成份
        public string ItemName
        {
            get
            {
                return m_ItemName;
            }
        }
        private string m_ItemStd = string.Empty;//纱线支数
        public string ItemStd
        {
            get
            {
                return m_ItemStd;
            }
        }

        private string m_ItemAttnCode = string.Empty;//辅助编码
        public string ItemAttnCode
        {
            get
            {
                return m_ItemAttnCode;
            }
        }


        private string m_ItemModel = string.Empty;//品种
        public string ItemModel
        {
            get
            {
                return m_ItemModel;
            }
        }


        private string m_ItemUnit = string.Empty;//纱线单位
        public string ItemUnit
        {
            get
            {
                return m_ItemUnit;
            }
        }
        private decimal m_ItemPrice = 0;//纱线价格
        public decimal ItemPrice
        {
            get
            {
                return m_ItemPrice;
            }
        }
        private bool m_SelectFlag = false;//选择标志
        public bool SelectFlag
        {
            get
            {
                return m_SelectFlag;
            }
        }
        #endregion

        #region 全局变量
        int SaveItemClassID = 0;
        int SaveItemTypeID = 0;


        string conditionstr = string.Empty;
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得查询条件
        /// </summary>
        private void GetCondition()
        {
            string sql = string.Empty;
            if (txtQItemCode.Text.Trim() != string.Empty)
            {
                sql += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemName.Text.Trim() != string.Empty)
            {
                sql += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != string.Empty)
            {
                sql += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }
            if (txtQItemAttnCode.Text.Trim() != string.Empty)
            {
                sql += " AND ItemAttnCode LIKE " + SysString.ToDBString("%" + txtQItemAttnCode.Text.Trim() + "%");
            }
            if (txtQItemModel.Text.Trim() != string.Empty)
            {
                sql += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }
            //sql += " AND ISnull(DelFlag, 0)=0";
            if (m_ItemTypeThis.Length > 0)
            {
                sql += " AND ItemTypeID IN (" + Common.ConvertArrayIntToStr(m_ItemTypeThis) + ")";
            }
            conditionstr = sql;
        }



        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindGrid()
        {
            string selfcon = "";
            if (SaveItemTypeID != 0)
            {
                selfcon = " AND ItemTypeID=" + SysString.ToDBString(SaveItemTypeID);
            }
            if (SaveItemClassID != 0)
            {
                selfcon += " AND ItemClassID=" + SysString.ToDBString(SaveItemClassID);
            }
            ItemRule rule = new ItemRule();
            gridView1.GridControl.DataSource = rule.RShowView(selfcon + conditionstr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
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
            string sql = "SELECT ID,Code,Name FROM Enum_ItemType WHERE 1=1";
            if (m_ItemTypeThis.Length>0)
            {
                sql += " AND ID IN("+Common.ConvertArrayIntToStr(m_ItemTypeThis)+")";
            }

            DataTable dtitemtype = SysUtils.Fill(sql);
            //for (int i = 0; i < dtitemtype.Rows.Count; i++)//将dtitemtype表的ID替换掉
            //{
            //    dtitemtype.Rows[i]["ID"] = "800000" + dtitemtype.Rows[i]["ID"].ToString();
            //}

            sql = "SELECT ID,Code,Name,ParentID,ItemTypeID FROM Data_ItemClass WHERE 1=1";
            if (m_ItemTypeThis.Length > 0)
            {
                sql += " AND ItemTypeID IN(" + Common.ConvertArrayIntToStr(m_ItemTypeThis) + ")";
            }
        
            DataTable dtitemclass = SysUtils.Fill(sql);

            for (int i = 0; i < dtitemclass.Rows.Count; i++)//将dtitemclass中ParentID为0的ID替换掉
            {

                if (dtitemclass.Rows[i]["ParentID"].ToString() == "0")
                {
                    dtitemclass.Rows[i]["ParentID"] = (int)EnumItemType.纱线;
                }
                //if (dtitemclass.Rows[i]["ParentID"].ToString() == "0")
                //{
                //    for (int j = 0; j < dtitemtype.Rows.Count; j++)
                //    {
                //        if ("800000" + dtitemclass.Rows[i]["ItemTypeID"].ToString() == dtitemtype.Rows[j]["ID"].ToString())
                //        {
                //            dtitemclass.Rows[i]["ParentID"] = dtitemtype.Rows[j]["ID"];
                //        }
                //    }
                //}
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
        #endregion

        #region Form事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        private void frmLoadItem_Load(object sender, System.EventArgs e)
        {
            try
            {
                ProcessTreeList.BindTreeColumn(treeList1, this.FormID);//绑定列				
                ProcessTreeList.SetTreeColumnUI(treeList1);//设置列UI

                ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI
 
                BindTreeList();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 窗口关闭
        /// </summary>
        private void frmLoadItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);

            }
        }
        #endregion

        #region treeList事件
        /// <summary>
        /// 焦点改变
        /// </summary>
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (treeList1.FocusedNode != null)
                {
                    int ID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                    if (ID != (int)EnumItemType.纱线 && ID != (int)EnumItemType.辅料)
                    {
                        SaveItemClassID = SysConvert.ToInt32(ID);
                        SaveItemTypeID = 0;
                    }
                    else
                    {
                        SaveItemTypeID = SysConvert.ToInt32(ID);
                        SaveItemClassID = 0;
                    }

                    

                    BindGrid();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        private void gridControlDetail_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                m_SelectFlag = true;
                m_ItemCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemCode"));
                m_ItemName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemName"));
                m_ItemStd = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemStd"));
                m_ItemUnit = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemUnit"));
                m_ItemAttnCode = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemAttnCode"));
                m_ItemModel = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemModel"));
                m_ItemPrice = SysConvert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BuyUnitPrice"));
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void drpQ_EditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.GetCondition();
                this.BindGrid();
                //GridViewFocus(gridView1,new string[3]{"ItemCode","ItemName","ItemStd"},new string[3]{txtQItemCode.Text,txtQItemName.Text,txtQItemStd.Text});
                ((Control)sender).Focus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void groupControlQuery_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e != null)
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }

    }
}