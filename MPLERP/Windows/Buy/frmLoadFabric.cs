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

        #region ȫ�ֱ���
        private List<string> list = new List<string>();
        #endregion

        #region ����

        /// <summary>
        /// ��ѡ����ѡģʽ
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
        /// �Ұ�ID
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
        /// ������Ʒ��������
        /// </summary>
        private int _HTItemTypeID = (int)EnumItemType.����;

        /// <summary>
        /// ������Ʒ��������
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
        /// ������Ʒ������������
        /// </summary>
        private int[] _HTItemTypeIDA = new int[] { };

        /// <summary>
        /// ������Ʒ������������
        /// </summary>
        public int[] HTItemTypeIDA
        {
            get
            {
                if (_HTItemTypeIDA.Length == 0)
                {
                    _HTItemTypeIDA = new int[] { (int)EnumItemType.���� };
                }
                return _HTItemTypeIDA;
            }
            set
            {
                _HTItemTypeIDA = value;
            }
        }


        /// <summary>
        /// ѡ�������Ʒ����
        /// 0��־��Ʒ
        /// 1��ʾ����+��Ʒ
        /// 2��ʾ����
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

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
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

            

            if (radioBtnFabric.Checked) //����
            {

                if (SysConvert.ToString(drpFactoryID.EditValue) != "")//��Ӧ����Ϣ 
                {
                    tempStr += " AND ID in(select MainID from Data_ItemCodeFacDts where FactoryID = " + SysString.ToDBString(SysConvert.ToString(drpFactoryID.EditValue)) + ")";

                    //ItemCodeFacDts
                }
            }
            else if (radioBtnML.Checked)//��Ʒ
            {
                if (SysConvert.ToString(drpFactoryID.EditValue) != "")//��Ӧ����Ϣ 
                {
                    tempStr += " AND GreyFabItemCode in(select ItemCode from Data_Item where ID in(select MainID from Data_ItemCodeFacDts where FactoryID = " + SysString.ToDBString(SysConvert.ToString(drpFactoryID.EditValue)) + "))";
                    //tempStr += " AND ID in(select MainID from Data_ItemCodeFacDts where FactoryID = " + SysString.ToDBString() + ")";

                    //ItemCodeFacDts
                }
            }


            if (checkBox1.Checked)//�鿴��ѡ
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
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = string.Empty;// " AND ItemTypeID=" + SysString.ToDBString((int)EnumItemType.����);

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
        /// ��д��ʼ��֮��ķ���
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);


            if (m_Double) //��ѡ
            {
                gridColumn19.Visible = true;
            }
            else
            {
                gridColumn19.Visible = false;
            }

           
        }
        
         /// <summary>
        /// ���ö�λ���ݼ�״̬
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
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Item";
            this.HTDataList = gridView1;
            
            Common.BindItemClass(drpQItemClass, HTItemTypeIDA, true);
            BindTreeList();


            Common.BindVendor(drpFactoryID, new int[] { (int)EnumVendorType.����, (int)EnumVendorType.��Ӧ��, (int)EnumVendorType.֯�� }, true);
            new VendorProc(drpFactoryID);



            if (m_SelectItemType == 0)   //0����ʾֻ֧�ּ��ز�Ʒ  1����ʾֻ֧��ѡ����ز�Ʒ��������
            {
                radioBtnML.Visible = true;
               radioBtnFabric.Visible = false;

                radioBtnML.Checked = true; 
            }
            else if (m_SelectItemType==1)   //0����ʾֻ֧�ּ��ز�Ʒ  1����ʾֻ֧��ѡ����ز�Ʒ��������
            {
              //  radioBtnML.Visible = true;
             //   radioBtnFabric.Visible = true;
             //   radioBtnML.Checked = true; 
            }
            else if (m_SelectItemType == 2) //����
            {
                radioBtnML.Visible = false;
                radioBtnFabric.Visible = true;
                radioBtnFabric.Checked = true; 
             }


             if (m_Double) //��ѡ
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


        /// <summary>
        /// ���ٲ�ѯ
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

        #region ���عҰ���Ϣ

        /// <summary>
        /// ��ȡѡ���ID����
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
            else //��ѡȡ�۽��е�����
            {
                int[] tempstorge = new int[1];

                tempstorge[0] = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));

                return tempstorge;
            }

        }

        /// <summary>
        /// ��������
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
                this.ShowMessage("û��ѡ���κ�����");
                return;
            }
            else if (m_GBID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("ѡ����ص���������Ϊ��" + m_GBID.Length.ToString() + Environment.NewLine + "����100�У������ٶȿ��ܻ������ȷ�ϼ�����"))
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
        /// ȫѡ
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
            sql += "WHERE ID=" + SysString.ToDBString(HTItemTypeID);//(int)EnumItemType.����
            DataTable dtitemtype = SysUtils.Fill(sql);

            sql = "SELECT ID,Code,Name,ParentID,ItemTypeID FROM Data_ItemClass";
            sql += " WHERE ItemTypeID=" + SysString.ToDBString(HTItemTypeID);
            DataTable dtitemclass = SysUtils.Fill(sql);
            for (int i = 0; i < dtitemclass.Rows.Count; i++)//��dtitemclass��ParentIDΪ0��ID�滻��
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
        /// ѡ��ģʽ�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnML_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnFabric.Checked) //����
            {
              
                radioBtnML.Checked = false;
             

           
                //groupControl3.Visible = true;
                //gridControlDetail.Visible = false;


                _HTItemTypeID = (int)EnumItemType.����;
                _HTItemTypeIDA = new int[] { (int)EnumItemType.���� };
        
                BindTreeList();
            }
            
            else if (radioBtnML.Checked)//��Ʒ
            {
  
                radioBtnFabric.Checked = false;


                //groupControl3.Visible = false;
                //gridControlDetail.Visible = true;

                _HTItemTypeID = (int)EnumItemType.����;

                _HTItemTypeIDA = new int[] { (int)EnumItemType.���� };

                   
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
        /// ��ѡ�¼�
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