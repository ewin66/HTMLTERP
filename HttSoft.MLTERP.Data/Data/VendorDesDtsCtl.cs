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
	/// 目的：Data_VendorDesDts实体控制类
	/// 作者:章文强
	/// 创建日期:2012/12/7
	/// </summary>
	public sealed class VendorDesDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public VendorDesDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public VendorDesDtsCtl(IDBTransAccess p_SqlCmd)
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
                VendorDesDts MasterEntity=(VendorDesDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_VendorDesDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("DCDate"+","); 
  				if(MasterEntity.DCDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DCDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Address"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Address)+","); 
  				MasterField.Append("LeftBrand"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LeftBrand)+","); 
  				MasterField.Append("RightBrand"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RightBrand)+","); 
  				MasterField.Append("TopBrand"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TopBrand)+","); 
  				MasterField.Append("ButtBrand"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ButtBrand)+","); 
  				MasterField.Append("ITEM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ITEM)+","); 
  				MasterField.Append("ItemPrice"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemPrice)+","); 
  				MasterField.Append("CFBL"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CFBL)+","); 
  				MasterField.Append("LB"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LB)+","); 
  				MasterField.Append("SX"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SX)+","); 
  				MasterField.Append("AddPS"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AddPS)+")"); 
 
                
                

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
                VendorDesDts MasterEntity=(VendorDesDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_VendorDesDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				 
  				if(MasterEntity.DCDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" DCDate="+SysString.ToDBString(MasterEntity.DCDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DCDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Address="+SysString.ToDBString(MasterEntity.Address)+","); 
  				UpdateBuilder.Append(" LeftBrand="+SysString.ToDBString(MasterEntity.LeftBrand)+","); 
  				UpdateBuilder.Append(" RightBrand="+SysString.ToDBString(MasterEntity.RightBrand)+","); 
  				UpdateBuilder.Append(" TopBrand="+SysString.ToDBString(MasterEntity.TopBrand)+","); 
  				UpdateBuilder.Append(" ButtBrand="+SysString.ToDBString(MasterEntity.ButtBrand)+","); 
  				UpdateBuilder.Append(" ITEM="+SysString.ToDBString(MasterEntity.ITEM)+","); 
  				UpdateBuilder.Append(" ItemPrice="+SysString.ToDBString(MasterEntity.ItemPrice)+","); 
  				UpdateBuilder.Append(" CFBL="+SysString.ToDBString(MasterEntity.CFBL)+","); 
  				UpdateBuilder.Append(" LB="+SysString.ToDBString(MasterEntity.LB)+","); 
  				UpdateBuilder.Append(" SX="+SysString.ToDBString(MasterEntity.SX)+","); 
  				UpdateBuilder.Append(" AddPS="+SysString.ToDBString(MasterEntity.AddPS)); 
 
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
                VendorDesDts MasterEntity=(VendorDesDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_VendorDesDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
