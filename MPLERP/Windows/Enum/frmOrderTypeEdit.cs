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
    /// ���ܣ��������͹���
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-19
    /// ����������
    /// </summary>
    public partial class frmOrderTypeEdit : frmAPBaseUISinEdit
    {
        public frmOrderTypeEdit()
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
            OrderTypeRule rule = new OrderTypeRule();
            OrderType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            OrderTypeRule rule = new OrderTypeRule();
            OrderType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            OrderType entity = new OrderType();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            ColorConverter cc = new ColorConverter(); 
            this.drpSelectColor.EditValue = cc.ConvertFromString(entity.ColorStr);

           
            if (!findFlag)
            {
               
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            OrderTypeRule rule = new OrderTypeRule();
            OrderType entity = EntityGet();
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
            this.HTDataTableName = "Enum_OrderType";
            //
        
        }
        public override void IniInsertSet()
        {
          
        }
        public override void IniUpdateSet()
        {
            txtID.Properties.ReadOnly = true;
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private OrderType EntityGet()
        {
            OrderType entity = new OrderType();
            //entity.ID = HTDataID;
            entity.SelectByID();
            entity.ID = Convert.ToInt32( txtID.Text.Trim());
            entity.Code = txtCode.Text.Trim();//����
            entity.Name = txtName.Text.Trim(); //����
            ColorConverter cc = new ColorConverter();
            entity.ColorStr = cc.ConvertToString(drpSelectColor.Color);//��ɫ
  			
            return entity;
        }
        #endregion

       
    }
}