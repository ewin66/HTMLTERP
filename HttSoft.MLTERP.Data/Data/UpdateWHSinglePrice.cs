using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_UpdateWHSinglePriceʵ����
	/// ����:����ǿ
	/// ��������:2012/12/19
	/// </summary>
	public sealed class UpdateWHSinglePrice : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public UpdateWHSinglePrice()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public UpdateWHSinglePrice(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "Data_UpdateWHSinglePrice";
		 
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
  
  		private string m_FormNo = string.Empty ; 
  		public string FormNo 
  		{ 
  			get 
  			{ 
  				return m_FormNo ; 
  			}  
  			set 
  			{ 
  				m_FormNo = value ; 
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
  
  		private decimal m_NewSinglePrice = 0; 
  		public decimal NewSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_NewSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_NewSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_OldSinglePrice = 0; 
  		public decimal OldSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_OldSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_OldSinglePrice = value ; 
  			}  
  		} 
  
  		private string m_UpdateOPName = string.Empty ; 
  		public string UpdateOPName 
  		{ 
  			get 
  			{ 
  				return m_UpdateOPName ; 
  			}  
  			set 
  			{ 
  				m_UpdateOPName = value ; 
  			}  
  		} 
  
  		private DateTime m_UpdateDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime UpdateDate 
  		{ 
  			get 
  			{ 
  				return m_UpdateDate ; 
  			}  
  			set 
  			{ 
  				m_UpdateDate = value ; 
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
            string Sql="SELECT * FROM Data_UpdateWHSinglePrice WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_UpdateWHSinglePrice WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
                m_ID=SysConvert.ToInt32(MasterTable.Rows[0]["ID"]); 
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_DtsID=SysConvert.ToInt32(MasterTable.Rows[0]["DtsID"]); 
  				m_NewSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["NewSinglePrice"]); 
  				m_OldSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["OldSinglePrice"]); 
  				m_UpdateOPName=SysConvert.ToString(MasterTable.Rows[0]["UpdateOPName"]); 
  				m_UpdateDate=SysConvert.ToDateTime(MasterTable.Rows[0]["UpdateDate"]); 
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
