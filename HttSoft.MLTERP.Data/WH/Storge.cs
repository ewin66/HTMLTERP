using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_Storge实体类
	/// 作者:xusc
	/// 创建日期:2015/12/26
	/// </summary>
	public sealed class Storge : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Storge()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Storge(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WH_Storge";
		 
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
  
  		private string m_WHID = string.Empty ; 
  		public string WHID 
  		{ 
  			get 
  			{ 
  				return m_WHID ; 
  			}  
  			set 
  			{ 
  				m_WHID = value ; 
  			}  
  		} 
  
  		private string m_SectionID = string.Empty ; 
  		public string SectionID 
  		{ 
  			get 
  			{ 
  				return m_SectionID ; 
  			}  
  			set 
  			{ 
  				m_SectionID = value ; 
  			}  
  		} 
  
  		private string m_SBitID = string.Empty ; 
  		public string SBitID 
  		{ 
  			get 
  			{ 
  				return m_SBitID ; 
  			}  
  			set 
  			{ 
  				m_SBitID = value ; 
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
  
  		private string m_CustomerID = string.Empty ; 
  		public string CustomerID 
  		{ 
  			get 
  			{ 
  				return m_CustomerID ; 
  			}  
  			set 
  			{ 
  				m_CustomerID = value ; 
  			}  
  		} 
  
  		private string m_WHType = string.Empty ; 
  		public string WHType 
  		{ 
  			get 
  			{ 
  				return m_WHType ; 
  			}  
  			set 
  			{ 
  				m_WHType = value ; 
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
  
  		private string m_ItemStd = string.Empty ; 
  		public string ItemStd 
  		{ 
  			get 
  			{ 
  				return m_ItemStd ; 
  			}  
  			set 
  			{ 
  				m_ItemStd = value ; 
  			}  
  		} 
  
  		private string m_Batch = string.Empty ; 
  		public string Batch 
  		{ 
  			get 
  			{ 
  				return m_Batch ; 
  			}  
  			set 
  			{ 
  				m_Batch = value ; 
  			}  
  		} 
  
  		private string m_VendorBatch = string.Empty ; 
  		public string VendorBatch 
  		{ 
  			get 
  			{ 
  				return m_VendorBatch ; 
  			}  
  			set 
  			{ 
  				m_VendorBatch = value ; 
  			}  
  		} 
  
  		private string m_Twist = string.Empty ; 
  		public string Twist 
  		{ 
  			get 
  			{ 
  				return m_Twist ; 
  			}  
  			set 
  			{ 
  				m_Twist = value ; 
  			}  
  		} 
  
  		private string m_YarnType = string.Empty ; 
  		public string YarnType 
  		{ 
  			get 
  			{ 
  				return m_YarnType ; 
  			}  
  			set 
  			{ 
  				m_YarnType = value ; 
  			}  
  		} 
  
  		private decimal m_Weight = 0; 
  		public decimal Weight 
  		{ 
  			get 
  			{ 
  				return m_Weight ; 
  			}  
  			set 
  			{ 
  				m_Weight = value ; 
  			}  
  		} 
  
  		private decimal m_TubeGW = 0; 
  		public decimal TubeGW 
  		{ 
  			get 
  			{ 
  				return m_TubeGW ; 
  			}  
  			set 
  			{ 
  				m_TubeGW = value ; 
  			}  
  		} 
  
  		private int m_TubeQty = 0; 
  		public int TubeQty 
  		{ 
  			get 
  			{ 
  				return m_TubeQty ; 
  			}  
  			set 
  			{ 
  				m_TubeQty = value ; 
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
  
  		private decimal m_LockQty = 0; 
  		public decimal LockQty 
  		{ 
  			get 
  			{ 
  				return m_LockQty ; 
  			}  
  			set 
  			{ 
  				m_LockQty = value ; 
  			}  
  		} 
  
  		private decimal m_FreeQty = 0; 
  		public decimal FreeQty 
  		{ 
  			get 
  			{ 
  				return m_FreeQty ; 
  			}  
  			set 
  			{ 
  				m_FreeQty = value ; 
  			}  
  		} 
  
  		private string m_Needle = string.Empty ; 
  		public string Needle 
  		{ 
  			get 
  			{ 
  				return m_Needle ; 
  			}  
  			set 
  			{ 
  				m_Needle = value ; 
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
  
  		private int m_PieceQty = 0; 
  		public int PieceQty 
  		{ 
  			get 
  			{ 
  				return m_PieceQty ; 
  			}  
  			set 
  			{ 
  				m_PieceQty = value ; 
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
  
  		private string m_JarNo = string.Empty ; 
  		public string JarNo 
  		{ 
  			get 
  			{ 
  				return m_JarNo ; 
  			}  
  			set 
  			{ 
  				m_JarNo = value ; 
  			}  
  		} 
  
  		private string m_JarNum = string.Empty ; 
  		public string JarNum 
  		{ 
  			get 
  			{ 
  				return m_JarNum ; 
  			}  
  			set 
  			{ 
  				m_JarNum = value ; 
  			}  
  		} 
  
  		private string m_SO = string.Empty ; 
  		public string SO 
  		{ 
  			get 
  			{ 
  				return m_SO ; 
  			}  
  			set 
  			{ 
  				m_SO = value ; 
  			}  
  		} 
  
  		private DateTime m_LastUpdTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime LastUpdTime 
  		{ 
  			get 
  			{ 
  				return m_LastUpdTime ; 
  			}  
  			set 
  			{ 
  				m_LastUpdTime = value ; 
  			}  
  		} 
  
  		private DateTime m_LastUpdOP = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime LastUpdOP 
  		{ 
  			get 
  			{ 
  				return m_LastUpdOP ; 
  			}  
  			set 
  			{ 
  				m_LastUpdOP = value ; 
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
  
  		private DateTime m_Indate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime Indate 
  		{ 
  			get 
  			{ 
  				return m_Indate ; 
  			}  
  			set 
  			{ 
  				m_Indate = value ; 
  			}  
  		} 
  
  		private string m_DutyOPID = string.Empty ; 
  		public string DutyOPID 
  		{ 
  			get 
  			{ 
  				return m_DutyOPID ; 
  			}  
  			set 
  			{ 
  				m_DutyOPID = value ; 
  			}  
  		} 
  
  		private decimal m_CostPrice = 0; 
  		public decimal CostPrice 
  		{ 
  			get 
  			{ 
  				return m_CostPrice ; 
  			}  
  			set 
  			{ 
  				m_CostPrice = value ; 
  			}  
  		} 
  
  		private int m_WHQualityFlag = 0; 
  		public int WHQualityFlag 
  		{ 
  			get 
  			{ 
  				return m_WHQualityFlag ; 
  			}  
  			set 
  			{ 
  				m_WHQualityFlag = value ; 
  			}  
  		} 
  
  		private int m_WHQualityFFlag = 0; 
  		public int WHQualityFFlag 
  		{ 
  			get 
  			{ 
  				return m_WHQualityFFlag ; 
  			}  
  			set 
  			{ 
  				m_WHQualityFFlag = value ; 
  			}  
  		} 
  
  		private int m_WHXiePianFlag = 0; 
  		public int WHXiePianFlag 
  		{ 
  			get 
  			{ 
  				return m_WHXiePianFlag ; 
  			}  
  			set 
  			{ 
  				m_WHXiePianFlag = value ; 
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
  
  		private string m_GoodsLevel = string.Empty ; 
  		public string GoodsLevel 
  		{ 
  			get 
  			{ 
  				return m_GoodsLevel ; 
  			}  
  			set 
  			{ 
  				m_GoodsLevel = value ; 
  			}  
  		} 
  
  		private string m_MWidth = string.Empty ; 
  		public string MWidth 
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
  
  		private string m_MWeight = string.Empty ; 
  		public string MWeight 
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
  
  		private int m_MLType = 0; 
  		public int MLType 
  		{ 
  			get 
  			{ 
  				return m_MLType ; 
  			}  
  			set 
  			{ 
  				m_MLType = value ; 
  			}  
  		} 
  
  		private DateTime m_PDDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime PDDate 
  		{ 
  			get 
  			{ 
  				return m_PDDate ; 
  			}  
  			set 
  			{ 
  				m_PDDate = value ; 
  			}  
  		} 
  
  		private int m_PDFlag = 0; 
  		public int PDFlag 
  		{ 
  			get 
  			{ 
  				return m_PDFlag ; 
  			}  
  			set 
  			{ 
  				m_PDFlag = value ; 
  			}  
  		} 
  
  		private string m_DVendorID = string.Empty ; 
  		public string DVendorID 
  		{ 
  			get 
  			{ 
  				return m_DVendorID ; 
  			}  
  			set 
  			{ 
  				m_DVendorID = value ; 
  			}  
  		} 
  
  		private string m_StyleNo = string.Empty ; 
  		public string StyleNo 
  		{ 
  			get 
  			{ 
  				return m_StyleNo ; 
  			}  
  			set 
  			{ 
  				m_StyleNo = value ; 
  			}  
  		} 
  
  		private decimal m_Yard = 0; 
  		public decimal Yard 
  		{ 
  			get 
  			{ 
  				return m_Yard ; 
  			}  
  			set 
  			{ 
  				m_Yard = value ; 
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
            string Sql="SELECT * FROM WH_Storge WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_Storge WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_WHID=SysConvert.ToString(MasterTable.Rows[0]["WHID"]); 
  				m_SectionID=SysConvert.ToString(MasterTable.Rows[0]["SectionID"]); 
  				m_SBitID=SysConvert.ToString(MasterTable.Rows[0]["SBitID"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_CustomerID=SysConvert.ToString(MasterTable.Rows[0]["CustomerID"]); 
  				m_WHType=SysConvert.ToString(MasterTable.Rows[0]["WHType"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_Batch=SysConvert.ToString(MasterTable.Rows[0]["Batch"]); 
  				m_VendorBatch=SysConvert.ToString(MasterTable.Rows[0]["VendorBatch"]); 
  				m_Twist=SysConvert.ToString(MasterTable.Rows[0]["Twist"]); 
  				m_YarnType=SysConvert.ToString(MasterTable.Rows[0]["YarnType"]); 
  				m_Weight=SysConvert.ToDecimal(MasterTable.Rows[0]["Weight"]); 
  				m_TubeGW=SysConvert.ToDecimal(MasterTable.Rows[0]["TubeGW"]); 
  				m_TubeQty=SysConvert.ToInt32(MasterTable.Rows[0]["TubeQty"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_LockQty=SysConvert.ToDecimal(MasterTable.Rows[0]["LockQty"]); 
  				m_FreeQty=SysConvert.ToDecimal(MasterTable.Rows[0]["FreeQty"]); 
  				m_Needle=SysConvert.ToString(MasterTable.Rows[0]["Needle"]); 
  				m_SinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SinglePrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_PieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["PieceQty"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_JarNo=SysConvert.ToString(MasterTable.Rows[0]["JarNo"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_SO=SysConvert.ToString(MasterTable.Rows[0]["SO"]); 
  				m_LastUpdTime=SysConvert.ToDateTime(MasterTable.Rows[0]["LastUpdTime"]); 
  				m_LastUpdOP=SysConvert.ToDateTime(MasterTable.Rows[0]["LastUpdOP"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_Indate=SysConvert.ToDateTime(MasterTable.Rows[0]["Indate"]); 
  				m_DutyOPID=SysConvert.ToString(MasterTable.Rows[0]["DutyOPID"]); 
  				m_CostPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["CostPrice"]); 
  				m_WHQualityFlag=SysConvert.ToInt32(MasterTable.Rows[0]["WHQualityFlag"]); 
  				m_WHQualityFFlag=SysConvert.ToInt32(MasterTable.Rows[0]["WHQualityFFlag"]); 
  				m_WHXiePianFlag=SysConvert.ToInt32(MasterTable.Rows[0]["WHXiePianFlag"]); 
  				m_VColorNum=SysConvert.ToString(MasterTable.Rows[0]["VColorNum"]); 
  				m_VColorName=SysConvert.ToString(MasterTable.Rows[0]["VColorName"]); 
  				m_VItemCode=SysConvert.ToString(MasterTable.Rows[0]["VItemCode"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_GoodsLevel=SysConvert.ToString(MasterTable.Rows[0]["GoodsLevel"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_OrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["OrderFormNo"]); 
  				m_MLType=SysConvert.ToInt32(MasterTable.Rows[0]["MLType"]); 
  				m_PDDate=SysConvert.ToDateTime(MasterTable.Rows[0]["PDDate"]); 
  				m_PDFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PDFlag"]); 
  				m_DVendorID=SysConvert.ToString(MasterTable.Rows[0]["DVendorID"]); 
  				m_StyleNo=SysConvert.ToString(MasterTable.Rows[0]["StyleNo"]); 
  				m_Yard=SysConvert.ToDecimal(MasterTable.Rows[0]["Yard"]); 
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
