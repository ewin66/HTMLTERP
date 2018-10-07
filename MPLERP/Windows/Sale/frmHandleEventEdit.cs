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
    public partial class frmHandleEventEdit : frmAPBaseUISinEdit
    {
        public frmHandleEventEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入标题");
            //    txtTitle.Focus();
            //    return false;
            //}            

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            HandleEventRule rule = new HandleEventRule();
            HandleEvent entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            HandleEventRule rule = new HandleEventRule();
            HandleEvent entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            HandleEvent entity = new HandleEvent();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtFormNo.Text = entity.FormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  		drpEventType.EditValue = entity.EventType.ToString(); 
            //txtVedorID.Text = entity.VedorID.ToString(); 
            drpVendorID.EditValue = entity.VedorID.ToString();
  			txtOrderFormNo.Text = entity.OrderFormNo.ToString(); 
  			txtRemark1.Text = entity.Remark1.ToString(); 
  			txtRemark2.Text = entity.Remark2.ToString(); 
  			txtRemark3.Text = entity.Remark3.ToString(); 
  			txtRemark4.Text = entity.Remark4.ToString(); 
  			txtRemark5.Text = entity.Remark5.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtMakeOPID.Text = entity.MakeOPID.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtEventStatus.EditValue =SysConvert.ToInt32( entity.EventStatus);
            txtRDate.Text = entity.RDate.ToString(); 

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            HandleEventRule rule = new HandleEventRule();
            HandleEvent entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            //ProcessCtl.ProcControlEdit(new Control[] { txtRDate }, true);
        }
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPID.Text = FParamConfig.LoginName;
            txtRDate.DateTime = DateTime.Now.AddDays(20).Date;
            txtEventStatus.EditValue = 1;
            txtFormNo_DoubleClick(null, null);
        }
        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_HandleEvent";
            //txtEventType.Properties

            Common.BindCLS(drpEventType, "Sale_HandleEvent", "EventType", true);
           
        }
        public override void IniRefreshData()
        {
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private HandleEvent EntityGet()
        {
            HandleEvent entity = new HandleEvent();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date;
            entity.EventType = SysConvert.ToString(drpEventType.EditValue);
            //entity.VedorID = txtVedorID.Text.Trim(); 
            entity.VedorID = SysConvert.ToString(drpVendorID.EditValue);
  			entity.OrderFormNo = txtOrderFormNo.Text.Trim(); 
  			entity.Remark1 = txtRemark1.Text.Trim(); 
  			entity.Remark2 = txtRemark2.Text.Trim(); 
  			entity.Remark3 = txtRemark3.Text.Trim(); 
  			entity.Remark4 = txtRemark4.Text.Trim(); 
  			entity.Remark5 = txtRemark5.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.MakeOPID = txtMakeOPID.Text.Trim(); 
  			entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.EventStatus = SysConvert.ToInt32(txtEventStatus.EditValue);
            entity.RDate = txtRDate.DateTime.Date;
            return entity;
        }
        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus==FormStatus.新增||HTFormStatus==FormStatus.修改)
                {
                    ProductCommon.FormNoIniSet(txtFormNo, "Sale_HandleEvent", "FormNo", 0);
                }
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
            
        }

    }
}