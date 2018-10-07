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
    /// 功能：表单字段设置
    /// 
    /// 
    /// </summary>
    public partial class frmFiledSetEdit : frmAPBaseUISinEdit
    {
        public frmFiledSetEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (SysConvert.ToInt32(txtFormID.Text.Trim())==0)
            {
                this.ShowMessage("请输入页面ID");
                txtFormID.Focus();
                return false;
            }

            if (SysConvert.ToString(txtName.Text.Trim()) == "")
            {
                this.ShowMessage("请输入名称");
                txtName.Focus();
                return false;
            }

            if (SysConvert.ToString(txtFiledName.Text.Trim()) =="")
            {
                this.ShowMessage("请输入字段");
                txtFiledName.Focus();
                return false;
            }

            if (SysConvert.ToString(txtFiledType.Text.Trim()) == "")
            {
                this.ShowMessage("请输入字段类型");
                txtFiledType.Focus();
                return false;
            }  

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            FiledSetRule rule = new FiledSetRule();
            FiledSet entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FiledSetRule rule = new FiledSetRule();
            FiledSet entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FiledSet entity = new FiledSet();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtFormID.Text = entity.FormID.ToString();
             txtFAID.Text = entity.FAID.ToString();
             txtFBID.Text = entity.FBID.ToString(); 
  			txtSort.Text = entity.Sort.ToString(); 
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtFiledName.Text = entity.FiledName.ToString(); 
  			txtFiledType.Text = entity.FiledType.ToString(); 
  			drpBindType.EditValue =SysConvert.ToInt32( entity.BindType); 
  			txtLength.Text = entity.Length.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();

            drpUseableFlag.EditValue = entity.UseableFlag;
            drpUpDateFlag.EditValue = entity.UpDateFlag;
            txtMainTable.Text = entity.MainTable;
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FiledSetRule rule = new FiledSetRule();
            FiledSet entity = EntityGet();
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
        /// 新增初始化
        /// </summary>
        public override void IniInsertSet()
        {
            drpUpDateFlag.EditValue = 1;
            drpUseableFlag.EditValue = 1;
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sys_FiledSet";
            //

            Common.BindCLSList(drpBindType,true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FiledSet EntityGet()
        {
            FiledSet entity = new FiledSet();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormID = SysConvert.ToInt32(txtFormID.Text.Trim());
            entity.FAID = SysConvert.ToInt32(txtFAID.Text.Trim());
            entity.FBID = SysConvert.ToInt32(txtFBID.Text.Trim()); 
  			entity.Sort = SysConvert.ToInt32(txtSort.Text.Trim()); 
  			entity.Code = SysConvert.ToInt32(txtCode.Text.Trim()); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.FiledName = txtFiledName.Text.Trim(); 
  			entity.FiledType = txtFiledType.Text.Trim();
            entity.BindType = SysConvert.ToString(drpBindType.EditValue);
  			entity.Length = SysConvert.ToInt32(txtLength.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim();

            entity.UseableFlag = SysConvert.ToInt32(drpUseableFlag.EditValue);
            entity.UpDateFlag = SysConvert.ToInt32(drpUpDateFlag.EditValue);
            entity.MainTable = txtMainTable.Text.Trim();
  			
            return entity;
        }
        #endregion
    }
}