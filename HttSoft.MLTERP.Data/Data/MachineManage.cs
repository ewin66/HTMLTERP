using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_MachineManage实体类
	/// 作者:杨光
	/// 创建日期:11/20/2011
	/// </summary>
	public sealed class MachineManage : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public MachineManage()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public MachineManage(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_MachineManage";
		 
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
  
  		private string m_MachineType = string.Empty ; 
  		public string MachineType 
  		{ 
  			get 
  			{ 
  				return m_MachineType ; 
  			}  
  			set 
  			{ 
  				m_MachineType = value ; 
  			}  
  		} 
  
  		private string m_Machine = string.Empty ; 
  		public string Machine 
  		{ 
  			get 
  			{ 
  				return m_Machine ; 
  			}  
  			set 
  			{ 
  				m_Machine = value ; 
  			}  
  		} 
  
  		private string m_Needie = string.Empty ; 
  		public string Needie 
  		{ 
  			get 
  			{ 
  				return m_Needie ; 
  			}  
  			set 
  			{ 
  				m_Needie = value ; 
  			}  
  		} 
  
  		private int m_UserFlag = 0; 
  		public int UserFlag 
  		{ 
  			get 
  			{ 
  				return m_UserFlag ; 
  			}  
  			set 
  			{ 
  				m_UserFlag = value ; 
  			}  
  		} 
  
  		private int m_DayOuty = 0; 
  		public int DayOuty 
  		{ 
  			get 
  			{ 
  				return m_DayOuty ; 
  			}  
  			set 
  			{ 
  				m_DayOuty = value ; 
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
  
  		private string m_JarNum = string.Empty ; 
  		public string JarNum 
  		{ 
  			get 
  			{ 
  				return m_JarNum ; 
  			}  
  			set 
  			{ 
  				m_JarNum = value ; 
  			}  
  		} 
  
  		private int m_NeedleLen = 0; 
  		public int NeedleLen 
  		{ 
  			get 
  			{ 
  				return m_NeedleLen ; 
  			}  
  			set 
  			{ 
  				m_NeedleLen = value ; 
  			}  
  		} 
  
  		private int m_TolNeedle = 0; 
  		public int TolNeedle 
  		{ 
  			get 
  			{ 
  				return m_TolNeedle ; 
  			}  
  			set 
  			{ 
  				m_TolNeedle = value ; 
  			}  
  		} 
  
  		private int m_InItem = 0; 
  		public int InItem 
  		{ 
  			get 
  			{ 
  				return m_InItem ; 
  			}  
  			set 
  			{ 
  				m_InItem = value ; 
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
            string Sql="SELECT * FROM Data_MachineManage WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_MachineManage WHERE "+ "Code="+SysString.ToDBString(m_Code);
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
  				m_MachineType=SysConvert.ToString(MasterTable.Rows[0]["MachineType"]); 
  				m_Machine=SysConvert.ToString(MasterTable.Rows[0]["Machine"]); 
  				m_Needie=SysConvert.ToString(MasterTable.Rows[0]["Needie"]); 
  				m_UserFlag=SysConvert.ToInt32(MasterTable.Rows[0]["UserFlag"]); 
  				m_DayOuty=SysConvert.ToInt32(MasterTable.Rows[0]["DayOuty"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_NeedleLen=SysConvert.ToInt32(MasterTable.Rows[0]["NeedleLen"]); 
  				m_TolNeedle=SysConvert.ToInt32(MasterTable.Rows[0]["TolNeedle"]); 
  				m_InItem=SysConvert.ToInt32(MasterTable.Rows[0]["InItem"]); 
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
