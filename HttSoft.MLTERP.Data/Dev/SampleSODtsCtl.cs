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
	/// 目的：Dev_SampleSODts实体控制类
	/// 作者:邱继中
	/// 创建日期:2014/6/9
	/// </summary>
	public sealed class SampleSODtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public SampleSODtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SampleSODtsCtl(IDBTransAccess p_SqlCmd)
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
                SampleSODts MasterEntity=(SampleSODts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Dev_SampleSODts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
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
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("MWidth"+","); 
  				if(MasterEntity.MWidth!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MWeight"+","); 
  				if(MasterEntity.MWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WeightUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				MasterField.Append("DesignNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DesignNo)+","); 
  				MasterField.Append("DesignType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DesignType)+","); 
  				MasterField.Append("VendorItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorItemCode)+","); 
  				MasterField.Append("BFabirPZ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BFabirPZ)+","); 
  				MasterField.Append("XHXPZ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XHXPZ)+","); 
  				MasterField.Append("BFabricColor"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BFabricColor)+","); 
  				MasterField.Append("XHXColor"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XHXColor)+","); 
  				MasterField.Append("XHXType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XHXType)+","); 
  				MasterField.Append("XHMWidth"+","); 
  				if(MasterEntity.XHMWidth!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.XHMWidth)+","); 
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
                SampleSODts MasterEntity=(SampleSODts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Dev_SampleSODts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				 
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
  			 		UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MWeight=null,");  
  				} 
  
  				UpdateBuilder.Append(" WeightUnit="+SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				UpdateBuilder.Append(" DesignNo="+SysString.ToDBString(MasterEntity.DesignNo)+","); 
  				UpdateBuilder.Append(" DesignType="+SysString.ToDBString(MasterEntity.DesignType)+","); 
  				UpdateBuilder.Append(" VendorItemCode="+SysString.ToDBString(MasterEntity.VendorItemCode)+","); 
  				UpdateBuilder.Append(" BFabirPZ="+SysString.ToDBString(MasterEntity.BFabirPZ)+","); 
  				UpdateBuilder.Append(" XHXPZ="+SysString.ToDBString(MasterEntity.XHXPZ)+","); 
  				UpdateBuilder.Append(" BFabricColor="+SysString.ToDBString(MasterEntity.BFabricColor)+","); 
  				UpdateBuilder.Append(" XHXColor="+SysString.ToDBString(MasterEntity.XHXColor)+","); 
  				UpdateBuilder.Append(" XHXType="+SysString.ToDBString(MasterEntity.XHXType)+","); 
  				 
  				if(MasterEntity.XHMWidth!=0) 
  				{ 
  			 		UpdateBuilder.Append(" XHMWidth="+SysString.ToDBString(MasterEntity.XHMWidth)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" XHMWidth=null,");  
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
                SampleSODts MasterEntity=(SampleSODts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Dev_SampleSODts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
