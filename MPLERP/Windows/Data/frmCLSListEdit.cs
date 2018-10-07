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
    public partial class frmCLSListEdit : frmAPBaseUISinEdit
    {
        public frmCLSListEdit()
        {
            InitializeComponent();
        }
        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCLSA.Text.Trim() == "")
            //{
            //    this.ShowMessage("���������");
            //    txtCLSA.Focus();
            //    return false;
            //}
            //if (txtCLSB.Text.Trim() == "")
            //{
            //    this.ShowMessage("������С��");
            //    txtCLSB.Focus();
            //    return false;
            //}            
            if (txtCLSDESC.Text.Trim() == "")
            {
                this.ShowMessage("����������");
                txtCLSDESC.Focus();
                return false;
            }
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            CLSListRule rule = new CLSListRule();
            CLSList entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            CLSListRule rule = new CLSListRule();
            CLSList entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            CLSList entity = new CLSList();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtCLSA.Text = entity.CLSA.ToString();
            txtCLSB.Text = entity.CLSB.ToString();
            txtCLSDESC.Text = entity.CLSDESC.ToString();         
            if (!findFlag)//����Ĭ��ֵ
            {
            }
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CLSListRule rule = new CLSListRule();
            CLSList entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_CLSList";
            //Common.BindCLSList(drpCLSList, true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CLSList EntityGet()
        {
            CLSList entity = new CLSList();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CLSA = txtCLSA.Text.Trim();
            entity.CLSB = txtCLSB.Text.Trim();
            entity.CLSDESC = txtCLSDESC.Text.Trim();

            return entity;
        }
        #endregion
    }
}