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
    /// Ŀ�ģ�WO_BProductCheckDtsFaultʵ��ҵ�������
    /// ����:��С��
    /// ��������:2013/4/30
    /// </summary>
    public class BProductCheckDtsFaultRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public BProductCheckDtsFaultRule()
        {
        }

        /// <summary>
        /// ��齫Ҫ�����������Ƿ����ҵ�����
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            BProductCheckDtsFault entity = (BProductCheckDtsFault)p_BE;
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
        //    BProductCheckDtsFault entity = (BProductCheckDtsFault)p_BE;
        //    bool ret = false;
        //    string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 AND {0}={2} AND {3}<>{4}", p_FieldName, BProductCheckDtsFault.TableName, SysString.ToDBString(p_FieldValue), "ID", entity.ID);
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
                string sql = "SELECT " + p_FieldName + " FROM WO_BProductCheckDtsFault WHERE 1=1";
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
                BProductCheckDtsFault entity = (BProductCheckDtsFault)p_BE;
                BProductCheckDtsFaultCtl control = new BProductCheckDtsFaultCtl(sqlTrans);
                entity.ID = (int)EntityIDTable.GetID((long)SysEntity.WO_BProductCheckDtsFault, sqlTrans);
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
                BProductCheckDtsFault entity = (BProductCheckDtsFault)p_BE;
                BProductCheckDtsFaultCtl control = new BProductCheckDtsFaultCtl(sqlTrans);
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
                BProductCheckDtsFault entity = (BProductCheckDtsFault)p_BE;
                BProductCheckDtsFaultCtl control = new BProductCheckDtsFaultCtl(sqlTrans);
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
        /// <param name="p_BE">Ҫɾ����ʵ��</param>
        public void RDelete(int p_BE)
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
        public void RDelete(int p_BE, IDBTransAccess sqlTrans)
        {
            try
            {

                BProductCheckDtsFault entity = new BProductCheckDtsFault(sqlTrans);
                entity.ID = p_BE;
                entity.SelectByID();
                RDelete(entity, sqlTrans);
                BProductCheckDts en = new BProductCheckDts(sqlTrans);
                en.ID = entity.MainID;
                en.SelectByID();
                en.CY -= entity.CYQty;

                string sql = "";
                en.RCKF = 0m;
                en.CJRC = 0m;
                en.FMRC = 0m;
                en.ZCKF = 0m;
                en.CJZC = 0m;
                en.FMZC = 0m;
                en.MQty3 = 0m;
                #region ͳ�ƺϼ�����
                sql = "SELECT SUM(DQuantity) DQuantity,SUM(Deduction) Deduction,SUM(DYM) DYM,B.CDType FROM WO_BProductCheckDtsFault AS A,Data_CDGL AS B WHERE A.FaultDes=B.Code AND A.MainID=" + entity.MainID + " GROUP BY B.CDType";
                DataTable dt = sqlTrans.Fill(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["CDType"].ToString() == "Ⱦ��")
                    {
                        // DQuantity// ����
                        //Deduction�۷�
                        //DYM �ü�
                        en.RCKF = SysConvert.ToDecimal(dr["Deduction"]);
                        en.CJRC = SysConvert.ToDecimal(dr["DYM"]);
                        en.FMRC = SysConvert.ToDecimal(dr["DQuantity"]);
                    }
                    else if (dr["CDType"].ToString() == "֯��")
                    {
                        en.ZCKF = SysConvert.ToDecimal(dr["Deduction"]);
                        en.CJZC = SysConvert.ToDecimal(dr["DYM"]);
                        en.FMZC = SysConvert.ToDecimal(dr["DQuantity"]);
                    }
                    else
                    {
                        en.MQty3 = SysConvert.ToDecimal(dr["DQuantity"]);
                    }
                }

                BProductCheckDtsRule rulebp2 = new BProductCheckDtsRule();
                rulebp2.RUpdate(en, sqlTrans);
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
        public int RSaveFault(BProductCheckDtsFault p_BE, BProductCheckDts entity, int MainID, int PackDtsID)
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
        public int RSaveFault(BProductCheckDtsFault p_BE, BProductCheckDts entityMain, int MainID, int PackDtsID, IDBTransAccess sqlTrans)
        {
            try
            {
                if (PackDtsID == 0)
                {
                    throw new Exception("����ѡ�����ָʾ��");
                }
                BProductCheckDtsFault entity = p_BE as BProductCheckDtsFault;
                if (MainID == 0)
                {
                    entityMain.MainID = PackDtsID;

                    BProductCheckDtsRule rulebp = new BProductCheckDtsRule();
                    if (entity.DQuantity == 0m && entity.Deduction == 0m && entity.DYM == 0m && entity.CYQty == 0m)//ͳƥë��
                    {
                        entityMain.VColorName = entity.FaultDes;
                        entity.Position = "ͳƥ";
                    }

                    entityMain.CY += entity.CYQty;

                    rulebp.RAdd(entityMain, sqlTrans);

                    entity.MainID = entityMain.ID;
                }
                else
                {
                    BProductCheckDtsRule rulebp = new BProductCheckDtsRule();
                    if (entity.DQuantity == 0m && entity.Deduction == 0m && entity.DYM == 0m && entity.CYQty == 0m)//ͳƥë��
                    {
                        entityMain.VColorName = entity.FaultDes;
                        entity.Position = "ͳƥ";
                    }
                    entityMain.CY += entity.CYQty;

                    rulebp.RUpdate(entityMain, sqlTrans);
                }
                RAdd(entity, sqlTrans);
                string sql = "";

                #region ͳ�ƺϼ�����
                sql = "SELECT SUM(DQuantity) DQuantity,SUM(Deduction) Deduction,SUM(DYM) DYM,B.CDType,SUM(CYQty) CYQty FROM WO_BProductCheckDtsFault AS A,Data_CDGL AS B WHERE A.FaultDes=B.Code AND A.MainID=" + entityMain.ID + " GROUP BY B.CDType";
                DataTable dt = sqlTrans.Fill(sql);
                entityMain.RCKF = 0m;
                entityMain.CJRC = 0m;
                entityMain.FMRC = 0m;
                entityMain.ZCKF = 0m;
                entityMain.CJZC = 0m;
                entityMain.FMZC = 0m;
                entityMain.MQty3 = 0m;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["CDType"].ToString() == "Ⱦ��")
                    {
                        // DQuantity// ����
                        //Deduction�۷�
                        //DYM �ü�
                        entityMain.RCKF = SysConvert.ToDecimal(dr["Deduction"]);
                        entityMain.CJRC = SysConvert.ToDecimal(dr["DYM"]);
                        entityMain.FMRC = SysConvert.ToDecimal(dr["DQuantity"]);
                    }
                    else if (dr["CDType"].ToString() == "֯��")
                    {
                        entityMain.ZCKF = SysConvert.ToDecimal(dr["Deduction"]);
                        entityMain.CJZC = SysConvert.ToDecimal(dr["DYM"]);
                        entityMain.FMZC = SysConvert.ToDecimal(dr["DQuantity"]);
                    }
                    else
                    {
                        entityMain.MQty3 = SysConvert.ToDecimal(dr["DQuantity"]);
                    }
                }
                BProductCheckDtsRule rulebp2 = new BProductCheckDtsRule();
                rulebp2.RUpdate(entityMain, sqlTrans);
                #endregion

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
        public int RJYEnd(int p_BE, BProductCheckDts entity, int p_PackID, decimal Qty, decimal YMQty, int JarNo)
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
        public int RJYEnd(int p_BE, BProductCheckDts entity2, int p_PackID, decimal Qty, decimal YMQty, int JarNo, IDBTransAccess sqlTrans)
        {
            try
            {

                if (p_BE == 0)//�����0 ���ʾû�дõ�
                {
                    entity2.MainID = p_PackID;

                    BProductCheckDtsRule rulebp = new BProductCheckDtsRule();

                    rulebp.RAdd(entity2, sqlTrans);

                    p_BE = entity2.ID;
                }
                BProductCheckDts entity = new BProductCheckDts(sqlTrans);
                entity.ID = p_BE;

                entity.SelectByID();
                entity.MainID = p_PackID;
                entity.YM = YMQty;
                entity.SM = Qty;//�������
                entity.FMQty = entity2.FMQty;//��������
                entity.KZ = entity2.KZ;//����
                entity.MF = entity2.MF;//�ŷ�
                entity.WX = entity2.WX;//γб
                entity.PrintCD = entity2.PrintCD;//��ӡ�õ���Ŀ
                entity.ColorName = entity2.ColorName;//��ɫ
                entity.ColorNum = entity2.ColorNum;//ɫ��
                entity.GoodsLevel = entity2.GoodsLevel;//�ȼ�
                entity.Qty = entity2.SM - entity2.FMQty;//����=�������-��������

                string sqls = "Select ISNULL(Max(JarNo),0) From WO_BProductCheckDts where JarNum=" + SysString.ToDBString(SysConvert.ToString(entity.JarNum));
                sqls += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(entity.ItemCode));
                sqls += " AND ColorNum=" + SysString.ToDBString(SysConvert.ToString(entity.ColorNum));
                DataTable dts = sqlTrans.Fill(sqls);
                if ((SysConvert.ToInt32(dts.Rows[0][0]) + 1) != JarNo)
                {
                    entity.JarNo = SysConvert.ToInt32(dts.Rows[0][0]) + 1;//���
                }
                else
                {
                    entity.JarNo = JarNo;//���
                }

                entity.ShopID = entity2.ShopID;

                entity.YQty = SysConvert.ToDecimal(Qty * 1.0936132983377m, 2);//����ת����
                BProductCheckDtsRule rule = new BProductCheckDtsRule();
                rule.RUpdate(entity, sqlTrans);







                #region ͳ�ƺϼ�����
                entity.RCKF = 0m;
                entity.CJRC = 0m;
                entity.FMRC = 0m;
                entity.ZCKF = 0m;
                entity.CJZC = 0m;
                entity.FMZC = 0m;
                entity.MQty3 = 0m;
                string sql = "SELECT SUM(DQuantity) DQuantity,SUM(Deduction) Deduction,SUM(DYM) DYM,B.CDType FROM WO_BProductCheckDtsFault AS A,Data_CDGL AS B WHERE A.FaultDes=B.Code AND A.MainID=" + p_BE + " GROUP BY B.CDType";
                DataTable dt = sqlTrans.Fill(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["CDType"].ToString() == "Ⱦ��")
                    {

                        entity.RCKF = SysConvert.ToDecimal(dr["Deduction"]);
                        entity.CJRC = SysConvert.ToDecimal(dr["DYM"]);
                        entity.FMRC = SysConvert.ToDecimal(dr["DQuantity"]);
                    }
                    else if (dr["CDType"].ToString() == "֯��")
                    {
                        entity.ZCKF = SysConvert.ToDecimal(dr["Deduction"]);
                        entity.CJZC = SysConvert.ToDecimal(dr["DYM"]);
                        entity.FMZC = SysConvert.ToDecimal(dr["DQuantity"]);
                    }
                    else
                    {
                        //entity.MQty3 = SysConvert.ToDecimal(dr["DQuantity"]);
                        entity.ZCKF = SysConvert.ToDecimal(dr["Deduction"]);
                        entity.CJZC = SysConvert.ToDecimal(dr["DYM"]);
                        entity.FMZC = SysConvert.ToDecimal(dr["DQuantity"]);
                    }

                }

                entity.SJQty = SysConvert.ToDecimal(entity.SM - entity.CJZC - entity.CJRC - entity.FMQty, 1);//ʵ������=�������-�ü�����-��������
                BProductCheckDtsRule rulebp2 = new BProductCheckDtsRule();
                rulebp2.RUpdate(entity, sqlTrans);







                #endregion


                #region �ϼƼ����������ܵ������嵥

                sql = "Select SUM(Qty) Qty from WO_BProductCheckDts where MainID=" + p_PackID;
                DataTable dtS = sqlTrans.Fill(sql);
                if (dtS.Rows.Count != 0)
                {
                    sql = "Update WO_PackOrderDts Set CheckQty=" + SysConvert.ToDecimal(dtS.Rows[0]["Qty"]);
                    sql += " where ID=" + p_PackID;
                    sqlTrans.ExecuteNonQuery(sql);
                }
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
    }
}