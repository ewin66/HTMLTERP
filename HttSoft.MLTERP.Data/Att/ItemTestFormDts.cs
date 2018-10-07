using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Att_ItemTestFormDts实体类
	/// 作者:章文强
	/// 创建日期:2012/6/4
	/// </summary>
	public sealed class ItemTestFormDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemTestFormDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemTestFormDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Att_ItemTestFormDts";
		 
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
  
  		private int m_Sort = 0; 
  		public int Sort 
  		{ 
  			get 
  			{ 
  				return m_Sort ; 
  			}  
  			set 
  			{ 
  				m_Sort = value ; 
  			}  
  		} 
  
  		private string m_CheckItem = string.Empty ; 
  		public string CheckItem 
  		{ 
  			get 
  			{ 
  				return m_CheckItem ; 
  			}  
  			set 
  			{ 
  				m_CheckItem = value ; 
  			}  
  		} 
  
  		private string m_CheckUnit = string.Empty ; 
  		public string CheckUnit 
  		{ 
  			get 
  			{ 
  				return m_CheckUnit ; 
  			}  
  			set 
  			{ 
  				m_CheckUnit = value ; 
  			}  
  		} 
  
  		private string m_TecReq = string.Empty ; 
  		public string TecReq 
  		{ 
  			get 
  			{ 
  				return m_TecReq ; 
  			}  
  			set 
  			{ 
  				m_TecReq = value ; 
  			}  
  		} 
  
  		private string m_CheckResult = string.Empty ; 
  		public string CheckResult 
  		{ 
  			get 
  			{ 
  				return m_CheckResult ; 
  			}  
  			set 
  			{ 
  				m_CheckResult = value ; 
  			}  
  		} 
  
  		private string m_PJ = string.Empty ; 
  		public string PJ 
  		{ 
  			get 
  			{ 
  				return m_PJ ; 
  			}  
  			set 
  			{ 
  				m_PJ = value ; 
  			}  
  		} 
  
  		private decimal m_TFree = 0; 
  		public decimal TFree 
  		{ 
  			get 
  			{ 
  				return m_TFree ; 
  			}  
  			set 
  			{ 
  				m_TFree = value ; 
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
            string Sql="SELECT * FROM Att_ItemTestFormDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Att_ItemTestFormDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Sort=SysConvert.ToInt32(MasterTable.Rows[0]["Sort"]); 
  				m_CheckItem=SysConvert.ToString(MasterTable.Rows[0]["CheckItem"]); 
  				m_CheckUnit=SysConvert.ToString(MasterTable.Rows[0]["CheckUnit"]); 
  				m_TecReq=SysConvert.ToString(MasterTable.Rows[0]["TecReq"]); 
  				m_CheckResult=SysConvert.ToString(MasterTable.Rows[0]["CheckResult"]); 
  				m_PJ=SysConvert.ToString(MasterTable.Rows[0]["PJ"]); 
  				m_TFree=SysConvert.ToDecimal(MasterTable.Rows[0]["TFree"]); 
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
