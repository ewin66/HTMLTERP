using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;

namespace HttSoft.MLTERP.DataCtl
{
    /// <summary>
    /// Ŀ�ģ�WH_IOFormDtsʵ��ҵ�������
    /// ����:�¼Ӻ�
    /// ��������:2009-4-23
    /// </summary>
    public class IOFormDtsRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public IOFormDtsRule()
        {
        }

        /// <summary>
        /// ��齫Ҫ�����������Ƿ����ҵ�����
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            IOFormDts entity = (IOFormDts)p_BE;
        }


        #region  ��ʾ����

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
        public DataTable RShowDts2(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDts WHERE 1=1";
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
        public DataTable RShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDts WHERE 1=1";
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
        public DataTable SOShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDtsISN WHERE 1=1";
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
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDts WHERE 1=1";
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
        public DataTable RShow(int p_ID, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDts WHERE 1=1";
                sql += " AND MainID=" + p_ID;
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
        /// ��ʾ����                  // ����÷��� ����ʾ����ⱨ��
        /// </summary>
        /// <param name="p_condition"></param>

        public DataTable RShowIO(string p_condition, string p_FieldName)
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

        #endregion

        #region ���淽��
        /// <summary>
        /// ����(����������)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSave(IOForm p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;

                sql = "";//ɾ���뵥��ϸ����������䣻��������Ҫɾ��ԭʼ�뵥����Ҫ��ϸ�о�����ΪĳЩ�����(���鲼)ԭʼ�뵥������Ҫ�����

                sql = "DELETE FROM WH_IOFormDts WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������Ӧ��ɾ������ϸ���ݣ������ݿ����е���UI���Ѿ�ɾ��������



                int FormListTopType = GetFormListTopTypeByFormListID(p_Entity.HeadType, sqlTrans);//���㵥������
                if (FormListTopType == (int)WHFormList.���)//ɾ��û�õ�ϸ��
                {
                    sql = "DELETE FROM WH_PackBox WHERE BoxNo in(select BoxNo from WH_IOFormDtsPack where MainID=" + p_Entity.ID.ToString();
                    sql += " AND DID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                    sql += ")";
                    sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������Ӧ��ɾ������ϸ���ݣ������ݿ����е���UI���Ѿ�ɾ��������
                }


                sql = "DELETE FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND DID NOT IN" + string.Format("({0})", GetIDExist(p_BE));
                sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������Ӧ��ɾ������ϸ���ݣ������ݿ����е���UI���Ѿ�ɾ��������







                for (int i = 0; i < p_BE.Length; i++)
                {
                    IOFormDts entitydts = (IOFormDts)p_BE[i];
                    if (entitydts.ID != 0)//ID��Ϊ0˵�����ݿ����Ѿ�����
                    {
                        this.RUpdate(entitydts, sqlTrans);

                        ///��ֹ����ɾ�в�����Seq���¸�ֵ
                        sql = "Update WH_IOFormDtsPack Set Seq=" + entitydts.Seq + " where  MainID=" + p_Entity.ID.ToString();
                        sql += " AND DID =" + entitydts.ID;
                        sqlTrans.ExecuteNonQuery(sql);//



                    }
                    else
                    {
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(entitydts, sqlTrans);
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

        /// <summary>
        /// ������ݿ���û�б�ɾ����ID(�����ݿ����ж���UI��Ҳû��ɾ��������)
        /// </summary>
        /// <param name="p_BE"></param>
        /// <returns></returns>
        private string GetIDExist(BaseEntity[] p_BE)
        {
            string outstr = "0";
            for (int i = 0; i < p_BE.Length; i++)
            {
                IOFormDts entitydts = (IOFormDts)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
        }
        #endregion


        #region ����

        ///// <summary>
        ///// ����(����������)
        ///// </summary>
        ///// <param name="p_Entity"></param>
        ///// <param name="p_BE"></param>
        ///// <param name="sqlTrans"></param>
        //public void RSave(IOForm p_Entity, BaseEntity[] p_BE, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {
        //        string sql = "DELETE FROM WH_IOFormDts WHERE MainID=" + p_Entity.ID.ToString();
        //        sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������ϸ����
        //        for (int i = 0; i < p_BE.Length; i++)
        //        {
        //            IOFormDts entitydts = (IOFormDts)p_BE[i];
        //            sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM WH_IOFormDts WHERE MainID=" + p_Entity.ID.ToString();
        //            entitydts.Seq = SysConvert.ToInt32(sqlTrans.Fill(sql).Rows[0][0].ToString());//�ҵ�����Seq
        //            entitydts.MainID = p_Entity.ID;
        //            this.RAdd(entitydts, sqlTrans);
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

        #endregion


        #region ��������

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
                IOFormDts entity = (IOFormDts)p_BE;
                IOFormDtsCtl control = new IOFormDtsCtl(sqlTrans);

                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WH_IOFormDts, sqlTrans);
                control.AddNew(entity);
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
                IOFormDts entity = (IOFormDts)p_BE;
                IOFormDtsCtl control = new IOFormDtsCtl(sqlTrans);
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
                IOFormDts entity = (IOFormDts)p_BE;
                IOFormDtsCtl control = new IOFormDtsCtl(sqlTrans);
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


        #region �ύ�����ύ--������
        /// <summary>
        /// ���ͨ������˾ܾ�
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        /// <param name="drFormList">����С�������ֵ��</param>
        /// <returns></returns>
        public void RSubmit(int p_FormID, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            try
            {
                IOForm entity = new IOForm(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();

                int FormListTopType = GetFormListTopTypeByFormListID(entity.HeadType, sqlTrans);//���㵥������

                IOFormDts[] entitydts = this.RGetFormDts(p_FormID, sqlTrans);
                for (int i = 0; i < entitydts.Length; i++)
                {
                    if (FormListTopType == (int)WHFormList.�̵�)//�����ͬ���̵�
                    {
                        if (entitydts[i].MoveQty == entitydts[i].SourceQty && entitydts[i].SourceQty != 0)
                        {
                            if (entity.SubType == 801)
                            {
                                UpdatePDDate(p_FormID, p_Type, entitydts[i].ID, sqlTrans);
                            }
                            continue;
                        }
                    }
                    if (FormListTopType == (int)WHFormList.�ƿ�)//�������λ��ͬ���ƿ�
                    {
                        if (entitydts[i].WHID == entitydts[i].ToWHID
                            && entitydts[i].SectionID == entitydts[i].ToSectionID
                            && entitydts[i].SBitID == entitydts[i].ToSBitID)
                        {
                            continue;
                        }
                    }



                    StorgeRule rulest = new StorgeRule();//������
                    rulest.RSubmit(FormListTopType, entity, entitydts[i], p_Type, sqlTrans);
                }

                PackBoxProc(FormListTopType, entity, entitydts, p_Type, sqlTrans);//����װ�䵥����

                RFillDataType(entity, entitydts, p_Type, SysConvert.ToInt32(drFormList["FillDataTypeID"]), drFormList, sqlTrans);//�������ݴ���
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

        private void UpdatePDDate(int p_FormID, int p_Type, int p_ID, IDBTransAccess sqlTrans)
        {
            IOFormDts entity = new IOFormDts();
            entity.ID = p_ID;
            entity.SelectByID();
            if (p_Type == (int)ConfirmFlag.δ�ύ)
            {
                string sql = "UPDATE WH_Storge SET PDDate=NULL";
                sql += " WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                sql += " AND GoodsCode=" + SysString.ToDBString(entity.GoodsCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entity.ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entity.ColorName);
                sql += " AND SectionID=" + SysString.ToDBString(entity.SectionID);
                sql += " AND WHID=" + SysString.ToDBString(entity.WHID);
                sqlTrans.ExecuteNonQuery(sql);
            }
            else
            {
                string sql = "UPDATE WH_Storge SET PDDate=" + SysString.ToDBString(DateTime.Now.Date);
                sql += " WHERE ItemCode=" + SysString.ToDBString(entity.ItemCode);
                sql += " AND GoodsCode=" + SysString.ToDBString(entity.GoodsCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entity.ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entity.ColorName);
                sql += " AND SectionID=" + SysString.ToDBString(entity.SectionID);
                sql += " AND WHID=" + SysString.ToDBString(entity.WHID);
                sqlTrans.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// ����װ�䵥״̬
        /// </summary>
        void PackBoxProc(int p_FormListTopType, IOForm p_entity, IOFormDts[] p_entitydts, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            sql = "SELECT Seq,BoxNo,Qty,FactQty,Weight,Yard,GoodsLevel FROM WH_IOFormDtsPack WHERE MainID=" + SysString.ToDBString(p_entity.ID) + " ORDER BY MainID,Seq";
            DataTable dtBoxNo = sqlTrans.Fill(sql);
            for (int i = 0; i < dtBoxNo.Rows.Count; i++)
            {
                //Ѱ�Ҷ�Ӧ�ֿⵥ����ϸ���
                int ioformdtsdex = -1;
                for (int m = 0; m < p_entitydts.Length; m++)
                {
                    if (p_entitydts[m].Seq == SysConvert.ToInt32(dtBoxNo.Rows[i]["Seq"]))//�ҵ���ͬ��SEQ��
                    {
                        ioformdtsdex = m;
                        break;
                    }
                }
                if (ioformdtsdex == -1)//δ�ҵ����쳣
                {
                    throw new Exception("�뵥�쳣��δ�ҵ�������ϸ���к�:" + SysConvert.ToInt32(dtBoxNo.Rows[0]["Seq"]));
                }


                //Ѱ���뵥���
                PackBoxRule pbrule = new PackBoxRule();
                PackBox entity = pbrule.RGetEntityByBoxNo(dtBoxNo.Rows[i]["BoxNo"].ToString(), sqlTrans);
                if (entity.ID == 0)
                {
                    throw new Exception("�쳣���뵥��ϸ����δ�洢���뵥��ű��ڣ����Գ������������뵥��ϸ����");
                }


                switch (p_FormListTopType)
                {
                    case (int)WHFormList.���:
                        if (p_Type == (int)YesOrNo.Yes)//�ύ
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.δ���)
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "���Ǵ���δ���״̬��������ı�δ���״̬");
                            }
                            entity.WHID = p_entitydts[ioformdtsdex].WHID;
                            entity.SectionID = p_entitydts[ioformdtsdex].SectionID;
                            entity.SBitID = p_entitydts[ioformdtsdex].SBitID;
                            entity.InFormNo = p_entity.FormNo;
                            entity.BoxStatusID = (int)EnumBoxStatus.���;


                            ///����У����������״̬  zhoufc
                            sql = "Update WO_BProductCheckDts set InWHFlag=1 where DISN =" + SysString.ToDBString(entity.BoxNo);
                            sqlTrans.ExecuteNonQuery(sql);//
                        }
                        else//�����ύ
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.���)
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "���Ǵ������״̬��������ı�Ϊδ���״̬");
                            }
                            entity.BoxStatusID = (int)EnumBoxStatus.δ���;

                            ///����У����������״̬ zhoufc
                            sql = "Update WO_BProductCheckDts set InWHFlag=0 where DISN =" + SysString.ToDBString(entity.BoxNo);
                            sqlTrans.ExecuteNonQuery(sql);//
                        }

                        pbrule.RUpdate(entity, sqlTrans);//��������
                        break;

                    case (int)WHFormList.����:
                        if (p_Type == (int)YesOrNo.Yes)//�ύ
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.���)
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "���Ǵ������״̬��������ı�Ϊ����״̬");
                            }

                            entity.OutFormNo = p_entity.FormNo;
                            entity.BoxStatusID = (int)EnumBoxStatus.����;
                        }
                        else//�����ύ
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.����)
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "���Ǵ��ڳ���״̬��������ı�δ���״̬");
                            }
                            entity.BoxStatusID = (int)EnumBoxStatus.���;
                        }

                        pbrule.RUpdate(entity, sqlTrans);//��������
                        break;

                    case (int)WHFormList.�̵�://�̵�Ӧ���ı�����,Ҫ��������
                        if (p_Type == (int)YesOrNo.Yes)//�ύ
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.���)
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "���Ǵ������״̬���������ƿ�");
                            }
                            entity.Qty = SysConvert.ToDecimal(dtBoxNo.Rows[i]["Qty"]);
                            entity.Weight = SysConvert.ToDecimal(dtBoxNo.Rows[i]["Weight"]);
                            //if(entity.BoxNo)
                        }
                        else//�����ύ
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.���)
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "���Ǵ������״̬���������ƿ�");
                            }
                            entity.Qty = SysConvert.ToDecimal(dtBoxNo.Rows[i]["Qty"]);
                            entity.Weight = SysConvert.ToDecimal(dtBoxNo.Rows[i]["Weight"]);
                        }

                        pbrule.RUpdate(entity, sqlTrans);//��������
                        break;

                    case (int)WHFormList.�ƿ�://�ƿ�Ӧ�ı���λ״̬��Ҫ��������
                        if (p_Type == (int)YesOrNo.Yes)//�ύ
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.���)
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "���Ǵ������״̬���������ƿ�");
                            }

                            if (entity.Qty != SysConvert.ToDecimal(dtBoxNo.Rows[i]["Qty"]))
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "�����Ѹı䣬����������������Ƿ���й���ƥ����");
                            }
                            entity.WHID = p_entitydts[ioformdtsdex].ToWHID;
                            entity.SectionID = p_entitydts[ioformdtsdex].ToSectionID;
                            entity.SBitID = p_entitydts[ioformdtsdex].ToSBitID;
                        }
                        else//�����ύ
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.���)
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "���Ǵ������״̬���������ƿ�");
                            }
                            if (entity.Qty != SysConvert.ToDecimal(dtBoxNo.Rows[i]["Qty"]))
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "�����Ѹı䣬����������������Ƿ���й���ƥ����");
                            }
                            entity.WHID = p_entitydts[ioformdtsdex].WHID;
                            entity.SectionID = p_entitydts[ioformdtsdex].SectionID;
                            entity.SBitID = p_entitydts[ioformdtsdex].SBitID;
                        }

                        pbrule.RUpdate(entity, sqlTrans);//��������
                        break;
                }
                #region �̵�ע��
                //if (p_FormListTopType == (int)WHFormList.�̵�)
                //{
                //    for (int f = 0; f < p_entitydts.Length; f++)
                //    {
                //        sql = "SELECT * FROM WH_PackBox WHERE BoxNo NOT IN( SELECT BoxNo FROM WH_IOFormDtsPack WHERE DID=" + SysString.ToDBString(p_entitydts[f].ID) + " )";
                //        #region
                //        sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(p_entitydts[f].WHID);//��òֿ���������ֶ�
                //        DataTable dt = SysUtils.Fill(sql);
                //        string FieldNamestr = string.Empty;
                //        if (dt.Rows.Count != 0)
                //        {
                //            FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
                //        }
                //        #endregion
                //        sql = "SELECT *  FROM UV1_WH_PackBox WHERE 1=1";
                //        sql += " AND WHID=" + SysString.ToDBString(p_entitydts[f].WHID);
                //        sql += " AND SectionID=" + SysString.ToDBString(p_entitydts[f].SectionID);
                //        sql += " AND SBitID=" + SysString.ToDBString(p_entitydts[f].SBitID);
                //        sql += "AND BoxNo NOT IN( SELECT BoxNo FROM WH_IOFormDtsPack WHERE DID=" + SysString.ToDBString(p_entitydts[f].ID) + " )";
                //        int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
                //        if (FieldNamestr != string.Empty)
                //        {
                //            string[] FieldName = FieldNamestr.Split('+');
                //            for (int h = 0; h < FieldName.Length; h++)
                //            {
                //                string sqlFieldName = "SELECT ID FROM Enum_WHCalMethodFieldName WHERE Name=" + SysString.ToDBString(FieldName[h]);//�ҵ��������ֶζ�Ӧ��ID
                //                DataTable dtFieldName = SysUtils.Fill(sqlFieldName);
                //                if (dtFieldName.Rows.Count != 0 && dtFieldName.Rows[0]["ID"].ToString() != "")
                //                {
                //                    CalFieldName = SysConvert.ToInt32(dtFieldName.Rows[0]["ID"]);
                //                }
                //                switch (CalFieldName)
                //                {
                //                    case (int)WHCalMethodFieldName.ItemCode://��Ʒ����
                //                        sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(p_entitydts[f].ItemCode);
                //                        break;
                //                    case (int)WHCalMethodFieldName.ColorNum://ɫ��
                //                        sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(p_entitydts[f].ColorNum);
                //                        break;
                //                    case (int)WHCalMethodFieldName.ColorName://��ɫ
                //                        sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(p_entitydts[f].ColorName);
                //                        break;
                //                    case (int)WHCalMethodFieldName.Batch:   //����
                //                        sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(p_entitydts[f].Batch);
                //                        break;
                //                    case (int)WHCalMethodFieldName.VendorBatch:  //�ͻ�����
                //                        sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(p_entitydts[f].VendorBatch);
                //                        break;
                //                    case (int)WHCalMethodFieldName.JarNum:  //�׺�
                //                        sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(p_entitydts[f].JarNum);
                //                        break;
                //                    case (int)WHCalMethodFieldName.MWidth://�ŷ�
                //                        sql += " AND ISNULL(MWidth,0)=" + SysString.ToDBString(p_entitydts[f].MWidth);
                //                        break;
                //                    case (int)WHCalMethodFieldName.MWeight://����
                //                        sql += " AND ISNULL(MWeight,0)=" + SysString.ToDBString(p_entitydts[f].MWeight);
                //                        break;
                //                    default:
                //                        throw new Exception("�����쳣�����㶨����ֶεײ�δ��Ӧ��" + CalFieldName + ",����ϵ����Ա");
                //                }
                //            }
                //        }

                //        sql += " AND (ISNULL(Qty,0)>0 OR ISNULL(Weight,0)>0)";

                //        if (p_Type == (int)YesOrNo.Yes)//�ύ
                //        {
                //            sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.���);
                //            DataTable dtBox = sqlTrans.Fill(sql);
                //            if (dtBox.Rows.Count > 0)
                //            {
                //                sql = "UPDATE WH_PackBox SET BoxStatusID =" + SysString.ToDBString((int)EnumBoxStatus.�̵�);
                //                sql += " WHERE BoxNo IN (";
                //                string str = string.Empty;
                //                foreach (DataRow dr in dtBox.Rows)
                //                {
                //                    if (str != string.Empty)
                //                    {
                //                        str += ",";
                //                    }
                //                    str += SysString.ToDBString(SysConvert.ToString(dr["BoxNo"]));
                //                }
                //                sql += str + ")";
                //                sqlTrans.ExecuteNonQuery(sql);
                //            }


                //        }
                //        else//�����ύ
                //        {
                //            sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.�̵�);
                //            DataTable dtBox = sqlTrans.Fill(sql);
                //            if (dtBox.Rows.Count > 0)
                //            {
                //                sql = "UPDATE WH_PackBox SET BoxStatusID =" + SysString.ToDBString((int)EnumBoxStatus.���);
                //                sql += " WHERE BoxNo IN (";
                //                string str = string.Empty;
                //                foreach (DataRow dr in dtBox.Rows)
                //                {
                //                    if (str != string.Empty)
                //                    {
                //                        str += ",";
                //                    }
                //                    str += SysString.ToDBString(SysConvert.ToString(dr["BoxNo"]));
                //                }
                //                sql += str + ")";
                //                sqlTrans.ExecuteNonQuery(sql);
                //            }
                //        }
                //        //pbrule.RUpdate(entity, sqlTrans);//��������
                //    }
                //}
                #endregion
            }
        }
        #endregion


        #region �������ݴ���
        /// <summary>
        /// ���������ܴ�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        /// <param name="p_FillDataTypeID">���������</param>
        /// <returns></returns>
        public void RFillDataType(IOForm entity, IOFormDts[] entitydts, int p_Type, int p_FillDataTypeID, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            switch (p_FillDataTypeID)
            {
                case (int)EnumFillDataType.�ɹ�����׼�����:   //��������
                    goto case (int)EnumFillDataType.�ɹ�������׼�����;
                //case (int)EnumFillDataType.����ɴ�߲ɹ������:
                //    RFillDataPSCGRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //break;
                case (int)EnumFillDataType.���۳����׼�����:
                    RFillDataXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    RFillDataXSCKFH(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                case (int)EnumFillDataType.���۳�����������۶�������:
                    RFillDataXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;

                case (int)EnumFillDataType.�ɹ�������׼�����:
                    RFillDataCGRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;


                case (int)EnumFillDataType.�ӹ�������׼�����:
                    RFillDataWORK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                case (int)EnumFillDataType.���۳���������۳�����:
                    RFillDataXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                //case (int)EnumFillDataType.��������׼�����:
                //    RFillDataDYRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;
                //case (int)EnumFillDataType.�������۳����׼�����:
                //    RFillDataDYXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    RFillDataXSCKFH(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;
                case (int)EnumFillDataType.Ⱦ���ӹ������׼�����:
                    RFillDataRBCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                case (int)EnumFillDataType.Ⱦ���ӹ�����׼�����:
                    RFillDataRBRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;

                case (int)EnumFillDataType.�����ӹ�����׼�����:
                    RFillDataHZRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                case (int)EnumFillDataType.�����ӹ������׼�����:
                    RFillDataHZCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;

                case (int)EnumFillDataType.��Ʒ�ӹ�����׼�����:
                    RFillDataCPHZRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;

                //case (int)EnumFillDataType.ӡ���ӹ������׼�����:
                //    RFillDataYHCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;
                //case (int)EnumFillDataType.ӡ���ӹ�����׼�����:
                //    RFillDataYHRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;


                case (int)EnumFillDataType.֯��ӹ������׼�����:
                    RFillDataZZCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
                case (int)EnumFillDataType.֯��ӹ�����׼�����:
                    RFillDataZZRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                    break;
            }

        }

        #region �ɹ�����׼�����
        /// <summary>
        /// �ɹ�����׼�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataCGRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            SaleOrderRule sorule = new SaleOrderRule();
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,TotalRecQty,* FROM UV1_Buy_ItemBuyFormDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {

                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                    }

                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisWeight = 0 - thisWeight;//�˻��ø�������
                    }

                    string Unit = SysConvert.ToString(dtData.Rows[0]["Unit"]);//�ɹ��ĵ�λ

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalRecQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE Buy_ItemBuyFormDts SET ";
                        sql += " ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (Unit.EndsWith("KG"))//����ɹ��ĵ�λ�ǹ��� ������
                        {
                            sql += ",ReceivedQty=" + "(" + SysString.ToDBString(thisWeight) + ")";
                            sql += ",TotalRecQty=ISNULL(TotalRecQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        else
                        {
                            sql += ",ReceivedQty=" + "(" + SysString.ToDBString(thisQty) + ")";
                            sql += ",TotalRecQty=ISNULL(TotalRecQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalRecQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE Buy_ItemBuyFormDts SET ";

                        sql += " ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",ReceivedQty=0";
                        if (Unit.EndsWith("KG"))
                        {
                            sql += ",TotalRecQty=ISNULL(TotalRecQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        else
                        {
                            sql += ",TotalRecQty=ISNULL(TotalRecQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ�Ĳɹ�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }


                sorule.RUpdateStep(entitydts[i].DtsOrderFormNo, entitydts[i].ItemCode, entitydts[i].ColorNum, entitydts[i].ColorName, 0, entity.SubType, 0, 0, p_Type, true, sqlTrans);//���¶������� (int)EnumOrderStep.�ɹ����



            }
        }
        #endregion

        #region �ӹ�����׼�����
        /// <summary>
        /// �ӹ�����׼�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataWORK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }

            SaleOrderRule sorule = new SaleOrderRule();

            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,InQty FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",ReceivedQty=" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",TotalRecQty=ISNULL(TotalRecQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",ReceivedQty=0";
                        sql += ",TotalRecQty=ISNULL(TotalRecQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ�ļӹ�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

                sorule.RUpdateStep(entitydts[i].DtsOrderFormNo, entitydts[i].ItemCode, entitydts[i].ColorNum, entitydts[i].ColorName, 0, entity.SubType, 0, 0, p_Type, true, sqlTrans);//���¶������� (int)EnumOrderStep.�ɹ����

            }
        }
        #endregion

        #region ���۳����׼�����
        /// <summary>
        /// ���۳����׼�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataXSCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            SaleOrderRule sorule = new SaleOrderRule();
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }


            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,Weight,Yard,PieceQty,TotalRecQty,TotalRecWeight,TotalRecYard,TotalRecPieceQty FROM UV1_Sale_SaleOrderDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsOrderFormNo);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    decimal thisWeight = entitydts[i].Weight;
                    decimal thisYard = entitydts[i].Yard;
                    int thisPieceQty = entitydts[i].PieceQty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                        thisWeight = 0 - thisWeight;
                        thisYard = 0 - thisYard;
                        thisPieceQty = 0 - thisPieceQty;
                    }
                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalRecQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_SaleOrderDts SET ";
                        sql += " ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",ReceivedQty=" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",TotalRecQty=ISNULL(TotalRecQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",ReceivedWeight=" + "(" + SysString.ToDBString(thisWeight) + ")";
                        sql += ",TotalRecWeight=ISNULL(TotalRecWeight,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        sql += ",ReceivedYard=" + "(" + SysString.ToDBString(thisYard) + ")";
                        sql += ",TotalRecYard=ISNULL(TotalRecYard,0)+" + "(" + SysString.ToDBString(thisYard) + ")";
                        sql += ",ReceivedPieceQty=" + "(" + SysString.ToDBString(thisPieceQty) + ")";
                        sql += ",TotalRecPieceQty=ISNULL(TotalRecPieceQty,0)+" + "(" + SysString.ToDBString(thisPieceQty) + ")";
                        sql += ",OrderstepID = " + (int)EnumOrderStep.���۳���;//
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalRecQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_SaleOrderDts SET ";
                        sql += " ReceivedDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",ReceivedQty=0";
                        sql += ",TotalRecQty=ISNULL(TotalRecQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",ReceivedWeight=0";
                        sql += ",TotalRecWeight=ISNULL(TotalRecWeight,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        sql += ",ReceivedYard=0";
                        sql += ",TotalRecYard=ISNULL(TotalRecYard,0)-" + "(" + SysString.ToDBString(thisYard) + ")";
                        sql += ",ReceivedPieceQty=0";
                        sql += ",TotalRecPieceQty=ISNULL(TotalRecPieceQty,0)-" + "(" + SysString.ToDBString(thisPieceQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ�����۶�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }


                sorule.RUpdateStep(entitydts[i].DtsOrderFormNo, entitydts[i].ItemCode, entitydts[i].ColorNum, entitydts[i].ColorName, 0, entity.SubType, 0, 0, p_Type, true, sqlTrans);//���¶������� (int)EnumOrderStep.���۳���



            }
        }
        #endregion

        #region ��������׼�����
        /// <summary>
        /// ��������׼�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataDYRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT ID,Qty,InQty FROM Sale_DYGL WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_DYGL SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["ID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_DYGL SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["ID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ�ĵ���������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

            }
        }
        #endregion

        #region �������۳����׼�����
        /// <summary>
        /// �������۳����׼�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataDYXSCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }
            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT ID,Qty,OutQty FROM Sale_DYGL WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsOrderFormNo);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                    }
                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["OutQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_DYGL SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",OutQty=ISNULL(OutQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",DYStatusID=" + SysString.ToDBString((int)EnumDYStatus.�����);
                        sql += ",FormDate=" + SysString.ToDBString(DateTime.Now.Date);
                        sql += " WHERE ID=" + dtData.Rows[0]["ID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["OutQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_DYGL SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",OutQty=ISNULL(OutQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",DYStatusID=" + SysString.ToDBString((int)EnumDYStatus.������);
                        sql += ",FormDate=null";
                        sql += " WHERE ID=" + dtData.Rows[0]["ID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ�ĵ���������ɫ��" + entitydts[i].DtsOrderFormNo + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion

        #region ���۳��ⷢ���������(�ӷ����������۳������)
        /// <summary>
        /// ���۳��ⷢ���������(�ӷ����������۳������)
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataXSCKFH(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            SaleOrderRule sorule = new SaleOrderRule();
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }
            if (thFlag)//�˻�����������
            {
                return;
            }
            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,TotalSendQty FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalSendQty"]) + entitydts[i].Qty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_FHFormDts SET ";
                        sql += " SendDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += " ,DtsSendFlag=1";
                        sql += ",TotalSendQty=ISNULL(TotalSendQty,0)+" + SysString.ToDBString(entitydts[i].Qty);
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["TotalSendQty"]) - entitydts[i].Qty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE Sale_FHFormDts SET ";
                        sql += " SendDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (SysConvert.ToDecimal(dtData.Rows[0]["TotalSendQty"]) - entitydts[i].Qty <= 0)
                        {
                            sql += " ,DtsSendFlag=0";
                        }
                        sql += ",TotalSendQty=ISNULL(TotalSendQty,0)-" + SysString.ToDBString(entitydts[i].Qty);
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ�ķ���������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }





            }
        }
        #endregion

        #region Ⱦ���ӹ�����׼�����
        /// <summary>
        /// Ⱦ���ӹ�����׼�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataRBRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,InQty ,Unit FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                //sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND BCPItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);//���Ʒ����
                //sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND BCPColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    //������ĵ�λ �ͼӹ����ĵ�λ��һ��
                    if (!SysConvert.ToString(entitydts[i].Unit).EndsWith(SysConvert.ToString(dtData.Rows[0]["Unit"])))
                    {
                        throw new BaseException("��λ�ͼӹ����ĵ�λ��һ�£�����");
                    }

                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                    }

                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisWeight = 0 - thisWeight;//�˻��ø�������
                    }

                    decimal thisYard = entitydts[i].Yard;
                    if (thFlag)
                    {
                        thisYard = 0 - thisYard;//�˻��ø�������
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisYard) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisYard) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ��Ⱦ���ӹ�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

            }
        }
        #endregion

        #region Ⱦ���ӹ���������
        /// <summary>
        /// Ⱦ���ӹ���������(����������)
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataRBCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }
            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,OutQty,NLQty FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                //sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND CPItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);//��������
                //sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                //sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                        thisWeight = 0 - thisWeight;//�˻��ø�������
                    }
                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["NLQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));

                        //sql += ",NLQty=ISNULL(NLQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",OutQty=ISNULL(OutQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["NLQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        //sql += ",NLQty=ISNULL(NLQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += ",OutQty=ISNULL(OutQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ��Ⱦ���ӹ�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion



        #region �����ӹ�����׼�����
        /// <summary>
        /// �����ӹ�����׼�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataHZRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,InQty ,Unit FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                //sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND BCPItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);//���Ʒ����
                sql += " AND BCPColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND BCPColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    //������ĵ�λ �ͼӹ����ĵ�λ��һ��
                    if (!SysConvert.ToString(entitydts[i].Unit).EndsWith(SysConvert.ToString(dtData.Rows[0]["Unit"])))
                    {
                        throw new BaseException("��λ�ͼӹ����ĵ�λ��һ�£�����");
                    }

                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                    }
                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisWeight = 0 - thisWeight;//�˻��ø�������
                    }
                    decimal thisYard = entitydts[i].Yard;
                    if (thFlag)
                    {
                        thisYard = 0 - thisYard;//�˻��ø�������
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisYard) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisYard) + ")";
                        }
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ��Ⱦ���ӹ�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

            }
        }
        #endregion




        #region ��Ʒ�����ӹ�����׼�����
        /// <summary>
        /// �����ӹ�����׼�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataCPHZRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,InQty FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " CPInDate =" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",CPInQty =ISNULL(CPInQty ,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " CPInDate =" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",CPInQty=ISNULL(CPInQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ��Ⱦ���ӹ�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

            }
        }
        #endregion

        #region �����ӹ������׼�����
        /// <summary>
        /// �����ӹ������׼�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataHZCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,InQty, Unit FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                //sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND BCPItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);//���Ʒ����
                sql += " AND BCPColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND BCPColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    //������ĵ�λ �ͼӹ����ĵ�λ��һ��
                    if (!SysConvert.ToString(entitydts[i].Unit).EndsWith(SysConvert.ToString(dtData.Rows[0]["Unit"])))
                    {
                        throw new BaseException("��λ�ͼӹ����ĵ�λ��һ�£�����");
                    }

                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                    }
                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisWeight = 0 - thisWeight;//�˻��ø�������
                    }
                    decimal thisYard = entitydts[i].Yard;
                    if (thFlag)
                    {
                        thisYard = 0 - thisYard;//�˻��ø�������
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)+" + "(" + SysString.ToDBString(thisYard) + ")";
                        }

                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_FabricProcessDts SET ";
                        sql += " OutFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.EndsWith("M"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("KG"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        if (entitydts[i].Unit.EndsWith("Y"))
                        {
                            sql += ",OutQty=ISNULL(OutQty,0)-" + "(" + SysString.ToDBString(thisYard) + ")";
                        }

                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ��Ⱦ���ӹ�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }

            }
        }
        #endregion


        #region ӡ���ӹ�����׼�����
        /// <summary>
        /// ӡ���ӹ�����׼�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataYHRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,InQty FROM UV1_WO_PrintingProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                //sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                //sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_PrintingProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_PrintingProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ��ӡ���ӹ�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion

        #region ӡ���ӹ���������
        /// <summary>
        /// ӡ���ӹ���������
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataYHCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }
            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,OutQty,NLQty FROM UV1_WO_PrintingProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                //sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                //sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                    }
                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["NLQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_PrintingProcessDts SET ";
                        sql += " NLFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",NLQty=ISNULL(NLQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["NLQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_PrintingProcessDts SET ";
                        sql += " NLFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",NLQty=ISNULL(NLQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ��ӡ���ӹ�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion

        #region ֯��ӹ�����׼�����
        /// <summary>
        /// ֯��ӹ�����׼�����
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataZZRK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }

            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,InQty FROM UV1_WO_FabricProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    decimal thisWeight = entitydts[i].Weight;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                        thisWeight = 0 - thisWeight;//�˻��ø�������
                    }

                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE UV1_WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.Contains("KG"))  //���� �ͻ�������
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        else
                        {
                            sql += ",InQty=ISNULL(InQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        sql += " WHERE DtsID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["InQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE UV1_WO_FabricProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        if (entitydts[i].Unit.Contains("KG"))  //���� �ͻ�������
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisWeight) + ")";
                        }
                        else
                        {
                            sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        }
                        sql += " WHERE DtsID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ��֯��ӹ�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion

        #region ֯��ӹ���������
        /// <summary>
        /// ֯��ӹ���������
        /// </summary>
        /// <param name="entity">��ͷ</param>
        /// <param name="entitydts">������ϸ</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        void RFillDataZZCK(IOForm entity, IOFormDts[] entitydts, int p_Type, DataRow drFormList, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            bool thFlag = false;
            if (SysConvert.ToInt32(drFormList["DZFlag"]) == (int)EnumDZFlag.���ʸ�)
            {
                thFlag = true;
            }
            for (int i = 0; i < entitydts.Length; i++)//ѭ��������ʷ
            {
                sql = "SELECT DtsID,Qty,OutQty,NLQty FROM UV1_WO_WeaveProcessDts2 WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
                sql += " AND ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                sql += " AND ItemName=" + SysString.ToDBString(entitydts[i].ItemName);
                sql += " AND ItemStd=" + SysString.ToDBString(entitydts[i].ItemStd);
                sql += " AND ColorNum=" + SysString.ToDBString(entitydts[i].ColorNum);
                sql += " AND ColorName=" + SysString.ToDBString(entitydts[i].ColorName);
                DataTable dtData = sqlTrans.Fill(sql);
                if (dtData.Rows.Count != 0)
                {
                    decimal thisQty = entitydts[i].Qty;
                    if (thFlag)
                    {
                        thisQty = 0 - thisQty;//�˻��ø�������
                    }
                    string o_ErrorMsg = "";
                    if (p_Type == (int)YesOrNo.Yes)//�ύ
                    {
                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["NLQty"]) + thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��� �����룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "  " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_WeaveProcessDts2 SET ";
                        sql += " NLFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",NLQty=ISNULL(NLQty,0)+" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    else//�����ύ
                    {

                        if (!RFillDataCheckQty(drFormList, SysConvert.ToDecimal(dtData.Rows[0]["Qty"]), SysConvert.ToDecimal(dtData.Rows[0]["NLQty"]) - thisQty, out o_ErrorMsg))//У������������
                        {
                            throw new Exception("���ܲ������������������õĹ��򣺱��룺" + entitydts[i].ItemCode + "ɫ�ţ�" + entitydts[i].ColorNum + "   " + o_ErrorMsg);
                        }

                        sql = "UPDATE WO_WeaveProcessDts2 SET ";
                        sql += " NLFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",NLQty=ISNULL(NLQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
                        sql += " WHERE ID=" + dtData.Rows[0]["DtsID"].ToString();
                    }
                    sqlTrans.ExecuteNonQuery(sql);
                }
                else
                {
                    throw new Exception("��������ʧ�ܣ�û���ҵ���Ӧ��֯��ӹ�������ɫ��" + entitydts[i].DtsSO + "  " + entitydts[i].ItemCode
                         + "  " + entitydts[i].ColorNum + "  " + entitydts[i].ColorName);
                }
            }
        }
        #endregion

        #region У������������
        /// <summary>
        /// У������������
        /// </summary>
        /// <param name="drFormList">��������</param>
        /// <param name="p_PlanQty">�ƻ���</param>
        /// <param name="p_FactQty">ʵ�ʷ�����</param>
        /// <returns>true/false</returns>
        bool RFillDataCheckQty(DataRow drFormList, decimal p_PlanQty, decimal p_FactQty, out string o_ErrorMsg)
        {
            bool outbool = false;
            o_ErrorMsg = "�ƻ���:" + p_PlanQty + "  �ۼ������:" + p_FactQty;
            if (p_PlanQty < SysConvert.ToDecimal(drFormList["CheckQtyFrom"]))//С������ʹ��ǰһ�����ж�
            {
                if (SysConvert.ToDecimal(drFormList["CheckQtyPer1"]) > 0)//������ֵ���ж�
                {
                    if (p_PlanQty != 0)
                    {
                        if (p_FactQty / p_PlanQty - 1 <= SysConvert.ToDecimal(drFormList["CheckQtyPer1"]))//�ں���������Χ��
                        {
                            outbool = true;
                        }
                    }
                }
                else
                {
                    outbool = true;
                }
            }
            else//��������ʹ�ú�һ�����ж�
            {
                if (SysConvert.ToDecimal(drFormList["CheckQtyPer2"]) > 0)//������ֵ���ж�
                {
                    if (p_PlanQty != 0)
                    {
                        if (p_FactQty / p_PlanQty - 1 <= SysConvert.ToDecimal(drFormList["CheckQtyPer2"]))//�ں���������Χ��
                        {
                            outbool = true;
                        }
                    }
                }
                else
                {
                    outbool = true;
                }
            }

            return outbool;
        }
        #endregion
        #endregion


        #region ��������
        /// <summary>
        /// ����FormListAID�õ����㵥��������⡢���⡢�̵㡢�ƿ⡢��̬ת�����ڳ����
        /// </summary>
        /// <param name="p_FormListAID">loginID</param>
        /// <returns></returns>
        public static int GetFormListTopTypeByFormListID(int p_FormListAID, IDBTransAccess sqlTrans)
        {
            int outint = p_FormListAID;
            string sql = "SELECT ParentID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (SysConvert.ToInt32(dt.Rows[0]["ParentID"]) != 0)
                {
                    outint = SysConvert.ToInt32(dt.Rows[0]["ParentID"]);
                }
            }
            return outint;
        }

        /// <summary>
        /// ��õ�����ϸ������
        /// </summary>
        /// <param name="p_IOFormID">����ID</param>
        /// <param name="sqlTrans">������</param>
        private IOFormDts[] RGetFormDts(int p_IOFormID, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT ID FROM WH_IOFormDts WHERE MainID=" + p_IOFormID.ToString();
                DataTable dt = sqlTrans.Fill(sql);
                IOFormDts[] entity = new IOFormDts[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    entity[i] = new IOFormDts(sqlTrans);
                    entity[i].ID = SysConvert.ToInt32(dt.Rows[i][0].ToString());
                    entity[i].SelectByID();
                }
                return entity;
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


        #region ��ɴȾɫ�����Զ���Ⱦ���⴦��
        ///// <summary>
        ///// �Զ�Ⱦ�����
        ///// </summary>
        ///// <param name="p_FormID">����ID</param>
        ///// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        ///// <returns></returns>
        //public void RSubmitColorIn(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {
        //        ParamSetRule rulePS = new ParamSetRule();
        //        //if (SysConvert.ToInt32(rulePS.RShowIntByCode((int)ParamSetEnum.Ⱦ���Ƿ��Զ������)) == (int)YesOrNo.No)//Ⱦ�������Զ���Ⱦ���� && p_Type == (int)ConfirmFlag.���ύ
        //        //{
        //        //    return;
        //        //}
        //        IOForm entity = new IOForm(sqlTrans);
        //        entity.ID = p_FormID;
        //        entity.SelectByID();


        //        IOFormDts[] entitydts = this.RGetFormDts(p_FormID, sqlTrans);
        //        if (p_Type == (int)ConfirmFlag.���ύ)
        //        {
        //            //���ӳ����¼
        //            IOFormRule rule = new IOFormRule();
        //            FormNoControlRule formconrule = new FormNoControlRule();
        //            IOForm entityi = new IOForm(sqlTrans);
        //            entityi.HeadType = (int)WHFormList.��ɴ��ⵥ;
        //            entityi.SubType = (int)WHFormList.Ⱦ�����;
        //            entityi.CardNo = entity.FormNo;
        //            entityi.FormNo = formconrule.RGetFormNo((int)WHFormList.Ⱦ�����, 0, "", sqlTrans);
        //            entityi.FormDate = DateTime.Now.Date;
        //            entityi.PassOP = ParamConfig.LoginName;
        //            entityi.WHOP = ParamConfig.LoginName;
        //            //entityi.Indep = "�ֿ�";
        //            entityi.WHID = entity.VendorID;
        //            entityi.VendorID = entity.VendorID;
        //            //entityi.JSCFlag = (int)YesOrNo.Yes;
        //            entityi.WHTypeID = (int)EnumWHType.��ɴ;
        //            string sql = "SELECT * FROM WH_IOFormDts WHERE MainID=" + p_FormID.ToString();
        //            DataTable dt = sqlTrans.Fill(sql);//�����ϸ����
        //            ArrayList al = new ArrayList();
        //            foreach (DataRow dr in dt.Rows)//�ó��м�������
        //            {
        //                IOFormDts entitydtsi = new IOFormDts(sqlTrans);
        //                entitydtsi.DtsSO = dr["DtsSO"].ToString();
        //                entitydtsi.DtsVendorID = entityi.VendorID;
        //                entitydtsi.ItemCode = dr["ItemCode"].ToString();
        //                entitydtsi.ItemName = dr["ItemName"].ToString();
        //                entitydtsi.ItemStd = dr["ItemStd"].ToString();
        //                entitydtsi.ColorName = dr["ColorName"].ToString();
        //                entitydtsi.ColorNum = dr["ColorNum"].ToString();
        //                entitydtsi.VendorBatch = dr["VendorBatch"].ToString();
        //                entitydtsi.Batch = dr["Batch"].ToString();
        //                entitydtsi.Amount = SysConvert.ToDecimal(dr["Amount"]);
        //                entitydtsi.SinglePrice = SysConvert.ToDecimal(dr["SinglePrice"]);
        //                entitydtsi.Weight = SysConvert.ToDecimal(dr["Weight"]);
        //                entitydtsi.Qty = SysConvert.ToDecimal(dr["Qty"]);
        //                entitydtsi.Unit = SysConvert.ToString(dr["Unit"]);
        //                entitydtsi.DtsSaleOPID = SysConvert.ToString(dr["DtsSaleOPID"]);
        //                entitydtsi.WHID = entity.VendorID;
        //                entitydtsi.WHTypeID = (int)EnumWHType.��ɴ;

        //                entitydtsi.CompanyTypeID =SysConvert.ToInt32(dr["CompanyTypeID"]);

        //                al.Add(entitydtsi);
        //            }

        //            IOFormDts[] dtsarray = new IOFormDts[al.Count];
        //            for (int i = 0; i < al.Count; i++)
        //            {
        //                dtsarray[i] = (IOFormDts)al[i];
        //            }

        //            rule.RAdd(entityi, dtsarray, sqlTrans);//����
        //            rule.RSubmit(entityi.ID, p_Type, sqlTrans);//���

        //        }
        //        else if (p_Type == (int)ConfirmFlag.δ�ύ)
        //        {
        //            string sql = "SELECT ID FROM WH_IOForm WHERE SubType=" + (int)WHFormList.Ⱦ����� + " AND CardNo=" + SysString.ToDBString(entity.FormNo) + " AND DelFlag=0";
        //            DataTable dt = sqlTrans.Fill(sql);
        //            if (dt.Rows.Count != 0)
        //            {
        //                IOFormRule rule = new IOFormRule();
        //                int p_ID = SysConvert.ToInt32(dt.Rows[0][0].ToString());
        //                rule.RSubmit(p_ID, p_Type, sqlTrans);//�������
        //                rule.RDelete(p_ID, sqlTrans);//ɾ��
        //            }
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
        #endregion

        #region ί��Ⱦɫ��ɴ���ʱȾ���Զ�����
        ///// <summary>
        ///// �Զ�Ⱦ������
        ///// </summary>
        ///// <param name="p_FormID">����ID</param>
        ///// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        ///// <returns></returns>
        //public void RSubmitColorOut(int p_FormID, int p_Type, IDBTransAccess sqlTrans)
        //{
        //    try
        //    {

        //        ParamSetRule rulePS = new ParamSetRule();
        //        //if (SysConvert.ToInt32(rulePS.RShowIntByCode((int)ParamSetEnum.Ⱦ���Ƿ��Զ������)) == (int)YesOrNo.No)//Ⱦ�������Զ���Ⱦ���� && p_Type == (int)ConfirmFlag.���ύ
        //        //{
        //        //    return;
        //        //}

        //        IOForm entity = new IOForm(sqlTrans);
        //        entity.ID = p_FormID;
        //        entity.SelectByID();

        //        IOFormDts[] entitydts = this.RGetFormDts(p_FormID, sqlTrans);
        //        if (p_Type == (int)ConfirmFlag.���ύ)
        //        {
        //            string tempStr = CheckShopStorge(p_FormID, sqlTrans);
        //            if (tempStr != string.Empty)//У������
        //            {
        //                //if (DialogResult.Yes != BaseForm.d ShowConfirmMessage(tempStr + Environment.NewLine + "ȷ��Ҫ�ύ�˵���"))

        //                if (DialogResult.Yes != MessageBox.Show(tempStr + Environment.NewLine + "ȷ��Ҫ�ύ�˵���", FParamConfig.SystemName, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        //                {
        //                    throw new Exception("û��ȷ���ύ�õ���");
        //                }
        //            }

        //            //���ӳ����¼
        //            IOFormRule rule = new IOFormRule();
        //            FormNoControlRule formconrule = new FormNoControlRule();
        //            IOForm entityi = new IOForm(sqlTrans);
        //            entityi.HeadType = (int)WHFormList.��ɴ���ⵥ;
        //            entityi.SubType = (int)WHFormList.Ⱦ������;
        //            entityi.CardNo = entity.FormNo;
        //            entityi.FormNo = formconrule.RGetFormNo((int)WHFormList.Ⱦ������, 0, "", sqlTrans);
        //            entityi.FormDate = DateTime.Now.Date;
        //            entityi.PassOP = ParamConfig.LoginName;
        //            entityi.WHOP = ParamConfig.LoginName;
        //            //entityi.Indep = "�ֿ�";
        //            entityi.WHID = entity.VendorID;
        //            entityi.VendorID = entity.VendorID;
        //            //entityi.JSCFlag = (int)YesOrNo.Yes;
        //            entityi.WHTypeID = (int)EnumWHType.��ɴ;
        //            string sql = "SELECT * FROM WH_IOFormDts WHERE MainID=" + p_FormID.ToString();
        //            DataTable dt = sqlTrans.Fill(sql);//�����ϸ����
        //            ArrayList al = new ArrayList();
        //            foreach (DataRow dr in dt.Rows)//�ó��м�������
        //            {
        //                IOFormDts entitydtsi = new IOFormDts(sqlTrans);
        //                entitydtsi.DtsSO = dr["DtsSO"].ToString();
        //                entitydtsi.DtsVendorID = entityi.VendorID;
        //                entitydtsi.ItemCode = dr["ItemCode"].ToString();
        //                entitydtsi.ItemName = dr["ItemName"].ToString();
        //                entitydtsi.ItemStd = dr["ItemStd"].ToString();
        //                entitydtsi.ColorName = dr["ColorName"].ToString();
        //                entitydtsi.ColorNum = dr["ColorNum"].ToString();
        //                entitydtsi.VendorBatch = dr["VendorBatch"].ToString();
        //                entitydtsi.Batch = dr["Batch"].ToString();
        //                entitydtsi.Amount = SysConvert.ToDecimal(dr["Amount"]);
        //                entitydtsi.SinglePrice = SysConvert.ToDecimal(dr["SinglePrice"]);
        //                entitydtsi.Weight = SysConvert.ToDecimal(dr["Weight"]);
        //                entitydtsi.Qty = SysConvert.ToDecimal(dr["Qty"]);
        //                entitydtsi.Unit = SysConvert.ToString(dr["Unit"]);
        //                entitydtsi.DtsSaleOPID = SysConvert.ToString(dr["DtsSaleOPID"]);
        //                entitydtsi.WHID = entity.VendorID;

        //                entitydtsi.CompanyTypeID =SysConvert.ToInt32(dr["CompanyTypeID"]);

        //                entitydtsi.WHTypeID = (int)EnumWHType.��ɴ;
        //                al.Add(entitydtsi);
        //            }

        //            IOFormDts[] dtsarray = new IOFormDts[al.Count];
        //            for (int i = 0; i < al.Count; i++)
        //            {
        //                dtsarray[i] = (IOFormDts)al[i];
        //            }

        //            rule.RAdd(entityi, dtsarray, sqlTrans);//����
        //            rule.RSubmit(entityi.ID, p_Type, sqlTrans);//���

        //        }
        //        else if (p_Type == (int)ConfirmFlag.δ�ύ)
        //        {
        //            string sql = "SELECT ID FROM WH_IOForm WHERE SubType=" + (int)WHFormList.Ⱦ������ + " AND CardNo=" + SysString.ToDBString(entity.FormNo) + " AND DelFlag=0";
        //            DataTable dt = sqlTrans.Fill(sql);
        //            if (dt.Rows.Count != 0)
        //            {
        //                IOFormRule rule = new IOFormRule();
        //                int p_ID = SysConvert.ToInt32(dt.Rows[0][0].ToString());
        //                rule.RSubmit(p_ID, p_Type, sqlTrans);//�������
        //                rule.RDelete(p_ID, sqlTrans);//ɾ��
        //            }
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
        ///// У��Ⱦ������Ƿ���
        ///// </summary>
        ///// <returns></returns>
        //private string CheckShopStorge(int p_FormID, IDBTransAccess sqlTrans)
        //{
        //    string outStr = string.Empty;
        //    IOForm entity = new IOForm(sqlTrans);
        //    entity.ID = p_FormID;
        //    entity.SelectByID();

        //    string sql = "SELECT * From WH_IOFormDts WHERE MainID=" + p_FormID;
        //    DataTable dt = sqlTrans.Fill(sql);
        //    if (dt.Rows.Count != 0)
        //    {
        //        bool findError = false;
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {

        //            string ItemCode = SysConvert.ToString(dt.Rows[i]["ItemCode"]);
        //            //string Batch = SysConvert.ToString(dt.Rows[i]["Batch"]);
        //            //string VendorBatch = SysConvert.ToString(dt.Rows[i]["VendorBatch"]);
        //            decimal Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);

        //            StorgeRule rule = new StorgeRule();
        //            int[] stia = rule.FindStorges(entity.VendorID, "", "", entity.CompanyTypeID, ItemCode, "", "", "", "", "", "", "", "", (int)EnumWHType.��ɴ, "", "", "", sqlTrans);
        //            Storge entityS = new Storge();
        //            if (stia.Length > 0)
        //            {
        //                entityS.ID = stia[0];
        //                entityS.SelectByID();
        //            }
        //            if (Qty > entityS.Qty)
        //            {
        //                findError = true;
        //            }
        //            if (outStr != string.Empty)
        //            {
        //                outStr += Environment.NewLine;
        //            }
        //            outStr += "ɴ�߱�ţ�" + ItemCode +  " Ⱦ�����������" + entityS.Qty + "KG" + " Ⱦɫ������" + Qty.ToString() + " KG";//+ " ���ţ�" + tempA[1]
        //        }
        //        if (findError)
        //        {
        //            outStr = "������Ϣ��Ⱦ�����ɴ��Ⱦɫ������" + Environment.NewLine + outStr;
        //        }
        //        return outStr;
        //    }
        //    return outStr;
        //}
        #endregion


        #region  ����Ⱦɫ��ⵥʵ����
        /// <summary>
        /// ���ͨ������˾ܾ�
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        /// <param name="p_Type">1/0 ���ͨ��/��˾ܾ�</param>
        /// <returns></returns>
        public void RDealColorInQty(int p_FormID, IOFormDts[] p_entityDts)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    IOForm entity = new IOForm(sqlTrans);
                    entity.ID = p_FormID;
                    entity.SelectByID();

                    IOFormDts[] entitydts = this.RGetFormDts(p_FormID, sqlTrans);
                    for (int i = 0; i < entitydts.Length; i++)
                    {
                        StorgeRule rulest = new StorgeRule();//���
                        rulest.RDealColorInQty(p_FormID, entity, entitydts[i], p_entityDts[i], sqlTrans);

                        ///������ⵥ����
                        string sql = "UPDATE WH_IOFormDts Set Qty=" + SysConvert.ToDecimal(p_entityDts[i].Qty);
                        sql += " ,Amount=" + SysConvert.ToDecimal(SysConvert.ToDecimal(p_entityDts[i].Qty) * SysConvert.ToDecimal(p_entityDts[i].SinglePrice), 2);
                        sql += " ,QtyDiff=" + SysConvert.ToDecimal(SysConvert.ToDecimal(p_entityDts[i].Weight) - SysConvert.ToDecimal(p_entityDts[i].Qty), 2);//����=ʵ����-����
                        //if (SysConvert.ToDecimal(p_entityDts[i].CompactQty)-SysConvert.ToDecimal(p_entityDts[i].Qty) != 0 && SysConvert.ToDecimal(p_entityDts[i].CompactQty) != 0)
                        //{
                        //    ///Ⱦɫ���=(ͶȾ��-ʵ����)/ͶȾ��
                        //    sql += " ,LossRate=" + SysConvert.ToDecimal((SysConvert.ToDecimal(p_entityDts[i].CompactQty)-SysConvert.ToDecimal(p_entityDts[i].Qty)) / SysConvert.ToDecimal(p_entityDts[i].CompactQty)*100, 2);
                        //}
                        sql += " WHERE 1=1 AND MainID=" + p_FormID;
                        sql += " AND Seq=" + entitydts[i].Seq;
                        sqlTrans.ExecuteNonQuery(sql);
                    }
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
        #endregion

    }
}
