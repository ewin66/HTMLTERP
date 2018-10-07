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
    public partial class frmSaleCaiWu : frmAPBaseUIRpt
    {
        public frmSaleCaiWu()
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
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID="+SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "EXEC USP1_GetSaleCaiwu "+SysString.ToDBString(txtQMakeDateS.DateTime)+","+SysString.ToDBString(txtQMakeDateE.DateTime)+","+SysString.ToDBString(HTDataConditionStr);
            DataTable dt = SysUtils.Fill(sql);
            foreach (DataRow dr in dt.Rows)
            {
                if (SysConvert.ToDecimal(dr["QCAmount"]) == 0)
                {
                    dr["QCAmount"] = DBNull.Value;
                }

                if (SysConvert.ToDecimal(dr["BQInAmount"]) == 0)
                {
                    dr["BQInAmount"] = DBNull.Value;
                }

                if (SysConvert.ToDecimal(dr["BQOutAmount"]) == 0)
                {
                    dr["BQOutAmount"] = DBNull.Value;
                }

                if (SysConvert.ToDecimal(dr["QMAmount"]) == 0)
                {
                    dr["QMAmount"] = DBNull.Value;
                }
            }
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FQCRule rule = new FQCRule();
            FQC entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_FQC";
            this.HTDataList = gridView1;
            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            //new VendorProc(drpVendorID);

            txtQMakeDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtQMakeDateE.DateTime = DateTime.Now.Date;

            btnQuery_Click(null, null);

           

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FQC EntityGet()
        {
            FQC entity = new FQC();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

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
    }
}