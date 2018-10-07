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
    /// Ŀ�ģ�WO_BProductCheckʵ��ҵ�������
    /// ����:��С��
    /// ��������:2013/3/21
    /// </summary>
    public class BProductCheckRule
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public BProductCheckRule()
        {
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
        /// ��ʾ����
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
        /// ��ʾ����
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

        

        #region  ���鹴ѡ�Զ����
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
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
        /// ����(����������)
        /// </summary>
        /// <param name="p_BE">Ҫ������ʵ��</param>
        /// <param name="sqlTrans">������</param>
        public void RSubmitInWH(List<BProductCheckDts> p_BE, string WHID, string SectionID, IDBTransAccess sqlTrans)
        {
            try
            {
                string CheckItem = GetListID(p_BE);
                //1�����Ƿ����
                string sql = "SELECT StatusID,ID FROM WO_BProductCheckDts WHERE StatusID>" + (int)EnumBoxStatus.δ��� + " AND ID IN (" + CheckItem + ")";
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    BProductCheckDts entity = new BProductCheckDts(sqlTrans);
                    entity.ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    entity.SelectByID();
                    throw new Exception("����" + entity.DISN + " �Ѿ��������");
                }

                //2У��ͨ������ʼ������ⵥ��
                sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,ColorNum,ColorName,JarNum,MF,KZ,ShopID,VendorID,SUM(Qty) Qty,SUM(YQty) Weight,DLever,CompactNo,SaleOPID,JSUnit FROM UV1_WO_BProductCheckDts WHERE DID IN(" + CheckItem + ")";
                sql += " GROUP BY ItemCode,ItemName,ItemStd,ItemModel,ColorNum,ColorName,JarNum,MF,KZ,ShopID,VendorID,DLever,CompactNo,SaleOPID,JSUnit";
                dt = sqlTrans.Fill(sql);

                sql = "SELECT DISTINCT ShopID FROM UV1_WO_BProductCheckDts WHERE DID IN(" + CheckItem + ")";
                DataTable dtshop = sqlTrans.Fill(sql);//���ι�ѡ�����Ǽ���Ⱦ��������


                sql = "SELECT * FROM UV1_WO_BProductCheckDts WHERE DID IN(" + CheckItem + ")";

                DataTable dtall = sqlTrans.Fill(sql);

                foreach (DataRow drshop in dtshop.Rows)//һ��Ⱦ��һ����ⵥ
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
                    IOentity.Remark = "��������";

                    DataRow[] Shopinwh = dt.Select("ShopID=" + SysString.ToDBString(drshop["ShopID"].ToString()));//һ��Ⱦ������׺Ż�Ʒ��
                    IOFormDts[] entitydts = new IOFormDts[Shopinwh.Length];
                    ArrayList List = new ArrayList();
                    int i = 0;
                    foreach (DataRow drinwh in Shopinwh)//һ��Ⱦ������׺Ż�Ʒ��
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
                        entitydts[i].Remark = "�������Ʒ��";
                        entitydts[i].Unit = drinwh["JSUnit"].ToString();
                        entitydts[i].PackFlag = 1;//ϸ���־
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

                            entity.Remark = "�������Ʒ��";
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




                    rule2.RSubmit(IOentity.ID, (int)ConfirmFlag.���ύ, sqlTrans);
                }

                //3��������״̬���ⲽ������������ύ��ʱ����
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
