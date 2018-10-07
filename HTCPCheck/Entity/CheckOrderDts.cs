using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：Chk_CheckOrderDts实体类
	/// 作者:周富春
	/// 创建日期:2015/11/4
	/// </summary>
	public sealed class CheckOrderDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CheckOrderDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckOrderDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Chk_CheckOrderDts";
		 
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
  
  		private string m_Batch = string.Empty ; 
  		public string Batch 
  		{ 
  			get 
  			{ 
  				return m_Batch ; 
  			}  
  			set 
  			{ 
  				m_Batch = value ; 
  			}  
  		} 
  
  		private string m_VendorBatch = string.Empty ; 
  		public string VendorBatch 
  		{ 
  			get 
  			{ 
  				return m_VendorBatch ; 
  			}  
  			set 
  			{ 
  				m_VendorBatch = value ; 
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
  
  		private int m_PieceQty = 0; 
  		public int PieceQty 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Chk_CheckOrderDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Chk_CheckOrderDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_Batch=SysConvert.ToString(MasterTable.Rows[0]["Batch"]); 
  				m_VendorBatch=SysConvert.ToString(MasterTable.Rows[0]["VendorBatch"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_PieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["PieceQty"]); 
  				m_CheckQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQty"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
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
