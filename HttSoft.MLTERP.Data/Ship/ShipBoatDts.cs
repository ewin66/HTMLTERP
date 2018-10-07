using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Ship_ShipBoatDts实体类
	/// 作者:qiuchao
	/// 创建日期:2015/7/21
	/// </summary>
	public sealed class ShipBoatDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ShipBoatDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ShipBoatDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Ship_ShipBoatDts";
		 
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
  
  		private decimal m_CrossWeight = 0; 
  		public decimal CrossWeight 
  		{ 
  			get 
  			{ 
  				return m_CrossWeight ; 
  			}  
  			set 
  			{ 
  				m_CrossWeight = value ; 
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
  
  		private decimal m_SizeChang = 0; 
  		public decimal SizeChang 
  		{ 
  			get 
  			{ 
  				return m_SizeChang ; 
  			}  
  			set 
  			{ 
  				m_SizeChang = value ; 
  			}  
  		} 
  
  		private decimal m_SizeKuan = 0; 
  		public decimal SizeKuan 
  		{ 
  			get 
  			{ 
  				return m_SizeKuan ; 
  			}  
  			set 
  			{ 
  				m_SizeKuan = value ; 
  			}  
  		} 
  
  		private decimal m_SizeGao = 0; 
  		public decimal SizeGao 
  		{ 
  			get 
  			{ 
  				return m_SizeGao ; 
  			}  
  			set 
  			{ 
  				m_SizeGao = value ; 
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
  
  		private decimal m_BoxNum = 0; 
  		public decimal BoxNum 
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
  
  		private string m_HSCODE = string.Empty ; 
  		public string HSCODE 
  		{ 
  			get 
  			{ 
  				return m_HSCODE ; 
  			}  
  			set 
  			{ 
  				m_HSCODE = value ; 
  			}  
  		} 
  
  		private string m_dex = string.Empty ; 
  		public string dex 
  		{ 
  			get 
  			{ 
  				return m_dex ; 
  			}  
  			set 
  			{ 
  				m_dex = value ; 
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
  
  		private int m_PrintStatus = 0; 
  		public int PrintStatus 
  		{ 
  			get 
  			{ 
  				return m_PrintStatus ; 
  			}  
  			set 
  			{ 
  				m_PrintStatus = value ; 
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
  
  		private string m_TSItemName = string.Empty ; 
  		public string TSItemName 
  		{ 
  			get 
  			{ 
  				return m_TSItemName ; 
  			}  
  			set 
  			{ 
  				m_TSItemName = value ; 
  			}  
  		} 
  
  		private decimal m_BulkSize = 0; 
  		public decimal BulkSize 
  		{ 
  			get 
  			{ 
  				return m_BulkSize ; 
  			}  
  			set 
  			{ 
  				m_BulkSize = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Ship_ShipBoatDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Ship_ShipBoatDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
  				m_SSN=SysConvert.ToString(MasterTable.Rows[0]["SSN"]); 
  				m_DSN=SysConvert.ToString(MasterTable.Rows[0]["DSN"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_CrossWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["CrossWeight"]); 
  				m_NetWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["NetWeight"]); 
  				m_SizeChang=SysConvert.ToDecimal(MasterTable.Rows[0]["SizeChang"]); 
  				m_SizeKuan=SysConvert.ToDecimal(MasterTable.Rows[0]["SizeKuan"]); 
  				m_SizeGao=SysConvert.ToDecimal(MasterTable.Rows[0]["SizeGao"]); 
  				m_StyleNo=SysConvert.ToString(MasterTable.Rows[0]["StyleNo"]); 
  				m_Style=SysConvert.ToString(MasterTable.Rows[0]["Style"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_BoxNum=SysConvert.ToDecimal(MasterTable.Rows[0]["BoxNum"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_Country=SysConvert.ToString(MasterTable.Rows[0]["Country"]); 
  				m_HSCODE=SysConvert.ToString(MasterTable.Rows[0]["HSCODE"]); 
  				m_dex=SysConvert.ToString(MasterTable.Rows[0]["dex"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_SinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SinglePrice"]); 
  				m_PrintStatus=SysConvert.ToInt32(MasterTable.Rows[0]["PrintStatus"]); 
  				m_Model=SysConvert.ToString(MasterTable.Rows[0]["Model"]); 
  				m_ID=SysConvert.ToInt32(MasterTable.Rows[0]["ID"]); 
  				m_TSItemName=SysConvert.ToString(MasterTable.Rows[0]["TSItemName"]); 
  				m_BulkSize=SysConvert.ToDecimal(MasterTable.Rows[0]["BulkSize"]); 
  				m_MWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
  				m_PieceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PieceQty"]); 
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
