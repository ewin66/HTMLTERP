using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;



namespace HttSoft.HTCPCheck.DataCtl
{
    /// <summary>
    /// Ŀ�ģ�WH_IOFormʵ��ҵ�������
    /// ����:�¼Ӻ�
    /// ��������:2009-4-23
    /// </summary>
    public class IOFormRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public IOFormRule()
        {
        }

        /// <summary>
        /// ��齫Ҫ�����������Ƿ����ҵ�����
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            IOForm entity = (IOForm)p_BE;
        }

        #region ���������
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
                string sql = "SELECT " + p_FieldName + " FROM WH_IOForm WHERE 1=1";
                sql += " AND ID IN(SELECT MainID FROM WH_IOFormDts WHERE 1=1 ";
                sql += ")";
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
        public DataTable RIOFormShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_IOFormDts WHERE 1=1 ";
         
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_IOFormDts WHERE 1=1";
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
        public DataTable RShowDtsPack(string p_condition)
        {
            try
            {
                return RShowDtsPack(p_condition, "*");
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
        public DataTable RShowDtsPack(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV2_WH_IOFormDtsPack WHERE 1=1";
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
                IOForm entity = (IOForm)p_BE;
                IOFormDtsRule ruledts = new IOFormDtsRule();
                for (int i = 0; i < p_BE2.Length; i++)
                {
                    IOFormDts entityDts = (IOFormDts)p_BE2[i];
                    entityDts.MainID = entity.ID;
                    entityDts.Seq = i + 1;
                    ruledts.RAdd(entityDts, sqlTrans);
                }

                //ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//����ӱ�
                //FormNoControlRule rulest = new FormNoControlRule();
                //rulest.RAddSort((int)FormNoControlEnum.��ⵥ��,sqlTrans);


                FormNoControlRule rulefn = new FormNoControlRule();//���µ���
                int tempFormNoControlID = 0;
                string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    if (tempFormNoControlID == 0)//������û������ ���ȡ�����͵�������
                    {
                        sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.HeadType);
                        dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                        }
                    }
                }
                rulefn.RAddSort(tempFormNoControlID, sqlTrans);

                #region �����Զ�����

                //sql = "SELECT * FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                //dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count != 0)
                //{
                //    int saveLoadFormType = SysConvert.ToInt32(dt.Rows[0]["LoadFormTypeID"]);
                //    if (saveLoadFormType == (int)LoadFormType.�ͻ���)
                //    {
                //        sql = "SELECT LoadDtsID,ID,Seq FROM WH_IOFormDts WHERE MainID=" + SysString.ToDBString(entity.ID);
                //        dt = sqlTrans.Fill(sql);
                //        for (int i = 0; i < dt.Rows.Count; i++)
                //        {
                //            int LoadDtsID = SysConvert.ToInt32(dt.Rows[i]["LoadDtsID"]);
                //            int Seq = SysConvert.ToInt32(dt.Rows[i]["Seq"]);
                //            int ID = SysConvert.ToInt32(dt.Rows[i]["ID"]);
                //            int SubSeq = 1;
                //            if (LoadDtsID > 0)
                //            {
                //                sql = "SELECT * FROM Sale_FHFormDtsPack WHERE DID=" + SysString.ToDBString(LoadDtsID);
                //                DataTable dtfh = sqlTrans.Fill(sql);
                              
                //                for (int j = 0; j < dtfh.Rows.Count; j++)
                //                {
                //                    IOFormDtsPackRule rulePack = new IOFormDtsPackRule();
                //                    IOFormDtsPack entityPack = new IOFormDtsPack();
                //                    entityPack.MainID = entity.ID;
                //                    entityPack.Seq = Seq;
                //                    entityPack.DID = ID;
                //                    entityPack.SubSeq = SubSeq;
                //                    entityPack.BoxNo = SysConvert.ToString(dtfh.Rows[j]["BoxNo"]);
                //                    entityPack.Remark = SysConvert.ToString(dtfh.Rows[j]["BoxNo"]);
                //                    entityPack.Qty = SysConvert.ToDecimal(dtfh.Rows[j]["Qty"]);
                //                    SubSeq++;
                //                    rulePack.RAdd(entityPack,sqlTrans);
                                    
                //                }
                //            }
                //        }

                //    }
                //}

                
                #endregion

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
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd2(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd2(p_BE, p_BE2, sqlTrans);

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
        public void RAdd2(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                IOForm entity = (IOForm)p_BE;
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//����ӱ�
                FormNoControlRule rulest = new FormNoControlRule();
                //rulest.RAddSort((int)FormNoControlEnum.���ⵥ��, sqlTrans);

                FormNoControlRule rulefn = new FormNoControlRule();//���µ���
                int tempFormNoControlID = 0;
                string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    if (tempFormNoControlID == 0)//������û������ ���ȡ�����͵�������
                    {
                        sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.HeadType);
                        dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                        }
                    }
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
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd3(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd3(p_BE, p_BE2, sqlTrans);

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
        public void RAdd3(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                IOForm entity = (IOForm)p_BE;
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//����ӱ�


                FormNoControlRule rulefn = new FormNoControlRule();//���µ���
                int tempFormNoControlID = 0;
                string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    if (tempFormNoControlID == 0)//������û������ ���ȡ�����͵�������
                    {
                        sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.HeadType);
                        dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                        }
                    }
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
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd4(BaseEntity p_BE, BaseEntity[] p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd4(p_BE, p_BE2, sqlTrans);

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
        public void RAdd4(BaseEntity p_BE, BaseEntity[] p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAdd(p_BE, sqlTrans);
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//����ӱ�



                IOForm entity = (IOForm)p_BE;
                FormNoControlRule rulefn = new FormNoControlRule();//���µ���
                int tempFormNoControlID = 0;
                string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    if (tempFormNoControlID == 0)//������û������ ���ȡ�����͵�������
                    {
                        sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.HeadType);
                        dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                        }
                    }
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
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//����ӱ�


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
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2,BaseEntity p_BE3, BaseEntity[] p_BE4)
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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, BaseEntity p_BE3, BaseEntity[] p_BE4, IDBTransAccess sqlTrans)
        {
            try
            {

                this.RUpdate(p_BE, sqlTrans);
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//����ӱ�  

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

                    this.RAdd(p_BE, sqlTrans);

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
        public void RAdd(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOForm entity = (IOForm)p_BE;
                IOFormCtl control = new IOFormCtl(sqlTrans);
                //У�鵥��Ψһ��
                string sql = "SELECT FormNo FROM WH_IOForm WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                if (sqlTrans.Fill(sql).Rows.Count != 0)
                {
                    throw new Exception("�����Ѿ����ڣ����������ɵ���");
                }

                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WH_IOForm, sqlTrans);
                control.AddNew(entity);


                FormNoControlRule rulefn = new FormNoControlRule();//���µ���
                int tempFormNoControlID = 0;
                sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                    if (tempFormNoControlID == 0)//������û������ ���ȡ�����͵�������
                    {
                        sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.HeadType);
                        dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            tempFormNoControlID = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString());
                        }
                    }
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
        public void RUpdate(BaseEntity p_BE)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOForm entity = (IOForm)p_BE;
                IOFormCtl control = new IOFormCtl(sqlTrans);
                control.Update(entity);
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

                    this.RDelete(p_BE, sqlTrans);

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
        /// ɾ��
        /// </summary>
        /// <param name="p_BE">Ҫɾ����ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RDelete(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOForm entity = (IOForm)p_BE;
                IOFormCtl control = new IOFormCtl(sqlTrans);

                string sql = string.Empty;
                int FormListTopType = IOFormDtsRule.GetFormListTopTypeByFormListID(entity.HeadType, sqlTrans);//���㵥������


                if (FormListTopType == (int)WHFormList.�ڳ���� || FormListTopType == (int)WHFormList.���)//��������
                {
                    sql = "DELETE FROM WH_PackBox WHERE BoxNo IN(SELECT BoxNo FROM WH_IOFormDtsPack WHERE MainID=" + entity.ID.ToString() + ")";
                    sqlTrans.ExecuteNonQuery(sql);//ɾ������뵥����
                }

                sql = "DELETE FROM WH_IOFormDts WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������ϸ����


                sql = "DELETE FROM WH_IOFormDtsPack WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ�����뵥��ϸ����



                sql = "DELETE FROM WH_IOFormDtsInputPack WHERE MainID=" + entity.ID.ToString();
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ����¼���뵥��ϸ����


                control.Delete(entity);
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
        /// ɾ��
        /// </summary>
        /// <param name="p_IOFormID">����ID</param>
        public void RDelete(int p_IOFormID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    RDelete(p_IOFormID, sqlTrans);

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
        /// ɾ��
        /// </summary>
        /// <param name="p_IOFormID">����ID</param>
        /// <param name="sqlTrans">������</param>
        public void RDelete(int p_IOFormID, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "UPDATE WH_IOForm SET DelFlag=1 WHERE ID=" + SysString.ToDBString(p_IOFormID);
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


    

        #region �����¼�
        /// <summary>
        /// ���ݴ��ϵ�кŴӲɹ����õ�����ϵ�к�
        /// </summary>
        /// <param name="p_dsn"></param>
        /// <returns></returns>
        public DataTable GetSSN(string p_dsn)
        {
            string sql = "SELECT * FROM Buy_YarnCompact WHERE DSN="+SysString.ToDBString(p_dsn);
            DataTable dt = SysUtils.Fill(sql);
            return dt;

        }
        public DataTable GetSSNFromSOM(string p_dsn)
        {
            string sql = " SELECT * FROM Sale_SOM WHERE DSN=" + SysString.ToDBString(p_dsn);
            DataTable dt = SysUtils.Fill(sql);
            return dt;
        }
        #endregion


   

        #region ��������
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList List)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_BE, p_BE2, List, sqlTrans);

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
        public void RAdd(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {

                //RCheckMDQty(p_BE, p_BE2, list);//У���뵥��ϸ�͵�����ϸ�����Ƿ�һ��

                IOForm entity = (IOForm)p_BE;
                this.RAdd(p_BE, sqlTrans);
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, (IOFormDts[])p_BE2, sqlTrans);//����ӱ�


                IOFormDtsPackRule dtsprule = new IOFormDtsPackRule();//�����뵥��ϸ
                dtsprule.RSave(entity, (IOFormDts[])p_BE2, list, sqlTrans);


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
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd2(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList List)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd2(p_BE, p_BE2, List, sqlTrans);

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
        public void RAdd2(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {
                //RCheckMDQty(p_BE, p_BE2, list);//У���뵥��ϸ�͵�����ϸ�����Ƿ�һ��

                IOForm entity = (IOForm)p_BE;

                this.RAdd(p_BE, sqlTrans);
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, p_BE2, sqlTrans);//����ӱ�


                IOFormDtsPackRule dtsprule = new IOFormDtsPackRule();//�����뵥��ϸ
                dtsprule.RSave(entity, (IOFormDts[])p_BE2, list, sqlTrans);

              
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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList list)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_BE2, list, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, BaseEntity[] p_BE2, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {

                //RCheckMDQty(p_BE, p_BE2, list);//У���뵥��ϸ�͵�����ϸ�����Ƿ�һ��

                IOForm entity = (IOForm)p_BE;
                this.RUpdate(p_BE, sqlTrans);
                IOFormDtsRule ruledts = new IOFormDtsRule();
                ruledts.RSave((IOForm)p_BE, (IOFormDts[])p_BE2, sqlTrans);//����ӱ�

                //ɾ�����ݿ��д˵������͵��뵥��Ϣ2011-07-12

                IOFormDtsPackRule dtsprule = new IOFormDtsPackRule();//�����뵥��ϸ
                dtsprule.RSave(entity, (IOFormDts[])p_BE2, list, sqlTrans);
              
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
        /// <param name="p_Type">0/1/2/3:����/���</param>
        public void RSubmit(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                int p_TempType = p_Type;//����״̬
                string sql = string.Empty;
                IOForm entity = new IOForm(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();

                //if (!RSubmitCheckJS(entity.FormDate, sqlTrans))
                //{
                //    throw new Exception("������������˵�������֮���Ѿ��н�������");
                //}

                if (entity.SubmitFlag == p_Type)//�����ͬ�쳣
                {
                    throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
                }

                int p_AuditFlag = -1;
                sql = "SELECT FillDataTypeID,AuditFlag,WHQtyPosID,CheckQtyPer1,CheckQtyFrom,CheckQtyPer2,DZFlag FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entity.SubType);
                DataTable dtFormList = sqlTrans.Fill(sql);
                if (dtFormList.Rows.Count != 0)
                {
                    p_AuditFlag = SysConvert.ToInt32(dtFormList.Rows[0]["AuditFlag"]);
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

                    //����ת���󵥾ݵ�״̬
                    sql = "UPDATE WH_IOForm SET SubmitFlag=" + SysString.ToDBString(p_Type);
                    if (p_Type == (int)ConfirmFlag.���ͨ�� || p_Type == (int)ConfirmFlag.��˾ܾ�)
                    {
                        sql += ",SubmitOPID=" + SysString.ToDBString(ParamConfig.LoginName) + ",SubmitTime=" + SysString.ToDBString(DateTime.Now);
                    }
                    sql += " WHERE FromIOFormID=" + p_FormID.ToString();
                    sqlTrans.ExecuteNonQuery(sql);


                    //��ʼ������ж��Ƿ���Ҫ�ύ
                    int TempSubmitType = 0;//�ύ�ͳ����ύ״̬
                    bool SubmitFlag = false;//�Ƿ���Ҫ�ύ
                    if (p_AuditFlag == 0)//����Ҫ���
                    {
                        switch (p_TempType)
                        {
                            case (int)ConfirmFlag.���ͨ��:
                                SubmitFlag = true;
                                TempSubmitType = 1;
                                break;
                            case (int)ConfirmFlag.��˾ܾ�:
                                TempSubmitType = 0;
                                break;
                            case (int)ConfirmFlag.���ύ:
                                SubmitFlag = true;
                                TempSubmitType = 1;
                                break;
                            case (int)ConfirmFlag.δ�ύ:
                                SubmitFlag = true;
                                TempSubmitType = 0;
                                break;
                        }
                    }
                    else//��Ҫ���
                    {
                        switch (p_TempType)
                        {
                            case (int)ConfirmFlag.���ͨ��:
                                TempSubmitType = 1;
                                SubmitFlag = true;
                                break;
                            case (int)ConfirmFlag.��˾ܾ�:
                                if (entity.SubmitFlag == (int)ConfirmFlag.���ͨ��)//���֮ǰ��״̬�����ͨ���Ĳ�ִ��
                                {
                                    TempSubmitType = 0;
                                    SubmitFlag = true;
                                }
                                break;
                            case (int)ConfirmFlag.���ύ:
                                break;
                            case (int)ConfirmFlag.δ�ύ:
                                break;
                        }
                    }

                    if (SubmitFlag)//��Ҫִ���ύ����
                    {

                        IOFormDtsRule ruledts = new IOFormDtsRule();
                        ruledts.RSubmit(p_FormID, TempSubmitType, dtFormList.Rows[0], sqlTrans);//�����ӱ���

                    }
                    #endregion


                }
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

        #endregion
    }
}
