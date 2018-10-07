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
    public partial class frmFormList : frmAPBaseUISin
    {
        public frmFormList()
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
            FormListRule rule = new FormListRule();
            gridView1.GridControl.DataSource=rule.UvRShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FormListRule rule = new FormListRule();
            FormList entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_FormList";
            this.HTDataList = gridView1;

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FormList EntityGet()
        {
            FormList entity = new FormList();
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