using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using HttSoft.HTCPCheck.DataCtl;
using System.Collections;
using HttSoft.Framework;
using System.Data;

namespace HTCPCheck
{
    /// <summary>
    /// Ŀ��: ����ͨ�÷���
    /// ����: �¼Ӻ�
    /// ��������: 2014.5.6
    /// </summary>
    public class HTCPCommon
    {
        #region ���Ž������
        /// <summary>
        /// ���ÿؼ��Ƿ�ֻ��
        /// </summary>
        /// <param name="p_Txt"></param>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        /// <param name="p_SubTypeID"></param>
        public static void FormNoCtlEditSet(TextEdit p_Txt, string p_CLSA, string p_CLSB, bool p_Flag)
        {
            FormNoCtlEditSet(p_Txt, p_CLSA, p_CLSB, 0, p_Flag);
        }



        /// <summary>
        /// ���ÿؼ��Ƿ�ֻ��
        /// </summary>
        /// <param name="p_Txt"></param>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        /// <param name="p_SubTypeID"></param>
        public static void FormNoCtlEditSet(TextEdit p_Txt, string p_CLSA, string p_CLSB, int p_SubTypeID, bool p_Flag)
        {

            FNORelRule frule = new FNORelRule();
            if (frule.RGetFormNoControlEditFlag(p_CLSA, p_CLSB, p_SubTypeID))//�ɱ༭
            {
                p_Txt.Properties.ReadOnly = !p_Flag;
            }
            else//���ɱ༭
            {
                p_Txt.Properties.ReadOnly = true;
            }
        }


        /// <summary>
        /// ���õ���ֵ
        /// </summary>
        /// <param name="p_Txt"></param>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        public static void FormNoIniSet(TextEdit p_Txt, string p_CLSA, string p_CLSB)
        {
            FormNoIniSet(p_Txt, p_CLSA, p_CLSB, 0);
        }
        /// <summary>
        /// ���õ���ֵ
        /// </summary>
        /// <param name="p_Txt"></param>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        /// <param name="p_SubTypeID"></param>
        public static void FormNoIniSet(TextEdit p_Txt, string p_CLSA, string p_CLSB, int p_SubTypeID)
        {
            FNORelRule frule = new FNORelRule();
            if (frule.RGetFormNoControlEditFlag(p_CLSA, p_CLSB, p_SubTypeID))//������б༭
            {
            }
            else//��������б༭
            {
                FormNoControlRule rule = new FormNoControlRule();
                string formcode = rule.RGetFormNo(p_CLSA, p_CLSB, p_SubTypeID);
                if (formcode != string.Empty)
                {
                    p_Txt.Text = formcode;
                }
            }
        }
        #endregion



        #region �����ȡͨ����Ϣ����(���Ҫ�ò�Ʒ���������������)

        /// <summary>
        /// ���ݺ�ͬ�Ż�ȡ��ͬ��Ϣ
        /// </summary>
        /// <param name="p_CompactNo">��ͬ��</param>
        /// <returns>����ArrayList 0/1:�ͻ�/����</returns>
        public static ArrayList GetCompactInfoByCompactNo(string p_CompactNo)
        {
            ArrayList al = new ArrayList();
            string sql = string.Empty;
            sql = "SELECT VendorID,ReqDate FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(p_CompactNo);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                al.Add(dt.Rows[0]["VendorID"].ToString());
                al.Add(SysConvert.ToDateTime(dt.Rows[0]["ReqDate"]));
            }

            return al;
        }

        #endregion
    }


    
}
