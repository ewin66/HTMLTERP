using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;
using DevExpress.XtraGrid.Columns;


namespace HttSoft.UCFab
{
    /// <summary>
    /// ���ܣ�¼���뵥 ����ģʽ
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-31
    /// </summary>
    public partial class UCFabIHori : UCFabBaseInputCtl
    {
        public UCFabIHori()
        {
            InitializeComponent();
        }

        #region ��ʱ��̬�����������ƶ���ȫ�ֱ��������������ݿ���
        static Color UCBackColor = Color.FromArgb(255, 255, 255);//Ĭ��ɫϵ 255, 255, 192
        static Color UCBackColor2 = Color.FromArgb(255, 255, 255);//Ĭ��ɫϵ 255, 255, 128
        static Color UCBorderColor = Color.FromArgb(192, 255, 255);//Ĭ��ɫϵ

        static Color UCBackColorS = Color.FromArgb(255, 255, 192);//ż����ɫϵ 192, 255, 192
        static Color UCBackColorS2 = Color.AliceBlue;//ż����ɫϵ 128, 255, 128

        static Color UCSelectColor = Color.FromArgb(255, 192, 255);//ѡ��ɫϵ

        static Color UCTitleColor = Color.FromArgb(224, 224, 224);//Color.Gray;//Color.FromArgb(255, 192, 255);//ѡ��ɫϵ
        #endregion

        #region �ⲿ���÷���


        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public override void UCAct()
        {
            BindGrid();
        }

        /// <summary>
        /// ִ�����¸�ֵ����������¼��ʱ
        /// </summary>
        public override void UCBind()
        {
            BindGrid();
        }

        /// <summary>
        /// ���õ�ǰ�۽��к�
        /// </summary>
        public override void UCSetCurrectIndex()
        {
            int rowIndex = gridView1.FocusedRowHandle / 5;//ƥ�š����������������ϲ�һ��
            if (!UCVolumeNumberShowFlag)//�������ʾ��ţ�������������������������������GridView�к�
            {
                rowIndex = gridView1.FocusedRowHandle / 4;
            }
            int colIndex = 0;
            if (gridView1.FocusedColumn.FieldName == "ColTitle")
            {
                colIndex = 1;
            }
            else if (gridView1.FocusedColumn.FieldName.IndexOf("ColVal") != -1)//ֵ���
            {
                colIndex = SysConvert.ToInt32(gridView1.FocusedColumn.FieldName.Substring(6));
            }

            int dataSourceIndex = UCColumnCount * rowIndex + colIndex - 1;

            UCCurrnetFocusIndex = dataSourceIndex;
        }
        #endregion

        #region �ڲ�����
        /// <summary>
        /// ��Grid
        /// </summary>
        void BindGrid()
        {
            UCFabCommon.AddDtRow(UCDataSource, UCInputCount);
            gridView1.GridControl.DataSource = ConvertDataSource(UCDataSource);
            gridView1.GridControl.Show();
            DataSourceTotalCalcAll();//����С��
            DataSourceTotalInfoSet();
            //lblFabCount.Text = "ƥ��:" + SysConvert.ToString(UCDataSource.Compute("COUNT(Qty)", " ISNULL(Qty,0)<>0")); //UCDataSource.Rows.Count.ToString();
            //lblFabQty.Text = "����:"+SysConvert.ToString(UCDataSource.Compute("SUM(Qty)", ""));
        }


