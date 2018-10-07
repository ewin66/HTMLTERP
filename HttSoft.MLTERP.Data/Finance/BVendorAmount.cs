using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_BVendorAmount实体类
	/// 作者:章文强
	/// 创建日期:2014/9/17
	/// </summary>
	public sealed class BVendorAmount : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public BVendorAmount()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public BVendorAmount(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Finance_BVendorAmount";
		 
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
  
  		private decimal m_BQty = 0; 
  		public decimal BQty 
  		{ 
  			get 
  			{ 
  				return m_BQty ; 
  			}  
  			set 
  			{ 
  				m_BQty = value ; 
  			}  
  		} 
  
  		private int m_BPieceQty = 0; 
  		public int BPieceQty 
  		{ 
  			get 
  			{ 
  				return m_BPieceQty ; 
  			}  
  			set 
  			{ 
  				m_BPieceQty = value ; 
  			}  
  		} 
  
  		private decimal m_BAmount = 0; 
  		public decimal BAmount 
  		{ 
  			get 
  			{ 
  				return m_BAmount ; 
  			}  
  			set 
  			{ 
  				m_BAmount = value ; 
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
  
  		private string m_UpdateOP = string.Empty ; 
  		public string UpdateOP 
  		{ 
  			get 
  			{ 
  				return m_UpdateOP ; 
  			}  
  			set 
  			{ 
  				m_UpdateOP = value ; 
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
  
  		private int m_DZTypeID = 0; 
  		public int DZTypeID 
  		{ 
  			get 
  			{ 
  				return m_DZTypeID ; 
  			}  
  			set 
  			{ 
  				m_DZTypeID = value ; 
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
            string Sql="SELECT * FROM Finance_BVendorAmount WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_BVendorAmount WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_BQty=SysConvert.ToDecimal(MasterTable.Rows[0]["BQty"]); 
  				m_BPieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["BPieceQty"]); 
  				m_BAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["BAmount"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_UpdateOP=SysConvert.ToString(MasterTable.Rows[0]["UpdateOP"]); 
  				m_UpdateDate=SysConvert.ToDateTime(MasterTable.Rows[0]["UpdateDate"]); 
  				m_DZTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["DZTypeID"]); 
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
