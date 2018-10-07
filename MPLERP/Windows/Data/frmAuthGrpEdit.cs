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
    public partial class frmAuthGrpEdit : frmAPBaseUISinEdit
    {
        public frmAuthGrpEdit()
        {
            InitializeComponent();
        }
        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtID.Text.Trim() == "")
            {
                this.ShowMessage("请输入ID");
                txCode.Focus();
                return false;
            }
            if (txCode.Text.Trim() == "")
            {
                this.ShowMessage("请输入编码");
                txCode.Focus();
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
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            AuthGrp entity = new AuthGrp();
            entity.ID = HTDataID;
            txtID.Text = entity.ID.ToString();
            bool findFlag = entity.SelectByID();
            txCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            drpIsDefaultFlag.EditValue = entity.IsDefaultFlag;
            if (!findFlag)//处理默认值
            {
            }
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControl1, p_Flag);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_AuthGrp";

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private AuthGrp EntityGet()
        {
            AuthGrp entity = new AuthGrp();
            entity.ID = HTDataID;
            entity.ID = SysConvert.ToInt32(txtID.Text.Trim());
            entity.SelectByID();
            entity.Code = txCode.Text.Trim();
            entity.Name = txtName.Text.Trim();
            entity.IsDefaultFlag = SysConvert.ToInt32(drpIsDefaultFlag.EditValue);

            return entity;
        }
        #endregion
    }
}