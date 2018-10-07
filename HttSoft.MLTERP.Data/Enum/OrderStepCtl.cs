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
	/// 目的：Enum_OrderStep实体控制类
	/// 作者:周富春
	/// 创建日期:2014/10/17
	/// </summary>
	public sealed class OrderStepCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public OrderStepCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public OrderStepCtl(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
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
                OrderStep MasterEntity=(OrderStep)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Enum_OrderStep(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("Name"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Name)+","); 
  				MasterField.Append("ColorStr"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorStr)+","); 
  				MasterField.Append("NextStepID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.NextStepID)+","); 
  				MasterField.Append("SaleProcedureID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleProcedureID)+","); 
  				MasterField.Append("FormListID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormListID)+","); 
  				MasterField.Append("DZFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DZFlag)+","); 
  				MasterField.Append("InvoiceFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceFlag)+","); 
  				MasterField.Append("RecAmountFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecAmountFlag)+","); 
  				MasterField.Append("FinishFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FinishFlag)+","); 
  				MasterField.Append("CancelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CancelFlag)+","); 
  				MasterField.Append("ShowFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShowFlag)+","); 
  				MasterField.Append("CheckItemFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckItemFlag)+","); 
  				MasterField.Append("CheckColorFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckColorFlag)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("SaleProcedureID2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleProcedureID2)+","); 
  				MasterField.Append("FormListID2"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormListID2)+")"); 
 
                
                

                //执行
                int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString());
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString());
				}
                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
               throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBInsert),E);
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
                OrderStep MasterEntity=(OrderStep)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Enum_OrderStep SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				UpdateBuilder.Append(" Name="+SysString.ToDBString(MasterEntity.Name)+","); 
  				UpdateBuilder.Append(" ColorStr="+SysString.ToDBString(MasterEntity.ColorStr)+","); 
  				UpdateBuilder.Append(" NextStepID="+SysString.ToDBString(MasterEntity.NextStepID)+","); 
  				UpdateBuilder.Append(" SaleProcedureID="+SysString.ToDBString(MasterEntity.SaleProcedureID)+","); 
  				UpdateBuilder.Append(" FormListID="+SysString.ToDBString(MasterEntity.FormListID)+","); 
  				UpdateBuilder.Append(" DZFlag="+SysString.ToDBString(MasterEntity.DZFlag)+","); 
  				UpdateBuilder.Append(" InvoiceFlag="+SysString.ToDBString(MasterEntity.InvoiceFlag)+","); 
  				UpdateBuilder.Append(" RecAmountFlag="+SysString.ToDBString(MasterEntity.RecAmountFlag)+","); 
  				UpdateBuilder.Append(" FinishFlag="+SysString.ToDBString(MasterEntity.FinishFlag)+","); 
  				UpdateBuilder.Append(" CancelFlag="+SysString.ToDBString(MasterEntity.CancelFlag)+","); 
  				UpdateBuilder.Append(" ShowFlag="+SysString.ToDBString(MasterEntity.ShowFlag)+","); 
  				UpdateBuilder.Append(" CheckItemFlag="+SysString.ToDBString(MasterEntity.CheckItemFlag)+","); 
  				UpdateBuilder.Append(" CheckColorFlag="+SysString.ToDBString(MasterEntity.CheckColorFlag)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" SaleProcedureID2="+SysString.ToDBString(MasterEntity.SaleProcedureID2)+","); 
  				UpdateBuilder.Append(" FormListID2="+SysString.ToDBString(MasterEntity.FormListID2)); 
 
                UpdateBuilder.Append(" WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID));
                
                

               //执行
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(UpdateBuilder.ToString());
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(UpdateBuilder.ToString());
				}
                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBUpdate),E);
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
                OrderStep MasterEntity=(OrderStep)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Enum_OrderStep WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
                //执行
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(Sql);
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(Sql);
				}

                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBDelete),E);
            }
        }
	}
}
