using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_UpdateWHSinglePrice实体类
	/// 作者:章文强
	/// 创建日期:2012/12/19
	/// </summary>
	public sealed class UpdateWHSinglePrice : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public UpdateWHSinglePrice()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public UpdateWHSinglePrice(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_UpdateWHSinglePrice";
		 
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
  
  		private int m_DtsID = 0; 
  		public int DtsID 
  		{ 
  			get 
  			{ 
  				return m_DtsID ; 
  			}  
  			set 
  			{ 
  				m_DtsID = value ; 
  			}  
  		} 
  
  		private decimal m_NewSinglePrice = 0; 
  		public decimal NewSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_NewSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_NewSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_OldSinglePrice = 0; 
  		public decimal OldSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_OldSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_OldSinglePrice = value ; 
  			}  
  		} 
  
  		private string m_UpdateOPName = string.Empty ; 
  		public string UpdateOPName 
  		{ 
  			get 
  			{ 
  				return m_UpdateOPName ; 
  			}  
  			set 
  			{ 
  				m_UpdateOPName = value ; 
  			}  
  		} 
  
  		private DateTime m_UpdateDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime UpdateDate 
  		{ 
  			get 
  			{ 
  				return m_UpdateDate ; 
  			}  
  			set 
  			{ 
  				m_UpdateDate = value ; 
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
            string Sql="SELECT * FROM Data_UpdateWHSinglePrice WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_UpdateWHSinglePrice WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_DtsID=SysConvert.ToInt32(MasterTable.Rows[0]["DtsID"]); 
  				m_NewSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["NewSinglePrice"]); 
  				m_OldSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["OldSinglePrice"]); 
  				m_UpdateOPName=SysConvert.ToString(MasterTable.Rows[0]["UpdateOPName"]); 
  				m_UpdateDate=SysConvert.ToDateTime(MasterTable.Rows[0]["UpdateDate"]); 
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
