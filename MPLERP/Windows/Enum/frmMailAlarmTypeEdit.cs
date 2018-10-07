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
    public partial class frmMailAlarmTypeEdit : frmAPBaseUISinEdit
    {
        public frmMailAlarmTypeEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("������ɫ�����");
            //    txtCode.Focus();
            //    return false;
            //}
  

            if (!this.CheckCorrectDts())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            OPMailAlarmRule rule = new OPMailAlarmRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            MailAlarmTypeRule rule = new MailAlarmTypeRule();
            MailAlarmType entity = EntityGet();
            OPMailAlarm[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            MailAlarmTypeRule rule = new MailAlarmTypeRule();
            MailAlarmType entity = EntityGet();
            OPMailAlarm[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            MailAlarmType entity = new MailAlarmType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtMailFileName.Text = entity.MailFileName.ToString(); 
  			txtMailTitle.Text = entity.MailTitle.ToString(); 
  			txtMailExcuteTime.Time = entity.MailExcuteTime;
            txtMailExcuteTime2.Time = entity.MailExcuteTime2;
            txtMailExcuteTime3.Time = entity.MailExcuteTime3; 
  			txtAlarmCondition.Text = entity.AlarmCondition.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			
  			
            HTDataSubmitFlag = entity.SubmitFlag;
            HTDataDelFlag = entity.DelFlag;
            if (!findFlag)
            {
               
            }

            BindGridDts();
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            MailAlarmTypeRule rule = new MailAlarmTypeRule();
            MailAlarmType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_MailAlarmType";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"OPID"};//������ϸУ�����¼���ֶ�

            Common.BindOPID(drpGridOPID, true);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private MailAlarmType EntityGet()
        {
            MailAlarmType entity = new MailAlarmType();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.MailFileName = txtMailFileName.Text.Trim(); 
  			entity.MailTitle = txtMailTitle.Text.Trim();
            entity.MailExcuteTime = txtMailExcuteTime.Time;
            entity.MailExcuteTime2 = txtMailExcuteTime2.Time; 
  			entity.MailExcuteTime3 = txtMailExcuteTime3.Time; 
  			entity.AlarmCondition = txtAlarmCondition.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			 
            
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private OPMailAlarm[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            OPMailAlarm[] entitydts = new OPMailAlarm[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new OPMailAlarm();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].MailAlarmTypeID = HTDataID; 
  			 		entitydts[index].OPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "OPID")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        #region �����¼�
       
        #endregion


    }
}