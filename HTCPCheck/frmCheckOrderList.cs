using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
//using HttSoft.HTCheck.Data;
//using HttSoft.HTCheck.DataCtl;
//using HttSoft.HTCheck.Sys;
using HttSoft.WinUIBase;
using HttSoft.HTCPCheck.DataCtl;
using HttSoft.HTCPCheck.Data;

namespace HTCPCheck
{
    public partial class frmCheckOrderList : frmAPBaseUIRpt
    {
        public frmCheckOrderList()
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

            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo Like " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode Like " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel Like " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }
            if (ChkFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtFormDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            CheckOrderRule rule = new CheckOrderRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CheckOrderRule rule = new CheckOrderRule();
            CheckOrder entity = EntityGet();
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
            this.HTDataTableName = "Chk_CheckOrder";
            this.HTDataList = gridView1;

            txtFormDateS.DateTime = DateTime.Now.AddMonths(-1);
            txtFormDateE.DateTime = DateTime.Now.Date;



            btnPrintVisible = false;
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckOrder EntityGet()
        {
            CheckOrder entity = new CheckOrder();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        /// <summary>
        /// 检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                frmChecking frm = new frmChecking();
                frm.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"ID"));
                frm.DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                frm.ShowDialog();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}