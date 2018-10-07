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
    /// Ŀ�ģ�Enum_FormNoControlʵ��ҵ�������
    /// ����:�¼Ӻ�
    /// ��������:2006-2-21
    /// </summary>
    public class FormNoControlRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public FormNoControlRule()
        {
        }

        /// <summary>
        /// ��齫Ҫ�����������Ƿ����ҵ�����
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            FormNoControl entity = (FormNoControl)p_BE;
        }


        bool THAddOneFlag = false;//2010/12�´���ϵͳ�����쳣 ��־�Ƿ��Ѿ��Զ�����һ����

        #region ������

        /// <summary>
        /// ��õ��ݺ���(ͨ�����Ź�ϵ��)
        /// </summary>
        /// <param name="p_ClsA"></param>
        /// <param name="p_ClsB"></param>
        /// <returns></returns>
        public string RGetFormNo(string p_ClsA, string p_ClsB)
        {
            try
            {
                return RGetFormNo(p_ClsA, p_ClsB, 0);
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
        /// ��õ��ݺ���(ͨ�����Ź�ϵ��)
        /// </summary>
        /// <param name="p_ClsA"></param>
        /// <param name="p_ClsB"></param>
        /// <returns></returns>
        public string RGetFormNo(string p_ClsA, string p_ClsB, IDBTransAccess sqlTrans)
        {
            try
            {
                return RGetFormNo(p_ClsA, p_ClsB, 0, sqlTrans);
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
        ///  ��õ��ݺ���(ͨ�����Ź�ϵ��)
        /// </summary>
        /// <param name="p_ClsA"></param>
        /// <param name="p_ClsB"></param>
        /// <param name="p_DepID">����</param>
        /// <returns></returns>
        public string RGetFormNo(string p_ClsA, string p_ClsB, int p_DepID, IDBTransAccess sqlTrans)
        {
            string outstr = string.Empty;
            string sql = "SELECT FormNoControlID FROM Data_FNORel WHERE CLSA=" + SysString.ToDBString(p_ClsA) + " AND CLSB=" + SysString.ToDBString(p_ClsB);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = this.RGetFormNo(SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"]), sqlTrans);
            }

            return outstr;
        }

        /// <summary>
        ///  ��õ��ݺ���(ͨ�����Ź�ϵ��)
        /// </summary>
        /// <param name="p_ClsA"></param>
        /// <param name="p_ClsB"></param>
        /// <param name="p_DepID">����</param>
        /// <returns></returns>
        public string RGetFormNo(string p_ClsA, string p_ClsB, int p_DepID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    string outstr = string.Empty;
                    sqlTrans.OpenTrans();

                    string sql = "SELECT FormNoControlID FROM Data_FNORel WHERE CLSA=" + SysString.ToDBString(p_ClsA) + " AND CLSB=" + SysString.ToDBString(p_ClsB);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        outstr = this.RGetFormNo(SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"]), sqlTrans);
                    }

                    sqlTrans.CommitTrans();

                    return outstr;
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
        /// ��õ��ݺ��벢�������
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        public string RGetFormNoAddSort(int p_FormNoID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    string outstr = this.RGetFormNo(p_FormNoID, 0, sqlTrans);
                    this.RAddSort(p_FormNoID, sqlTrans);

                    sqlTrans.CommitTrans();

                    return outstr;
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
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        /// <param name="sqlTrans">����</param>
        public string RGetFormNo(int p_FormNoID, IDBTransAccess sqlTrans)
        {
            try
            {
                return this.RGetFormNo(p_FormNoID, 0, sqlTrans);
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
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        /// <param name="p_Num">�ڼ������ݺ���0,1,2,</param>
        /// <param name="sqlTrans">����</param>
        public string RGetFormNo(int p_FormNoID, int p_Num, IDBTransAccess sqlTrans)
        {
            try
            {
                string outstr = "";
                FormNoControl entity = new FormNoControl(sqlTrans);
                entity.ID = p_FormNoID;
                entity.SelectByID();
                
                string sql = "SELECT getdate() AS ServerTime";
                DateTime dtserver = SysConvert.ToDateTime(sqlTrans.Fill(sql).Rows[0][0].ToString());

                bool UpdFlag = false;
                if (entity.CurYear != 0 && entity.CurYear != dtserver.Year)//�ж���
                {
                    entity.CurYear = dtserver.Year;
                    UpdFlag = true;
                }
                if (entity.CurMonth != 0 && entity.CurMonth != dtserver.Month)//�ж���
                {
                    entity.CurMonth = dtserver.Month;
                    UpdFlag = true;
                }
                if (entity.CurDay != 0 && entity.CurDay != dtserver.Day)//�ж���
                {
                    entity.CurDay = dtserver.Day;
                    UpdFlag = true;
                }
                if (UpdFlag)//��Ҫ����
                {
                    entity.CurSort = 0;
                    this.RUpdate(entity, sqlTrans);
                }
                outstr = entity.FormRulePre;

                if (entity.CurYear != 0)//�滻��
                {
                    outstr = outstr.Replace("YYYY", entity.CurYear.ToString());//�����4λ �¼Ӻ�2010/3/26���޸�
                    outstr = outstr.Replace("YY", entity.CurYear.ToString().Substring(2));
                }
                if (entity.CurMonth != 0)//�滻��
                {
                    outstr = outstr.Replace("MM", SysString.IntToStr(entity.CurMonth, 2));
                }
                if (entity.CurDay != 0)//�滻��
                {
                    outstr = outstr.Replace("DD", SysString.IntToStr(entity.CurDay, 2));
                }

                if (entity.FormRuleSpecial != "")//�滻�������
                {
                    outstr = outstr.Replace("X", entity.FormRuleSpecial);
                }
                outstr += SysString.IntToStr(entity.CurSort + 1 + p_Num, entity.FormRuleSort.Length);//������

                if (!THAddOneFlag)//û�е��Ź�����ֹ��ѭ��
                {
                    try//������֤�Ƿ���ڴ����������1
                    {
                        sql = "SELECT DTableName,DFieldName FROM Enum_FormNoControl WHERE ID=" + p_FormNoID;
                        DataTable dtL = sqlTrans.Fill(sql);
                        if (dtL.Rows.Count != 0)
                        {
                            if (dtL.Rows[0]["DTableName"].ToString() != string.Empty && dtL.Rows[0]["DFieldName"].ToString() != string.Empty)
                            {
                                sql = "SELECT " + dtL.Rows[0]["DFieldName"].ToString() + " FROM " + dtL.Rows[0]["DTableName"].ToString() + " WHERE " + dtL.Rows[0]["DFieldName"].ToString() + "=" + SysString.ToDBString(outstr);
                                if (sqlTrans.Fill(sql).Rows.Count != 0)//�����ĺ���ϵͳ���Ѵ��ڣ����������
                                {
                                    THAddOneFlag = true;
                                    this.RAddSort(p_FormNoID, sqlTrans);
                                    outstr = RGetFormNo(p_FormNoID, p_Num, sqlTrans);//ѭ������һ��

                                }
                            }
                        }
                    }
                    catch (Exception EL)//�쳣�������д��ʱ��Ϣ
                    {
                        SysFile.WriteFrameworkLog(EL.Message);
                    }
                }


                return outstr;
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

        #region ���ĳ�൥��ÿ���ͻ���������ˮ��
        /// <summary>
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        public string RGetFormNoVendor(int p_FormNoID,int p_FNCVID, string p_VendorID)
        {
            try
            {

                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    string outstr = this.RGetFormNoVendor(p_FormNoID, p_FNCVID, p_VendorID, sqlTrans);
                   
                    sqlTrans.CommitTrans();

                    return outstr;
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
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        /// <param name="p_Num">�ڼ������ݺ���0,1,2,</param>
        /// <param name="sqlTrans">����</param>
        public string RGetFormNoVendor(int p_FormNoID, int p_FNCVID, string p_VendorID, IDBTransAccess sqlTrans)
        {
            try
            {
                string outstr = "";
                FormNoControl entity = new FormNoControl(sqlTrans);
                entity.ID = p_FormNoID;
                entity.SelectByID();
                if (entity.NoType == 2)//ʹ�þ���ҵ�����д���
                {
                    FormNCVendorRule nvRule = new FormNCVendorRule();

                    outstr = nvRule.RGetFormNo(entity,p_FNCVID, p_VendorID, sqlTrans);
                    //Data_FormNCVendor
                }
                else
                {
                    outstr = "�����쳣,�������ʹ���";
                }
                return outstr;
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

        #region ���ݺ��봦��
        public string RGetWHFormNo(int p_FormListAID, int p_FormListBID, string p_WHID)
        {
            try
            {
                if (p_FormListBID != 0)//�ֿⵥ�����಻Ϊ��
                {
                    string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListBID);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        if (SysConvert.ToInt32(dt.Rows[0][0].ToString()) != 0)//�ֿ��ӵ��ݱ����������ʹ��������
                        {
                            return RGetWHFormNo(p_FormListBID, p_WHID);
                        }
                    }
                }
                return RGetWHFormNo(p_FormListAID, p_WHID);//�����������ݱ��
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
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        private string RGetWHFormNo(int p_FormListID, string p_WHID)
        {
            try
            {
                string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    return this.RGetFormNo(SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString()), 0, p_WHID);
                }
                return "";
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
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        public string RGetFormNo(int p_FormNoID, string p_WHID)
        {
            try
            {
                return this.RGetFormNo(p_FormNoID, 0, p_WHID);
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

        #region ��
        public string RGetWHFormNo(int p_FormListAID, int p_FormListBID, string p_WHID, IDBTransAccess sqlTrans)
        {
            try
            {
                if (p_FormListBID != 0)//�ֿⵥ�����಻Ϊ��
                {
                    string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListBID);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        if (SysConvert.ToInt32(dt.Rows[0][0].ToString()) != 0)//�ֿ��ӵ��ݱ����������ʹ��������
                        {
                            return RGetWHFormNo(p_FormListBID, p_WHID, sqlTrans);
                        }
                    }
                }
                return RGetWHFormNo(p_FormListAID, p_WHID, sqlTrans);//�����������ݱ��
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
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        private string RGetWHFormNo(int p_FormListID, string p_WHID, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    return this.RGetFormNo(SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"].ToString()), 0, p_WHID, sqlTrans);
                }
                return "";
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
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        public string RGetFormNo(int p_FormNoID, string p_WHID, IDBTransAccess sqlTrans)
        {
            try
            {
                return this.RGetFormNo(p_FormNoID, 0, p_WHID, sqlTrans);
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
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        /// <param name="p_Num">�ڼ������ݺ���0,1,2,</param>
        public string RGetFormNo(int p_FormNoID, int p_Num, string p_WHID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    string outstr = this.RGetFormNo(p_FormNoID, p_Num, p_WHID, sqlTrans);

                    sqlTrans.CommitTrans();

                    return outstr;
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
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        /// <param name="p_Num">�ڼ������ݺ���0,1,2,</param>
        /// <param name="sqlTrans">����</param>
        public string RGetFormNo(int p_FormNoID, int p_Num, string p_WHID, IDBTransAccess sqlTrans)
        {
            try
            {
                string outstr = "";
                FormNoControl entity = new FormNoControl(sqlTrans);
                entity.ID = p_FormNoID;
                entity.SelectByID();
                string sql = "SELECT getdate() AS ServerTime";
                DateTime dtserver = SysConvert.ToDateTime(sqlTrans.Fill(sql).Rows[0][0].ToString());

                bool UpdFlag = false;
                if (entity.CurYear != 0 && entity.CurYear != dtserver.Year)//�ж���
                {
                    entity.CurYear = dtserver.Year;
                    UpdFlag = true;
                }
                if (entity.CurMonth != 0 && entity.CurMonth != dtserver.Month)//�ж���
                {
                    entity.CurMonth = dtserver.Month;
                    UpdFlag = true;
                }
                if (entity.CurDay != 0 && entity.CurDay != dtserver.Day)//�ж���
                {
                    entity.CurDay = dtserver.Day;
                    UpdFlag = true;
                }
                if (UpdFlag)//��Ҫ����
                {
                    entity.CurSort = 0;
                    this.RUpdate(entity, sqlTrans);
                }
                outstr = entity.FormRulePre;

                if (entity.CurYear != 0)//�滻��
                {
                    outstr = outstr.Replace("YY", entity.CurYear.ToString().Substring(2));
                }
                if (entity.CurMonth != 0)//�滻��
                {
                    outstr = outstr.Replace("MM", SysString.IntToStr(entity.CurMonth, 2));
                }
                if (entity.CurDay != 0)//�滻��
                {
                    outstr = outstr.Replace("DD", SysString.IntToStr(entity.CurDay, 2));
                }

                if (entity.FormRuleSpecial != "")//�滻�������
                {
                    outstr = outstr.Replace("X", entity.FormRuleSpecial);
                }
                outstr += SysString.IntToStr(entity.CurSort + 1 + p_Num, entity.FormRuleSort.Length);//������


                if (!THAddOneFlag)//û�е��Ź�����ֹ��ѭ��
                {
                    try//������֤�Ƿ���ڴ����������1
                    {
                        sql = "SELECT DTableName,DFieldName FROM Enum_FormNoControl WHERE ID=" + p_FormNoID;
                        DataTable dtL = sqlTrans.Fill(sql);
                        if (dtL.Rows.Count != 0)
                        {
                            if (dtL.Rows[0]["DTableName"].ToString() != string.Empty && dtL.Rows[0]["DFieldName"].ToString() != string.Empty)
                            {
                                sql = "SELECT " + dtL.Rows[0]["DFieldName"].ToString() + " FROM " + dtL.Rows[0]["DTableName"].ToString() + " WHERE " + dtL.Rows[0]["DFieldName"].ToString() + "=" + SysString.ToDBString(outstr);
                                if (sqlTrans.Fill(sql).Rows.Count != 0)//�����ĺ���ϵͳ���Ѵ��ڣ����������
                                {
                                    THAddOneFlag = true;
                                    this.RAddSort(p_FormNoID, sqlTrans);
                                    outstr = RGetFormNo(p_FormNoID, p_Num,p_WHID, sqlTrans);//ѭ������һ��

                                }
                            }
                        }
                    }
                    catch (Exception EL)//�쳣�������д��ʱ��Ϣ
                    {
                        SysFile.WriteFrameworkLog(EL.Message);
                    }
                }
                return outstr;
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
        /// ��õ��ݺ���(ͨ�����Ź�ϵ��)
        /// </summary>
        /// <param name="p_ClsA"></param>
        /// <param name="p_ClsB"></param>
        /// <returns></returns>
        public void RAddSort(string p_ClsA, string p_ClsB, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT FormNoControlID FROM Data_FNORel WHERE CLSA=" + SysString.ToDBString(p_ClsA) + " AND CLSB=" + SysString.ToDBString(p_ClsB);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                this.RAddSort(SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"]), sqlTrans);
            }
        }


        /// <summary>
        /// ������ż�һ
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        /// <param name="sqlTrans">����</param>
        public void RAddSort(int p_FormNoID, IDBTransAccess sqlTrans)
        {
            try
            {
                this.RAddSort(p_FormNoID, 1, sqlTrans);
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
        /// ������ż�N(��Щ���ſ���һ�β������)
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        /// <param name="p_Num">�ڼ������ݺ���0,1,2,</param>
        /// <param name="sqlTrans">����</param>
        public void RAddSort(int p_FormNoID, int p_Num, IDBTransAccess sqlTrans)
        {
            try
            {
                FormNoControl entity = new FormNoControl(sqlTrans);
                entity.ID = p_FormNoID;
                entity.SelectByID();
                string sql = "UPDATE Enum_FormNoControl SET CurSort=" + (entity.CurSort + p_Num) + " WHERE ID=" + p_FormNoID;
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




        #region ���
        /// <summary>
        /// ��õ��ݺ���(ͨ�����Ź�ϵ��)
        /// </summary>
        /// <param name="p_ClsA"></param>
        /// <param name="p_ClsB"></param>
        /// <returns></returns>
        public int RGetFormNoControlID(string p_ClsA, string p_ClsB, IDBTransAccess sqlTrans)
        {
            try
            {
                try
                {
                    int outstr = 0;

                    string sql = "SELECT FormNoControlID FROM Data_FNORel WHERE CLSA=" + SysString.ToDBString(p_ClsA) + " AND CLSB=" + SysString.ToDBString(p_ClsB);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        outstr = SysConvert.ToInt32(dt.Rows[0]["FormNoControlID"]);
                    }

                    return outstr;
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




        #region ��ñ��
        /// <summary>
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        public string RGetFormNo(int p_FormNoID)
        {
            try
            {
                return this.RGetFormNo(p_FormNoID, 0);
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
        /// ��õ��ݺ���
        /// </summary>
        /// <param name="p_FormNoID">����ID</param>
        /// <param name="p_Num">�ڼ������ݺ���0,1,2,</param>
        public string RGetFormNo(int p_FormNoID, int p_Num)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    string outstr = this.RGetFormNo(p_FormNoID, p_Num, sqlTrans);

                    sqlTrans.CommitTrans();

                    return outstr;
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


        #region �Զ����ɴ���
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
                string sql = "SELECT " + p_FieldName + " FROM Enum_FormNoControl WHERE 1=1 ";
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
                FormNoControl entity = (FormNoControl)p_BE;
                FormNoControlCtl control = new FormNoControlCtl(sqlTrans);

                //entity.ID = (int)EntityIDTable.GetID((long)SysEntity.Enum_FormNoControl, sqlTrans);
                string sql = string.Empty;//"SELECT Code FROM Enum_FormNoControl WHERE Code=" + SysString.ToDBString(entity.Code);

                //DataTable dt = SysUtils.Fill(sql);
                //if (dt.Rows.Count != 0)
                //{
                //    throw new Exception("�ñ����Ѿ����ڣ����������룡");
                //}
                sql = "SELECT ID FROM Enum_FormNoControl WHERE ID=" + SysString.ToDBString(entity.ID);

                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    throw new Exception("ID�Ѿ����ڣ����������룡");
                }
                sql = "SELECT FormNM FROM Enum_FormNoControl WHERE FormNM=" + SysString.ToDBString(entity.FormNM);

                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    throw new Exception("�����Ѿ����ڣ����������룡");
                }
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
                FormNoControl entity = (FormNoControl)p_BE;
                FormNoControlCtl control = new FormNoControlCtl(sqlTrans);

                string sql = string.Empty;//"SELECT Code FROM Enum_FormNoControl WHERE Code=" + SysString.ToDBString(entity.Code);

                //sql += " AND ID<>" + SysString.ToDBString(entity.ID);
                //DataTable dt = SysUtils.Fill(sql);
                //if (dt.Rows.Count != 0)
                //{
                //    throw new Exception("�ñ����Ѿ����ڣ����������룡");
                //}
                sql = "SELECT FormNM FROM Enum_FormNoControl WHERE FormNM=" + SysString.ToDBString(entity.FormNM);

                sql += " AND ID<>" + SysString.ToDBString(entity.ID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    throw new Exception("�����Ѿ����ڣ����������룡");
                }


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
                FormNoControl entity = (FormNoControl)p_BE;
                FormNoControlCtl control = new FormNoControlCtl(sqlTrans);
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
    }
}
