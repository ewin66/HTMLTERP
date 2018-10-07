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
    public partial class frmProductionNoticeRpt : frmAPBaseUIForm
    {
        public frmProductionNoticeRpt()
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

            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (chkQMakeDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN "+SysString.ToDBString(txtQMakeDateB.DateTime)+" AND "+SysString.ToDBString(txtQMakeDateE.DateTime);
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID="+SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
            }

            if (SysConvert.ToString(drpTrackOPID.EditValue) != "")
            {
                tempStr += " AND TrackOPID=" + SysString.ToDBString(SysConvert.ToString(drpTrackOPID.EditValue));
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }

            if (txtFlower.Text.Trim() != "")
            {
                tempStr += " AND Flower LIKE " + SysString.ToDBString("%" + txtFlower.Text.Trim() + "%");
            }

            if (chkNoFinish.Checked)
            {
                tempStr += " AND LoadID NOT IN (SELECT ISNULL(DtsID,0) FROM UV1_Sale_SaleOrderDts WHERE TotalRecQty>0.8*Qty)";
            }
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            ProductionNoticeRule rule = new ProductionNoticeRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ProductionNoticeRule rule = new ProductionNoticeRule();
            ProductionNotice entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// ���ö�λ���ݼ�״̬
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_ProductionNotice";
            this.HTDataList = gridView1;
            txtQMakeDateB.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQMakeDateE.DateTime = DateTime.Now.Date;

            Common.BindOP(drpSaleOPID, true);
            Common.BindOP(drpTrackOPID, true);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ProductionNotice EntityGet()
        {
            ProductionNotice entity = new ProductionNotice();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}