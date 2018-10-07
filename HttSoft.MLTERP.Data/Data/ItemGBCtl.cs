using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;

namespace HttSoft.MLTERP.DataCtl
{
    /// <summary>
    /// 目的：Data_ItemGB实体控制类
    /// 作者:章文强
    /// 创建日期:2014/3/18
    /// </summary>
    public sealed class ItemGBCtl : BaseControl
    {
        private bool sqlTransFlag = false;
        private IDBTransAccess sqlTrans;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ItemGBCtl()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ItemGBCtl(IDBTransAccess p_SqlCmd)
        {
            sqlTrans = p_SqlCmd;
            sqlTransFlag = true;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int AddNew(BaseEntity p_Entity)
        {
            try
            {
                ItemGB MasterEntity = (ItemGB)p_Entity;
                if (MasterEntity.ID == 0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField = new StringBuilder();
                StringBuilder MasterValue = new StringBuilder();
                MasterField.Append("INSERT INTO Data_ItemGB(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.ID) + ",");
                MasterField.Append("MainID" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.MainID) + ",");
                MasterField.Append("Seq" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.Seq) + ",");
                MasterField.Append("GBCode" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.GBCode) + ",");
                MasterField.Append("GBDate" + ",");
                if (MasterEntity.GBDate != SystemConfiguration.DateTimeDefaultValue)
                {
                    MasterValue.Append(SysString.ToDBString(MasterEntity.GBDate.ToString("yyyy-MM-dd HH:mm:ss")) + ",");
                }
                else
                {
                    MasterValue.Append("null,");
                }

                MasterField.Append("ColorNum" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum) + ",");
                MasterField.Append("ColorName" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName) + ",");
                MasterField.Append("GBDesc" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.GBDesc) + ",");
                MasterField.Append("XY" + ",");
                if (MasterEntity.XY != 0)
                {
                    MasterValue.Append(SysString.ToDBString(MasterEntity.XY) + ",");
                }
                else
                {
                    MasterValue.Append("null,");
                }

