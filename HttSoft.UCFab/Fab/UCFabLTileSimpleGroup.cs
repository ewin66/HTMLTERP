using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;

namespace HttSoft.UCFab
{
    /// <summary>
    /// ���ܣ����ز������б�
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-29
    /// 
    /// �Զ������������������Զ�������
    /// </summary>
    public partial class UCFabLTileSimpleGroup : UCFabBaseLoadCtl
    {
        public UCFabLTileSimpleGroup()
        {
            InitializeComponent();

            InitPanGroup();
        }



        #region ����




        ///// <summary>
        ///// ��ȡѡ�������Դ
        ///// </summary>
        //public DataTable UCSelectDataSource
        //{
        //    get
        //    {
        //        DataTable outdt = UCDataSource.Clone();
        //        foreach (Control ctl in panGroup.Controls)//
        //        {
        //            if (ctl is UCFabLTile)
        //            {
        //                UCFabLTile ucf = (UCFabLTile)ctl;
        //                if (ucf.UCChecked)
        //                {
        //                    DataRow[] drA = UCDataSource.Select("BoxNo=" + ucf.UCISN);
        //                    if (drA.Length == 1)//�ҵ�����
        //                    {
        //                        DataRow outdr = outdt.NewRow();
        //                        for (int i = 0; i < outdt.Columns.Count; i++)//ѭ������
        //                        {
        //                            outdr[i] = drA[0][i];
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return outdt;
        //    }
        //}
        #endregion


        #region �ⲿ���÷���


        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public override void UCAct()
        {
            CreateFabTile(UCDataSource, UCColumnCount);
        }

        /// <summary>
        /// ȫѡ
        /// </summary>
        public override void UCSelectAll()
        {
            foreach (Control ctl in panGroup.Controls)//
            {
                if (ctl is UCFabLTileSimple)
                {
                    UCFabLTileSimple ucf = (UCFabLTileSimple)ctl;
                    ucf.UCChecked = true;
                }
            }
        }

        /// <summary>
        /// ��ѡ
        /// </summary>
        public override void UCSelectFan()
        {
            foreach (Control ctl in panGroup.Controls)
            {
                if (ctl is UCFabLTileSimple)
                {
                    UCFabLTileSimple ucf = (UCFabLTileSimple)ctl;
                    ucf.UCChecked = !ucf.UCChecked;
                }
            }
        }


        /// <summary>
        /// ȡ��һ��ѡ��ⲿ����
        /// </summary>
        /// <param name="p_ISN"></param>
        public override void UCCancelOne(string p_ISN)
        {
            foreach (Control ctl in panGroup.Controls)
            {
                if (ctl is UCFabLTileSimple)
                {
                    UCFabLTileSimple ucf = (UCFabLTileSimple)ctl;
                    if (ucf.UCISN == p_ISN)
                    {
                        ucf.UCChecked = false;
                    }
                }
            }
        }
        #endregion

        #region �ڲ�����
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="dtSource">����Դ����0/1/2/3/4:ѡ���־/BoxNo/���/����/�׺�</param>
        /// <param name="p_ColumnCount">������</param>
        void CreateFabTile(DataTable dtSource, int p_ColumnCount)
        {

            RemoveUserCtl(panGroup);
            //panGroup.Controls.Clear();//������������пؼ�


            int firstColumnWidth = 55 + 1;
            int firstRowHeight = 23 + 1;


            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                int xIndex = i % (p_ColumnCount);//ˮƽ ȡ�� С�ߴ磬����2 *2
                int yIndex = i / (p_ColumnCount);//��ֱ ȡ�� С�ߴ磬����2 * 2

                int colorIndex = 1;//ɫϵ
                //if (xIndex % 2 == 1)//ȡ��
                //{
                //    colorIndex = 2;
                //}


                if (xIndex == 0)//����һ����ʼ��
                {
                    UCFabLTileSimpleFirstColumn ucftc = CreateFabTileFirstColumnOne(xIndex, yIndex, firstRowHeight);
                    ucftc.UCRowIndex = yIndex + 1;
                    panGroup.Controls.Add(ucftc);
                }
                if (yIndex == 0)//����һ����ʼ��
                {
                    UCFabLTileSimpleFirstRow ucftr = CreateFabTileFirstRowOne(xIndex, yIndex, firstColumnWidth);
                    ucftr.UCColIndex = xIndex + 1;
                    panGroup.Controls.Add(ucftr);
                }


                UCFabLTileSimple ucft = CreateFabTileOne(xIndex, yIndex, firstColumnWidth, firstRowHeight);
                ucft.IniValue(dtSource.Rows[i]["BoxNo"].ToString()
                    , new string[] { dtSource.Rows[i]["SubSeq"].ToString(), dtSource.Rows[i]["Qty"].ToString(), dtSource.Rows[i]["JarNum"].ToString() }
                    , SysConvert.ToBoolean(SysConvert.ToInt32(dtSource.Rows[i]["SelectFlag"])), colorIndex);
                ucft.UCRowIndex = i;//�������
                panGroup.Controls.Add(ucft);

            }
        }


