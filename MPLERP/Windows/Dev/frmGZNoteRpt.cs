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

namespace MLTERP
{
    public partial class frmGZNoteRpt : BaseForm
    {
        public frmGZNoteRpt()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
       
      
        

       

        public  void BindGrid()
        {
            int star = 3;
            for (int i = star; i < 20 + star; i++)
            {
                switch (i)
                {
                    case 3:
                       
                        this.gridColumn3.Caption = DateTime.Now.AddDays(-19).Date.ToString("yyyy/MM/dd") +"   星期" + DateTime.Now.AddDays(-19).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 4:
                        this.gridColumn4.Caption = DateTime.Now.AddDays(-18).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-18).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 5:
                        this.gridColumn5.Caption = DateTime.Now.AddDays(-17).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-17).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 6:
                        this.gridColumn6.Caption = DateTime.Now.AddDays(-16).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-16).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 7:
                        this.gridColumn7.Caption = DateTime.Now.AddDays(-15).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-15).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 8:
                        this.gridColumn8.Caption = DateTime.Now.AddDays(-14).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-14).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 9:
                        this.gridColumn9.Caption = DateTime.Now.AddDays(-13).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-13).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 10:
                        this.gridColumn10.Caption = DateTime.Now.AddDays(-12).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-12).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 11:
                        this.gridColumn11.Caption = DateTime.Now.AddDays(-11).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-11).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 12:
                        this.gridColumn12.Caption = DateTime.Now.AddDays(-10).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-10).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 13:
                        this.gridColumn13.Caption = DateTime.Now.AddDays(-9).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-9).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 14:
                        this.gridColumn14.Caption = DateTime.Now.AddDays(-8).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-8).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 15:
                        this.gridColumn15.Caption = DateTime.Now.AddDays(-7).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-7).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 16:
                        this.gridColumn16.Caption = DateTime.Now.AddDays(-6).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-6).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 17:
                        this.gridColumn17.Caption = DateTime.Now.AddDays(-5).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-5).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 18:
                        this.gridColumn18.Caption = DateTime.Now.AddDays(-4).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-4).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 19:
                        this.gridColumn19.Caption = DateTime.Now.AddDays(-3).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-3).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 20:
                        this.gridColumn20.Caption = DateTime.Now.AddDays(-2).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-2).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 21:
                        this.gridColumn21.Caption = DateTime.Now.AddDays(-1).Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.AddDays(-1).Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                    case 22:
                        this.gridColumn22.Caption = DateTime.Now.Date.ToString("yyyy/MM/dd") + " 星期" + DateTime.Now.Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn")).Replace("周", "");
                        break;
                }
            }

            string sql = "EXEC USP1_Data_GZNoteRpt '' ";
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }


        #endregion

        private void drpYesNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void frmGZNoteRpt_Load(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        //public void NavigateWin(string p_FormClassName, string p_ParentID, FormStatus p_MFormStatus)
        //{
        //    MDIForm.ContextMenuOpenForm(FUISourceObject.GetResultArrayList(FUISourceObject.SourceForm, this), p_FormClassName, this.FormListAID, this.FormListBID, this.SubmitFlag, this.AuditFlag, p_ParentID, p_MFormStatus);
        //}








    }
}