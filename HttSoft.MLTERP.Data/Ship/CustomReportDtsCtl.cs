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
	/// 目的：Ship_CustomReportDts实体控制类
	/// 作者:鲁帆
	/// 创建日期:2015/3/26
	/// </summary>
	public sealed class CustomReportDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public CustomReportDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CustomReportDtsCtl(IDBTransAccess p_SqlCmd)
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
                CustomReportDts MasterEntity=(CustomReportDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Ship_CustomReportDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("GoodNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodNo)+","); 
  				MasterField.Append("Description"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Description)+","); 
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
  				MasterField.Append("UnitPrice"+","); 
  				if(MasterEntity.UnitPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.UnitPrice)+","); 
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
  
  				MasterField.Append("ILeftQty"+","); 
  				if(MasterEntity.ILeftQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ILeftQty)+","); 
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
  
  				MasterField.Append("ILeftAmount"+","); 
  				if(MasterEntity.ILeftAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ILeftAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SCQty"+","); 
  				if(MasterEntity.SCQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SCQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SCAmount"+","); 
  				if(MasterEntity.SCAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SCAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BGFY"+","); 
  				if(MasterEntity.BGFY!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BGFY)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BGFY2"+","); 
  				if(MasterEntity.BGFY2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BGFY2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BGFY3"+","); 
  				if(MasterEntity.BGFY3!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BGFY3)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BGFY4"+","); 
  				if(MasterEntity.BGFY4!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BGFY4)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BGFY5"+","); 
  				if(MasterEntity.BGFY5!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BGFY5)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Country"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Country)+","); 
  				MasterField.Append("ZM"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZM)+","); 
  				MasterField.Append("Model"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Model)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("KGUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.KGUnit)+","); 
  				MasterField.Append("AmountUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AmountUnit)+","); 
  				MasterField.Append("AmountEnUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AmountEnUnit)+","); 
  				MasterField.Append("NetQty"+","); 
  				if(MasterEntity.NetQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NetQty)+","); 
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
  
  				MasterField.Append("Size1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Size1)+","); 
  				MasterField.Append("Size2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Size2)+","); 
  				MasterField.Append("Size3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Size3)+","); 
  				MasterField.Append("Size4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Size4)+","); 
  				MasterField.Append("Size5"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Size5)+","); 
  				MasterField.Append("Size6"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Size6)+","); 
  				MasterField.Append("length1"+","); 
  				if(MasterEntity.length1!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.length1)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("length2"+","); 
  				if(MasterEntity.length2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.length2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("length3"+","); 
  				if(MasterEntity.length3!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.length3)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("length4"+","); 
  				if(MasterEntity.length4!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.length4)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("length5"+","); 
  				if(MasterEntity.length5!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.length5)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("length6"+","); 
  				if(MasterEntity.length6!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.length6)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Size7"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Size7)+","); 
  				MasterField.Append("Size8"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Size8)+","); 
  				MasterField.Append("length7"+","); 
  				if(MasterEntity.length7!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.length7)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("length8"+")"); 
  				if(MasterEntity.length8!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.length8)+")"); 
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
                CustomReportDts MasterEntity=(CustomReportDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Ship_CustomReportDts SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" GoodNo="+SysString.ToDBString(MasterEntity.GoodNo)+","); 
  				UpdateBuilder.Append(" Description="+SysString.ToDBString(MasterEntity.Description)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				 
  				if(MasterEntity.UnitPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" UnitPrice="+SysString.ToDBString(MasterEntity.UnitPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" UnitPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.ICheckedQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ICheckedQty="+SysString.ToDBString(MasterEntity.ICheckedQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ICheckedQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.ILeftQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ILeftQty="+SysString.ToDBString(MasterEntity.ILeftQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ILeftQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.ICheckedAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ICheckedAmount="+SysString.ToDBString(MasterEntity.ICheckedAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ICheckedAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.ILeftAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ILeftAmount="+SysString.ToDBString(MasterEntity.ILeftAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ILeftAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.SCQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SCQty="+SysString.ToDBString(MasterEntity.SCQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SCQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.SCAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SCAmount="+SysString.ToDBString(MasterEntity.SCAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SCAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.BGFY!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BGFY="+SysString.ToDBString(MasterEntity.BGFY)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BGFY=null,");  
  				} 
  
  				 
  				if(MasterEntity.BGFY2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BGFY2="+SysString.ToDBString(MasterEntity.BGFY2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BGFY2=null,");  
  				} 
  
  				 
  				if(MasterEntity.BGFY3!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BGFY3="+SysString.ToDBString(MasterEntity.BGFY3)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BGFY3=null,");  
  				} 
  
  				 
  				if(MasterEntity.BGFY4!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BGFY4="+SysString.ToDBString(MasterEntity.BGFY4)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BGFY4=null,");  
  				} 
  
  				 
  				if(MasterEntity.BGFY5!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BGFY5="+SysString.ToDBString(MasterEntity.BGFY5)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BGFY5=null,");  
  				} 
  
  				UpdateBuilder.Append(" Country="+SysString.ToDBString(MasterEntity.Country)+","); 
  				UpdateBuilder.Append(" ZM="+SysString.ToDBString(MasterEntity.ZM)+","); 
  				UpdateBuilder.Append(" Model="+SysString.ToDBString(MasterEntity.Model)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" KGUnit="+SysString.ToDBString(MasterEntity.KGUnit)+","); 
  				UpdateBuilder.Append(" AmountUnit="+SysString.ToDBString(MasterEntity.AmountUnit)+","); 
  				UpdateBuilder.Append(" AmountEnUnit="+SysString.ToDBString(MasterEntity.AmountEnUnit)+","); 
  				 
  				if(MasterEntity.NetQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NetQty="+SysString.ToDBString(MasterEntity.NetQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NetQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Amount="+SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Amount=null,");  
  				} 
  
  				UpdateBuilder.Append(" Size1="+SysString.ToDBString(MasterEntity.Size1)+","); 
  				UpdateBuilder.Append(" Size2="+SysString.ToDBString(MasterEntity.Size2)+","); 
  				UpdateBuilder.Append(" Size3="+SysString.ToDBString(MasterEntity.Size3)+","); 
  				UpdateBuilder.Append(" Size4="+SysString.ToDBString(MasterEntity.Size4)+","); 
  				UpdateBuilder.Append(" Size5="+SysString.ToDBString(MasterEntity.Size5)+","); 
  				UpdateBuilder.Append(" Size6="+SysString.ToDBString(MasterEntity.Size6)+","); 
  				 
  				if(MasterEntity.length1!=0) 
  				{ 
  			 		UpdateBuilder.Append(" length1="+SysString.ToDBString(MasterEntity.length1)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" length1=null,");  
  				} 
  
  				 
  				if(MasterEntity.length2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" length2="+SysString.ToDBString(MasterEntity.length2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" length2=null,");  
  				} 
  
  				 
  				if(MasterEntity.length3!=0) 
  				{ 
  			 		UpdateBuilder.Append(" length3="+SysString.ToDBString(MasterEntity.length3)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" length3=null,");  
  				} 
  
  				 
  				if(MasterEntity.length4!=0) 
  				{ 
  			 		UpdateBuilder.Append(" length4="+SysString.ToDBString(MasterEntity.length4)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" length4=null,");  
  				} 
  
  				 
  				if(MasterEntity.length5!=0) 
  				{ 
  			 		UpdateBuilder.Append(" length5="+SysString.ToDBString(MasterEntity.length5)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" length5=null,");  
  				} 
  
  				 
  				if(MasterEntity.length6!=0) 
  				{ 
  			 		UpdateBuilder.Append(" length6="+SysString.ToDBString(MasterEntity.length6)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" length6=null,");  
  				} 
  
  				UpdateBuilder.Append(" Size7="+SysString.ToDBString(MasterEntity.Size7)+","); 
  				UpdateBuilder.Append(" Size8="+SysString.ToDBString(MasterEntity.Size8)+","); 
  				 
  				if(MasterEntity.length7!=0) 
  				{ 
  			 		UpdateBuilder.Append(" length7="+SysString.ToDBString(MasterEntity.length7)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" length7=null,");  
  				} 
  
  				 
  				if(MasterEntity.length8!=0) 
  				{ 
  			 		UpdateBuilder.Append(" length8="+SysString.ToDBString(MasterEntity.length8)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" length8=null");  
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
                CustomReportDts MasterEntity=(CustomReportDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Ship_CustomReportDts WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq);
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
