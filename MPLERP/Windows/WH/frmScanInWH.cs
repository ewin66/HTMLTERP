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
    public partial class frmScanInWH : BaseForm
    {
        public frmScanInWH()
        {
            InitializeComponent();
        }


        #region 属性

        int saveID = 0;

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

        #endregion



        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
             
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
        }

       

        /// <summary>
        /// 入库提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();

                try
                {
                    sqlTrans.OpenTrans();

                  

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

        #region 扫描条码

        /// <summary>
        /// 条码扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtISN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//回车扫描
                {
                    if (txtISN.Text.Trim() == "")
                    {
                        this.ShowMessage("请扫描条码");
                        return;
                    }
                    if (SysConvert.ToString(drpWHID.EditValue)=="")
                    {
                        this.ShowMessage("请选择仓库");
                        return;
                    }
                    if (txtSectionID.Text.Trim() == "")
                    {
                        this.ShowMessage("请选择区");
                        return;
                    }


                    if (chkCancel.Checked)//取消
                    {
                        DelWHPackNo();
                    }
                    else
                    {
                        SetWHPackNo();//刷入条码时会自动产生SaveID
                    }
                    if (saveID == 0)
                    {
                        this.ShowMessage("系统异常请联系系统管理员");
                        txtISN.Text = "";
                        return;
                    }
                    txtISN.Text = "";
                    txtISN.Focus();

                    string p_ErrorMsg = string.Empty;
                    //DataSet o_ds;

                    //PDAParamConfig.WSAP.MLWHGetPackDts(saveID, out p_ErrorMsg, out o_ds);
                    //if (o_ds.Tables.Count > 0)
                    //{
                    //    string[] ColFieldName = { "产品", "序号", "数量" };
                    //    string[] ColTitle = { "产品", "序号", "数量" };
                    //    int[] ColWidth = { 120, 50, 50 };
                    //    BindGrid(o_ds.Tables[0], ColFieldName, ColTitle, ColWidth);
                    //}

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void DelWHPackNo()
        {
            //string PackNo = txtPackNo.Text.Trim();
            //string p_ErrorMsg = "";
            //PDAParamConfig.WSAP.MLDelPackNo(saveID, PackNo, out p_ErrorMsg);
            //if (p_ErrorMsg != string.Empty)
            //{
            //    this.ShowMessage(p_ErrorMsg);
            //    return;
            //}

        }


        private void SetWHPackNo()
        {
            //string PackNo = txtPackNo.Text.Trim();
            //string p_ErrorMsg = "";
            //string p_ShopID = "";
            //string MainIDstr = PDAParamConfig.WSAP.DCMLSetPackNo(saveID, PackNo, ShopID, m_SubType, out p_ShopID, out p_ErrorMsg);
            //if (p_ErrorMsg != string.Empty)
            //{
            //    this.ShowMessage(p_ErrorMsg);
            //    return;
            //}
            //if (saveID == 0)
            //{
            //    saveID = SysConvert.ToInt32(MainIDstr);
            //}
            //if (saveID == 0)
            //{
            //    this.ShowMessage("系统异常请联系系统管理员，必须退出系统");
            //    txtPackNo.Text = "";
            //    return;
            //}
            //if (ShopID == string.Empty)
            //{
            //    ShopID = p_ShopID;
            //}



        }

        #endregion

    }

}