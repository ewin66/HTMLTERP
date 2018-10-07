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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ��ͻ������ʱ���
    /// 
    /// 
    /// fornlistAID=1 �ɹ�
    /// fornlistAID=2 �ӹ�
    /// fornlistAID=3 ����
    /// </summary>
    public partial class frmVendorInOutRptSum : frmAPBaseUIRpt
    {
        public frmVendorInOutRptSum()
        {
            InitializeComponent();
        }
        private string VendorID = string.Empty;
        

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;

            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
           
           
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            try
            {
                string sql = " Select  VendorID,VendorAttn,0.0 Amount  from Data_Vendor where 1=1";

                if (FormListAID == 1)//�ɹ�
                {
                    sql += " AND VendorID in(select VendorID from Data_VendorTypeDts where VendorTypeID in (6))";
                }
                if (FormListAID == 2)//�ӹ�
                {
                    sql += " AND VendorID in(select VendorID from Data_VendorTypeDts where VendorTypeID in (2,7,8,9,11,13))";
                }
                if (FormListAID == 3)//����
                {
                    sql += " AND VendorID in(select VendorID from Data_VendorTypeDts where VendorTypeID in (1))";
                }
                DataTable dt = SysUtils.Fill(sql);


                PorcDataTable(dt);

                gridView1.GridControl.DataSource = dt;
                gridView1.GridControl.Show();


                //gridView1.OptionsCustomization.AllowFilter = false;
                //gridView1.OptionsCustomization.AllowSort = false;

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void PorcDataTable(DataTable p_Dt)
        {
            foreach (DataRow dr in p_Dt.Rows)
            {
                string sql = string.Empty;

                decimal QCAmount = 0.0m; //�ڳ����
                sql = "Select SUM(BAmount) QCAmount ";
                sql += " from Finance_BVendorAmount where 1=1";
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(dr["VendorID"]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    QCAmount = SysConvert.ToDecimal(dt.Rows[0]["QCAmount"]);
                }


                decimal DZAmount = 0.0m; //���˽��
                sql = "Select SUM(ISNULL(DZAmount,0)) DZAmount";//���˽��
                sql += " from UV1_WH_IOFOrmDts where 1=1";
                if (FormListAID == 1)//�ɹ�
                {
                    sql += " AND ISNULL(BuyFlag,0)=1";
                }
                if (FormListAID == 2)//�ӹ�
                {
                    sql += " AND ISNULL(ColorFlag,0)=1";
                }
                if (FormListAID == 3)//����
                {
                    sql += " AND ISNULL(SaleFlag,0)=1";
                }
                sql += " AND ISNULL(SubmitFlag,0)=1";//���ύ
                sql += " AND ISNULL(DZFlag,0)=1";//ֻ��ѯ�Թ��ʵ�����
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(dr["VendorID"]));
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    DZAmount = SysConvert.ToDecimal(dt.Rows[0]["DZAmount"]);
                }


                decimal RecPayAmount = 0.0m;//�ո�����
                sql = " Select SUM(ISNULL(ExAmount,0)) Amount";
                sql += " from Finance_RecPay where 1=1";
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(dr["VendorID"]));
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    RecPayAmount = SysConvert.ToDecimal(dt.Rows[0]["Amount"]);
                }

                decimal HKAmount = 0.0m;//������
                sql = " Select  SUM(ISNULL(Amount,0)) Amount";
                sql += " from Finance_PaymentHandle where 1=1";
                sql += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(dr["VendorID"]));
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    HKAmount = SysConvert.ToDecimal(dt.Rows[0]["Amount"]);
                }


                dr["Amount"] = SysConvert.ToDecimal(QCAmount + DZAmount - RecPayAmount - HKAmount);
            }
        }

        
        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "CaiWu_CWPay";
            this.HTDataList = gridView1;

            DevMethod.BindVendorByDZTypeID(drpQVendorID, this.FormListAID, true);
            //new VendorProc(drpQVendorID);

            btnPrintVisible = true;


            //IsPostBack = false;
          
        }



        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private CWPay EntityGet()
        {
            CWPay entity = new CWPay();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

 

        private void drpQVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
     


        #region ��ӡ����¼�

        /// <summary>
        /// �󶨱�������
        /// </summary>
        public virtual void BindReport(DevComponents.DotNetBar.ComboBoxItem p_DrpID)
        {
            if (FormID != 0)
            {
                string sql = "SELECT ReportName,ID FROM dbo.Data_ReportManage where ";//WinListID = " +  FormID.ToString() + "

                sql += " WinID=" + this.FormID;
                sql += " AND HeadTypeID=" + this.FormListAID;
                sql += " AND SubTypeID=" + this.FormListBID;
                sql += " ORDER BY Seq";
                DataTable dt = SysUtils.Fill(sql);
                FCommon.LoadDropDNBarComb(p_DrpID, dt, "ID", "ReportName", true);
                if (dt.Rows.Count > 0)
                {
                    p_DrpID.SelectedIndex = 1;
                }
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
                //VendorID = drpQVendorID.EditValue.ToString();
                //if (VendorID == string.Empty)
                //{
                //    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                //    return;
                //}

                //DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                //if (ci.SelectedItem == null)
                //{
                //    this.ShowMessage("��ѡ�񱨱�ģ��");
                //    return;
                //}
                //int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                //if (tempReportID == 0)
                //{
                //    this.ShowMessage("��ѡ�񱨱�ģ��");
                //    return;
                //}
                //FastReport.ReportRun(tempReportID, (int)ReportPrintType.���, new string[] { "VendorID" }, new string[] { VendorID.ToString() });




                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                if (ci.SelectedItem == null)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }

                if (tempReportID == 125)//�̶������ʽ
                {

               
                    DataTable dtMain = new DataTable();
                    dtMain.TableName = "Main";

                    dtMain.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
                    //dtMain.Columns.Add(new DataColumn("DataTime1", typeof(DateTime)));
                    //dtMain.Columns.Add(new DataColumn("DataTime2", typeof(DateTime)));

                    DataRow dr = dtMain.NewRow();
                    dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(drpQVendorID.EditValue));
               
                    dtMain.Rows.Add(dr);

                    DataTable dtDetail = (DataTable)gridView1.GridControl.DataSource;
                    dtDetail.TableName = "Detail";

                    //FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.���, new DataTable[] { dtMain, dtDetail });
                }
                else
                {
                    //FastReport.ReportRun(tempReportID, (int)ReportPrintType.���, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
                }


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// Ԥ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                if (ci.SelectedItem == null)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }

                if (tempReportID == 125)//�̶������ʽ
                {


                    DataTable dtMain = new DataTable();
                    dtMain.TableName = "Main";

                    dtMain.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
                    //dtMain.Columns.Add(new DataColumn("DataTime1", typeof(DateTime)));
                    //dtMain.Columns.Add(new DataColumn("DataTime2", typeof(DateTime)));

                    DataRow dr = dtMain.NewRow();
                    dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(drpQVendorID.EditValue));
                    //dr["DataTime1"] = txtQIndateS.DateTime.Date;
                    //dr["DataTime2"] = txtQIndateE.DateTime.Date;
                    dtMain.Rows.Add(dr);

                    DataTable dtDetail = (DataTable)gridView1.GridControl.DataSource;
                    dtDetail.TableName = "Detail";

                    //FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.Ԥ��, new DataTable[] { dtMain, dtDetail });
                }
                else
                {
                    //FastReport.ReportRun(tempReportID, (int)ReportPrintType.Ԥ��, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
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

                if (HTDataID == 0)
                {
                    this.ShowMessage("��ѡ��Ҫ�����ļ�¼");
                    return;
                }

                DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
                if (ci.SelectedItem == null)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }
                int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
                if (tempReportID == 0)
                {
                    this.ShowMessage("��ѡ�񱨱�ģ��");
                    return;
                }


                if (tempReportID == 125)//�̶������ʽ
                {


                    DataTable dtMain = new DataTable();
                    dtMain.TableName = "Main";

                    dtMain.Columns.Add(new DataColumn("VendorAttn", typeof(string)));
                    //dtMain.Columns.Add(new DataColumn("DataTime1", typeof(DateTime)));
                    //dtMain.Columns.Add(new DataColumn("DataTime2", typeof(DateTime)));

                    DataRow dr = dtMain.NewRow();
                    dr["VendorAttn"] = Common.GetVendorNameByVendorID(SysConvert.ToString(drpQVendorID.EditValue));
                    //dr["DataTime1"] = txtQIndateS.DateTime.Date;
                    //dr["DataTime2"] = txtQIndateE.DateTime.Date;
                    dtMain.Rows.Add(dr);

                    DataTable dtDetail = (DataTable)gridView1.GridControl.DataSource;
                    dtDetail.TableName = "Detail";

                    //FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.��ӡ, new DataTable[] { dtMain, dtDetail });
                }
                else
                {
                    //FastReport.ReportRun(tempReportID, (int)ReportPrintType.��ӡ, new string[] { "ID", "MainID" }, new string[] { HTDataID.ToString(), HTDataID.ToString() });
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