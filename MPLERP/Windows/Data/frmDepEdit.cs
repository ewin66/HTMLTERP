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
    /// ���ܣ����Ź���
    /// 
    /// </summary>
    public partial class frmDepEdit : frmAPBaseUISinEdit
    {
        public frmDepEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
           
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("����������");
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
            DepRule rule = new DepRule();
            Dep entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            DepRule rule = new DepRule();
            Dep entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            Dep entity = new Dep();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtStructureID.Text = entity.StructureID.ToString();
            chkIncludeSubStructureFlag.Checked = SysConvert.ToBoolean(entity.IncludeSubStructureFlag);


            if (!findFlag)
            {
               
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            DepRule rule = new DepRule();
            Dep entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);

            txtStructureID.Properties.ReadOnly = true;
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Dep";
            //
        }

        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            chkIncludeSubStructureFlag.Checked = true;
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Dep EntityGet()
        {
            Dep entity = new Dep();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();
            entity.Name = txtName.Text.Trim();
            entity.StructureID = SysConvert.ToInt32(txtStructureID.Text.Trim());
  			entity.Remark = txtRemark.Text.Trim();
            entity.IncludeSubStructureFlag = SysConvert.ToInt32(chkIncludeSubStructureFlag.Checked);
  			
            return entity;
        }
        #endregion

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //��TextBox��KeyPress�¼����ж�����ֵ��ASC��,�����Ϊ���־Ͱ�e.Handled��ΪTure,ȡ��KeyPress�¼�,����txtIDֻ����������
            if (e.KeyChar > 57 || (e.KeyChar > 8 && e.KeyChar < 47) || e.KeyChar < 8)
            {
                e.Handled = true;
            }

        }
        #region �����¼�
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStructureID_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus != FormStatus.��ѯ)
                {
                    frmLoadStructure frm = new frmLoadStructure();
                    frm.ShowDialog();
                    if (frm.HTLoadData.Count != 0)
                    {
                        txtStructureID.Text = frm.HTLoadData[0].ToString();
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ֵ�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStructureID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtStructureName.Text = Common.GetStructureName(SysConvert.ToInt32(txtStructureID.Text));
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

       

    }
}