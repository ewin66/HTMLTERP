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
using DevExpress.XtraGrid.Views.Base;



namespace MLTERP
{
    public partial class frmSetRecordOPID : BaseForm
    {
        public frmSetRecordOPID()
        {
            InitializeComponent();
        }

        private int m_ID;
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        private string m_OrderStatusName;
        public string OrderStatusName
        {
            get
            {
                return m_OrderStatusName;
            }
            set
            {
                m_OrderStatusName = value;
            }
        }
        //public override void IniData()
        //{
        //    Common.BindOP(drpOPID1, (int)EnumOPDep.�ֿ�, true);
        //    Common.BindOP(drpOPID2, (int)EnumOPDep.�ֿ�, true);
        //}
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                Common.BindOP(drpOPID1, (int)EnumOPDep.����Ա, true);
                Common.BindOP(drpOPID2, (int)EnumOPDep.����Ա, true);

                IOForm entity = new IOForm();
                entity.ID = m_ID;
                entity.SelectByID();

                drpOPID1.EditValue = entity.RecordOPID1;
                drpOPID2.EditValue = entity.RecordOPID2;
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
        /// <summary>
        /// �޸����ۺ�ͬվ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpOPID1.EditValue) == "")
                {
                    return;
                }

                string sql = "UPDATE WH_IOForm SET RecordOPID1="+SysString.ToDBString(SysConvert.ToString(drpOPID1.EditValue));
                sql += ", RecordOPID2=" + SysString.ToDBString(SysConvert.ToString(drpOPID2.EditValue));
                sql += " WHERE ID=" + SysString.ToDBString(m_ID);
                SysUtils.ExecuteNonQuery(sql);


                this.ShowInfoMessage("���óɹ���");


                this.Close();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        


    }

}