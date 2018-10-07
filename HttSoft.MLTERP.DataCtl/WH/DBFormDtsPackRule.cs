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
	/// Ŀ�ģ�WH_DBFormDtsPackʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2014/7/21
	/// </summary>
	public class DBFormDtsPackRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public DBFormDtsPackRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			DBFormDtsPack entity=(DBFormDtsPack)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WH_DBFormDtsPack WHERE 1=1";
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



        #region ϸ�����

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(int p_ID, string p_IDStr)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_ID, p_IDStr, sqlTrans);

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
        public void RAdd(int p_ID, string p_IDStr, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT SectionID,JarNum,Batch FROM WH_PackBox WHERE ID IN (" + p_IDStr + ")";
                sql += " GROUP BY SectionID,JarNum,Batch";
                DataTable dt = sqlTrans.Fill(sql);
                int MaxSeq = GetMaxSeq(p_ID);
                decimal Qty = 0;
                DBFormDtsRule rule = new DBFormDtsRule();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)//��һ�и���
                    {
                        sql = "SELECT * FROM WH_PackBox WHERE ID IN (" + p_IDStr + ")";
                        sql += " AND SectionID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["SectionID"]));
                        sql += " AND JarNum=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["JarNum"]));
                        sql += " AND Batch=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["Batch"]));
                        DataTable dtsql = sqlTrans.Fill(sql);

                        DBFormDts entitydts = new DBFormDts(sqlTrans);
                        entitydts.ID = p_ID;
                        entitydts.SelectByID();
                        entitydts.SectionID = SysConvert.ToString(dt.Rows[i]["SectionID"]);
                        entitydts.JarNum = SysConvert.ToString(dt.Rows[i]["JarNum"]);
                        entitydts.Batch = SysConvert.ToString(dt.Rows[i]["Batch"]);
                        entitydts.Qty = SysConvert.ToDecimal(dtsql.Compute("SUM(Qty)", ""));
                        entitydts.PieceQty = dtsql.Rows.Count;
                        entitydts.PackFlag = 1;
                        entitydts.Amount = entitydts.Qty * entitydts.SinglePrice;

                        rule.RUpdate(entitydts, sqlTrans);

                        DBFormDtsPackRule prule = new DBFormDtsPackRule();
                        sql = "DELETE WH_DBFormDtsPack WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        sqlTrans.ExecuteNonQuery(sql);
                        for (int j = 0; j < dtsql.Rows.Count; j++)
                        {

                            DBFormDtsPack pentity = new DBFormDtsPack(sqlTrans);
                            pentity.MainID = entitydts.MainID;
                            pentity.Seq = entitydts.Seq;
                            pentity.SubSeq = j + 1;
                            pentity.BoxNo = SysConvert.ToString(dtsql.Rows[j]["BoxNo"]);
                            pentity.Qty = SysConvert.ToDecimal(dtsql.Rows[j]["Qty"]);
                            pentity.DID = entitydts.ID;
                            prule.RAdd(pentity, sqlTrans);

                        }



                    }
                    else
                    {
                        sql = "SELECT * FROM WH_PackBox WHERE ID IN (" + p_IDStr + ")";
                        sql += " AND SectionID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["SectionID"]));
                        sql += " AND JarNum=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["JarNum"]));
                        sql += " AND Batch=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["Batch"]));
                        DataTable dtsql = sqlTrans.Fill(sql);

                        DBFormDts entitydts = new DBFormDts(sqlTrans);
                        entitydts.ID = p_ID;
                        entitydts.SelectByID();
                        entitydts.Seq = MaxSeq + i;
                        entitydts.SectionID = SysConvert.ToString(dt.Rows[i]["SectionID"]);
                        entitydts.JarNum = SysConvert.ToString(dt.Rows[i]["JarNum"]);
                        entitydts.Batch = SysConvert.ToString(dt.Rows[i]["Batch"]);
                        entitydts.Qty = SysConvert.ToDecimal(dtsql.Compute("SUM(Qty)", ""));
                        entitydts.PieceQty = dtsql.Rows.Count;
                        entitydts.PackFlag = 1;
                        entitydts.Amount = entitydts.Qty * entitydts.SinglePrice;

                        sql = "SELECT ID FROM WH_DBFormDts WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        if (sqlTrans.Fill(sql).Rows.Count > 0)
                        {
                            throw new BaseException("�������У������Ѵ���");
                        }
                        rule.RAdd(entitydts, sqlTrans);

                        DBFormDtsPackRule prule = new DBFormDtsPackRule();
                        sql = "DELETE WH_DBFormDtsPack WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        sqlTrans.ExecuteNonQuery(sql);
                        for (int j = 0; j < dtsql.Rows.Count; j++)
                        {

                            DBFormDtsPack pentity = new DBFormDtsPack(sqlTrans);
                            pentity.MainID = entitydts.MainID;
                            pentity.Seq = entitydts.Seq;
                            pentity.SubSeq = j + 1;
                            pentity.BoxNo = SysConvert.ToString(dtsql.Rows[j]["BoxNo"]);
                            pentity.Qty = SysConvert.ToDecimal(dtsql.Rows[j]["Qty"]);
                            pentity.DID = entitydts.ID;
                            prule.RAdd(pentity, sqlTrans);

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

        private int GetMaxSeq(int p_ID)
        {
            int MaxSeq = 0;
            string sql = "SELECT Max(Seq) Seq FROM WH_DBFormDts WHERE MainID=(SELECT MainID FROM WH_DBFormDts WHERE ID=" + SysString.ToDBString(p_ID) + ")";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                MaxSeq = SysConvert.ToInt32(dt.Rows[0][0]);
            }
            return MaxSeq;
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
				DBFormDtsPack entity=(DBFormDtsPack)p_BE;				
				DBFormDtsPackCtl control=new DBFormDtsPackCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.WH_DBFormDtsPack,sqlTrans);
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
				DBFormDtsPack entity=(DBFormDtsPack)p_BE;				
				DBFormDtsPackCtl control=new DBFormDtsPackCtl(sqlTrans);				
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
				DBFormDtsPack entity=(DBFormDtsPack)p_BE;				
				DBFormDtsPackCtl control=new DBFormDtsPackCtl(sqlTrans);
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
