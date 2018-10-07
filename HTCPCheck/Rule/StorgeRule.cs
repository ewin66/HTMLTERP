using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;


namespace HttSoft.HTCPCheck.DataCtl
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
                            entityst.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;//������
                           
                            break;
                        case (int)WHFormList.����:
                            entityst.Qty -= p_EntityDts.Qty;
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
                            entityst.Amount -= p_EntityDts.Qty * p_EntityDts.SinglePrice;//������
                            break;
                        case (int)WHFormList.����:
                            entityst.Qty += p_EntityDts.Qty;

                            entityst.PieceQty += p_EntityDts.PieceQty;
                            entityst.Weight += p_EntityDts.Weight;
                            entityst.Amount += p_EntityDts.Qty * p_EntityDts.SinglePrice;//������
                            break;
                        case (int)WHFormList.�ڳ����:
                            goto case (int)WHFormList.���;
                    }

                }

              
                if (entityst.Qty < -0.001m)//�����������0
                {
                    throw new Exception("����������������0�����ܲ��������룺" + entityst.ItemCode + " ɫ�ţ�" + entityst.ColorNum + " ��ɫ��" + entityst.ColorName + " ������" + entityst.Qty.ToString());
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
                        default:
                            throw new Exception("�����쳣�����㶨����ֶεײ�δ��Ӧ��"+CalFieldName);

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
        public int FindStorge(IOFormDts p_entity,int p_Type,IDBTransAccess sqlTrans)
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
                    if (entity.ID != 0 && (entity.Qty == 0))//���� && entity.PieceQty==0
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

       

    }
}
