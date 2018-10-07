using System;

namespace HttSoft.HTERP.Sys
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
        Data_CLSForm = 13,
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
        Data_Fabric = 36,
        Data_FabricItem = 37,
        Data_FabricColor = 38,
        Data_FabricColorItem = 39,
        Data_FabricSJ = 40,
        Data_MachineManage = 41,
        Data_CDGL = 130001,
        DataWO_BBaseStep = 43,
        DataWO_BStepShop = 44,
        DataWO_BStepWork = 45,
        Data_FabricWZ = 51,
        Data_FabricWD = 52,
        Data_FabricJZ = 53,
        Data_FabricGY = 54,


        Com_LeaveApply = 55,
        Com_ResignationApply = 56,
        Com_EmployRecord = 57,
        Com_EmployRecordDts = 58,
        Com_RecruitApply = 59,
        Com_Regulation = 60,
        ADH_DataISN = 61,
        Pic_ItemPicture = 62,

        Development_FabricTechnology = 63,
        Development_FabricTechnologyDts = 64,
        Development_FabricTechnologyHistory = 65,
        Data_ItemVendorDts = 66,
        Data_FabricBOM = 67,

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
        Enum_Department = 115,//部门
        Enum_SaleGroup = 116,
        Enum_Unit = 117,
        Enum_OrderStatus = 118,
        Enum_OrderType = 119,
        Enum_OrderLevel = 120,
        Enum_FormList = 121,
        Enum_BoxStatus = 122,
        Enum_FabricType = 123,
        Enum_Dep = 124,//岗位 


        Sys_ParamSet = 90,


        //开发管理
        Dev_GBJC = 201,
        Dev_GBJCDts = 202,
        Dev_LYGL = 203,
        Dev_LYGLDts = 204,

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

        Sale_OrderReview = 314,
        Sale_OrderReviewProduct = 315,
        Sale_OrderReviewItem = 316,
        Sale_OrderReviewItemJarNum = 317,
        Sale_OrderReviewAfterFinishing = 318,
        Sale_SaleOrderSumDts = 319,
        Sale_FabricQuotedPrice = 320,
        Sale_FabricQuotedPriceDts = 321,

        Sale_SendSample = 322,
        Sale_SendSampleDts = 323,

        Sale_RecordMove=324,


        //打样
        Sale_PrintingSampleNotice = 900,
        Sale_YarnSampleNotice = 901,
        Sale_YarnSampleNoticeDts = 902,
        Sale_FabricSampleNotice = 903,
        Sale_FabricSampleNoticeDts = 904,
        Sale_DeliverySampleRecord = 905,//送办记录主表
        Sale_DeliverySampleRecordDts = 906,//送办记录明细表
        Sale_VendorSampleRegister = 907,
        Sale_VendorSampleRegisterDts = 908,
        Sale_ColorCardApply = 909,
        Sale_ColorCardApplyDts = 910,
        Sale_ColorCardSend = 911,
        Sale_ColorCardSendDts = 912,
        Sale_OrderReviewItemDts = 913,
        Sale_OrderReviewMessage = 914,
        Sale_OrderCancel = 915,
        Sale_OrderCancelDts = 916,
        //采购管理
        Buy_ItemBuyForm = 401,
        Buy_ItemBuyFormDts = 402,
        Buy_ItemBuyFollow = 403,
        Buy_ItemBuyFollowDts = 404,
        Buy_ItemBuyCapExDts = 405,
        Buy_ItemBuyCapDts = 406,


        JS_JSTab = 451,
        JS_JSFee = 452,
        JS_JSBaseKHSubject = 453,
        JS_JSSORec = 454,
        JS_JSBaseTabSubject = 455,
        JS_JSSO = 456,
        JS_JSBaseKHSection = 457,
        JS_JSBaseTabSection = 458,
        JS_JSBaseTab = 459,
        JS_JSKH = 460,
        JS_JSTabSubject = 461,
        JS_JSFeeSubject = 462,
        JS_JSKHSubject = 463,
        JS_JSBaseKH = 464,
        JS_ESectionType = 465,
        JS_ESourceType = 466,
        JS_ECalType = 467,
        JS_JSAccrual = 468,
        JS_JSBaseTabSubjectStepCalc=470,

        //辅助管理
        Att_ItemTestForm = 501,
        Att_ItemTestFormDts = 502,
        Att_ProductCheck = 503,
        Att_ProductCheckDts = 504,
        Att_GoodsTrans = 505,
        Att_GoodsTransDts = 506,
        Att_GoodsPost = 507,

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
        WH_Transceivers = 616,
        WH_TransceiversNodeShow = 617,
        WH_TransceiversNodeShowDts = 618,
        WH_Section = 619,
        WH_SBit = 620,
        WH_PckISN = 621,
        WH_PackDetailDts = 622,
        WH_PackDetail = 623,
        WH_CheckWHNegativeNumber = 624,
        WH_PriceUpdate = 625,
        WH_PriceUpdateDts = 626,
        WH_PckISNBag=627,
        WH_PBInCompactQty=628,
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
        Finance_JGDZMain = 723,
        Finance_PayablesDZ = 724,
        Finance_TradeSale = 725,
        Finance_PayablesDZJG = 726,
        Finance_GZMain = 727,
        Finance_DomesticTrade = 728,
        Finance_GZMonth = 729,
        Finance_AmountQC = 730,
        Finance_RecPayDts=731,
        //短信管理
        SMS_Test = 801,

        Data_FlowerTypeContol = 900,
        WO_Fabric = 901,


        //WO车间检验 1000-1099
        WO_PackISNDts = 1004,
        WO_PackISN = 1002,
        WO_ISNTemp = 1003,
        WO_OutPutRecordDts = 1006,
        WO_OutPutRecord = 1005,
        WO_BProductCheck = 1007,
        WO_BProductCheckDts = 130004,
        WO_BProductCheckDtsFault = 130005,
        WO_AddItemApply = 1110,
        WO_AddItemApplyDts = 1111,
        WO_BProductCheckDtsModifyLog=130006,
        WO_LLList=113,
        SMS_MSGMain = 1101,
        SMS_SParamset = 1102,
        SMS_MSGSource = 1103,
        SMS_MSGInput = 1104,
        SMS_MSGInputDts = 1105,
        WO_DefectRegistration = 1106,
        WO_ProCheck = 1107,
        WO_FXLog = 1108,
        WO_FXOperation = 1109,

        BBS_InfoMain = 1201,
        BBS_InfoMainShareDts = 1203,
        Enum_InfoType = 1205,
        WO_PackOrderDts = 130002,
        WO_PackOrder = 130003,

        //加工
        WO_FabricProcess = 1300,
        WO_FabricProcessDts = 1301,
        WO_PrintingProcess = 1302,
        WO_PrintingProcessDts = 1303,

        WO_WeaveProcess = 1304,
        WO_WeaveProcessDts = 1305,
        WO_WeaveProcessDts2 = 1306,
        WO_ProduceSchedule = 1307,
        WO_OrderZPSchedule = 1308,

        WO_YarnProcess = 1309,
        WO_YarnProcessDts = 1310,
        WO_ShopOutPutRegister = 1311,

        WO_FabricFHProcess = 1312,
        WO_FabricFHProcessDts = 1313,
        WO_ItemCodeProduceQty = 1314,
        WO_Repair = 1315,
        WO_RepairDts = 1316,
        WO_UpdateFabricProcess=1317,
        WO_UpdateFabricProcessDts=1318,


        //出入口
        Ship_ShipBoat = 1510,
        Ship_ShipBoatDts = 1511,
        Ship_Custom = 1512,
        Ship_CustomDts = 1513,
        Ship_CustomInvoiceDts = 1514,
        Ship_CustomPackDts = 1515,
        Ship_Export = 1516,
        Ship_ExportDts = 1517,
        Ship_ExportInvoiceDts = 1518,
        Ship_ExportPackDts = 1519,


        /// <summary>
        /// 展会
        /// </summary>
        ADH_CheckForm = 1401,


        //其他无用
        Process_ProcessInstructions = 1401,
        Process_ProcessQCTracking = 1402,

        Purchase_FabricPurchase = 1403,
        Purchase_FabricPurchaseDts = 1404,
        Process_RealityYSInventory = 1405,
        Process_RealityYSInventoryDts = 1406,
        Process_SZYCostOrder = 1407,
        Process_SZYCostOrderDts = 1408,
        Process_SZYExecuteSituation = 1409,
        Process_WeavingDesign = 1410,
        Process_WeavingDesignDts = 1411,




        CaiWu_CostRecord = 1501,

        WO_FabricCheck = 1502,

        WO_CYDDCJRpt = 1550,
        WO_ZJCSRpt = 1555,



        WO_DataCBFee=1556,
        Data_EXRate=1557,
        Data_ReqRpt=1558,
        Data_ReqRptDts=1559,
        Data_TotalAmountQty=1600,
        WO_CPCJWHAmount=1601,
        Data_ZJLReqRpt=1602,
        Chk_CheckOrder = 1603,
        Chk_CheckOrderDts = 1604,

        Chk_CheckOrderISN = 1605,
        Chk_CheckOrderISNFault = 1606,
    }
}