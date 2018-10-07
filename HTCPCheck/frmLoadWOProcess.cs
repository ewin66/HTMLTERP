using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTCPCheck.DataCtl;
using HttSoft.HTERP.Sys;
using HttSoft.WinUIBase;

namespace HTCPCheck
{
    public partial class frmLoadWOProcess : frmAPBaseLoad
    {
        public frmLoadWOProcess()
        {
            InitializeComponent();
        }

        #region  �Զ�������
        public int OnlyOneFormNo = 0;//0 ��������ض�����¼��    1 ֻ������ص����ӹ���

        /// <summary>
        /// �ɹ�����ϸID
        /// </summary>
        private int[] m_ItemBuyID = new int[] { };
        public int[] ItemBuyID
        {
            get
            {
                return m_ItemBuyID;
            }
            set
            {
                m_ItemBuyID = value;
            }
        }

        private string  m_VendorID =string.Empty;
        public string VendorID
        {
            get
            {
                return m_VendorID;
            }
            set
            {
                m_VendorID = value;
            }
        }


        /// <summary>
        /// δ����SQL�������
        /// </summary>
        private string m_NoLoadCondition = string.Empty;
        public string NoLoadCondition
        {
            get
            {
                return m_NoLoadCondition;
            }
            set
            {
                m_NoLoadCondition = value;
            }
        }

        private int m_LoadType = 1; //Ĭ��Ϊ���ϲɹ���
        public int LoadType
        {
            get
            {
                return m_LoadType;
            }
            set
            {
                m_LoadType = value;
            }
        }

        private int m_ProcessTypeID = 1; //Ĭ��ΪȾ���ӹ���
        public int ProcessTypeID
        {
            get
            {
                return m_ProcessTypeID;
            }
            set
            {
                m_ProcessTypeID = value;
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
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtOrderDateS.DateTime) + " AND " + SysString.ToDBString(txtOrderDateE.DateTime);
            }

            if (chkReqDate.Checked)
            {
                tempStr += " AND ReqDate BETWEEN " + SysString.ToDBString(txtReqDateS.DateTime) + " AND " + SysString.ToDBString(txtReqDateE.DateTime);
            }

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND DyeFactorty = " + SysString.ToDBString(drpQVendorID.EditValue.ToString());
            }

            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }

            if (txtMWeightS.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWeight>" + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }

            if (txtMWeightE.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWeight<" + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }

            if (txtMWidth.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWidth=" + SysString.ToDBString(txtMWidth.Text.Trim());
            }

            if (txtItemName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");
            }

            if (txtVColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND VColorNum LIKE " + SysString.ToDBString("%" + txtVColorNum.Text.Trim() + "%");
            }

            if (txtVColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND VColorName LIKE " + SysString.ToDBString("%" + txtVColorName.Text.Trim() + "%");
            }




            

            if(txtOrderFormNo.Text.Trim()!=string.Empty)
            {
                tempStr += " AND OrderFormNo LIKE " + SysString.ToDBString("%"+txtOrderFormNo.Text.Trim()+"%"); ;
            }
            if (drpQueryType.Visible)
            {
                if (drpQueryType.SelectedIndex == 0)//ֻ��ѯδ����
                {
                    tempStr += m_NoLoadCondition;
                }
            }


            tempStr += " AND ProcessTypeID=" + SysString.ToDBString(m_ProcessTypeID);
            tempStr += " AND SubmitFlag=1";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            FabricProcessRule rule = new FabricProcessRule();
             
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.Show();
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


        /// <summary>
        /// ��д��ʼ��֮��ķ���
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }
        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_FabricProcess";
            this.HTDataList = gridView1;
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            txtReqDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtReqDateE.DateTime = DateTime.Now.Date;
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            if (m_ProcessTypeID == (int)EnumProcessType.Ⱦ���ӹ���)
            {
                Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.Ⱦ�� }, true);
            }
            else if (m_ProcessTypeID == (int)EnumProcessType.ӡ���ӹ���)
            {
                Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ӹ��� }, true);
            }
            else if (m_ProcessTypeID == (int)EnumProcessType.֯��ӹ���)
            {
                Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.֯�� }, true);
            }
            else if (m_ProcessTypeID == (int)EnumProcessType.�����ӹ���)
            {
                Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�����ӹ��� }, true);
            }
            if (m_NoLoadCondition != string.Empty)//�����δ�����������ʾ��ѯ����
            {
                drpQueryType.Visible = true;
            }
            txtVendorID.Text = m_VendorID;
            drpQVendorID.EditValue = m_VendorID;
            btnQuery_Click(null, null);
            

        }

        #endregion

        #region �Զ��巽��
        ///// <summary>
        ///// ���ʵ��
        ///// </summary>
        ///// <returns></returns>
        //private ItemBuyForm EntityGet()
        //{
        //    ItemBuyForm entity = new ItemBuyForm();
        //    entity.ID = HTDataID;      
        //    return entity;
        //}
        #endregion

        #region ����Ⱦ���ӹ�����Ϣ

        /// <summary>
        /// ��ȡѡ���ID����
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
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    tempstorge[index] = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DtsID"));
                    index++;
                }
            }
            return tempstorge;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public override void LoadData()
        {

            this.BaseFocusLabel.Focus();
            m_ItemBuyID = GetStorgeArray();
            if (m_ItemBuyID.Length == 0)
            {
                this.ShowMessage("û��ѡ���κ�����");
                return;
            }
            else if (m_ItemBuyID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("ѡ����ص���������Ϊ��" + m_ItemBuyID.Length.ToString() + Environment.NewLine + "����100�У������ٶȿ��ܻ������ȷ�ϼ�����"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_ItemBuyID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_ItemBuyID[i]));
            }
        }


        #endregion

        #region ��������
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

        private void chkSelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            this.BaseFocusLabel.Focus();
            string FormNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormNo"));
            int SelectFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag"));
            if (OnlyOneFormNo == 1)//����1 ����ֻ������ص����ɹ���
            {

                if (SelectFlag == 1)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1 && i != gridView1.FocusedRowHandle && FormNo != SysConvert.ToString(gridView1.GetRowCellValue(i, "FormNo")))
                        {
                            this.ShowMessage("ֻ�ܼ���ͬһ�������ݣ�������ѡ��");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag", 0);
                            return;
                        }
                    }
                }
            }
        }

        
    }
}