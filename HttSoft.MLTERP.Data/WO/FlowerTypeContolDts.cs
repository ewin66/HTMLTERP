using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_FlowerTypeContolDts实体类
	/// 作者:丛远晶
	/// 创建日期:2012/5/24
	/// </summary>
	public sealed class FlowerTypeContolDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FlowerTypeContolDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FlowerTypeContolDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_FlowerTypeContolDts";
		 
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
  
  		private string m_ColorCode = string.Empty ; 
  		public string ColorCode 
  		{ 
  			get 
  			{ 
  				return m_ColorCode ; 
  			}  
  			set 
  			{ 
  				m_ColorCode = value ; 
  			}  
  		} 
  
  		private string m_Freestr1 = string.Empty ; 
  		public string Freestr1 
  		{ 
  			get 
  			{ 
  				return m_Freestr1 ; 
  			}  
  			set 
  			{ 
  				m_Freestr1 = value ; 
  			}  
  		} 
  
  		private string m_Freestr2 = string.Empty ; 
  		public string Freestr2 
  		{ 
  			get 
  			{ 
  				return m_Freestr2 ; 
  			}  
  			set 
  			{ 
  				m_Freestr2 = value ; 
  			}  
  		} 
  
  		private string m_Freestr3 = string.Empty ; 
  		public string Freestr3 
  		{ 
  			get 
  			{ 
  				return m_Freestr3 ; 
  			}  
  			set 
  			{ 
  				m_Freestr3 = value ; 
  			}  
  		} 
  
  		private string m_Freestr4 = string.Empty ; 
  		public string Freestr4 
  		{ 
  			get 
  			{ 
  				return m_Freestr4 ; 
  			}  
  			set 
  			{ 
  				m_Freestr4 = value ; 
  			}  
  		} 
  
  		private string m_Freestr5 = string.Empty ; 
  		public string Freestr5 
  		{ 
  			get 
  			{ 
  				return m_Freestr5 ; 
  			}  
  			set 
  			{ 
  				m_Freestr5 = value ; 
  			}  
  		} 
  
  		private string m_Freestr6 = string.Empty ; 
  		public string Freestr6 
  		{ 
  			get 
  			{ 
  				return m_Freestr6 ; 
  			}  
  			set 
  			{ 
  				m_Freestr6 = value ; 
  			}  
  		} 
  
  		private string m_Freestr7 = string.Empty ; 
  		public string Freestr7 
  		{ 
  			get 
  			{ 
  				return m_Freestr7 ; 
  			}  
  			set 
  			{ 
  				m_Freestr7 = value ; 
  			}  
  		} 
  
  		private string m_Freestr8 = string.Empty ; 
  		public string Freestr8 
  		{ 
  			get 
  			{ 
  				return m_Freestr8 ; 
  			}  
  			set 
  			{ 
  				m_Freestr8 = value ; 
  			}  
  		} 
  
  		private string m_Freestr9 = string.Empty ; 
  		public string Freestr9 
  		{ 
  			get 
  			{ 
  				return m_Freestr9 ; 
  			}  
  			set 
  			{ 
  				m_Freestr9 = value ; 
  			}  
  		} 
  
  		private string m_Freestr10 = string.Empty ; 
  		public string Freestr10 
  		{ 
  			get 
  			{ 
  				return m_Freestr10 ; 
  			}  
  			set 
  			{ 
  				m_Freestr10 = value ; 
  			}  
  		} 
  
  		private string m_Freestr11 = string.Empty ; 
  		public string Freestr11 
  		{ 
  			get 
  			{ 
  				return m_Freestr11 ; 
  			}  
  			set 
  			{ 
  				m_Freestr11 = value ; 
  			}  
  		} 
  
  		private string m_Freestr12 = string.Empty ; 
  		public string Freestr12 
  		{ 
  			get 
  			{ 
  				return m_Freestr12 ; 
  			}  
  			set 
  			{ 
  				m_Freestr12 = value ; 
  			}  
  		} 
  
  		private string m_Freestr13 = string.Empty ; 
  		public string Freestr13 
  		{ 
  			get 
  			{ 
  				return m_Freestr13 ; 
  			}  
  			set 
  			{ 
  				m_Freestr13 = value ; 
  			}  
  		} 
  
  		private string m_Freestr14 = string.Empty ; 
  		public string Freestr14 
  		{ 
  			get 
  			{ 
  				return m_Freestr14 ; 
  			}  
  			set 
  			{ 
  				m_Freestr14 = value ; 
  			}  
  		} 
  
  		private string m_Freestr15 = string.Empty ; 
  		public string Freestr15 
  		{ 
  			get 
  			{ 
  				return m_Freestr15 ; 
  			}  
  			set 
  			{ 
  				m_Freestr15 = value ; 
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
            string Sql="SELECT * FROM Data_FlowerTypeContolDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_FlowerTypeContolDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
  				m_ColorCode=SysConvert.ToString(MasterTable.Rows[0]["ColorCode"]); 
  				m_Freestr1=SysConvert.ToString(MasterTable.Rows[0]["Freestr1"]); 
  				m_Freestr2=SysConvert.ToString(MasterTable.Rows[0]["Freestr2"]); 
  				m_Freestr3=SysConvert.ToString(MasterTable.Rows[0]["Freestr3"]); 
  				m_Freestr4=SysConvert.ToString(MasterTable.Rows[0]["Freestr4"]); 
  				m_Freestr5=SysConvert.ToString(MasterTable.Rows[0]["Freestr5"]); 
  				m_Freestr6=SysConvert.ToString(MasterTable.Rows[0]["Freestr6"]); 
  				m_Freestr7=SysConvert.ToString(MasterTable.Rows[0]["Freestr7"]); 
  				m_Freestr8=SysConvert.ToString(MasterTable.Rows[0]["Freestr8"]); 
  				m_Freestr9=SysConvert.ToString(MasterTable.Rows[0]["Freestr9"]); 
  				m_Freestr10=SysConvert.ToString(MasterTable.Rows[0]["Freestr10"]); 
  				m_Freestr11=SysConvert.ToString(MasterTable.Rows[0]["Freestr11"]); 
  				m_Freestr12=SysConvert.ToString(MasterTable.Rows[0]["Freestr12"]); 
  				m_Freestr13=SysConvert.ToString(MasterTable.Rows[0]["Freestr13"]); 
  				m_Freestr14=SysConvert.ToString(MasterTable.Rows[0]["Freestr14"]); 
  				m_Freestr15=SysConvert.ToString(MasterTable.Rows[0]["Freestr15"]); 
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
