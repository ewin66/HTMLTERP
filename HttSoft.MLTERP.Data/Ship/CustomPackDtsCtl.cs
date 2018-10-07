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
	/// 目的：Ship_CustomPackDts实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/7/23
	/// </summary>
	public sealed class CustomPackDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public CustomPackDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CustomPackDtsCtl(IDBTransAccess p_SqlCmd)
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
                CustomPackDts MasterEntity=(CustomPackDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Ship_CustomPackDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("PackPlanID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackPlanID)+","); 
  				MasterField.Append("PackPlanCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackPlanCode)+","); 
  				MasterField.Append("SSN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SSN)+","); 
  				MasterField.Append("DSN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DSN)+","); 
  				MasterField.Append("StyleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				MasterField.Append("SStyleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SStyleNo)+","); 
  				MasterField.Append("Model"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Model)+","); 
  				MasterField.Append("CtnNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CtnNo)+","); 
  				MasterField.Append("CtnQty"+","); 
  				if(MasterEntity.CtnQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CtnQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CrossWeight"+","); 
  				if(MasterEntity.CrossWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CrossWeight)+","); 
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
  
  				MasterField.Append("TotalBulk"+","); 
  				if(MasterEntity.TotalBulk!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalBulk)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Style"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Style)+","); 
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
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
                CustomPackDts MasterEntity=(CustomPackDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Ship_CustomPackDts SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" PackPlanID="+SysString.ToDBString(MasterEntity.PackPlanID)+","); 
  				UpdateBuilder.Append(" PackPlanCode="+SysString.ToDBString(MasterEntity.PackPlanCode)+","); 
  				UpdateBuilder.Append(" SSN="+SysString.ToDBString(MasterEntity.SSN)+","); 
  				UpdateBuilder.Append(" DSN="+SysString.ToDBString(MasterEntity.DSN)+","); 
  				UpdateBuilder.Append(" StyleNo="+SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				UpdateBuilder.Append(" SStyleNo="+SysString.ToDBString(MasterEntity.SStyleNo)+","); 
  				UpdateBuilder.Append(" Model="+SysString.ToDBString(MasterEntity.Model)+","); 
  				UpdateBuilder.Append(" CtnNo="+SysString.ToDBString(MasterEntity.CtnNo)+","); 
  				 
  				if(MasterEntity.CtnQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CtnQty="+SysString.ToDBString(MasterEntity.CtnQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CtnQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CrossWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CrossWeight="+SysString.ToDBString(MasterEntity.CrossWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CrossWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.NetWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NetWeight="+SysString.ToDBString(MasterEntity.NetWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NetWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalBulk!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalBulk="+SysString.ToDBString(MasterEntity.TotalBulk)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalBulk=null,");  
  				} 
  
  				UpdateBuilder.Append(" Style="+SysString.ToDBString(MasterEntity.Style)+","); 
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				 
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
                CustomPackDts MasterEntity=(CustomPackDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Ship_CustomPackDts WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq);
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
