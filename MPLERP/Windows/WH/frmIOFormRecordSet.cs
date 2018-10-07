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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmIOFormRecordSet : frmAPBaseUIRpt
    {
        public frmIOFormRecordSet()
        {
            InitializeComponent();//
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtBoxNo.Text.Trim() != "")
            {
                tempStr += " AND BoxNo LIKE " + SysString.ToDBString("%" + txtBoxNo.Text.Trim() + "%");
            }
            if (txtWHID.Text.Trim() != "")
            {
                tempStr += " AND WHID LIKE " + SysString.ToDBString("%" + txtWHID.Text.Trim() + "%");
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }
          
            if (chkItemDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtFormDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }
          
            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE "+SysString.ToDBString("%"+txtItemModel.Text.Trim()+"%");
            }

            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");//
            }

            if (FormListAID == 1)//正品入库
            {
                tempStr += " AND SubType= 1107";
            }

            if (FormListAID ==2)//正品出库
            {
                tempStr += " AND SubType= 1201";
            }

            if (chkNoRecord.Checked)//只查询未设置员工的数据
            {
                tempStr += " AND ISNULL(RecordOPID,'')=''";
            }

            tempStr += " ORDER BY ID";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            IOFormDtsPackRule rule = new IOFormDtsPackRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
           
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            PackBoxRule rule = new PackBoxRule();
            PackBox entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_PackBox";
            this.HTDataList = gridView1;
            txtFormDateS.DateTime = DateTime.Now.AddMonths(-2).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;
            txtBoxNo.Focus();
            btnQuery_Click(null, null);

            Common.BindOPID(drpGridRecordOPID,true);
            Common.BindOP(drpGridRecordOPID, (int)EnumOPDep.仓库, true);


            this.ToolBarItemAdd(28, "btnSave", "保存", false, btnSave_Click);
        }

        /// <summary>
        ///保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(i, "RecordOPID")) != "")
                    {
                        int PackID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "PackID"));

                        IOFormDtsPackRule rule = new IOFormDtsPackRule();
                        IOFormDtsPack entity = new IOFormDtsPack();
                        entity.ID = PackID;
                        entity.SelectByID();

                        entity.RecordOPID = SysConvert.ToString(gridView1.GetRowCellValue(i, "RecordOPID"));
                        if (FormListAID == 1)
                        {
                            entity.RecordType = "打卷";
                        }
                        if (FormListAID == 2)
                        {
                            entity.RecordType = "上布";
                        }

                        rule.RUpdate(entity);
                    }

                }

                this.ShowInfoMessage("保存成功！");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private PackBox EntityGet()
        {
            PackBox entity = new PackBox();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion



        #region 其它事件
        private void txtBoxNo_EditValueChanged(object sender, EventArgs e)
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

        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "RecordOPID" }, true);
        }
        #endregion

        #region 打印码单
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "BoxStatusName")//
                {
                    e.Appearance.BackColor = PackBoxStatusProc.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "BoxStatusName")));
                }
            
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();
            string BoxIDStr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    if (BoxIDStr != "")
                    {
                        BoxIDStr += ",";
                    }
                    BoxIDStr += SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                }
            }

            if (BoxIDStr == "")
            {
                this.ShowMessage("请勾选需要打印的挂板条码");
                return false;
            }


            DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            if (ci.SelectedItem == null)
            {
                this.ShowMessage("请选择报表模板");
                return false;
            }
            int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            if (tempReportID == 1)
            {
                this.ShowMessage("请选择报表模板");
                return false;
            }


            string sql = "SELECT * FROM WH_PackBox WHERE ID IN (" + BoxIDStr + ")";
            DataTable dtSource = SysUtils.Fill(sql);

            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dtSource);


            //FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { BoxIDStr });
            return true;
        }

        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnPreview_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.预览);


            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


       
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                base.btnPrint_Click(sender, e);

                btnPrintAbount((int)ReportPrintType.打印);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.设计);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

      
    }
}