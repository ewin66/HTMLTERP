using System;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.Data;
using HttSoft.MLTERP.DataCtl;
using System.Windows.Forms;
using System.Drawing;
using HttSoft.MLTERP.Sys;


namespace MLTERP
{

    

    /// <summary>
    /// ��Ʒ������
    /// �¼Ӻ�
    /// 2014.4.17
    /// </summary>
    public class ProductCommon
    {

        #region  FormNo ���Ž������
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
            FormNoIniSet( p_Txt,  p_CLSA,  p_CLSB,0);
        }
        /// <summary>
        /// ���õ���ֵ
        /// </summary>
        /// <param name="p_Txt"></param>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        /// <param name="p_SubTypeID"></param>
        public static void FormNoIniSet(TextEdit p_Txt,string p_CLSA,string p_CLSB,int p_SubTypeID)
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


        #region JG�ӹ����Ͽ������

        /// <summary>
        /// ��ʼ�����ϰ�ť�Ƿ�ɼ�
        /// </summary>
        /// <param name="btnKL">���ϰ�ť</param>
        /// <param name="p_SaleProcedureID">�ӹ�������</param>
        public static void JGButtonIni(DevExpress.XtraEditors.SimpleButton btnKL,int p_SaleProcedureID)
        {
            btnKL.Visible = false;
            string sql = string.Empty;
            sql = "SELECT JGUseFlag FROM Enum_SaleProcedure WHERE ID=" + p_SaleProcedureID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (SysConvert.ToBoolean(SysConvert.ToInt32((dt.Rows[0]["JGUseFlag"]))))
                {
                    btnKL.Visible = true;
                }
            }
        }

        /// <summary>
        /// ���ϰ�ť״̬����
        /// </summary>
        /// <param name="p_FrmStatus">����״̬</param>
        /// <param name="p_SubmitFlag">�ύ״̬</param>
        /// <param name="p_DataID">����ID</param>
        /// <param name="btnKL">���ϰ�ť</param>
        public static void JGButtonStatusSet(FormStatus p_FrmStatus, int p_SubmitFlag, int p_DataID, DevExpress.XtraEditors.SimpleButton btnKL)
        {
            if (btnKL.Visible)//�ɼ��ٴ���
            {
                //if (p_FrmStatus == FormStatus.��ѯ && p_SubmitFlag == 1)//�ύ��ѯ״̬�ſ��Բ�������
                //{
                //    btnKL.Enabled = true;
                //}
                //else
                //{
                //    btnKL.Enabled = false;
                //}

                string sql = string.Empty;//Ѱ���Ƿ����п�������
                sql = "SELECT ID,SubmitFlag,FormNo FROM WO_FabricWHOutForm WHERE MainID=" + p_DataID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    if (SysConvert.ToBoolean(SysConvert.ToInt32(dt.Rows[0]["SubmitFlag"])))//�������ύ
                    {
                        btnKL.Appearance.BackColor = Color.FromArgb(255, 255, 192);
                        btnKL.Appearance.BackColor2 = Color.Yellow;

                    }
                    else//���ϵ����ɵ�δ�ύ
                    {
                        btnKL.Appearance.BackColor = Color.FromArgb(255, 255, 192);
                        btnKL.Appearance.BackColor2 = Color.White;
                    }
                }
                else//δ���ɿ��ϵ�
                {
                    btnKL.Appearance.BackColor = Color.White;
                    btnKL.Appearance.BackColor2 = Color.White;
                }
            }
        }

        /// <summary>
        /// �򿪿��ϴ���
        /// </summary>
        /// <param name="p_SaleProcedureID"></param>
        public static void JGOpenKLForm(int p_SaleProcedureID,int p_HTDataID,string p_HTFormNo)
        {
            string sql = string.Empty;
            sql = "SELECT JGUseFlag,JGItemTypeID,JGWHIDDefault,JGFormListID FROM Enum_SaleProcedure WHERE ID=" + p_SaleProcedureID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (SysConvert.ToBoolean(SysConvert.ToInt32((dt.Rows[0]["JGUseFlag"]))))//����
                {
                    switch (SysConvert.ToInt32(dt.Rows[0]["JGItemTypeID"]))
                    {
                        case (int)EnumItemType.ɴ��:
                            frmBuckleMaterial frm = new frmBuckleMaterial();
                            frm.PackFlag = false;//����Ҫ�뵥
                            frm.FormNo = p_HTFormNo;//����
                            frm.WHItemTypeID = SysConvert.ToInt32(dt.Rows[0]["JGItemTypeID"]);//��������
                            frm.WHFormListAID = Common.GetFormListIDBySubTypeID(SysConvert.ToInt32(dt.Rows[0]["JGFormListID"]));//������
                            frm.WHFormListBID = SysConvert.ToInt32(dt.Rows[0]["JGFormListID"]);//������
                            frm.MainID = p_HTDataID;
                            frm.WHID = SysConvert.ToString(dt.Rows[0]["JGWHIDDefault"]);//���Ͽ��
                            frm.ShowDialog();
                            break;
                        case (int)EnumItemType.����:
                            frmFabricBuckleMaterial frmFabric = new frmFabricBuckleMaterial();
                            frmFabric.PackFlag = true;//��Ҫ�뵥
                            frmFabric.WHItemTypeID = SysConvert.ToInt32(dt.Rows[0]["JGItemTypeID"]);//��������
                            frmFabric.FormNo = p_HTFormNo;//����
                            frmFabric.WHFormListAID = Common.GetFormListIDBySubTypeID(SysConvert.ToInt32(dt.Rows[0]["JGFormListID"]));//������
                            frmFabric.WHFormListBID = SysConvert.ToInt32(dt.Rows[0]["JGFormListID"]);//������
                            frmFabric.MainID = p_HTDataID;
                            frmFabric.WHID = SysConvert.ToString(dt.Rows[0]["JGWHIDDefault"]);//���Ͽ��
                            frmFabric.ShowDialog();
                            break;
                        case (int)EnumItemType.����:
                            goto case (int)EnumItemType.����;
                    }
                }
            }
           
        }
        #endregion


        #region  UnitConvert ��λģʽ�������
        /// <summary>
        /// ����Ϊ������λ���������ػ�����λ
        /// (����¼��ʹ��)
        /// </summary>
        /// <param name="p_SourceUnit"></param>
        /// <param name="p_Qty"></param>
        /// <param name="o_BaseUnit"></param>
        /// <returns></returns>
        public static decimal UnitConvertValueBaseUnit(string p_SourceUnit,decimal p_Qty,out string o_BaseUnit)
        {
            decimal outdec = p_Qty;
            o_BaseUnit = p_SourceUnit;
            if (p_SourceUnit != string.Empty)
            {
                string sql = string.Empty;
                sql = "SELECT * FROM Enum_Unit WHERE Name=" + SysString.ToDBString(p_SourceUnit);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    if (SysConvert.ToString(dt.Rows[0]["BaseUnit"]) != string.Empty)//������λ
                    {
                        o_BaseUnit = SysConvert.ToString(dt.Rows[0]["BaseUnit"]);
                        string fomula = SysConvert.ToString(dt.Rows[0]["Formula"]);//����Ϊ������λ�Ĺ�ʽ
                        if (fomula != string.Empty)//��ʽ��Ϊ�գ���ʼ����
                        {
                            outdec = SysConvert.ToDecimal(SysConvert.ToExpressions(p_Qty.ToString() + fomula), 2);
                        }
                    }
                    else//û�л�����λ�����û���
                    {
                        //��ִ�в���
                    }
                }
                else
                {
                    throw new Exception("��λ�ڻ�������--������λ���㹫ʽ�����в����ڣ����ܲ���");
                }
            }
            else
            {
                throw new Exception("û��ѡ��λ�����ܲ���");
            }

            return outdec;
        }

        /// <summary>
        /// ��ת��Ϊ�����㷨
        /// ��һ���㷨 �����ף�
        /// </summary>
        /// <param name="p_Qty">����</param>
        /// <param name="p_MWidth">�ŷ�</param>
        /// <param name="p_MWeight">����</param>
        /// <returns>������</returns>
        public static decimal UnitConvertMiToKG1ST(decimal p_Qty, decimal p_MWidth, decimal p_MWeight)
        {
            /*�㷨˵�� ����*�ŷ�*����/1000/100
            */
            decimal outdec = p_Qty;


            outdec = p_Qty * (p_MWidth / 100m) * (p_MWeight / 1000m);//����*�ŷ�*����
            return outdec;
        }

        /// <summary>
        /// ��ת��Ϊ�����㷨
        /// �ڶ����㷨(�����)
        /// </summary>
        /// <param name="p_Qty">����</param>
        /// <param name="p_MWidth">�ŷ�</param>
        /// <param name="p_MWeight">����</param>
        /// <returns>������</returns>
        public static decimal UnitConvertMiToKG2ND(decimal p_Qty,decimal p_MWidth,decimal p_MWeight)
        {
            /*�㷨˵�� ���µ�����ת��Ϊ��������ʽ˵�����£�      ���ȣ���1000���Կ����ٳ����ŷ��õ�һ������ A     ��ϵ���ٳ���100��
                    �ر�ע�⣬��ϵ������100��������������С��10��
                                            1.ʮ��λΪ0����ֻȡ������      ���ӣ� 0.0502 ����> 5
                                             2.ʮ��λ��Ϊ0�������Ϊ����һλ��Ч����   ���ӣ� 0.0512����> 5.1 ��Ҫ��������
                                ���������ִ��ڵ���10����ֻȡ�������֡�  ���ӣ�0.1025����>10 
             ��������A �õ����
            */
            decimal outdec = p_Qty;

            decimal xsA = 0;//ϵ��
            if (p_MWidth != 0 && p_MWeight != 0)
            {
                xsA = (1000m / (p_MWidth * p_MWeight)) * 100m;
                if (xsA >= 10)
                {
                    xsA = SysConvert.ToDecimal(xsA, 0);//ȡ��
                }
                else//С��10
                {
                    if (xsA.ToString().Length >= 3)//С��������1λ
                    {
                        xsA = SysConvert.ToDecimal(SysConvert.ToDecimal(xsA.ToString().Substring(0,3)), 1);//ȡ1λС��
                    }
                    else
                    {
                        xsA = SysConvert.ToDecimal(xsA, 0);//ȡ��
                    }
                }
            }
            if (xsA != 0)
            {
                outdec = p_Qty / xsA;
            }
            return outdec;
        }


        /// <summary>
        /// ��λ����ϵ���Լ�¼��
        /// ��ʮ���㷨(�꿵��)
        /// </summary>
        /// <param name="p_Qty">����</param>
        /// <param name="p_XS">ϵ��</param>
        /// <returns>ת��������</returns>
        public static decimal UnitConvertMiToUnit10Ten(decimal p_Qty, decimal p_XS)
        {
            /*�㷨˵��
             ��������ϵ�� �õ����
            */
            decimal outdec = p_Qty;

         
            if (p_XS != 0)
            {
                outdec = p_Qty * p_XS;
            }
            return outdec;
        }

        /// <summary>
        /// ������λ��������Ϊ�ǻ�����λ����
        /// (������/���ⵥʹ��)
        /// </summary>
        /// <param name="p_BaseUnit">������λ</param>
        /// <param name="p_BaseQty">��������</param>
        /// <param name="p_InputUnit">¼�뵥λ</param>
        /// <param name="p_InputConvertXS">¼��ת��ϵ��</param>
        /// <returns></returns>
        public static decimal UnitConvertValueAnyUnit(string p_BaseUnit, decimal p_BaseQty, string p_InputUnit,decimal p_InputConvertXS)
        {
            decimal outdec = p_BaseQty;
            if (p_BaseUnit != string.Empty || p_InputUnit!=string.Empty)
            {
                if (p_InputConvertXS != 0)
                {
                    outdec = SysConvert.ToDecimal(p_BaseQty / p_InputConvertXS, 2);
                }
                //string sql = string.Empty;
                //sql = "SELECT * FROM Enum_Unit WHERE Name=" + SysString.ToDBString(p_SourceUnit);
                //DataTable dt = SysUtils.Fill(sql);
                //if (dt.Rows.Count != 0)
                //{
                //    if (SysConvert.ToString(dt.Rows[0]["BaseUnit"]) != string.Empty)//������λ
                //    {
                //        o_BaseUnit = SysConvert.ToString(dt.Rows[0]["BaseUnit"]);
                //        string fomula = SysConvert.ToString(dt.Rows[0]["Formula"]);//����Ϊ������λ�Ĺ�ʽ
                //        if (fomula != string.Empty)//��ʽ��Ϊ�գ���ʼ����
                //        {
                //            outdec = SysConvert.ToDecimal(SysConvert.ToExpressions(p_Qty.ToString() + fomula), 2);
                //        }
                //    }
                //    else//û�л�����λ�����û���
                //    {
                //        //��ִ�в���
                //    }
                //}
                //else
                //{
                //    throw new Exception("��λ�ڻ�������--������λ���㹫ʽ�����в����ڣ����ܲ���");
                //}
            }
            else
            {
                throw new Exception("û��ѡ��λ�����ܲ���");
            }

            return outdec;
        }
        #endregion


        #region ItemControl ��Ʒ�������
        /// <summary>
        /// ������Ʒ��Ż����������
        /// </summary>
        /// <param name="p_ItemCode"></param>
        /// <returns></returns>
        public static int ItemControlGetFabricType(string p_ItemCode)
        {
            int outi = 0;
            string sql = string.Empty;
            sql = "SELECT FabricTypeID FROM Data_Item WHERE ItemCode="+SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outi = SysConvert.ToInt32(dt.Rows[0]["FabricTypeID"]);
            }

            return outi;
        }
        #endregion

    }
}
