using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_ItemGreyFabReplace实体类
	/// 作者:qiuchao
	/// 创建日期:2015/6/6
	/// </summary>
	public sealed class ItemGreyFabReplace : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemGreyFabReplace()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemGreyFabReplace(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_ItemGreyFabReplace";
		 
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
  
  		private string m_GreyFabItemCode = string.Empty ; 
  		public string GreyFabItemCode 
  		{ 
  			get 
  			{ 
  				return m_GreyFabItemCode ; 
  			}  
  			set 
  			{ 
  				m_GreyFabItemCode = value ; 
  			}  
  		} 
  
  		private string m_ReplaceFabItemCode = string.Empty ; 
  		public string ReplaceFabItemCode 
  		{ 
  			get 
  			{ 
  				return m_ReplaceFabItemCode ; 
  			}  
  			set 
  			{ 
  				m_ReplaceFabItemCode = value ; 
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
  
  		private decimal m_PBPrice = 0; 
  		public decimal PBPrice 
  		{ 
  			get 
  			{ 
  				return m_PBPrice ; 
  			}  
  			set 
  			{ 
  				m_PBPrice = value ; 
  			}  
  		} 
  
  		private decimal m_DyePrice = 0; 
  		public decimal DyePrice 
  		{ 
  			get 
  			{ 
  				return m_DyePrice ; 
  			}  
  			set 
  			{ 
  				m_DyePrice = value ; 
  			}  
  		} 
  
  		private string m_DyeVendorID = string.Empty ; 
  		public string DyeVendorID 
  		{ 
  			get 
  			{ 
  				return m_DyeVendorID ; 
  			}  
  			set 
  			{ 
  				m_DyeVendorID = value ; 
  			}  
  		} 
  
  		private string m_Str1 = string.Empty ; 
  		public string Str1 
  		{ 
  			get 
  			{ 
  				return m_Str1 ; 
  			}  
  			set 
  			{ 
  				m_Str1 = value ; 
  			}  
  		} 
  
  		private string m_Str2 = string.Empty ; 
  		public string Str2 
  		{ 
  			get 
  			{ 
  				return m_Str2 ; 
  			}  
  			set 
  			{ 
  				m_Str2 = value ; 
  			}  
  		} 
  
  		private string m_Str3 = string.Empty ; 
  		public string Str3 
  		{ 
  			get 
  			{ 
  				return m_Str3 ; 
  			}  
  			set 
  			{ 
  				m_Str3 = value ; 
  			}  
  		} 
  
  		private decimal m_SL = 0; 
  		public decimal SL 
  		{ 
  			get 
  			{ 
  				return m_SL ; 
  			}  
  			set 
  			{ 
  				m_SL = value ; 
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
            string Sql="SELECT * FROM Data_ItemGreyFabReplace WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ItemGreyFabReplace WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_GreyFabItemCode=SysConvert.ToString(MasterTable.Rows[0]["GreyFabItemCode"]); 
  				m_ReplaceFabItemCode=SysConvert.ToString(MasterTable.Rows[0]["ReplaceFabItemCode"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_Needle=SysConvert.ToString(MasterTable.Rows[0]["Needle"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_PBPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["PBPrice"]); 
  				m_DyePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DyePrice"]); 
  				m_DyeVendorID=SysConvert.ToString(MasterTable.Rows[0]["DyeVendorID"]); 
  				m_Str1=SysConvert.ToString(MasterTable.Rows[0]["Str1"]); 
  				m_Str2=SysConvert.ToString(MasterTable.Rows[0]["Str2"]); 
  				m_Str3=SysConvert.ToString(MasterTable.Rows[0]["Str3"]); 
  				m_SL=SysConvert.ToDecimal(MasterTable.Rows[0]["SL"]); 
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
