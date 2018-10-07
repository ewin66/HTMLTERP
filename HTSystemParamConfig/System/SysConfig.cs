using System;
using System.Drawing;

namespace HttSoft.HTERP.Sys
{
    /// <summary>
    /// 系统框架配置信息类.
    /// </summary>
    /// <remarks>设置系统配置信息,如不设置则为默认初始值</remarks> 
    public sealed class SysConfig
    {
        //系统框架变量默认值
        private static int myInt32DefaultValue = 0;
        private static int myInt32MinValue = -2147483648;
        private static int myInt32MaxValue = 2147483647;
        private static int myDecimalDefaultDigits = 2;
        private static int myDecimalQuantityDigits = 2;
        private static int myDecimalPriceDigits = 4;
        private static int myDecimalAmountDigits = 2;
        private static decimal myDecimalDefaultValue = 0;
        private static decimal myDecimalMinValue = -1;
        private static decimal myDecimalMaxValue = -1;
        private static DateTime myDateTimeDefaultValue = new DateTime(1900, 1, 1);
        private static DateTime myDateTimeMinValue = new DateTime(1900, 1, 1);
        private static DateTime myDateTimeMaxValue = new DateTime(2100, 1, 1);
        private static string myLogFile = "/SysLog.txt";
        private static long myLogFileLength = 10000;//10K
        /// <summary>
        /// 构造方法
        /// </summary>
        private SysConfig()
        {

        }

        #region 关于Int32类型数据的配置
        /// <summary>
        /// Int32类型数据默认值
        /// </summary>
        /// <remarks>初始默认值为0</remarks>
        public static int Int32DefaultValue
        {
            get
            {
                return myInt32DefaultValue;
            }
            set
            {
                myInt32DefaultValue = value;
            }
        }
        /// <summary>
        /// Int32类型数据允许的最小值
        /// </summary>
        /// <remarks>初始值为-2147483648</remarks>
        public static int Int32MinValue
        {
            get
            {
                return myInt32MinValue;
            }
            set
            {
                myInt32MinValue = value;
            }
        }
        /// <summary>
        /// Int32类型数据允许的最大值
        /// </summary>
        /// <remarks>初始值为2147483647</remarks>
        public static int Int32MaxValue
        {
            get
            {
                return myInt32MaxValue;
            }
            set
            {
                myInt32MaxValue = value;
            }
        }

        #endregion

        #region 关于Decimal类型数据的配置
        /// <summary>
        /// 默认的Decimal数据精度(小数位数)
        /// </summary>
        /// <remarks>初始值为2</remarks>
        public static int DecimalDefaultDigits
        {
            get
            {
                return myDecimalDefaultDigits;
            }
            set
            {
                myDecimalDefaultDigits = value;
            }
        }
        /// <summary>
        /// Decimal类型表示数量的数据精度(小数位数)
        /// </summary>
        /// <remarks>初始值为2</remarks>
        public static int DecimalQuantityDigits
        {
            get
            {
                return myDecimalQuantityDigits;
            }
            set
            {
                myDecimalQuantityDigits = value;
            }
        }
        /// <summary>
        /// Decimal类型表示单价的数据精度(小数位数)
        /// </summary>
        /// <remarks>初始值为6</remarks>
        public static int DecimalPriceDigits
        {
            get
            {
                return myDecimalPriceDigits;
            }
            set
            {
                myDecimalPriceDigits = value;
            }
        }
        /// <summary>
        /// Decimal类型表示金额的数据精度(小数位数)
        /// </summary>
        /// <remarks>初始值为2</remarks>
        public static int DecimalAmountDigits
        {
            get
            {
                return myDecimalAmountDigits;
            }
            set
            {
                myDecimalAmountDigits = value;
            }
        }
        /// <summary>
        /// Decimal类型数据的默认值
        /// </summary>
        /// <remarks>初始值为0</remarks>
        public static decimal DecimalDefaultValue
        {
            get
            {
                return myDecimalDefaultValue;
            }
            set
            {
                myDecimalDefaultValue = value;
            }
        }
        /// <summary>
        /// decimal类型数据允许的最小值
        /// </summary>
        /// <remarks>默认为不限制</remarks>
        public static decimal DecimalMinValue
        {
            get
            {
                return myDecimalMinValue;
            }
            set
            {
                myDecimalMinValue = value;
            }
        }
        /// <summary>
        /// decimal类型数据允许的最大值
        /// </summary>
        /// <remarks>默认为不限制</remarks>
        public static decimal DecimalMaxValue
        {
            get
            {
                return myDecimalMaxValue;
            }
            set
            {
                myDecimalMaxValue = value;
            }
        }
        #endregion

        #region 关于DateTime类型数据的配置
        /// <summary>
        /// 日期型数据默认值
        /// </summary>
        /// <remarks>初始值为1900-1-1，与SQL SERVER数据库的日期型字段默认值相同</remarks>
        public static DateTime DateTimeDefaultValue
        {
            get
            {
                return myDateTimeDefaultValue;
            }
        }
        /// <summary>
        /// 日期型数据最小值
        /// </summary>
        /// <remarks>初始为1900-1-1</remarks> 
        public static DateTime DateTimeMinValue
        {
            get
            {
                return myDateTimeMinValue;
            }
            set
            {
                myDateTimeMinValue = value;
            }
        }
        /// <summary>
        /// 日期型数据最大值
        /// </summary>
        /// <remarks>初始值为2100-1-1</remarks> 
        public static DateTime DateTimeMaxValue
        {
            get
            {
                return myDateTimeMaxValue;
            }
            set
            {
                myDateTimeMaxValue = value;
            }
        }
        #endregion

        #region 关于日志文件的配置
        /// <summary>
        /// Framework错误信息文件地址
        /// </summary>
        public static string LogFile
        {
            get
            {
                return myLogFile;
            }
            set
            {
                myLogFile = value;
            }
        }

        /// <summary>
        /// Framework错误信息文件大小(单位:字节 默认100K)
        /// </summary>
        public static long LogFileLength
        {
            get
            {
                return myLogFileLength;
            }
            set
            {
                myLogFileLength = value;
            }
        }
        #endregion

    }

}
