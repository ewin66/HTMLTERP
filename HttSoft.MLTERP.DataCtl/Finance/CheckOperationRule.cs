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
	/// Ŀ�ģ�Finance_CheckOperationʵ��ҵ�������
	/// ����:������
	/// ��������:2012/5/8
	/// </summary>
	public class CheckOperationRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public CheckOperationRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CheckOperation entity=(CheckOperation)p_BE;
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
            CheckOperation entity = (CheckOperation)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, CheckOperation.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Finance_CheckOperation WHERE 1=1";
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
        /// ��ʾ����
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShowDts(string p_condition)
        {
            try
            {
                return RShowDts(p_condition, "*");
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
        public DataTable RShowDts(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_Finance_CheckOperationDts WHERE 1=1";
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
        
        
        #region  ���ӱ��淽��
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                CheckOperationDtsRule ruledts = new CheckOperationDtsRule();
                ruledts.RSave((CheckOperation)p_BE, p_BE2, sqlTrans);//����ӱ�


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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                CheckOperationDtsRule ruledts = new CheckOperationDtsRule();
                ruledts.RSave((CheckOperation)p_BE, p_BE2, sqlTrans);//����ӱ�
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
				CheckOperation entity=(CheckOperation)p_BE;
                string sql = "SELECT FormNo FROM Finance_CheckOperation WHERE FormNo="+SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("���˵����Ѵ��ڣ�����������");
                }
				CheckOperationCtl control=new CheckOperationCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Finance_CheckOperation, sqlTrans);
				control.AddNew(entity);

                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.���˵���,sqlTrans);
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
				CheckOperation entity=(CheckOperation)p_BE;				
				CheckOperationCtl control=new CheckOperationCtl(sqlTrans);				
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
				CheckOperation entity=(CheckOperation)p_BE;				
				CheckOperationCtl control=new CheckOperationCtl(sqlTrans);
				
				
                string sql = "DELETE FROM Finance_CheckOperationDts WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������ϸ����
				
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

        #region �ύ����
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        /// <param name="p_Type">0/1:����/���</param>
        public void RSubmit(int p_FormID, int p_Type)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSubmit(p_FormID, p_Type, sqlTrans);
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
        /// ���
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        /// <param name="p_Type">0/1/2/3:����/���</param>
        public void RSubmit(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                int p_TempType = p_Type;//����״̬
                string sql = string.Empty;
                CheckOperation entity = new CheckOperation(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//�����ͬ�쳣
                {
                    throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
                }

                //����״̬
                sql = "UPDATE  Finance_CheckOperation SET SubmitFlag=" + SysString.ToDBString(p_Type) + " WHERE ID=" + p_FormID;
                sqlTrans.ExecuteNonQuery(sql);

                if (entity.MergeFlage == 1)
                {
                    SetCheckOperationTotal(p_FormID, p_Type, sqlTrans);
                }
                else
                {
                    SetCheckOperation(p_FormID, p_Type, sqlTrans);//�������ݴ���
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
        /// ������˻�������
        /// </summary>
        /// <param name="p_FormID"></param>
        /// <param name="p_Type"></param>
        /// <param name="sqlTrans"></param>
        private void SetCheckOperation(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT ID,MainID,Seq FROM Finance_CheckOperationDts WHERE MainID=" + SysString.ToDBString(p_FormID);
            sql += " ORDER BY Seq";
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {

                    //���˵�
                    CheckOperation entity = new CheckOperation();
                    entity.ID = p_FormID;

                    ///���˵���ϸ
                    CheckOperationDts entityDts = new CheckOperationDts();
                    entityDts.ID = SysConvert.ToInt32(dr["ID"]);
                    entityDts.SelectByID();

                    ///�ֿⵥ����ϸ
                    IOFormDts entityIOF = new IOFormDts(sqlTrans);
                    entityIOF.ID = entityDts.DLOADDtsID;
                    if (entityDts.DLOADDtsID > 0) ///����ֿ���������
                    {
                        if (entityIOF.SelectByID())
                        {
                        }
                        else
                        {
                            throw new Exception("�����쳣��û���ҵ�������¼ ID:" + entityDts.DLOADDtsID);
                        }
                        if (p_Type == (int)YesOrNo.Yes)//�ύ
                        {
                            //if (entityIOF.DZFlag == (int)YesOrNo.Yes && entityIOF.Qty == entityDts.DCheckQty)
                            //{
                            //    throw new Exception("���ܲ����������Ѷ��� ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                            //}

                            ///�������ݵ�������ϸ���У��������������˽����˵��ۡ����˱�־�����˵����������ڡ����˵���                            
                            sql = "UPDATE WH_IOFormDts SET DZQty=ISNULL(DZQty,0)+(" + SysString.ToDBString(entityDts.DCheckQty) + ")";
                            sql += ",DZAmount=ISNULL(DZAmount,0)+(" + SysString.ToDBString(entityDts.DCheckAmount) + ")";
                            sql += ",DZSinglePrice=" + SysString.ToDBString(entityDts.DCheckSinglePrice);
                            sql += ",DZFlag=1";
                            sql += ",DZOPID=" + SysString.ToDBString(entity.SaleOPID);
                            sql += ",DZTime=GetDate()";
                            sql += ",DZNo=" + SysString.ToDBString(entity.FormNo);
                            sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                        else//�����ύ
                        {
                            //if (entityIOF.InvoiceQty != 0 && entityIOF.Qty == entityDts.DCheckQty)
                            //{
                            //    throw new Exception("���ܲ������������п�Ʊ���� ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                            //}

                            sql = "UPDATE WH_IOFormDts SET DZQty=ISNULL(DZQty,0)-(" + SysString.ToDBString(entityDts.DCheckQty) + ")";
                            sql += ",DZAmount=ISNULL(DZAmount,0)-(" + SysString.ToDBString(entityDts.DCheckAmount) + ")";
                            sql += ",DZSinglePrice=NULL";
                            if (entityIOF.DZQty == entityDts.DCheckQty)
                            {
                                sql += ",DZFlag=0";
                            }
                            sql += ",DZOPID=''";
                            sql += ",DZTime=NULL";
                            sql += ",DZNo=''";
                            sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
                            sqlTrans.ExecuteNonQuery(sql);
                        }

                    }
                }
            }
        }
        /// <summary>
        /// ������˻�������
        /// </summary>
        /// <param name="p_FormID"></param>
        /// <param name="p_Type"></param>
        /// <param name="sqlTrans"></param>
        private void SetCheckOperationTotal(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT ID,MainID,Seq FROM Finance_CheckOperationDts WHERE MainID=" + SysString.ToDBString(p_FormID);
            sql += " ORDER BY Seq";
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {

                    //���˵�
                    CheckOperation entity = new CheckOperation();
                    entity.ID = p_FormID;

                    ///���˵���ϸ
                    CheckOperationDts entityDts = new CheckOperationDts();
                    entityDts.ID = SysConvert.ToInt32(dr["ID"]);
                    entityDts.SelectByID();

                    ///�ֿⵥ����ϸ
                    IOForm entityIOF = new IOForm(sqlTrans);
                    entityIOF.ID = entityDts.DLOADID;
                    entityIOF.SelectByID();
                    if (entityDts.DLOADID > 0) ///����ֿ���������
                    {
                        if (entityIOF.SelectByID())
                        {
                        }
                        else
                        {
                            throw new Exception("�����쳣��û���ҵ�������¼ ID:" + entityDts.DLOADID);
                        }
                        if (p_Type == (int)YesOrNo.Yes)//�ύ
                        {
                            //if (entityIOF.DZFlag == (int)YesOrNo.Yes && entityIOF.Qty == entityDts.DCheckQty)
                            //{
                            //    throw new Exception("���ܲ����������Ѷ��� ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                            //}

                            ///�������ݵ�������ϸ���У��������������˽����˵��ۡ����˱�־�����˵����������ڡ����˵���               
                            ///
                            sql = "UPDATE WH_IOForm SET DZQty=ISNULL(DZQty,0)+(" + SysString.ToDBString(entityDts.DCheckQty) + ")";
                            sql += ",DZAmount=ISNULL(DZAmount,0)+(" + SysString.ToDBString(entityDts.DCheckAmount) + ")";
                            sql += ",DZSinglePrice=" + SysString.ToDBString(entityDts.DCheckSinglePrice);
                            sql += ",DZFlag=1";
                            sql += ",DZOPID=" + SysString.ToDBString(entity.SaleOPID);
                            sql += ",DZTime=GetDate()";
                            sql += ",DZNo=" + SysString.ToDBString(entity.FormNo);
                            sql += " WHERE ID=" + SysString.ToDBString(entityIOF.ID);
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                        else//�����ύ
                        {
                            //if (entityIOF.InvoiceQty != 0 && entityIOF.Qty == entityDts.DCheckQty)
                            //{
                            //    throw new Exception("���ܲ������������п�Ʊ���� ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                            //}

                            sql = "UPDATE WH_IOForm SET DZQty=ISNULL(DZQty,0)-(" + SysString.ToDBString(entityDts.DCheckQty) + ")";
                            sql += ",DZAmount=ISNULL(DZAmount,0)-(" + SysString.ToDBString(entityDts.DCheckAmount) + ")";
                            sql += ",DZSinglePrice=NULL";
                            if (entityIOF.DZQty == entityDts.DCheckQty)
                            {
                                sql += ",DZFlag=0";
                            }
                            sql += ",DZOPID=''";
                            sql += ",DZTime=NULL";
                            sql += ",DZNo=''";
                            sql += " WHERE ID=" + SysString.ToDBString(entityIOF.ID);
                            sqlTrans.ExecuteNonQuery(sql);

                        }

                    }
                }
            }
        }
        
    
    
        #endregion

        #region  ���ӱ��淽��
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2,BaseEntity[] p_BE3,BaseEntity[] p_BE4)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, p_BE3, p_BE4,sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2,BaseEntity[] p_BE3,BaseEntity[] p_BE4,IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                CheckOperationDtsRule ruledts = new CheckOperationDtsRule();
                ruledts.RSave((CheckOperation)p_BE, p_BE2, p_BE3, p_BE4,sqlTrans);//����ӱ�


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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, BaseEntity[] p_BE4)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2,p_BE3,p_BE4, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2,BaseEntity[] p_BE3,BaseEntity[] p_BE4, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                CheckOperationDtsRule ruledts = new CheckOperationDtsRule();
                ruledts.RSave((CheckOperation)p_BE, p_BE2, p_BE3, p_BE4,sqlTrans);//����ӱ�
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
