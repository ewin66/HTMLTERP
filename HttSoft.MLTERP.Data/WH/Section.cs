using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_Section实体类
	/// 作者:章文强
	/// 创建日期:2014/6/10
	/// </summary>
	public sealed class Section : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Section()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Section(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WH_Section";
		 
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
  
  		private int m_PosX = 0; 
  		public int PosX 
  		{ 
  			get 
  			{ 
  				return m_PosX ; 
  			}  
  			set 
  			{ 
  				m_PosX = value ; 
  			}  
  		} 
  
  		private int m_PosY = 0; 
  		public int PosY 
  		{ 
  			get 
  			{ 
  				return m_PosY ; 
  			}  
  			set 
  			{ 
  				m_PosY = value ; 
  			}  
  		} 
  
  		private int m_SizeWidth = 0; 
  		public int SizeWidth 
  		{ 
  			get 
  			{ 
  				return m_SizeWidth ; 
  			}  
  			set 
  			{ 
  				m_SizeWidth = value ; 
  			}  
  		} 
  
  		private int m_SizeHeight = 0; 
  		public int SizeHeight 
  		{ 
  			get 
  			{ 
  				return m_SizeHeight ; 
  			}  
  			set 
  			{ 
  				m_SizeHeight = value ; 
  			}  
  		} 
  
  		private int m_WHPicID = 0; 
  		public int WHPicID 
  		{ 
  			get 
  			{ 
  				return m_WHPicID ; 
  			}  
  			set 
  			{ 
  				m_WHPicID = value ; 
  			}  
  		} 
  
  		private string m_WHISN = string.Empty ; 
  		public string WHISN 
  		{ 
  			get 
  			{ 
  				return m_WHISN ; 
  			}  
  			set 
  			{ 
  				m_WHISN = value ; 
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
            string Sql="SELECT * FROM WH_Section WHERE "+ "SectionID="+SysString.ToDBString(m_SectionID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_Section WHERE "+ "SectionID="+SysString.ToDBString(m_SectionID);
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
  				m_WHID=SysConvert.ToString(MasterTable.Rows[0]["WHID"]); 
  				m_SectionID=SysConvert.ToString(MasterTable.Rows[0]["SectionID"]); 
  				m_IsUseable=SysConvert.ToInt32(MasterTable.Rows[0]["IsUseable"]); 
  				m_WeightMax=SysConvert.ToDecimal(MasterTable.Rows[0]["WeightMax"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_BulkMax=SysConvert.ToDecimal(MasterTable.Rows[0]["BulkMax"]); 
  				m_PosX=SysConvert.ToInt32(MasterTable.Rows[0]["PosX"]); 
  				m_PosY=SysConvert.ToInt32(MasterTable.Rows[0]["PosY"]); 
  				m_SizeWidth=SysConvert.ToInt32(MasterTable.Rows[0]["SizeWidth"]); 
  				m_SizeHeight=SysConvert.ToInt32(MasterTable.Rows[0]["SizeHeight"]); 
  				m_WHPicID=SysConvert.ToInt32(MasterTable.Rows[0]["WHPicID"]); 
  				m_WHISN=SysConvert.ToString(MasterTable.Rows[0]["WHISN"]); 
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
