using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;
using HttSoft.FrameFunc;



namespace HttSoft.MLTERP.DataCtl
{
	/// <summary>
	/// Ŀ�ģ�WO_FabricProcessʵ��ҵ�������
	/// ����:������
	/// ��������:2012-8-17
	/// </summary>
	public class FabricProcessRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
        public FabricProcessRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			FabricProcess entity=(FabricProcess)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WO_FabricProcess WHERE 1=1";
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_WO_FabricProcessDts WHERE 1=1";
                sql += p_condition;
                sql += " ORDER BY FormNo DESC ";
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
                FabricProcess entity = new FabricProcess(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//�����ͬ�쳣
                {
                    throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
                }
                if (p_Type == (int)ConfirmFlag.δ�ύ)//�����ύ��֤
                {
                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5809)))//�ӹ����вֿⵥ�ݲ������޸�
                    {
                        bool allowOPFlag = true;
                        string refuseMessage = string.Empty;
                        DataTable dtSOFlow;
                        if (allowOPFlag)
                        {
                            //�ֿ����̵���
                            sql = "SELECT TOP 1 ID,FormNo FROM UV1_WH_IOFormDts WHERE DtsSO=" + SysString.ToDBString(entity.FormNo);
                            dtSOFlow = SysUtils.Fill(sql);
                            if (dtSOFlow.Rows.Count != 0)
                            {
                                allowOPFlag = false;
                                refuseMessage = "�˵����вֿⵥ��(����):" + dtSOFlow.Rows[0]["FormNo"].ToString() + "����������";
                            }
                        }

                        if (!allowOPFlag)//���������
                        {
                            throw new Exception(refuseMessage);
                        }
                    }
                }


                sql = "UPDATE WO_FabricProcess SET SubmitFlag=" + SysString.ToDBString(p_Type);
                //if (p_Type == (int)ConfirmFlag.���ͨ�� || p_Type == (int)ConfirmFlag.��˾ܾ�)
                //{
                    //sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                //}
                sql += " WHERE ID=" + p_FormID.ToString();//���µ����������״̬
                sqlTrans.ExecuteNonQuery(sql);



                int tempSaleProcedureID = 0;
                switch (entity.ProcessTypeID)//2��֯��;1��Ⱦ��;3��ӡ��;4������
                {
                    case 1:
                        tempSaleProcedureID = (int)EnumSaleProcedure.Ⱦ���ӹ���;
                        break;
                    case 2:
                        tempSaleProcedureID = (int)EnumSaleProcedure.֯�߼ӹ���;//֯��ӹ���
                        break;
                    case 3:
                        tempSaleProcedureID = (int)EnumSaleProcedure.ӡ���ӹ���;
                        break;
                    case 4://����  ��Ϊ�����ӹ�
                        tempSaleProcedureID = (int)EnumSaleProcedure.�����ӹ���;
                        break;
                    case 5:
                        tempSaleProcedureID = (int)EnumSaleProcedure.���ϼӹ���;
                        break;
                }


                //if (p_Type == (int)YesOrNo.Yes)
                if (p_Type == (int)ConfirmFlag.���ύ)
                {
                    sql = "SELECT DtsSO,ItemCode,ColorNum,ColorName,DtsSO,CPItemCode FROM WO_FabricProcessDts WHERE MainID=" + p_FormID;
                    DataTable dtDts = sqlTrans.Fill(sql);
                    if (tempSaleProcedureID == (int)EnumSaleProcedure.֯�߼ӹ���)//֯��ӹ���
                    {
                        SaleOrderRule salerule = new SaleOrderRule();
                        foreach (DataRow dr in dtDts.Rows)
                        {
                            salerule.RUpdateStep(dr["DtsSO"].ToString(), dr["CPItemCode"].ToString(), dr["ColorNum"].ToString(), dr["ColorName"].ToString(), tempSaleProcedureID, 0, 0, 0, p_Type, true, sqlTrans);
                        }
                    }
                    else
                    {
                        SaleOrderRule salerule = new SaleOrderRule();
                        foreach (DataRow dr in dtDts.Rows)
                        {
                            salerule.RUpdateStep(dr["DtsSO"].ToString(), dr["ItemCode"].ToString(), dr["ColorNum"].ToString(), dr["ColorName"].ToString(), tempSaleProcedureID, 0, 0, 0, p_Type, true, sqlTrans);
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

        //private void RUpdateStep(int p_FormListAID, string p_DtsSO, string p_ItemCode, string p_ColorName, IDBTransAccess sqlTrans)
        //{
        //    string sql = "";

        //    string[] arr = p_DtsSO.Split(',');
        //    string DtsSO = "";
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        if (DtsSO != "")
        //        {
        //            DtsSO += ",";
        //        }
        //        DtsSO += SysString.ToDBString(arr[i]);
        //    }

        //    if (DtsSO != "")
        //    {
        //        sql = "SELECT DISTINCT DtsID FROM UV1_Sale_SaleOrderDts WHERE FormNo IN (" + DtsSO + ") AND ItemCode=" + SysString.ToDBString(p_ItemCode) + " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //        DataTable dt = sqlTrans.Fill(sql);
        //        for (int j = 0; j < dt.Rows.Count; j++)
        //        {
        //            int ID = SysConvert.ToInt32(dt.Rows[j][0]);
        //            if (p_FormListAID == 1)
        //            {
        //                sql = "UPDATE Sale_SaleOrderDts SET OrderStepID=" + SysString.ToDBString((int)EnumProcessType.Ⱦɴ�ӹ���) + " WHERE ID=" + SysString.ToDBString(ID);
        //                sqlTrans.ExecuteNonQuery(sql);
        //            }
        //            else
        //            {
        //                sql = "UPDATE Sale_SaleOrderDts SET OrderStepID=" + SysString.ToDBString((int)EnumProcessType.Ⱦ���ӹ���) + " WHERE ID=" + SysString.ToDBString(ID);
        //                sqlTrans.ExecuteNonQuery(sql);
        //            }
        //        }
        //    }


        //}

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
				FabricProcess entity=(FabricProcess)p_BE;				
				FabricProcessCtl control=new FabricProcessCtl(sqlTrans);
                string sql = "SELECT FormNo FROM WO_FabricProcess WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�����Ѵ��ڣ�����������");
                }
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WO_FabricProcess, sqlTrans);
				control.AddNew(entity);

                FormNoControlRule fnrule = new FormNoControlRule();
                fnrule.RAddSort("WO_FabricProcess", "FormNo", entity.ProcessTypeID, sqlTrans);



              ///��������֪ͨ��������
                if (entity.ProductionID != 0)
                {
                    //sql = "select SUM(ISNULL(TotalQty,0)) TotalQty from WO_FabricProcess where 1=1";
                    //sql += " AND ProductionID=" + entity.ProductionID;
                    //DataTable dtP = sqlTrans.Fill(sql);
                    //if(dtP.Rows.Count!=0)
                    //{
                    
                    //}
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
				FabricProcess entity=(FabricProcess)p_BE;				
				FabricProcessCtl control=new FabricProcessCtl(sqlTrans);				
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
				FabricProcess entity=(FabricProcess)p_BE;				
				FabricProcessCtl control=new FabricProcessCtl(sqlTrans);
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

        #region  �������� 
        
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            RAdd(p_BE, p_BE2, null);
        }
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

                    this.RAdd(p_BE, p_BE2, p_BE3,sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                FabricProcess entity = (FabricProcess)p_BE;
                this.RAdd(entity, sqlTrans);
                //string sql = "SELECT FormNo FROM WO_FabricProcess WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                //DataTable dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count > 0)
                //{
                //    throw new BaseException("Ⱦ���ӹ������Ѵ��ڣ�����������");
                //}
                //FabricProcessCtl control = new FabricProcessCtl(sqlTrans);
                //entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WO_FabricProcess, sqlTrans);
                //control.AddNew(entity);
                for (int i = 0; i < p_BE2.Length;i++ )
                {
                    FabricProcessDtsRule rule = new FabricProcessDtsRule();
                    FabricProcessDts entityDts = (FabricProcessDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts,sqlTrans);
                }


                if (p_BE3 != null)
                {
                    for (int i = 0; i < p_BE3.Length; i++)
                    {
                        FabricProcessItemDtsRule rule = new FabricProcessItemDtsRule();
                        FabricProcessItemDts entityItemfac = (FabricProcessItemDts)p_BE3[i];
                        entityItemfac.MainID = entity.ID;
                        entityItemfac.Seq = i + 1;
                        rule.RAdd(entityItemfac, sqlTrans);
                    }
                }
                //FormNoControlRule frule = new FormNoControlRule();
                //if (entity.ProcessTypeID == (int)EnumProcessType.Ⱦ���ӹ���)
                //{
                //    frule.RAddSort((int)FormNoControlEnum.Ⱦ���ӹ�����,sqlTrans);
                //}

                //if (entity.ProcessTypeID == (int)EnumProcessType.ӡ���ӹ���)
                //{
                //    frule.RAddSort((int)FormNoControlEnum.ӡ���ӹ�����, sqlTrans);
                //}

                //if (entity.ProcessTypeID == (int)EnumProcessType.֯��ӹ���)
                //{
                //    frule.RAddSort((int)FormNoControlEnum.֯��ӹ�����, sqlTrans);
                //}

                //if (entity.ProcessTypeID == (int)EnumProcessType.�����ӹ���)
                //{
                //    frule.RAddSort((int)FormNoControlEnum.�����ӹ�����, sqlTrans);
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


        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            RUpdate(p_BE, p_BE2, null);
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

                    this.RUpdate(p_BE, p_BE2, p_BE3, sqlTrans);

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
                this.CheckCorrect(p_BE);
                FabricProcess entity = (FabricProcess)p_BE;
                FabricProcessCtl control = new FabricProcessCtl(sqlTrans);
                control.Update(entity);
                FabricProcessDtsRule rule = new FabricProcessDtsRule();
                rule.RSave(entity, p_BE2, sqlTrans);

                if (p_BE3 != null)
                {
                    FabricProcessItemDtsRule ruleitem = new FabricProcessItemDtsRule();
                    ruleitem.RSave(entity, p_BE3, sqlTrans);
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

        #region

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE,BaseEntity p_BEAdd,BaseEntity[] p_BE2,BaseEntity[] p_BE3)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE,p_BEAdd,p_BE2,p_BE3, sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity p_BEAdd, BaseEntity[] p_BE2, BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                FabricProcess entity = (FabricProcess)p_BE;
                FabricProcessCtl control = new FabricProcessCtl(sqlTrans);
                string sql = "SELECT FormNo FROM WO_FabricProcess WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�����Ѵ��ڣ�����������");
                }
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WO_FabricProcess, sqlTrans);
                control.AddNew(entity);

                FormNoControlRule fnrule = new FormNoControlRule();
                fnrule.RAddSort("WO_FabricProcess", "FormNo", entity.ProcessTypeID, sqlTrans);

                FabricProcessAddRule ruleAdd = new FabricProcessAddRule();
                FabricProcessAdd entityAdd = (FabricProcessAdd)p_BEAdd;
                entityAdd.ID = entity.ID;
                ruleAdd.RAdd(entityAdd,sqlTrans);


                for (int i = 0; i < p_BE2.Length; i++)
                {
                    FabricProcessDtsRule rule = new FabricProcessDtsRule();
                    FabricProcessDts entityDts = (FabricProcessDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts, sqlTrans);
                }

                for (int i = 0; i < p_BE3.Length; i++)
                {
                    FabricProcessPBDtsRule rule = new FabricProcessPBDtsRule();
                    FabricProcessPBDts entityDts = (FabricProcessPBDts)p_BE3[i];
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

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity p_BEAdd, BaseEntity[] p_BE2, BaseEntity[] p_BE3)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BEAdd, p_BE2,p_BE3, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity p_BEAdd, BaseEntity[] p_BE2, BaseEntity[] p_BE3, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                FabricProcess entity = (FabricProcess)p_BE;
                FabricProcessCtl control = new FabricProcessCtl(sqlTrans);
                control.Update(entity);

                FabricProcessDtsRule rule = new FabricProcessDtsRule();
                rule.RSave(entity, p_BE2, sqlTrans);

                string sql = "DELETE WO_FabricProcessAdd WHERE ID="+SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);

                sql = "DELETE WO_FabricProcessPBDts WHERE MainID=" + SysString.ToDBString(entity.ID);
                sqlTrans.ExecuteNonQuery(sql);

                FabricProcessAddRule ruleAdd = new FabricProcessAddRule();
                FabricProcessAdd entityAdd = (FabricProcessAdd)p_BEAdd;
                entityAdd.ID = entity.ID;
                ruleAdd.RAdd(entityAdd, sqlTrans);

                for (int i = 0; i < p_BE3.Length; i++)
                {
                    FabricProcessPBDtsRule rule2 = new FabricProcessPBDtsRule();
                    FabricProcessPBDts entityDts = (FabricProcessPBDts)p_BE3[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule2.RAdd(entityDts, sqlTrans);
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
