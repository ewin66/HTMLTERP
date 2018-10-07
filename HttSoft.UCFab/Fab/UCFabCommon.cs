using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using HttSoft.Framework;
using System.Drawing;

namespace HttSoft.UCFab
{

    #region �����¼�����

    /// <summary>
    /// д�����  �۽�Index �ı��¼�
    /// </summary>
    /// <param name="sender">����</param>
    /// <param name="rowIndex">��ֵ</param>
    public delegate void UCFabRowIndexChanged(object sender, int rowIndex);// ����ί�д������



    /// <summary>
    /// ѡ��ؼ� ȡ��ƥί���¼�����
    /// </summary>
    public delegate void UCFabSelectCancel(string p_ISN);// ����ί�д������




    /// <summary>
    /// ���ؿؼ� ѡ��ı�ί���¼�����
    /// </summary>
    /// <param name="sender">�ؼ�</param>
    public delegate void UCFabLTileCheckChanged(object sender);// ����ί�д������ ,bool p_ShiftKeyFlag/// <param name="p_ShiftKeyFlag">Shift����</param>

    #endregion


    /// <summary>
    /// ���ݿ������
    /// </summary>
    public class UCFabParamSet
    {
        /// <summary>
        /// �����뵥UI������
        /// </summary>
        static DataTable m_FabUIParamSetDt;
        /// <summary>
        /// �����뵥UI������
        /// </summary>
        public static DataTable FabUIParamSetDt
        {

            set
            {
                m_FabUIParamSetDt = value;
            }
            get
            {
                if (m_FabUIParamSetDt == null)
                {
                    string sql = string.Empty;
                    sql = "SELECT * FROM Sys_ParamSet WHERE ID BETWEEN 6001 AND  6050";//�����뵥�����ؼ���Χ
                    m_FabUIParamSetDt = SysUtils.Fill(sql);
                }
                return m_FabUIParamSetDt;
            }
        }


        /// <summary>
        /// �����������ֵID
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns>����ֵ</returns>
        public static int GetIntValueByID(int p_ID)
        {
            int outI = 0;
            DataRow[] drA = FabUIParamSetDt.Select("ID=" + p_ID.ToString());
            if (drA.Length == 1)
            {
                outI = SysConvert.ToInt32(drA[0]["SetValueInt"]);
            }

            return outI;
        }



    }


    /// <summary>
    /// �뵥����ת����
    /// </summary>
    public class UCFabDataConvert
    {


        /// <summary>
        /// �ֿ��뵥ת��
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        /// <param name="p_ColCount">�뵥����</param>
        /// <returns>ת���������Դ</returns>
        public static DataTable WHFabConvert(int p_FormID, int p_ColCount)
        {
            DataTable outdt = FabConvertDtStructure(p_ColCount);
            string sql = string.Empty;
            sql = "SELECT Seq  FROM WH_IOFormDts WHERE MainID=" + p_FormID + " ORDER BY Seq ";
            DataTable dtSeq = SysUtils.Fill(sql);
            for (int i = 0; i < dtSeq.Rows.Count; i++)
            {
                sql = "SELECT SubSeq,Qty FROM WH_IOFormDtsPack WHERE  MainID=" + p_FormID + " AND Seq=" + SysConvert.ToInt32(dtSeq.Rows[i]["Seq"]) + " ORDER BY SubSeq";
                DataTable dtPack = SysUtils.Fill(sql);
                DataTable dtConvert = FabConvertDtsData(SysConvert.ToInt32(dtSeq.Rows[i]["Seq"]), dtPack, p_ColCount);

                FabConvertInResult(outdt, dtPack, dtConvert);
            }


            return outdt;
        }

