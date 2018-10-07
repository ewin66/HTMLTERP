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
    public partial class frmUpdateColorCardStatusSD : BaseForm
    {
        public frmUpdateColorCardStatusSD()
        {
            InitializeComponent();
        }
        #region 属性
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
        #endregion


        #region  窗体事件
        private void frmUpdateColorCardStatus_Load(object sender, EventArgs e)
        {
            try
            {

                Common.BindColorCardStatus(drpColorStatus, false);
                Common.BindOP(drpScrapSampleNo, true);
                EntitySet();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ColorCardDts EntityDtsGet()
        {

            ColorCardDts entitydts = new ColorCardDts();

            entitydts.ID = DtsID;
            entitydts.SelectByID();
            entitydts.ColorCardStatusID = SysConvert.ToInt32(drpColorStatus.EditValue);
            entitydts.FirstFinish = SysConvert.ToString(txtFirstFinish.Text.Trim());
            entitydts.FirstRemark = SysConvert.ToString(txtFirstRemark.Text.Trim());
            entitydts.SecondFinish = SysConvert.ToString(txtSecondFinish.Text.Trim());
            entitydts.SecondRemark = SysConvert.ToString(txtSecondRemark.Text.Trim());
            entitydts.ThirdFinish = SysConvert.ToString(txtThirdFinish.Text.Trim());
            entitydts.ThirdRemark = SysConvert.ToString(txtThirdRemark.Text.Trim());
            entitydts.FreeStr1 = SysConvert.ToString(txtFreeStr1.Text.Trim());
            entitydts.FreeStr2 = SysConvert.ToString(txtFreeStr2.Text.Trim());
            entitydts.DesignEdition = SysConvert.ToString(txtDesignEdition.Text.Trim());
            entitydts.OKEdition = SysConvert.ToString(txtOKEdition.Text.Trim());
            entitydts.DesignNO = SysConvert.ToString(txtDesignNO.Text.Trim());
            entitydts.FinishDate = txtFinishDate.DateTime;
            entitydts.HGFinishDate = txtHGFinishDate.DateTime;
            entitydts.HGBack = txtHGBack.Text;
            entitydts.FlowerNum = txtFlowerNum.Text;
            entitydts.ScrapSampleNo = SysConvert.ToString(drpScrapSampleNo.EditValue);
            entitydts.JYDate = txtHGFinishDate.DateTime;
            






            return entitydts;
        }

        void EntitySet()
        {
            ColorCardDts entitydts = new ColorCardDts();

            entitydts.ID = DtsID;
            entitydts.SelectByID();

            drpColorStatus.EditValue=entitydts.ColorCardStatusID;
            txtOKEdition.Text = entitydts.OKEdition;
            txtDesignEdition.Text = entitydts.DesignEdition;
            txtFirstFinish.Text = entitydts.FirstFinish;
            txtFirstRemark.Text = entitydts.FirstRemark;
            txtSecondFinish.Text = entitydts.SecondFinish;
            txtSecondRemark.Text = entitydts.SecondRemark;
            txtThirdFinish.Text = entitydts.ThirdFinish;
            txtThirdRemark.Text = entitydts.ThirdRemark;
            txtFreeStr1.Text = entitydts.FreeStr1;
            txtFreeStr2.Text = entitydts.FreeStr2;
            txtDesignNO.Text = entitydts.DesignNO;
            txtHGFinishDate.DateTime = entitydts.JYDate;
            txtFinishDate.DateTime = entitydts.FinishDate;
            txtHGBack.Text = entitydts.HGBack;
            txtHGFinishDate.DateTime = entitydts.HGFinishDate;
            drpScrapSampleNo.EditValue = entitydts.ScrapSampleNo;
            txtFlowerNum.Text = entitydts.FlowerNum;


        }
        #endregion
        #region 保存


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ColorCardDtsRule rule = new ColorCardDtsRule();

                ColorCardDts entity = EntityDtsGet();

                rule.RUpdate(entity);

                this.Close();

            }
            catch (Exception E)
            {

            }
        }
        #endregion

    
    
  
   


    }
}