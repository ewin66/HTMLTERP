using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_VendorDesDts实体类
	/// 作者:章文强
	/// 创建日期:2012/12/7
	/// </summary>
	public sealed class VendorDesDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public VendorDesDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public VendorDesDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_VendorDesDts";
		 
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
  
  		private DateTime m_DCDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime DCDate 
  		{ 
  			get 
  			{ 
  				return m_DCDate ; 
  			}  
  			set 
  			{ 
  				m_DCDate = value ; 
  			}  
  		} 
  
  		private string m_Address = string.Empty ; 
  		public string Address 
  		{ 
  			get 
  			{ 
  				return m_Address ; 
  			}  
  			set 
  			{ 
  				m_Address = value ; 
  			}  
  		} 
  
  		private string m_LeftBrand = string.Empty ; 
  		public string LeftBrand 
  		{ 
  			get 
  			{ 
  				return m_LeftBrand ; 
  			}  
  			set 
  			{ 
  				m_LeftBrand = value ; 
  			}  
  		} 
  
  		private string m_RightBrand = string.Empty ; 
  		public string RightBrand 
  		{ 
  			get 
  			{ 
  				return m_RightBrand ; 
  			}  
  			set 
  			{ 
  				m_RightBrand = value ; 
  			}  
  		} 
  
  		private string m_TopBrand = string.Empty ; 
  		public string TopBrand 
  		{ 
  			get 
  			{ 
  				return m_TopBrand ; 
  			}  
  			set 
  			{ 
  				m_TopBrand = value ; 
  			}  
  		} 
  
  		private string m_ButtBrand = string.Empty ; 
  		public string ButtBrand 
  		{ 
  			get 
  			{ 
  				return m_ButtBrand ; 
  			}  
  			set 
  			{ 
  				m_ButtBrand = value ; 
  			}  
  		} 
  
  		private string m_ITEM = string.Empty ; 
  		public string ITEM 
  		{ 
  			get 
  			{ 
  				return m_ITEM ; 
  			}  
  			set 
  			{ 
  				m_ITEM = value ; 
  			}  
  		} 
  
  		private string m_ItemPrice = string.Empty ; 
  		public string ItemPrice 
  		{ 
  			get 
  			{ 
  				return m_ItemPrice ; 
  			}  
  			set 
  			{ 
  				m_ItemPrice = value ; 
  			}  
  		} 
  
  		private string m_CFBL = string.Empty ; 
  		public string CFBL 
  		{ 
  			get 
  			{ 
  				return m_CFBL ; 
  			}  
  			set 
  			{ 
  				m_CFBL = value ; 
  			}  
  		} 
  
  		private string m_LB = string.Empty ; 
  		public string LB 
  		{ 
  			get 
  			{ 
  				return m_LB ; 
  			}  
  			set 
  			{ 
  				m_LB = value ; 
  			}  
  		} 
  
  		private string m_SX = string.Empty ; 
  		public string SX 
  		{ 
  			get 
  			{ 
  				return m_SX ; 
  			}  
  			set 
  			{ 
  				m_SX = value ; 
  			}  
  		} 
  
  		private string m_AddPS = string.Empty ; 
  		public string AddPS 
  		{ 
  			get 
  			{ 
  				return m_AddPS ; 
  			}  
  			set 
  			{ 
  				m_AddPS = value ; 
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
            string Sql="SELECT * FROM Data_VendorDesDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_VendorDesDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_DCDate=SysConvert.ToDateTime(MasterTable.Rows[0]["DCDate"]); 
  				m_Address=SysConvert.ToString(MasterTable.Rows[0]["Address"]); 
  				m_LeftBrand=SysConvert.ToString(MasterTable.Rows[0]["LeftBrand"]); 
  				m_RightBrand=SysConvert.ToString(MasterTable.Rows[0]["RightBrand"]); 
  				m_TopBrand=SysConvert.ToString(MasterTable.Rows[0]["TopBrand"]); 
  				m_ButtBrand=SysConvert.ToString(MasterTable.Rows[0]["ButtBrand"]); 
  				m_ITEM=SysConvert.ToString(MasterTable.Rows[0]["ITEM"]); 
  				m_ItemPrice=SysConvert.ToString(MasterTable.Rows[0]["ItemPrice"]); 
  				m_CFBL=SysConvert.ToString(MasterTable.Rows[0]["CFBL"]); 
  				m_LB=SysConvert.ToString(MasterTable.Rows[0]["LB"]); 
  				m_SX=SysConvert.ToString(MasterTable.Rows[0]["SX"]); 
  				m_AddPS=SysConvert.ToString(MasterTable.Rows[0]["AddPS"]); 
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
