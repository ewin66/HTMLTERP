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
    public partial class frmSampleSale : frmAPBaseUIForm
    {
        public frmSampleSale()
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
            if (txtFormNo.Text.Trim() != "")
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpSampleType.EditValue)!="")
            {
                tempStr = " AND SampleType = " + SysString.ToDBString(SysConvert.ToString(drpSampleType.EditValue));
            }
            if (SysConvert.ToString(drpMakeOPID.EditValue) != "")
            {
                tempStr += "AND MakeOPID LIKE" + SysString.ToDBString("%" + SysConvert.ToString(drpMakeOPID.EditValue) + "%");
            }
            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            SampleSaleRule rule = new SampleSaleRule();
            gridView1.GridControl.DataSource=rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();

            //ProcessGrid.SetGridEdit(gridView1, new string[] { "FinishedFlag" }, true); 
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            SampleSaleRule rule = new SampleSaleRule();
            SampleSale entity = EntityGet();
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
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "FinishedFlag" }, true);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SampleSale";
            this.HTDataList = gridView1;
            Common.BindOP(drpMakeOPID, true);
            Common.BindSampleType(drpSampleType, true);


            Common.BindSubmitFlag(drpGridSubmitFlag, true);

            txtMakeDateS.DateTime = DateTime.Now.AddDays(-15).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;



            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
        }
        

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SampleSale EntityGet()
        {
            SampleSale entity = new SampleSale();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        /// <summary>
        /// 勾选完成标志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFinishedFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }




                this.BaseFocusLabel.Focus();

                if (SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SubmitFlag")) == 0)
                {                   
                    this.ShowMessage("此单据未提交,不能勾选完成！");
                    return;
                }



                string sql = "Update Sale_SampleSaleDts set FinishedFlag =" + SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FinishedFlag"));              
                sql += " Where ID = " + SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                SysUtils.ExecuteNonQuery(sql);
                MessageBox.Show("修改成功！");

                BindGrid();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}