        /// <summary>
        /// �����뵥ת��
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        /// <param name="p_ColCount">�뵥����</param>
        /// <returns></returns>
        public static DataTable FHFabConvert(int p_FormID, int p_ColCount)
        {
            DataTable outdt = FabConvertDtStructure(p_ColCount);
            string sql = string.Empty;
            sql = "SELECT Seq  FROM Sale_FHFormDts WHERE MainID=" + p_FormID + " ORDER BY Seq ";
            DataTable dtSeq = SysUtils.Fill(sql);
            for (int i = 0; i < dtSeq.Rows.Count; i++)
            {
                sql = "SELECT SubSeq,Qty FROM Sale_FHFormDtsPack WHERE  MainID=" + p_FormID + " AND Seq=" + SysConvert.ToInt32(dtSeq.Rows[i]["Seq"]) + " ORDER BY SubSeq";
                DataTable dtPack = SysUtils.Fill(sql);
                DataTable dtConvert = FabConvertDtsData(SysConvert.ToInt32(dtSeq.Rows[i]["Seq"]), dtPack, p_ColCount);

                FabConvertInResult(outdt, dtPack, dtConvert);
            }


            return outdt;
        }


        /// <summary>
        /// ��ʽ�����ܱ���
        /// �ܱ����ÿ��ֵ�������һ������
        /// </summary>
        /// <param name="dtResult">�����</param>
        /// <param name="dtPack">�뵥��ϸ��</param>
        /// <param name="dtConvert">ת������뵥��ά��</param>
        static void FabConvertInResult(DataTable dtResult, DataTable dtPack, DataTable dtConvert)
        {
            foreach (DataRow drConvert in dtConvert.Rows)//���и�������
            {
                DataRow drResult = dtResult.NewRow();
                for (int i = 0; i < dtResult.Columns.Count; i++)
                {
                    drResult[i] = drConvert[i];
                }
                dtResult.Rows.Add(drResult);
            }

            ////���һ����ϸ������
            //DataRow drResultTotal = dtResult.NewRow();
            //drResultTotal[1] = "С��";
            //drResultTotal[2] = "����";
            //drResultTotal[3] = dtPack.Rows.Count.ToString();
            //drResultTotal[4] = "����";
            //drResultTotal[5] = SysConvert.ToDecimal(dtPack.Compute("SUM(Qty)", ""));

            //dtResult.Rows.Add(drResultTotal);
        }

        /// <summary>
        /// �����뵥ת����ά
        /// </summary>
        /// <returns>��0��Ϊ��ϸ��Seq,��һ��Ϊ���⣻ÿ������ռ���У���һ��ƥ�ţ��ڶ�������</returns>
        static DataTable FabConvertDtsData(int Seq, DataTable dtSource, int p_ColCount)
        {
            DataTable outdt = FabConvertDtStructure(p_ColCount);

            //�������ϣ���ʼת������
            int rowIndex = 0;//ת�����к�
            int colIndex = 0;//ת�����к�

            int rowFabNum = 0;//ÿ�о���
            decimal rowFabTotalQty = 0;//ÿ�л�����
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                rowIndex = i / p_ColCount;
                colIndex = i % p_ColCount;

                if (colIndex == 0)//��һ�У����������
                {
                    DataRow dr = outdt.NewRow();
                    dr["Seq"] = Seq;
                    dr["ColTitle"] = "ƥ��";
                    outdt.Rows.Add(dr);


                    DataRow dr2 = outdt.NewRow();
                    dr2["ColTitle"] = "����";
                    dr2["Seq"] = Seq;
                    outdt.Rows.Add(dr2);

                    rowFabNum = 1;
                    rowFabTotalQty = SysConvert.ToDecimal(dtSource.Rows[i]["Qty"]);
                }
                else
                {
                    rowFabNum++;
                    rowFabTotalQty += SysConvert.ToDecimal(dtSource.Rows[i]["Qty"]);
                }

                //��ʼ��ֵ
                outdt.Rows[rowIndex * 2]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["SubSeq"].ToString();//ƥ��
                outdt.Rows[rowIndex * 2 + 1]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Qty"].ToString();//����


                outdt.Rows[rowIndex * 2]["RowFabNum"] = rowFabNum;//ÿ�о���
                outdt.Rows[rowIndex * 2]["RowTotalQty"] = rowFabTotalQty;//ÿ�л�����
            }
            return outdt;
        }

