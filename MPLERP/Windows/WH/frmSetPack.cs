using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.MLTERP.Data;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.MLTERP.DataCtl;

namespace MLTERP
{
    public partial class frmSetPack : BaseForm
    {
        public frmSetPack()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 库存ID
        /// </summary>
        private int m_StorgeID;
        public int StorgeID
        {
            get
            {
                return m_StorgeID;
            }
            set
            {
                m_StorgeID = value;
            }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetPack_Load(object sender, EventArgs e)
        {
            Common.BindOP(drpSaleOPID, true);
        }

        private StorgePack EntityGet()
        {
            StorgePack entity = new StorgePack();
            string sql = "SELECT * FROM  WH_Storge WHERE ID="+SysString.ToDBString(m_StorgeID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                //entity.ItemCode = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                //entity.ColorNum = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                //entity.ColorName = SysConvert.ToString(dt.Rows[0]["ColorName"]);
               // entity.KPDate = DateTime.Now.Date;
                entity.Qty = SysConvert.ToDecimal(txtPackNum.Text.Trim());
                //entity.KPDes = txtKPDes.Text.Trim();
            }
            return entity;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPackNum.Text.Trim() == "")
            {
                this.ShowMessage("请输入开匹数量");
                txtPackNum.Focus();
                return;
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) == "")
            {
                this.ShowMessage("请选择开匹人员");
                drpSaleOPID.Focus();
                return;
            }

            if (txtKPDes.Text.Trim() == "")
            {
                this.ShowMessage("请输入开匹去向");
                txtKPDes.Focus();
                return;
            }

            StorgePackRule rule = new StorgePackRule();
            StorgePack entity = EntityGet();
            rule.RAdd(entity);
            this.ShowMessage("开匹成功");
            this.Close();
        }
    }
}