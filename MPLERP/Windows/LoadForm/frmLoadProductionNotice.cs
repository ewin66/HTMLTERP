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
    /// ���ؿ��
    /// </summary>
    public partial class frmLoadProductionNotice : frmAPBaseLoad
    {
        public frmLoadProductionNotice()
        {
            InitializeComponent();
        }

        #region ����
        /// <summary>
        /// ���ID
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

        private int m_ID=0;
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }
        /// <summary>
        /// ��˾��
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
        /// �ֿ�����
        /// </summary>
        private int m_WHTypeID=1;   //Ĭ�������ϲֿ�
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
        /// �ֿ���������
        /// </summary>
        private int m_WHItemTypeID = 0;   //�ֿ���������
        /// <summary>
        /// �ֿ���������
        /// </summary>
        public int WHItemTypeID
        {
            get
            {
                return m_WHItemTypeID;
            }
            set
            {
                m_WHItemTypeID = value;
            }
        }

        /// <summary>
        /// �Ƿ�����Ŀ�
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
        /// ԭ�ϱ��
        /// </summary>
        private string m_ItemCode;
        public string ItemCode
        {
            get { return m_ItemCode; }
            set { m_ItemCode = value; }
        }

        /// <summary>
        /// �ֿ���
        /// </summary>
        private string m_WHID;
        public string WHID
        {
            get { return m_WHID; }
            set { m_WHID = value; }
        }

        #endregion

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (chkQMakeDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQMakeDateB.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
            }

            if (SysConvert.ToString(drpTrackOPID.EditValue) != "")
            {
                tempStr += " AND TrackOPID=" + SysString.ToDBString(SysConvert.ToString(drpTrackOPID.EditValue));
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }

            if (txtFlower.Text.Trim() != "")
            {
                tempStr += " AND Flower LIKE " + SysString.ToDBString("%" + txtFlower.Text.Trim() + "%");
            }
            if (ID > 0)
            {
                tempStr += " AND MainID=" + SysString.ToDBString(ID);
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            ProductionNoticeRule rule = new ProductionNoticeRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.Show();


        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_ProductionNotice";
            this.HTDataList = gridView1;
            txtQMakeDateB.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQMakeDateE.DateTime = DateTime.Now.Date;

            Common.BindOP(drpSaleOPID, true);
            Common.BindOP(drpTrackOPID, true);
            HTDataList.OptionsBehavior.ShowEditorOnMouseUp = false;

            btnQuery_Click(null, null);
        }

        /// <summary>
        /// ��д��ʼ��֮��ķ���
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }

        #endregion
          
        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Storge EntityGet()
        {
            Storge entity = new Storge();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        #region ���ؿ��
        /// <summary>
        /// ȡ�ÿ������
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

            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
            //    {
            //        if (i != 0 && SysConvert.ToInt32(gridView1.GetRowCellValue(i, "CompanyTypeID")) != SysConvert.ToInt32(gridView1.GetRowCellValue(i - 1, "CompanyTypeID")))
            //        {
            //            this.ShowMessage("����ϸ���ݲ�����ͳһ��˾��");
            //            return;
            //        }
            //    }
            //}

            m_StorgeID = GetStorgeArray();
            if (m_StorgeID.Length == 0)
            {
                this.ShowMessage("û��ѡ���κ�����");
                return;
            }
            else if (m_StorgeID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("ѡ����ص���������Ϊ��" + m_StorgeID.Length.ToString() + Environment.NewLine + "����100�У������ٶȿ��ܻ������ȷ�ϼ�����"))
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

        #region   �����¼�
        /// <summary>
        /// ���ٲ�ѯ
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



       

        #endregion

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        


    }
}