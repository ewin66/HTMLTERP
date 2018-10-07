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
	/// Ŀ�ģ�Finance_InvoiceOperationʵ��ҵ�������
	/// ����:������
	/// ��������:2012/5/8
	/// </summary>
	public class InvoiceOperationRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public InvoiceOperationRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			InvoiceOperation entity=(InvoiceOperation)p_BE;
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
            InvoiceOperation entity = (InvoiceOperation)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, "Finance_InvoiceOperation", SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Finance_InvoiceOperationDts WHERE 1=1";
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
        public DataTable RShowPay(string p_condition)
        {
            try
            {
                return RShowPay(p_condition, "*");
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
        public DataTable RShowPay(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_Finance_InvoiceOperation WHERE 1=1";
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



        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        public void RHX(InvoiceOperation entity, InvoiceOperationDts entityDts)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RHX(entity, entityDts, sqlTrans);

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
        /// ��������
        /// </summary>
        public void RHX(InvoiceOperation entity, InvoiceOperationDts entityDts, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                //First ����Ʊ��������
                InvoiceOperation entityinvoice = new InvoiceOperation(sqlTrans);//�����ո�����������
                entityinvoice.ID = entity.ID;
                entityinvoice.SelectByID();

                if (entityinvoice.PreHXAmount + entityDts.DInvoiceAmount > entityinvoice.TotalAmount)
                {
                    throw new Exception("���ܲ��������������˿�Ʊδ�˽��");
                }
                if (entityinvoice.PreHXQty + entityDts.DInvoiceQty > entityinvoice.TotalQty)
                {
                    throw new Exception("���ܲ������������������˿�Ʊδ������");
                }
                if (entityinvoice.PreHXAmount + entityDts.DInvoiceAmount == entityinvoice.TotalAmount)
                {
                    entityinvoice.PreHXFlag = (int)YesOrNo.Yes;
                }
                entityinvoice.PreHXQty += entityDts.DInvoiceQty;
                entityinvoice.PreHXAmount += entityDts.DInvoiceAmount;
                this.RUpdate(entityinvoice, sqlTrans);


                //Second

                IOFormDtsRule ioformdtsRule = new IOFormDtsRule();//�������ⵥ����ϸ����
                IOFormDts entityIOF = new IOFormDts(sqlTrans);//����ⵥ����ϸ
                entityIOF.ID = entityDts.DLOADDtsID;
                entityIOF.SelectByID();

                if (entityIOF.DtsInvoiceDelFlag == (int)YesOrNo.Yes)
                {
                    throw new Exception("���ܲ����������ѿ�Ʊ���� ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                }
                if (entityDts.DInvoiceQty + entityIOF.InvoiceQty > entityIOF.DZQty || entityDts.DInvoiceAmount + entityIOF.InvoiceAmount > entityIOF.DZAmount)//��Ʊ���
                {
                    throw new Exception("���ܲ�������Ʊ������������ �� ��Ʊ�������˽�� ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                }

                sql = "UPDATE WH_IOFormDts SET InvoiceQty=ISNULL(InvoiceQty,0)+" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)+" + "(" + SysString.ToDBString(entityDts.DInvoiceAmount) + ")";
                sql += ",DtsInvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                sql += ",DtsInvoiceDelTime=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                sql += ",DtsInvoiceNo=" + SysString.ToDBString(entity.InvoiceNO);
                if (entityDts.DInvoiceAmount + entityIOF.InvoiceAmount >= entityIOF.DZAmount)//��Ʊ���
                {
                    sql += ",DtsInvoiceDelFlag=1";
                }
                else
                {
                    sql += ",DtsInvoiceDelFlag=0";
                }
                sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
                sqlTrans.ExecuteNonQuery(sql);


                InvoiceOperationDtsRule dtsRule = new InvoiceOperationDtsRule();
                entityDts.MainID = entity.ID;
                entityDts.Seq = SysConvert.ToInt32(sqlTrans.Fill("SELECT ISNULL(MAX(Seq),0)+1 FROM Finance_InvoiceOperationDts WHERE MainID="+entity.ID).Rows[0][0]);//ȡ����MAXSEQֵ

                dtsRule.RAdd(entityDts, sqlTrans);

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

        #region ������������
        /// <summary>
        /// ������������
        /// </summary>
        public void RHXCancel(InvoiceOperation entity, int p_DtsID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RHXCancel(entity, p_DtsID, sqlTrans);
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
        /// ������������
        /// </summary>
        public void RHXCancel(InvoiceOperation entity, int p_DtsID, IDBTransAccess sqlTrans)
        {
            try
            {

                string sql = string.Empty;
                //First ����Ʊ��������
                InvoiceOperation entityinvoice = new InvoiceOperation(sqlTrans);//�����ո�����������
                entityinvoice.ID = entity.ID;
                entityinvoice.SelectByID();


                //Second ɾ����Ʊ������ϸ����
                InvoiceOperationDtsRule dtsRule = new InvoiceOperationDtsRule();
                InvoiceOperationDts entityDts = new InvoiceOperationDts(sqlTrans);
                entityDts.ID = p_DtsID;
                entityDts.SelectByID();
                if (entityDts.PayAmount != 0)
                {
                    throw new Exception("���ܲ������������ո��������ˣ����ܽ��г���");
                }

                dtsRule.RDelete(entityDts, sqlTrans);//ɾ����ϸʵ��


                //First ����Ʊ��������
                entityinvoice.PreHXFlag = (int)YesOrNo.No;
                entityinvoice.PreHXQty -= entityDts.DInvoiceQty;
                entityinvoice.PreHXAmount -= entityDts.DInvoiceAmount;
                this.RUpdate(entityinvoice, sqlTrans);



                IOFormDtsRule ioformdtsRule = new IOFormDtsRule();//�������ⵥ����ϸ����
                IOFormDts entityIOF = new IOFormDts(sqlTrans);//����ⵥ����ϸ
                entityIOF.ID = entityDts.DLOADDtsID;
                entityIOF.SelectByID();
                //����Ʊ��ϸ����;�������ϸ����
                if (entityIOF.PayAmount != 0)
                {
                    throw new Exception("���ܲ��������������ո������� ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                }

                sql = "UPDATE WH_IOFormDts SET InvoiceQty=ISNULL(InvoiceQty,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceAmount) + ")";
                sql += ",DtsInvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                sql += ",DtsInvoiceDelTime=null";
                sql += ",DtsInvoiceNo=''";
                sql += ",DtsInvoiceDelFlag=0";//��Ʊ��ɱ�־
                sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
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
        }
        #endregion
        
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
                InvoiceOperationDtsRule ruledts = new InvoiceOperationDtsRule();
                ruledts.RSave((InvoiceOperation)p_BE, p_BE2, sqlTrans);//����ӱ�


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
                InvoiceOperationDtsRule ruledts = new InvoiceOperationDtsRule();
                ruledts.RSave((InvoiceOperation)p_BE, p_BE2, sqlTrans);//����ӱ�
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

        #region  ���ӱ��淽��2
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2,p_BE3, sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2,BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                InvoiceOperationDtsRule ruledts = new InvoiceOperationDtsRule();
                ruledts.RSave2((InvoiceOperation)p_BE, p_BE2,p_BE3, sqlTrans);//����ӱ�


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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2,p_BE3, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                InvoiceOperationDtsRule ruledts = new InvoiceOperationDtsRule();
                ruledts.RSave2((InvoiceOperation)p_BE, p_BE2, p_BE3, sqlTrans);//����ӱ�
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
				InvoiceOperation entity=(InvoiceOperation)p_BE;
                string sql = "SELECT FormNo FROM Finance_InvoiceOperation WHERE FormNo="+SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�����Ѵ��ڣ�����������");
                }
                if (entity.InvoiceNO != "")
                {
                    sql = "SELECT ID FROM Finance_InvoiceOperation WHERE InvoiceNO=" + SysString.ToDBString(entity.InvoiceNO);
                    dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        throw new BaseException("��Ʊ���Ѵ��ڣ�����������");
                    }
                }

				InvoiceOperationCtl control=new InvoiceOperationCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Finance_InvoiceOperation,sqlTrans);
				control.AddNew(entity);

                FormNoControlRule rulest = new FormNoControlRule();
                if (entity.DZTypeID == 3)
                {
                    rulest.RAddSort((int)FormNoControlEnum.��Ʊ����, sqlTrans);
                }
                else
                {
                    rulest.RAddSort((int)FormNoControlEnum.��Ʊ����2, sqlTrans);
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
				InvoiceOperation entity=(InvoiceOperation)p_BE;
                string sql = "SELECT FormNo FROM Finance_InvoiceOperation WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                sql += " AND ID<>"+entity.ID;
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�����Ѵ��ڣ��쳣����������ϵ����Ա���");
                }

                //sql = "SELECT ID FROM Finance_InvoiceOperation WHERE InvoiceNO=" + SysString.ToDBString(entity.InvoiceNO);
                //sql += " AND ID<>" + entity.ID;
                //dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count > 0)
                //{
                //    throw new BaseException("��Ʊ���Ѵ��ڣ�����������");
                //}

				InvoiceOperationCtl control=new InvoiceOperationCtl(sqlTrans);				
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
				InvoiceOperation entity=(InvoiceOperation)p_BE;				
				InvoiceOperationCtl control=new InvoiceOperationCtl(sqlTrans);
				
				
                string sql = "DELETE FROM Finance_InvoiceOperationDts WHERE MainID=" + entity.ID.ToString();
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
                InvoiceOperation entity = new InvoiceOperation(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//�����ͬ�쳣
                {
                    throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
                }

                //����״̬
                sql = "UPDATE  Finance_InvoiceOperation SET SubmitFlag=" + SysString.ToDBString(p_Type);
                sql += " WHERE ID="+SysString.ToDBString(p_FormID);
                sqlTrans.ExecuteNonQuery(sql);

                
                SetInvoiceOperation(p_FormID, p_Type, sqlTrans);//�ύ����
                //switch (p_Type)
                //{
                //    case 1://�ύ
                //        break;
                //    case 0://�����ύ
                //        SetCancelInvoiceOperation(p_FormID, p_Type, sqlTrans);
                //        break;

                //}







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
        /// <param name="p_FormID"></param>
        /// <param name="p_Type"></param>
        /// <param name="sqlTrans"></param>
        private void SetInvoiceOperation(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT ID,MainID,Seq FROM Finance_InvoiceOperationDts WHERE MainID=" + SysString.ToDBString(p_FormID);
            sql += " ORDER BY Seq";
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    //���˵�
                    InvoiceOperation entity = new InvoiceOperation(sqlTrans);
                    entity.ID = p_FormID;
                    entity.SelectByID();

                    ///���˵���ϸ
                    InvoiceOperationDts entityDts = new InvoiceOperationDts(sqlTrans);
                    entityDts.ID = SysConvert.ToInt32(dr["ID"]);
                    entityDts.SelectByID();
                    
                    ///�ֿⵥ����ϸ
                    IOFormDts entityIOF = new IOFormDts(sqlTrans);
                    if (entityDts.MergeFlage == 1)
                    {
                        if (entityDts.DLOADID > 0)
                        {
                            IOForm entityNoDts = new IOForm(sqlTrans);
                            entityNoDts.ID = entityDts.DLOADID;
                            entityNoDts.SelectByID();
                            if (entityNoDts.SelectByID())
                            {
                            }
                            else
                            {
                                throw new Exception("�����쳣��û���ҵ�������¼ ID:" + entityDts.DLOADID);
                            }
                            if (p_Type == (int)YesOrNo.Yes)//�ύ
                            {

                                //if (entityDts.DInvoiceQty + entityIOF.InvoiceQty > entityIOF.DZQty || entityDts.DInvoiceAmount + entityIOF.InvoiceAmount > entityIOF.DZAmount)//��Ʊ���
                                //{
                                //    throw new Exception("���ܲ�������Ʊ������������ �� ��Ʊ�������˽�� ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                                //}
                                if (entityNoDts.InvoiceDelFlag == (int)YesOrNo.Yes && entityNoDts.TotalQty == entityNoDts.InvoiceQty)
                                {
                                    throw new Exception("���ܲ����������ѿ�Ʊ���� ID:" + entityDts.DLOADID);
                                    //+ " " + SysConvert.ToString(drs["ItemCode"]) + " " + SysConvert.ToString(drs["ColorNum"])
                                }
                                sql = "UPDATE WH_IOForm SET InvoiceQty=ISNULL(InvoiceQty,0)+" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)+" + "(" + SysString.ToDBString(SysConvert.ToDecimal(entityDts.DInvoiceAmount)) + ")";
                                sql += ",InvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                                sql += ",InvoiceDelTime=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                                sql += ",InvoiceNo=" + SysString.ToDBString(entity.InvoiceNO);
                                if (entityDts.DInvoiceAmount +  entityNoDts.InvoiceAmount >= entityNoDts.DZAmount)//��Ʊ���
                                {
                                    sql += ",InvoiceDelFlag=1";
                                }
                                else
                                {
                                    sql += ",InvoiceDelFlag=0";
                                }
                                sql += " WHERE ID=" + SysString.ToDBString(entityNoDts.ID);
                                sqlTrans.ExecuteNonQuery(sql);

                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=1 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }
                            else//�����ύ
                            {


                                if (entityNoDts.PayAmount != 0)
                                {
                                    throw new Exception("���ܲ��������������ո������� ID:" + entityDts.DLOADID);
                                }
                                sql = "UPDATE WH_IOForm SET InvoiceQty=ISNULL(InvoiceQty,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceAmount) + ")";
                                sql += ",InvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                                sql += ",InvoiceDelTime=null";
                                sql += ",InvoiceNo=''";
                                if (entityNoDts.InvoiceQty == entityDts.DInvoiceQty)
                                {
                                    sql += ",InvoiceDelFlag=0";//��Ʊ��ɱ�־
                                }
                                sql += " WHERE ID=" + SysString.ToDBString(entityNoDts.ID);
                                sqlTrans.ExecuteNonQuery(sql);

                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=0 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }

                            }
                        }
                        else
                        {

                            if (p_Type == (int)YesOrNo.Yes)//�ύ
                            {
                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=1 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }
                            else
                            {
                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=0 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }

                        }
                    }
                    else
                    {
                        entityIOF.ID = entityDts.DLOADDtsID;
                        if (entityDts.DLOADDtsID > 0)
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
                                if (entityIOF.DtsInvoiceDelFlag == (int)YesOrNo.Yes && entityIOF.Qty == entityIOF.InvoiceQty)
                                {
                                    throw new Exception("���ܲ����������ѿ�Ʊ���� ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                                }
                                //if (entityDts.DInvoiceQty + entityIOF.InvoiceQty > entityIOF.DZQty || entityDts.DInvoiceAmount + entityIOF.InvoiceAmount > entityIOF.DZAmount)//��Ʊ���
                                //{
                                //    throw new Exception("���ܲ�������Ʊ������������ �� ��Ʊ�������˽�� ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                                //}

                                sql = "UPDATE WH_IOFormDts SET InvoiceQty=ISNULL(InvoiceQty,0)+" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)+" + "(" + SysString.ToDBString(entityDts.DInvoiceAmount) + ")";
                                sql += ",DtsInvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                                sql += ",DtsInvoiceDelTime=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                                sql += ",DtsInvoiceNo=" + SysString.ToDBString(entity.InvoiceNO);
                                if (entityDts.DInvoiceAmount + entityIOF.InvoiceAmount >= entityIOF.DZAmount)//��Ʊ���
                                {
                                    sql += ",DtsInvoiceDelFlag=1";
                                }
                                else
                                {
                                    sql += ",DtsInvoiceDelFlag=0";
                                }
                                sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
                                sqlTrans.ExecuteNonQuery(sql);

                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=1 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }
                            else//�����ύ
                            {
                                if (entityIOF.PayAmount != 0)
                                {
                                    throw new Exception("���ܲ��������������ո������� ID:" + entityDts.DLOADDtsID + " " + entityIOF.ItemCode + " " + entityIOF.ColorNum);
                                }

                                sql = "UPDATE WH_IOFormDts SET InvoiceQty=ISNULL(InvoiceQty,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceQty) + ")";
                                sql += ",InvoiceAmount=ISNULL(InvoiceAmount,0)-" + "(" + SysString.ToDBString(entityDts.DInvoiceAmount) + ")";
                                sql += ",DtsInvoiceDelOPID=" + SysString.ToDBString(entity.SaleOPID);
                                sql += ",DtsInvoiceDelTime=null";
                                sql += ",DtsInvoiceNo=''";
                                if (entityIOF.InvoiceQty == entityDts.DInvoiceQty)
                                {
                                    sql += ",DtsInvoiceDelFlag=0";//��Ʊ��ɱ�־
                                }
                                sql += " WHERE ID=" + SysString.ToDBString(entityDts.DLOADDtsID);
                                sqlTrans.ExecuteNonQuery(sql);

                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=0 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }
                        }
                        else
                        {

                            if (p_Type == (int)YesOrNo.Yes)//�ύ
                            {
                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=1 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }
                            else
                            {
                                if (entityDts.DLoadCheckDtsID > 0)
                                {
                                    sql = "UPDATE Finance_CheckOperationDts SET InvoiceFlag=0 WHERE ID=" + SysString.ToDBString(entityDts.DLoadCheckDtsID);
                                    sqlTrans.ExecuteNonQuery(sql);
                                }
                            }

                        }
                    }
                }
            }
        }
        #endregion

        #region 
        
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd2(BaseEntity p_BE,BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd2(p_BE,p_BE2, sqlTrans);

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
        public void RAdd2(BaseEntity p_BE,BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                InvoiceOperation entity = (InvoiceOperation)p_BE;
                string sql = "SELECT FormNo FROM Finance_InvoiceOperation WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�����Ѵ��ڣ�����������");
                }

                if (entity.InvoiceNO != "")
                {
                    sql = "SELECT ID FROM Finance_InvoiceOperation WHERE InvoiceNO=" + SysString.ToDBString(entity.InvoiceNO);
                    dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        throw new BaseException("��Ʊ���Ѵ��ڣ�����������");
                    }
                }

                InvoiceOperationCtl control = new InvoiceOperationCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Finance_InvoiceOperation, sqlTrans);
                control.AddNew(entity);

                for (int i = 0; i < p_BE2.Length; i++)
                {
                    InvoiceYOperationDtsRule rule = new InvoiceYOperationDtsRule();
                    InvoiceYOperationDts entityDts = (InvoiceYOperationDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts, sqlTrans);
                }

                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.��Ʊ����, sqlTrans);
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
        public void RUpdate2(BaseEntity p_BE,BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate2(p_BE,p_BE2, sqlTrans);

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
        public void RUpdate2(BaseEntity p_BE,BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                InvoiceOperation entity = (InvoiceOperation)p_BE;
                string sql = "SELECT FormNo FROM Finance_InvoiceOperation WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                sql += " AND ID<>" + entity.ID;
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�����Ѵ��ڣ��쳣����������ϵ����Ա���");
                }

                if (entity.InvoiceNO != "")
                {
                    sql = "SELECT ID FROM Finance_InvoiceOperation WHERE InvoiceNO=" + SysString.ToDBString(entity.InvoiceNO);
                    sql += " AND ID<>" + entity.ID;
                    dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        throw new BaseException("��Ʊ���Ѵ��ڣ�����������");
                    }
                }

                

                InvoiceOperationCtl control = new InvoiceOperationCtl(sqlTrans);
                control.Update(entity);

                sql = "DELETE Finance_InvoiceYOperationDts WHERE MainID="+SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    InvoiceYOperationDtsRule rule = new InvoiceYOperationDtsRule();
                    InvoiceYOperationDts entityDts = (InvoiceYOperationDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts, sqlTrans);
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
