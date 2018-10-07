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
    /// 功能：收发存报表
    /// </summary>
    public partial class frmWHIOStorgeRpt : frmAPBaseUIRpt
    {
        public frmWHIOStorgeRpt()
        {
            InitializeComponent();
        }
        #region 全局变量

        //int iLKParamSet = 0;//留库天数；
        #endregion

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
            if (SysConvert.ToString(drpQWHTypeID.EditValue) != "")
            {
                tempStr += " AND WHTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQWHTypeID.EditValue));
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (txtQSSN.Text.Trim() != "")
            {
                tempStr += " AND SSN LIKE " + SysString.ToDBString("%" + txtQSSN.Text.Trim() + "%");
            }
            if (txtQDSN.Text.Trim() != "")
            {
                tempStr += " AND DSN LIKE " + SysString.ToDBString("%" + txtQDSN.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
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
            switch (this.FormListAID)//判断是原料还是辅料/ItemTypeID 1原料 2辅料 3成衣 4 机物料 5 目录 6 色卡 7 只片 
            {
                case 0://所有
                    tempStr += " ";
                    break;
                //case 0://原料
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=1)";
                //    break;
                //case 1://辅料
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=2)";
                //    break;
                //case 2://成衣
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=3)";
                //    break;
                //case 3://机物料
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=4)";
                //    break;
                //default:
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=1)";
                //    break;
            }
            //tempStr += " AND FormDate <=" + SysString.ToDBString(DateTime.Now.Date.AddDays(-iLKParamSet).ToString("yyyy-MM-dd"));

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = " Exec USP2_IOStorge " + SysString.ToDBString(FParamConfig.LoginID);
            sql += "," + SysString.ToDBString(SysConvert.ToString(txtWriteDateS.DateTime.Date));
            sql += "," + SysString.ToDBString(SysConvert.ToString(txtWriteDateE.DateTime.Date));
            sql += "," + SysString.ToDBString(HTDataConditionStr);
            //SystemConfiguration.DBTimeOut = 60;
            SysUtils.ExecuteNonQuery(sql);

            //sql = " Select * from WH_QWHJS where 1=1 ";
            //if (this.txtQBatch.Text.Trim() != "")
            //{
            //    sql += " AND Batch LIKE " + SysString.ToDBString("%" + this.txtQBatch.Text.Trim() + "%");
            //}
            //if (this.txtQVendorBatch.Text.Trim() != "")
            //{
            //    sql += " AND VendorBatch LIKE" + SysString.ToDBString("%" + this.txtQVendorBatch.Text.Trim() + "%");
            //}
            //if (this.txtQColorName.Text.Trim() != "")
            //{
            //    sql += " AND ColorName LIKE" + SysString.ToDBString("%" + this.txtQColorName.Text.Trim() + "%");
            //}
            //if (this.txtQColorNum.Text.Trim() != "")
            //{
            //    sql += " AND ColorNum LIKE" + SysString.ToDBString("%" + this.txtQColorNum.Text.Trim() + "%");
            //}
            //if (this.txtQJarNum.Text.Trim() != "")
            //{
            //    sql += " AND JarNum LIKE" + SysString.ToDBString("%" + this.txtQJarNum.Text.Trim() + "%");
            //}
           
            //if (txtQItemStd.Text.Trim() != string.Empty)
            //{
            //    sql += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            //}
            //sql += " AND OPID = " + SysString.ToDBString(FParamConfig.LoginID);

            int tempDBTimeOut = SystemConfiguration.DBTimeOut;
            SystemConfiguration.DBTimeOut = 600;//10分钟
            DataTable  dt = SysUtils.Fill(sql);
            SystemConfiguration.DBTimeOut = tempDBTimeOut;

            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_Storge";
            this.HTDataList = gridView1;

            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂 }, true);//客户 

            Common.BindWHType(drpQWHTypeID, true);
            Common.BindWH(drpQWHID, true);

            switch (this.FormListAID)//判断是原料还是辅料/ItemTypeID 1原料 2辅料 3成衣 4 机物料 5 目录 6 色卡 7 只片 
            {
                case 0://原料
                    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.面料 }, true, true);
                    break;
                //case 1://辅料
                //    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.辅料 }, true, true);
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


            txtWriteDateS.DateTime = DateTime.Now.Date.AddDays(0 - 15);
            txtWriteDateE.DateTime = DateTime.Now.Date;

            SetTabIndex(0, groupControlQuery);
            new VendorProc(drpQVendorID);
        }

        #endregion

    }
}