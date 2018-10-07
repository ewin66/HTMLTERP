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
    public partial class frmCurrencyEdit : frmAPBaseUISinEdit
    {
        public frmCurrencyEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("请输入编号");
                txtCode.Focus();
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
            CurrencyRule rule = new CurrencyRule();
            Currency entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CurrencyRule rule = new CurrencyRule();
            Currency entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            Currency entity = new Currency();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtCode.Text = entity.Code.ToString();
            drpCName.EditValue = SysConvert.ToString(entity.CName);
            txtName.Text = SysConvert.ToString(entity.Name);
            txtRate.Text = SysConvert.ToString(entity.Rate);
            txtRemark.Text = SysConvert.ToString(entity.Remark);
            //drpBaseName.EditValue = SysConvert.ToString(entity.b);
            txtSymbol.Text = SysConvert.ToString(entity.Symbol);
            txtOPName.Text = SysConvert.ToString(entity.OPName);
            //txtRDate.DateTime = SysConvert.ToDateTime(entity.r);
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CurrencyRule rule = new CurrencyRule();
            Currency entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            //ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);      
        }

        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            //txtSetDate.DateTime = DateTime.Now.Date;
            //txtSetOPName.Text = FParamConfig.LoginName;
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Currency";
            //
            Common.BindCLS(drpBaseName, "Data_Currency", "ItemCurrency", true);
            Common.BindCLS(drpCName, "Data_Currency", "ItemCurrency", true);
            //Common.BindCLS(drpQCName, "Data_Currency", "ItemCurrency", true);
            //txtBRDate.DateTime = DateTime.Now.Date.AddDays(-7);
            //txtERDate.DateTime = DateTime.Now.Date;
            drpBaseName.Text = "人民币";
            //SetTabIndex(0, groupControlMainten);
        }
        

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Currency EntityGet()
        {
            Currency entity = new Currency();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();
            entity.CName = SysConvert.ToString(drpCName.EditValue);
            entity.Name = txtName.Text.Trim();
            if (txtOPName.Text.Trim() == "")
            {
                entity.OPName = FParamConfig.LoginName;
            }
            else
            {
                entity.OPName = txtOPName.Text.Trim();
            }
            entity.Rate = SysConvert.ToDecimal(txtRate.Text.Trim());
            entity.Symbol = txtSymbol.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            if (txtRDate.DateTime.ToString() != "")
            {
                entity.RDate = SysConvert.ToDateTime(txtRDate.DateTime.Date.ToString("yyyy-MM-dd"));
            }
            else
            {
                entity.RDate = SysConvert.ToDateTime(DateTime.Now.Date.ToString("yyyy-mm-dd"));
            }
            entity.BaseName = SysConvert.ToString(drpBaseName.EditValue);
            return entity;
        }
        #endregion
    }
}