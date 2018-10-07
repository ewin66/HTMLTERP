using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using DevExpress.XtraGrid.Views.Base;

namespace HttSoft.WinUIBase
{
    /// <summary>
    /// 帮助编辑
    /// </summary>
    public partial class frmAPBaseHelpEdit : frmAPBaseUISinEdit
    {
        public frmAPBaseHelpEdit()
        {
            InitializeComponent();
        }

        #region 全局变量、属性
        //int SaveID = 0;
        public int HelpWinListID = 0;
        public int HelpHeadTypeID = 0;
        public int HelpSubTypeID = 0;
        public string HelpFormCaption = string.Empty;
        #endregion

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
            SysStudyDicRule rule = new SysStudyDicRule();
            SysStudyDic entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            SysStudyDicRule rule = new SysStudyDicRule();
            SysStudyDic entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            SysStudyDic entity = new SysStudyDic();
            entity.ID = HTDataID;
            entity.SelectByID();
            txtTitle.Text = entity.Title;
            txtContext.Text = entity.Context;
            if (entity.SysFlag == 1)
            {
                chkSysFlag.Checked = true;
            }
            else
            {
                chkSysFlag.Checked = false;
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            SysStudyDicRule rule = new SysStudyDicRule();
            SysStudyDic entity = EntityGet();
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
            this.HTDataTableName = "Sys_SysStudyDic";
        }


        /// <summary>
        /// 刷新父窗体数据
        /// </summary>
        public override void RefreshParentData()
        {
            int tempID = HTDataID;
            this.BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 绑定GRID数据
        /// </summary>
        private void BindGrid()
        {
            string conditionStr = string.Empty;
            conditionStr += " AND WinListID=" + HelpWinListID;
            conditionStr += " AND HeadTypeID=" + HelpHeadTypeID;
            conditionStr += " AND SubTypeID=" + HelpSubTypeID;
            SysStudyDicRule rule = new SysStudyDicRule();
            gridView1.GridControl.DataSource = rule.RShow(conditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SysStudyDic EntityGet()
        {
            SysStudyDic entity = new SysStudyDic();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Title = txtTitle.Text.Trim();
            entity.WinListID = HelpWinListID;
            entity.HeadTypeID = HelpHeadTypeID;
            entity.SubTypeID = HelpSubTypeID;
            entity.Context = txtContext.Text.Trim();
            if (HTFormStatus == FormStatus.新增)
            {
                entity.AddOPID = FParamConfig.LoginID;
                entity.AddTime = DateTime.Now;
            }
            if (chkSysFlag.Checked)
            {
                entity.SysFlag = 1;
            }
            else
            {
                entity.SysFlag = 0;
            }
            entity.UpdOPID = FParamConfig.LoginID;
            entity.UpdTime = DateTime.Now;
            return entity;
        }
        #endregion

        #region 窗体事件
        private void frmAPBaseHelpEdit_Load(object sender, EventArgs e)
        {
            try
            {

                this.Text += "--" + HelpFormCaption;
                this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);
                this.gridViewBindEventA1(gridView1);

                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 重置实体到控件
        /// </summary>
        /// <param name="sender"></param>
        private void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            HTDataID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
            EntitySet();

            SetFormStatus(FormStatus.查询);
        }
        #endregion

      
    }
}