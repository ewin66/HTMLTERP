using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Buy_ItemBuyFollow实体类
	/// 作者:章文强
	/// 创建日期:2012-5-31
	/// </summary>
	public sealed class ItemBuyFollow : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemBuyFollow()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemBuyFollow(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
        public static string TableName = "Buy_ItemBuyFollow";
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
        private int m_DLoadDtsID = 0;
        public int DLoadDtsID
        {
            get { return m_DLoadDtsID; }
            set { m_DLoadDtsID = value; }
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
  
  		private DateTime m_ReqDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ReqDate 
  		{ 
  			get 
  			{ 
  				return m_ReqDate ; 
  			}  
  			set 
  			{ 
  				m_ReqDate = value ; 
  			}  
  		} 
  
  		private string m_OrderFormNo = string.Empty ; 
  		public string OrderFormNo 
  		{ 
  			get 
  			{ 
  				return m_OrderFormNo ; 
  			}  
  			set 
  			{ 
  				m_OrderFormNo = value ; 
  			}  
  		} 
  
  		private string m_BuyFormNo = string.Empty ; 
  		public string BuyFormNo 
  		{ 
  			get 
  			{ 
  				return m_BuyFormNo ; 
  			}  
  			set 
  			{ 
  				m_BuyFormNo = value ; 
  			}  
  		} 
  
  		private decimal m_TotalQty = 0; 
  		public decimal TotalQty 
  		{ 
  			get 
  			{ 
  				return m_TotalQty ; 
  			}  
  			set 
  			{ 
  				m_TotalQty = value ; 
  			}  
  		} 
  
  		private decimal m_TotalAmount = 0; 
  		public decimal TotalAmount 
  		{ 
  			get 
  			{ 
  				return m_TotalAmount ; 
  			}  
  			set 
  			{ 
  				m_TotalAmount = value ; 
  			}  
  		} 
  
  		private string m_ColorCount = string.Empty ; 
  		public string ColorCount 
  		{ 
  			get 
  			{ 
  				return m_ColorCount ; 
  			}  
  			set 
  			{ 
  				m_ColorCount = value ; 
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
  
  		private string m_ItemModel = string.Empty ; 
  		public string ItemModel 
  		{ 
  			get 
  			{ 
  				return m_ItemModel ; 
  			}  
  			set 
  			{ 
  				m_ItemModel = value ; 
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
  
  		private string m_YarnStd = string.Empty ; 
  		public string YarnStd 
  		{ 
  			get 
  			{ 
  				return m_YarnStd ; 
  			}  
  			set 
  			{ 
  				m_YarnStd = value ; 
  			}  
  		} 
  
  		private string m_JWM = string.Empty ; 
  		public string JWM 
  		{ 
  			get 
  			{ 
  				return m_JWM ; 
  			}  
  			set 
  			{ 
  				m_JWM = value ; 
  			}  
  		} 
  
  		private string m_ZWZZ = string.Empty ; 
  		public string ZWZZ 
  		{ 
  			get 
  			{ 
  				return m_ZWZZ ; 
  			}  
  			set 
  			{ 
  				m_ZWZZ = value ; 
  			}  
  		} 
  
  		private string m_RSType = string.Empty ; 
  		public string RSType 
  		{ 
  			get 
  			{ 
  				return m_RSType ; 
  			}  
  			set 
  			{ 
  				m_RSType = value ; 
  			}  
  		} 
  
  		private string m_ItemName = string.Empty ; 
  		public string ItemName 
  		{ 
  			get 
  			{ 
  				return m_ItemName ; 
  			}  
  			set 
  			{ 
  				m_ItemName = value ; 
  			}  
  		} 
  
  		private string m_PackReq = string.Empty ; 
  		public string PackReq 
  		{ 
  			get 
  			{ 
  				return m_PackReq ; 
  			}  
  			set 
  			{ 
  				m_PackReq = value ; 
  			}  
  		} 
  
  		private int m_FYFlag = 0; 
  		public int FYFlag 
  		{ 
  			get 
  			{ 
  				return m_FYFlag ; 
  			}  
  			set 
  			{ 
  				m_FYFlag = value ; 
  			}  
  		} 
  
  		private int m_FYCount = 0; 
  		public int FYCount 
  		{ 
  			get 
  			{ 
  				return m_FYCount ; 
  			}  
  			set 
  			{ 
  				m_FYCount = value ; 
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
  
  		private DateTime m_FactFinishDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FactFinishDate 
  		{ 
  			get 
  			{ 
  				return m_FactFinishDate ; 
  			}  
  			set 
  			{ 
  				m_FactFinishDate = value ; 
  			}  
  		} 
  
  		private string m_PGZL = string.Empty ; 
  		public string PGZL 
  		{ 
  			get 
  			{ 
  				return m_PGZL ; 
  			}  
  			set 
  			{ 
  				m_PGZL = value ; 
  			}  
  		} 
  
  		private string m_PGZLDesc = string.Empty ; 
  		public string PGZLDesc 
  		{ 
  			get 
  			{ 
  				return m_PGZLDesc ; 
  			}  
  			set 
  			{ 
  				m_PGZLDesc = value ; 
  			}  
  		} 
  
  		private string m_PGJQ = string.Empty ; 
  		public string PGJQ 
  		{ 
  			get 
  			{ 
  				return m_PGJQ ; 
  			}  
  			set 
  			{ 
  				m_PGJQ = value ; 
  			}  
  		} 
  
  		private string m_PGJQDesc = string.Empty ; 
  		public string PGJQDesc 
  		{ 
  			get 
  			{ 
  				return m_PGJQDesc ; 
  			}  
  			set 
  			{ 
  				m_PGJQDesc = value ; 
  			}  
  		} 
  
  		private string m_PGPH = string.Empty ; 
  		public string PGPH 
  		{ 
  			get 
  			{ 
  				return m_PGPH ; 
  			}  
  			set 
  			{ 
  				m_PGPH = value ; 
  			}  
  		} 
  
  		private string m_PGPHDesc = string.Empty ; 
  		public string PGPHDesc 
  		{ 
  			get 
  			{ 
  				return m_PGPHDesc ; 
  			}  
  			set 
  			{ 
  				m_PGPHDesc = value ; 
  			}  
  		} 
  
  		private string m_PGZH = string.Empty ; 
  		public string PGZH 
  		{ 
  			get 
  			{ 
  				return m_PGZH ; 
  			}  
  			set 
  			{ 
  				m_PGZH = value ; 
  			}  
  		} 
  
  		private string m_PGZHDesc = string.Empty ; 
  		public string PGZHDesc 
  		{ 
  			get 
  			{ 
  				return m_PGZHDesc ; 
  			}  
  			set 
  			{ 
  				m_PGZHDesc = value ; 
  			}  
  		} 
  
  		private string m_FYItemName = string.Empty ; 
  		public string FYItemName 
  		{ 
  			get 
  			{ 
  				return m_FYItemName ; 
  			}  
  			set 
  			{ 
  				m_FYItemName = value ; 
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
            string Sql="SELECT * FROM Buy_ItemBuyFollow WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Buy_ItemBuyFollow WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
                m_DLoadDtsID = SysConvert.ToInt32(MasterTable.Rows[0]["DLoadDtsID"]);
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_ShopID=SysConvert.ToString(MasterTable.Rows[0]["ShopID"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_ReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ReqDate"]); 
  				m_OrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["OrderFormNo"]); 
  				m_BuyFormNo=SysConvert.ToString(MasterTable.Rows[0]["BuyFormNo"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_ColorCount=SysConvert.ToString(MasterTable.Rows[0]["ColorCount"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_MWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_YarnStd=SysConvert.ToString(MasterTable.Rows[0]["YarnStd"]); 
  				m_JWM=SysConvert.ToString(MasterTable.Rows[0]["JWM"]); 
  				m_ZWZZ=SysConvert.ToString(MasterTable.Rows[0]["ZWZZ"]); 
  				m_RSType=SysConvert.ToString(MasterTable.Rows[0]["RSType"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_PackReq=SysConvert.ToString(MasterTable.Rows[0]["PackReq"]); 
  				m_FYFlag=SysConvert.ToInt32(MasterTable.Rows[0]["FYFlag"]); 
  				m_FYCount=SysConvert.ToInt32(MasterTable.Rows[0]["FYCount"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_FactFinishDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FactFinishDate"]); 
  				m_PGZL=SysConvert.ToString(MasterTable.Rows[0]["PGZL"]); 
  				m_PGZLDesc=SysConvert.ToString(MasterTable.Rows[0]["PGZLDesc"]); 
  				m_PGJQ=SysConvert.ToString(MasterTable.Rows[0]["PGJQ"]); 
  				m_PGJQDesc=SysConvert.ToString(MasterTable.Rows[0]["PGJQDesc"]); 
  				m_PGPH=SysConvert.ToString(MasterTable.Rows[0]["PGPH"]); 
  				m_PGPHDesc=SysConvert.ToString(MasterTable.Rows[0]["PGPHDesc"]); 
  				m_PGZH=SysConvert.ToString(MasterTable.Rows[0]["PGZH"]); 
  				m_PGZHDesc=SysConvert.ToString(MasterTable.Rows[0]["PGZHDesc"]); 
  				m_FYItemName=SysConvert.ToString(MasterTable.Rows[0]["FYItemName"]); 
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
