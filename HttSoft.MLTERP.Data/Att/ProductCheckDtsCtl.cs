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
	/// 目的：Att_ProductCheckDts实体控制类
	/// 作者:cyj
	/// 创建日期:2013/3/4
	/// </summary>
	public sealed class ProductCheckDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ProductCheckDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ProductCheckDtsCtl(IDBTransAccess p_SqlCmd)
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
                ProductCheckDts MasterEntity=(ProductCheckDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Att_ProductCheckDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("PS"+","); 
  				if(MasterEntity.PS!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PS)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("VColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				MasterField.Append("VColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorName)+","); 
  				MasterField.Append("VItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				MasterField.Append("RecQty"+","); 
  				if(MasterEntity.RecQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RecQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckGQty"+","); 
  				if(MasterEntity.CheckGQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckGQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQty"+","); 
  				if(MasterEntity.CheckQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckCQty"+","); 
  				if(MasterEntity.CheckCQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckCQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQQty1"+","); 
  				if(MasterEntity.CheckQQty1!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQQty1)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQQty2"+","); 
  				if(MasterEntity.CheckQQty2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQQty2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQQty3"+","); 
  				if(MasterEntity.CheckQQty3!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQQty3)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQQty4"+","); 
  				if(MasterEntity.CheckQQty4!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQQty4)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQQty5"+","); 
  				if(MasterEntity.CheckQQty5!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQQty5)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQQty6"+","); 
  				if(MasterEntity.CheckQQty6!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQQty6)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQQty7"+","); 
  				if(MasterEntity.CheckQQty7!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQQty7)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQQty8"+","); 
  				if(MasterEntity.CheckQQty8!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQQty8)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckQQty9"+","); 
  				if(MasterEntity.CheckQQty9!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckQQty9)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
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
  				MasterField.Append("Unit"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+")"); 
 
                
                

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
                ProductCheckDts MasterEntity=(ProductCheckDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Att_ProductCheckDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				 
  				if(MasterEntity.PS!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PS="+SysString.ToDBString(MasterEntity.PS)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PS=null,");  
  				} 
  
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" VColorNum="+SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				UpdateBuilder.Append(" VColorName="+SysString.ToDBString(MasterEntity.VColorName)+","); 
  				UpdateBuilder.Append(" VItemCode="+SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				 
  				if(MasterEntity.RecQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RecQty="+SysString.ToDBString(MasterEntity.RecQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RecQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckGQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckGQty="+SysString.ToDBString(MasterEntity.CheckGQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckGQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQty="+SysString.ToDBString(MasterEntity.CheckQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckCQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckCQty="+SysString.ToDBString(MasterEntity.CheckCQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckCQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQQty1!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty1="+SysString.ToDBString(MasterEntity.CheckQQty1)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty1=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQQty2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty2="+SysString.ToDBString(MasterEntity.CheckQQty2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty2=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQQty3!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty3="+SysString.ToDBString(MasterEntity.CheckQQty3)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty3=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQQty4!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty4="+SysString.ToDBString(MasterEntity.CheckQQty4)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty4=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQQty5!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty5="+SysString.ToDBString(MasterEntity.CheckQQty5)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty5=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQQty6!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty6="+SysString.ToDBString(MasterEntity.CheckQQty6)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty6=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQQty7!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty7="+SysString.ToDBString(MasterEntity.CheckQQty7)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty7=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQQty8!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty8="+SysString.ToDBString(MasterEntity.CheckQQty8)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty8=null,");  
  				} 
  
  				 
  				if(MasterEntity.CheckQQty9!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty9="+SysString.ToDBString(MasterEntity.CheckQQty9)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckQQty9=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
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
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)); 
 
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
                ProductCheckDts MasterEntity=(ProductCheckDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Att_ProductCheckDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
