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
    public partial class frmWHTypeEdit : frmAPBaseUISinEdit
    {
        public frmWHTypeEdit()
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
            WHTypeRule rule = new WHTypeRule();
            WHType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            WHTypeRule rule = new WHTypeRule();
            WHType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            WHType entity = new WHType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtWHPosMethodID.Text = entity.WHPosMethodID.ToString(); 
  			txtItemTypeID.Text = entity.ItemTypeID.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtTax.Text = entity.Tax.ToString(); 
  			txtItemTypeID2.Text = entity.ItemTypeID2.ToString(); 
  			txtItemTypeID3.Text = entity.ItemTypeID3.ToString(); 
  			txtItemTypeID4.Text = entity.ItemTypeID4.ToString(); 
  			txtItemTypeID5.Text = entity.ItemTypeID5.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            WHTypeRule rule = new WHTypeRule();
            WHType entity = EntityGet();
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
            this.HTDataTableName = "Enum_WHType";
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private WHType EntityGet()
        {
            WHType entity = new WHType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.WHPosMethodID = SysConvert.ToInt32(txtWHPosMethodID.Text.Trim()); 
  			entity.ItemTypeID = SysConvert.ToInt32(txtItemTypeID.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.Tax = SysConvert.ToDecimal(txtTax.Text.Trim()); 
  			entity.ItemTypeID2 = SysConvert.ToInt32(txtItemTypeID2.Text.Trim()); 
  			entity.ItemTypeID3 = SysConvert.ToInt32(txtItemTypeID3.Text.Trim()); 
  			entity.ItemTypeID4 = SysConvert.ToInt32(txtItemTypeID4.Text.Trim()); 
  			entity.ItemTypeID5 = SysConvert.ToInt32(txtItemTypeID5.Text.Trim()); 
  			
            return entity;
        }
        #endregion

    }
}