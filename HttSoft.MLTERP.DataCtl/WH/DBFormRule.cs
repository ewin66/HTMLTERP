using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;


namespace HttSoft.MLTERP.DataCtl
{
	/// <summary>
	/// Ŀ�ģ�WH_DBFormʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2014/7/21
	/// </summary>
	public class DBFormRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public DBFormRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			DBForm entity=(DBForm)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WH_DBForm WHERE 1=1";
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
        public DataTable RShowDts(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_DBFormDts WHERE 1=1";
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
                DBForm entity = new DBForm(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();

                if (!RSubmitCheckJS(entity.FormDate, sqlTrans))
                {
                    throw new Exception("������������˵�������֮���Ѿ��н�������");
                }

                if (entity.SubmitFlag == p_Type)//�����ͬ�쳣
                {
                    throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
                }

                int p_AuditFlag = 0;
                //sql = "SELECT FillDataTypeID,AuditFlag,WHQtyPosID,CheckQtyPer1,CheckQtyFrom,CheckQtyPer2,DZFlag FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                //DataTable dtFormList = sqlTrans.Fill(sql);
                //if (dtFormList.Rows.Count != 0)
                //{
                //p_AuditFlag = SysConvert.ToInt32(dtFormList.Rows[0]["AuditFlag"]);
                if (p_AuditFlag == 0)//����Ҫ���
                {
                    switch (p_Type)
                    {
                        case (int)ConfirmFlag.δ�ύ:
                            //p_Type=(int)ConfirmFlag.δ�ύ;
                            break;
                        case (int)ConfirmFlag.���ύ:
                            p_Type = (int)ConfirmFlag.���ͨ��;
                            break;
                        case (int)ConfirmFlag.���ͨ��:
                            //								p_Type=(int)ConfirmFlag.���ͨ��;
                            break;
                        case (int)ConfirmFlag.��˾ܾ�:
                            p_Type = (int)ConfirmFlag.δ�ύ;
                            break;
                    }
                }

                #region �ύ
                sql = "UPDATE WH_IOForm SET SubmitFlag=" + SysString.ToDBString(p_Type);
                if (p_Type == (int)ConfirmFlag.���ͨ�� || p_Type == (int)ConfirmFlag.��˾ܾ�)
                {
                    sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                }
                sql += " WHERE ID=" + p_FormID.ToString();//���µ����������״̬
                sqlTrans.ExecuteNonQuery(sql);



                //IOFormDtsRule ruledts = new IOFormDtsRule();
                //ruledts.RSubmit(p_FormID, TempSubmitType, dtFormList.Rows[0], sqlTrans);//�����ӱ���

                #endregion

                if (entity.SubmitFlag == p_Type)//�����ͬ�쳣
                {
                    throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
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
        /// �ύʱУ�������
        /// </summary>
        /// <returns></returns>
        bool RSubmitCheckJS(DateTime p_FormDate, IDBTransAccess sqlTrans)
        {
            bool outbool = true;
            //ParamSetRule psrule = new ParamSetRule();
            //bool checkFlag = SysConvert.ToBoolean(psrule.RShowIntByID((int)ParamSetEnum.�ֿ��ύУ���������));//(int)ParamSetEnum.�ֿ��ύУ���������
            bool checkFlag = SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6421));

            if (checkFlag)//���
            {
                string sql = string.Empty;
                sql = "SELECT TOP 1 JSDateE FROM WH_StorgeJS WHERE   JSFlag=1 ORDER BY JSDateE DESC";
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)//�ҵ���������
                {
                    if (SysConvert.ToDateTime(dt.Rows[0]["JSDateE"]) >= p_FormDate)
                    {
                        outbool = false;
                    }
                }
            }

            return outbool;
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
                DBForm entity = (DBForm)p_BE;
                DBFormDtsRule ruledts = new DBFormDtsRule();
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    DBFormDts entityDts = (DBFormDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruledts.RAdd(entityDts, sqlTrans);
                }

                //ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//����ӱ�
                //FormNoControlRule rulest = new FormNoControlRule();
                //rulest.RAddSort((int)FormNoControlEnum.��ⵥ��,sqlTrans);


                FormNoControlRule rulefn = new FormNoControlRule();//���µ���
                int tempFormNoControlID = 0;
                string sql = "SELECT FormNoControlID FROM Enum_FormListDB WHERE ID=" + SysString.ToDBString(entity.FormListDBID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    
                }
                rulefn.RAddSort(tempFormNoControlID, sqlTrans);

                

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
                DBFormDtsRule ruledts = new DBFormDtsRule();
                ruledts.RSave((DBForm)p_BE, p_BE2, sqlTrans);//����ӱ�


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


        #region �ύУ���뵥��ϸ���ݺ��б����������Ƿ�һ��
        /// <summary>
        /// У���뵥����һ����
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public bool RCheckCorrectPackData(int p_ID, out string o_ErrorMsg)
        {
            o_ErrorMsg = string.Empty;

            bool outb = true;
            string sql = string.Empty;
            sql = "SELECT * FROM WH_DBFormDts WHERE MainID=" + p_ID;
            DataTable dtDts = SysUtils.Fill(sql);

            sql = "SELECT * FROM WH_DBFormDtsPack WHERE MainID=" + p_ID;
            DataTable dtDtsPack = SysUtils.Fill(sql);

            int rowID = 0;
            foreach (DataRow drDts in dtDts.Rows)//����У��
            {
                rowID++;
                //У���뵥��������ϸ�������Ƿ�һ��
                sql = "SELECT ID FROM WH_PackBox WHERE BoxNo IN(SELECT BoxNo FROM WH_DBFormDtsPack WHERE DID=" + drDts["ID"].ToString() + ")";
                sql += " AND (ItemCode<>" + SysString.ToDBString(drDts["ItemCode"].ToString()) + " OR ColorNum<>" + SysString.ToDBString(drDts["ColorNum"].ToString()) + "  OR ColorName<>" + SysString.ToDBString(drDts["ColorName"].ToString());
                sql += " OR Batch<>" + SysString.ToDBString(drDts["Batch"].ToString()) + " OR JarNum<>" + SysString.ToDBString(drDts["JarNum"].ToString());
                sql += ")";
                DataTable dtBoxNo = SysUtils.Fill(sql);
                if (dtBoxNo.Rows.Count != 0)//���쳣����
                {
                    o_ErrorMsg = "��" + rowID + "�����쳣,������ϸ���뵥���Բ�һ��" + Environment.NewLine + "�����±����뵥��ϸ";
                    outb = false;
                    break;
                }

                //У�������Ƿ�һ��
                if (outb)//�����֤ͨ������У��
                {
                    int mdCount = SysConvert.ToInt32(dtDtsPack.Compute("COUNT(ID)", " DID=" + drDts["ID"].ToString()));
                    decimal mdQty = SysConvert.ToDecimal(dtDtsPack.Compute("SUM(Qty)", " DID=" + drDts["ID"].ToString()));
                    if (SysConvert.ToInt32(drDts["PieceQty"]) != mdCount)
                    {
                        o_ErrorMsg = "��" + rowID + "�����쳣,������ϸ���뵥������һ��" + Environment.NewLine + "�����±����뵥��ϸ";
                        outb = false;
                        break;
                    }

                    if (SysConvert.ToInt32(drDts["PieceQty"]) != mdCount)
                    {
                        o_ErrorMsg = "��" + rowID + "�����쳣,������ϸ���뵥������һ��" + Environment.NewLine + "�����±����뵥��ϸ";
                        outb = false;
                        break;
                    }
                    //DataRow[] drDtsPackA = dtDtsPack.Select(" DID="+SysConvert.ToInt32(drDts["ID"]));//�ȶ���ɫƷ����ϸ�Ƿ�һ��
                }
            }
            return outb;
        }
        #endregion


        #region ���ɴ���

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
				DBForm entity=(DBForm)p_BE;				
				DBFormCtl control=new DBFormCtl(sqlTrans);
				entity.ID=(int)EntityIDTable.GetID((long)SysEntity.WH_DBForm,sqlTrans);
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
				DBForm entity=(DBForm)p_BE;				
				DBFormCtl control=new DBFormCtl(sqlTrans);				
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
				DBForm entity=(DBForm)p_BE;				
				DBFormCtl control=new DBFormCtl(sqlTrans);
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
        #endregion
    }
}
