using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_SBit实体类
	/// 作者:xushoucheng
	/// 创建日期:2015/11/20
	/// </summary>
	public sealed class SBit : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SBit()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SBit(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WH_SBit";
		 
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
  
  		private string m_WHID = string.Empty ; 
  		public string WHID 
  		{ 
  			get 
  			{ 
  				return m_WHID ; 
  			}  
  			set 
  			{ 
  				m_WHID = value ; 
  			}  
  		} 
  
  		private string m_SectionID = string.Empty ; 
  		public string SectionID 
  		{ 
  			get 
  			{ 
  				return m_SectionID ; 
  			}  
  			set 
  			{ 
  				m_SectionID = value ; 
  			}  
  		} 
  
  		private string m_SBitID = string.Empty ; 
  		public string SBitID 
  		{ 
  			get 
  			{ 
  				return m_SBitID ; 
  			}  
  			set 
  			{ 
  				m_SBitID = value ; 
  			}  
  		} 
  
  		private int m_IsUseable = 0; 
  		public int IsUseable 
  		{ 
  			get 
  			{ 
  				return m_IsUseable ; 
  			}  
  			set 
  			{ 
  				m_IsUseable = value ; 
  			}  
  		} 
  
  		private decimal m_WeightMax = 0; 
  		public decimal WeightMax 
  		{ 
  			get 
  			{ 
  				return m_WeightMax ; 
  			}  
  			set 
  			{ 
  				m_WeightMax = value ; 
  			}  
  		} 
  
  		private decimal m_BulkMax = 0; 
  		public decimal BulkMax 
  		{ 
  			get 
  			{ 
  				return m_BulkMax ; 
  			}  
  			set 
  			{ 
  				m_BulkMax = value ; 
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
  
  		private string m_SBitISN = string.Empty ; 
  		public string SBitISN 
  		{ 
  			get 
  			{ 
  				return m_SBitISN ; 
  			}  
  			set 
  			{ 
  				m_SBitISN = value ; 
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
            string Sql="SELECT * FROM WH_SBit WHERE "+ "SBitID="+SysString.ToDBString(m_SBitID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_SBit WHERE "+ "SBitID="+SysString.ToDBString(m_SBitID);
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
  				m_SubSeq=SysConvert.ToInt32(MasterTable.Rows[0]["SubSeq"]); 
  				m_WHID=SysConvert.ToString(MasterTable.Rows[0]["WHID"]); 
  				m_SectionID=SysConvert.ToString(MasterTable.Rows[0]["SectionID"]); 
  				m_SBitID=SysConvert.ToString(MasterTable.Rows[0]["SBitID"]); 
  				m_IsUseable=SysConvert.ToInt32(MasterTable.Rows[0]["IsUseable"]); 
  				m_WeightMax=SysConvert.ToDecimal(MasterTable.Rows[0]["WeightMax"]); 
  				m_BulkMax=SysConvert.ToDecimal(MasterTable.Rows[0]["BulkMax"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SBitISN=SysConvert.ToString(MasterTable.Rows[0]["SBitISN"]); 
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
