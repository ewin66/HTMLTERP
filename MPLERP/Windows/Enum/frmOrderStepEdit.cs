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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmOrderStepEdit : frmAPBaseUISinEdit
    {
        public frmOrderStepEdit()
        {
            InitializeComponent();
        }




        #region  创建Bar默认按钮
        /// <summary>
        /// 创建Bar默认按钮
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(2, ToolButtonName.btnUpdate.ToString(), "修改", false, btnUpdate_Click, eShortcut.F2);//eShortcut.F2
            this.ToolBarItemAdd(4, ToolButtonName.btnSave.ToString(), "保存", false, btnSave_Click, eShortcut.F4);//F4
            this.ToolBarItemAdd(5, ToolButtonName.btnCancel.ToString(), "放弃", false, btnCancel_Click, eShortcut.F5);


            this.ToolBarItemAdd(15, ToolButtonName.btnFirst.ToString(), "首页", true, btnFirst_Click, eShortcut.CtrlUp);
            this.ToolBarItemAdd(16, ToolButtonName.btnPre.ToString(), "上页", false, btnPre_Click, eShortcut.CtrlLeft);
            this.ToolBarItemAdd(17, ToolButtonName.btnNext.ToString(), "下页", false, btnNext_Click, eShortcut.CtrlRight);
            this.ToolBarItemAdd(18, ToolButtonName.btnLast.ToString(), "末页", false, btnLast_Click, eShortcut.CtrlDown);



            this.ToolBarItemAdd(7, ToolButtonName.btnClose.ToString(), "退出", true, btnClose_Click, eShortcut.F12);
        }

        #endregion

        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("请输入站别编码");
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("请输入站别名称");
                txtName.Focus();
                return false;
            }    

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            OrderStepRule rule = new OrderStepRule();
            OrderStep entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            OrderStepRule rule = new OrderStepRule();
            OrderStep entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            OrderStep entity = new OrderStep();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString();
            ColorConverter cc = new ColorConverter();
            this.drpSelectColor.EditValue = cc.ConvertFromString(entity.ColorStr);

            drpNextStepID.EditValue = entity.NextStepID;
            drpSaleProduceID.EditValue = entity.SaleProcedureID;
            drpFormListID.EditValue = entity.FormListID;

            drpSaleProduceID2.EditValue = entity.SaleProcedureID2;
            drpFormListID2.EditValue = entity.FormListID2;

            chkDZFlag.Checked = SysConvert.ToBoolean(entity.DZFlag);
            chkInvoiceFlag.Checked = SysConvert.ToBoolean(entity.InvoiceFlag);
            chkRecAmountFlag.Checked = SysConvert.ToBoolean(entity.RecAmountFlag);
            chkFinishFlag.Checked = SysConvert.ToBoolean(entity.FinishFlag);
            chkCancelFlag.Checked = SysConvert.ToBoolean(entity.CancelFlag);
            chkCheckItemFlag.Checked = SysConvert.ToBoolean(entity.CheckItemFlag);
            chkCheckColorFlag.Checked = SysConvert.ToBoolean(entity.CheckColorFlag);
  			txtRemark.Text = entity.Remark.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            OrderStepRule rule = new OrderStepRule();
            OrderStep entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_OrderStep";

            Common.BindOrderStep(drpNextStepID, true);
            Common.BindSaleProcedure(drpSaleProduceID, true);
            Common.BindSubTypeNoTop(drpFormListID, true);
            Common.BindSaleProcedure(drpSaleProduceID2, true);
            Common.BindSubTypeNoTop(drpFormListID2, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OrderStep EntityGet()
        {
            OrderStep entity = new OrderStep();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim();
            ColorConverter cc = new ColorConverter();
            entity.ColorStr = cc.ConvertToString(drpSelectColor.Color);//颜色
            entity.NextStepID = SysConvert.ToInt32(drpNextStepID.EditValue);

            entity.SaleProcedureID = SysConvert.ToInt32(drpSaleProduceID.EditValue);
            entity.FormListID = SysConvert.ToInt32(drpFormListID.EditValue);

            entity.SaleProcedureID2 = SysConvert.ToInt32(drpSaleProduceID2.EditValue);
            entity.FormListID2 = SysConvert.ToInt32(drpFormListID2.EditValue);

            entity.DZFlag = SysConvert.ToInt32(chkDZFlag.Checked);
            entity.InvoiceFlag = SysConvert.ToInt32(chkInvoiceFlag.Checked);
            entity.RecAmountFlag = SysConvert.ToInt32(chkRecAmountFlag.Checked);
            entity.FinishFlag = SysConvert.ToInt32(chkFinishFlag.Checked);
            entity.CancelFlag = SysConvert.ToInt32(chkCancelFlag.Checked);
            entity.CheckItemFlag = SysConvert.ToInt32(chkCheckItemFlag.Checked);
            entity.CheckColorFlag = SysConvert.ToInt32(chkCheckColorFlag.Checked);
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
      


        public override void btnInsert_Click(object sender, EventArgs e)
        {
            this.ShowMessage("若需新增数据，请联系开发商");
           
        }
        #endregion

       
    }
}