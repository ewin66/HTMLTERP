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
	/// Ŀ�ģ�Finance_RecPayʵ��ҵ�������
	/// ����:�ܸ���
	/// ��������:2012-5-22
	/// </summary>
	public class RecPayRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public RecPayRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			RecPay entity=(RecPay)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Finance_RecPay WHERE 1=1";
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


        #region �������ۺ�ͬ���ع�����Ϣ
        #endregion



        #region ���ݲɹ���ͬ���ع�����Ϣ
        #endregion

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        public void RHX(RecPay entity,int p_InvoiceID,decimal p_HXAmount)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RHX(entity, p_InvoiceID, p_HXAmount, sqlTrans);

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
        public void RHX(RecPay entity, int p_InvoiceID, decimal p_HXAmount, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                //First �����ո�����������
                RecPay entitypay=new RecPay(sqlTrans);//�����ո�����������
                entitypay.ID=entity.ID;
                entitypay.SelectByID();

                if (entitypay.HXAmount + p_HXAmount > entitypay.ExAmount)
                {
                    throw new Exception("���ܲ��������������˸���δ�˽��");
                }
                if (entitypay.HXAmount + p_HXAmount == entitypay.ExAmount)
                {
                    entitypay.HXFlag = (int)YesOrNo.Yes;
                }
                entitypay.HXAmount += p_HXAmount;
                entitypay.NoHXAmount = entitypay.ExAmount - entitypay.HXAmount;
                this.RUpdate(entitypay, sqlTrans);


                //Second
                InvoiceOperationRule invoicerule = new InvoiceOperationRule();//����Ʊ��������
                InvoiceOperation invoiceentity=new InvoiceOperation(sqlTrans);//��Ʊʵ��
                invoiceentity.ID=p_InvoiceID;
                invoiceentity.SelectByID();
                if (invoiceentity.PayAmount + p_HXAmount > invoiceentity.TotalAmount)
                {
                    throw new Exception("���ܲ��������������˷�Ʊδ�˽��");
                }
                invoiceentity.PayAmount += p_HXAmount;
                invoicerule.RUpdate(invoiceentity, sqlTrans);
                
                

                //Third ���Ӹ��������ϸ����
                RecPayHXDtsRule dtsRule = new RecPayHXDtsRule();
                RecPayHXDts dtsentity = new RecPayHXDts(sqlTrans);
                dtsentity.MainID = entity.ID;
                dtsentity.HXOPID = entity.MakeOPID;
                dtsentity.HXOPName = entity.MakeOPName;
                dtsentity.HXDate = DateTime.Now;
                dtsentity.HXAmount = p_HXAmount;
                dtsentity.InvoiceNo = invoiceentity.InvoiceNO;
                dtsentity.InvoiceOperationID = p_InvoiceID;
                dtsRule.RAdd(dtsentity, sqlTrans);//������ϸʵ��
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
        public void RHXCancel(RecPay entity, int p_DtsID)
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
        public void RHXCancel(RecPay entity, int p_DtsID, IDBTransAccess sqlTrans)
        {
            try
            {

                string sql = string.Empty;
                //First �����ո�����������
                RecPay entitypay = new RecPay(sqlTrans);//�����ո�����������
                entitypay.ID = entity.ID;
                entitypay.SelectByID();

                //Second ɾ�����������ϸ����
                RecPayHXDtsRule dtsRule = new RecPayHXDtsRule();
                RecPayHXDts dtsentity = new RecPayHXDts(sqlTrans);
                dtsentity.ID = p_DtsID;
                dtsentity.SelectByID();
                dtsRule.RDelete(dtsentity, sqlTrans);//ɾ����ϸʵ��


                //First �����ո�����������
                entitypay.HXFlag = (int)YesOrNo.No;
                entitypay.HXAmount -= dtsentity.HXAmount;
                entitypay.NoHXAmount = entitypay.ExAmount - entitypay.HXAmount;
                this.RUpdate(entitypay, sqlTrans);


                //Third ����Ʊ��������
                InvoiceOperationRule invoicerule = new InvoiceOperationRule();//����Ʊ��������
                InvoiceOperation invoiceentity = new InvoiceOperation(sqlTrans);//��Ʊʵ��
                invoiceentity.ID = dtsentity.InvoiceOperationID;
                invoiceentity.SelectByID();

                invoiceentity.PayAmount -= dtsentity.HXAmount;
                if (invoiceentity.PayAmount < 0)
                {
                    throw new BaseException("�����������������飬��Ʊ�ĺ������С��0");
                }
                invoicerule.RUpdate(invoiceentity, sqlTrans);

               
              


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


        #region ��ͬ��������
        ///// <summary>
        ///// ��ͬ��������
        ///// </summary>
        //public void RHT(RecPay entity, string p_HTNo, decimal p_HTAmount, int p_HTTypeID)
        //{
        //    try
        //    {
        //        IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
        //        try
        //        {
        //            sqlTrans.OpenTrans();

        //            this.RHT(entity, p_HTNo, p_HTAmount, p_HTTypeID, sqlTrans);

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
        ///// ��ͬ��������
        ///// </summary>
        //public void RHT(RecPay entity, string p_HTNo, decimal p_HTAmount,int p_HTTypeID, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {
        //        string sql = string.Empty;
        //        //First �����ո�����������
        //        RecPay entitypay = new RecPay(sqlTrans);//�����ո�����������
        //        entitypay.ID = entity.ID;
        //        entitypay.SelectByID();

        //        if (entitypay.HTAmount + p_HTAmount > entitypay.ExAmount)
        //        {
        //            throw new Exception("���ܲ�����������ͬ�����˸�����");
        //        }
        //        if (entitypay.HTAmount + p_HTAmount == entitypay.ExAmount)
        //        {
        //            entitypay.HTFlag = (int)YesOrNo.Yes;
        //        }
        //        entitypay.HTAmount += p_HTAmount;
        //        if (entitypay.HTNo == string.Empty || entitypay.HTNo.IndexOf(" "+p_HTNo) == -1)
        //        {
        //            if (entitypay.HTNo != string.Empty)//���ͬ����
        //            {
        //                entitypay.HTNo += " ";
        //            }
        //            entitypay.HTNo += p_HTNo;
        //        }
        //        this.RUpdate(entitypay, sqlTrans);



        //        //Second ���Ӹ����ͬ��ϸ����
        //        RecPayHTDtsRule dtsRule = new RecPayHTDtsRule();
        //        RecPayHTDts dtsentity = new RecPayHTDts(sqlTrans);
        //        dtsentity.MainID = entity.ID;
        //        dtsentity.HTOPID = entity.MakeOPID;
        //        dtsentity.HTOPName = entity.MakeOPName;
        //        dtsentity.HTDate = DateTime.Now;
        //        dtsentity.HTAmount = p_HTAmount;
        //        dtsentity.HTNo = p_HTNo;
        //        dtsentity.HTTypeID = p_HTTypeID;
        //        dtsRule.RAdd(dtsentity, sqlTrans);//������ϸʵ��

              
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



        #endregion

        #region ��ͬ��������-����ItemCode
        /// <summary>
        /// ��ͬ��������
        /// </summary>
        public void RHT(RecPay entity, string p_HTNo,string p_HTItemCode,string p_HTGoodsCode, decimal p_HTAmount, int p_HTTypeID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RHT(entity, p_HTNo,p_HTItemCode,p_HTGoodsCode, p_HTAmount, p_HTTypeID, sqlTrans);

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
        /// ��ͬ��������
        /// </summary>
        public void RHT(RecPay entity, string p_HTNo,string p_HTItemCode,string p_HTGoodsCode, decimal p_HTAmount, int p_HTTypeID, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                //First �����ո�����������
                RecPay entitypay = new RecPay(sqlTrans);//�����ո�����������
                entitypay.ID = entity.ID;
                entitypay.SelectByID();

                if (entitypay.HTAmount + p_HTAmount > entitypay.ExAmount)
                {
                    throw new Exception("���ܲ�����������ͬ�������ո�����");
                }
                if (entitypay.HTAmount + p_HTAmount == entitypay.ExAmount)
                {
                    entitypay.HTFlag = (int)YesOrNo.Yes;
                }
                entitypay.HTAmount += p_HTAmount;
                if (entitypay.HTNo == string.Empty || entitypay.HTNo.IndexOf(" " + p_HTNo) == -1)
                {
                    if (entitypay.HTNo != string.Empty)//���ͬ����
                    {
                        entitypay.HTNo += " ";
                    }
                    entitypay.HTNo += p_HTNo;
                }
                if (entitypay.HTGoodsCode == string.Empty || entitypay.HTGoodsCode.IndexOf(" " + p_HTGoodsCode) == -1)
                {
                    if (entitypay.HTGoodsCode != string.Empty)//���ͬ����
                    {
                        entitypay.HTGoodsCode += " ";
                    }
                    entitypay.HTGoodsCode += p_HTGoodsCode;
                }
                this.RUpdate(entitypay, sqlTrans);



                //Second ���Ӹ����ͬ��ϸ����
                RecPayHTDtsRule dtsRule = new RecPayHTDtsRule();
                RecPayHTDts dtsentity = new RecPayHTDts(sqlTrans);
                dtsentity.MainID = entity.ID;
                dtsentity.HTOPID = entity.MakeOPID;
                dtsentity.HTOPName = entity.MakeOPName;
                dtsentity.HTDate = DateTime.Now;
                dtsentity.HTAmount = p_HTAmount;
                dtsentity.HTNo = p_HTNo;
                dtsentity.HTGoodsCode = p_HTGoodsCode;
                dtsentity.HTTypeID = p_HTTypeID;
                dtsentity.HTItemCode = p_HTItemCode;
                dtsRule.RAdd(dtsentity, sqlTrans);//������ϸʵ��

                //�������ɹ����������ۺ�ͬ�ʽ�ʵ��ִ�б�
                if (p_HTTypeID == (int)EnumRecPayType.�տ�)
                {
                    SaleOrderCapExDtsRule capRule = new SaleOrderCapExDtsRule();
                    capRule.RHT(entitypay, dtsentity, sqlTrans);
                }
                else if (p_HTTypeID == (int)EnumRecPayType.����)
                {
                    ItemBuyCapExDtsRule capRule = new ItemBuyCapExDtsRule();
                    capRule.RHT(entitypay,dtsentity, sqlTrans);
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

        #region ������ͬ��������
        /// <summary>
        /// ������ͬ��������
        /// </summary>
        public void RHTCancel(RecPay entity, int p_DtsID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RHTCancel(entity, p_DtsID, sqlTrans);
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
        /// ������ͬ��������
        /// </summary>
        public void RHTCancel(RecPay entity, int p_DtsID, IDBTransAccess sqlTrans)
        {
            try
            {

                string sql = string.Empty;
                //First �����ո�����������
                RecPay entitypay = new RecPay(sqlTrans);//�����ո�����������
                entitypay.ID = entity.ID;
                entitypay.SelectByID();

                //Second ɾ�����������ϸ����
                RecPayHTDtsRule dtsRule = new RecPayHTDtsRule();
                RecPayHTDts dtsentity = new RecPayHTDts(sqlTrans);
                dtsentity.ID = p_DtsID;
                dtsentity.SelectByID();
                dtsRule.RDelete(dtsentity, sqlTrans);//ɾ����ϸʵ��


                //First �����ո�����������
                entitypay.HTFlag = (int)YesOrNo.No;
                entitypay.HTAmount -= dtsentity.HTAmount;
                entitypay.HTNo=entitypay.HTNo.Replace(dtsentity.HTNo, "").Replace(" " + dtsentity.HTNo, "");//�滻��ͬ��
                if (entitypay.HTGoodsCode != "")
                {
                    entitypay.HTGoodsCode = entitypay.HTGoodsCode.Replace(dtsentity.HTGoodsCode, "").Replace(" " + dtsentity.HTGoodsCode, "");//�滻��Ʒ��
                }
                this.RUpdate(entitypay, sqlTrans);

                //�������ɹ����������ۺ�ͬ�ʽ�ʵ��ִ�б�
                if (dtsentity.HTTypeID == (int)EnumRecPayType.�տ�)
                {
                    SaleOrderCapExDtsRule capRule = new SaleOrderCapExDtsRule();
                    capRule.RHTCancel(dtsentity, sqlTrans);
                }
                else if (dtsentity.HTTypeID == (int)EnumRecPayType.����)
                {
                    ItemBuyCapExDtsRule capRule = new ItemBuyCapExDtsRule();
                    capRule.RHTCancel(dtsentity, sqlTrans);
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
                RecPay entity = new RecPay(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//�����ͬ�쳣
                {
                    throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
                }
                if (entity.HXAmount != 0)
                {
                    throw new Exception("���������ֵ,���������");
                }

                if (entity.HTNo != string.Empty && entity.HTAmount!=0)
                {
                    throw new Exception("�й�����ͬ,���������");
                }

                //����״̬
                sql = "UPDATE Finance_RecPay SET SubmitFlag=" + SysString.ToDBString(p_Type) + " WHERE ID=" + p_FormID;
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
				RecPay entity=(RecPay)p_BE;
                string sql = "SELECT FormNo FROM Finance_RecPay WHERE FormNo="+SysString.ToDBString(entity.FormNo);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�����Ѵ��ڣ�����������");
                }
				RecPayCtl control=new RecPayCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Finance_RecPay,sqlTrans);
				control.AddNew(entity);
                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.�ո����,sqlTrans);
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
				RecPay entity=(RecPay)p_BE;				
				RecPayCtl control=new RecPayCtl(sqlTrans);				
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
				RecPay entity=(RecPay)p_BE;				
				RecPayCtl control=new RecPayCtl(sqlTrans);
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
                RecPayDtsRule ruledts = new RecPayDtsRule();
                ruledts.RSave((RecPay)p_BE, p_BE2, sqlTrans);//����ӱ�


                //RecPayHXDtsRule ruledts = new RecPayHXDtsRule();
                //ruledts.RSave((RecPay)p_BE, p_BE2, sqlTrans);//����ӱ�


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
                RecPayDtsRule ruledts = new RecPayDtsRule();
                ruledts.RSave((RecPay)p_BE, p_BE2, sqlTrans);//����ӱ�

                //RecPayHXDtsRule ruledts = new RecPayHXDtsRule();
                //ruledts.RSave((RecPay)p_BE, p_BE2, sqlTrans);//����ӱ�
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
