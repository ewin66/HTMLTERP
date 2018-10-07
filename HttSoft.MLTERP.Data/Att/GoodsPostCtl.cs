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
	/// 目的：Att_GoodsPost实体控制类
	/// 作者:章文强
	/// 创建日期:2014/3/20
	/// </summary>
	public sealed class GoodsPostCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public GoodsPostCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public GoodsPostCtl(IDBTransAccess p_SqlCmd)
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
                GoodsPost MasterEntity=(GoodsPost)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Att_GoodsPost(");
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
  
  				MasterField.Append("CheckOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				MasterField.Append("CheckDate"+","); 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PostComID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PostComID)+","); 
  				MasterField.Append("PostCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PostCode)+","); 
  				MasterField.Append("RecName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecName)+","); 
  				MasterField.Append("RecPhone"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecPhone)+","); 
  				MasterField.Append("PostFee"+","); 
  				if(MasterEntity.PostFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PostFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("RecAddress"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecAddress)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("JSFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JSFlag)+","); 
  				MasterField.Append("JSDate"+","); 
  				if(MasterEntity.JSDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JSDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JSFee"+","); 
  				if(MasterEntity.JSFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JSFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JSRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JSRemark)+","); 
  				MasterField.Append("FJR"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FJR)+","); 
  				MasterField.Append("PostType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PostType)+","); 
  				MasterField.Append("GOFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GOFlag)+","); 
  				MasterField.Append("SKType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SKType)+","); 
  				MasterField.Append("TotalPieceQty"+","); 
  				if(MasterEntity.TotalPieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalPieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalQty"+","); 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JJVendor"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JJVendor)+","); 
  				MasterField.Append("PostComFirst"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PostComFirst)+","); 
  				MasterField.Append("ConFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ConFormNo)+","); 
  				MasterField.Append("ConID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ConID)+","); 
  				MasterField.Append("Context"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Context)+","); 
  				MasterField.Append("PostFormType"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PostFormType)+")"); 
 
                
                

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
                GoodsPost MasterEntity=(GoodsPost)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Att_GoodsPost SET ");
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
  
  				UpdateBuilder.Append(" CheckOPID="+SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate="+SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" PostComID="+SysString.ToDBString(MasterEntity.PostComID)+","); 
  				UpdateBuilder.Append(" PostCode="+SysString.ToDBString(MasterEntity.PostCode)+","); 
  				UpdateBuilder.Append(" RecName="+SysString.ToDBString(MasterEntity.RecName)+","); 
  				UpdateBuilder.Append(" RecPhone="+SysString.ToDBString(MasterEntity.RecPhone)+","); 
  				 
  				if(MasterEntity.PostFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PostFee="+SysString.ToDBString(MasterEntity.PostFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PostFee=null,");  
  				} 
  
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" RecAddress="+SysString.ToDBString(MasterEntity.RecAddress)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" JSFlag="+SysString.ToDBString(MasterEntity.JSFlag)+","); 
  				 
  				if(MasterEntity.JSDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" JSDate="+SysString.ToDBString(MasterEntity.JSDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JSDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.JSFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" JSFee="+SysString.ToDBString(MasterEntity.JSFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JSFee=null,");  
  				} 
  
  				UpdateBuilder.Append(" JSRemark="+SysString.ToDBString(MasterEntity.JSRemark)+","); 
  				UpdateBuilder.Append(" FJR="+SysString.ToDBString(MasterEntity.FJR)+","); 
  				UpdateBuilder.Append(" PostType="+SysString.ToDBString(MasterEntity.PostType)+","); 
  				UpdateBuilder.Append(" GOFlag="+SysString.ToDBString(MasterEntity.GOFlag)+","); 
  				UpdateBuilder.Append(" SKType="+SysString.ToDBString(MasterEntity.SKType)+","); 
  				 
  				if(MasterEntity.TotalPieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalPieceQty="+SysString.ToDBString(MasterEntity.TotalPieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalPieceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty="+SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" JJVendor="+SysString.ToDBString(MasterEntity.JJVendor)+","); 
  				UpdateBuilder.Append(" PostComFirst="+SysString.ToDBString(MasterEntity.PostComFirst)+","); 
  				UpdateBuilder.Append(" ConFormNo="+SysString.ToDBString(MasterEntity.ConFormNo)+","); 
  				UpdateBuilder.Append(" ConID="+SysString.ToDBString(MasterEntity.ConID)+","); 
  				UpdateBuilder.Append(" Context="+SysString.ToDBString(MasterEntity.Context)+","); 
  				UpdateBuilder.Append(" PostFormType="+SysString.ToDBString(MasterEntity.PostFormType)); 
 
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
                GoodsPost MasterEntity=(GoodsPost)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Att_GoodsPost WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
