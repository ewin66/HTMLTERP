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
    public partial class frmSetRecordOPID2 : BaseForm
    {
        public frmSetRecordOPID2()
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
        //    Common.BindOP(drpOPID1, (int)EnumOPDep.仓库, true);
        //    Common.BindOP(drpOPID2, (int)EnumOPDep.仓库, true);
        //}
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                Common.BindOP(drpOPID1,(int)EnumOPDep.上布员, true);
                Common.BindOP(drpOPID2, (int)EnumOPDep.上布员, true);
                Common.BindOP(drpOPID3, (int)EnumOPDep.上布员, true);
                Common.BindOP(drpOPID4, (int)EnumOPDep.上布员, true);
                Common.BindOP(drpOPID5, (int)EnumOPDep.上布员, true);
                Common.BindOP(drpOPID6, (int)EnumOPDep.运输员, true);

                IOForm entity = new IOForm();
                entity.ID = m_ID;
                entity.SelectByID();

                drpOPID1.EditValue = entity.RecordSBOPID1;
                drpOPID2.EditValue = entity.RecordSBOPID2;
                drpOPID3.EditValue = entity.RecordSBOPID3;
                drpOPID4.EditValue = entity.RecordSBOPID4;
                drpOPID5.EditValue = entity.RecordSBOPID5;
                drpOPID6.EditValue = entity.RecordYSOPID1;
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
        /// <summary>
        /// 修改销售合同站别
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

                string sql = "UPDATE WH_IOForm SET RecordSBOPID1=" + SysString.ToDBString(SysConvert.ToString(drpOPID1.EditValue));
                sql += ", RecordSBOPID2=" + SysString.ToDBString(SysConvert.ToString(drpOPID2.EditValue));
                sql += ", RecordSBOPID3=" + SysString.ToDBString(SysConvert.ToString(drpOPID3.EditValue));
                sql += ", RecordSBOPID4=" + SysString.ToDBString(SysConvert.ToString(drpOPID4.EditValue));
                sql += ", RecordSBOPID5=" + SysString.ToDBString(SysConvert.ToString(drpOPID5.EditValue));
                sql += ", RecordYSOPID1=" + SysString.ToDBString(SysConvert.ToString(drpOPID6.EditValue));
                sql += " WHERE ID=" + SysString.ToDBString(m_ID);
                SysUtils.ExecuteNonQuery(sql);


                this.ShowInfoMessage("设置成功！");


                this.Close();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        


    }

}