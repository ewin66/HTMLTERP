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
    /// 加载库存
    /// </summary>
    public partial class frmLoadYarnStorge : frmAPBaseLoad
    {
        public frmLoadYarnStorge()
        {
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// 库存ID
        /// </summary>
        private int[] m_StorgeID;
        public int[] StorgeID
        {
            get
            {
                return m_StorgeID;
            }
            set
            {
                m_StorgeID = value;
            }
        }
        /// <summary>
        /// 公司别
        /// </summary>
        private int m_CompanyTypeID;
        public int CompanyTypeID
        {
            get
            {
                return m_CompanyTypeID;
            }
            set
            {
                m_CompanyTypeID = value;
            }
        }
        /// <summary>
        /// 仓库类型
        /// </summary>
        private int m_WHTypeID=1;   //默认是纱线仓库
        public int WHTypeID
        {
            get
            {
                return m_WHTypeID;
            }
            set
            {
                m_WHTypeID = value;
            }
        }

        /// <summary>
        /// 是否包含寄库
        /// </summary>
        private bool m_IncludeJK;
        public bool IncludeJK
        {
            get
            {
                return m_IncludeJK;
            }
            set
            {
                m_IncludeJK = value;
            }
        }
        /// <summary>
        /// 原料编号
        /// </summary>
        private string m_ItemCode;
        public string ItemCode
        {
            get { return m_ItemCode; }
            set { m_ItemCode = value; }
        }

        /// <summary>
        /// 仓库编号
        /// </summary>
        private string m_WHID;
        public string WHID
        {
            get { return m_WHID; }
            set { m_WHID = value; }
        }

        /// <summary>
        /// 仓库编号
        /// </summary>
        private int m_ItemType;
        public int ItemType
        {
            get { return m_ItemType; }
            set { m_ItemType = value; }
        }

        public string ItemClassArray = string.Empty;
        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            if (txtItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE "+SysString.ToDBString("%"+txtItemName.Text.Trim()+"%");
            }
            if (txtMWeightS.Text.Trim() != "")
            {
                tempStr += " AND MWeight >"+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }

            if (txtMWeightE.Text.Trim() != "")
            {
                tempStr += " AND MWeight <"+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }
            if (!Common.CheckLookUpEditBlank(drpMLType))
            {
                tempStr += " AND MLType=" +SysConvert.ToInt32(drpMLType.EditValue).ToString();
            }
            if (m_WHTypeID != 0)
            {
                tempStr += " AND WHTypeID=" + m_WHTypeID.ToString();
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = " AND ItemTypeID=" + SysString.ToDBString(m_ItemType);
            if (ItemClassArray != "-1" && ItemClassArray != "")
            {
                sql += " AND ItemClassID IN(" + ItemClassArray + ")";
            }

            StorgeRule rule = new StorgeRule();
            gridView1.GridControl.DataSource = rule.RShow(sql+HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.Show();


        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_Storge";
            this.HTDataList = gridView1;
            Common.BindWHByWHType(drpQWHID,m_WHTypeID, true);
           // Common.BindMLType(drpMLType, true);
           // Common.BindMLType(drpResMLType, true);
            drpQWHID.EditValue = WHID;
            drpQWHID_EditValueChanged(null, null);
            HTDataList.OptionsBehavior.ShowEditorOnMouseUp = false;
            Common.BindItemClass(drpQItemClass, m_ItemType, true);
            BindTreeList();
        }

        /// <summary>
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }

        #endregion
          
        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Storge EntityGet()
        {
            Storge entity = new Storge();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        #region 加载库存
        /// <summary>
        /// 取得库存数组
        /// </summary>
        /// <returns></returns>
        private int[] GetStorgeArray()
        {
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    index++;
                }
            }
            int[] tempstorge = new int[index];
            //IsSelected = true;
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    tempstorge[index] = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    index++;
                }
            }
            return tempstorge;
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();

            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
            //    {
            //        if (i != 0 && SysConvert.ToInt32(gridView1.GetRowCellValue(i, "CompanyTypeID")) != SysConvert.ToInt32(gridView1.GetRowCellValue(i - 1, "CompanyTypeID")))
            //        {
            //            this.ShowMessage("有明细单据不属于统一公司的");
            //            return;
            //        }
            //    }
            //}

            m_StorgeID = GetStorgeArray();
            if (m_StorgeID.Length == 0)
            {
                this.ShowMessage("没有选择任何数据");
                return;
            }
            else if (m_StorgeID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("选择加载的数据行数为：" + m_StorgeID.Length.ToString() + Environment.NewLine + "超过100行，加载速度可能会很慢，确认加载吗？"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_StorgeID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_StorgeID[i]));
            }
        }


        #endregion

        #region   其他事件
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpQWHID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetCondtion();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (chkAll.Checked)
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 1);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 0);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
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
            ProcessTreeList.BindTreeList(dt, treeList1, "ID", "ParentID", 18, true);
        }

        /// <summary>
        /// 组装TreeList表
        /// </summary>
        /// <returns></returns>
        private DataTable GetTreeListTable()
        {
            string sql = "SELECT ID,Code,Name FROM Enum_ItemType ";
            sql += "WHERE ID=" + SysString.ToDBString(m_ItemType);
            DataTable dtitemtype = SysUtils.Fill(sql);

            sql = "SELECT ID,Code,Name,ParentID,ItemTypeID FROM Data_ItemClass";
            sql += " WHERE ItemTypeID=" + SysString.ToDBString(m_ItemType);
            DataTable dtitemclass = SysUtils.Fill(sql);
            for (int i = 0; i < dtitemclass.Rows.Count; i++)//将dtitemclass中ParentID为0的ID替换掉
            {
                if (dtitemclass.Rows[i]["ParentID"].ToString() == "0")
                {
                    dtitemclass.Rows[i]["ParentID"] = m_ItemType;
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
                    if (ID != m_ItemType)
                    {
                        drpQItemClass.EditValue = SysConvert.ToInt32(ID);

                    }
                    else
                    {
                        drpQItemClass.EditValue = 0;
                    }
                    drpItemClass_EditValueChanged(null, null);

                    BindGrid();
                }





            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        


    }
}