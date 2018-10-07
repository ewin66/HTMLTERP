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
	/// 目的：Att_GoodsTrans实体控制类
	/// 作者:章文强
	/// 创建日期:2012/7/15
	/// </summary>
	public sealed class GoodsTransCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public GoodsTransCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public GoodsTransCtl(IDBTransAccess p_SqlCmd)
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
                GoodsTrans MasterEntity=(GoodsTrans)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Att_GoodsTrans(");
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
  
  				MasterField.Append("SendNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SendNo)+","); 
  				MasterField.Append("TransComID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TransComID)+","); 
  				MasterField.Append("TransFee"+","); 
  				if(MasterEntity.TransFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TransFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RLFee"+","); 
  				if(MasterEntity.RLFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RLFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ShopID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShopID)+","); 
  				MasterField.Append("THFee"+","); 
  				if(MasterEntity.THFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.THFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("THAddress"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.THAddress)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("RecAddress"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RecAddress)+","); 
  				MasterField.Append("YSFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YSFlag)+","); 
  				MasterField.Append("YSTime"+","); 
  				if(MasterEntity.YSTime!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YSTime)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("FLC"+","); 
  				if(MasterEntity.FLC!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FLC)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FDT"+","); 
  				if(MasterEntity.FDT!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FDT)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FSHSJD"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FSHSJD)+","); 
  				MasterField.Append("FHWZZ"+","); 
  				if(MasterEntity.FHWZZ!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FHWZZ)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FDTJ"+","); 
  				if(MasterEntity.FDTJ!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FDTJ)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FHDFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FHDFlag)+","); 
  				MasterField.Append("FHDDate"+","); 
  				if(MasterEntity.FHDDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FHDDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
  				MasterField.Append("OtherFee"+","); 
  				if(MasterEntity.OtherFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OtherFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalAmount"+","); 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
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
  
  				MasterField.Append("SJFHDate"+")"); 
  				if(MasterEntity.SJFHDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SJFHDate.ToString("yyyy-MM-dd HH:mm:ss"))+")"); 
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
                GoodsTrans MasterEntity=(GoodsTrans)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Att_GoodsTrans SET ");
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
  
  				UpdateBuilder.Append(" SendNo="+SysString.ToDBString(MasterEntity.SendNo)+","); 
  				UpdateBuilder.Append(" TransComID="+SysString.ToDBString(MasterEntity.TransComID)+","); 
  				 
  				if(MasterEntity.TransFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TransFee="+SysString.ToDBString(MasterEntity.TransFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TransFee=null,");  
  				} 
  
  				 
  				if(MasterEntity.RLFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RLFee="+SysString.ToDBString(MasterEntity.RLFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RLFee=null,");  
  				} 
  
  				UpdateBuilder.Append(" ShopID="+SysString.ToDBString(MasterEntity.ShopID)+","); 
  				 
  				if(MasterEntity.THFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" THFee="+SysString.ToDBString(MasterEntity.THFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" THFee=null,");  
  				} 
  
  				UpdateBuilder.Append(" THAddress="+SysString.ToDBString(MasterEntity.THAddress)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" RecAddress="+SysString.ToDBString(MasterEntity.RecAddress)+","); 
  				UpdateBuilder.Append(" YSFlag="+SysString.ToDBString(MasterEntity.YSFlag)+","); 
  				 
  				if(MasterEntity.YSTime!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YSTime="+SysString.ToDBString(MasterEntity.YSTime)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YSTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.FLC!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FLC="+SysString.ToDBString(MasterEntity.FLC)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FLC=null,");  
  				} 
  
  				 
  				if(MasterEntity.FDT!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FDT="+SysString.ToDBString(MasterEntity.FDT)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FDT=null,");  
  				} 
  
  				UpdateBuilder.Append(" FSHSJD="+SysString.ToDBString(MasterEntity.FSHSJD)+","); 
  				 
  				if(MasterEntity.FHWZZ!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FHWZZ="+SysString.ToDBString(MasterEntity.FHWZZ)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FHWZZ=null,");  
  				} 
  
  				 
  				if(MasterEntity.FDTJ!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FDTJ="+SysString.ToDBString(MasterEntity.FDTJ)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FDTJ=null,");  
  				} 
  
  				UpdateBuilder.Append(" FHDFlag="+SysString.ToDBString(MasterEntity.FHDFlag)+","); 
  				 
  				if(MasterEntity.FHDDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FHDDate="+SysString.ToDBString(MasterEntity.FHDDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FHDDate=null,");  
  				} 
  
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
  				 
  				if(MasterEntity.OtherFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OtherFee="+SysString.ToDBString(MasterEntity.OtherFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OtherFee=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount="+SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount=null,");  
  				} 
  
  				 
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
  
  				 
  				if(MasterEntity.SJFHDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SJFHDate="+SysString.ToDBString(MasterEntity.SJFHDate.ToString("yyyy-MM-dd HH:mm:ss"))); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SJFHDate=null");  
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
                GoodsTrans MasterEntity=(GoodsTrans)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Att_GoodsTrans WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
