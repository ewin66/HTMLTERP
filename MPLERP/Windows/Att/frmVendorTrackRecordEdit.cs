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
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;


namespace MLTERP
{
    public partial class frmVendorTrackRecordEdit : frmAPBaseUISinEdit
    {
        public frmVendorTrackRecordEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (drpTrackType.Text.Trim() == "")
            {
                this.ShowMessage("�������������");
                drpTrackType.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue)=="")
            {
                this.ShowMessage("��ѡ��ͻ�");
                drpVendorID.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            VendorTrackRecordRule rule = new VendorTrackRecordRule();
            VendorTrackRecord entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            VendorTrackRecordRule rule = new VendorTrackRecordRule();
            VendorTrackRecord entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            VendorTrackRecord entity = new VendorTrackRecord();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtFormNo.Text = entity.FormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  		
  			drpVendorID.EditValue = entity.VendorID.ToString(); 
  			txtSaleOPID.Tag = entity.SaleOPID.ToString();
            txtSaleOPID.Text = entity.SaleOPID +" "+ Common.GetOPName(entity.SaleOPID);
  			drpTrackType.Text = entity.TrackType.ToString(); 
  			txtTrackTitle.Text = entity.TrackTitle.ToString();
            txtTrackContext.RichText = entity.TrackContextRtf;
            chkTrackFlag.Checked = SysConvert.ToBoolean(entity.TrackFlag);
  			txtRemark.Text = entity.Remark.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            VendorTrackRecordRule rule = new VendorTrackRecordRule();
            VendorTrackRecord entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);


            //ProductCommon.FormNoIniSet(txtFormNo, "Att_VendorTrackRecord", "FormNo");
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Att_VendorTrackRecord", "FormNo", p_Flag);
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtSaleOPID.Text = FParamConfig.LoginName;
            txtSaleOPID.Tag = FParamConfig.LoginID;

        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Att_VendorTrackRecord";


       

            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);

            Common.BindCLS(drpTrackType, "Att_VendorTrackRecord", "TrackType", true);

            //
        }


        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private VendorTrackRecord EntityGet()
        {
            VendorTrackRecord entity = new VendorTrackRecord();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date;
            if (HTFormStatus == FormStatus.����)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = DateTime.Now.Date;
            }
  			entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.SaleOPID = SysConvert.ToString(txtSaleOPID.Tag);
  			entity.TrackType = drpTrackType.Text.Trim(); 
  			entity.TrackTitle = txtTrackTitle.Text.Trim();
            entity.TrackContext = txtTrackContext.Text;
            entity.TrackContextRtf = txtTrackContext.RichText;
  			entity.TrackFlag = SysConvert.ToInt32(chkTrackFlag.Checked); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }
        #endregion

        #region �����¼�
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    //FormNoControlRule rule = new FormNoControlRule();
                    //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��ͬ��);
                    ProductCommon.FormNoIniSet(txtFormNo, "Att_VendorTrackRecord", "FormNo");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
}