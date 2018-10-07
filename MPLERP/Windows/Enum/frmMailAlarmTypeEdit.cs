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


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入色卡编号");
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
        /// 绑定数据明细
        /// </summary>
        public override void BindGridDts()
        {
            OPMailAlarmRule rule = new OPMailAlarmRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
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
        /// 修改
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
        /// 设置
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
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            MailAlarmTypeRule rule = new MailAlarmTypeRule();
            MailAlarmType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
            
        }


        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_MailAlarmType";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] {"OPID"};//数据明细校验必须录入字段

            Common.BindOPID(drpGridOPID, true);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
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
        /// 获得实体
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

        #region 其它事件
       
        #endregion


    }
}