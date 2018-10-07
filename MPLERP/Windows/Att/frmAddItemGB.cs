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
    public partial class frmAddItemGB : BaseForm
    {
        public frmAddItemGB()
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

        private string m_GBCode;
        public string GBCode
        {
            get
            {
                return m_GBCode;
            }
            set
            {
                m_GBCode = value;
            }
        }

       
        /// <summary>
        /// ¥∞ÃÂº”‘ÿ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {

                //lbOrderFormNo.Text = "π“∞Â£∫" + m_GBCode;
                EntitySet();
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void EntitySet()
        {
            ItemGB entity = new ItemGB();
            entity.ID = m_ID;
            entity.SelectByID();
            txtGBDesc.Text = entity.GBDesc;
            drpXY.EditValue = entity.XY;
            txtXYDesc.Text = entity.XYDesc;
            txtDRemark.Text = entity.Remark;
        }

       
        /// <summary>
        /// ±£¥Ê
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();

                try
                {
                    sqlTrans.OpenTrans();

                    string[] listm_GBCode = m_GBCode.Split(new char[1] { ',' });
                    for (int i = 0; i < listm_GBCode.Length; i++)
                    {
                        string sql = "UPDATE Data_ItemGB SET XY=" + SysConvert.ToInt32(drpXY.EditValue);
                        sql += ",XYDesc=" + SysString.ToDBString(txtXYDesc.Text.Trim());
                        sql += ",GBDesc=" + SysString.ToDBString(txtGBDesc.Text.Trim());
                        sql += ",Remark=" + SysString.ToDBString(txtDRemark.Text.Trim());
                        sql += " WHERE GBCode=" + SysString.ToDBString(listm_GBCode[i]);
                        sqlTrans.ExecuteNonQuery(sql);

                    }
                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }

                
                this.Close();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnPicNewBrowsing_Click(object sender, EventArgs e)
        {

        }

        


    }

}