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
	/// Ŀ�ģ�Sys_ParamSetʵ��ҵ�������
	/// ����:������
	/// ��������:2012/4/17
	/// </summary>
	public class ParamSetRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public ParamSetRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			ParamSet entity=(ParamSet)p_BE;
		}	
		
		/// <summary>
        /// �����ֶ�ֵ�Ƿ��Ѵ���
        /// </summary>
        /// <param name="p_TableName">����</param>
        /// <param name="p_FieldName">�ֶ���</param>
        /// <param name="p_FieldValue">�ֶ�ֵ</param>
        /// <param name="p_KeyField">������ֻ��������ΪID�������</param>
        /// <param name="p_KeyValue">����ֵ</param>
        /// <param name="p_sqlTrans"></param>
        /// <returns></returns>
        private bool CheckFieldValueIsExist(BaseEntity p_BE, string p_FieldName, string p_FieldValue, IDBTransAccess p_sqlTrans)
        {
            ParamSet entity = (ParamSet)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, ParamSet.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
            DataTable dt = p_sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                ret = true;
            }

            return ret;
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
                string sql = "SELECT " + p_FieldName + " FROM Sys_ParamSet WHERE 1=1";
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

        #region Show By Code
        /// <summary>
        /// ���ݱ����ѯ
        /// </summary>
        public string RShowStrByCode(int p_Code)
        {
            return RShowStrByCode(p_Code.ToString());
        }
        /// <summary>
        /// ���ݱ����ѯ
        /// </summary>
        public string RShowStrByCode(string p_Code)
        {
            try
            {
                string outstr = string.Empty;
                string sql = string.Empty;
                sql = " SELECT SetValueStr FROM Sys_ParamSet  WHERE  Code = " + SysString.ToDBString(p_Code);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    outstr = dt.Rows[0][0].ToString();
                }
                return outstr;
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
        /// ���ݱ����ѯ
        /// </summary>
        public int RShowIntByCode(int p_Code)
        {
            return RShowIntByCode(p_Code.ToString());
        }
        /// <summary>
        /// ���ݱ����ѯ
        /// </summary>
        public int RShowIntByCode(string p_Code)
        {
            try
            {
                int outstr = -100;
                string sql = string.Empty;
                sql = " SELECT SetValueInt FROM Sys_ParamSet  WHERE  Code = " + SysString.ToDBString(p_Code);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    outstr = SysConvert.ToInt32(dt.Rows[0][0].ToString());
                }
                return outstr;
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
        /// ���ݱ����ѯ
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        public decimal RShowDecimalByCode(int p_Code)
        {
            return RShowDecimalByCode(p_Code.ToString());
        }
        /// <summary>
        /// ���ݱ����ѯ
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        public decimal RShowDecimalByCode(string p_Code)
        {
            string str = RShowStrByCode(p_Code);
            return SysConvert.ToDecimal(str);
        }
        #endregion

        #region Show By ID
       
        /// <summary>
        /// ����ID��ѯ
        /// </summary>
        public string RShowStrByID(int p_ID)
        {
            try
            {
                string outstr = string.Empty;
                string sql = string.Empty;
                sql = " SELECT SetValueStr FROM Sys_ParamSet  WHERE  ID = " + SysString.ToDBString(p_ID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    outstr = dt.Rows[0][0].ToString();
                }
                return outstr;
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
        /// ���ݱ����ѯ
        /// </summary>
        public int RShowIntByID(int p_ID)
        {
            try
            {
                int outstr = -100;
                string sql = string.Empty;
                sql = " SELECT SetValueInt FROM Sys_ParamSet  WHERE  ID = " + SysString.ToDBString(p_ID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    outstr = SysConvert.ToInt32(dt.Rows[0][0].ToString());
                }
                return outstr;
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
        /// ���ݱ����ѯ
        /// </summary>
        /// <param name="p_Code"></param>
        /// <returns></returns>
        public decimal RShowDecimalByID(int p_ID)
        {
            string str = RShowStrByID(p_ID);
            return SysConvert.ToDecimal(str);
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
				ParamSet entity=(ParamSet)p_BE;				
				ParamSetCtl control=new ParamSetCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Sys_ParamSet,sqlTrans);
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
				ParamSet entity=(ParamSet)p_BE;				
				ParamSetCtl control=new ParamSetCtl(sqlTrans);				
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
				ParamSet entity=(ParamSet)p_BE;				
				ParamSetCtl control=new ParamSetCtl(sqlTrans);
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



        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        public void RUpdatePDDate()
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdatePDDate(sqlTrans);

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
        public void RUpdatePDDate(IDBTransAccess sqlTrans)
        {
            try
            {
                //��һ�� ɾ���̵�����
                string sql = "UPDATE WH_Storge SET PDDate=NULL";
                sqlTrans.ExecuteNonQuery(sql);

                //�ڶ��� �����̵������
                sql = "SELECT FormNo,FormDate,WHID,SectionID,ItemCode,GoodsCode,ColorNum,ColorName FROM UV1_WH_IOFormDts WHERE SubType=801 AND SubmitFlag=1 ORDER BY FormDate";
                DataTable dt = sqlTrans.Fill(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime FormDate = SysConvert.ToDateTime(dt.Rows[i]["FormDate"]);
                    string WHID = SysConvert.ToString(dt.Rows[i]["WHID"]);
                    string SectionID = SysConvert.ToString(dt.Rows[i]["SectionID"]);
                    string ItemCode = SysConvert.ToString(dt.Rows[i]["ItemCode"]);
                    string GoodsCode = SysConvert.ToString(dt.Rows[i]["GoodsCode"]);
                    string ColorNum = SysConvert.ToString(dt.Rows[i]["ColorNum"]);
                    string ColorName = SysConvert.ToString(dt.Rows[i]["ColorName"]);
                    sql = "UPDATE WH_Storge SET PDDate="+SysString.ToDBString(FormDate);
                    sql += " WHERE WHID=" + SysString.ToDBString(WHID);
                    sql += " AND SectionID=" + SysString.ToDBString(SectionID);
                    sql += " AND ItemCode=" + SysString.ToDBString(ItemCode);
                    sql += " AND GoodsCode=" + SysString.ToDBString(GoodsCode);
                    sql += " AND ColorNum=" + SysString.ToDBString(ColorNum);
                    sql += " AND ColorName=" + SysString.ToDBString(ColorName);
                    sqlTrans.ExecuteNonQuery(sql);

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

       
    }
}
