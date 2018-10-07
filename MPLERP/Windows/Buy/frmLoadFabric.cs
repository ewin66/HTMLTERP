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
    public partial class frmLoadFabric : frmAPBaseLoad
    {
        public frmLoadFabric()
        {
            InitializeComponent();
        }

        #region 全局变量
        private List<string> list = new List<string>();
        #endregion

        #region 属性

        /// <summary>
        /// 单选、多选模式
        /// </summary>
        private bool m_Double = true;
        public bool Double
        {
            get
            {
                return m_Double;
            }
            set
            {
                m_Double = value;
            }
        }

        /// <summary>
        /// 挂板ID
        /// </summary>
        private int[] m_GBID = new int[] { };
        public int[] GBID
        {
            get
            {
                return m_GBID;
            }
            set
            {
                m_GBID = value;
            }
        }

        private string ItemClassArray = string.Empty;

        /// <summary>
        /// 属性物品检索类型
        /// </summary>
        private int _HTItemTypeID = (int)EnumItemType.面料;

        /// <summary>
        /// 属性物品检索类型
        /// </summary>
        public int HTItemTypeID
        {
            get
            {
                return _HTItemTypeID;
            }
            set
            {
                _HTItemTypeID = value;
                _HTItemTypeIDA = new int[] { value };
            }
        }

        /// <summary>
        /// 属性物品检索类型数组
        /// </summary>
        private int[] _HTItemTypeIDA = new int[] { };

        /// <summary>
        /// 属性物品检索类型数组
        /// </summary>
        public int[] HTItemTypeIDA
        {
            get
            {
                if (_HTItemTypeIDA.Length == 0)
                {
                    _HTItemTypeIDA = new int[] { (int)EnumItemType.面料 };
                }
                return _HTItemTypeIDA;
            }
            set
            {
                _HTItemTypeIDA = value;
            }
        }


        /// <summary>
        /// 选择加载物品类型
        /// 0标志成品
        /// 1表示坯布+成品
        /// 2表示坯布
        /// </summary>
        private int m_SelectItemType = 0;
        public int SelectItemType
        {
            get
            {
                return m_SelectItemType;
            }
            set
            {
                m_SelectItemType = value;
            }
        }

        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
    
            if(txtItemCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }
            if(txtMWeightS.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND MWeight>"+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }

            if(txtMWeightE.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND MWeight<"+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }


            //if (txtMWidthS.Text.Trim() != string.Empty)
            //{
            //    tempStr += " AND MWidth>" + SysString.ToDBString(SysConvert.ToDecimal(txtMWidthS.Text.Trim()));
            //}

            //if (txtMWidthE.Text.Trim() != string.Empty)
            //{
            //    tempStr += " AND MWidth<" + SysString.ToDBString(SysConvert.ToDecimal(txtMWidthE.Text.Trim()));
            //}



            //if(txtMWidth.Text.Trim()!=string.Empty)
            //{
            //    tempStr+=" AND MWidth="+SysString.ToDBString(txtMWidth.Text.Trim());
            //}

            if(txtItemName.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ItemName LIKE "+SysString.ToDBString("%"+txtItemName.Text.Trim()+"%");
            }

            if (txtItemStd.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtItemStd.Text.Trim() + "%");
            }

            if (txtItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode Like " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }

            

            if (radioBtnFabric.Checked) //坯布
            {

                if (SysConvert.ToString(drpFactoryID.EditValue) != "")//供应商信息 
                {
                    tempStr += " AND ID in(select MainID from Data_ItemCodeFacDts where FactoryID = " + SysString.ToDBString(SysConvert.ToString(drpFactoryID.EditValue)) + ")";

                    //ItemCodeFacDts
                }
            }
            else if (radioBtnML.Checked)//成品
            {
                if (SysConvert.ToString(drpFactoryID.EditValue) != "")//供应商信息 
                {
                    tempStr += " AND GreyFabItemCode in(select ItemCode from Data_Item where ID in(select MainID from Data_ItemCodeFacDts where FactoryID = " + SysString.ToDBString(SysConvert.ToString(drpFactoryID.EditValue)) + "))";
                    //tempStr += " AND ID in(select MainID from Data_ItemCodeFacDts where FactoryID = " + SysString.ToDBString() + ")";

                    //ItemCodeFacDts
                }
            }


            if (checkBox1.Checked)//查看已选
            {
                if (GetListStr() != "" && GetListStr() != string.Empty)
                {
                    tempStr += " AND ID in (" + GetListStr() + ")";
                }
                else
                {
                    tempStr += " AND 1=0 ";
                }
            }


            tempStr += " ORDER BY ItemCode";
          
          
            HTDataConditionStr = tempStr;
        }

        private string GetListStr()
        {
            string str = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                if (str != string.Empty && SysConvert.ToString(list[i]) != "" && SysConvert.ToString(list[i]) != "0")
                {
                    str += ",";
                }
                if (SysConvert.ToString(list[i]) != "" && SysConvert.ToString(list[i]) != "0")
                {
                    str += SysConvert.ToString(list[i]);
                }
            }
            return str;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = string.Empty;// " AND ItemTypeID=" + SysString.ToDBString((int)EnumItemType.面料);

            string itemtypestr = "0";
            for (int i = 0; i < HTItemTypeIDA.Length; i++)
            {
                itemtypestr += ",";
                itemtypestr += HTItemTypeIDA[i];
            }
            sql = " AND ItemTypeID IN(" + itemtypestr + ")";

            if (ItemClassArray != "-1" && ItemClassArray != "")
            {
                sql += " AND ItemClassID IN(" + ItemClassArray + ")";
            }
            ItemRule rule = new ItemRule();

            DataTable dt = rule.RShow(sql + HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (list.Contains(SysConvert.ToString(dt.Rows[i]["ID"])))
                {
                    dt.Rows[i]["SelectFlag"] = 1;
                }
            }
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();


        }

        /// <summary>
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);


            if (m_Double) //多选
            {
                gridColumn19.Visible = true;
            }
            else
            {
                gridColumn19.Visible = false;
            }

           
        }
        
         /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }

        public override void IniRefreshData()
        {
            //base.IniRefreshData();
            txtItemModel.Focus();
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Item";
            this.HTDataList = gridView1;
            
            Common.BindItemClass(drpQItemClass, HTItemTypeIDA, true);
            BindTreeList();


            Common.BindVendor(drpFactoryID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.供应商, (int)EnumVendorType.织厂 }, true);
            new VendorProc(drpFactoryID);



            if (m_SelectItemType == 0)   //0：表示只支持加载产品  1：表示只支持选择加载产品或者坯布
            {
                radioBtnML.Visible = true;
               radioBtnFabric.Visible = false;

                radioBtnML.Checked = true; 
            }
            else if (m_SelectItemType==1)   //0：表示只支持加载产品  1：表示只支持选择加载产品或者坯布
            {
              //  radioBtnML.Visible = true;
             //   radioBtnFabric.Visible = true;
             //   radioBtnML.Checked = true; 
            }
            else if (m_SelectItemType == 2) //坯布
            {
                radioBtnML.Visible = false;
                radioBtnFabric.Visible = true;
                radioBtnFabric.Checked = true; 
             }


             if (m_Double) //多选
             {
                 gridColumn19.Visible = true;
             }
             else
             {
                 gridColumn19.Visible = false;
             }

             btnQuery_Click(null, null);
             this.ActiveControl = this.txtItemModel;
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


        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
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
        #endregion

        #region 加载挂板信息

        /// <summary>
        /// 获取选择的ID数组
        /// </summary>
        /// <returns></returns>
        private int[] GetStorgeArray()
        {
            if (m_Double)
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
            else //单选取聚焦行的数据
            {
                int[] tempstorge = new int[1];

                tempstorge[0] = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));

                return tempstorge;
            }

        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();

            m_GBID = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                m_GBID[i] =SysConvert.ToInt32( list[i]);
            }

                //m_GBID = GetStorgeArray();
            if (m_GBID.Length == 0)
            {
                this.ShowMessage("没有选择任何数据");
                return;
            }
            else if (m_GBID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("选择加载的数据行数为：" + m_GBID.Length.ToString() + Environment.NewLine + "超过100行，加载速度可能会很慢，确认加载吗？"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_GBID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_GBID[i]));
            }
        }

        #endregion

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
            sql += "WHERE ID=" + SysString.ToDBString(HTItemTypeID);//(int)EnumItemType.面料
            DataTable dtitemtype = SysUtils.Fill(sql);

            sql = "SELECT ID,Code,Name,ParentID,ItemTypeID FROM Data_ItemClass";
            sql += " WHERE ItemTypeID=" + SysString.ToDBString(HTItemTypeID);
            DataTable dtitemclass = SysUtils.Fill(sql);
            for (int i = 0; i < dtitemclass.Rows.Count; i++)//将dtitemclass中ParentID为0的ID替换掉
            {
                if (dtitemclass.Rows[i]["ParentID"].ToString() == "0")
                {
                    dtitemclass.Rows[i]["ParentID"] = HTItemTypeID;
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
                    if (ID != HTItemTypeID)
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


        /// <summary>
        /// 选择模式改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnML_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnFabric.Checked) //坯布
            {
              
                radioBtnML.Checked = false;
             

           
                //groupControl3.Visible = true;
                //gridControlDetail.Visible = false;


                _HTItemTypeID = (int)EnumItemType.坯布;
                _HTItemTypeIDA = new int[] { (int)EnumItemType.坯布 };
        
                BindTreeList();
            }
            
            else if (radioBtnML.Checked)//成品
            {
  
                radioBtnFabric.Checked = false;


                //groupControl3.Visible = false;
                //gridControlDetail.Visible = true;

                _HTItemTypeID = (int)EnumItemType.面料;

                _HTItemTypeIDA = new int[] { (int)EnumItemType.面料 };

                   
                BindTreeList();
            }
           
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnQuery_Click(null,null);
                    txtItemModel.Text = "";
                }
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 勾选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseFocusLabel.Focus();

                string ID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                if (1 == SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag")))
                {
                    if (!list.Contains(ID))
                    {
                        list.Add(ID);
                    }
                }
                else
                {
                    list.Remove(ID);
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

      


    }
}