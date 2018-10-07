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
     /// ���ܣ���̨����
     /// 
     /// </summary>
    public partial class frmMachineManage : frmAPBaseUISin
    {
        public frmMachineManage()
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
            if (drpMachineType.Text != "")
            {
                tempStr += " AND MachineType = " + SysString.ToDBString(drpMachineType.Text.ToString());
            }
            if (drpMacType.Text != "")
            {
                tempStr += " AND Machine = " + SysString.ToDBString(drpMacType.Text.ToString());
            }
            if (drpNeedle.Text != "")
            {
                tempStr += " AND Needie = " + SysString.ToDBString(drpNeedle.Text.ToString());
            }
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            MachineManageRule rule = new MachineManageRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            MachineManageRule rule = new MachineManageRule();
            MachineManage entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_MachineManage";
            this.HTDataList = gridView1;

            Common.BindCLS(drpNeedle, "Ship_SOutContract", "Needle", true);//����
            Common.BindCLS(drpMachineType, "frmSampleTecEdit", "NeedleType", true);//����
            Common.BindCLS(drpMacType, "Pro_Sample", "MacType", true);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private MachineManage EntityGet()
        {
            MachineManage entity = new MachineManage();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
        #region  �����б�Ȩ��
        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��6))
            {
                this.ShowMessage("��û�д˲���Ȩ��");
                return;
            }
            base.btnToExcel_Click(sender, e);
        }

        //public override void btnToExcelAdv_Click(object sender, EventArgs e)
        //{
        //    if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��6))
        //    {
        //        this.ShowMessage("��û�д˲���Ȩ��");
        //        return;
        //    }
        //    base.btnToExcel_Click(sender, e);
        //}
        #endregion
    }
}