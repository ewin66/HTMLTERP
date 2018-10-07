using System;
using System.Collections.Generic;
using System.Text;

namespace HttSoft.MLTERP.Sys
{

    #region 码长
    /// <summary>
    /// 码长
    /// </summary>
    public class BarcodeLen
    {
        /// <summary>
        /// 最短码长
        /// </summary>
        public const int MIN = 4;
        /// <summary>
        /// 衣服
        /// </summary>
        public const int Cloth = 9;
        /// <summary>
        /// 附件
        /// </summary>
        public const int Attach = 10;
        /// <summary>
        /// 包
        /// </summary>
        public const int Package = 8;
        /// <summary>
        /// 工号
        /// </summary>
        public const int OP = 4;
        /// <summary>
        /// 系统码
        /// </summary>
        public const int SYS = 4;
        /// <summary>
        /// 错误码
        /// </summary>
        public const int ERROR = 5;

        /// <summary>
        /// 系统切换条码
        /// </summary>
        public const int SCONV = 4;

        /// <summary>
        /// 流转单号长度
        /// </summary>
        public const int StreamFormNo = 10;
    }

    #endregion


    #region 码抬头
    /// <summary>
    /// 条码类型枚举
    /// </summary>
    public enum BarcodeHead
    {
        NO,//无类型
        Y,//衣服 抬头为空
        YF,////附件 抬头F
        YP,////包 P
        N,//工人条码打头
        NX,//工人条码
        ER,//错误信息码
        StreamForm,//流转单
        SY,//系统基础码
        SD,
        SE
    }

    /// <summary>
    /// 条码抬头字符串
    /// </summary>
    public enum BarcodeHeadStr
    {
        NO,//无类型
        //衣服 抬头为空
        F,////附件 抬头F
        P,////包 P
    }

    #endregion


    #region 基础条码
    /// <summary>
    /// 基础条码
    /// </summary>
    public enum BarcodeBase
    {
        /// <summary>
        /// 清0
        /// </summary>
        SY01,//清0
        /// <summary>
        /// 提交完成
        /// </summary>
        SY02,//提交完成
        //		/// <summary>
        //		/// 清除上一个刷入的条码
        //		/// </summary>
        //		SY03,//清除上一个刷入的条码

        /// <summary>
        /// 不良返品
        /// </summary>
        SYER,//不良

        /// <summary>
        /// 次品报废
        /// </summary>
        SYBA,//次品


    }

    #endregion


    #region 条码状态
    /// <summary>
    /// 条码状态(衣服、包、附件)状态
    /// </summary>
    public enum BISNStatus
    {
        /// <summary> 
        /// 无 
        /// </summary> 
        无 = 0,
        /// <summary> 
        /// 正常 
        /// </summary> 
        正常 = 1,
        /// <summary> 
        /// 不良修复中 
        /// </summary> 
        不良 = 2,
        /// <summary> 
        /// 报废 
        /// </summary> 
        报废 = 3,
        /// <summary> 
        /// 出货 
        /// </summary> 
        出货 = 4,
        /// <summary> 
        /// 未启用 
        /// </summary> 
        未启用 = 90,
    }
    #endregion


    #region 条码站别状态
    /// <summary>
    /// 条码站别状态(衣服、包、附件)站别状态
    /// </summary>
    public enum BISNStepStatus
    {
        /// <summary> 
        /// 无 
        /// </summary> 
        无 = 0,
        /// <summary> 
        /// 普通发 
        /// </summary> 
        普通发 = 1,
        /// <summary> 
        /// 普通收 
        /// </summary> 
        普通收 = 2,
        /// <summary> 
        /// 检验发 
        /// </summary> 
        检验发 = 3,
        /// <summary> 
        /// 检验收 
        /// </summary> 
        检验收 = 4,
        /// <summary> 
        /// 补料 
        /// </summary> 
        补料 = 5,
        /// <summary> 
        /// 退料 
        /// </summary> 
        退料 = 6,
        /// <summary> 
        /// 下转 
        /// </summary> 
        下转 = 7,
        /// <summary> 
        /// 不良 
        /// </summary> 
        不良 = 8,
        /// <summary> 
        /// 报废 
        /// </summary> 
        报废 = 9,
        /// <summary> 
        /// 外发发 
        /// </summary> 
        外发发 = 10,
        /// <summary> 
        /// 外发收 
        /// </summary> 
        外发收 = 11,
        /// <summary> 
        /// 包装 
        /// </summary> 
        包装 = 12,
        /// <summary> 
        /// 加入包 
        /// </summary> 
        加入包 = 13,
        /// <summary> 
        /// 离开包 
        /// </summary> 
        离开包 = 14,
        /// <summary> 
        /// 接收下转 
        /// </summary> 
        接收下转 = 15,
        /// <summary> 
        /// 配附件 
        /// </summary> 
        配附件 = 16,
        /// <summary> 
        /// 未制作退回上站 
        /// </summary> 
        未制作退回上站 = 17,
        /// <summary> 
        /// 取消流转 
        /// </summary> 
        取消流转 = 18,
        /// <summary> 
        /// 打印 
        /// </summary> 
        打印 = 80,
        /// <summary> 
        /// 未启用 
        /// </summary> 
        未启用 = 90,
    }
    #endregion

    #region 制程类型
    public enum WOStepWorkType
    {
        织片 = 1,
        烫片 = 2,
        毛验 = 3,
    }
    #endregion

    #region 站别
    public enum WOBBaseStep
    {
        /// <summary>
        /// 横机
        /// </summary>
        START,
        /// <summary>
        /// 套扣
        /// </summary>
        WK002,
        /// <summary>
        /// 手缝
        /// </summary>
        WK003,
        /// <summary>
        /// 前道外发
        /// </summary>
        WK004,
        /// <summary>
        /// 水洗
        /// </summary>
        WK005,
        /// <summary>
        /// 平车
        /// </summary>
        WK006,
        /// <summary>
        /// 整烫
        /// </summary>
        WK007,
        /// <summary>
        /// 复尺
        /// </summary>
        WK008,
        /// <summary>
        /// 检验
        /// </summary>
        WK009,
        /// <summary>
        /// 后整外发
        /// </summary>
        WK010,
        /// <summary>
        /// 外加工厂
        /// </summary>
        WK099,
        /// <summary>
        /// 包装
        /// </summary>
        WKEND,
    }
    #endregion

    #region 条码类型
    public enum BarcodeType
    {
        衣服条码 = 1,
        附件条码 = 2,
        包条码 = 3,
    }
    #endregion

    #region 条码详细信息
    public enum ConfigBarcode
    {
        //衣服
        衣服标题 = 0,
        衣服条码 = 1,
        衣服货号 = 2,
        衣服尺码 = 3,
        衣服色号 = 4,
        衣服色名 = 5,
        衣服缸号 = 6,
        衣服横机 = 7,
        衣服套口 = 8,
        衣服手缝 = 9,
        衣服平车 = 10,
        衣服线 = 11,

        //附件
        附件属性 = 12,
        附件货号 = 13,
        附件尺码 = 14,
        附件色号 = 15,
        附件色名 = 16,
        附件缸号 = 17,
        附件横机 = 18,
        附件线 = 19,
        附件条码 = 20,

        //包
        包标题 = 21,
        包条码 = 22,

        //条码设定
        打印深度 = 23,
        条码高度 = 24,
    }
    #endregion
    
}
