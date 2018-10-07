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
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：出入库报表
    /// </summary>
    public partial class frmYarnInOutWHRpt : frmAPBaseUIRpt
    {
        public frmYarnInOutWHRpt()
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

            if (SysConvert.ToString(drpQVendorID.EditValue) == "")
            {
                this.ShowMessage("请选择加工厂");
                return;
            }
            tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));

            if (chkQFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQFormDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQFormDateE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }





            //tempStr += Common.GetWHRightCondition();

             
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            IOFormDtsRule rule = new IOFormDtsRule();
            gridView1.GridControl.DataSource = rule.RShowIO(HTDataConditionStr + " AND HeadType=14 AND SubmitFlag=1 ORDER BY FormDate DESC ", ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
            BindGrid2();
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public void BindGrid2()
        {
            IOFormDtsRule rule = new IOFormDtsRule();
            DataTable dt = rule.RShowIO(HTDataConditionStr + " AND HeadType=13 AND SubmitFlag=1 ORDER BY FormDate DESC ", ProcessGrid.GetQueryField(gridView2));
            Proc(dt);
            
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }
        private void Proc(DataTable p_dt)
        {
            string sql = "select * from WH_YarnTiaoPing where 1=1 " + HTDataConditionStr;
            DataTable dt = SysUtils.Fill(sql);
            foreach (DataRow dr in dt.Rows)
            {
                DataRow p_dr = p_dt.NewRow();
                p_dr["VendorID"] = dr["VendorID"].ToString();
                p_dr["FormDate"] = SysConvert.ToDateTime(dr["FormDate"]);
                p_dr["Qty"] = SysConvert.ToString(dr["Qty"]);
                p_dr["Remark"] = dr["Remark"].ToString();
                p_dr["MakeOPName"] = dr["MakeOPName"].ToString();
                p_dr["FormNM"] = "调平";
                p_dt.Rows.Add(p_dr);
            }
            
            
        }
        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };
            txtQFormDateS.DateTime = DateTime.Now.AddDays(0 - ParamConfig.QueryDayNum);
            txtQFormDateE.DateTime = DateTime.Now.Date;

            //Common.BindVendor(drpQVendorID, "WH_IOForm", "VendorID", true);

            DevMethod.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.染厂, (int)EnumVendorType.加工户, (int)EnumVendorType.织厂, (int)EnumVendorType.其他加工厂 }, true);


             
            Common.BindCLS(drpQWHPosition, "WH_WH", "WHID", false);//绑定仓库位置




            //txtQFormNo_EditValueChanged(null, null);
            //InOutWHStatus.ColorIniTextBox(groupControlSOColor);
        }

        #endregion


        #region 其他事件
        /// <summary>
        /// 颜色变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                //int WHFormTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "WHFormTypeID"));
                //e.Appearance.BackColor = InOutWHStatus.GetGridRowBackColor(WHFormTypeID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQFormNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetCondtion();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void txtQItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

                txtQFormNo_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmMakeYarnTP frm = new frmMakeYarnTP();
                if (SysConvert.ToString(drpQVendorID.EditValue) == "")
                {
                    this.ShowMessage("请选择加工厂");
                    return;
                }
                frm.VendorID = SysConvert.ToString(drpQVendorID.EditValue);
                frm.ShowDialog();
                btnQuery_Click(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
                return;
            }
        }




    }
}