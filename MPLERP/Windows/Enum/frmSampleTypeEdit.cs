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
    public partial class frmSampleTypeEdit : frmAPBaseUISinEdit
    {
        public frmSampleTypeEdit()
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
            SampleTypeRule rule = new SampleTypeRule();
            SampleType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            SampleTypeRule rule = new SampleTypeRule();
            SampleType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            SampleType entity = new SampleType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtID.Text = entity.ID.ToString();            
            txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtNameEn.Text = entity.NameEn.ToString(); 
  			txtNameJP.Text = entity.NameJP.ToString();
            drpTecClass.EditValue = entity.TecClass.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtUnitPrice.Text = entity.UnitPrice.ToString();
            txtPeriod.Text = entity.Period.ToString();
            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            SampleTypeRule rule = new SampleTypeRule();
            SampleType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            if (HTFormStatus == FormStatus.修改)
            {
                ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
                ProcessCtl.ProcControlEdit(new Control[] { txtID }, false);
            }
            else
            {
                ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
                ProcessCtl.ProcControlEdit(new Control[] { txtID }, true);
            }
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_SampleType";
            //
            Common.BindCLS(drpTecClass, HTDataTableName, "TecClass", true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SampleType EntityGet()
        {
            SampleType entity = new SampleType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.ID = SysConvert.ToInt32(txtID.Text.Trim());
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.NameEn = txtNameEn.Text.Trim(); 
  			entity.NameJP = txtNameJP.Text.Trim();
            entity.TecClass = drpTecClass.EditValue.ToString();
            entity.Period = SysConvert.ToDecimal(txtPeriod.Text.Trim());
            entity.Remark = txtRemark.Text.Trim();
            entity.UnitPrice = SysConvert.ToDecimal(txtUnitPrice.Text.Trim());
            return entity;
        }
        #endregion
    }
}