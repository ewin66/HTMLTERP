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
    /// <summary>
    /// ���ܣ�Ա��������ϸ
    /// </summary>
    public partial class frmOPEdit : frmAPBaseUISinEdit
    {
        public frmOPEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {

            if (txtOPID.Text.Trim() == "")
            {
                this.ShowMessage("������Ա�����");
                txtOPID.Focus();
                return false;
            }
            if (txtOPNM.Text.Trim() == "")
            {
                this.ShowMessage("������Ա������");
                txtOPNM.Focus();
                return false;
            }
            return true;
        }

       

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            OPRule rule = new OPRule();
            OP entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            OPRule rule = new OPRule();
            OP entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            OP entity = new OP();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.OPID;

            txtOPID.Text = entity.OPID.ToString();
            txtOPNM.Text = entity.OPName.ToString();
            txtPSWORD.Text = entity.Password.ToString();
            drpUseable.EditValue =SysConvert.ToInt32(entity.UseableFlag.ToString());
            drpSex.EditValue = entity.Sex.ToString();
            txtBirthday.EditValue = entity.Birthday.ToString();
            txtCardID.EditValue = entity.CardID.ToString();
            txtEmail.Text = entity.Email.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtAddress.Text = entity.Address.ToString();
            txtInDate.EditValue =entity.InDate.ToString();
            txtSDep.Text = entity.SDep.ToString();
            txtSDuty.Text = entity.SDuty.ToString();
            txtOrigin.Text = entity.Origin.ToString();
            drpGrade.Text = entity.Diploma.ToString();
            txtAddress.Text = entity.Address.ToString();
            txtTel.Text = entity.Phone.ToString();
            drpWebFlag.EditValue = entity.WebFlag;
            txtNation.Text = entity.Nation;
            txtMarriageState.Text = entity.MarriageState;
            txtPolitical.Text = entity.Political;
            txtMobile.Text = entity.Mobile;
            txtOPCode.Text = entity.OPCode;

        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            OPRule rule = new OPRule();
            OP entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);

            ProductCommon.FormNoCtlEditSet(txtOPID, "Data_OP", "OPID", 0, p_Flag);

            if (HTFormStatus == FormStatus.�޸� || HTFormStatus == FormStatus.��ѯ)
            {
                ProcessCtl.ProcControlEdit(new Control[] { txtOPID }, false);
            }
            else
            {
                //ProcessCtl.ProcControlEdit(new Control[] { txtOPID }, true);
            }

        }

        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
           
            drpWebFlag.EditValue = 1;
            drpUseable.EditValue = 1;
            txtBirthday.DateTime = DateTime.Now.Date;
            txtInDate.DateTime = DateTime.Now.Date;
            txtOPID_DoubleClick(null, null);

           
           
        }

        /// <summary>
        /// ��ʼ��ˢ������(״�����ʱ���û�ˢ�°�ťʱ����) �����ƶ� 2009-10-31 standy
        /// </summary>
        public override void IniRefreshData()
        {
            
           


        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_OP";
            SetPosCondition = " AND ISNULL(DefaultFlag,0)=0 ";
            Common.BindCLS(txtSDuty, "Data_OP", "SDuty", true);
            Common.BindCLS(txtSDep, "Data_OP", "SDep", true);

            DevMethod.BindOPDep(drpDepID,true);

        }

        #endregion

        #region �Զ��巽��

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private OP EntityGet()
        {
            OP entity = new OP();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.OPID = txtOPID.Text.Trim();
            entity.OPName = txtOPNM.Text.Trim();
            entity.Password = txtPSWORD.Text.Trim();
            entity.Email = txtEmail.Text.Trim();
            entity.SDuty = txtSDuty.Text.Trim();
            entity.SDep = txtSDep.Text.Trim();
            entity.UseableFlag = SysConvert.ToInt32(drpUseable.EditValue);
            entity.WebFlag = SysConvert.ToInt32(drpWebFlag.EditValue);
            entity.Sex = SysConvert.ToString(drpSex.EditValue);
            entity.Birthday = txtBirthday.DateTime.Date;
            entity.CardID = txtCardID.Text.Trim();
            entity.Origin = txtOrigin.Text.Trim();
            entity.Address = txtAddress.Text.Trim();
            entity.Phone= txtTel.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.InDate = txtInDate.DateTime.Date;
            entity.Address = txtAddress.Text.Trim();
            entity.Diploma = drpGrade.Text.Trim();
            entity.Political = txtPolitical.Text.Trim();
            entity.Nation = txtNation.Text.Trim();
            entity.WebFlag = SysConvert.ToInt32(drpWebFlag.EditValue);
            entity.MarriageState = txtMarriageState.Text.Trim();
            entity.Mobile = txtMobile.Text.Trim();
            entity.OPCode = txtOPCode.Text.Trim();

            return entity;
        }

       

      
        /// <summary>
        /// ��������Ա�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOPID_DoubleClick(object sender, EventArgs e)
        {
            if (HTFormStatus == FormStatus.����)
            {
                ProductCommon.FormNoIniSet(txtOPID, "Data_OP", "OPID", 0);
            }
        }

        #endregion


    }
}