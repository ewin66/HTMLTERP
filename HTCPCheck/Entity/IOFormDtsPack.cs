using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：WH_IOFormDtsPack实体类
	/// 作者:陈加海
	/// 创建日期:2014/5/23
	/// </summary>
	public sealed class IOFormDtsPack : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public IOFormDtsPack()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public IOFormDtsPack(IDBTransAccess p_SqlCmd)
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
  
  		private int m_SubSeq = 0; 
  		public int SubSeq 
  		{ 
  			get 
  			{ 
  				return m_SubSeq ; 
  			}  
  			set 
  			{ 
  				m_SubSeq = value ; 
  			}  
  		} 
  
  		private string m_PackNo = string.Empty ; 
  		public string PackNo 
  		{ 
  			get 
  			{ 
  				return m_PackNo ; 
  			}  
  			set 
  			{ 
  				m_PackNo = value ; 
  			}  
  		} 
  
  		private string m_BoxNo = string.Empty ; 
  		public string BoxNo 
  		{ 
  			get 
  			{ 
  				return m_BoxNo ; 
  			}  
  			set 
  			{ 
  				m_BoxNo = value ; 
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
  
  		private decimal m_FactQty = 0; 
  		public decimal FactQty 
  		{ 
  			get 
  			{ 
  				return m_FactQty ; 
  			}  
  			set 
  			{ 
  				m_FactQty = value ; 
  			}  
  		} 
  
  		private decimal m_PDQty = 0; 
  		public decimal PDQty 
  		{ 
  			get 
  			{ 
  				return m_PDQty ; 
  			}  
  			set 
  			{ 
  				m_PDQty = value ; 
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
  
  		private int m_DID = 0; 
  		public int DID 
  		{ 
  			get 
  			{ 
  				return m_DID ; 
  			}  
  			set 
  			{ 
  				m_DID = value ; 
  			}  
  		} 
  
  		private string m_Unit = string.Empty ; 
  		public string Unit 
  		{ 
  			get 
  			{ 
  				return m_Unit ; 
  			}  
  			set 
  			{ 
  				m_Unit = value ; 
  			}  
  		} 
  
  		private decimal m_InputQty = 0; 
  		public decimal InputQty 
  		{ 
  			get 
  			{ 
  				return m_InputQty ; 
  			}  
  			set 
  			{ 
  				m_InputQty = value ; 
  			}  
  		} 
  
  		private string m_InputUnit = string.Empty ; 
  		public string InputUnit 
  		{ 
  			get 
  			{ 
  				return m_InputUnit ; 
  			}  
  			set 
  			{ 
  				m_InputUnit = value ; 
  			}  
  		} 
  
  		private decimal m_InputConvertXS = 0; 
  		public decimal InputConvertXS 
  		{ 
  			get 
  			{ 
  				return m_InputConvertXS ; 
  			}  
  			set 
  			{ 
  				m_InputConvertXS = value ; 
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
            string Sql="SELECT * FROM WH_IOFormDtsPack WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_IOFormDtsPack WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_SubSeq=SysConvert.ToInt32(MasterTable.Rows[0]["SubSeq"]); 
  				m_PackNo=SysConvert.ToString(MasterTable.Rows[0]["PackNo"]); 
  				m_BoxNo=SysConvert.ToString(MasterTable.Rows[0]["BoxNo"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_FactQty=SysConvert.ToDecimal(MasterTable.Rows[0]["FactQty"]); 
  				m_PDQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PDQty"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_DID=SysConvert.ToInt32(MasterTable.Rows[0]["DID"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_InputQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InputQty"]); 
  				m_InputUnit=SysConvert.ToString(MasterTable.Rows[0]["InputUnit"]); 
  				m_InputConvertXS=SysConvert.ToDecimal(MasterTable.Rows[0]["InputConvertXS"]); 
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
