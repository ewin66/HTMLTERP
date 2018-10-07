using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_DYGL实体类
	/// 作者:陈加海
	/// 创建日期:2013/3/11
	/// </summary>
	public sealed class DYGL : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public DYGL()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public DYGL(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
  		private int m_ID = 0; 
  		public int ID 
  		{ 
  			get 
  			{ 
  				return m_ID ; 
  			}  
  			set 
  			{ 
  				m_ID = value ; 
  			}  
  		} 
  
  		private string m_FormNo = string.Empty ; 
  		public string FormNo 
  		{ 
  			get 
  			{ 
  				return m_FormNo ; 
  			}  
  			set 
  			{ 
  				m_FormNo = value ; 
  			}  
  		} 
  
  		private string m_MakeOPID = string.Empty ; 
  		public string MakeOPID 
  		{ 
  			get 
  			{ 
  				return m_MakeOPID ; 
  			}  
  			set 
  			{ 
  				m_MakeOPID = value ; 
  			}  
  		} 
  
  		private string m_MakeOPName = string.Empty ; 
  		public string MakeOPName 
  		{ 
  			get 
  			{ 
  				return m_MakeOPName ; 
  			}  
  			set 
  			{ 
  				m_MakeOPName = value ; 
  			}  
  		} 
  
  		private DateTime m_MakeDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime MakeDate 
  		{ 
  			get 
  			{ 
  				return m_MakeDate ; 
  			}  
  			set 
  			{ 
  				m_MakeDate = value ; 
  			}  
  		} 
  
  		private string m_CheckOPID = string.Empty ; 
  		public string CheckOPID 
  		{ 
  			get 
  			{ 
  				return m_CheckOPID ; 
  			}  
  			set 
  			{ 
  				m_CheckOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_CheckDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CheckDate 
  		{ 
  			get 
  			{ 
  				return m_CheckDate ; 
  			}  
  			set 
  			{ 
  				m_CheckDate = value ; 
  			}  
  		} 
  
  		private int m_SubmitFlag = 0; 
  		public int SubmitFlag 
  		{ 
  			get 
  			{ 
  				return m_SubmitFlag ; 
  			}  
  			set 
  			{ 
  				m_SubmitFlag = value ; 
  			}  
  		} 
  
  		private int m_DelFlag = 0; 
  		public int DelFlag 
  		{ 
  			get 
  			{ 
  				return m_DelFlag ; 
  			}  
  			set 
  			{ 
  				m_DelFlag = value ; 
  			}  
  		} 
  
  		private DateTime m_FormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FormDate 
  		{ 
  			get 
  			{ 
  				return m_FormDate ; 
  			}  
  			set 
  			{ 
  				m_FormDate = value ; 
  			}  
  		} 
  
  		private string m_VendorID = string.Empty ; 
  		public string VendorID 
  		{ 
  			get 
  			{ 
  				return m_VendorID ; 
  			}  
  			set 
  			{ 
  				m_VendorID = value ; 
  			}  
  		} 
  
  		private string m_SaleOPID = string.Empty ; 
  		public string SaleOPID 
  		{ 
  			get 
  			{ 
  				return m_SaleOPID ; 
  			}  
  			set 
  			{ 
  				m_SaleOPID = value ; 
  			}  
  		} 
  
  		private string m_GBCode = string.Empty ; 
  		public string GBCode 
  		{ 
  			get 
  			{ 
  				return m_GBCode ; 
  			}  
  			set 
  			{ 
  				m_GBCode = value ; 
  			}  
  		} 
  
  		private string m_ItemCode = string.Empty ; 
  		public string ItemCode 
  		{ 
  			get 
  			{ 
  				return m_ItemCode ; 
  			}  
  			set 
  			{ 
  				m_ItemCode = value ; 
  			}  
  		} 
  
  		private string m_ColorNum = string.Empty ; 
  		public string ColorNum 
  		{ 
  			get 
  			{ 
  				return m_ColorNum ; 
  			}  
  			set 
  			{ 
  				m_ColorNum = value ; 
  			}  
  		} 
  
  		private string m_ColorName = string.Empty ; 
  		public string ColorName 
  		{ 
  			get 
  			{ 
  				return m_ColorName ; 
  			}  
  			set 
  			{ 
  				m_ColorName = value ; 
  			}  
  		} 
  
  		private string m_ShopID = string.Empty ; 
  		public string ShopID 
  		{ 
  			get 
  			{ 
  				return m_ShopID ; 
  			}  
  			set 
  			{ 
  				m_ShopID = value ; 
  			}  
  		} 
  
  		private string m_DYXZ = string.Empty ; 
  		public string DYXZ 
  		{ 
  			get 
  			{ 
  				return m_DYXZ ; 
  			}  
  			set 
  			{ 
  				m_DYXZ = value ; 
  			}  
  		} 
  
  		private decimal m_Qty = 0; 
  		public decimal Qty 
  		{ 
  			get 
  			{ 
  				return m_Qty ; 
  			}  
  			set 
  			{ 
  				m_Qty = value ; 
  			}  
  		} 
  
  		private string m_PYRequest = string.Empty ; 
  		public string PYRequest 
  		{ 
  			get 
  			{ 
  				return m_PYRequest ; 
  			}  
  			set 
  			{ 
  				m_PYRequest = value ; 
  			}  
  		} 
  
  		private int m_DYStatusID = 0; 
  		public int DYStatusID 
  		{ 
  			get 
  			{ 
  				return m_DYStatusID ; 
  			}  
  			set 
  			{ 
  				m_DYStatusID = value ; 
  			}  
  		} 
  
  		private decimal m_SinglePrice = 0; 
  		public decimal SinglePrice 
  		{ 
  			get 
  			{ 
  				return m_SinglePrice ; 
  			}  
  			set 
  			{ 
  				m_SinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_Amount = 0; 
  		public decimal Amount 
  		{ 
  			get 
  			{ 
  				return m_Amount ; 
  			}  
  			set 
  			{ 
  				m_Amount = value ; 
  			}  
  		} 
  
  		private DateTime m_PYReqDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime PYReqDate 
  		{ 
  			get 
  			{ 
  				return m_PYReqDate ; 
  			}  
  			set 
  			{ 
  				m_PYReqDate = value ; 
  			}  
  		} 
  
  		private string m_Remark = string.Empty ; 
  		public string Remark 
  		{ 
  			get 
  			{ 
  				return m_Remark ; 
  			}  
  			set 
  			{ 
  				m_Remark = value ; 
  			}  
  		} 
  
  		private string m_FormDesc = string.Empty ; 
  		public string FormDesc 
  		{ 
  			get 
  			{ 
  				return m_FormDesc ; 
  			}  
  			set 
  			{ 
  				m_FormDesc = value ; 
  			}  
  		} 
  
  		private string m_GoodsCode = string.Empty ; 
  		public string GoodsCode 
  		{ 
  			get 
  			{ 
  				return m_GoodsCode ; 
  			}  
  			set 
  			{ 
  				m_GoodsCode = value ; 
  			}  
  		} 
  
  		private string m_DLCode = string.Empty ; 
  		public string DLCode 
  		{ 
  			get 
  			{ 
  				return m_DLCode ; 
  			}  
  			set 
  			{ 
  				m_DLCode = value ; 
  			}  
  		} 
  
  		private decimal m_InQty = 0; 
  		public decimal InQty 
  		{ 
  			get 
  			{ 
  				return m_InQty ; 
  			}  
  			set 
  			{ 
  				m_InQty = value ; 
  			}  
  		} 
  
  		private DateTime m_InFormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime InFormDate 
  		{ 
  			get 
  			{ 
  				return m_InFormDate ; 
  			}  
  			set 
  			{ 
  				m_InFormDate = value ; 
  			}  
  		} 
  
  		private decimal m_OutQty = 0; 
  		public decimal OutQty 
  		{ 
  			get 
  			{ 
  				return m_OutQty ; 
  			}  
  			set 
  			{ 
  				m_OutQty = value ; 
  			}  
  		} 
  
  		private DateTime m_OutFormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime OutFormDate 
  		{ 
  			get 
  			{ 
  				return m_OutFormDate ; 
  			}  
  			set 
  			{ 
  				m_OutFormDate = value ; 
  			}  
  		} 
  
  		private int m_SaleOrderCount = 0; 
  		public int SaleOrderCount 
  		{ 
  			get 
  			{ 
  				return m_SaleOrderCount ; 
  			}  
  			set 
  			{ 
  				m_SaleOrderCount = value ; 
  			}  
  		} 
  
  		private decimal m_SaleOrderQty = 0; 
  		public decimal SaleOrderQty 
  		{ 
  			get 
  			{ 
  				return m_SaleOrderQty ; 
  			}  
  			set 
  			{ 
  				m_SaleOrderQty = value ; 
  			}  
  		} 
  
  		private DateTime m_FSaleOrderDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FSaleOrderDate 
  		{ 
  			get 
  			{ 
  				return m_FSaleOrderDate ; 
  			}  
  			set 
  			{ 
  				m_FSaleOrderDate = value ; 
  			}  
  		} 
  
  		private DateTime m_LSaleOrderDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime LSaleOrderDate 
  		{ 
  			get 
  			{ 
  				return m_LSaleOrderDate ; 
  			}  
  			set 
  			{ 
  				m_LSaleOrderDate = value ; 
  			}  
  		} 
  
  		private string m_VendorID2 = string.Empty ; 
  		public string VendorID2 
  		{ 
  			get 
  			{ 
  				return m_VendorID2 ; 
  			}  
  			set 
  			{ 
  				m_VendorID2 = value ; 
  			}  
  		} 
  
  		private string m_Unit = string.Empty ; 
  		public string Unit 
  		{ 
  			get 
  			{ 
  				return m_Unit ; 
  			}  
  			set 
  			{ 
  				m_Unit = value ; 
  			}  
  		} 
  
  		private DateTime m_SJDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SJDate 
  		{ 
  			get 
  			{ 
  				return m_SJDate ; 
  			}  
  			set 
  			{ 
  				m_SJDate = value ; 
  			}  
  		} 
  
  		private decimal m_DYPrice = 0; 
  		public decimal DYPrice 
  		{ 
  			get 
  			{ 
  				return m_DYPrice ; 
  			}  
  			set 
  			{ 
  				m_DYPrice = value ; 
  			}  
  		} 
  
  		private string m_VItemCode = string.Empty ; 
  		public string VItemCode 
  		{ 
  			get 
  			{ 
  				return m_VItemCode ; 
  			}  
  			set 
  			{ 
  				m_VItemCode = value ; 
  			}  
  		} 
  
  		private string m_VColorNum = string.Empty ; 
  		public string VColorNum 
  		{ 
  			get 
  			{ 
  				return m_VColorNum ; 
  			}  
  			set 
  			{ 
  				m_VColorNum = value ; 
  			}  
  		} 
  
  		private string m_VColorName = string.Empty ; 
  		public string VColorName 
  		{ 
  			get 
  			{ 
  				return m_VColorName ; 
  			}  
  			set 
  			{ 
  				m_VColorName = value ; 
  			}  
  		} 
  
  		private string m_DSLeiXin = string.Empty ; 
  		public string DSLeiXin 
  		{ 
  			get 
  			{ 
  				return m_DSLeiXin ; 
  			}  
  			set 
  			{ 
  				m_DSLeiXin = value ; 
  			}  
  		} 
  
  		private string m_QRColorName = string.Empty ; 
  		public string QRColorName 
  		{ 
  			get 
  			{ 
  				return m_QRColorName ; 
  			}  
  			set 
  			{ 
  				m_QRColorName = value ; 
  			}  
  		} 
  
  		private DateTime m_QRDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime QRDate 
  		{ 
  			get 
  			{ 
  				return m_QRDate ; 
  			}  
  			set 
  			{ 
  				m_QRDate = value ; 
  			}  
  		} 
  
  		private decimal m_MWidth = 0; 
  		public decimal MWidth 
  		{ 
  			get 
  			{ 
  				return m_MWidth ; 
  			}  
  			set 
  			{ 
  				m_MWidth = value ; 
  			}  
  		} 
  
  		private decimal m_MWeight = 0; 
  		public decimal MWeight 
  		{ 
  			get 
  			{ 
  				return m_MWeight ; 
  			}  
  			set 
  			{ 
  				m_MWeight = value ; 
  			}  
  		} 
  
  		private string m_WeightUnit = string.Empty ; 
  		public string WeightUnit 
  		{ 
  			get 
  			{ 
  				return m_WeightUnit ; 
  			}  
  			set 
  			{ 
  				m_WeightUnit = value ; 
  			}  
  		} 
  
  		private string m_RelFormNo = string.Empty ; 
  		public string RelFormNo 
  		{ 
  			get 
  			{ 
  				return m_RelFormNo ; 
  			}  
  			set 
  			{ 
  				m_RelFormNo = value ; 
  			}  
  		} 
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Sale_DYGL WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_DYGL WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按传入的SQL语句查询后给属性赋值
        /// </summary>
        /// <param name="p_Sql">SQL语句</param>
        /// <returns>记录存在回true，不存在返回false</returns>
        protected override bool Select(string p_Sql)
        {
            DataTable MasterTable=new DataTable();
            if(!this.sqlTransFlag)
			{
				MasterTable=this.Fill(p_Sql);
			}
			else
			{
				MasterTable=sqlTrans.Fill(p_Sql);
			}
				
            if (MasterTable.Rows.Count>0)
            {
                //查询主表记录
                m_ID=SysConvert.ToInt32(MasterTable.Rows[0]["ID"]); 
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_GBCode=SysConvert.ToString(MasterTable.Rows[0]["GBCode"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_ShopID=SysConvert.ToString(MasterTable.Rows[0]["ShopID"]); 
  				m_DYXZ=SysConvert.ToString(MasterTable.Rows[0]["DYXZ"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_PYRequest=SysConvert.ToString(MasterTable.Rows[0]["PYRequest"]); 
  				m_DYStatusID=SysConvert.ToInt32(MasterTable.Rows[0]["DYStatusID"]); 
  				m_SinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SinglePrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_PYReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["PYReqDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_FormDesc=SysConvert.ToString(MasterTable.Rows[0]["FormDesc"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_DLCode=SysConvert.ToString(MasterTable.Rows[0]["DLCode"]); 
  				m_InQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InQty"]); 
  				m_InFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["InFormDate"]); 
  				m_OutQty=SysConvert.ToDecimal(MasterTable.Rows[0]["OutQty"]); 
  				m_OutFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["OutFormDate"]); 
  				m_SaleOrderCount=SysConvert.ToInt32(MasterTable.Rows[0]["SaleOrderCount"]); 
  				m_SaleOrderQty=SysConvert.ToDecimal(MasterTable.Rows[0]["SaleOrderQty"]); 
  				m_FSaleOrderDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FSaleOrderDate"]); 
  				m_LSaleOrderDate=SysConvert.ToDateTime(MasterTable.Rows[0]["LSaleOrderDate"]); 
  				m_VendorID2=SysConvert.ToString(MasterTable.Rows[0]["VendorID2"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_SJDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SJDate"]); 
  				m_DYPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DYPrice"]); 
  				m_VItemCode=SysConvert.ToString(MasterTable.Rows[0]["VItemCode"]); 
  				m_VColorNum=SysConvert.ToString(MasterTable.Rows[0]["VColorNum"]); 
  				m_VColorName=SysConvert.ToString(MasterTable.Rows[0]["VColorName"]); 
  				m_DSLeiXin=SysConvert.ToString(MasterTable.Rows[0]["DSLeiXin"]); 
  				m_QRColorName=SysConvert.ToString(MasterTable.Rows[0]["QRColorName"]); 
  				m_QRDate=SysConvert.ToDateTime(MasterTable.Rows[0]["QRDate"]); 
  				m_MWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_RelFormNo=SysConvert.ToString(MasterTable.Rows[0]["RelFormNo"]); 
                MasterTable.Dispose();
                return true;
            }
            else
            {
                MasterTable.Dispose();
                return false;
            }
        }
	}
}
