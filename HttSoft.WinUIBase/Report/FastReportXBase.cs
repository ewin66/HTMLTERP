using System;
using System.Collections.Generic;
using System.Text;
using FastReport;
using System.Collections;
using System.Data;
using HttSoft.FrameFunc;
using HttSoft.Framework;

namespace HttSoft.WinUIBase
{
    /// <summary>
    /// FastReport.net�Ļ����
    /// </summary>
    public class FastReportXBase
    {
        private Report reportX = null;
        /// <summary>
        /// ���췽��
        /// </summary>
        public FastReportXBase()
        {
            reportX = null;
        }

        #region ��������
        private string reportTemplate = string.Empty;
        /// <summary>
        /// ģ������(����·��)
        /// </summary>
        public string ReportTemplate
        {
            get { return reportTemplate; }
            set { reportTemplate = value; }
        }
        #endregion

        #region ������
        /// <summary>
        /// �򿪱���
        /// </summary>
        public void OpenReport()
        {
            try
            {
                reportX = new Report();
                reportX.Load(reportTemplate);
            }
            catch (Exception ex)
            {
                CloseReport();
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// ���ñ��������Դ
        /// </summary>
        /// <param name="lstDs"></param>
        public void ReportRegisterData(List<RptDataSrcEntity> lstDs)
        {
            DataTable dt = null;
            foreach (RptDataSrcEntity rdse in lstDs)
            {
                if (rdse.IsSqlPrint == false) //������Ǹ������õ�SQL���д�ӡ
                {
                    dt = rdse.DtPrint;
                    if (dt != null)
                    {
                        dt.TableName = rdse.DataSetName;
                    }
                }
                else
                {
                    string strSql = rdse.SqlContent + " " + rdse.SqlCondition;
                    dt = SysUtils.Fill(strSql);
                    if (dt != null)
                    {
                        dt.TableName = rdse.DataSetName;
                    }
                }
                if (dt != null)
                {
                    reportX.RegisterData(dt, rdse.DataSetName);
                    reportX.GetDataSource(rdse.DataSetName).Enabled = true;
                }
            }
        }
        /// <summary>
        /// Ԥ������
        /// </summary>
        public void ShowReport()
        {
            try
            {
                reportX.Show();
            }
            catch (Exception ex)
            {
                CloseReport();
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// ��Ʊ���
        /// </summary>
        public void DesignReport()
        {
            try
            {
                reportX.Design();
            }
            catch (Exception ex)
            {
                CloseReport();
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// ��ӡ����
        /// </summary>
        public void PrintReport()
        {
            try
            {
                reportX.Load(reportTemplate);
                reportX.PrintPrepared();
                reportX.PrintSettings.ShowDialog = false;
                reportX.Print();
            }
            catch (Exception ex)
            {
                CloseReport();
                throw new Exception(ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// �ر�FastReport����
        /// </summary>
        public void CloseReport()
        {
            if (reportX != null)
            {
                reportX.Clear();
            }
            reportX = null;
            System.GC.Collect();
        }
    }
}
