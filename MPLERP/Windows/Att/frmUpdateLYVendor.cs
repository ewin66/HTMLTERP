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
    public partial class frmUpdateLYVendor : BaseForm
    {
        public frmUpdateLYVendor()
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
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
                new VendorProc(drpVendorID);
                //EntitySet();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void EntitySet()
        {
            //GBJCDts entity = new GBJCDts();
            //entity.ID = m_ID;
            //entity.SelectByID();
            ////txtLYVendorName.Text = entity.LYVendorName;
            //drpVendorID.EditValue = entity.LYVendorID;
        }


        /// <summary>
        /// 保存
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
                    bool flag = false;
                    string sql = "Select * from Dev_GBJCDts where 1= 1";
                    if (GBCode != string.Empty)
                    {
                        sql += " AND " + GBCode;
                    }
                    DataTable dtDev = sqlTrans.Fill(sql);
                    for (int i = 0; i < dtDev.Rows.Count; i++)
                    {
                        string VendorIDStr = SysConvert.ToString(dtDev.Rows[i]["LYVendorID"]);
                        string VendorNameStr = SysConvert.ToString(dtDev.Rows[i]["LYVendorName"]);
                        string[] vendorid = VendorIDStr.Split(',');
                        if (SysConvert.ToString(dtDev.Rows[i]["LYVendorID"]) == "")
                        {
                            VendorIDStr = SysConvert.ToString(drpVendorID.EditValue);
                            sql = "Select VendorAttn from Data_Vendor where VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                            DataTable dt = sqlTrans.Fill(sql);
                            if (dt.Rows.Count == 1)
                            {
                                VendorNameStr = SysConvert.ToString(dt.Rows[0]["VendorAttn"]);
                            }
                        }
                        else
                        {
                            sql = "Select VendorAttn from Data_Vendor where VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
                            DataTable dt = sqlTrans.Fill(sql);
                            if (vendorid.Length > 0)
                            {
                                for (int j = 0; j < vendorid.Length; j++)
                                {
                                    if (vendorid[j].ToString() == SysConvert.ToString(drpVendorID.EditValue))
                                    {
                                        flag = true;
                                        break;

                                    }
                                }
                            }
                            if (!flag)
                            {
                                if (dt.Rows.Count == 1)
                                {

                                    VendorNameStr += "," + SysConvert.ToString(dt.Rows[0]["VendorAttn"]);
                                }
                                VendorIDStr += "," + SysConvert.ToString(drpVendorID.EditValue);
                            }

                        }

                        sql = "UPDATE Dev_GBJCDts SET LYVendorID= " + SysString.ToDBString(VendorIDStr);
                        sql += ",LYVendorName = " + SysString.ToDBString(VendorNameStr);
                        sql += ",LYFlag = 1";
                        sql += " WHERE MainID =" + SysConvert.ToString(dtDev.Rows[i]["MainID"]);
                        sql += " AND Seq = " + SysConvert.ToString(dtDev.Rows[i]["Seq"]);
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

            }
        }




    }

}