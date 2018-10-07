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
	/// 目的：Ship_CustomInvoiceDts实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/7/23
	/// </summary>
	public sealed class CustomInvoiceDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public CustomInvoiceDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CustomInvoiceDtsCtl(IDBTransAccess p_SqlCmd)
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
                CustomInvoiceDts MasterEntity=(CustomInvoiceDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Ship_CustomInvoiceDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("PackPlanID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackPlanID)+","); 
  				MasterField.Append("PackPlanCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackPlanCode)+","); 
  				MasterField.Append("DSN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DSN)+","); 
  				MasterField.Append("SSN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SSN)+","); 
  				MasterField.Append("StyleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				MasterField.Append("SStyleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SStyleNo)+","); 
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ICheckedQty"+","); 
  				if(MasterEntity.ICheckedQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ICheckedQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ICheckedAmount"+","); 
  				if(MasterEntity.ICheckedAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ICheckedAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ILeftQty"+","); 
  				if(MasterEntity.ILeftQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ILeftQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ILeftAmount"+","); 
  				if(MasterEntity.ILeftAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ILeftAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Style"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Style)+","); 
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("Country"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Country)+","); 
  				MasterField.Append("NetQty"+","); 
  				if(MasterEntity.NetQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NetQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZM)+","); 
  				MasterField.Append("NetWeight"+","); 
  				if(MasterEntity.NetWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NetWeight)+","); 
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
  
  				MasterField.Append("USPrice"+","); 
  				if(MasterEntity.USPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.USPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BoxNum"+","); 
  				if(MasterEntity.BoxNum!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BoxNum)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Model"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Model)+","); 
  				MasterField.Append("AmountUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AmountUnit)+","); 
  				MasterField.Append("PCSUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PCSUnit)+","); 
  				MasterField.Append("SinglePrice"+","); 
  				if(MasterEntity.SinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Amount"+","); 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SKAmount"+","); 
  				if(MasterEntity.SKAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SKAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SKDate"+","); 
  				if(MasterEntity.SKDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SKDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SKOP"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SKOP)+","); 
  				MasterField.Append("QGSinglePrice"+","); 
  				if(MasterEntity.QGSinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.QGSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("QGAmount"+","); 
  				if(MasterEntity.QGAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.QGAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("QGQty"+","); 
  				if(MasterEntity.QGQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.QGQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("PieceQty"+","); 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Volume"+","); 
  				if(MasterEntity.Volume!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Volume)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MWidth"+","); 
  				if(MasterEntity.MWidth!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MWeight"+")"); 
  				if(MasterEntity.MWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+")"); 
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
                CustomInvoiceDts MasterEntity=(CustomInvoiceDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Ship_CustomInvoiceDts SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" PackPlanID="+SysString.ToDBString(MasterEntity.PackPlanID)+","); 
  				UpdateBuilder.Append(" PackPlanCode="+SysString.ToDBString(MasterEntity.PackPlanCode)+","); 
  				UpdateBuilder.Append(" DSN="+SysString.ToDBString(MasterEntity.DSN)+","); 
  				UpdateBuilder.Append(" SSN="+SysString.ToDBString(MasterEntity.SSN)+","); 
  				UpdateBuilder.Append(" StyleNo="+SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				UpdateBuilder.Append(" SStyleNo="+SysString.ToDBString(MasterEntity.SStyleNo)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				 
  				if(MasterEntity.ICheckedQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ICheckedQty="+SysString.ToDBString(MasterEntity.ICheckedQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ICheckedQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.ICheckedAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ICheckedAmount="+SysString.ToDBString(MasterEntity.ICheckedAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ICheckedAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.ILeftQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ILeftQty="+SysString.ToDBString(MasterEntity.ILeftQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ILeftQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.ILeftAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ILeftAmount="+SysString.ToDBString(MasterEntity.ILeftAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ILeftAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" Style="+SysString.ToDBString(MasterEntity.Style)+","); 
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				UpdateBuilder.Append(" Country="+SysString.ToDBString(MasterEntity.Country)+","); 
  				 
  				if(MasterEntity.NetQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NetQty="+SysString.ToDBString(MasterEntity.NetQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NetQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" ZM="+SysString.ToDBString(MasterEntity.ZM)+","); 
  				 
  				if(MasterEntity.NetWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NetWeight="+SysString.ToDBString(MasterEntity.NetWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NetWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.GrossWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" GrossWeight="+SysString.ToDBString(MasterEntity.GrossWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" GrossWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.USPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" USPrice="+SysString.ToDBString(MasterEntity.USPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" USPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.BoxNum!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BoxNum="+SysString.ToDBString(MasterEntity.BoxNum)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BoxNum=null,");  
  				} 
  
  				UpdateBuilder.Append(" Model="+SysString.ToDBString(MasterEntity.Model)+","); 
  				UpdateBuilder.Append(" AmountUnit="+SysString.ToDBString(MasterEntity.AmountUnit)+","); 
  				UpdateBuilder.Append(" PCSUnit="+SysString.ToDBString(MasterEntity.PCSUnit)+","); 
  				 
  				if(MasterEntity.SinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SinglePrice="+SysString.ToDBString(MasterEntity.SinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Amount="+SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Amount=null,");  
  				} 
  
  				 
  				if(MasterEntity.SKAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SKAmount="+SysString.ToDBString(MasterEntity.SKAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SKAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.SKDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SKDate="+SysString.ToDBString(MasterEntity.SKDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SKDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" SKOP="+SysString.ToDBString(MasterEntity.SKOP)+","); 
  				 
  				if(MasterEntity.QGSinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" QGSinglePrice="+SysString.ToDBString(MasterEntity.QGSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" QGSinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.QGAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" QGAmount="+SysString.ToDBString(MasterEntity.QGAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" QGAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.QGQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" QGQty="+SysString.ToDBString(MasterEntity.QGQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" QGQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty="+SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.Volume!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Volume="+SysString.ToDBString(MasterEntity.Volume)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Volume=null,");  
  				} 
  
  				 
  				if(MasterEntity.MWidth!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MWidth=null,");  
  				} 
  
  				 
  				if(MasterEntity.MWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MWeight=null");  
  				} 
  
 
                UpdateBuilder.Append(" WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq));
                
                

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
                CustomInvoiceDts MasterEntity=(CustomInvoiceDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Ship_CustomInvoiceDts WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq);
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
