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
    /// ģ��תExcel
    /// </summary>
    public class TemplateExcel
    {

        private static string TemplateFileRoute = Application.StartupPath + @"\Template\";//ģ���ļ�·��
        private static string TempFileRoute = Application.StartupPath + @"\Temp\";//������ʱ�ļ�·��

        private static string OPArgFileName = "OPArg.xls";//Ա��Ȩ��ģ���ļ�����
        private static string OPArgFilePre = "Ա��Ȩ��";//Ա��Ȩ�ޱ���ʱ�ļ�ǰ׺

        private static string SOMFileName = "SOM.xls";//�ͻ�����ģ���ļ�����
        private static string SOMFilePre = "�ͻ�����";//�ͻ���������ʱ�ļ�ǰ׺


        private static string ItemFileName = "Item.xls";//�ͻ�����ģ���ļ�����
        private static string ItemFilePre = "ɴ�߹���";//�ͻ���������ʱ�ļ�ǰ׺


        private static string FHFormFileName = "FHForm.xls";//������ģ���ļ�����
        private static string FHFormFilePre = "������";//����������ʱ�ļ�ǰ׺

        private static string DZFileName = "CaiWuDZ.xls";//������ģ���ļ�����
        private static string DZFilePre = "�������";//����������ʱ�ļ�ǰ׺

        private static string InOutFileName = "FinceWHInOutRpt.xls";//������ģ���ļ�����
        private static string InOutFilePre = "�������񱨱�";//����������ʱ�ļ�ǰ׺


       
    






        #region ɴ�߹���
        /// <summary>
        /// ����Ա��Ȩ��
        /// </summary>
        /// <param name="p_SampleID">OPID</param>
        /// <param name="p_ExportFile">�����ļ�����</param>
        public static void ItemFileToExcel(DataTable dt, string p_Date, out string p_ExportFile)
        {
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + ItemFileName;//ģ���ļ�
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("ģ���ļ�û���ҵ�" + Environment.NewLine + "·����" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(ItemFilePre);//��ʱ�ļ�
            if (oReport.ReportExport == "")
            {
                throw new Exception("������ʱ�ļ�����ʧ�ܣ������µ���");
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
            p_ExportFile = oReport.ReportExport;//���ص����ļ�����





            
        }
        #endregion
              

        #region �����ļ�����

        /// <summary>
        /// ��õ����ļ�����
        /// </summary>
        /// <param name="p_FilePre">�ļ�ǰ׺</param>
        /// <returns>�ļ�����(��·��)</returns>
        private static string GetTempFileName(string p_FilePre)
        {
            string outstr = string.Empty;
            const int sindex = 10, eindex = 30, mindex = 21;//sindex=10,eindex=15,mindex=12;
            SysFile.CreateDDirectory(TempFileRoute);//û���ҵ��򴴽���ʱ�ļ���·��
            string FileName = string.Empty, DleteFileName = string.Empty;
            int i = 0;
            for (i = sindex; i < eindex; i++)
            {
                FileName = TempFileRoute + p_FilePre + i.ToString() + ".xls";
                if (!SysFile.CheckFileExit(FileName))//�ҵ�������
                {
                    break;
                }
            }
            if (i == mindex)//��������м��ߣ�ɾ���м��ߺ�����ļ�
            {
                for (int j = mindex + 1; j < eindex; j++)
                {
                    DleteFileName = TempFileRoute + p_FilePre + j.ToString() + ".xls";
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            if (i == eindex)//�������ĩβ��ɾ���м���ǰ����ļ�
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

        #region Ա��Ȩ��
        /// <summary>
        /// ����Ա��Ȩ��
        /// </summary>
        /// <param name="p_SampleID">OPID</param>
        /// <param name="p_ExportFile">�����ļ�����</param>
        public static void OPArgToExcel(string p_OPID, ArrayList p_Al, out string p_ExportFile)
        {
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + OPArgFileName;//ģ���ļ�
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("ģ���ļ�û���ҵ�" + Environment.NewLine + "·����" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(OPArgFilePre);//��ʱ�ļ�
            if (oReport.ReportExport == "")
            {
                throw new Exception("������ʱ�ļ�����ʧ�ܣ������µ���");
            }

            oReport.BeginExport();
            /*������Bein*/

            oReport.SetCellValue(1, "A", Common.GetNameByOPID(p_OPID));//Ա������
            for (int i = 0; i < p_Al.Count; i++)
            {
                string[] tempa = (string[])(p_Al[i]);
                oReport.SetCellValue(i + 2, "A", tempa[0]);//�˵�����
                oReport.SetCellValue(i + 2, "B", tempa[1]);//Ȩ������
            }
            oReport.SetCellValue(p_Al.Count + 2, "A", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));//��������
            /*������End*/
            oReport.EndExport();
            p_ExportFile = oReport.ReportExport;//���ص����ļ�����
        }
        #endregion



        #region ����������
        /// <summary>
        /// ����Ա��Ȩ��
        /// </summary>
        /// <param name="p_ID">ID</param>
        /// <param name="p_ExportFile">�����ļ�����</param>
        public static void FHFormToExcel(int p_ID, out string p_ExportFile)
        {
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + FHFormFileName;//ģ���ļ�
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("ģ���ļ�û���ҵ�" + Environment.NewLine + "·����" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(FHFormFilePre);//��ʱ�ļ�
            if (oReport.ReportExport == "")
            {
                throw new Exception("������ʱ�ļ�����ʧ�ܣ������µ���");
            }

            oReport.BeginExport();

            string sql = "SELECT * FROM UV1_Sale_FHForm WHERE ID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                oReport.SetCellValue(5, "B", SysConvert.ToString(dt.Rows[0]["VendorAttn"]));//�ջ���λ
                oReport.SetCellValue(3, "H", SysConvert.ToString(dt.Rows[0]["FormNo"]));//����
                oReport.SetCellValue(4, "H", "No��" + SysConvert.ToString(dt.Rows[0]["SendCode"]));//����
                oReport.SetCellValue(5, "H", "���ڣ�" + SysConvert.ToDateTime(dt.Rows[0]["MakeDate"]).ToString("yyyy-MM-dd"));//�Ƶ�����
                oReport.SetCellValue(12, "B", SysConvert.ToString(dt.Rows[0]["Address"]) + "" + SysConvert.ToString(dt.Rows[0]["Tel"]));//��ע
                oReport.SetCellValue(13, "B", SysConvert.ToString(dt.Rows[0]["MakeOPName"]));//�Ƶ���
                oReport.SetCellValue(13, "D", SysConvert.ToString(dt.Rows[0]["OPName"]));//ҵ��Ա
                oReport.SetCellValue(13, "G", SysConvert.ToString(dt.Rows[0]["SHR"]));//�ͻ���
                oReport.SetCellValue(14, "A", "��ַ���Ϻ���ˮ·480��  �Ϻ���֯�κ�԰��4��1¥   �绰����021��51095188  ���棺��021��51098093*889   ��ϵ�ˣ�" + SysConvert.ToString(dt.Rows[0]["OPName"]));//��ϵ��
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
                oReport.SetCellValue(4, "B", SysConvert.ToString(dto.Rows[0]["CustomerCode"]));//��ͬ��
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
                oReport.SetCellValue(11, "D", pieceQty.ToString());//�ջ���λ
                oReport.SetCellValue(11, "E", qty.ToString());//�ջ���λ
                oReport.SetCellValue(11, "G", amount.ToString());//�ջ���λ

            }
            //oReport.SetCellValue(3, "A", "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            //oReport.RangeSet("A3", "Z3");
            //oReport.RangeAutoFit();
            oReport.EndExport();
            p_ExportFile = oReport.ReportExport;//���ص����ļ�����






        }
        #endregion

        #region ����������2
        /// <summary>
        /// ����Ա��Ȩ��
        /// </summary>
        /// <param name="p_ID">ID</param>
        /// <param name="p_ExportFile">�����ļ�����</param>
        public static void FHFormToExcel2(int p_ID, DataTable p_dt, int p_Num, out string p_ExportFile)
        {
            if (p_Num > p_dt.Rows.Count)
            {

                p_ExportFile = "��һ��������";
            }
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + FHFormFileName;//ģ���ļ�
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("ģ���ļ�û���ҵ�" + Environment.NewLine + "·����" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(FHFormFilePre);//��ʱ�ļ�
            if (oReport.ReportExport == "")
            {
                throw new Exception("������ʱ�ļ�����ʧ�ܣ������µ���");
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
                oReport.SetCellValue(4, "F","page:"+ pageStr);//�ջ���λ
                oReport.SetCellValue(5, "B", SysConvert.ToString(dt.Rows[0]["VendorAttn"]));//�ջ���λ
                oReport.SetCellValue(3, "H", SysConvert.ToString(dt.Rows[0]["FormNo"]));//����
                oReport.SetCellValue(4, "H", "No��" + SysConvert.ToString(dt.Rows[0]["SendCode"]));//����
                oReport.SetCellValue(5, "H", "���ڣ�" + SysConvert.ToDateTime(dt.Rows[0]["MakeDate"]).ToString("yyyy-MM-dd"));//�Ƶ�����
                oReport.SetCellValue(12, "B", SysConvert.ToString(dt.Rows[0]["Address"]) + "" + SysConvert.ToString(dt.Rows[0]["Tel"]));//��ע
                oReport.SetCellValue(13, "B", SysConvert.ToString(dt.Rows[0]["MakeOPName"]));//�Ƶ���
                oReport.SetCellValue(13, "D", SysConvert.ToString(dt.Rows[0]["OPName"]));//ҵ��Ա
                oReport.SetCellValue(13, "G", SysConvert.ToString(dt.Rows[0]["SHR"]));//�ͻ���
                oReport.SetCellValue(14, "A", "��ַ���Ϻ���ˮ·480��  �Ϻ���֯�κ�԰��4��1¥   �绰����021��51095188  ���棺��021��51098093*889   ��ϵ�ˣ�" + SysConvert.ToString(dt.Rows[0]["OPName"]));//��ϵ��
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
                    oReport.SetCellValue(11, "D", pieceQty.ToString());//�ͻ���
                    oReport.SetCellValue(11, "E", qty.ToString());//�ͻ���
                    oReport.SetCellValue(11, "G", amount.ToString());//�ͻ���
                   
                   

                }



            }

            bool autofileFlag = false;//�Ƿ��Զ������߶ȱ�־
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
                oReport.SetCellValue(4, "B", cusc);//��ͬ��
               
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
            //////��ȡ�Ѵ򿪵�Excel
            ////Excel.Worksheet workSheet1 = (Excel.Worksheet)workBook.Sheets["Sheet1"];

            ////oReport.SetCellValue(staro + i, "G", SysConvert.ToString(dto.Rows[i]["Amount"]));
            //if (p_Num < 5)
            //{
            //    decimal H1=SysConvert.ToDecimal(((Excel.Range)oReport.objRange.Rows[5]).RowHeight);
            //    oReport.RangeSet("A11", "H11");
            //    oReport.RangeSetRowHeight(30);
            //    oReport.SetCellValue(19, "A", H1.ToString());//�ͻ���
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
            p_ExportFile = oReport.ReportExport;//���ص����ļ�����






        }
        #endregion

        #region ����������3
        /// <summary>
        /// ����Ա��Ȩ��
        /// </summary>
        /// <param name="p_ID">ID</param>
        /// <param name="p_ExportFile">�����ļ�����</param>
        public static void FHFormToExcel3(int p_ID, DataTable p_dt, int p_Num, out string p_ExportFile)
        {
            //if (p_Num > p_dt.Rows.Count)
            //{

            //    return;
            //}
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + FHFormFileName;//ģ���ļ�
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("ģ���ļ�û���ҵ�" + Environment.NewLine + "·����" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(FHFormFilePre);//��ʱ�ļ�
            if (oReport.ReportExport == "")
            {
                throw new Exception("������ʱ�ļ�����ʧ�ܣ������µ���");
            }

            oReport.BeginExport();

            string sql = "SELECT * FROM UV1_Sale_FHForm WHERE ID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                oReport.SetCellValue(4, "F", "page:2/2");//�ջ���λ
                oReport.SetCellValue(5, "B", SysConvert.ToString(dt.Rows[0]["VendorAttn"]));//�ջ���λ
                oReport.SetCellValue(3, "H", SysConvert.ToString(dt.Rows[0]["FormNo"]));//����
                oReport.SetCellValue(4, "H", "No��" + SysConvert.ToString(dt.Rows[0]["SendCode"]));//����
                oReport.SetCellValue(5, "H", "���ڣ�" + SysConvert.ToDateTime(dt.Rows[0]["MakeDate"]).ToString("yyyy-MM-dd"));//�Ƶ�����
                oReport.SetCellValue(12, "B", SysConvert.ToString(dt.Rows[0]["Address"]) + "" + SysConvert.ToString(dt.Rows[0]["Tel"]));//��ע
                oReport.SetCellValue(13, "B", SysConvert.ToString(dt.Rows[0]["MakeOPName"]));//�Ƶ���
                oReport.SetCellValue(13, "D", SysConvert.ToString(dt.Rows[0]["OPName"]));//ҵ��Ա
                oReport.SetCellValue(13, "G", SysConvert.ToString(dt.Rows[0]["SHR"]));//�ͻ���
                oReport.SetCellValue(14, "A", "��ַ���Ϻ���ˮ·480��  �Ϻ���֯�κ�԰��4��1¥   �绰����021��51095188  ���棺��021��51098093*889   ��ϵ�ˣ�" + SysConvert.ToString(dt.Rows[0]["OPName"]));//��ϵ��
               
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
                    oReport.SetCellValue(11, "D", pieceQty.ToString());//�ͻ���
                    oReport.SetCellValue(11, "E", qty.ToString());//�ͻ���
                    oReport.SetCellValue(11, "G", amount.ToString());//�ͻ���
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
                oReport.SetCellValue(4, "B", cusc);//��ͬ��
              
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
            p_ExportFile = oReport.ReportExport;//���ص����ļ�����






        }
        #endregion

        #region ����������˱���
        /// <summary>
        /// ����������˱���
        /// </summary>
        /// <param name="p_ID">ID</param>
        /// <param name="p_ExportFile">�����ļ�����</param>
        public static void CaiWuDZToExcel(DataTable dto,string p_DateStr, out string p_ExportFile)
        {
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute +DZFileName;//ģ���ļ�
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("ģ���ļ�û���ҵ�" + Environment.NewLine + "·����" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(DZFilePre);//��ʱ�ļ�
            if (oReport.ReportExport == "")
            {
                throw new Exception("������ʱ�ļ�����ʧ�ܣ������µ���");
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
                string FinSUM = "Ӧ��Ʊ������"+SysConvert.ToDecimal(Qty-KPQty).ToString()+";Ӧ��Ʊ��"+SysConvert.ToDecimal(Amount-KPAmount).ToString()+";�ո����"+SysConvert.ToDecimal(Amount-LKAmount).ToString();
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
            p_ExportFile = oReport.ReportExport;//���ص����ļ�����






        }
        #endregion

        #region �����ֿ�������񱨱�
        /// <summary>
        /// �����ֿ�������񱨱�
        /// </summary>
        /// <param name="p_ID">ID</param>
        /// <param name="p_ExportFile">�����ļ�����</param>
        public static void CaiWuWHInOutToExcel(DataTable dto, string p_DateStr, out string p_ExportFile)
        {
            ProcessExcel oReport = new ProcessExcel();
            oReport.ReportTemplate = TemplateFileRoute + InOutFileName;//ģ���ļ�
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("ģ���ļ�û���ҵ�" + Environment.NewLine + "·����" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(InOutFilePre);//��ʱ�ļ�
            if (oReport.ReportExport == "")
            {
                throw new Exception("������ʱ�ļ�����ʧ�ܣ������µ���");
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
            p_ExportFile = oReport.ReportExport;//���ص����ļ�����






        }
        #endregion

        #region ͨ�÷�������EXCEL
        /*****
         * ����ʾ��
         * ��һ��ģ�塢�޳��������  CommonExcelTypeToExcel((int)ExcelType.���¹��յ�,new string[]{this.ID.ToString()},out p_ExportFile);
         * ��һ��ģ�塢�г��������  string[,] p_apExport= string[2,3];
         *                             p_apExport[0,0]="1"; p_apExport[0,1]="A", p_apExport[0,2]="������¹��յ�";;
         *                             p_apExport[1,0]="2"; p_apExport[1,1]="A", p_apExport[1,2]=FParamConfig.LoginName;
         *                             CommonExcelTypeToExcel((int)ExcelType.���¹��յ�,new string[]{this.ID.ToString()},out p_ExportFile);
         * 
         * ���ģ�壬�޳��������    CommonExMainToExcel(ExMainID,new string[]{this.ID.ToString()},out p_ExportFile);
         * 
         * *************/

        /// <summary>
        /// ����EXCEL(��������)
        /// </summary>
        /// <param name="p_ExcelID">ģ��ID</param>
        /// <param name="p_ConParam">��������</param>
        /// <param name="p_ExportFile">�����ļ�����</param>
        public static void CommonExcelTypeToExcel(int p_ExcelTypeID, string[] p_ConParam, out string p_ExportFile)
        {
            CommonExcelTypeToExcel(p_ExcelTypeID, p_ConParam, new string[0, 0], out p_ExportFile);
        }

        /// <summary>
        /// ����EXCEL(��������)
        /// </summary>
        /// <param name="p_ExcelID">ģ��ID</param>
        /// <param name="p_ConParam">��������</param>
        /// <param name="p_apExport">��������</param>
        /// <param name="p_ExportFile">�����ļ�����</param>
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
                throw new Exception("���ܴ�ӡ��û�����ô�ӡģ�壬����ϵϵͳ����Ա");
            }
        }



        /// <summary>
        /// ����EXCEL(ģ��ID)
        /// </summary>
        /// <param name="p_ExcelID">ģ��ID</param>
        /// <param name="p_ConParam">��������</param>
        /// <param name="p_ExportFile">�����ļ�����</param>
        public static void CommonExMainToExcel(int p_ExmainID, string[] p_ConParam, out string p_ExportFile)
        {
            CommonExMainToExcel(p_ExmainID, p_ConParam, new string[0, 0], out p_ExportFile);
        }


        /// <summary>
        /// ����EXCEL(ģ��ID)
        /// </summary>
        /// <param name="p_ExcelID">ģ��ID</param>
        /// <param name="p_ConParam">��������</param>
        /// <param name="p_apExport">��������</param>
        /// <param name="p_ExportFile">�����ļ�����</param>
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
            oReport.ReportTemplate = TemplateFileRoute + TemplateFileName;//ģ���ļ�
            if (!SysFile.CheckFileExit(oReport.ReportTemplate))
            {
                throw new Exception("ģ���ļ�û���ҵ�" + Environment.NewLine + "·����" + oReport.ReportTemplate);
            }

            oReport.ReportExport = GetTempFileName(FilePreName);//��ʱ�ļ�
            if (oReport.ReportExport == "")
            {
                throw new Exception("������ʱ�ļ�����ʧ�ܣ������µ���");
            }

            oReport.BeginExport();
            if (p_apExport.Length != 0)//�г������������
            {
                for (int i = 0; i < p_apExport.Length / 3; i++)
                {
                    oReport.SetCellValue(p_apExport[i, 0], p_apExport[i, 1], p_apExport[i, 2]);
                }
            }


            /*������Bein*/
            //��ͷ���ݸ�ֵ
            sql = "SELECT COUNT(ExDataSourceID) SCount,ExDataSourceID FROM Data_ExMainDts WHERE ExmainID=" + SysString.ToDBString(p_ExcelID);//Ѱ������Դ
            sql += " GROUP BY ExDataSourceID";
            dt = SysUtils.Fill(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql = "SELECT SqlStr,DBSort FROM Data_ExDataSource WHERE ID=" + SysString.ToDBString(dt.Rows[i]["ExDataSourceID"].ToString());
                DataTable dtTempSource = SysUtils.Fill(sql);
                if (dtTempSource.Rows.Count != 0)
                {
                    sql = GetConSqlStr(dtTempSource.Rows[0]["SqlStr"].ToString(), p_ConParam);//����Դִ��SQL
                    DataTable dtSource = ExeDBSortSql(sql, (int)dtTempSource.Rows[0]["DBSort"]);//SysUtils.Fill(sql);
                    if (dtSource.Rows.Count == 0)//һ��ֵ��û�У��������һѭ��
                    {
                        continue;
                    }

                    //Ѱ�ҵ�ͷÿһ������
                    sql = "SELECT FieldName,ExcelDataTypeID,RowCell,ColCell,SavePosNum,PicSizeWidth,PicSizeHeight FROM Data_ExMainDts WHERE ExmainID=" + SysString.ToDBString(p_ExcelID);
                    sql += " AND ExDataSourceID=" + SysString.ToDBString(dt.Rows[i]["ExDataSourceID"].ToString());
                    DataTable dtField = SysUtils.Fill(sql);
                    if (dtField.Rows.Count != 0)
                    {
                        for (int j = 0; j < dtField.Rows.Count; j++)
                        {
                            string tempstr = GetPropCellValue(dtSource.Rows[0][dtField.Rows[j]["FieldName"].ToString()], SysConvert.ToInt32(dtField.Rows[j]["ExcelDataTypeID"]), SysConvert.ToInt32(dtField.Rows[j]["SavePosNum"]));
                            if (SysConvert.ToInt32(dtField.Rows[j]["ExcelDataTypeID"]) != (int)ExcelDataType.ͼƬ)//��ͼƬ
                            {
                                oReport.SetCellValue(SysConvert.ToInt32(dtField.Rows[j]["RowCell"]), dtField.Rows[j]["ColCell"].ToString(), tempstr);
                            }
                            else//����ͼƬ
                            {
                                if (tempstr != "")
                                {
                                    oReport.PictureInsert(dtField.Rows[j]["ColCell"].ToString() + SysConvert.ToInt32(dtField.Rows[j]["RowCell"]), tempstr, SysConvert.ToFloat(dtField.Rows[j]["PicSizeWidth"]), SysConvert.ToFloat(dtField.Rows[j]["PicSizeHeight"]));//����ݿ��/6.41���߶ȸ���EXCEL�߶ȵõ�
                                }
                            }
                        }
                    }
                }
            }

            //��ϸ���ݸ�ֵ
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

                            if (autoAddFlag == (int)YesOrNo.Yes)//�Զ�����
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
                            if (dtField.Rows.Count != 0)//����ϸ�ֶ�
                            {
                                for (int j = 0; j < dtField.Rows.Count; j++)//������ϸ�ֶ�
                                {
                                    int index = 0;
                                    for (int k = beginRow; k <= endRow; k++)//��ϸ�����ݸ�ֵ
                                    {
                                        if (index >= dtSource.Rows.Count)
                                        {
                                            break;
                                        }

                                        string tempstr = GetPropCellValue(dtSource.Rows[index][dtField.Rows[j]["FieldName"].ToString()], SysConvert.ToInt32(dtField.Rows[j]["ExcelDataTypeID"]), SysConvert.ToInt32(dtField.Rows[j]["SavePosNum"]));
                                        if (SysConvert.ToInt32(dtField.Rows[j]["ExcelDataTypeID"]) != (int)ExcelDataType.ͼƬ)//��ͼƬ
                                        {
                                            oReport.SetCellValue(k, dtField.Rows[j]["ColCell"].ToString(), tempstr);
                                        }
                                        else//����ͼƬ
                                        {
                                            if (tempstr != "")
                                            {
                                                oReport.PictureInsert(dtField.Rows[j]["ColCell"].ToString() + k, tempstr, SysConvert.ToFloat(dtField.Rows[j]["PicSizeWidth"]), SysConvert.ToFloat(dtField.Rows[j]["PicSizeHeight"]));//����ݿ��/6.41���߶ȸ���EXCEL�߶ȵõ�
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

            /*������End*/
            oReport.EndExport();
            p_ExportFile = oReport.ReportExport;//���ص����ļ�����
        }



        /// <summary>
        /// ��ú��ʵ�����
        /// </summary>
        /// <param name="p_CellValue">��Ԫ���ֵ</param>
        /// <param name="p_DataTypeID">��������ID</param>
        /// <param name="p_SavePosNum">С��λ��</param>
        /// <returns>ֵ</returns>
        private static string GetPropCellValue(object p_CellValue, int p_DataTypeID, int p_SavePosNum)
        {
            string p_OutProCellValue = string.Empty;
            switch (p_DataTypeID)
            {
                case (int)ExcelDataType.�ַ�:
                    p_OutProCellValue = p_CellValue.ToString();
                    break;
                case (int)ExcelDataType.��ֵ:
                    p_OutProCellValue = p_CellValue.ToString();
                    break;
                case (int)ExcelDataType.����:
                    if (SysConvert.ToDateTime(p_CellValue) != SystemConfiguration.DateTimeDefaultValue)
                    {
                        p_OutProCellValue = SysConvert.ToDateTime(p_CellValue).ToString("yyyy-MM-dd");
                    }
                    break;
                case (int)ExcelDataType.ͼƬ:
                    p_OutProCellValue = TemplatePic.SaveImage((byte[])p_CellValue, "htp");
                    break;
                case (int)ExcelDataType.С��:
                    if (SysConvert.ToDecimal(p_CellValue) != 0)
                    {
                        p_OutProCellValue = SysConvert.ToDecimal(p_CellValue.ToString(), p_SavePosNum).ToString();
                    }
                    else
                    {
                        p_OutProCellValue = p_CellValue.ToString();
                    }
                    break;
                case (int)ExcelDataType.���ڴ�ʱ��:
                    if (SysConvert.ToDateTime(p_CellValue) != SystemConfiguration.DateTimeDefaultValue)
                    {
                        p_OutProCellValue = SysConvert.ToDateTime(p_CellValue).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    break;
            }
            return p_OutProCellValue;
        }

        /// <summary>
        /// ����滻��ѯ�������SQL���
        /// </summary>
        /// <param name="p_SqlStr">��Ҫ�滻������SQL���</param>
        /// <param name="p_ConParam">��������</param>
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

        #region ���ݿ�ִ��
        /// <summary>
        /// ���յڼ����ݿ�ִ��
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
