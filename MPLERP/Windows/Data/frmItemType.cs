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
    /// ���ܣ���Ʒ�����б�
    /// </summary>
    public partial class frmItemType : frmAPBaseUISin
    {
        public frmItemType()
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
            if (txtQItemTypeName.Text.Trim() != "")//��ѯ
            {
                tempStr += " AND Name LIKE " + SysString.ToDBString("%" + txtQItemTypeName.Text.Trim() + "%");
            }
            tempStr += " ORDER BY ID";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            ItemTypeRule rule = new ItemTypeRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ItemTypeRule rule = new ItemTypeRule();
            HttSoft.MLTERP.Data.ItemType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_ItemType";
            this.HTDataList = gridView1;

            Common.BindVendorType(drpGridVendorTypeID, false);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private HttSoft.MLTERP.Data.ItemType EntityGet()
        {
            HttSoft.MLTERP.Data.ItemType entity = new HttSoft.MLTERP.Data.ItemType();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion
    }
}