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
    /// Ŀ�ģ�WH_Storgeʵ��ҵ�������
    /// ����:�¼Ӻ�
    /// ��������:2009-4-23
    /// </summary>
    public class StorgeRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public StorgeRule()
        {
        }

        /// <summary>
        /// ��齫Ҫ�����������Ƿ����ҵ�����
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            Storge entity = (Storge)p_BE;
        }

        #region ��ʾ����
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
                string sql = "SELECT " + p_FieldName + " FROM UV1_WH_Storge WHERE 1=1";
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
        public DataTable LKRShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM WH_Storge WHERE 1=1";
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

        #region  ���ɵĴ���
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
                Storge entity = (Storge)p_BE;
                StorgeCtl control = new StorgeCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WH_Storge, sqlTrans);
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
                Storge entity = (Storge)p_BE;
                StorgeCtl control = new StorgeCtl(sqlTrans);
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
                Storge entity = (Storge)p_BE;
                StorgeCtl control = new StorgeCtl(sqlTrans);
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
        #endregion

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="p_Entity">IOFormʵ��</param>
        /// <param name="p_EntityDts">IOFormDtsʵ��</param>
        /// <param name="p_Type">1/3 ���ͨ��/��˾ܾ�</param>
        public void RSubmit(int p_FormTopType, IOForm p_Entity, IOFormDts p_EntityDts, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                if (p_FormTopType == (int)WHFormList.�ƿ�)//�ƿⵥ����
                {
                    this.RSubmitMove(p_FormTopType, p_Entity, p_EntityDts, p_Type, sqlTrans);
                    return;
                }

                if (p_FormTopType == (int)WHFormList.�̵�)//�̵㵥����
                {
                    this.RSubmitCheck(p_FormTopType, p_Entity, p_EntityDts, p_Type, sqlTrans);
                    return;
                }



                Storge entityst = new Storge(sqlTrans);//��������
                int StorgeID = 0;
                bool p_NegativeFlag = false;//������־
                bool p_ZeroExitFlag = false;//Ϊ0��־
                int p_ISJK = 0;//�Ŀ��־

                WH entityWH = new WH(sqlTrans);
                string sqlWH = "Select ID,ISJK FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_EntityDts.WHID);
                DataTable dtWH = sqlTrans.Fill(sqlWH);
                if (dtWH.Rows.Count != 0)
                {
                    entityWH.ID = SysConvert.ToInt32(dtWH.Rows[0]["ID"]);
                    entityWH.SelectByID();

                    p_ISJK = SysConvert.ToInt32(dtWH.Rows[0]["ISJK"]);//�Ŀ�
                }



                StorgeID = FindStorge(p_EntityDts, sqlTrans);
                if (StorgeID != 0)//�ҵ���ʷ��¼
                {
                    entityst.ID = StorgeID;
                    entityst.SelectByID();

                }
                else//�Ҳ�����ʷ��¼
                {
                    entityst.Indate = p_Entity.FormDate;
                    entityst.DutyOPID = p_Entity.DutyOP;
                    entityst.WHID = p_EntityDts.WHID;
                    entityst.SectionID = p_EntityDts.SectionID;
                    entityst.SBitID = p_EntityDts.SBitID;
                    entityst.ItemCode = p_EntityDts.ItemCode;
                    entityst.ItemName = p_EntityDts.ItemName;
                    entityst.ItemStd = p_EntityDts.ItemStd;
                    entityst.ColorNum = p_EntityDts.ColorNum;
                    entityst.ColorName = p_EntityDts.ColorName;
                    entityst.JarNum = p_EntityDts.JarNum;
                    entityst.Batch = p_EntityDts.Batch;
                    entityst.VendorBatch = p_EntityDts.VendorBatch;
                    entityst.YarnType = p_EntityDts.YarnType;
                    entityst.Unit = p_EntityDts.Unit;
                    entityst.SinglePrice = p_EntityDts.SinglePrice;
                    entityst.TubeGW = p_EntityDts.TubeGW;
                    entityst.Remark = p_EntityDts.Remark;
                    entityst.VColorNum = p_EntityDts.VColorNum;
                    entityst.VColorName = p_EntityDts.VColorName;
                    entityst.VItemCode = p_EntityDts.VItemCode;
                    entityst.GoodsCode = p_EntityDts.GoodsCode;
                    entityst.GoodsLevel = p_EntityDts.GoodsLevel;
                    entityst.MWidth = p_EntityDts.MWidth;
                    entityst.MWeight = p_EntityDts.MWeight;
                    entityst.WeightUnit = p_EntityDts.WeightUnit;
                    entityst.MLType = p_EntityDts.MLType;   //�������ֳ�Ʒ���Ϻ�����
                    if (p_FormTopType != (int)WHFormList.����)//�ǳ���״̬
                    {
                        entityst.VendorID = p_EntityDts.DtsVendorID;//
                        entityst.SO = p_EntityDts.DtsSO;//���ݺ�
                        entityst.DutyOPID = p_EntityDts.DtsSaleOPID;//ҵ��Ա
                        entityst.OrderFormNo = p_EntityDts.DtsOrderFormNo;//��ͬ��
                    }
                    else//����״̬
                    {
                        entityst.VendorID = p_EntityDts.DtsInVendorID;//���ͻ�
                        entityst.SO = p_EntityDts.InSO;//��ⶩ��
                        entityst.DutyOPID = p_EntityDts.InSaleOPID;//���ҵ��Ա
                        entityst.OrderFormNo = p_EntityDts.InOrderFormNo;//����ͬ��
                    }

                    entityst.DVendorID = p_EntityDts.DVendorID;//���ۺ�ͬ
                    entityst.Needle = p_EntityDts.Needle;



                }
                if (p_Entity.SubmitFlag == (int)ConfirmFlag.���ͨ��)
                {
                    switch (p_FormTopType)
                    {
                        case (int)WHFormList.���:
                            entityst.Qty += p_EntityDts.Qty;
                            entityst.PieceQty += p_EntityDts.PieceQty;
                            entityst.Weight += p_EntityDts.Weight;
                            entityst.Yard += p_EntityDts.Yard;
                            entityst.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;//������

                            break;
                        case (int)WHFormList.����:
                            entityst.Qty -= p_EntityDts.Qty;
                            entityst.Yard -= p_EntityDts.Yard;
                            entityst.PieceQty -= p_EntityDts.PieceQty;
                            entityst.Weight -= p_EntityDts.Weight;
                            entityst.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;//������
                            break;
                        case (int)WHFormList.�ڳ����:
                            goto case (int)WHFormList.���;
                    }

                }
                else
                {
                    switch (p_FormTopType)
                    {
                        case (int)WHFormList.���:
                            entityst.Qty -= p_EntityDts.Qty;
                            entityst.PieceQty -= p_EntityDts.PieceQty;
                            entityst.Weight -= p_EntityDts.Weight;
                            entityst.Yard -= p_EntityDts.Yard;
                            entityst.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;//������
                            break;
                        case (int)WHFormList.����:
                            entityst.Qty += p_EntityDts.Qty;

                            entityst.PieceQty += p_EntityDts.PieceQty;
                            entityst.Weight += p_EntityDts.Weight;
                            entityst.Yard += p_EntityDts.Yard;
                            entityst.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;//������
                            break;
                        case (int)WHFormList.�ڳ����:
                            goto case (int)WHFormList.���;
                    }

                }


                if (entityst.Qty < -0.001m || entityst.Weight < -0.001m || entityst.Yard < -0.001m)//�����������0
                {
                    throw new Exception("����������������0�����ܲ��������룺" + entityst.ItemCode + " ���ţ�" + entityst.Batch + " ɫ�ţ�" + entityst.ColorNum + " ��ɫ��" + entityst.ColorName + " �׺ţ�" + entityst.JarNum + " ������" + entityst.Qty.ToString() + "������" + entityst.Weight.ToString());
                }

                if (entityst.FreeQty < -0.001m)//����ʹ����������0
                {
                    throw new Exception("���������ʹ����������0�����ܲ��������룺" + entityst.ItemCode + "  ɫ�ţ�" + entityst.ColorNum + " ��ɫ��" + entityst.ColorName + " ������" + entityst.FreeQty.ToString());
                }

                this.RSaveEntity(entityst, p_ZeroExitFlag, sqlTrans);


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
        /// ���ϳ������ҿ��
        /// </summary>
        /// <param name="p_entity"></param>
        /// <param name="sqlTrans"></param>
        /// <returns></returns>
        public int FindStorge(IOFormDts p_entity, IDBTransAccess sqlTrans)
        {

            if (p_entity.WHID == string.Empty)
            {
                throw new Exception("���ݲֿ�δ�ҵ������ܲ���");
            }

            string conditionstr = string.Empty;
            string sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(p_entity.WHID);//��òֿ���������ֶ�
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                conditionstr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
            }



            sql = "SELECT ID FROM WH_Storge WHERE 1=1";//���ҿ��ID
            int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
            if (conditionstr != string.Empty)
            {
                string[] FieldName = conditionstr.Split('+');
                sql += " AND WHID=" + SysString.ToDBString(p_entity.WHID);
                sql += " AND SectionID=" + SysString.ToDBString(p_entity.SectionID);
                sql += " AND SBitID=" + SysString.ToDBString(p_entity.SBitID);
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
                        case (int)WHCalMethodFieldName.WHID://��
                            sql += " AND WHID=" + SysString.ToDBString(p_entity.WHID);
                            break;
                        case (int)WHCalMethodFieldName.SectionID://��
                            sql += " AND SectionID=" + SysString.ToDBString(p_entity.SectionID);
                            break;
                        case (int)WHCalMethodFieldName.SBitID://λ
                            sql += " AND SBitID=" + SysString.ToDBString(p_entity.SBitID);
                            break;
                        case (int)WHCalMethodFieldName.ItemCode://��Ʒ����
                            sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(p_entity.ItemCode);
                            break;
                        case (int)WHCalMethodFieldName.JarNum://�׺�
                            sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(p_entity.JarNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorNum://ɫ��
                            sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(p_entity.ColorNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorName://��ɫ
                            sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(p_entity.ColorName);
                            break;
                        case (int)WHCalMethodFieldName.MWidth://�ŷ�
                            sql += " AND ISNULL(MWidth,0)=" + SysString.ToDBString(p_entity.MWidth);
                            break;
                        case (int)WHCalMethodFieldName.MWeight://����
                            sql += " AND ISNULL(MWeight,0)=" + SysString.ToDBString(p_entity.MWeight);
                            break;
                        case (int)WHCalMethodFieldName.VendorID://�ͻ�
                            sql += " AND ISNULL(VendorID,'')=" + SysString.ToDBString(p_entity.DtsVendorID);
                            break;
                        case (int)WHCalMethodFieldName.GoodsCode://��Ʒ��
                            sql += " AND ISNULL(GoodsCode,'')=" + SysString.ToDBString(p_entity.GoodsCode);
                            break;
                        case (int)WHCalMethodFieldName.GoodsLevel://�ȼ�
                            sql += " AND ISNULL(GoodsLevel,'')=" + SysString.ToDBString(p_entity.GoodsLevel);
                            break;
                        case (int)WHCalMethodFieldName.Batch:   //����
                            sql += " AND ISNULL(Batch,'')=" + SysString.ToDBString(p_entity.Batch);
                            break;
                        case (int)WHCalMethodFieldName.Unit:   //��λ
                            sql += " AND ISNULL(Unit,'')=" + SysString.ToDBString(p_entity.Unit);
                            break;
                        case (int)WHCalMethodFieldName.VendorBatch:  //�ͻ�����
                            sql += " AND ISNULL(VendorBatch,'')=" + SysString.ToDBString(p_entity.VendorBatch);
                            break;
                        case (int)WHCalMethodFieldName.DtsOrderFormNo:  //������
                            sql += " AND ISNULL(OrderFormNo,'')=" + SysString.ToDBString(p_entity.DtsOrderFormNo);
                            break;
                        default:
                            throw new Exception("�����쳣�����㶨����ֶεײ�δ��Ӧ��" + CalFieldName);

                    }
                }
            }
            else
            {
                throw new Exception("û���ҵ��������ͣ�����ϵ����Ա���ֿ�����������Ϣ");
            }
            DataTable dtlog = sqlTrans.Fill(sql);
            if (dtlog.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dtlog.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// �����ƿ���ҿ��
        /// </summary>
        /// <param name="p_entity"></param>
        /// <param name="sqlTrans"></param>
        /// <returns></returns>
        public int FindStorge(IOFormDts p_entity, int p_Type, IDBTransAccess sqlTrans)
        {

            if (p_entity.WHID == string.Empty)
            {
                throw new Exception("���ݲֿ�δ�ҵ������ܲ���");
            }

            string conditionstr = string.Empty;
            string sql = "SELECT FieldName FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(p_entity.WHID);//��òֿ���������ֶ�
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                conditionstr += SysConvert.ToString(dt.Rows[0]["FieldName"]);
            }



            sql = "SELECT ID FROM WH_Storge WHERE 1=1";//���ҿ��ID
            int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
            if (conditionstr != string.Empty)
            {
                string[] FieldName = conditionstr.Split('+');
                if (p_Type == (int)EnumWHMove.�ƶ���)
                {
                    sql += " AND WHID=" + SysString.ToDBString(p_entity.WHID);
                    sql += " AND SectionID=" + SysString.ToDBString(p_entity.SectionID);
                    sql += " AND SBitID=" + SysString.ToDBString(p_entity.SBitID);
                }
                else if (p_Type == (int)EnumWHMove.Ŀ�Ŀ�)
                {
                    sql += " AND WHID=" + SysString.ToDBString(p_entity.ToWHID);
                    sql += " AND SectionID=" + SysString.ToDBString(p_entity.ToSectionID);
                    sql += " AND SBitID=" + SysString.ToDBString(p_entity.ToSBitID);
                }
                else
                {
                    throw new Exception("������������쳣");
                }
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
                        case (int)WHCalMethodFieldName.WHID://�� �Ϸ��Ѵ���
                            break;
                        case (int)WHCalMethodFieldName.SectionID://��
                            break;
                        case (int)WHCalMethodFieldName.SBitID://λ
                            break;
                        case (int)WHCalMethodFieldName.ItemCode://��Ʒ����
                            sql += " AND ItemCode=" + SysString.ToDBString(p_entity.ItemCode);
                            break;
                        case (int)WHCalMethodFieldName.JarNum://�׺�
                            sql += " AND JarNum=" + SysString.ToDBString(p_entity.JarNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorNum://ɫ��
                            sql += " AND ColorNum=" + SysString.ToDBString(p_entity.ColorNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorName://��ɫ
                            sql += " AND ColorName=" + SysString.ToDBString(p_entity.ColorName);
                            break;
                        case (int)WHCalMethodFieldName.MWidth://�ŷ�
                            sql += " AND MWidth=" + SysString.ToDBString(p_entity.MWidth);
                            break;
                        case (int)WHCalMethodFieldName.MWeight://����
                            sql += " AND MWeight=" + SysString.ToDBString(p_entity.MWeight);
                            break;
                        case (int)WHCalMethodFieldName.VendorID://�ͻ�
                            sql += " AND VendorID=" + SysString.ToDBString(p_entity.DtsVendorID);
                            break;
                        case (int)WHCalMethodFieldName.GoodsCode://��Ʒ��
                            sql += " AND GoodsCode=" + SysString.ToDBString(p_entity.GoodsCode);
                            break;
                        case (int)WHCalMethodFieldName.GoodsLevel://�ȼ�
                            sql += " AND GoodsLevel=" + SysString.ToDBString(p_entity.GoodsLevel);
                            break;
                        case (int)WHCalMethodFieldName.Batch:   //����
                            sql += " AND Batch=" + SysString.ToDBString(p_entity.Batch);
                            break;
                        case (int)WHCalMethodFieldName.Unit:   //����
                            sql += " AND Unit=" + SysString.ToDBString(p_entity.Unit);
                            break;
                        case (int)WHCalMethodFieldName.VendorBatch:  //�ͻ�����
                            sql += " AND VendorBatch=" + SysString.ToDBString(p_entity.VendorBatch);
                            break;
                        case (int)WHCalMethodFieldName.DtsOrderFormNo:  //������
                            sql += " AND ISNULL(DtsOrderFormNo,'')=" + SysString.ToDBString(p_entity.DtsOrderFormNo);
                            break;
                        case (int)WHCalMethodFieldName.DtsSO:  //������
                            sql += " AND ISNULL(DtsSO,'')=" + SysString.ToDBString(p_entity.DtsSO);
                            break;
                        default:
                            throw new Exception("�����쳣�����㶨����ֶεײ�δ��Ӧ��" + CalFieldName);


                    }
                }
            }
            else
            {
                throw new Exception("û���ҵ��������ͣ�����ϵ����Ա���ֿ�����������Ϣ");
            }
            DataTable dtlog = sqlTrans.Fill(sql);
            if (dtlog.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dtlog.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region ��������
        /// <summary>
        /// ȡ�òֿ��������
        /// </summary>
        /// <param name="p_WHID"></param>
        /// <returns></returns>
        private int GetAmountType(string p_WHID, IDBTransAccess sqlTrans)
        {
            int p_AmountType = 0;
            string sql = "SELECT AmountType FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_WHID);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                p_AmountType = SysConvert.ToInt32(dt.Rows[0]["AmountType"].ToString());
            }
            return p_AmountType;
        }
        #endregion

        #region ���������ʵ��
        /// <summary>
        /// ���������ʵ��
        /// </summary>
        private void RSaveEntity(BaseEntity p_BE, bool p_ZeroExitFlag, IDBTransAccess sqlTrans)
        {
            try
            {
                Storge entity = (Storge)p_BE;


                ///2010.2.1�޸�--�ܸ���
                if (entity.ID == 0)//����
                {
                    this.RAdd(entity, sqlTrans);
                }

                if (entity.ID != 0)//���� 
                {
                    this.RUpdate(entity, sqlTrans);
                }


                if (!p_ZeroExitFlag)//���������Ϊ0�Ŀ����ڣ��������¼
                {
                    if (entity.ID != 0 && (entity.Qty == 0 && entity.Weight == 0 && entity.Yard == 0))//���� && entity.PieceQty==0
                    {
                        this.RDelete(entity, sqlTrans);
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

        #region �ҿ������
        //public int FindStorge(string p_WHID, string p_SectionID, string p_SBitID, int p_CompanyTypeID, string p_ItemCode, string p_Batch, string p_VendorBatch, string p_JarNum, string p_ColorNum, string p_ColorName, string p_Needle, string p_YarnStatus, string p_DtsSO, int p_WHTypeID, string p_SizeName)
        //{
        //    try
        //    {
        //        IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
        //        try
        //        {
        //            sqlTrans.OpenTrans();

        //            return FindStorge(p_WHID, p_SectionID, p_SBitID, p_CompanyTypeID, p_ItemCode, p_Batch, p_VendorBatch, p_JarNum, p_ColorNum, p_ColorName, p_Needle, p_YarnStatus, p_DtsSO, p_WHTypeID, p_SizeName, sqlTrans);

        //            sqlTrans.CommitTrans();
        //        }
        //        catch (Exception TE)
        //        {
        //            sqlTrans.RollbackTrans();
        //            throw TE;
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
        ///// �жϿ����Ƿ���ڸü�¼
        ///// </summary>
        ///// <param name="p_WHID"></param>
        ///// <param name="p_SectionID"></param>
        ///// <param name="p_SBitID"></param>
        ///// <param name="p_ItemCode"></param>
        ///// <param name="p_Batch"></param>
        ///// <param name="p_JarNum"></param>
        ///// <param name="p_ColorNum"></param>
        ///// <param name="sqlTrans"></param>
        ///// <returns>����ID</returns>
        //public int FindStorge(string p_WHID, string p_SectionID, string p_SBitID, int p_CompanyTypeID, string p_ItemCode, string p_Batch, string p_VendorBatch, string p_JarNum, string p_ColorNum, string p_ColorName, string p_Needle, string p_YarnStatus, string p_DtsSO, int p_WHTypeID, string p_SizeName, IDBTransAccess sqlTrans)
        //{

        //    string sql="SELECT WHCalMethodID FROM WH_WH WHERE WHID="+SysString.ToDBString(p_WHID);
        //    int CalType = (int)EnumWHCalMethod.�����;//
        //    DataTable dt = sqlTrans.Fill(sql);//��õ�ǰ�ֿ�Ľ��㷽ʽ
        //    if (dt.Rows.Count != 0)
        //    {
        //        CalType = SysConvert.ToInt32(dt.Rows[0][0].ToString());
        //    }
        //    else
        //    {
        //        CalType = (int)EnumWHCalMethod.����ſͻ����ű�������;
        //    }
        //    sql="SELECT ID FROM WH_Storge WHERE WHID="+SysString.ToDBString(p_WHID)+" AND SectionID="+SysString.ToDBString(p_SectionID);
        //    sql+=" AND SBitID="+SysString.ToDBString(p_SBitID);
        //    switch (CalType)
        //    {
        //        case (int)EnumWHCalMethod.�����:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            break;
        //        case (int)EnumWHCalMethod.����ſͻ�����:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            break;
        //        case (int)EnumWHCalMethod.����ű�������:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            break;
        //        case (int)EnumWHCalMethod.����ſͻ����ű�������:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            break;
        //        case (int)EnumWHCalMethod.�����ɫ��:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            break;
        //        case (int)EnumWHCalMethod.����Ÿ׺�:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            break;
        //        case (int)EnumWHCalMethod.�����ɫ�Ÿ׺�:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            break;
        //        case (int)EnumWHCalMethod.����ſͻ����ű�������ɫ�Ÿ׺�:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            break;
        //        case (int)EnumWHCalMethod.���������:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Needle=" + SysString.ToDBString(p_Needle);
        //            break;
        //        case (int)EnumWHCalMethod.�����ɫ�Ÿ׺�ɴ����̬:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.����ſͻ����ű�������ɴ����̬:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);                  
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.����ſͻ����ű�������ɫ�Ÿ׺�ɴ����̬:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.����ſͻ����ű������Ŷ�����ɴ����̬:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND DtsSO=" + SysString.ToDBString(p_DtsSO);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.�����ɫ�Ÿ׺Ŷ�����ɴ����̬:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND DtsSO=" + SysString.ToDBString(p_DtsSO);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.����ſͻ����ű�������ɫ�Ÿ׺Ŷ�����ɴ����̬:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND DtsSO=" + SysString.ToDBString(p_DtsSO);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.�����ɫ��ɫ���׺Ŷ�����ɴ����̬:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND DtsSO=" + SysString.ToDBString(p_DtsSO);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.����ſͻ����ű�������ɫ��ɫ���׺Ŷ�����ɴ����̬:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
        //            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND DtsSO=" + SysString.ToDBString(p_DtsSO);
        //            sql += " AND YarnStatus=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.�����ɫ��ɫ���׺�ɴ����̬:
        //            sql += " AND ISNULL(ItemCode,'')=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND ISNULL(DesignNO,'')=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND ISNULL(ColorName,'')=" + SysString.ToDBString(p_ColorName);
        //            sql += " AND ISNULL(JarNum,'')=" + SysString.ToDBString(p_JarNum);
        //            sql += " AND ISNULL(YarnStatus,'')=" + SysString.ToDBString(p_YarnStatus);
        //            break;
        //        case (int)EnumWHCalMethod.�����ɫ��ɫ���׺�:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
        //            break;
        //        case (int)EnumWHCalMethod.���������ɫ��ɫ��:
        //            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
        //            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //            //sql += " AND DesignNO=" + SysString.ToDBString(p_DesignNO);
        //            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
        //            sql += " AND Needle=" + SysString.ToDBString(p_Needle);
        //            break;


        //    }
        //    DataTable dtlog = sqlTrans.Fill(sql);
        //    if (dtlog.Rows.Count > 0)
        //    {
        //        return SysConvert.ToInt32(dtlog.Rows[0][0].ToString());
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        #endregion

        #region Ⱦɫ���ҿ��
        public int[] FindStorges(string p_WHID, string p_SectionID, string p_SBitID, int p_CompanyTypeID, string p_ItemCode, string p_Batch, string p_VendorBatch, string p_JarNum, string p_ColorNum, string p_ColorName, string p_Needle, string p_YarnStatus, string p_DtsSO, int p_WHTypeID, string p_SizeName, string p_SSN, string p_DSN, string p_Unit)
        {
            int[] iFindStorges = new int[0];
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    //return FindStorges(p_WHID, p_SectionID, p_SBitID, p_CompanyTypeID, p_ItemCode, p_Batch, p_VendorBatch, p_JarNum, p_ColorNum, p_ColorName, p_Needle, p_YarnStatus, p_DtsSO, p_WHTypeID, p_SizeName, p_SSN, p_DSN, sqlTrans);
                    iFindStorges = FindStorges(p_WHID, p_SectionID, p_SBitID, p_CompanyTypeID, p_ItemCode, p_Batch, p_VendorBatch, p_JarNum, p_ColorNum, p_ColorName, p_Needle, p_YarnStatus, p_DtsSO, p_WHTypeID, p_SizeName, p_SSN, p_DSN, p_Unit, sqlTrans);

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
            return iFindStorges;
        }
        /// <summary>
        /// �жϿ����Ƿ���ڸü�¼
        /// </summary>
        /// <param name="p_WHID"></param>
        /// <param name="p_SectionID"></param>
        /// <param name="p_SBitID"></param>
        /// <param name="p_ItemCode"></param>
        /// <param name="p_Batch"></param>
        /// <param name="p_JarNum"></param>
        /// <param name="p_ColorNum"></param>
        /// <param name="sqlTrans"></param>
        /// <returns>����ID</returns>
        public int[] FindStorges(string p_WHID, string p_SectionID, string p_SBitID, int p_CompanyTypeID, string p_ItemCode, string p_Batch, string p_VendorBatch, string p_JarNum, string p_ColorNum, string p_ColorName, string p_Needle, string p_YarnStatus, string p_DtsSO, int p_WHTypeID, string p_SizeName, string p_SSN, string p_DSN, string p_Unit, IDBTransAccess sqlTrans)
        {
            string conditionstr = string.Empty;
            string sql = "SELECT WHCalMethodName,FieldName FROM UV1_Enum_WHType WHERE ID=" + SysString.ToDBString(p_WHTypeID);//��òֿ���������ֶ�
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                conditionstr = SysConvert.ToString(dt.Rows[0]["FieldName"]);
            }


            int WHJKFlag = 0;
            string sqlWH = "Select ISJK FROM WH_WH WHERE WHID=" + SysString.ToDBString(SysConvert.ToString(p_WHID));
            DataTable dtWH = sqlTrans.Fill(sqlWH);
            if (dtWH.Rows.Count != 0)
            {
                WHJKFlag = SysConvert.ToInt32(dtWH.Rows[0]["ISJK"]);
            }

            if (WHJKFlag == 1)//�Ŀ�---Ⱦ����Ĭ�ϵ��Ǹ������ϡ���˾��ϵ�кš������
            {
                conditionstr = "ItemCode+CompanyTypeID";
            }


            sql = "SELECT ID FROM WH_Storge WHERE 1=1";//���ҿ��ID
            int CalFieldName = (int)WHCalMethodFieldName.ItemCode;
            if (conditionstr != string.Empty)
            {
                string[] FieldName = conditionstr.Split('+');
                for (int i = 0; i < FieldName.Length; i++)
                {
                    string sqlFieldName = "SELECT ID FROM Enum_WHCalMethodFieldName WHERE Name=" + SysString.ToDBString(FieldName[i]);//�ҵ��������ֶζ�Ӧ��ID
                    DataTable dtFieldName = sqlTrans.Fill(sqlFieldName);
                    if (dtFieldName.Rows.Count != 0 && dtFieldName.Rows[0]["ID"].ToString() != "")
                    {
                        CalFieldName = SysConvert.ToInt32(dtFieldName.Rows[0]["ID"]);
                    }


                    sql += " AND WHID=" + SysString.ToDBString(p_WHID);
                    //sql += " AND SectionID=" + SysString.ToDBString(p_SectionID);----2010.3.9ע�͵�
                    //sql += " AND SBitID=" + SysString.ToDBString(p_SBitID);

                    switch (CalFieldName)
                    {
                        case (int)WHCalMethodFieldName.ItemCode://����
                            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
                            break;
                        case (int)WHCalMethodFieldName.WHID://��
                            sql += " AND WHID=" + SysString.ToDBString(p_WHID);
                            break;
                        case (int)WHCalMethodFieldName.SectionID://��
                            sql += " AND SectionID=" + SysString.ToDBString(p_SectionID);
                            break;
                        case (int)WHCalMethodFieldName.SBitID://λ
                            sql += " AND SBitID=" + SysString.ToDBString(p_SBitID);
                            break;

                        case (int)WHCalMethodFieldName.Batch://��������
                            sql += " AND Batch=" + SysString.ToDBString(p_Batch);
                            break;

                        case (int)WHCalMethodFieldName.JarNum://�׺�
                            sql += " AND JarNum=" + SysString.ToDBString(p_JarNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorNum://ɫ��
                            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
                            break;
                        case (int)WHCalMethodFieldName.ColorName://ɫ��
                            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
                            break;

                        case (int)WHCalMethodFieldName.Unit:   //����
                            sql += " AND Unit=" + SysString.ToDBString(p_Unit);
                            break;

                        case (int)WHCalMethodFieldName.WHTypeID://�ֿ�����
                            sql += " AND WHTypeID=" + SysString.ToDBString(p_WHTypeID);
                            break;
                        case (int)WHCalMethodFieldName.SizeName://����
                            sql += " AND SizeName=" + SysString.ToDBString(p_SizeName);
                            break;

                        case (int)WHCalMethodFieldName.VendorBatch:  //�ͻ�����
                            sql += " AND VendorBatch=" + SysString.ToDBString(p_VendorBatch);
                            break;

                    }
                }
            }
            int[] outinta = new int[0];
            DataTable dtlog = sqlTrans.Fill(sql);
            if (dtlog.Rows.Count > 0)
            {
                outinta = new int[dtlog.Rows.Count];
                for (int i = 0; i < dtlog.Rows.Count; i++)
                {
                    outinta[i] = SysConvert.ToInt32(dtlog.Rows[i]["ID"]);
                }
            }

            return outinta;
        }
        #endregion

        #region �ƿ����
        /// <summary>
        /// �ƿ����
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        /// <param name="p_Type">0/1:����/���</param>
        public void RSubmitMove(int p_FormTopType, IOForm p_Entity, IOFormDts p_EntityDts, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                Storge entitystdtsSource = new Storge(sqlTrans);//Դ���
                Storge entitystdts = new Storge(sqlTrans);//Ŀ�Ŀ��

                //int StorgeIDS = FindStorge(p_EntityDts.WHID, p_EntityDts.SectionID, p_EntityDts.SBitID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, sqlTrans);//Դ���
                //int StorgeIDT = FindStorge(p_EntityDts.FromWHID, p_EntityDts.FromSectionID, p_EntityDts.FromSBitID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, sqlTrans);//Ŀ�Ŀ��


                int StorgeIDS = FindStorge(p_EntityDts, (int)EnumWHMove.�ƶ���, sqlTrans); //FindStorge(p_EntityDts.WHID, p_EntityDts.SectionID, p_EntityDts.SBitID, p_EntityDts.CompanyTypeID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, p_EntityDts.WHTypeID, p_EntityDts.SizeName, sqlTrans);
                int StorgeIDT = FindStorge(p_EntityDts, (int)EnumWHMove.Ŀ�Ŀ�, sqlTrans);  //FindStorge(p_EntityDts.FromWHID, p_EntityDts.FromSectionID, p_EntityDts.FromSBitID, p_EntityDts.CompanyTypeID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, p_EntityDts.WHTypeID, p_EntityDts.SizeName, sqlTrans);



                bool p_NegativeFlag = false;//������־
                bool p_ZeroExitFlag = false;//Ϊ0��־

                bool p_NegativeFlagT = false;//������־
                bool p_ZeroExitFlagT = false;//Ϊ0��־

                WH entityWH = new WH(sqlTrans);
                entityWH.WHID = p_EntityDts.WHID;
                entityWH.SelectByID();

                entityWH.WHID = p_EntityDts.FromWHID;
                entityWH.SelectByID();




                if (StorgeIDT != 0)//Ŀ�Ŀ��
                {
                    entitystdts.ID = StorgeIDT;
                    entitystdts.SelectByID();
                }


                if (StorgeIDS != 0)//Դ���
                {
                    entitystdtsSource.ID = StorgeIDS;
                    entitystdtsSource.SelectByID();
                }
                else
                {

                    entitystdtsSource.DutyOPID = entitystdts.DutyOPID;
                    entitystdtsSource.WHID = p_EntityDts.WHID;
                    entitystdtsSource.SectionID = p_EntityDts.SectionID;
                    entitystdtsSource.SBitID = p_EntityDts.SBitID;
                    entitystdtsSource.VendorID = p_EntityDts.DtsVendorID;
                    entitystdtsSource.ItemCode = p_EntityDts.ItemCode;
                    // entitystdtsSource.ItemModel = p_EntityDts.ItemModel;
                    entitystdtsSource.ItemName = p_EntityDts.ItemName;
                    entitystdtsSource.ItemStd = p_EntityDts.ItemStd;
                    entitystdtsSource.Batch = p_EntityDts.Batch;
                    entitystdtsSource.VendorBatch = p_EntityDts.VendorBatch;
                    entitystdtsSource.Unit = p_EntityDts.Unit;
                    entitystdtsSource.SinglePrice = p_EntityDts.SinglePrice;
                    entitystdtsSource.ColorNum = p_EntityDts.ColorNum;
                    entitystdtsSource.ColorName = p_EntityDts.ColorName;
                    entitystdtsSource.JarNum = p_EntityDts.JarNum;
                    entitystdtsSource.TubeGW = p_EntityDts.TubeGW;
                    entitystdtsSource.Remark = p_EntityDts.Remark;
                    entitystdtsSource.VColorNum = p_EntityDts.VColorNum;
                    entitystdtsSource.VColorName = p_EntityDts.VColorName;
                    entitystdtsSource.VItemCode = p_EntityDts.VItemCode;
                    entitystdtsSource.GoodsCode = p_EntityDts.GoodsCode;
                    entitystdtsSource.GoodsLevel = p_EntityDts.GoodsLevel;
                    entitystdtsSource.MWidth = p_EntityDts.MWidth;
                    entitystdtsSource.MWeight = p_EntityDts.MWeight;
                    entitystdtsSource.WeightUnit = p_EntityDts.WeightUnit;
                    entitystdtsSource.MLType = p_EntityDts.MLType;   //�������ֳ�Ʒ���Ϻ�����

                    entitystdtsSource.VendorID = p_EntityDts.DtsVendorID;//
                    entitystdtsSource.SO = p_EntityDts.DtsSO;//���ݺ�
                    entitystdtsSource.DutyOPID = p_EntityDts.DtsSaleOPID;//ҵ��Ա
                    entitystdtsSource.OrderFormNo = p_EntityDts.DtsOrderFormNo;//��ͬ��

                }



                if (StorgeIDT == 0)//Ŀ�Ŀ��,�Ҳ�����ʷ��¼
                {

                    entitystdts.DutyOPID = entitystdtsSource.DutyOPID;
                    entitystdts.WHID = p_EntityDts.ToWHID;
                    entitystdts.SectionID = p_EntityDts.ToSectionID;
                    entitystdts.SBitID = p_EntityDts.ToSBitID;
                    entitystdts.VendorID = p_EntityDts.DtsVendorID;
                    entitystdts.ItemCode = p_EntityDts.ItemCode;
                    entitystdts.ItemName = p_EntityDts.ItemName;
                    entitystdts.ItemStd = p_EntityDts.ItemStd;
                    entitystdts.Batch = p_EntityDts.Batch;
                    entitystdts.VendorBatch = p_EntityDts.VendorBatch;
                    entitystdts.Twist = p_EntityDts.Twist;
                    entitystdts.Unit = p_EntityDts.Unit;
                    entitystdts.SinglePrice = p_EntityDts.SinglePrice;
                    entitystdts.ColorNum = p_EntityDts.ColorNum;
                    entitystdts.ColorName = p_EntityDts.ColorName;
                    entitystdts.JarNum = p_EntityDts.JarNum;

                    entitystdts.TubeGW = p_EntityDts.TubeGW;
                    entitystdts.Remark = p_EntityDts.Remark;
                    entitystdts.VColorNum = p_EntityDts.VColorNum;
                    entitystdts.VColorName = p_EntityDts.VColorName;
                    entitystdts.VItemCode = p_EntityDts.VItemCode;
                    entitystdts.GoodsCode = p_EntityDts.GoodsCode;
                    entitystdts.GoodsLevel = p_EntityDts.GoodsLevel;
                    entitystdts.MWidth = p_EntityDts.MWidth;
                    entitystdts.MWeight = p_EntityDts.MWeight;
                    entitystdts.WeightUnit = p_EntityDts.WeightUnit;

                    entitystdts.VendorID = p_EntityDts.DtsVendorID;//
                    entitystdts.SO = p_EntityDts.DtsSO;//���ݺ�
                    entitystdts.DutyOPID = p_EntityDts.DtsSaleOPID;//ҵ��Ա
                    entitystdts.OrderFormNo = p_EntityDts.DtsOrderFormNo;//��ͬ��

                    entitystdts.MLType = p_EntityDts.MLType;        //�������ֳ�Ʒ���Ϻ�����


                }
                //int AmountTypeID = 0;
                switch (p_FormTopType)
                {
                    case (int)WHFormList.�ƿ�://�ƿ�
                        if (p_Type == (int)ConfirmFlag.δ�ύ)//����
                        {
                            entitystdts.PieceQty -= p_EntityDts.PieceQty;//ʵ������

                            entitystdts.Qty -= p_EntityDts.Qty;//ʵ������
                            //entitystdts.FreeQty -= p_EntityDts.Qty;//��������
                            entitystdts.Weight -= p_EntityDts.Weight;//ʵ������

                            entitystdtsSource.PieceQty += p_EntityDts.PieceQty;//ʵ������

                            entitystdtsSource.Qty += p_EntityDts.Qty;//ʵ������
                            entitystdtsSource.Weight += p_EntityDts.Weight;//ʵ������
                            if (p_EntityDts.Unit == "RMB/KG")
                            {
                                entitystdts.Amount -= p_EntityDts.Weight * p_EntityDts.SinglePrice;
                                entitystdtsSource.Amount += p_EntityDts.Weight * p_EntityDts.SinglePrice;
                            }
                            if (p_EntityDts.Unit == "RMB/M")
                            {
                                entitystdts.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;
                                entitystdtsSource.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;
                            }
                        }
                        else
                        {
                            entitystdts.PieceQty += p_EntityDts.PieceQty;//ʵ������	
                            entitystdts.Qty += p_EntityDts.Qty;//ʵ������	
                            entitystdts.Weight += p_EntityDts.Weight;//ʵ������								

                            entitystdtsSource.PieceQty -= p_EntityDts.PieceQty;//ʵ������
                            entitystdtsSource.Qty -= p_EntityDts.Qty;//ʵ������
                            entitystdtsSource.Weight -= p_EntityDts.Weight;//ʵ������

                            if (p_EntityDts.Unit == "RMB/KG")
                            {
                                entitystdtsSource.Amount -= p_EntityDts.Weight * p_EntityDts.SinglePrice;
                                entitystdts.Amount += p_EntityDts.Weight * p_EntityDts.SinglePrice;
                            }
                            if (p_EntityDts.Unit == "RMB/M")
                            {
                                entitystdtsSource.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;
                                entitystdts.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;
                            }
                        }
                        break;
                }
                if (!p_NegativeFlag)//�������������У��
                {
                    if (entitystdtsSource.Qty < -0.001m || entitystdtsSource.Weight < -0.001m)
                    {
                        throw new Exception("����������������0�����ܲ�������Ʒ���룺" + entitystdts.ItemCode + " ɫ�ţ�" + entitystdts.ColorNum + " ������" + entitystdtsSource.Qty.ToString() + " Ŀ��������" + entitystdts.Qty.ToString() + " ��������" + entitystdtsSource.Weight.ToString() + " Ŀ�Ĺ�������" + entitystdts.Weight.ToString());
                    }
                }
                if (!p_NegativeFlagT)//�������������У��
                {
                    if (entitystdts.Qty < -0.001m || entitystdtsSource.Weight < -0.001m)
                    {
                        throw new Exception("����������������0�����ܲ�������Ʒ���룺" + entitystdts.ItemCode + " ɫ�ţ�" + entitystdts.ColorNum + " ������" + entitystdtsSource.Qty.ToString() + " Ŀ��������" + entitystdts.Qty.ToString() + " ��������" + entitystdtsSource.Weight.ToString() + " Ŀ�Ĺ�������" + entitystdts.Weight.ToString());
                    }
                }


                this.RSaveEntity(entitystdtsSource, p_ZeroExitFlag, sqlTrans);
                this.RSaveEntity(entitystdts, p_ZeroExitFlagT, sqlTrans);
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

        #region �̵����
        /// <summary>
        /// �̵����
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        /// <param name="p_Type">0/1:����/���</param>
        public void RSubmitCheck(int p_FormTopType, IOForm p_Entity, IOFormDts p_EntityDts, int p_Type, IDBTransAccess sqlTrans)
        {
            try
            {
                Storge entitystdts = new Storge(sqlTrans);

                //int StorgeID = 0;
                bool p_NegativeFlag = false;//������־
                bool p_ZeroExitFlag = false;//Ϊ0��־

                //WH entityWH = new WH(sqlTrans);
                //entityWH.WHID = p_EntityDts.WHID;
                //entityWH.SelectByID();
                WH entityWH = new WH(sqlTrans);
                string sqlWH = "Select ID FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_EntityDts.WHID);
                DataTable dtWH = sqlTrans.Fill(sqlWH);
                if (dtWH.Rows.Count != 0)
                {
                    entityWH.ID = SysConvert.ToInt32(dtWH.Rows[0]["ID"]);
                    entityWH.SelectByID();
                }
                //if (entityWH.NegativeFlag == (int)YesOrNo.Yes)
                //{
                //    p_NegativeFlag = true;
                //}
                //if (entityWH.ZeroExitFlag == (int)YesOrNo.Yes)
                //{
                //    p_ZeroExitFlag = true;
                //}

                //int StorgeIDT = FindStorge(p_EntityDts.WHID, p_EntityDts.SectionID, p_EntityDts.SBitID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, sqlTrans);

                int StorgeIDT = FindStorge(p_EntityDts, sqlTrans); //FindStorge(p_EntityDts.WHID, p_EntityDts.SectionID, p_EntityDts.SBitID, p_EntityDts.CompanyTypeID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, p_EntityDts.WHTypeID, p_EntityDts.SizeName, sqlTrans);



                if (StorgeIDT != 0)//�ҵ���ʷ��¼
                {
                    entitystdts.ID = StorgeIDT;
                    entitystdts.SelectByID();
                }
                else//�Ҳ�����ʷ��¼
                {
                    //entitystdts.InDate = p_Entity.FormDate;
                    entitystdts.WHID = p_Entity.WHID;
                    entitystdts.SectionID = p_EntityDts.SectionID;
                    entitystdts.SBitID = p_EntityDts.SBitID;
                    entitystdts.ItemCode = p_EntityDts.ItemCode;
                    entitystdts.ItemName = p_EntityDts.ItemName;
                    entitystdts.ItemStd = p_EntityDts.ItemStd;
                    //entitystdts.ItemModel = p_EntityDts.ItemModel;
                    entitystdts.Batch = p_EntityDts.Batch;
                    entitystdts.VendorBatch = p_EntityDts.VendorBatch;
                    entitystdts.ColorNum = p_EntityDts.ColorNum;
                    entitystdts.ColorName = p_EntityDts.ColorName;
                    entitystdts.JarNo = p_EntityDts.JarNo;
                    entitystdts.JarNum = p_EntityDts.JarNum;
                    entitystdts.Twist = p_EntityDts.Twist;
                    entitystdts.Needle = p_EntityDts.Needle;
                    entitystdts.Unit = p_EntityDts.Unit;
                    entitystdts.SinglePrice = p_EntityDts.SinglePrice;
                    entitystdts.VendorID = p_EntityDts.DtsVendorID;
                    entitystdts.TubeGW = p_EntityDts.TubeGW;
                    entitystdts.Remark = p_EntityDts.Remark;
                    entitystdts.VColorNum = p_EntityDts.VColorNum;
                    entitystdts.VColorName = p_EntityDts.VColorName;
                    entitystdts.VItemCode = p_EntityDts.VItemCode;
                    entitystdts.GoodsCode = p_EntityDts.GoodsCode;
                    entitystdts.GoodsLevel = p_EntityDts.GoodsLevel;
                    entitystdts.MWidth = p_EntityDts.MWidth;
                    entitystdts.MWeight = p_EntityDts.MWeight;
                    entitystdts.WeightUnit = p_EntityDts.WeightUnit;

                    entitystdts.VendorID = p_EntityDts.DtsVendorID;//
                    entitystdts.SO = p_EntityDts.DtsSO;//���ݺ�
                    entitystdts.DutyOPID = p_EntityDts.DtsSaleOPID;//ҵ��Ա
                    entitystdts.OrderFormNo = p_EntityDts.DtsOrderFormNo;//��ͬ��

                    entitystdts.MLType = p_EntityDts.MLType;    //�������ֳ�Ʒ���Ϻ�����

                }

                switch (p_FormTopType)
                {
                    case (int)WHFormList.�̵�:
                        if (p_Type == (int)ConfirmFlag.δ�ύ)//����
                        {
                            entitystdts.Qty += (p_EntityDts.Qty - p_EntityDts.MoveQty);//ʵ������
                            entitystdts.Weight += (p_EntityDts.Weight - p_EntityDts.MoveWeight);//ʵ������
                            entitystdts.PieceQty += (p_EntityDts.PieceQty - p_EntityDts.MovePieceQty);//ʵ������
                            if (entitystdts.Unit == "RMB/KG")
                            {
                                entitystdts.Amount = entitystdts.Weight * entitystdts.SinglePrice;
                            }
                            if (entitystdts.Unit == "RMB/M")
                            {
                                entitystdts.Amount = entitystdts.Qty * entitystdts.SinglePrice;
                            }
                            //if (p_Entity.SubType == 801)
                            //{
                            //    entitystdts.PDFlag = 0;
                            //    entitystdts.PDDate = SysConvert.ToDateTime(DBNull.Value);
                            //}


                        }
                        else//���
                        {
                            entitystdts.Qty -= (p_EntityDts.Qty - p_EntityDts.MoveQty);//ʵ������
                            entitystdts.Weight -= (p_EntityDts.Weight - p_EntityDts.MoveWeight);//ʵ������
                            entitystdts.PieceQty -= (p_EntityDts.PieceQty - p_EntityDts.MovePieceQty);//ʵ������
                            if (entitystdts.Unit == "RMB/KG")
                            {
                                entitystdts.Amount = entitystdts.Weight * entitystdts.SinglePrice;
                            }
                            if (entitystdts.Unit == "RMB/M")
                            {
                                entitystdts.Amount = entitystdts.Qty * entitystdts.SinglePrice;
                            }
                        }
                        break;
                }

                this.RSaveEntity(entitystdts, p_ZeroExitFlag, sqlTrans);
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

        #region ���¿������
        /// <summary>
        /// ���¿��
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void UpdateStorge(int p_StorgeID, float P_LockQty, bool p_Flag)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.UpdateStorge(p_StorgeID, P_LockQty, p_Flag, sqlTrans);

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
        /// ���¿��
        /// </summary>
        /// <param name="p_Storge">���ID</param>
        /// <param name="P_LockQty">��������</param>
        public void UpdateStorge(int p_StorgeID, float P_LockQty, bool p_Flag, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            if (p_Flag)
            {
                sql = "UPDATE WH_Storge SET LOCKQTY=ISNULL(LOCKQTY,0)+" + P_LockQty + ", FREEQTY=ISNULL(FREEQTY,0)-" + P_LockQty + " WHERE ID=" + SysString.ToDBString(p_StorgeID);
            }
            else
            {
                sql = "UPDATE WH_Storge SET LOCKQTY=ISNULL(LOCKQTY,0)-" + P_LockQty + ", FREEQTY=ISNULL(FREEQTY,0)+" + P_LockQty + " WHERE ID=" + SysString.ToDBString(p_StorgeID);
            }
            sqlTrans.ExecuteNonQuery(sql);
        }
        #endregion

        #region ���±�ע����
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="p_ID">ID��</param>
        /// <param name="p_Field">�ֶ���</param>
        /// <param name="p_value">ֵ</param>
        public void RUpdateSBitRemark(int p_ID, string p_Field, string p_value)
        {
            try
            {
                string sql = "UPDATE  WH_STORGE SET " + p_Field + "=" + SysString.ToDBString(p_value) + " WHERE ID=" + SysString.ToDBString(p_ID);
                SysUtils.ExecuteNonQuery(sql);
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }
        #endregion

        #region У���Ƿ���ڳ����������̵���
        /// <summary>
        ///  У���Ƿ���ڳ�������
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="state">״̬��0���ڳ���1�ڳ�</param>
        /// <returns></returns>
        public bool CheckIOForm(Storge entity, int state)
        {
            string sql = "SELECT * FROM UV1_WH_IOFormDts WHERE 1=1";

            sql += " AND isnull(ColorNum,'')=" + SysString.ToDBString(entity.ColorNum);
            sql += " AND isnull(ColorName,'')=" + SysString.ToDBString(entity.ColorName);
            sql += " AND isnull(Batch,'')=" + SysString.ToDBString(entity.Batch);
            sql += " AND isnull(VendorBatch,'')=" + SysString.ToDBString(entity.VendorBatch);
            sql += " AND isnull(JarNum,'')=" + SysString.ToDBString(entity.JarNum);
            //sql += " AND isnull(SizeName,'')=" + SysString.ToDBString(entity.SizeName);
            sql += " AND isnull(ItemCode,'')=" + SysString.ToDBString(entity.ItemCode);
            //sql += " AND isnull(YarnStatus,'')=" + SysString.ToDBString(entity.YarnStatus);
            sql += " AND isnull(WHID,'')=" + SysString.ToDBString(entity.WHID);
            if (state == 0)
            {
                sql += " AND HeadType<>'9'";

                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                sql += " AND HeadType='9'";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }

        }
        /// <summary>
        /// �̵�ɾ�����
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteIOForm(Storge entity)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    string sql = "Delete From WH_STORGE  WHERE ID=" + SysString.ToDBString(entity.ID);
                    sqlTrans.ExecuteNonQuery(sql);

                    sql = "Delete From  WH_IOFormDts WHERE 1=1";

                    sql += " AND isnull(ColorNum,'')=" + SysString.ToDBString(entity.ColorNum);
                    sql += " AND isnull(ColorName,'')=" + SysString.ToDBString(entity.ColorName);
                    sql += " AND isnull(Batch,'')=" + SysString.ToDBString(entity.Batch);
                    sql += " AND isnull(VendorBatch,'')=" + SysString.ToDBString(entity.VendorBatch);
                    sql += " AND isnull(JarNum,'')=" + SysString.ToDBString(entity.JarNum);
                    //sql += " AND isnull(SizeName,'')=" + SysString.ToDBString(entity.SizeName);
                    sql += " AND isnull(ItemCode,'')=" + SysString.ToDBString(entity.ItemCode);
                    //sql += " AND isnull(YarnStatus,'')=" + SysString.ToDBString(entity.YarnStatus);
                    sql += " AND isnull(WHID,'')=" + SysString.ToDBString(entity.WHID);

                    sqlTrans.ExecuteNonQuery(sql);


                    sql = "Delete From  WH_IOFormLedger WHERE 1=1";

                    sql += " AND isnull(ColorNum,'')=" + SysString.ToDBString(entity.ColorNum);
                    sql += " AND isnull(ColorName,'')=" + SysString.ToDBString(entity.ColorName);
                    sql += " AND isnull(Batch,'')=" + SysString.ToDBString(entity.Batch);
                    sql += " AND isnull(VendorBatch,'')=" + SysString.ToDBString(entity.VendorBatch);
                    sql += " AND isnull(JarNum,'')=" + SysString.ToDBString(entity.JarNum);
                    //sql += " AND isnull(SizeName,'')=" + SysString.ToDBString(entity.SizeName);
                    sql += " AND isnull(ItemCode,'')=" + SysString.ToDBString(entity.ItemCode);
                    //sql += " AND isnull(YarnStatus,'')=" + SysString.ToDBString(entity.YarnStatus);
                    sql += " AND isnull(WHID,'')=" + SysString.ToDBString(entity.WHID);

                    sqlTrans.ExecuteNonQuery(sql);

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

        #region ɾ�����0������--û�н��׼�¼��

        /// <summary>
        ///  У���Ƿ���ڳ�������
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="state">״̬��0���ڳ���1�ڳ�</param>
        /// <returns></returns>
        public bool CheckIOForm(Storge entity)
        {
            string sql = "SELECT * FROM UV1_WH_IOFormDts WHERE 1=1";

            sql += " AND isnull(ColorNum,'')=" + SysString.ToDBString(entity.ColorNum);
            sql += " AND isnull(ColorName,'')=" + SysString.ToDBString(entity.ColorName);
            sql += " AND isnull(Batch,'')=" + SysString.ToDBString(entity.Batch);
            sql += " AND isnull(VendorBatch,'')=" + SysString.ToDBString(entity.VendorBatch);
            sql += " AND isnull(JarNum,'')=" + SysString.ToDBString(entity.JarNum);
            //sql += " AND isnull(SizeName,'')=" + SysString.ToDBString(entity.SizeName);
            sql += " AND isnull(ItemCode,'')=" + SysString.ToDBString(entity.ItemCode);
            //sql += " AND isnull(YarnStatus,'')=" + SysString.ToDBString(entity.YarnStatus);
            //sql += " AND isnull(WHID,'')=" + SysString.ToDBString(entity.WHID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// ɾ�����0������--û�н��׼�¼��
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteZeroIOForm(Storge entity)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();
                    string sql = "Delete From WH_STORGE  WHERE ID =" + entity.ID;
                    sqlTrans.ExecuteNonQuery(sql);

                    sql = "Delete From  WH_IOFormLedger WHERE 1=1";

                    sql += " AND isnull(ColorNum,'')=" + SysString.ToDBString(entity.ColorNum);
                    sql += " AND isnull(ColorName,'')=" + SysString.ToDBString(entity.ColorName);
                    sql += " AND isnull(Batch,'')=" + SysString.ToDBString(entity.Batch);
                    sql += " AND isnull(VendorBatch,'')=" + SysString.ToDBString(entity.VendorBatch);
                    sql += " AND isnull(JarNum,'')=" + SysString.ToDBString(entity.JarNum);
                    //sql += " AND isnull(SizeName,'')=" + SysString.ToDBString(entity.SizeName);
                    sql += " AND isnull(ItemCode,'')=" + SysString.ToDBString(entity.ItemCode);
                    //sql += " AND isnull(YarnStatus,'')=" + SysString.ToDBString(entity.YarnStatus);
                    sql += " AND isnull(WHID,'')=" + SysString.ToDBString(entity.WHID);

                    sqlTrans.ExecuteNonQuery(sql);

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

        #region ����ʵ����  zhoufc20111221--MLTERP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void RDealColorInQty(int p_ID, IOForm p_Entity, IOFormDts p_EntityDts, IOFormDts p_NewEntityDts, IDBTransAccess sqlTrans)
        {
            try
            {
                //Storge entityst = new Storge(sqlTrans);//��������
                //int StorgeID = 0;
                //bool p_NegativeFlag = false;//������־
                //bool p_ZeroExitFlag = false;//Ϊ0��־
                //int p_ISJK = 0;//�Ŀ��־

                //WH entityWH = new WH(sqlTrans);
                //string sqlWH = "Select ID,ISJK FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_EntityDts.WHID);
                //DataTable dtWH = sqlTrans.Fill(sqlWH);
                //if (dtWH.Rows.Count != 0)
                //{
                //    entityWH.ID = SysConvert.ToInt32(dtWH.Rows[0]["ID"]);
                //    entityWH.SelectByID();

                //    p_ISJK = SysConvert.ToInt32(dtWH.Rows[0]["ISJK"]);//�Ŀ�
                //}
                ////if (entityWH.NegativeFlag == (int)YesOrNo.Yes)
                ////{
                ////    p_NegativeFlag = true;
                ////}
                ////if (entityWH.ZeroExitFlag == (int)YesOrNo.Yes)
                ////{
                ////    p_ZeroExitFlag = true;
                ////}


                //StorgeID = FindStorge(p_EntityDts.WHID, p_EntityDts.SectionID, p_EntityDts.SBitID, p_EntityDts.CompanyTypeID, p_EntityDts.ItemCode, p_EntityDts.Batch, p_EntityDts.VendorBatch, p_EntityDts.JarNum, p_EntityDts.ColorNum, p_EntityDts.ColorName, p_EntityDts.Needle, p_EntityDts.YarnStatus, p_EntityDts.DtsSO, p_EntityDts.WHTypeID, p_EntityDts.SizeName, sqlTrans);
                //if (StorgeID != 0)//�ҵ���ʷ��¼
                //{
                //    entityst.ID = StorgeID;
                //    entityst.SelectByID();

                //}
                //else//�Ҳ�����ʷ��¼
                //{

                //    entityst.DutyOPID = p_Entity.DutyOP;
                //    entityst.WHID = p_Entity.WHID;
                //    entityst.SectionID = p_EntityDts.SectionID;
                //    entityst.SBitID = p_EntityDts.SBitID;
                //    entityst.VendorID = p_EntityDts.DtsVendorID;


                //    entityst.ItemCode = p_EntityDts.ItemCode;
                //    entityst.ItemName = p_EntityDts.ItemName;
                //    entityst.ItemStd = p_EntityDts.ItemStd;
                //    if (p_ISJK == 0)//�ǼĿ⡢Ҳ���Ƿ�Ⱦ�����
                //    {


                //        entityst.Batch = p_EntityDts.Batch;
                //        entityst.VendorBatch = p_EntityDts.VendorBatch;
                //        entityst.ColorNum = p_EntityDts.ColorNum;
                //        entityst.ColorName = p_EntityDts.ColorName;
                //        entityst.JarNo = p_EntityDts.JarNo;
                //        entityst.JarNum = p_EntityDts.JarNum;
                //        entityst.Twist = p_EntityDts.Twist;
                //        entityst.Needle = p_EntityDts.Needle;

                //    }



                //    entityst.Unit = p_EntityDts.Unit;
                //    entityst.SinglePrice = p_EntityDts.SinglePrice;

                //    entityst.TubeGW = p_EntityDts.TubeGW;
                //    entityst.Remark = p_EntityDts.Remark;

                //}


                //entityst.Qty += p_NewEntityDts.Qty;
                //entityst.FreeQty += p_NewEntityDts.Qty;
                //entityst.Amount += p_NewEntityDts.Qty * p_NewEntityDts.SinglePrice;//������


                //entityst.Qty -= p_EntityDts.Qty;
                //entityst.FreeQty -= p_EntityDts.Qty;
                //entityst.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;//������



                //if (!p_NegativeFlag)//�������������У��
                //{
                //    if (entityst.Qty < -0.001m)//�����������0
                //    {
                //        throw new Exception("����������������0�����ܲ��������룺" + entityst.ItemCode + " �׺ţ�" + entityst.JarNum + " ������" + entityst.Qty.ToString());
                //    }

                //    if (entityst.FreeQty < -0.001m)//����ʹ����������0
                //    {
                //        throw new Exception("���������ʹ����������0�����ܲ��������룺" + entityst.ItemCode + " �׺ţ�" + entityst.JarNum + " ������" + entityst.FreeQty.ToString());
                //    }
                //}
                //this.RSaveEntity(entityst, p_ZeroExitFlag, sqlTrans);

                ////this.RSaveEntity(entityst, p_ZeroExitFlag, sqlTrans);

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
