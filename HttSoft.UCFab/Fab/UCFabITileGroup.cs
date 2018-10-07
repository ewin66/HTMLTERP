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
    /// ���ܣ�¼���뵥 ����Groupģʽ
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-29
    /// 
    /// 
    /// �Զ������������������Զ�������
    /// </summary>
    public partial class UCFabITileGroup : UCFabBaseInputCtl
    {
        public UCFabITileGroup()
        {
            InitializeComponent();
            InitPanGroup();
        }

        #region ����

        #endregion

        #region �ⲿ���÷���


        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public override void UCAct()
        {
            UCFabCommon.AddDtRow(UCDataSource, UCInputCount);
            CreateFabTile(UCDataSource, UCColumnCount);
        }


        /// <summary>
        /// ִ�����¸�ֵ����������¼��ʱ
        /// </summary>
        public override void UCBind()
        {
            BindFabTile();//ˢ������
        }

        #endregion

        #region �ڲ�����
        /// <summary>
        /// ���¸�ֵ����
        /// </summary>
        void BindFabTile()
        {
            foreach (Control ctl in panGroup.Controls)
            {
                if (ctl is UCFabITile)
                {
                    ((UCFabITile)ctl).UCBindData();
                }
            }
        }

       

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="dtSource">����Դ����0/1/2/3/4:ѡ���־/BoxNo/���/����/�׺�</param>
        /// <param name="p_ColumnCount">������</param>
        void CreateFabTile(DataTable dtSource, int p_ColumnCount)
        {


            panGroup.Controls.Clear();//������������пؼ�
            int firstColumnWidth = 46+1;
            int firstRowHeight = 27+1;
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                int xIndex = i % p_ColumnCount;//ˮƽ ȡ��
                int yIndex = i / p_ColumnCount;//��ֱ ȡ��

                int colorIndex = 1;//ɫϵ
                //if (xIndex % 2 == 1)//ȡ��
                //{
                //    colorIndex = 2;
                //}


                if (xIndex == 0)//����һ����ʼ��
                {
                    UCFabITileFirstColumn ucftc = CreateFabTileFirstColumnOne(xIndex, yIndex, firstRowHeight);
                    ucftc.UCRowIndex = yIndex + 1;
                    panGroup.Controls.Add(ucftc);
                }
                if (yIndex == 0)//����һ����ʼ��
                {
                    UCFabITileFirstRow ucftr = CreateFabTileFirstRowOne(xIndex, yIndex, firstColumnWidth);
                    ucftr.UCColIndex = xIndex + 1;
                    panGroup.Controls.Add(ucftr);
                }

                UCFabITile ucft = CreateFabTileOne(xIndex, yIndex, firstColumnWidth, firstRowHeight);
                ucft.UCBackColorIndex = colorIndex;
                ucft.DrSource = dtSource.Rows[i];
                ucft.UCRowIndex = i;

                panGroup.Controls.Add(ucft);

                Application.DoEvents();

            }
        }

        /// <summary>
        /// ��������һ�� ��һ��
        /// </summary>
        /// <param name="p_XIndex">ˮƽ���</param>
        /// <param name="p_YIndex">��ֱ���</param>
        UCFabITileFirstColumn CreateFabTileFirstColumnOne(int p_XIndex, int p_YIndex,int p_FirstRowHeight)
        {
            int splitpixel = 1;//�������
            int tempHeight = 85;
            UCFabITileFirstColumn ucftc = new UCFabITileFirstColumn();
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
        UCFabITileFirstRow CreateFabTileFirstRowOne(int p_XIndex, int p_YIndex, int p_FirstColumnWidth)
        {
            int splitpixel = 1;//�������
            int tempWidth = 97;
            UCFabITileFirstRow ucftr = new UCFabITileFirstRow();
            ucftr.Location = new System.Drawing.Point(p_XIndex * tempWidth + splitpixel * (p_XIndex + 1) + p_FirstColumnWidth, splitpixel);
            ucftr.Name = "ucftfr" + (10000 * p_YIndex + p_XIndex);
            //ucft.Size = new System.Drawing.Size(tempWidth, tempHeight);
            //ucft.TabIndex = 1000 * p_YIndex + p_XIndex;
            ucftr.MouseClick += new MouseEventHandler(panGroup_MouseClick);//���ٵ����������
            return ucftr;
        }


        /// <summary>
        /// ��������һ��
        /// </summary>
        /// <param name="p_XIndex">ˮƽ���</param>
        /// <param name="p_YIndex">��ֱ���</param>
        UCFabITile CreateFabTileOne(int p_XIndex, int p_YIndex, int p_FirstColumnWidth, int p_FirstRowHeight)
        {
            int splitpixel = 1;//�������
            int tempWidth = 97, tempHeight = 85;

            UCFabITile ucft = new UCFabITile();
            ucft.Location = new System.Drawing.Point(p_XIndex * tempWidth + splitpixel * (p_XIndex + 1) + p_FirstColumnWidth, p_YIndex * tempHeight + splitpixel * (p_YIndex + 1) + p_FirstRowHeight);
            ucft.Name = "ucft" + (10000 * p_YIndex + p_XIndex);
            ucft.Size = new System.Drawing.Size(tempWidth, tempHeight);
            ucft.TabIndex = 1000 * p_YIndex + p_XIndex;
            ucft.UCTileXY = p_XIndex.ToString() + " " + p_YIndex.ToString();
            ucft.UCControl_RowIndexChanged += new UCFabRowIndexChanged(UCControl_RowIndexChanged);

            //ucft.MouseClick += new MouseEventHandler(panGroup_MouseClick);//���ٵ����������
            return ucft;
        }

        /// <summary>
        /// ������Ÿı��¼�
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        void UCControl_RowIndexChanged(object sender, int rowIndex)
        {
            UCCurrnetFocusIndex = rowIndex;

            if (sender is DevExpress.XtraEditors.TextEdit)
            {
            }
            else
            {
                panGroup_MouseClick(null, null);
            }

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

        /// <summary>
        /// �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
