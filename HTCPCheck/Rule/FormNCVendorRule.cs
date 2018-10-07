using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;
using HttSoft.HTERP.Sys;


namespace HttSoft.HTCPCheck.DataCtl
{
	/// <summary>
	/// Ŀ�ģ�Data_FormNCVendorʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2012-4-17
	/// </summary>
	public class FormNCVendorRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public FormNCVendorRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			FormNCVendor entity=(FormNCVendor)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Data_FormNCVendor WHERE 1=1";
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

        #region ��ˮ�Ŵ���

        bool THAddOneFlag = false;//2010/12�´���ϵͳ�����쳣 ��־�Ƿ��Ѿ��Զ�����һ����

        /// <summary>
        /// �����ˮ�Ŵ���
        /// </summary>
        /// <param name="fncEntity">���ſ��Ʊ�</param>
        /// <param name="p_VendorID">�ͻ�</param>
        /// <param name="sqlTrans">����</param>
        /// <returns></returns>
        public string RGetFormNo(FormNoControl fncEntity, int p_FNCVID, string p_VendorID, IDBTransAccess sqlTrans)
        {
            string outstr = string.Empty;
            string sql = "";

            //���ڴ����ÿͻ���ˮ��ʵ��BEGIN
            sql = "SELECT ID FROM Data_FormNCVendor WHERE VendorID=" + SysString.ToDBString(p_VendorID) + " AND FNCVID=" + p_FNCVID;
            DataTable dt = sqlTrans.Fill(sql);
            FormNCVendor entity = new FormNCVendor(sqlTrans);
            if (dt.Rows.Count != 0)
            {
                entity.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                entity.SelectByID();
            }
            else//���û�ҵ�������һ�ʽ�ȥ
            {
                entity.VendorID = p_VendorID;
                entity.FNCVID = p_FNCVID;
                this.RAdd(entity, sqlTrans);
            }
            //���ڴ����ÿͻ���ˮ��ʵ��END

            #region ��ʼȡ��
            sql = "SELECT getdate() AS ServerTime";
            DateTime dtserver = SysConvert.ToDateTime(sqlTrans.Fill(sql).Rows[0][0].ToString());

            bool UpdFlag = false;
            if (fncEntity.CurYear != 0 && entity.CurYear != dtserver.Year)//�ж���
            {
                entity.CurYear = dtserver.Year;
                UpdFlag = true;
            }
            if (fncEntity.CurMonth != 0 && entity.CurMonth != dtserver.Month)//�ж���
            {
                entity.CurMonth = dtserver.Month;
                UpdFlag = true;
            }
            if (fncEntity.CurDay != 0 && entity.CurDay != dtserver.Day)//�ж���
            {
                entity.CurDay = dtserver.Day;
                UpdFlag = true;
            }
            if (UpdFlag)//��Ҫ����
            {
                entity.CurSort = 0;
                this.RUpdate(entity, sqlTrans);
            }
            outstr = fncEntity.FormRulePre;

            if (entity.CurYear != 0)//�滻��
            {
                outstr = outstr.Replace("YYYY", entity.CurYear.ToString());//�����4λ �¼Ӻ�2010/3/26���޸�
                outstr = outstr.Replace("YY", entity.CurYear.ToString().Substring(2));
            }
            if (entity.CurMonth != 0)//�滻��
            {
                outstr = outstr.Replace("MM", SysString.IntToStr(entity.CurMonth, 2));
            }
            if (entity.CurDay != 0)//�滻��
            {
                outstr = outstr.Replace("DD", SysString.IntToStr(entity.CurDay, 2));
            }
            if (fncEntity.FormRuleSpecial == "V4")
            {
                string spstr = p_VendorID;
                if (p_VendorID.Length > 4)
                {
                    spstr = p_VendorID.Substring(p_VendorID.Length - 4);
                }
                outstr = outstr.Replace("X", spstr);
            }
            else if (fncEntity.FormRuleSpecial != "")//�滻�������
            {
                outstr = outstr.Replace("X", fncEntity.FormRuleSpecial);
            }
            outstr += SysString.IntToStr(entity.CurSort + 1, fncEntity.FormRuleSort.Length);//������

            #endregion

            #region ����һ���Ŵ���
            if (!THAddOneFlag)//û�е��Ź�����ֹ��ѭ��
            {
                try//������֤�Ƿ���ڴ����������1
                {
                    sql = "SELECT DTableName,DFieldName FROM Enum_FormNoControl WHERE ID=" + fncEntity.ID;
                    DataTable dtL = sqlTrans.Fill(sql);
                    if (dtL.Rows.Count != 0)
                    {
                        if (dtL.Rows[0]["DTableName"].ToString() != string.Empty && dtL.Rows[0]["DFieldName"].ToString() != string.Empty)
                        {
                            sql = "SELECT " + dtL.Rows[0]["DFieldName"].ToString() + " FROM " + dtL.Rows[0]["DTableName"].ToString() + " WHERE " + dtL.Rows[0]["DFieldName"].ToString() + "=" + SysString.ToDBString(outstr);
                            if (sqlTrans.Fill(sql).Rows.Count != 0)//�����ĺ���ϵͳ���Ѵ��ڣ����������
                            {
                                THAddOneFlag = true;
                                this.RAddSort(fncEntity.ID, p_FNCVID, p_VendorID, sqlTrans);
                                outstr = RGetFormNo(fncEntity, p_FNCVID, p_VendorID, sqlTrans);//ѭ������һ��

                            }
                        }
                    }
                }
                catch (Exception EL)//�쳣�������д��ʱ��Ϣ
                {
                    SysFile.WriteFrameworkLog(EL.Message);
                }
            }
            #endregion
            return outstr;
        }

        /// <summary>
        /// ������ż�1
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        /// <param name="p_Num">�ڼ������ݺ���0,1,2,</param>
        /// <param name="sqlTrans">����</param>
        public void RAddSort(int p_FormNoContronlID, int p_FNCVID, string p_VendorID, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT ID FROM Data_FormNCVendor WHERE VendorID=" + SysString.ToDBString(p_VendorID) + " AND FNCVID=" + p_FNCVID;
                DataTable dt = sqlTrans.Fill(sql);
                FormNCVendor entity = new FormNCVendor(sqlTrans);
                if (dt.Rows.Count != 0)
                {
                    entity.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    entity.SelectByID();

                    sql = "UPDATE Data_FormNCVendor SET CurSort=" + (entity.CurSort + 1) + " WHERE ID=" + entity.ID;
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
				FormNCVendor entity=(FormNCVendor)p_BE;
                //���ݿͻ�����͵���ID��ѯ�����ѯ�õ��������ظ�
                string sql = "SELECT * FROM Data_FormNCVendor WHERE VendorID="+SysString.ToDBString(entity.VendorID);
                sql += " AND FNCVID="+SysString.ToDBString(entity.FNCVID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("ͬ�ͻ��ĵ�����ˮ�������Ѵ���,�������������!");
                }
				FormNCVendorCtl control=new FormNCVendorCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Data_FormNCVendor,sqlTrans);
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
				FormNCVendor entity=(FormNCVendor)p_BE;				
				FormNCVendorCtl control=new FormNCVendorCtl(sqlTrans);				
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
				FormNCVendor entity=(FormNCVendor)p_BE;				
				FormNCVendorCtl control=new FormNCVendorCtl(sqlTrans);
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
