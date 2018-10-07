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
    /// ���ܣ���Ʒ����ģʽ��
    ///    �������
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-06-21
    /// ����������
    /// </summary>
    public partial class frmDevItemMode2nd : frmAPBaseUIForm
    {
        public frmDevItemMode2nd()
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

            if (txtItemName.Text.Trim() != "")
            {
                tempStr += " AND ID IN(SELECT MainID FROM Data_ItemDts WHERE DtsItemName LIKE "+SysString.ToDBString("%"+txtItemName.Text.Trim()+"%");
                if (txtPercentageS.Text.Trim() != "")
                {
                    tempStr += " AND Percentage>="+SysString.ToDBString(SysConvert.ToDecimal(txtPercentageS.Text.Trim()));
                }
                if (txtPercentageE.Text.Trim() != "")
                {
                    tempStr += " AND Percentage<=" + SysString.ToDBString(SysConvert.ToDecimal(txtPercentageE.Text.Trim()));
                }
                tempStr += ")";
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
            //tempStr += " ORDER BY ItemCode DESC";
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
            DataTable dt = rule.RShow(sql + HTDataConditionStr+" ORDER BY ItemCode DESC", ProcessGrid.GetQueryField(gridView1).Replace(",GBPic2", ""));//GBPic2 ���µ���������;
            BindProcPicture(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// �󶨴���ͼƬ
        /// </summary>
        private void BindProcPicture(DataTable dtSource)
        {
            string sqlConditionStr = " AND ItemTypeID=" + SysString.ToDBString((int)EnumItemType.����);
            if (ItemClassArray != "-1" && ItemClassArray!="")
            {
                sqlConditionStr += " AND ItemClassID IN(" + ItemClassArray + ")";
            }

            string sql = string.Empty;

            sql = "SELECT MainID,GBPic2 FROM Data_ItemGB WHERE MainID IN(SELECT ID FROM Data_Item WHERE 1=1" + sqlConditionStr + HTDataConditionStr + ") ORDER BY MainID";
            DataTable dtImg = SysUtils.Fill(sql);

            DataColumn dc = new DataColumn("GBPic2", typeof(byte[]));
            dtSource.Columns.Add(dc);

            int preMainID = 0;
            foreach (DataRow drImg in dtImg.Rows)
            {
                if (preMainID != SysConvert.ToInt32(drImg["MainID"]))
                {
                    DataRow[] drSourceA = dtSource.Select("ID=" + drImg["MainID"].ToString());
                    if (drSourceA.Length != 0)
                    {
                        drSourceA[0]["GBPic2"] = drImg["GBPic2"];
                    }
                }
                preMainID = SysConvert.ToInt32(drImg["MainID"]);
            }

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
        }

        /// <summary>
        /// ͨ�ô�����ط����������Ҫʹ�ã�����д��һ�㲻Ҫ�޸�
        /// </summary>
        public override void IniFormLoadBehind()
        {
            BindTreeList();
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

       

    }
}