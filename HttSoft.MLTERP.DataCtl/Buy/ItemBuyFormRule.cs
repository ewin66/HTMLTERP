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
	/// Ŀ�ģ�Buy_ItemBuyFormʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2012-4-17
	/// </summary>
	public class ItemBuyFormRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public ItemBuyFormRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			ItemBuyForm entity=(ItemBuyForm)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM Buy_ItemBuyForm WHERE 1=1";
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_Buy_ItemBuyFormDts WHERE 1=1";
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
                ItemBuyForm entity = new ItemBuyForm(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//�����ͬ�쳣
                {
                    throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
                }
                if (p_Type == (int)ConfirmFlag.δ�ύ)//�����ύ��֤
                {
                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5609)))//�ɹ����вֿⵥ�ݲ������޸�
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


                sql = "UPDATE Buy_ItemBuyForm SET SubmitFlag=" + SysString.ToDBString(p_Type);
                //if (p_Type == (int)ConfirmFlag.���ͨ�� || p_Type == (int)ConfirmFlag.��˾ܾ�)
                //{
                    //sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                //}
                sql += " WHERE ID=" + p_FormID.ToString();//���µ����������״̬
                sqlTrans.ExecuteNonQuery(sql);

                int tempSaleProcedureID = 0;
                switch (entity.FormAID)//1/2/3/4/5����Ʒ��������ɴ�ߣ�ɫ��������


                {
                    case 1:
                        tempSaleProcedureID = (int)EnumSaleProcedure.��Ʒ�ɹ���;
                        break;
                    case 2:
                        tempSaleProcedureID = (int)EnumSaleProcedure.�����ɹ���;
                        break;
                    case 3:
                        tempSaleProcedureID = (int)EnumSaleProcedure.ɴ�߲ɹ���;
                        break;
                    case 4:
                        tempSaleProcedureID = (int)EnumSaleProcedure.�����ɹ���;
                        break;
                    case 5://����
                        tempSaleProcedureID = (int)EnumSaleProcedure.���ϲɹ���;
                        break;
                
                }
                if (p_Type == (int)YesOrNo.Yes)
                {
                    if (tempSaleProcedureID != (int)EnumSaleProcedure.�����ɹ���)
                    {
                        sql = "SELECT DtsSO,ItemCode,ColorNum,ColorName FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                        DataTable dtDts = sqlTrans.Fill(sql);

                        SaleOrderRule salerule = new SaleOrderRule();
                        foreach (DataRow dr in dtDts.Rows)
                        {
                            salerule.RUpdateStep(dr["DtsSO"].ToString(), dr["ItemCode"].ToString(), dr["ColorNum"].ToString(), dr["ColorName"].ToString(), tempSaleProcedureID, 0, 0, 0, p_Type, true, sqlTrans);
                        }
                    }
                    else  //�����ɹ����ض���ʱ��  ��������� ItemCode ���ص� CPItemCode
                    {
                        sql = "SELECT DtsSO,CPItemCode,ColorNum,ColorName FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                        DataTable dtDts = sqlTrans.Fill(sql);

                        SaleOrderRule salerule = new SaleOrderRule();
                        foreach (DataRow dr in dtDts.Rows)
                        {
                            salerule.RUpdateStep(dr["DtsSO"].ToString(), dr["CPItemCode"].ToString(), dr["ColorNum"].ToString(), dr["ColorName"].ToString(), tempSaleProcedureID, 0, 0, 0, p_Type, true, sqlTrans);
                        }
                    }

                    
                }

                //#region ����ɹ������
                //if (p_Type == (int)YesOrNo.Yes)//�ύ
                //{
                //    if (entity.MLType == (int)EnumMLType.ɴ�� || entity.MLType == (int)EnumMLType.����)
                //    {
                //        decimal TotalQty = 0m;
                //        sql = "SELECT  SUM(Qty) Qty FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                //        DataTable dtDts = sqlTrans.Fill(sql);
                //        if (dtDts.Rows.Count != 0)
                //        {
                //            TotalQty = SysConvert.ToDecimal(dtDts.Rows[0]["Qty"]);
                //        }
                //        sql = "SELECT ID FROM Sale_SaleOrderDts WHERE MainID=(SELECT ID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(entity.OrderFormNo) + ")";
                //        DataTable dtorder = sqlTrans.Fill(sql);//Ѱ��ԭʼ����
                //        if (dtorder.Rows.Count != 0)
                //        {
                //            while (TotalQty > 0m)//��ʼ����
                //            {
                //                for (int i = 0; i < dtorder.Rows.Count;i++ )
                //                {
                //                    SaleOrderDts orderentity = new SaleOrderDts(sqlTrans);
                //                    orderentity.ID = SysConvert.ToInt32(dtorder.Rows[i]["ID"]);
                //                    bool findR=orderentity.SelectByID();
                //                    if (i == dtorder.Rows.Count - 1)
                //                    {
                //                        switch (entity.MLType)
                //                        {

                //                            case (int)EnumMLType.ɴ��:
                //                                orderentity.PSCGQty += TotalQty;
                //                                TotalQty = 0;
                //                                break;
                //                            case (int)EnumMLType.����:
                //                                orderentity.PBCGQty += TotalQty;
                //                                TotalQty = 0;
                //                                break;
                //                            default:
                //                                break;
                //                        }
                //                    }
                //                    else
                //                    {
                //                       // decimal HTQty = DifQty <= TotalQty ? DifQty : TotalQty;
                //                        switch (entity.MLType)
                //                        {

                //                            case (int)EnumMLType.ɴ��:
                //                                decimal DifPSQty = orderentity.Qty - orderentity.PSCGQty;
                //                                if (TotalQty <= DifPSQty)
                //                                {
                //                                    orderentity.PSCGQty += TotalQty;
                //                                    TotalQty = 0;
                //                                    break;
                //                                }
                //                                else
                //                                {
                //                                    if (DifPSQty > 0)
                //                                    {
                //                                        orderentity.PSCGQty += DifPSQty;
                //                                        TotalQty -= DifPSQty;
                //                                        break;
                //                                    }
                //                                }                                              
                //                                break;
                //                            case (int)EnumMLType.����:
                //                                decimal DifPBQty = orderentity.Qty - orderentity.PBCGQty;
                //                                if (TotalQty <= DifPBQty)
                //                                {
                //                                    orderentity.PBCGQty += TotalQty;
                //                                    TotalQty = 0;
                //                                    break;
                //                                }
                //                                else
                //                                {
                //                                    if (DifPBQty > 0)
                //                                    {
                //                                        orderentity.PBCGQty += DifPBQty;
                //                                        TotalQty -= DifPBQty;
                //                                        break;
                //                                    }
                //                                }
                //                                break;
                //                            default:
                //                                break;

                //                        }
                //                    }
                //                    if (findR)
                //                    {
                //                        SaleOrderDtsRule rule = new SaleOrderDtsRule();
                //                        rule.RUpdate(orderentity, sqlTrans);
                //                    }
                                   
                //                } //Forѭ����β
                //            }   //While��β
                //        }
                //        else
                //        {
                //            throw new Exception("���ݳ����쳣δ�ҵ�ԭʼ����");
                //        }

                //    }
                //    if (entity.MLType == (int)EnumMLType.��Ʒ)
                //    {
                //        sql = "SELECT ItemCode,ColorNum,ColorName,Qty FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                //        DataTable dtDts1 = sqlTrans.Fill(sql);
                //        foreach(DataRow dr in dtDts1.Rows)
                //        {
                //             sql = "SELECT DtsID FROM UV1_Sale_SaleOrderDts WHERE FormNo=" + SysString.ToDBString(entity.OrderFormNo);
                //             sql += " AND ItemCode=" + SysString.ToDBString(dr["ItemCode"].ToString());
                //             sql += " AND ColorNum=" + SysString.ToDBString(dr["ColorNum"].ToString());
                //             sql += " AND ColorName=" + SysString.ToDBString(dr["ColorName"].ToString());
                //            DataTable dtorder = sqlTrans.Fill(sql);//Ѱ��ԭʼ����
                //            if (dtorder.Rows.Count == 1)
                //            {
                //                SaleOrderDts orderentity = new SaleOrderDts(sqlTrans);
                //                orderentity.ID = SysConvert.ToInt32(dtorder.Rows[0]["DtsID"]);
                //                bool findR=orderentity.SelectByID();
                //                orderentity.CPCGQty += SysConvert.ToDecimal(dr["Qty"]);
                //                if (findR)
                //                {
                //                    SaleOrderDtsRule rule = new SaleOrderDtsRule();
                //                    rule.RUpdate(orderentity, sqlTrans);
                //                }
                //            }
                //            else
                //            {
                //                throw new Exception("���ݳ����쳣δ�ҵ�ԭʼ���� �����ţ�"+entity.FormNo);
                //            }
                //        }
                //    }

                //}
                //else        //�����ύ��������
                //{
                //    if (entity.MLType == (int)EnumMLType.ɴ�� || entity.MLType == (int)EnumMLType.����)
                //    {
                //        decimal TotalQty = 0m;
                //        sql = "SELECT  SUM(Qty) Qty FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                //        DataTable dtDts = sqlTrans.Fill(sql);
                //        if (dtDts.Rows.Count != 0)
                //        {
                //            TotalQty = SysConvert.ToDecimal(dtDts.Rows[0]["Qty"]);
                //        }
                //        sql = "SELECT ID FROM Sale_SaleOrderDts WHERE MainID=(SELECT ID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(entity.OrderFormNo) + ")";
                //        DataTable dtorder = sqlTrans.Fill(sql);//Ѱ��ԭʼ����
                //        if (dtorder.Rows.Count != 0)
                //        {
                //            while (TotalQty > 0m)//��ʼ����
                //            {
                //                for (int i = 0; i < dtorder.Rows.Count; i++)
                //                {
                //                    SaleOrderDts orderentity = new SaleOrderDts(sqlTrans);
                //                    orderentity.ID = SysConvert.ToInt32(dtorder.Rows[i]["ID"]);
                //                    bool findR=orderentity.SelectByID();
                //                    if (i == dtorder.Rows.Count - 1)
                //                    {
                //                        switch (entity.MLType)
                //                        {

                //                            case (int)EnumMLType.ɴ��:
                //                                orderentity.PSCGQty -= TotalQty;
                //                                //if (orderentity.PSCGQty < 0)
                //                                //{
                //                                //    orderentity.PSCGQty = 0;
                //                                //}
                //                                TotalQty = 0;
                //                                break;
                //                            case (int)EnumMLType.����:
                //                                orderentity.PBCGQty -= TotalQty;
                //                                //if (orderentity.PBCGQty < 0)
                //                                //{
                //                                //    orderentity.PBCGQty = 0;
                //                                //}
                //                                TotalQty = 0;
                //                                break;
                //                            default:
                //                                break;
                //                        }
                //                    }
                //                    else
                //                    {
                //                        switch (entity.MLType)
                //                        {

                //                            case (int)EnumMLType.ɴ��:
                //                               // decimal DifPSQty = orderentity.Qty - orderentity.PSCGQty;
                //                                if (TotalQty <= orderentity.PSCGQty)
                //                                {
                //                                    orderentity.PSCGQty -= TotalQty;
                //                                    TotalQty = 0;
                //                                    break;
                //                                }
                //                                else
                //                                {
                //                                    if (orderentity.PSCGQty > 0)
                //                                    {
                //                                        TotalQty -= orderentity.PSCGQty;
                //                                        orderentity.PSCGQty =0;
                //                                        break;
                //                                    }
                //                                }
                //                                break;
                //                            case (int)EnumMLType.����:
                //                                //decimal DifPBQty = orderentity.Qty - orderentity.PBCGQty;
                //                                if (TotalQty <= orderentity.PBCGQty)
                //                                {
                //                                    orderentity.PBCGQty -= TotalQty;
                //                                    TotalQty = 0;
                //                                    break;
                //                                }
                //                                else
                //                                {
                //                                    if (orderentity.PBCGQty > 0)
                //                                    {
                //                                        TotalQty -= orderentity.PBCGQty;
                //                                        orderentity.PBCGQty= 0;
                //                                        break;
                //                                    }
                //                                }
                //                                break;
                //                            default:
                //                                break;

                //                        }
                //                    }
                //                    if (findR)
                //                    {
                //                        SaleOrderDtsRule rule = new SaleOrderDtsRule();
                //                        rule.RUpdate(orderentity, sqlTrans);
                //                    }

                //                } //Forѭ����β
                //            }   //While��β
                //        }
                //        else
                //        {
                //            throw new Exception("���ݳ����쳣δ�ҵ�ԭʼ����");
                //        }

                //    }
                //    if (entity.MLType == (int)EnumMLType.��Ʒ)
                //    {
                //        sql = "SELECT ItemCode,ColorNum,ColorName,Qty FROM Buy_ItemBuyFormDts WHERE MainID=" + p_FormID;
                //        DataTable dtDts1 = sqlTrans.Fill(sql);
                //        foreach (DataRow dr in dtDts1.Rows)
                //        {
                //            sql = "SELECT DtsID FROM UV1_Sale_SaleOrderDts WHERE FormNo=" + SysString.ToDBString(entity.OrderFormNo);
                //            sql += " AND ItemCode=" + SysString.ToDBString(dr["ItemCode"].ToString());
                //            sql += " AND ColorNum=" + SysString.ToDBString(dr["ColorNum"].ToString());
                //            sql += " AND ColorName=" + SysString.ToDBString(dr["ColorName"].ToString());
                //            DataTable dtorder = sqlTrans.Fill(sql);//Ѱ��ԭʼ����
                //            if (dtorder.Rows.Count == 1)
                //            {
                //                SaleOrderDts orderentity = new SaleOrderDts(sqlTrans);
                //                orderentity.ID = SysConvert.ToInt32(dtorder.Rows[0]["DtsID"]);
                //                bool findR= orderentity.SelectByID();
                //                orderentity.CPCGQty -= SysConvert.ToDecimal(dr["Qty"]);
                //                if (findR)
                //                {
                //                    SaleOrderDtsRule rule = new SaleOrderDtsRule();
                //                    rule.RUpdate(orderentity, sqlTrans);
                //                }
                //            }
                //            else
                //            {
                //                throw new Exception("���ݳ����쳣δ�ҵ�ԭʼ���� �����ţ�" + entity.FormNo);
                //            }
                //        }
                //    }
                //}
                //#endregion
    

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
                ItemBuyForm entity = (ItemBuyForm)p_BE;

                string sql = "SELECT FormNo FROM Buy_ItemBuyForm WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�ɹ������Ѵ��ڣ�����������");
                }
                ItemBuyFormCtl control = new ItemBuyFormCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Buy_ItemBuyForm, sqlTrans);
                control.AddNew(entity);

                FormNoControlRule fnrule = new FormNoControlRule();
                fnrule.RAddSort("Buy_ItemBuyForm", "FormNo", entity.FormAID, sqlTrans);

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
				ItemBuyForm entity=(ItemBuyForm)p_BE;				
				ItemBuyFormCtl control=new ItemBuyFormCtl(sqlTrans);				
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
				ItemBuyForm entity=(ItemBuyForm)p_BE;				
				ItemBuyFormCtl control=new ItemBuyFormCtl(sqlTrans);
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
                ItemBuyForm entity = (ItemBuyForm)p_BE;
                this.RAdd(entity, sqlTrans);
                for (int i = 0; i < p_BE2.Length;i++ )
                {
                    ItemBuyFormDtsRule rule = new ItemBuyFormDtsRule();
                    ItemBuyFormDts entityDts = (ItemBuyFormDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    rule.RAdd(entityDts,sqlTrans);
                }
                //FormNoControlRule rulest = new FormNoControlRule();
                //switch (entity.FormAID)     //ע����ɹ����������
                //{ 
                //    case 0:
                //        rulest.RAddSort((int)FormNoControlEnum.���ۺ�ͬ�ɹ�����, sqlTrans); //�ɹ���Ʒ����
                //        break;
                //    case 1:
                //        rulest.RAddSort((int)FormNoControlEnum.�����ɹ�����, sqlTrans);
                //        break;
                //    case 2:
                //        rulest.RAddSort((int)FormNoControlEnum.ɴ�߲ɹ�����, sqlTrans);
                //        break;
                //    default:
                //        rulest.RAddSort((int)FormNoControlEnum.���ۺ�ͬ�ɹ�����, sqlTrans);
                //        break;
                //}
               
                ItemBuyCapDtsRule capRule = new ItemBuyCapDtsRule();
                capRule.RSaveBuyCap(entity, sqlTrans);//�����ʽ�ƻ���ϸ
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
        public void RUpdate(BaseEntity p_BE,BaseEntity[] p_BE2)
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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2,IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                ItemBuyForm entity = (ItemBuyForm)p_BE;
                ItemBuyFormCtl control = new ItemBuyFormCtl(sqlTrans);
                control.Update(entity);
                ItemBuyFormDtsRule rule = new ItemBuyFormDtsRule();
                rule.RSave(entity, p_BE2, sqlTrans);
                //string sql = "DELETE Buy_ItemBuyFormDts WHERE MainID="+SysString.ToDBString(entity.ID);
                //sqlTrans.ExecuteNonQuery(sql);
                //for (int i = 0; i < p_BE2.Length; i++)
                //{
                //    ItemBuyFormDtsRule rule = new ItemBuyFormDtsRule();
                //    ItemBuyFormDts entityDts = (ItemBuyFormDts)p_BE2[i];
                //    entityDts.MainID = entity.ID;
                //    entityDts.Seq = i + 1;
                //    rule.RAdd(entityDts, sqlTrans);
                //}

                ItemBuyCapDtsRule capRule = new ItemBuyCapDtsRule();
                capRule.RSaveBuyCap(entity, sqlTrans);//�����ʽ�ƻ���ϸ
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
