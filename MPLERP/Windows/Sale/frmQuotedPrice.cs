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
    /// <summary>
    /// 功能：报价管理
    ///  
    /// </summary>
    public partial class frmQuotedPrice : frmAPBaseUIForm
    {
        public frmQuotedPrice()
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
            if (txtFormNo.Text.Trim() != "")//查询。
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND DVendorID =" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (chkQMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateB.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE "+SysString.ToDBString("%"+txtItemModel.Text.Trim()+"%");
            }

            //if (txtVendorID.Text.Trim() != "")
            //{
            //    tempStr += " AND VendorID like "+SysString.ToDBString("%"+txtVendorID.Text.Trim()+"%");
            //}

            //if (txtGBCode.Text.Trim() != "")
            //{
            //    tempStr += " AND GBCode LIKE "+SysString.ToDBString("%"+txtGBCode.Text.Trim()+"%");
            //}

            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID="+SysString.ToDBString(drpSaleOPID.EditValue.ToString());
            }
            if (chkAuto.Checked)
            {
                tempStr += " AND ISNULL(SubmitFlag,0)=1 ";
            }
            if (chkNoAuto.Checked)
            {
                tempStr += " AND ISNULL(SubmitFlag,0)<>1";
            }


            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//销售订单业务员只查看自己的的订单
            {
                tempStr += " AND SaleOPID IN(" + WCommon.GetStructureMemberOPStr() + ")";
            }


            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            QuotedPriceRule rule = new QuotedPriceRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            QuotedPriceRule rule = new QuotedPriceRule();
            QuotedPrice entity = EntityGet();
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
            this.HTDataTableName = "Sale_QuotedPrice";
            this.HTDataList = gridView1;

            this.HTQryContainer = groupControlQuery;

            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);
            //Common.BindOP(drpSaleOPID, true);
            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//组织结构体系启用
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }
            txtQMakeDateB.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtQMakeDateE.DateTime = DateTime.Now;

            Common.BindMLDL(drpMLDL,true);
            Common.BindMLLB(drpMLLB, true);
            //if (this.FormListAID == 1)
            //{
            //    chkAuto.Checked = true;
            //    chkNoAuto.Checked = false;
            //}
            //else
            //{
            //    chkAuto.Checked = false;
            //    chkNoAuto.Checked = true;
            //}

            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限0))//查看价格权限
            {
                txtGridSet.PasswordChar = '*';
            }

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private QuotedPrice EntityGet()
        {
            QuotedPrice entity = new QuotedPrice();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion 
       

      

       
    }
}