                MasterField.Append("XYDesc" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.XYDesc) + ",");
                MasterField.Append("GBPic" + ",");
                MasterValue.Append(@"@GBPic" + ",");
                MasterField.Append("GBPic2" + ",");
                MasterValue.Append(@"@GBPic2" + ",");
                MasterField.Append("GBStatusID" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.GBStatusID) + ",");
                MasterField.Append("Remark" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.Remark) + ",");
                MasterField.Append("GBFlag" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.GBFlag) + ",");
                MasterField.Append("MWidth" + ",");

                MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth) + ",");


                MasterField.Append("MWeight" + ",");

                MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight) + ",");


                MasterField.Append("WeightUnit" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.WeightUnit) + ",");
                MasterField.Append("testReportFlag" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.testReportFlag) + ",");
                MasterField.Append("testReportNum" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.testReportNum) + ",");
                MasterField.Append("ItemName" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName) + ",");
                MasterField.Append("PMainID" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.PMainID) + ",");
                MasterField.Append("PItemName" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.PItemName) + ",");
                MasterField.Append("XYDescRemark" + ",");
                MasterValue.Append(SysString.ToDBString(MasterEntity.XYDescRemark) + ",");
                MasterField.Append("GBPrice" + ",");
                if (MasterEntity.GBPrice != 0)
                {
                    MasterValue.Append(SysString.ToDBString(MasterEntity.GBPrice) + ",");
                }
                else
                {
                    MasterValue.Append("null,");
                }

                MasterField.Append("Unit" + ")");
                MasterValue.Append(SysString.ToDBString(MasterEntity.Unit) + ")");



                object[,] obja = new object[2, 2];
                obja[0, 0] = "@GBPic";
                obja[1, 0] = MasterEntity.GBPic;
                obja[0, 1] = "@GBPic2";
                obja[1, 1] = MasterEntity.GBPic2;

                //执行
                int AffectedRows = 0;
                if (!this.sqlTransFlag)
                {
                    AffectedRows = this.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString(), obja);
                }
                else
                {
                    AffectedRows = sqlTrans.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString(), obja);
                }
                return AffectedRows;
            }
            catch (BaseException E)
            {
                throw new BaseException(E.Message, E);
            }
            catch (Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBInsert), E);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int Update(BaseEntity p_Entity)
        {
            try
            {
                ItemGB MasterEntity = (ItemGB)p_Entity;
                if (MasterEntity.ID == 0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder = new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_ItemGB SET ");
                UpdateBuilder.Append(" ID=" + SysString.ToDBString(MasterEntity.ID) + ",");
                UpdateBuilder.Append(" MainID=" + SysString.ToDBString(MasterEntity.MainID) + ",");
                UpdateBuilder.Append(" Seq=" + SysString.ToDBString(MasterEntity.Seq) + ",");
                UpdateBuilder.Append(" GBCode=" + SysString.ToDBString(MasterEntity.GBCode) + ",");

                if (MasterEntity.GBDate != SystemConfiguration.DateTimeDefaultValue)
                {
                    UpdateBuilder.Append(" GBDate=" + SysString.ToDBString(MasterEntity.GBDate.ToString("yyyy-MM-dd HH:mm:ss")) + ",");
                }
                else
                {
                    UpdateBuilder.Append(" GBDate=null,");
                }

                UpdateBuilder.Append(" ColorNum=" + SysString.ToDBString(MasterEntity.ColorNum) + ",");
                UpdateBuilder.Append(" ColorName=" + SysString.ToDBString(MasterEntity.ColorName) + ",");
                UpdateBuilder.Append(" GBDesc=" + SysString.ToDBString(MasterEntity.GBDesc) + ",");

                if (MasterEntity.XY != 0)
                {
                    UpdateBuilder.Append(" XY=" + SysString.ToDBString(MasterEntity.XY) + ",");
                }
                else
                {
                    UpdateBuilder.Append(" XY=null,");
                }

                UpdateBuilder.Append(" XYDesc=" + SysString.ToDBString(MasterEntity.XYDesc) + ",");
                UpdateBuilder.Append(" GBPic=@GBPic" + ",");
                UpdateBuilder.Append(" GBPic2=@GBPic2" + ",");
                UpdateBuilder.Append(" GBStatusID=" + SysString.ToDBString(MasterEntity.GBStatusID) + ",");
                UpdateBuilder.Append(" Remark=" + SysString.ToDBString(MasterEntity.Remark) + ",");
                UpdateBuilder.Append(" GBFlag=" + SysString.ToDBString(MasterEntity.GBFlag) + ",");
                UpdateBuilder.Append(" MWidth=" + SysString.ToDBString(MasterEntity.MWidth) + ",");
                UpdateBuilder.Append(" MWeight=" + SysString.ToDBString(MasterEntity.MWeight) + ",");


                UpdateBuilder.Append(" WeightUnit=" + SysString.ToDBString(MasterEntity.WeightUnit) + ",");
                UpdateBuilder.Append(" testReportFlag=" + SysString.ToDBString(MasterEntity.testReportFlag) + ",");
                UpdateBuilder.Append(" testReportNum=" + SysString.ToDBString(MasterEntity.testReportNum) + ",");
                UpdateBuilder.Append(" ItemName=" + SysString.ToDBString(MasterEntity.ItemName) + ",");
                UpdateBuilder.Append(" PMainID=" + SysString.ToDBString(MasterEntity.PMainID) + ",");
                UpdateBuilder.Append(" PItemName=" + SysString.ToDBString(MasterEntity.PItemName) + ",");
                UpdateBuilder.Append(" XYDescRemark=" + SysString.ToDBString(MasterEntity.XYDescRemark) + ",");

                if (MasterEntity.GBPrice != 0)
                {
                    UpdateBuilder.Append(" GBPrice=" + SysString.ToDBString(MasterEntity.GBPrice) + ",");
                }
                else
                {
                    UpdateBuilder.Append(" GBPrice=null,");
                }

                UpdateBuilder.Append(" Unit=" + SysString.ToDBString(MasterEntity.Unit));

                UpdateBuilder.Append(" WHERE " + "ID=" + SysString.ToDBString(MasterEntity.ID));


                object[,] obja = new object[2, 2];
                obja[0, 0] = "@GBPic";
                obja[1, 0] = MasterEntity.GBPic;
                obja[0, 1] = "@GBPic2";
                obja[1, 1] = MasterEntity.GBPic2;

                //执行
                int AffectedRows = 0;
                if (!this.sqlTransFlag)
                {
                    AffectedRows = this.ExecuteNonQuery(UpdateBuilder.ToString(), obja);
                }
                else
                {
                    AffectedRows = sqlTrans.ExecuteNonQuery(UpdateBuilder.ToString(), obja);
                }
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
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int Delete(BaseEntity p_Entity)
        {
            try
            {
                ItemGB MasterEntity = (ItemGB)p_Entity;
                if (MasterEntity.ID == 0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql = "";
                Sql = "DELETE FROM Data_ItemGB WHERE " + "ID=" + SysString.ToDBString(MasterEntity.ID);
                //执行
                int AffectedRows = 0;
                if (!this.sqlTransFlag)
                {
                    AffectedRows = this.ExecuteNonQuery(Sql);
                }
                else
                {
                    AffectedRows = sqlTrans.ExecuteNonQuery(Sql);
                }

                return AffectedRows;
            }
            catch (BaseException E)
            {
                throw new BaseException(E.Message, E);
            }
            catch (Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBDelete), E);
            }
        }
    }
}
