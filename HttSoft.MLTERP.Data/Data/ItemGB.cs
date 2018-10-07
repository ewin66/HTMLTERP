using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_ItemGB实体类
	/// 作者:章文强
	/// 创建日期:2014/3/18
	/// </summary>
	public sealed class ItemGB : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemGB()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemGB(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_ItemGB";
		 
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
  
  		private string m_GBCode = string.Empty ; 
  		public string GBCode 
  		{ 
  			get 
  			{ 
  				return m_GBCode ; 
  			}  
  			set 
  			{ 
  				m_GBCode = value ; 
  			}  
  		} 
  
  		private DateTime m_GBDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime GBDate 
  		{ 
  			get 
  			{ 
  				return m_GBDate ; 
  			}  
  			set 
  			{ 
  				m_GBDate = value ; 
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
  
  		private string m_GBDesc = string.Empty ; 
  		public string GBDesc 
  		{ 
  			get 
  			{ 
  				return m_GBDesc ; 
  			}  
  			set 
  			{ 
  				m_GBDesc = value ; 
  			}  
  		} 
  
  		private int m_XY = 0; 
  		public int XY 
  		{ 
  			get 
  			{ 
  				return m_XY ; 
  			}  
  			set 
  			{ 
  				m_XY = value ; 
  			}  
  		} 
  
  		private string m_XYDesc = string.Empty ; 
  		public string XYDesc 
  		{ 
  			get 
  			{ 
  				return m_XYDesc ; 
  			}  
  			set 
  			{ 
  				m_XYDesc = value ; 
  			}  
  		} 
  
  		private byte[] m_GBPic = new byte[1]; 
  		public byte[] GBPic 
  		{ 
  			get 
  			{ 
  				return m_GBPic ; 
  			}  
  			set 
  			{ 
  				m_GBPic = value ; 
  			}  
  		} 
  
  		private byte[] m_GBPic2 = new byte[1]; 
  		public byte[] GBPic2 
  		{ 
  			get 
  			{ 
  				return m_GBPic2 ; 
  			}  
  			set 
  			{ 
  				m_GBPic2 = value ; 
  			}  
  		} 
  
  		private int m_GBStatusID = 0; 
  		public int GBStatusID 
  		{ 
  			get 
  			{ 
  				return m_GBStatusID ; 
  			}  
  			set 
  			{ 
  				m_GBStatusID = value ; 
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
  
  		private int m_GBFlag = 0; 
  		public int GBFlag 
  		{ 
  			get 
  			{ 
  				return m_GBFlag ; 
  			}  
  			set 
  			{ 
  				m_GBFlag = value ; 
  			}  
  		}

        private string m_MWidth = string.Empty;
        public string MWidth 
  		{ 
  			get 
  			{ 
  				return m_MWidth ; 
  			}  
  			set 
  			{ 
  				m_MWidth = value ; 
  			}  
  		}

        private string m_MWeight = string.Empty;
        public string MWeight 
  		{ 
  			get 
  			{ 
  				return m_MWeight ; 
  			}  
  			set 
  			{ 
  				m_MWeight = value ; 
  			}  
  		} 
  
  		private string m_WeightUnit = string.Empty ; 
  		public string WeightUnit 
  		{ 
  			get 
  			{ 
  				return m_WeightUnit ; 
  			}  
  			set 
  			{ 
  				m_WeightUnit = value ; 
  			}  
  		} 
  
  		private int m_testReportFlag = 0; 
  		public int testReportFlag 
  		{ 
  			get 
  			{ 
  				return m_testReportFlag ; 
  			}  
  			set 
  			{ 
  				m_testReportFlag = value ; 
  			}  
  		} 
  
  		private string m_testReportNum = string.Empty ; 
  		public string testReportNum 
  		{ 
  			get 
  			{ 
  				return m_testReportNum ; 
  			}  
  			set 
  			{ 
  				m_testReportNum = value ; 
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
  
  		private int m_PMainID = 0; 
  		public int PMainID 
  		{ 
  			get 
  			{ 
  				return m_PMainID ; 
  			}  
  			set 
  			{ 
  				m_PMainID = value ; 
  			}  
  		} 
  
  		private string m_PItemName = string.Empty ; 
  		public string PItemName 
  		{ 
  			get 
  			{ 
  				return m_PItemName ; 
  			}  
  			set 
  			{ 
  				m_PItemName = value ; 
  			}  
  		} 
  
  		private string m_XYDescRemark = string.Empty ; 
  		public string XYDescRemark 
  		{ 
  			get 
  			{ 
  				return m_XYDescRemark ; 
  			}  
  			set 
  			{ 
  				m_XYDescRemark = value ; 
  			}  
  		} 
  
  		private decimal m_GBPrice = 0; 
  		public decimal GBPrice 
  		{ 
  			get 
  			{ 
  				return m_GBPrice ; 
  			}  
  			set 
  			{ 
  				m_GBPrice = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_ItemGB WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ItemGB WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_GBCode=SysConvert.ToString(MasterTable.Rows[0]["GBCode"]); 
  				m_GBDate=SysConvert.ToDateTime(MasterTable.Rows[0]["GBDate"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_GBDesc=SysConvert.ToString(MasterTable.Rows[0]["GBDesc"]); 
  				m_XY=SysConvert.ToInt32(MasterTable.Rows[0]["XY"]); 
  				m_XYDesc=SysConvert.ToString(MasterTable.Rows[0]["XYDesc"]); 
  				if(MasterTable.Rows[0]["GBPic"]!=DBNull.Value) 
  				{ 
  				 	m_GBPic=(byte[])(MasterTable.Rows[0]["GBPic"]); 
  				} 
  				if(MasterTable.Rows[0]["GBPic2"]!=DBNull.Value) 
  				{ 
  				 	m_GBPic2=(byte[])(MasterTable.Rows[0]["GBPic2"]); 
  				} 
  				m_GBStatusID=SysConvert.ToInt32(MasterTable.Rows[0]["GBStatusID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_GBFlag=SysConvert.ToInt32(MasterTable.Rows[0]["GBFlag"]);
                m_MWidth = SysConvert.ToString(MasterTable.Rows[0]["MWidth"]);
                m_MWeight = SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_testReportFlag=SysConvert.ToInt32(MasterTable.Rows[0]["testReportFlag"]); 
  				m_testReportNum=SysConvert.ToString(MasterTable.Rows[0]["testReportNum"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_PMainID=SysConvert.ToInt32(MasterTable.Rows[0]["PMainID"]); 
  				m_PItemName=SysConvert.ToString(MasterTable.Rows[0]["PItemName"]); 
  				m_XYDescRemark=SysConvert.ToString(MasterTable.Rows[0]["XYDescRemark"]); 
  				m_GBPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["GBPrice"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
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
