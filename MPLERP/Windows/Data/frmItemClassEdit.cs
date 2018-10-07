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
   /// 功能：物品类型分类
   /// </summary>
    public partial class frmItemClassEdit : frmAPBaseUISinEdit
    {
        public frmItemClassEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (SysConvert.ToString(drpItemTypeID.EditValue) == "")
            {
                this.ShowMessage("请选择类型");
                drpItemTypeID.Focus();
                return false;
            }  
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
            ItemClassRule rule = new ItemClassRule();
            ItemClass entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            ItemClassRule rule = new ItemClassRule();
            ItemClass entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            ItemClass entity = new ItemClass();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            drpItemTypeID.EditValue =SysConvert.ToInt32(entity.ItemTypeID); 
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtParentID.Text = entity.ParentID.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtItemCodeRule.Text = entity.ItemCodeRule.ToString();

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ItemClassRule rule = new ItemClassRule();
            ItemClass entity = EntityGet();
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
            this.HTDataTableName = "Data_ItemClass";

            Common.BindItemType(drpItemTypeID, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemClass EntityGet()
        {
            ItemClass entity = new ItemClass();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.ItemTypeID = SysConvert.ToInt32(drpItemTypeID.EditValue); 
  			entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.ParentID = SysConvert.ToInt32(txtParentID.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();
            entity.ItemCodeRule = txtItemCodeRule.Text.Trim(); 
            return entity;
        }
        #endregion
    }
}