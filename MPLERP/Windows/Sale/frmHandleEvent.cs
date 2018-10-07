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
    public partial class frmHandleEvent : frmAPBaseUISin
    {
        public frmHandleEvent()
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
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (SysConvert.ToInt32(txtEventStatus.EditValue)!=0)
            {
                tempStr += " AND EventStatus=" + SysConvert.ToInt32(txtEventStatus.EditValue);
            }
            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }
            if (chkRDate.Checked)
            {
                tempStr += " AND RDate BETWEEN " + SysString.ToDBString(txtRDateS.DateTime) + " AND " + SysString.ToDBString(txtRDateE.DateTime);
            }
            if (checkSef.Checked && !FParamConfig.LoginHTFlag)
            {
                tempStr += " AND MakeOPID=" + SysString.ToDBString(FParamConfig.LoginName);
            }
            if (drpVendorID.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorID LIKE " + SysString.ToDBString("%" + drpVendorID.Text.Trim() + "%");
            }
       
            tempStr += " ORDER BY FormNo DESC ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            HandleEventRule rule = new HandleEventRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "EventStatus" }, true);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            HandleEventRule rule = new HandleEventRule();
            HandleEvent entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_HandleEvent";
            this.HTDataList = gridView1;
            txtMakeDateS.DateTime = DateTime.Now.Date.AddMonths(-1);
            txtMakeDateE.DateTime = DateTime.Now.Date;
            txtRDateS.DateTime = DateTime.Now.Date.AddDays(10);
            txtRDateE.DateTime = DateTime.Now.Date.AddDays(30);
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            this.ToolBarItemAdd(29, ToolButtonName.btnLoad.ToString(), "保存状态", false, btnSaveStatus_Click);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private HandleEvent EntityGet()
        {
            HandleEvent entity = new HandleEvent();
            entity.ID = HTDataID;      
            return entity;
        }

        public void btnSaveStatus_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                int ID =SysConvert.ToInt32( gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                int Status = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "EventStatus"));
                HandleEventRule rule = new HandleEventRule();
                HandleEvent entity = new HandleEvent();
                entity.ID = ID;
                entity.SelectByID();
                if (entity.EventStatus!=Status)
                {
                    entity.EventStatus = Status;
                    rule.RUpdate(entity);
                    this.ShowInfoMessage("状态更新成功");
                }
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                 DateTime RDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, "RDate"));//获得提醒时间
                if (e.Column.FieldName=="EventStatus")
                {
                    int Status = SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "EventStatus")); 
                    if (Status==2)//处理中
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    if (Status==3)//处理完成
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                }
                if (e.Column.FieldName == "RDate") 
                {
                    int Status = SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "EventStatus")); 
                    if (RDate == DateTime.Now.Date.AddDays(3) && Status!=3) 
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                    if (RDate <= DateTime.Now.Date && Status != 3)
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}