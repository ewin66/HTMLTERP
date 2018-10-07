using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：Chk_CheckOrderISNFault实体类
	/// 作者:周富春
	/// 创建日期:2015/11/4
	/// </summary>
	public sealed class CheckOrderISNFault : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CheckOrderISNFault()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckOrderISNFault(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Chk_CheckOrderISNFault";
		 
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
  
  		private string m_PositionS = string.Empty ; 
  		public string PositionS 
  		{ 
  			get 
  			{ 
  				return m_PositionS ; 
  			}  
  			set 
  			{ 
  				m_PositionS = value ; 
  			}  
  		} 
  
  		private string m_PositionE = string.Empty ; 
  		public string PositionE 
  		{ 
  			get 
  			{ 
  				return m_PositionE ; 
  			}  
  			set 
  			{ 
  				m_PositionE = value ; 
  			}  
  		} 
  
  		private string m_Deduction = string.Empty ; 
  		public string Deduction 
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
            string Sql="SELECT * FROM Chk_CheckOrderISNFault WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Chk_CheckOrderISNFault WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FaultDes=SysConvert.ToString(MasterTable.Rows[0]["FaultDes"]); 
  				m_PositionS=SysConvert.ToString(MasterTable.Rows[0]["PositionS"]); 
  				m_PositionE=SysConvert.ToString(MasterTable.Rows[0]["PositionE"]); 
  				m_Deduction=SysConvert.ToString(MasterTable.Rows[0]["Deduction"]); 
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
