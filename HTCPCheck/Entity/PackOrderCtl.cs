using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;

namespace HttSoft.HTCPCheck.DataCtl
{
	/// <summary>
	/// 目的：WO_PackOrder实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/6/16
	/// </summary>
	public sealed class PackOrderCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public PackOrderCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public PackOrderCtl(IDBTransAccess p_SqlCmd)
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
                PackOrder MasterEntity=(PackOrder)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_PackOrder(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("MakeOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				MasterField.Append("MakeDate"+","); 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SaleProcedureID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleProcedureID)+","); 
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("ShopID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShopID)+","); 
  				MasterField.Append("SaleProcedureFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleProcedureFormNo)+","); 
  				MasterField.Append("CompactNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompactNo)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("CWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CWeight)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("ReqDate"+","); 
  				if(MasterEntity.ReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CWidth)+","); 
  				MasterField.Append("PrintItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintItemName)+","); 
  				MasterField.Append("PrintGoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintGoodsCode)+","); 
  				MasterField.Append("PrintRemark1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintRemark1)+","); 
  				MasterField.Append("PrintRemark2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintRemark2)+","); 
  				MasterField.Append("PrintRemark3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintRemark3)+","); 
  				MasterField.Append("PrintRemark4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintRemark4)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("Needle"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Needle)+")"); 
 
                
                

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
                PackOrder MasterEntity=(PackOrder)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_PackOrder SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				UpdateBuilder.Append(" MakeOPName="+SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" SaleProcedureID="+SysString.ToDBString(MasterEntity.SaleProcedureID)+","); 
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" ShopID="+SysString.ToDBString(MasterEntity.ShopID)+","); 
  				UpdateBuilder.Append(" SaleProcedureFormNo="+SysString.ToDBString(MasterEntity.SaleProcedureFormNo)+","); 
  				UpdateBuilder.Append(" CompactNo="+SysString.ToDBString(MasterEntity.CompactNo)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" CWeight="+SysString.ToDBString(MasterEntity.CWeight)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				 
  				if(MasterEntity.ReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ReqDate="+SysString.ToDBString(MasterEntity.ReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReqDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" CWidth="+SysString.ToDBString(MasterEntity.CWidth)+","); 
  				UpdateBuilder.Append(" PrintItemName="+SysString.ToDBString(MasterEntity.PrintItemName)+","); 
  				UpdateBuilder.Append(" PrintGoodsCode="+SysString.ToDBString(MasterEntity.PrintGoodsCode)+","); 
  				UpdateBuilder.Append(" PrintRemark1="+SysString.ToDBString(MasterEntity.PrintRemark1)+","); 
  				UpdateBuilder.Append(" PrintRemark2="+SysString.ToDBString(MasterEntity.PrintRemark2)+","); 
  				UpdateBuilder.Append(" PrintRemark3="+SysString.ToDBString(MasterEntity.PrintRemark3)+","); 
  				UpdateBuilder.Append(" PrintRemark4="+SysString.ToDBString(MasterEntity.PrintRemark4)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" Needle="+SysString.ToDBString(MasterEntity.Needle)); 
 
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
                PackOrder MasterEntity=(PackOrder)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_PackOrder WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
