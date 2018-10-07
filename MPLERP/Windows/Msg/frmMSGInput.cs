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
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmMSGInput : frmAPBaseUIForm
    {
        public frmMSGInput()
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

            if (txtFormNo.Text.Trim() != "")//查询。
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (chkFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }

            if (chkSendDate.Checked)
            {
                tempStr += " AND SendTime BETWEEN " + SysString.ToDBString(txtSendDateS.DateTime) + " AND " + SysString.ToDBString(txtSendDateE.DateTime);
            }

            if (SysConvert.ToInt32(drpMSGSourceID.EditValue) != 0)
            {
                tempStr += " AND MSGSourceID=" + SysString.ToDBString(SysConvert.ToInt32(drpMSGSourceID.EditValue));
            }

            if (txtSendPhone.Text.Trim() != "")
            {
                tempStr += " AND SendPhone LIKE " + SysString.ToDBString("%" + txtSendPhone.Text.Trim() + "%");
            }

            if (txtTargetPhone.Text.Trim() != "")
            {
                tempStr += " AND TargetPhone LIKE " + SysString.ToDBString("%" + txtTargetPhone.Text.Trim() + "%");
            }

            if (txtTaregtInfo.Text.Trim() != "")
            {
                tempStr += " AND TaregtInfo LIKE " + SysString.ToDBString("%" + txtTaregtInfo.Text.Trim() + "%");
            }

            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            MSGInputRule rule = new MSGInputRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            MSGInputRule rule = new MSGInputRule();
            MSGInput entity = EntityGet();
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
            this.HTDataTableName = "SMS_MSGInput";
            this.HTDataList = gridView1;
            txtFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;
            txtSendDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtSendDateE.DateTime = DateTime.Now.Date;

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private MSGInput EntityGet()
        {
            MSGInput entity = new MSGInput();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
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
    }
}