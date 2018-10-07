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
    /// 功能：员工管理明细
    /// </summary>
    public partial class frmOPEdit : frmAPBaseUISinEdit
    {
        public frmOPEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {

            if (txtOPID.Text.Trim() == "")
            {
                this.ShowMessage("请输入员工编号");
                txtOPID.Focus();
                return false;
            }
            if (txtOPNM.Text.Trim() == "")
            {
                this.ShowMessage("请输入员工姓名");
                txtOPNM.Focus();
                return false;
            }
            return true;
        }

       

        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            OPRule rule = new OPRule();
            OP entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            OPRule rule = new OPRule();
            OP entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            OP entity = new OP();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.OPID;

            txtOPID.Text = entity.OPID.ToString();
            txtOPNM.Text = entity.OPName.ToString();
            txtPSWORD.Text = entity.Password.ToString();
            drpUseable.EditValue =SysConvert.ToInt32(entity.UseableFlag.ToString());
            drpSex.EditValue = entity.Sex.ToString();
            txtBirthday.EditValue = entity.Birthday.ToString();
            txtCardID.EditValue = entity.CardID.ToString();
            txtEmail.Text = entity.Email.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtAddress.Text = entity.Address.ToString();
            txtInDate.EditValue =entity.InDate.ToString();
            txtSDep.Text = entity.SDep.ToString();
            txtSDuty.Text = entity.SDuty.ToString();
            txtOrigin.Text = entity.Origin.ToString();
            drpGrade.Text = entity.Diploma.ToString();
            txtAddress.Text = entity.Address.ToString();
            txtTel.Text = entity.Phone.ToString();
            drpWebFlag.EditValue = entity.WebFlag;
            txtNation.Text = entity.Nation;
            txtMarriageState.Text = entity.MarriageState;
            txtPolitical.Text = entity.Political;
            txtMobile.Text = entity.Mobile;
            txtOPCode.Text = entity.OPCode;

        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            OPRule rule = new OPRule();
            OP entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);

            ProductCommon.FormNoCtlEditSet(txtOPID, "Data_OP", "OPID", 0, p_Flag);

            if (HTFormStatus == FormStatus.修改 || HTFormStatus == FormStatus.查询)
            {
                ProcessCtl.ProcControlEdit(new Control[] { txtOPID }, false);
            }
            else
            {
                //ProcessCtl.ProcControlEdit(new Control[] { txtOPID }, true);
            }

        }

        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
           
            drpWebFlag.EditValue = 1;
            drpUseable.EditValue = 1;
            txtBirthday.DateTime = DateTime.Now.Date;
            txtInDate.DateTime = DateTime.Now.Date;
            txtOPID_DoubleClick(null, null);

           
           
        }

        /// <summary>
        /// 初始化刷新数据(状体加载时或用户刷新按钮时调用) 代码移动 2009-10-31 standy
        /// </summary>
        public override void IniRefreshData()
        {
            
           


        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_OP";
            SetPosCondition = " AND ISNULL(DefaultFlag,0)=0 ";
            Common.BindCLS(txtSDuty, "Data_OP", "SDuty", true);
            Common.BindCLS(txtSDep, "Data_OP", "SDep", true);

            DevMethod.BindOPDep(drpDepID,true);

        }

        #endregion

        #region 自定义方法

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OP EntityGet()
        {
            OP entity = new OP();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.OPID = txtOPID.Text.Trim();
            entity.OPName = txtOPNM.Text.Trim();
            entity.Password = txtPSWORD.Text.Trim();
            entity.Email = txtEmail.Text.Trim();
            entity.SDuty = txtSDuty.Text.Trim();
            entity.SDep = txtSDep.Text.Trim();
            entity.UseableFlag = SysConvert.ToInt32(drpUseable.EditValue);
            entity.WebFlag = SysConvert.ToInt32(drpWebFlag.EditValue);
            entity.Sex = SysConvert.ToString(drpSex.EditValue);
            entity.Birthday = txtBirthday.DateTime.Date;
            entity.CardID = txtCardID.Text.Trim();
            entity.Origin = txtOrigin.Text.Trim();
            entity.Address = txtAddress.Text.Trim();
            entity.Phone= txtTel.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.InDate = txtInDate.DateTime.Date;
            entity.Address = txtAddress.Text.Trim();
            entity.Diploma = drpGrade.Text.Trim();
            entity.Political = txtPolitical.Text.Trim();
            entity.Nation = txtNation.Text.Trim();
            entity.WebFlag = SysConvert.ToInt32(drpWebFlag.EditValue);
            entity.MarriageState = txtMarriageState.Text.Trim();
            entity.Mobile = txtMobile.Text.Trim();
            entity.OPCode = txtOPCode.Text.Trim();

            return entity;
        }

       

      
        /// <summary>
        /// 控制生成员工编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOPID_DoubleClick(object sender, EventArgs e)
        {
            if (HTFormStatus == FormStatus.新增)
            {
                ProductCommon.FormNoIniSet(txtOPID, "Data_OP", "OPID", 0);
            }
        }

        #endregion


    }
}