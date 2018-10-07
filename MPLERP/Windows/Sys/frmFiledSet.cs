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
    public partial class frmFiledSet : frmAPBaseUISin
    {
        public frmFiledSet()
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
            if (txtFormID.Text.Trim() != "")
            {
                tempStr += " AND FormID="+SysString.ToDBString(SysConvert.ToInt32(txtFormID.Text.Trim()));
            }

            if (txtName.Text.Trim() != "")
            {
                tempStr += " AND Name LIKE "+SysString.ToDBString("%"+txtName.Text.Trim()+"%");
            }

            if (txtFiledName.Text.Trim() != "")
            {
                tempStr += " AND FiledName LIKE "+SysString.ToDBString("%"+txtFiledName.Text.Trim()+"%");
            }
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            FiledSetRule rule = new FiledSetRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FiledSetRule rule = new FiledSetRule();
            FiledSet entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sys_FiledSet";
            this.HTDataList = gridView1;

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FiledSet EntityGet()
        {
            FiledSet entity = new FiledSet();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void txtFormID_EditValueChanged(object sender, EventArgs e)
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