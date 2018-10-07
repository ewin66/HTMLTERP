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
    /// ���ܣ�������λ����
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-19
    /// ����������
    /// </summary>
    public partial class frmUnitEdit : frmAPBaseUISinEdit
    {
        public frmUnitEdit()
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
                this.ShowMessage("���������");
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == ""&&txtNameEN.Text.Trim()=="")
            {
                this.ShowMessage("�������������ƻ�Ӣ�������е�һ��");
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
            UnitRule rule = new UnitRule();
            Unit entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            UnitRule rule = new UnitRule();
            Unit entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            Unit entity = new Unit();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            txtFormula.Text = entity.Formula.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtNameEN.Text = entity.NameEN.ToString();
            txtBaseUnit.Text = entity.BaseUnit.ToString();
            txtUnitQtyName.Text = entity.UnitQtyName.ToString();

            if (!findFlag)
            {
               
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            UnitRule rule = new UnitRule();
            Unit entity = EntityGet();
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
            this.HTDataTableName = "Enum_Unit";
            //
        }

      

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Unit EntityGet()
        {
            Unit entity = new Unit();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();//����
            entity.Name = txtName.Text.Trim(); //����
  			entity.Formula = txtFormula.Text.Trim(); //���㹫ʽ
            entity.NameEN =txtNameEN.Text.Trim();//Ӣ������
            entity.BaseUnit = txtBaseUnit.Text.Trim();//��׼��λ
            entity.Remark = txtRemark.Text.Trim();//��ע
            entity.UnitQtyName = txtUnitQtyName.Text.Trim();// ��λ����������

            return entity;
        }
        #endregion

   

       
    }
}