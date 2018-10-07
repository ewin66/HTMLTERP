using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：ADH_CheckFormDts实体类
	/// 作者:章文强
	/// 创建日期:2012/10/26
	/// </summary>
	public sealed class CheckFormDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CheckFormDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckFormDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "ADH_CheckFormDts";
		 
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
  
  		private string m_ISN = string.Empty ; 
  		public string ISN 
  		{ 
  			get 
  			{ 
  				return m_ISN ; 
  			}  
  			set 
  			{ 
  				m_ISN = value ; 
  			}  
  		} 
  
  		private int m_DataGradeID = 0; 
  		public int DataGradeID 
  		{ 
  			get 
  			{ 
  				return m_DataGradeID ; 
  			}  
  			set 
  			{ 
  				m_DataGradeID = value ; 
  			}  
  		} 
  
  		private string m_SOQtyDesc = string.Empty ; 
  		public string SOQtyDesc 
  		{ 
  			get 
  			{ 
  				return m_SOQtyDesc ; 
  			}  
  			set 
  			{ 
  				m_SOQtyDesc = value ; 
  			}  
  		} 
  
  		private string m_SODateDesc = string.Empty ; 
  		public string SODateDesc 
  		{ 
  			get 
  			{ 
  				return m_SODateDesc ; 
  			}  
  			set 
  			{ 
  				m_SODateDesc = value ; 
  			}  
  		} 
  
  		private DateTime m_AddTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime AddTime 
  		{ 
  			get 
  			{ 
  				return m_AddTime ; 
  			}  
  			set 
  			{ 
  				m_AddTime = value ; 
  			}  
  		} 
  
  		private DateTime m_UpdTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime UpdTime 
  		{ 
  			get 
  			{ 
  				return m_UpdTime ; 
  			}  
  			set 
  			{ 
  				m_UpdTime = value ; 
  			}  
  		} 
  
  		private int m_YPQty = 0; 
  		public int YPQty 
  		{ 
  			get 
  			{ 
  				return m_YPQty ; 
  			}  
  			set 
  			{ 
  				m_YPQty = value ; 
  			}  
  		} 
  
  		private decimal m_YSQty = 0; 
  		public decimal YSQty 
  		{ 
  			get 
  			{ 
  				return m_YSQty ; 
  			}  
  			set 
  			{ 
  				m_YSQty = value ; 
  			}  
  		} 
  
  		private string m_FreeStr1 = string.Empty ; 
  		public string FreeStr1 
  		{ 
  			get 
  			{ 
  				return m_FreeStr1 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr1 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr2 = string.Empty ; 
  		public string FreeStr2 
  		{ 
  			get 
  			{ 
  				return m_FreeStr2 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr2 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr3 = string.Empty ; 
  		public string FreeStr3 
  		{ 
  			get 
  			{ 
  				return m_FreeStr3 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr3 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr4 = string.Empty ; 
  		public string FreeStr4 
  		{ 
  			get 
  			{ 
  				return m_FreeStr4 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr4 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr5 = string.Empty ; 
  		public string FreeStr5 
  		{ 
  			get 
  			{ 
  				return m_FreeStr5 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr5 = value ; 
  			}  
  		} 
  
  		private decimal m_FreeDec1 = 0; 
  		public decimal FreeDec1 
  		{ 
  			get 
  			{ 
  				return m_FreeDec1 ; 
  			}  
  			set 
  			{ 
  				m_FreeDec1 = value ; 
  			}  
  		} 
  
  		private decimal m_FreeDec2 = 0; 
  		public decimal FreeDec2 
  		{ 
  			get 
  			{ 
  				return m_FreeDec2 ; 
  			}  
  			set 
  			{ 
  				m_FreeDec2 = value ; 
  			}  
  		} 
  
  		private decimal m_FreeDec3 = 0; 
  		public decimal FreeDec3 
  		{ 
  			get 
  			{ 
  				return m_FreeDec3 ; 
  			}  
  			set 
  			{ 
  				m_FreeDec3 = value ; 
  			}  
  		} 
  
  		private decimal m_FreeDec4 = 0; 
  		public decimal FreeDec4 
  		{ 
  			get 
  			{ 
  				return m_FreeDec4 ; 
  			}  
  			set 
  			{ 
  				m_FreeDec4 = value ; 
  			}  
  		} 
  
  		private decimal m_FreeDec5 = 0; 
  		public decimal FreeDec5 
  		{ 
  			get 
  			{ 
  				return m_FreeDec5 ; 
  			}  
  			set 
  			{ 
  				m_FreeDec5 = value ; 
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
  
  		private int m_DYFlag = 0; 
  		public int DYFlag 
  		{ 
  			get 
  			{ 
  				return m_DYFlag ; 
  			}  
  			set 
  			{ 
  				m_DYFlag = value ; 
  			}  
  		} 
  
  		private decimal m_Qty = 0; 
  		public decimal Qty 
  		{ 
  			get 
  			{ 
  				return m_Qty ; 
  			}  
  			set 
  			{ 
  				m_Qty = value ; 
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
            string Sql="SELECT * FROM ADH_CheckFormDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM ADH_CheckFormDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
                m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_ISN=SysConvert.ToString(MasterTable.Rows[0]["ISN"]); 
  				m_DataGradeID=SysConvert.ToInt32(MasterTable.Rows[0]["DataGradeID"]); 
  				m_SOQtyDesc=SysConvert.ToString(MasterTable.Rows[0]["SOQtyDesc"]); 
  				m_SODateDesc=SysConvert.ToString(MasterTable.Rows[0]["SODateDesc"]); 
  				m_AddTime=SysConvert.ToDateTime(MasterTable.Rows[0]["AddTime"]); 
  				m_UpdTime=SysConvert.ToDateTime(MasterTable.Rows[0]["UpdTime"]); 
  				m_YPQty=SysConvert.ToInt32(MasterTable.Rows[0]["YPQty"]); 
  				m_YSQty=SysConvert.ToDecimal(MasterTable.Rows[0]["YSQty"]); 
  				m_FreeStr1=SysConvert.ToString(MasterTable.Rows[0]["FreeStr1"]); 
  				m_FreeStr2=SysConvert.ToString(MasterTable.Rows[0]["FreeStr2"]); 
  				m_FreeStr3=SysConvert.ToString(MasterTable.Rows[0]["FreeStr3"]); 
  				m_FreeStr4=SysConvert.ToString(MasterTable.Rows[0]["FreeStr4"]); 
  				m_FreeStr5=SysConvert.ToString(MasterTable.Rows[0]["FreeStr5"]); 
  				m_FreeDec1=SysConvert.ToDecimal(MasterTable.Rows[0]["FreeDec1"]); 
  				m_FreeDec2=SysConvert.ToDecimal(MasterTable.Rows[0]["FreeDec2"]); 
  				m_FreeDec3=SysConvert.ToDecimal(MasterTable.Rows[0]["FreeDec3"]); 
  				m_FreeDec4=SysConvert.ToDecimal(MasterTable.Rows[0]["FreeDec4"]); 
  				m_FreeDec5=SysConvert.ToDecimal(MasterTable.Rows[0]["FreeDec5"]); 
  				m_JYFlag=SysConvert.ToInt32(MasterTable.Rows[0]["JYFlag"]); 
  				m_DYFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DYFlag"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
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
