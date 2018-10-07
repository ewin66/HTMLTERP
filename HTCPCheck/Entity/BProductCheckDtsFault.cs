using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// Ŀ�ģ�WO_BProductCheckDtsFaultʵ����
	/// ����:�¼Ӻ�
	/// ��������:2014/5/4
	/// </summary>
	public sealed class BProductCheckDtsFault : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public BProductCheckDtsFault()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public BProductCheckDtsFault(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		 
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
  
  		private int m_FaultType = 0; 
  		public int FaultType 
  		{ 
  			get 
  			{ 
  				return m_FaultType ; 
  			}  
  			set 
  			{ 
  				m_FaultType = value ; 
  			}  
  		} 
  
  		private decimal m_BLength = 0; 
  		public decimal BLength 
  		{ 
  			get 
  			{ 
  				return m_BLength ; 
  			}  
  			set 
  			{ 
  				m_BLength = value ; 
  			}  
  		} 
  
  		private decimal m_ELength = 0; 
  		public decimal ELength 
  		{ 
  			get 
  			{ 
  				return m_ELength ; 
  			}  
  			set 
  			{ 
  				m_ELength = value ; 
  			}  
  		} 
  
  		private string m_FaultDes = string.Empty ; 
  		public string FaultDes 
  		{ 
  			get 
  			{ 
  				return m_FaultDes ; 
  			}  
  			set 
  			{ 
  				m_FaultDes = value ; 
  			}  
  		} 
  
  		private decimal m_Deduction = 0; 
  		public decimal Deduction 
  		{ 
  			get 
  			{ 
  				return m_Deduction ; 
  			}  
  			set 
  			{ 
  				m_Deduction = value ; 
  			}  
  		} 
  
  		private decimal m_DQuantity = 0; 
  		public decimal DQuantity 
  		{ 
  			get 
  			{ 
  				return m_DQuantity ; 
  			}  
  			set 
  			{ 
  				m_DQuantity = value ; 
  			}  
  		} 
  
  		private string m_Position = string.Empty ; 
  		public string Position 
  		{ 
  			get 
  			{ 
  				return m_Position ; 
  			}  
  			set 
  			{ 
  				m_Position = value ; 
  			}  
  		} 
  
  		private int m_MaxIndex = 0; 
  		public int MaxIndex 
  		{ 
  			get 
  			{ 
  				return m_MaxIndex ; 
  			}  
  			set 
  			{ 
  				m_MaxIndex = value ; 
  			}  
  		} 
  
  		private decimal m_DYM = 0; 
  		public decimal DYM 
  		{ 
  			get 
  			{ 
  				return m_DYM ; 
  			}  
  			set 
  			{ 
  				m_DYM = value ; 
  			}  
  		} 
  
  		private decimal m_CYQty = 0; 
  		public decimal CYQty 
  		{ 
  			get 
  			{ 
  				return m_CYQty ; 
  			}  
  			set 
  			{ 
  				m_CYQty = value ; 
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
            string Sql="SELECT * FROM WO_BProductCheckDtsFault WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_BProductCheckDtsFault WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_FaultType=SysConvert.ToInt32(MasterTable.Rows[0]["FaultType"]); 
  				m_BLength=SysConvert.ToDecimal(MasterTable.Rows[0]["BLength"]); 
  				m_ELength=SysConvert.ToDecimal(MasterTable.Rows[0]["ELength"]); 
  				m_FaultDes=SysConvert.ToString(MasterTable.Rows[0]["FaultDes"]); 
  				m_Deduction=SysConvert.ToDecimal(MasterTable.Rows[0]["Deduction"]); 
  				m_DQuantity=SysConvert.ToDecimal(MasterTable.Rows[0]["DQuantity"]); 
  				m_Position=SysConvert.ToString(MasterTable.Rows[0]["Position"]); 
  				m_MaxIndex=SysConvert.ToInt32(MasterTable.Rows[0]["MaxIndex"]); 
  				m_DYM=SysConvert.ToDecimal(MasterTable.Rows[0]["DYM"]); 
  				m_CYQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CYQty"]); 
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
