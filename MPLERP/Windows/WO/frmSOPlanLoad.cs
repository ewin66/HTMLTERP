using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
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
    public partial class frmSOPlanLoad : frmAPBaseLoad
    {
        public frmSOPlanLoad()
        {
            InitializeComponent();
        }


  
        #region   全局变量
        string sSO = string.Empty;
        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (!Common.CheckLookUpEditBlank(drpQCompanyTypeID))
            {
                tempStr += " AND CompanyTypeID = " + SysString.ToDBString(drpQCompanyTypeID.EditValue.ToString());
            }

            if (chkInDate.Checked)
            {
                tempStr += " AND InDate BETWEEN " + SysString.ToDBString(txtQInDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQInDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");

            }
            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(drpQVendorID.EditValue.ToString());
            }
            if (!Common.CheckLookUpEditBlank(drpQSaleOPID))
            {
                tempStr += " AND MakeOPID = " + SysString.ToDBString(drpQSaleOPID.EditValue.ToString());
            }
            if (txtQSO.Text.Trim() != "")
            {
                tempStr += " AND SO LIKE " + SysString.ToDBString("%"+txtQSO.Text.Trim() + "%");
            }
            if (txtCode.Text.Trim() != "")
            {
                tempStr += " AND Code LIKE" + SysString.ToDBString("%" + txtCode.Text.Trim() + "%");
            }
            if (chkInDate.Checked)
            {
                tempStr += " AND InDate BETWEEN " + SysString.ToDBString(txtQInDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQInDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");

            }
            tempStr += "ORDER BY Code DESC ";
            HTDataConditionStr = tempStr;
        }


        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            SOPlanRule rule = new SOPlanRule();
            gridView1.GridControl.DataSource = rule.RShow(HTLoadConditionStr + HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", " 0 AS SelectFlag"));
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();
            if (HTDataList.FocusedRowHandle >= 0)
            {
                if (HTDataList.FocusedRowHandle >= 0)
                {
                    HTLoadData.Clear();
                    string sID = "";
              
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["SelectFlag"])) == 1)
                        {
                            if (sID != "")//条件不为空
                            {
                                sID += ",";
                            }
                            sID += SysConvert.ToString(gridView1.GetRowCellValue(i, "ID"));
                        }
                    }
                    if (sID != "")
                    {
                        HTLoadData.Add(new string[] { sID });
                    }

                }
            }
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SO";
            this.HTDataList = gridView1;

            txtQInDateS.DateTime = DateTime.Now.AddDays(0 - ParamConfig.QueryDayNum);
            txtQInDateE.DateTime = DateTime.Now.Date;         

            //Common.BindOPID(drpQSaleOPID, true);
            //Common.BindCompanyType(drpQCompanyTypeID, true);
            //Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.客户 }, true);//客户
            txtQSO_EditValueChanged(null,null);

        }

        /// <summary>
        /// 初始化刷新数据(窗体加载时或用户刷新按钮时调用)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindOPID(drpQSaleOPID, true);
            Common.BindCompanyType(drpQCompanyTypeID, true);
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.客户 }, true);//客户
        }


        /// <summary>
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }
        #endregion

        #region 其他事件
        /// <summary>
        /// 勾选校验同一系列号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSelectFlag_EditValueChanged(object sender, EventArgs e)
        {
            this.BaseFocusLabel.Focus();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["SelectFlag"])) == 1)
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SOID")) != SysConvert.ToString(gridView1.GetRowCellValue(i, "SOID")))
                    {
                        this.ShowMessage("请加载同一订单的数据");
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag", "0");
                        return;
                    }
                }
            }
        }
        #endregion

        private void txtQSO_EditValueChanged(object sender, EventArgs e)
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