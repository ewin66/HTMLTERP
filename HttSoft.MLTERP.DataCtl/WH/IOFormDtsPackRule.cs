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
    /// Ŀ�ģ�WH_IOFormDtsPackʵ��ҵ�������
    /// ����:�¼Ӻ�
    /// ��������:2012-5-7
    /// </summary>
    public class IOFormDtsPackRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public IOFormDtsPackRule()
        {
        }

        /// <summary>
        /// ��齫Ҫ�����������Ƿ����ҵ�����
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            IOFormDtsPack entity = (IOFormDtsPack)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM WH_IOFormDtsPack WHERE 1=1";
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_IOFormDtsPackBT WHERE 1=1";
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

        #region �������
        /// <summary>
        /// ������ݿ���û�б�ɾ����ID(�����ݿ����ж���UI��Ҳû��ɾ��������)
        /// </summary>
        /// <param name="p_BE"></param>
        /// <returns></returns>
        private string GetIDExist(ArrayList p_BE)
        {
            string outstr = "0";
            for (int i = 0; i < p_BE.Count; i++)
            {
                IOFormDtsPack entitydts = (IOFormDtsPack)p_BE[i];
                if (entitydts.ID != 0)
                {
                    outstr += "," + entitydts.ID;
                }
            }
            return outstr;
        }

        /// <summary>
        /// ����(����������)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSave(IOForm p_Entity, IOFormDts[] p_EntityDts, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;

                int FormListTopType = IOFormDtsRule.GetFormListTopTypeByFormListID(p_Entity.HeadType, sqlTrans);//���㵥������
                //if (FormListTopType != (int)WHFormList.��� && FormListTopType != (int)WHFormList.�ڳ����)//�������������͵ĵ���
                if (FormListTopType != (int)WHFormList.��� && FormListTopType != (int)WHFormList.�ڳ����
                     && FormListTopType != (int)WHFormList.������ⵥ && FormListTopType != (int)WHFormList.������ⵥ)//�������������͵ĵ���
                {
                    RSaveOther(p_Entity, p_EntityDts, list, sqlTrans);
                    return;
                }


                sql = "SELECT BoxNo FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(list));
                DataTable dtDelete = sqlTrans.Fill(sql);//ɾ����ṹ
                if (dtDelete.Rows.Count != 0)//����Ҫɾ��������
                {
                    foreach (DataRow dr in dtDelete.Rows)//У���Ƿ����ɾ��
                    {
                        PackBoxRule pbrule = new PackBoxRule();
                        pbrule.RCheckDelete(dr["BoxNo"].ToString(), sqlTrans);//������
                    }

                    sql = "DELETE FROM WH_PackBox WHERE BoxNo IN(SELECT BoxNo FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                    sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(list)) + ")";//ɾ���뵥��ϸ����
                    sqlTrans.ExecuteNonQuery(sql);

                    sql = "DELETE FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                    sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(list));
                    sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������Ӧ��ɾ������ϸ���ݣ������ݿ����е���UI���Ѿ�ɾ��������
                }
                for (int i = 0; i < list.Count; i++)
                {
                    IOFormDtsPack entitydts = (IOFormDtsPack)list[i];
                    int ioformdtsdex = -1;
                    for (int m = 0; m < p_EntityDts.Length; m++)
                    {
                        if (p_EntityDts[m].Seq == entitydts.Seq)//�ҵ���ͬ��SEQ��
                        {
                            ioformdtsdex = m;
                            break;
                        }
                    }
                    if (ioformdtsdex == -1)//δ�ҵ����쳣
                    {
                        throw new Exception("�뵥�����쳣��δ�ҵ�������ϸ���к�:" + entitydts.Seq);
                    }


                    if (entitydts.ID != 0)//ID��Ϊ0˵�����ݿ����Ѿ�����
                    {
                        PackBoxRule pbrule = new PackBoxRule();
                        pbrule.RCheckUpdate(entitydts.BoxNo, sqlTrans);//������
                        this.RUpdate(p_EntityDts[ioformdtsdex], entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.MainID = p_Entity.ID;
                        this.RAdd(p_Entity, p_EntityDts[ioformdtsdex], entitydts, sqlTrans);
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
        /// ����(����������)
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <param name="p_BE"></param>
        /// <param name="sqlTrans"></param>
        public void RSaveOther(IOForm p_Entity, IOFormDts[] p_EntityDts, ArrayList list, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = string.Empty;
                int FormListTopType = IOFormDtsRule.GetFormListTopTypeByFormListID(p_Entity.HeadType, sqlTrans);//���㵥������

                sql = "SELECT BoxNo FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(list));
                DataTable dtDelete = sqlTrans.Fill(sql);//ɾ����ṹ
                if (dtDelete.Rows.Count != 0)//����Ҫɾ��������
                {
                    sql = "DELETE FROM WH_IOFormDtsPack WHERE MainID=" + p_Entity.ID.ToString();
                    sql += " AND ID NOT IN" + string.Format("({0})", GetIDExist(list));
                    sqlTrans.ExecuteNonQuery(sql);//ɾ��ԭ������Ӧ��ɾ������ϸ���ݣ������ݿ����е���UI���Ѿ�ɾ��������
                }
                for (int i = 0; i < list.Count; i++)
                {
                    IOFormDtsPack entitydts = (IOFormDtsPack)list[i];
                    int ioformdtsdex = -1;
                    for (int m = 0; m < p_EntityDts.Length; m++)
                    {
                        if (p_EntityDts[m].Seq == entitydts.Seq)//�ҵ���ͬ��SEQ��
                        {
                            ioformdtsdex = m;
                            break;
                        }
                    }
                    if (ioformdtsdex == -1)//δ�ҵ����쳣
                    {
                        throw new Exception("�뵥�����쳣��δ�ҵ�������ϸ���к�:" + entitydts.Seq);
                    }

                    if (entitydts.ID != 0)//ID��Ϊ0˵�����ݿ����Ѿ�����
                    {
                        this.RUpdateOther(p_EntityDts[ioformdtsdex], entitydts, sqlTrans);
                    }
                    else
                    {
                        entitydts.MainID = p_Entity.ID;
                        entitydts.DID = p_EntityDts[ioformdtsdex].ID;
                        this.RAddOther(p_EntityDts[ioformdtsdex], entitydts, sqlTrans);

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
        public void RAdd(IOForm p_MainEntity, IOFormDts p_MainDts, BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;

                PackBox pbentity = new PackBox(sqlTrans);
                pbentity.SourceTypeID = (int)PackBoxSourceType.��ⵥ;
                pbentity.BoxStatusID = (int)EnumBoxStatus.δ���;
                CopyEntityData(p_MainDts, entity, pbentity);
                //if (entity.BoxNo != string.Empty && p_MainEntity.Remark == "EIN")//�����ڵ�����ʱʹ�õ�
                if (entity.BoxNo != string.Empty)//�����ڵ�����ʱʹ�õ�
                {
                    pbentity.CreateTime = p_MainEntity.FormDate;
                    pbentity.BoxNo = entity.BoxNo;
                }
                pbentity.DID = p_MainDts.ID;
                pbentity.SubSeq = entity.SubSeq;
                PackBoxRule pbrule = new PackBoxRule();
                pbrule.RAdd(pbentity, sqlTrans);



                entity.DID = p_MainDts.ID;//20141009 zhoufc
                entity.BoxNo = pbentity.BoxNo;
                this.RAdd(entity, sqlTrans);//������ԭ����������ڲ������ʵ��ʱ���ɵ�
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
        public void RAddOther(IOFormDts p_MainDts, BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;

                RSaveOtherCheck(p_MainDts, p_BE, sqlTrans);


                this.RAdd(entity, sqlTrans);
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
        /// ������������ʱ���ƥ����
        /// </summary>
        public void RSaveOtherCheck(IOFormDts p_MainDts, BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            this.CheckCorrect(p_BE);
            IOFormDtsPack entity = (IOFormDtsPack)p_BE;

            if (entity.BoxNo == string.Empty)
            {
                throw new Exception("�쳣��û�ж�ȡ���뵥���");
            }
            PackBoxRule pbrule = new PackBoxRule();
            PackBox pbentity = pbrule.RGetEntityByBoxNo(entity.BoxNo, sqlTrans);
            if (pbentity.BoxStatusID != (int)EnumBoxStatus.���)
            {
                throw new Exception("�쳣���뵥���" + entity.BoxNo + "��ǰδ�������״̬�����������");
            }
            if (pbentity.ItemCode != p_MainDts.ItemCode || pbentity.ColorNum != p_MainDts.ColorNum ||
                pbentity.ColorName != p_MainDts.ColorName)//|| pbentity.GoodsLevel != p_MainDts.GoodsLevel �Ȳ��ܵȼ�
            {
                throw new Exception("�쳣���뵥���" + entity.BoxNo + "�͵�����ϸ���Բ�ƥ��");
            }

        }

        /// <summary>
        /// �������ݵ�ʵ����
        /// </summary>
        /// <param name="p_MainDts"></param>
        /// <param name="p_BE"></param>
        public void CopyEntityData(IOFormDts p_MainDts, IOFormDtsPack p_BE, PackBox p_PBEntity)
        {
            p_PBEntity.ColorName = p_MainDts.ColorName;
            p_PBEntity.ColorNum = p_MainDts.ColorNum;
            p_PBEntity.CompanyTypeID = p_MainDts.CompanyTypeID;
            p_PBEntity.GoodsCode = p_MainDts.GoodsCode;
            p_PBEntity.GoodsLevel = p_MainDts.GoodsLevel;
            p_PBEntity.ItemCode = p_MainDts.ItemCode;
            p_PBEntity.ItemName = p_MainDts.ItemName;
            p_PBEntity.ItemStd = p_MainDts.ItemStd;
            p_PBEntity.JarNum = p_MainDts.JarNum;
            p_PBEntity.Batch = p_MainDts.Batch;
            p_PBEntity.VendorBatch = p_MainDts.VendorBatch;
            p_PBEntity.MWeight = p_MainDts.MWeight;
            p_PBEntity.MWidth = p_MainDts.MWidth;
            p_PBEntity.Qty = p_BE.Qty;
            p_PBEntity.Weight = p_BE.Weight;
            //p_PBEntity.Unit = p_MainDts.Unit;
            p_PBEntity.FMQty = p_BE.FMQty;// ����

        }



        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RUpdate(IOFormDts p_MainDts, BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;
                this.RUpdate(p_BE, sqlTrans);

                PackBoxRule pbrule = new PackBoxRule();
                PackBox pbentity = pbrule.RGetEntityByBoxNo(entity.BoxNo, sqlTrans);//����䵥ʵ��               

                CopyEntityData(p_MainDts, entity, pbentity);//��������

                pbrule.RUpdate(pbentity, sqlTrans);//����
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
        public void RUpdateOther(IOFormDts p_MainDts, BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;

                RSaveOtherCheck(p_MainDts, p_BE, sqlTrans);

                this.RUpdate(p_BE, sqlTrans);

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
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;
                IOFormDtsPackCtl control = new IOFormDtsPackCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WH_IOFormDtsPack, sqlTrans);


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
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;
                IOFormDtsPackCtl control = new IOFormDtsPackCtl(sqlTrans);
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
                IOFormDtsPack entity = (IOFormDtsPack)p_BE;
                IOFormDtsPackCtl control = new IOFormDtsPackCtl(sqlTrans);
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
                        IOFormDtsPack entity = (IOFormDtsPack)p_BE[i];
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
                        sql = "DELETE FROM WH_PackBox WHERE BoxNo IN (SELECT BoxNo FROM WH_IOFormDtsPack WHERE DID=" + SysString.ToDBString(p_ID) + " AND ID NOT IN(" + idStr + ") )";
                        sqlTrans.ExecuteNonQuery(sql);//ִ��������ɾ��

                        sql = "DELETE FROM WH_IOFormDtsPack WHERE DID=" + SysString.ToDBString(p_ID) + " AND ID NOT IN(" + idStr + ")";//WH_IOFormDtsPack WH_PackBox
                        sqlTrans.ExecuteNonQuery(sql);
                    }
                }
                else//����״̬
                {
                    sql = "SELECT TOP 1 ID FROM WH_IOFormDtsPack WHERE DID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        throw new BaseException("�����ظ����棡");
                    }
                }


                IOForm p_Main = new IOForm(sqlTrans);
                p_Main.ID = p_MainID;
                p_Main.SelectByID();

                IOFormDts p_MainDts = new IOFormDts(sqlTrans);
                p_MainDts.ID = p_ID;
                p_MainDts.SelectByID();



                IOFormDtsPackRule rule = new IOFormDtsPackRule();
                PackBoxRule Brule = new PackBoxRule();
                decimal Qty = 0;
                decimal Weight = 0;
                decimal Yard = 0;
                decimal PieceQty = 0;
                for (int i = 0; i < p_BE.Length; i++)
                {
                    FormNoControlRule frule = new FormNoControlRule();
                    IOFormDtsPack entity = (IOFormDtsPack)p_BE[i];
                    int boxNoCreateTypeID = 0;//���������Դ
                    if (entity.ID == 0)
                    {
                        if (entity.BoxNo == string.Empty)//û���������
                        {
                            entity.BoxNo = frule.RGetFormNo((int)FormNoControlEnum.�뵥���, sqlTrans);
                            rule.RAdd(entity, sqlTrans);
                            frule.RAddSort((int)FormNoControlEnum.�뵥���, sqlTrans);
                        }
                        else//���������˵�����鲼����������
                        {
                            boxNoCreateTypeID = 1;//�鲼��Դ
                        }
                    }
                    else
                    {
                        rule.RUpdate(entity, sqlTrans);
                    }


                    PackBox entityBox = new PackBox();
                    if (entity.ID != 0)//�ֿ���ϸ�����ɣ���Ѱ�����ID �˴��ж���ʵ�����壬��������Ĵ���϶���IDֵ��
                    {
                        sql = "SELECT ID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(entity.BoxNo);
                        DataTable dtPackBox = sqlTrans.Fill(sql);
                        if (dtPackBox.Rows.Count != 0)//����ҵ�����
                        {
                            entityBox.ID = SysConvert.ToInt32(dtPackBox.Rows[0]["ID"]);
                        }
                        else//���δ�ҵ�����
                        {
                            entityBox.CreateSourceID = boxNoCreateTypeID;////ԭʼ�����Ӹ��ֶα�ʾ��Դ 0:��ʾ���¼��
                        }
                    }
                    entityBox.BoxNo = entity.BoxNo;
                    entityBox.WHID = p_MainDts.WHID;
                    entityBox.SectionID = p_MainDts.SectionID;
                    entityBox.SBitID = p_MainDts.SBitID;
                    entityBox.ColorName = p_MainDts.ColorName;
                    entityBox.ColorNum = p_MainDts.ColorNum;
                    entityBox.CompanyTypeID = p_MainDts.CompanyTypeID;
                    entityBox.GoodsCode = p_MainDts.GoodsCode;
                    // entityBox.GoodsLevel = p_MainDts.GoodsLevel;
                    entityBox.ItemCode = p_MainDts.ItemCode;
                    entityBox.ItemModel = p_MainDts.ItemModel;
                    entityBox.ItemName = p_MainDts.ItemName;
                    entityBox.ItemStd = p_MainDts.ItemStd;
                    entityBox.JarNum = p_MainDts.JarNum;
                    entityBox.Batch = p_MainDts.Batch;
                    entityBox.VendorBatch = p_MainDts.VendorBatch;
                    entityBox.MWeight = p_MainDts.MWeight;
                    entityBox.MWidth = p_MainDts.MWidth;
                    entityBox.Qty = entity.Qty;
                    entityBox.Weight = entity.Weight;
                    entityBox.Yard = entity.Yard;
                    entityBox.GoodsLevel = entity.GoodsLevel;
                    entityBox.Unit = p_MainDts.Unit;
                    entityBox.BoxStatusID = (int)EnumBoxStatus.δ���;
                    entityBox.DID = p_ID;
                    entityBox.InFormNo = p_Main.FormNo;
                    entityBox.OrderFormNo = p_MainDts.DtsOrderFormNo;//��ͬ����ϸ
                    entityBox.SubSeq = entity.SubSeq;//���

                    if (entityBox.ID == 0)//û��ID������
                    {
                        Brule.RAdd(entityBox, sqlTrans);
                    }
                    else//��ID���޸�
                    {
                        Brule.RUpdate(entityBox, sqlTrans);
                    }

                    Qty += entity.Qty;
                    Weight += entity.Weight;
                    Yard += entity.Yard;
                    PieceQty++;


                }

                //if (PieceQty == 0)
                //{
                //    throw new BaseException("����дϸ���������");
                //}

                sql = "UPDATE WH_IOFormDts SET Qty=" + SysString.ToDBString(Qty);
                sql += ",Weight=" + SysString.ToDBString(Weight);
                sql += ",Yard=" + SysString.ToDBString(Yard);
                sql += ",PieceQty=" + SysString.ToDBString(PieceQty);
                sql += ",PackFlag=1 ";
                sql += " WHERE ID=" + SysString.ToDBString(p_ID);
                sqlTrans.ExecuteNonQuery(sql);
                sql = "UPDATE WH_IOFormDts SET Amount=ISNULL(SinglePrice,0)*(";
                sql += "CASE";
                sql += " WHEN Unit='RMB/KG' OR Unit='USD/KG' THEN ISNULL(Weight,0)";
                sql += " WHEN Unit='RMB/Y' OR Unit='USD/Y' THEN ISNULL(Yard,0) ";
                sql += " WHEN Unit='RMB/M' OR Unit='USD/M' THEN ISNULL(Qty,0) ";
                sql += " ELSE 0 END)";
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
                string sql = "SELECT WHID,SectionID,SBitID,JarNum,Batch FROM WH_PackBox WHERE ID IN (" + p_IDStr + ")";
                sql += " GROUP BY WHID,SectionID,SBitID,JarNum,Batch";
                DataTable dt = sqlTrans.Fill(sql);
                int MaxSeq = GetMaxSeq(p_ID);
                decimal Qty = 0;
                IOFormDtsRule rule = new IOFormDtsRule();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)//��һ�и���
                    {
                        sql = "SELECT * FROM WH_PackBox WHERE ID IN (" + p_IDStr + ")";
                        sql += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["WHID"]));
                        sql += " AND SectionID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["SectionID"]));
                        sql += " AND SBitID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["SBitID"]));
                        sql += " AND JarNum=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["JarNum"]));
                        sql += " AND Batch=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["Batch"]));
                        DataTable dtsql = sqlTrans.Fill(sql);

                        IOFormDts entitydts = new IOFormDts(sqlTrans);
                        entitydts.ID = p_ID;
                        entitydts.SelectByID();
                        entitydts.WHID = SysConvert.ToString(dt.Rows[i]["WHID"]);
                        entitydts.SectionID = SysConvert.ToString(dt.Rows[i]["SectionID"]);
                        entitydts.SBitID = SysConvert.ToString(dt.Rows[i]["SBitID"]);
                        entitydts.JarNum = SysConvert.ToString(dt.Rows[i]["JarNum"]);
                        entitydts.Batch = SysConvert.ToString(dt.Rows[i]["Batch"]);
                        entitydts.Qty = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Qty)", "")), 2);
                        entitydts.Weight = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Weight)", "")), 2);
                        entitydts.Yard = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Yard)", "")), 2);
                        entitydts.PieceQty = dtsql.Rows.Count;
                        entitydts.PackFlag = 1;
                        if (entitydts.Unit == "RMB/KG" || entitydts.Unit == "USD/KG")
                        {
                            entitydts.Amount = entitydts.Weight * entitydts.SinglePrice;
                        }
                        if (entitydts.Unit == "RMB/M" || entitydts.Unit == "USD/M")
                        {
                            entitydts.Amount = entitydts.Qty * entitydts.SinglePrice;
                        }
                        if (entitydts.Unit == "RMB/Y" || entitydts.Unit == "USD/Y")
                        {
                            entitydts.Amount = entitydts.Yard * entitydts.SinglePrice;
                        }
                        rule.RUpdate(entitydts, sqlTrans);

                        IOFormDtsPackRule prule = new IOFormDtsPackRule();
                        sql = "DELETE WH_IOFormDtsPack WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        sqlTrans.ExecuteNonQuery(sql);
                        for (int j = 0; j < dtsql.Rows.Count; j++)
                        {
                            IOFormDtsPack pentity = new IOFormDtsPack(sqlTrans);
                            pentity.MainID = entitydts.MainID;
                            pentity.Seq = entitydts.Seq;
                            pentity.SubSeq = SysConvert.ToInt32(dtsql.Rows[j]["SubSeq"]); //zhoufc 2014.10.17 SubSeq��ʾ���
                            pentity.GoodsLevel = SysConvert.ToString(dtsql.Rows[j]["GoodsLevel"]);
                            pentity.BoxNo = SysConvert.ToString(dtsql.Rows[j]["BoxNo"]);
                            pentity.Weight = SysConvert.ToDecimal(dtsql.Rows[j]["Weight"]);
                            pentity.Qty = SysConvert.ToDecimal(dtsql.Rows[j]["Qty"]);
                            pentity.Yard = SysConvert.ToDecimal(dtsql.Rows[j]["Yard"]);
                            pentity.DID = entitydts.ID;
                            prule.RAdd(pentity, sqlTrans);
                        }
                    }
                    else
                    {
                        sql = "SELECT * FROM WH_PackBox WHERE ID IN (" + p_IDStr + ")";
                        sql += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["WHID"]));
                        sql += " AND SectionID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["SectionID"]));
                        sql += " AND SBitID=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["SBitID"]));
                        sql += " AND JarNum=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["JarNum"]));
                        sql += " AND Batch=" + SysString.ToDBString(SysConvert.ToString(dt.Rows[i]["Batch"]));
                        DataTable dtsql = sqlTrans.Fill(sql);

                        IOFormDts entitydts = new IOFormDts(sqlTrans);
                        entitydts.ID = p_ID;
                        entitydts.SelectByID();
                        entitydts.Seq = MaxSeq + i;
                        entitydts.WHID = SysConvert.ToString(dt.Rows[i]["WHID"]);
                        entitydts.SectionID = SysConvert.ToString(dt.Rows[i]["SectionID"]);
                        entitydts.SBitID = SysConvert.ToString(dt.Rows[i]["SBitID"]);
                        entitydts.JarNum = SysConvert.ToString(dt.Rows[i]["JarNum"]);
                        entitydts.Batch = SysConvert.ToString(dt.Rows[i]["Batch"]);
                        entitydts.Qty = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Qty)", "")));
                        entitydts.Weight = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Weight)", "")), 2);
                        entitydts.Yard = SysConvert.ToDecimal(SysConvert.ToDecimal(dtsql.Compute("SUM(Yard)", "")), 2);
                        entitydts.PieceQty = dtsql.Rows.Count;
                        entitydts.PackFlag = 1;
                        if (entitydts.Unit == "RMB/KG" || entitydts.Unit == "USD/KG")
                        {
                            entitydts.Amount = entitydts.Weight * entitydts.SinglePrice;
                        }
                        if (entitydts.Unit == "RMB/M" || entitydts.Unit == "USD/M")
                        {
                            entitydts.Amount = entitydts.Qty * entitydts.SinglePrice;
                        }
                        if (entitydts.Unit == "RMB/Y" || entitydts.Unit == "USD/Y")
                        {
                            entitydts.Amount = entitydts.Yard * entitydts.SinglePrice;
                        }
                        sql = "SELECT ID FROM WH_IOFormDts WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        if (sqlTrans.Fill(sql).Rows.Count > 0)
                        {
                            throw new BaseException("�������У������Ѵ���");
                        }
                        rule.RAdd(entitydts, sqlTrans);
                        IOFormDtsPackRule prule = new IOFormDtsPackRule();
                        sql = "DELETE WH_IOFormDtsPack WHERE MainID=" + SysString.ToDBString(entitydts.MainID);
                        sql += " AND Seq=" + SysString.ToDBString(entitydts.Seq);
                        sqlTrans.ExecuteNonQuery(sql);
                        for (int j = 0; j < dtsql.Rows.Count; j++)
                        {
                            IOFormDtsPack pentity = new IOFormDtsPack(sqlTrans);
                            pentity.MainID = entitydts.MainID;
                            pentity.Seq = entitydts.Seq;
                            pentity.SubSeq = SysConvert.ToInt32(dtsql.Rows[j]["SubSeq"]); //zhoufc 2014.10.17 SubSeq��ʾ���
                            pentity.GoodsLevel = SysConvert.ToString(dtsql.Rows[j]["GoodsLevel"]);
                            pentity.BoxNo = SysConvert.ToString(dtsql.Rows[j]["BoxNo"]);
                            pentity.Weight = SysConvert.ToDecimal(dtsql.Rows[j]["Weight"]);
                            pentity.Qty = SysConvert.ToDecimal(dtsql.Rows[j]["Qty"]);
                            pentity.Yard = SysConvert.ToDecimal(dtsql.Rows[j]["Yard"]);
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




    }
}