        /// <summary>
        /// ����ת�����ձ�ṹ
        /// </summary>
        /// <param name="p_ColCount">�뵥����</param>
        /// <returns></returns>
        static DataTable FabConvertDtStructure(int p_ColCount)
        {
            DataTable outdt = new DataTable();
            outdt.Columns.Add(new DataColumn("Seq", typeof(int)));
            outdt.Columns.Add(new DataColumn("ColTitle", typeof(string)));
            for (int i = 1; i <= p_ColCount; i++)
            {
                outdt.Columns.Add(new DataColumn("ColVal" + i, typeof(string)));//���һ��
            }
            outdt.Columns.Add(new DataColumn("RowFabNum", typeof(int)));//ÿ�о���
            outdt.Columns.Add(new DataColumn("RowTotalQty", typeof(decimal)));//ÿ�л�����
            return outdt;
        }
    }

    /// <summary>
    /// ������
    /// </summary>
    class UCFabCommon
    {



        #region ��GridView�к�
        /// <summary>
        /// ��GridView�к�
        /// </summary>
        /// <param name="p_Grid"></param>
        public static void GridViewRowIndexBind(GridView p_Grid)
        {
            p_Grid.IndicatorWidth = 40;
            p_Grid.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView_CustomDrawRowIndicator);
        }
        /// <summary>
        /// ����һ�������
        /// </summary>
        private static void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                if (e.Info.IsRowIndicator)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// �Ƴ�¼���뵥����Դ�еĿ���;�Ӻ���ǰ
        /// ������ֵ�����Զ�����
        /// </summary>
        /// <param name="p_Dt"></param>
        public static void RemoveInputBankRow(DataTable p_Dt)
        {
            for (int i = p_Dt.Rows.Count - 1; i >= 0; i--)
            {
                if (p_Dt.Rows[i]["BoxNo"].ToString() == string.Empty
                    && SysConvert.ToDecimal(p_Dt.Rows[i]["Qty"]) == 0 && SysConvert.ToDecimal(p_Dt.Rows[i]["Weight"]) == 0
                    && SysConvert.ToString(p_Dt.Rows[i]["SubSeq"]) == string.Empty)//û��ֵ
                {
                    p_Dt.Rows.Remove(p_Dt.Rows[i]);
                }
                else//�ҵ���ֵ������������ѭ��
                {
                    break;
                }
            }
        }
        #endregion

        #region ͨ�÷���
        /// <summary>
        /// ����DataTable��ָ��������
        /// </summary>��
        /// <param name="p_Dt">����</param>
        /// <param name="RowCount">����</param>
        public static void AddDtRow(DataTable p_Dt, int RowCount)
        {
            for (int i = p_Dt.Rows.Count; i < RowCount; i++)
            {
                p_Dt.Rows.Add(p_Dt.NewRow());
            }
        }

        /// <summary>
        /// ɾ��һ������Դ
        /// </summary>
        public static void DelDtRow(DataTable p_Dt, int RowID)
        {
            if (RowID > -1)
            {
                p_Dt.Rows.RemoveAt(RowID);
            }
        }
        #endregion

        #region ��ɫת��
        /// <summary>
        /// �����ַ���ת��Ϊ��ɫ
        /// </summary>
        /// <param name="p_Str"></param>
        /// <returns></returns>
        public static Color ConvertColorByStr(string p_Str)
        {
            Color outc = Color.White;
            string[] tempstr = p_Str.ToString().Split(',');
            if (tempstr.Length == 3)//����Ϊ3
            {
                outc = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
            }
            else
            {
                outc = Color.White;
            }
            return outc;
        }
        #endregion
    }
}
