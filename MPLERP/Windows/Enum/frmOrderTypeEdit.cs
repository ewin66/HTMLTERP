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
    /// 功能：订单类型管理
    /// 作者：章文强
    /// 日期：2012-04-19
    /// 操作：新增
    /// </summary>
    public partial class frmOrderTypeEdit : frmAPBaseUISinEdit
    {
        public frmOrderTypeEdit()
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
            OrderTypeRule rule = new OrderTypeRule();
            OrderType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            OrderTypeRule rule = new OrderTypeRule();
            OrderType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            OrderType entity = new OrderType();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            ColorConverter cc = new ColorConverter(); 
            this.drpSelectColor.EditValue = cc.ConvertFromString(entity.ColorStr);

           
            if (!findFlag)
            {
               
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            OrderTypeRule rule = new OrderTypeRule();
            OrderType entity = EntityGet();
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
            this.HTDataTableName = "Enum_OrderType";
            //
        
        }
        public override void IniInsertSet()
        {
          
        }
        public override void IniUpdateSet()
        {
            txtID.Properties.ReadOnly = true;
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OrderType EntityGet()
        {
            OrderType entity = new OrderType();
            //entity.ID = HTDataID;
            entity.SelectByID();
            entity.ID = Convert.ToInt32( txtID.Text.Trim());
            entity.Code = txtCode.Text.Trim();//编码
            entity.Name = txtName.Text.Trim(); //名称
            ColorConverter cc = new ColorConverter();
            entity.ColorStr = cc.ConvertToString(drpSelectColor.Color);//颜色
  			
            return entity;
        }
        #endregion

       
    }
}