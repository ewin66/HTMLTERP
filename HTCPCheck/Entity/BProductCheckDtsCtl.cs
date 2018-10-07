using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;

namespace HttSoft.HTCPCheck.DataCtl
{
	/// <summary>
	/// 目的：WO_BProductCheckDts实体控制类
	/// 作者:周富春
	/// 创建日期:2015/5/7
	/// </summary>
	public sealed class BProductCheckDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public BProductCheckDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public BProductCheckDtsCtl(IDBTransAccess p_SqlCmd)
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
                BProductCheckDts MasterEntity=(BProductCheckDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_BProductCheckDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("DISN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DISN)+","); 
  				MasterField.Append("StatusID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StatusID)+","); 
  				MasterField.Append("Fault"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Fault)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YQty"+","); 
  				if(MasterEntity.YQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Weight"+","); 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YWeight"+","); 
  				if(MasterEntity.YWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CJQty"+","); 
  				if(MasterEntity.CJQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CJQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FMQty"+","); 
  				if(MasterEntity.FMQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FMQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SO)+","); 
  				MasterField.Append("CompactNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompactNo)+","); 
  				MasterField.Append("DLever"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLever)+","); 
  				MasterField.Append("Deduction"+","); 
  				if(MasterEntity.Deduction!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Deduction)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MQty1"+","); 
  				if(MasterEntity.MQty1!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MQty1)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MQty2"+","); 
  				if(MasterEntity.MQty2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MQty2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MQty3"+","); 
  				if(MasterEntity.MQty3!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MQty3)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MQty4"+","); 
  				if(MasterEntity.MQty4!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MQty4)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MQty5"+","); 
  				if(MasterEntity.MQty5!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MQty5)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RepairFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RepairFlag)+","); 
  				MasterField.Append("RepairCount"+","); 
  				if(MasterEntity.RepairCount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RepairCount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InitialISN"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InitialISN)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("RepairReason"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.RepairReason)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("JarNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+","); 
  				MasterField.Append("ShopID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShopID)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("JarCount"+","); 
  				if(MasterEntity.JarCount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JarCount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MaXIndex"+","); 
  				if(MasterEntity.MaXIndex!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MaXIndex)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("VColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorName)+","); 
  				MasterField.Append("VColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				MasterField.Append("CheckDate"+","); 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				MasterField.Append("MF"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MF)+","); 
  				MasterField.Append("KZ"+","); 
  				if(MasterEntity.KZ!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.KZ)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZNMF"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZNMF)+","); 
  				MasterField.Append("XMQty"+","); 
  				if(MasterEntity.XMQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.XMQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BMKF"+","); 
  				if(MasterEntity.BMKF!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BMKF)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JYBZ"+","); 
  				if(MasterEntity.JYBZ!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JYBZ)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CY"+","); 
  				if(MasterEntity.CY!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CY)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CJZC"+","); 
  				if(MasterEntity.CJZC!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CJZC)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CJRC"+","); 
  				if(MasterEntity.CJRC!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CJRC)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WX"+","); 
  				if(MasterEntity.WX!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.WX)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ZCKF"+","); 
  				if(MasterEntity.ZCKF!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ZCKF)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RCKF"+","); 
  				if(MasterEntity.RCKF!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RCKF)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("KF"+","); 
  				if(MasterEntity.KF!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.KF)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PF"+","); 
  				if(MasterEntity.PF!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PF)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FactoryCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FactoryCode)+","); 
  				MasterField.Append("JarNumCount"+","); 
  				if(MasterEntity.JarNumCount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JarNumCount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("YM"+","); 
  				if(MasterEntity.YM!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.YM)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SM"+","); 
  				if(MasterEntity.SM!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SM)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JSUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JSUnit)+","); 
  				MasterField.Append("PT"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PT)+","); 
  				MasterField.Append("ZG"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ZG)+","); 
  				MasterField.Append("GZ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GZ)+","); 
  				MasterField.Append("FMZC"+","); 
  				if(MasterEntity.FMZC!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FMZC)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FMRC"+","); 
  				if(MasterEntity.FMRC!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FMRC)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SectionID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SectionID)+","); 
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("MQty"+","); 
  				if(MasterEntity.MQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MQty)+","); 
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
  
  				MasterField.Append("KF20"+","); 
  				if(MasterEntity.KF20!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.KF20)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("KF22"+","); 
  				if(MasterEntity.KF22!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.KF22)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("KF24"+","); 
  				if(MasterEntity.KF24!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.KF24)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("KF25"+","); 
  				if(MasterEntity.KF25!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.KF25)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InWHFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InWHFlag)+","); 
  				MasterField.Append("SJQty"+","); 
  				if(MasterEntity.SJQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SJQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JarNo"+","); 
  				if(MasterEntity.JarNo!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JarNo)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("GoodsLevel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
  				MasterField.Append("PrintItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintItemName)+","); 
  				MasterField.Append("PrintGoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintGoodsCode)+","); 
  				MasterField.Append("PrintCD"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintCD)+","); 
  				MasterField.Append("PrintRemark1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintRemark1)+","); 
  				MasterField.Append("PrintRemark2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintRemark2)+","); 
  				MasterField.Append("PrintRemark3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintRemark3)+","); 
  				MasterField.Append("PrintRemark4"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintRemark4)+")"); 
 
                
                

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
                BProductCheckDts MasterEntity=(BProductCheckDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_BProductCheckDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" DISN="+SysString.ToDBString(MasterEntity.DISN)+","); 
  				UpdateBuilder.Append(" StatusID="+SysString.ToDBString(MasterEntity.StatusID)+","); 
  				UpdateBuilder.Append(" Fault="+SysString.ToDBString(MasterEntity.Fault)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				 
  				if(MasterEntity.YQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YQty="+SysString.ToDBString(MasterEntity.YQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Weight="+SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Weight=null,");  
  				} 
  
  				 
  				if(MasterEntity.YWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YWeight="+SysString.ToDBString(MasterEntity.YWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.CJQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CJQty="+SysString.ToDBString(MasterEntity.CJQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CJQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.FMQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FMQty="+SysString.ToDBString(MasterEntity.FMQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FMQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" SO="+SysString.ToDBString(MasterEntity.SO)+","); 
  				UpdateBuilder.Append(" CompactNo="+SysString.ToDBString(MasterEntity.CompactNo)+","); 
  				UpdateBuilder.Append(" DLever="+SysString.ToDBString(MasterEntity.DLever)+","); 
  				 
  				if(MasterEntity.Deduction!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Deduction="+SysString.ToDBString(MasterEntity.Deduction)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Deduction=null,");  
  				} 
  
  				 
  				if(MasterEntity.MQty1!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MQty1="+SysString.ToDBString(MasterEntity.MQty1)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MQty1=null,");  
  				} 
  
  				 
  				if(MasterEntity.MQty2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MQty2="+SysString.ToDBString(MasterEntity.MQty2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MQty2=null,");  
  				} 
  
  				 
  				if(MasterEntity.MQty3!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MQty3="+SysString.ToDBString(MasterEntity.MQty3)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MQty3=null,");  
  				} 
  
  				 
  				if(MasterEntity.MQty4!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MQty4="+SysString.ToDBString(MasterEntity.MQty4)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MQty4=null,");  
  				} 
  
  				 
  				if(MasterEntity.MQty5!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MQty5="+SysString.ToDBString(MasterEntity.MQty5)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MQty5=null,");  
  				} 
  
  				UpdateBuilder.Append(" RepairFlag="+SysString.ToDBString(MasterEntity.RepairFlag)+","); 
  				 
  				if(MasterEntity.RepairCount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RepairCount="+SysString.ToDBString(MasterEntity.RepairCount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RepairCount=null,");  
  				} 
  
  				UpdateBuilder.Append(" InitialISN="+SysString.ToDBString(MasterEntity.InitialISN)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" RepairReason="+SysString.ToDBString(MasterEntity.RepairReason)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)+","); 
  				UpdateBuilder.Append(" ShopID="+SysString.ToDBString(MasterEntity.ShopID)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				 
  				if(MasterEntity.JarCount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" JarCount="+SysString.ToDBString(MasterEntity.JarCount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JarCount=null,");  
  				} 
  
  				 
  				if(MasterEntity.MaXIndex!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MaXIndex="+SysString.ToDBString(MasterEntity.MaXIndex)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MaXIndex=null,");  
  				} 
  
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" VColorName="+SysString.ToDBString(MasterEntity.VColorName)+","); 
  				UpdateBuilder.Append(" VColorNum="+SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate="+SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" CheckOPID="+SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				UpdateBuilder.Append(" MF="+SysString.ToDBString(MasterEntity.MF)+","); 
  				 
  				if(MasterEntity.KZ!=0) 
  				{ 
  			 		UpdateBuilder.Append(" KZ="+SysString.ToDBString(MasterEntity.KZ)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" KZ=null,");  
  				} 
  
  				UpdateBuilder.Append(" ZNMF="+SysString.ToDBString(MasterEntity.ZNMF)+","); 
  				 
  				if(MasterEntity.XMQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" XMQty="+SysString.ToDBString(MasterEntity.XMQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" XMQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.BMKF!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BMKF="+SysString.ToDBString(MasterEntity.BMKF)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BMKF=null,");  
  				} 
  
  				 
  				if(MasterEntity.JYBZ!=0) 
  				{ 
  			 		UpdateBuilder.Append(" JYBZ="+SysString.ToDBString(MasterEntity.JYBZ)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JYBZ=null,");  
  				} 
  
  				 
  				if(MasterEntity.CY!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CY="+SysString.ToDBString(MasterEntity.CY)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CY=null,");  
  				} 
  
  				 
  				if(MasterEntity.CJZC!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CJZC="+SysString.ToDBString(MasterEntity.CJZC)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CJZC=null,");  
  				} 
  
  				 
  				if(MasterEntity.CJRC!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CJRC="+SysString.ToDBString(MasterEntity.CJRC)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CJRC=null,");  
  				} 
  
  				 
  				if(MasterEntity.WX!=0) 
  				{ 
  			 		UpdateBuilder.Append(" WX="+SysString.ToDBString(MasterEntity.WX)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" WX=null,");  
  				} 
  
  				 
  				if(MasterEntity.ZCKF!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ZCKF="+SysString.ToDBString(MasterEntity.ZCKF)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ZCKF=null,");  
  				} 
  
  				 
  				if(MasterEntity.RCKF!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RCKF="+SysString.ToDBString(MasterEntity.RCKF)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RCKF=null,");  
  				} 
  
  				 
  				if(MasterEntity.KF!=0) 
  				{ 
  			 		UpdateBuilder.Append(" KF="+SysString.ToDBString(MasterEntity.KF)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" KF=null,");  
  				} 
  
  				 
  				if(MasterEntity.PF!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PF="+SysString.ToDBString(MasterEntity.PF)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PF=null,");  
  				} 
  
  				UpdateBuilder.Append(" FactoryCode="+SysString.ToDBString(MasterEntity.FactoryCode)+","); 
  				 
  				if(MasterEntity.JarNumCount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" JarNumCount="+SysString.ToDBString(MasterEntity.JarNumCount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JarNumCount=null,");  
  				} 
  
  				 
  				if(MasterEntity.YM!=0) 
  				{ 
  			 		UpdateBuilder.Append(" YM="+SysString.ToDBString(MasterEntity.YM)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" YM=null,");  
  				} 
  
  				 
  				if(MasterEntity.SM!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SM="+SysString.ToDBString(MasterEntity.SM)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SM=null,");  
  				} 
  
  				UpdateBuilder.Append(" JSUnit="+SysString.ToDBString(MasterEntity.JSUnit)+","); 
  				UpdateBuilder.Append(" PT="+SysString.ToDBString(MasterEntity.PT)+","); 
  				UpdateBuilder.Append(" ZG="+SysString.ToDBString(MasterEntity.ZG)+","); 
  				UpdateBuilder.Append(" GZ="+SysString.ToDBString(MasterEntity.GZ)+","); 
  				 
  				if(MasterEntity.FMZC!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FMZC="+SysString.ToDBString(MasterEntity.FMZC)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FMZC=null,");  
  				} 
  
  				 
  				if(MasterEntity.FMRC!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FMRC="+SysString.ToDBString(MasterEntity.FMRC)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FMRC=null,");  
  				} 
  
  				UpdateBuilder.Append(" SectionID="+SysString.ToDBString(MasterEntity.SectionID)+","); 
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				 
  				if(MasterEntity.MQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MQty="+SysString.ToDBString(MasterEntity.MQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.MWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.KF20!=0) 
  				{ 
  			 		UpdateBuilder.Append(" KF20="+SysString.ToDBString(MasterEntity.KF20)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" KF20=null,");  
  				} 
  
  				 
  				if(MasterEntity.KF22!=0) 
  				{ 
  			 		UpdateBuilder.Append(" KF22="+SysString.ToDBString(MasterEntity.KF22)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" KF22=null,");  
  				} 
  
  				 
  				if(MasterEntity.KF24!=0) 
  				{ 
  			 		UpdateBuilder.Append(" KF24="+SysString.ToDBString(MasterEntity.KF24)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" KF24=null,");  
  				} 
  
  				 
  				if(MasterEntity.KF25!=0) 
  				{ 
  			 		UpdateBuilder.Append(" KF25="+SysString.ToDBString(MasterEntity.KF25)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" KF25=null,");  
  				} 
  
  				UpdateBuilder.Append(" InWHFlag="+SysString.ToDBString(MasterEntity.InWHFlag)+","); 
  				 
  				if(MasterEntity.SJQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SJQty="+SysString.ToDBString(MasterEntity.SJQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SJQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.JarNo!=0) 
  				{ 
  			 		UpdateBuilder.Append(" JarNo="+SysString.ToDBString(MasterEntity.JarNo)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JarNo=null,");  
  				} 
  
  				UpdateBuilder.Append(" GoodsLevel="+SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
  				UpdateBuilder.Append(" PrintItemName="+SysString.ToDBString(MasterEntity.PrintItemName)+","); 
  				UpdateBuilder.Append(" PrintGoodsCode="+SysString.ToDBString(MasterEntity.PrintGoodsCode)+","); 
  				UpdateBuilder.Append(" PrintCD="+SysString.ToDBString(MasterEntity.PrintCD)+","); 
  				UpdateBuilder.Append(" PrintRemark1="+SysString.ToDBString(MasterEntity.PrintRemark1)+","); 
  				UpdateBuilder.Append(" PrintRemark2="+SysString.ToDBString(MasterEntity.PrintRemark2)+","); 
  				UpdateBuilder.Append(" PrintRemark3="+SysString.ToDBString(MasterEntity.PrintRemark3)+","); 
  				UpdateBuilder.Append(" PrintRemark4="+SysString.ToDBString(MasterEntity.PrintRemark4)); 
 
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
                BProductCheckDts MasterEntity=(BProductCheckDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_BProductCheckDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
