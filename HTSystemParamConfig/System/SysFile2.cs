using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using System.Net;
using System.Diagnostics;  
namespace HttSoft.HTERP.Sys
{
    /// <summary>
    /// �ļ�����Ĺ������
    /// </summary>    
    public sealed class SysFile2
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public SysFile2()
        {
        }
        /// <summary>
        /// ���ָ��·���ַ������ļ�������չ��
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }
        /// <summary>
        /// ���ָ��·���ַ�������չ��
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileExtension(string path)
        {
            return Path.GetExtension(path);
        }
        /// <summary>
        /// ����ļ��Ĵ�С(KB)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static double GetFileSize(string path)
        {
            FileInfo fi = new FileInfo(path);
            return fi.Length / 1024;
        }

        #region ����д�ļ�����
        /// <summary>
        /// ��ȡ�ļ��������ִ�
        /// </summary>
        /// <param name="fileName">�ļ���/����·��</param>
        /// <returns>�ļ�����</returns>
        public static string ReadFile(string fileName)
        {
            try
            {
                SysFile2.SetNormal(fileName);
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.Default);

                string file = sr.ReadToEnd();
                sr.Close();
                fs.Close();

                return file;
            }
            catch (Exception ex)
            {
                throw new Exception("��ȡ�ļ������쳣��[" + ex.Message + "]");
            }
        }

        /// <summary>
        /// д�ļ�
        /// </summary>
        public static void WriteFile(string fileName, string context)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                sw.Write(context);//д�ļ� 
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("�ļ�����д���쳣��[" + ex.Message + "]");
            }
        }
        #endregion

        /// <summary>
        /// ����ļ��Ƿ����
        /// </summary>
        /// <param name="file">�ļ���</param>
        /// <returns>��/�����</returns>
        public static bool Exists(string file)
        {
            FileInfo fi = new FileInfo(file);
            return fi.Exists;
        }

        /// <summary>
        /// �����ļ�����Ϊ��ͨ
        /// </summary>
        /// <param name="file">�ļ�ȫ·��+�ļ���</param>
        public static void SetNormal(string file)
        {
            File.SetAttributes(file, FileAttributes.Normal);
        }

        /// <summary>
        /// ����ļ����Ƿ����
        /// </summary>
        /// <param name="path">·��</param>
        /// <returns>��/�����</returns>
        public static bool DirectoryExists(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            return di.Exists;
        }
        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        /// <param name="path"></param>
        public static void CreateDirtory(string path)
        {
            if (!File.Exists(path))
            {
                string[] dirArray = path.Split('\\');
                string temp = string.Empty;
                for (int i = 0; i < dirArray.Length - 1; i++)
                {
                    temp += dirArray[i].Trim() + "\\";
                    if (!Directory.Exists(temp))
                    {
                        Directory.CreateDirectory(temp);
                    }
                }
            }
        }

        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <param name="path">·��</param>
        public static void DeleteFile(string path)
        {
            if (SysFile2.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// дFramework��־�ļ�
        /// </summary>
        public static void WriteLog(string logStr)
        {
            try
            {
                string logpath = SysConfig.LogFile;
                if (SysFile2.Exists(logpath))
                {
                    FileInfo fi = new FileInfo(logpath);
                    long mn = fi.Length;
                    if (mn > SysConfig.LogFileLength)//������ɾ���ļ�
                    {
                        fi.Delete();
                    }
                }
                StreamWriter sw = new StreamWriter(logpath, true, Encoding.Unicode);
                sw.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss") + "    " + logStr);
                sw.Close();
            }
            catch
            {

            }
        }

        /// <summary>
        /// ���ļ�ת���ɶ�����
        /// </summary>
        /// <returns></returns>
        public static byte[] FileToBinary(string fullName)
        {
            try
            {
                System.IO.FileStream stream = new System.IO.FileInfo(fullName).OpenRead();
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
                return buffer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// ��������ת�����ļ�
        /// </summary>
        /// <returns></returns>
        public static string BinaryToFile(byte[] context, string fullName)
        {
            System.IO.FileStream fStream = null;
            try
            {
                byte[] br = context;
                fStream = System.IO.File.Create(fullName, br.Length);
                fStream.Write(br, 0, br.Length);//������ת�����ļ�
            }
            catch
            {
                throw new Exception("�ļ�������д�����");
            }
            finally
            {
                fStream.Close();
            }
            return fullName;
        }
        /// <summary>
        /// ����������ת����Image
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Image BinaryToImage(byte[] context)
        {
            Image img = null;
            if (context.Length == 0)
            {
                return img;
            }
            else
            {
                ImageConverter imgCvt = new ImageConverter();

                object obj = imgCvt.ConvertFrom(context);
                img = (Image)obj;
                return img;
            }
        }
        /// <summary>
        /// ����ļ�������޸�ʱ��
        /// </summary>
        /// <param name="fullName">ȫ�ļ���</param>
        /// <returns>����ʱ��</returns>
        public static DateTime GetFileLastWriteTime(string fullName)
        {
            try
            {
                FileInfo file = new FileInfo(fullName);
                return file.LastWriteTime;
            }
            catch
            {
                return System.DateTime.Now;
            }
        }
        /// <summary>
        /// ����ļ��汾
        /// </summary>
        /// <param name="fullName">ȫ�ļ���</param>
        /// <returns></returns>
        public static string GetFileVersion(string fullName)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(fullName);
            return string.Format("{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
        }
        /// <summary>
        /// ָɾ���ļ�
        /// </summary>
        /// <param name="path">Ŀ¼</param>
        /// <param name="fileName">�ļ���</param>
        public static void BatchDeleteFiles(string path, string fileName)
        {
            if (DirectoryExists(path) == true)
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles(fileName);

                foreach (FileInfo file in files)
                {
                    file.Delete();
                }
            }
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="sourceFile">ȫ·��Դ�ļ�</param>
        /// <param name="targeFile">ȫ·��Ŀ���ļ�</param>
        public static void CopyFile(string sourceFile, string targeFile)
        {
            System.IO.File.Copy(sourceFile, targeFile, true);
        }
        /// <summary>
        /// ����Ŀ¼�µ������ļ�
        /// </summary>
        /// <param name="sourcePath">ԴĿ¼</param>
        /// <param name="targePath">Ŀ��Ŀ¼</param>
        public static void CopyFiles(string sourcePath, string targePath)
        {
            if (!Directory.Exists(targePath))
            {
                Directory.CreateDirectory(targePath);
            }
            string[] files = Directory.GetFiles(sourcePath);
            for (int i = 0; i < files.Length; i++)
            {
                string[] childfile = files[i].Split('\\');
                File.Copy(files[i], targePath + @"\" + childfile[childfile.Length - 1], true);
            }
            string[] dirs = Directory.GetDirectories(sourcePath);
            for (int i = 0; i < dirs.Length; i++)
            {
                string[] childdir = dirs[i].Split('\\');
                CopyFile(dirs[i], targePath + @"\" + childdir[childdir.Length - 1]);
            }
        }
        /// <summary>
        /// �ļ�����
        /// </summary>
        /// <param name="downUrl">���ص�ַ</param>
        /// <param name="downFile">Ҫ���ص��ļ�</param>
        /// <returns></returns>
        public static bool DownFile(string downUrl, string downFile)
        {
            long fileLength = 0;

            WebRequest webReq = WebRequest.Create(downUrl);
            WebResponse webRes = webReq.GetResponse();
            fileLength = webRes.ContentLength;
            try
            {
                Stream srm = webRes.GetResponseStream();
                StreamReader srmReader = new StreamReader(srm);
                byte[] bufferbyte = new byte[fileLength];
                int allByte = (int)bufferbyte.Length;
                int startByte = 0;
                while (fileLength > 0)
                {
                    int downByte = srm.Read(bufferbyte, startByte, allByte);
                    if (downByte == 0)
                    {
                        break;
                    }
                    startByte += downByte;
                    fileLength -= downByte;
                }
                SysFile2.CreateDirtory(downFile);
                FileStream fs = new FileStream(downFile, FileMode.Create, FileAccess.Write);
                fs.Write(bufferbyte, 0, startByte);
                srm.Close();
                srmReader.Close();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
