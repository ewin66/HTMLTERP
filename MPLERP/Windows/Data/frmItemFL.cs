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
    /// ��Ʒ����
    /// </summary>
    public partial class frmItemFL : frmAPBaseUISin
    {
        public frmItemFL()
        {
            InitializeComponent();
        }

        #region ȫ�ֱ���
        //private int SaveItemClassID = 0;
        private string ItemClassArray = string.Empty;
        #endregion

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtQItemCode.Text.Trim() != "")//��ѯ
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemName.Text.Trim() != "")//��ѯ
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
        /// ��Grid
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
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ItemRule rule = new ItemRule();
            Item entity = EntityGet();
            entity.SelectByID();
         
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Item";
            this.HTDataList = gridView1;

            txtQMakeDateE.DateTime = DateTime.Now.Date;
            txtQMakeDateS.DateTime = DateTime.Now.Date.AddDays(0 - ParamConfig.QueryDayNum);

            ProcessTreeList.BindTreeColumn(treeList1, this.FormID);//����				
            ProcessTreeList.SetTreeColumnUI(treeList1);//������UI

            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//������UI
            ProcessGrid.SetGridEdit(gridView1, new string[] { "ItemName","ItemCode","ItemStd"}, true);//��ʱ���䴦�ڿɱ༭״̬
            

            Common.BindItemClass(drpQItemClass, this.FormListAID, true);
            BindTreeList();
        }

        /// <summary>
        /// ͬ��������Ϣ
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
        ///���� ���Ƶ�ʱ��
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
                    string strDate = txtQMakeDateS.DateTime.ToString("yyyy-MM-dd") + "��" + txtQMakeDateE.DateTime.ToString("yyyy-MM-dd");

                    TemplateExcel.ItemFileToExcel(dt, strDate, out exportfile);
                    this.OpenFileNoConfirm(exportfile);
                    FCommon.AddDBLog(this.Text, "��������", "", "");
                }
                else
                {
                    this.ShowMessage("��ѡ��Ҫ�Ƶ����ڣ�");
                }

                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Item EntityGet()
        {
            Item entity = new Item();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        #region treelist�¼�
        /// <summary>
        /// treelist�¼�
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
        /// ��Grid����
        /// </summary>
        private void BindTreeList()
        {
            treeList1.Nodes.Clear();
            DataTable dt = this.GetTreeListTable();
            ProcessTreeList.BindTreeList(dt, treeList1, "ID", "ParentID", 18, true);
        }

        /// <summary>
        /// ��װTreeList��
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
            for (int i = 0; i < dtitemclass.Rows.Count; i++)//��dtitemclass��ParentIDΪ0��ID�滻��
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
        /// ���ItemClass�ַ���
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
        /// ���ٲ�ѯ
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