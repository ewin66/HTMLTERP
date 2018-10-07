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
    /// 功能：库存预警报表
    /// </summary>
    public partial class frmWHALarmRpt : frmAPBaseUIRpt
    {
        public frmWHALarmRpt()
        {
            InitializeComponent();
        }


        #region 全局变量
        string conditionstr2 = string.Empty;

        int saveAlarmPer = 0;//预警百分比
        string saveWHID = string.Empty;//预警库
        int saveWHTypeID = 0;//预警仓库类型

        #endregion


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            //if (!Common.CheckLookUpEditBlank(drpQWHAlarmID))
            //{
            //    tempStr += " AND WHAlarmID = " + SysString.ToDBString(drpQWHAlarmID.EditValue.ToString());
            //}
            //else
            //{
            //    this.ShowMessage("请选择预警类型");
            //    drpQWHAlarmID.Focus();
            //    return;
            //}
            if (txtQItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }
            if (txtQItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }

            tempStr += " AND WHAlarmID IN(SELECT ID FROM WH_WHAlarm WHERE 1=1 AND ItemTypeID=" + FormListAID + ")";

            HTDataConditionStr = tempStr;
        }


        /// <summary>
        /// 获得查询条件
        /// </summary>
        private void GetCondition2()
        {
            string outstr = string.Empty;
            if (saveWHID == string.Empty)
            {
                outstr += " AND WHID IN(SELECT WHID FROM WH_WH WHERE WHTypeID=" + saveWHTypeID + ")";
            }
            else
            {
                outstr += " AND WHID=" + SysString.ToDBString(saveWHID);
            }
            conditionstr2 = outstr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            //WHALarmDtsRule rule = new WHALarmDtsRule();
            //gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            //gridView1.GridControl.Show();

            gridView1.GridControl.DataSource = SysUtils.Fill(GetLow());
            gridView1.GridControl.Show();
            gridView2.GridControl.DataSource = SysUtils.Fill(GetHigh());
            gridView2.GridControl.Show();
        }




        private string GetHigh()
        {
            decimal lowper = 1m - saveAlarmPer / 100m;
            string outstr = string.Empty;
            outstr += "SELECT Z.* FROM ";
            outstr += "(SELECT A.*,B.SQty Qty,C.ItemModel FROM ";//查询总表
            if (SysConvert.ToInt32(drpQWHAlarmID.EditValue) == (int)WHAlarmType.坯纱预警)
            {
                outstr += " ( SELECT ID,WHAlarmID,ItemCode,ItemStd,ItemName,AlarmHighQty FROM UV1_WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmHighQty>0) AS A LEFT OUTER JOIN";//预警设置表

                outstr += " ( SELECT ItemCode,SUM(Qty) SQty FROM WH_Storge WHERE ItemCode IN ";//当前库存表
                outstr += "  ( SELECT ItemCode FROM WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmHighQty>0) " + conditionstr2 + "  GROUP BY ItemCode) AS B";

                outstr += "  ON A.ItemCode=B.ItemCode  ";
            }
            else if (SysConvert.ToInt32(drpQWHAlarmID.EditValue) == (int)WHAlarmType.色纱预警)
            {
                outstr += " ( SELECT ID,WHAlarmID,ItemCode,ItemStd,ItemName,AlarmHighQty,ColorName FROM UV1_WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmHighQty>0) AS A LEFT OUTER JOIN";//预警设置表

                outstr += " ( SELECT ItemCode,SUM(Qty) SQty,ColorName FROM WH_Storge WHERE ItemCode+ColorName IN ";//当前库存表
                outstr += "  ( SELECT ItemCode+ColorName FROM UV1_WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmHighQty>0) " + conditionstr2 + "  GROUP BY ItemCode,ColorName) AS B";

                outstr += "  ON A.ItemCode=B.ItemCode AND A.ColorName=B.ColorName ";
            }
            else if (SysConvert.ToInt32(drpQWHAlarmID.EditValue) == (int)WHAlarmType.原料预警)
            {
                outstr += " ( SELECT ID,WHAlarmID,ItemCode,ItemStd,ItemName,AlarmHighQty,ColorName FROM UV1_WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmHighQty>0) AS A LEFT OUTER JOIN";//预警设置表

                outstr += " ( SELECT ItemCode,SUM(Qty) SQty,ColorName FROM WH_Storge WHERE ItemCode+ColorName IN ";//当前库存表
                outstr += "  ( SELECT ItemCode+ColorName FROM UV1_WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmHighQty>0) " + conditionstr2 + "  GROUP BY ItemCode,ColorName) AS B";

                outstr += "  ON A.ItemCode=B.ItemCode AND A.ColorName=B.ColorName ";
            }

            outstr += " LEFT OUTER JOIN (SELECT ItemCode,ItemModel FROM Data_Item ) AS C";
            outstr += " ON A.ItemCode=C.ItemCode";

            outstr += ") AS Z";// WHERE   ISNULL(Qty,0)>=AlarmHighQty*" + lowper;//大于最高库存数

            switch (drpQueryType.SelectedIndex)
            {
                case 0://查询全部设置预警库存
                    break;
                case 1://只查询预警及超过安全数
                    outstr += " WHERE  ISNULL(Qty,0)>=AlarmHighQty*" + lowper;
                    break;
                case 2://只查询预警安全数
                    outstr += " WHERE ISNULL(Qty,0)<AlarmHighQty AND ISNULL(Qty,0)>=AlarmHighQty*" + lowper;
                    break;
                case 3://只查询超过安全数
                    outstr += " WHERE  ISNULL(Qty,0)>=AlarmHighQty";
                    break;
            }
            return outstr;
        }

        private string GetLow()
        {
            decimal lowper = 1m + saveAlarmPer / 100m;
            string outstr = string.Empty;
            outstr += "SELECT Z.* FROM ";
            outstr += "(SELECT A.*,B.SQty Qty,C.ItemModel FROM ";//查询总表


            //if (FormListAID == (int)WHAlarmType.坯纱预警)
            if (SysConvert.ToInt32(drpQWHAlarmID.EditValue) == (int)WHAlarmType.坯纱预警)
            {
                outstr += " ( SELECT ID,WHAlarmID,ItemCode,ItemStd,ItemName,AlarmLowQty FROM UV1_WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmLowQty>0 ) AS A LEFT OUTER JOIN";//预警设置表

                outstr += " ( SELECT ItemCode,SUM(Qty) SQty FROM WH_Storge WHERE ItemCode IN ";//当前库存表
                outstr += "  ( SELECT ItemCode FROM UV1_WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmLowQty>0) " + conditionstr2 + "  GROUP BY ItemCode) AS B";

                outstr += "  ON A.ItemCode=B.ItemCode ";
            }
            else if (SysConvert.ToInt32(drpQWHAlarmID.EditValue) == (int)WHAlarmType.色纱预警)
            {
                outstr += " ( SELECT ID,WHAlarmID,ItemCode,ItemStd,ItemName,AlarmLowQty,ColorName FROM UV1_WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmLowQty>0 ) AS A LEFT OUTER JOIN";//预警设置表

                outstr += " ( SELECT ItemCode,SUM(Qty) SQty,ColorName FROM WH_Storge WHERE ItemCode+ColorName IN ";//当前库存表
                outstr += "  ( SELECT ItemCode+ColorName FROM UV1_WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmLowQty>0) " + conditionstr2 + "  GROUP BY ItemCode,ColorName) AS B";

                outstr += "  ON A.ItemCode=B.ItemCode AND A.ColorName=B.ColorName";
            }
            else if (SysConvert.ToInt32(drpQWHAlarmID.EditValue) == (int)WHAlarmType.原料预警)
            {
                outstr += " ( SELECT ID,WHAlarmID,ItemCode,ItemStd,ItemName,AlarmLowQty,ColorName FROM UV1_WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmLowQty>0 ) AS A LEFT OUTER JOIN";//预警设置表

                outstr += " ( SELECT ItemCode,SUM(Qty) SQty,ColorName FROM WH_Storge WHERE ItemCode+ColorName IN ";//当前库存表
                outstr += "  ( SELECT ItemCode+ColorName FROM UV1_WH_WHAlarmDts WHERE 1=1 " + HTDataConditionStr + "  AND AlarmLowQty>0) " + conditionstr2 + "  GROUP BY ItemCode,ColorName) AS B";

                outstr += "  ON A.ItemCode=B.ItemCode AND A.ColorName=B.ColorName";
            }

            outstr += " LEFT OUTER JOIN (SELECT ItemCode,ItemModel FROM Data_Item ) AS C";
            outstr += " ON A.ItemCode=C.ItemCode";

            outstr += ") AS Z";// WHERE  ISNULL(Qty,0)<=AlarmLowQty*" + lowper;//小于最低库存数
            switch (drpQueryType.SelectedIndex)
            {
                case 0://查询全部设置预警库存
                    break;
                case 1://只查询预警及超过安全数
                    outstr += " WHERE  ISNULL(Qty,0)<=AlarmLowQty*" + lowper;
                    break;
                case 2://只查询预警安全数
                    outstr += " WHERE ISNULL(Qty,0)>AlarmLowQty AND ISNULL(Qty,0)<=AlarmLowQty*" + lowper;
                    break;
                case 3://只查询超过安全数
                    outstr += " WHERE  ISNULL(Qty,0)<=AlarmLowQty";
                    break;
            }

            // "AND ISNULL(SQty,0)<=AlarmLowQty*" + lowper;//小于最低库存数

            return outstr;
        }




        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            WHALarmDtsRule rule = new WHALarmDtsRule();
            WHALarmDts entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_WHALarmDts";
            this.HTDataList = gridView1;

            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2 };

            Common.BindWHAlarmType(drpQWHAlarmID, this.FormListAID, false);
      
            drpQWHAlarmID.EditValue = (int)WHAlarmType.坯纱预警;
            drpQueryType.EditValue = "查询全部设置预警库存";
            drpQAlarmType_EditValueChanged(null,null);

            if (this.FormListAID == 1)
            {
                label2.Text = "纱线编码";
                label6.Text = "纱线品名";
                label4.Text = "纱线支数";
                label3.Text = "纱线成份";
            }
            if (this.FormListAID ==2)
            {
                label2.Text = "原料编码";
                label6.Text = "纱线品名";
                label4.Text = "原料规格";
                label3.Text = "原料名称";
            }

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private WHALarmDts EntityGet()
        {
            WHALarmDts entity = new WHALarmDts();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion



        #region 其他
        /// <summary>
        /// 预警类型改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpQAlarmType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT WHID,WHTypeID FROM WH_WHAlarm WHERE ID=" + SysConvert.ToInt32(drpQWHAlarmID.EditValue);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    saveWHID = dt.Rows[0][0].ToString();
                    saveWHTypeID = SysConvert.ToInt32(dt.Rows[0][1]);
                }
                else
                {
                    saveWHID = "";
                    saveWHTypeID = 0;
                }
                ParamSetRule rule = new ParamSetRule();
                //saveAlarmPer = SysConvert.ToInt32(rule.RShowStrByCode((int)ParamSetEnum.安全库存预警百分比));
                GetCondtion();
              
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        /// <summary>
        /// grid颜色改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {

                //decimal qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "Qty"));
                //decimal setqty = SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "AlarmLowQty"));
                //e.Appearance.BackColor = WHAlarmCommon.GetWHColorLow(qty, setqty, saveAlarmPer);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// grid颜色改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                //decimal qty = SysConvert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "Qty"));
                //decimal setqty = SysConvert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "AlarmHighQty"));
                //e.Appearance.BackColor = WHAlarmCommon.GetWHColorHigh(qty, setqty, saveAlarmPer);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

      
    }
}