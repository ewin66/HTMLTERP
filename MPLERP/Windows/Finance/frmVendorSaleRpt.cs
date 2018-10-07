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
    /// 功能：关联客户报表
    /// 
    /// </summary>
    public partial class frmVendorSaleRpt : frmAPBaseUIRpt
    {
        public frmVendorSaleRpt()
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
            /*
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (drpXZ.Text.Trim() != string.Empty)
            {
                tempStr += " AND XZ="+SysString.ToDBString(drpXZ.Text.Trim());
            }

            if (txtDM.Text.Trim() != string.Empty)
            {
                tempStr += " AND DM LIKE "+SysString.ToDBString("%"+txtDM.Text.Trim()+"%");
            }

            if(txtInvoiceNo.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND InvoiceNo LIKE "+SysString.ToDBString("%"+txtInvoiceNo.Text.Trim()+"%");
            }

            if(txtQDtsSO.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND DtsSO LIKE "+SysString.ToDBString("%"+txtQDtsSO.Text.Trim()+"%");
            }

            if(txtItemCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if(txtGoodsCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND GoodsCode="+SysString.ToDBString(txtGoodsCode.Text.Trim());
            }

            if(txtColorNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if(txtColorName.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            if(txtVColorNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VColorNum LIKE "+SysString.ToDBString("%"+txtVColorNum.Text.Trim()+"%");
            }

            if(txtVColorName.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VColorName LIKE "+SysString.ToDBString("%"+txtVColorName.Text.Trim()+"%");
            }

            if(txtVItemCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VItemCode LIKE "+SysString.ToDBString("%"+txtVItemCode.Text.Trim()+"%");
            }

            if(txtBatch.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND Batch="+SysString.ToDBString(txtBatch.Text.Trim());
            }

            if(txtJarNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND JarNum LIKE "+SysString.ToDBString("%"+txtJarNum.Text.Trim()+"%");
            }
            if (SysConvert.ToString(drpSubType.EditValue) != string.Empty)
            {
                tempStr += " AND SubType=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
            }

            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE "+SysString.ToDBString("%"+txtItemModel.Text.Trim()+"%");
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString());
            }
            */
            if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }

            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtOrderDateS.DateTime) + " AND " + SysString.ToDBString(txtOrderDateE.DateTime);
            }
            //tempStr += " ORDER BY SaleOPID DESC ";
           
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            //IOFormRule rule = new IOFormRule();
            //gridView1.GridControl.DataSource=rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            //gridView1.GridControl.Show();
            string sql = "select VendorID,Unit,VendorAttn,VendorName,SUM(Qty) Qty,0.0 CostAmount,0.0 Profits,0.0 ProfitsRate from UV1_WH_IOFormDts where 1=1";
            sql += " AND ISNULL(SubmitFlag,0)=1";
            sql += " AND ISNULL(SaleFlag,0)=1";
            sql += HTDataConditionStr;
            sql += " Group By VendorID,VendorAttn,VendorName,Unit";
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
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
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.供应商, (int)EnumVendorType.染厂, (int)EnumVendorType.加工户, (int)EnumVendorType.织厂, (int)EnumVendorType.其他加工厂 }, true);
            //new VendorProc(drpVendorID);
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            int AID = 0;
            int BID = 0;
            if (this.FormListAID == (int)EnumWHType.原料仓库)
            {
                AID = 13;
                BID = 14;
            }
            else if (this.FormListAID == (int)EnumWHType.面料仓库)
            {
                AID = 11;
                BID = 12;
            }
            else if (this.FormListAID == (int)EnumWHType.坯布仓库)
            {
                AID = 15;
                BID = 16;
            }
            else if (this.FormListAID == (int)EnumWHType.辅料仓库)
            {
                AID = 17;
                BID = 18;
            }
            Common.BindSubType(drpSubType, new int[] {AID,BID}, true);
            Common.BindCLS(drpXZ, "WH_IOForm", "XZ", true);
            Common.BindOP(drpSaleOPID, true);
            btnQuery_Click(null, null);
            
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            return entity;
        }


     

      
        
        #endregion

        

        #region 检索相关方法

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// 快速查询(值改变即检索)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //GetCondtion();
                //BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 快速查询(回车即检索)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GetCondtion();
                    BindGrid();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion
        
    }
}