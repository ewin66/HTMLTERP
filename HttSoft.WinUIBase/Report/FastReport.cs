using System;
using System.Data;
using System.Text;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Collections.Generic;

namespace HttSoft.WinUIBase
{
    /// <summary>
    /// FastReport
    /// </summary>
    public class FastReportX
    {
        private static string TemplateFileRoute = Application.StartupPath;//模板文件路径

        /// <summary>
        /// FastReport
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <param name="reportTypeID">报表类型</param>
        /// <param name="queryName">查询数据名</param>
        /// <param name="queryValue">查询数据值</param>
        public static void ReportRun(int reportID, int reportTypeID, string[] queryName, string[] queryValue)
        {
            FastReportXBase rptBase = new FastReportXBase();
            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                DownFile(reportManage.FileName, reportManage.FileID);


                //rptBase.OpenReport();


                rptBase.ReportTemplate = TemplateFileRoute + reportManage.Url + reportManage.FileName;

                if (!SysFile.CheckFileExit(rptBase.ReportTemplate))
                {
                    throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + rptBase.ReportTemplate);
                }

                rptBase.OpenReport();

                List<RptDataSrcEntity> lstDs = new List<RptDataSrcEntity>();//存放Sql语句的

                ReportManageDtsRule dtsRule = new ReportManageDtsRule();
                DataTable dtSource = dtsRule.RShow(reportManage.ID);
                string sql = "";
                if (dtSource.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSource.Rows)
                    {
                        bool findSource = false;
                        string conditionStr = string.Empty;
                        if (SysConvert.ToInt32(dr["SqlFlag"]) == 0)//不使用SQL语句 (int)YesOrNo.No
                        {
                            string[] tempA = dr["QueryName"].ToString().Split(' ');

                            for (int q = 0; q < queryName.Length; q++)
                            {
                                for (int fi = 0; fi < tempA.Length; fi++)
                                {
                                    if (queryName[q].ToString().ToUpper() == tempA[fi].ToUpper())
                                    {
                                        if (conditionStr != string.Empty)
                                        {
                                            conditionStr += " AND ";
                                        }
                                        conditionStr += queryName[q].ToString() + "=" + SysString.ToDBString(queryValue[q]);
                                        findSource = true; ;
                                        break;
                                    }

                                }
                            }
                        }
                        else//使用标准SQL语句
                        {
                            conditionStr = SysConvert.ToString(dr["QueryName"]).ToUpper();
                            for (int i = 0; i < queryName.Length; i++)
                            {
                                string queryStr = "{" + queryName[i].ToUpper() + "}";
                                conditionStr = conditionStr.Replace(queryStr, queryValue[i]);
                            }
                            if (conditionStr.Contains("{") || conditionStr.Contains("}"))
                            {
                                findSource = false;
                            }
                            else
                            {
                                findSource = true;
                            }
                        }
                        if (findSource)
                        {
                            //sql = "select * from (" + dr["SqlStr"].ToString() + ") a where " + queryName[query].ToString() + " = " + SysString.ToDBString(queryValue[query].ToString());

                            if (SysConvert.ToInt32(dr["SqlFlag"]) == 0)//(int)YesOrNo.No
                            {
                                sql = "select * from (" + dr["SqlStr"].ToString() + ") a where " + conditionStr;// queryName[query].ToString() + " = " + SysString.ToDBString(queryValue[query].ToString());
                            }
                            else
                            {
                                sql = dr["SqlStr"].ToString() + " " + conditionStr;
                            }
                            DataTable dt = new DataTable();
                            try
                            {
                                dt = SysUtils.Fill(sql);
                            }
                            catch
                            {
                                throw new Exception("查询数据源出错,请检查报表配置是否有误");
                            }
                            dt.TableName = dr["SqlName"].ToString();
                            //FrxDataTable frxDataTable = new FrxDataTable(dt);
                            //  frxDataTable.AssignToReport(true, fastReportBase.report);
                            // frxDataTable.AssignToDataBand(dr["DataSourceName"].ToString(), fastReportBase.report);
                            RptDataSrcEntity entity = new RptDataSrcEntity();
                            entity.DataSetName = dr["SqlName"].ToString();
                            entity.IsSqlPrint = true;
                            entity.SqlContent = sql;
                            entity.DtPrint = dt;
                            lstDs.Add(entity);
                        }
                    }
                }


                rptBase.ReportRegisterData(lstDs);

