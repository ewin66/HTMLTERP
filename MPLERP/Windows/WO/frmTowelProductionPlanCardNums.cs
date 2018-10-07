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
using DevExpress.XtraGrid.Views.Base;


namespace MLTERP.Windows.WO
{
    public partial class frmTowelProductionPlanCardNums : frmAPBaseUIFormEdit
    {
        public frmTowelProductionPlanCardNums()
        {
            InitializeComponent();
        }
        public int CardNums { get; set; }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SysConvert.ToInt32(txtCardNums.Text) == 0)
            {
                this.ShowInfoMessage("请输入开卡数量");
                return;
            }
            CardNums = SysConvert.ToInt32(txtCardNums.Text.Trim());
            this.Close();
        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
