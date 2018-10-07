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
    public partial class frmMSGInputEdit : frmAPBaseUIFormEdit
    {
        public frmMSGInputEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtFormNo.Text.Trim() == "")
            {
                this.ShowMessage("请输入单号");
                txtFormNo.Focus();
                return false;
            }

            if (SysConvert.ToInt32(drpMSGSourceID.EditValue) == 0)
            {
                this.ShowMessage("请选择信息来源");
                drpMSGSourceID.Focus();
                return false;
            }
  

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
            MSGInputDtsRule rule = new MSGInputDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            MSGInputRule rule = new MSGInputRule();
            MSGInput entity = EntityGet();
            MSGInputDts[] entitydts = EntityDtsGet();

            entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            MSGInputRule rule = new MSGInputRule();
            MSGInput entity = EntityGet();
            MSGInputDts[] entitydts = EntityDtsGet();
            entity.SubmitFlag = this.HTSubmitFlagUpdateGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            MSGInput entity = new MSGInput();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
           
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate;
            drpMSGSourceID.EditValue = entity.MSGSourceID;
  			txtContext.Text = entity.Context.ToString(); 
  			txtReplaceRule.Text = entity.ReplaceRule.ToString(); 
  			txtSendInfo.Text = entity.SendInfo.ToString(); 
  			txtSendDesc.Text = entity.SendDesc.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			
  			
            HTDataSubmitFlag = entity.SubmitFlag;
            //HTDataDelFlag = entity.DelFlag;
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
            MSGInputRule rule = new MSGInputRule();
            MSGInput entity = EntityGet();
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
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "SMS_MSGInput";
            this.HTDataDts = gridView1;
            this.HTCheckDataField = new string[] { "Context" };//数据明细校验必须录入字段
            Common.BindMSGSource(drpMSGSourceID, true);
            

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private MSGInput EntityGet()
        {
            MSGInput entity = new MSGInput();
            entity.ID = HTDataID;
            entity.SelectByID();
            
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date;
            entity.InsertTime = DateTime.Now.Date;
  			entity.MSGSourceID = SysConvert.ToInt32(drpMSGSourceID.EditValue); 
  			entity.Context = txtContext.Text.Trim(); 
  			entity.ReplaceRule = txtReplaceRule.Text.Trim(); 
  			entity.SendInfo = txtSendInfo.Text.Trim(); 
  			entity.SendDesc = txtSendDesc.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			 
            
            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private MSGInputDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            MSGInputDts[] entitydts = new MSGInputDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    entitydts[index] = new MSGInputDts();
                    entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID")); 
                    if (entitydts[index].MainID == HTDataID && HTDataID != 0)//已存在表示修改
                    {
                        entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")); 
                        entitydts[index].SelectByID();
                    }
                    else//新增
                    {
                        entitydts[index].MainID = HTDataID;
                        entitydts[index].Seq = i + 1;
                    }
                    
                    entitydts[index].Context = SysConvert.ToString(gridView1.GetRowCellValue(i, "Context")); 
  			 		entitydts[index].TargetPhone = SysConvert.ToString(gridView1.GetRowCellValue(i, "TargetPhone")); 
  			 		entitydts[index].TaregtInfo = SysConvert.ToString(gridView1.GetRowCellValue(i, "TaregtInfo")); 
  			 		entitydts[index].TargetDesc = SysConvert.ToString(gridView1.GetRowCellValue(i, "TargetDesc")); 
  			 		entitydts[index].SendTime = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "SendTime")); 
  			 		entitydts[index].SendFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SendFlag")); 
  			 		entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark")); 
  			 		 
                    
                    index++;
                }
            }
            return entitydts;
        }

        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.短信输入单号);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 其它事件
       
        #endregion


    }
}