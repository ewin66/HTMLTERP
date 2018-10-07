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
    /// 目的：WO_BProductCheckDtsFault实体业务规则类
    /// 作者:朱小涛
    /// 创建日期:2013/4/30
    /// </summary>
    public class BProductCheckDtsFaultRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BProductCheckDtsFaultRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            BProductCheckDtsFault entity = (BProductCheckDtsFault)p_BE;
        }

        ///// <summary>
        ///// 检验字段值是否已存在
        ///// </summary>
        ///// <param name="p_TableName">表名</param>
        ///// <param name="p_FieldName">字段名</param>
        ///// <param name="p_FieldValue">字段值</param>
        ///// <param name="p_KeyField">主键（只考虑主键为ID的情况）</param>
        ///// <param name="p_KeyValue">主键值</param>
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
        /// 删除
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
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
        /// 删除
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
        /// <param name="sqlTrans">事务类</param>
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
                #region 统计合计数据
                sql = "SELECT SUM(DQuantity) DQuantity,SUM(Deduction) Deduction,SUM(DYM) DYM,B.CDType FROM WO_BProductCheckDtsFault AS A,Data_CDGL AS B WHERE A.FaultDes=B.Code AND A.MainID=" + entity.MainID + " GROUP BY B.CDType";
                DataTable dt = sqlTrans.Fill(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["CDType"].ToString() == "染疵")
                    {
                        // DQuantity// 放码
                        //Deduction扣分
                        //DYM 裁剪
                        en.RCKF = SysConvert.ToDecimal(dr["Deduction"]);
                        en.CJRC = SysConvert.ToDecimal(dr["DYM"]);
                        en.FMRC = SysConvert.ToDecimal(dr["DQuantity"]);
                    }
                    else if (dr["CDType"].ToString() == "织疵")
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
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
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
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public int RSaveFault(BProductCheckDtsFault p_BE, BProductCheckDts entityMain, int MainID, int PackDtsID, IDBTransAccess sqlTrans)
        {
            try
            {
                if (PackDtsID == 0)
                {
                    throw new Exception("请先选择检验指示单");
                }
                BProductCheckDtsFault entity = p_BE as BProductCheckDtsFault;
                if (MainID == 0)
                {
                    entityMain.MainID = PackDtsID;

                    BProductCheckDtsRule rulebp = new BProductCheckDtsRule();
                    if (entity.DQuantity == 0m && entity.Deduction == 0m && entity.DYM == 0m && entity.CYQty == 0m)//统匹毛病
                    {
                        entityMain.VColorName = entity.FaultDes;
                        entity.Position = "统匹";
                    }

                    entityMain.CY += entity.CYQty;

                    rulebp.RAdd(entityMain, sqlTrans);

                    entity.MainID = entityMain.ID;
                }
                else
                {
                    BProductCheckDtsRule rulebp = new BProductCheckDtsRule();
                    if (entity.DQuantity == 0m && entity.Deduction == 0m && entity.DYM == 0m && entity.CYQty == 0m)//统匹毛病
                    {
                        entityMain.VColorName = entity.FaultDes;
                        entity.Position = "统匹";
                    }
                    entityMain.CY += entity.CYQty;

                    rulebp.RUpdate(entityMain, sqlTrans);
                }
                RAdd(entity, sqlTrans);
                string sql = "";

                #region 统计合计数据
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
                    if (dr["CDType"].ToString() == "染疵")
                    {
                        // DQuantity// 放码
                        //Deduction扣分
                        //DYM 裁剪
                        entityMain.RCKF = SysConvert.ToDecimal(dr["Deduction"]);
                        entityMain.CJRC = SysConvert.ToDecimal(dr["DYM"]);
                        entityMain.FMRC = SysConvert.ToDecimal(dr["DQuantity"]);
                    }
                    else if (dr["CDType"].ToString() == "织疵")
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
       /// 检验结束
       /// </summary>
       /// <param name="p_BE"></param>
       /// <param name="entity"></param>
       /// <param name="p_PackID"></param>
       /// <param name="Qty">码表数量</param>
       /// <param name="YMQty">原码数量，暂不使用</param>
       /// <param name="JarNo">缸号</param>
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
        /// 检验结束
        /// </summary>
        /// <param name="p_BE">要删除的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public int RJYEnd(int p_BE, BProductCheckDts entity2, int p_PackID, decimal Qty, decimal YMQty, int JarNo, IDBTransAccess sqlTrans)
        {
            try
            {

                if (p_BE == 0)//如果是0 则表示没有疵点
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
                entity.SM = Qty;//码表数量
                entity.FMQty = entity2.FMQty;//放码数量
                entity.KZ = entity2.KZ;//克重
                entity.MF = entity2.MF;//门幅
                entity.WX = entity2.WX;//纬斜
                entity.PrintCD = entity2.PrintCD;//打印疵点项目
                entity.ColorName = entity2.ColorName;//颜色
                entity.ColorNum = entity2.ColorNum;//色号
                entity.GoodsLevel = entity2.GoodsLevel;//等级
                entity.Qty = entity2.SM - entity2.FMQty;//数量=码表数量-放码数量

                string sqls = "Select ISNULL(Max(JarNo),0) From WO_BProductCheckDts where JarNum=" + SysString.ToDBString(SysConvert.ToString(entity.JarNum));
                sqls += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(entity.ItemCode));
                sqls += " AND ColorNum=" + SysString.ToDBString(SysConvert.ToString(entity.ColorNum));
                DataTable dts = sqlTrans.Fill(sqls);
                if ((SysConvert.ToInt32(dts.Rows[0][0]) + 1) != JarNo)
                {
                    entity.JarNo = SysConvert.ToInt32(dts.Rows[0][0]) + 1;//卷号
                }
                else
                {
                    entity.JarNo = JarNo;//卷号
                }

                entity.ShopID = entity2.ShopID;

                entity.YQty = SysConvert.ToDecimal(Qty * 1.0936132983377m, 2);//米数转码数
                BProductCheckDtsRule rule = new BProductCheckDtsRule();
                rule.RUpdate(entity, sqlTrans);







                #region 统计合计数据
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
                    if (dr["CDType"].ToString() == "染疵")
                    {

                        entity.RCKF = SysConvert.ToDecimal(dr["Deduction"]);
                        entity.CJRC = SysConvert.ToDecimal(dr["DYM"]);
                        entity.FMRC = SysConvert.ToDecimal(dr["DQuantity"]);
                    }
                    else if (dr["CDType"].ToString() == "织疵")
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

                entity.SJQty = SysConvert.ToDecimal(entity.SM - entity.CJZC - entity.CJRC - entity.FMQty, 1);//实际数量=码表数量-裁剪数量-放码数量
                BProductCheckDtsRule rulebp2 = new BProductCheckDtsRule();
                rulebp2.RUpdate(entity, sqlTrans);







                #endregion


                #region 合计检验米数汇总到待检清单

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