        /// <summary>
        /// ����Դ��С�Ƶļ����������
        /// </summary>
        void DataSourceTotalCalcAll()
        {
            DataTable dtView = (DataTable)gridView1.GridControl.DataSource;
            for (int i = 0; i < dtView.Rows.Count; i++)
            {
                DataSourceTotalCalc(dtView, i);

            }
        }

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        void DataSourceTotalInfoSet()
        {
            lblFabCount.Text = "ƥ��:" + SysConvert.ToString(UCDataSource.Compute("COUNT(SubSeq)", "(ISNULL(Qty,0)<>0 OR ISNULL(Weight,0)<>0 OR ISNULL(Yard,0)<>0)")); //UCDataSource.Rows.Count.ToString();
            lblFabQty.Text = "����:" + SysConvert.ToString(UCDataSource.Compute("SUM(Qty)", ""));
            lblFabWeight.Text = "������:" + SysConvert.ToString(UCDataSource.Compute("SUM(Weight)", ""));
            lblFabYard.Text = "����:" + SysConvert.ToString(UCDataSource.Compute("SUM(Yard)", ""));
        }


        /// <summary>
        /// ����Դ��С�Ƶļ���
        /// </summary>
        /// <param name="rowID"></param>
        void DataSourceTotalCalc(int rowID)
        {
            DataTable dtView = (DataTable)gridView1.GridControl.DataSource;
            DataSourceTotalCalc(dtView, rowID);
        }
        /// <summary>
        /// ����Դ��С�Ƶļ���
        /// </summary>
        /// <param name="rowID"></param>
        void DataSourceTotalCalc(DataTable dtView, int rowID)
        {

            decimal totalQty = 0m;
            for (int i = 0; i < UCColumnCount; i++)
            {
                if (UCVolumeNumberShowFlag)//�����ʾ���,��������
                {
                    if (rowID % 5 == 0)//ƥ��
                    {
                        if (SysConvert.ToInt32(dtView.Rows[rowID]["ColVal" + (i + 1)]) != 0)
                        {
                            totalQty = totalQty + 1;
                        }
                    }
                    else//����
                    {
                        totalQty = totalQty + SysConvert.ToDecimal(dtView.Rows[rowID]["ColVal" + (i + 1)]);
                    }
                }
                else//�������ʾ��ţ�����һ������
                {
                    totalQty = totalQty + SysConvert.ToDecimal(dtView.Rows[rowID]["ColVal" + (i + 1)]);
                }
            }

            if (totalQty != 0)
            {
                dtView.Rows[rowID]["ColTotal"] = totalQty;
            }
            else
            {
                dtView.Rows[rowID]["ColTotal"] = DBNull.Value;
            }

        }
        #endregion


        #region �ڲ�����



