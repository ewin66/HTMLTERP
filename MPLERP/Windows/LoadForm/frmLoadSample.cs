using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;




namespace MLTERP
{
    public partial class frmLoadSample : frmAPBaseLoad
    {
        public frmLoadSample()
        {
            InitializeComponent();
        }

        private int[] m_OrderID = new int[] { };
        public int[] OrderID
        {
            get
            {
                return m_OrderID;
            }
            set
            {
                m_OrderID = value;
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
        /// <summary>
        /// ��ѯ�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnQuery_Click(object sender, EventArgs e)
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
                    tempstorge[index] = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    index++;
                }
            }
            return tempstorge;
        }
        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            //
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (txtSO.Text.Trim() != string.Empty)
            {
                tempStr += " AND SO LIKE " + SysString.ToDBString("%" + txtSO.Text.Trim() + "%");
            }

            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
            }
            if (drpQueryType.Visible)
            {
                if (drpQueryType.SelectedIndex == 0)//ֻ��ѯδ����
                {
                    tempStr += m_NoLoadCondition;
                }
            }

           // tempStr += " AND SampleType=" + FormListBID;//��������
           // tempStr += " AND SOType=2";
            tempStr += " and SampleName='�����'";
           tempStr += " and SubmitFlag=1" ;

            tempStr += " ORDER BY FormNo DESC";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>

        public override void BindGrid()
        {
            SampleRule rule = new SampleRule();
            gridView1.GridControl.DataSource = rule.RShow2(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.Show();
        }

        ///// <summary>
        ///// ɾ��
        ///// </summary>
        //public override void EntityDelete()
        //{
        //    SampleRule rule = new SampleRule();
        //    Sample entity = EntityGet();
        //    rule.RDelete(entity);
        //}
        
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
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_Sample";
            this.HTDataList = gridView1;
            Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            btnQuery_Click(null, null);
        }

        #endregion
                /// <summary>
        /// ��д��ʼ��֮��ķ���
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }
        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Sample EntityGet()
        {
            Sample entity = new Sample();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

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
        /// <summary>
        /// ��������
        /// </summary>
        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();
           
            m_OrderID = GetStorgeArray();
            if (m_OrderID.Length == 0)
            {
                this.ShowMessage("û��ѡ���κ�����");
                return;
            }
            else if (m_OrderID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("ѡ����ص���������Ϊ��" + m_OrderID.Length.ToString() + Environment.NewLine + "����100�У������ٶȿ��ܻ������ȷ�ϼ�����"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_OrderID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_OrderID[i]));
            }
        }

       


      

        private void drpSaleOPID_EditValueChanged(object sender, EventArgs e)
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

        private void gridControlDetail_DoubleClick(object sender, EventArgs e)
        {
            this.BaseFocusLabel.Focus();
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag", 1);
            LoadData();
        }
    }
}