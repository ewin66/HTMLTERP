using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_IOFormDtsPack实体类
	/// 作者:xusc
	/// 创建日期:2015/12/26
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
		public static readonly string TableName = "WH_IOFormDtsPack";
		 
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
  
  		private decimal m_FMQty = 0; 
  		public decimal FMQty 
  		{ 
  			get 
  			{ 
  				return m_FMQty ; 
  			}  
  			set 
  			{ 
  				m_FMQty = value ; 
  			}  
  		} 
  
  		private decimal m_GrossQty = 0; 
  		public decimal GrossQty 
  		{ 
  			get 
  			{ 
  				return m_GrossQty ; 
  			}  
  			set 
  			{ 
  				m_GrossQty = value ; 
  			}  
  		} 
  
  		private decimal m_GrossWeight = 0; 
  		public decimal GrossWeight 
  		{ 
  			get 
  			{ 
  				return m_GrossWeight ; 
  			}  
  			set 
  			{ 
  				m_GrossWeight = value ; 
  			}  
  		} 
  
  		private decimal m_NetWeight = 0; 
  		public decimal NetWeight 
  		{ 
  			get 
  			{ 
  				return m_NetWeight ; 
  			}  
  			set 
  			{ 
  				m_NetWeight = value ; 
  			}  
  		} 
  
  		private string m_Description = string.Empty ; 
  		public string Description 
  		{ 
  			get 
  			{ 
  				return m_Description ; 
  			}  
  			set 
  			{ 
  				m_Description = value ; 
  			}  
  		} 
  
  		private string m_Destination = string.Empty ; 
  		public string Destination 
  		{ 
  			get 
  			{ 
  				return m_Destination ; 
  			}  
  			set 
  			{ 
  				m_Destination = value ; 
  			}  
  		} 
  
  		private string m_RecordOPID = string.Empty ; 
  		public string RecordOPID 
  		{ 
  			get 
  			{ 
  				return m_RecordOPID ; 
  			}  
  			set 
  			{ 
  				m_RecordOPID = value ; 
  			}  
  		} 
  
  		private string m_RecordType = string.Empty ; 
  		public string RecordType 
  		{ 
  			get 
  			{ 
  				return m_RecordType ; 
  			}  
  			set 
  			{ 
  				m_RecordType = value ; 
  			}  
  		} 
  
  		private decimal m_Weight = 0; 
  		public decimal Weight 
  		{ 
  			get 
  			{ 
  				return m_Weight ; 
  			}  
  			set 
  			{ 
  				m_Weight = value ; 
  			}  
  		} 
  
  		private string m_GoodsLevel = string.Empty ; 
  		public string GoodsLevel 
  		{ 
  			get 
  			{ 
  				return m_GoodsLevel ; 
  			}  
  			set 
  			{ 
  				m_GoodsLevel = value ; 
  			}  
  		} 
  
  		private decimal m_Yard = 0; 
  		public decimal Yard 
  		{ 
  			get 
  			{ 
  				return m_Yard ; 
  			}  
  			set 
  			{ 
  				m_Yard = value ; 
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
  				m_FMQty=SysConvert.ToDecimal(MasterTable.Rows[0]["FMQty"]); 
  				m_GrossQty=SysConvert.ToDecimal(MasterTable.Rows[0]["GrossQty"]); 
  				m_GrossWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["GrossWeight"]); 
  				m_NetWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["NetWeight"]); 
  				m_Description=SysConvert.ToString(MasterTable.Rows[0]["Description"]); 
  				m_Destination=SysConvert.ToString(MasterTable.Rows[0]["Destination"]); 
  				m_RecordOPID=SysConvert.ToString(MasterTable.Rows[0]["RecordOPID"]); 
  				m_RecordType=SysConvert.ToString(MasterTable.Rows[0]["RecordType"]); 
  				m_Weight=SysConvert.ToDecimal(MasterTable.Rows[0]["Weight"]); 
  				m_GoodsLevel=SysConvert.ToString(MasterTable.Rows[0]["GoodsLevel"]); 
  				m_Yard=SysConvert.ToDecimal(MasterTable.Rows[0]["Yard"]); 
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
