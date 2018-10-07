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
    /// ���ܣ�ԭ�ϲ�ѯ
    /// ���ߣ�����÷
    /// ���ڣ�2012-04-24
    /// ��������ѯ
    /// </summary>
    
    
    
    public partial class frmMLYL : frmAPBaseUISin
    {
        public frmMLYL()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtName.Text.Trim() != "")
            {
                tempStr = "AND Name LIKE " + SysString.ToDBString("%" + txtName.Text.Trim() + "%");
            }
            tempStr += "ORDER BY Sort";
             
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            MLYLRule rule = new MLYLRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            MLYLRule rule = new MLYLRule();
            MLYL entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_MLYL";
            this.HTDataList = gridView1;

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private MLYL EntityGet()
        {
            MLYL entity = new MLYL();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            GetCondtion();
            BindGrid();
        }
    }
}