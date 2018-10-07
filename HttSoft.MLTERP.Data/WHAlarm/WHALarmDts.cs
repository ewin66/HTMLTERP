using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_WHALarmDts实体类
	/// 作者:曹小艮
	/// 创建日期:2011-11-17
	/// </summary>
	public sealed class WHALarmDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WHALarmDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public WHALarmDts(IDBTransAccess p_SqlCmd)
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
  
  		private int m_WHAlarmID = 0; 
  		public int WHAlarmID 
  		{ 
  			get 
  			{ 
  				return m_WHAlarmID ; 
  			}  
  			set 
  			{ 
  				m_WHAlarmID = value ; 
  			}  
  		} 
  
  		private string m_ItemCode = string.Empty ; 
  		public string ItemCode 
  		{ 
  			get 
  			{ 
  				return m_ItemCode ; 
  			}  
  			set 
  			{ 
  				m_ItemCode = value ; 
  			}  
  		} 
  
  		private string m_ItemName = string.Empty ; 
  		public string ItemName 
  		{ 
  			get 
  			{ 
  				return m_ItemName ; 
  			}  
  			set 
  			{ 
  				m_ItemName = value ; 
  			}  
  		} 
  
  		private string m_ItemStd = string.Empty ; 
  		public string ItemStd 
  		{ 
  			get 
  			{ 
  				return m_ItemStd ; 
  			}  
  			set 
  			{ 
  				m_ItemStd = value ; 
  			}  
  		} 
  
  		private decimal m_AlarmLowQty = 0; 
  		public decimal AlarmLowQty 
  		{ 
  			get 
  			{ 
  				return m_AlarmLowQty ; 
  			}  
  			set 
  			{ 
  				m_AlarmLowQty = value ; 
  			}  
  		} 
  
  		private decimal m_AlarmHighQty = 0; 
  		public decimal AlarmHighQty 
  		{ 
  			get 
  			{ 
  				return m_AlarmHighQty ; 
  			}  
  			set 
  			{ 
  				m_AlarmHighQty = value ; 
  			}  
  		} 
  
  		private DateTime m_LastUpdTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime LastUpdTime 
  		{ 
  			get 
  			{ 
  				return m_LastUpdTime ; 
  			}  
  			set 
  			{ 
  				m_LastUpdTime = value ; 
  			}  
  		} 
  
  		private string m_LastUpdOP = string.Empty ; 
  		public string LastUpdOP 
  		{ 
  			get 
  			{ 
  				return m_LastUpdOP ; 
  			}  
  			set 
  			{ 
  				m_LastUpdOP = value ; 
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
  
  		private string m_ColorName = string.Empty ; 
  		public string ColorName 
  		{ 
  			get 
  			{ 
  				return m_ColorName ; 
  			}  
  			set 
  			{ 
  				m_ColorName = value ; 
  			}  
  		} 
  
  		private string m_ColorNum = string.Empty ; 
  		public string ColorNum 
  		{ 
  			get 
  			{ 
  				return m_ColorNum ; 
  			}  
  			set 
  			{ 
  				m_ColorNum = value ; 
  			}  
  		} 
  
  		private string m_JarNo = string.Empty ; 
  		public string JarNo 
  		{ 
  			get 
  			{ 
  				return m_JarNo ; 
  			}  
  			set 
  			{ 
  				m_JarNo = value ; 
  			}  
  		} 
  
  		private string m_ItemModel = string.Empty ; 
  		public string ItemModel 
  		{ 
  			get 
  			{ 
  				return m_ItemModel ; 
  			}  
  			set 
  			{ 
  				m_ItemModel = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WH_WHALarmDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_WHALarmDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_WHAlarmID=SysConvert.ToInt32(MasterTable.Rows[0]["WHAlarmID"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_AlarmLowQty=SysConvert.ToDecimal(MasterTable.Rows[0]["AlarmLowQty"]); 
  				m_AlarmHighQty=SysConvert.ToDecimal(MasterTable.Rows[0]["AlarmHighQty"]); 
  				m_LastUpdTime=SysConvert.ToDateTime(MasterTable.Rows[0]["LastUpdTime"]); 
  				m_LastUpdOP=SysConvert.ToString(MasterTable.Rows[0]["LastUpdOP"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_JarNo=SysConvert.ToString(MasterTable.Rows[0]["JarNo"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
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
