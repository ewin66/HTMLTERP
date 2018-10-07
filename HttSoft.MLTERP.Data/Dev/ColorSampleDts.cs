using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Dev_ColorSampleDts实体类
	/// 作者:zhjh
	/// 创建日期:2014/11/15
	/// </summary>
	public sealed class ColorSampleDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ColorSampleDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ColorSampleDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Dev_ColorSampleDts";
		 
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
  
  		private string m_PColorNum = string.Empty ; 
  		public string PColorNum 
  		{ 
  			get 
  			{ 
  				return m_PColorNum ; 
  			}  
  			set 
  			{ 
  				m_PColorNum = value ; 
  			}  
  		} 
  
  		private string m_DtsRemark = string.Empty ; 
  		public string DtsRemark 
  		{ 
  			get 
  			{ 
  				return m_DtsRemark ; 
  			}  
  			set 
  			{ 
  				m_DtsRemark = value ; 
  			}  
  		} 
  
  		private DateTime m_FinishDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FinishDate 
  		{ 
  			get 
  			{ 
  				return m_FinishDate ; 
  			}  
  			set 
  			{ 
  				m_FinishDate = value ; 
  			}  
  		} 
  
  		private DateTime m_JYDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime JYDate 
  		{ 
  			get 
  			{ 
  				return m_JYDate ; 
  			}  
  			set 
  			{ 
  				m_JYDate = value ; 
  			}  
  		} 
  
  		private DateTime m_HGFinishDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime HGFinishDate 
  		{ 
  			get 
  			{ 
  				return m_HGFinishDate ; 
  			}  
  			set 
  			{ 
  				m_HGFinishDate = value ; 
  			}  
  		} 
  
  		private string m_HGBack = string.Empty ; 
  		public string HGBack 
  		{ 
  			get 
  			{ 
  				return m_HGBack ; 
  			}  
  			set 
  			{ 
  				m_HGBack = value ; 
  			}  
  		} 
  
  		private string m_FlowerNum = string.Empty ; 
  		public string FlowerNum 
  		{ 
  			get 
  			{ 
  				return m_FlowerNum ; 
  			}  
  			set 
  			{ 
  				m_FlowerNum = value ; 
  			}  
  		} 
  
  		private string m_ScrapSampleNo = string.Empty ; 
  		public string ScrapSampleNo 
  		{ 
  			get 
  			{ 
  				return m_ScrapSampleNo ; 
  			}  
  			set 
  			{ 
  				m_ScrapSampleNo = value ; 
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
            string Sql="SELECT * FROM Dev_ColorSampleDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Dev_ColorSampleDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_PColorNum=SysConvert.ToString(MasterTable.Rows[0]["PColorNum"]); 
  				m_DtsRemark=SysConvert.ToString(MasterTable.Rows[0]["DtsRemark"]); 
  				m_FinishDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FinishDate"]); 
  				m_JYDate=SysConvert.ToDateTime(MasterTable.Rows[0]["JYDate"]); 
  				m_HGFinishDate=SysConvert.ToDateTime(MasterTable.Rows[0]["HGFinishDate"]); 
  				m_HGBack=SysConvert.ToString(MasterTable.Rows[0]["HGBack"]); 
  				m_FlowerNum=SysConvert.ToString(MasterTable.Rows[0]["FlowerNum"]); 
  				m_ScrapSampleNo=SysConvert.ToString(MasterTable.Rows[0]["ScrapSampleNo"]); 
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
