using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Sale_AuditPriceDtsʵ����
	/// ����:��С��
	/// ��������:2011-12-30
	/// </summary>
	public sealed class AuditPriceDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public AuditPriceDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public AuditPriceDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		 
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
  
  		private decimal m_Price = 0; 
  		public decimal Price 
  		{ 
  			get 
  			{ 
  				return m_Price ; 
  			}  
  			set 
  			{ 
  				m_Price = value ; 
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
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Sale_AuditPriceDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_AuditPriceDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// �������SQL����ѯ������Ը�ֵ
        /// </summary>
        /// <param name="p_Sql">SQL���</param>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
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
                //��ѯ�����¼
                m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_Price=SysConvert.ToDecimal(MasterTable.Rows[0]["Price"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_Percentage=SysConvert.ToDecimal(MasterTable.Rows[0]["Percentage"]); 
  				m_Loss=SysConvert.ToDecimal(MasterTable.Rows[0]["Loss"]); 
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