        /// <summary>
        /// ��������һ�� ��һ��
        /// </summary>
        /// <param name="p_XIndex">ˮƽ���</param>
        /// <param name="p_YIndex">��ֱ���</param>
        UCFabLTileSimpleFirstColumn CreateFabTileFirstColumnOne(int p_XIndex, int p_YIndex, int p_FirstRowHeight)
        {
            int splitpixel = 2;//�������
            int tempHeight = 44;
            UCFabLTileSimpleFirstColumn ucftc = new UCFabLTileSimpleFirstColumn();
            ucftc.Location = new System.Drawing.Point(splitpixel, p_YIndex * tempHeight + splitpixel * (p_YIndex + 1) + p_FirstRowHeight);
            ucftc.Name = "ucftfc" + (10000 * p_YIndex + p_XIndex);
            //ucft.Size = new System.Drawing.Size(tempWidth, tempHeight);
            //ucft.TabIndex = 1000 * p_YIndex + p_XIndex;
            ucftc.MouseClick += new MouseEventHandler(panGroup_MouseClick);//���ٵ����������
            return ucftc;
        }

        /// <summary>
        /// ��������һ�� ��һ��
        /// </summary>
        /// <param name="p_XIndex">ˮƽ���</param>
        /// <param name="p_YIndex">��ֱ���</param>
        UCFabLTileSimpleFirstRow CreateFabTileFirstRowOne(int p_XIndex, int p_YIndex, int p_FirstColumnWidth)
        {
            int splitpixel = 2;//�������
            int tempWidth = 85;
            int setWidth = UCFabParamSet.GetIntValueByID(6014);//�뵥ѡ����ģʽ�������
            if (setWidth > 0)
            {
                tempWidth = setWidth;
            }
            int tempHeight = 23;


            UCFabLTileSimpleFirstRow ucftr = new UCFabLTileSimpleFirstRow();
            ucftr.Location = new System.Drawing.Point(p_XIndex * tempWidth + splitpixel * (p_XIndex + 1) + p_FirstColumnWidth, splitpixel);
            ucftr.Name = "ucftfr" + (10000 * p_YIndex + p_XIndex);
            ucftr.Size = new System.Drawing.Size(tempWidth, tempHeight);
            //ucft.TabIndex = 1000 * p_YIndex + p_XIndex;
            ucftr.MouseClick += new MouseEventHandler(panGroup_MouseClick);//���ٵ����������
            return ucftr;
        }

        /// <summary>
        /// ��������һ��
        /// </summary>
        /// <param name="p_XIndex">ˮƽ���</param>
        /// <param name="p_YIndex">��ֱ���</param>
        UCFabLTileSimple CreateFabTileOne(int p_XIndex, int p_YIndex, int p_FirstColumnWidth, int p_FirstRowHeight)
        {
            int splitpixel = 2;//�������
            int tempWidth = 85, tempHeight = 44;

            int setWidth = UCFabParamSet.GetIntValueByID(6014);//�뵥ѡ����ģʽ�������
            if (setWidth > 0)
            {
                tempWidth = setWidth;
            }

            UCFabLTileSimple ucft = new UCFabLTileSimple();
            ucft.Location = new System.Drawing.Point(p_XIndex * tempWidth + splitpixel * (p_XIndex + 1) + p_FirstColumnWidth, p_YIndex * tempHeight + splitpixel * (p_YIndex + 1) + p_FirstRowHeight);
            ucft.Name = "ucft" + (10000 * p_YIndex + p_XIndex);
            ucft.Size = new System.Drawing.Size(tempWidth, tempHeight);
            ucft.TabIndex = 1000 * p_YIndex + p_XIndex;
            //ucft.UCBackColorIndex = p_ColorIndex;
            ucft.object_CheckedChanged += new UCFabLTileCheckChanged(UCFabLTile_CheckChanged);//����ί���¼�
            //ucft.MouseClick += new MouseEventHandler(panGroup_MouseClick);//���ٵ����������

            ucft.UCControl_RowIndexChanged += new UCFabRowIndexChanged(UCControl_RowIndexChanged);

            if (UCAllowKPFlag)//����ƥ
            {
                ucft.ContextMenuStrip = cMenuLoadFab;
            }
            return ucft;
        }


