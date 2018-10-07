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
    public partial class frmSOPlanEdit : frmAPBaseUISinEdit
    {
        public frmSOPlanEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtQty.Text.Trim() == "")
            {
                this.ShowMessage("��������������");
                txtQty.Focus();
                return false;
            }            

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            SOPlanRule rule = new SOPlanRule();
            SOPlan entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            SOPlanRule rule = new SOPlanRule();
            SOPlan entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            SOPlan entity = new SOPlan();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();

            HTDataFormNo = entity.Code;

            drpCompanyTypeID.EditValue =entity.CompanyTypeID; 
  			txtCode.Text = entity.Code.ToString(); 
  			drpVendorID.EditValue = entity.VendorID.ToString(); 
  			txtInDate.DateTime = entity.InDate;
            if (entity.NeedDate != SystemConfiguration.DateTimeDefaultValue && SysConvert.ToString(entity.NeedDate) != "")
            {
                txtNeedDate.DateTime = entity.NeedDate;
            }
            else
            {
                txtNeedDate.Text = "";
            }
  			txtSO.Text = entity.SO.ToString(); 
  			drpItemCode.EditValue = entity.ItemCode.ToString(); 
  			txtItemName.Text = entity.ItemName.ToString(); 
  			txtItemStd.Text = entity.ItemStd.ToString(); 
  			txtItemModel.Text = entity.ItemModel.ToString(); 
  			txtCompactQty.Text = entity.CompactQty.ToString(); 
  			txtQty.Text = entity.Qty.ToString();
            drpItemUnit.EditValue = entity.ItemUnit;
            txtMakeOPID.Text = Common.GetOPName(entity.MakeOPID.ToString());
  			txtMakeDate.DateTime = entity.MakeDate; 
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
            SOPlanRule rule = new SOPlanRule();
            SOPlan entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(new Control[] { txtCode,txtMakeDate,txtMakeOPID}, false);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WO_SOPlan";
            //
            //Common.BindCompanyType(drpCompanyTypeID, true);//�󶨹�˾��
            //Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.ȫ�� }, true);//�ͻ�
            //new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, txtItemModel, new int[] {  (int)EnumItemType.���� }, true, true);
           
            this.ToolBarItemAdd(28, "btnLoad", "����", false, btnCheckLoad_Click);

            SetTabIndex(0, groupControlMainten);

        }


        /// <summary>
        /// ��ʼ��ˢ������(�������ʱ���û�ˢ�°�ťʱ����)
        /// </summary>
        public override void IniRefreshData()
        {
            Common.BindCompanyType(drpCompanyTypeID, true);//�󶨹�˾��
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.ȫ�� }, true);//�ͻ�
            new ItemProcLookUp(drpItemCode, txtItemName, txtItemStd, txtItemModel, new int[] { (int)EnumItemType.���� }, true, true);
        }
        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {
            txtMakeOPID.Text = Common.GetOPName(FParamConfig.LoginID);
            txtNeedDate.Text = "";
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtInDate.DateTime = DateTime.Now.Date;
            txtCompactQty.Text = Common.TrimZero(txtCompactQty.Text);
            txtQty.Text = Common.TrimZero(txtQty.Text);

            drpCompanyTypeID.EditValue = 1;
            drpItemUnit.EditValue = "KG";
            
            txtCode_DoubleClick(null,null);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SOPlan EntityGet()
        {
            SOPlan entity = new SOPlan();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue); 
  			entity.Code = txtCode.Text.Trim(); 
  			entity.VendorID =SysConvert.ToString(drpVendorID.EditValue); 
  			entity.InDate = txtInDate.DateTime.Date;

            if (txtNeedDate.DateTime.Date != SystemConfiguration.DateTimeDefaultValue && txtNeedDate.Text.Trim() != "")
            {
                entity.NeedDate = txtNeedDate.DateTime.Date;
            }
  			entity.SO = txtSO.Text.Trim(); 
  			entity.ItemCode =SysConvert.ToString(drpItemCode.EditValue); 
  			entity.ItemName = txtItemName.Text.Trim(); 
  			entity.ItemStd = txtItemStd.Text.Trim(); 
  			entity.ItemModel = txtItemModel.Text.Trim(); 
  			entity.CompactQty = SysConvert.ToDecimal(txtCompactQty.Text.Trim()); 
  			entity.Qty = SysConvert.ToDecimal(txtQty.Text.Trim());
            entity.ItemUnit = SysConvert.ToString(drpItemUnit.EditValue);
            if (HTFormStatus == FormStatus.����)
            {
                entity.MakeOPID = FParamConfig.LoginID;
                entity.MakeDate = txtMakeDate.DateTime.Date;
            }
  			entity.Remark = txtRemark.Text.Trim(); 
  			
            return entity;
        }

        /// <summary>
        /// ���ض���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    SODtsLoad();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        //���ض���
        private void SODtsLoad()
        {
            //frmSODtsLoad frm = new frmSODtsLoad();
            //frm.LoadFormID = this.GetFormIDByClassName("frmSOPlanEdit");
            //frm.ShowDialog();
            //if (frm.HTLoadData.Count != 0)
            //{
            //    string listStr = ((string[])frm.HTLoadData[2])[0];

            //    //��ϸ����
            //    string sql = "SELECT SOID,DtsItemCode,VendorID,CompanyTypeID,SUM(Qty)Qty,ItemUnit FROM UV1_Sale_SODts WHERE 1=1 AND " + listStr + " Group by SOID,DtsItemCode,VendorID,CompanyTypeID,ItemUnit ";
            //    DataTable dt = SysUtils.Fill(sql);
            //    if (dt.Rows.Count != 0)
            //    {
            //        txtSO.Text = dt.Rows[0]["SOID"].ToString();
            //        drpItemCode.EditValue = dt.Rows[0]["DtsItemCode"].ToString();
            //        txtCompactQty.Text = dt.Rows[0]["Qty"].ToString();
            //        drpCompanyTypeID.EditValue = SysConvert.ToInt32(dt.Rows[0]["CompanyTypeID"].ToString());
            //        drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"].ToString());
            //        drpItemUnit.EditValue = SysConvert.ToString(dt.Rows[0]["ItemUnit"].ToString());
            //    }

            //}

        }
        /// <summary>
        /// ���ɵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.����)
                {
                    FormNoControlRule rule = new FormNoControlRule();
                    //txtCode.Text = rule.RGetFormNo((int)FormNoControlEnum.����֪ͨ����);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �����¼�����ӡ��أ�
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //base.btnPreview_Click(sender, e);
                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.Ԥ��, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }
        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //base.btnPrint_Click(sender, e);

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.��ӡ, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                //base.btnDesign_Click(sender, e);
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.�ύ3))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                FastReportX.ReportRun(tempReportID, (int)ReportPrintType.���, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
            }
            catch
            {
            }
        }

        #endregion

        private void drpItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string itemCode = SysConvert.ToString(drpItemCode.EditValue);

                SetStorgeQty(itemCode);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ����һ�����
        /// </summary>
        private void SetStorgeQty(string p_ItemCode)
        {
            string sql = string.Empty;
            DataTable dt;
            decimal tqty = 0;
            string tstr = string.Empty;

            sql = "SELECT WHID,SectionID,Sum(FreeQty) SQty,ColorName,JarNum,ColorNum FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//��ѯɫɴ���
            sql += " AND ISNULL(ISJK,0)=0";
            //sql += " AND WHTypeID=" + (int)WHType.ɫɴ + " AND ISNULL(ISJK,0)=0";
            sql += " GROUP BY WHID,SectionID,ColorNum,JarNum,ColorName ORDER BY SQty DESC";
            dt = SysUtils.Fill(sql);
            tqty = 0;
            tstr = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                tqty += SysConvert.ToDecimal(dr["SQty"]);
                tstr += Environment.NewLine + "������" + Common.GetWHNM(dr["WHID"].ToString()) + " " + dr["SectionID"].ToString() + " ��ɫ��" + dr["ColorName"].ToString() + " ɫ�ţ�" + dr["ColorNum"].ToString() + "   �׺ţ�" + dr["JarNum"].ToString() + "   ������" + SysConvert.ToDecimal(dr["SQty"]) + "KG";
            }
            tstr = "���ϼ�:" + tqty.ToString() + "KG" + tstr;//��ϸ��
            txtWHStorgeQty.Text = tstr;


            sql = "SELECT WHID,Sum(FreeQty) SQty,ColorName,JarNum,ColorNum FROM UV1_WH_Storge WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//��ѯɫɴ���
            sql += " AND ISNULL(ISJK,0)=1";
            //sql += " AND WHTypeID=" + (int)WHType.ɫɴ + " AND ISNULL(ISJK,0)=1";//�Ŀ�
            sql += " GROUP BY WHID,ColorNum,JarNum,ColorName ORDER BY SQty DESC";
            dt = SysUtils.Fill(sql);
            tqty = 0;
            tstr = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                tqty += SysConvert.ToDecimal(dr["SQty"]);
                tstr += Environment.NewLine + "�ֿ⣺" + "" + " ��ɫ��" + dr["ColorName"].ToString() + " ɫ�ţ�" + dr["ColorNum"].ToString() + "   �׺ţ�" + dr["JarNum"].ToString() + "   ������" + SysConvert.ToDecimal(dr["SQty"]) + "KG";
            }
            tstr = "���ϼ�:" + tqty.ToString() + "KG" + tstr;//��ϸ��
            txtWHJKStorgeQty.Text = tstr;
        }


     
    }
}