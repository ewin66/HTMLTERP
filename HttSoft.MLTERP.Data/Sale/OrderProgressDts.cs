using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_OrderProgressDts实体类
	/// 作者:章文强
	/// 创建日期:2012-5-31
	/// </summary>
	public sealed class OrderProgressDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public OrderProgressDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public OrderProgressDts(IDBTransAccess p_SqlCmd)
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
  
  		private string m_FollowNo = string.Empty ; 
  		public string FollowNo 
  		{ 
  			get 
  			{ 
  				return m_FollowNo ; 
  			}  
  			set 
  			{ 
  				m_FollowNo = value ; 
  			}  
  		} 
  
  		private string m_ModelCode = string.Empty ; 
  		public string ModelCode 
  		{ 
  			get 
  			{ 
  				return m_ModelCode ; 
  			}  
  			set 
  			{ 
  				m_ModelCode = value ; 
  			}  
  		} 
  
  		private string m_ModelName = string.Empty ; 
  		public string ModelName 
  		{ 
  			get 
  			{ 
  				return m_ModelName ; 
  			}  
  			set 
  			{ 
  				m_ModelName = value ; 
  			}  
  		} 
  
  		private string m_GoodsCode = string.Empty ; 
  		public string GoodsCode 
  		{ 
  			get 
  			{ 
  				return m_GoodsCode ; 
  			}  
  			set 
  			{ 
  				m_GoodsCode = value ; 
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
  
  		private DateTime m_ReqDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ReqDate 
  		{ 
  			get 
  			{ 
  				return m_ReqDate ; 
  			}  
  			set 
  			{ 
  				m_ReqDate = value ; 
  			}  
  		} 
  
  		private string m_SR = string.Empty ; 
  		public string SR 
  		{ 
  			get 
  			{ 
  				return m_SR ; 
  			}  
  			set 
  			{ 
  				m_SR = value ; 
  			}  
  		} 
  
  		private string m_FS = string.Empty ; 
  		public string FS 
  		{ 
  			get 
  			{ 
  				return m_FS ; 
  			}  
  			set 
  			{ 
  				m_FS = value ; 
  			}  
  		} 
  
  		private string m_ZZ = string.Empty ; 
  		public string ZZ 
  		{ 
  			get 
  			{ 
  				return m_ZZ ; 
  			}  
  			set 
  			{ 
  				m_ZZ = value ; 
  			}  
  		} 
  
  		private string m_RZ = string.Empty ; 
  		public string RZ 
  		{ 
  			get 
  			{ 
  				return m_RZ ; 
  			}  
  			set 
  			{ 
  				m_RZ = value ; 
  			}  
  		} 
  
  		private string m_CP = string.Empty ; 
  		public string CP 
  		{ 
  			get 
  			{ 
  				return m_CP ; 
  			}  
  			set 
  			{ 
  				m_CP = value ; 
  			}  
  		} 
  
  		private string m_DRemark = string.Empty ; 
  		public string DRemark 
  		{ 
  			get 
  			{ 
  				return m_DRemark ; 
  			}  
  			set 
  			{ 
  				m_DRemark = value ; 
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
            string Sql="SELECT * FROM Sale_OrderProgressDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_OrderProgressDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FollowNo=SysConvert.ToString(MasterTable.Rows[0]["FollowNo"]); 
  				m_ModelCode=SysConvert.ToString(MasterTable.Rows[0]["ModelCode"]); 
  				m_ModelName=SysConvert.ToString(MasterTable.Rows[0]["ModelName"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_ReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ReqDate"]); 
  				m_SR=SysConvert.ToString(MasterTable.Rows[0]["SR"]); 
  				m_FS=SysConvert.ToString(MasterTable.Rows[0]["FS"]); 
  				m_ZZ=SysConvert.ToString(MasterTable.Rows[0]["ZZ"]); 
  				m_RZ=SysConvert.ToString(MasterTable.Rows[0]["RZ"]); 
  				m_CP=SysConvert.ToString(MasterTable.Rows[0]["CP"]); 
  				m_DRemark=SysConvert.ToString(MasterTable.Rows[0]["DRemark"]); 
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
