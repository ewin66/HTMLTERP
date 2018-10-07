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
    /// 功能：仓库单据类型管理表
    /// 作者：刘德苏
    /// 日期：2012-4-19
    /// 操作：新增
    /// </summary>
    public partial class frmFormListDBEdit : frmAPBaseUISinEdit
    {
        public frmFormListDBEdit()
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
                txtID.Focus();
                return false;
            }

            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("请输入编号");
                txtCode.Focus();
                return false;
            }

            if (txtFormNM.Text.Trim() == "")
            {
                this.ShowMessage("请输入名称");
                txtFormNM.Focus();
                return false;
            }

          
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            FormListDBRule rule = new FormListDBRule();
            FormListDB entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            FormListDBRule rule = new FormListDBRule();
            FormListDB entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            FormListDB entity = new FormListDB();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text = entity.Code.ToString(); 
  			txtFormNM.Text = entity.FormNM.ToString(); 
 
  			drpFormNoControlID.EditValue =SysConvert.ToInt32(entity.FormNoControlID.ToString());
            drpWHTypeID.EditValue = entity.WHTypeID;
  			txtRemark.Text = entity.Remark.ToString();
            drpOutFormListID.EditValue = entity.OutFormListID;
            drpInFormListID.EditValue = entity.InFormListID;
            drpDefaultWHID.EditValue = entity.DefaultWHID;
            drpWHDBFlag.EditValue = entity.WHDBFlag;

            drpSODBFlag.EditValue = entity.SODBFlag;
            drpXMFlag.EditValue = entity.XMFlag;

            if (!findFlag)
            {
              
            }
        }

        /// <summary>
        /// 设置出入库类型
        /// </summary>
        /// <param name="p_CheckList"></param>
        /// <param name="p_CheckValus"></param>
        private void SetCheckInOutType(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList, string p_CheckValus)
        {
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                p_CheckList.SetItemCheckState(i, CheckState.Unchecked);
            }
            string[] VenodrTypes = p_CheckValus.Split(',');

            foreach (string dr in VenodrTypes)
            {
                for (int i = 0; i < p_CheckList.ItemCount; i++)
                {
                    if (dr == p_CheckList.GetItemValue(i).ToString())//
                    {
                        p_CheckList.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }


        /// <summary>
        /// 获取面料类别
        /// </summary>
        /// <param name="p_CheckList"></param>
        /// <returns></returns>
        private string GetCheckInOutType(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList)
        {
            string MLLB = string.Empty;
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                if (p_CheckList.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (MLLB == string.Empty)
                    {
                        MLLB += p_CheckList.GetItemValue(i).ToString();
                    }
                    else
                    {
                        MLLB += "," + p_CheckList.GetItemValue(i).ToString();
                    }

                }
            }
            return MLLB;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FormListDBRule rule = new FormListDBRule();
            FormListDB entity = EntityGet();
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
        /// 编辑单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniUpdateSet()
        {
            txtID.Properties.ReadOnly = true;
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_FormListDB";
            Common.BindWHType(drpWHTypeID, true);
            Common.BindSubTypeNoTopForDB(drpInFormListID, true);
            Common.BindSubTypeNoTopForDB(drpOutFormListID, true);
            //Common.BindFormNoControlID(drpFormNoControlID, true);
            Common.BindFormNoControl(drpFormNoControlID, true);
            Common.BindDefaultWH(drpDefaultWHID, true);       //默认仓库
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FormListDB EntityGet()
        {
            FormListDB entity = new FormListDB();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();
            entity.ID =SysConvert.ToInt32(txtID.Text.Trim());
  			entity.FormNM = txtFormNM.Text.Trim();  
  			entity.FormNoControlID = SysConvert.ToInt32(drpFormNoControlID.EditValue); 
  			entity.WHTypeID = SysConvert.ToInt32(drpWHTypeID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.OutFormListID = SysConvert.ToInt32(drpOutFormListID.EditValue);
            entity.InFormListID = SysConvert.ToInt32(drpInFormListID.EditValue);
            entity.DefaultWHID = SysConvert.ToString(drpDefaultWHID.EditValue);
            entity.WHDBFlag = SysConvert.ToInt32(drpWHDBFlag.EditValue);


            entity.SODBFlag = SysConvert.ToInt32(drpSODBFlag.EditValue);
            entity.XMFlag = SysConvert.ToInt32(drpXMFlag.EditValue);
            return entity;
        }
        #endregion






    }
}