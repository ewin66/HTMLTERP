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
    /// ���ܣ���Ʒ����
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-18
    /// ����������
    /// </summary>
    public partial class frmDevItemFinish : frmAPBaseUIForm
    {
        public frmDevItemFinish()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]

        private string ItemClassArray = string.Empty;

        /// <summary>
        /// ��ѯ����
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
                tempStr += " AND MWeight="+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }

            if (txtMWeightE.Text.Trim() != "")
            {
                tempStr += " AND MWeight <="+SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }

            if (txtPrice.Text.Trim() != "")
            {
                tempStr += " AND SalePrice="+SysString.ToDBString(SysConvert.ToDecimal(txtPrice.Text.Trim()));
            }

            if (txtMLDL.Text.Trim() != "")
            {
                tempStr += " AND MLDLCode LIKE "+SysString.ToDBString("%"+txtMLDL.Text.Trim()+"%");
            }

            if (txtMLLB.Text.Trim() != "")
            {
                tempStr += " AND MLLBCode LIKE "+SysString.ToDBString("%"+txtMLLB.Text.Trim()+"%");
            }

            if (txtItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");

                ///20140911 zhoufc ע�͵� 
                //tempStr += " AND ID IN(SELECT MainID FROM Data_ItemDts WHERE DtsItemName LIKE "+SysString.ToDBString("%"+txtItemName.Text.Trim()+"%");
                //if (txtPercentageS.Text.Trim() != "")
                //{
                //    tempStr += " AND Percentage>="+SysString.ToDBString(SysConvert.ToDecimal(txtPercentageS.Text.Trim()));
                //}
                //if (txtPercentageE.Text.Trim() != "")
                //{
                //    tempStr += " AND Percentage<=" + SysString.ToDBString(SysConvert.ToDecimal(txtPercentageE.Text.Trim()));
                //}
                //tempStr += ")";
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

            if (txtSeason.Text.Trim() != "")
            {
                tempStr += " AND Season LIKE "+SysString.ToDBString("%"+txtSeason.Text.Trim()+"%");
            }

            tempStr += " AND ISNULL(FabricTypeID,0) IN(0,1)";
            tempStr += " ORDER BY ID DESC";
            HTDataConditionStr = tempStr;
        }


       

        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = " AND ItemTypeID=" + SysString.ToDBString((int)EnumItemType.����);
            if (ItemClassArray != "-1" && ItemClassArray!="")
            {
                sql += " AND ItemClassID IN(" + ItemClassArray + ")";
            }
            ItemRule rule = new ItemRule();
            gridView1.GridControl.DataSource = rule.RShow(sql + HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ItemRule rule = new ItemRule();
            Item entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Item";
            this.HTDataList = gridView1;
            this.HTQryContainer = groupControlQuery;
            ProcessTreeList.BindTreeColumn(treeList1, this.FormID);//����				
            ProcessTreeList.SetTreeColumnUI(treeList1);//������UI
            IsPostBack = false;
            //btnQuery_Click(null, null);
            txtItemDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtItemDateE.DateTime = DateTime.Now.Date;
            Common.BindItemClass(drpQItemClass,(int)EnumItemType.����, true);
            Common.BindItemClass(drpItemClassID, new int[] { (int)EnumItemType.���� }, true);
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
        }

        /// <summary>
        /// ͨ�ô�����ط����������Ҫʹ�ã�����д��һ�㲻Ҫ�޸�
        /// </summary>
        public override void IniFormLoadBehind()
        {
            BindTreeList();
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
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

        #region ���νṹ
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
            sql += "WHERE ID=" +SysString.ToDBString((int)EnumItemType.����);
            DataTable dtitemtype = SysUtils.Fill(sql);

            sql = "SELECT ID,Code,Name,ParentID,ItemTypeID FROM Data_ItemClass";
            sql += " WHERE ItemTypeID=" + SysString.ToDBString((int)EnumItemType.����);
            DataTable dtitemclass = SysUtils.Fill(sql);
            for (int i = 0; i < dtitemclass.Rows.Count; i++)//��dtitemclass��ParentIDΪ0��ID�滻��
            {
                if (dtitemclass.Rows[i]["ParentID"].ToString() == "0")
                {
                    dtitemclass.Rows[i]["ParentID"] = (int)EnumItemType.����;
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

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {

                if (treeList1.FocusedNode != null)
                {

                    int ID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                    if (ID != (int)EnumItemType.����)
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

        #region �����ӡ

        /// <summary>
        /// ��ӡ��������
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            string GBIDStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    if (GBIDStr != "")
                    {
                        GBIDStr += ",";
                    }
                    GBIDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                }
            }

            if (GBIDStr == "")
            {
                this.ShowMessage("�빴ѡ��Ҫ��ӡ�ĹҰ�����");
                return false;
            }


            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 1)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }
            string sql = "SELECT * FROM Data_Item WHERE ID IN ("+GBIDStr+")";
            DataTable dtSource = SysUtils.Fill(sql);

            dtSource.Columns.Add(new DataColumn("ERCode", typeof(Image)));
            //dtSource.Columns.Add(new DataColumn("ERCode2", typeof(Image)));
            foreach (DataRow dr in dtSource.Rows)
            {
                string EWM1 = SysConvert.ToString(dr["ItemCode"]);
                string MSG = "";
                dr["ERCode"] = HTERCode.HTERBarcode.Create(EWM1, 2, 0, "", out MSG);
            }

             FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dtSource);

            return true;
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
               

                btnPrintAbount((int)ReportPrintType.Ԥ��);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        
        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
              
                btnPrintAbount((int)ReportPrintType.��ӡ);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
               
                btnPrintAbount((int)ReportPrintType.���);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
       

    }
}