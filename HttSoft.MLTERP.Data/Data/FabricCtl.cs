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
	/// 目的：WO_Fabric实体控制类
	/// 作者:丛远晶
	/// 创建日期:2012/5/25
	/// </summary>
	public sealed class FabricCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public FabricCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FabricCtl(IDBTransAccess p_SqlCmd)
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
                Fabric MasterEntity=(Fabric)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_Fabric(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("ISN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ISN)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("JarNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+","); 
  				MasterField.Append("FlowerType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FlowerType)+","); 
  				MasterField.Append("Status"+","); 
  				if(MasterEntity.Status!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Status)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CFFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CFFlag)+","); 
  				MasterField.Append("PackFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackFlag)+","); 
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("Section"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Section)+","); 
  				MasterField.Append("Sbit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Sbit)+","); 
  				MasterField.Append("SourceISN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SourceISN)+","); 
  				MasterField.Append("IOFormID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.IOFormID)+","); 
  				MasterField.Append("IOFormSeq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.IOFormSeq)+","); 
  				MasterField.Append("BoxID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BoxID)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("StyleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				MasterField.Append("MF"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MF)+","); 
  				MasterField.Append("Weight"+","); 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PNum)+","); 
  				MasterField.Append("Shop"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Shop)+","); 
  				MasterField.Append("JTNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JTNum)+","); 
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
  
  				MasterField.Append("CheckOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckOPName)+","); 
  				MasterField.Append("CheckDate"+","); 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Length"+")"); 
  				if(MasterEntity.Length!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Length)+")"); 
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
                Fabric MasterEntity=(Fabric)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_Fabric SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" ISN="+SysString.ToDBString(MasterEntity.ISN)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)+","); 
  				UpdateBuilder.Append(" FlowerType="+SysString.ToDBString(MasterEntity.FlowerType)+","); 
  				 
  				if(MasterEntity.Status!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Status="+SysString.ToDBString(MasterEntity.Status)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Status=null,");  
  				} 
  
  				UpdateBuilder.Append(" CFFlag="+SysString.ToDBString(MasterEntity.CFFlag)+","); 
  				UpdateBuilder.Append(" PackFlag="+SysString.ToDBString(MasterEntity.PackFlag)+","); 
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				UpdateBuilder.Append(" Section="+SysString.ToDBString(MasterEntity.Section)+","); 
  				UpdateBuilder.Append(" Sbit="+SysString.ToDBString(MasterEntity.Sbit)+","); 
  				UpdateBuilder.Append(" SourceISN="+SysString.ToDBString(MasterEntity.SourceISN)+","); 
  				UpdateBuilder.Append(" IOFormID="+SysString.ToDBString(MasterEntity.IOFormID)+","); 
  				UpdateBuilder.Append(" IOFormSeq="+SysString.ToDBString(MasterEntity.IOFormSeq)+","); 
  				UpdateBuilder.Append(" BoxID="+SysString.ToDBString(MasterEntity.BoxID)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" StyleNo="+SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				UpdateBuilder.Append(" MF="+SysString.ToDBString(MasterEntity.MF)+","); 
  				 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Weight="+SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Weight=null,");  
  				} 
  
  				UpdateBuilder.Append(" PNum="+SysString.ToDBString(MasterEntity.PNum)+","); 
  				UpdateBuilder.Append(" Shop="+SysString.ToDBString(MasterEntity.Shop)+","); 
  				UpdateBuilder.Append(" JTNum="+SysString.ToDBString(MasterEntity.JTNum)+","); 
  				UpdateBuilder.Append(" MakeOPName="+SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" CheckOPName="+SysString.ToDBString(MasterEntity.CheckOPName)+","); 
  				 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate="+SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.Length!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Length="+SysString.ToDBString(MasterEntity.Length)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Length=null");  
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
                Fabric MasterEntity=(Fabric)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_Fabric WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
