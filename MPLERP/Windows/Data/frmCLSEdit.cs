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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmCLSEdit : frmAPBaseUISinEdit
    {
        public frmCLSEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCLSIDC.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入编码");
            //    txtCLSIDC.Focus();
            //    return false;
            //}
            if (txtCLSNM.Text.Trim() == "")
            {
                this.ShowMessage("请输入内容");
                txtCLSNM.Focus();
                return false;
            }
            if (SysConvert.ToString(drpCLSList.EditValue) == "")
            {
                this.ShowMessage("请输入类型");
                drpCLSList.Focus();
                return false;
            }
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            CLSRule rule = new CLSRule();
            CLS entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CLSRule rule = new CLSRule();
            CLS entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            CLS entity = new CLS();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtCLSIDC.Text = entity.CLSIDC.ToString();
            txtCLSNM.Text = entity.CLSNM.ToString();
            txtRemark.Text = entity.Remark.ToString();
            drpCLSList.EditValue = entity.CLSListID;
            //txtFCode.Text = entity.FCode;
            if (!findFlag)//处理默认值
            {
            }
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CLSRule rule = new CLSRule();
            CLS entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_CLS";
            Common.BindCLSList(drpCLSList, true);

            SetTabIndex(0, groupControlMainten);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CLS EntityGet()
        {
            CLS entity = new CLS();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CLSIDC = txtCLSIDC.Text.Trim();
            entity.CLSNM = txtCLSNM.Text.Trim();
            //entity.CLSNMEn = txtCLSNMEn.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            entity.CLSListID = SysConvert.ToInt32(drpCLSList.EditValue);
            //entity.FCode = txtFCode.Text.Trim();
            return entity;
        }
        #endregion
    }
}