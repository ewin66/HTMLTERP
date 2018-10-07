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
    /// ���ܣ��ͻ���ˮ�Ų�ѯ
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-17
    /// ����������
    /// </summary>
    public partial class frmFormNCVendor : frmAPBaseUISin
    {
        public frmFormNCVendor()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]

        /// <summary>
        /// ��ѯ����
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (SysConvert.ToString(drpVendorID.EditValue) != "")//���ݿͻ���ѯ
            {
                tempStr += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpFNCVID.EditValue) != "")//���ݵ��ݲ�ѯ
            {
                tempStr += " AND FNCVID=" + SysString.ToDBString(drpFNCVID.EditValue.ToString());
            }
            tempStr += " ORDER BY ID";
            HTDataConditionStr = tempStr;
        }

        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            FormNCVendorRule rule = new FormNCVendorRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FormNCVendorRule rule = new FormNCVendorRule();
            FormNCVendor entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_FormNCVendor";
            this.HTDataList = gridView1;
            Common.BindFNCV(drpFNCVID, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.ȫ�� }, true);//�ͻ�
            btnQuery_Click(null, null);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FormNCVendor EntityGet()
        {
            FormNCVendor entity = new FormNCVendor();
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

        
    }
}