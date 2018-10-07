using System;

namespace HttSoft.MLTERP.Sys
{
    /// <summary>
    /// 系统数据实体枚举
    /// </summary>
    public enum SysEntity
    {
        //基础管理
        Data_OP = 1,
        Data_Vendor = 2,
        Data_VendorContact = 3,
        Data_VendorSaleOP = 4,
        Data_VendorFile = 5,
        Data_VDsigner = 6,
        Data_VDsignerFile = 7,
        Data_CLS = 8,
        Data_CLSList = 9,
        Data_Board = 10,
        Data_CSBGItem = 11,
        Data_CSBGItemDts = 12,
        Data_MLDL = 13,
        Data_MLLB = 14,
        Data_MLYL = 15,
        Data_ItemClass = 16,
        Data_Item = 17,
        Data_ItemDts = 18,
        Data_ItemLBDts = 19,
        Data_ItemColorDts = 20,
        Data_ItemColorDtsHis = 21,
        Data_ItemGB = 22,
        Data_FormNCVendor = 23,
        Data_PayMethod = 24,
        Data_ProStep = 25,
        Data_SOContext = 26,
        Data_ReportManage = 27,
        Data_ReportFile = 28,
        Data_Follow = 29,
        Data_ItemGBUPHis = 30,
        Data_GZNoteDts = 31,
        Data_GZNote = 32,
        Data_PayMethodDts = 33,
        Data_VendorDesDts = 34,
        Data_VendorDes = 35,
        Data_UpdateWHVendor = 36,
        Data_UpdateWHSinglePrice = 37,
        Data_AddressList = 38,
        Data_AddressListDts = 39,
        Data_MsgPhone = 40,
        Data_BugForm = 41,
        Data_FNORel = 42,
        Data_SaleFlowModule = 43,
        Data_SaleFlowModuleDts = 44,
        Data_WinListAttachFile = 45,
        Data_WOOtherType = 46,
        Data_ItemCompositeDts = 47,
        Data_FOPDep = 48,
        Data_Structure = 49,
        Data_FVendorForm = 50,
        Data_ItemCodeFacDts = 51,
        Data_MachineManage = 52,


        Sys_ParamSet = 90,
        Sys_FiledSet = 91,

        /// <summary>
        /// 枚举类
        /// </summary>
        Enum_CompanyType = 101,
        Enum_ItemType = 102,
        Enum_WHCalMethod = 103,
        Enum_WHType = 104,
        Enum_WHSpecialType = 105,
        Enum_WHFormType = 106,
        Enum_WHCaiWuType = 107,
        Enum_WHDZType = 108,
        Enum_CompactType = 109,
        Enum_VendorType = 110,
        Enum_FormNoControl = 111,
        Enum_ParamSetType = 112,
        Enum_BaseEvaluation = 113,
        Enum_MailAlarmType = 114,
        Enum_Department = 115,
        Enum_SaleGroup = 116,
        Enum_Unit = 117,
        Enum_OrderStatus = 118,
        Enum_OrderType = 119,
        Enum_OrderLevel = 120,
        Enum_FormList = 121,
        Enum_BoxStatus = 122,
        Enum_SaleProcedure = 123,
        Enum_WOFollowType = 124,
        Enum_WOFollowStep = 125,
        Enum_WOFollowFieldSet = 126,



        Data_ItemCheckStandardPhy = 150,
        Data_ItemBaseCheckItem = 151,
        Data_ItemCheckSO = 152,
        Data_ItemSample = 153,
        Data_ItemGY = 154,
        Data_ItemGYFlowDts = 155,
        Data_ItemGYFlowItemDts = 156,
        Data_ItemBaseGYType = 157,
        Data_ItemBaseGYTypeDts = 158,

        Data_ItemGreyFabReplace = 159,


        //开发管理
        Dev_GBJC = 201,
        Dev_GBJCDts = 202,
        Dev_LYGL = 203,
        Dev_LYGLDts = 204,
        Dev_GBJCLR = 205,
        Dev_GBJCLRDts = 206,

        Dev_ColorSample = 207,
        Dev_ColorSampleDts = 208,
        Dev_QASample = 209,
        Dev_QASampleDts = 210,

        Dev_SampleSO = 211,
        Dev_SampleSODts = 212,
        Dev_ColorCard = 213,
        Dev_ColorCardDts = 214,

        Dev_Sample = 215,
        Dev_SampleDts = 216,

        //销售管理
        Sale_DYGL = 301,
        Sale_QuotedPrice = 302,
        Sale_QuotedPriceDts = 303,
        Sale_SaleOrder = 304,
        Sale_SaleOrderDts = 305,
        Sale_FHForm = 306,
        Sale_FHFormDts = 307,
        Sale_OrderProgress = 308,
        Sale_OrderProgressDts = 309,
        Sale_FHFormDtsPack = 310,
        Sale_FavItemGB = 311,
        Sale_SaleOrderCapDts = 312,
        Sale_SaleOrderCapExDts = 313,
        Sale_SOColor = 314,
        Sale_SampleSale = 315,
        Sale_SampleSaleDts = 316,
        Sale_SaleOrderItem = 317,
        Sale_SaleOrderFabric = 318,
        Sale_SaleOrderProcedureDts = 319,
        Sale_SaleOrderTFabric = 320,
        Sale_SaleOrderTColorItem = 321,
        Sale_SaleOrderTItem = 322,
        Sale_SaleOrderJS = 323,
        Sale_SaleOrderJSDts = 324,
        Sale_SaleOrderFabricCompSite = 325,
        Sale_SaleOrderTFabricCompSite = 326,
        Sale_ProductionNotice = 327,
        Sale_ProductionNoticeDts = 328,
        Sale_ProductionNoticeZZDts = 329,
        Sale_ProductionNoticeRSDts = 330,
        Sale_ProductionNoticeHZLDts = 331,
        Sale_ProductionNoticeBZDts = 332,
        Sale_SendSample = 333,
        Sale_JYOrder = 334,
        Sale_JYOrderDts = 335,
        Sale_JYOrderDtsInputPack = 336,
        Sale_HandleEvent = 337,
        Sale_SaleOrderInstruct = 338,
        Sale_SaleOrderInstructDts = 339,
        //采购管理
        Buy_ItemBuyForm = 401,
        Buy_ItemBuyFormDts = 402,
        Buy_ItemBuyFollow = 403,
        Buy_ItemBuyFollowDts = 404,
        Buy_ItemBuyCapExDts = 405,
        Buy_ItemBuyCapDts = 406,


