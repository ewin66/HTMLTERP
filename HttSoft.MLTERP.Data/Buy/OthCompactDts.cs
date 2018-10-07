using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Buy_OthCompactDts实体类
	/// 作者:辛明献
	/// 创建日期:2011-11-8
	/// </summary>
	public sealed class OthCompactDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public OthCompactDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public OthCompactDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
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
  
  		private string m_DesignNO = string.Empty ; 
  		public string DesignNO 
  		{ 
  			get 
  			{ 
  				return m_DesignNO ; 
  			}  
  			set 
  			{ 
  				m_DesignNO = value ; 
  			}  
  		} 
  
  		private string m_EditionNo = string.Empty ; 
  		public string EditionNo 
  		{ 
  			get 
  			{ 
  				return m_EditionNo ; 
  			}  
  			set 
  			{ 
  				m_EditionNo = value ; 
  			}  
  		} 
  
  		private decimal m_Qty = 0; 
  		public decimal Qty 
  		{ 
  			get 
  			{ 
  				return m_Qty ; 
  			}  
  			set 
  			{ 
  				m_Qty = value ; 
  			}  
  		} 
  
  		private decimal m_Amount = 0; 
  		public decimal Amount 
  		{ 
  			get 
  			{ 
  				return m_Amount ; 
  			}  
  			set 
  			{ 
  				m_Amount = value ; 
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
  
  		private string m_YarnStatus = string.Empty ; 
  		public string YarnStatus 
  		{ 
  			get 
  			{ 
  				return m_YarnStatus ; 
  			}  
  			set 
  			{ 
  				m_YarnStatus = value ; 
  			}  
  		} 
  
  		private int m_YarnTypeID = 0; 
  		public int YarnTypeID 
  		{ 
  			get 
  			{ 
  				return m_YarnTypeID ; 
  			}  
  			set 
  			{ 
  				m_YarnTypeID = value ; 
  			}  
  		} 
  
  		private string m_SourceItemCode = string.Empty ; 
  		public string SourceItemCode 
  		{ 
  			get 
  			{ 
  				return m_SourceItemCode ; 
  			}  
  			set 
  			{ 
  				m_SourceItemCode = value ; 
  			}  
  		} 
  
  		private string m_SourceItemName = string.Empty ; 
  		public string SourceItemName 
  		{ 
  			get 
  			{ 
  				return m_SourceItemName ; 
  			}  
  			set 
  			{ 
  				m_SourceItemName = value ; 
  			}  
  		} 
  
  		private string m_SourceItemStd = string.Empty ; 
  		public string SourceItemStd 
  		{ 
  			get 
  			{ 
  				return m_SourceItemStd ; 
  			}  
  			set 
  			{ 
  				m_SourceItemStd = value ; 
  			}  
  		} 
  
  		private string m_SourceItemModel = string.Empty ; 
  		public string SourceItemModel 
  		{ 
  			get 
  			{ 
  				return m_SourceItemModel ; 
  			}  
  			set 
  			{ 
  				m_SourceItemModel = value ; 
  			}  
  		} 
  
  		private decimal m_UnitPrice = 0; 
  		public decimal UnitPrice 
  		{ 
  			get 
  			{ 
  				return m_UnitPrice ; 
  			}  
  			set 
  			{ 
  				m_UnitPrice = value ; 
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
            string Sql="SELECT * FROM Buy_OthCompactDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Buy_OthCompactDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_DesignNO=SysConvert.ToString(MasterTable.Rows[0]["DesignNO"]); 
  				m_EditionNo=SysConvert.ToString(MasterTable.Rows[0]["EditionNo"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_YarnStatus=SysConvert.ToString(MasterTable.Rows[0]["YarnStatus"]); 
  				m_YarnTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["YarnTypeID"]); 
  				m_SourceItemCode=SysConvert.ToString(MasterTable.Rows[0]["SourceItemCode"]); 
  				m_SourceItemName=SysConvert.ToString(MasterTable.Rows[0]["SourceItemName"]); 
  				m_SourceItemStd=SysConvert.ToString(MasterTable.Rows[0]["SourceItemStd"]); 
  				m_SourceItemModel=SysConvert.ToString(MasterTable.Rows[0]["SourceItemModel"]); 
  				m_UnitPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["UnitPrice"]); 
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
