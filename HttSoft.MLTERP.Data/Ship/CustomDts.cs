using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Ship_CustomDts实体类
	/// 作者:qiuchao
	/// 创建日期:2015/7/23
	/// </summary>
	public sealed class CustomDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CustomDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CustomDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Ship_CustomDts";
		 
  		private int m_MainID = 0; 
  		public int MainID 
  		{ 
  			get 
  			{ 
  				return m_MainID ; 
  			}  
  			set 
  			{ 
  				m_MainID = value ; 
  			}  
  		} 
  
  		private int m_Seq = 0; 
  		public int Seq 
  		{ 
  			get 
  			{ 
  				return m_Seq ; 
  			}  
  			set 
  			{ 
  				m_Seq = value ; 
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
  
  		private int m_PackPlanID = 0; 
  		public int PackPlanID 
  		{ 
  			get 
  			{ 
  				return m_PackPlanID ; 
  			}  
  			set 
  			{ 
  				m_PackPlanID = value ; 
  			}  
  		} 
  
  		private string m_PackPlanCode = string.Empty ; 
  		public string PackPlanCode 
  		{ 
  			get 
  			{ 
  				return m_PackPlanCode ; 
  			}  
  			set 
  			{ 
  				m_PackPlanCode = value ; 
  			}  
  		} 
  
  		private string m_DSN = string.Empty ; 
  		public string DSN 
  		{ 
  			get 
  			{ 
  				return m_DSN ; 
  			}  
  			set 
  			{ 
  				m_DSN = value ; 
  			}  
  		} 
  
  		private string m_SSN = string.Empty ; 
  		public string SSN 
  		{ 
  			get 
  			{ 
  				return m_SSN ; 
  			}  
  			set 
  			{ 
  				m_SSN = value ; 
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
  
  		private string m_SStyleNo = string.Empty ; 
  		public string SStyleNo 
  		{ 
  			get 
  			{ 
  				return m_SStyleNo ; 
  			}  
  			set 
  			{ 
  				m_SStyleNo = value ; 
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
  
  		private int m_ICheckedQty = 0; 
  		public int ICheckedQty 
  		{ 
  			get 
  			{ 
  				return m_ICheckedQty ; 
  			}  
  			set 
  			{ 
  				m_ICheckedQty = value ; 
  			}  
  		} 
  
  		private decimal m_ICheckedAmount = 0; 
  		public decimal ICheckedAmount 
  		{ 
  			get 
  			{ 
  				return m_ICheckedAmount ; 
  			}  
  			set 
  			{ 
  				m_ICheckedAmount = value ; 
  			}  
  		} 
  
  		private int m_ILeftQty = 0; 
  		public int ILeftQty 
  		{ 
  			get 
  			{ 
  				return m_ILeftQty ; 
  			}  
  			set 
  			{ 
  				m_ILeftQty = value ; 
  			}  
  		} 
  
  		private decimal m_ILeftAmount = 0; 
  		public decimal ILeftAmount 
  		{ 
  			get 
  			{ 
  				return m_ILeftAmount ; 
  			}  
  			set 
  			{ 
  				m_ILeftAmount = value ; 
  			}  
  		} 
  
  		private string m_Style = string.Empty ; 
  		public string Style 
  		{ 
  			get 
  			{ 
  				return m_Style ; 
  			}  
  			set 
  			{ 
  				m_Style = value ; 
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
  
  		private string m_Country = string.Empty ; 
  		public string Country 
  		{ 
  			get 
  			{ 
  				return m_Country ; 
  			}  
  			set 
  			{ 
  				m_Country = value ; 
  			}  
  		} 
  
  		private decimal m_NetQty = 0; 
  		public decimal NetQty 
  		{ 
  			get 
  			{ 
  				return m_NetQty ; 
  			}  
  			set 
  			{ 
  				m_NetQty = value ; 
  			}  
  		} 
  
  		private string m_ZM = string.Empty ; 
  		public string ZM 
  		{ 
  			get 
  			{ 
  				return m_ZM ; 
  			}  
  			set 
  			{ 
  				m_ZM = value ; 
  			}  
  		} 
  
  		private decimal m_NetWeight = 0; 
  		public decimal NetWeight 
  		{ 
  			get 
  			{ 
  				return m_NetWeight ; 
  			}  
  			set 
  			{ 
  				m_NetWeight = value ; 
  			}  
  		} 
  
  		private decimal m_GrossWeight = 0; 
  		public decimal GrossWeight 
  		{ 
  			get 
  			{ 
  				return m_GrossWeight ; 
  			}  
  			set 
  			{ 
  				m_GrossWeight = value ; 
  			}  
  		} 
  
  		private decimal m_USPrice = 0; 
  		public decimal USPrice 
  		{ 
  			get 
  			{ 
  				return m_USPrice ; 
  			}  
  			set 
  			{ 
  				m_USPrice = value ; 
  			}  
  		} 
  
  		private int m_BoxNum = 0; 
  		public int BoxNum 
  		{ 
  			get 
  			{ 
  				return m_BoxNum ; 
  			}  
  			set 
  			{ 
  				m_BoxNum = value ; 
  			}  
  		} 
  
  		private string m_Model = string.Empty ; 
  		public string Model 
  		{ 
  			get 
  			{ 
  				return m_Model ; 
  			}  
  			set 
  			{ 
  				m_Model = value ; 
  			}  
  		} 
  
  		private string m_AmountUnit = string.Empty ; 
  		public string AmountUnit 
  		{ 
  			get 
  			{ 
  				return m_AmountUnit ; 
  			}  
  			set 
  			{ 
  				m_AmountUnit = value ; 
  			}  
  		} 
  
  		private string m_PCSUnit = string.Empty ; 
  		public string PCSUnit 
  		{ 
  			get 
  			{ 
  				return m_PCSUnit ; 
  			}  
  			set 
  			{ 
  				m_PCSUnit = value ; 
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
  
  		private decimal m_SKAmount = 0; 
  		public decimal SKAmount 
  		{ 
  			get 
  			{ 
  				return m_SKAmount ; 
  			}  
  			set 
  			{ 
  				m_SKAmount = value ; 
  			}  
  		} 
  
  		private DateTime m_SKDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SKDate 
  		{ 
  			get 
  			{ 
  				return m_SKDate ; 
  			}  
  			set 
  			{ 
  				m_SKDate = value ; 
  			}  
  		} 
  
  		private string m_SKOP = string.Empty ; 
  		public string SKOP 
  		{ 
  			get 
  			{ 
  				return m_SKOP ; 
  			}  
  			set 
  			{ 
  				m_SKOP = value ; 
  			}  
  		} 
  
  		private decimal m_QGSinglePrice = 0; 
  		public decimal QGSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_QGSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_QGSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_QGAmount = 0; 
  		public decimal QGAmount 
  		{ 
  			get 
  			{ 
  				return m_QGAmount ; 
  			}  
  			set 
  			{ 
  				m_QGAmount = value ; 
  			}  
  		} 
  
  		private decimal m_QGQty = 0; 
  		public decimal QGQty 
  		{ 
  			get 
  			{ 
  				return m_QGQty ; 
  			}  
  			set 
  			{ 
  				m_QGQty = value ; 
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
  
  		private decimal m_PieceQty = 0; 
  		public decimal PieceQty 
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
  
  		private decimal m_Volume = 0; 
  		public decimal Volume 
  		{ 
  			get 
  			{ 
  				return m_Volume ; 
  			}  
  			set 
  			{ 
  				m_Volume = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Ship_CustomDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Ship_CustomDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
                m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_PackPlanID=SysConvert.ToInt32(MasterTable.Rows[0]["PackPlanID"]); 
  				m_PackPlanCode=SysConvert.ToString(MasterTable.Rows[0]["PackPlanCode"]); 
  				m_DSN=SysConvert.ToString(MasterTable.Rows[0]["DSN"]); 
  				m_SSN=SysConvert.ToString(MasterTable.Rows[0]["SSN"]); 
  				m_StyleNo=SysConvert.ToString(MasterTable.Rows[0]["StyleNo"]); 
  				m_SStyleNo=SysConvert.ToString(MasterTable.Rows[0]["SStyleNo"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_ICheckedQty=SysConvert.ToInt32(MasterTable.Rows[0]["ICheckedQty"]); 
  				m_ICheckedAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ICheckedAmount"]); 
  				m_ILeftQty=SysConvert.ToInt32(MasterTable.Rows[0]["ILeftQty"]); 
  				m_ILeftAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ILeftAmount"]); 
  				m_Style=SysConvert.ToString(MasterTable.Rows[0]["Style"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_Country=SysConvert.ToString(MasterTable.Rows[0]["Country"]); 
  				m_NetQty=SysConvert.ToDecimal(MasterTable.Rows[0]["NetQty"]); 
  				m_ZM=SysConvert.ToString(MasterTable.Rows[0]["ZM"]); 
  				m_NetWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["NetWeight"]); 
  				m_GrossWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["GrossWeight"]); 
  				m_USPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["USPrice"]); 
  				m_BoxNum=SysConvert.ToInt32(MasterTable.Rows[0]["BoxNum"]); 
  				m_Model=SysConvert.ToString(MasterTable.Rows[0]["Model"]); 
  				m_AmountUnit=SysConvert.ToString(MasterTable.Rows[0]["AmountUnit"]); 
  				m_PCSUnit=SysConvert.ToString(MasterTable.Rows[0]["PCSUnit"]); 
  				m_SinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SinglePrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_SKAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["SKAmount"]); 
  				m_SKDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SKDate"]); 
  				m_SKOP=SysConvert.ToString(MasterTable.Rows[0]["SKOP"]); 
  				m_QGSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["QGSinglePrice"]); 
  				m_QGAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["QGAmount"]); 
  				m_QGQty=SysConvert.ToDecimal(MasterTable.Rows[0]["QGQty"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_PieceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PieceQty"]); 
  				m_Volume=SysConvert.ToDecimal(MasterTable.Rows[0]["Volume"]); 
  				m_MWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
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
