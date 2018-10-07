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
    public partial class frmBugForm : frmAPBaseUISin
    {
        public frmBugForm()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            //
            
            if (txtQFormNo.Text.Trim() != "")
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtQFormNo.Text.Trim() + "%");
            }//输入不为空
            if (SysConvert.ToInt32(drpQBugType.EditValue)!=0)
            {
                tempStr += "AND BugType = " +drpQBugType.EditValue;
            }
            if (SysConvert.ToInt32(drpQStatus.EditValue)!=0)
            {
                tempStr += "AND Status=" +drpQStatus.EditValue;
            }
            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }


            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            BugFormRule rule = new BugFormRule();
            gridView1.GridControl.DataSource=rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            BugFormRule rule = new BugFormRule();
            BugForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_BugForm";
            this.HTDataList = gridView1;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            txtMakeDateS.DateTime = DateTime.Now.AddDays(-7).Date;
            Common.BindBugType(drpQBugType, true);
            Common.BindBugStatus(drpQStatus, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private BugForm EntityGet()
        {
            BugForm entity = new BugForm();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}