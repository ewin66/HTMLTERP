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
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmMachineManageEdit : frmAPBaseUISinEdit
    {
        public frmMachineManageEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("���������");
            //    txtTitle.Focus();
            //    return false;
            //}            

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            MachineManageRule rule = new MachineManageRule();
            MachineManage entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            string sql = "SELECT Machine FROM Data_Item WHERE Machine=" + SysString.ToDBString(HTDataID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                this.ShowMessage("�˻����Ѿ�������������Ӧ�ã������޸�");
                return;
            }
            MachineManageRule rule = new MachineManageRule();
            MachineManage entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            MachineManage entity = new MachineManage();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString();

             drpMachineType.Text = entity.MachineType.ToString();
             drpMachine.Text = entity.Machine.ToString();
             drpNeedle.Text = entity.Needie.ToString();
             drpUseableFlag.EditValue = SysConvert.ToInt32(entity.UserFlag);
  			txtDayOuty.Text = entity.DayOuty.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            txtInItem.Text = entity.InItem.ToString();
            txtNeedleLen.Text = entity.NeedleLen.ToString();
            txtTolNeedle.Text = entity.TolNeedle.ToString();
            txtInItem.Text = entity.InItem.ToString();
            //txtJarNum.Text = entity.JarNum.ToString();

            if (!findFlag)
            {
              
            }
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
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_MachineManage";

            Common.BindCLS(drpNeedle, "Ship_SOutContract", "Needle", true);//����
            Common.BindCLS(drpMachineType, "frmSampleTecEdit", "NeedleType", true);//����
            Common.BindCLS(drpMachine, "Pro_Sample", "MacType", true);
            drpUseableFlag.EditValue = (int)YesOrNo.Yes;
            //
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
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();
            entity.MachineType = SysConvert.ToString(drpMachineType.Text);
            entity.Machine = SysConvert.ToString(drpMachine.Text);
            entity.Needie = SysConvert.ToString(drpNeedle.Text);
            entity.UserFlag = SysConvert.ToInt32(drpUseableFlag.EditValue);
            entity.DayOuty = SysConvert.ToInt32(txtDayOuty.Text.Trim());
            entity.InItem = SysConvert.ToInt32(txtInItem.Text.Trim());
            entity.NeedleLen = SysConvert.ToInt32(txtNeedleLen.Text.Trim());
            entity.TolNeedle = SysConvert.ToInt32(txtTolNeedle.Text.Trim());
  			entity.Remark = txtRemark.Text.Trim();
         //   entity.JarNum = txtJarNum.Text.Trim();
            return entity;
        }
        #endregion 


        public override void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "SELECT Machine FROM Data_Item WHERE Machine=" + SysString.ToDBString(HTDataID);
            DataTable dt = SysUtils.Fill(sql);
            if(dt.Rows.Count!=0)
            {
                this.ShowMessage("�˻����Ѿ�������������Ӧ�ã������޸�");
                return;
            }

            base.btnUpdate_Click(sender, e);
        }
       
    }
}