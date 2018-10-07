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
    /// 库存报表
    /// </summary>
    public partial class frmStorge : frmAPBaseUIRpt
    {
        public frmStorge()
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
            switch (this.FormListAID)//判断是原料还是辅料/ItemTypeID 1原料 2辅料 3成衣 4 机物料 5 目录 6 色卡 7 只片 
            {
                case 0://所有
                    tempStr += " ";
                    break;
                case 1://坯纱
                    tempStr += " AND WHTypeID=1";
                    break;
                case 2://色纱
                    tempStr += " AND WHTypeID=2";
                    break;
                case 3://原料
                    tempStr += " AND WHTypeID=3";
                    break;
                //case 3://机物料
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=4)";
                //    break;
                //default:
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=1)";
                //    break;
            }

            tempStr += Common.GetWHRightCondition();


            tempStr += " ORDER BY InDate DESC ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            StorgeRule rule = new StorgeRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_Storge";
            this.HTDataList = gridView1;


            //Common.BindVendor(drpQVendorID, "WH_Storge", "VendorID", true);
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂 }, true);//客户 

         
            Common.BindAllWH(drpQWHID, true);
            Common.BindCLS(drpQWHPosition, "WH_WH", "WHID", false);//绑定仓库位置
            new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.面料 }, true, true);//(int)ItemType.纱线


            drpQWHPosition.EditValue = "本厂";
            txtQColorNum_EditValueChanged(null,null);
            SetTabIndex(0, groupControlQuery);
            //drpQWHID_EditValueChanged(null, null);
           
        }

        #endregion

       
    

        #region 回车事件
       

        private void txtQItemName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    this.GetCondtion();
                    this.BindGrid();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtQItemStd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    this.GetCondtion();
                    this.BindGrid();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtQBatch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    this.GetCondtion();
                    this.BindGrid();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtQVendorBatch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    this.GetCondtion();
                    this.BindGrid();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void drpQWHID_EditValueChanged(object sender, EventArgs e)
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

        private void txtQItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
               if(this.FormListAID!=0)
               {

                  txtQItemName.Text = "";
                    txtQItemStd.Text = "";
                    //txtQItemModel.Text = "";
                    //string sql = "SELECT ItemName,ItemStd,ItemAttnCode,ItemModel FROM Data_Item WHERE 1=1 AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text.Trim());
                    string sql = "SELECT ItemAttnCode FROM Data_Item WHERE 1=1 AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text.Trim());
                    DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    //txtQItemName.Text = dt.Rows[0]["ItemName"].ToString();
                  
                    //txtQItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
                    //txtQItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
                }
            }
                txtQColorNum_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }

        private void txtQColorNum_EditValueChanged(object sender, EventArgs e)
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




    }
}