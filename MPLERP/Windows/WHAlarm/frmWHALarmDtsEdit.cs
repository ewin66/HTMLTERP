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
    public partial class frmWHALarmDtsEdit : frmAPBaseUISinEdit
    {
        public frmWHALarmDtsEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (Common.CheckLookUpEditBlank(drpWHAlarmID))
            {
                this.ShowMessage("������Ԥ������");
                drpWHAlarmID.Focus();
                return false;
            }
            if (Common.CheckLookUpEditBlank(drpItemCode))
            {
                this.ShowMessage("������ɴ�߱���");
                drpItemCode.Focus();
                return false;
            }
            if (txtAlarmLowQty.Text.Trim() == "")
            {
                this.ShowMessage("�������������");
                txtAlarmLowQty.Focus();
                return false;
            }
            else
            {
                if (!SysConvert.IsDecimal(txtAlarmLowQty.Text.Trim()))
                {
                    this.ShowMessage("�����������Ϊ���֣�����������");
                    txtAlarmLowQty.Focus();
                    return false;
                }
            }

            if (txtAlarmHighQty.Text.Trim() == "")
            {
                this.ShowMessage("�������������");
                txtAlarmHighQty.Focus();
                return false;
            }
            else
            {
                if (!SysConvert.IsDecimal(txtAlarmHighQty.Text.Trim()))
                {
                    this.ShowMessage("�����������Ϊ���֣�����������");
                    txtAlarmHighQty.Focus();
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            WHALarmDtsRule rule = new WHALarmDtsRule();
            WHALarmDts entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            WHALarmDtsRule rule = new WHALarmDtsRule();
            WHALarmDts entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            WHALarmDts entity = new WHALarmDts();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            drpWHAlarmID.EditValue = entity.WHAlarmID;
            drpItemCode.EditValue = entity.ItemCode.ToString();
            txtItemName.Text = entity.ItemName.ToString();
            txtItemStd.Text = entity.ItemStd.ToString();
            txtAlarmLowQty.Text = entity.AlarmLowQty.ToString();
            txtAlarmHighQty.Text = entity.AlarmHighQty.ToString();
            txtRemark.Text = entity.Remark.ToString();


            if (!findFlag)
            {

            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            WHALarmDtsRule rule = new WHALarmDtsRule();
            WHALarmDts entity = EntityGet();
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
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {

            txtAlarmLowQty.Text = Common.TrimZero(txtAlarmLowQty.Text);
            txtAlarmHighQty.Text = Common.TrimZero(txtAlarmHighQty.Text);
   
        }
        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_WHALarmDts";

            Common.BindWHAlarmType(drpWHAlarmID, FormListAID,false);

            new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, txtItemModel, new int[] { (int)EnumItemType.���� }, true, true);
            //if (this.FormListAID == 1)//ɴ��
            //{
            //    lable.Text = "ɴ�߱���";
            //}
            //if (this.FormListAID == 2)//ԭ��
            //{
            //    new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, txtItemModel, new int[] { (int)EnumItemType.ԭ�� }, true, true);
            //    lable.Text = "ԭ�ϱ���";
            //}

            SetPosCondition=" AND WHAlarmID IN(SELECT ID FROM WH_WHAlarm WHERE 1=1 AND ItemTypeID=" + FormListAID + ")";
           
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WHALarmDts EntityGet()
        {
            WHALarmDts entity = new WHALarmDts();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.WHAlarmID = SysConvert.ToInt32(drpWHAlarmID.EditValue.ToString());
            entity.ItemCode = drpItemCode.EditValue.ToString(); 
  			entity.ItemName = txtItemName.Text.Trim(); 
  			entity.ItemStd = txtItemStd.Text.Trim();
            entity.ItemModel = txtItemModel.Text.Trim();
  			entity.AlarmLowQty = SysConvert.ToDecimal(txtAlarmLowQty.Text.Trim()); 
  			entity.AlarmHighQty = SysConvert.ToDecimal(txtAlarmHighQty.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.LastUpdOP = FParamConfig.LoginID;
            entity.LastUpdTime = DateTime.Now.Date;

            return entity;
        }
        #endregion

    }
}