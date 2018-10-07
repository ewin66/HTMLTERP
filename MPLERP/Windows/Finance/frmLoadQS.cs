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
    public partial class frmLoadQS : frmAPBaseLoad
    {
        public frmLoadQS()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]

        private int[] m_DtsID;
        public int[] DtsID
        {
            get
            {
                return m_DtsID;
            }
            set
            {
                m_DtsID = value;
            }
        }


        private string m_VendorID = string.Empty;
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

        private int m_NoQtyFlag =0;
        public int NoQtyFlag
        {
            get
            {
                return m_NoQtyFlag;
            }
            set
            {
                m_NoQtyFlag = value;
            }
        }

        private int m_CGFlag = 0;
        public int CGFlag
        {
            get
            {
                return m_CGFlag;
            }
            set
            {
                m_CGFlag = value;
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
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            //
            if (SysConvert.ToString(drpVendorID.EditValue) != "" && m_CGFlag==0)
            {
                tempStr += " AND VendorID ="+SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }
            if(chkOrderDate.Checked)
            {
                tempStr+=" AND FormDate BETWEEN "+SysString.ToDBString(txtFormDateS.DateTime)+" AND "+SysString.ToDBString(txtFormDateE.DateTime);
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (CGFlag == 1)
            {
                tempStr += " AND ItemVendorID="+SysString.ToDBString(m_VendorID);
            }
            if (drpQueryType.Visible)
            {
                if (drpQueryType.SelectedIndex == 0)//ֻ��ѯδ����
                {
                    tempStr += m_NoLoadCondition;
                }
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            QSRule rule = new QSRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag","0 SelectFlag"));
            setDt(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private void setDt(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["VendorID"] = Common.GetVendorNameByVendorID(dr["VendorID"].ToString());
            }
        }

        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }
      

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_QS";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�}, true);
            new VendorProc(drpVendorID);
            txtFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            drpVendorID.EditValue = m_VendorID;
            btnQuery_Click(null, null);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private QS EntityGet()
        {
            QS entity = new QS();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        #region ����ȱ����Ϣ

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

        /// <summary>
        /// ��������
        /// </summary>
        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();
            m_DtsID = GetStorgeArray();
            m_NoQtyFlag = SysConvert.ToInt32(chkNoQtyFlag.Checked);
            if (m_DtsID.Length == 0)
            {
                this.ShowMessage("û��ѡ���κ�����");
                return;
            }
            else if (m_DtsID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("ѡ����ص���������Ϊ��" + m_DtsID.Length.ToString() + Environment.NewLine + "����100�У������ٶȿ��ܻ������ȷ�ϼ�����"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_DtsID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_DtsID[i]));
            }
        }





        #endregion

        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
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