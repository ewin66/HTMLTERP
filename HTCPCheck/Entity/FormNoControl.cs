using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：Enum_FormNoControl实体类
	/// 作者:陈加海
	/// 创建日期:2012-4-17
	/// </summary>
	public sealed class FormNoControl : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FormNoControl()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FormNoControl(IDBTransAccess p_SqlCmd)
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
  
  		private string m_Code = string.Empty ; 
  		public string Code 
  		{ 
  			get 
  			{ 
  				return m_Code ; 
  			}  
  			set 
  			{ 
  				m_Code = value ; 
  			}  
  		} 
  
  		private int m_NoType = 0; 
  		public int NoType 
  		{ 
  			get 
  			{ 
  				return m_NoType ; 
  			}  
  			set 
  			{ 
  				m_NoType = value ; 
  			}  
  		} 
  
  		private string m_FormNM = string.Empty ; 
  		public string FormNM 
  		{ 
  			get 
  			{ 
  				return m_FormNM ; 
  			}  
  			set 
  			{ 
  				m_FormNM = value ; 
  			}  
  		} 
  
  		private string m_FormRuleSpecial = string.Empty ; 
  		public string FormRuleSpecial 
  		{ 
  			get 
  			{ 
  				return m_FormRuleSpecial ; 
  			}  
  			set 
  			{ 
  				m_FormRuleSpecial = value ; 
  			}  
  		} 
  
  		private string m_FormRulePre = string.Empty ; 
  		public string FormRulePre 
  		{ 
  			get 
  			{ 
  				return m_FormRulePre ; 
  			}  
  			set 
  			{ 
  				m_FormRulePre = value ; 
  			}  
  		} 
  
  		private string m_FormRuleSort = string.Empty ; 
  		public string FormRuleSort 
  		{ 
  			get 
  			{ 
  				return m_FormRuleSort ; 
  			}  
  			set 
  			{ 
  				m_FormRuleSort = value ; 
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
  
  		private string m_DTableName = string.Empty ; 
  		public string DTableName 
  		{ 
  			get 
  			{ 
  				return m_DTableName ; 
  			}  
  			set 
  			{ 
  				m_DTableName = value ; 
  			}  
  		} 
  
  		private string m_DFieldName = string.Empty ; 
  		public string DFieldName 
  		{ 
  			get 
  			{ 
  				return m_DFieldName ; 
  			}  
  			set 
  			{ 
  				m_DFieldName = value ; 
  			}  
  		} 
  
  		private string m_Condition = string.Empty ; 
  		public string Condition 
  		{ 
  			get 
  			{ 
  				return m_Condition ; 
  			}  
  			set 
  			{ 
  				m_Condition = value ; 
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
  
  		private string m_SortAddType = string.Empty ; 
  		public string SortAddType 
  		{ 
  			get 
  			{ 
  				return m_SortAddType ; 
  			}  
  			set 
  			{ 
  				m_SortAddType = value ; 
  			}  
  		} 
  
  		private int m_DelFlag = 0; 
  		public int DelFlag 
  		{ 
  			get 
  			{ 
  				return m_DelFlag ; 
  			}  
  			set 
  			{ 
  				m_DelFlag = value ; 
  			}  
  		} 
  
  		private int m_SourceFlag = 0; 
  		public int SourceFlag 
  		{ 
  			get 
  			{ 
  				return m_SourceFlag ; 
  			}  
  			set 
  			{ 
  				m_SourceFlag = value ; 
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
            string Sql="SELECT * FROM Enum_FormNoControl WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_FormNoControl WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_NoType=SysConvert.ToInt32(MasterTable.Rows[0]["NoType"]); 
  				m_FormNM=SysConvert.ToString(MasterTable.Rows[0]["FormNM"]); 
  				m_FormRuleSpecial=SysConvert.ToString(MasterTable.Rows[0]["FormRuleSpecial"]); 
  				m_FormRulePre=SysConvert.ToString(MasterTable.Rows[0]["FormRulePre"]); 
  				m_FormRuleSort=SysConvert.ToString(MasterTable.Rows[0]["FormRuleSort"]); 
  				m_CurSort=SysConvert.ToInt32(MasterTable.Rows[0]["CurSort"]); 
  				m_CurYear=SysConvert.ToInt32(MasterTable.Rows[0]["CurYear"]); 
  				m_CurMonth=SysConvert.ToInt32(MasterTable.Rows[0]["CurMonth"]); 
  				m_CurDay=SysConvert.ToInt32(MasterTable.Rows[0]["CurDay"]); 
  				m_DTableName=SysConvert.ToString(MasterTable.Rows[0]["DTableName"]); 
  				m_DFieldName=SysConvert.ToString(MasterTable.Rows[0]["DFieldName"]); 
  				m_Condition=SysConvert.ToString(MasterTable.Rows[0]["Condition"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SortAddType=SysConvert.ToString(MasterTable.Rows[0]["SortAddType"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_SourceFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SourceFlag"]); 
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
