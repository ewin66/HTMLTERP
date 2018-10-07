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
    public partial class frmSOContextEdit : frmAPBaseUISinEdit
    {
        public frmSOContextEdit()
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
            if (txtCode.Text.Trim() == string.Empty)
            {
                this.ShowMessage("请输入合同内容编号");
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == string.Empty)
            {
                this.ShowMessage("请输入合同内容名称");
                txtName.Focus();
                return false;
            }

            if (txtContext.Text.Trim() == string.Empty)
            {
                this.ShowMessage("请输入合同内容");
                txtContext.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            SOContextRule rule = new SOContextRule();
            SOContext entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            SOContextRule rule = new SOContextRule();
            SOContext entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            SOContext entity = new SOContext();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtContext.Text = entity.Context.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            cmbTextType.Text = entity.Type.ToString();
            drpUseableFlag.EditValue = entity.DelFlag;

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            SOContextRule rule = new SOContextRule();
            SOContext entity = EntityGet();
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
            this.HTDataTableName = "Data_SOContext";
            //
            Common.BindCLS(cmbTextType, "Data_SOContext", "Type", true);
        }

        public override void IniInsertSet()
        {
            drpUseableFlag.EditValue = 1;
            cmbTextType.Text = "销售";
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SOContext EntityGet()
        {
            SOContext entity = new SOContext();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.Context = txtContext.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.Type = cmbTextType.Text.ToString();
            entity.DelFlag = SysConvert.ToInt32(drpUseableFlag.EditValue);
            return entity;
        }
        #endregion
    }
}