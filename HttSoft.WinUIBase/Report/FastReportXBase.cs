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
    /// FastReport.net的基类库
    /// </summary>
    public class FastReportXBase
    {
        private Report reportX = null;
        /// <summary>
        /// 构造方法
        /// </summary>
        public FastReportXBase()
        {
            reportX = null;
        }

        #region 报表属性
        private string reportTemplate = string.Empty;
        /// <summary>
        /// 模板名称(包含路径)
        /// </summary>
        public string ReportTemplate
        {
            get { return reportTemplate; }
            set { reportTemplate = value; }
        }
        #endregion

        #region 报表功能
        /// <summary>
        /// 打开报表
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
        /// 设置报表的数据源
        /// </summary>
        /// <param name="lstDs"></param>
        public void ReportRegisterData(List<RptDataSrcEntity> lstDs)
        {
            DataTable dt = null;
            foreach (RptDataSrcEntity rdse in lstDs)
            {
                if (rdse.IsSqlPrint == false) //如果不是根据配置的SQL进行打印
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
        /// 预览报表
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
        /// 设计报表
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
        /// 打印报表
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
        /// 关闭FastReport报表
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
