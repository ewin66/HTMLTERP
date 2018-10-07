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
	/// 目的：Finance_CheckOperationDts实体控制类
	/// 作者:周富春
	/// 创建日期:2014/10/17
	/// </summary>
	public sealed class CheckOperationDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public CheckOperationDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckOperationDtsCtl(IDBTransAccess p_SqlCmd)
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
                CheckOperationDts MasterEntity=(CheckOperationDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Finance_CheckOperationDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("DLOADID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLOADID)+","); 
  				MasterField.Append("DLOADSEQ"+","); 
  				if(MasterEntity.DLOADSEQ!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DLOADSEQ)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DLOADNO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLOADNO)+","); 
  				MasterField.Append("DLOADDtsID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLOADDtsID)+","); 
  				MasterField.Append("DCheckQty"+","); 
  				if(MasterEntity.DCheckQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DCheckQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DCheckSinglePrice"+","); 
  				if(MasterEntity.DCheckSinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DCheckSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DCheckAmount"+","); 
  				if(MasterEntity.DCheckAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DCheckAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("InvoiceFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceFlag)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("DCheckDYPrice"+","); 
  				if(MasterEntity.DCheckDYPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DCheckDYPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("QSID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QSID)+","); 
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("LoadFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LoadFlag)+","); 
  				MasterField.Append("YuLiaoQty"+","); 
  				if(MasterEntity.YuLiaoQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YuLiaoQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TZAmount"+","); 
  				if(MasterEntity.TZAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FAmount1"+","); 
  				if(MasterEntity.FAmount1!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FAmount1)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FAmount2"+","); 
  				if(MasterEntity.FAmount2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FAmount2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FAmount3"+","); 
  				if(MasterEntity.FAmount3!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FAmount3)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FAmount4"+")"); 
  				if(MasterEntity.FAmount4!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FAmount4)+")"); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null)"); 
  				} 
  
 
                
                

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
                CheckOperationDts MasterEntity=(CheckOperationDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Finance_CheckOperationDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" DLOADID="+SysString.ToDBString(MasterEntity.DLOADID)+","); 
  				 
  				if(MasterEntity.DLOADSEQ!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DLOADSEQ="+SysString.ToDBString(MasterEntity.DLOADSEQ)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DLOADSEQ=null,");  
  				} 
  
  				UpdateBuilder.Append(" DLOADNO="+SysString.ToDBString(MasterEntity.DLOADNO)+","); 
  				UpdateBuilder.Append(" DLOADDtsID="+SysString.ToDBString(MasterEntity.DLOADDtsID)+","); 
  				 
  				if(MasterEntity.DCheckQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DCheckQty="+SysString.ToDBString(MasterEntity.DCheckQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DCheckQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.DCheckSinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DCheckSinglePrice="+SysString.ToDBString(MasterEntity.DCheckSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DCheckSinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.DCheckAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DCheckAmount="+SysString.ToDBString(MasterEntity.DCheckAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DCheckAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" InvoiceFlag="+SysString.ToDBString(MasterEntity.InvoiceFlag)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				 
  				if(MasterEntity.DCheckDYPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DCheckDYPrice="+SysString.ToDBString(MasterEntity.DCheckDYPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DCheckDYPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" QSID="+SysString.ToDBString(MasterEntity.QSID)+","); 
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				UpdateBuilder.Append(" LoadFlag="+SysString.ToDBString(MasterEntity.LoadFlag)+","); 
  				 
  				if(MasterEntity.YuLiaoQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YuLiaoQty="+SysString.ToDBString(MasterEntity.YuLiaoQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YuLiaoQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TZAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TZAmount="+SysString.ToDBString(MasterEntity.TZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TZAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.FAmount1!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FAmount1="+SysString.ToDBString(MasterEntity.FAmount1)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FAmount1=null,");  
  				} 
  
  				 
  				if(MasterEntity.FAmount2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FAmount2="+SysString.ToDBString(MasterEntity.FAmount2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FAmount2=null,");  
  				} 
  
  				 
  				if(MasterEntity.FAmount3!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FAmount3="+SysString.ToDBString(MasterEntity.FAmount3)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FAmount3=null,");  
  				} 
  
  				 
  				if(MasterEntity.FAmount4!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FAmount4="+SysString.ToDBString(MasterEntity.FAmount4)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FAmount4=null");  
  				} 
  
 
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
                CheckOperationDts MasterEntity=(CheckOperationDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Finance_CheckOperationDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
