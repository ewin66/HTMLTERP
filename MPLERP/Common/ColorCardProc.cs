using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HttSoft.Framework;
using System.Collections;

namespace MLTERP
{
    /// <summary>
    /// 染色卡处理
    /// </summary>
    public class ColorCardProc
    {
        /// <summary>
        /// 染色卡区块参数表
        /// </summary>
        private static DataTable m_ColorCardSectionDt;
        private static DataTable ColorCardSectionDt
        {
            get
            {
                if (m_ColorCardSectionDt == null)
                {
                    string sql = "SELECT ID,Name,RowNum,0 CurRowNum,WarterRowNum FROM Enum_ColorCardSection";//CurRowNum当前行数
                    m_ColorCardSectionDt = SysUtils.Fill(sql);

                }
                return m_ColorCardSectionDt;
            }
        }

        /// <summary>
        /// 初始化当前行数
        /// </summary>
        private static void CurRowNumIni()
        {
            foreach (DataRow dr in ColorCardSectionDt.Rows)
            {
                dr["CurRowNum"] = 0;
            }
        }

        /// <summary>
        /// 更新当前行数
        /// </summary>
        private static void CurRowNumUpd(int p_ColorCardSectionID)
        {
            foreach (DataRow dr in ColorCardSectionDt.Rows)
            {
                if (SysConvert.ToInt32(dr["ID"]) == p_ColorCardSectionID)
                {
                    dr["CurRowNum"] = SysConvert.ToInt32(dr["CurRowNum"]) + 1;
                    break;
                }
            }
        }

        /// <summary>
        /// 获得当前行数
        /// </summary>
        private static int CurRowNumGet(int p_ColorCardSectionID)
        {
            int outint = 0;
            foreach (DataRow dr in ColorCardSectionDt.Rows)
            {
                if (SysConvert.ToInt32(dr["ID"]) == p_ColorCardSectionID)
                {
                    outint = SysConvert.ToInt32(dr["CurRowNum"]);
                    break;
                }
            }
            return outint;
        }

