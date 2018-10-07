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
    public partial class frmWHCalMethod : frmAPBaseUISin
    {
        public frmWHCalMethod()
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
            if (txtQCode.Text.Trim()!= "")//��ѯ
            {
                tempStr += " AND Code LIKE " + SysString.ToDBString("%" + txtQCode.Text.Trim() + "%");
            }
            if (txtQName.Text.Trim() != "")//��ѯ
            {
                tempStr += " AND Name LIKE " + SysString.ToDBString("%" + txtQName.Text.Trim() + "%");
            }


            tempStr += " ORDER BY ID";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            WHCalMethodRule rule = new WHCalMethodRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            WHCalMethodRule rule = new WHCalMethodRule();
            WHCalMethod entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_WHCalMethod";
            this.HTDataList = gridView1;

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private WHCalMethod EntityGet()
        {
            WHCalMethod entity = new WHCalMethod();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void txtQCode_EditValueChanged(object sender, EventArgs e)
        {
            GetCondtion();
            BindGrid();
        }

        private void txtQName_EditValueChanged(object sender, EventArgs e)
        {
            GetCondtion();
            BindGrid();
        }
    }
}