        /// <summary>
        /// Shift����ִ�й�����
        /// </summary>
        bool tempTileShifFlag = false;

        /// <summary>
        /// ����ѡ��ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        void UCFabLTile_CheckChanged(object sender)
        {
            if (tempTileShifFlag)//��ִ��Shift�¼��У���ִ�У���ֹ��ѭ��
            {
                return;
            }
            tempTileShifFlag = true;

            UCFabLTileSimple ucft = (UCFabLTileSimple)sender;
            DataRow[] drA = UCDataSource.Select(" BoxNo=" + SysString.ToDBString(ucft.UCISN));
            if (drA.Length == 1)
            {
                drA[0]["SelectFlag"] = SysConvert.ToInt32(ucft.UCChecked);
            }

            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)//��ס��Shift����
            {
                if (UCCurrnetFocusIndex != -1)//ǰһ�۽��к��Ѵ���
                {
                    for (int i = UCCurrnetFocusIndex + 1; i < ucft.UCRowIndex; i++)//��ֹ��ѭ������
                    {
                        UCDataSource.Rows[i]["SelectFlag"] = ucft.UCChecked;
                    }

                    foreach (Control ctl in panGroup.Controls)
                    {
                        if (ctl is UCFabLTileSimple)
                        {
                            UCFabLTileSimple ucf = (UCFabLTileSimple)ctl;
                            if (ucf.UCRowIndex >= UCCurrnetFocusIndex + 1 && ucf.UCRowIndex <= ucft.UCRowIndex)
                            {
                                ucf.UCChecked = ucft.UCChecked;
                            }
                        }
                    }

                }
            }


            UCCurrnetFocusIndex = ucft.UCRowIndex;
            tempTileShifFlag = false;
        }

        /// <summary>
        /// ������Ÿı��¼�
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        void UCControl_RowIndexChanged(object sender, int rowIndex)
        {
            //UCCurrnetFocusIndex = rowIndex;
            panGroup_MouseClick(null, null);

        }

        /// <summary>
        /// ��ʼ��Panel����
        /// </summary>
        void InitPanGroup()
        {
            this.panGroup.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panGroup_MouseWheel);
        }

        private void panGroup_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                int tempValue = panGroup.VerticalScroll.Value;

                if (tempValue - e.Delta <= this.panGroup.VerticalScroll.Minimum)
                {
                    tempValue = 0;
                    panGroup.VerticalScroll.Value = tempValue;
                }
                else if (tempValue - e.Delta >= this.panGroup.VerticalScroll.Maximum)
                {
                    tempValue = this.panGroup.VerticalScroll.Maximum;
                    panGroup.VerticalScroll.Value = tempValue;
                }
                else
                {
                    panGroup.VerticalScroll.Value -= e.Delta;
                }


                panGroup.Refresh();
                panGroup.Invalidate();
                panGroup.Update();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void panGroup_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.panGroup.Focus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        #endregion

        #region ��ƥ����
        /// <summary>
        /// ��ƥ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmiLoadFabKP_Click(object sender, EventArgs e)
        {
            try
            {
                UCKP(SysConvert.ToString(cmiLoadFabKP.Tag));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }            
        }

        /// <summary>
        /// �Ҽ��˵���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuLoadFab_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                Control ctl= (sender as ContextMenuStrip).SourceControl;
                if (ctl is UCFabLTileSimple)
                {
                    cmiLoadFabKP.Tag = ((UCFabLTileSimple)ctl).UCISN;
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
