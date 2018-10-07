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
    /// 功能：职位管理
    /// 
    /// </summary>
    public partial class frmDutyEdit : frmAPBaseUISinEdit
    {
        public frmDutyEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
           
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("请输入名称");
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
            DutyRule rule = new DutyRule();
            Duty entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            DutyRule rule = new DutyRule();
            Duty entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            Duty entity = new Duty();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtName.Text = entity.Name.ToString();
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
            DutyRule rule = new DutyRule();
            Duty entity = EntityGet();
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
            this.HTDataTableName = "Data_Duty";
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Duty EntityGet()
        {
            Duty entity = new Duty();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Name = txtName.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //在TextBox的KeyPress事件里判断输入值的ASC码,如果不为数字就把e.Handled设为Ture,取消KeyPress事件,控制txtID只能输入数字
            if (e.KeyChar > 57 || (e.KeyChar > 8 && e.KeyChar < 47) || e.KeyChar < 8)
            {
                e.Handled = true;
            }

        }
    }
}