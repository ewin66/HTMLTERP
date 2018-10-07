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
    /// 目的：WH_SBit实体业务规则类
    /// 作者:陈加海
    /// 创建日期:2006-11-10
    /// </summary>
    public class SBitRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SBitRule()
        {
        }

        /// <summary>
        /// 检查将要操作的数据是否符合业务规则
        /// </summary>
        /// <param name="p_BE"></param>
        private void CheckCorrect(BaseEntity p_BE)
        {
            SBit entity = (SBit)p_BE;
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <returns></returns>
        public DataTable RShow(string p_Condition)
        {
            return RShow(p_Condition, "*");
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <returns></returns>
        public DataTable RShow(string p_Condition, string p_QueryField)
        {
            string sql = "SELECT ";
            sql += p_QueryField;
            sql += " FROM WH_SBit WHERE 1=1 ";
            sql += p_Condition;
            return SysUtils.Fill(sql);
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
                SBit entity = (SBit)p_BE;
                SBitCtl control = new SBitCtl(sqlTrans);
                //entity.ID=EntityIDTable.GetID((long)SysEntity.WH_SBit,sqlTrans);
                string sql = "SELECT SBitID FROM WH_SBit WHERE SBitID=" + SysString.ToDBString(entity.SBitID) + " AND SectionID=" + SysString.ToDBString(entity.SectionID) + " AND WHID=" + SysString.ToDBString(entity.WHID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    throw new Exception("该仓库位编码已经存在，请重新输入");
                }
                FormNoControlRule rule = new FormNoControlRule();
                entity.SBitISN = rule.RGetFormNo(1026, sqlTrans);
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
                SBit entity = (SBit)p_BE;
                SBitCtl control = new SBitCtl(sqlTrans);
                //string sql = "SELECT SBitID FROM WH_SBit WHERE SBitID=" + SysString.ToDBString(entity.SBitID) +" AND SectionID=" + SysString.ToDBString(entity.SectionID) + " AND WHID=" + SysString.ToDBString(entity.WHID);
                //sql+=" AND SBitID<>"+SysString.ToDBString(entity.OldSBitID);
                //DataTable dt = sqlTrans.Fill(sql);
                //if(dt.Rows.Count!=0)
                //{
                //    throw new Exception("该仓库位编码已经存在，请重新输入");
                //}
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
        /// 修改
        /// </summary>
        /// <param name="p_BE">要修改的实体</param>
        public void RUpdate(BaseEntity p_BE, string p_Old)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RUpdate(p_BE, p_Old, sqlTrans);

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
        public void RUpdate(BaseEntity p_BE, string p_Old, IDBTransAccess sqlTrans)
        {
            try
            {
                string sql = "SELECT * FROM WH_IOFormDts WHERE SBitID =" + SysString.ToDBString(p_Old);
                if (sqlTrans.Fill(sql).Rows.Count > 0)
                {
                    throw new Exception("该仓位已经做出入库单据，不能修改");
                    return;
                }
                this.CheckCorrect(p_BE);
                SBit entity = (SBit)p_BE;
                //SBitCtl control = new SBitCtl(sqlTrans);
                //string sql = "SELECT SBitID FROM WH_SBit WHERE SBitID=" + SysString.ToDBString(entity.SBitID) +" AND SectionID=" + SysString.ToDBString(entity.SectionID) + " AND WHID=" + SysString.ToDBString(entity.WHID);
                //sql+=" AND SBitID<>"+SysString.ToDBString(entity.OldSBitID);
                //DataTable dt = sqlTrans.Fill(sql);
                //if(dt.Rows.Count!=0)
                //{
                //    throw new Exception("该仓库位编码已经存在，请重新输入");
                //}
                this.Update(entity, p_Old, sqlTrans);
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
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public int Update(BaseEntity p_Entity, string p_Old, IDBTransAccess sqlTrans)
        {
            try
            {
                SBit MasterEntity = (SBit)p_Entity;
                if (MasterEntity.SBitID == "")
                {
                    return 0;
                }
                //更新主表数据
                StringBuilder UpdateBuilder = new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_SBit SET ");
                UpdateBuilder.Append(" MainID=" + SysString.ToDBString(MasterEntity.MainID) + ",");
                UpdateBuilder.Append(" Seq=" + SysString.ToDBString(MasterEntity.Seq) + ",");
                UpdateBuilder.Append(" SubSeq=" + SysString.ToDBString(MasterEntity.SubSeq) + ",");
                UpdateBuilder.Append(" WHID=" + SysString.ToDBString(MasterEntity.WHID) + ",");
                UpdateBuilder.Append(" SectionID=" + SysString.ToDBString(MasterEntity.SectionID) + ",");
                UpdateBuilder.Append(" SBitID=" + SysString.ToDBString(MasterEntity.SBitID) + ",");

                if (MasterEntity.IsUseable != 0)
                {
                    UpdateBuilder.Append(" IsUseable=" + SysString.ToDBString(MasterEntity.IsUseable) + ",");
                }
                else
                {
                    UpdateBuilder.Append(" IsUseable=null,");
                }


                if (MasterEntity.WeightMax != 0)
                {
                    UpdateBuilder.Append(" WeightMax=" + SysString.ToDBString(MasterEntity.WeightMax) + ",");
                }
                else
                {
                    UpdateBuilder.Append(" WeightMax=null,");
                }


                if (MasterEntity.BulkMax != 0)
                {
                    UpdateBuilder.Append(" BulkMax=" + SysString.ToDBString(MasterEntity.BulkMax) + ",");
                }
                else
                {
                    UpdateBuilder.Append(" BulkMax=null,");
                }

                UpdateBuilder.Append(" Remark=" + SysString.ToDBString(MasterEntity.Remark) + ",");
                UpdateBuilder.Append(" SBitISN=" + SysString.ToDBString(MasterEntity.SBitISN));

                UpdateBuilder.Append(" WHERE " + "SBitID=" + SysString.ToDBString(p_Old));
                //执行
                int AffectedRows = 0;
                AffectedRows = sqlTrans.ExecuteNonQuery(UpdateBuilder.ToString());
                return AffectedRows;
            }
            catch (BaseException E)
            {
                throw new BaseException(E.Message, E);
            }
            catch (Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBUpdate), E);
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
                SBit entity = (SBit)p_BE;
                SBitCtl control = new SBitCtl(sqlTrans);
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
    }
}
