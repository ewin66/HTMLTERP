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
	/// 目的：Att_ItemTestFormDts实体控制类
	/// 作者:章文强
	/// 创建日期:2012/6/4
	/// </summary>
	public sealed class ItemTestFormDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ItemTestFormDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemTestFormDtsCtl(IDBTransAccess p_SqlCmd)
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
                ItemTestFormDts MasterEntity=(ItemTestFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Att_ItemTestFormDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("Sort"+","); 
  				if(MasterEntity.Sort!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Sort)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckItem"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckItem)+","); 
  				MasterField.Append("CheckUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckUnit)+","); 
  				MasterField.Append("TecReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TecReq)+","); 
  				MasterField.Append("CheckResult"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckResult)+","); 
  				MasterField.Append("PJ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PJ)+","); 
  				MasterField.Append("TFree"+")"); 
  				if(MasterEntity.TFree!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TFree)+")"); 
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
                ItemTestFormDts MasterEntity=(ItemTestFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Att_ItemTestFormDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				 
  				if(MasterEntity.Sort!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Sort="+SysString.ToDBString(MasterEntity.Sort)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Sort=null,");  
  				} 
  
  				UpdateBuilder.Append(" CheckItem="+SysString.ToDBString(MasterEntity.CheckItem)+","); 
  				UpdateBuilder.Append(" CheckUnit="+SysString.ToDBString(MasterEntity.CheckUnit)+","); 
  				UpdateBuilder.Append(" TecReq="+SysString.ToDBString(MasterEntity.TecReq)+","); 
  				UpdateBuilder.Append(" CheckResult="+SysString.ToDBString(MasterEntity.CheckResult)+","); 
  				UpdateBuilder.Append(" PJ="+SysString.ToDBString(MasterEntity.PJ)+","); 
  				 
  				if(MasterEntity.TFree!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TFree="+SysString.ToDBString(MasterEntity.TFree)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TFree=null");  
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
                ItemTestFormDts MasterEntity=(ItemTestFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Att_ItemTestFormDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
