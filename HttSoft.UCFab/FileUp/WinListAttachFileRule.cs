using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;


namespace HttSoft.UCFab
{
	/// <summary>
	/// 目的：Data_WinListAttachFile实体业务规则类
	/// 作者:陈加海
	/// 创建日期:2014/4/23
	/// </summary>
	public class WinListAttachFileRule
	{
	    /// <summary>
        /// 构造函数
        /// </summary>
		public WinListAttachFileRule()
		{
		}
		
		/// <summary>
		/// 检查将要操作的数据是否符合业务规则
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			WinListAttachFile entity=(WinListAttachFile)p_BE;
        }


        #region 自定义方法
        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="p_FileID">文件ID</param>
        /// <param name="o_File">文件内容</param>
        public static byte[] ReadFileContext(int p_FileID)
        {
            byte[] o_File = new byte[0];
            string sql = "SELECT FileContext FROM Data_WinListAttachFile WHERE ID=" + SysString.ToDBString(p_FileID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                o_File = (byte[])dt.Rows[0][0];
            }
            return o_File;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="o_FileID">文件ID</param>
        public static void DeleteFile(int o_FileID)
        {
            string sql = "DELETE FROM Data_WinListAttachFile WHERE ID=" + o_FileID;
            SysUtils.ExecuteNonQuery(sql);
        }



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
            catch (Exception E)
            {
                throw E;
                //return null;
            }
        }

        #endregion

        #region 数据保存
        #region 保存文件
        /// <summary>
        /// 新增
        /// </summary>
        public int RAdd(byte[] p_File, int winListID, int headtype, int subtype, int dataid, int dataSeq, string fileName, string filetitle, string fileExec, string p_Remark, string p_FileProt1, string p_FileProt2, decimal fileSize, string LoginID, string LoginName, int loginLogID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess(SystemConfiguration.ConnectionString);
                try
                {
                    sqlTrans.OpenTrans();

                    int outid = RAdd(p_File, winListID, headtype, subtype, dataid, dataSeq, fileName, filetitle, fileExec, p_Remark, p_FileProt1, p_FileProt2, fileSize, LoginID, LoginName, loginLogID, sqlTrans);

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
        public int RAdd(byte[] p_File, int winListID, int headtype, int subtype, int dataid, int dataSeq, string fileName, string filetitle, string fileExec, string p_Remark, string p_FileProt1, string p_FileProt2, decimal fileSize, string LoginID, string LoginName, int loginLogID, IDBTransAccess sqlTrans)
        {
            try
            {
                int sysEntityID= UCFileUPParamSet.GetIntValueByID(7201);//获得文件管理实体ID
                if (sysEntityID == 0)
                {
                    sysEntityID = 45;//默认是45
                }
                int maxID = (int)EntityIDTable.GetID(sysEntityID, (int)DBSort.Default, sqlTrans);
                string sql = string.Empty;
                //sql = "SELECT ISNULL(MAX(Seq),0)+1 MSeq FROM Pro_TecFile WHERE TecID=" + SysString.ToDBString(tecID);
                //int maxSeq = 0;// SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0]);
                sql = "INSERT INTO Data_WinListAttachFile(ID,WinListID,HeadType,SubType,HTDataID,HTDataSeq,FileName,FileContext,FileSize";
                sql += ",UploadTime,UploadOPID,UploadOPName,UploadLoginLogID,FileExe,Remark,FileProt1,FileProt2)";
                sql += "VALUES(" + maxID + "," + winListID + "," + headtype + "," + subtype + "," + dataid + "," + dataSeq + "," + SysString.ToDBString(fileName) + ",@Context," + SysString.ToDBString(fileSize);
                sql += ",GetDate()," + SysString.ToDBString(LoginID) + "," + SysString.ToDBString(LoginName) + "," + SysString.ToDBString(loginLogID);
                sql += "," + SysString.ToDBString(fileExec) + "," + SysString.ToDBString(p_Remark) + "," + SysString.ToDBString(p_FileProt1) + "," + SysString.ToDBString(p_FileProt2);
                sql += ")";

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
        #endregion

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
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM Data_WinListAttachFile WHERE 1=1";
                sql += p_condition;
                return SysUtils.Fill(sql);
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
		/// 新增
		/// </summary>
		/// <param name="p_BE">要新增的实体</param>
		public void RAdd(BaseEntity p_BE)
		{
			try
			{
			    IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();				
				try
				{
					sqlTrans.OpenTrans();
					
					this.RAdd(p_BE,sqlTrans);
			
			        sqlTrans.CommitTrans();
				}
				catch(Exception TE)
				{					
					sqlTrans.RollbackTrans();
					throw TE;
				}
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// 新增(传入事务处理)
		/// </summary>
		/// <param name="p_BE">要新增的实体</param>
		/// <param name="sqlTrans">事务类</param>
		public void RAdd(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
			try
			{
				this.CheckCorrect(p_BE);
				WinListAttachFile entity=(WinListAttachFile)p_BE;				
				WinListAttachFileCtl control=new WinListAttachFileCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID(45,sqlTrans);
				control.AddNew(entity);
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="p_BE">要修改的实体</param>
		public void RUpdate(BaseEntity p_BE)
		{
			try
			{
				IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();				
				try
				{
					sqlTrans.OpenTrans();
					
					this.RUpdate(p_BE,sqlTrans);
					
					sqlTrans.CommitTrans();
				}
				catch(Exception TE)
				{					
					sqlTrans.RollbackTrans();
					throw TE;
				}				
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="p_BE">要修改的实体</param>
		/// <param name="sqlTrans">事务类</param>
		public void RUpdate(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
			try
			{
				this.CheckCorrect(p_BE);
				WinListAttachFile entity=(WinListAttachFile)p_BE;				
				WinListAttachFileCtl control=new WinListAttachFileCtl(sqlTrans);				
				control.Update(entity);
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="p_BE">要删除的实体</param>
		public void RDelete(BaseEntity p_BE)
		{
			try
			{
				IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();				
				try
				{
					sqlTrans.OpenTrans();
					
					this.RDelete(p_BE,sqlTrans);
					
					sqlTrans.CommitTrans();
				}
				catch(Exception TE)
				{					
					sqlTrans.RollbackTrans();
					throw TE;
				}				
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
		
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="p_BE">要删除的实体</param>
		/// <param name="sqlTrans">事务类</param>
		public void RDelete(BaseEntity p_BE,IDBTransAccess sqlTrans)
		{
			try
			{
			    this.CheckCorrect(p_BE);
				WinListAttachFile entity=(WinListAttachFile)p_BE;				
				WinListAttachFileCtl control=new WinListAttachFileCtl(sqlTrans);
				control.Delete(entity);						
			}
			catch(BaseException)
			{
				throw;
			}
			catch(Exception E)
			{
				throw new BaseException(E.Message);
			}
		}
	}
}
