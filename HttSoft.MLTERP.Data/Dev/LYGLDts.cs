using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Dev_LYGLDts实体类
	/// 作者:章文强
	/// 创建日期:2014/3/18
	/// </summary>
	public sealed class LYGLDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public LYGLDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public LYGLDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Dev_LYGLDts";
		 
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
  
  		private string m_JQDesc = string.Empty ; 
  		public string JQDesc 
  		{ 
  			get 
  			{ 
  				return m_JQDesc ; 
  			}  
  			set 
  			{ 
  				m_JQDesc = value ; 
  			}  
  		} 
  
  		private int m_PBFlag = 0; 
  		public int PBFlag 
  		{ 
  			get 
  			{ 
  				return m_PBFlag ; 
  			}  
  			set 
  			{ 
  				m_PBFlag = value ; 
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
  
  		private DateTime m_SalePriceDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SalePriceDate 
  		{ 
  			get 
  			{ 
  				return m_SalePriceDate ; 
  			}  
  			set 
  			{ 
  				m_SalePriceDate = value ; 
  			}  
  		} 
  
  		private decimal m_SalePrice = 0; 
  		public decimal SalePrice 
  		{ 
  			get 
  			{ 
  				return m_SalePrice ; 
  			}  
  			set 
  			{ 
  				m_SalePrice = value ; 
  			}  
  		} 
  
  		private string m_SaleQYSource = string.Empty ; 
  		public string SaleQYSource 
  		{ 
  			get 
  			{ 
  				return m_SaleQYSource ; 
  			}  
  			set 
  			{ 
  				m_SaleQYSource = value ; 
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
  
  		private int m_JYFlag = 0; 
  		public int JYFlag 
  		{ 
  			get 
  			{ 
  				return m_JYFlag ; 
  			}  
  			set 
  			{ 
  				m_JYFlag = value ; 
  			}  
  		} 
  
  		private int m_LYType = 0; 
  		public int LYType 
  		{ 
  			get 
  			{ 
  				return m_LYType ; 
  			}  
  			set 
  			{ 
  				m_LYType = value ; 
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
            string Sql="SELECT * FROM Dev_LYGLDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Dev_LYGLDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_GBCode=SysConvert.ToString(MasterTable.Rows[0]["GBCode"]); 
  				m_JQDesc=SysConvert.ToString(MasterTable.Rows[0]["JQDesc"]); 
  				m_PBFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PBFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SalePriceDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SalePriceDate"]); 
  				m_SalePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SalePrice"]); 
  				m_SaleQYSource=SysConvert.ToString(MasterTable.Rows[0]["SaleQYSource"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_MWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_JYFlag=SysConvert.ToInt32(MasterTable.Rows[0]["JYFlag"]); 
  				m_LYType=SysConvert.ToInt32(MasterTable.Rows[0]["LYType"]); 
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
