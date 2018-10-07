using System;
using System.Data;
using System.Text;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using HttSoft.MLTERP.Sys;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;



namespace MLTERP
{

    /// <summary>
    /// 模板转Excel
    /// </summary>
    public class TemplateExcel
    {

        private static string TemplateFileRoute = Application.StartupPath + @"\Template\";//模板文件路径
        private static string TempFileRoute = Application.StartupPath + @"\Temp\";//导出临时文件路径

        private static string OPArgFileName = "OPArg.xls";//员工权限模板文件名称
        private static string OPArgFilePre = "员工权限";//员工权限表临时文件前缀

        private static string SOMFileName = "SOM.xls";//客户订单模板文件名称
        private static string SOMFilePre = "客户订单";//客户订单表临时文件前缀


        private static string ItemFileName = "Item.xls";//客户订单模板文件名称
        private static string ItemFilePre = "纱线管理";//客户订单表临时文件前缀


        private static string FHFormFileName = "FHForm.xls";//发货单模板文件名称
        private static string FHFormFilePre = "发货单";//发货单表临时文件前缀

        private static string DZFileName = "CaiWuDZ.xls";//发货单模板文件名称
        private static string DZFilePre = "财务对账";//发货单表临时文件前缀

        private static string InOutFileName = "FinceWHInOutRpt.xls";//发货单模板文件名称
        private static string InOutFilePre = "出入库财务报表";//发货单表临时文件前缀


       
    






        #region 纱线管理
        /// <summary>
        /// 导出员工权限
        /// </summary>
        /// <param name="p_SampleID">OPID</param>
        /// <param name="p_ExportFile">导出文件名称</param>
        public static void ItemFileToExcel(DataTable dt, string p_Date, out string p_ExportFile)
        {
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + ItemFileName;//模板文件
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(ItemFilePre);//临时文件
            if (oReport.ReportExport == "")
            {
                throw new Exception("导出临时文件生成失败，请重新导出");
            }

            oReport.BeginExport();
            int ProRow = 2;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                oReport.SetCellValue(ProRow, "A", dt.Rows[j]["ItemCode"].ToString());
                oReport.SetCellValue(ProRow, "B", dt.Rows[j]["ItemName"].ToString());
                oReport.SetCellValue(ProRow, "C", dt.Rows[j]["ItemStd"].ToString());
                oReport.SetCellValue(ProRow, "D", dt.Rows[j]["ItemModel"].ToString());
                ProRow++;

            }
            oReport.EndExport();
            p_ExportFile = oReport.ReportExport;//返回导出文件名称





            
        }
        #endregion
              

        #region 导出文件名称

