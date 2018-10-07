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
	/// Ŀ�ģ�Sale_JYOrderDtsInputPackʵ��ҵ�������
	/// ����:����ǿ
	/// ��������:2014/12/18
	/// </summary>
	public class JYOrderDtsInputPackRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public JYOrderDtsInputPackRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			JYOrderDtsInputPack entity=(JYOrderDtsInputPack)p_BE;
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
            JYOrderDtsInputPack entity = (JYOrderDtsInputPack)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, JYOrderDtsInputPack.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM Sale_JYOrderDtsInputPack WHERE 1=1";
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
				JYOrderDtsInputPack entity=(JYOrderDtsInputPack)p_BE;				
				JYOrderDtsInputPackCtl control=new JYOrderDtsInputPackCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.Sale_JYOrderDtsInputPack,sqlTrans);
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
				JYOrderDtsInputPack entity=(JYOrderDtsInputPack)p_BE;				
				JYOrderDtsInputPackCtl control=new JYOrderDtsInputPackCtl(sqlTrans);				
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
				JYOrderDtsInputPack entity=(JYOrderDtsInputPack)p_BE;				
				JYOrderDtsInputPackCtl control=new JYOrderDtsInputPackCtl(sqlTrans);
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


        #region ��������
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RSave(int p_ID, int p_MainID, int p_Seq, BaseEntity[] p_BE, bool p_UpdateFlag)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSave(p_ID, p_MainID, p_Seq, p_BE, p_UpdateFlag, sqlTrans);

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
        public void RSave(int p_ID, int p_MainID, int p_Seq, BaseEntity[] p_BE, bool p_UpdateFlag, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "";
                if (p_UpdateFlag)//�޸�״̬�����������ɾ�����뵥��ϸ
                {
                    string idStr = string.Empty;//ID�ַ���
                    idStr = "0";
                    for (int i = 0; i < p_BE.Length; i++)
                    {
                        JYOrderDtsInputPack entity = (JYOrderDtsInputPack)p_BE[i];
                        if (entity.ID != 0)//��ID
                        {
                            if (idStr != string.Empty)
                            {
                                idStr += ",";
                            }
                            idStr += entity.ID.ToString();
                        }
                    }

                    if (idStr != string.Empty)
                    {
                        //sql = "DELETE FROM WH_PackBox WHERE BoxNo IN (SELECT BoxNo FROM WH_IOFormDtsInputPack WHERE DID=" + SysString.ToDBString(p_ID) + " AND ID NOT IN(" + idStr + ") )";
                        //sqlTrans.ExecuteNonQuery(sql);//ִ��������ɾ��

                        sql = "DELETE FROM Sale_JYOrderDtsInputPack WHERE DID=" + SysString.ToDBString(p_ID) + " AND ID NOT IN(" + idStr + ")";//WH_IOFormDtsPack WH_PackBox
                        sqlTrans.ExecuteNonQuery(sql);
                    }
                }
                else//����״̬
                {
                    sql = "SELECT TOP 1 ID FROM Sale_JYOrderDtsInputPack WHERE DID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        throw new BaseException("�����ظ����棡");
                    }
                }


                JYOrder p_Main = new JYOrder(sqlTrans);
                p_Main.ID = p_MainID;
                p_Main.SelectByID();

                JYOrderDts p_MainDts = new JYOrderDts(sqlTrans);
                p_MainDts.ID = p_ID;
                p_MainDts.SelectByID();



                //IOFormDtsPackRule rule = new IOFormDtsPackRule();
                //PackBoxRule Brule = new PackBoxRule();
                decimal Qty = 0;
                decimal PieceQty = 0;
                decimal inputQty = 0;
                for (int i = 0; i < p_BE.Length; i++)
                {
                    //FormNoControlRule frule = new FormNoControlRule();
                    JYOrderDtsInputPack entity = (JYOrderDtsInputPack)p_BE[i];

                    if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5405)))//ת��ΪĬ�ϵ�λģʽ����,Ŀǰ֧��ת��Ϊ����ģʽ
                    {
                        //��ʼ���㵥λ
                        //entity.InputUnit = p_MainDts.InputUnit;
                        //entity.Unit = p_MainDts.Unit;
                        //entity.InputConvertXS = p_MainDts.InputConvertXS;
                        entity.InputQty = entity.Qty;// ProductCommon.UnitConvertValueAnyUnit(entitydts[index].Unit, entitydts[index].Qty, entitydts[index].InputUnit, entitydts[index].InputConvertXS);
                        if (entity.InputConvertXS != 0)
                        {
                            entity.InputQty = SysConvert.ToDecimal(entity.Qty / entity.InputConvertXS, 2);
                        }

                    }
                    if (entity.ID == 0)
                    {
                        //entity.BoxNo = frule.RGetFormNo((int)FormNoControlEnum.�뵥���, sqlTrans);
                        this.RAdd(entity, sqlTrans);
                        //frule.RAddSort((int)FormNoControlEnum.�뵥���, sqlTrans);
                    }
                    else
                    {
                        this.RUpdate(entity, sqlTrans);
                    }


                    inputQty += entity.InputQty;
                    Qty += entity.Qty;
                    PieceQty++;


                }

                //if (PieceQty == 0)
                //{
                //    throw new BaseException("����дϸ���������");
                //}

                sql = "UPDATE Sale_JYOrderDts SET Qty=" + SysString.ToDBString(Qty);
                sql += ",PieceQty=" + SysString.ToDBString(PieceQty);
                //sql += ",InputQty=" + SysString.ToDBString(inputQty);
                sql += ",PackFlag=1 ";
                //sql += ",InputAmount= " + SysString.ToDBString(inputQty * p_MainDts.InputSinglePrice + p_MainDts.DYPrice);
                //sql += ",Amount= " + SysString.ToDBString(Qty * p_MainDts.SinglePrice + p_MainDts.DYPrice);
                sql += " WHERE ID=" + SysString.ToDBString(p_ID);
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
	}
}
