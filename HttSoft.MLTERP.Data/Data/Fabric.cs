using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_Fabric实体类
	/// 作者:丛远晶
	/// 创建日期:2012/5/25
	/// </summary>
	public sealed class Fabric : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Fabric()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Fabric(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_Fabric";
		 
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
  
  		private string m_ISN = string.Empty ; 
  		public string ISN 
  		{ 
  			get 
  			{ 
  				return m_ISN ; 
  			}  
  			set 
  			{ 
  				m_ISN = value ; 
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
  
  		private string m_FlowerType = string.Empty ; 
  		public string FlowerType 
  		{ 
  			get 
  			{ 
  				return m_FlowerType ; 
  			}  
  			set 
  			{ 
  				m_FlowerType = value ; 
  			}  
  		} 
  
  		private int m_Status = 0; 
  		public int Status 
  		{ 
  			get 
  			{ 
  				return m_Status ; 
  			}  
  			set 
  			{ 
  				m_Status = value ; 
  			}  
  		} 
  
  		private int m_CFFlag = 0; 
  		public int CFFlag 
  		{ 
  			get 
  			{ 
  				return m_CFFlag ; 
  			}  
  			set 
  			{ 
  				m_CFFlag = value ; 
  			}  
  		} 
  
  		private int m_PackFlag = 0; 
  		public int PackFlag 
  		{ 
  			get 
  			{ 
  				return m_PackFlag ; 
  			}  
  			set 
  			{ 
  				m_PackFlag = value ; 
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
  
  		private string m_Section = string.Empty ; 
  		public string Section 
  		{ 
  			get 
  			{ 
  				return m_Section ; 
  			}  
  			set 
  			{ 
  				m_Section = value ; 
  			}  
  		} 
  
  		private string m_Sbit = string.Empty ; 
  		public string Sbit 
  		{ 
  			get 
  			{ 
  				return m_Sbit ; 
  			}  
  			set 
  			{ 
  				m_Sbit = value ; 
  			}  
  		} 
  
  		private string m_SourceISN = string.Empty ; 
  		public string SourceISN 
  		{ 
  			get 
  			{ 
  				return m_SourceISN ; 
  			}  
  			set 
  			{ 
  				m_SourceISN = value ; 
  			}  
  		} 
  
  		private int m_IOFormID = 0; 
  		public int IOFormID 
  		{ 
  			get 
  			{ 
  				return m_IOFormID ; 
  			}  
  			set 
  			{ 
  				m_IOFormID = value ; 
  			}  
  		} 
  
  		private int m_IOFormSeq = 0; 
  		public int IOFormSeq 
  		{ 
  			get 
  			{ 
  				return m_IOFormSeq ; 
  			}  
  			set 
  			{ 
  				m_IOFormSeq = value ; 
  			}  
  		} 
  
  		private int m_BoxID = 0; 
  		public int BoxID 
  		{ 
  			get 
  			{ 
  				return m_BoxID ; 
  			}  
  			set 
  			{ 
  				m_BoxID = value ; 
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
  
  		private string m_VendorID = string.Empty ; 
  		public string VendorID 
  		{ 
  			get 
  			{ 
  				return m_VendorID ; 
  			}  
  			set 
  			{ 
  				m_VendorID = value ; 
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
  
  		private string m_MF = string.Empty ; 
  		public string MF 
  		{ 
  			get 
  			{ 
  				return m_MF ; 
  			}  
  			set 
  			{ 
  				m_MF = value ; 
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
  
  		private string m_PNum = string.Empty ; 
  		public string PNum 
  		{ 
  			get 
  			{ 
  				return m_PNum ; 
  			}  
  			set 
  			{ 
  				m_PNum = value ; 
  			}  
  		} 
  
  		private string m_Shop = string.Empty ; 
  		public string Shop 
  		{ 
  			get 
  			{ 
  				return m_Shop ; 
  			}  
  			set 
  			{ 
  				m_Shop = value ; 
  			}  
  		} 
  
  		private string m_JTNum = string.Empty ; 
  		public string JTNum 
  		{ 
  			get 
  			{ 
  				return m_JTNum ; 
  			}  
  			set 
  			{ 
  				m_JTNum = value ; 
  			}  
  		} 
  
  		private string m_MakeOPName = string.Empty ; 
  		public string MakeOPName 
  		{ 
  			get 
  			{ 
  				return m_MakeOPName ; 
  			}  
  			set 
  			{ 
  				m_MakeOPName = value ; 
  			}  
  		} 
  
  		private DateTime m_MakeDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime MakeDate 
  		{ 
  			get 
  			{ 
  				return m_MakeDate ; 
  			}  
  			set 
  			{ 
  				m_MakeDate = value ; 
  			}  
  		} 
  
  		private string m_CheckOPName = string.Empty ; 
  		public string CheckOPName 
  		{ 
  			get 
  			{ 
  				return m_CheckOPName ; 
  			}  
  			set 
  			{ 
  				m_CheckOPName = value ; 
  			}  
  		} 
  
  		private DateTime m_CheckDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CheckDate 
  		{ 
  			get 
  			{ 
  				return m_CheckDate ; 
  			}  
  			set 
  			{ 
  				m_CheckDate = value ; 
  			}  
  		} 
  
  		private decimal m_Length = 0; 
  		public decimal Length 
  		{ 
  			get 
  			{ 
  				return m_Length ; 
  			}  
  			set 
  			{ 
  				m_Length = value ; 
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
            string Sql="SELECT * FROM WO_Fabric WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_Fabric WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ISN=SysConvert.ToString(MasterTable.Rows[0]["ISN"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_FlowerType=SysConvert.ToString(MasterTable.Rows[0]["FlowerType"]); 
  				m_Status=SysConvert.ToInt32(MasterTable.Rows[0]["Status"]); 
  				m_CFFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CFFlag"]); 
  				m_PackFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PackFlag"]); 
  				m_WHID=SysConvert.ToString(MasterTable.Rows[0]["WHID"]); 
  				m_Section=SysConvert.ToString(MasterTable.Rows[0]["Section"]); 
  				m_Sbit=SysConvert.ToString(MasterTable.Rows[0]["Sbit"]); 
  				m_SourceISN=SysConvert.ToString(MasterTable.Rows[0]["SourceISN"]); 
  				m_IOFormID=SysConvert.ToInt32(MasterTable.Rows[0]["IOFormID"]); 
  				m_IOFormSeq=SysConvert.ToInt32(MasterTable.Rows[0]["IOFormSeq"]); 
  				m_BoxID=SysConvert.ToInt32(MasterTable.Rows[0]["BoxID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_StyleNo=SysConvert.ToString(MasterTable.Rows[0]["StyleNo"]); 
  				m_MF=SysConvert.ToString(MasterTable.Rows[0]["MF"]); 
  				m_Weight=SysConvert.ToDecimal(MasterTable.Rows[0]["Weight"]); 
  				m_PNum=SysConvert.ToString(MasterTable.Rows[0]["PNum"]); 
  				m_Shop=SysConvert.ToString(MasterTable.Rows[0]["Shop"]); 
  				m_JTNum=SysConvert.ToString(MasterTable.Rows[0]["JTNum"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_CheckOPName=SysConvert.ToString(MasterTable.Rows[0]["CheckOPName"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_Length=SysConvert.ToDecimal(MasterTable.Rows[0]["Length"]); 
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
