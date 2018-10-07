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
using DevComponents.DotNetBar;

namespace MLTERP
{
    public partial class frmColorCard : frmAPBaseUIForm
    {
        public frmColorCard()
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
            if (txtFormNo.Text.Trim() !=  string .Empty)
            {
                tempStr += " and FormNO Like " + SysString.ToDBString("%" + txtFormNo.Text.Trim() +"%"); 
            }
            if (Convert.ToString( drpShopID.EditValue) != string.Empty)
            {
                tempStr += " and ShopID =  " + SysString.ToDBString(drpShopID.EditValue.ToString());
            }
            
            if(Convert.ToString( drpVendorID.EditValue) != string.Empty)
            {
                tempStr += " and VendorID = " + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (chkOrderDate.Checked)
            {
                tempStr += " and FormDate Between " + SysString.ToDBString(begintime.DateTime) + " and " + SysString.ToDBString(endtime.DateTime );
            }
            if (chkFinishFlag.Checked)
            {
                //tempStr += " AND FinishDate IS NOT NULL";
            }

            //
            tempStr += " AND SampleType = " + this.FormListAID;//1: L/D样    2：S/O样
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ColorCardRule rule = new ColorCardRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ColorCardRule rule = new ColorCardRule();
            ColorCard entity = EntityGet();
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
            this.HTDataTableName = "Dev_ColorCard";
            this.HTDataList = gridView1;
            begintime.DateTime = DateTime.Now.AddDays(-15).Date;
            endtime.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindVendor(drpShopID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.染厂, (int)EnumVendorType.其他加工厂}, true);
            Common.BindOP(drpResScrapSampleNo, true);
            this.ToolBarItemAdd(32, "btnUpdateColorStatus", "修改色卡状态", true, btnUpdateColorStatus_Click, eShortcut.None);
            if (ColorCardStatusProc.ColorIniFlag)
            {
                ucStatusBarStand1.UCDataSource = ColorCardStatusProc.ColorStatusDt;
                ucStatusBarStand1.UCAct();
            }

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 修改色卡状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateColorStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("没有此权限，请联系管理员");
                    return;
                }
                //1: L/D样    2：S/D样
                if (this.FormListAID == 1)
                {
                    frmUpdateColorCardStatus frm = new frmUpdateColorCardStatus();
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.Location = new Point(400, 280);
                    frm.DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                    frm.ShowDialog();
                    btnQuery_Click(null, null);
                    ProcessGrid.GridViewFocus(gridView1, new string[1] { "DtsID" }, new string[1] { frm.DtsID.ToString() });
                }
                else if (this.FormListAID == 2)
                {
                    frmUpdateColorCardStatusSD frm = new frmUpdateColorCardStatusSD();
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.Location = new Point(400, 280);
                    frm.DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                    frm.ShowDialog();
                    btnQuery_Click(null, null);
                    ProcessGrid.GridViewFocus(gridView1, new string[1] { "DtsID" }, new string[1] { frm.DtsID.ToString() });
                }

                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ColorCard EntityGet()
        {
            ColorCard entity = new ColorCard();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion


        #region 其它事件


        /// <summary>
        /// 颜色变化 方法重载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void _HTDataDts_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                base._HTDataDts_RowCellStyle(sender, e);
                if (e.Column.FieldName == "ColorCardStatusName")
                {
                    e.Appearance.BackColor = ColorCardStatusProc.GetGridRowBackColor(SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "ColorCardStatusID")));
                }

                //if (e.Column.FieldName == "FormNo")
                //{
                //    if(SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle,"CapFlag"))==1)
                //    {
                //        e.Appearance.BackColor = Color.LightBlue;
                //    }
                //}

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

    }
}