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
    public partial class frmCompanyContact : frmAPBaseUISin
    {
        public frmCompanyContact()
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
            if (!Common.CheckLookUpEditBlank(drpQCompanyID))//查询
            {
                tempStr += " AND CompanyID = " + SysString.ToDBString(drpQCompanyID.EditValue.ToString() );
            }

            if (!Common.CheckLookUpEditBlank(drpQDepID))//查询
            {
                tempStr += " AND DepID = " + SysString.ToDBString(drpQDepID.EditValue.ToString());
            }

            tempStr += " ORDER BY CompanyID";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            CompanyContactRule rule = new CompanyContactRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CompanyContactRule rule = new CompanyContactRule();
            CompanyContact entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_CompanyContact";
            this.HTDataList = gridView1;
            Common.BindCompanyType(drpQCompanyID, true);
            Common.BindDep(drpQDepID, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CompanyContact EntityGet()
        {
            CompanyContact entity = new CompanyContact();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
        #region 其他事件
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpQCompanyID_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQDepID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

       
    }
}