        /// <summary>
        /// 获得导出文件名称
        /// </summary>
        /// <param name="p_FilePre">文件前缀</param>
        /// <returns>文件名称(含路径)</returns>
        private static string GetTempFileName(string p_FilePre)
        {
            string outstr = string.Empty;
            const int sindex = 10, eindex = 30, mindex = 21;//sindex=10,eindex=15,mindex=12;
            SysFile.CreateDDirectory(TempFileRoute);//没有找到则创建临时文件夹路径
            string FileName = string.Empty, DleteFileName = string.Empty;
            int i = 0;
            for (i = sindex; i < eindex; i++)
            {
                FileName = TempFileRoute + p_FilePre + i.ToString() + ".xls";
                if (!SysFile.CheckFileExit(FileName))//找到则跳出
                {
                    break;
                }
            }
            if (i == mindex)//如果到了中间线，删除中间线后面的文件
            {
                for (int j = mindex + 1; j < eindex; j++)
                {
                    DleteFileName = TempFileRoute + p_FilePre + j.ToString() + ".xls";
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            if (i == eindex)//如果到了末尾，删除中间线前面的文件
            {
                for (int j = sindex; j <= mindex; j++)
                {
                    DleteFileName = TempFileRoute + p_FilePre + j.ToString() + ".xls";
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            outstr = FileName;
            return outstr;

        }

        #endregion

        #region 员工权限
        /// <summary>
        /// 导出员工权限
        /// </summary>
        /// <param name="p_SampleID">OPID</param>
        /// <param name="p_ExportFile">导出文件名称</param>
        public static void OPArgToExcel(string p_OPID, ArrayList p_Al, out string p_ExportFile)
        {
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + OPArgFileName;//模板文件
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(OPArgFilePre);//临时文件
            if (oReport.ReportExport == "")
            {
                throw new Exception("导出临时文件生成失败，请重新导出");
            }

            oReport.BeginExport();
            /*赋数据Bein*/

            oReport.SetCellValue(1, "A", Common.GetNameByOPID(p_OPID));//员工名字
            for (int i = 0; i < p_Al.Count; i++)
            {
                string[] tempa = (string[])(p_Al[i]);
                oReport.SetCellValue(i + 2, "A", tempa[0]);//菜单名字
                oReport.SetCellValue(i + 2, "B", tempa[1]);//权限名字
            }
            oReport.SetCellValue(p_Al.Count + 2, "A", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));//导出日期
            /*赋数据End*/
            oReport.EndExport();
            p_ExportFile = oReport.ReportExport;//返回导出文件名称
        }
        #endregion



        #region 导出发货单
        /// <summary>
        /// 导出员工权限
        /// </summary>
        /// <param name="p_ID">ID</param>
        /// <param name="p_ExportFile">导出文件名称</param>
        public static void FHFormToExcel(int p_ID, out string p_ExportFile)
        {
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + FHFormFileName;//模板文件
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(FHFormFilePre);//临时文件
            if (oReport.ReportExport == "")
            {
                throw new Exception("导出临时文件生成失败，请重新导出");
            }

            oReport.BeginExport();

            string sql = "SELECT * FROM UV1_Sale_FHForm WHERE ID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                oReport.SetCellValue(5, "B", SysConvert.ToString(dt.Rows[0]["VendorAttn"]));//收货单位
                oReport.SetCellValue(3, "H", SysConvert.ToString(dt.Rows[0]["FormNo"]));//单号
                oReport.SetCellValue(4, "H", "No：" + SysConvert.ToString(dt.Rows[0]["SendCode"]));//单号
                oReport.SetCellValue(5, "H", "日期：" + SysConvert.ToDateTime(dt.Rows[0]["MakeDate"]).ToString("yyyy-MM-dd"));//制单日期
                oReport.SetCellValue(12, "B", SysConvert.ToString(dt.Rows[0]["Address"]) + "" + SysConvert.ToString(dt.Rows[0]["Tel"]));//备注
                oReport.SetCellValue(13, "B", SysConvert.ToString(dt.Rows[0]["MakeOPName"]));//制单人
                oReport.SetCellValue(13, "D", SysConvert.ToString(dt.Rows[0]["OPName"]));//业务员
                oReport.SetCellValue(13, "G", SysConvert.ToString(dt.Rows[0]["SHR"]));//送货人
                oReport.SetCellValue(14, "A", "地址：上海汶水路480号  上海纺织鑫豪园区4栋1楼   电话：（021）51095188  传真：（021）51098093*889   联系人：" + SysConvert.ToString(dt.Rows[0]["OPName"]));//联系人
            }

            sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE MainID=" + SysString.ToDBString(p_ID);
            DataTable dto = SysUtils.Fill(sql);
            if (dto.Rows.Count > 0)
            {

                for (int i = 4; i < dto.Rows.Count; i++)
                {
                    oReport.RangeSet("A9", "H9");
                    oReport.RangeInsertRow();
                }

                int staro = 7;
                oReport.SetCellValue(4, "B", SysConvert.ToString(dto.Rows[0]["CustomerCode"]));//合同号
                int pieceQty = 0;
                decimal qty = 0;
                decimal amount = 0;
                for (int i = 0; i < dto.Rows.Count; i++)
                {
                    string packdts = SysConvert.ToString(dto.Rows[i]["PackDts"]);
                    string[] arrpackdts = packdts.Split(',');
                    string newpackdts = "";
                    for (int j = 0; j < arrpackdts.Length; j++)
                    {
                        if (newpackdts != "")
                        {
                            newpackdts += " ";
                        }
                        newpackdts += arrpackdts[j].ToString();
                    }


                    oReport.SetCellValue(staro + i, "A", SysConvert.ToString(dto.Rows[i]["ItemCode"]) + Environment.NewLine + SysConvert.ToString(dto.Rows[i]["VItemCode"]));
                    oReport.SetCellValue(staro + i, "B", SysConvert.ToString(dto.Rows[i]["GoodsCode"]));
                    if (SysConvert.ToString(dto.Rows[i]["ColorNum"]) == SysConvert.ToString(dto.Rows[i]["ColorName"]))
                    {
                        oReport.SetCellValue(staro + i, "C", SysConvert.ToString(dto.Rows[i]["ColorNum"]) + Environment.NewLine + SysConvert.ToString(dto.Rows[i]["VColorNum"]) + SysConvert.ToString(dto.Rows[i]["VColorName"]));
                    }
                    else
                    {
                        oReport.SetCellValue(staro + i, "C", SysConvert.ToString(dto.Rows[i]["ColorNum"]) + SysConvert.ToString(dto.Rows[i]["ColorName"]) + Environment.NewLine + SysConvert.ToString(dto.Rows[i]["VColorNum"]) + SysConvert.ToString(dto.Rows[i]["VColorName"]));
                    }
                    oReport.SetCellValue(staro + i, "D", SysConvert.ToString(dto.Rows[i]["PieceQty"]));
                    oReport.SetCellValue(staro + i, "E", SysConvert.ToString(dto.Rows[i]["Qty"]));
                    oReport.SetCellValue(staro + i, "F", SysConvert.ToString(dto.Rows[i]["SingPrice"]));
                    oReport.SetCellValue(staro + i, "G", SysConvert.ToString(dto.Rows[i]["Amount"]));
                    oReport.SetCellValue(staro + i, "H", newpackdts);
                    pieceQty += SysConvert.ToInt32(dto.Rows[i]["PieceQty"]);
                    qty += SysConvert.ToDecimal(dto.Rows[i]["Qty"]);
                    amount += SysConvert.ToDecimal(dto.Rows[i]["Amount"]);



                }
                oReport.SetCellValue(11, "D", pieceQty.ToString());//收货单位
                oReport.SetCellValue(11, "E", qty.ToString());//收货单位
                oReport.SetCellValue(11, "G", amount.ToString());//收货单位

            }
            //oReport.SetCellValue(3, "A", "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            //oReport.RangeSet("A3", "Z3");
            //oReport.RangeAutoFit();
            oReport.EndExport();
            p_ExportFile = oReport.ReportExport;//返回导出文件名称






        }
        #endregion

        #region 导出发货单2
        /// <summary>
        /// 导出员工权限
        /// </summary>
        /// <param name="p_ID">ID</param>
        /// <param name="p_ExportFile">导出文件名称</param>
        public static void FHFormToExcel2(int p_ID, DataTable p_dt, int p_Num, out string p_ExportFile)
        {
            if (p_Num > p_dt.Rows.Count)
            {

                p_ExportFile = "行一设置有误";
            }
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + FHFormFileName;//模板文件
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(FHFormFilePre);//临时文件
            if (oReport.ReportExport == "")
            {
                throw new Exception("导出临时文件生成失败，请重新导出");
            }

            oReport.BeginExport();
           
            string sql = "SELECT * FROM UV1_Sale_FHForm WHERE ID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
             string pageStr = "";
             if (p_Num == p_dt.Rows.Count)
             {
                 pageStr = "1/1";
             }
             else
             {
                 pageStr = "1/2";
             }
            if (dt.Rows.Count > 0)
            {
                oReport.SetCellValue(4, "F","page:"+ pageStr);//收货单位
                oReport.SetCellValue(5, "B", SysConvert.ToString(dt.Rows[0]["VendorAttn"]));//收货单位
                oReport.SetCellValue(3, "H", SysConvert.ToString(dt.Rows[0]["FormNo"]));//单号
                oReport.SetCellValue(4, "H", "No：" + SysConvert.ToString(dt.Rows[0]["SendCode"]));//单号
                oReport.SetCellValue(5, "H", "日期：" + SysConvert.ToDateTime(dt.Rows[0]["MakeDate"]).ToString("yyyy-MM-dd"));//制单日期
                oReport.SetCellValue(12, "B", SysConvert.ToString(dt.Rows[0]["Address"]) + "" + SysConvert.ToString(dt.Rows[0]["Tel"]));//备注
                oReport.SetCellValue(13, "B", SysConvert.ToString(dt.Rows[0]["MakeOPName"]));//制单人
                oReport.SetCellValue(13, "D", SysConvert.ToString(dt.Rows[0]["OPName"]));//业务员
                oReport.SetCellValue(13, "G", SysConvert.ToString(dt.Rows[0]["SHR"]));//送货人
                oReport.SetCellValue(14, "A", "地址：上海汶水路480号  上海纺织鑫豪园区4栋1楼   电话：（021）51095188  传真：（021）51098093*889   联系人：" + SysConvert.ToString(dt.Rows[0]["OPName"]));//联系人
            }

            sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE MainID=" + SysString.ToDBString(p_ID);
            DataTable dto = SysUtils.Fill(sql);
            int pieceQty = 0;
            decimal qty = 0;
            decimal amount = 0;
            string CustomerCode="";
            for (int i = 0; i < dto.Rows.Count; i++)
            {
                if (i < p_Num)
                {

                    pieceQty += SysConvert.ToInt32(dto.Rows[i]["PieceQty"]);
                    qty += SysConvert.ToDecimal(dto.Rows[i]["Qty"]);
                    amount += SysConvert.ToDecimal(dto.Rows[i]["Amount"]);
                    oReport.SetCellValue(11, "D", pieceQty.ToString());//送货人
                    oReport.SetCellValue(11, "E", qty.ToString());//送货人
                    oReport.SetCellValue(11, "G", amount.ToString());//送货人
                   
                   

                }



            }

            bool autofileFlag = false;//是否自动调整高度标志
            if (dto.Rows.Count > 0)
            {

                for (int i = 0; i < p_Num-4; i++)
                {
                    oReport.RangeSet("A9", "H9");
                    oReport.RangeInsertRow();
                }

                int staro = 7;
                sql = "SELECT CustomerCode FROM UV1_Sale_FHFormDts WHERE MainID="+SysString.ToDBString(p_ID);
                sql += " AND  CustomerCode<>''";
                sql += " GROUP BY CustomerCode";
                string cusc = "";
                DataTable dtcus = SysUtils.Fill(sql);
                for (int i = 0; i < dtcus.Rows.Count; i++)
                {
                    if (cusc != "")
                    {
                        cusc += ",";
                    }
                    cusc += SysConvert.ToString(dtcus.Rows[i][0]);
                }
                oReport.SetCellValue(4, "B", cusc);//合同号
               
                for (int i = 0; i < dto.Rows.Count; i++)
                {
                    if (i < p_Num)
                    {
                        string packdts = SysConvert.ToString(dto.Rows[i]["PackDts"]);
                        string[] arrpackdts = packdts.Split(',');
                        string newpackdts = "";
                        for (int j = 0; j < arrpackdts.Length; j++)
                        {
                            if (newpackdts != "")
                            {
                                newpackdts += " ";
                            }
                            newpackdts += arrpackdts[j].ToString();
                        }


                        oReport.SetCellValue(staro + i, "A", SysConvert.ToString(dto.Rows[i]["ItemCode"]) + Environment.NewLine + SysConvert.ToString(dto.Rows[i]["VItemCode"]));
                        oReport.SetCellValue(staro + i, "B", SysConvert.ToString(dto.Rows[i]["GoodsCode"]));
                        if (SysConvert.ToString(dto.Rows[i]["ColorNum"]) == SysConvert.ToString(dto.Rows[i]["ColorName"]))
                        {
                            oReport.SetCellValue(staro + i, "C", SysConvert.ToString(dto.Rows[i]["ColorNum"]) + Environment.NewLine + SysConvert.ToString(dto.Rows[i]["VColorNum"]) + SysConvert.ToString(dto.Rows[i]["VColorName"]));
                        }
                        else
                        {
                            oReport.SetCellValue(staro + i, "C", SysConvert.ToString(dto.Rows[i]["ColorNum"]) + SysConvert.ToString(dto.Rows[i]["ColorName"]) + Environment.NewLine + SysConvert.ToString(dto.Rows[i]["VColorNum"]) + SysConvert.ToString(dto.Rows[i]["VColorName"]));
                        }
                        oReport.SetCellValue(staro + i, "D", SysConvert.ToString(dto.Rows[i]["PieceQty"]));
                        oReport.SetCellValue(staro + i, "E", SysConvert.ToString(dto.Rows[i]["Qty"]));
                        oReport.SetCellValue(staro + i, "F", SysConvert.ToString(dto.Rows[i]["SingPrice"]));
                        oReport.SetCellValue(staro + i, "G", SysConvert.ToString(dto.Rows[i]["Amount"]));
                        oReport.SetCellValue(staro + i, "H", newpackdts);
                        pieceQty += SysConvert.ToInt32(dto.Rows[i]["PieceQty"]);
                        qty += SysConvert.ToDecimal(dto.Rows[i]["Qty"]);
                        amount += SysConvert.ToDecimal(dto.Rows[i]["Amount"]);


                    }
                }

                


            }
            //Excel.Application _excelApplicatin = null;
            //_excelApplicatin = new Excel.Application();
            //_excelApplicatin.Visible = true;
            //_excelApplicatin.DisplayAlerts = true;



            ////string strExcelPathName = TemplateFileRoute + FHFormFileName;
            ////Excel.Workbook workBook = _excelApplicatin.Workbooks.Open(strExcelPathName, Type.Missing, Type.Missing,
            ////  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            ////  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //////读取已打开的Excel
            ////Excel.Worksheet workSheet1 = (Excel.Worksheet)workBook.Sheets["Sheet1"];

            ////oReport.SetCellValue(staro + i, "G", SysConvert.ToString(dto.Rows[i]["Amount"]));
            //if (p_Num < 5)
            //{
            //    decimal H1=SysConvert.ToDecimal(((Excel.Range)oReport.objRange.Rows[5]).RowHeight);
            //    oReport.RangeSet("A11", "H11");
            //    oReport.RangeSetRowHeight(30);
            //    oReport.SetCellValue(19, "A", H1.ToString());//送货人
            //}
            //else
            //{
            //    oReport.RangeSet("A" + SysConvert.ToInt32(11 + p_Num - 4).ToString(), "H" + SysConvert.ToInt32(11 + p_Num - 4).ToString());
            //    oReport.RangeSetRowHeight(30);
            //}
            //oReport.SetCellValue(3, "A", "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            //oReport.RangeSet("A3", "Z3");
            //oReport.RangeAutoFit();
            oReport.EndExport();
            p_ExportFile = oReport.ReportExport;//返回导出文件名称






        }
        #endregion

        #region 导出发货单3
        /// <summary>
        /// 导出员工权限
        /// </summary>
        /// <param name="p_ID">ID</param>
        /// <param name="p_ExportFile">导出文件名称</param>
        public static void FHFormToExcel3(int p_ID, DataTable p_dt, int p_Num, out string p_ExportFile)
        {
            //if (p_Num > p_dt.Rows.Count)
            //{

            //    return;
            //}
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + FHFormFileName;//模板文件
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(FHFormFilePre);//临时文件
            if (oReport.ReportExport == "")
            {
                throw new Exception("导出临时文件生成失败，请重新导出");
            }

            oReport.BeginExport();

            string sql = "SELECT * FROM UV1_Sale_FHForm WHERE ID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                oReport.SetCellValue(4, "F", "page:2/2");//收货单位
                oReport.SetCellValue(5, "B", SysConvert.ToString(dt.Rows[0]["VendorAttn"]));//收货单位
                oReport.SetCellValue(3, "H", SysConvert.ToString(dt.Rows[0]["FormNo"]));//单号
                oReport.SetCellValue(4, "H", "No：" + SysConvert.ToString(dt.Rows[0]["SendCode"]));//单号
                oReport.SetCellValue(5, "H", "日期：" + SysConvert.ToDateTime(dt.Rows[0]["MakeDate"]).ToString("yyyy-MM-dd"));//制单日期
                oReport.SetCellValue(12, "B", SysConvert.ToString(dt.Rows[0]["Address"]) + "" + SysConvert.ToString(dt.Rows[0]["Tel"]));//备注
                oReport.SetCellValue(13, "B", SysConvert.ToString(dt.Rows[0]["MakeOPName"]));//制单人
                oReport.SetCellValue(13, "D", SysConvert.ToString(dt.Rows[0]["OPName"]));//业务员
                oReport.SetCellValue(13, "G", SysConvert.ToString(dt.Rows[0]["SHR"]));//送货人
                oReport.SetCellValue(14, "A", "地址：上海汶水路480号  上海纺织鑫豪园区4栋1楼   电话：（021）51095188  传真：（021）51098093*889   联系人：" + SysConvert.ToString(dt.Rows[0]["OPName"]));//联系人
               
            }

            sql = "SELECT * FROM UV1_Sale_FHFormDts WHERE MainID=" + SysString.ToDBString(p_ID);
            DataTable dto = SysUtils.Fill(sql);
            int pieceQty = 0;
            decimal qty = 0;
            decimal amount = 0;
            for (int i = 0; i < dto.Rows.Count; i++)
            {
                if (i > p_Num - 1)
                {

                    pieceQty += SysConvert.ToInt32(dto.Rows[i]["PieceQty"]);
                    qty += SysConvert.ToDecimal(dto.Rows[i]["Qty"]);
                    amount += SysConvert.ToDecimal(dto.Rows[i]["Amount"]);
                    oReport.SetCellValue(11, "D", pieceQty.ToString());//送货人
                    oReport.SetCellValue(11, "E", qty.ToString());//送货人
                    oReport.SetCellValue(11, "G", amount.ToString());//送货人
                }



            }
            if (dto.Rows.Count > 0)
            {

                for (int i = 4; i < dto.Rows.Count-p_Num; i++)
                {
                    oReport.RangeSet("A9", "H9");
                    oReport.RangeInsertRow();
                }

                int staro = 7;
                sql = "SELECT CustomerCode FROM UV1_Sale_FHFormDts WHERE MainID=" + SysString.ToDBString(p_ID);
                sql += " AND  CustomerCode<>''";
                sql += " GROUP BY CustomerCode";
                string cusc = "";
                DataTable dtcus = SysUtils.Fill(sql);
                for (int i = 0; i < dtcus.Rows.Count; i++)
                {
                    if (cusc != "")
                    {
                        cusc += ",";
                    }
                    cusc += SysConvert.ToString(dtcus.Rows[i][0]);
                }
                oReport.SetCellValue(4, "B", cusc);//合同号
              
                for (int i = 0; i < dto.Rows.Count; i++)
                {
                    if (i > p_Num-1)
                    {
                        string packdts = SysConvert.ToString(dto.Rows[i]["PackDts"]);
                        string[] arrpackdts = packdts.Split(',');
                        string newpackdts = "";
                        for (int j = 0; j < arrpackdts.Length; j++)
                        {
                            if (newpackdts != "")
                            {
                                newpackdts += " ";
                            }
                            newpackdts += arrpackdts[j].ToString();
                        }


                        oReport.SetCellValue(staro + i-p_Num, "A", SysConvert.ToString(dto.Rows[i]["ItemCode"]) + Environment.NewLine + SysConvert.ToString(dto.Rows[i]["VItemCode"]));
                        oReport.SetCellValue(staro + i-p_Num, "B", SysConvert.ToString(dto.Rows[i]["GoodsCode"]));
                        if (SysConvert.ToString(dto.Rows[i]["ColorNum"]) == SysConvert.ToString(dto.Rows[i]["ColorName"]))
                        {
                            oReport.SetCellValue(staro + i-p_Num, "C", SysConvert.ToString(dto.Rows[i]["ColorNum"]) + Environment.NewLine + SysConvert.ToString(dto.Rows[i]["VColorNum"]) + SysConvert.ToString(dto.Rows[i]["VColorName"]));
                        }
                        else
                        {
                            oReport.SetCellValue(staro + i-p_Num, "C", SysConvert.ToString(dto.Rows[i]["ColorNum"]) + SysConvert.ToString(dto.Rows[i]["ColorName"]) + Environment.NewLine + SysConvert.ToString(dto.Rows[i]["VColorNum"]) + SysConvert.ToString(dto.Rows[i]["VColorName"]));
                        }
                        oReport.SetCellValue(staro + i-p_Num, "D", SysConvert.ToString(dto.Rows[i]["PieceQty"]));
                        oReport.SetCellValue(staro + i-p_Num, "E", SysConvert.ToString(dto.Rows[i]["Qty"]));
                        oReport.SetCellValue(staro + i-p_Num, "F", SysConvert.ToString(dto.Rows[i]["SingPrice"]));
                        oReport.SetCellValue(staro + i-p_Num, "G", SysConvert.ToString(dto.Rows[i]["Amount"]));
                        oReport.SetCellValue(staro + i-p_Num, "H", newpackdts);
                        pieceQty += SysConvert.ToInt32(dto.Rows[i]["PieceQty"]);
                        qty += SysConvert.ToDecimal(dto.Rows[i]["Qty"]);
                        amount += SysConvert.ToDecimal(dto.Rows[i]["Amount"]);
                    }



                }
               

            }
            //oReport.SetCellValue(3, "A", "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            //oReport.RangeSet("A3", "Z3");
            //oReport.RangeAutoFit();
            oReport.EndExport();
            p_ExportFile = oReport.ReportExport;//返回导出文件名称






        }
        #endregion

        #region 导出财务对账报表
        /// <summary>
        /// 导出财务对账报表
        /// </summary>
        /// <param name="p_ID">ID</param>
        /// <param name="p_ExportFile">导出文件名称</param>
        public static void CaiWuDZToExcel(DataTable dto,string p_DateStr, out string p_ExportFile)
        {
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute +DZFileName;//模板文件
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(DZFilePre);//临时文件
            if (oReport.ReportExport == "")
            {
                throw new Exception("导出临时文件生成失败，请重新导出");
            }

            oReport.BeginExport();

            oReport.SetCellValue(4, "B", dto.Rows[0]["VendorAttn"].ToString());
            oReport.SetCellValue(10, "K", p_DateStr);
           
            if (dto.Rows.Count > 0)
            {

                decimal Qty = 0;
                decimal Amount = 0;
                decimal KPQty = 0;
                decimal KPAmount = 0;
                decimal LKAmount = 0;
                for (int j = 0; j < dto.Rows.Count; j++)
                {
                    Qty += SysConvert.ToDecimal(dto.Rows[j]["Qty"]);
                    Amount += SysConvert.ToDecimal(dto.Rows[j]["Amount"]);
                    KPQty += SysConvert.ToDecimal(dto.Rows[j]["KPQty"]);
                    KPAmount += SysConvert.ToDecimal(dto.Rows[j]["KPAmount"]);
                    LKAmount += SysConvert.ToDecimal(dto.Rows[j]["LKAmount"]);
                }
                string FinSUM = "应开票数量："+SysConvert.ToDecimal(Qty-KPQty).ToString()+";应开票金额："+SysConvert.ToDecimal(Amount-KPAmount).ToString()+";收付款金额："+SysConvert.ToDecimal(Amount-LKAmount).ToString();
                oReport.SetCellValue(10, "A", FinSUM.ToString());
                oReport.SetCellValue(8, "H", Qty.ToString());
                oReport.SetCellValue(8, "J", Amount.ToString());
                oReport.SetCellValue(8, "K", KPQty.ToString());
                oReport.SetCellValue(8, "L", KPAmount.ToString());
                oReport.SetCellValue(8, "M", LKAmount.ToString());
                for (int i = 1; i < dto.Rows.Count; i++)
                {
                    oReport.RangeSet("A7", "L7");
                    oReport.RangeInsertRow();
                }
                

                for (int i = 0; i < dto.Rows.Count; i++)
                {
                    oReport.SetCellValue(7+i, "A", dto.Rows[i]["FormDate"].ToString());
                    oReport.SetCellValue(7 + i, "B", "'" + dto.Rows[i]["DtsOrderFormNo"].ToString());
                    oReport.SetCellValue(7 + i, "C", "'" + dto.Rows[i]["ItemCode"].ToString());
                    oReport.SetCellValue(7 + i, "D","'"+dto.Rows[i]["GoodsCode"].ToString());
                    if (dto.Rows[i]["ColorNum"].ToString() == dto.Rows[i]["ColorName"].ToString())
                    {
                        oReport.SetCellValue(7 + i, "G", "'" + dto.Rows[i]["ColorNum"].ToString());
                    }
                    else
                    {
                        oReport.SetCellValue(7 + i, "G", "'" + dto.Rows[i]["ColorNum"].ToString() + dto.Rows[i]["ColorName"].ToString());
                    }
                    oReport.SetCellValue(7 + i, "E", "'" + dto.Rows[i]["VOrderFormNo"].ToString());
                    oReport.SetCellValue(7 + i, "F", "'" + dto.Rows[i]["VItemCode"].ToString());
                    oReport.SetCellValue(7 + i, "H", dto.Rows[i]["Qty"].ToString());
                    oReport.SetCellValue(7 + i, "I", dto.Rows[i]["SinglePrice"].ToString());
                    oReport.SetCellValue(7 + i, "J", dto.Rows[i]["Amount"].ToString());
                    oReport.SetCellValue(7 + i, "K", dto.Rows[i]["KPQty"].ToString());
                    oReport.SetCellValue(7 + i, "L", dto.Rows[i]["KPAmount"].ToString());
                    oReport.SetCellValue(7 + i, "M", dto.Rows[i]["LKAmount"].ToString());
                }


            }


 
            oReport.EndExport();
            p_ExportFile = oReport.ReportExport;//返回导出文件名称






        }
        #endregion

        #region 导出仓库出入库财务报表
        /// <summary>
        /// 导出仓库出入库财务报表
        /// </summary>
        /// <param name="p_ID">ID</param>
        /// <param name="p_ExportFile">导出文件名称</param>
        public static void CaiWuWHInOutToExcel(DataTable dto, string p_DateStr, out string p_ExportFile)
        {
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + InOutFileName;//模板文件
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(InOutFilePre);//临时文件
            if (oReport.ReportExport == "")
            {
                throw new Exception("导出临时文件生成失败，请重新导出");
            }

            oReport.BeginExport();

          

            if (dto.Rows.Count > 0)
            {
                int PieceQty = 0;
                decimal Qty = 0;
                decimal Amount = 0;
                decimal InvoiceQty = 0;
                decimal InvoiceAmount = 0;
                decimal PayAmount = 0;
                for (int j = 0; j < dto.Rows.Count; j++)
                {
                    PieceQty += SysConvert.ToInt32(dto.Rows[j]["PieceQty"]);
                    Qty += SysConvert.ToDecimal(dto.Rows[j]["Qty"]);
                    Amount += SysConvert.ToDecimal(dto.Rows[j]["Amount"]);
                    InvoiceQty += SysConvert.ToDecimal(dto.Rows[j]["InvoiceQty"]);
                    InvoiceAmount += SysConvert.ToDecimal(dto.Rows[j]["InvoiceAmount"]);
                    PayAmount += SysConvert.ToDecimal(dto.Rows[j]["PayAmount"]);
                }

                oReport.SetCellValue(7, "I",PieceQty.ToString() );
                oReport.SetCellValue(7, "J",Qty.ToString());
             
                oReport.SetCellValue(7, "L",Amount.ToString());
                oReport.SetCellValue(7, "M",InvoiceQty.ToString());
                oReport.SetCellValue(7, "N", InvoiceAmount.ToString());
                oReport.SetCellValue(7, "O", PayAmount.ToString());

                for (int i = 2; i < dto.Rows.Count; i++)
                {
                    oReport.RangeSet("A5", "O5");
                    oReport.RangeInsertRow();
                }


                for (int i = 0; i < dto.Rows.Count; i++)
                {
                    oReport.SetCellValue(5 + i, "A", dto.Rows[i]["FormNM"].ToString());
                    oReport.SetCellValue(5 + i, "B", "'" + dto.Rows[i]["VendorAttn"].ToString());
                    oReport.SetCellValue(5 + i, "C", "'" +SysConvert.ToDateTime(dto.Rows[i]["FormDate"]).ToString("yyyy-MM-dd"));
                    oReport.SetCellValue(5 + i, "D", "'" + dto.Rows[i]["DtsSO"].ToString());
                   
                    oReport.SetCellValue(5 + i, "F", "'" + dto.Rows[i]["GoodsCode"].ToString());
                    
                    
                    oReport.SetCellValue(5 + i, "E", "'" + dto.Rows[i]["ItemCode"].ToString());
                    oReport.SetCellValue(5 + i, "G", dto.Rows[i]["ColorNum"].ToString());
                    oReport.SetCellValue(5 + i, "H", dto.Rows[i]["ColorName"].ToString());
                    oReport.SetCellValue(5 + i, "I", dto.Rows[i]["PieceQty"].ToString());
                    oReport.SetCellValue(5 + i, "J", dto.Rows[i]["Qty"].ToString());
                    oReport.SetCellValue(5 + i, "K", dto.Rows[i]["SinglePrice"].ToString());
                    oReport.SetCellValue(5 + i, "L", dto.Rows[i]["Amount"].ToString());
                    oReport.SetCellValue(5 + i, "M", dto.Rows[i]["InvoiceQty"].ToString());
                    oReport.SetCellValue(5 + i, "N", dto.Rows[i]["InvoiceAmount"].ToString());
                    oReport.SetCellValue(5 + i, "O", dto.Rows[i]["PayAmount"].ToString());
                }


            }



            oReport.EndExport();
            p_ExportFile = oReport.ReportExport;//返回导出文件名称






        }
        #endregion

        #region 通用方法导出EXCEL
        /*****
         * 调用示例
         * 仅一个模板、无程序传入参数  CommonExcelTypeToExcel((int)ExcelType.样衣工艺单,new string[]{this.ID.ToString()},out p_ExportFile);
         * 仅一个模板、有程序传入参数  string[,] p_apExport= string[2,3];
         *                             p_apExport[0,0]="1"; p_apExport[0,1]="A", p_apExport[0,2]="横机样衣工艺单";;
         *                             p_apExport[1,0]="2"; p_apExport[1,1]="A", p_apExport[1,2]=FParamConfig.LoginName;
         *                             CommonExcelTypeToExcel((int)ExcelType.样衣工艺单,new string[]{this.ID.ToString()},out p_ExportFile);
         * 
         * 多个模板，无程序传入参数    CommonExMainToExcel(ExMainID,new string[]{this.ID.ToString()},out p_ExportFile);
         * 
         * *************/

        /// <summary>
        /// 导出EXCEL(单据类型)
        /// </summary>
        /// <param name="p_ExcelID">模板ID</param>
        /// <param name="p_ConParam">条件数组</param>
        /// <param name="p_ExportFile">导出文件名称</param>
        public static void CommonExcelTypeToExcel(int p_ExcelTypeID, string[] p_ConParam, out string p_ExportFile)
        {
            CommonExcelTypeToExcel(p_ExcelTypeID, p_ConParam, new string[0, 0], out p_ExportFile);
        }

        /// <summary>
        /// 导出EXCEL(单据类型)
        /// </summary>
        /// <param name="p_ExcelID">模板ID</param>
        /// <param name="p_ConParam">条件数组</param>
        /// <param name="p_apExport">导出参数</param>
        /// <param name="p_ExportFile">导出文件名称</param>
        public static void CommonExcelTypeToExcel(int p_ExcelTypeID, string[] p_ConParam, string[,] p_apExport, out string p_ExportFile)
        {

            string sql = "SELECT ID FROM Data_ExMain WHERE ExcelTypeID=" + p_ExcelTypeID + " AND DefaultFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                CommonExMainToExcel(SysConvert.ToInt32(dt.Rows[0][0]), p_ConParam, p_apExport, out p_ExportFile);
            }
            else
            {
                throw new Exception("不能打印，没有配置打印模板，请联系系统管理员");
            }
        }



