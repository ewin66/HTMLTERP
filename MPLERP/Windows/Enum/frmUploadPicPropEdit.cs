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
    public partial class frmUploadPicPropEdit : frmAPBaseUISinEdit
    {
        public frmUploadPicPropEdit()
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
            UploadPicPropRule rule = new UploadPicPropRule();
            UploadPicProp entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            UploadPicPropRule rule = new UploadPicPropRule();
            UploadPicProp entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            UploadPicProp entity = new UploadPicProp();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            txtPicWidth.Text = entity.PicWidth.ToString();
            txtPicHeight.Text = entity.PicHeight.ToString();
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
            UploadPicPropRule rule = new UploadPicPropRule();
            UploadPicProp entity = EntityGet();
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
            this.HTDataTableName = "Enum_UploadPicProp";
            //
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private UploadPicProp EntityGet()
        {
            UploadPicProp entity = new UploadPicProp();
            entity.ID = HTDataID;
            entity.SelectByID();

            entity.ID = SysConvert.ToInt32(txtID.Text.Trim());
            entity.Code = txtCode.Text.Trim();
            entity.Name = txtName.Text.Trim();
            entity.PicWidth = SysConvert.ToInt32(txtPicWidth.Text.Trim());
            entity.PicHeight = SysConvert.ToInt32(txtPicHeight.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();

            return entity;
        }
        #endregion
    }
}