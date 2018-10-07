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
	/// 目的：Dev_ColorCardDts实体控制类
	/// 作者:章文强
	/// 创建日期:2014/12/2
	/// </summary>
	public sealed class ColorCardDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ColorCardDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ColorCardDtsCtl(IDBTransAccess p_SqlCmd)
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
                ColorCardDts MasterEntity=(ColorCardDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Dev_ColorCardDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("ColorCardStatusID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorCardStatusID)+","); 
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
  				MasterField.Append("Season"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Season)+","); 
  				MasterField.Append("DesignNO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DesignNO)+","); 
  				MasterField.Append("VendorNO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorNO)+","); 
  				MasterField.Append("DesignEdition"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DesignEdition)+","); 
  				MasterField.Append("OKEdition"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OKEdition)+","); 
  				MasterField.Append("FirstFinish"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FirstFinish)+","); 
  				MasterField.Append("FirstRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FirstRemark)+","); 
  				MasterField.Append("SecondFinish"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SecondFinish)+","); 
  				MasterField.Append("SecondRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SecondRemark)+","); 
  				MasterField.Append("ThirdFinish"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ThirdFinish)+","); 
  				MasterField.Append("ThirdRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ThirdRemark)+","); 
  				MasterField.Append("FreeStr1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr1)+","); 
  				MasterField.Append("FreeStr2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr2)+","); 
  				MasterField.Append("FreeStr3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr3)+","); 
  				MasterField.Append("FreeStr4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr4)+","); 
  				MasterField.Append("FreeStr5"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr5)+","); 
  				MasterField.Append("FreeDate1"+","); 
  				if(MasterEntity.FreeDate1!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeDate1.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeDate2"+","); 
  				if(MasterEntity.FreeDate2!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeDate2.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeDate3"+","); 
  				if(MasterEntity.FreeDate3!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeDate3.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeDate4"+","); 
  				if(MasterEntity.FreeDate4!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeDate4.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FreeDate5"+","); 
  				if(MasterEntity.FreeDate5!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeDate5.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DtsRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsRemark)+","); 
  				MasterField.Append("FinishDate"+","); 
  				if(MasterEntity.FinishDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FinishDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JYDate"+","); 
  				if(MasterEntity.JYDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JYDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("HGFinishDate"+","); 
  				if(MasterEntity.HGFinishDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HGFinishDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("HGBack"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HGBack)+","); 
  				MasterField.Append("FlowerNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FlowerNum)+","); 
  				MasterField.Append("ScrapSampleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ScrapSampleNo)+","); 
  				MasterField.Append("MWidth2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth2)+","); 
  				MasterField.Append("GYOPID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GYOPID)+")"); 
 
                
                

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
                ColorCardDts MasterEntity=(ColorCardDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Dev_ColorCardDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ColorCardStatusID="+SysString.ToDBString(MasterEntity.ColorCardStatusID)+","); 
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
  				UpdateBuilder.Append(" Season="+SysString.ToDBString(MasterEntity.Season)+","); 
  				UpdateBuilder.Append(" DesignNO="+SysString.ToDBString(MasterEntity.DesignNO)+","); 
  				UpdateBuilder.Append(" VendorNO="+SysString.ToDBString(MasterEntity.VendorNO)+","); 
  				UpdateBuilder.Append(" DesignEdition="+SysString.ToDBString(MasterEntity.DesignEdition)+","); 
  				UpdateBuilder.Append(" OKEdition="+SysString.ToDBString(MasterEntity.OKEdition)+","); 
  				UpdateBuilder.Append(" FirstFinish="+SysString.ToDBString(MasterEntity.FirstFinish)+","); 
  				UpdateBuilder.Append(" FirstRemark="+SysString.ToDBString(MasterEntity.FirstRemark)+","); 
  				UpdateBuilder.Append(" SecondFinish="+SysString.ToDBString(MasterEntity.SecondFinish)+","); 
  				UpdateBuilder.Append(" SecondRemark="+SysString.ToDBString(MasterEntity.SecondRemark)+","); 
  				UpdateBuilder.Append(" ThirdFinish="+SysString.ToDBString(MasterEntity.ThirdFinish)+","); 
  				UpdateBuilder.Append(" ThirdRemark="+SysString.ToDBString(MasterEntity.ThirdRemark)+","); 
  				UpdateBuilder.Append(" FreeStr1="+SysString.ToDBString(MasterEntity.FreeStr1)+","); 
  				UpdateBuilder.Append(" FreeStr2="+SysString.ToDBString(MasterEntity.FreeStr2)+","); 
  				UpdateBuilder.Append(" FreeStr3="+SysString.ToDBString(MasterEntity.FreeStr3)+","); 
  				UpdateBuilder.Append(" FreeStr4="+SysString.ToDBString(MasterEntity.FreeStr4)+","); 
  				UpdateBuilder.Append(" FreeStr5="+SysString.ToDBString(MasterEntity.FreeStr5)+","); 
  				 
  				if(MasterEntity.FreeDate1!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FreeDate1="+SysString.ToDBString(MasterEntity.FreeDate1.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeDate1=null,");  
  				} 
  
  				 
  				if(MasterEntity.FreeDate2!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FreeDate2="+SysString.ToDBString(MasterEntity.FreeDate2.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeDate2=null,");  
  				} 
  
  				 
  				if(MasterEntity.FreeDate3!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FreeDate3="+SysString.ToDBString(MasterEntity.FreeDate3.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeDate3=null,");  
  				} 
  
  				 
  				if(MasterEntity.FreeDate4!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FreeDate4="+SysString.ToDBString(MasterEntity.FreeDate4.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeDate4=null,");  
  				} 
  
  				 
  				if(MasterEntity.FreeDate5!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FreeDate5="+SysString.ToDBString(MasterEntity.FreeDate5.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeDate5=null,");  
  				} 
  
  				UpdateBuilder.Append(" DtsRemark="+SysString.ToDBString(MasterEntity.DtsRemark)+","); 
  				 
  				if(MasterEntity.FinishDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FinishDate="+SysString.ToDBString(MasterEntity.FinishDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FinishDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.JYDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" JYDate="+SysString.ToDBString(MasterEntity.JYDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JYDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.HGFinishDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" HGFinishDate="+SysString.ToDBString(MasterEntity.HGFinishDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HGFinishDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" HGBack="+SysString.ToDBString(MasterEntity.HGBack)+","); 
  				UpdateBuilder.Append(" FlowerNum="+SysString.ToDBString(MasterEntity.FlowerNum)+","); 
  				UpdateBuilder.Append(" ScrapSampleNo="+SysString.ToDBString(MasterEntity.ScrapSampleNo)+","); 
  				UpdateBuilder.Append(" MWidth2="+SysString.ToDBString(MasterEntity.MWidth2)+","); 
  				UpdateBuilder.Append(" GYOPID="+SysString.ToDBString(MasterEntity.GYOPID)); 
 
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
                ColorCardDts MasterEntity=(ColorCardDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Dev_ColorCardDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
