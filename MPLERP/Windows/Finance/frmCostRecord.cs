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
    public partial class frmCostRecord : frmAPBaseUISin
    {
        public frmCostRecord()
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


            if (chkFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }

            if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }

            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            CostRecordRule rule = new CostRecordRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CostRecordRule rule = new CostRecordRule();
            CostRecord entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "UV1_Finance_CostRecord";
            this.HTDataList = gridView1;


            string ConditionV = string.Empty;
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//���۶���ҵ��Աֻ�鿴�Լ��ĵĶ���
            {
                ConditionV = " AND ID IN(Select MainID from Data_VendorSaleOP where OPID in(" + WCommon.GetStructureMemberOPStr() + "))";
            }
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, ConditionV, true);



            txtFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CostRecord EntityGet()
        {
            CostRecord entity = new CostRecord();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion
    }
}