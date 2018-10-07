using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;


namespace HttSoft.MLTERP.DataCtl
{
	/// <summary>
	/// Ŀ�ģ�Dev_GBJCʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2012-4-17
	/// </summary>
	public class GBJCLRRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public GBJCLRRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			GBJCLR entity=(GBJCLR)p_BE;
		}	
		
		
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
                string sql = "SELECT " + p_FieldName + " FROM UV2_Dev_GBJCLRDts WHERE 1=1";
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
				GBJCLR entity=(GBJCLR)p_BE;
                string sql = "SELECT FormNo FROM Dev_GBJCLR WHERE FormNo="+SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�Ұ��������Ѵ��ڣ�����������");
                }
				GBJCLRCtl control=new GBJCLRCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Dev_GBJCLR,sqlTrans);
				control.AddNew(entity);
                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.�Ұ�������,sqlTrans);
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
				GBJCLR entity=(GBJCLR)p_BE;				
				GBJCLRCtl control=new GBJCLRCtl(sqlTrans);				
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
				GBJCLR entity=(GBJCLR)p_BE;				
				GBJCLRCtl control=new GBJCLRCtl(sqlTrans);
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
        #region ��������
        ///// <summary>
        ///// ����
        ///// </summary>
        ///// <param name="p_BE">Ҫ������ʵ��</param>
        //public void RAdd(BaseEntity p_BE,BaseEntity[] p_BE2)
        //{
        //    try
        //    {
        //        IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
        //        try
        //        {
        //            sqlTrans.OpenTrans();

        //            this.RAdd(p_BE,p_BE2,sqlTrans);

        //            sqlTrans.CommitTrans();
        //        }
        //        catch (Exception TE)
        //        {
        //            sqlTrans.RollbackTrans();
        //            throw TE;
        //        }
        //    }
        //    catch (BaseException)
        //    {
        //        throw;
        //    }
        //    catch (Exception E)
        //    {
        //        throw new BaseException(E.Message);
        //    }
        //}

        ///// <summary>
        ///// ����(����������)
        ///// </summary>
        ///// <param name="p_BE">Ҫ������ʵ��</param>
        ///// <param name="sqlTrans">������</param>
        //public void RAdd(BaseEntity p_BE,BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {
        //        this.CheckCorrect(p_BE);
        //        GBJCLR entity = (GBJCLR)p_BE;
        //        string sql = "SELECT FormNo FROM Dev_GBJC WHERE FormNo="+SysString.ToDBString(entity.FormNo);
        //        DataTable dt = sqlTrans.Fill(sql);
        //        if (dt.Rows.Count > 0)
        //        {
        //            throw new BaseException("�Ұ��������ظ����������������");
        //        }
        //        GBJCLRCtl control = new GBJCLRCtl(sqlTrans);
        //        entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Dev_GBJC, sqlTrans);
        //        control.AddNew(entity);
        //        for (int i = 0; i < p_BE2.Length; i++)
        //        {
        //            GBJCDtsRule rule = new GBJCDtsRule();
        //            GBJCDts entityDts = (GBJCDts)p_BE2[i];
        //            entityDts.MainID = entity.ID;
        //            entityDts.Seq = i + 1;
        //            rule.RAdd(entityDts, sqlTrans);
        //        }
        //        FormNoControlRule rulefst = new FormNoControlRule();
        //        rulefst.RAddSort((int)FormNoControlEnum.�Ұ�������,sqlTrans);
        //    }
        //    catch (BaseException)
        //    {
        //        throw;
        //    }
        //    catch (Exception E)
        //    {
        //        throw new BaseException(E.Message);
        //    }
        //}
      

        ///// <summary>
        ///// �޸�
        ///// </summary>
        ///// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        //public void RUpdate(BaseEntity p_BE,BaseEntity[] p_BE2)
        //{
        //    try
        //    {
        //        IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
        //        try
        //        {
        //            sqlTrans.OpenTrans();

        //            this.RUpdate(p_BE,p_BE2,sqlTrans);

        //            sqlTrans.CommitTrans();
        //        }
        //        catch (Exception TE)
        //        {
        //            sqlTrans.RollbackTrans();
        //            throw TE;
        //        }
        //    }
        //    catch (BaseException)
        //    {
        //        throw;
        //    }
        //    catch (Exception E)
        //    {
        //        throw new BaseException(E.Message);
        //    }
        //}

        ///// <summary>
        ///// �޸�
        ///// </summary>
        ///// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        ///// <param name="sqlTrans">������</param>
        //public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {
        //        this.CheckCorrect(p_BE);
        //        GBJCLR entity = (GBJCLR)p_BE;
        //        GBJCLRCtl control = new GBJCLRCtl(sqlTrans);
        //        control.Update(entity);
        //        string sql = "DELETE Dev_GBJCDts  WHERE MainID="+SysString.ToDBString(entity.ID);
        //        sqlTrans.Fill(sql);
        //        for (int i = 0; i < p_BE2.Length; i++)
        //        {
        //            GBJCDtsRule rule = new GBJCDtsRule();
        //            GBJCDts entityDts = (GBJCDts)p_BE2[i];
        //            entityDts.MainID = entity.ID;
        //            entityDts.Seq = i + 1;
        //            rule.RAdd(entityDts, sqlTrans);
        //        }
        //    }
        //    catch (BaseException)
        //    {
        //        throw;
        //    }
        //    catch (Exception E)
        //    {
        //        throw new BaseException(E.Message);
        //    }
        //}

        /// <summary>
        /// �ύ
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        public void RSubmit(int p_ID,int p_SubmitFlag)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSubmit(p_ID, p_SubmitFlag, sqlTrans);

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
        /// �ύ
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RSubmit(int p_ID, int p_SubmitFlag, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT SubmitFlag FROM Dev_GBJCLR WHERE ID="+SysString.ToDBString(p_ID);
                DataTable dt = sqlTrans.Fill(sql);
                int SubmitFlag = 0;
                if (dt.Rows.Count > 0)
                {
                    SubmitFlag = SysConvert.ToInt32(dt.Rows[0]["SubmitFlag"]);
                    if (SubmitFlag == p_SubmitFlag)
                    {
                        throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
                    }
                    switch (SubmitFlag)
                    {
                        case 1://�����ύ
                            sql = "UPDATE Dev_GBJCLR SET SubmitFlag=0 WHERE ID=" + SysString.ToDBString(p_ID);
                            sqlTrans.ExecuteNonQuery(sql);
                            break;
                        case 0://�ύ
                            sql = "UPDATE Dev_GBJCLR SET SubmitFlag=1 WHERE ID=" + SysString.ToDBString(p_ID);
                            sqlTrans.ExecuteNonQuery(sql);
                            break;
                    }

                    
                    //RSetGBStatus(p_ID, p_SubmitFlag, sqlTrans);//����Ұ�״̬

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
        /// ����Ұ�״̬
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_SubmitFlag"></param>
        /// <param name="sqlTrans"></param>
        private void RSetGBStatus(int p_ID, int p_SubmitFlag, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT ID,GBCode FROM Dev_GBJCDts WHERE MainID=" + SysString.ToDBString(p_ID);
            DataTable dt = sqlTrans.Fill(sql);
            int QStatus = 0;
            if (p_SubmitFlag == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sql = "SELECT GBStatusID FROM Data_ItemGB WHERE GBCode="+SysString.ToDBString(dr["GBCode"].ToString());
                    DataTable dto = sqlTrans.Fill(sql);
                    if (dto.Rows.Count > 0)
                    {
                        QStatus = SysConvert.ToInt32(dto.Rows[0][0]);
                        if (QStatus == (int)EnumGBStatus.�ڿ� || QStatus == (int)EnumGBStatus.�黹)
                        {
                            sql = "UPDATE Data_ItemGB SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.���);
                            sql += "WHERE GBCode=" + SysString.ToDBString(SysConvert.ToString(dr["GBCode"]));
                            sqlTrans.ExecuteNonQuery(sql);

                            sql = "UPDATE Dev_GBJCDts SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.���);
                            sql += "WHERE ID="+SysString.ToDBString(SysConvert.ToInt32(dr["ID"]));
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                        else
                        {
                            throw new BaseException("�Ұ�[" + SysConvert.ToString(dr["GBCode"]) + "]�������ڿ��黹״̬����鿴");
                        }
                    }
                    else
                    {
                        throw new BaseException("�Ұ�[" + SysConvert.ToString(dr["GBCode"]) + "]�����ڣ�����Ұ����");
                    }
                }
            }

            else if (p_SubmitFlag == 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sql = "SELECT GBStatusID FROM Data_ItemGB WHERE GBCode=" + SysString.ToDBString(dr["GBCode"].ToString());
                    DataTable dto = sqlTrans.Fill(sql);
                    if (dto.Rows.Count > 0)
                    {
                        QStatus = SysConvert.ToInt32(dto.Rows[0][0]);
                        if (QStatus == (int)EnumGBStatus.���)
                        {
                            sql = "UPDATE Data_ItemGB SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.�ڿ�);
                            sql += "WHERE GBCode=" + SysString.ToDBString(SysConvert.ToString(dr["GBCode"]));
                            sqlTrans.ExecuteNonQuery(sql);

                            //sql = "UPDATE Dev_GBJCDts SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.�ڿ�);
                            //sql += "WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(dr["ID"]));
                            //sqlTrans.ExecuteNonQuery(sql);
                        }
                        else
                        {
                            throw new BaseException("�Ұ�[" + SysConvert.ToString(dr["GBCode"]) + "]�����ڽ��״̬����鿴");
                        }
                    }
                    else
                    {
                        throw new BaseException("�Ұ�[" + SysConvert.ToString(dr["GBCode"]) + "]�����ڣ�����Ұ����");
                    }
                }
            }
        }

        /// <summary>
        /// ����״̬ID�õ�״̬��
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        private string GetStatusName(int p_ID)
        {
            string sql = "SELECT Name FROM Enum_GBStatus WHERE ID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            return string.Empty;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        public void RUpdate(string p_GBCode, int p_SubmitFlag, int p_MainID,int LYFlag,string p_OPID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_GBCode, p_SubmitFlag, p_MainID, LYFlag, p_OPID,sqlTrans);

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
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RUpdate(string p_GBCode,int p_SubmitFlag,int p_MainID,int LYFlag,string p_OPID,IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT GBCode FROM Data_ItemGB WHERE GBCode="+SysString.ToDBString(p_GBCode);
                DataTable dto = sqlTrans.Fill(sql);
                if (dto.Rows.Count == 0)
                {
                    throw new BaseException("ɨ��Ұ岻���ڣ����ڹҰ������в鿴");
                }
                if (p_SubmitFlag == 1)
                {

                    sql = "SELECT * FROM UV1_Dev_GBJCDts WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                    sql += " AND GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.���);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        throw new BaseException("�Ұ�[" + p_GBCode + "]û����������ѹ黹������");
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        sql = "UPDATE Dev_GBJCDts SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.�黹);
                        sql += ",GHTime=" + SysString.ToDBString(DateTime.Now.Date);
                        sql += ",LYFlag="+SysString.ToDBString(LYFlag);
                        sql += ",GHOPID="+SysString.ToDBString(p_OPID);
                        sql += "WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                        sql += " AND GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.���);
                        sql += " AND MainID IN(SELECT ID FROM Dev_GBJC)";
                        sqlTrans.ExecuteNonQuery(sql);

                        sql = "UPDATE Data_ItemGB SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.�黹);
                        sql += "WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                        sqlTrans.ExecuteNonQuery(sql);

                    }
                    else
                    {
                        throw new BaseException("�Ұ�[" + p_GBCode + "]�ڽ�����д�������ͬΪ���״̬�����ݣ�����");
                    }
                }
                else if (p_SubmitFlag == 0)
                {
                    if (p_MainID == 0)
                    {
                        throw new BaseException("�����黹���ݴ����쳣����鿴");
                    }
                    sql = "SELECT * FROM Dev_GBJCDts WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                    sql += " AND MainID=" + SysString.ToDBString(p_MainID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        throw new BaseException("�Ұ�[" + p_GBCode + "]û�й黹��������������");
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        sql = "UPDATE Dev_GBJCDts SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.���);
                        sql += ",GHTime=null,LYFlag=0,GHOPID='' ";
                        sql += "WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                        sql += " AND MainID=" + SysString.ToDBString(p_MainID);
                        sqlTrans.ExecuteNonQuery(sql);

                        sql = "UPDATE Data_ItemGB SET GBStatusID=" + SysString.ToDBString((int)EnumGBStatus.���);
                        sql += "WHERE GBCode=" + SysString.ToDBString(p_GBCode);
                        sqlTrans.ExecuteNonQuery(sql);

                    }
                   
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
        #endregion
    }
}
