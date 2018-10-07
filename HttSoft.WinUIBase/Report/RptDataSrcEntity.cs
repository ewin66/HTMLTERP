using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace HttSoft.WinUIBase
{
    /// <summary>
    /// ��������Դ��Ϣʵ����
    /// </summary>
    public class RptDataSrcEntity
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public RptDataSrcEntity() { }

        //private string dataSrcName = string.Empty;
        ///// <summary>
        ///// ����Դ��
        ///// </summary>
        //public string DataSrcName
        //{
        //    get { return dataSrcName; }
        //    set { dataSrcName = value; }
        //}
        private DataTable dtPrint = null;
        /// <summary>
        /// Ҫ��ӡ�����ݱ�
        /// </summary>
        public DataTable DtPrint
        {
            get { return dtPrint; }
            set { dtPrint = value; }
        }
        private string dataSetName = string.Empty;
        /// <summary>
        /// ���ݼ���
        /// </summary>
        public string DataSetName
        {
            get { return dataSetName; }
            set { dataSetName = value; }
        }
        private bool isSqlPrint = false;
        /// <summary>
        /// �Ƿ����SQL��ӡ
        /// </summary>
        public bool IsSqlPrint
        {
            get { return isSqlPrint; }
            set { isSqlPrint = value; }
        }
        private string sqlContent = string.Empty;
        /// <summary>
        /// SQL����
        /// </summary>
        public string SqlContent
        {
            get { return sqlContent; }
            set { sqlContent = value; }
        }
        private string sqlCondition = string.Empty;
        /// <summary>
        /// SQL����
        /// </summary>
        public string SqlCondition
        {
            get { return sqlCondition; }
            set { sqlCondition = value; }
        }
    }
}
