using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：WO_BProductCheckDtsFault实体类
	/// 作者:陈加海
	/// 创建日期:2014/5/4
	/// </summary>
	public sealed class BProductCheckDtsFault : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public BProductCheckDtsFault()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public BProductCheckDtsFault(IDBTransAccess p_SqlCmd)
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
  
  		private int m_FaultType = 0; 
  		public int FaultType 
  		{ 
  			get 
  			{ 
  				return m_FaultType ; 
  			}  
  			set 
  			{ 
  				m_FaultType = value ; 
  			}  
  		} 
  
  		private decimal m_BLength = 0; 
  		public decimal BLength 
  		{ 
  			get 
  			{ 
  				return m_BLength ; 
  			}  
  			set 
  			{ 
  				m_BLength = value ; 
  			}  
  		} 
  
  		private decimal m_ELength = 0; 
  		public decimal ELength 
  		{ 
  			get 
  			{ 
  				return m_ELength ; 
  			}  
  			set 
  			{ 
  				m_ELength = value ; 
  			}  
  		} 
  
  		private string m_FaultDes = string.Empty ; 
  		public string FaultDes 
  		{ 
  			get 
  			{ 
  				return m_FaultDes ; 
  			}  
  			set 
  			{ 
  				m_FaultDes = value ; 
  			}  
  		} 
  
  		private decimal m_Deduction = 0; 
  		public decimal Deduction 
  		{ 
  			get 
  			{ 
  				return m_Deduction ; 
  			}  
  			set 
  			{ 
  				m_Deduction = value ; 
  			}  
  		} 
  
  		private decimal m_DQuantity = 0; 
  		public decimal DQuantity 
  		{ 
  			get 
  			{ 
  				return m_DQuantity ; 
  			}  
  			set 
  			{ 
  				m_DQuantity = value ; 
  			}  
  		} 
  
  		private string m_Position = string.Empty ; 
  		public string Position 
  		{ 
  			get 
  			{ 
  				return m_Position ; 
  			}  
  			set 
  			{ 
  				m_Position = value ; 
  			}  
  		} 
  
  		private int m_MaxIndex = 0; 
  		public int MaxIndex 
  		{ 
  			get 
  			{ 
  				return m_MaxIndex ; 
  			}  
  			set 
  			{ 
  				m_MaxIndex = value ; 
  			}  
  		} 
  
  		private decimal m_DYM = 0; 
  		public decimal DYM 
  		{ 
  			get 
  			{ 
  				return m_DYM ; 
  			}  
  			set 
  			{ 
  				m_DYM = value ; 
  			}  
  		} 
  
  		private decimal m_CYQty = 0; 
  		public decimal CYQty 
  		{ 
  			get 
  			{ 
  				return m_CYQty ; 
  			}  
  			set 
  			{ 
  				m_CYQty = value ; 
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
            string Sql="SELECT * FROM WO_BProductCheckDtsFault WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_BProductCheckDtsFault WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FaultType=SysConvert.ToInt32(MasterTable.Rows[0]["FaultType"]); 
  				m_BLength=SysConvert.ToDecimal(MasterTable.Rows[0]["BLength"]); 
  				m_ELength=SysConvert.ToDecimal(MasterTable.Rows[0]["ELength"]); 
  				m_FaultDes=SysConvert.ToString(MasterTable.Rows[0]["FaultDes"]); 
  				m_Deduction=SysConvert.ToDecimal(MasterTable.Rows[0]["Deduction"]); 
  				m_DQuantity=SysConvert.ToDecimal(MasterTable.Rows[0]["DQuantity"]); 
  				m_Position=SysConvert.ToString(MasterTable.Rows[0]["Position"]); 
  				m_MaxIndex=SysConvert.ToInt32(MasterTable.Rows[0]["MaxIndex"]); 
  				m_DYM=SysConvert.ToDecimal(MasterTable.Rows[0]["DYM"]); 
  				m_CYQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CYQty"]); 
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
