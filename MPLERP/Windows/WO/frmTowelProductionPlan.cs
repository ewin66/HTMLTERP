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
    public partial class frmTowelProductionPlan : frmAPBaseUIForm
    {
        public frmTowelProductionPlan()
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

            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " and VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }

            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }


            if (txtItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }
            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }
            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }


            if (txtDtsSo.Text.Trim() != "")
            {
                tempStr += " AND DtsSo LIKE " + SysString.ToDBString("%" + txtDtsSo.Text.Trim() + "%");
            }

            if (chkOrderDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtOrderDateS.DateTime) + " AND " + SysString.ToDBString(txtOrderDateE.DateTime);
            }
            tempStr += " and SubSeq = 1 ";//Ĭ��

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            TowelProductionPlanRule rule = new TowelProductionPlanRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            TowelProductionPlanRule rule = new TowelProductionPlanRule();
            TowelProductionPlan entity = EntityGet();
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
            this.HTDataTableName = "WO_TowelProductionPlan";
            this.HTDataList = gridView1;
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1);
            txtOrderDateE.DateTime = DateTime.Now;

            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�����ͻ� }, true);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private TowelProductionPlan EntityGet()
        {
            TowelProductionPlan entity = new TowelProductionPlan();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion
    }
}