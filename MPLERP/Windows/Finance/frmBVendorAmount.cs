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
    public partial class frmBVendorAmount : frmAPBaseUISin
    {
        public frmBVendorAmount()
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
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            tempStr += " AND VendorID IN (SELECT VendorID FROM Data_Vendor WHERE VendorTypeID="+FormListAID+")";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            BVendorAmountRule rule = new BVendorAmountRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            BVendorAmountRule rule = new BVendorAmountRule();
            BVendorAmount entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_BVendorAmount";
            this.HTDataList = gridView1;
            switch (FormListAID)
            {
                case 1:
                    lbVendor.Text = "�ͻ�";
                    Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
                    new VendorProc(drpVendorID);
                    break;
                case 2:
                    lbVendor.Text = "����";
                    Common.BindVendor(drpVendorID, new int[] {(int)EnumVendorType.���� }, true);
                    new VendorProc(drpVendorID);
                    break;
                
            }

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private BVendorAmount EntityGet()
        {
            BVendorAmount entity = new BVendorAmount();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}