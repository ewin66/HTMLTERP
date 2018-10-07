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
	/// 目的：WO_FabricProcessAdd实体控制类
	/// 作者:章文强
	/// 创建日期:2014/12/2
	/// </summary>
	public sealed class FabricProcessAddCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public FabricProcessAddCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FabricProcessAddCtl(IDBTransAccess p_SqlCmd)
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
                FabricProcessAdd MasterEntity=(FabricProcessAdd)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_FabricProcessAdd(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("Signed"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Signed)+","); 
  				MasterField.Append("Desizing"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Desizing)+","); 
  				MasterField.Append("Mercerized"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Mercerized)+","); 
  				MasterField.Append("Reactive"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Reactive)+","); 
  				MasterField.Append("Pigment"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Pigment)+","); 
  				MasterField.Append("NonAzo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.NonAzo)+","); 
  				MasterField.Append("Softner"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Softner)+","); 
  				MasterField.Append("Stentering"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Stentering)+","); 
  				MasterField.Append("Sanfor"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Sanfor)+","); 
  				MasterField.Append("Waterwash"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Waterwash)+","); 
  				MasterField.Append("Airowash"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Airowash)+","); 
  				MasterField.Append("Carbonpeach"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Carbonpeach)+","); 
  				MasterField.Append("Moleskin"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Moleskin)+","); 
  				MasterField.Append("PHValue"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PHValue)+","); 
  				MasterField.Append("SL"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SL)+","); 
  				MasterField.Append("GC"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GC)+","); 
  				MasterField.Append("SC"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SC)+","); 
  				MasterField.Append("Light"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Light)+","); 
  				MasterField.Append("XSHZSLD"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XSHZSLD)+","); 
  				MasterField.Append("PillingMartindale"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PillingMartindale)+","); 
  				MasterField.Append("DSGY1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DSGY1)+","); 
  				MasterField.Append("DSGY2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DSGY2)+","); 
  				MasterField.Append("DSGY3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DSGY3)+","); 
  				MasterField.Append("DSGY4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DSGY4)+","); 
  				MasterField.Append("DSGY5"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DSGY5)+","); 
  				MasterField.Append("DSGY6"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DSGY6)+","); 
  				MasterField.Append("TensileStrength"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TensileStrength)+","); 
  				MasterField.Append("TearingStrength"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TearingStrength)+","); 
  				MasterField.Append("SeamSlippage"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SeamSlippage)+","); 
  				MasterField.Append("XSLD"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XSLD)+","); 
  				MasterField.Append("XDLD"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.XDLD)+","); 
  				MasterField.Append("WX"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WX)+","); 
  				MasterField.Append("ShipmentSample"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShipmentSample)+","); 
  				MasterField.Append("ApprovedLab"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ApprovedLab)+","); 
  				MasterField.Append("HandFeelSample"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HandFeelSample)+","); 
  				MasterField.Append("Smooth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Smooth)+","); 
  				MasterField.Append("Rough"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Rough)+","); 
  				MasterField.Append("RolledOnTube"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RolledOnTube)+","); 
  				MasterField.Append("PolyBagWrapped"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PolyBagWrapped)+","); 
  				MasterField.Append("YardFolded"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YardFolded)+","); 
  				MasterField.Append("DoublePolyBagWrapped"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DoublePolyBagWrapped)+","); 
  				MasterField.Append("CartonPack"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CartonPack)+","); 
  				MasterField.Append("ForBales"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ForBales)+")"); 
 
                
                

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
                FabricProcessAdd MasterEntity=(FabricProcessAdd)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_FabricProcessAdd SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" Signed="+SysString.ToDBString(MasterEntity.Signed)+","); 
  				UpdateBuilder.Append(" Desizing="+SysString.ToDBString(MasterEntity.Desizing)+","); 
  				UpdateBuilder.Append(" Mercerized="+SysString.ToDBString(MasterEntity.Mercerized)+","); 
  				UpdateBuilder.Append(" Reactive="+SysString.ToDBString(MasterEntity.Reactive)+","); 
  				UpdateBuilder.Append(" Pigment="+SysString.ToDBString(MasterEntity.Pigment)+","); 
  				UpdateBuilder.Append(" NonAzo="+SysString.ToDBString(MasterEntity.NonAzo)+","); 
  				UpdateBuilder.Append(" Softner="+SysString.ToDBString(MasterEntity.Softner)+","); 
  				UpdateBuilder.Append(" Stentering="+SysString.ToDBString(MasterEntity.Stentering)+","); 
  				UpdateBuilder.Append(" Sanfor="+SysString.ToDBString(MasterEntity.Sanfor)+","); 
  				UpdateBuilder.Append(" Waterwash="+SysString.ToDBString(MasterEntity.Waterwash)+","); 
  				UpdateBuilder.Append(" Airowash="+SysString.ToDBString(MasterEntity.Airowash)+","); 
  				UpdateBuilder.Append(" Carbonpeach="+SysString.ToDBString(MasterEntity.Carbonpeach)+","); 
  				UpdateBuilder.Append(" Moleskin="+SysString.ToDBString(MasterEntity.Moleskin)+","); 
  				UpdateBuilder.Append(" PHValue="+SysString.ToDBString(MasterEntity.PHValue)+","); 
  				UpdateBuilder.Append(" SL="+SysString.ToDBString(MasterEntity.SL)+","); 
  				UpdateBuilder.Append(" GC="+SysString.ToDBString(MasterEntity.GC)+","); 
  				UpdateBuilder.Append(" SC="+SysString.ToDBString(MasterEntity.SC)+","); 
  				UpdateBuilder.Append(" Light="+SysString.ToDBString(MasterEntity.Light)+","); 
  				UpdateBuilder.Append(" XSHZSLD="+SysString.ToDBString(MasterEntity.XSHZSLD)+","); 
  				UpdateBuilder.Append(" PillingMartindale="+SysString.ToDBString(MasterEntity.PillingMartindale)+","); 
  				UpdateBuilder.Append(" DSGY1="+SysString.ToDBString(MasterEntity.DSGY1)+","); 
  				UpdateBuilder.Append(" DSGY2="+SysString.ToDBString(MasterEntity.DSGY2)+","); 
  				UpdateBuilder.Append(" DSGY3="+SysString.ToDBString(MasterEntity.DSGY3)+","); 
  				UpdateBuilder.Append(" DSGY4="+SysString.ToDBString(MasterEntity.DSGY4)+","); 
  				UpdateBuilder.Append(" DSGY5="+SysString.ToDBString(MasterEntity.DSGY5)+","); 
  				UpdateBuilder.Append(" DSGY6="+SysString.ToDBString(MasterEntity.DSGY6)+","); 
  				UpdateBuilder.Append(" TensileStrength="+SysString.ToDBString(MasterEntity.TensileStrength)+","); 
  				UpdateBuilder.Append(" TearingStrength="+SysString.ToDBString(MasterEntity.TearingStrength)+","); 
  				UpdateBuilder.Append(" SeamSlippage="+SysString.ToDBString(MasterEntity.SeamSlippage)+","); 
  				UpdateBuilder.Append(" XSLD="+SysString.ToDBString(MasterEntity.XSLD)+","); 
  				UpdateBuilder.Append(" XDLD="+SysString.ToDBString(MasterEntity.XDLD)+","); 
  				UpdateBuilder.Append(" WX="+SysString.ToDBString(MasterEntity.WX)+","); 
  				UpdateBuilder.Append(" ShipmentSample="+SysString.ToDBString(MasterEntity.ShipmentSample)+","); 
  				UpdateBuilder.Append(" ApprovedLab="+SysString.ToDBString(MasterEntity.ApprovedLab)+","); 
  				UpdateBuilder.Append(" HandFeelSample="+SysString.ToDBString(MasterEntity.HandFeelSample)+","); 
  				UpdateBuilder.Append(" Smooth="+SysString.ToDBString(MasterEntity.Smooth)+","); 
  				UpdateBuilder.Append(" Rough="+SysString.ToDBString(MasterEntity.Rough)+","); 
  				UpdateBuilder.Append(" RolledOnTube="+SysString.ToDBString(MasterEntity.RolledOnTube)+","); 
  				UpdateBuilder.Append(" PolyBagWrapped="+SysString.ToDBString(MasterEntity.PolyBagWrapped)+","); 
  				UpdateBuilder.Append(" YardFolded="+SysString.ToDBString(MasterEntity.YardFolded)+","); 
  				UpdateBuilder.Append(" DoublePolyBagWrapped="+SysString.ToDBString(MasterEntity.DoublePolyBagWrapped)+","); 
  				UpdateBuilder.Append(" CartonPack="+SysString.ToDBString(MasterEntity.CartonPack)+","); 
  				UpdateBuilder.Append(" ForBales="+SysString.ToDBString(MasterEntity.ForBales)); 
 
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
                FabricProcessAdd MasterEntity=(FabricProcessAdd)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_FabricProcessAdd WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
