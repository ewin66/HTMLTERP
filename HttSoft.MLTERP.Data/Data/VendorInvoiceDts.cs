using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_VendorInvoiceDtsʵ����
	/// ����:����ǿ
	/// ��������:2014/11/12
	/// </summary>
	public sealed class VendorInvoiceDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public VendorInvoiceDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public VendorInvoiceDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "Data_VendorInvoiceDts";
		 
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
  
  		private string m_CompName = string.Empty ; 
  		public string CompName 
  		{ 
  			get 
  			{ 
  				return m_CompName ; 
  			}  
  			set 
  			{ 
  				m_CompName = value ; 
  			}  
  		} 
  
  		private string m_TaxNo = string.Empty ; 
  		public string TaxNo 
  		{ 
  			get 
  			{ 
  				return m_TaxNo ; 
  			}  
  			set 
  			{ 
  				m_TaxNo = value ; 
  			}  
  		} 
  
  		private string m_Address = string.Empty ; 
  		public string Address 
  		{ 
  			get 
  			{ 
  				return m_Address ; 
  			}  
  			set 
  			{ 
  				m_Address = value ; 
  			}  
  		} 
  
  		private string m_Tel = string.Empty ; 
  		public string Tel 
  		{ 
  			get 
  			{ 
  				return m_Tel ; 
  			}  
  			set 
  			{ 
  				m_Tel = value ; 
  			}  
  		} 
  
  		private string m_Bank = string.Empty ; 
  		public string Bank 
  		{ 
  			get 
  			{ 
  				return m_Bank ; 
  			}  
  			set 
  			{ 
  				m_Bank = value ; 
  			}  
  		} 
  
  		private string m_No = string.Empty ; 
  		public string No 
  		{ 
  			get 
  			{ 
  				return m_No ; 
  			}  
  			set 
  			{ 
  				m_No = value ; 
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
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_VendorInvoiceDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_VendorInvoiceDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
  				m_CompName=SysConvert.ToString(MasterTable.Rows[0]["CompName"]); 
  				m_TaxNo=SysConvert.ToString(MasterTable.Rows[0]["TaxNo"]); 
  				m_Address=SysConvert.ToString(MasterTable.Rows[0]["Address"]); 
  				m_Tel=SysConvert.ToString(MasterTable.Rows[0]["Tel"]); 
  				m_Bank=SysConvert.ToString(MasterTable.Rows[0]["Bank"]); 
  				m_No=SysConvert.ToString(MasterTable.Rows[0]["No"]); 
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
