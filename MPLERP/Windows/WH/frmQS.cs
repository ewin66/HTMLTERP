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


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
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
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            QSRule rule = new QSRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
          
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

      

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            QSRule rule = new QSRule();
            QS entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_QS";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�}, true);
            new VendorProc(drpVendorID);
            txtFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
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