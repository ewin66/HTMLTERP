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
    /// 目的：Enum_FormNoControl实体业务规则类
    /// 作者:陈加海
    /// 创建日期:2006-2-21
    /// </summary>
    public class FormNoControlRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FormNoControlRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            FormNoControl entity = (FormNoControl)p_BE;
        }


        bool THAddOneFlag = false;//2010/12月处理系统调号异常 标志是否已经自动跳过一次了

        #region 获得序号

        /// <summary>
        /// 获得单据号码(通过单号关系表)
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
        /// 获得单据号码(通过单号关系表)
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
        ///  获得单据号码(通过单号关系表)
        /// </summary>
        /// <param name="p_ClsA"></param>
        /// <param name="p_ClsB"></param>
        /// <param name="p_DepID">部门</param>
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
        ///  获得单据号码(通过单号关系表)
        /// </summary>
        /// <param name="p_ClsA"></param>
        /// <param name="p_ClsB"></param>
        /// <param name="p_DepID">部门</param>
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
        /// 获得单据号码并增加序号
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
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
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
        /// <param name="sqlTrans">事务</param>
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
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
        /// <param name="p_Num">第几个单据号码0,1,2,</param>
        /// <param name="sqlTrans">事务</param>
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
                if (entity.CurYear != 0 && entity.CurYear != dtserver.Year)//判断年
                {
                    entity.CurYear = dtserver.Year;
                    UpdFlag = true;
                }
                if (entity.CurMonth != 0 && entity.CurMonth != dtserver.Month)//判断月
                {
                    entity.CurMonth = dtserver.Month;
                    UpdFlag = true;
                }
                if (entity.CurDay != 0 && entity.CurDay != dtserver.Day)//判断日
                {
                    entity.CurDay = dtserver.Day;
                    UpdFlag = true;
                }
                if (UpdFlag)//需要更新
                {
                    entity.CurSort = 0;
                    this.RUpdate(entity, sqlTrans);
                }
                outstr = entity.FormRulePre;

                if (entity.CurYear != 0)//替换年
                {
                    outstr = outstr.Replace("YYYY", entity.CurYear.ToString());//如果是4位 陈加海2010/3/26日修改
                    outstr = outstr.Replace("YY", entity.CurYear.ToString().Substring(2));
                }
                if (entity.CurMonth != 0)//替换月
                {
                    outstr = outstr.Replace("MM", SysString.IntToStr(entity.CurMonth, 2));
                }
                if (entity.CurDay != 0)//替换日
                {
                    outstr = outstr.Replace("DD", SysString.IntToStr(entity.CurDay, 2));
                }

                if (entity.FormRuleSpecial != "")//替换特殊符号
                {
                    outstr = outstr.Replace("X", entity.FormRuleSpecial);
                }
                outstr += SysString.IntToStr(entity.CurSort + 1 + p_Num, entity.FormRuleSort.Length);//获得序号

                if (!THAddOneFlag)//没有调号过，防止死循环
                {
                    try//跳号验证是否存在处理，存在则加1
                    {
                        sql = "SELECT DTableName,DFieldName FROM Enum_FormNoControl WHERE ID=" + p_FormNoID;
                        DataTable dtL = sqlTrans.Fill(sql);
                        if (dtL.Rows.Count != 0)
                        {
                            if (dtL.Rows[0]["DTableName"].ToString() != string.Empty && dtL.Rows[0]["DFieldName"].ToString() != string.Empty)
                            {
                                sql = "SELECT " + dtL.Rows[0]["DFieldName"].ToString() + " FROM " + dtL.Rows[0]["DTableName"].ToString() + " WHERE " + dtL.Rows[0]["DFieldName"].ToString() + "=" + SysString.ToDBString(outstr);
                                if (sqlTrans.Fill(sql).Rows.Count != 0)//产生的号码系统中已存在，则序号跳号
                                {
                                    THAddOneFlag = true;
                                    this.RAddSort(p_FormNoID, sqlTrans);
                                    outstr = RGetFormNo(p_FormNoID, p_Num, sqlTrans);//循环调用一次

                                }
                            }
                        }
                    }
                    catch (Exception EL)//异常情况下填写临时信息
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

        #region 获得某类单据每个客户独立的流水号
        /// <summary>
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
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
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
        /// <param name="p_Num">第几个单据号码0,1,2,</param>
        /// <param name="sqlTrans">事务</param>
        public string RGetFormNoVendor(int p_FormNoID, int p_FNCVID, string p_VendorID, IDBTransAccess sqlTrans)
        {
            try
            {
                string outstr = "";
                FormNoControl entity = new FormNoControl(sqlTrans);
                entity.ID = p_FormNoID;
                entity.SelectByID();
                if (entity.NoType == 2)//使用具体业务表进行处理
                {
                    FormNCVendorRule nvRule = new FormNCVendorRule();

                    outstr = nvRule.RGetFormNo(entity,p_FNCVID, p_VendorID, sqlTrans);
                    //Data_FormNCVendor
                }
                else
                {
                    outstr = "单号异常,设置类型错误";
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

        #region 单据号码处理
        public string RGetWHFormNo(int p_FormListAID, int p_FormListBID, string p_WHID)
        {
            try
            {
                if (p_FormListBID != 0)//仓库单据子类不为零
                {
                    string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListBID);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        if (SysConvert.ToInt32(dt.Rows[0][0].ToString()) != 0)//仓库子单据编号配置了则使用子类编号
                        {
                            return RGetWHFormNo(p_FormListBID, p_WHID);
                        }
                    }
                }
                return RGetWHFormNo(p_FormListAID, p_WHID);//否则用主单据编号
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
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
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
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
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

        #region 新
        public string RGetWHFormNo(int p_FormListAID, int p_FormListBID, string p_WHID, IDBTransAccess sqlTrans)
        {
            try
            {
                if (p_FormListBID != 0)//仓库单据子类不为零
                {
                    string sql = "SELECT FormNoControlID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListBID);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        if (SysConvert.ToInt32(dt.Rows[0][0].ToString()) != 0)//仓库子单据编号配置了则使用子类编号
                        {
                            return RGetWHFormNo(p_FormListBID, p_WHID, sqlTrans);
                        }
                    }
                }
                return RGetWHFormNo(p_FormListAID, p_WHID, sqlTrans);//否则用主单据编号
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
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
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
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
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
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
        /// <param name="p_Num">第几个单据号码0,1,2,</param>
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
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
        /// <param name="p_Num">第几个单据号码0,1,2,</param>
        /// <param name="sqlTrans">事务</param>
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
                if (entity.CurYear != 0 && entity.CurYear != dtserver.Year)//判断年
                {
                    entity.CurYear = dtserver.Year;
                    UpdFlag = true;
                }
                if (entity.CurMonth != 0 && entity.CurMonth != dtserver.Month)//判断月
                {
                    entity.CurMonth = dtserver.Month;
                    UpdFlag = true;
                }
                if (entity.CurDay != 0 && entity.CurDay != dtserver.Day)//判断日
                {
                    entity.CurDay = dtserver.Day;
                    UpdFlag = true;
                }
                if (UpdFlag)//需要更新
                {
                    entity.CurSort = 0;
                    this.RUpdate(entity, sqlTrans);
                }
                outstr = entity.FormRulePre;

                if (entity.CurYear != 0)//替换年
                {
                    outstr = outstr.Replace("YY", entity.CurYear.ToString().Substring(2));
                }
                if (entity.CurMonth != 0)//替换月
                {
                    outstr = outstr.Replace("MM", SysString.IntToStr(entity.CurMonth, 2));
                }
                if (entity.CurDay != 0)//替换日
                {
                    outstr = outstr.Replace("DD", SysString.IntToStr(entity.CurDay, 2));
                }

                if (entity.FormRuleSpecial != "")//替换特殊符号
                {
                    outstr = outstr.Replace("X", entity.FormRuleSpecial);
                }
                outstr += SysString.IntToStr(entity.CurSort + 1 + p_Num, entity.FormRuleSort.Length);//获得序号


                if (!THAddOneFlag)//没有调号过，防止死循环
                {
                    try//跳号验证是否存在处理，存在则加1
                    {
                        sql = "SELECT DTableName,DFieldName FROM Enum_FormNoControl WHERE ID=" + p_FormNoID;
                        DataTable dtL = sqlTrans.Fill(sql);
                        if (dtL.Rows.Count != 0)
                        {
                            if (dtL.Rows[0]["DTableName"].ToString() != string.Empty && dtL.Rows[0]["DFieldName"].ToString() != string.Empty)
                            {
                                sql = "SELECT " + dtL.Rows[0]["DFieldName"].ToString() + " FROM " + dtL.Rows[0]["DTableName"].ToString() + " WHERE " + dtL.Rows[0]["DFieldName"].ToString() + "=" + SysString.ToDBString(outstr);
                                if (sqlTrans.Fill(sql).Rows.Count != 0)//产生的号码系统中已存在，则序号跳号
                                {
                                    THAddOneFlag = true;
                                    this.RAddSort(p_FormNoID, sqlTrans);
                                    outstr = RGetFormNo(p_FormNoID, p_Num,p_WHID, sqlTrans);//循环调用一次

                                }
                            }
                        }
                    }
                    catch (Exception EL)//异常情况下填写临时信息
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
        /// 获得单据号码(通过单号关系表)
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
        /// 单据序号加一
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
        /// <param name="sqlTrans">事务</param>
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
        /// 单据序号加N(有些批号可能一次产生多个)
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
        /// <param name="p_Num">第几个单据号码0,1,2,</param>
        /// <param name="sqlTrans">事务</param>
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




        #region 获得
        /// <summary>
        /// 获得单据号码(通过单号关系表)
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




        #region 获得编号
        /// <summary>
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
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
        /// 获得单据号码
        /// </summary>
        /// <param name="p_FormNoID">单据ID</param>
        /// <param name="p_Num">第几个单据号码0,1,2,</param>
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


        #region 自动生成代码
        /// <summary>
        /// 显示数据
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
        /// 显示数据
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
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
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
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
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
                //    throw new Exception("该编码已经存在，请重新输入！");
                //}
                sql = "SELECT ID FROM Enum_FormNoControl WHERE ID=" + SysString.ToDBString(entity.ID);

                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    throw new Exception("ID已经存在，请重新输入！");
                }
                sql = "SELECT FormNM FROM Enum_FormNoControl WHERE FormNM=" + SysString.ToDBString(entity.FormNM);

                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    throw new Exception("名称已经存在，请重新输入！");
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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        /// <param name="sqlTrans">事务类</param>
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
                //    throw new Exception("该编码已经存在，请重新输入！");
                //}
                sql = "SELECT FormNM FROM Enum_FormNoControl WHERE FormNM=" + SysString.ToDBString(entity.FormNM);

                sql += " AND ID<>" + SysString.ToDBString(entity.ID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    throw new Exception("名称已经存在，请重新输入！");
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
        /// 删除
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
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
        /// 删除
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
        /// <param name="sqlTrans">事务类</param>
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
