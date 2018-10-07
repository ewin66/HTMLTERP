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
	/// 目的：Enum_FormList实体控制类
	/// 作者:周富春
	/// 创建日期:2014/11/19
	/// </summary>
	public sealed class FormListCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public FormListCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FormListCtl(IDBTransAccess p_SqlCmd)
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
                FormList MasterEntity=(FormList)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Enum_FormList(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("Code"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Code)+","); 
  				MasterField.Append("FormNM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNM)+","); 
  				MasterField.Append("ParentID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ParentID)+","); 
  				MasterField.Append("IsShow"+","); 
  				if(MasterEntity.IsShow!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.IsShow)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FormNoControlID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNoControlID)+","); 
  				MasterField.Append("WHTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHTypeID)+","); 
  				MasterField.Append("CheckFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckFlag)+","); 
  				MasterField.Append("MoveFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MoveFlag)+","); 
  				MasterField.Append("WHQtyPosID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHQtyPosID)+","); 
  				MasterField.Append("LoadFormTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LoadFormTypeID)+","); 
  				MasterField.Append("FillDataTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FillDataTypeID)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("VendorTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorTypeID)+","); 
  				MasterField.Append("VendorTypeID2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorTypeID2)+","); 
  				MasterField.Append("VendorTypeID3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorTypeID3)+","); 
  				MasterField.Append("VendorTypeID4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorTypeID4)+","); 
  				MasterField.Append("VendorTypeID5"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorTypeID5)+","); 
  				MasterField.Append("DZFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DZFlag)+","); 
  				MasterField.Append("DZType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DZType)+","); 
  				MasterField.Append("CaiWuFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CaiWuFlag)+","); 
  				MasterField.Append("CaiWuType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CaiWuType)+","); 
  				MasterField.Append("InvoiceFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceFlag)+","); 
  				MasterField.Append("IsFreeForm"+","); 
  				if(MasterEntity.IsFreeForm!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.IsFreeForm)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeFormID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeFormID)+","); 
  				MasterField.Append("IsDelForm"+","); 
  				if(MasterEntity.IsDelForm!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.IsDelForm)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("UnLockFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UnLockFlag)+","); 
  				MasterField.Append("DelFormID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFormID)+","); 
  				MasterField.Append("LockFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LockFlag)+","); 
  				MasterField.Append("CheckSOFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckSOFlag)+","); 
  				MasterField.Append("SaleFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleFlag)+","); 
  				MasterField.Append("ColorFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorFlag)+","); 
  				MasterField.Append("BuyFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BuyFlag)+","); 
  				MasterField.Append("PrintTitle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintTitle)+","); 
  				MasterField.Append("PrintCondition"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintCondition)+","); 
  				MasterField.Append("PrintColTitle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintColTitle)+","); 
  				MasterField.Append("SpecialFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SpecialFlag)+","); 
  				MasterField.Append("RecInvoiceFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecInvoiceFlag)+","); 
  				MasterField.Append("OthFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OthFlag)+","); 
  				MasterField.Append("CaiWuCostFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CaiWuCostFlag)+","); 
  				MasterField.Append("CaiWuCostType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CaiWuCostType)+","); 
  				MasterField.Append("NeedCheckType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.NeedCheckType)+","); 
  				MasterField.Append("AuditFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AuditFlag)+","); 
  				MasterField.Append("WHFormTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHFormTypeID)+","); 
  				MasterField.Append("WHSpecialTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHSpecialTypeID)+","); 
  				MasterField.Append("DefaultWHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DefaultWHID)+","); 
  				MasterField.Append("VendorIDCaption"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorIDCaption)+","); 
  				MasterField.Append("CheckFieldName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckFieldName)+","); 
  				MasterField.Append("CheckDtsFieldName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckDtsFieldName)+","); 
  				MasterField.Append("SaleOPCaption"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPCaption)+","); 
  				MasterField.Append("CompactCodeVisible"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompactCodeVisible)+","); 
  				MasterField.Append("CheckQtyPer1"+","); 
  				if(MasterEntity.CheckQtyPer1!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQtyPer1)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQtyFrom"+","); 
  				if(MasterEntity.CheckQtyFrom!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQtyFrom)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQtyPer2"+","); 
  				if(MasterEntity.CheckQtyPer2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQtyPer2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("THLoadFormListIDStr"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.THLoadFormListIDStr)+","); 
  				MasterField.Append("CBSourceTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CBSourceTypeID)+","); 
  				MasterField.Append("DEditReadOnlyFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DEditReadOnlyFlag)+","); 
  				MasterField.Append("DBFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DBFlag)+","); 
  				MasterField.Append("DefaultVendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DefaultVendorID)+","); 
  				MasterField.Append("DefaultSubTypeID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DefaultSubTypeID)+")"); 
 
                
                

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
                FormList MasterEntity=(FormList)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Enum_FormList SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" Code="+SysString.ToDBString(MasterEntity.Code)+","); 
  				UpdateBuilder.Append(" FormNM="+SysString.ToDBString(MasterEntity.FormNM)+","); 
  				UpdateBuilder.Append(" ParentID="+SysString.ToDBString(MasterEntity.ParentID)+","); 
  				 
  				if(MasterEntity.IsShow!=0) 
  				{ 
  			 		UpdateBuilder.Append(" IsShow="+SysString.ToDBString(MasterEntity.IsShow)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" IsShow=null,");  
  				} 
  
  				UpdateBuilder.Append(" FormNoControlID="+SysString.ToDBString(MasterEntity.FormNoControlID)+","); 
  				UpdateBuilder.Append(" WHTypeID="+SysString.ToDBString(MasterEntity.WHTypeID)+","); 
  				UpdateBuilder.Append(" CheckFlag="+SysString.ToDBString(MasterEntity.CheckFlag)+","); 
  				UpdateBuilder.Append(" MoveFlag="+SysString.ToDBString(MasterEntity.MoveFlag)+","); 
  				UpdateBuilder.Append(" WHQtyPosID="+SysString.ToDBString(MasterEntity.WHQtyPosID)+","); 
  				UpdateBuilder.Append(" LoadFormTypeID="+SysString.ToDBString(MasterEntity.LoadFormTypeID)+","); 
  				UpdateBuilder.Append(" FillDataTypeID="+SysString.ToDBString(MasterEntity.FillDataTypeID)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" VendorTypeID="+SysString.ToDBString(MasterEntity.VendorTypeID)+","); 
  				UpdateBuilder.Append(" VendorTypeID2="+SysString.ToDBString(MasterEntity.VendorTypeID2)+","); 
  				UpdateBuilder.Append(" VendorTypeID3="+SysString.ToDBString(MasterEntity.VendorTypeID3)+","); 
  				UpdateBuilder.Append(" VendorTypeID4="+SysString.ToDBString(MasterEntity.VendorTypeID4)+","); 
  				UpdateBuilder.Append(" VendorTypeID5="+SysString.ToDBString(MasterEntity.VendorTypeID5)+","); 
  				UpdateBuilder.Append(" DZFlag="+SysString.ToDBString(MasterEntity.DZFlag)+","); 
  				UpdateBuilder.Append(" DZType="+SysString.ToDBString(MasterEntity.DZType)+","); 
  				UpdateBuilder.Append(" CaiWuFlag="+SysString.ToDBString(MasterEntity.CaiWuFlag)+","); 
  				UpdateBuilder.Append(" CaiWuType="+SysString.ToDBString(MasterEntity.CaiWuType)+","); 
  				UpdateBuilder.Append(" InvoiceFlag="+SysString.ToDBString(MasterEntity.InvoiceFlag)+","); 
  				 
  				if(MasterEntity.IsFreeForm!=0) 
  				{ 
  			 		UpdateBuilder.Append(" IsFreeForm="+SysString.ToDBString(MasterEntity.IsFreeForm)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" IsFreeForm=null,");  
  				} 
  
  				UpdateBuilder.Append(" FreeFormID="+SysString.ToDBString(MasterEntity.FreeFormID)+","); 
  				 
  				if(MasterEntity.IsDelForm!=0) 
  				{ 
  			 		UpdateBuilder.Append(" IsDelForm="+SysString.ToDBString(MasterEntity.IsDelForm)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" IsDelForm=null,");  
  				} 
  
  				UpdateBuilder.Append(" UnLockFlag="+SysString.ToDBString(MasterEntity.UnLockFlag)+","); 
  				UpdateBuilder.Append(" DelFormID="+SysString.ToDBString(MasterEntity.DelFormID)+","); 
  				UpdateBuilder.Append(" LockFlag="+SysString.ToDBString(MasterEntity.LockFlag)+","); 
  				UpdateBuilder.Append(" CheckSOFlag="+SysString.ToDBString(MasterEntity.CheckSOFlag)+","); 
  				UpdateBuilder.Append(" SaleFlag="+SysString.ToDBString(MasterEntity.SaleFlag)+","); 
  				UpdateBuilder.Append(" ColorFlag="+SysString.ToDBString(MasterEntity.ColorFlag)+","); 
  				UpdateBuilder.Append(" BuyFlag="+SysString.ToDBString(MasterEntity.BuyFlag)+","); 
  				UpdateBuilder.Append(" PrintTitle="+SysString.ToDBString(MasterEntity.PrintTitle)+","); 
  				UpdateBuilder.Append(" PrintCondition="+SysString.ToDBString(MasterEntity.PrintCondition)+","); 
  				UpdateBuilder.Append(" PrintColTitle="+SysString.ToDBString(MasterEntity.PrintColTitle)+","); 
  				UpdateBuilder.Append(" SpecialFlag="+SysString.ToDBString(MasterEntity.SpecialFlag)+","); 
  				UpdateBuilder.Append(" RecInvoiceFlag="+SysString.ToDBString(MasterEntity.RecInvoiceFlag)+","); 
  				UpdateBuilder.Append(" OthFlag="+SysString.ToDBString(MasterEntity.OthFlag)+","); 
  				UpdateBuilder.Append(" CaiWuCostFlag="+SysString.ToDBString(MasterEntity.CaiWuCostFlag)+","); 
  				UpdateBuilder.Append(" CaiWuCostType="+SysString.ToDBString(MasterEntity.CaiWuCostType)+","); 
  				UpdateBuilder.Append(" NeedCheckType="+SysString.ToDBString(MasterEntity.NeedCheckType)+","); 
  				UpdateBuilder.Append(" AuditFlag="+SysString.ToDBString(MasterEntity.AuditFlag)+","); 
  				UpdateBuilder.Append(" WHFormTypeID="+SysString.ToDBString(MasterEntity.WHFormTypeID)+","); 
  				UpdateBuilder.Append(" WHSpecialTypeID="+SysString.ToDBString(MasterEntity.WHSpecialTypeID)+","); 
  				UpdateBuilder.Append(" DefaultWHID="+SysString.ToDBString(MasterEntity.DefaultWHID)+","); 
  				UpdateBuilder.Append(" VendorIDCaption="+SysString.ToDBString(MasterEntity.VendorIDCaption)+","); 
  				UpdateBuilder.Append(" CheckFieldName="+SysString.ToDBString(MasterEntity.CheckFieldName)+","); 
  				UpdateBuilder.Append(" CheckDtsFieldName="+SysString.ToDBString(MasterEntity.CheckDtsFieldName)+","); 
  				UpdateBuilder.Append(" SaleOPCaption="+SysString.ToDBString(MasterEntity.SaleOPCaption)+","); 
  				UpdateBuilder.Append(" CompactCodeVisible="+SysString.ToDBString(MasterEntity.CompactCodeVisible)+","); 
  				 
  				if(MasterEntity.CheckQtyPer1!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQtyPer1="+SysString.ToDBString(MasterEntity.CheckQtyPer1)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQtyPer1=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQtyFrom!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQtyFrom="+SysString.ToDBString(MasterEntity.CheckQtyFrom)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQtyFrom=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQtyPer2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQtyPer2="+SysString.ToDBString(MasterEntity.CheckQtyPer2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQtyPer2=null,");  
  				} 
  
  				UpdateBuilder.Append(" THLoadFormListIDStr="+SysString.ToDBString(MasterEntity.THLoadFormListIDStr)+","); 
  				UpdateBuilder.Append(" CBSourceTypeID="+SysString.ToDBString(MasterEntity.CBSourceTypeID)+","); 
  				UpdateBuilder.Append(" DEditReadOnlyFlag="+SysString.ToDBString(MasterEntity.DEditReadOnlyFlag)+","); 
  				UpdateBuilder.Append(" DBFlag="+SysString.ToDBString(MasterEntity.DBFlag)+","); 
  				UpdateBuilder.Append(" DefaultVendorID="+SysString.ToDBString(MasterEntity.DefaultVendorID)+","); 
  				UpdateBuilder.Append(" DefaultSubTypeID="+SysString.ToDBString(MasterEntity.DefaultSubTypeID)); 
 
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
                FormList MasterEntity=(FormList)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Enum_FormList WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
