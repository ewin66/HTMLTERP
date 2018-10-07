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
    /// 功能：公告明细
    /// </summary>
    public partial class frmBoardEdit : frmAPBaseUISinEdit
    {
        public frmBoardEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtTitle.Text.Trim() == "")
            {
                this.ShowMessage("请输入标题");
                txtTitle.Focus();
                return false;
            }
            if (txtContext.Text.Trim() == "")
            {
                this.ShowMessage("请输入内容");
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
            BoardRule rule = new BoardRule();
            Board entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            BoardRule rule = new BoardRule();
            Board entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            Board entity = new Board();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtTitle.Text = entity.Title;
            txtContext.Text = entity.Context;
            txtSendDate.DateTime = entity.SendDate;
            txtTime.Time = entity.SendDate;
            txtSendOP.Text = entity.SendOP;
            drpIsShow.EditValue = entity.IsShow;
       
            if (!findFlag)
            {
                txtSendOP.Text = FParamConfig.LoginName;
                txtSendDate.DateTime = DateTime.Now;
                txtTime.Time = DateTime.Now;
                drpIsShow.EditValue = 1;
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            BoardRule rule = new BoardRule();
            Board entity = EntityGet();
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
            this.HTDataTableName = "Data_Board";
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Board EntityGet()
        {
            Board entity = new Board();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Title = txtTitle.Text.Trim();
            entity.Context = txtContext.Text.Trim();
            entity.SendOP = txtSendOP.Text.Trim();
            entity.SendDate = SysConvert.ToDateTime(txtSendDate.DateTime.Date.ToString("yyyy-MM-dd") + txtTime.Time.ToString(" HH:mm:ss"));

            //entity.SendDate = SysConvert.ToDateTime(txtSendDate.DateTime.Date.ToString("yyyy-MM-dd") +  entity.SendDate.ToString(" HH:mm:ss"));
            ImageComboBoxItem item = drpIsShow.SelectedItem as ImageComboBoxItem;
            if (item != null)
            {
                entity.IsShow = SysConvert.ToInt32(item.Value.ToString());
            }
            return entity;
        }
        #endregion
    }
}