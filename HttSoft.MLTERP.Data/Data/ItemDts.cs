using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_ItemDts实体类
	/// 作者:章文强
	/// 创建日期:2014/11/21
	/// </summary>
	public sealed class ItemDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_ItemDts";
		 
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
  
  		private string m_DtsItemCode = string.Empty ; 
  		public string DtsItemCode 
  		{ 
  			get 
  			{ 
  				return m_DtsItemCode ; 
  			}  
  			set 
  			{ 
  				m_DtsItemCode = value ; 
  			}  
  		} 
  
  		private string m_DtsItemName = string.Empty ; 
  		public string DtsItemName 
  		{ 
  			get 
  			{ 
  				return m_DtsItemName ; 
  			}  
  			set 
  			{ 
  				m_DtsItemName = value ; 
  			}  
  		} 
  
  		private string m_DtsItemStd = string.Empty ; 
  		public string DtsItemStd 
  		{ 
  			get 
  			{ 
  				return m_DtsItemStd ; 
  			}  
  			set 
  			{ 
  				m_DtsItemStd = value ; 
  			}  
  		} 
  
  		private string m_DtsItemModel = string.Empty ; 
  		public string DtsItemModel 
  		{ 
  			get 
  			{ 
  				return m_DtsItemModel ; 
  			}  
  			set 
  			{ 
  				m_DtsItemModel = value ; 
  			}  
  		} 
  
  		private decimal m_Percentage = 0; 
  		public decimal Percentage 
  		{ 
  			get 
  			{ 
  				return m_Percentage ; 
  			}  
  			set 
  			{ 
  				m_Percentage = value ; 
  			}  
  		} 
  
  		private decimal m_Loss = 0; 
  		public decimal Loss 
  		{ 
  			get 
  			{ 
  				return m_Loss ; 
  			}  
  			set 
  			{ 
  				m_Loss = value ; 
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
  
  		private decimal m_PerMiWeight = 0; 
  		public decimal PerMiWeight 
  		{ 
  			get 
  			{ 
  				return m_PerMiWeight ; 
  			}  
  			set 
  			{ 
  				m_PerMiWeight = value ; 
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
  
  		private string m_MWeight2 = string.Empty ; 
  		public string MWeight2 
  		{ 
  			get 
  			{ 
  				return m_MWeight2 ; 
  			}  
  			set 
  			{ 
  				m_MWeight2 = value ; 
  			}  
  		} 
  
  		private string m_FactoryID = string.Empty ; 
  		public string FactoryID 
  		{ 
  			get 
  			{ 
  				return m_FactoryID ; 
  			}  
  			set 
  			{ 
  				m_FactoryID = value ; 
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
  
  		private decimal m_Price = 0; 
  		public decimal Price 
  		{ 
  			get 
  			{ 
  				return m_Price ; 
  			}  
  			set 
  			{ 
  				m_Price = value ; 
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
  
  		private string m_ReqDate = string.Empty ; 
  		public string ReqDate 
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
  
  		private string m_MinQty = string.Empty ; 
  		public string MinQty 
  		{ 
  			get 
  			{ 
  				return m_MinQty ; 
  			}  
  			set 
  			{ 
  				m_MinQty = value ; 
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
            string Sql="SELECT * FROM Data_ItemDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ItemDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_DtsItemCode=SysConvert.ToString(MasterTable.Rows[0]["DtsItemCode"]); 
  				m_DtsItemName=SysConvert.ToString(MasterTable.Rows[0]["DtsItemName"]); 
  				m_DtsItemStd=SysConvert.ToString(MasterTable.Rows[0]["DtsItemStd"]); 
  				m_DtsItemModel=SysConvert.ToString(MasterTable.Rows[0]["DtsItemModel"]); 
  				m_Percentage=SysConvert.ToDecimal(MasterTable.Rows[0]["Percentage"]); 
  				m_Loss=SysConvert.ToDecimal(MasterTable.Rows[0]["Loss"]); 
  				m_SinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SinglePrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_PerMiWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["PerMiWeight"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_MWeight2=SysConvert.ToString(MasterTable.Rows[0]["MWeight2"]); 
  				m_FactoryID=SysConvert.ToString(MasterTable.Rows[0]["FactoryID"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_Price=SysConvert.ToDecimal(MasterTable.Rows[0]["Price"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_ReqDate=SysConvert.ToString(MasterTable.Rows[0]["ReqDate"]); 
  				m_MinQty=SysConvert.ToString(MasterTable.Rows[0]["MinQty"]); 
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
