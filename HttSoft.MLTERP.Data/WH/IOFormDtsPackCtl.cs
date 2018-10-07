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
	/// 目的：WH_IOFormDtsPack实体控制类
	/// 作者:xusc
	/// 创建日期:2015/12/26
	/// </summary>
	public sealed class IOFormDtsPackCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public IOFormDtsPackCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public IOFormDtsPackCtl(IDBTransAccess p_SqlCmd)
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
                IOFormDtsPack MasterEntity=(IOFormDtsPack)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_IOFormDtsPack(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("SubSeq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				MasterField.Append("PackNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackNo)+","); 
  				MasterField.Append("BoxNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BoxNo)+","); 
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FactQty"+","); 
  				if(MasterEntity.FactQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FactQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PDQty"+","); 
  				if(MasterEntity.PDQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PDQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("DID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DID)+","); 
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("InputQty"+","); 
  				if(MasterEntity.InputQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InputQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InputUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InputUnit)+","); 
  				MasterField.Append("InputConvertXS"+","); 
  				if(MasterEntity.InputConvertXS!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InputConvertXS)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FMQty"+","); 
  				if(MasterEntity.FMQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FMQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("GrossQty"+","); 
  				if(MasterEntity.GrossQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.GrossQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("GrossWeight"+","); 
  				if(MasterEntity.GrossWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.GrossWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("NetWeight"+","); 
  				if(MasterEntity.NetWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NetWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Description"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Description)+","); 
  				MasterField.Append("Destination"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Destination)+","); 
  				MasterField.Append("RecordOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecordOPID)+","); 
  				MasterField.Append("RecordType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecordType)+","); 
  				MasterField.Append("Weight"+","); 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("GoodsLevel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
  				MasterField.Append("Yard"+")"); 
  				if(MasterEntity.Yard!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Yard)+")"); 
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
                IOFormDtsPack MasterEntity=(IOFormDtsPack)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_IOFormDtsPack SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" SubSeq="+SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				UpdateBuilder.Append(" PackNo="+SysString.ToDBString(MasterEntity.PackNo)+","); 
  				UpdateBuilder.Append(" BoxNo="+SysString.ToDBString(MasterEntity.BoxNo)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				 
  				if(MasterEntity.FactQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FactQty="+SysString.ToDBString(MasterEntity.FactQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FactQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.PDQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PDQty="+SysString.ToDBString(MasterEntity.PDQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PDQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" DID="+SysString.ToDBString(MasterEntity.DID)+","); 
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				 
  				if(MasterEntity.InputQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputQty="+SysString.ToDBString(MasterEntity.InputQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" InputUnit="+SysString.ToDBString(MasterEntity.InputUnit)+","); 
  				 
  				if(MasterEntity.InputConvertXS!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputConvertXS="+SysString.ToDBString(MasterEntity.InputConvertXS)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputConvertXS=null,");  
  				} 
  
  				 
  				if(MasterEntity.FMQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FMQty="+SysString.ToDBString(MasterEntity.FMQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FMQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.GrossQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" GrossQty="+SysString.ToDBString(MasterEntity.GrossQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" GrossQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.GrossWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" GrossWeight="+SysString.ToDBString(MasterEntity.GrossWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" GrossWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.NetWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NetWeight="+SysString.ToDBString(MasterEntity.NetWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NetWeight=null,");  
  				} 
  
  				UpdateBuilder.Append(" Description="+SysString.ToDBString(MasterEntity.Description)+","); 
  				UpdateBuilder.Append(" Destination="+SysString.ToDBString(MasterEntity.Destination)+","); 
  				UpdateBuilder.Append(" RecordOPID="+SysString.ToDBString(MasterEntity.RecordOPID)+","); 
  				UpdateBuilder.Append(" RecordType="+SysString.ToDBString(MasterEntity.RecordType)+","); 
  				 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Weight="+SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Weight=null,");  
  				} 
  
  				UpdateBuilder.Append(" GoodsLevel="+SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
  				 
  				if(MasterEntity.Yard!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Yard="+SysString.ToDBString(MasterEntity.Yard)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Yard=null");  
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
                IOFormDtsPack MasterEntity=(IOFormDtsPack)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WH_IOFormDtsPack WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
