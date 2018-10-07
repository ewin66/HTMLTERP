using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTCPCheck;

using System.Windows.Forms;
using HttSoft.HTERP.Sys;
using HTCPCheck;

namespace HttSoft.HTCPCheck.DataCtl
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


                for (int i = 0; i < p_BE.Length; i++)
                {
                    IOFormDts entitydts = (IOFormDts)p_BE[i];
                    if (entitydts.ID != 0)//ID��Ϊ0˵�����ݿ����Ѿ�����
                    {
                        this.RUpdate(entitydts, sqlTrans);
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
        #endregion

        #region �������
        /// <summary>
        /// ����װ�䵥״̬
        /// </summary>
        void PackBoxProc(int p_FormListTopType, IOForm p_entity, IOFormDts[] p_entitydts, int p_Type, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            sql = "SELECT Seq,BoxNo,Qty,FactQty FROM WH_IOFormDtsPack WHERE MainID=" + SysString.ToDBString(p_entity.ID) + " ORDER BY MainID,Seq";
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
                        }
                        else//�����ύ
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.���)
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "���Ǵ������״̬��������ı�Ϊδ���״̬");
                            }
                            entity.BoxStatusID = (int)EnumBoxStatus.δ���;
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
                            entity.Qty = SysConvert.ToDecimal(dtBoxNo.Rows[i]["FactQty"]);

                        }
                        else//�����ύ
                        {
                            if (entity.BoxStatusID != (int)EnumBoxStatus.���)
                            {
                                throw new Exception("��ǰ�뵥" + dtBoxNo.Rows[i]["BoxNo"].ToString() + "���Ǵ������״̬���������ƿ�");
                            }
                            entity.Qty = SysConvert.ToDecimal(dtBoxNo.Rows[i]["Qty"]);

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
                //case (int)EnumFillDataType.�ɹ�����׼�����:   //��������
                //    goto case (int)EnumFillDataType.�ɹ�������׼�����;
                ////case (int)EnumFillDataType.����ɴ�߲ɹ������:
                ////    RFillDataPSCGRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                ////    break;
                //case (int)EnumFillDataType.���۳����׼�����:
                //    RFillDataXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    RFillDataXSCKFH(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;
                //case (int)EnumFillDataType.���۳�����������۶�������:
                //    RFillDataXSCK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;

                //case (int)EnumFillDataType.�ɹ�������׼�����:
                //    RFillDataCGRK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;


                //case (int)EnumFillDataType.�ӹ�������׼�����:
                //    RFillDataWORK(entity, entitydts, p_Type, drFormList, sqlTrans);
                //    break;
              
            }

        }

      


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
                sql = "SELECT DtsID,Qty,InQty FROM UV1_WO_WeaveProcessDts WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);
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

                        sql = "UPDATE WO_WeaveProcessDts SET ";
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

                        sql = "UPDATE WO_WeaveProcessDts SET ";
                        sql += " InFormDate=" + SysString.ToDBString(entity.FormDate.ToString("yyyy-MM-dd"));
                        sql += ",InQty=ISNULL(InQty,0)-" + "(" + SysString.ToDBString(thisQty) + ")";
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

    }
}
