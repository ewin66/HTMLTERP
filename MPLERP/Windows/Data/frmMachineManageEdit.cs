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
    public partial class frmMachineManageEdit : frmAPBaseUISinEdit
    {
        public frmMachineManageEdit()
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
            MachineManageRule rule = new MachineManageRule();
            MachineManage entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            string sql = "SELECT Machine FROM Data_Item WHERE Machine=" + SysString.ToDBString(HTDataID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                this.ShowMessage("此机型已经在坯布管理中应用，不能修改");
                return;
            }
            MachineManageRule rule = new MachineManageRule();
            MachineManage entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            MachineManage entity = new MachineManage();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString();

             drpMachineType.Text = entity.MachineType.ToString();
             drpMachine.Text = entity.Machine.ToString();
             drpNeedle.Text = entity.Needie.ToString();
             drpUseableFlag.EditValue = SysConvert.ToInt32(entity.UserFlag);
  			txtDayOuty.Text = entity.DayOuty.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            txtInItem.Text = entity.InItem.ToString();
            txtNeedleLen.Text = entity.NeedleLen.ToString();
            txtTolNeedle.Text = entity.TolNeedle.ToString();
            txtInItem.Text = entity.InItem.ToString();
            //txtJarNum.Text = entity.JarNum.ToString();

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            MachineManageRule rule = new MachineManageRule();
            MachineManage entity = EntityGet();
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
            this.HTDataTableName = "Data_MachineManage";

            Common.BindCLS(drpNeedle, "Ship_SOutContract", "Needle", true);//针型
            Common.BindCLS(drpMachineType, "frmSampleTecEdit", "NeedleType", true);//机型
            Common.BindCLS(drpMachine, "Pro_Sample", "MacType", true);
            drpUseableFlag.EditValue = (int)YesOrNo.Yes;
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private MachineManage EntityGet()
        {
            MachineManage entity = new MachineManage();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();
            entity.MachineType = SysConvert.ToString(drpMachineType.Text);
            entity.Machine = SysConvert.ToString(drpMachine.Text);
            entity.Needie = SysConvert.ToString(drpNeedle.Text);
            entity.UserFlag = SysConvert.ToInt32(drpUseableFlag.EditValue);
            entity.DayOuty = SysConvert.ToInt32(txtDayOuty.Text.Trim());
            entity.InItem = SysConvert.ToInt32(txtInItem.Text.Trim());
            entity.NeedleLen = SysConvert.ToInt32(txtNeedleLen.Text.Trim());
            entity.TolNeedle = SysConvert.ToInt32(txtTolNeedle.Text.Trim());
  			entity.Remark = txtRemark.Text.Trim();
         //   entity.JarNum = txtJarNum.Text.Trim();
            return entity;
        }
        #endregion 


        public override void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "SELECT Machine FROM Data_Item WHERE Machine=" + SysString.ToDBString(HTDataID);
            DataTable dt = SysUtils.Fill(sql);
            if(dt.Rows.Count!=0)
            {
                this.ShowMessage("此机型已经在坯布管理中应用，不能修改");
                return;
            }

            base.btnUpdate_Click(sender, e);
        }
       
    }
}