        /// <summary>
        /// 导出EXCEL(模板ID)
        /// </summary>
        /// <param name="p_ExcelID">模板ID</param>
        /// <param name="p_ConParam">条件数组</param>
        /// <param name="p_ExportFile">导出文件名称</param>
        public static void CommonExMainToExcel(int p_ExmainID, string[] p_ConParam, out string p_ExportFile)
        {
            CommonExMainToExcel(p_ExmainID, p_ConParam, new string[0, 0], out p_ExportFile);
        }


        /// <summary>
        /// 导出EXCEL(模板ID)
        /// </summary>
        /// <param name="p_ExcelID">模板ID</param>
        /// <param name="p_ConParam">条件数组</param>
        /// <param name="p_apExport">导出参数</param>
        /// <param name="p_ExportFile">导出文件名称</param>
        public static void CommonExMainToExcel(int p_ExcelID, string[] p_ConParam, string[,] p_apExport, out string p_ExportFile)
        {
            string sql = string.Empty;
            string TemplateFileName = string.Empty, FilePreName = string.Empty;
            p_ExportFile = string.Empty;
            ProcessExcel oReport = new ProcessExcel();
            sql = "SELECT TemplateFileName,FilePreName FROM Data_ExMain WHERE ID=" + SysString.ToDBString(p_ExcelID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                TemplateFileName = dt.Rows[0]["TemplateFileName"].ToString();
                FilePreName = dt.Rows[0]["FilePreName"].ToString();
            }
            else
            {
                return;
            }
            oReport.ReportTemplate = TemplateFileRoute + TemplateFileName;//模板文件
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("模板文件没有找到" + Environment.NewLine + "路径：" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(FilePreName);//临时文件
            if (oReport.ReportExport == "")
            {
                throw new Exception("导出临时文件生成失败，请重新导出");
            }

            oReport.BeginExport();
            if (p_apExport.Length != 0)//有程序输出的数据
            {
                for (int i = 0; i < p_apExport.Length / 3; i++)
                {
                    oReport.SetCellValue(p_apExport[i, 0], p_apExport[i, 1], p_apExport[i, 2]);
                }
            }


            /*赋数据Bein*/
            //单头数据赋值
            sql = "SELECT COUNT(ExDataSourceID) SCount,ExDataSourceID FROM Data_ExMainDts WHERE ExmainID=" + SysString.ToDBString(p_ExcelID);//寻找数据源
            sql += " GROUP BY ExDataSourceID";
            dt = SysUtils.Fill(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql = "SELECT SqlStr,DBSort FROM Data_ExDataSource WHERE ID=" + SysString.ToDBString(dt.Rows[i]["ExDataSourceID"].ToString());
                DataTable dtTempSource = SysUtils.Fill(sql);
                if (dtTempSource.Rows.Count != 0)
                {
                    sql = GetConSqlStr(dtTempSource.Rows[0]["SqlStr"].ToString(), p_ConParam);//数据源执行SQL
                    DataTable dtSource = ExeDBSortSql(sql, (int)dtTempSource.Rows[0]["DBSort"]);//SysUtils.Fill(sql);
                    if (dtSource.Rows.Count == 0)//一行值都没有，则进行下一循环
                    {
                        continue;
                    }

                    //寻找单头每一个数据
                    sql = "SELECT FieldName,ExcelDataTypeID,RowCell,ColCell,SavePosNum,PicSizeWidth,PicSizeHeight FROM Data_ExMainDts WHERE ExmainID=" + SysString.ToDBString(p_ExcelID);
                    sql += " AND ExDataSourceID=" + SysString.ToDBString(dt.Rows[i]["ExDataSourceID"].ToString());
                    DataTable dtField = SysUtils.Fill(sql);
                    if (dtField.Rows.Count != 0)
                    {
                        for (int j = 0; j < dtField.Rows.Count; j++)
                        {
                            string tempstr = GetPropCellValue(dtSource.Rows[0][dtField.Rows[j]["FieldName"].ToString()], SysConvert.ToInt32(dtField.Rows[j]["ExcelDataTypeID"]), SysConvert.ToInt32(dtField.Rows[j]["SavePosNum"]));
                            if (SysConvert.ToInt32(dtField.Rows[j]["ExcelDataTypeID"]) != (int)ExcelDataType.图片)//非图片
                            {
                                oReport.SetCellValue(SysConvert.ToInt32(dtField.Rows[j]["RowCell"]), dtField.Rows[j]["ColCell"].ToString(), tempstr);
                            }
                            else//导出图片
                            {
                                if (tempstr != "")
                                {
                                    oReport.PictureInsert(dtField.Rows[j]["ColCell"].ToString() + SysConvert.ToInt32(dtField.Rows[j]["RowCell"]), tempstr, SysConvert.ToFloat(dtField.Rows[j]["PicSizeWidth"]), SysConvert.ToFloat(dtField.Rows[j]["PicSizeHeight"]));//宽根据宽度/6.41；高度根据EXCEL高度得到
                                }
                            }
                        }
                    }
                }
            }

            //明细数据赋值
            sql = "SELECT ExDataSourceID,Seq,BeginRow,EndRow,AutoAddFlag,AutoAddRow,AutoAddColB,AutoAddColE FROM Data_ExDetail WHERE ExmainID=" + SysString.ToDBString(p_ExcelID);
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sql = "SELECT SqlStr FROM Data_ExDataSource WHERE ID=" + SysString.ToDBString(dt.Rows[i]["ExDataSourceID"].ToString());
                    DataTable dtSource = SysUtils.Fill(sql);
                    if (dtSource.Rows.Count != 0)
                    {
                        sql = GetConSqlStr(dtSource.Rows[0]["SqlStr"].ToString(), p_ConParam);
                        dtSource = SysUtils.Fill(sql);
                        if (dtSource.Rows.Count != 0)
                        {
                            int autoAddFlag = SysConvert.ToInt32(dt.Rows[i]["AutoAddFlag"]);//
                            int autoAddRow = SysConvert.ToInt32(dt.Rows[i]["AutoAddRow"]);//
                            string autoAddColB = SysConvert.ToString(dt.Rows[i]["AutoAddColB"]);//
                            string autoAddColE = SysConvert.ToString(dt.Rows[i]["AutoAddColE"]);//
                            int beginRow = SysConvert.ToInt32(dt.Rows[i]["BeginRow"]);//
                            int endRow = SysConvert.ToInt32(dt.Rows[i]["EndRow"]);//

                            if (autoAddFlag == (int)YesOrNo.Yes)//自动增行
                            {

                                sql = "SELECT ColCellBegin,ColCellEnd FROM Data_ExDetailMerge WHERE ExmainID=" + SysString.ToDBString(p_ExcelID);
                                sql += " AND Seq=" + SysString.ToDBString(dt.Rows[i]["Seq"].ToString());
                                DataTable dtMerge = SysUtils.Fill(sql);

                                for (int addR = endRow - beginRow + 1; addR < dtSource.Rows.Count; addR++)
                                {
                                    oReport.RangeSet(autoAddColB + autoAddRow, autoAddColE + autoAddRow);
                                    oReport.RangeInsertRow();
                                    foreach (DataRow drMerge in dtMerge.Rows)
                                    {
                                        oReport.RangeSet(drMerge["ColCellBegin"].ToString() + autoAddRow, drMerge["ColCellEnd"].ToString() + autoAddRow);
                                        oReport.RangeMergeCells();
                                    }
                                }
                                endRow = beginRow + dtSource.Rows.Count - 1;
                            }

                            sql = "SELECT FieldName,ExcelDataTypeID,ColCell,SavePosNum,PicSizeWidth,PicSizeHeight FROM Data_ExDetailDts WHERE ExmainID=" + SysString.ToDBString(p_ExcelID);
                            sql += " AND Seq=" + SysString.ToDBString(dt.Rows[i]["Seq"].ToString());
                            DataTable dtField = SysUtils.Fill(sql);
                            if (dtField.Rows.Count != 0)//有明细字段
                            {
                                for (int j = 0; j < dtField.Rows.Count; j++)//遍历明细字段
                                {
                                    int index = 0;
                                    for (int k = beginRow; k <= endRow; k++)//明细行数据赋值
                                    {
                                        if (index >= dtSource.Rows.Count)
                                        {
                                            break;
                                        }

                                        string tempstr = GetPropCellValue(dtSource.Rows[index][dtField.Rows[j]["FieldName"].ToString()], SysConvert.ToInt32(dtField.Rows[j]["ExcelDataTypeID"]), SysConvert.ToInt32(dtField.Rows[j]["SavePosNum"]));
                                        if (SysConvert.ToInt32(dtField.Rows[j]["ExcelDataTypeID"]) != (int)ExcelDataType.图片)//非图片
                                        {
                                            oReport.SetCellValue(k, dtField.Rows[j]["ColCell"].ToString(), tempstr);
                                        }
                                        else//导出图片
                                        {
                                            if (tempstr != "")
                                            {
                                                oReport.PictureInsert(dtField.Rows[j]["ColCell"].ToString() + k, tempstr, SysConvert.ToFloat(dtField.Rows[j]["PicSizeWidth"]), SysConvert.ToFloat(dtField.Rows[j]["PicSizeHeight"]));//宽根据宽度/6.41；高度根据EXCEL高度得到
                                            }
                                        }
                                        index++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            /*赋数据End*/
            oReport.EndExport();
            p_ExportFile = oReport.ReportExport;//返回导出文件名称
        }



        /// <summary>
        /// 获得合适的数据
        /// </summary>
        /// <param name="p_CellValue">单元格的值</param>
        /// <param name="p_DataTypeID">数据类型ID</param>
        /// <param name="p_SavePosNum">小数位数</param>
        /// <returns>值</returns>
        private static string GetPropCellValue(object p_CellValue, int p_DataTypeID, int p_SavePosNum)
        {
            string p_OutProCellValue = string.Empty;
            switch (p_DataTypeID)
            {
                case (int)ExcelDataType.字符:
                    p_OutProCellValue = p_CellValue.ToString();
                    break;
                case (int)ExcelDataType.数值:
                    p_OutProCellValue = p_CellValue.ToString();
                    break;
                case (int)ExcelDataType.日期:
                    if (SysConvert.ToDateTime(p_CellValue) != SystemConfiguration.DateTimeDefaultValue)
                    {
                        p_OutProCellValue = SysConvert.ToDateTime(p_CellValue).ToString("yyyy-MM-dd");
                    }
                    break;
                case (int)ExcelDataType.图片:
                    p_OutProCellValue = TemplatePic.SaveImage((byte[])p_CellValue, "htp");
                    break;
                case (int)ExcelDataType.小数:
                    if (SysConvert.ToDecimal(p_CellValue) != 0)
                    {
                        p_OutProCellValue = SysConvert.ToDecimal(p_CellValue.ToString(), p_SavePosNum).ToString();
                    }
                    else
                    {
                        p_OutProCellValue = p_CellValue.ToString();
                    }
                    break;
                case (int)ExcelDataType.日期带时间:
                    if (SysConvert.ToDateTime(p_CellValue) != SystemConfiguration.DateTimeDefaultValue)
                    {
                        p_OutProCellValue = SysConvert.ToDateTime(p_CellValue).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    break;
            }
            return p_OutProCellValue;
        }

        /// <summary>
        /// 获得替换查询条件后的SQL语句
        /// </summary>
        /// <param name="p_SqlStr">需要替换条件的SQL语句</param>
        /// <param name="p_ConParam">参数数组</param>
        /// <returns></returns>
        private static string GetConSqlStr(string p_SqlStr, string[] p_ConParam)
        {
            for (int i = 0; i < p_ConParam.Length; i++)
            {
                string oldStr = "[" + i.ToString() + "]";
                string newStr = SysString.ToDBString(p_ConParam[i]);
                p_SqlStr = p_SqlStr.Replace(oldStr, newStr);
            }
            return p_SqlStr;
        }
        #endregion

        #region 数据库执行
        /// <summary>
        /// 按照第几数据库执行
        /// </summary>
        /// <returns></returns>
        private static DataTable ExeDBSortSql(string p_Sql, int p_Sort)
        {
            DataTable p_Dt = new DataTable();
            switch (p_Sort)
            {

                case 1:
                    p_Dt = SysUtils.Fill(p_Sql);
                    break;
                case 2:
                    p_Dt = SysUtilsSecond.Fill(p_Sql);
                    break;
                case 3:
                    p_Dt = SysUtilsThird.Fill(p_Sql);
                    break;
                case 4:
                    p_Dt = SysUtilsFourth.Fill(p_Sql);
                    break;
                default:
                    p_Dt = SysUtils.Fill(p_Sql);
                    break;
            }
            return p_Dt;
        }
        #endregion

    

     


    }
}
