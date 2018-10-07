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
        /// ��ȡ����汾A
        /// </summary>
        /// <returns></returns>
        public static List<string> ReadSCanISN()
        {
            ReadINIFile read = new ReadINIFile("ParamSet.ini");
            string defaultPath = "";// new ParamSetRule().RShowStr((int)ParamSet.ɨ�������ļ���Ĭ��·��);
            if (defaultPath == string.Empty)
            {
                defaultPath = @"D:\DATA.TXT";
            }
            string ScanPath = read.ReadString("ScanBarCode", "ScanPath", defaultPath); //Ĭ��·��
            List<string> lstTxt = new List<string>();
            if (SysFile.CheckFileExit(ScanPath))
            {
                using (StreamReader reader = new StreamReader(ScanPath))
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    string line = reader.ReadLine();
                    while (line != null)//�жϵ�һ���Ƿ�Ϊ��
                    {
                        string[] strArray = line.Split(',');
                        if (strArray.Length >= 2)
                        {
                            lstTxt.Add(strArray[1].Trim());
                        }
                        line = reader.ReadLine();//�����ı�
                    }
                }
            }
            else
            {
                throw new Exception("ɨ���ļ�������:" + @ScanPath);
            }

            return lstTxt;
        }
    }
}