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
    public partial class frmWHSpecialType : frmAPBaseUISin
    {
        public frmWHSpecialType()
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
            if (!txtQName.Text.Trim().Equals(""))
            {
                tempStr += " AND Name LIKE " + SysString.ToDBString("%" + txtQName.Text.Trim() + "%");
            }
            tempStr += " ORDER BY Code";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            WHSpecialTypeRule rule = new WHSpecialTypeRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            WHSpecialTypeRule rule = new WHSpecialTypeRule();
            WHSpecialType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_WHSpecialType";
            this.HTDataList = gridView1;

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WHSpecialType EntityGet()
        {
            WHSpecialType entity = new WHSpecialType();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}