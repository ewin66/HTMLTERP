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
    /// 功能：计量单位管理
    /// 作者：章文强
    /// 日期：2012-04-19
    /// 操作：新增
    /// </summary>
    public partial class frmUnitEdit : frmAPBaseUISinEdit
    {
        public frmUnitEdit()
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
                this.ShowMessage("请输入编码");
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == ""&&txtNameEN.Text.Trim()=="")
            {
                this.ShowMessage("请输入中文名称或英文名称中的一个");
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
            UnitRule rule = new UnitRule();
            Unit entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            UnitRule rule = new UnitRule();
            Unit entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            Unit entity = new Unit();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            txtFormula.Text = entity.Formula.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtNameEN.Text = entity.NameEN.ToString();
            txtBaseUnit.Text = entity.BaseUnit.ToString();
            txtUnitQtyName.Text = entity.UnitQtyName.ToString();

            if (!findFlag)
            {
               
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            UnitRule rule = new UnitRule();
            Unit entity = EntityGet();
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
            this.HTDataTableName = "Enum_Unit";
            //
        }

      

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Unit EntityGet()
        {
            Unit entity = new Unit();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();//编码
            entity.Name = txtName.Text.Trim(); //名称
  			entity.Formula = txtFormula.Text.Trim(); //计算公式
            entity.NameEN =txtNameEN.Text.Trim();//英文名称
            entity.BaseUnit = txtBaseUnit.Text.Trim();//基准单位
            entity.Remark = txtRemark.Text.Trim();//备注
            entity.UnitQtyName = txtUnitQtyName.Text.Trim();// 单位数量标题名

            return entity;
        }
        #endregion

   

       
    }
}