using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ��������Ͳ�ѯ
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-18
    /// ����������
    /// </summary>
    public partial class frmOrderType : frmAPBaseUISin
    {
        public frmOrderType()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]

        /// <summary>
        /// ��ѯ����
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtName.Text.Trim() != "")//��ѯ��
            {
                tempStr = " AND Name LIKE " + SysString.ToDBString("%" + txtName.Text.Trim() + "%");
            }

            tempStr += " ORDER BY ID";
            HTDataConditionStr = tempStr;
        }

        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            OrderTypeRule rule = new OrderTypeRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            OrderTypeRule rule = new OrderTypeRule();
            OrderType entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_OrderType";
            this.HTDataList = gridView1;
            btnQuery_Click(null, null);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private OrderType EntityGet()
        {
            OrderType entity = new OrderType();
            entity.ID = HTDataID;      
            return entity;
        }

        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���и�ֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                ColumnView view = sender as ColumnView;
                string ColorStr = SysConvert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["ColorStr"]));
                e.Appearance.BackColor = Color.YellowGreen;
                string[] tempstr = ColorStr.Split(',');
                if (tempstr.Length == 3)//����Ϊ3
                {
                    e.Appearance.BackColor = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    e.Appearance.BackColor = Color.FromName(ColorStr);
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