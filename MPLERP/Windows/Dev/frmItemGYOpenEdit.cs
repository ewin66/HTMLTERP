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
    /// 功能：物品工艺管理
    /// 作者：陈加海
    /// 日期：2014-6-21
    /// </summary>
    public partial class frmItemGYOpenEdit : frmAPBaseTool
    {
        public frmItemGYOpenEdit()
        {
            InitializeComponent();
        }


        #region 属性
        /// <summary>
        /// 物品ID
        /// </summary>
        int _WPItemID = 0;
        /// <summary>
        /// 物品ID
        /// </summary>
        public int WPItemID
        {
            set
            {
                _WPItemID = value;
            }
        }



        /// <summary>
        /// 保存标志
        /// </summary>
        bool _WPSaveFlag = false;
        /// <summary>
        ///保存标志
        /// </summary>
        public bool WPSaveFlag
        {
            get
            {
                return _WPSaveFlag;
            }
        }
        #endregion


        #region 工具栏初始化
        /// <summary>
        /// 创建Bar默认按钮
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(4, ToolButtonName.btnSave.ToString(), "保存", false, btnSave_Click, eShortcut.F4);

        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 工艺明细数据表,缓存数组
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
        /// 绑定明细数据
        /// </summary>
        /// <param name="p_StrongRefresh">强制刷新标志，如果工艺流程改变则强制刷新，已保存的会自动清空</param>
        void BindGrid2(bool p_StrongRefresh)
        {
            ItemGYFlowItemDtsRule rule = new ItemGYFlowItemDtsRule();
            DataTable dt= rule.RShow(" AND 1=0", ProcessGrid.GetQueryField(gridView2));//查询结果格式

            bool findFlag = false;
            if (gridView1.FocusedRowHandle >= 0)
            {
                if (saveDtGYItemDts[gridView1.FocusedRowHandle] != null)
                {
                    dt = saveDtGYItemDts[gridView1.FocusedRowHandle];
                    findFlag = true;
                }
            }

            if (p_StrongRefresh || !findFlag)//强制刷新或没有数据表值
            {
                string conditionStr = string.Empty;
                conditionStr = " AND MainID=" + SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID")) + " ORDER BY Seq";
                dt = rule.RShow(conditionStr, ProcessGrid.GetQueryField(gridView2));

                if (dt.Rows.Count == 0)//如果为空，绑定初始定义值
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
        ///通用 重新设置实体1，如果不要使用，则重写，一般不要修改
        /// </summary>
        public virtual void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            HTDataID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            BindGrid2(false);
        }


        /// <summary>
        /// 初始化
        /// </summary>
        void IniData()
        {
            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);

            Common.BindItemBaseGYType(drpGridItemGYTypeID, true);
        }
        #endregion

        #region 窗体事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmItemGYOpenEdit_Load(object sender, EventArgs e)
        {
            try
            {

                IniData();//初始化

                BindGrid1();
               
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }
        #endregion


        #region 实体数据获得
        /// <summary>
        /// 获得实体
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
        /// 获得实体
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


                    //开始处理工艺明细
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

        #region  保存事件

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
                this.ShowInfoMessage("保存成功");

            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }
        #endregion


        #region 其它事件
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