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
	/// 目的：Sale_QuotedPrice实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/7/30
	/// </summary>
	public sealed class QuotedPriceCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public QuotedPriceCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public QuotedPriceCtl(IDBTransAccess p_SqlCmd)
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
                QuotedPrice MasterEntity=(QuotedPrice)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_QuotedPrice(");
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
  
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("VendorOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorOPName)+","); 
  				MasterField.Append("EffDate"+","); 
  				if(MasterEntity.EffDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.EffDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PriceContext"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PriceContext)+","); 
  				MasterField.Append("TradeType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TradeType)+","); 
  				MasterField.Append("AddPer"+","); 
  				if(MasterEntity.AddPer!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddPer)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("EffTime"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.EffTime)+","); 
  				MasterField.Append("HL"+","); 
  				if(MasterEntity.HL!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HL)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TradeWay"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TradeWay)+","); 
  				MasterField.Append("PayMethodFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PayMethodFlag)+","); 
  				MasterField.Append("TransportWay"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TransportWay)+","); 
  				MasterField.Append("SelvageReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SelvageReq)+","); 
  				MasterField.Append("DyeReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DyeReq)+","); 
  				MasterField.Append("ArrangeReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ArrangeReq)+","); 
  				MasterField.Append("PackReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackReq)+","); 
  				MasterField.Append("QualityReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.QualityReq)+","); 
  				MasterField.Append("DeliveryReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DeliveryReq)+","); 
  				MasterField.Append("OtherReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OtherReq)+","); 
  				MasterField.Append("VAddress"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VAddress)+","); 
  				MasterField.Append("VTelephone"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VTelephone)+","); 
  				MasterField.Append("VFax"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VFax)+","); 
  				MasterField.Append("VEmail"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VEmail)+","); 
  				MasterField.Append("JiaoQi"+","); 
  				if(MasterEntity.JiaoQi!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JiaoQi.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YongJing"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YongJing)+","); 
  				MasterField.Append("GangKou"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GangKou)+","); 
  				MasterField.Append("KHType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.KHType)+","); 
  				MasterField.Append("ZZMarket"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZZMarket)+","); 
  				MasterField.Append("AuditTime"+","); 
  				if(MasterEntity.AuditTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AuditTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BJSaleOPID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BJSaleOPID)+")"); 
 
                
                

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
                QuotedPrice MasterEntity=(QuotedPrice)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_QuotedPrice SET ");
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
  
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" VendorOPName="+SysString.ToDBString(MasterEntity.VendorOPName)+","); 
  				 
  				if(MasterEntity.EffDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" EffDate="+SysString.ToDBString(MasterEntity.EffDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" EffDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" PriceContext="+SysString.ToDBString(MasterEntity.PriceContext)+","); 
  				UpdateBuilder.Append(" TradeType="+SysString.ToDBString(MasterEntity.TradeType)+","); 
  				 
  				if(MasterEntity.AddPer!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddPer="+SysString.ToDBString(MasterEntity.AddPer)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddPer=null,");  
  				} 
  
  				UpdateBuilder.Append(" EffTime="+SysString.ToDBString(MasterEntity.EffTime)+","); 
  				 
  				if(MasterEntity.HL!=0) 
  				{ 
  			 		UpdateBuilder.Append(" HL="+SysString.ToDBString(MasterEntity.HL)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HL=null,");  
  				} 
  
  				UpdateBuilder.Append(" TradeWay="+SysString.ToDBString(MasterEntity.TradeWay)+","); 
  				UpdateBuilder.Append(" PayMethodFlag="+SysString.ToDBString(MasterEntity.PayMethodFlag)+","); 
  				UpdateBuilder.Append(" TransportWay="+SysString.ToDBString(MasterEntity.TransportWay)+","); 
  				UpdateBuilder.Append(" SelvageReq="+SysString.ToDBString(MasterEntity.SelvageReq)+","); 
  				UpdateBuilder.Append(" DyeReq="+SysString.ToDBString(MasterEntity.DyeReq)+","); 
  				UpdateBuilder.Append(" ArrangeReq="+SysString.ToDBString(MasterEntity.ArrangeReq)+","); 
  				UpdateBuilder.Append(" PackReq="+SysString.ToDBString(MasterEntity.PackReq)+","); 
  				UpdateBuilder.Append(" QualityReq="+SysString.ToDBString(MasterEntity.QualityReq)+","); 
  				UpdateBuilder.Append(" DeliveryReq="+SysString.ToDBString(MasterEntity.DeliveryReq)+","); 
  				UpdateBuilder.Append(" OtherReq="+SysString.ToDBString(MasterEntity.OtherReq)+","); 
  				UpdateBuilder.Append(" VAddress="+SysString.ToDBString(MasterEntity.VAddress)+","); 
  				UpdateBuilder.Append(" VTelephone="+SysString.ToDBString(MasterEntity.VTelephone)+","); 
  				UpdateBuilder.Append(" VFax="+SysString.ToDBString(MasterEntity.VFax)+","); 
  				UpdateBuilder.Append(" VEmail="+SysString.ToDBString(MasterEntity.VEmail)+","); 
  				 
  				if(MasterEntity.JiaoQi!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" JiaoQi="+SysString.ToDBString(MasterEntity.JiaoQi.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JiaoQi=null,");  
  				} 
  
  				UpdateBuilder.Append(" YongJing="+SysString.ToDBString(MasterEntity.YongJing)+","); 
  				UpdateBuilder.Append(" GangKou="+SysString.ToDBString(MasterEntity.GangKou)+","); 
  				UpdateBuilder.Append(" KHType="+SysString.ToDBString(MasterEntity.KHType)+","); 
  				UpdateBuilder.Append(" ZZMarket="+SysString.ToDBString(MasterEntity.ZZMarket)+","); 
  				 
  				if(MasterEntity.AuditTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" AuditTime="+SysString.ToDBString(MasterEntity.AuditTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AuditTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" BJSaleOPID="+SysString.ToDBString(MasterEntity.BJSaleOPID)); 
 
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
                QuotedPrice MasterEntity=(QuotedPrice)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sale_QuotedPrice WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
