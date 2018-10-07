using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_RecPayHTDts实体类
	/// 作者:章文强
	/// 创建日期:2013/8/2
	/// </summary>
	public sealed class RecPayHTDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public RecPayHTDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public RecPayHTDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Finance_RecPayHTDts";
		 
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
  
  		private string m_HTOPID = string.Empty ; 
  		public string HTOPID 
  		{ 
  			get 
  			{ 
  				return m_HTOPID ; 
  			}  
  			set 
  			{ 
  				m_HTOPID = value ; 
  			}  
  		} 
  
  		private string m_HTOPName = string.Empty ; 
  		public string HTOPName 
  		{ 
  			get 
  			{ 
  				return m_HTOPName ; 
  			}  
  			set 
  			{ 
  				m_HTOPName = value ; 
  			}  
  		} 
  
  		private string m_HTNo = string.Empty ; 
  		public string HTNo 
  		{ 
  			get 
  			{ 
  				return m_HTNo ; 
  			}  
  			set 
  			{ 
  				m_HTNo = value ; 
  			}  
  		} 
  
  		private int m_HTTypeID = 0; 
  		public int HTTypeID 
  		{ 
  			get 
  			{ 
  				return m_HTTypeID ; 
  			}  
  			set 
  			{ 
  				m_HTTypeID = value ; 
  			}  
  		} 
  
  		private DateTime m_HTDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime HTDate 
  		{ 
  			get 
  			{ 
  				return m_HTDate ; 
  			}  
  			set 
  			{ 
  				m_HTDate = value ; 
  			}  
  		} 
  
  		private decimal m_HTAmount = 0; 
  		public decimal HTAmount 
  		{ 
  			get 
  			{ 
  				return m_HTAmount ; 
  			}  
  			set 
  			{ 
  				m_HTAmount = value ; 
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
  
  		private string m_HTItemCode = string.Empty ; 
  		public string HTItemCode 
  		{ 
  			get 
  			{ 
  				return m_HTItemCode ; 
  			}  
  			set 
  			{ 
  				m_HTItemCode = value ; 
  			}  
  		} 
  
  		private string m_HTGoodsCode = string.Empty ; 
  		public string HTGoodsCode 
  		{ 
  			get 
  			{ 
  				return m_HTGoodsCode ; 
  			}  
  			set 
  			{ 
  				m_HTGoodsCode = value ; 
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
            string Sql="SELECT * FROM Finance_RecPayHTDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_RecPayHTDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_HTOPID=SysConvert.ToString(MasterTable.Rows[0]["HTOPID"]); 
  				m_HTOPName=SysConvert.ToString(MasterTable.Rows[0]["HTOPName"]); 
  				m_HTNo=SysConvert.ToString(MasterTable.Rows[0]["HTNo"]); 
  				m_HTTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["HTTypeID"]); 
  				m_HTDate=SysConvert.ToDateTime(MasterTable.Rows[0]["HTDate"]); 
  				m_HTAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["HTAmount"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_HTItemCode=SysConvert.ToString(MasterTable.Rows[0]["HTItemCode"]); 
  				m_HTGoodsCode=SysConvert.ToString(MasterTable.Rows[0]["HTGoodsCode"]); 
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
