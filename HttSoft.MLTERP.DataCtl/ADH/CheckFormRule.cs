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
	/// Ŀ�ģ�ADH_CheckFormʵ��ҵ�������
	/// ����:��Զ��
	/// ��������:2011-8-25
	/// </summary>
	public class CheckFormRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public CheckFormRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CheckForm entity=(CheckForm)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_ADH_CheckFormDts WHERE 1=1";
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



        #region ɨ������

        /// <summary>
        /// ɨ������
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public int RScan(int p_ID, string p_ISN, int p_YPQty, string p_Vendorid, int p_ZHID, DateTime p_Time)
        {
            int outi = 0;
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    outi = this.RScan(p_ID, p_ISN, p_YPQty, p_Vendorid, p_ZHID,p_Time, sqlTrans);

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
            return outi;
        }

        /// <summary>
        /// ɨ������(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public int RScan(int p_ID, string p_ISN, int p_YPQty, string p_Vendorid, int p_ZHID,DateTime p_Time, IDBTransAccess sqlTrans)
        {
            int outi = 0;
            try
            {
                CheckForm entity = new CheckForm(sqlTrans);
                if (p_ID == 0)
                {
                    FormNoControlRule prule = new FormNoControlRule();

                    //entity.FormCode = prule.RGetFormNo("ADH_CheckForm", "FormCode", sqlTrans);

                    entity.FormCode = prule.RGetFormNo((int)FormNoControlEnum.��Ʒ���۵���);

                    entity.DVendorID = p_Vendorid;
                    entity.FormDate = DateTime.Now;
                    entity.DataDHID = p_ZHID;
                    entity.BJHL = 1;
                    this.RAdd(entity, sqlTrans);
                    outi = entity.ID;
                    CheckFormDtsRule dtsrule = new CheckFormDtsRule();
                    dtsrule.RScan(entity.ID, p_ISN, p_YPQty, p_Time,sqlTrans);
                }
                else
                {
                    outi = p_ID;
                    entity.ID = p_ID;
                    if (entity.SelectByID())//�ҵ�������
                    {
                        if (entity.SubmitFlag==(int)YesOrNo.Yes)
                        {
                            throw new Exception("���������,���ܲ���");
                        }

                        CheckFormDtsRule dtsrule = new CheckFormDtsRule();
                        dtsrule.RScan(entity.ID, p_ISN, p_YPQty, p_Time,sqlTrans);
                    }
                }


                //��¼ɨ����ʷ
                string sql = string.Empty;
                sql = "INSERT INTO ADH_ScanHis(ISN,DataDHID,DVendorID) VALUES(" + SysString.ToDBString(p_ISN) + ","+SysString.ToDBString(p_ZHID)+","+SysString.ToDBString(p_Vendorid)+")";
                sqlTrans.ExecuteNonQuery(sql);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
            return outi;
        }
        #endregion

        #region ɨ������ ȷ�����

        /// <summary>
        /// ɨ������ ȷ�����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public int RScanOK(int p_ID)
        {
            int outi = 0;
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    outi = this.RScanOK(p_ID, sqlTrans);

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
            return outi;
        }

        /// <summary>
        /// ɨ������(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public int RScanOK(int p_ID, IDBTransAccess sqlTrans)
        {
            int outi = 0;
            try
            {
                CheckForm entity = new CheckForm(sqlTrans);
                if (p_ID == 0)
                {
                    throw new Exception("δ�ҵ�����");
                }
                else
                {
                    outi = p_ID;
                    entity.ID = p_ID;
                    if (entity.SelectByID())//�ҵ�������
                    {
                        if (entity.SubmitFlag == (int)YesOrNo.Yes)
                        {
                            throw new Exception("���������,���ܲ���");
                        }
                        entity.SubmitFlag = 1;
                        this.RUpdate(entity, sqlTrans);

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
            return outi;
        }
        #endregion

        #region ɨ�賷��
        /// <summary>
        /// ɨ������
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RScanCancel(int p_ID, string p_ISN)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RScanCancel(p_ID, p_ISN, sqlTrans);

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
        /// ɨ������(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RScanCancel(int p_ID, string p_ISN, IDBTransAccess sqlTrans)
        {
            try
            {
                CheckForm entity = new CheckForm(sqlTrans);
                if (p_ID == 0)
                {
                    throw new Exception("δ�ҵ�����");
                }
                else
                {
                    entity.ID = p_ID;
                    entity.SelectByID();
                    if (entity.SubmitFlag==(int)YesOrNo.Yes)
                    {
                        throw new Exception("���������,���ܲ���");
                    }
                    string sql = string.Empty;
                    if (p_ISN == string.Empty)
                    {
                        sql = "DELETE FROM ADH_CheckFormDts WHERE MainID=" + SysString.ToDBString(p_ID);
                        sqlTrans.ExecuteNonQuery(sql);
                    }
                    else
                    {

                        if (sqlTrans.Fill("SELECT MainID FROM ADH_CheckFormDts WHERE MainID=" + SysString.ToDBString(p_ID) + " AND ISN=" + SysString.ToDBString(p_ISN)).Rows.Count != 0)
                        {
                            sql = "DELETE FROM ADH_CheckFormDts WHERE MainID=" + SysString.ToDBString(p_ID) + " AND ISN=" + SysString.ToDBString(p_ISN);
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                        else
                        {
                            throw new Exception("������δ�ҵ�������");
                        }
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
                CheckForm entity = (CheckForm)p_BE;
                CheckFormCtl control = new CheckFormCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.ADH_CheckForm, sqlTrans);

                string sql = "SELECT FormCode FROM ADH_CheckForm WHERE FormCode=" + SysString.ToDBString(entity.FormCode);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�����Ѵ��ڣ�����������");
                }


                control.AddNew(entity);

                FormNoControlRule prule = new FormNoControlRule();

                prule.RAddSort((int)FormNoControlEnum.��Ʒ���۵���, sqlTrans);

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
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE1)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE1,sqlTrans);

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
        /// ����(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE1,IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                CheckFormDtsRule rule = new CheckFormDtsRule();
                for (int i = 0; i < p_BE1.Length;i++ )
                {
                    CheckFormDts entitydts = p_BE1[i] as CheckFormDts;
                    entitydts.MainID = ((CheckForm)p_BE).ID;
                    entitydts.Seq = i + 1;
                    rule.RAdd(entitydts, sqlTrans); 
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
				CheckForm entity=(CheckForm)p_BE;				
				CheckFormCtl control=new CheckFormCtl(sqlTrans);				
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
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE1)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE1,sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE1,IDBTransAccess sqlTrans)
        {
            try
            {
                this.RUpdate(p_BE, sqlTrans);
                string sql = " DELETE FROM ADH_CheckFormDts where MainID=" + ((CheckForm)p_BE).ID;

                sqlTrans.ExecuteNonQuery(sql);
                CheckFormDtsRule rule = new CheckFormDtsRule();
                for (int i = 0; i < p_BE1.Length; i++)
                {
                    CheckFormDts entitydts = p_BE1[i] as CheckFormDts;
                    entitydts.MainID = ((CheckForm)p_BE).ID;
                    entitydts.Seq = i + 1;
                    rule.RAdd(entitydts, sqlTrans);
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
				CheckForm entity=(CheckForm)p_BE;
                string sql = " DELETE FROM ADH_CheckFormDts where MainID=" + ((CheckForm)p_BE).ID;

                sqlTrans.ExecuteNonQuery(sql);

				CheckFormCtl control=new CheckFormCtl(sqlTrans);
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
