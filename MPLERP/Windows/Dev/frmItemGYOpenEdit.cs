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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;
using DevComponents.DotNetBar;
using System.Collections;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ���Ʒ���չ���
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-6-21
    /// </summary>
    public partial class frmItemGYOpenEdit : frmAPBaseTool
    {
        public frmItemGYOpenEdit()
        {
            InitializeComponent();
        }


        #region ����
        /// <summary>
        /// ��ƷID
        /// </summary>
        int _WPItemID = 0;
        /// <summary>
        /// ��ƷID
        /// </summary>
        public int WPItemID
        {
            set
            {
                _WPItemID = value;
            }
        }



        /// <summary>
        /// �����־
        /// </summary>
        bool _WPSaveFlag = false;
        /// <summary>
        ///�����־
        /// </summary>
        public bool WPSaveFlag
        {
            get
            {
                return _WPSaveFlag;
            }
        }
        #endregion


        #region ��������ʼ��
        /// <summary>
        /// ����BarĬ�ϰ�ť
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(4, ToolButtonName.btnSave.ToString(), "����", false, btnSave_Click, eShortcut.F4);

        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ������ϸ���ݱ�,��������
        /// </summary>
        DataTable[] saveDtGYItemDts=new DataTable[10];

        void BindGrid1()
        {
            ItemGYFlowDtsRule rule = new ItemGYFlowDtsRule();
            DataTable dt = rule.RShow(" AND MainID=" + _WPItemID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));
            WCommon.AddDtRow(dt, 10);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ����ϸ����
        /// </summary>
        /// <param name="p_StrongRefresh">ǿ��ˢ�±�־������������̸ı���ǿ��ˢ�£��ѱ���Ļ��Զ����</param>
        void BindGrid2(bool p_StrongRefresh)
        {
            ItemGYFlowItemDtsRule rule = new ItemGYFlowItemDtsRule();
            DataTable dt= rule.RShow(" AND 1=0", ProcessGrid.GetQueryField(gridView2));//��ѯ�����ʽ

            bool findFlag = false;
            if (gridView1.FocusedRowHandle >= 0)
            {
                if (saveDtGYItemDts[gridView1.FocusedRowHandle] != null)
                {
                    dt = saveDtGYItemDts[gridView1.FocusedRowHandle];
                    findFlag = true;
                }
            }

            if (p_StrongRefresh || !findFlag)//ǿ��ˢ�»�û�����ݱ�ֵ
            {
                string conditionStr = string.Empty;
                conditionStr = " AND MainID=" + SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID")) + " ORDER BY Seq";
                dt = rule.RShow(conditionStr, ProcessGrid.GetQueryField(gridView2));

                if (dt.Rows.Count == 0)//���Ϊ�գ��󶨳�ʼ����ֵ
                {
                    string sql = "SELECT Name FROM Data_ItemBaseGYTypeDts WHERE 1=1 AND MainID=" + SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ItemGYTypeID")) + " ORDER BY Code";
                    DataTable dtBaseInfo = SysUtils.Fill(sql);
                    int i = 1;
                    foreach (DataRow drBaseInfo in dtBaseInfo.Rows)
                    {
                        DataRow dr = dt.NewRow();
                        dr["Seq"] = i++;
                        dr["GYItemName"] = drBaseInfo["Name"].ToString();
                        dt.Rows.Add(dr);
                    }
                }

                if (gridView1.FocusedRowHandle >= 0)
                {
                    saveDtGYItemDts[gridView1.FocusedRowHandle] = dt;
                }
            }

            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }
        /// <summary>
        ///ͨ�� ��������ʵ��1�������Ҫʹ�ã�����д��һ�㲻Ҫ�޸�
        /// </summary>
        public virtual void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            HTDataID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            BindGrid2(false);
        }


        /// <summary>
        /// ��ʼ��
        /// </summary>
        void IniData()
        {
            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);

            Common.BindItemBaseGYType(drpGridItemGYTypeID, true);
        }
        #endregion

        #region �����¼�
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmItemGYOpenEdit_Load(object sender, EventArgs e)
        {
            try
            {

                IniData();//��ʼ��

                BindGrid1();
               
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }
        #endregion


        #region ʵ�����ݻ��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        ItemGY EntityGet()
        {
            ItemGY entity = new ItemGY();
            entity.ID = _WPItemID;
            entity.SelectByID();
            return entity;
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        ItemGYFlowDts[] EntitFlowDtsyGet(out ArrayList alFlowItem)
        {
            ItemGYFlowDts[] entityDts;
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemGYTypeID")) != string.Empty)
                {
                    Num++;
                }
            }
            alFlowItem = new ArrayList();
            ItemGYFlowDts[] entitydts = new ItemGYFlowDts[Num];
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemGYTypeID")) != string.Empty)
                {
                    entitydts[index] = new ItemGYFlowDts();
                    entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entitydts[index].SelectByID();
                    entitydts[index].MainID = _WPItemID;
                    entitydts[index].Seq = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "Seq"));
                    if (entitydts[index].Seq == 0)
                    {
                        entitydts[index].Seq = i + 1;
                    }
                    entitydts[index].ItemGYTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ItemGYTypeID"));


                    //��ʼ��������ϸ
                    DataTable dtItemDts = saveDtGYItemDts[i];
                    if (dtItemDts != null)
                    {
                        int dtsnum = 0;
                        foreach (DataRow dr in dtItemDts.Rows)
                        {
                            if (dr["GYItemName"].ToString() != string.Empty)
                            {
                                dtsnum++;
                            }
                        }
                        ItemGYFlowItemDts[] entityFlowItemDts = new ItemGYFlowItemDts[dtsnum];
                        dtsnum = 0;
                        foreach (DataRow dr in dtItemDts.Rows)
                        {
                            if (dr["GYItemName"].ToString() != string.Empty)
                            {
                                entityFlowItemDts[dtsnum] = new ItemGYFlowItemDts();
                                entityFlowItemDts[dtsnum].ID = SysConvert.ToInt32(dr["ID"]);
                                entityFlowItemDts[dtsnum].MainID = SysConvert.ToInt32(dr["MainID"]);
                                entityFlowItemDts[dtsnum].Seq = SysConvert.ToInt32(dr["Seq"]);
                                entityFlowItemDts[dtsnum].TopID = _WPItemID;
                                if (entityFlowItemDts[dtsnum].Seq == 0)
                                {
                                    entityFlowItemDts[dtsnum].Seq = dtsnum + 1;
                                }

                                entityFlowItemDts[dtsnum].GYItemName = SysConvert.ToString(dr["GYItemName"]);
                                entityFlowItemDts[dtsnum].GYItemValue = SysConvert.ToString(dr["GYItemValue"]);

                                dtsnum++;

                            }
                        }

                        alFlowItem.Add(entityFlowItemDts);
                    }
                    else
                    {
                        alFlowItem.Add(new ItemGYFlowItemDts[] { });
                    }


                    index++;

                }
            }
            return entitydts;
        }
        #endregion

        #region  �����¼�

        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ItemGYRule rule = new ItemGYRule();
                ItemGY entity = EntityGet();

                ArrayList alFlowItem;
                ItemGYFlowDts[] entityflow = EntitFlowDtsyGet(out alFlowItem);
                rule.RSave(entity, entityflow, alFlowItem);
                _WPSaveFlag = true;
                this.ShowInfoMessage("����ɹ�");

            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }
        #endregion


        #region �����¼�
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {

                if (e.Column.FieldName == "ItemGYTypeID")
                {
                    BindGrid2(true);
                }

            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }
        #endregion
    }
}