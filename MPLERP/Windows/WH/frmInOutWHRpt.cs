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
    public partial class frmInOutWHRpt : frmAPBaseUIRpt
    {
        public frmInOutWHRpt()
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
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
           
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
           
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }
            if (txtQItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
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
            if (txtQFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtQFormNo.Text.Trim() + "%");
            }
            if (chkQFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQFormDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQFormDateE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }
            //if (chkLocalWH.Checked)//只查寄存为否的库
            //{
            //    tempStr += " AND WHID IN( SELECT WHID FROM WH_WH WHERE ISJK = 0) ";
            //}
            //if (drpQWHPosition.Text == "本厂")
            //{
            //    tempStr += " AND WHID IN( SELECT WHID FROM WH_WH WHERE ISJK = 0) ";
            //}
            //else if (drpQWHPosition.Text == "染厂")
            //{
            //    tempStr += " AND WHID IN( SELECT WHID FROM WH_WH WHERE ISNULL(ISJK,0) = 1) ";
            //}
            switch (drpQWHFormTypeID.SelectedIndex)
            {
                case 1:
                    //tempStr += " AND WHFormTypeID=1";
                    tempStr += " AND SubType IN(SELECT Code FROM Enum_FormList WHERE FormNM LIKE '%入库'  AND ParentID<>9)";//入库
                    break;
                case 2:
                    tempStr += " AND SubType IN(SELECT Code FROM Enum_FormList WHERE FormNM LIKE '%出库')";//出库
                    break;
                case 3:
                    tempStr += " AND SubType IN(SELECT Code FROM Enum_FormList WHERE FormNM LIKE '%期初入库')";//期初入库
                    break;
                case 4:
                    tempStr += " AND SubType IN(SELECT Code FROM Enum_FormList WHERE FormNM LIKE '%移库')";//移库
                    break;
                case 5:
                    tempStr += " AND SubType IN(SELECT Code FROM Enum_FormList WHERE FormNM LIKE '%盘点' )";//盘点
                    break;
            }
            switch (drpQSubmitFlagType.SelectedIndex)
            {
                case 1:
                    tempStr += " AND isnull(SubmitFlag,0)=1";
                    break;
                case 2:
                    tempStr += " AND isnull(SubmitFlag,0)=0";
                    break;
            }

            switch (drpQDelFlagType.SelectedIndex)
            {
                case 1:
                    tempStr += " AND isnull(DelFlag,0)=0";
                    break;
                case 2:
                    tempStr += " AND isnull(DelFlag,0)=1";
                    break;
            }


            tempStr += Common.GetWHRightCondition();

            //switch (this.FormListAID)//判断是原料还是辅料/ItemTypeID 1原料 2辅料 3成衣 4 机物料 5 目录 6 色卡 7 只片 
            //{
            //    case 0://原料
            //        tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=1)";
            //        break;
            //    case 1://辅料
            //        tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=2)";
            //        break;
            //    case 2://成衣
            //        tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=3)";
            //        break;
            //    case 3://机物料
            //        tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=4)";
            //        break;
            //    default:
            //        tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=1)";
            //        break;
            //}

            tempStr += " ORDER BY FormDate DESC ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            IOFormDtsRule rule = new IOFormDtsRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;

            txtQFormDateS.DateTime = DateTime.Now.AddDays(0 - ParamConfig.QueryDayNum);
            txtQFormDateE.DateTime = DateTime.Now.Date;

            //Common.BindVendor(drpQVendorID, "WH_IOForm", "VendorID", true);
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂 }, true);//客户 

         
            Common.BindAllWH(drpQWHID,true);


            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂 }, true);//客户 
            Common.BindCLS(drpQWHPosition, "WH_WH", "WHID",false);//绑定仓库位置

            drpQWHPosition.EditValue = "本厂";

            switch (this.FormListAID)//判断是原料还是辅料/ItemTypeID 1原料 2辅料 3成衣 4 机物料 5 目录 6 色卡 7 只片 
            {
                case 0://纱线
                    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.面料 }, true, true);
                    break;
                //case 1://辅料
                //    new ItemProcLookUp(drpQItemCode, new int[] {(int)EnumItemType.辅料 }, true, true);
                //    break;
                //case 2://成衣
                //    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.成衣 }, true, true);
                //    break;
                //case 3://机物料
                //    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.药剂 }, true, true);
                //    break;
                //default:
                //    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.纱线, (int)EnumItemType.辅料, (int)EnumItemType.成衣, (int)EnumItemType.药剂 }, true, true);
                //    break;
            }

            txtQFormNo_EditValueChanged(null,null);
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
                txtQItemName.Text = "";
                txtQItemStd.Text = "";
                txtQItemModel.Text = "";
                string sql = "SELECT ItemName,ItemStd,ItemAttnCode,ItemModel FROM Data_Item WHERE 1=1 AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text.Trim());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    txtQItemName.Text = dt.Rows[0]["ItemName"].ToString();
                    txtQItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
                    txtQItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
                }
                txtQFormNo_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }




    }
}