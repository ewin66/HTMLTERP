using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：Data_FormNCVendor实体类
	/// 作者:陈加海
	/// 创建日期:2012-4-17
	/// </summary>
	public sealed class FormNCVendor : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FormNCVendor()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FormNCVendor(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
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
  
  		private int m_FNCVID = 0; 
  		public int FNCVID 
  		{ 
  			get 
  			{ 
  				return m_FNCVID ; 
  			}  
  			set 
  			{ 
  				m_FNCVID = value ; 
  			}  
  		} 
  
  		private int m_CurSort = 0; 
  		public int CurSort 
  		{ 
  			get 
  			{ 
  				return m_CurSort ; 
  			}  
  			set 
  			{ 
  				m_CurSort = value ; 
  			}  
  		} 
  
  		private int m_CurYear = 0; 
  		public int CurYear 
  		{ 
  			get 
  			{ 
  				return m_CurYear ; 
  			}  
  			set 
  			{ 
  				m_CurYear = value ; 
  			}  
  		} 
  
  		private int m_CurMonth = 0; 
  		public int CurMonth 
  		{ 
  			get 
  			{ 
  				return m_CurMonth ; 
  			}  
  			set 
  			{ 
  				m_CurMonth = value ; 
  			}  
  		} 
  
  		private int m_CurDay = 0; 
  		public int CurDay 
  		{ 
  			get 
  			{ 
  				return m_CurDay ; 
  			}  
  			set 
  			{ 
  				m_CurDay = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_FormNCVendor WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_FormNCVendor WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FNCVID=SysConvert.ToInt32(MasterTable.Rows[0]["FNCVID"]); 
  				m_CurSort=SysConvert.ToInt32(MasterTable.Rows[0]["CurSort"]); 
  				m_CurYear=SysConvert.ToInt32(MasterTable.Rows[0]["CurYear"]); 
  				m_CurMonth=SysConvert.ToInt32(MasterTable.Rows[0]["CurMonth"]); 
  				m_CurDay=SysConvert.ToInt32(MasterTable.Rows[0]["CurDay"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
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
