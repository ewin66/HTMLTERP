using System;
using System.Collections.Generic;
using System.Text;
using HttSoft.Framework;
using System.Data;
using System.Windows.Forms;

namespace MLTERP
{
    public static class CheckBoxISN
    {
        //����У������¼���
        /*
         1�������Ƿ���Ч
         2�������Ƿ����
         3�������Ƿ����
         4�������Ƿ����
         5�������Ƿ��Ѿ����
         6�������Ƿ񱻲��
         7��
         8�� 
         9�� 
         10�� 
         11�� 
        */
        /// <summary>
        /// �����Ƿ���Ч
        /// </summary>
        /// <param name="p_ISN"></param>
        /// <returns></returns>
        public static bool CheckUse(string p_ISN)
        {
            string sql = "SELECT ID,CFFlag FROM WO_Fabric WHERE ISN=" + SysString.ToDBString(p_ISN);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 1)
            {
                MessageBox.Show("��ʾ", "���벻��������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (SysConvert.ToInt32(dt.Rows[0]["CFFlag"]) == 1)
                {
                    MessageBox.Show("��ʾ", "�����Ѿ����������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// �����Ƿ����
        /// </summary>
        /// <param name="p_ISN"></param>
        /// <returns></returns>
        public static bool CheckInWH(string p_ISN)
        {
            string sql = "SELECT ID,CFFlag FROM WO_Fabric WHERE ISN=" + SysString.ToDBString(p_ISN);
            sql += " AND Status=1 AND ISNULL(CFFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("��ʾ", "����δ�������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        /// <summary>
        /// �����Ƿ����
        /// </summary>
        /// <param name="p_ISN"></param>
        /// <returns></returns>
        public static bool CheckOutWH(string p_ISN)
        {
            string sql = "SELECT ID,CFFlag FROM WO_Fabric WHERE ISN=" + SysString.ToDBString(p_ISN);
            sql += " AND Status=2 AND ISNULL(CFFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("��ʾ", "����δ��������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        /// <summary>
        /// �����Ƿ���
        /// </summary>
        /// <param name="p_ISN"></param>
        /// <returns></returns>
        public static bool CheckPackISN(string p_ISN)
        {
            string sql = "SELECT ID,CFFlag FROM WO_Fabric WHERE ISN=" + SysString.ToDBString(p_ISN);
            sql += " AND ISNULL(PackFlag,0)=1";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("��ʾ", "�����Ѿ��������" + p_ISN, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �����Ƿ���
        /// </summary>
        /// <param name="p_ISN"></param>
        /// <returns></returns>
        public static bool CheckISNCF(string p_ISN)
        {
            string sql = "SELECT ID,CFFlag FROM WO_Fabric WHERE ISN=" + SysString.ToDBString(p_ISN);
            sql += " AND ISNULL(CFFlag,0)=1";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
