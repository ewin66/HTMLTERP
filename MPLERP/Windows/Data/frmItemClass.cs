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
    /// ���ܣ���Ʒ���ͷ���
    /// </summary>
    public partial class frmItemClass :frmAPBaseUISin
    {
        public frmItemClass()
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

            if (SysConvert.ToInt32(drpqQItemTypeID.EditValue) != 0)
            {
                tempStr += " AND ItemTypeID=" + SysString.ToDBString(SysConvert.ToInt32(drpqQItemTypeID.EditValue));
            }

            if (txtQCode.Text.Trim() != "")
            {
                tempStr += " AND Code LIKE" + SysString.ToDBString("%"+txtQCode.Text.Trim()+"%");
            }
            if (txtQName.Text.Trim() != "")
            {
                tempStr += " AND Name LIKE" + SysString.ToDBString("%"+txtQName.Text.Trim()+"%");
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            ItemClassRule rule = new ItemClassRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ItemClassRule rule = new ItemClassRule();
            ItemClass entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_ItemClass";            
            this.HTDataList = gridView1;

            Common.BindItemType(drpqQItemTypeID, true);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ItemClass EntityGet()
        {
            ItemClass entity = new ItemClass();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}