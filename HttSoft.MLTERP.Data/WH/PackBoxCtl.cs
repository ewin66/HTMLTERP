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
	/// 目的：WH_PackBox实体控制类
	/// 作者:xusc
	/// 创建日期:2015/12/26
	/// </summary>
	public sealed class PackBoxCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public PackBoxCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public PackBoxCtl(IDBTransAccess p_SqlCmd)
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
                PackBox MasterEntity=(PackBox)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_PackBox(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("BoxNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BoxNo)+","); 
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("SectionID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SectionID)+","); 
  				MasterField.Append("SBitID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SBitID)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("GoodsLevel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
  				MasterField.Append("MWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				MasterField.Append("MWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("Batch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Batch)+","); 
  				MasterField.Append("VendorBatch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorBatch)+","); 
  				MasterField.Append("Weight"+","); 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("JarNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+","); 
  				MasterField.Append("CreateTime"+","); 
  				if(MasterEntity.CreateTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BoxStatusID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BoxStatusID)+","); 
  				MasterField.Append("InFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InFormNo)+","); 
  				MasterField.Append("OutFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OutFormNo)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("SourceTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SourceTypeID)+","); 
  				MasterField.Append("KPFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.KPFlag)+","); 
  				MasterField.Append("SourceBoxNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SourceBoxNo)+","); 
  				MasterField.Append("DID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DID)+","); 
  				MasterField.Append("CreateSourceID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CreateSourceID)+","); 
  				MasterField.Append("OrderFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				MasterField.Append("SubSeq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				MasterField.Append("FMQty"+","); 
  				if(MasterEntity.FMQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FMQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReHandle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ReHandle)+","); 
  				MasterField.Append("SplitColor"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SplitColor)+","); 
  				MasterField.Append("MiddleDiff"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MiddleDiff)+","); 
  				MasterField.Append("HeadTailDiff"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HeadTailDiff)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
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
                PackBox MasterEntity=(PackBox)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_PackBox SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				UpdateBuilder.Append(" BoxNo="+SysString.ToDBString(MasterEntity.BoxNo)+","); 
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				UpdateBuilder.Append(" SectionID="+SysString.ToDBString(MasterEntity.SectionID)+","); 
  				UpdateBuilder.Append(" SBitID="+SysString.ToDBString(MasterEntity.SBitID)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" GoodsLevel="+SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
  				UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" Batch="+SysString.ToDBString(MasterEntity.Batch)+","); 
  				UpdateBuilder.Append(" VendorBatch="+SysString.ToDBString(MasterEntity.VendorBatch)+","); 
  				 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Weight="+SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Weight=null,");  
  				} 
  
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)+","); 
  				 
  				if(MasterEntity.CreateTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CreateTime="+SysString.ToDBString(MasterEntity.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CreateTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" BoxStatusID="+SysString.ToDBString(MasterEntity.BoxStatusID)+","); 
  				UpdateBuilder.Append(" InFormNo="+SysString.ToDBString(MasterEntity.InFormNo)+","); 
  				UpdateBuilder.Append(" OutFormNo="+SysString.ToDBString(MasterEntity.OutFormNo)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" SourceTypeID="+SysString.ToDBString(MasterEntity.SourceTypeID)+","); 
  				UpdateBuilder.Append(" KPFlag="+SysString.ToDBString(MasterEntity.KPFlag)+","); 
  				UpdateBuilder.Append(" SourceBoxNo="+SysString.ToDBString(MasterEntity.SourceBoxNo)+","); 
  				UpdateBuilder.Append(" DID="+SysString.ToDBString(MasterEntity.DID)+","); 
  				UpdateBuilder.Append(" CreateSourceID="+SysString.ToDBString(MasterEntity.CreateSourceID)+","); 
  				UpdateBuilder.Append(" OrderFormNo="+SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				UpdateBuilder.Append(" SubSeq="+SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				 
  				if(MasterEntity.FMQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FMQty="+SysString.ToDBString(MasterEntity.FMQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FMQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" ReHandle="+SysString.ToDBString(MasterEntity.ReHandle)+","); 
  				UpdateBuilder.Append(" SplitColor="+SysString.ToDBString(MasterEntity.SplitColor)+","); 
  				UpdateBuilder.Append(" MiddleDiff="+SysString.ToDBString(MasterEntity.MiddleDiff)+","); 
  				UpdateBuilder.Append(" HeadTailDiff="+SysString.ToDBString(MasterEntity.HeadTailDiff)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				 
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
                PackBox MasterEntity=(PackBox)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WH_PackBox WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
