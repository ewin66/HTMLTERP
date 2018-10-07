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
    public partial class frmSaleZBEdit : frmAPBaseUISinEdit
    {
        public frmSaleZBEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("�����ɱ���");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text.Trim ()=="")
            {
                this.ShowMessage("���������");
                txtName.Focus();
                return false;
            }  
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
           SaleGroupRule rule = new SaleGroupRule();
           SaleGroup entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
           SaleGroupRule rule = new SaleGroupRule();
           SaleGroup entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
           SaleGroup entity = new SaleGroup();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = SysConvert.ToString(entity.Name);
            //drpName.EditValue = SysConvert.ToString(entity.Name );
            //txtName.Text = SysConvert.ToString(entity.Name);
            //txtRate.Text = SysConvert.ToString(entity.Rate);
            txtRemark.Text = SysConvert.ToString(entity.Remark);
            //drpBaseName.EditValue = SysConvert.ToString(entity.b);
            //txtSymbol.Text = SysConvert.ToString(entity.Symbol);
            //txtOPName.Text = SysConvert.ToString(entity.OPName);
            //txtRDate.DateTime = SysConvert.ToDateTime(entity.r);
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
           SaleGroupRule rule = new SaleGroupRule();
           SaleGroup entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            //ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);      
        }

        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            //txtSetDate.DateTime = DateTime.Now.Date;
            //txtSetOPName.Text = FParamConfig.LoginName;
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_SaleGroup";
            //Common.BindZB(drpName, true);
           
            //Common.BindCLS(drpBaseName, "Data_Currency", "ItemCurrency", true);
            //Common.BindCLS(drpName, "Enum_SaleGroup", "ItemCurrency", true);
            //Common.BindCLS(drpQCName, "Data_Currency", "ItemCurrency", true);
            //txtBRDate.DateTime = DateTime.Now.Date.AddDays(-7);
            //txtERDate.DateTime = DateTime.Now.Date;
            //drpBaseName.Text = "�����";
            //SetTabIndex(0, groupControlMainten);

            
            
            
        }


    
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SaleGroup EntityGet()
        {
           SaleGroup entity = new SaleGroup();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code =SysConvert.ToInt32( txtCode.Text.Trim());
            entity.Name = SysConvert.ToString(txtName.Text.Trim());
            //entity.Name = txtName.Text.Trim();
            //if (txtOPName.Text.Trim() == "")
            //{ 
            //    entity.OPName = FParamConfig.LoginName;
            //}
            //else
            //{
            //    entity.OPName = txtOPName.Text.Trim();
            //}
            //entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim());
            //entity.Symbol = txtSymbol.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            //if (txtRDate.DateTime.ToString() != "")
            //{
            //    entity.RDate = SysConvert.ToDateTime(txtRDate.DateTime.Date.ToString("yyyy-MM-dd"));
            //}
            //else
            //{
            //    entity.RDate = SysConvert.ToDateTime(DateTime.Now.Date.ToString("yyyy-mm-dd"));
            //}
            //entity.BaseName = SysConvert.ToString(drpBaseName.EditValue);
            return entity;
        }
        #endregion

        private void txtName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        ///// <summary>
        ///// �������Զ�����
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    if (HTFormStatus == FormStatus.����)
            //    {
            //        //FormNoControlRule rule = new FormNoControlRule();
            //        //txtCode.Text = rule.RGetFormNo((int)FormNoControlEnum.������);
            //    }
            //}
            //catch (Exception E)
            //{
            //    this.ShowMessage(E.Message);
            //}
        }
    }
}