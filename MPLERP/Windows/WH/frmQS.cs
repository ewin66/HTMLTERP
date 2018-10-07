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
    public partial class frmQS : frmAPBaseUISin
    {
        public frmQS()
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
            //
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID ="+SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }
            if(chkOrderDate.Checked)
            {
                tempStr+=" AND FormDate BETWEEN "+SysString.ToDBString(txtFormDateS.DateTime)+" AND "+SysString.ToDBString(txtFormDateE.DateTime);
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtItemVendorID.Text.Trim() != "")
            {
                tempStr += " AND ItemVendorID LIKE "+SysString.ToDBString("%"+txtItemVendorID.Text.Trim()+"%");
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            QSRule rule = new QSRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
          
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

      

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            QSRule rule = new QSRule();
            QS entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_QS";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户}, true);
            new VendorProc(drpVendorID);
            txtFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private QS EntityGet()
        {
            QS entity = new QS();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
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