        /// <summary>
        /// ת������ԴΪ����
        /// </summary>
        /// <returns>��һ��Ϊ���⣻ÿ������ռ���У���һ��ƥ�ţ��ڶ�������</returns>
        DataTable ConvertDataSource(DataTable dtSource)
        {
            gridView1.Columns.Clear();
            //���� UCColumnCount;
            DataTable outdt = new DataTable();
            outdt.Columns.Add(new DataColumn("ColTitle", typeof(string)));
            gridView1.Columns.Add(CreateGridColumnOne("ColTitle", "����", 0, 0, true));//���һ��

            int colWidth = UCFabParamSet.GetIntValueByID(6026);//�뵥�༭����ģʽ�п��
            if (colWidth <= 0)
            {
                colWidth = 0;
            }


            for (int i = 1; i <= UCColumnCount; i++)
            {
                outdt.Columns.Add(new DataColumn("ColVal" + i, typeof(string)));
                gridView1.Columns.Add(CreateGridColumnOne("ColVal" + i.ToString(), (i).ToString(), colWidth, i + 1, false));//���һ��
            }


            outdt.Columns.Add(new DataColumn("ColTotal", typeof(string)));
            gridView1.Columns.Add(CreateGridColumnOne("ColTotal", "С��", 0, UCColumnCount + 2, true));//���һ��

            //�������ϣ���ʼת������
            int rowIndex = 0;//ת�����к�
            int colIndex = 0;//ת�����к�
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                rowIndex = i / UCColumnCount;
                colIndex = i % UCColumnCount;

                if (colIndex == 0)//��һ�У����������
                {
                    if (UCVolumeNumberShowFlag)//�����ʾ��ţ������ƥ����
                    {
                        DataRow dr = outdt.NewRow();
                        dr["ColTitle"] = "ƥ��";
                        outdt.Rows.Add(dr);
                    }


                    DataRow dr2 = outdt.NewRow();
                    if (UCVolumeNumberShowFlag)//�����ʾ��ţ�����ʾ����
                    {
                        dr2["ColTitle"] = "����";
                    }
                    else
                    {
                        dr2["ColTitle"] = (rowIndex + 1).ToString();//��ʾ�к�,ֱ��
                    }
                    outdt.Rows.Add(dr2);
                    if (UCVolumeNumberShowFlag)//�����ʾ��ţ������ƥ����
                    {
                        DataRow dr3 = outdt.NewRow();
                        dr3["ColTitle"] = "����";
                        outdt.Rows.Add(dr3);
                        DataRow dr5 = outdt.NewRow();
                        dr5["ColTitle"] = "����";
                        outdt.Rows.Add(dr5);
                    }
                    if (UCVolumeNumberShowFlag)//�����ʾ��ţ������ƥ����
                    {
                        DataRow dr4 = outdt.NewRow();
                        dr4["ColTitle"] = "�ȼ�";
                        outdt.Rows.Add(dr4);
                    }
                }

                //��ʼ��ֵ
                if (UCVolumeNumberShowFlag)//��ʾ���
                {
                    outdt.Rows[rowIndex * 5]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["SubSeq"].ToString();//ƥ��
                    outdt.Rows[rowIndex * 5 + 1]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Qty"].ToString();//����
                    outdt.Rows[rowIndex * 5 + 2]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Weight"].ToString();//������
                    outdt.Rows[rowIndex * 5 + 3]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Yard"].ToString();//����
                    outdt.Rows[rowIndex * 5 + 4]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["GoodsLevel"].ToString();//�ȼ�
                }
                else//�������ʾ��ţ�����һ���������򲻸�ֵƥ��
                {
                    outdt.Rows[rowIndex * 4]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Qty"].ToString();//����
                    outdt.Rows[rowIndex * 4 + 1]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Weight"].ToString();//������
                    outdt.Rows[rowIndex * 4 + 2]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Yard"].ToString();//����
                    outdt.Rows[rowIndex * 4 + 3]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["GoodsLevel"].ToString();//�ȼ�
                }

            }

            return outdt;

        }


        /// <summary>
        /// ����һ��Grid��
        /// </summary>
        /// <param name="p_FiledName"></param>
        /// <param name="p_Title"></param>
        /// <param name="p_ColSize"></param>
        /// <param name="p_VIndex"></param>
        /// <returns></returns>
        GridColumn CreateGridColumnOne(string p_FiledName, string p_Title, int p_ColSize, int p_VIndex, bool p_ReadOnly)
        {
            GridColumn col = new GridColumn();
            col.Name = "col" + p_FiledName;
            col.FieldName = p_FiledName;
            col.Caption = p_Title;
            col.OptionsColumn.ReadOnly = p_ReadOnly;
            if (p_ReadOnly)
            {
                col.OptionsColumn.AllowEdit = !p_ReadOnly;
            }
            if (p_ColSize != 0)
            {
                col.Width = p_ColSize;
            }
            col.VisibleIndex = p_VIndex;
            return col;

        }
        #endregion

