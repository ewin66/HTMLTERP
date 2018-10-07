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
    /// Ŀ�ģ�WO_BProductCheckDtsʵ��ҵ�������
    /// ����:��С��
    /// ��������:2013/3/21
    /// </summary>
    public class BProductCheckDtsRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public BProductCheckDtsRule()
        {
        }

        /// <summary>
        /// ��齫Ҫ�����������Ƿ����ҵ�����
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            BProductCheckDts entity = (BProductCheckDts)p_BE;
        }

        ///// <summary>
        ///// �����ֶ�ֵ�Ƿ��Ѵ���
        ///// </summary>
        ///// <param name="p_TableName">����</param>
        ///// <param name="p_FieldName">�ֶ���</param>
        ///// <param name="p_FieldValue">�ֶ�ֵ</param>
        ///// <param name="p_KeyField">������ֻ��������ΪID�������</param>
        ///// <param name="p_KeyValue">����ֵ</param>
        ///// <param name="p_sqlTrans"></param>
        ///// <returns></returns>
        //private bool CheckFieldValueIsExist(BaseEntity p_BE, string p_FieldName, string p_FieldValue, IDBTransAccess p_sqlTrans)
        //{
        //    BProductCheckDts entity = (BProductCheckDts)p_BE;
        //    bool ret = false;
        //    string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, BProductCheckDts.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
        //    DataTable dt = p_sqlTrans.Fill(sql);
        //    if (dt.Rows.Count != 0)
        //    {
        //        ret = true;
        //    }

        //    return ret;
        //}
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
                string sql = "SELECT " + p_FieldName + " FROM WO_BProductCheckDts WHERE 1=1";
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

                BProductCheckDts entity = (BProductCheckDts)p_BE;


                if (entity.ID == 0)
                {
                    BProductCheckDtsCtl control = new BProductCheckDtsCtl(sqlTrans);
                    entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WO_BProductCheckDts, sqlTrans);
                    if (entity.Seq == 0)
                    {
                        entity.StatusID = (int)EnumBoxStatus.δ���;
                        entity.DISN = GetDISN(sqlTrans);
                        entity.Seq = GetMaxSeq(entity.MainID, entity.JarNum, sqlTrans);

                        
                    }

                    //CalcQty(entity);
                    control.AddNew(entity);
                }
                else
                {
                    if (entity.StatusID != (int)EnumBoxStatus.δ���)//�Ѿ��������벻���޸�
                    {
                        throw new Exception("���벻�ǳ�ʼ״̬�����޸�");
                    }

                    RUpdate(entity, sqlTrans);
                }

                ///RCalcMZJZ(entity, sqlTrans);
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
        public void RAdd2(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                BProductCheckDts entity = (BProductCheckDts)p_BE;
                BProductCheckDtsCtl control = new BProductCheckDtsCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WO_BProductCheckDts, sqlTrans);
                control.AddNew(entity);
                RCalcMZJZ(entity, sqlTrans);
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
        /// �õ������
        /// </summary>
        /// <param name="sqlTrans"></param>
        /// <returns></returns>
        string GetDISN(IDBTransAccess sqlTrans)
        {
            string Str = string.Empty;
            string sql = "SELECT MAX(DISN) DISN FROM WO_BProductCheckDts WHERE DISN LIKE " + SysString.ToDBString(DateTime.Now.ToString("yyyyMMdd") + "____");
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["DISN"].ToString() == string.Empty)
                {
                    return DateTime.Now.ToString("yyyyMMdd") + "0001";
                }
                else
                {
                    Str = dt.Rows[0]["DISN"].ToString();
                    Str = Str.Substring(8, 4);
                    return DateTime.Now.ToString("yyyyMMdd") + SysString.LongToStr(SysConvert.ToInt32(Str) + 1, 4);
                }
            }
            else
            {
                return DateTime.Now.ToString("yyyyMMdd") + "0001";
            }
            return Str;
        }

        public int GetMaxSeq(int p_ID, string JarNum, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT MAX(Seq) Seq FROM WO_BProductCheckDts WHERE JarNum=" + SysString.ToDBString(JarNum);
            sql += " AND MainID=" + p_ID;
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                return SysConvert.ToInt32(dt.Rows[0]["Seq"]) + 1;
            }
            else
            {
                return 1;
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
                BProductCheckDts entity = (BProductCheckDts)p_BE;
                BProductCheckDtsCtl control = new BProductCheckDtsCtl(sqlTrans);
                //CalcQty(entity);
                control.Update(entity);

                //RCalcMZJZ(entity, sqlTrans);
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


        private void CalcQty(BProductCheckDts entity)
        {
            //==entity.KF25=1 ��ƥ�����������룬entity.KF20 = 1������ƥ��������
            if (entity.KF25 != 1 && entity.KF20 != 1)//���ǿ�ƥ�Ĳż���
            {
                entity.KF = entity.RCKF + entity.ZCKF;//�ϼƿ۷�=֯�õ�+Ⱦ�õ�
                entity.Qty = entity.SM - entity.CJRC - entity.CJZC - entity.FMZC - entity.FMRC - entity.CY - entity.MQty3;
                entity.MQty4 = entity.SM - entity.CJRC - entity.CJZC - entity.FMZC - entity.FMRC - entity.CY - entity.MQty3;
                if (entity.Qty != 0m)
                {
                    entity.BMKF = entity.KF / entity.Qty;
                }

                if (entity.MQty4 != 0m)
                {
                    entity.FMQty = SysConvert.ToDecimal(entity.MQty4 * 1.0936132983377m);
                }
                else
                {
                    entity.FMQty = SysConvert.ToDecimal(entity.Qty * 1.0936132983377m);
                }
                if (!SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6428)))//�ֿ����ѡ��ͻ�ֱ�Ӵ����ÿͻ���ص���
                {
                    entity.Qty = GetChangeQty(entity.Qty);
                    entity.FMQty = GetChangeQty(entity.FMQty);
                }
              


            }
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="p_BE">Ҫ�޸ĵ�ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RUpdate2(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                this.CheckCorrect(p_BE);
                BProductCheckDts entity = (BProductCheckDts)p_BE;
                BProductCheckDtsCtl control = new BProductCheckDtsCtl(sqlTrans);
                control.Update(entity);

                RCalcMZJZ(entity, sqlTrans);
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
        /// �ı������㷨
        /// </summary>
        /// <param name="Qty"></param>
        /// <returns></returns>
        private decimal GetChangeQty(decimal Qty)
        {
            decimal MQty = Qty;


            if (Qty.ToString().IndexOf('.') >= 0)
            {
                string strBase = Qty.ToString().Substring(0, Qty.ToString().IndexOf('.'));
                string str = Qty.ToString().Substring(Qty.ToString().IndexOf('.') + 1, Qty.ToString().Length - Qty.ToString().IndexOf('.') - 1);
                decimal X = SysConvert.ToDecimal("0." + str);
                if (X < 0.3m)
                {
                    MQty = SysConvert.ToDecimal(strBase);
                }
                else if (X >= 0.3m && X < 0.7m)
                {
                    MQty = SysConvert.ToDecimal(strBase + ".5");
                }
                else
                {
                    MQty = SysConvert.ToDecimal(strBase) + 1m;
                }

            }

            return MQty;
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
                BProductCheckDts entity = (BProductCheckDts)p_BE;
                BProductCheckDtsCtl control = new BProductCheckDtsCtl(sqlTrans);
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


        #region

        /// <summary>
        /// �޸�����״̬
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void ModifyLog(BProductCheckDts p_BE, BProductCheckDtsModifyLog p_BE2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.ModifyLog(p_BE, p_BE2, sqlTrans);

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
        public void ModifyLog(BProductCheckDts p_BE, BProductCheckDtsModifyLog p_BE2, IDBTransAccess sqlTrans)
        {
            try
            {


                if (p_BE.StatusID != (int)EnumBoxStatus.δ���)
                {
                    throw new Exception("�����Ѿ���������룬�����޸�");
                }

                if (p_BE.KF24 == 1)
                {
                    throw new Exception("��ƥ���Ѿ��޸Ĺ�һ���ˣ������ڴ��޸�");
                }

                #region ���ݵ�������
                BProductCheckDts entityold = new BProductCheckDts(sqlTrans);
                entityold.ID = p_BE.ID;
                entityold.SelectByID();//���Ƶ�������
                #endregion


                #region �����ϵ�����Ϊ�µ����룬ֻ������ţ����޸ĵ����ݣ�������Ϣ����
                if (p_BE2.CompactNo != string.Empty)
                {
                    p_BE2.OldCompactNo = p_BE.CompactNo;

                    p_BE.CompactNo = p_BE2.CompactNo;

                    string sqlcheck = "SELECT ID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(p_BE2.CompactNo) + " AND SubmitFlag=1";
                    DataTable dtcheck = sqlTrans.Fill(sqlcheck);
                    if (dtcheck.Rows.Count != 1)
                    {
                        throw new Exception("����ĺ�ͬ�Ų����ڣ�����");
                    }

                }
                if (p_BE2.JarNum != string.Empty)
                {
                    p_BE2.OldJarNum = p_BE.JarNum;


                    p_BE.JarNum = p_BE2.JarNum;


                }

                if (p_BE2.Seq != 0)
                {
                    p_BE2.OldSeq = p_BE.Seq;

                    p_BE.Seq = p_BE2.Seq;
                }



                p_BE.KF24 = 0;
                p_BE.KF22 = 1;//�˻�������������µ�����
                p_BE.DISN = GetDISN(sqlTrans);
                p_BE.StatusID = (int)EnumBoxStatus.δ���;
                RUpdate2(p_BE, sqlTrans);

                #endregion


                #region �����ϵ����룬��־Ϊ�����޸ģ�������Log��־
                p_BE2.ModifyID = p_BE.ID;
                entityold.StatusID = (int)EnumBoxStatus.δ���;
                entityold.KF24 = 1;//�޸ĺ��²�������

                entityold.ID = 0;
                RAdd2(entityold, sqlTrans);
                p_BE2.NewISNID = entityold.ID;//�²��������ID
                BProductCheckDtsModifyLogRule rule = new BProductCheckDtsModifyLogRule();
                rule.RAdd(p_BE2, sqlTrans);
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
        #endregion


        /// <summary>
        /// ����ë�ؾ���
        /// </summary>
        /// <param name="p_BE">Ҫɾ����ʵ��</param>
        public void RCalcMZJZ(BaseEntity p_BE, IDBTransAccess sqlTrans)
        {
            try
            {
                //BProductCheckDts entity = p_BE as BProductCheckDts;
                //string sql = "SELECT CWith,CWeight,FMQty,Qty,JSUnit FROM UV1_WO_BProductCheckDts WHERE DISN="+SysString.ToDBString(entity.DISN);
                //DataTable dt = sqlTrans.Fill(sql);
                //if (dt.Rows.Count != 0)
                //{
                //    //if (dt.Rows[0]["JSUnit"].ToString() == "Y")
                //    //{
                //    //    entity.MQty = SysConvert.ToDecimal(dt.Rows[0]["CWeight"]) * SysConvert.ToDecimal(dt.Rows[0]["FMQty"])/1000m;
                //    //}
                //    //else
                //    //{
                //        entity.MQty = SysConvert.ToDecimal(dt.Rows[0]["CWeight"]) * SysConvert.ToDecimal(dt.Rows[0]["Qty"])/1000m;
                //    //}
                //    entity.MWeight = entity.MQty + 0.3m;

                //    sql = "UPDATE WO_BProductCheckDts SET MQty=" + SysString.ToDBString(entity.MQty.ToString()) + ",MWeight=" + SysString.ToDBString(entity.MWeight.ToString()) + " WHERE DISN=" + SysString.ToDBString(entity.DISN);
                //    sqlTrans.Fill(sql);
                //}


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
