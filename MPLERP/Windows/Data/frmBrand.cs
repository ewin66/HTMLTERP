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
    public partial class frmBrand : frmAPBaseUISin
    {
        public frmBrand()
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
            if (txtQBrandID.Text.Trim() != "")//��ѯ
            {
                tempStr += " AND BrandID LIKE " + SysString.ToDBString("%" + txtQBrandID.Text.Trim() + "%");
            }
            if (txtQBrandAttn.Text.Trim()!= "")//��ѯ
            {
                tempStr += " AND BrandAttn LIKE " + SysString.ToDBString("%" + txtQBrandAttn.Text.Trim() + "%");
            }
            if (!Common.CheckLookUpEditBlank(drpQSaleOPID))
            {
                tempStr += " AND SaleOPID = " + SysString.ToDBString(drpQSaleOPID.EditValue.ToString());
            }
            if (txtQDesignName.Text.Trim() != "")
            {
                tempStr += " AND DesignName LIKE " + SysString.ToDBString("%" + txtQDesignName.Text.Trim() + "%");
            }
            tempStr += " ORDER BY BrandID";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            BrandRule rule = new BrandRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            BrandRule rule = new BrandRule();
            Brand entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Brand";
            this.HTDataList = gridView1;

           // Common.BindOPID(drpQSaleOPID, true);
            Common.BindOPID(drpQSaleOPID, this.HTDataTableName, "SaleOPID", true);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Brand EntityGet()
        {
            Brand entity = new Brand();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion
    }
}