using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_FabricProcessItemDts实体类
	/// 作者:陈加海
	/// 创建日期:2014/7/15
	/// </summary>
	public sealed class FabricProcessItemDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FabricProcessItemDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FabricProcessItemDts(IDBTransAccess p_SqlCmd)
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
  
  		private int m_DtsID = 0; 
  		public int DtsID 
  		{ 
  			get 
  			{ 
  				return m_DtsID ; 
  			}  
  			set 
  			{ 
  				m_DtsID = value ; 
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
  
  		private string m_DtsItemCode = string.Empty ; 
  		public string DtsItemCode 
  		{ 
  			get 
  			{ 
  				return m_DtsItemCode ; 
  			}  
  			set 
  			{ 
  				m_DtsItemCode = value ; 
  			}  
  		} 
  
  		private string m_DtsItemName = string.Empty ; 
  		public string DtsItemName 
  		{ 
  			get 
  			{ 
  				return m_DtsItemName ; 
  			}  
  			set 
  			{ 
  				m_DtsItemName = value ; 
  			}  
  		} 
  
  		private string m_DtsItemStd = string.Empty ; 
  		public string DtsItemStd 
  		{ 
  			get 
  			{ 
  				return m_DtsItemStd ; 
  			}  
  			set 
  			{ 
  				m_DtsItemStd = value ; 
  			}  
  		} 
  
  		private string m_DtsItemModel = string.Empty ; 
  		public string DtsItemModel 
  		{ 
  			get 
  			{ 
  				return m_DtsItemModel ; 
  			}  
  			set 
  			{ 
  				m_DtsItemModel = value ; 
  			}  
  		} 
  
  		private decimal m_Percentage = 0; 
  		public decimal Percentage 
  		{ 
  			get 
  			{ 
  				return m_Percentage ; 
  			}  
  			set 
  			{ 
  				m_Percentage = value ; 
  			}  
  		} 
  
  		private decimal m_Loss = 0; 
  		public decimal Loss 
  		{ 
  			get 
  			{ 
  				return m_Loss ; 
  			}  
  			set 
  			{ 
  				m_Loss = value ; 
  			}  
  		} 
  
  		private decimal m_UseQty = 0; 
  		public decimal UseQty 
  		{ 
  			get 
  			{ 
  				return m_UseQty ; 
  			}  
  			set 
  			{ 
  				m_UseQty = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WO_FabricProcessItemDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_FabricProcessItemDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_DtsID=SysConvert.ToInt32(MasterTable.Rows[0]["DtsID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_DtsItemCode=SysConvert.ToString(MasterTable.Rows[0]["DtsItemCode"]); 
  				m_DtsItemName=SysConvert.ToString(MasterTable.Rows[0]["DtsItemName"]); 
  				m_DtsItemStd=SysConvert.ToString(MasterTable.Rows[0]["DtsItemStd"]); 
  				m_DtsItemModel=SysConvert.ToString(MasterTable.Rows[0]["DtsItemModel"]); 
  				m_Percentage=SysConvert.ToDecimal(MasterTable.Rows[0]["Percentage"]); 
  				m_Loss=SysConvert.ToDecimal(MasterTable.Rows[0]["Loss"]); 
  				m_UseQty=SysConvert.ToDecimal(MasterTable.Rows[0]["UseQty"]); 
  				m_DtsRemark=SysConvert.ToString(MasterTable.Rows[0]["DtsRemark"]); 
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
