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
    public partial class frmSendSampleEdit : frmAPBaseUISinEdit
    {
        public frmSendSampleEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("���������");
            //    txtTitle.Focus();
            //    return false;
            //}      

            if (txtItemCode.Text.Trim() == "")
            {
                this.ShowMessage("�������Ʒ����");
                txtItemCode.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
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
            SendSampleRule rule = new SendSampleRule();
            SendSample entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            SendSampleRule rule = new SendSampleRule();
            SendSample entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            SendSample entity = new SendSample();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtMakeDate.DateTime = entity.MakeDate; 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtFormNo.Text = entity.FormNo.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  			drpVendorID.EditValue = entity.VendorID.ToString(); 
  			txtFactoryID.Text = entity.FactoryID.ToString(); 
  			txtVendorOPName.Text = entity.VendorOPName.ToString(); 
  			txtItemCode.Text = entity.ItemCode.ToString(); 
  			txtItemName.Text = entity.ItemName.ToString(); 
  			txtItemStd.Text = entity.ItemStd.ToString(); 
  			txtItemModel.Text = entity.ItemModel.ToString(); 
  			txtMWidth.Text = entity.MWidth.ToString(); 
  			txtMWeight.Text = entity.MWeight.ToString(); 
  			txtMWeight2.Text = entity.MWeight2.ToString(); 
  			txtColorNum.Text = entity.ColorNum.ToString(); 
  			txtColorName.Text = entity.ColorName.ToString(); 
  			txtDensity.Text = entity.Density.ToString(); 
  			txtFacricPrice.Text = entity.FacricPrice.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtGYOPName.Text = entity.GYOPName.ToString(); 
  			txtFinishDate.DateTime = entity.FinishDate; 
  			txtFlower.Text = entity.Flower.ToString(); 
  			txtSampTypeID.Text = entity.SampTypeID.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            SendSampleRule rule = new SendSampleRule();
            SendSample entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);

            txtFormNo.Properties.ReadOnly = true;
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_SendSample";

            Common.BindVendor(drpVendorID, new int[] {(int)EnumVendorType.�ͻ� }, true);
            new VendorProc(drpVendorID);

            this.ToolBarItemAdd(28, "btnkLoadItem", "���ز�Ʒ", false, btnkLoadItem_Click);
            //
        }


        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtFormNo_DoubleClick(null, null);
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtMakeOPName.Text = FParamConfig.LoginName;
            txtFormDate.DateTime = DateTime.Now.Date;
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SendSample EntityGet()
        {
            SendSample entity = new SendSample();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.MakeDate = txtMakeDate.DateTime.Date; 
  			entity.MakeOPName = txtMakeOPName.Text.Trim(); 
  			entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.VendorID = SysConvert.ToString(drpVendorID.EditValue); 
  			entity.FactoryID = txtFactoryID.Text.Trim(); 
  			entity.VendorOPName = txtVendorOPName.Text.Trim(); 
  			entity.ItemCode = txtItemCode.Text.Trim(); 
  			entity.ItemName = txtItemName.Text.Trim(); 
  			entity.ItemStd = txtItemStd.Text.Trim(); 
  			entity.ItemModel = txtItemModel.Text.Trim(); 
  			entity.MWidth = txtMWidth.Text.Trim(); 
  			entity.MWeight = txtMWeight.Text.Trim(); 
  			entity.MWeight2 = txtMWeight2.Text.Trim(); 
  			entity.ColorNum = txtColorNum.Text.Trim(); 
  			entity.ColorName = txtColorName.Text.Trim(); 
  			entity.Density = txtDensity.Text.Trim(); 
  			entity.FacricPrice = txtFacricPrice.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.GYOPName = txtGYOPName.Text.Trim(); 
  			entity.FinishDate = txtFinishDate.DateTime.Date; 
  			entity.Flower = txtFlower.Text.Trim(); 
  			entity.SampTypeID = this.FormListAID; 
  			
            return entity;
        }
        #endregion

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule frule = new FormNoControlRule();
                    txtFormNo.Text = frule.RGetFormNo((int)FormNoControlEnum.�������);
                    if (this.FormListAID == 1)
                    {
                        txtFormNo.Text += "A";//LD
                    }
                    if (this.FormListAID == 2)
                    {
                        txtFormNo.Text +=  "B";//S/O
                    }
                    if (this.FormListAID == 3)
                    {
                        txtFormNo.Text +="C";//��ʱ
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region ���ز�Ʒ

        public void btnkLoadItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    frmLoadFabric frm = new frmLoadFabric();
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID != null && frm.GBID.Length != 0)
                    {
                        for (int i = 0; i < frm.GBID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.GBID[i]);
                        }
                        setItemNews(str);
                    }
                }
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews(string str)
        {
            string[] gbid = str.Split(',');
            if (gbid.Length > 0)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[0]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    txtItemCode.Text = SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                    txtItemModel.Text = SysConvert.ToString(dt.Rows[0]["ItemModel"]);


                    if (SysConvert.ToString(dt.Rows[0]["FK"]) != "")
                    {
                        txtMWidth.Text = SysConvert.ToString(dt.Rows[0]["FK"]);
                    }
                    else
                    {
                        txtMWidth.Text = SysConvert.ToString(dt.Rows[0]["MWidth"]);
                    }

                    txtMWeight.Text = SysConvert.ToString(dt.Rows[0]["MWeight"]);
                    txtItemName.Text = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                    txtItemStd.Text = SysConvert.ToString(dt.Rows[0]["ItemStd"]);


                }
            }

        }

        #endregion
    }
}