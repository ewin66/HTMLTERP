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
    /// <summary>
    /// 功能：加载采购单明细
    /// </summary>
    public partial class frmIOFormLoad : frmAPBaseLoad
    {
        public frmIOFormLoad()
        {
            InitializeComponent();
        }


  
        #region   全局变量
        string sSO = string.Empty;
        #endregion

        #region 属性
         private int m_LoadFormID = 0;//窗体的菜单ID

        public int LoadFormID
        {
            get { return m_LoadFormID; }
            set { m_LoadFormID = value; }
        }
        private int m_LoadFormAID = 0;//窗体大类

        public int LoadFormAID
        {
            get { return m_LoadFormAID; }
            set { m_LoadFormAID = value; }
        }

        private string m_VendorID =string.Empty;//窗体大类
        public string VendorID
        {
            get { return m_VendorID; }
            set { m_VendorID = value; }
        }

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
            if (chkQFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQFormDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQFormDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
           if(SysConvert.ToString(drpQBuyOPID.EditValue)!="")
           {
               tempStr += " AND DutyOP=" + SysString.ToDBString(SysConvert.ToString(drpQBuyOPID.EditValue));
           }
            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(drpQVendorID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpQWHFormTypeID.EditValue) == "只查询入库")
            {
                tempStr += " AND SubType IN(300,301,302,303,304,501,503,504,506,507)";
            }
            if (SysConvert.ToString(drpQWHFormTypeID.EditValue) == "只查询出库")
            {
                tempStr += " AND SubType IN(402,504,601)";
            }
            if (!Common.CheckLookUpEditBlank(drpQYarnYtpeID))
            {
                tempStr += " AND YarnTypeID = " + SysString.ToDBString(drpQYarnYtpeID.EditValue.ToString());
            }
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode =" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (txtQColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtQColorName.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != "")
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQBatch.Text.Trim() != "")
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtQBatch.Text.Trim() + "%");
            }
            if (txtQVendorBatch.Text.Trim() != "")
            {
                tempStr += " AND VendorBatch LIKE " + SysString.ToDBString("%" + txtQVendorBatch.Text.Trim() + "%");
            }
            if (txtQFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtQFormNo.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
            HTDataConditionStr = tempStr;
        }


        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            IOFormRule rule = new IOFormRule();
            gridView1.GridControl.DataSource = rule.RIOFormShow(HTLoadConditionStr + HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", " 0 AS SelectFlag"));
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
                            if (LoadFormID == 8831)
                            {
                                StrWhere += "(IOFormID=" + SysConvert.ToString(gridView1.GetRowCellValue(i, "ID")) + " AND IOFormSeq=" + SysConvert.ToString(gridView1.GetRowCellValue(i, "Seq")) + ")";
                            }
                            else
                            {
                                StrWhere += "(MainID=" + SysConvert.ToString(gridView1.GetRowCellValue(i, "ID")) + " AND Seq=" + SysConvert.ToString(gridView1.GetRowCellValue(i, "Seq")) + ")";
                            }
                        }
                    }
                    if (StrWhere != "")
                    {
                        HTLoadData.Add(new string[] { sID });
                        HTLoadData.Add(new string[] { sSeq });
                        HTLoadData.Add(new string[] { StrWhere });
                    }

                }
            }
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Buy_YarnCompact";
            this.HTDataList = gridView1;

            txtQFormDateS.DateTime = DateTime.Now.AddDays(0 - ParamConfig.QueryDayNum);
            txtQFormDateE.DateTime = DateTime.Now.Date;     
            //Common.BindWHType(drpQWHTypeID, false);
            Common.BindWH(drpQWHID, true);
            new ItemProcLookUp(drpQItemCode, new int[] {  (int)EnumItemType.面料 }, true, true);
            Common.BindOPID(drpQBuyOPID, true);
            Common.BindCompanyType(drpQCompanyTypeID, true);
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂}, true);//客户
            Common.BindYarnType(drpQYarnYtpeID, true);//纱类
            Common.BindWHType(drpGridSubType, false);//仓库类型
            Common.BindWH(drpGridWHID, false);//仓库
            Common.BindCompanyType(drpGridCompanyTypeID, false);//公司别

            if (LoadFormID == 8831&&LoadFormAID==1)//进项对账
            {
                drpQWHFormTypeID.EditValue = "只查询入库";
                drpQWHFormTypeID.Properties.ReadOnly = true;
            }
            else if (LoadFormID == 8831 && LoadFormAID == 2)//销项对账
            {
                drpQWHFormTypeID.EditValue = "只查询出库";
                drpQWHFormTypeID.Properties.ReadOnly = true;
            }

            if (m_VendorID != "")
            {
                drpQVendorID.EditValue = m_VendorID;
            }

            txtQCode_EditValueChanged(null,null);
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
            //this.BaseFocusLabel.Focus();
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["SelectFlag"])) == 1)
            //    {
            //        if (SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO")) != SysConvert.ToString(gridView1.GetRowCellValue(i, "SO")))
            //        {
            //            this.ShowMessage("请加载同一大货系列号的数据");
            //            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag", "0");
            //            return;
            //        }
            //    }
            //}
        }

        private void txtQCode_EditValueChanged(object sender, EventArgs e)
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