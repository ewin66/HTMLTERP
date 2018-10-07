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
    public partial class frmShipmentDtsLoad : frmAPBaseLoad
    {
        public frmShipmentDtsLoad()
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
            if (txtCode.Text.Trim() != "")
            {
                tempStr += " AND Code LIKE " + SysString.ToDBString("%" + txtCode.Text.Trim() + "%");
            }
            if (chkShipDate.Checked)
            {
                tempStr += " AND ShipDate BETWEEN " + SysString.ToDBString(txtQShipDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQShipDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (SysConvert.ToString(drpQSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(SysConvert.ToString(drpQSaleOPID.EditValue));
            }
            if (SysConvert.ToString(drpQShipTypeID.EditValue) != "")
            {
                tempStr += " AND ShipTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQShipTypeID.EditValue));
            }
            if (SysConvert.ToString(drpQCompanyTypeID.EditValue) != "")
            {
                tempStr += " AND CompanyTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQCompanyTypeID.EditValue));
            }
         
            tempStr += " ORDER BY Code ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ShipmentRule rule = new ShipmentRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTLoadConditionStr + HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", " 0 AS SelectFlag"));
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
                    string sSeq = "";
                    string StrWhere = "";
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["SelectFlag"])) == 1)
                        {
                            if (sID != "")//条件不为空
                            {
                                sID += ",";
                            }
                            sID += SysConvert.ToString(gridView1.GetRowCellValue(i, "ID"));
                            if (sSeq != "")//条件不为空
                            {
                                sSeq += ",";
                            }
                            sSeq += SysConvert.ToString(gridView1.GetRowCellValue(i, "Seq"));
                            if (StrWhere != "")//条件不为空
                            {
                                StrWhere += " or ";
                            }
                            StrWhere += "(MainID=" + SysConvert.ToString(gridView1.GetRowCellValue(i, "ID")) + " AND Seq=" + SysConvert.ToString(gridView1.GetRowCellValue(i, "Seq")) + ")";

                        }
                    }
                    if (StrWhere != "")
                    {
                        HTLoadData.Add(new string[] { sID });
                        //HTLoadData.Add(new string[] { sSeq });
                        //HTLoadData.Add(new string[] { StrWhere });
                    }

                }
            }
        }
        
        // /// <summary>
        ///// 设置定位数据及状态
        ///// </summary>
        ///// <param name="p_ID">ID</param>
        //public override void SetPosStatus(int p_ID)
        //{
        //    int tempID = HTDataID;
        //    BindGrid();
        //    ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        //}
        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_Shipment";
            this.HTDataList = gridView1;


            txtQShipDateE.DateTime = DateTime.Now.Date;
            txtQShipDateS.DateTime = DateTime.Now.Date.AddDays(0 - ParamConfig.QueryDayNum);


            Common.BindCompanyType(drpQCompanyTypeID, true);//绑定公司别
            Common.BindOPID(drpQSaleOPID, true);//业务员
            Common.BindSubType(drpQShipTypeID, 6, true);//绑定发货类型
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.工厂, (int)EnumVendorType.客户 }, true);//客户
            txtCode_EditValueChanged(null,null);
        }
        /// <summary>
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }
        #endregion

        #region 自定义方法
      
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_EditValueChanged(object sender, EventArgs e)
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
        #endregion

      
    }
}