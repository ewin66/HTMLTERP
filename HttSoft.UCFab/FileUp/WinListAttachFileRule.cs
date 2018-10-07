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
	/// Ŀ�ģ�Data_WinListAttachFileʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2014/4/23
	/// </summary>
	public class WinListAttachFileRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public WinListAttachFileRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			WinListAttachFile entity=(WinListAttachFile)p_BE;
        }


        #region �Զ��巽��
        /// <summary>
        /// ��ȡ�ļ�����
        /// </summary>
        /// <param name="p_FileID">�ļ�ID</param>
        /// <param name="o_File">�ļ�����</param>
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
        /// ɾ���ļ�
        /// </summary>
        /// <param name="o_FileID">�ļ�ID</param>
        public static void DeleteFile(int o_FileID)
        {
            string sql = "DELETE FROM Data_WinListAttachFile WHERE ID=" + o_FileID;
            SysUtils.ExecuteNonQuery(sql);
        }



        //����·��������Ӧ���Ƿ�Ϊ�ļ�

        public static long FileSize(string filePath)
        {
            long temp = 0;

            //�жϵ�ǰ·����ָ����Ƿ�Ϊ�ļ�
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

                //����һ��FileInfo����,ʹ֮��filePath��ָ����ļ������,

                //�Ի�ȡ���С
                FileInfo fileInfo = new FileInfo(filePath);
                return fileInfo.Length;
            }
            return temp;
        }

        /// <summary>
        /// ���ļ�ת���ɶ�����
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

        #region ���ݱ���
        #region �����ļ�
        /// <summary>
        /// ����
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
        /// ����(����������)
        /// </summary>
        /// <param name="sqlTrans">������</param>
        public int RAdd(byte[] p_File, int winListID, int headtype, int subtype, int dataid, int dataSeq, string fileName, string filetitle, string fileExec, string p_Remark, string p_FileProt1, string p_FileProt2, decimal fileSize, string LoginID, string LoginName, int loginLogID, IDBTransAccess sqlTrans)
        {
            try
            {
                int sysEntityID= UCFileUPParamSet.GetIntValueByID(7201);//����ļ�����ʵ��ID
                if (sysEntityID == 0)
                {
                    sysEntityID = 45;//Ĭ����45
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
        /// ��ʾ����
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
        /// ��ʾ����
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
		/// ����
		/// </summary>
		/// <param name="p_BE">Ҫ������ʵ��</param>
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
		/// ����(����������)
		/// </summary>
		/// <param name="p_BE">Ҫ������ʵ��</param>
		/// <param name="sqlTrans">������</param>
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
		/// �޸�
		/// </summary>
		/// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
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
		/// �޸�
		/// </summary>
		/// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
		/// <param name="sqlTrans">������</param>
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
		/// ɾ��
		/// </summary>
		/// <param name="p_BE">Ҫɾ����ʵ��</param>
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
		/// ɾ��
		/// </summary>
		/// <param name="p_BE">Ҫɾ����ʵ��</param>
		/// <param name="sqlTrans">������</param>
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
