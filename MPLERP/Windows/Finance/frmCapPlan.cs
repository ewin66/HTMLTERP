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
    public partial class frmCapPlan : frmAPBaseUIForm
    {
        public frmCapPlan()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }

            if (chkINDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN "+SysString.ToDBString(txtFormDateS.DateTime)+" AND "+SysString.ToDBString(txtFormDateE.DateTime);
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                tempStr += " AND PlanOPID="+SysString.ToDBString(drpSaleOPID.EditValue.ToString());
            }

            tempStr += " AND CapPlanTypeID="+SysString.ToDBString(this.FormListAID);
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            CapPlanRule rule = new CapPlanRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CapPlanRule rule = new CapPlanRule();
            CapPlan entity = EntityGet();
            rule.RDelete(entity);
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
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_CapPlan";
            this.HTDataList = gridView1;
            Common.BindOP(drpSaleOPID, true);
            Common.BindVendorName(drpVendorName, true);
            switch (FormListAID)
            {
                case 1:
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
                    lbVendor.Text = "�ͻ�";
                    new VendorProc(drpVendorID);
                    break;
                case 2:
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.���� }, true);
                    lbVendor.Text = "����";
                    new VendorProc(drpVendorID);
                    break;
            }
            txtFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;
           

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CapPlan EntityGet()
        {
            CapPlan entity = new CapPlan();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

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
    }
}