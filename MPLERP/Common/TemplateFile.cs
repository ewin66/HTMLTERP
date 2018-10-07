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
using DevExpress.XtraGrid.Views.Base;
using System.IO;

namespace MLTERP
{
    /// <summary>
    /// 工艺文件类型
    /// </summary>
    public enum TecFlieType
    {
        前期EXCEL = 1,
        前期WORD = 2,
        前期PIC = 3,
        前期款式图二 = 4,
        样衣工艺尺寸图片 = 5,
        板房EXCEL = 6,
        抽检报告图 = 7,
        板房PIC = 8,
        制品检察图 = 9,
        辅料款式图 = 10,
        各色报告图 = 11,
        坯布指示书 = 12,
        大货平缝工艺 = 13,
        封样报告 = 14,

    }

    /// <summary>
    /// 文件处理
    /// </summary>
    public class TemplateFile
    {
        private static string FileRouteRead = Application.StartupPath + @"\TempFileRead\";//读取文件路径
        private static string FileRouteSave = Application.StartupPath + @"\TempFileSave\";//保存文件路径

        private static string FileSaveNameExcel = "xls";
        private static string FileSaveNameWord = "doc";
        private static string FileSaveNameHtml = "mht";


        #region 保存文件名称

        /// <summary>
        /// 获得保存文件名称
        /// </summary>
        /// <param name="p_FilePre">文件前缀</param>
        /// <returns>文件名称(含路径)</returns>
        private static string GetTempFileName(string p_FilePre, string p_FileExe)
        {
            string outstr = string.Empty;
            const int sindex = 10, eindex = 50, mindex = 31;//sindex=10,eindex=15,mindex=12;
            SysFile.CreateDDirectory(FileRouteSave);//没有找到则创建临时文件夹路径
            string FileName = string.Empty, DleteFileName = string.Empty;
            int i = 0;
            for (i = sindex; i <= eindex; i++)
            {
                FileName = FileRouteSave + p_FilePre + i.ToString() + "." + p_FileExe;
                if (!SysFile.CheckFileExit(FileName))//找到则跳出
                {
                    break;
                }
            }
            if (i == mindex)//如果到了中间线，删除中间线后面的文件
            {
                for (int j = mindex + 1; j <= eindex; j++)
                {
                    DleteFileName = FileRouteSave + p_FilePre + j.ToString() + "." + p_FileExe;
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            if (i == eindex)//如果到了末尾，删除中间线前面的文件
            {
                for (int j = sindex; j <= mindex; j++)
                {
                    DleteFileName = FileRouteSave + p_FilePre + j.ToString() + "." + p_FileExe;
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            outstr = FileName;
            return outstr;

        }

        /// <summary>
        /// 获得读取文件名称
        /// </summary>
        /// <param name="p_FilePre">文件前缀</param>
        /// <returns>文件名称(含路径)</returns>
        private static string GetReadFileName(string p_FilePre, string p_FileExe)
        {
            string outstr = string.Empty;
            const int sindex = 10, eindex = 50, mindex = 31;//sindex=10,eindex=15,mindex=12;
            SysFile.CreateDDirectory(FileRouteRead);//没有找到则创建临时文件夹路径
            string FileName = string.Empty, DleteFileName = string.Empty;
            int i = 0;
            for (i = sindex; i <= eindex; i++)
            {
                FileName = FileRouteRead + p_FilePre + i.ToString() + "." + p_FileExe;
                if (!SysFile.CheckFileExit(FileName))//找到则跳出
                {
                    break;
                }
            }
            if (i == mindex)//如果到了中间线，删除中间线后面的文件
            {
                for (int j = mindex + 1; j <= eindex; j++)
                {
                    DleteFileName = FileRouteRead + p_FilePre + j.ToString() + "." + p_FileExe;
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            if (i == eindex)//如果到了末尾，删除中间线前面的文件
            {
                for (int j = sindex; j <= mindex; j++)
                {
                    DleteFileName = FileRouteRead + p_FilePre + j.ToString() + "." + p_FileExe;
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            outstr = FileName;
            return outstr;

        }

        #endregion

        #region 保存文件
        /// <summary>
        /// 新增
        /// </summary>
        private int RAddFile(byte[] p_File, int tecID, string fileName, int fileType, string fileExec, string p_Remark)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess(SystemConfiguration.ConnectStringSecond, DBType.MSSQL);
                try
                {
                    sqlTrans.OpenTrans();

                    int outid = this.RAddFile(p_File, tecID, fileName, fileType, fileExec, p_Remark, sqlTrans);

                    sqlTrans.CommitTrans();

                    return outid;
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="sqlTrans">事务类</param>
        private int RAddFile(byte[] p_File, int tecID, string fileName, int fileType, string fileExec, string p_Remark, IDBTransAccess sqlTrans)
        {
            try
            {
                //int maxID = (int)EntityIDTable.GetID((long)SysEntity.Pro_TecFile, (int)DBSort.Second, sqlTrans);
                string sql = string.Empty;
                sql = "SELECT ISNULL(MAX(Seq),0)+1 MSeq FROM Pro_TecFile WHERE TecID=" + SysString.ToDBString(tecID);
                int maxSeq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0]);
                sql = "INSERT INTO Pro_TecFile(ID,TecID,Seq,Context,FileName,FileType,FileExec,Remark,UploadTime)";
                sql += "VALUES(" + 0 + "," + tecID + "," + maxSeq + ",@Context," + SysString.ToDBString(fileName) + ",'" + fileType + "','" + fileExec + "'," + SysString.ToDBString(p_Remark) + ",GetDate())";

                object[,] obja = new object[2, 1];
                obja[0, 0] = "@Context";
                obja[1, 0] = p_File;
                sqlTrans.ExecuteNonQuery(sql, obja);
                return 0;

            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }
        #endregion

        #region 修改文件
        /// <summary>
        /// 修改文件
        /// </summary>
        private void RUpdateFile(int id, byte[] p_File, int tecID, string fileName, int fileType, string fileExec, string p_Remark)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess(SystemConfiguration.ConnectStringSecond, DBType.MSSQL);
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdateFile(id, p_File, tecID, fileName, fileType, fileExec, p_Remark, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// 修改文件(传入事务处理)
        /// </summary>
        /// <param name="sqlTrans">事务类</param>
        private void RUpdateFile(int id, byte[] p_File, int tecID, string fileName, int fileType, string fileExec, string p_Remark, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "UPDATE Pro_TecFile SET Context=@Context,FileName=" + SysString.ToDBString(fileName) + ",FileType='" + fileType + "',FileExec='" + fileExec + "',Remark=" + SysString.ToDBString(p_Remark) + ",UploadTime=GetDate() ";
                sql += " WHERE ID=" + id;
                object[,] obja = new object[2, 1];
                obja[0, 0] = "@Context";
                obja[1, 0] = p_File;
                sqlTrans.ExecuteNonQuery(sql, obja);

            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }
        #endregion

        #region 保存读取文件
        /// <summary>
        /// 保存文件图片
        /// </summary>
        /// <param name="fileName">当前文件名</param>
        /// <param name="tecID">工艺单ID</param>
        /// <param name="p_ID">文件ID</param>
        public static int SaveFilePic(int tecID, int p_ID, int p_FileType, byte[] p_Pic, string p_Remark)
        {
            int fileID = 0;
            TemplateFile tf = new TemplateFile();

            if (p_ID == 0)//没有新增
            {
                fileID = tf.RAddFile(p_Pic, tecID, "a.jpg", p_FileType, "jpg", p_Remark);
            }
            else//存在这更新
            {
                tf.RUpdateFile(p_ID, p_Pic, tecID, "a.jpg", p_FileType, "jpg", p_Remark);
                fileID = p_ID;
            }
            return fileID;
        }

        /// <summary>
        /// 保存文件图片
        /// </summary>
        /// <param name="fileName">当前文件名</param>
        /// <param name="tecID">工艺单ID</param>
        /// <param name="p_ID">文件ID</param>
        public static int SaveFilePic(int tecID, int p_ID, int p_FileType, byte[] p_Pic, string p_Remark, string Name, string TypeName)
        {
            int fileID = 0;
            TemplateFile tf = new TemplateFile();

            if (p_ID == 0)//没有新增
            {
                fileID = tf.RAddFile(p_Pic, tecID, Name, p_FileType, TypeName, p_Remark);
            }
            else//存在这更新
            {
                tf.RUpdateFile(p_ID, p_Pic, tecID, Name, p_FileType, TypeName, p_Remark);
                fileID = p_ID;
            }
            return fileID;
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="tecID"></param>
        /// <param name="p_FileType"></param>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public static int SaveFileExcel(string fileName, int tecID, int p_FileType, int p_ID)
        {
            return SaveFileExcel(fileName, tecID, p_FileType, p_ID, "");
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fileName">当前文件名</param>
        /// <param name="tecID">工艺单ID</param>
        /// <param name="p_ID">文件ID</param>
        public static int SaveFileExcel(string fileName, int tecID, int p_FileType, int p_ID, string p_Remark)
        {
            int outint = 0;
            TemplateFile tf = new TemplateFile();

            string tempFileName = GetTempFileName(FileSaveNameExcel, FileSaveNameExcel);
            if (System.IO.File.Exists(tempFileName))
            {
                System.IO.File.Delete(tempFileName);
            }

            System.IO.File.Copy(fileName, tempFileName);

            if (p_ID == 0)//没有新增
            {
                outint = tf.RAddFile(System.IO.File.ReadAllBytes(tempFileName), tecID, System.IO.Path.GetFileName(fileName), p_FileType, System.IO.Path.GetExtension(fileName), p_Remark);
            }
            else//存在这更新
            {
                tf.RUpdateFile(p_ID, System.IO.File.ReadAllBytes(tempFileName), tecID, System.IO.Path.GetFileName(fileName), p_FileType, System.IO.Path.GetExtension(fileName), p_Remark);
                outint = p_ID;
            }
            return outint;
        }


        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fileName">当前文件名</param>
        /// <param name="tecID">工艺单ID</param>
        /// <param name="p_ID">文件ID</param>
        public static int SaveFileWord(string fileName, int tecID, int p_ID, int p_FileType)
        {
            int outint = 0;
            TemplateFile tf = new TemplateFile();

            string tempFileName = GetTempFileName(FileSaveNameWord, FileSaveNameWord);
            if (System.IO.File.Exists(tempFileName))
            {
                System.IO.File.Delete(tempFileName);
            }

            System.IO.File.Copy(fileName, tempFileName);

            if (p_ID == 0)//没有新增
            {
                outint = tf.RAddFile(System.IO.File.ReadAllBytes(tempFileName), tecID, System.IO.Path.GetFileName(fileName), p_FileType, System.IO.Path.GetExtension(fileName), "");
            }
            else//存在这更新
            {
                tf.RUpdateFile(p_ID, System.IO.File.ReadAllBytes(tempFileName), tecID, System.IO.Path.GetFileName(fileName), p_FileType, System.IO.Path.GetExtension(fileName), "");
                outint = p_ID;
            }
            return outint;
        }

        /// <summary>
        /// 读取EXCEL
        /// </summary>
        /// <param name="p_TecID"></param>
        /// <param name="p_FileType"></param>
        /// <param name="o_FileID"></param>
        /// <param name="p_FileName"></param>
        public static void ReadFileExcel(int p_TecID, int p_FileType, out int o_FileID, out string p_FileName)
        {
            string p_Remark = string.Empty;
            ReadFileExcel(p_TecID, p_FileType, out o_FileID, out p_FileName, out p_Remark);
        }

        public static void ReadFileExcel(int p_TecID, int p_FileType, int o_FileID, out string p_FileName)
        {
            string p_Remark = string.Empty;
            ReadFileExcel(p_TecID, p_FileType, o_FileID, out p_FileName, out p_Remark);
        }


        /// <summary>
        /// 读取文件Excel
        /// </summary>
        /// <param name="p_TecID">工艺单ID</param>
        /// <param name="o_FileID">返回文件ID</param>
        /// <param name="p_FileName">文件名称</param>
        public static void ReadFileExcel(int p_TecID, int p_FileType, out int o_FileID, out string p_FileName, out string p_Remark)
        {
            byte[] o_File;
            p_FileName = string.Empty;
            ReadFile(p_TecID, p_FileType, out o_FileID, out o_File, out p_Remark);
            if (o_FileID != 0)
            {
                SysFile.CreateDDirectory(FileRouteRead);//没有找到则创建临时文件夹路径
                p_FileName = GetReadFileName(FileSaveNameExcel, FileSaveNameExcel);

                System.IO.File.WriteAllBytes(p_FileName, o_File);
            }
        }

        public static void ReadFileExcel(int p_TecID, int p_FileType, int o_FileID, out string p_FileName, out string p_Remark)
        {
            byte[] o_File;
            p_FileName = string.Empty;
            ReadFile(p_TecID, p_FileType, o_FileID, out o_File, out p_Remark);
            if (o_FileID != 0)
            {
                SysFile.CreateDDirectory(FileRouteRead);//没有找到则创建临时文件夹路径
                p_FileName = GetReadFileName(FileSaveNameExcel, FileSaveNameExcel);

                System.IO.File.WriteAllBytes(p_FileName, o_File);
            }
        }


        /// <summary>
        /// 读取文件Word
        /// </summary>
        /// <param name="p_TecID">工艺单ID</param>
        /// <param name="o_FileID">返回文件ID</param>
        /// <param name="p_FileName">文件名称</param>
        public static void ReadFileWord(int p_TecID, int p_FileType, out int o_FileID, out string p_FileName)
        {
            byte[] o_File;
            p_FileName = string.Empty; ;
            ReadFile(p_TecID, p_FileType, out o_FileID, out o_File);
            if (o_FileID != 0)
            {
                SysFile.CreateDDirectory(FileRouteRead);//没有找到则创建临时文件夹路径
                p_FileName = GetReadFileName(FileSaveNameWord, FileSaveNameWord);
                System.IO.File.WriteAllBytes(p_FileName, o_File);
            }
        }

        public static void ReadFile(int p_TecID, int fileType, out int o_FileID, out byte[] o_File)
        {
            string p_Remark = string.Empty;
            ReadFile(p_TecID, fileType, out o_FileID, out o_File, out p_Remark);
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="p_TecID"></param>
        /// <param name="fileType"></param>
        /// <param name="o_FileID"></param>
        /// <param name="o_File"></param>
        public static void ReadFile(int p_TecID, int fileType, out int o_FileID, out byte[] o_File, out string p_Remark)
        {
            o_FileID = 0;
            p_Remark = string.Empty;
            o_File = new byte[0];
            string sql = "SELECT ID,Context,Remark FROM Pro_TecFile WHERE TecID=" + SysString.ToDBString(p_TecID) + " AND FileType=" + fileType;
            //string sql = "SELECT ID,Context,Remark FROM Pro_TecFile WHERE  ID=" + SysString.ToDBString(o_FileID);
            DataTable dt = SysUtilsSecond.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                o_FileID = SysConvert.ToInt32(dt.Rows[0][0]);
                o_File = (byte[])dt.Rows[0][1];
                p_Remark = dt.Rows[0][2].ToString();
            }
        }

        public static void ReadFile(int p_TecID, int fileType, int o_FileID, out byte[] o_File, out string p_Remark)
        {
            p_Remark = string.Empty;
            o_File = new byte[0];
            //string sql = "SELECT ID,Context,Remark FROM Pro_TecFile WHERE TecID=" + SysString.ToDBString(p_TecID) + " AND FileType=" + fileType;
            string sql = "SELECT ID,Context,Remark FROM Pro_TecFile WHERE  ID=" + SysString.ToDBString(o_FileID);
            DataTable dt = SysUtilsSecond.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                o_FileID = SysConvert.ToInt32(dt.Rows[0][0]);
                o_File = (byte[])dt.Rows[0][1];
                p_Remark = dt.Rows[0][2].ToString();
            }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="p_TecID"></param>
        /// <param name="fileType"></param>
        /// <param name="o_FileID"></param>
        /// <param name="o_File"></param>
        public static int ReadFileID(int p_TecID, int fileType)
        {
            int o_FileID = 0;
            string sql = "SELECT ID FROM Pro_TecFile WHERE TecID=" + SysString.ToDBString(p_TecID) + " AND FileType=" + fileType;
            DataTable dt = SysUtilsSecond.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                o_FileID = SysConvert.ToInt32(dt.Rows[0][0]);
            }
            return o_FileID;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="p_TecID"></param>
        /// <param name="fileType"></param>
        /// <param name="o_FileID"></param>
        /// <param name="o_File"></param>
        public static void ReadFile(int p_TecID, int fileType, out int o_FileID, out byte[] o_File, out string p_Remark, out string p_FileName, out string p_FileExec)
        {
            o_FileID = 0;
            p_Remark = string.Empty;
            o_File = new byte[0];
            p_FileName = string.Empty;
            p_FileExec = string.Empty;
            string sql = "SELECT ID,Context,Remark,FileName,FileExec FROM Pro_TecFile WHERE TecID=" + SysString.ToDBString(p_TecID) + " AND FileType=" + fileType;
            //string sql = "SELECT ID,Context,Remark FROM Pro_TecFile WHERE  ID=" + SysString.ToDBString(o_FileID);
            DataTable dt = SysUtilsSecond.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                o_FileID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                o_File = (byte[])dt.Rows[0]["Context"];
                p_Remark = dt.Rows[0]["Remark"].ToString();
                p_FileName = dt.Rows[0]["FileName"].ToString();
                p_FileExec = dt.Rows[0]["FileExec"].ToString();
            }
        }

        /// <summary>
        /// 读取文件扩展名
        /// </summary>
        /// <param name="p_FileID">文件Exec</param>
        public static string ReadFileExec(int p_FileID)
        {
            string outstr = string.Empty;
            string sql = "SELECT FileExec FROM Pro_TecFile WHERE ID=" + SysString.ToDBString(p_FileID);
            DataTable dt = SysUtilsSecond.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = dt.Rows[0][0].ToString();
                outstr = outstr.Replace(".", "");
            }
            return outstr;
        }



        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="p_FileID">文件ID</param>
        /// <param name="o_File">文件内容</param>
        public static byte[] ReadFileContext(int p_FileID)
        {
            byte[] o_File = new byte[0];
            string sql = "SELECT Context FROM Pro_TecFile WHERE ID=" + SysString.ToDBString(p_FileID);
            DataTable dt = SysUtilsSecond.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                o_File = (byte[])dt.Rows[0][0];
            }
            return o_File;
        }


        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="p_FileID">文件ID</param>
        /// <param name="o_File">文件内容</param>
        public static string ReadFileRemark(int p_FileID)
        {
            string Remark = string.Empty;
            string sql = "SELECT Remark FROM Pro_TecFile WHERE ID=" + SysString.ToDBString(p_FileID);
            DataTable dt = SysUtilsSecond.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                Remark = dt.Rows[0][0].ToString();
            }
            return Remark;
        }

        /// <summary>
        /// 读取文件名称
        /// </summary>
        /// <param name="p_FileID">文件ID</param>
        /// <param name="o_File">文件内容</param>
        public static string ReadFileName(int p_FileID)
        {
            string FileName = string.Empty;
            string sql = "SELECT FileName FROM Pro_TecFile WHERE ID=" + SysString.ToDBString(p_FileID);
            DataTable dt = SysUtilsSecond.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                FileName = dt.Rows[0][0].ToString();
            }
            return FileName;
        }

        /// <summary>
        /// 读取文件名称
        /// </summary>
        /// <param name="p_FileID">文件ID</param>
        /// <param name="o_File">文件内容</param>
        public static string ReadFileExecTwo(int p_FileID)
        {
            string FileExec = string.Empty;
            string sql = "SELECT FileExec FROM Pro_TecFile WHERE ID=" + SysString.ToDBString(p_FileID);
            DataTable dt = SysUtilsSecond.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                FileExec = dt.Rows[0][0].ToString();
            }
            return FileExec;

        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="o_FileID">文件ID</param>
        public static void DeleteFile(int o_FileID)
        {
            string sql = "DELETE FROM Pro_TecFile WHERE ID=" + o_FileID;
            SysUtilsSecond.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 获得空EXCEL文件
        /// </summary>
        /// <param name="o_FileID">文件ID</param>
        public static string GetBankExcel()
        {
            return FileRouteRead + "0.xls";
        }
        #endregion

        #region 获得临时文件EXCEL转WORD

        public static void GetExcelTempFileName(out string p_TempExcelName, out string p_HtmlName)
        {
            p_TempExcelName = GetReadFileName(FileSaveNameExcel, FileSaveNameExcel);
            p_HtmlName = GetReadFileName(FileSaveNameHtml, FileSaveNameHtml);
        }
        #endregion

        #region 新的（周富春）

        public static void ReadFile(string p_TecID, int fileType, out int o_FileID, out byte[] o_File)
        {
            string p_Remark = string.Empty;
            ReadFile(p_TecID, fileType, out o_FileID, out o_File, out p_Remark);
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="p_TecID"></param>
        /// <param name="fileType"></param>
        /// <param name="o_FileID"></param>
        /// <param name="o_File"></param>
        public static void ReadFile(string p_TecID, int fileType, out int o_FileID, out byte[] o_File, out string p_Remark)
        {
            o_FileID = 0;
            p_Remark = string.Empty;
            o_File = new byte[0];
            string sql = "SELECT ID,Context,Remark FROM Data_ItemPicture WHERE ItemCode=" + SysString.ToDBString(p_TecID) + " AND FileType=" + fileType;
            DataTable dt = SysUtilsSecond.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                o_FileID = SysConvert.ToInt32(dt.Rows[0][0]);
                o_File = (byte[])dt.Rows[0][1];
                p_Remark = dt.Rows[0][2].ToString();
            }
        }


        #region 保存文件
        /// <summary>
        /// 新增
        /// </summary>
        private int RAddFile(byte[] p_File, string tecID, string fileName, int fileType, string fileExec, string p_Remark)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess(SystemConfiguration.ConnectStringSecond, DBType.MSSQL);
                try
                {
                    sqlTrans.OpenTrans();

                    int outid = this.RAddFile(p_File, tecID, fileName, fileType, fileExec, p_Remark, sqlTrans);

                    sqlTrans.CommitTrans();

                    return outid;
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="sqlTrans">事务类</param>
        private int RAddFile(byte[] p_File, string tecID, string fileName, int fileType, string fileExec, string p_Remark, IDBTransAccess sqlTrans)
        {
            try
            {
                int maxID = (int)EntityIDTable.GetID(10, sqlTrans);
                string sql = string.Empty;
                sql = "SELECT ISNULL(MAX(Seq),0)+1 MSeq FROM Data_ItemPicture WHERE ItemCode=" + SysString.ToDBString(tecID);
                int maxSeq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0]);
                sql = "INSERT INTO Data_ItemPicture(ID,ItemCode,Seq,Context,FileName,FileType,FileExec,Remark,UploadTime)";
                sql += "VALUES(" + maxID + "," + SysString.ToDBString(tecID) + "," + maxSeq + ",@Context," + SysString.ToDBString(fileName) + ",'" + fileType + "','" + fileExec + "'," + SysString.ToDBString(p_Remark) + ",GetDate())";

                object[,] obja = new object[2, 1];
                obja[0, 0] = "@Context";
                obja[1, 0] = p_File;
                sqlTrans.ExecuteNonQuery(sql, obja);
                return maxID;

            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }
        #endregion

        #region 修改文件
        /// <summary>
        /// 修改文件
        /// </summary>
        private void RUpdateFile(int id, byte[] p_File, string tecID, string fileName, int fileType, string fileExec, string p_Remark)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess(SystemConfiguration.ConnectStringSecond, DBType.MSSQL);
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdateFile(id, p_File, tecID, fileName, fileType, fileExec, p_Remark, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// 修改文件(传入事务处理)
        /// </summary>
        /// <param name="sqlTrans">事务类</param>
        private void RUpdateFile(int id, byte[] p_File, string tecID, string fileName, int fileType, string fileExec, string p_Remark, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "UPDATE Data_ItemPicture SET Context=@Context,FileName=" + SysString.ToDBString(fileName) + ",FileType='" + fileType + "',FileExec='" + fileExec + "',Remark=" + SysString.ToDBString(p_Remark) + ",UploadTime=GetDate() ";
                sql += " WHERE ID=" + id;
                object[,] obja = new object[2, 1];
                obja[0, 0] = "@Context";
                obja[1, 0] = p_File;
                sqlTrans.ExecuteNonQuery(sql, obja);

            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }
        #endregion
        #region 保存读取文件
        /// <summary>
        /// 保存文件图片
        /// </summary>
        /// <param name="fileName">当前文件名</param>
        /// <param name="tecID">工艺单ID</param>
        /// <param name="p_ID">文件ID</param>
        public static int SaveFilePic(string tecID, int p_ID, int p_FileType, byte[] p_Pic)
        {
            int fileID = 0;
            TemplateFile tf = new TemplateFile();

            if (p_ID == 0)//没有新增
            {
                fileID = tf.RAddFile(p_Pic, tecID, "a.jpg", p_FileType, "jpg", "");
            }
            else//存在这更新
            {
                tf.RUpdateFile(p_ID, p_Pic, tecID, "a.jpg", p_FileType, "jpg", "");
                fileID = p_ID;
            }
            return fileID;
        }
        #endregion
        #endregion

        #region  文件处理

        #region 保存文件
        /// <summary>
        /// 新增
        /// </summary>
        public int RAdd(byte[] p_File, int tecID, string fileName, int fileType, string fileExec, string p_Remark, decimal fileSize, string LoginID, string LoginName)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess(SystemConfiguration.ConnectStringSecond);
                try
                {
                    sqlTrans.OpenTrans();

                    int outid  = RAdd(p_File, tecID, fileName, fileType, fileExec, p_Remark, fileSize, LoginID, LoginName, sqlTrans);

                    sqlTrans.CommitTrans();

                    return outid;
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="sqlTrans">事务类</param>
        public int RAdd(byte[] p_File, int tecID, string fileName, int fileType, string fileExec, string p_Remark, decimal fileSize, string LoginID, string LoginName, IDBTransAccess sqlTrans)
        {
            try
            {
                //int maxID = (int)EntityIDTable.GetID((long)SysEntity.Pro_TecFile, (int)DBSort.Second, sqlTrans);
                string sql = string.Empty;
                sql = "SELECT ISNULL(MAX(Seq),0)+1 MSeq FROM Pro_TecFile WHERE TecID=" + SysString.ToDBString(tecID);
                int maxSeq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0]);
                sql = "INSERT INTO Pro_TecFile(ID,TecID,Seq,Context,FileName,FileType,FileExec,Remark,UploadTime,fileSize,UploadOPID,UploadOPName)";
                sql += "VALUES(" + 0 + "," + tecID + "," + maxSeq + ",@Context," + SysString.ToDBString(fileName) + ",'" + fileType + "','" + fileExec + "'," + SysString.ToDBString(p_Remark) + ",GetDate(),";
                sql += fileSize + "," + SysString.ToDBString(LoginID) + "," + SysString.ToDBString(LoginName) + ")";

                object[,] obja = new object[2, 1];
                obja[0, 0] = "@Context";
                obja[1, 0] = p_File;
                sqlTrans.ExecuteNonQuery(sql, obja);
                return 0;

            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        #endregion

        #region 修改文件
        /// <summary>
        /// 修改文件
        /// </summary>
        public void RUpdate(int id, byte[] p_File, string fileName, string fileExec, string p_Remark, decimal fileSize, string LoginID, string LoginName)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess(SystemConfiguration.ConnectStringSecond, DBType.MSSQL);
                try
                {
                    sqlTrans.OpenTrans();

                    RUpdate(id, p_File, fileName, fileExec, p_Remark, fileSize, LoginID, LoginName, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// 修改文件(传入事务处理)
        /// </summary>
        /// <param name="sqlTrans">事务类</param>
        public void RUpdate(int id, byte[] p_File, string fileName, string fileExec, string p_Remark, decimal fileSize, string LoginID, string LoginName, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "UPDATE Pro_TecFile SET Context=@Context,FileName=" + SysString.ToDBString(fileName)  + ",FileExec='" + fileExec + "',Remark=" + SysString.ToDBString(p_Remark) + ",UploadTime=GetDate(), ";
                sql += "fileSize=" + fileSize+",";
                sql += "UploadOPID=" + SysString.ToDBString(LoginID) + ",";
                sql += "UploadOPName=" + SysString.ToDBString(LoginName);
                sql += " WHERE ID=" + id;
                object[,] obja = new object[2, 1];
                obja[0, 0] = "@Context";
                obja[1, 0] = p_File;
                sqlTrans.ExecuteNonQuery(sql, obja);

            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        #endregion

        #region 显示

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShow(string p_condition)
        {
            try
            {
                return RShow(p_condition, "*");
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShow(string p_condition, string p_FieldName)
        {

            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess(SystemConfiguration.ConnectStringSecond);
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM Pro_TecFile WHERE 1=1";
                sql += p_condition;
                return sqlTrans.Fill(sql);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        #endregion

        //所给路径中所对应的是否为文件

        public static long FileSize(string filePath)
        {
            long temp = 0;

            //判断当前路径所指向的是否为文件
            if (File.Exists(filePath) == false)
            {
                string[] str1 = Directory.GetFileSystemEntries(filePath);
                foreach (string s1 in str1)
                {
                    temp += FileSize(s1);
                }
            }
            else
            {

                //定义一个FileInfo对象,使之与filePath所指向的文件向关联,

                //以获取其大小
                FileInfo fileInfo = new FileInfo(filePath);
                return fileInfo.Length;
            }
            return temp;
        }

        #endregion

    }


}
