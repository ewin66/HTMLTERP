using System;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.MLTERP.Sys;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data;
using System.Windows.Forms;
using System.Data;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;

namespace MLTERP
{
    public delegate void FormItemMoreProcEventLoad(out string p_TableName,out int p_TableID,out FormStatus p_FormStatus);// ����ί�д������
    /// <summary>
    /// �������ԭ����
    /// </summary>
    public class frmFormItemMoreProc : BaseForm
    {
        private MemoEdit m_FormItemText;//���ڲ���
        FormItemMoreProcEventLoad m_EventLoad;
        
        public frmFormItemMoreProc(MemoEdit p_FormItemText,FormItemMoreProcEventLoad p_EventLoad)
        {
            m_FormItemText = p_FormItemText;
            m_FormItemText.Properties.ReadOnly = true;

            m_FormItemText.DoubleClick += new System.EventHandler(txtItem_DoubleClick);
            m_EventLoad = p_EventLoad;

        }

        /// <summary>
        /// ˫����������ҳ��
        /// </summary>
        private void txtItem_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                string tableName;
                int tableID;
                FormStatus formStatus ;

                m_EventLoad(out tableName, out tableID, out formStatus);

                if (formStatus == FormStatus.���� || formStatus == FormStatus.�޸�)
                {
                    frmFormItemMoreLoad frm = new frmFormItemMoreLoad();
                    frm.FormItemText = m_FormItemText;
                    frm.HTDataTableName = tableName;
                    frm.HTDataID = tableID;
                    frm.ShowDialog();                    
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}
