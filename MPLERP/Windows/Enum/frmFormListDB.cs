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
    /// ���ܣ��ֿⵥ�����͹����
    /// ���ߣ�������
    /// ���ڣ�2012-4-19
    /// ����������
    public partial class frmFormListDB : frmAPBaseUISin
    {
        public frmFormListDB()
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
            if (!txtQFormNM.Text.Trim().Equals(""))
            {
                tempStr += " AND FormNM LIKE " + SysString.ToDBString("%" + txtQFormNM.Text.Trim() + "%");
            }
            tempStr += " ORDER BY ID";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            FormListDBRule rule = new FormListDBRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FormListDBRule rule = new FormListDBRule();
            FormListDB entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_FormListDB";
            this.HTDataList = gridView1;

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FormListDB EntityGet()
        {
            FormListDB entity = new FormListDB();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
        #region ���ٲ�ѯ
        /// <summary>
        ///���ٲ�ѯ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQFormNM_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }

        }
        #endregion
    }
}