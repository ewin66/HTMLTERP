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
    /// Ŀ�ģ�WH_PackBoxKPʵ��ҵ�������
    /// ����:�¼Ӻ�
    /// ��������:2012-5-7
    /// </summary>
    public class PackBoxKPRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public PackBoxKPRule()
        {
        }

        /// <summary>
        /// ��齫Ҫ�����������Ƿ����ҵ�����
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            PackBoxKP entity = (PackBoxKP)p_BE;
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_PackBoxKP WHERE 1=1";
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
                PackBoxKP entity = (PackBoxKP)p_BE;
                string sql = "SELECT FormNo FROM WH_PackBoxKP WHERE FormNo=" + SysString.ToDBString(entity.FormNo);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    throw new BaseException("�����Ѵ��ڣ�����������");
                }
                PackBoxKPCtl control = new PackBoxKPCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WH_PackBoxKP, sqlTrans);
                control.AddNew(entity);
                FormNoControlRule rulest = new FormNoControlRule();
                rulest.RAddSort((int)FormNoControlEnum.��ƥ����, sqlTrans);
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
                PackBoxKP entity = (PackBoxKP)p_BE;
                PackBoxKPCtl control = new PackBoxKPCtl(sqlTrans);
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
                PackBoxKP entity = (PackBoxKP)p_BE;
                PackBoxKPCtl control = new PackBoxKPCtl(sqlTrans);
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
                PackBoxKP entity = new PackBoxKP(sqlTrans);
                entity.ID = p_FormID;
                entity.SelectByID();
                if (entity.SubmitFlag == p_Type)//�����ͬ�쳣
                {
                    throw new Exception("����״̬�ظ����ã���رճ������´򿪲���");
                }


                //��ƥ�����ύ

                PackBoxRule pbrule = new PackBoxRule();
                PackBox pbentitysource = pbrule.RGetEntityByBoxNo(entity.BoxNo, sqlTrans);
                if (pbentitysource.ID != 0)
                {
                    if (pbentitysource.BoxStatusID == (int)EnumBoxStatus.���)
                    {
                        if (p_Type == (int)YesOrNo.Yes)//��ƥ����
                        {
                            if ((pbentitysource.Qty <= entity.TargetQty && pbentitysource.Qty != 0 && entity.TargetQty != 0) || (pbentitysource.Weight <= entity.TargetWeight && pbentitysource.Weight != 0 && entity.TargetWeight != 0) || (pbentitysource.Yard <= entity.TargetYard && pbentitysource.Yard != 0 && entity.TargetYard != 0))
                            {
                                throw new Exception("��������Դ�������������������߹�����С�ڵ��ڿ�ƥĿ�����������������߹�������");
                            }

                            entity.Qty = pbentitysource.Qty;//��ֵ������������ֹ����������
                            entity.Weight = pbentitysource.Weight;
                            entity.Yard = pbentitysource.Yard;
                            PackBox pbentity = new PackBox(sqlTrans);//Ŀ�����ʵ��
                            pbentity.SelectByID();
                            CopyEntityData(pbentitysource, pbentity);
                            pbentity.SourceTypeID = (int)PackBoxSourceType.��ƥ;
                            pbentity.BoxStatusID = (int)EnumBoxStatus.���;
                            pbentity.Qty = entity.TargetQty;
                            pbentity.Weight = entity.TargetWeight;
                            pbentity.Yard = entity.Yard;
                            pbentity.SourceBoxNo = pbentitysource.BoxNo;
                            pbrule.RAdd(pbentity, sqlTrans);

                            pbentitysource.Qty = pbentitysource.Qty - pbentity.Qty;//�޸�Դ�������
                            pbentitysource.Weight = pbentitysource.Weight - pbentity.Weight;
                            pbentitysource.Yard = pbentitysource.Yard - pbentity.Yard;
                            pbentitysource.KPFlag = (int)YesOrNo.Yes;//�޸�Դ��ſ�ƥ��־
                            pbrule.RUpdate(pbentitysource, sqlTrans);
                            entity.TargetBoxNo = pbentity.BoxNo;

                            //���뿪ƥ��ϸ����
                            PackBoxKPDtsRule dtsRule = new PackBoxKPDtsRule();
                            PackBoxKPDts entitydts1 = new PackBoxKPDts(sqlTrans);
                            entitydts1.MainID = entity.ID;
                            entitydts1.Seq = 1;
                            entitydts1.BoxNo = entity.BoxNo;
                            entitydts1.ColorNO = entity.ColorNO;
                            entitydts1.ColorName = entity.ColorName;
                            entitydts1.SourceQty = pbentitysource.Qty + pbentity.Qty;//�����ݸ���ʱ������ɾ����
                            entitydts1.SourceWeight = pbentitysource.Weight + pbentity.Weight;//�����ݸ���ʱ������ɾ����
                            entitydts1.SourceYard = pbentitysource.Yard + pbentity.Yard;//�����ݸ���ʱ������ɾ����
                            entitydts1.Qty = pbentitysource.Qty;//�����ݸ���ʱ������ɾ����
                            entitydts1.Weight = pbentitysource.Weight;//�����ݸ���ʱ������ɾ����
                            entitydts1.Yard = pbentitysource.Yard;//�����ݸ���ʱ������ɾ����
                            dtsRule.RAdd(entitydts1, sqlTrans);

                            PackBoxKPDts entitydts2 = new PackBoxKPDts(sqlTrans);
                            entitydts2.MainID = entity.ID;
                            entitydts2.Seq = 2;
                            entitydts2.BoxNo = entity.TargetBoxNo;
                            entitydts2.ColorNO = entity.ColorNO;
                            entitydts2.ColorName = entity.ColorName;
                            entitydts2.SourceQty = 0;
                            entitydts2.Qty = entity.TargetQty;
                            entitydts2.Weight = entity.TargetWeight;
                            entitydts2.Yard = entity.TargetYard;
                            dtsRule.RAdd(entitydts2, sqlTrans);
                            #region ���Ҳֿ��������
                            string sqlCal = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(pbentity.WHID);//��òֿ���������ֶ�
                            DataTable dt = sqlTrans.Fill(sqlCal);
                            string FieldNamestr = string.Empty;
                            if (dt.Rows.Count != 0)
                            {
                                FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
                            }
                            sql = "UPDATE WH_Storge SET PieceQty=PieceQty+1 WHERE 1=1";
                            sql += " AND WHID=" + SysString.ToDBString(pbentity.WHID);
                            sql += " AND SectionID=" + SysString.ToDBString(pbentity.SectionID);
                            sql += " AND SBitID=" + SysString.ToDBString(pbentity.SBitID);
                            int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
                            if (FieldNamestr != string.Empty)
                            {
                                string[] FieldName = FieldNamestr.Split('+');
                                for (int i = 0; i < FieldName.Length; i++)
                                {
                                    string sqlFieldName = "SELECT ID FROM Enum_WHCalMethodFieldName WHERE Name=" + SysString.ToDBString(FieldName[i]);//�ҵ��������ֶζ�Ӧ��ID
                                    DataTable dtFieldName = sqlTrans.Fill(sqlFieldName);
                                    if (dtFieldName.Rows.Count != 0 && dtFieldName.Rows[0]["ID"].ToString() != "")
                                    {
                                        CalFieldName = SysConvert.ToInt32(dtFieldName.Rows[0]["ID"]);
                                    }
                                    switch (CalFieldName)
                                    {
                                        case (int)WHCalMethodFieldName.ItemCode://��Ʒ����
                                            sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(pbentity.ItemCode);
                                            break;
                                        case (int)WHCalMethodFieldName.ColorNum://ɫ��
                                            sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(pbentity.ColorNum);
                                            break;
                                        case (int)WHCalMethodFieldName.ColorName://��ɫ
                                            sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(pbentity.ColorName);
                                            break;
                                        case (int)WHCalMethodFieldName.Batch:   //����
                                            sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(pbentity.Batch);
                                            break;
                                        case (int)WHCalMethodFieldName.VendorBatch:  //�ͻ�����
                                            sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(pbentity.VendorBatch);
                                            break;
                                        case (int)WHCalMethodFieldName.JarNum:  //�׺�
                                            sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(pbentity.JarNum);
                                            break;
                                        case (int)WHCalMethodFieldName.MWidth://�ŷ�
                                            sql += " AND ISNULL(MWidth,'')=" + SysString.ToDBString(pbentity.MWidth);
                                            break;
                                        case (int)WHCalMethodFieldName.MWeight://����
                                            sql += " AND ISNULL(MWeight,'')=" + SysString.ToDBString(pbentity.MWeight);
                                            break;
                                        case (int)WHCalMethodFieldName.DtsOrderFormNo://����
                                            sql += " AND ISNULL(OrderFormNo,0)=" + SysString.ToDBString(pbentity.OrderFormNo);
                                            break;
                                        default:
                                            throw new Exception("�����쳣�����㶨����ֶεײ�δ��Ӧ��" + CalFieldName + ",����ϵ����Ա");
                                    }
                                }
                            }
                            #endregion
                            sqlTrans.ExecuteNonQuery(sql);

                        }
                        else//������ƥ����
                        {
                            PackBox pbentity = pbrule.RGetEntityByBoxNo(entity.TargetBoxNo, sqlTrans);//Ŀ�����ʵ��
                            if (pbentitysource.ID == 0)
                            {
                                throw new Exception("��������δ�ҵ�Ŀ������");
                            }
                            //��ʼ�����Ƿ��������ύ
                            if (pbentity.WHID == pbentitysource.WHID && pbentity.SectionID == pbentitysource.SectionID
                                && pbentity.SBitID == pbentitysource.SBitID)
                            {
                            }
                            else//�����иı�
                            {
                                throw new Exception("�������󣬿�ƥ���������ƿ��ˣ����볷��ɾ���ƿⵥ���ٽ����ƿ����");
                            }
                            #region �жϿ�ƥ���������û���ٴα���ƥ
                            sql = "SELECT * FROM WH_PackBox WHERE SourceBoxNo =" + SysString.ToDBString(pbentity.BoxNo);
                            DataTable dtSource = sqlTrans.Fill(sql);
                            if (dtSource.Rows.Count > 0)
                            {
                                throw new Exception("��������,��ƥ��������ֿ���ƥ�����볷��������Ŀ�ƥ���ٽ��г���");
                            }
                            #endregion
                            #region �жϿ�ƥ��������״̬
                            sql = "SELECT BoxStatusID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(pbentity.BoxNo);
                            DataTable dtBoxStatus = sqlTrans.Fill(sql);
                            if (dtBoxStatus.Rows.Count != 0)
                            {
                                if (SysConvert.ToInt32(dtBoxStatus.Rows[0]["BoxStatusID"]) != (int)EnumBoxStatus.���)
                                {
                                    throw new Exception("����" + pbentity.BoxNo + "״̬δ�������״̬�����ܳ���");
                                }
                            }
                            #endregion
                            //���������Ƿ��������ύ
                            //pbrule.RCheckDelete(entity.TargetBoxNo, sqlTrans);//У���Ƿ�����ɾ��
                            pbrule.RDelete(pbentity, sqlTrans);

                            pbentitysource.Qty = pbentitysource.Qty + pbentity.Qty;//�޸�Դ�������
                            pbentitysource.Weight = pbentitysource.Weight + pbentity.Weight;
                            pbentitysource.Yard = pbentitysource.Yard + pbentity.Yard;
                            #region �жϸ�ƥ�Ƿ����俪ƥ
                            sql = "SELECT * FROM WH_PackBox WHERE SourceBoxNo =" + SysString.ToDBString(pbentitysource.BoxNo);
                            DataTable dtpbentitysource = sqlTrans.Fill(sql);
                            if (dtpbentitysource.Rows.Count == 0)
                            {
                                pbentitysource.KPFlag = (int)YesOrNo.No;//�޸�Դ��ſ�ƥ��־
                            }
                            #endregion
                            pbrule.RUpdate(pbentitysource, sqlTrans);
                            entity.TargetBoxNo = "";//Ŀ�����
                            sql = "DELETE FROM WH_PackBoxKPDts WHERE MainID=" + entity.ID;//ɾ����ƥ��ϸ����
                            sqlTrans.ExecuteNonQuery(sql);

                            #region ���Ҳֿ��������
                            string sqlCal = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(pbentity.WHID);//��òֿ���������ֶ�
                            DataTable dt = sqlTrans.Fill(sqlCal);
                            string FieldNamestr = string.Empty;
                            if (dt.Rows.Count != 0)
                            {
                                FieldNamestr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
                            }
                            sql = "UPDATE WH_Storge SET PieceQty=PieceQty-1 WHERE 1=1";
                            sql += " AND WHID=" + SysString.ToDBString(pbentity.WHID);
                            sql += " AND SectionID=" + SysString.ToDBString(pbentity.SectionID);
                            sql += " AND SBitID=" + SysString.ToDBString(pbentity.SBitID);
                            int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
                            if (FieldNamestr != string.Empty)
                            {
                                string[] FieldName = FieldNamestr.Split('+');
                                for (int i = 0; i < FieldName.Length; i++)
                                {
                                    string sqlFieldName = "SELECT ID FROM Enum_WHCalMethodFieldName WHERE Name=" + SysString.ToDBString(FieldName[i]);//�ҵ��������ֶζ�Ӧ��ID
                                    DataTable dtFieldName = sqlTrans.Fill(sqlFieldName);
                                    if (dtFieldName.Rows.Count != 0 && dtFieldName.Rows[0]["ID"].ToString() != "")
                                    {
                                        CalFieldName = SysConvert.ToInt32(dtFieldName.Rows[0]["ID"]);
                                    }
                                    switch (CalFieldName)
                                    {
                                        case (int)WHCalMethodFieldName.ItemCode://��Ʒ����
                                            sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(pbentity.ItemCode);
                                            break;
                                        case (int)WHCalMethodFieldName.ColorNum://ɫ��
                                            sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(pbentity.ColorNum);
                                            break;
                                        case (int)WHCalMethodFieldName.ColorName://��ɫ
                                            sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(pbentity.ColorName);
                                            break;
                                        case (int)WHCalMethodFieldName.Batch:   //����
                                            sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(pbentity.Batch);
                                            break;
                                        case (int)WHCalMethodFieldName.VendorBatch:  //�ͻ�����
                                            sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(pbentity.VendorBatch);
                                            break;
                                        case (int)WHCalMethodFieldName.JarNum:  //�׺�
                                            sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(pbentity.JarNum);
                                            break;
                                        case (int)WHCalMethodFieldName.MWidth://�ŷ�
                                            sql += " AND ISNULL(MWidth,'')=" + SysString.ToDBString(pbentity.MWidth);
                                            break;
                                        case (int)WHCalMethodFieldName.MWeight://����
                                            sql += " AND ISNULL(MWeight,'')=" + SysString.ToDBString(pbentity.MWeight);
                                            break;
                                        case (int)WHCalMethodFieldName.DtsOrderFormNo://����
                                            sql += " AND ISNULL(OrderFormNo,0)=" + SysString.ToDBString(pbentity.OrderFormNo);
                                            break;
                                        default:
                                            throw new Exception("�����쳣�����㶨����ֶεײ�δ��Ӧ��" + CalFieldName + ",����ϵ����Ա");
                                    }
                                }
                            }
                            #endregion
                            sqlTrans.ExecuteNonQuery(sql);
                        }
                    }
                    else
                    {
                        throw new Exception("��������Դ���벻�������״̬");
                    }
                }
                else
                {
                    throw new Exception("��������δ�ҵ�Դ����");
                }

                entity.SubmitFlag = p_Type;
                this.RUpdate(entity, sqlTrans);//��������״̬


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
        /// �������ݵ�ʵ����
        /// </summary>
        /// <param name="p_MainDts"></param>
        /// <param name="p_BE"></param>
        public void CopyEntityData(PackBox p_PBEntitySouce, PackBox p_PBEntity)
        {
            p_PBEntity.CompanyTypeID = p_PBEntitySouce.CompanyTypeID;
            p_PBEntity.GoodsCode = p_PBEntitySouce.GoodsCode;
            p_PBEntity.GoodsLevel = p_PBEntitySouce.GoodsLevel;
            p_PBEntity.MWeight = p_PBEntitySouce.MWeight;
            p_PBEntity.MWidth = p_PBEntitySouce.MWidth;
            p_PBEntity.ItemCode = p_PBEntitySouce.ItemCode;
            p_PBEntity.ItemName = p_PBEntitySouce.ItemName;
            p_PBEntity.ItemStd = p_PBEntitySouce.ItemStd;
            p_PBEntity.Batch = p_PBEntitySouce.Batch;
            p_PBEntity.VendorBatch = p_PBEntitySouce.VendorBatch;
            p_PBEntity.WHID = p_PBEntitySouce.WHID;
            p_PBEntity.SectionID = p_PBEntitySouce.SectionID;
            p_PBEntity.SBitID = p_PBEntitySouce.SBitID;
            p_PBEntity.Unit = p_PBEntitySouce.Unit;
            p_PBEntity.ColorName = p_PBEntitySouce.ColorName;
            p_PBEntity.ColorNum = p_PBEntitySouce.ColorNum;
            p_PBEntity.JarNum = p_PBEntitySouce.JarNum;
            p_PBEntity.OrderFormNo = p_PBEntitySouce.OrderFormNo;
            p_PBEntity.ItemModel = p_PBEntitySouce.ItemModel;
        }
        #endregion

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RAdd(int p_ID, decimal p_Qty, string p_OPID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RAdd(p_ID, p_Qty, p_OPID, sqlTrans);

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
        public void RAdd(int p_ID, decimal p_Qty, string p_OPID, IDBTransAccess sqlTrans)
        {
            try
            {


                PackBoxKPRule rule = new PackBoxKPRule();
                PackBox entity = new PackBox(sqlTrans);
                entity.ID = p_ID;
                entity.SelectByID();

                FormNoControlRule frule = new FormNoControlRule();
                PackBoxKP pentity = new PackBoxKP();
                pentity.FormNo = frule.RGetFormNo((int)FormNoControlEnum.��ƥ����, sqlTrans);
                pentity.FormDate = DateTime.Now;
                pentity.MakeDate = DateTime.Now;
                pentity.MakeOPID = p_OPID;
                pentity.SaleOPID = p_OPID;
                pentity.KPOPID = p_OPID;
                pentity.BoxNo = entity.BoxNo;
                pentity.Qty = entity.Qty;
                pentity.TargetQty = p_Qty;

                rule.RAdd(pentity, sqlTrans);

                rule.RSubmit(pentity.ID, 1, sqlTrans);


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





    }
}
