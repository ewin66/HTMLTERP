using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;

namespace MLTERP
{
    public partial class frmFavItem :BaseForm
    {
        public frmFavItem()
        {
            InitializeComponent();
        }

        private string m_GBCode;
        public string GBCode
        {
            get
            {
                return m_GBCode;
            }
            set
            {
                m_GBCode = value;
            }
        }

       

        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {
                Common.BindVendor(drpVendorID, new int[] {(int)EnumVendorType.客户 }, true);
                new VendorProc(drpVendorID);
                BindGrid();
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        private void BindGrid()
        {
            string sql = "SELECT * FROM Sale_FavItemGB WHERE GBCode="+SysString.ToDBString(m_GBCode);
            sql += " AND ISNULL(CancelFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

       


       

       

        private void frmLoadPack_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                
               
            }
            catch (Exception E)
            {

            }
        }

        private void btnFav_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_GBCode == "")
                {
                    this.ShowMessage("没用得到挂板信息，请关闭此页面重新收藏");
                    return;
                }
                if (txtFavDes.Text.Trim() == "")
                {
                    this.ShowMessage("请输入收藏说明");
                    txtFavDes.Focus();
                    return;
                }
                FavItemGBRule rule = new FavItemGBRule();
                FavItemGB entity = new FavItemGB();
                entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
                entity.SaleOPID = FParamConfig.LoginID;
                entity.GBCode = m_GBCode;
                entity.FavDes = txtFavDes.Text.Trim();
                entity.FormDate = DateTime.Now.Date;
                rule.RAdd(entity);
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

       
    }
}