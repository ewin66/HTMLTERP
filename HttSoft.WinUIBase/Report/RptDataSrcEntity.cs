using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace HttSoft.WinUIBase
{
    /// <summary>
    /// 报表数据源信息实体类
    /// </summary>
    public class RptDataSrcEntity
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public RptDataSrcEntity() { }

        //private string dataSrcName = string.Empty;
        ///// <summary>
        ///// 数据源名
        ///// </summary>
        //public string DataSrcName
        //{
        //    get { return dataSrcName; }
        //    set { dataSrcName = value; }
        //}
        private DataTable dtPrint = null;
        /// <summary>
        /// 要打印的数据表
        /// </summary>
        public DataTable DtPrint
        {
            get { return dtPrint; }
            set { dtPrint = value; }
        }
        private string dataSetName = string.Empty;
        /// <summary>
        /// 数据集名
        /// </summary>
        public string DataSetName
        {
            get { return dataSetName; }
            set { dataSetName = value; }
        }
        private bool isSqlPrint = false;
        /// <summary>
        /// 是否根据SQL打印
        /// </summary>
        public bool IsSqlPrint
        {
            get { return isSqlPrint; }
            set { isSqlPrint = value; }
        }
        private string sqlContent = string.Empty;
        /// <summary>
        /// SQL内容
        /// </summary>
        public string SqlContent
        {
            get { return sqlContent; }
            set { sqlContent = value; }
        }
        private string sqlCondition = string.Empty;
        /// <summary>
        /// SQL条件
        /// </summary>
        public string SqlCondition
        {
            get { return sqlCondition; }
            set { sqlCondition = value; }
        }
    }
}
