using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using HttSoft.Framework;
using HttSoft.MLTERP.Sys;
using HttSoft.FrameFunc;

namespace HttSoft.MLTERP.DataCtl
{
    class WHClearingRule
    {
     
        /// <summary>
        /// 结算一段时间
        /// </summary>
        /// <param name="p_Time1"></param>
        /// <param name="p_Time2"></param>
        public void Clearing(int p_ClearingID,DateTime p_Time1,DateTime p_Time2)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();

                    this.Clearing(p_ClearingID,p_Time1, p_Time2, sqlTrans);

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
        /// 结算一段时间
        /// </summary>
        /// <param name="p_Time1"></param>
        /// <param name="p_Time2"></param>
        public void Clearing(int p_ClearingID, DateTime p_Time1, DateTime p_Time2, IDBTransAccess sqlTrans)
        {
            try
            {
                string CheckInfor = string.Empty;
                if (!CheckDocumentSubmitStatus(p_Time1, p_Time2, out CheckInfor, sqlTrans))//校验本段时间单据
                {
                    throw new Exception("这些单据：" + CheckInfor + " 未提交，请检查");
                }
                CopyStorge(p_ClearingID, sqlTrans);//拷贝库存

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
        /// 校验这段时间的单据是否全部提交
        /// </summary>
        /// <param name="p_Time1"></param>
        /// <param name="p_Time2"></param>
        /// <param name="sqlTrans"></param>
        /// <returns></returns>
        private bool CheckDocumentSubmitStatus(DateTime p_Time1, DateTime p_Time2, out string ReturnInfor, IDBTransAccess sqlTrans)
        {
            try
            {
                ReturnInfor = string.Empty;
                string sql = "SELECT FormNo FROM WH_IOForm WHERE CheckDate BETWEEN" + SysString.ToDBString(p_Time1.ToString("yyyy-MM-dd"));
                sql += " AND "+SysString.ToDBString(p_Time2.ToString("yyyy-MM-dd")+" 23:59:59");
                sql += " AND ISNULL(DelFlag,0)=0";
                sql += " AND ISNULL(ConfirmFlag,0)<>" + (int)ConfirmFlag.已提交;
                DataTable dt = sqlTrans.Fill(sql);
                for (int i = 0; i < dt.Rows.Count;i++)
                {
                    if(i!=0)
                    {
                        ReturnInfor += ",";
                    }
                    ReturnInfor += dt.Rows[i]["FormNo"].ToString();
                }
                if (ReturnInfor!=string.Empty)
                {
                    return false;
                }
                return true;
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
        private void CopyStorge(int p_ClearingID, IDBTransAccess sqlTrans)
        {
            string sql = string.Empty;
            sql += " INSERT INTO WH_StorgeBackup(ID,ClearingID,WHID,SectionID,SBitID,SBitCellID,VendorID,VendorAID,VendorBID,CustomerID,WHTypeID,ItemCode,ItemName,ItemStd,Batch,VendorBatch,Twist,YarnType,Weight,InQty,TubeGW,TubeQty,Qty,LockQty,";
            sql += "FreeQty,LockSO,Needle,SinglePrice,Amount,PieceQty,Unit,ColorNum,ColorName,JarNo,JarNum,SO,LastUpdTime,LastUpdOP,Remark,InDate,DutyOPID,DtsSO,LWHID,CWAmount,CBNo,BoxNo";
            sql += ")";
            sql = " SELECT ID," + p_ClearingID + " ClearingID,";
            sql += "WHID,SectionID,SBitID,SBitCellID,VendorID,VendorAID,VendorBID,CustomerID,WHTypeID,ItemCode,ItemName,ItemStd,Batch,VendorBatch,Twist,YarnType,Weight,InQty,TubeGW,TubeQty,Qty,LockQty,";
            sql += " FreeQty,LockSO,Needle,SinglePrice,Amount,PieceQty,Unit,ColorNum,ColorName,JarNo,JarNum,SO,LastUpdTime,LastUpdOP,Remark,InDate,DutyOPID,DtsSO,LWHID,CWAmount,CBNo,BoxNo FROM WH_Storge WHERE 1=1 ";
            sqlTrans.ExecuteNonQuery(sql);
        }
    }
}
