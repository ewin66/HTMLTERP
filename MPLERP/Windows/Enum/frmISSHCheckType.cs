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
    public partial class frmISSHCheckType : frmAPBaseUISin
    {
        public frmISSHCheckType()
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
            if (SysConvert.ToString(txtQCode.Text.Trim()) != "")
            {
                tempStr += " AND CODE LIKE"+SysString.ToDBString("%"+SysConvert.ToString(txtQCode.Text.Trim())+"%");
            }
            if (SysConvert.ToString(txtQName.Text.Trim()) != "")
            {
                tempStr += " AND Name LIKE" + SysString.ToDBString("%" + SysConvert.ToString(txtQName.Text.Trim()) + "%");
            }
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            ISSHCheckTypeRule rule = new ISSHCheckTypeRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ISSHCheckTypeRule rule = new ISSHCheckTypeRule();
            ISSHCheckType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_ISSHCheckType";
            this.HTDataList = gridView1;

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ISSHCheckType EntityGet()
        {
            ISSHCheckType entity = new ISSHCheckType();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}