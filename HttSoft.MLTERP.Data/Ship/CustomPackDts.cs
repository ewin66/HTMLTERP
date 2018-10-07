using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Ship_CustomPackDts实体类
	/// 作者:qiuchao
	/// 创建日期:2015/7/23
	/// </summary>
	public sealed class CustomPackDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CustomPackDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CustomPackDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Ship_CustomPackDts";
		 
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
  
  		private int m_PackPlanID = 0; 
  		public int PackPlanID 
  		{ 
  			get 
  			{ 
  				return m_PackPlanID ; 
  			}  
  			set 
  			{ 
  				m_PackPlanID = value ; 
  			}  
  		} 
  
  		private string m_PackPlanCode = string.Empty ; 
  		public string PackPlanCode 
  		{ 
  			get 
  			{ 
  				return m_PackPlanCode ; 
  			}  
  			set 
  			{ 
  				m_PackPlanCode = value ; 
  			}  
  		} 
  
  		private string m_SSN = string.Empty ; 
  		public string SSN 
  		{ 
  			get 
  			{ 
  				return m_SSN ; 
  			}  
  			set 
  			{ 
  				m_SSN = value ; 
  			}  
  		} 
  
  		private string m_DSN = string.Empty ; 
  		public string DSN 
  		{ 
  			get 
  			{ 
  				return m_DSN ; 
  			}  
  			set 
  			{ 
  				m_DSN = value ; 
  			}  
  		} 
  
  		private string m_StyleNo = string.Empty ; 
  		public string StyleNo 
  		{ 
  			get 
  			{ 
  				return m_StyleNo ; 
  			}  
  			set 
  			{ 
  				m_StyleNo = value ; 
  			}  
  		} 
  
  		private string m_SStyleNo = string.Empty ; 
  		public string SStyleNo 
  		{ 
  			get 
  			{ 
  				return m_SStyleNo ; 
  			}  
  			set 
  			{ 
  				m_SStyleNo = value ; 
  			}  
  		} 
  
  		private string m_Model = string.Empty ; 
  		public string Model 
  		{ 
  			get 
  			{ 
  				return m_Model ; 
  			}  
  			set 
  			{ 
  				m_Model = value ; 
  			}  
  		} 
  
  		private string m_CtnNo = string.Empty ; 
  		public string CtnNo 
  		{ 
  			get 
  			{ 
  				return m_CtnNo ; 
  			}  
  			set 
  			{ 
  				m_CtnNo = value ; 
  			}  
  		} 
  
  		private int m_CtnQty = 0; 
  		public int CtnQty 
  		{ 
  			get 
  			{ 
  				return m_CtnQty ; 
  			}  
  			set 
  			{ 
  				m_CtnQty = value ; 
  			}  
  		} 
  
  		private decimal m_CrossWeight = 0; 
  		public decimal CrossWeight 
  		{ 
  			get 
  			{ 
  				return m_CrossWeight ; 
  			}  
  			set 
  			{ 
  				m_CrossWeight = value ; 
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
  
  		private decimal m_TotalBulk = 0; 
  		public decimal TotalBulk 
  		{ 
  			get 
  			{ 
  				return m_TotalBulk ; 
  			}  
  			set 
  			{ 
  				m_TotalBulk = value ; 
  			}  
  		} 
  
  		private string m_Style = string.Empty ; 
  		public string Style 
  		{ 
  			get 
  			{ 
  				return m_Style ; 
  			}  
  			set 
  			{ 
  				m_Style = value ; 
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
  
  		private decimal m_QGSinglePrice = 0; 
  		public decimal QGSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_QGSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_QGSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_QGAmount = 0; 
  		public decimal QGAmount 
  		{ 
  			get 
  			{ 
  				return m_QGAmount ; 
  			}  
  			set 
  			{ 
  				m_QGAmount = value ; 
  			}  
  		} 
  
  		private decimal m_QGQty = 0; 
  		public decimal QGQty 
  		{ 
  			get 
  			{ 
  				return m_QGQty ; 
  			}  
  			set 
  			{ 
  				m_QGQty = value ; 
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
  
  		private decimal m_PieceQty = 0; 
  		public decimal PieceQty 
  		{ 
  			get 
  			{ 
  				return m_PieceQty ; 
  			}  
  			set 
  			{ 
  				m_PieceQty = value ; 
  			}  
  		} 
  
  		private decimal m_Volume = 0; 
  		public decimal Volume 
  		{ 
  			get 
  			{ 
  				return m_Volume ; 
  			}  
  			set 
  			{ 
  				m_Volume = value ; 
  			}  
  		} 
  
  		private decimal m_MWidth = 0; 
  		public decimal MWidth 
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
  
  		private decimal m_MWeight = 0; 
  		public decimal MWeight 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Ship_CustomPackDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Ship_CustomPackDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
  				m_PackPlanID=SysConvert.ToInt32(MasterTable.Rows[0]["PackPlanID"]); 
  				m_PackPlanCode=SysConvert.ToString(MasterTable.Rows[0]["PackPlanCode"]); 
  				m_SSN=SysConvert.ToString(MasterTable.Rows[0]["SSN"]); 
  				m_DSN=SysConvert.ToString(MasterTable.Rows[0]["DSN"]); 
  				m_StyleNo=SysConvert.ToString(MasterTable.Rows[0]["StyleNo"]); 
  				m_SStyleNo=SysConvert.ToString(MasterTable.Rows[0]["SStyleNo"]); 
  				m_Model=SysConvert.ToString(MasterTable.Rows[0]["Model"]); 
  				m_CtnNo=SysConvert.ToString(MasterTable.Rows[0]["CtnNo"]); 
  				m_CtnQty=SysConvert.ToInt32(MasterTable.Rows[0]["CtnQty"]); 
  				m_CrossWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["CrossWeight"]); 
  				m_NetWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["NetWeight"]); 
  				m_TotalBulk=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalBulk"]); 
  				m_Style=SysConvert.ToString(MasterTable.Rows[0]["Style"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_QGSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["QGSinglePrice"]); 
  				m_QGAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["QGAmount"]); 
  				m_QGQty=SysConvert.ToDecimal(MasterTable.Rows[0]["QGQty"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_PieceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PieceQty"]); 
  				m_Volume=SysConvert.ToDecimal(MasterTable.Rows[0]["Volume"]); 
  				m_MWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
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
