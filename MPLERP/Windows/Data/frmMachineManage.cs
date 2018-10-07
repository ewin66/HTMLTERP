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
     /// <summary>
     /// 功能：机台管理
     /// 
     /// </summary>
    public partial class frmMachineManage : frmAPBaseUISin
    {
        public frmMachineManage()
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
            if (drpMachineType.Text != "")
            {
                tempStr += " AND MachineType = " + SysString.ToDBString(drpMachineType.Text.ToString());
            }
            if (drpMacType.Text != "")
            {
                tempStr += " AND Machine = " + SysString.ToDBString(drpMacType.Text.ToString());
            }
            if (drpNeedle.Text != "")
            {
                tempStr += " AND Needie = " + SysString.ToDBString(drpNeedle.Text.ToString());
            }
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            MachineManageRule rule = new MachineManageRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            MachineManageRule rule = new MachineManageRule();
            MachineManage entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_MachineManage";
            this.HTDataList = gridView1;

            Common.BindCLS(drpNeedle, "Ship_SOutContract", "Needle", true);//针型
            Common.BindCLS(drpMachineType, "frmSampleTecEdit", "NeedleType", true);//机型
            Common.BindCLS(drpMacType, "Pro_Sample", "MacType", true);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private MachineManage EntityGet()
        {
            MachineManage entity = new MachineManage();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
        #region  导出列表权限
        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限6))
            {
                this.ShowMessage("你没有此操作权限");
                return;
            }
            base.btnToExcel_Click(sender, e);
        }

        //public override void btnToExcelAdv_Click(object sender, EventArgs e)
        //{
        //    if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限6))
        //    {
        //        this.ShowMessage("你没有此操作权限");
        //        return;
        //    }
        //    base.btnToExcel_Click(sender, e);
        //}
        #endregion
    }
}