        //辅助管理
        Att_ItemTestForm = 501,
        Att_ItemTestFormDts = 502,
        Att_ProductCheck = 503,
        Att_ProductCheckDts = 504,
        Att_GoodsTrans = 505,
        Att_GoodsTransDts = 506,
        Att_GoodsPost = 507,
        Att_VendorTrackRecord = 508,

        //仓库管理
        WH_WH = 601,
        WH_IOForm = 602,
        WH_Storge = 603,
        WH_StorgeLock = 604,
        WH_StorgeLockHis = 605,
        WH_StorgeAlarm = 606,
        WH_StorgePack = 607,
        WH_IOFormDetail = 608,
        WH_PackBoxKP = 609,
        WH_PackBox = 610,
        WH_PackBoxKPDts = 611,
        WH_StorgeJS = 612,
        WH_IOFormDtsPack = 613,
        WH_IOFormDts = 614,
        WH_QS = 615,
        WH_YQFormDtsPack = 616,
        WH_YQForm = 617,
        WH_YQFormDts = 618,
        WH_IOFormDtsInputPack = 619,
        WH_PckISN = 620,
        WH_DBForm = 621,
        WH_DBFormDts = 622,
        WH_DBFormDtsPack = 623,
        WH_LYForm = 624,
        WH_IOFormDtsISN = 625,
        WH_YarnTiaoPing = 626,

        //财务管理
        Finance_Pay = 701,
        Finance_Receiving = 702,
        Finance_CheckOperation = 703,
        Finance_CheckOperationDts = 704,
        Finance_ExpressDts = 705,
        Finance_Express = 706,
        Finance_CostRegister = 707,
        Finance_CostRegisterDts = 708,
        Finance_InvoiceOperation = 709,
        Finance_InvoiceOperationDts = 710,
        Finance_RecPay = 711,
        Finance_RecPayHXDts = 712,
        Finance_CapPlan = 713,
        Finance_CapPlanDts = 714,
        Finance_RecPayHTDts = 715,
        Finance_CheckOperationPayDts = 716,
        Finance_CheckOperationInvDts = 717,
        Finance_InvoiceYOperationDts = 718,
        Finance_FQC = 719,
        Finance_BVendorAmount = 720,
        Finance_JSVendorAmount = 721,
        Finance_WHAmountCE = 722,
        Finance_CostRecord = 723,
        Finance_RecPayDts = 724,

        Finance_SaleOPIDSaleRpt = 725,////////////////////
        Finance_VendorSaleRpt = 726,//////////////////
        Finance_ItemCodeSaleRpt = 727,///////////////////////
        Finance_PaymentHandle = 728,//货款处理

        //短信管理
        SMS_Test = 801,

        SMS_Message = 808,
        SMS_MSGMessage = 809,
        SMS_MSGMessageDts = 807,


        Data_FlowerTypeContol = 900,
        WO_Fabric = 901,



        //进出口
        Ship_ShipBoat = 909,
        Ship_Custom = 910,

        //WO车间检验
        WO_PackISNDts = 1004,
        WO_PackISN = 1002,
        WO_ISNTemp = 1003,

        WO_FabricWHOutForm = 1010,
        WO_FabricWHOutFormDts = 1011,
        WO_FabricWHOutFormDtsPack = 1012,
        WO_FabricProcessPBDts = 1013,
        WO_FabricProcessAdd = 1014,
        WO_TestReport = 1015,
        WO_TestReportDts = 1016,
        WO_ProductionPlan = 1017,
        WO_ProductionPlanDts = 1018,
        WO_ProductionPlanDts2 = 1019,

        SMS_MSGMain = 1101,
        SMS_SParamset = 1102,
        SMS_MSGSource = 1103,
        SMS_MSGInput = 1104,
        SMS_MSGInputDts = 1105,

        BBS_InfoMain = 1201,
        BBS_InfoMainShareDts = 1203,
        Enum_InfoType = 1205,

        //加工
        WO_FabricProcess = 1300,
        WO_FabricProcessDts = 1301,
        WO_PrintingProcess = 1302,
        WO_PrintingProcessDts = 1303,

        WO_WeaveProcess = 1304,
        WO_WeaveProcessDts = 1305,
        WO_WeaveProcessDts2 = 1306,

        WO_FabricProcessItemDts = 1308,


        WO_YieldRecord = 1309,
        WO_YieldRecordDts = 1310,



        /// <summary>
        /// 展会
        /// </summary>
        ADH_CheckForm = 1401,

        /// <summary>
        /// 毛巾生产计划
        /// </summary>
        WO_TowelProductionPlan = 1402,
        WO_TowelProductionPlanDts = 1403,
        WO_TowelProduction = 1404,
        WO_TowelProductionPlanDtsStep = 1405,
        WO_TowelProductionPlanDtsStepProducts = 1406,

    }
}