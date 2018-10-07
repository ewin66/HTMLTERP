using System;
using System.Collections.Generic;
using System.Text;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Data;
using System.IO;
using HttSoft.Framework;
using System.Data;

namespace MLTERP
{
    public static class ReadBoxISN
    {
        /// <summary>
        /// 读取条码版本A
        /// </summary>
        /// <returns></returns>
        public static List<string> ReadSCanISN()
        {
            ReadINIFile read = new ReadINIFile("ParamSet.ini");
            string defaultPath = "";// new ParamSetRule().RShowStr((int)ParamSet.扫描条码文件的默认路径);
            if (defaultPath == string.Empty)
            {
                defaultPath = @"D:\DATA.TXT";
            }
            string ScanPath = read.ReadString("ScanBarCode", "ScanPath", defaultPath); //默认路径
            List<string> lstTxt = new List<string>();
            if (SysFile.CheckFileExit(ScanPath))
            {
                using (StreamReader reader = new StreamReader(ScanPath))
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    string line = reader.ReadLine();
                    while (line != null)//判断第一行是否为空
                    {
                        string[] strArray = line.Split(',');
                        if (strArray.Length >= 2)
                        {
                            lstTxt.Add(strArray[1].Trim());
                        }
                        line = reader.ReadLine();//接收文本
                    }
                }
            }
            else
            {
                throw new Exception("扫描文件不存在:" + @ScanPath);
            }

            return lstTxt;
        }
    }
}