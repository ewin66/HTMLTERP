using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;


namespace HttSoft.MLTERP.DataCtl
{
	/// <summary>
	/// Ŀ�ģ�Data_VendorTypeDtsʵ��ҵ�������
	/// ����:�¼Ӻ�
	/// ��������:2014/5/24
	/// </summary>
	public class VendorTypeDtsRule
	{
	    /// <summary>
        /// ���캯��
        /// </summary>
		public VendorTypeDtsRule()
		{
		}
		
		/// <summary>
		/// ��齫Ҫ�����������Ƿ����ҵ�����
		/// </summary>
		/// <param name="p_BE"></param>
		private void CheckCorrect(BaseEntity p_BE)
		{
			VendorTypeDts entity=(VendorTypeDts)p_BE;
		}	
		
		
		 /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShow(string p_condition)
        {
            try
            {
                return RShow(p_condition, "*");
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShow(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM Data_VendorTypeDts WHERE 1=1";
                sql += p_condition;
                return SysUtils.Fill(sql);
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }


        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        public void RSave(BaseEntity p_BEMain, ArrayList p_BEDts)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSave(p_BEMain, p_BEDts, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        /// <summary>
        /// ����(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RSave(BaseEntity p_BEMain, ArrayList p_BEDts, IDBTransAccess sqlTrans)
        {
            try
            {
                Vendor entityVendor = (Vendor)p_BEMain;
                string sql = "";

                sql = "DELETE FROM Data_VendorTypeDts WHERE VendorID=" + SysString.ToDBString(entityVendor.VendorID);
                sqlTrans.ExecuteNonQuery(sql);

                for (int i = 0; i < p_BEDts.Count; i++)
                {
                    VendorTypeDts entity=(VendorTypeDts)p_BEDts[i];
                    sql = "INSERT INTO Data_VendorTypeDts(VendorID,VendorTypeID) VALUES("+SysString.ToDBString(entityVendor.VendorID)+","+entity.VendorTypeID+")";
                    sqlTrans.ExecuteNonQuery(sql);
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

		
	}
}
