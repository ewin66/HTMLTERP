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
    public partial class frmTeams : frmAPBaseUISin
    {
        public frmTeams()
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
            if (txtCode.Text.Trim() != "")//查询
            {
                tempStr += " AND Code LIKE " + SysString.ToDBString("%" + txtCode.Text.Trim() + "%");
            }
                 if (txtName.Text.Trim() != "")//查询
            {
                tempStr += " AND Name LIKE " + SysString.ToDBString("%" + txtName.Text.Trim() + "%");
            }
            if (!Common.CheckLookUpEditBlank(drpBaseShop))
            {
                tempStr += " AND BaseShop =" + SysString.ToDBString(SysConvert.ToString(drpBaseShop.EditValue));
            }
            if (!chkFormDate.Checked)
            {
                tempStr += " AND ISNULL(ValidType,0)=0";
            }
            tempStr += " ORDER BY Code,BaseShop";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            TeamsRule rule = new TeamsRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            TeamsRule rule = new TeamsRule();
            Teams entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Teams";
            this.HTDataList = gridView1;
            Common.BindDepartment(drpBaseShop, true, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Teams EntityGet()
        {
            Teams entity = new Teams();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion


        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch(Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}