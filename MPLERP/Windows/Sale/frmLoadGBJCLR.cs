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
    /// ���ܣ���Ʒ�Ұ����
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-25
    /// ����������
    /// </summary>
    public partial class frmLoadGBJCLR : frmAPBaseLoad
    {
        public frmLoadGBJCLR()
        {
            InitializeComponent();
        }

        #region
        /// <summary>
        /// �Ұ�ID
        /// </summary>
        private int[] m_GBID;
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
        #endregion

        #region �Զ����鷽������[��Ҫ�޸�]

        /// <summary>
        /// ��ѯ����
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() != "")//��ѯ��
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr = " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr = " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }
            if (txtColorNum.Text.Trim() != "")
            {
                tempStr = " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }
            if (txtColorName.Text.Trim() != "")
            {
                tempStr = " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }
            if (this.chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }
            if (this.chkJCTime.Checked)
            {
                tempStr += " AND JCTime BETWEEN " + SysString.ToDBString(txtJCTimeS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtJCTimeE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }
            if (this.chkGHTime.Checked)
            {
                tempStr += " AND GHTime BETWEEN " + SysString.ToDBString(txtGHTimeS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtGHTimeE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }
            if (SysConvert.ToString(drpLYVendorID.EditValue) != "")
            {
                tempStr += " AND LYVendorID = " + SysString.ToDBString(SysConvert.ToString(drpLYVendorID.EditValue));
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID = " + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
            }
            if (txtGBCode.Text.Trim() != "")
            {
                tempStr += " AND GBCode LIKE " + SysString.ToDBString("%" + txtGBCode.Text.Trim() + "%");
            }
            tempStr += " AND ISNULL(FormListID,0) = " + this.FormListAID; //2013.11.14 zjh
            tempStr += " AND ISNULL(SubmitFlag,0) = 1";
            tempStr += " AND ISNULL(GBCode,'') != ''";
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }

        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            GBJCLRRule rule = new GBJCLRRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.Show();
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
            this.HTDataTableName = "Dev_GBJCLR";
            this.HTDataList = gridView1;
            btnQuery_Click(null, null);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.����, (int)EnumVendorType.�ͻ� }, true);//�ͻ�        
            new VendorProc(drpVendorID);
            Common.BindVendor(drpLYVendorID, new int[] { (int)EnumVendorType.����, (int)EnumVendorType.�ͻ� }, true);//�����ͻ�
            new VendorProc(drpLYVendorID);
            Common.BindDOP(drpSaleOPID, true);
            txtJCTimeS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtJCTimeE.DateTime = DateTime.Now.Date;
            txtMakeDateS.DateTime = DateTime.Now.AddDays(-5).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            txtGHTimeS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtGHTimeE.DateTime = DateTime.Now.Date;
            this.chkMakeDate.Checked = true;

            btnQuery_Click(null, null);

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
        private void txtName_EditValueChanged(object sender, EventArgs e)
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
                    tempstorge[index] = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DevDtsID"));
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
            m_GBID = GetStorgeArray();
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


    }
}