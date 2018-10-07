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
    public partial class frmUpdateWHAmount : BaseForm
    {
        public frmUpdateWHAmount()
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

        private int m_DtsID;
        public int DtsID
        {
            get
            {
                return m_DtsID;
            }
            set
            {
                m_DtsID = value;
            }
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                IOForm entity = new IOForm();
                entity.ID = m_ID;
                entity.SelectByID();

                IOFormDts entityDts = new IOFormDts();
                entityDts.ID = m_DtsID;
                entityDts.SelectByID();
                
                lbShow.Text = "����ⵥ�ţ�"+entity.FormNo+",��Ʒ���룺"+entityDts.ItemCode+",��ɫ��"+entityDts.ColorNum+" "+entityDts.ColorName;
                txtOldSinglePrice.Text = entityDts.SinglePrice.ToString();
                txtNewSinglePrice.Text = entityDts.SinglePrice.ToString();
            }
            catch (Exception E)
            {
               
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
                if (m_ID ==0||m_DtsID==0)
                {
                    this.ShowMessage("����������鿴");
                    return;

                }
                if (SysConvert.ToString(txtOldSinglePrice.Text.Trim()) == string.Empty)
                {
                    this.ShowMessage("�ɵ���Ϊ�գ�����");
                    return;
                }
                if (SysConvert.ToString(txtNewSinglePrice.Text.Trim()) == string.Empty)
                {
                    this.ShowMessage("�µ���Ϊ�գ�����");
                    return;
                }
                if (SysConvert.ToString(txtOldSinglePrice.Text.Trim()) == SysConvert.ToString(txtNewSinglePrice.Text.Trim()))
                {
                    this.ShowMessage("�¾ɵ�����ͬ������");
                    return;
                }

                IOForm entity = new IOForm();
                entity.ID = m_ID;
                entity.SelectByID();

                IOFormDts entityDts = new IOFormDts();
                entityDts.ID = m_DtsID;
                entityDts.SelectByID();

                UpdateWHSinglePriceRule rule = new UpdateWHSinglePriceRule();
                UpdateWHSinglePrice entityWH = new UpdateWHSinglePrice();
                entityWH.FormNo = entity.FormNo;
                entityWH.DtsID = entityDts.ID;
                entityWH.ItemCode = entityDts.ItemCode;
                entityWH.ColorNum = entityDts.ColorNum;
                entityWH.ColorName = entityDts.ColorName;
                entityWH.NewSinglePrice = SysConvert.ToDecimal(txtNewSinglePrice.Text.Trim());
                entityWH.OldSinglePrice = SysConvert.ToDecimal(txtOldSinglePrice.Text.Trim());
                entityWH.UpdateDate = DateTime.Now;
                entityWH.UpdateOPName = FParamConfig.LoginName;
                rule.RAdd(entityWH);


                string sql = "UPDATE WH_IOFormDts SET SinglePrice=" + SysString.ToDBString(SysConvert.ToDecimal(txtNewSinglePrice.Text.Trim()));
                sql += ",Amount=ISNULL(DYPrice,0)+ISNULL(Qty,0)*" + SysString.ToDBString(SysConvert.ToDecimal(txtNewSinglePrice.Text.Trim()));
                sql += " WHERE ID="+SysString.ToDBString(m_DtsID);
                SysUtils.ExecuteNonQuery(sql);
                this.ShowInfoMessage("�޸ĳɹ�");
                this.Close();

               

            }
            catch (Exception E)
            {

            }
        }

       

       
     
        


    }

}