                if (reportTypeID == (int)ReportPrintType.设计)
                {
                    rptBase.DesignReport();

                    //把报表文件保存到数据库
                    ReportFileRule reportFileRule = new ReportFileRule();
                    ReportFile reportFile = new ReportFile();
                    reportFile.ID = reportManage.FileID;
                    reportFile.SelectByID();
                    reportFile.Context = FastReportX.ConvertToBinary(reportManage.FileName);
                    reportFile.UploadTime = DateTime.Now;

                    if (reportFile.ID == 0)
                    {
                        reportFileRule.RAdd(reportFile);
                        if (reportManage.ID != 0)
                        {
                            string s = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(reportFile.ID) + " WHERE ID=" + SysString.ToDBString(reportFile.ID);
                            SysUtils.ExecuteNonQuery(s);
                        }
                    }
                    else
                    {
                        reportFileRule.RUpdate(reportFile);
                    }
                }
                else if (reportTypeID == (int)ReportPrintType.预览)
                {
                    rptBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.转Excel)
                {
                    //  rptBase.ExportToXLS(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".xls");
                    Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".xls");
                }
                else if (reportTypeID == (int)ReportPrintType.转PDF)
                {
                    rptBase.ShowReport();
                    //fastReportBase.ExportToPDF(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                }
                else if (reportTypeID == (int)ReportPrintType.打印)
                {
                    rptBase.PrintReport();
                }

                rptBase.CloseReport();
            }
            catch (Exception E)
            {
                rptBase.CloseReport();
                throw E;
            }
        }
        /// <summary>
        /// FastReport
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <param name="reportTypeID">报表类型</param>
        /// <param name="queryName">查询数据名</param>
        /// <param name="queryValue">查询数据值</param>
        public static void ReportRun(int reportID, int reportTypeID, string[] queryName, string[] queryValue, string printerName)
        {
            FastReportXBase fastReportBase = new FastReportXBase();
            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                DownFile(reportManage.FileName, reportManage.FileID);

                fastReportBase.ReportTemplate = TemplateFileRoute + reportManage.Url + reportManage.FileName;
                if (!SysFile.CheckFileExit(fastReportBase.ReportTemplate))
                {
                    throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + fastReportBase.ReportTemplate);
                }

                fastReportBase.OpenReport();

                ReportManageDtsRule dtsRule = new ReportManageDtsRule();
                DataTable dtSource = dtsRule.RShow(reportManage.ID);
                string sql = "";
                if (dtSource.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSource.Rows)
                    {
                        int query = 0;
                        bool findSource = false;
                        for (int q = 0; q < queryName.Length; q++)
                        {
                            if (queryName[q].ToString().ToUpper() == dr["QueryName"].ToString().ToUpper())
                            {
                                query = q;
                                findSource = true;
                                break;
                            }
                        }
                        if (findSource)
                        {
                            sql = "select * from (" + dr["SqlStr"].ToString() + ") a where " + queryName[query].ToString() + " = " + SysString.ToDBString(queryValue[query].ToString());
                            DataTable dt = SysUtils.Fill(sql);
                            dt.TableName = dr["SqlName"].ToString();
                            //FrxDataTable frxDataTable = new FrxDataTable(dt);
                            //frxDataTable.AssignToReport(true, fastReportBase.report);
                            // frxDataTable.AssignToDataBand(dr["DataSourceName"].ToString(), fastReportBase.report);
                        }
                    }
                }

                if (reportTypeID == (int)ReportPrintType.设计)
                {
                    fastReportBase.DesignReport();

                    //把报表文件保存到数据库
                    ReportFileRule reportFileRule = new ReportFileRule();
                    ReportFile reportFile = new ReportFile();
                    reportFile.ID = reportManage.FileID;
                    reportFile.SelectByID();
                    reportFile.Context = FastReportX.ConvertToBinary(reportManage.FileName);
                    reportFile.UploadTime = DateTime.Now;

                    if (reportFile.ID == 0)
                    {
                        reportFileRule.RAdd(reportFile);
                        if (reportManage.ID != 0)
                        {
                            string s = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(reportFile.ID) + " WHERE ID=" + SysString.ToDBString(reportFile.ID);
                            SysUtils.ExecuteNonQuery(s);
                        }
                    }
                    else
                    {
                        reportFileRule.RUpdate(reportFile);
                    }
                }
                else if (reportTypeID == (int)ReportPrintType.预览)
                {
                    if (printerName == string.Empty)
                    {
                        throw new Exception("指定的打印机不存在请检查");
                    }
                    //fastReportBase.report.PrintOptions.Printer = printerName;
                    //fastReportBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.转Excel)
                {
                    //fastReportBase.ExportToXLS(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".xls");
                    Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".xls");
                }
                else if (reportTypeID == (int)ReportPrintType.转PDF)
                {
                    fastReportBase.ShowReport();
                    //fastReportBase.ExportToPDF(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                }
                else if (reportTypeID == (int)ReportPrintType.打印)
                {
                    if (printerName == string.Empty)
                    {
                        throw new Exception("指定的打印机不存在请检查");
                    }
                    //fastReportBase.report.PrintOptions.Printer = printerName;
                    //fastReportBase.PrintReport();
                }

                fastReportBase.CloseReport();
            }
            catch (Exception E)
            {
                fastReportBase.CloseReport();
                throw E;
            }
        }

        /// <summary>
        /// FastReport
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <param name="reportTypeID">报表类型</param>
        /// <param name="dt">数据源表</param>
        public static void ReportRunTable(int reportID, int reportTypeID, DataTable dt)
        {
            FastReportXBase rptBase = new FastReportXBase();
            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                DownFile(reportManage.FileName, reportManage.FileID);


                //rptBase.OpenReport();


                rptBase.ReportTemplate = TemplateFileRoute + reportManage.Url + reportManage.FileName;

                if (!SysFile.CheckFileExit(rptBase.ReportTemplate))
                {
                    throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + rptBase.ReportTemplate);
                }

                rptBase.OpenReport();
                List<RptDataSrcEntity> lstDs = new List<RptDataSrcEntity>();//存放Sql语句的
                ReportManageDtsRule dtsRule = new ReportManageDtsRule();
                DataTable dtSource = dtsRule.RShow(reportManage.ID);
                //string sql = "";
                if (dtSource.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSource.Rows)
                    {
                        dt.TableName = dr["SqlName"].ToString();
                        //FrxDataTable frxDataTable = new FrxDataTable(dt);



                        RptDataSrcEntity entity = new RptDataSrcEntity();
                        entity.DataSetName = dr["SqlName"].ToString();
                        entity.IsSqlPrint = false;
                        entity.SqlContent = dr["SqlStr"].ToString();
                        entity.DtPrint = dt;
                        lstDs.Add(entity);
                        //frxDataTable.AssignToReport(true, fastReportBase.report);
                        //frxDataTable.AssignToDataBand(dr["DataSourceName"].ToString(), fastReportBase.report);
                    }

                }
                else
                {
               
                 
                    RptDataSrcEntity entity = new RptDataSrcEntity();
                    entity.DataSetName = "Main";
                    entity.IsSqlPrint = false;
                    entity.SqlContent = "";
                    entity.DtPrint = dt;
                    lstDs.Add(entity);
                }


                rptBase.ReportRegisterData(lstDs);

                if (reportTypeID == (int)ReportPrintType.设计)
                {
                    rptBase.DesignReport();

                    //把报表文件保存到数据库
                    ReportFileRule reportFileRule = new ReportFileRule();
                    ReportFile reportFile = new ReportFile();
                    reportFile.ID = reportManage.FileID;
                    reportFile.SelectByID();
                    reportFile.Context = FastReportX.ConvertToBinary(reportManage.FileName);
                    reportFile.UploadTime = DateTime.Now;

                    if (reportFile.ID == 0)
                    {
                        reportFileRule.RAdd(reportFile);
                        if (reportManage.ID != 0)
                        {
                            string s = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(reportFile.ID) + " WHERE ID=" + SysString.ToDBString(reportFile.ID);
                            SysUtils.ExecuteNonQuery(s);
                        }
                    }
                    else
                    {
                        reportFileRule.RUpdate(reportFile);
                    }
                }
                else if (reportTypeID == (int)ReportPrintType.预览)
                {
                    rptBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.转Excel)
                {
                    //  rptBase.ExportToXLS(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".xls");
                    Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".xls");
                }
                else if (reportTypeID == (int)ReportPrintType.转PDF)
                {
                    rptBase.ShowReport();
                    //fastReportBase.ExportToPDF(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                }
                else if (reportTypeID == (int)ReportPrintType.打印)
                {
                    rptBase.PrintReport();
                }


                rptBase.CloseReport();
            }
            catch (Exception E)
            {
                rptBase.CloseReport();
                throw E;
            }
        }
        /// <summary>
        /// FastReport
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <param name="reportTypeID">报表类型</param>
        /// <param name="dt">数据源表</param>
        public static void ReportRunTable(int reportID, int reportTypeID, DataTable dt, string p_PrinterName)
        {
            FastReportXBase fastReportBase = new FastReportXBase();
            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                DownFile(reportManage.FileName, reportManage.FileID);

                fastReportBase.ReportTemplate = TemplateFileRoute + reportManage.Url + reportManage.FileName;
                if (!SysFile.CheckFileExit(fastReportBase.ReportTemplate))
                {
                    throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + fastReportBase.ReportTemplate);
                }

                fastReportBase.OpenReport();

                ReportManageDtsRule dtsRule = new ReportManageDtsRule();
                DataTable dtSource = dtsRule.RShow(reportManage.ID);
                //string sql = "";
                if (dtSource.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSource.Rows)
                    {
                        dt.TableName = dr["SqlName"].ToString();
                        //FrxDataTable frxDataTable = new FrxDataTable(dt);
                        //frxDataTable.AssignToReport(true, fastReportBase.report);
                        //frxDataTable.AssignToDataBand(dr["DataSourceName"].ToString(), fastReportBase.report);
                    }
                }

                if (reportTypeID == (int)ReportPrintType.设计)
                {
                    fastReportBase.DesignReport();

                    //把报表文件保存到数据库
                    ReportFileRule reportFileRule = new ReportFileRule();
                    ReportFile reportFile = new ReportFile();
                    reportFile.ID = reportManage.FileID;
                    reportFile.SelectByID();
                    reportFile.Context = FastReportX.ConvertToBinary(reportManage.FileName);
                    reportFile.UploadTime = DateTime.Now;

                    if (reportFile.ID == 0)
                    {
                        reportFileRule.RAdd(reportFile);
                        if (reportManage.ID != 0)
                        {
                            string s = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(reportFile.ID) + " WHERE ID=" + SysString.ToDBString(reportFile.ID);
                            SysUtils.ExecuteNonQuery(s);
                        }
                    }
                    else
                    {
                        reportFileRule.RUpdate(reportFile);
                    }
                }
                else if (reportTypeID == (int)ReportPrintType.预览)
                {
                    if (p_PrinterName == string.Empty)
                    {
                        throw new Exception("你指定的打印机名称找不到请检查");
                    }
                    //fastReportBase.report.PrintOptions.Printer = p_PrinterName;
                    fastReportBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.转Excel)
                {
                    //fastReportBase.ExportToXLS(TemplateFileRoute + reportManage.Url + reportManage.ReportName + "xls");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + "xls");
                }
                else if (reportTypeID == (int)ReportPrintType.转PDF)
                {
                    //fastReportBase.ExportToPDF(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                }
                else if (reportTypeID == (int)ReportPrintType.打印)
                {
                    if (p_PrinterName == string.Empty)
                    {
                        throw new Exception("你指定的打印机名称找不到请检查");
                    }
                    //fastReportBase.report.PrepareReport(false);
                    //fastReportBase.report.PrintOptions.ShowDialog = false;
                    //fastReportBase.report.PrintOptions.Printer = p_PrinterName;
                    //fastReportBase.report.ShowProgress = false;
                    //fastReportBase.report.PrintReport();

                    //fastReportBase.PrintReport();
                }

                fastReportBase.CloseReport();
            }
            catch (Exception E)
            {
                fastReportBase.CloseReport();
                throw E;
            }
        }

        /// <summary>
        /// 获取报表图片
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <returns></returns>
        public static Image GetReportImage(int reportID)
        {
            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                return Image.FromFile(TemplateFileRoute + reportManage.Url + reportManage.FileName.Substring(0, reportManage.FileName.IndexOf(".")) + ".1.bmp");
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        /// <summary>
        /// 将文件转换成二进制
        /// </summary>
        /// <returns></returns>
        public static byte[] ConvertToBinary(string name)
        {
            try
            {
                System.IO.FileStream stream = new System.IO.FileInfo(TemplateFileRoute + "\\Report\\" + name).OpenRead();
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
                return buffer;
            }
            catch
            {
                // throw E;
                return null;
            }
        }

        /// <summary>
        /// 将二进制转换成文件
        /// </summary>
        /// <returns></returns>
        public static void ConvertToFile(string name, byte[] context)
        {
            System.IO.FileStream fStream = null;
            try
            {
                if (!SysFile.CheckDDirectoryExit(TemplateFileRoute + "\\Report\\"))
                {
                    SysFile.CreateDDirectory(TemplateFileRoute + "\\Report\\");
                }
                string filePath = TemplateFileRoute + "\\Report\\" + name;//文件路径
                byte[] br = context;
                fStream = System.IO.File.Create(filePath, br.Length);
                fStream.Write(br, 0, br.Length);//二进制转换成文件
            }
            catch
            {
            }
            finally
            {
                fStream.Close();
            }
        }

        /// <summary>
        /// 将文件转换成二进制
        /// </summary>
        /// <returns></returns>
        public static byte[] ConvertToBinaryByPath(string path)
        {
            try
            {
                System.IO.FileStream stream = new System.IO.FileInfo(path).OpenRead();
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
                return buffer;
            }
            catch
            {

                return null;
            }
        }

        /// <summary>
        /// 将二进制转换成文件
        /// </summary>
        /// <returns></returns>
        public static void ConvertToFileByPath(string path, byte[] context)
        {
            System.IO.FileStream fStream = null;
            try
            {
                string filePath = path;//文件路径
                byte[] br = context;
                fStream = System.IO.File.Create(filePath, br.Length);
                fStream.Write(br, 0, br.Length);//二进制转换成文件
            }
            catch
            {
            }
            finally
            {
                fStream.Close();
            }
        }

        /// <summary>
        /// 下载报表文件
        /// </summary>
        public static bool DownFileModel(string fileName, int fileID)
        {
            string sql = "SELECT Context FROM Data_ReportFileModel WHERE ID =" + fileID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                byte[] file = (byte[])dt.Rows[0]["Context"];
                ConvertToFile(fileName, file);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 下载报表文件
        /// </summary>
        public static bool DownFile(string fileName, int fileID)
        {
            string sql = "SELECT Context FROM Data_ReportFile WHERE ID = " + fileID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                byte[] file = (byte[])dt.Rows[0]["Context"];
                ConvertToFile(fileName, file);
                return true;
            }
            else
            {
                return false;
            }
        }
    }




    /// <summary>
    /// FastReport
    /// </summary>
    public class FastReport
    {
        private static string TemplateFileRoute = Application.StartupPath;//模板文件路径

        /// <summary>
        /// FastReport
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <param name="reportTypeID">报表类型</param>
        /// <param name="queryName">查询数据名</param>
        /// <param name="queryValue">查询数据值</param>
        public static void ReportRun(int reportID, int reportTypeID, string[] queryName, string[] queryValue)
        {


            FastReportXBase rptBase = new FastReportXBase();


            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                DownFile(reportManage.FileName, reportManage.FileID);


                //rptBase.OpenReport();


                rptBase.ReportTemplate = TemplateFileRoute + reportManage.Url + reportManage.FileName;

                if (!SysFile.CheckFileExit(rptBase.ReportTemplate))
                {
                    throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + rptBase.ReportTemplate);
                }

                rptBase.OpenReport();

                List<RptDataSrcEntity> lstDs = new List<RptDataSrcEntity>();//存放Sql语句的

                ReportManageDtsRule dtsRule = new ReportManageDtsRule();
                DataTable dtSource = dtsRule.RShow(reportManage.ID);
                string sql = "";
                if (dtSource.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSource.Rows)
                    {
                      
                        string conditionStr = string.Empty;

                        bool findSource = false;

                        if (SysConvert.ToInt32(dr["SqlFlag"]) == 0)
                        {
                            string[] tempA = dr["QueryName"].ToString().Split(' ');
                            for (int q = 0; q < queryName.Length; q++)
                            {
                                for (int fi = 0; fi < tempA.Length; fi++)
                                {
                                    if (queryName[q].ToString().ToUpper() == tempA[fi].ToUpper())
                                    {
                                        if (conditionStr != string.Empty)
                                        {
                                            conditionStr += " AND ";
                                        }
                                        conditionStr += queryName[q].ToString() + "=" + SysString.ToDBString(queryValue[q]);

                                        conditionStr += SysConvert.ToString(dr["OrderCondition"]);

                                        findSource = true;
                                        break;
                                    }
                                }

                                //if (queryName[q].ToString().ToUpper() == dr["QueryName"].ToString().ToUpper())
                                //{
                                //    query = q;
                                //    findSource = true;
                                //    break;
                                //}
                            }
                        }
                        else
                        {
                            conditionStr = SysConvert.ToString(dr["QueryName"]).ToUpper();
                            for (int i = 0; i < queryName.Length; i++)
                            {
                                string queryStr = "{" + queryName[i].ToUpper() + "}";

                                conditionStr = conditionStr.Replace(queryStr, SysString.ToDBString(queryValue[i]));
                            }
                            if (conditionStr.Contains("{") || conditionStr.Contains("}"))
                            {
                                findSource = false;
                            }
                            else
                            {
                                findSource = true;
                            }
                        }
                        if (findSource)
                        {
                            //if (SysConvert.ToInt32(dr["SourceType"]) != 2)
                            //{
                                 if (SysConvert.ToInt32(dr["SqlFlag"]) == 0)
                            {
                                //sql = "select * from (" + dr["SqlStr"].ToString() + ") a where " + queryName[query].ToString() + " = " + SysString.ToDBString(queryValue[query].ToString());
                                sql = "select * from (" + dr["SqlStr"].ToString() + ") a where " + conditionStr;// queryName[query].ToString() + " = " + SysString.ToDBString(queryValue[query].ToString());
                            }
                            else
                            {
                                sql = dr["SqlStr"].ToString() + " " + queryValue[0];
                            }
                            DataTable dt = SysUtils.Fill(sql);
                            dt.TableName = dr["SqlName"].ToString();
                            //FrxDataTable frxDataTable = new FrxDataTable(dt);
                            //  frxDataTable.AssignToReport(true, fastReportBase.report);
                            // frxDataTable.AssignToDataBand(dr["DataSourceName"].ToString(), fastReportBase.report);
                            RptDataSrcEntity entity = new RptDataSrcEntity();
                            entity.DataSetName = dr["SqlName"].ToString();
                            entity.IsSqlPrint = true;
                            entity.SqlContent = sql;
                            entity.DtPrint = dt;
                            //if (SysConvert.ToInt32(dr["SourceType"]) == 2)
                            //{
                            //    entity.SourceType = 2;
                            //}
                            lstDs.Add(entity);
                        }
                        else
                        {
                            if (dr["SqlStr"].ToString() != string.Empty)
                            {
                                sql = dr["SqlStr"].ToString();
                                DataTable dt = SysUtils.Fill(sql);
                                dt.TableName = dr["SqlName"].ToString();

                                RptDataSrcEntity entity = new RptDataSrcEntity();
                                entity.DataSetName = dr["SqlName"].ToString();
                                entity.IsSqlPrint = true;
                                entity.SqlContent = sql;
                                entity.DtPrint = dt;
                                //if (SysConvert.ToInt32(dr["SourceType"]) == 2)
                                //{
                                //    entity.SourceType = 2;
                                //}
                                lstDs.Add(entity);
                            }
                        }
                    }
                }


                rptBase.ReportRegisterData(lstDs);

                if (reportTypeID == (int)ReportPrintType.设计)
                {
                    rptBase.DesignReport();

                    //把报表文件保存到数据库
                    ReportFileRule reportFileRule = new ReportFileRule();
                    ReportFile reportFile = new ReportFile();
                    reportFile.ID = reportManage.FileID;
                    reportFile.SelectByID();
                    reportFile.Context = FastReport.ConvertToBinary(reportManage.FileName);
                    reportFile.UploadTime = DateTime.Now;

                    if (reportFile.ID == 0)
                    {
                        reportFileRule.RAdd(reportFile);
                        if (reportManage.ID != 0)
                        {
                            string s = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(reportFile.ID) + " WHERE ID=" + SysString.ToDBString(reportFile.ID);
                            SysUtils.ExecuteNonQuery(s);
                        }
                    }
                    else
                    {
                        reportFileRule.RUpdate(reportFile);
                    }
                }
                else if (reportTypeID == (int)ReportPrintType.预览)
                {
                    rptBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.转Excel)
                {
                    //  rptBase.ExportToXLS(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".xls");
                    Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".xls");
                }
                else if (reportTypeID == (int)ReportPrintType.转PDF)
                {
                    rptBase.ShowReport();
                    //fastReportBase.ExportToPDF(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                }
                else if (reportTypeID == (int)ReportPrintType.打印)
                {
                    rptBase.PrintReport();
                }

                rptBase.CloseReport();
            }
            catch (Exception E)
            {
                rptBase.CloseReport();
                throw E;
            }
        }
        /// <summary>
        /// FastReport
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <param name="reportTypeID">报表类型</param>
        /// <param name="queryName">查询数据名</param>
        /// <param name="queryValue">查询数据值</param>
        public static void ReportRun(int reportID, int reportTypeID, string[] queryName, string[] queryValue, string printerName)
        {
            FastReportXBase fastReportBase = new FastReportXBase();
            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                DownFile(reportManage.FileName, reportManage.FileID);

                fastReportBase.ReportTemplate = TemplateFileRoute + reportManage.Url + reportManage.FileName;
                if (!SysFile.CheckFileExit(fastReportBase.ReportTemplate))
                {
                    throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + fastReportBase.ReportTemplate);
                }

                fastReportBase.OpenReport();

                ReportManageDtsRule dtsRule = new ReportManageDtsRule();
                DataTable dtSource = dtsRule.RShow(reportManage.ID);
                string sql = "";
                if (dtSource.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSource.Rows)
                    {
                        int query = 0;
                        bool findSource = false;
                        for (int q = 0; q < queryName.Length; q++)
                        {
                            if (queryName[q].ToString().ToUpper() == dr["QueryName"].ToString().ToUpper())
                            {
                                query = q;
                                findSource = true;
                                break;
                            }
                        }
                        if (findSource)
                        {
                            sql = "select * from (" + dr["SqlStr"].ToString() + ") a where " + queryName[query].ToString() + " = " + SysString.ToDBString(queryValue[query].ToString());

                            DataTable dt = SysUtils.Fill(sql);
                            if (SysConvert.ToInt32(dr["SourceType"]) == 2)
                            {
                                dt = SysUtilsSecond.Fill(sql);
                            }
                            dt.TableName = dr["SqlName"].ToString();
                            //FrxDataTable frxDataTable = new FrxDataTable(dt);

                            //frxDataTable.AssignToReport(true, fastReportBase.report);
                            // frxDataTable.AssignToDataBand(dr["DataSourceName"].ToString(), fastReportBase.report);
                        }
                    }
                }

                if (reportTypeID == (int)ReportPrintType.设计)
                {
                    fastReportBase.DesignReport();

                    //把报表文件保存到数据库
                    ReportFileRule reportFileRule = new ReportFileRule();
                    ReportFile reportFile = new ReportFile();
                    reportFile.ID = reportManage.FileID;
                    reportFile.SelectByID();
                    reportFile.Context = FastReport.ConvertToBinary(reportManage.FileName);
                    reportFile.UploadTime = DateTime.Now;

                    if (reportFile.ID == 0)
                    {
                        reportFileRule.RAdd(reportFile);
                        if (reportManage.ID != 0)
                        {
                            string s = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(reportFile.ID) + " WHERE ID=" + SysString.ToDBString(reportFile.ID);
                            SysUtils.ExecuteNonQuery(s);
                        }
                    }
                    else
                    {
                        reportFileRule.RUpdate(reportFile);
                    }
                }
                else if (reportTypeID == (int)ReportPrintType.预览)
                {
                    if (printerName == string.Empty)
                    {
                        throw new Exception("指定的打印机不存在请检查");
                    }
                    //fastReportBase.report.PrintOptions.Printer = printerName;
                    //fastReportBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.转Excel)
                {
                    //fastReportBase.ExportToXLS(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".xls");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".xls");
                }
                else if (reportTypeID == (int)ReportPrintType.转PDF)
                {
                    fastReportBase.ShowReport();
                    //fastReportBase.ExportToPDF(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                }
                else if (reportTypeID == (int)ReportPrintType.打印)
                {
                    if (printerName == string.Empty)
                    {
                        throw new Exception("指定的打印机不存在请检查");
                    }
                    //fastReportBase.report.PrintOptions.Printer = printerName;
                    //fastReportBase.PrintReport();
                }

                fastReportBase.CloseReport();
            }
            catch (Exception E)
            {
                fastReportBase.CloseReport();
                throw E;
            }
        }

        /// <summary>
        /// FastReport
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <param name="reportTypeID">报表类型</param>
        /// <param name="dt">数据源表</param>
        public static void ReportRunTable(int reportID, int reportTypeID, DataTable p_dt)
        {
            FastReportXBase rptBase = new FastReportXBase();

            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                DownFile(reportManage.FileName, reportManage.FileID);


                rptBase.ReportTemplate = TemplateFileRoute + reportManage.Url + reportManage.FileName;

                if (!SysFile.CheckFileExit(rptBase.ReportTemplate))
                {
                    throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + rptBase.ReportTemplate);
                }

                rptBase.OpenReport();

                List<RptDataSrcEntity> lstDs = new List<RptDataSrcEntity>();//存放Sql语句的
                RptDataSrcEntity entity = new RptDataSrcEntity();
                entity.DataSetName = "Main";
                entity.IsSqlPrint = false;
                entity.SqlContent = "";
                entity.DtPrint = p_dt;
                lstDs.Add(entity);

                rptBase.ReportRegisterData(lstDs);

                if (reportTypeID == (int)ReportPrintType.设计)
                {
                    rptBase.DesignReport();

                    //把报表文件保存到数据库
                    ReportFileRule reportFileRule = new ReportFileRule();
                    ReportFile reportFile = new ReportFile();
                    reportFile.ID = reportManage.FileID;
                    reportFile.SelectByID();
                    reportFile.Context = FastReport.ConvertToBinary(reportManage.FileName);
                    reportFile.UploadTime = DateTime.Now;

                    if (reportFile.ID == 0)
                    {
                        reportFileRule.RAdd(reportFile);
                        if (reportManage.ID != 0)
                        {
                            string s = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(reportFile.ID) + " WHERE ID=" + SysString.ToDBString(reportFile.ID);
                            SysUtils.ExecuteNonQuery(s);
                        }
                    }
                    else
                    {
                        reportFileRule.RUpdate(reportFile);
                    }
                }
                else if (reportTypeID == (int)ReportPrintType.预览)
                {
                    rptBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.转Excel)
                {
                    //rptBase.ExportToXLS(TemplateFileRoute + reportManage.Url + reportManage.ReportName + "xls");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + "xls");
                }
                else if (reportTypeID == (int)ReportPrintType.转PDF)
                {
                    //rptBase.ExportToPDF(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                }
                else if (reportTypeID == (int)ReportPrintType.打印)
                {
                    rptBase.PrintReport();
                }

                rptBase.CloseReport();
            }
            catch (Exception E)
            {
                rptBase.CloseReport();
                throw E;
            }
        }
        /// <summary>
        /// FastReport
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <param name="reportTypeID">报表类型</param>
        /// <param name="dt">数据源表</param>
        public static void ReportRunTable(int reportID, int reportTypeID, DataTable dt, string p_PrinterName)
        {
            FastReportXBase fastReportBase = new FastReportXBase();
            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                DownFile(reportManage.FileName, reportManage.FileID);

                fastReportBase.ReportTemplate = TemplateFileRoute + reportManage.Url + reportManage.FileName;
                if (!SysFile.CheckFileExit(fastReportBase.ReportTemplate))
                {
                    throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + fastReportBase.ReportTemplate);
                }

                fastReportBase.OpenReport();

                ReportManageDtsRule dtsRule = new ReportManageDtsRule();
                DataTable dtSource = dtsRule.RShow(reportManage.ID);
                //string sql = "";
                if (dtSource.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSource.Rows)
                    {
                        dt.TableName = dr["SqlName"].ToString();
                        //FrxDataTable frxDataTable = new FrxDataTable(dt);
                        //frxDataTable.AssignToReport(true, fastReportBase.report);
                        //frxDataTable.AssignToDataBand(dr["DataSourceName"].ToString(), fastReportBase.report);
                    }
                }

                if (reportTypeID == (int)ReportPrintType.设计)
                {
                    fastReportBase.DesignReport();

                    //把报表文件保存到数据库
                    ReportFileRule reportFileRule = new ReportFileRule();
                    ReportFile reportFile = new ReportFile();
                    reportFile.ID = reportManage.FileID;
                    reportFile.SelectByID();
                    reportFile.Context = FastReport.ConvertToBinary(reportManage.FileName);
                    reportFile.UploadTime = DateTime.Now;

                    if (reportFile.ID == 0)
                    {
                        reportFileRule.RAdd(reportFile);
                        if (reportManage.ID != 0)
                        {
                            string s = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(reportFile.ID) + " WHERE ID=" + SysString.ToDBString(reportFile.ID);
                            SysUtils.ExecuteNonQuery(s);
                        }
                    }
                    else
                    {
                        reportFileRule.RUpdate(reportFile);
                    }
                }
                else if (reportTypeID == (int)ReportPrintType.预览)
                {
                    if (p_PrinterName == string.Empty)
                    {
                        throw new Exception("你指定的打印机名称找不到请检查");
                    }
                    //fastReportBase.report.PrintOptions.Printer = p_PrinterName;
                    fastReportBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.转Excel)
                {
                    //fastReportBase.ExportToXLS(TemplateFileRoute + reportManage.Url + reportManage.ReportName + "xls");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + "xls");
                }
                else if (reportTypeID == (int)ReportPrintType.转PDF)
                {
                    //fastReportBase.ExportToPDF(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                }
                else if (reportTypeID == (int)ReportPrintType.打印)
                {
                    if (p_PrinterName == string.Empty)
                    {
                        throw new Exception("你指定的打印机名称找不到请检查");
                    }
                    //fastReportBase.report.PrepareReport(false);
                    //fastReportBase.report.PrintOptions.ShowDialog = false;
                    //fastReportBase.report.PrintOptions.Printer = p_PrinterName;
                    //fastReportBase.report.ShowProgress = false;
                    //fastReportBase.report.PrintReport();

                    //fastReportBase.PrintReport();
                }

                fastReportBase.CloseReport();
            }
            catch (Exception E)
            {
                fastReportBase.CloseReport();
                throw E;
            }
        }

        /// <summary>
        /// 获取报表图片
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <returns></returns>
        public static Image GetReportImage(int reportID)
        {
            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                return Image.FromFile(TemplateFileRoute + reportManage.Url + reportManage.FileName.Substring(0, reportManage.FileName.IndexOf(".")) + ".1.bmp");
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        /// <summary>
        /// 将文件转换成二进制
        /// </summary>
        /// <returns></returns>
        public static byte[] ConvertToBinary(string name)
        {
            try
            {
                System.IO.FileStream stream = new System.IO.FileInfo(TemplateFileRoute + "\\Report\\" + name).OpenRead();
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
                return buffer;
            }
            catch
            {
                // throw E;
                return null;
            }
        }

        /// <summary>
        /// 将二进制转换成文件
        /// </summary>
        /// <returns></returns>
        public static void ConvertToFile(string name, byte[] context)
        {
            System.IO.FileStream fStream = null;
            try
            {
                if (!SysFile.CheckDDirectoryExit(TemplateFileRoute + "\\Report\\"))
                {
                    SysFile.CreateDDirectory(TemplateFileRoute + "\\Report\\");
                }
                string filePath = TemplateFileRoute + "\\Report\\" + name;//文件路径
                byte[] br = context;
                fStream = System.IO.File.Create(filePath, br.Length);
                fStream.Write(br, 0, br.Length);//二进制转换成文件
            }
            catch
            {
            }
            finally
            {
                fStream.Close();
            }
        }

        /// <summary>
        /// 将文件转换成二进制
        /// </summary>
        /// <returns></returns>
        public static byte[] ConvertToBinaryByPath(string path)
        {
            try
            {
                System.IO.FileStream stream = new System.IO.FileInfo(path).OpenRead();
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
                return buffer;
            }
            catch
            {

                return null;
            }
        }

        /// <summary>
        /// 将二进制转换成文件
        /// </summary>
        /// <returns></returns>
        public static void ConvertToFileByPath(string path, byte[] context)
        {
            System.IO.FileStream fStream = null;
            try
            {
                string filePath = path;//文件路径
                byte[] br = context;
                fStream = System.IO.File.Create(filePath, br.Length);
                fStream.Write(br, 0, br.Length);//二进制转换成文件
            }
            catch
            {
            }
            finally
            {
                fStream.Close();
            }
        }

        /// <summary>
        /// 下载报表文件
        /// </summary>
        public static bool DownFileModel(string fileName, int fileID)
        {
            string sql = "SELECT Context FROM Data_ReportFileModel WHERE ID =" + fileID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                byte[] file = (byte[])dt.Rows[0]["Context"];
                ConvertToFile(fileName, file);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 下载报表文件
        /// </summary>
        public static bool DownFile(string fileName, int fileID)
        {
            string sql = "SELECT Context FROM Data_ReportFile WHERE ID = " + fileID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                byte[] file = (byte[])dt.Rows[0]["Context"];
                ConvertToFile(fileName, file);
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// FastReport（添加多个数据源 送样卡）
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <param name="reportTypeID">报表类型</param>
        /// <param name="dt">数据源表</param>
        public static void ReportRunTable2(int reportID, int reportTypeID, DataTable p_dt1, DataTable p_dt2)
        {
            FastReportXBase rptBase = new FastReportXBase();

            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                DownFile(reportManage.FileName, reportManage.FileID);


                rptBase.ReportTemplate = TemplateFileRoute + reportManage.Url + reportManage.FileName;

                if (!SysFile.CheckFileExit(rptBase.ReportTemplate))
                {
                    throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + rptBase.ReportTemplate);
                }

                rptBase.OpenReport();

                List<RptDataSrcEntity> lstDs = new List<RptDataSrcEntity>();//存放Sql语句的
                RptDataSrcEntity entity = new RptDataSrcEntity();
                entity.DataSetName = "Main";
                entity.IsSqlPrint = false;
                entity.SqlContent = "";
                entity.DtPrint = p_dt1;
                lstDs.Add(entity);

                rptBase.ReportRegisterData(lstDs);

                RptDataSrcEntity entity2 = new RptDataSrcEntity();
                entity2.DataSetName = "Main2";
                entity2.IsSqlPrint = false;
                entity2.SqlContent = "";
                entity2.DtPrint = p_dt2;
                lstDs.Add(entity2);

                rptBase.ReportRegisterData(lstDs);

                if (reportTypeID == (int)ReportPrintType.设计)
                {
                    rptBase.DesignReport();

                    //把报表文件保存到数据库
                    ReportFileRule reportFileRule = new ReportFileRule();
                    ReportFile reportFile = new ReportFile();
                    reportFile.ID = reportManage.FileID;
                    reportFile.SelectByID();
                    reportFile.Context = FastReport.ConvertToBinary(reportManage.FileName);
                    reportFile.UploadTime = DateTime.Now;

                    if (reportFile.ID == 0)
                    {
                        reportFileRule.RAdd(reportFile);
                        if (reportManage.ID != 0)
                        {
                            string s = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(reportFile.ID) + " WHERE ID=" + SysString.ToDBString(reportFile.ID);
                            SysUtils.ExecuteNonQuery(s);
                        }
                    }
                    else
                    {
                        reportFileRule.RUpdate(reportFile);
                    }
                }
                else if (reportTypeID == (int)ReportPrintType.预览)
                {
                    rptBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.转Excel)
                {
                    //rptBase.ExportToXLS(TemplateFileRoute + reportManage.Url + reportManage.ReportName + "xls");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + "xls");
                }
                else if (reportTypeID == (int)ReportPrintType.转PDF)
                {
                    //rptBase.ExportToPDF(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                }
                else if (reportTypeID == (int)ReportPrintType.打印)
                {
                    rptBase.PrintReport();
                }

                rptBase.CloseReport();
            }
            catch (Exception E)
            {
                rptBase.CloseReport();
                throw E;
            }
        }

        /// <summary>
        /// FastReport（添加多个数据源 染色卡）
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <param name="reportTypeID">报表类型</param>
        /// <param name="dt">数据源表</param>
        public static void ReportRunTable3(int reportID, int reportTypeID, DataTable p_dt1, DataTable p_dt2, DataTable p_dt3, DataTable p_dt4, DataTable p_dt5)
        {
            FastReportXBase rptBase = new FastReportXBase();

            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                DownFile(reportManage.FileName, reportManage.FileID);


                rptBase.ReportTemplate = TemplateFileRoute + reportManage.Url + reportManage.FileName;

                if (!SysFile.CheckFileExit(rptBase.ReportTemplate))
                {
                    throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + rptBase.ReportTemplate);
                }

                rptBase.OpenReport();

                List<RptDataSrcEntity> lstDs = new List<RptDataSrcEntity>();//存放Sql语句的
                RptDataSrcEntity entity = new RptDataSrcEntity();
                entity.DataSetName = "Main";
                entity.IsSqlPrint = false;
                entity.SqlContent = "";
                entity.DtPrint = p_dt1;
                lstDs.Add(entity);
                rptBase.ReportRegisterData(lstDs);

                RptDataSrcEntity entity2 = new RptDataSrcEntity();
                entity2.DataSetName = "Dts1";
                entity2.IsSqlPrint = false;
                entity2.SqlContent = "";
                entity2.DtPrint = p_dt2;
                lstDs.Add(entity2);
                rptBase.ReportRegisterData(lstDs);

                RptDataSrcEntity entity3 = new RptDataSrcEntity();
                entity3.DataSetName = "Dts2";
                entity3.IsSqlPrint = false;
                entity3.SqlContent = "";
                entity3.DtPrint = p_dt3;
                lstDs.Add(entity3);
                rptBase.ReportRegisterData(lstDs);

                RptDataSrcEntity entity4 = new RptDataSrcEntity();
                entity4.DataSetName = "Dts3";
                entity4.IsSqlPrint = false;
                entity4.SqlContent = "";
                entity4.DtPrint = p_dt4;
                lstDs.Add(entity4);
                rptBase.ReportRegisterData(lstDs);

                RptDataSrcEntity entity5 = new RptDataSrcEntity();
                entity5.DataSetName = "Dts4";
                entity5.IsSqlPrint = false;
                entity5.SqlContent = "";
                entity5.DtPrint = p_dt5;
                lstDs.Add(entity5);
                rptBase.ReportRegisterData(lstDs);

                if (reportTypeID == (int)ReportPrintType.设计)
                {
                    rptBase.DesignReport();

                    //把报表文件保存到数据库
                    ReportFileRule reportFileRule = new ReportFileRule();
                    ReportFile reportFile = new ReportFile();
                    reportFile.ID = reportManage.FileID;
                    reportFile.SelectByID();
                    reportFile.Context = FastReport.ConvertToBinary(reportManage.FileName);
                    reportFile.UploadTime = DateTime.Now;

                    if (reportFile.ID == 0)
                    {
                        reportFileRule.RAdd(reportFile);
                        if (reportManage.ID != 0)
                        {
                            string s = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(reportFile.ID) + " WHERE ID=" + SysString.ToDBString(reportFile.ID);
                            SysUtils.ExecuteNonQuery(s);
                        }
                    }
                    else
                    {
                        reportFileRule.RUpdate(reportFile);
                    }
                }
                else if (reportTypeID == (int)ReportPrintType.预览)
                {
                    rptBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.转Excel)
                {
                    //rptBase.ExportToXLS(TemplateFileRoute + reportManage.Url + reportManage.ReportName + "xls");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + "xls");
                }
                else if (reportTypeID == (int)ReportPrintType.转PDF)
                {
                    //rptBase.ExportToPDF(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                    //Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".pdf");
                }
                else if (reportTypeID == (int)ReportPrintType.打印)
                {
                    rptBase.PrintReport();
                }

                rptBase.CloseReport();
            }
            catch (Exception E)
            {
                rptBase.CloseReport();
                throw E;
            }
        }


        /// <summary>
        /// FastReport
        /// </summary>
        /// <param name="reportID">报表编号</param>
        /// <param name="reportTypeID">报表类型</param>
        /// <param name="queryName">查询数据名</param>
        /// <param name="queryValue">查询数据值</param>
        public static void ReportRun(int reportID, int reportTypeID, DataTable[] p_Source)
        {


            FastReportXBase rptBase = new FastReportXBase();


            try
            {
                ReportManage reportManage = new ReportManage();
                reportManage.ID = reportID;
                reportManage.SelectByID();

                DownFile(reportManage.FileName, reportManage.FileID);


                rptBase.ReportTemplate = TemplateFileRoute + reportManage.Url + reportManage.FileName;

                if (!SysFile.CheckFileExit(rptBase.ReportTemplate))
                {
                    throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + rptBase.ReportTemplate);
                }

                rptBase.OpenReport();

                List<RptDataSrcEntity> lstDs = new List<RptDataSrcEntity>();//存放Sql语句的

                ReportManageDtsRule dtsRule = new ReportManageDtsRule();
                DataTable dtSource = dtsRule.RShow(reportManage.ID);

                foreach (DataTable dt in p_Source)
                {
                    RptDataSrcEntity entity = new RptDataSrcEntity();
                    entity.DataSetName = dt.TableName;
                    entity.IsSqlPrint = false;
                    entity.SqlContent = "";
                    entity.DtPrint = dt;
                    lstDs.Add(entity);
                }

                rptBase.ReportRegisterData(lstDs);

                if (reportTypeID == (int)ReportPrintType.设计)
                {
                    rptBase.DesignReport();

                    //把报表文件保存到数据库
                    ReportFileRule reportFileRule = new ReportFileRule();
                    ReportFile reportFile = new ReportFile();
                    reportFile.ID = reportManage.FileID;
                    reportFile.SelectByID();
                    reportFile.Context = FastReport.ConvertToBinary(reportManage.FileName);
                    reportFile.UploadTime = DateTime.Now;

                    if (reportFile.ID == 0)
                    {
                        reportFileRule.RAdd(reportFile);
                        if (reportManage.ID != 0)
                        {
                            string s = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(reportFile.ID) + " WHERE ID=" + SysString.ToDBString(reportFile.ID);
                            SysUtils.ExecuteNonQuery(s);
                        }
                    }
                    else
                    {
                        reportFileRule.RUpdate(reportFile);
                    }
                }
                else if (reportTypeID == (int)ReportPrintType.预览)
                {
                    rptBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.转Excel)
                {
                    Process.Start(TemplateFileRoute + reportManage.Url + reportManage.ReportName + ".xls");
                }
                else if (reportTypeID == (int)ReportPrintType.转PDF)
                {
                    rptBase.ShowReport();
                }
                else if (reportTypeID == (int)ReportPrintType.打印)
                {
                    rptBase.PrintReport();
                }

                rptBase.CloseReport();
            }
            catch (Exception E)
            {
                rptBase.CloseReport();
                throw E;
            }
        }
    }
}
