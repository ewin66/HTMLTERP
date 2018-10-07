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


        #region ����

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
        /// �������
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
        /// ����ύ
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

        #region ɨ������

        /// <summary>
        /// ����ɨ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtISN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//�س�ɨ��
                {
                    if (txtISN.Text.Trim() == "")
                    {
                        this.ShowMessage("��ɨ������");
                        return;
                    }
                    if (SysConvert.ToString(drpWHID.EditValue)=="")
                    {
                        this.ShowMessage("��ѡ��ֿ�");
                        return;
                    }
                    if (txtSectionID.Text.Trim() == "")
                    {
                        this.ShowMessage("��ѡ����");
                        return;
                    }


                    if (chkCancel.Checked)//ȡ��
                    {
                        DelWHPackNo();
                    }
                    else
                    {
                        SetWHPackNo();//ˢ������ʱ���Զ�����SaveID
                    }
                    if (saveID == 0)
                    {
                        this.ShowMessage("ϵͳ�쳣����ϵϵͳ����Ա");
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
                    //    string[] ColFieldName = { "��Ʒ", "���", "����" };
                    //    string[] ColTitle = { "��Ʒ", "���", "����" };
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
            //    this.ShowMessage("ϵͳ�쳣����ϵϵͳ����Ա�������˳�ϵͳ");
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