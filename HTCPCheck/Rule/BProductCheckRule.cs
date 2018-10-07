using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;
using System.Collections.Generic;
using HttSoft.FrameFunc;



namespace HttSoft.HTCPCheck.DataCtl
{
    /// <summary>
    /// 目的：WO_BProductCheck实体业务规则类
    /// 作者:朱小涛
    /// 创建日期:2013/3/21
    /// </summary>
    public class BProductCheckRule
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BProductCheckRule()
        {
        }

         
        /// <summary>
        /// 显示数据
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
        /// 显示数据
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
                string sql = "SELECT " + p_FieldName + " FROM WO_BProductCheck WHERE 1=1";
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
        /// 显示数据
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShowDts(string p_condition)
        {
            try
            {
                return RShowDts(p_condition, "*");
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
        /// 显示数据
        /// </summary>
        /// <param name="p_condition"></param>
        public DataTable RShowDts(string p_condition, string p_FieldName)
        {
            try
            {
                if (p_FieldName == string.Empty)
                {
                    p_FieldName = "*";
                }
                string sql = "SELECT " + p_FieldName + " FROM UV1_WO_BProductCheckDts WHERE 1=1";
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

        

        #region  检验勾选自动入库
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        public void RSubmitInWH(List<BProductCheckDts> p_BE, string WHID, string SectionID)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.RSubmitInWH(p_BE, WHID, SectionID, sqlTrans);

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
        /// 新增(传入事务处理)
        /// </summary>
        /// <param name="p_BE">要新增的实体</param>
        /// <param name="sqlTrans">事务类</param>
        public void RSubmitInWH(List<BProductCheckDts> p_BE, string WHID, string SectionID, IDBTransAccess sqlTrans)
        {
            try
            {
                string CheckItem = GetListID(p_BE);
                //1检验是否入库
                string sql = "SELECT StatusID,ID FROM WO_BProductCheckDts WHERE StatusID>" + (int)EnumBoxStatus.未入库 + " AND ID IN (" + CheckItem + ")";
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    BProductCheckDts entity = new BProductCheckDts(sqlTrans);
                    entity.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    entity.SelectByID();
                    throw new Exception("条码" + entity.DISN + " 已经入库请检查");
                }

                //2校验通过，开始创建入库单。
                sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,ColorNum,ColorName,JarNum,MF,KZ,ShopID,VendorID,SUM(Qty) Qty,SUM(YQty) Weight,DLever,CompactNo,SaleOPID,JSUnit FROM UV1_WO_BProductCheckDts WHERE DID IN(" + CheckItem + ")";
                sql += " GROUP BY ItemCode,ItemName,ItemStd,ItemModel,ColorNum,ColorName,JarNum,MF,KZ,ShopID,VendorID,DLever,CompactNo,SaleOPID,JSUnit";
                dt = sqlTrans.Fill(sql);

                sql = "SELECT DISTINCT ShopID FROM UV1_WO_BProductCheckDts WHERE DID IN(" + CheckItem + ")";
                DataTable dtshop = sqlTrans.Fill(sql);//本次勾选的是那几家染厂的数据


                sql = "SELECT * FROM UV1_WO_BProductCheckDts WHERE DID IN(" + CheckItem + ")";

                DataTable dtall = sqlTrans.Fill(sql);

                foreach (DataRow drshop in dtshop.Rows)//一家染厂一个入库单
                {

                    IOForm IOentity = new IOForm(sqlTrans);

                    IOentity.FormDate = DateTime.Now.Date;

                    IOentity.WHID = WHID;
                    IOentity.WHType = WHID;
                    IOentity.HeadType = 11;
                    IOentity.SubType = 1107;
                  
                    IOentity.VendorID = drshop["ShopID"].ToString();

                    FormNoControlRule ruleno = new FormNoControlRule();
                    IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.HeadType, IOentity.SubType, IOentity.WHID, sqlTrans);
                    IOentity.Remark = "检验后入库";

                    DataRow[] Shopinwh = dt.Select("ShopID=" + SysString.ToDBString(drshop["ShopID"].ToString()));//一家染厂多个缸号或品种
                    IOFormDts[] entitydts = new IOFormDts[Shopinwh.Length];
                    ArrayList List = new ArrayList();
                    int i = 0;
                    foreach (DataRow drinwh in Shopinwh)//一家染厂多个缸号或品种
                    {

                        entitydts[i] = new IOFormDts(sqlTrans);
                        entitydts[i].Seq = i + 1;
                        entitydts[i].WHID = IOentity.WHID;
                        entitydts[i].SectionID = SectionID;
                        entitydts[i].SBitID = "";

                        entitydts[i].ItemCode = drinwh["ItemCode"].ToString();
                        //entitydts[i].CPItemCode = entitydts[i].ItemCode;
                        entitydts[i].ItemName = drinwh["ItemName"].ToString();
                        entitydts[i].ItemModel = drinwh["ItemName"].ToString();
                        entitydts[i].ItemStd = drinwh["ItemStd"].ToString();
                        entitydts[i].ItemModel = drinwh["ItemModel"].ToString();
                        entitydts[i].ColorNum = drinwh["ColorNum"].ToString();
                        entitydts[i].ColorName = drinwh["ColorName"].ToString();
                        entitydts[i].JarNum = drinwh["JarNum"].ToString();

                        entitydts[i].MWeight =SysConvert.ToDecimal( drinwh["KZ"]);
                        entitydts[i].MWidth = SysConvert.ToDecimal(drinwh["MF"]);

                        entitydts[i].DtsSO = drinwh["CompactNo"].ToString();
                        entitydts[i].DtsOrderFormNo = drinwh["CompactNo"].ToString();
                        //entitydts[i].DtsOrderFormNo = drinwh["SO"].ToString();
                        //entitydts[i].InSO = drinwh["SO"].ToString();
                        entitydts[i].InSaleOPID = drinwh["SaleOPID"].ToString();
                        entitydts[i].DtsVendorID = drinwh["VendorID"].ToString();
                        entitydts[i].GoodsLevel = drinwh["DLever"].ToString();
                        entitydts[i].Qty = SysConvert.ToDecimal(drinwh["Qty"]);
                        entitydts[i].Weight = SysConvert.ToDecimal(drinwh["Weight"]);
                        entitydts[i].Remark = "检验入成品库";
                        entitydts[i].Unit = drinwh["JSUnit"].ToString();
                        entitydts[i].PackFlag = 1;//细码标志
                        // ItemCode,ItemName,ItemStd,ColorNum,ColorName,JarNum,ShopID,VendorID,SUM(Qty) Qty,SUM(YQty) Weight,DLever,CompactNo,SO,SaleOPID
                        // ,,,,,,,,SUM(Qty) Qty,SUM(YQty) Weight,,,,

                        DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(drinwh["ItemCode"].ToString()) 
                            + " AND ISNULL(ItemName,'')=" + SysString.ToDBString(drinwh["ItemName"].ToString()) 
                            + " AND ISNULL(ItemStd,'')=" + SysString.ToDBString(drinwh["ItemStd"].ToString())
                                                   + " AND ISNULL(ItemModel,'')=" + SysString.ToDBString(drinwh["ItemModel"].ToString()) 
                            + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(drinwh["ColorName"].ToString()) 
                            + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(drinwh["ColorNum"].ToString()) 
                            + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(drinwh["JarNum"].ToString())
                                  //+ " AND ISNULL(MF,'')=" + SysString.ToDBString(drinwh["MF"].ToString())
                                  //      + " AND ISNULL(KZ,'')=" + SysString.ToDBString(drinwh["KZ"].ToString())
                            + " AND ISNULL(ShopID,'')=" + SysString.ToDBString(dt.Rows[i]["ShopID"].ToString()) 
                            + " AND ISNULL(VendorID,'')=" + SysString.ToDBString(dt.Rows[i]["VendorID"].ToString())
                            + " AND ISNULL(DLever,'')=" + SysString.ToDBString(dt.Rows[i]["DLever"].ToString())
                            + " AND ISNULL(CompactNo,'')=" + SysString.ToDBString(dt.Rows[i]["CompactNo"].ToString())  
                            + " AND ISNULL(SaleOPID,'')=" + SysString.ToDBString(dt.Rows[i]["SaleOPID"].ToString()));
                        entitydts[i].PieceQty = ISN.Length;

                        int m = 0;
                        foreach (DataRow dr in ISN)
                        {
                            IOFormDtsPack entity = new IOFormDtsPack(sqlTrans);
                            entity.Seq = i + 1;
                            entity.SubSeq = m + 1;
                            entity.BoxNo = dr["DISN"].ToString();

                            entity.Qty = SysConvert.ToDecimal(dr["Qty"]);

                            entity.Remark = "检验入成品库";
                            List.Add(entity);

                            m++;
                        }
                        i++;
                    }

                    decimal TotalQty = 0;
                    for (int j = 0; j < entitydts.Length; j++)
                    {
                        TotalQty += entitydts[j].Qty;
                    }

                    IOentity.TotalQty = TotalQty;



                    IOFormRule rule2 = new IOFormRule();
                    rule2.RAdd(IOentity, entitydts, List, sqlTrans);




                    rule2.RSubmit(IOentity.ID, (int)ConfirmFlag.已提交, sqlTrans);
                }

                //3更新条码状态（这步动作是在入库提交的时候处理）
                sql = "Update WO_BProductCheckDts Set InWHFlag=1 WHERE ID IN(" + CheckItem + ")";
                sqlTrans.ExecuteNonQuery(sql);


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

        private string GetListID(List<BProductCheckDts> p_entity)
        {
            string str = "";
            foreach (BProductCheckDts entity in p_entity)
            {
                if (str == string.Empty)
                {
                    str += entity.ID;
                }
                else
                {
                    str += "," + entity.ID;
                }
            }
            return str;
        }
        #endregion

    }
}
