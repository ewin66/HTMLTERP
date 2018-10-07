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
    public partial class frmLoadDY : frmAPBaseLoad
    {
        public frmLoadDY()
        {
            InitializeComponent();
        }

        #region ������ID
        /// <summary>
        /// ������ID
        /// </summary>
        private int[] m_DYID;
        public int[] DYID
        {
            get
            {
                return m_DYID;
            }
            set
            {
                m_DYID = value;
            }
        }

        /// <summary>
        /// �ͻ�
        /// </summary>
        private string m_VendorID;
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
        /// ��������
        /// </summary>
        private string m_VendorID2;
        public string VendorID2
        {
            get
            {
                return m_VendorID2;
            }
            set
            {
                m_VendorID2 = value;
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
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (txtShopID.Text.Trim() != string.Empty)
            {
                tempStr += " AND ShopID LIKE "+SysString.ToDBString("%"+txtShopID.Text.Trim()+"%");
            }

            if (txtDLCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND DLCode LIKE "+SysString.ToDBString("%"+txtDLCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }

            if (txtSaleOPName.Text.Trim() != string.Empty)
            {
                tempStr+=" AND OPName LIKE "+SysString.ToDBString("%"+txtSaleOPName.Text.Trim()+"%");
            }

            if(SysConvert.ToString(drpDYStatusID.EditValue)!=string.Empty)
            {
                tempStr+=" AND DYStatusID="+SysString.ToDBString(SysConvert.ToInt32(drpDYStatusID.EditValue));
            }

            if(drpDYXZ.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND DYXZ="+SysString.ToDBString(drpDYXZ.Text.Trim());
            }
            if (m_VendorID2 != "")
            {
                tempStr += " AND VendorID2="+SysString.ToDBString(m_VendorID2);
            }
            if (chkINDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime) + " AND " + SysString.ToDBString(txtQIndateE.DateTime);
            }
            if (drpQueryType.Visible)
            {
                if (drpQueryType.SelectedIndex == 0)//ֻ��ѯδ����
                {
                    tempStr += m_NoLoadCondition;
                }
            }
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            DYGLRule rule = new DYGLRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.Show();
        }

       

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_DYGL";
            this.HTDataList = gridView1;
            Common.BindCLS(drpDYXZ, "Sale_DYGL", "DYXZ", true);
            Common.BindDYStatus(drpDYStatusID, true);
            txtQIndateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQIndateE.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            new VendorProc(drpVendorID);
            drpVendorID.EditValue = m_VendorID;
            if (m_NoLoadCondition != string.Empty)//�����δ�����������ʾ��ѯ����
            {
                drpQueryType.Visible = true;
            }
            btnQuery_Click(null, null);
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
        private DYGL EntityGet()
        {
            DYGL entity = new DYGL();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        #region ���ص�������Ϣ

        /// <summary>
        /// ��ȡѡ���ID����
        /// </summary>
        /// <returns></returns>
        private int[] GetDYArray()
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

        /// <summary>
        /// ��������
        /// </summary>
        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();
            m_DYID = GetDYArray();
            if (m_DYID.Length == 0)
            {
                this.ShowMessage("û��ѡ���κ�����");
                return;
            }
            else if (m_DYID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("ѡ����ص���������Ϊ��" + m_DYID.Length.ToString() + Environment.NewLine + "����100�У������ٶȿ��ܻ������ȷ�ϼ�����"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_DYID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_DYID[i]));
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
                for(int i=0;i<gridView1.RowCount;i++)
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