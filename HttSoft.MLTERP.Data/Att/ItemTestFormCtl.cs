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
	/// 目的：Att_ItemTestForm实体控制类
	/// 作者:qiuchao
	/// 创建日期:2015/8/15
	/// </summary>
	public sealed class ItemTestFormCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public ItemTestFormCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemTestFormCtl(IDBTransAccess p_SqlCmd)
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
                ItemTestForm MasterEntity=(ItemTestForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Att_ItemTestForm(");
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
  				MasterField.Append("ShopID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ShopID)+","); 
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SendDate"+","); 
  				if(MasterEntity.SendDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SendDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RecDate"+","); 
  				if(MasterEntity.RecDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RecDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BGNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BGNo)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("CheckComID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckComID)+","); 
  				MasterField.Append("FormType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormType)+","); 
  				MasterField.Append("FormStatus"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormStatus)+","); 
  				MasterField.Append("TestFee"+","); 
  				if(MasterEntity.TestFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TestFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TestContext"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.TestContext)+","); 
  				MasterField.Append("YBGNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YBGNo)+","); 
  				MasterField.Append("YCheckComID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YCheckComID)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("FormXZ"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormXZ)+","); 
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("JSFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JSFlag)+","); 
  				MasterField.Append("JSFree"+","); 
  				if(MasterEntity.JSFree!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JSFree)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JSDate"+","); 
  				if(MasterEntity.JSDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.JSDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("VendorID2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID2)+","); 
  				MasterField.Append("VendorID3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID3)+","); 
  				MasterField.Append("VendorID4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID4)+","); 
  				MasterField.Append("BGType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BGType)+","); 
  				MasterField.Append("DLoadID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLoadID)+","); 
  				MasterField.Append("HTNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTNo)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("Used"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Used)+","); 
  				MasterField.Append("KDForm"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.KDForm)+","); 
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("ItemClass"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemClass)+","); 
  				MasterField.Append("FPNO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FPNO)+","); 
  				MasterField.Append("FPDate"+","); 
  				if(MasterEntity.FPDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FPDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("JYOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JYOPName)+","); 
  				MasterField.Append("OrderQty"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderQty)+")"); 
 
                
                

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
                ItemTestForm MasterEntity=(ItemTestForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Att_ItemTestForm SET ");
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
  				UpdateBuilder.Append(" ShopID="+SysString.ToDBString(MasterEntity.ShopID)+","); 
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.SendDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" SendDate="+SysString.ToDBString(MasterEntity.SendDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SendDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.RecDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" RecDate="+SysString.ToDBString(MasterEntity.RecDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RecDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" BGNo="+SysString.ToDBString(MasterEntity.BGNo)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" CheckComID="+SysString.ToDBString(MasterEntity.CheckComID)+","); 
  				UpdateBuilder.Append(" FormType="+SysString.ToDBString(MasterEntity.FormType)+","); 
  				UpdateBuilder.Append(" FormStatus="+SysString.ToDBString(MasterEntity.FormStatus)+","); 
  				 
  				if(MasterEntity.TestFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TestFee="+SysString.ToDBString(MasterEntity.TestFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TestFee=null,");  
  				} 
  
  				UpdateBuilder.Append(" TestContext="+SysString.ToDBString(MasterEntity.TestContext)+","); 
  				UpdateBuilder.Append(" YBGNo="+SysString.ToDBString(MasterEntity.YBGNo)+","); 
  				UpdateBuilder.Append(" YCheckComID="+SysString.ToDBString(MasterEntity.YCheckComID)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" FormXZ="+SysString.ToDBString(MasterEntity.FormXZ)+","); 
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" JSFlag="+SysString.ToDBString(MasterEntity.JSFlag)+","); 
  				 
  				if(MasterEntity.JSFree!=0) 
  				{ 
  			 		UpdateBuilder.Append(" JSFree="+SysString.ToDBString(MasterEntity.JSFree)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JSFree=null,");  
  				} 
  
  				 
  				if(MasterEntity.JSDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" JSDate="+SysString.ToDBString(MasterEntity.JSDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" JSDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" VendorID2="+SysString.ToDBString(MasterEntity.VendorID2)+","); 
  				UpdateBuilder.Append(" VendorID3="+SysString.ToDBString(MasterEntity.VendorID3)+","); 
  				UpdateBuilder.Append(" VendorID4="+SysString.ToDBString(MasterEntity.VendorID4)+","); 
  				UpdateBuilder.Append(" BGType="+SysString.ToDBString(MasterEntity.BGType)+","); 
  				UpdateBuilder.Append(" DLoadID="+SysString.ToDBString(MasterEntity.DLoadID)+","); 
  				UpdateBuilder.Append(" HTNo="+SysString.ToDBString(MasterEntity.HTNo)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" Used="+SysString.ToDBString(MasterEntity.Used)+","); 
  				UpdateBuilder.Append(" KDForm="+SysString.ToDBString(MasterEntity.KDForm)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				UpdateBuilder.Append(" ItemClass="+SysString.ToDBString(MasterEntity.ItemClass)+","); 
  				UpdateBuilder.Append(" FPNO="+SysString.ToDBString(MasterEntity.FPNO)+","); 
  				 
  				if(MasterEntity.FPDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FPDate="+SysString.ToDBString(MasterEntity.FPDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FPDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" JYOPName="+SysString.ToDBString(MasterEntity.JYOPName)+","); 
  				UpdateBuilder.Append(" OrderQty="+SysString.ToDBString(MasterEntity.OrderQty)); 
 
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
                ItemTestForm MasterEntity=(ItemTestForm)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Att_ItemTestForm WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
