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
    public partial class frmVendorTypeForm : frmAPBaseUISin
    {
        public frmVendorTypeForm()
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
            //
            if (!Common.CheckLookUpEditBlank(drpQVendorTypeID))
            {
                tempStr += " AND VendorTypeID = " + SysString.ToDBString(drpQVendorTypeID.EditValue.ToString());
            }
            if (txtCLSA.Text.Trim() != "")
            {
                tempStr += " AND CLSA LIKE " + SysString.ToDBString("%" + txtCLSA.Text.Trim() + "%");
            }
            if (txtCLSB.Text.Trim() != "")
            {
                tempStr += " AND CLSB LIKE " + SysString.ToDBString("%" + txtCLSB.Text.Trim() + "%");
            }
            tempStr += " ORDER BY CLSA";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>   
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            VendorTypeFormRule rule = new VendorTypeFormRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            VendorTypeFormRule rule = new VendorTypeFormRule();
            VendorTypeForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_VendorTypeForm";
            this.HTDataList = gridView1;

            Common.BindVendorType(drpQVendorTypeID, true);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private VendorTypeForm EntityGet()
        {
            VendorTypeForm entity = new VendorTypeForm();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        #region
        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpVendorTypeID_EditValueChanged(object sender, EventArgs e)
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