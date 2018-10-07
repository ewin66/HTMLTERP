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
    /// 锁定库存
    /// </summary>
    public partial class frmStorgeLock : frmAPBaseUIRpt
    {
        public frmStorgeLock()
        {
            InitializeComponent();
        }

        #region 全局变量
        int saveLockID = 0;
        private string saveBatch = string.Empty;
        private string saveVendorBatch = string.Empty;
        private string saveColorNum = string.Empty;
        private string saveColorName = string.Empty;
        private string saveJarNum = string.Empty;
        private string saveItemCode = string.Empty, saveItemName = string.Empty, saveItemStd = string.Empty, saveItemWHID;
        private string saveSectionID = string.Empty;
        private string saveSBitID = string.Empty;
        private string saveNeedle = string.Empty;
        private string saveDSN = string.Empty;
        private string saveSSN = string.Empty;
        //int saveWHTypeID = 0;       
        int saveStorgeID = 0;
        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
            if (SysConvert.ToString(drpQWHTypeID.EditValue) != "")
            {
                tempStr += " AND WHTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQWHTypeID.EditValue));
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
          
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }
            if (txtQColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (txtQColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtQColorName.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != "")
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQBatch.Text.Trim() != "")
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtQBatch.Text.Trim() + "%");
            }
            if (txtQVendorBatch.Text.Trim() != "")
            {
                tempStr += " AND VendorBatch LIKE " + SysString.ToDBString("%" + txtQVendorBatch.Text.Trim() + "%");
            }


            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            StorgeRule rule = new StorgeRule();

            DataTable dt = new DataTable();
            dt = rule.LKRShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
           
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();

        }


        /// <summary>
        /// 绑定锁定数据
        /// </summary>
        private void BindGridLockHis(string p_StorgeID)
        {
            StorgeLockHisRule rule = new StorgeLockHisRule();
            //gridView3.GridControl.DataSource=rule.RShow(" AND WHID="+SysString.ToDBString(p_WHID)+" AND ItemCode="+SysString.ToDBString(p_ItemCode),ProcessGrid.GetQueryField(gridView3));
            gridView3.GridControl.DataSource = rule.RShow(" AND StorgeID=" + SysString.ToDBString(p_StorgeID), ProcessGrid.GetQueryField(gridView3));
            gridView3.GridControl.Show();
        }
        /// <summary>
        /// 绑定锁定数据
        /// </summary>
        private void BindGridLock(string p_StorgeID)
        {
            StorgeLockRule rule = new StorgeLockRule();
            //gridView1.GridControl.DataSource=rule.RShow(" AND WHID="+SysString.ToDBString(p_WHID)+" AND ItemCode="+SysString.ToDBString(p_ItemCode),ProcessGrid.GetQueryField(gridView1));
            gridView2.GridControl.DataSource = rule.RShow(" AND StorgeID=" + SysString.ToDBString(p_StorgeID), ProcessGrid.GetQueryField(gridView2));
            gridView2.GridControl.Show();
        }

     


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_StorgeLock";
            this.HTDataList = gridView1;

            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2, gridView3 };


            gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged2);
            gridViewBindEventA2(gridView1);

            gridViewBaseRowChangedA3 += new gridViewBaseRowChangedA(gridViewRowChanged3);
            gridViewBindEventA3(gridView2);

            //Common.BindVendor(drpQVendorID, "WH_StorgeLock", "VendorID", true);

            //Common.BindOP(drpOPID, "WH_StorgeLock", "LockOPID", true);

            Common.BindWHType(drpQWHTypeID, false);
            Common.BindWH(drpQWHID, true);
            new ItemProcLookUp(drpQItemCode, new int[] { 1 }, true, true);//(int)ItemType.纱线

            SetTabIndex(0, groupControlQuery);
        }
        /// <summary>
        /// 重新设置实体1
        /// </summary>
        private void gridViewRowChanged2(object sender)
        {
            ColumnView view = sender as ColumnView;
            saveStorgeID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            txtTotalQty.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Qty"]));
            txtTotalLockQty.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LockQty"]));
            txtLeftQty.Text = SysConvert.ToString(SysConvert.ToDecimal(txtTotalQty.Text.Trim()) - SysConvert.ToDecimal(txtTotalLockQty.Text.Trim()));
            saveItemCode = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemCode"]));
            saveItemName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemName"]));
            saveItemStd = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ItemStd"]));
            saveItemWHID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WHID"]));
            saveBatch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Batch"]));
            saveVendorBatch = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["VendorBatch"]));
            saveColorNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorNum"]));
            saveColorName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ColorName"]));
            saveJarNum = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["JarNum"]));
            //saveWHTypeID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WHTypeID"]));
            saveSectionID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SectionID"]));
            saveSBitID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["SBitID"]));
            saveNeedle = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Needle"]));
            BindGridLockHis(saveStorgeID.ToString());
            BindGridLock(saveStorgeID.ToString());
           
        }


        /// <summary>
        /// 重新设置实体1
        /// </summary>
        private void gridViewRowChanged3(object sender)
        {
            ColumnView view = sender as ColumnView;
            txtLockQty.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LockQty"]));
            txtLockSO.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LockSO"]));
            txtRemark.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Remark"]));
            saveLockID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            drpOPID.EditValue = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LockOPID"]));

        }

        #endregion

        #region 按钮事件
        /// <summary>
        /// 锁定库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLockStorge_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (saveStorgeID == 0)
                {
                    this.ShowMessage("请先查询要操作的记录");
                    return;
                }
                if (SysConvert.ToFloat(txtLockQty.Text.Trim()) > SysConvert.ToFloat(txtLeftQty.Text.Trim()))
                {
                    this.ShowMessage("锁定数量大于当前可使用数量，不能实现库存锁定");
                    return;
                }
                if (!NewCheckCorrect())
                {
                    return;
                }
                //if (!CheckCorrectLock())
                //{
                //    return;
                //}
                StorgeLockRule rule = new StorgeLockRule();
                StorgeLock entity = this.GetEntity();
                rule.RLock(entity, true);

                string tempwhid = saveItemWHID;
                string tempitemcode = saveItemCode;
                string tempStorgeID = saveStorgeID.ToString();
                BindGrid();
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { tempStorgeID });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 解锁操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelLock_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (saveLockID == 0)
                {
                    this.ShowMessage("请先查询要操作的记录");
                    return;
                }

                if (DialogResult.Yes != ShowConfirmMessage("解除锁定为不可恢复操作，确认要解除？"))
                {
                    return;
                }
                if (!NewCheckCorrect())
                {
                    return;
                }
                //if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.审核1))//不具有审核权限
                //{
                //    if (!CheckOPID(FParamConfig.LoginID, saveLockID))//检验是不是管理员 !Common.CheckAdmin(FParamConfig.LoginID) && !Common.CheckWHAdmin(FParamConfig.LoginID) && 
                //    {
                //        this.ShowMessage("你不是该单的业务员，不能操作该单据");
                //        return;
                //    }
                //}
                if (SysConvert.ToDecimal(txtLockQty.Text.Trim()) > SysConvert.ToDecimal(txtTotalLockQty.Text.Trim()))
                {
                    this.ShowMessage("解锁数量大于锁定数量，解锁失败");
                    txtLockQty.Focus();
                    return;
                }
                StorgeLockRule rule = new StorgeLockRule();
                rule.RUnLock(saveLockID, SysConvert.ToDecimal(txtLockQty.Text.Trim()), txtRemark.Text.Trim(), true);

                string tempwhid = saveItemWHID;
                string tempitemcode = saveItemCode;
                string tempStorgeID = saveStorgeID.ToString();
                BindGrid();
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { tempStorgeID });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 校验数据
        /// </summary>
        /// <returns></returns>
        private bool NewCheckCorrect()
        {
            if (txtLockQty.Text.Trim() == "")
            {
                this.ShowMessage("请输入锁定数量");
                txtLockQty.Focus();
                return false;
            }
            else if (!SysConvert.IsDecimal(txtLockQty.Text.Trim()))
            {
                this.ShowMessage("请输入正确的锁定数量，数字");
                txtLockQty.Focus();
                return false;
            }
            else if (SysConvert.ToDecimal(txtLockQty.Text.Trim()) < 0)
            {
                this.ShowMessage("请输入大于0的锁定数量");
                txtLockQty.Focus();
                return false;
            }
            //if (Common.CheckLookUpEditBlank(drpOPID))
            //{
            //    this.ShowMessage("请选择业务员");
            //    drpOPID.Focus();
            //    return false;
            //}
            //			if(txtLockSO.Text.Trim()=="")
            //			{
            //				this.ShowMessage("请输入订单号");
            //				txtLockSO.Focus();
            //				return false;
            //			}
            return true;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private StorgeLock GetEntity()
        {
            StorgeLock entity = new StorgeLock();
            entity.ID = saveLockID;
            entity.SelectByID();
            entity.WHID = saveItemWHID;
            entity.ItemCode = saveItemCode;
            entity.ItemName = saveItemName;
            entity.ItemStd = saveItemStd;
            entity.LockSO = txtLockSO.Text.Trim();
            entity.LockQty = SysConvert.ToDecimal(txtLockQty.Text.Trim());
            entity.LockTime = DateTime.Now.Date;
            //ParamSetRule rule = new ParamSetRule();
            //if (this.FormListAID == (int)WHType.色纱)
            //{
            //    entity.NeedDate = DateTime.Now.AddDays(rule.RShowInt((int)ParamSet.色纱锁定期限));
            //}
            //else if (this.FormListAID == (int)WHType.坯纱)
            //{
            //    entity.NeedDate = DateTime.Now.AddDays(rule.RShowInt((int)ParamSet.坯纱锁定期限));
            //}
            entity.LockOPID = SysConvert.ToString(drpOPID.EditValue);
            entity.LockDesc = txtRemark.Text.Trim();
            entity.Remark = txtRemark.Text.Trim();
            //entity.StorgeID = saveStorgeID;
            entity.Batch = saveBatch;
            entity.VendorBatch = saveVendorBatch;
            entity.ColorNum = saveColorNum;
            entity.ColorName = saveColorName;
            entity.JarNum = saveJarNum;
            //entity.DSN = saveDSN;
            //entity.SSN = saveSSN;
            return entity;
        }
        #endregion

    }
}