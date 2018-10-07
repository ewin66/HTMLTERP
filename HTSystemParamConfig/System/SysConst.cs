using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HttSoft.HTERP.Sys
{
    public sealed class SystemConst
    {
        #region 单位
        public static readonly string 厘米 = "cm";
        public static readonly string 磅 = "lbs";
        public static readonly string 英尺 = "inch";
        public static readonly string 克每平米 = "g/m2";
        #endregion

        /// <summary>
        /// 物品编码，物品名称，物品规格字符串数组
        /// </summary>
        public static readonly string[] ItemCodeItemNameItemStdArray = new string[] { "ItemCode", "ItemName", "ItemStd" };//此数组很重要,任何人都不要修改
        /// <summary>
        /// 逗号分隔符 ,
        /// </summary>
        public static readonly string SpearateTokenComma = ",";
        /// <summary>
        /// 空格
        /// </summary>
        public static readonly string Space = " ";
        /// <summary>
        /// 加号  +
        /// </summary>
        public static readonly string PlusSign = "+";
        /// <summary>
        /// 反斜杠 /
        /// </summary>
        public static readonly string Backslash = "/";
        /// <summary>
        /// 箭头  ->
        /// </summary>
        public static readonly string Arrow = "->";
        /// <summary>
        /// 四种物品编码之间的分隔字符
        /// </summary>
        public static readonly string ItemSeparateToken = ",";//此分隔符很重要，任何人都不要随意修改
        /// <summary>
        /// GridView的列只读时的背景色
        /// </summary>
        public static readonly Color GridColumnReadonlyBackColor = System.Drawing.SystemColors.Control;
        /// <summary>
        /// 预计交期默认自动顺延天数
        /// </summary>
        public static readonly int ReqDateDefaultDelay = 7;
        /// <summary>
        /// //数据回填标志  提交回填
        /// </summary>
        public static readonly string FillBackFXZ = "Z";
        /// <summary>
        /// //数据回填标志  撤销提交回填
        /// </summary>
        public static readonly string FillBackFXF = "F";
        
        /// <summary>
        /// 尺码数量
        /// </summary>
        public static readonly int SizeNum = 15;
        /// <summary>
        /// 尺码列名前缀
        /// </summary>
        public static readonly string SizeName = "SizeName";
        /// <summary>
        /// 尺码颜色数量列名前缀
        /// </summary>
        public static readonly string QtyColumnName = "Qty";
        /// <summary>
        /// 尺码颜色汇总数
        /// </summary>
        public static readonly string TotalColorQtyColumnName = "TotalColorQty";
        /// <summary>
        /// 尺码名称列名数组
        /// </summary>
        public static readonly string[] SizeNameColumnNameArray = new string[] { "SizeName1", "SizeName2", "SizeName3", "SizeName4", "SizeName5", "SizeName6", "SizeName7", "SizeName8", "SizeName9", "SizeName10", "SizeName11", "SizeName12", "SizeName13", "SizeName14", "SizeName15", };
        /// <summary>
        /// 尺码颜色数量列名数组
        /// </summary>
        public static readonly string[] QtyNameColumnNameArray = new string[] { "Qty1", "Qty2", "Qty3", "Qty4", "Qty5", "Qty6", "Qty7", "Qty8", "Qty9", "Qty10", "Qty11", "Qty12", "Qty13", "Qty14", "Qty15", };
        /// <summary>
        /// 尺码颜色数量列名List
        /// </summary>
        public static readonly List<string> QtyNameColumnNameList = new List<string>(QtyNameColumnNameArray);
        /// <summary>
        /// 流程定义的最多个数
        /// </summary>
        public static readonly int BuyFlowMaxNum = 8;
        public static readonly string PlanBuyFormTypeIDName = "PlanBuyFormTypeID";
        /// <summary>
        /// 采购流程ID列名数组
        /// </summary>
        public static readonly string[] PlanBuyFormTypeIDNameArray = new string[] { "PlanBuyFormTypeID1","PlanBuyFormTypeID2", "PlanBuyFormTypeID3", "PlanBuyFormTypeID4", "PlanBuyFormTypeID5",
                                                                               "PlanBuyFormTypeID6","PlanBuyFormTypeID7","PlanBuyFormTypeID8"};
        /// <summary>
        /// 采购流程ID列名List
        /// </summary>
        public static readonly List<string> PlanBuyFormTypeIDNameList = new List<string>(PlanBuyFormTypeIDNameArray);
        /// <summary>
        /// 算料最大损耗数
        /// </summary>
        public static readonly int CalRateMaxNum = 15;
        /// <summary>
        /// 算料比例名称
        /// </summary>
        public static readonly string CalRateName = "PSRate";
        /// <summary>
        /// 算料比例用量名称
        /// </summary>
        public static readonly string CalQtyName = "PSQty";
        /// <summary>
        /// 算料单据类型ID名称
        /// </summary>
        public static readonly string CalBuyFormTypeIDName = "CalBuyFormTypeID";



    }
}
