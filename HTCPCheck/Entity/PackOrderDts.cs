using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：WO_PackOrderDts实体类
	/// 作者:周富春
	/// 创建日期:2014/12/26
	/// </summary>
	public sealed class PackOrderDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public PackOrderDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public PackOrderDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_PackOrderDts";
		 
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

        private int m_JarNo = 0;
        public int JarNo
        {
            get
            {
                return m_JarNo;
            }
            set
            {
                m_JarNo = value;
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
  
  		private string m_ColorNumEn = string.Empty ; 
  		public string ColorNumEn 
  		{ 
  			get 
  			{ 
  				return m_ColorNumEn ; 
  			}  
  			set 
  			{ 
  				m_ColorNumEn = value ; 
  			}  
  		} 
  
  		private string m_ColorNameEn = string.Empty ; 
  		public string ColorNameEn 
  		{ 
  			get 
  			{ 
  				return m_ColorNameEn ; 
  			}  
  			set 
  			{ 
  				m_ColorNameEn = value ; 
  			}  
  		} 
  
  		private decimal m_MLength = 0; 
  		public decimal MLength 
  		{ 
  			get 
  			{ 
  				return m_MLength ; 
  			}  
  			set 
  			{ 
  				m_MLength = value ; 
  			}  
  		} 
  
  		private decimal m_YLength = 0; 
  		public decimal YLength 
  		{ 
  			get 
  			{ 
  				return m_YLength ; 
  			}  
  			set 
  			{ 
  				m_YLength = value ; 
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
  
  		private decimal m_CheckQty = 0; 
  		public decimal CheckQty 
  		{ 
  			get 
  			{ 
  				return m_CheckQty ; 
  			}  
  			set 
  			{ 
  				m_CheckQty = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WO_PackOrderDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_PackOrderDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorNumEn=SysConvert.ToString(MasterTable.Rows[0]["ColorNumEn"]); 
  				m_ColorNameEn=SysConvert.ToString(MasterTable.Rows[0]["ColorNameEn"]); 
  				m_MLength=SysConvert.ToDecimal(MasterTable.Rows[0]["MLength"]); 
  				m_YLength=SysConvert.ToDecimal(MasterTable.Rows[0]["YLength"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_CheckQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQty"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]);
                m_JarNo = SysConvert.ToInt32(MasterTable.Rows[0]["JarNo"]); 
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