        #region �ؼ������¼�
        /// <summary>
        /// �ؼ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabIHori_Load(object sender, EventArgs e)
        {
            try
            {
                //UCFabCommon.GridViewRowIndexBind(gridView1);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �����¼�
        /// <summary>
        /// �б���ɫ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "ColTitle" || e.Column.FieldName == "ColTotal")//����
                {
                    e.Appearance.BackColor = UCTitleColor;
                }
                else
                {
                    if (e.RowHandle % 10 == 0 || e.RowHandle % 10 == 1 || e.RowHandle % 10 == 2 || e.RowHandle % 10 == 3 || e.RowHandle % 10 == 4)//����ֵ��10�У�
                    {
                        e.Appearance.BackColor = UCBackColor2;
                    }
                    else//ż��ֵ(10��)
                    {
                        e.Appearance.BackColor = UCBackColorS2;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ֵ�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.IndexOf("ColVal") != -1)//��ֵ
                {
                    int colIndex = SysConvert.ToInt32(e.Column.FieldName.Substring(6));//�к� 1��ʼ
                    int rowIndex = e.RowHandle / 5;//�кţ�ȡ�� 0��ʼ
                    if (!UCVolumeNumberShowFlag)//�������ʾ��ţ�����һ������������������GridView�к�
                    {
                        rowIndex = e.RowHandle;
                    }
                    int datasourceRow = rowIndex * UCColumnCount + (colIndex - 1);//����Դ�к�

                    if (UCDataSource.Rows.Count <= datasourceRow)//���
                    {
                        UCFabCommon.AddDtRow(UCDataSource, datasourceRow + 2);
                    }
                    if (UCDataSource.Rows.Count > datasourceRow)//δ���
                    {
                        if (UCVolumeNumberShowFlag)//�����ʾ��ţ��������У�һ��ƥ�ţ�һ�о��
                        {
                            if (e.RowHandle % 5 == 0)//ƥ��
                            {
                                if (SysConvert.ToInt32(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["SubSeq"] = SysConvert.ToInt32(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["SubSeq"] = DBNull.Value;
                                }
                            }
                            else if (e.RowHandle % 5 == 1)//����
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Qty"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Qty"] = DBNull.Value;
                                }
                            }
                            else if (e.RowHandle % 5 == 2)//������
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Weight"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Weight"] = DBNull.Value;
                                }
                            }
                            else if (e.RowHandle % 5 == 3)//����
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Yard"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Yard"] = DBNull.Value;
                                }
                            }
                            else
                            {
                                if (SysConvert.ToString(e.Value) != string.Empty)
                                {
                                    UCDataSource.Rows[datasourceRow]["GoodsLevel"] = SysConvert.ToString(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["GoodsLevel"] = DBNull.Value;
                                }
                            }
                        }
                        else//�������ʾ��ţ�����һ������
                        {
                            if (e.RowHandle % 4 == 0)//����
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Qty"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Qty"] = DBNull.Value;
                                }
                            }
                            else if (e.RowHandle % 4 == 1)//������
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Weight"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Weight"] = DBNull.Value;
                                }
                            }
                            else if (e.RowHandle % 4 == 2)
                            {
                                if (SysConvert.ToDecimal(e.Value) != 0)
                                {
                                    UCDataSource.Rows[datasourceRow]["Yard"] = SysConvert.ToDecimal(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["Yard"] = DBNull.Value;
                                }
                            }
                            else
                            {
                                if (SysConvert.ToString(e.Value) != string.Empty)
                                {
                                    UCDataSource.Rows[datasourceRow]["GoodsLevel"] = SysConvert.ToString(e.Value);
                                }
                                else
                                {
                                    UCDataSource.Rows[datasourceRow]["GoodsLevel"] = DBNull.Value;
                                }
                            }
                        }
                    }

                    DataSourceTotalCalc(e.RowHandle);//����С��
                    DataSourceTotalInfoSet();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }




        #endregion

        #region ���������
        /// <summary>
        /// ��յ�ǰ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmiClearRowData_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == this.ShowConfirmMessage("ȷ��Ҫ��ձ�������"))
                {
                    if (gridView1.FocusedRowHandle != -1)
                    {
                        for (int j = 0; j < gridView1.Columns.Count; j++)
                        {
                            if (gridView1.Columns[j].FieldName != "ColTitle" && gridView1.Columns[j].FieldName != "ColTotal")
                            {
                                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[j], "");
                            }

                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion




    }
}
