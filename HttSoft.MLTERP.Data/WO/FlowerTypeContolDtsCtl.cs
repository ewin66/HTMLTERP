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
	/// 目的：Data_FlowerTypeContolDts实体控制类
	/// 作者:丛远晶
	/// 创建日期:2012/5/24
	/// </summary>
	public sealed class FlowerTypeContolDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public FlowerTypeContolDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FlowerTypeContolDtsCtl(IDBTransAccess p_SqlCmd)
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
                FlowerTypeContolDts MasterEntity=(FlowerTypeContolDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_FlowerTypeContolDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("ColorCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorCode)+","); 
  				MasterField.Append("Freestr1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr1)+","); 
  				MasterField.Append("Freestr2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr2)+","); 
  				MasterField.Append("Freestr3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr3)+","); 
  				MasterField.Append("Freestr4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr4)+","); 
  				MasterField.Append("Freestr5"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr5)+","); 
  				MasterField.Append("Freestr6"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr6)+","); 
  				MasterField.Append("Freestr7"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr7)+","); 
  				MasterField.Append("Freestr8"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr8)+","); 
  				MasterField.Append("Freestr9"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr9)+","); 
  				MasterField.Append("Freestr10"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr10)+","); 
  				MasterField.Append("Freestr11"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr11)+","); 
  				MasterField.Append("Freestr12"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr12)+","); 
  				MasterField.Append("Freestr13"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr13)+","); 
  				MasterField.Append("Freestr14"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr14)+","); 
  				MasterField.Append("Freestr15"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Freestr15)+")"); 
 
                
                

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
                FlowerTypeContolDts MasterEntity=(FlowerTypeContolDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_FlowerTypeContolDts SET ");
                UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ColorCode="+SysString.ToDBString(MasterEntity.ColorCode)+","); 
  				UpdateBuilder.Append(" Freestr1="+SysString.ToDBString(MasterEntity.Freestr1)+","); 
  				UpdateBuilder.Append(" Freestr2="+SysString.ToDBString(MasterEntity.Freestr2)+","); 
  				UpdateBuilder.Append(" Freestr3="+SysString.ToDBString(MasterEntity.Freestr3)+","); 
  				UpdateBuilder.Append(" Freestr4="+SysString.ToDBString(MasterEntity.Freestr4)+","); 
  				UpdateBuilder.Append(" Freestr5="+SysString.ToDBString(MasterEntity.Freestr5)+","); 
  				UpdateBuilder.Append(" Freestr6="+SysString.ToDBString(MasterEntity.Freestr6)+","); 
  				UpdateBuilder.Append(" Freestr7="+SysString.ToDBString(MasterEntity.Freestr7)+","); 
  				UpdateBuilder.Append(" Freestr8="+SysString.ToDBString(MasterEntity.Freestr8)+","); 
  				UpdateBuilder.Append(" Freestr9="+SysString.ToDBString(MasterEntity.Freestr9)+","); 
  				UpdateBuilder.Append(" Freestr10="+SysString.ToDBString(MasterEntity.Freestr10)+","); 
  				UpdateBuilder.Append(" Freestr11="+SysString.ToDBString(MasterEntity.Freestr11)+","); 
  				UpdateBuilder.Append(" Freestr12="+SysString.ToDBString(MasterEntity.Freestr12)+","); 
  				UpdateBuilder.Append(" Freestr13="+SysString.ToDBString(MasterEntity.Freestr13)+","); 
  				UpdateBuilder.Append(" Freestr14="+SysString.ToDBString(MasterEntity.Freestr14)+","); 
  				UpdateBuilder.Append(" Freestr15="+SysString.ToDBString(MasterEntity.Freestr15)); 
 
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
                FlowerTypeContolDts MasterEntity=(FlowerTypeContolDts)p_Entity;
                if (MasterEntity.MainID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_FlowerTypeContolDts WHERE "+ "MainID="+SysString.ToDBString(MasterEntity.MainID)+" AND Seq="+SysString.ToDBString(MasterEntity.Seq);
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
