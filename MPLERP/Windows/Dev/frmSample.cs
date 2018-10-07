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
    public partial class frmSample : frmAPBaseUIForm
    {
        public frmSample()
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

            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
            }
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//销售订单业务员只查看自己的的订单
            {
                tempStr += " AND SaleOPID IN(" + WCommon.GetStructureMemberOPStr() + ")";
            }

           // tempStr += " AND SampleType=" + FormListBID;//打样类型
            tempStr += " AND SOType=" + FormListAID;//订单类型

            tempStr += " ORDER BY FormNo DESC";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            SampleRule rule = new SampleRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
            ProcessGrid.SetGridEdit(gridView1, new string[] { "EventStatus" }, true);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            SampleRule rule = new SampleRule();
            Sample entity = EntityGet();
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
            this.HTDataTableName = "Dev_Sample";
            this.HTDataList = gridView1;
            Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            this.ToolBarItemAdd(28, "btnSave", "保存状态", false, btnSaveStatus_Click);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Sample EntityGet()
        {
            Sample entity = new Sample();
            entity.ID = HTDataID;      
            return entity;
        }

        public void btnSaveStatus_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                int DtsID = 0;
                string Status = string.Empty;
                string sql = string.Empty;
                int Num = 0;
                SampleDtsRule rule = new SampleDtsRule();
                SampleDts entityDts = new SampleDts();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                   DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DtsID"));
                   Status = SysConvert.ToString(gridView1.GetRowCellValue(i, "EventStatus"));
                   sql = "Update Dev_SampleDts set EventStatus=" + SysString.ToDBString(Status);
                   if (entityDts.EventStatus != Status)
                   {
                       sql += " where ID=" + DtsID;
                       SysUtils.ExecuteNonQuery(sql);
                       Num++;
                   }

                }
                if (Num > 0)
                {
                    this.ShowInfoMessage(Num.ToString() + "条状态更新成功");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

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

        private void drpSaleOPID_EditValueChanged(object sender, EventArgs e)
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

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "EventStatus")
                {
                    string Status = SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "EventStatus"));
                    if (Status == "新任务")//新任务
                    {
                        e.Appearance.BackColor = Color.White;
                    }
                    if (Status == "处理中")//处理中
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    if (Status == "完成")//处理完成
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
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