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
    public partial class frmVendorTypeEdit : frmAPBaseUISinEdit
    {
        public frmVendorTypeEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtID.Text.Trim().Equals(""))
            {
                this.ShowMessage("请输入ID");
                txtID.Focus();
                return false;
            }
            if (txtCode.Text.Trim().Equals(""))
            {
                this.ShowMessage("请输入编码");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text.Trim().Equals(""))
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
            VendorTypeRule rule = new VendorTypeRule();
            VendorType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            VendorTypeRule rule = new VendorTypeRule();
            VendorType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            VendorType entity = new VendorType();
            entity.ID = HTDataID;
            txtID.Text = entity.ID.ToString();
            bool findFlag=entity.SelectByID();
            txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            VendorTypeRule rule = new VendorTypeRule();
            VendorType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);

            if (HTFormStatus == FormStatus.修改)
            {
                txtID.Properties.ReadOnly = true;
                txtCode.Properties.ReadOnly = true;
            }
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_VendorType";
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private VendorType EntityGet()
        {
            VendorType entity = new VendorType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.ID = SysConvert.ToInt32(txtID.Text.Trim());
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}