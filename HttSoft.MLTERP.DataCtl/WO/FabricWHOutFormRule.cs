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
	/// Ŀ�ģ�WO_FabricWHOutFormʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2014/5/4
	/// </summary>
	public class FabricWHOutFormRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public FabricWHOutFormRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			FabricWHOutForm entity=(FabricWHOutForm)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WO_FabricWHOutForm WHERE 1=1";
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

        #region ����¼��У��

        /// <summary>
        /// ����¼��У��
        /// </summary>
        /// <param name="p_MainID">����ID</param>
        public bool RAddCheck(int p_MainID,out string o_ErrorMSG)
        {
            bool outb = true;
            o_ErrorMSG=string.Empty;
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    outb=this.RAddCheck(p_MainID,out o_ErrorMSG ,sqlTrans);

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
            return outb;
        }

        /// <summary>
        /// ����¼��У��(����������)
        /// </summary>
        /// <param name="p_MainID">����ID</param>
        /// <param name="sqlTrans">������</param>
        public bool RAddCheck(int p_MainID,out string o_ErrorMSG, IDBTransAccess sqlTrans)
        {
            bool outb = true;
            o_ErrorMSG = string.Empty;
            try
            {

                string sql = "SELECT ID FROM WO_FabricWHOutForm WHERE MainID=" + SysString.ToDBString(p_MainID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    outb = false;
                    o_ErrorMSG = "���п��ϵ���������ִ�д˲���";
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

            return outb;
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
                FabricWHOutForm entity = new FabricWHOutForm(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();


                if (entity.SubmitFlag == p_Type)//�����ͬ�쳣
                {
                    throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
                }

                IOForm entitywh = new IOForm();
                if (p_Type == (int)YesOrNo.Yes)
                {
                    /*�����Զ����ⵥ���ύ*/
                    entitywh=RAutoCreateWHForm(entity, sqlTrans);
                }
                else
                {
                    /*�����ύ�Զ����ⵥ��ɾ��*/
                    RAutoDeleteWHForm(entity, sqlTrans);
                }

                /* ���¿��ϵ���״̬*/
                sql = "UPDATE WO_FabricWHOutForm SET SubmitFlag=" + SysString.ToDBString(p_Type);
                //if (p_Type == (int)ConfirmFlag.���ͨ�� || p_Type == (int)ConfirmFlag.��˾ܾ�)
                //{
                //    //sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                //}
                sql += ",AutoIOFormID=" + entitywh.ID;
                sql += ",AutoIOFormNo=" + SysString.ToDBString(entitywh.FormNo);
                sql += " WHERE ID=" + p_FormID.ToString();//���µ����������״̬
                sqlTrans.ExecuteNonQuery(sql);

                /*���¼ӹ����ݿ���״̬*/
                sql = "UPDATE WO_FabricProcess SET WHOutFormFlag=" + SysString.ToDBString(p_Type);              
                sql += " WHERE ID=" + entity.MainID.ToString();//���µ����������״̬
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


        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sqlTrans"></param>
        /// <returns></returns>
        IOForm RAutoCreateWHForm(FabricWHOutForm entity, IDBTransAccess sqlTrans)
        {
            IOForm entitywh = new IOForm(sqlTrans);
            FabricProcess entityjg = new FabricProcess(sqlTrans);
            entityjg.ID = entity.MainID;
            entityjg.SelectByID();

            #region ��ֵ����ⵥ����ʵ��
            /*��ֵ����ⵥ����ʵ�� Begin*/
            SaleProcedureRule rulesalePro = new SaleProcedureRule();
            int saleProcedureID = rulesalePro.GetSaleProcedureByWOTypeID(entityjg.ProcessTypeID);//�ӹ�ҵ�񵥾�����ID
            string sql = string.Empty;
            sql = "SELECT JGFormListID FROM Enum_SaleProcedure WHERE ID=" + saleProcedureID;
            DataTable dtSalePro = sqlTrans.Fill(sql);//���ñ�
            if (dtSalePro.Rows.Count != 0)
            {
                entitywh.SubType = SysConvert.ToInt32(dtSalePro.Rows[0]["JGFormListID"]);
                FormListRule ruleformlist = new FormListRule();
                entitywh.HeadType = ruleformlist.GetFormListIDBySubTypeID(entitywh.SubType, sqlTrans);
            }
            else
            {
                throw new Exception("ҵ�񵥾����������쳣");
            }
            entitywh.WHID = entity.WHID;
            entitywh.WHOP = ParamConfig.LoginName;
            entitywh.VendorID = entityjg.DyeFactorty;//�ӹ���
            entitywh.FormDate = DateTime.Now.Date;
            entitywh.WHType = entity.WHID;
            entitywh.SpecialNo = entity.FormNo;//Դ���ݺ�;�Զ����ϵĵ��ݺ�

            
            FormNoControlRule formconrule = new FormNoControlRule();
            entitywh.FormNo = formconrule.RGetWHFormNo(entitywh.SubType, "", sqlTrans);
            /*��ֵ����ⵥ����ʵ��End */
            #endregion


            #region ��ֵ����ⵥ����ϸʵ��
            /*��ֵ����ⵥ����ϸʵ�� Begin*/
            sql = "SELECT * FROM WO_FabricWHOutFormDts WHERE MainID=" + entity.ID ;
            DataTable dtDts = sqlTrans.Fill(sql);
            IOFormDts[] entityDtswh = new IOFormDts[dtDts.Rows.Count];

            if (dtDts.Rows.Count == 0)
            {
                throw new Exception("û��������ϸ����Ӧ�������ݱ���");
            }
            for (int i = 0; i < dtDts.Rows.Count; i++)
            {
                entityDtswh[i] = new IOFormDts();
                entityDtswh[i].Seq = i + 1;
                entityDtswh[i].WHID = dtDts.Rows[i]["WHID"].ToString();
                entityDtswh[i].SectionID = dtDts.Rows[i]["SectionID"].ToString();
                entityDtswh[i].SBitID = dtDts.Rows[i]["SBitID"].ToString();
                entityDtswh[i].ItemCode = dtDts.Rows[i]["ItemCode"].ToString();
                entityDtswh[i].ItemName = dtDts.Rows[i]["ItemName"].ToString();
                entityDtswh[i].ItemStd = dtDts.Rows[i]["ItemStd"].ToString();
                entityDtswh[i].ItemModel = dtDts.Rows[i]["ItemModel"].ToString();

                entityDtswh[i].Batch = dtDts.Rows[i]["Batch"].ToString();
                entityDtswh[i].VendorBatch = dtDts.Rows[i]["VendorBatch"].ToString();
                entityDtswh[i].ColorNum = dtDts.Rows[i]["ColorNum"].ToString();
                entityDtswh[i].ColorName = dtDts.Rows[i]["ColorName"].ToString();
                entityDtswh[i].JarNum = dtDts.Rows[i]["JarNum"].ToString();
                entityDtswh[i].PieceQty = SysConvert.ToInt32(dtDts.Rows[i]["PieceQty"]);
                entityDtswh[i].Remark = dtDts.Rows[i]["Remark"].ToString();
                entityDtswh[i].Qty = SysConvert.ToDecimal(dtDts.Rows[i]["Qty"]);
                entityDtswh[i].Unit = dtDts.Rows[i]["Unit"].ToString();
                entityDtswh[i].Weight = SysConvert.ToDecimal(dtDts.Rows[i]["Weight"]);
                entityDtswh[i].SinglePrice = SysConvert.ToDecimal(dtDts.Rows[i]["SinglePrice"]);
                entityDtswh[i].DYPrice = SysConvert.ToDecimal(dtDts.Rows[i]["DYPrice"]);
                entityDtswh[i].Amount = SysConvert.ToDecimal(dtDts.Rows[i]["Amount"]);
                entityDtswh[i].GoodsCode = dtDts.Rows[i]["GoodsCode"].ToString();
                entityDtswh[i].GoodsLevel = dtDts.Rows[i]["GoodsLevel"].ToString();

                entityDtswh[i].VColorNum = dtDts.Rows[i]["VColorNum"].ToString();
                entityDtswh[i].VColorName = dtDts.Rows[i]["VColorName"].ToString();
                entityDtswh[i].VItemCode = dtDts.Rows[i]["VItemCode"].ToString();
                entityDtswh[i].MWeight = dtDts.Rows[i]["MWeight"].ToString();
                entityDtswh[i].MWidth = dtDts.Rows[i]["MWidth"].ToString();
                entityDtswh[i].WeightUnit = dtDts.Rows[i]["WeightUnit"].ToString();
                entityDtswh[i].PackDts = dtDts.Rows[i]["PackDts"].ToString();
                //entityDtswh[i].DtsSO = dtDts.Rows[i]["DtsSO"].ToString();
                //entityDtswh[i].DtsOrderFormNo = dtDts.Rows[i]["DtsOrderFormNo"].ToString();
                entityDtswh[i].DtsInVendorID = dtDts.Rows[i]["DtsInVendorID"].ToString();
                entityDtswh[i].InSO = dtDts.Rows[i]["InSO"].ToString();
                entityDtswh[i].InOrderFormNo = dtDts.Rows[i]["InOrderFormNo"].ToString();
                entityDtswh[i].InSaleOPID = dtDts.Rows[i]["InSaleOPID"].ToString();
                entityDtswh[i].MLType = SysConvert.ToInt32(dtDts.Rows[i]["MLType"]);
                //entityDtswh[i].LoadDtsID = SysConvert.ToInt32(dtDts.Rows[i]["LoadDtsID"]);


                
                entityDtswh[i].LoadDtsID = SysConvert.ToInt32(dtDts.Rows[i]["ID"]);//��ϸ��ID
                entityDtswh[i].DtsSO = entityjg.FormNo;//��������
                entityDtswh[i].DtsOrderFormNo = dtDts.Rows[i]["DtsSO"].ToString();//������


            }
            
            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            for (int i = 0; i < entityDtswh.Length; i++)
            {
                TotalQty += SysConvert.ToDecimal(entityDtswh[i].Qty);
                TotalAmount += SysConvert.ToDecimal(entityDtswh[i].Amount);
            }
            entitywh.TotalQty = TotalQty;
            entitywh.TotalAmount = TotalAmount;
            /*��ֵ����ⵥ����ϸʵ�� End*/
            #endregion



            IOFormRule rulewh = new IOFormRule();
            rulewh.RAdd(entitywh, entityDtswh, sqlTrans);//������������
            #region �����������           
            
            /*��ֵ����ⵥ���뵥��ϸ���� Begin*/
            sql = "SELECT TOP 1 ID FROM WO_FabricWHOutFormDtsPack WHERE MainID=" + SysString.ToDBString(entity.ID);
            DataTable dtPackCheck = sqlTrans.Fill(sql);
            if (dtPackCheck.Rows.Count != 0)//������뵥��ϸ��ʾ��Ҫ�����뵥��ϸֵ
            {
                sql = "SELECT LoadDtsID,ID,Seq FROM WH_IOFormDts WHERE MainID=" + SysString.ToDBString(entitywh.ID);
                dtPackCheck = sqlTrans.Fill(sql);
                for (int i = 0; i < dtPackCheck.Rows.Count; i++)
                {
                    int LoadDtsID = SysConvert.ToInt32(dtPackCheck.Rows[i]["LoadDtsID"]);
                    int Seq = SysConvert.ToInt32(dtPackCheck.Rows[i]["Seq"]);
                    int ID = SysConvert.ToInt32(dtPackCheck.Rows[i]["ID"]);
                    int SubSeq = 1;
                    if (LoadDtsID > 0)
                    {
                        sql = "SELECT * FROM WO_FabricWHOutFormDtsPack WHERE DID=" + SysString.ToDBString(LoadDtsID);
                        DataTable dtfh = sqlTrans.Fill(sql);

                        for (int j = 0; j < dtfh.Rows.Count; j++)
                        {
                            IOFormDtsPackRule rulePack = new IOFormDtsPackRule();
                            IOFormDtsPack entityPack = new IOFormDtsPack();
                            entityPack.MainID = entitywh.ID;
                            entityPack.Seq = Seq;
                            entityPack.DID = ID;
                            entityPack.SubSeq = SubSeq;
                            entityPack.BoxNo = SysConvert.ToString(dtfh.Rows[j]["BoxNo"]);
                            entityPack.Remark = SysConvert.ToString(dtfh.Rows[j]["BoxNo"]);
                            entityPack.Qty = SysConvert.ToDecimal(dtfh.Rows[j]["Qty"]);
                            SubSeq++;
                            rulePack.RAdd(entityPack, sqlTrans);

                        }
                    }
                }
            }
            /*��ֵ����ⵥ���뵥��ϸ���� End*/
            #endregion

            rulewh.RSubmit(entitywh.ID, (int)YesOrNo.Yes, sqlTrans);//�ύ

            return entitywh;
        }

        /// <summary>
        /// �����ύ��ɾ������
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sqlTrans"></param>
        void RAutoDeleteWHForm(FabricWHOutForm entity, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;

            IOForm entitywh = new IOForm(sqlTrans);
            entitywh.ID = entity.AutoIOFormID;
            if (entitywh.SelectByID())
            {
                IOFormRule rulewh = new IOFormRule();
                rulewh.RSubmit(entitywh.ID, (int)YesOrNo.No, sqlTrans);
                rulewh.RDelete(entitywh, sqlTrans);
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

                FabricWHOutForm entity=(FabricWHOutForm)p_BE;
                string o_ErrorMSG=string.Empty;
                if (!RAddCheck(entity.MainID, out o_ErrorMSG, sqlTrans))
                {
                    throw new BaseException(o_ErrorMSG);
                }

                string sql = "SELECT FormNo FROM WO_FabricWHOutForm WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�����Ѵ��ڣ�����������");
                }

				FabricWHOutFormCtl control=new FabricWHOutFormCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.WO_FabricWHOutForm,sqlTrans);
				control.AddNew(entity);



                FormNoControlRule fnrule = new FormNoControlRule();
                fnrule.RAddSort("WO_FabricWHOutForm", "FormNo", sqlTrans);
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
				FabricWHOutForm entity=(FabricWHOutForm)p_BE;				
				FabricWHOutFormCtl control=new FabricWHOutFormCtl(sqlTrans);				
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
				FabricWHOutForm entity=(FabricWHOutForm)p_BE;				
				FabricWHOutFormCtl control=new FabricWHOutFormCtl(sqlTrans);
				control.Delete(entity);
                string sql = string.Empty;

                sql = "DELETE FROM WO_FabricWHOutFormDts WHERE MainID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);

                sql = "DELETE FROM WO_FabricWHOutFormDtsPack WHERE MainID=" + entity.ID;
                sqlTrans.ExecuteNonQuery(sql);
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

        #region �·���
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE,BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2,sqlTrans);

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
        public void RAdd(BaseEntity p_BE,BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                this.RAdd(p_BE, sqlTrans);

                FabricWHOutForm entity = (FabricWHOutForm)p_BE;
                //string sql = "DELETE WO_FabricWHOutFormDts WHERE MainID=" + SysString.ToDBString(entity.ID);
                //sqlTrans.ExecuteNonQuery(sql);

                FabricWHOutFormDtsRule rule = new FabricWHOutFormDtsRule();
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    FabricWHOutFormDts entityDts = (FabricWHOutFormDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts,sqlTrans);
                }

                //sql = "UPDATE WO_FabricProcess SET WHOutFormFlag=1 WHERE ID="+SysString.ToDBString(entity.MainID);
                //sqlTrans.ExecuteNonQuery(sql);
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

                    this.RUpdate(p_BE,p_BE2, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE,BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);

                this.RUpdate(p_BE, sqlTrans);


                FabricWHOutFormDtsRule ruledts = new FabricWHOutFormDtsRule();
                ruledts.RSave((FabricWHOutForm)p_BE, p_BE2, sqlTrans);//����ӱ�
                
                //string sql = "DELETE WO_FabricWHOutFormDts WHERE MainID="+SysString.ToDBString(entity.ID);
                //sqlTrans.ExecuteNonQuery(sql);

                //FabricWHOutFormDtsRule rule = new FabricWHOutFormDtsRule();
                //for (int i = 0; i < p_BE2.Length; i++)
                //{
                //    FabricWHOutFormDts entityDts = (FabricWHOutFormDts)p_BE2[i];
                //    entityDts.MainID = entity.ID;
                //    entityDts.Seq = i + 1;
                //    rule.RAdd(entityDts, sqlTrans);
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
                FabricWHOutFormDtsRule rule = new FabricWHOutFormDtsRule();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)//��һ�и���
                    {
                        sql = "SELECT * FROM WH_PackBox WHERE ID IN (" + p_IDStr + ")";
                        sql += " AND SectionID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["SectionID"]));
                        sql += " AND JarNum=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["JarNum"]));
                        sql += " AND Batch=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["Batch"]));
                        DataTable dtsql = sqlTrans.Fill(sql);

                        FabricWHOutFormDts entitydts = new FabricWHOutFormDts(sqlTrans);
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

                        FabricWHOutFormDtsPackRule prule = new FabricWHOutFormDtsPackRule();
                        sql = "DELETE WO_FabricWHOutFormDtsPack WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        sqlTrans.ExecuteNonQuery(sql);
                        for (int j = 0; j < dtsql.Rows.Count; j++)
                        {

                            FabricWHOutFormDtsPack pentity = new FabricWHOutFormDtsPack(sqlTrans);
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

                        FabricWHOutFormDts entitydts = new FabricWHOutFormDts(sqlTrans);
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

                        sql = "SELECT ID FROM WO_FabricWHOutFormDts WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        if (sqlTrans.Fill(sql).Rows.Count > 0)
                        {
                            throw new BaseException("�������У������Ѵ���");
                        }
                        rule.RAdd(entitydts, sqlTrans);


                        FabricWHOutFormDtsPackRule prule = new FabricWHOutFormDtsPackRule();
                        sql = "DELETE WO_FabricWHOutFormDtsPack WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        sqlTrans.ExecuteNonQuery(sql);
                        for (int j = 0; j < dtsql.Rows.Count; j++)
                        {

                            FabricWHOutFormDtsPack pentity = new FabricWHOutFormDtsPack(sqlTrans);
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
            string sql = "SELECT Max(Seq) Seq FROM WH_IOFormDts WHERE MainID=(SELECT MainID FROM WH_IOFormDts WHERE ID=" + SysString.ToDBString(p_ID) + ")";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                MaxSeq = SysConvert.ToInt32(dt.Rows[0][0]);
            }
            return MaxSeq;
        }

        #endregion

      #endregion
	}
}
