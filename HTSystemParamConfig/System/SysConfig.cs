using System;
using System.Drawing;

namespace HttSoft.HTERP.Sys
{
    /// <summary>
    /// ϵͳ���������Ϣ��.
    /// </summary>
    /// <remarks>����ϵͳ������Ϣ,�粻������ΪĬ�ϳ�ʼֵ</remarks> 
    public sealed class SysConfig
    {
        //ϵͳ��ܱ���Ĭ��ֵ
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
        /// ���췽��
        /// </summary>
        private SysConfig()
        {

        }

        #region ����Int32�������ݵ�����
        /// <summary>
        /// Int32��������Ĭ��ֵ
        /// </summary>
        /// <remarks>��ʼĬ��ֵΪ0</remarks>
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
        /// Int32���������������Сֵ
        /// </summary>
        /// <remarks>��ʼֵΪ-2147483648</remarks>
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
        /// Int32����������������ֵ
        /// </summary>
        /// <remarks>��ʼֵΪ2147483647</remarks>
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

        #region ����Decimal�������ݵ�����
        /// <summary>
        /// Ĭ�ϵ�Decimal���ݾ���(С��λ��)
        /// </summary>
        /// <remarks>��ʼֵΪ2</remarks>
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
        /// Decimal���ͱ�ʾ���������ݾ���(С��λ��)
        /// </summary>
        /// <remarks>��ʼֵΪ2</remarks>
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
        /// Decimal���ͱ�ʾ���۵����ݾ���(С��λ��)
        /// </summary>
        /// <remarks>��ʼֵΪ6</remarks>
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
        /// Decimal���ͱ�ʾ�������ݾ���(С��λ��)
        /// </summary>
        /// <remarks>��ʼֵΪ2</remarks>
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
        /// Decimal�������ݵ�Ĭ��ֵ
        /// </summary>
        /// <remarks>��ʼֵΪ0</remarks>
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
        /// decimal���������������Сֵ
        /// </summary>
        /// <remarks>Ĭ��Ϊ������</remarks>
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
        /// decimal����������������ֵ
        /// </summary>
        /// <remarks>Ĭ��Ϊ������</remarks>
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

        #region ����DateTime�������ݵ�����
        /// <summary>
        /// ����������Ĭ��ֵ
        /// </summary>
        /// <remarks>��ʼֵΪ1900-1-1����SQL SERVER���ݿ���������ֶ�Ĭ��ֵ��ͬ</remarks>
        public static DateTime DateTimeDefaultValue
        {
            get
            {
                return myDateTimeDefaultValue;
            }
        }
        /// <summary>
        /// ������������Сֵ
        /// </summary>
        /// <remarks>��ʼΪ1900-1-1</remarks> 
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
        /// �������������ֵ
        /// </summary>
        /// <remarks>��ʼֵΪ2100-1-1</remarks> 
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

        #region ������־�ļ�������
        /// <summary>
        /// Framework������Ϣ�ļ���ַ
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
        /// Framework������Ϣ�ļ���С(��λ:�ֽ� Ĭ��100K)
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
