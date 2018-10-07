using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;


namespace HttSoft.HTCPCheck.DataCtl
{
	/// <summary>
	/// Ŀ�ģ�Chk_CheckOrderISNFaultʵ��ҵ�������
	/// ����:�ܸ���
	/// ��������:2015/11/4
	/// </summary>
	public class CheckOrderISNFaultRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public CheckOrderISNFaultRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			CheckOrderISNFault entity=(CheckOrderISNFault)p_BE;
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
            CheckOrderISNFault entity = (CheckOrderISNFault)p_BE;
            bool ret = false;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, CheckOrderISNFault.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM Chk_CheckOrderISNFault WHERE 1=1";
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
				CheckOrderISNFault entity=(CheckOrderISNFault)p_BE;				
				CheckOrderISNFaultCtl control=new CheckOrderISNFaultCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Chk_CheckOrderISNFault, sqlTrans);
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
				CheckOrderISNFault entity=(CheckOrderISNFault)p_BE;				
				CheckOrderISNFaultCtl control=new CheckOrderISNFaultCtl(sqlTrans);				
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
				CheckOrderISNFault entity=(CheckOrderISNFault)p_BE;				
				CheckOrderISNFaultCtl control=new CheckOrderISNFaultCtl(sqlTrans);
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


        #region ����õ�
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public int RSaveFault(CheckOrderISNFault p_BE, CheckOrderISN entity, int MainID, int PackDtsID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    int TempID = this.RSaveFault(p_BE, entity, MainID, PackDtsID, sqlTrans);

                    sqlTrans.CommitTrans();

                    return TempID;
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
        public int RSaveFault(CheckOrderISNFault p_BE, CheckOrderISN entityMain, int MainID, int PackDtsID, IDBTransAccess sqlTrans)
        {
            try
            {
                if (PackDtsID == 0)
                {
                    throw new Exception("����ѡ�����ָʾ��");
                }
                CheckOrderISNFault entity = p_BE as CheckOrderISNFault;
                if (MainID == 0)
                {
                    entityMain.MainID = PackDtsID;

                    CheckOrderISNRule rulebp = new CheckOrderISNRule();


                    //entityMain.CY += entity.CYQty;
                    entityMain.Qty = entityMain.ChkQty - entityMain.KJQty;

                    rulebp.RAdd(entityMain, sqlTrans);

                    entity.MainID = entityMain.ID;
                }
                else
                {
                    CheckOrderISNRule rulebp = new CheckOrderISNRule();

                    //entityMain.CY += entity.CYQty;

                    entityMain.Qty = entityMain.ChkQty - entityMain.KJQty;

                    rulebp.RUpdate(entityMain, sqlTrans);
                }

                RAdd(entity, sqlTrans);



                return entity.MainID;
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


        #region �˾����
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="p_BE"></param>
        /// <param name="entity"></param>
        /// <param name="p_PackID"></param>
        /// <param name="Qty">�������</param>
        /// <param name="YMQty">ԭ���������ݲ�ʹ��</param>
        /// <param name="JarNo">�׺�</param>
        /// <returns></returns>
        public int RJYEnd(int p_BE, CheckOrderISN entity, int p_PackID, decimal Qty, decimal YMQty, int JarNo)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    int tempID = this.RJYEnd(p_BE, entity, p_PackID, Qty, YMQty, JarNo, sqlTrans);

                    sqlTrans.CommitTrans();


                    return tempID;
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
        /// �������
        /// </summary>
        /// <param name="p_BE">Ҫɾ����ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public int RJYEnd(int p_BE, CheckOrderISN entity2, int p_PackID, decimal Qty, decimal YMQty, int ReelNo, IDBTransAccess sqlTrans)
        {
            try
            {

                if (p_BE == 0)//�����0 ���ʾû�дõ�
                {
                    entity2.MainID = p_PackID;

                    CheckOrderISNRule rulebp = new CheckOrderISNRule();

                    rulebp.RAdd(entity2, sqlTrans);

                    p_BE = entity2.ID;
                }
                CheckOrderISN entity = new CheckOrderISN(sqlTrans);
                entity.ID = p_BE;
                entity.SelectByID();
                entity.MainID = p_PackID;

                entity.ChkQty = Qty;//�������  
            

                entity.ColorName = entity2.ColorName;//��ɫ
                entity.ColorNum = entity2.ColorNum;//ɫ��
                entity.MWidth = entity2.MWidth;//ƽ���ŷ�
                entity.MWeight = entity2.MWeight;//ƽ������



                string sqls = "SELECT MAX(Seq) Seq FROM Chk_CheckOrderISN WHERE JarNum=" + SysString.ToDBString(entity.JarNum);
                sqls += " AND MainID=" + p_BE;

                //string sqls = "Select ISNULL(Max(ReelNo),0) From Chk_CheckOrderISN where JarNum=" + SysString.ToDBString(SysConvert.ToString(entity.JarNum));
                //sqls += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(entity.ItemCode));
                //sqls += " AND ColorNum=" + SysString.ToDBString(SysConvert.ToString(entity.ColorNum));
                DataTable dts = sqlTrans.Fill(sqls);
                if ((SysConvert.ToInt32(dts.Rows[0][0]) + 1) != ReelNo)
                {
                    entity.ReelNo = SysConvert.ToString(SysConvert.ToInt32(dts.Rows[0][0]) + 1);//���
                }
                else
                {
                    entity.ReelNo = SysConvert.ToString(ReelNo);//���
                }

        

                //entity.YQty = SysConvert.ToDecimal(Qty * 1.0936132983377m, 2);//����ת����
                CheckOrderISNRule rule = new CheckOrderISNRule();
                rule.RUpdate(entity, sqlTrans);







                #region ͳ�ƺϼ�����
                entity.KJQty = 0.0m;//���������ϼ�
                string sql = "SELECT SUM(cast(Deduction as decimal(10,2))) Deduction FROM Chk_CheckOrderISNFault  WHERE 1=1";
                sql += " AND MainID=" + p_BE;
                sql += " AND FaultType=3";//����
                sql += " AND ISNUMERIC(Deduction)=1";
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    entity.KJQty = SysConvert.ToDecimal(dt.Rows[0]["Deduction"]);
                }

                entity.Qty = SysConvert.ToDecimal(entity.ChkQty - entity.KJQty, 2);//ʵ������=�������-�ü�����
                CheckOrderISNRule rulebp2 = new CheckOrderISNRule();
                rulebp2.RUpdate(entity, sqlTrans);

                #endregion


                #region �ϼƼ����������ܵ������嵥

                 sql = "Select SUM(Qty) Qty from Chk_CheckOrderISN where MainID=" + p_PackID;
                DataTable dtS = sqlTrans.Fill(sql);
                if (dtS.Rows.Count != 0)
                {
                    sql = "Update Chk_CheckOrderDts Set CheckQty=" + SysConvert.ToDecimal(dtS.Rows[0]["Qty"]);
                    sql += " where ID=" + p_PackID;
                    sqlTrans.ExecuteNonQuery(sql);
                }
                #endregion

                #region ����ͬ���׺ŵ�ƽ���ŷ�������
                //decimal AvgMWidth = 0.0m;
                //decimal AvgMWeight = 0.0m;
                //sql = "Select Avg(MWidth) MWidth,Avg(MWeight) MWeight from WO_BProductCheckDtsFault where 1=1";
                //sql += " AND MainID in(select ID from WO_BProductCheckDts  where 1=1 AND MainID=" + entity.MainID + ")";
                //sql += " AND ISNULL(MWidth,0)<>0  AND ISNULL(MWeight,0)<>0  ";
                //DataTable dtAvg = sqlTrans.Fill(sql);
                //if (dtAvg.Rows.Count != 0)
                //{
                //    AvgMWidth = SysConvert.ToDecimal(dtAvg.Rows[0]["MWidth"]);
                //    AvgMWeight = SysConvert.ToDecimal(dtAvg.Rows[0]["MWeight"]);
                //}
                //sql = "Update WO_BProductCheckDts set JarNumMWidth =" + AvgMWidth;
                //sql += ",JarNumMWeight=" + AvgMWeight;
                //sql += " where 1=1 AND MainID=" + entity.MainID;
                //sqlTrans.ExecuteNonQuery(sql);

                #endregion


                return p_BE;

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
