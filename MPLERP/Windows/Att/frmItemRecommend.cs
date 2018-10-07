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
   /// 王焕梅添加 2012.05.02 快递管理 
   /// </summary>
    public partial class frmItemRecommend : frmAPBaseUIRpt
    {
        public frmItemRecommend()
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

           
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string tempstr = "";
            if (txtSJFG.Text.Trim() != "" || txtAge.Text.Trim() != "" || txtYXD.Text.Trim() != "")
            {
                tempstr += " AND VendorID IN (SELECT VendorID FROM UV1_Data_VendorDesDts WHERE 1=1";
                if (txtSJFG.Text.Trim() != "")
                {
                    tempstr += " AND SJFG LIKE " + SysString.ToDBString("%" + txtSJFG.Text.Trim() + "%");
                }
                if (txtAge.Text.Trim() != "")
                {
                    tempstr += "AND Age1<=" + SysString.ToDBString(SysConvert.ToInt32(txtAge.Text.Trim()));
                    tempstr += " AND Age2>=" + SysString.ToDBString(SysConvert.ToInt32(txtAge.Text.Trim()));

                }
                if (txtFPrice.Text.Trim() != "")
                {
                    tempstr += "AND FPrice3<=" + SysString.ToDBString(SysConvert.ToDecimal(txtFPrice.Text.Trim()));
                    tempstr += " AND FPrice4>=" + SysString.ToDBString(SysConvert.ToDecimal(txtFPrice.Text.Trim()));
                }
                if (txtYXD.Text.Trim() != "")
                {
                    tempstr += " AND DtsAddress LIKE " + SysString.ToDBString("%" + txtYXD.Text.Trim() + "%");
                }
                if (!chkBH.Checked)
                {
                    tempstr += " AND VendorID<>" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                }
                tempstr += " )";
               
            }
            

            string sql = "SELECT ItemCode,GoodsCode,ColorNum,ColorName,Count(*) Num FROM(";
            sql += " SELECT ItemCode,GoodsCode,ColorNum,ColorName FROM UV2_Dev_GBJCDts";
            sql += " WHERE SubmitFlag=1 AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            //if (SysConvert.ToString(drpVendorID.EditValue) != "")
            //{
            //    sql += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            //}
            sql += tempstr;
            //sql += " GROUP BY ItemCode,GoodsCode,ColorNum,ColorName";
            sql += " UNION ALL";
            sql += " SELECT ItemCode,GoodsCode,ColorNum,ColorName FROM UV1_Dev_LYGLDts";
            sql += " WHERE SubmitFlag=1 AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            //if (SysConvert.ToString(drpVendorID.EditValue) != "")
            //{
            //    sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            //}
            sql += tempstr;
            //sql += " GROUP BY ItemCode,GoodsCode,ColorNum,ColorName";
            sql += " UNION ALL";
            sql += " SELECT ItemCode,GoodsCode,ColorNum,ColorName FROM Sale_DYGL";
            sql += " WHERE  MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            //if (SysConvert.ToString(drpVendorID.EditValue) != "")
            //{
            //    sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            //}
            sql += tempstr;
            //sql += " GROUP BY ItemCode,GoodsCode,ColorNum,ColorName";
            sql += " UNION ALL";
            sql += " SELECT ItemCode,GoodsCode,ColorNum,ColorName FROM UV1_Sale_SaleOrderDts";
            sql += " WHERE SubmitFlag=1 AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            //if (SysConvert.ToString(drpVendorID.EditValue) != "")
            //{
            //    sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            //}
            sql += tempstr;
            //sql += " GROUP BY ItemCode,GoodsCode,ColorNum,ColorName";
            sql += " UNION ALL";
            sql += " SELECT ItemCode,GoodsCode,ColorNum,ColorName FROM UV1_Sale_QuotedPriceDts";
            sql += " WHERE MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            //if (SysConvert.ToString(drpVendorID.EditValue) != "")
            //{
            //    sql += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            //}
            sql += tempstr;
            sql += " ) AS T";
            sql += " GROUP BY ItemCode,GoodsCode,ColorNum,ColorName";
            sql += " ORDER BY Num DESC";
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

      

      

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Att_GoodsPost";
            this.HTDataList = gridView1;

            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);

            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindYXD(txtYXD,SysConvert.ToString(drpVendorID.EditValue), false);
            btnQuery_Click(null, null);

        }

        #endregion

      

        private void txtPostCode_EditValueChanged(object sender, EventArgs e)
        {
            GetCondtion();
            BindGrid();
        }

        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM Data_VendorDes WHERE VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
                DataTable dt=SysUtils.Fill(sql);
                if(dt.Rows.Count>0)
                {
                    txtSJFG.Text = SysConvert.ToString(dt.Rows[0]["SJFG"]);
                    txtAge.Text = SysConvert.ToString(dt.Rows[0]["Age1"]);
                    txtAge2.Text = SysConvert.ToString(dt.Rows[0]["Age2"]);
                    txtFPrice.Text = SysConvert.ToString(dt.Rows[0]["FPrice3"]);
                    txtFprice2.Text = SysConvert.ToString(dt.Rows[0]["FPrice4"]);
                }
                Common.BindYXD(txtYXD, SysConvert.ToString(drpVendorID.EditValue), false);
                txtPostCode_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

       

 
    }
}