using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_UpdateWHVendor实体类
	/// 作者:章文强
	/// 创建日期:2012/10/12
	/// </summary>
	public sealed class UpdateWHVendor : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public UpdateWHVendor()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public UpdateWHVendor(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_UpdateWHVendor";
		 
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
  
  		private string m_OldVendor = string.Empty ; 
  		public string OldVendor 
  		{ 
  			get 
  			{ 
  				return m_OldVendor ; 
  			}  
  			set 
  			{ 
  				m_OldVendor = value ; 
  			}  
  		} 
  
  		private string m_NewVendor = string.Empty ; 
  		public string NewVendor 
  		{ 
  			get 
  			{ 
  				return m_NewVendor ; 
  			}  
  			set 
  			{ 
  				m_NewVendor = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_UpdateWHVendor WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_UpdateWHVendor WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_OldVendor=SysConvert.ToString(MasterTable.Rows[0]["OldVendor"]); 
  				m_NewVendor=SysConvert.ToString(MasterTable.Rows[0]["NewVendor"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_UpdateOPName=SysConvert.ToString(MasterTable.Rows[0]["UpdateOPName"]); 
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