        /// <summary>
        /// 初始化一个染色卡出来(复样配方)
        /// </summary>
        /// <returns></returns>
        public static DataTable ColorCardProcIniRePF(int p_MainID)
        {
            string sql = "SELECT * FROM HYS_DesignRePFDts WHERE MainID=" + p_MainID + " AND MainID<>0 ORDER BY Seq";
            DataTable outdt = SysUtils.Fill(sql);
            int seq = 0;
            if (outdt.Rows.Count == 0)//没有任何行，产生新模板
            {
                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)
                {
                    for (int j = 0; j < SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["RowNum"]); j++)
                    {
                        seq++;
                        DataRow dr = outdt.NewRow();
                        dr["MainID"] = p_MainID;
                        dr["Seq"] = seq;
                        dr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(dr);
                    }
                }
                return outdt;
            }
            else//自动化添加行
            {
                CurRowNumIni();
                //ArrayList alRowID = new ArrayList();
                //ArrayList alRow = new ArrayList();
                for (int i = 0; i < outdt.Rows.Count; i++)//取出现存行
                {
                    //alRowID.Add(new int[] { SysConvert.ToInt32(outdt.Rows[i]["Seq"]), SysConvert.ToInt32(outdt.Rows[i]["ColorCardSectionID"]) });
                    //alRow.Add(outdt.Rows[i]);
                    CurRowNumUpd(SysConvert.ToInt32(outdt.Rows[i]["ColorCardSectionID"]));
                }
                int addseq = 100;
                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)//比对增加新行
                {
                    addseq++;
                    int maxRowNum = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["RowNum"]);//设定最大行数
                    int curRowNum = CurRowNumGet(SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]));//当前最大行数

                    for (int m = curRowNum; m < maxRowNum; m++)//追加行
                    {
                        //alRowID.Add(new int[] { addseq, SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]) });
                        DataRow tempdr = outdt.NewRow();
                        tempdr["MainID"] = p_MainID;
                        tempdr["Seq"] = addseq;
                        tempdr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(tempdr);
                    }
                }

                DataTable outdtExit = SysUtils.Fill("SELECT * FROM HYS_DesignRePFDts WHERE 1=0");

                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)//处理最终结果表
                {
                    foreach (DataRow dr in outdt.Rows)
                    {
                        if (SysConvert.ToInt32(dr["ColorCardSectionID"]) == SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]))
                        {
                            DataRow tempdr = outdtExit.NewRow();
                            for (int j = 0; j < outdtExit.Columns.Count; j++)
                            {
                                tempdr[j] = dr[j];
                            }
                            outdtExit.Rows.Add(tempdr);
                        }
                    }
                }

                return outdtExit;
            }
        }

        /// <summary>
        /// 初始化一个染色卡出来(模板)
        /// </summary>
        /// <returns></returns>
        public static DataTable ColorCardProcIniMB(int p_MainID)
        {
            string sql = "SELECT * FROM CC_MBColorCardDts WHERE MBColorCardID=" + p_MainID + " AND MBColorCardID<>0 ORDER BY Seq";
            DataTable outdt = SysUtils.Fill(sql);
            int seq=0;
            if (outdt.Rows.Count == 0)//没有任何行，产生新模板
            {
                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)
                {
                    for (int j = 0; j < SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["RowNum"]); j++)
                    {
                        seq++;
                        DataRow dr = outdt.NewRow();
                        dr["MBColorCardID"] = p_MainID;
                        dr["Seq"] = seq;
                        dr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(dr);
                    }
                }
                return outdt;
            }
            else//自动化添加行
            {
                CurRowNumIni();
                //ArrayList alRowID = new ArrayList();
                //ArrayList alRow = new ArrayList();
                for (int i = 0; i < outdt.Rows.Count; i++)//取出现存行
                {
                    //alRowID.Add(new int[] { SysConvert.ToInt32(outdt.Rows[i]["Seq"]), SysConvert.ToInt32(outdt.Rows[i]["ColorCardSectionID"]) });
                    //alRow.Add(outdt.Rows[i]);
                    CurRowNumUpd(SysConvert.ToInt32(outdt.Rows[i]["ColorCardSectionID"]));
                }
                int addseq = 100;
                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)//比对增加新行
                {
                    addseq++;
                    int maxRowNum = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["RowNum"]);//设定最大行数
                    int curRowNum = CurRowNumGet(SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]));//当前最大行数

                    for (int m = curRowNum; m < maxRowNum; m++)//追加行
                    {
                        //alRowID.Add(new int[] { addseq, SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]) });
                        DataRow tempdr = outdt.NewRow();
                        tempdr["MBColorCardID"] = p_MainID;
                        tempdr["Seq"] = addseq;
                        tempdr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(tempdr);
                    }
                }

                DataTable outdtExit = SysUtils.Fill("SELECT * FROM CC_MBColorCardDts WHERE 1=0");

                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)//处理最终结果表
                {
                    foreach (DataRow dr in outdt.Rows)
                    {
                        if (SysConvert.ToInt32(dr["ColorCardSectionID"]) == SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]))
                        {
                            DataRow tempdr = outdtExit.NewRow();
                            for (int j = 0; j < outdtExit.Columns.Count; j++)
                            {
                                tempdr[j] = dr[j];
                            }
                            outdtExit.Rows.Add(tempdr);
                        }
                    }
                }

                return outdtExit;
            }
        }


        #region 洗缸
        /// <summary>
        /// 初始化一个染色卡出来(模板/洗缸)
        /// </summary>
        /// <returns></returns>
        public static DataTable ColorCardWaterProcIniMB(int p_MainID)
        {
            string sql = "SELECT * FROM CC_MBColorCardDts WHERE MBColorCardID=" + p_MainID + " AND MBColorCardID<>0 ORDER BY Seq";
            DataTable outdt = SysUtils.Fill(sql);
            int seq = 0;
            if (outdt.Rows.Count == 0)//没有任何行，产生新模板
            {
                for (int i = 0; i < 1; i++)//ColorCardSectionDt.Rows.Count
                {
                    for (int j = 0; j < SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["WarterRowNum"]); j++)
                    {
                        seq++;
                        DataRow dr = outdt.NewRow();
                        dr["MBColorCardID"] = p_MainID;
                        dr["Seq"] = seq;
                        dr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(dr);
                    }
                }
                return outdt;
            }
            else//自动化添加行
            {
                CurRowNumIni();
                //ArrayList alRowID = new ArrayList();
                //ArrayList alRow = new ArrayList();
                for (int i = 0; i < outdt.Rows.Count; i++)//取出现存行
                {
                    //alRowID.Add(new int[] { SysConvert.ToInt32(outdt.Rows[i]["Seq"]), SysConvert.ToInt32(outdt.Rows[i]["ColorCardSectionID"]) });
                    //alRow.Add(outdt.Rows[i]);
                    CurRowNumUpd(SysConvert.ToInt32(outdt.Rows[i]["ColorCardSectionID"]));
                }
                int addseq = 100;
                for (int i = 0; i < 1; i++)//比对增加新行 ColorCardSectionDt.Rows.Count
                {
                    addseq++;
                    int maxRowNum = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["WarterRowNum"]);//设定最大行数
                    int curRowNum = CurRowNumGet(SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]));//当前最大行数

                    for (int m = curRowNum; m < maxRowNum; m++)//追加行
                    {
                        //alRowID.Add(new int[] { addseq, SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]) });
                        DataRow tempdr = outdt.NewRow();
                        tempdr["MBColorCardID"] = p_MainID;
                        tempdr["Seq"] = addseq;
                        tempdr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(tempdr);
                    }
                }

                DataTable outdtExit = SysUtils.Fill("SELECT * FROM CC_MBColorCardDts WHERE 1=0");

                for (int i = 0; i < 1; i++)//处理最终结果表 ColorCardSectionDt.Rows.Count
                {
                    foreach (DataRow dr in outdt.Rows)
                    {
                        if (SysConvert.ToInt32(dr["ColorCardSectionID"]) == SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]))
                        {
                            DataRow tempdr = outdtExit.NewRow();
                            for (int j = 0; j < outdtExit.Columns.Count; j++)
                            {
                                tempdr[j] = dr[j];
                            }
                            outdtExit.Rows.Add(tempdr);
                        }
                    }
                }

                return outdtExit;
            }
        }


        /// <summary>
        /// 初始化一个染色卡(洗缸单)
        /// </summary>
        /// <param name="p_MainID"></param>
        /// <returns></returns>
        public static DataTable ColorCardWaterProcIni(int p_MainID)
        {
            string[] o_Str;
            return ColorCardWaterProcIni(p_MainID, false, out o_Str);
        }

        /// <summary>
        /// 初始化一个染色卡出来(洗缸单)
        /// </summary>
        /// <returns></returns>
        public static DataTable ColorCardWaterProcIni(int p_MainID, bool p_NewFlag, out string[] o_Str)
        {
            o_Str = new string[] { "", "", "" };
            string sql = "SELECT * FROM CC_ColorCardDts WHERE ColorCardID=" + p_MainID + " AND ColorCardID<>0 ORDER BY Seq";
            DataTable outdt = SysUtils.Fill(sql);
            int seq = 0;
            if (outdt.Rows.Count == 0)//没有任何行，产生新模板
            {
                for (int i = 0; i < 1; i++)//ColorCardSectionDt.Rows.Count
                {
                    for (int j = 0; j < SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["WarterRowNum"]); j++)
                    {
                        seq++;
                        DataRow dr = outdt.NewRow();
                        dr["ColorCardID"] = p_MainID;
                        dr["Seq"] = seq;
                        dr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(dr);
                    }
                }
                return outdt;
            }
            else//自动化添加行
            {
                CurRowNumIni();
                for (int i = 0; i < outdt.Rows.Count; i++)//取出现存行
                {
                    CurRowNumUpd(SysConvert.ToInt32(outdt.Rows[i]["ColorCardSectionID"]));
                }
                int addseq = 100;
                for (int i = 0; i < 1; i++)//比对增加新行 ColorCardSectionDt.Rows.Count
                {
                    addseq++;
                    int maxRowNum = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["WarterRowNum"]);//设定最大行数
                    int curRowNum = CurRowNumGet(SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]));//当前最大行数

                    for (int m = curRowNum; m < maxRowNum; m++)//追加行
                    {
                        //alRowID.Add(new int[] { addseq, SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]) });
                        DataRow tempdr = outdt.NewRow();
                        tempdr["ColorCardID"] = p_MainID;
                        tempdr["Seq"] = addseq;
                        tempdr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(tempdr);
                    }
                }

                DataTable outdtExit = SysUtils.Fill("SELECT * FROM CC_ColorCardDts WHERE 1=0");

                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)//处理最终结果表
                {
                    foreach (DataRow dr in outdt.Rows)
                    {
                        if (SysConvert.ToInt32(dr["ColorCardSectionID"]) == SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]))
                        {
                            DataRow tempdr = outdtExit.NewRow();

                            for (int j = 0; j < outdtExit.Columns.Count; j++)
                            {
                                if (p_NewFlag)
                                {
                                    if (outdtExit.Columns[j].ColumnName.IndexOf("QtyAdd") == -1)
                                    {
                                        tempdr[j] = dr[j];
                                    }
                                }
                                else
                                {
                                    tempdr[j] = dr[j];
                                }
                            }
                            outdtExit.Rows.Add(tempdr);
                        }
                    }
                }

                sql = "SELECT TecCaption1,TecCaption2,TecCaption3 FROM CC_ColorCard WHERE ID=" + p_MainID;
                DataTable dttemp = SysUtils.Fill(sql);
                if (dttemp.Rows.Count != 0)
                {
                    o_Str[0] = dttemp.Rows[0]["TecCaption1"].ToString();
                    o_Str[1] = dttemp.Rows[0]["TecCaption2"].ToString();
                    o_Str[2] = dttemp.Rows[0]["TecCaption3"].ToString();
                }

                return outdtExit;
            }
        }



        /// <summary>
        /// 初始化一个染色卡出来(套用模板洗缸)
        /// </summary>
        /// <returns></returns>
        public static DataTable ColorCardWaterProcUseMB(int p_MainID, int p_CardID, out string[] o_Str)
        {
            o_Str = new string[] { "", "", "" };

            string sql = "SELECT * FROM CC_ColorCardDts WHERE 1=0";
            DataTable outdt = SysUtils.Fill(sql);
            DataTable mbdt = ColorCardWaterProcIniMB(p_MainID);
            foreach (DataRow dr in mbdt.Rows)
            {
                DataRow tempdr = outdt.NewRow();
                tempdr["ColorCardID"] = p_CardID;
                tempdr["Seq"] = dr["Seq"];// SysConvert.ToInt32(dr["Seq"]);
                tempdr["ColorCardSectionID"] = dr["ColorCardSectionID"];// SysConvert.ToInt32(dr["ColorCardSectionID"]);
                tempdr["ItemCode"] = dr["ItemCode"];//.ToString();
                tempdr["ItemName"] = dr["ItemName"];//.ToString();
                tempdr["Nongdu"] = dr["Nongdu"];// SysConvert.ToDecimal(dr["Nongdu"]);
                tempdr["NUnit"] = dr["Unit"];//.ToString();
                tempdr["Remark"] = dr["Remark"];//.ToString();
                tempdr["Times"] = dr["Times"];// SysConvert.ToDecimal(dr["Times"]);
                tempdr["Template"] = dr["Template"];// SysConvert.ToDecimal(dr["Template"]);
                outdt.Rows.Add(tempdr);
            }
            sql = "SELECT TecCaption1,TecCaption2,TecCaption3 FROM CC_MBColorCard WHERE ID=" + p_MainID;
            DataTable dttemp = SysUtils.Fill(sql);
            if (dttemp.Rows.Count != 0)
            {
                o_Str[0] = dttemp.Rows[0]["TecCaption1"].ToString();
                o_Str[1] = dttemp.Rows[0]["TecCaption2"].ToString();
                o_Str[2] = dttemp.Rows[0]["TecCaption3"].ToString();
            }

            return outdt;
        }
        #endregion

        /// <summary>
        /// 初始化一个染色卡
        /// </summary>
        /// <param name="p_MainID"></param>
        /// <returns></returns>
        public static DataTable ColorCardProcIni(int p_MainID)
        {
            string[] o_Str;
            return ColorCardProcIni(p_MainID, false,out o_Str);
        }

        /// <summary>
        /// 初始化一个染色卡出来(染色卡)
        /// </summary>
        /// <returns></returns>
        public static DataTable ColorCardProcIni(int p_MainID,bool p_NewFlag,out string[] o_Str)
        {
            o_Str = new string[] { "", "", "" };
            string sql = "SELECT * FROM CC_ColorCardDts WHERE ColorCardID=" + p_MainID + " AND ColorCardID<>0 ORDER BY Seq";
            DataTable outdt = SysUtils.Fill(sql);
            int seq = 0;
            if (outdt.Rows.Count == 0)//没有任何行，产生新模板
            {
                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)
                {
                    for (int j = 0; j < SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["RowNum"]); j++)
                    {
                        seq++;
                        DataRow dr = outdt.NewRow();
                        dr["ColorCardID"] = p_MainID;
                        dr["Seq"] = seq;
                        dr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(dr);
                    }
                }
                return outdt;
            }
            else//自动化添加行
            {
                CurRowNumIni();
                for (int i = 0; i < outdt.Rows.Count; i++)//取出现存行
                {
                    CurRowNumUpd(SysConvert.ToInt32(outdt.Rows[i]["ColorCardSectionID"]));
                }
                int addseq = 100;
                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)//比对增加新行
                {
                    addseq++;
                    int maxRowNum = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["RowNum"]);//设定最大行数
                    int curRowNum = CurRowNumGet(SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]));//当前最大行数

                    for (int m = curRowNum; m < maxRowNum; m++)//追加行
                    {
                        //alRowID.Add(new int[] { addseq, SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]) });
                        DataRow tempdr = outdt.NewRow();
                        tempdr["ColorCardID"] = p_MainID;
                        tempdr["Seq"] = addseq;
                        tempdr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(tempdr);
                    }
                }

                DataTable outdtExit = SysUtils.Fill("SELECT * FROM CC_ColorCardDts WHERE 1=0");

                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)//处理最终结果表
                {
                    foreach (DataRow dr in outdt.Rows)
                    {
                        if (SysConvert.ToInt32(dr["ColorCardSectionID"]) == SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]))
                        {
                            DataRow tempdr = outdtExit.NewRow();
                           
                            for (int j = 0; j < outdtExit.Columns.Count; j++)
                            {
                                if (p_NewFlag)
                                {
                                    if (outdtExit.Columns[j].ColumnName.IndexOf("QtyAdd") == -1)
                                    {
                                        tempdr[j] = dr[j];
                                    }
                                }
                                else
                                {
                                    tempdr[j] = dr[j];
                                }
                            }
                            outdtExit.Rows.Add(tempdr);
                        }
                    }
                }

                sql = "SELECT TecCaption1,TecCaption2,TecCaption3 FROM CC_ColorCard WHERE ID=" + p_MainID;
                DataTable dttemp = SysUtils.Fill(sql);
                if (dttemp.Rows.Count != 0)
                {
                    o_Str[0] = dttemp.Rows[0]["TecCaption1"].ToString();
                    o_Str[1] = dttemp.Rows[0]["TecCaption2"].ToString();
                    o_Str[2] = dttemp.Rows[0]["TecCaption3"].ToString();
                }

                return outdtExit;
            }
        }

        /// <summary>
        /// 初始化一个染色卡出来(套用模板)
        /// </summary>
        /// <returns></returns>
        public static DataTable ColorCardProcUseMB(int p_MainID, int p_CardID,out string[] o_Str)
        {
            o_Str = new string[] { "", "", "" };

            string sql = "SELECT * FROM CC_ColorCardDts WHERE 1=0";
            DataTable outdt = SysUtils.Fill(sql);
            DataTable mbdt = ColorCardProcIniMB(p_MainID);
            foreach (DataRow dr in mbdt.Rows)
            {
                DataRow tempdr = outdt.NewRow();
                tempdr["ColorCardID"] = p_CardID;
                tempdr["Seq"] = dr["Seq"];// SysConvert.ToInt32(dr["Seq"]);
                tempdr["ColorCardSectionID"] = dr["ColorCardSectionID"];// SysConvert.ToInt32(dr["ColorCardSectionID"]);
                tempdr["ItemCode"] = dr["ItemCode"];//.ToString();
                tempdr["ItemName"] = dr["ItemName"];//.ToString();
                tempdr["Nongdu"] = dr["Nongdu"];// SysConvert.ToDecimal(dr["Nongdu"]);
                tempdr["NUnit"] = dr["Unit"];//.ToString();
                tempdr["Remark"] = dr["Remark"];//.ToString();
                tempdr["Times"] = dr["Times"];// SysConvert.ToDecimal(dr["Times"]);
                tempdr["Template"] = dr["Template"];// SysConvert.ToDecimal(dr["Template"]);
                outdt.Rows.Add(tempdr);
            }
            sql = "SELECT TecCaption1,TecCaption2,TecCaption3 FROM CC_MBColorCard WHERE ID="+p_MainID;
            DataTable dttemp = SysUtils.Fill(sql);
            if (dttemp.Rows.Count != 0)
            {
                o_Str[0] = dttemp.Rows[0]["TecCaption1"].ToString();
                o_Str[1] = dttemp.Rows[0]["TecCaption2"].ToString();
                o_Str[2] = dttemp.Rows[0]["TecCaption3"].ToString();
            }

            return outdt;
        }

        /// <summary>
        /// 初始化一个染色卡出来(套用复样配方)
        /// </summary>
        /// <returns></returns>
        public static DataTable ColorCardProcUseRePF(int p_MainID, int p_CardID)
        {
            string sql = "SELECT * FROM CC_ColorCardDts WHERE 1=0";
            DataTable outdt = SysUtils.Fill(sql);
            DataTable mbdt = ColorCardProcIniRePF(p_MainID);
            foreach (DataRow dr in mbdt.Rows)
            {
                DataRow tempdr = outdt.NewRow();
                tempdr["ColorCardID"] = p_CardID;
                tempdr["Seq"] = dr["Seq"];// SysConvert.ToInt32(dr["Seq"]);
                tempdr["ColorCardSectionID"] = dr["ColorCardSectionID"];// SysConvert.ToInt32(dr["ColorCardSectionID"]);
                tempdr["ItemCode"] = dr["ItemCode"];//.ToString();
                tempdr["ItemName"] = dr["ItemName"];//.ToString();
                tempdr["Nongdu"] = dr["Nongdu"];// SysConvert.ToDecimal(dr["Nongdu"]);
                tempdr["NUnit"] = dr["Unit"];//.ToString();
                tempdr["Remark"] = dr["Remark"];//.ToString();
                tempdr["Times"] = dr["Times"];// SysConvert.ToDecimal(dr["Times"]);
                tempdr["Template"] = dr["Template"];// SysConvert.ToDecimal(dr["Template"]);
                outdt.Rows.Add(tempdr);
            }

            return outdt;
        }


        /// <summary>
        /// 初始化一个染色卡出来(染色卡)
        /// </summary>
        /// <returns></returns>
        public static DataTable ColorCardProcIni(int p_MainID, bool p_NewFlag)
        {
            string sql = "SELECT * FROM CC_ColorCardDts WHERE ColorCardID=" + p_MainID + " AND ColorCardID<>0 ORDER BY Seq";
            DataTable outdt = SysUtils.Fill(sql);
            int seq = 0;
            if (outdt.Rows.Count == 0)//没有任何行，产生新模板
            {
                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)
                {
                    for (int j = 0; j < SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["RowNum"]); j++)
                    {
                        seq++;
                        DataRow dr = outdt.NewRow();
                        dr["ColorCardID"] = p_MainID;
                        dr["Seq"] = seq;
                        dr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(dr);
                    }
                }
                return outdt;
            }
            else//自动化添加行
            {
                CurRowNumIni();
                for (int i = 0; i < outdt.Rows.Count; i++)//取出现存行
                {
                    CurRowNumUpd(SysConvert.ToInt32(outdt.Rows[i]["ColorCardSectionID"]));
                }
                int addseq = 100;
                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)//比对增加新行
                {
                    addseq++;
                    int maxRowNum = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["RowNum"]);//设定最大行数
                    int curRowNum = CurRowNumGet(SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]));//当前最大行数

                    for (int m = curRowNum; m < maxRowNum; m++)//追加行
                    {
                        //alRowID.Add(new int[] { addseq, SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]) });
                        DataRow tempdr = outdt.NewRow();
                        tempdr["ColorCardID"] = p_MainID;
                        tempdr["Seq"] = addseq;
                        tempdr["ColorCardSectionID"] = SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]);
                        outdt.Rows.Add(tempdr);
                    }
                }

                DataTable outdtExit = SysUtils.Fill("SELECT * FROM CC_ColorCardDts WHERE 1=0");

                for (int i = 0; i < ColorCardSectionDt.Rows.Count; i++)//处理最终结果表
                {
                    foreach (DataRow dr in outdt.Rows)
                    {
                        if (SysConvert.ToInt32(dr["ColorCardSectionID"]) == SysConvert.ToInt32(ColorCardSectionDt.Rows[i]["ID"]))
                        {
                            DataRow tempdr = outdtExit.NewRow();

                            for (int j = 0; j < outdtExit.Columns.Count; j++)
                            {
                                if (p_NewFlag)
                                {
                                    if (outdtExit.Columns[j].ColumnName.IndexOf("QtyAdd") == -1)
                                    {
                                        tempdr[j] = dr[j];
                                    }
                                }
                                else
                                {
                                    tempdr[j] = dr[j];
                                }
                            }
                            outdtExit.Rows.Add(tempdr);
                        }
                    }
                }

                return outdtExit;
            }
        }


        /// <summary>
        /// 初始化一个染色卡出来(套用模板)
        /// </summary>
        /// <returns></returns>
        public static DataTable ColorCardProcUseMB(int p_MainID, int p_CardID)
        {
            string sql = "SELECT * FROM CC_ColorCardDts WHERE 1=0";
            DataTable outdt = SysUtils.Fill(sql);
            DataTable mbdt = ColorCardProcIniMB(p_MainID);
            foreach (DataRow dr in mbdt.Rows)
            {
                DataRow tempdr = outdt.NewRow();
                tempdr["ColorCardID"] = p_CardID;
                tempdr["Seq"] = dr["Seq"];// SysConvert.ToInt32(dr["Seq"]);
                tempdr["ColorCardSectionID"] = dr["ColorCardSectionID"];// SysConvert.ToInt32(dr["ColorCardSectionID"]);
                tempdr["ItemCode"] = dr["ItemCode"];//.ToString();
                tempdr["ItemName"] = dr["ItemName"];//.ToString();
                tempdr["Nongdu"] = dr["Nongdu"];// SysConvert.ToDecimal(dr["Nongdu"]);
                tempdr["NUnit"] = dr["Unit"];//.ToString();
                tempdr["Remark"] = dr["Remark"];//.ToString();
                tempdr["Times"] = dr["Times"];// SysConvert.ToDecimal(dr["Times"]);
                tempdr["Template"] = dr["Template"];// SysConvert.ToDecimal(dr["Template"]);
                outdt.Rows.Add(tempdr);
            }

            return outdt;
        }

 
    }
}
