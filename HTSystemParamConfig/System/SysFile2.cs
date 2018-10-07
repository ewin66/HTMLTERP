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
    /// 文件处理的公共类库
    /// </summary>    
    public sealed class SysFile2
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public SysFile2()
        {
        }
        /// <summary>
        /// 获得指定路径字符串的文件名和扩展名
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }
        /// <summary>
        /// 获得指定路径字符串的扩展名
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileExtension(string path)
        {
            return Path.GetExtension(path);
        }
        /// <summary>
        /// 获得文件的大小(KB)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static double GetFileSize(string path)
        {
            FileInfo fi = new FileInfo(path);
            return fi.Length / 1024;
        }

        #region 读、写文件内容
        /// <summary>
        /// 读取文件内所有字串
        /// </summary>
        /// <param name="fileName">文件名/包括路径</param>
        /// <returns>文件内容</returns>
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
                throw new Exception("读取文件内容异常！[" + ex.Message + "]");
            }
        }

        /// <summary>
        /// 写文件
        /// </summary>
        public static void WriteFile(string fileName, string context)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                sw.Write(context);//写文件 
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("文件内容写入异常！[" + ex.Message + "]");
            }
        }
        #endregion

        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="file">文件名</param>
        /// <returns>是/否存在</returns>
        public static bool Exists(string file)
        {
            FileInfo fi = new FileInfo(file);
            return fi.Exists;
        }

        /// <summary>
        /// 设置文件属性为普通
        /// </summary>
        /// <param name="file">文件全路径+文件名</param>
        public static void SetNormal(string file)
        {
            File.SetAttributes(file, FileAttributes.Normal);
        }

        /// <summary>
        /// 检查文件夹是否存在
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>是/否存在</returns>
        public static bool DirectoryExists(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            return di.Exists;
        }
        /// <summary>
        /// 创建目录
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
        /// 删除文件
        /// </summary>
        /// <param name="path">路径</param>
        public static void DeleteFile(string path)
        {
            if (SysFile2.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 写Framework日志文件
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
                    if (mn > SysConfig.LogFileLength)//大于则删除文件
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
        /// 将文件转换成二进制
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
        /// 将二进制转换成文件
        /// </summary>
        /// <returns></returns>
        public static string BinaryToFile(byte[] context, string fullName)
        {
            System.IO.FileStream fStream = null;
            try
            {
                byte[] br = context;
                fStream = System.IO.File.Create(fullName, br.Length);
                fStream.Write(br, 0, br.Length);//二进制转换成文件
            }
            catch
            {
                throw new Exception("文件创建或写入出错！");
            }
            finally
            {
                fStream.Close();
            }
            return fullName;
        }
        /// <summary>
        /// 将二进制流转换成Image
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
        /// 获得文件的最后修改时间
        /// </summary>
        /// <param name="fullName">全文件名</param>
        /// <returns>日期时间</returns>
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
        /// 获得文件版本
        /// </summary>
        /// <param name="fullName">全文件名</param>
        /// <returns></returns>
        public static string GetFileVersion(string fullName)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(fullName);
            return string.Format("{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
        }
        /// <summary>
        /// 指删除文件
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="fileName">文件名</param>
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
        /// 拷贝文件
        /// </summary>
        /// <param name="sourceFile">全路径源文件</param>
        /// <param name="targeFile">全路径目标文件</param>
        public static void CopyFile(string sourceFile, string targeFile)
        {
            System.IO.File.Copy(sourceFile, targeFile, true);
        }
        /// <summary>
        /// 拷贝目录下的所有文件
        /// </summary>
        /// <param name="sourcePath">源目录</param>
        /// <param name="targePath">目标目录</param>
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
        /// 文件下载
        /// </summary>
        /// <param name="downUrl">下载地址</param>
        /// <param name="downFile">要下载的文件</param>
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
