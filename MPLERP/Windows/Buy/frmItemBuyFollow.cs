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
    public partial class frmItemBuyFollow : frmAPBaseUIForm
    {
        public frmItemBuyFollow()
        {
            InitializeComponent();
        }


        int saveNoLoadCheckDayNum = 0;//未加载比对天数，防止随着时间的推移系统变慢
        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND ShopID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
         
            if (ChkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            }

            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE "+SysString.ToDBString("%"+txtItemName.Text.Trim()+"%");
            }
            if (chkJQ.Checked)
            {
                tempStr += " AND ReqDate BETWEEN " + SysString.ToDBString(txtFactFinishDateS.DateTime)+" AND "+SysString.ToDBString(txtFactFinishDateE.DateTime);
            }
            if (txtOrderFormNo.Text.Trim() != "")
            {
                tempStr += " AND BuyFormNo LIKE "+SysString.ToDBString("%"+txtOrderFormNo.Text.Trim()+"%");
            }
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ItemBuyFollowRule rule = new ItemBuyFollowRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();



            string sql = "SELECT FormNo,ShopID,ReqDate,MakeDate,TotalQty FROM Buy_ItemBuyForm WHERE 1=1";
            sql += " AND FormNo NOT IN (SELECT BuyFormNo FROM Buy_ItemBuyFollow";
            if (saveNoLoadCheckDayNum != 0)
            {
                sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            sql +=") ";
            if (ChkMakeDate.Checked)
            {
                sql += " AND FormDate BETWEEN " + SysString.ToDBString(txtBuyDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtBuyDateE.DateTime.ToString("yyyy-MM-dd"));
            }
            sql += " AND SubmitFlag=1 ORDER BY FormNo DESC ";
            DataTable dt = SysUtils.Fill(sql);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ItemBuyFollowRule rule = new ItemBuyFollowRule();
            ItemBuyFollow entity = EntityGet();
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
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.工厂 }, true);
            new VendorProc(drpQVendorID);
            this.HTDataTableName = "Buy_ItemBuyFollow";
            this.HTDataList = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2 };
            txtQMakeDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtQMakeDateE.DateTime = DateTime.Now;
            txtBuyDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtBuyDateE.DateTime = DateTime.Now.Date;
            txtFactFinishDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFactFinishDateE.DateTime = DateTime.Now.Date;

            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.未加载数据比对天数);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemBuyFollow EntityGet()
        {
            ItemBuyFollow entity = new ItemBuyFollow();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

      
        #region 快速查询
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
        private void txtMakeOPName_EditValueChanged(object sender, EventArgs e)
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


        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged_1(object sender, EventArgs e)
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