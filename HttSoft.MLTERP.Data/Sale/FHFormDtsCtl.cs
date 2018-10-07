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
	/// 目的：Sale_FHFormDts实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/7/6
	/// </summary>
	public sealed class FHFormDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public FHFormDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FHFormDtsCtl(IDBTransAccess p_SqlCmd)
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
                FHFormDts MasterEntity=(FHFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Sale_FHFormDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("GoodsLevel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("MWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				MasterField.Append("MWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				MasterField.Append("WeightUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("VColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				MasterField.Append("VColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorName)+","); 
  				MasterField.Append("VItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				MasterField.Append("PieceQty"+","); 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PieceQty)+","); 
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
  				MasterField.Append("SingPrice"+","); 
  				if(MasterEntity.SingPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SingPrice)+","); 
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
  
  				MasterField.Append("DtsOrderFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsOrderFormNo)+","); 
  				MasterField.Append("DtsDYFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsDYFormNo)+","); 
  				MasterField.Append("DtsSendFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsSendFlag)+","); 
  				MasterField.Append("TotalSendQty"+","); 
  				if(MasterEntity.TotalSendQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalSendQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SendDate"+","); 
  				if(MasterEntity.SendDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SendDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PackDts"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackDts)+","); 
  				MasterField.Append("FHFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FHFlag)+","); 
  				MasterField.Append("DYPrice"+","); 
  				if(MasterEntity.DYPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DYPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JarNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+","); 
  				MasterField.Append("SectionID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SectionID)+","); 
  				MasterField.Append("Batch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Batch)+","); 
  				MasterField.Append("PackFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackFlag)+","); 
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
  				MasterField.Append("InputSinglePrice"+","); 
  				if(MasterEntity.InputSinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InputSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InputAmount"+","); 
  				if(MasterEntity.InputAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InputAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InputConvertXS"+","); 
  				if(MasterEntity.InputConvertXS!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InputConvertXS)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("Remark"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+")"); 
 
                
                

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
                FHFormDts MasterEntity=(FHFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Sale_FHFormDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" GoodsLevel="+SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				UpdateBuilder.Append(" WeightUnit="+SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" VColorNum="+SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				UpdateBuilder.Append(" VColorName="+SysString.ToDBString(MasterEntity.VColorName)+","); 
  				UpdateBuilder.Append(" VItemCode="+SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty="+SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty=null,");  
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
  				 
  				if(MasterEntity.SingPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SingPrice="+SysString.ToDBString(MasterEntity.SingPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SingPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Amount="+SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Amount=null,");  
  				} 
  
  				UpdateBuilder.Append(" DtsOrderFormNo="+SysString.ToDBString(MasterEntity.DtsOrderFormNo)+","); 
  				UpdateBuilder.Append(" DtsDYFormNo="+SysString.ToDBString(MasterEntity.DtsDYFormNo)+","); 
  				UpdateBuilder.Append(" DtsSendFlag="+SysString.ToDBString(MasterEntity.DtsSendFlag)+","); 
  				 
  				if(MasterEntity.TotalSendQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalSendQty="+SysString.ToDBString(MasterEntity.TotalSendQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalSendQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.SendDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SendDate="+SysString.ToDBString(MasterEntity.SendDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SendDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" PackDts="+SysString.ToDBString(MasterEntity.PackDts)+","); 
  				UpdateBuilder.Append(" FHFlag="+SysString.ToDBString(MasterEntity.FHFlag)+","); 
  				 
  				if(MasterEntity.DYPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DYPrice="+SysString.ToDBString(MasterEntity.DYPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DYPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)+","); 
  				UpdateBuilder.Append(" SectionID="+SysString.ToDBString(MasterEntity.SectionID)+","); 
  				UpdateBuilder.Append(" Batch="+SysString.ToDBString(MasterEntity.Batch)+","); 
  				UpdateBuilder.Append(" PackFlag="+SysString.ToDBString(MasterEntity.PackFlag)+","); 
  				 
  				if(MasterEntity.InputQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputQty="+SysString.ToDBString(MasterEntity.InputQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" InputUnit="+SysString.ToDBString(MasterEntity.InputUnit)+","); 
  				 
  				if(MasterEntity.InputSinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputSinglePrice="+SysString.ToDBString(MasterEntity.InputSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputSinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.InputAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputAmount="+SysString.ToDBString(MasterEntity.InputAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.InputConvertXS!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputConvertXS="+SysString.ToDBString(MasterEntity.InputConvertXS)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputConvertXS=null,");  
  				} 
  
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)); 
 
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
                FHFormDts MasterEntity=(FHFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Sale_FHFormDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
