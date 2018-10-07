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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmLYFormEdit : frmAPBaseUISinEdit
    {
        public frmLYFormEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入标题");
            //    txtTitle.Focus();
            //    return false;
            //}            

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            LYFormRule rule = new LYFormRule();
            LYForm entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            LYFormRule rule = new LYFormRule();
            LYForm entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            LYForm entity = new LYForm();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtFormNo.Text = entity.FormNo.ToString(); 
  			txtItemCode.Text = entity.ItemCode.ToString(); 
  			txtItemModel.Text = entity.ItemModel.ToString(); 
  			txtItemStd.Text = entity.ItemStd.ToString(); 
  			txtItemName.Text = entity.ItemName.ToString(); 
  			txtColorName.Text = entity.ColorName.ToString(); 
  			txtColorNum.Text = entity.ColorNum.ToString(); 
  			txtMWidth.Text = entity.MWidth.ToString(); 
  			txtMWeight.Text = entity.MWeight.ToString(); 
  			txtQty.Text = entity.Qty.ToString(); 
  			txtFormDate.DateTime = entity.FormDate; 
  			txtMakeOPName.Text = entity.MakeOPName.ToString(); 
  			txtPosition.Text = entity.Position.ToString();
            drpItemClassID.EditValue = entity.ItemClassID;
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            LYFormRule rule = new LYFormRule();
            LYForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_LYForm";
            this.ToolBarItemAdd(28, ToolButtonName.btnLoad.ToString(), "加载", false, btnLoad_Click);
            Common.BindItemClass(drpItemClassID, (int)EnumItemType.面料, true);
        }
        public override void IniInsertSet()
        {
            txtFormDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private LYForm EntityGet()
        {
            LYForm entity = new LYForm();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim(); 
  			entity.ItemCode = txtItemCode.Text.Trim(); 
  			entity.ItemModel = txtItemModel.Text.Trim(); 
  			entity.ItemStd = txtItemStd.Text.Trim(); 
  			entity.ItemName = txtItemName.Text.Trim(); 
  			entity.ColorName = txtColorName.Text.Trim(); 
  			entity.ColorNum = txtColorNum.Text.Trim(); 
  			entity.MWidth = SysConvert.ToDecimal(txtMWidth.Text.Trim()); 
  			entity.MWeight = SysConvert.ToDecimal(txtMWeight.Text.Trim()); 
  			entity.Qty = SysConvert.ToDecimal(txtQty.Text.Trim()); 
  			entity.FormDate = txtFormDate.DateTime.Date; 
  			entity.MakeOPName = txtMakeOPName.Text.Trim(); 
  			entity.Position = txtPosition.Text.Trim();
            entity.ItemClassID = SysConvert.ToInt32(drpItemClassID.EditValue);
  			
            return entity;
        }
        #endregion


        /// <summary>
        /// 加载面料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                restxtItemCode_DoubleClick(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #region
        /// <summary>
        /// 双击产品编码加载产品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restxtItemCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增 || HTFormStatus == FormStatus.修改)
                {
                    frmLoadFabric frm = new frmLoadFabric();
                    frm.ShowDialog();
                    string str = string.Empty;
                    if (frm.GBID != null && frm.GBID.Length != 0)
                    {

                        for (int i = 0; i < frm.GBID.Length; i++)
                        {
                            if (str != string.Empty)
                            {
                                str += ",";
                            }
                            str += SysConvert.ToString(frm.GBID[i]);
                        }
                        setItemNews(str);
                    }
                   

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void setItemNews(string str)
        {
            string[] gbid = str.Split(',');
            for (int i = 0; i < gbid.Length; i++)
            {
                string sql = "SELECT * FROM  Data_Item WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(gbid[i]));
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    txtItemCode.Text =  SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                    txtItemModel.Text = SysConvert.ToString(dt.Rows[0]["ItemModel"]);
                    txtItemName.Text = SysConvert.ToString(dt.Rows[0]["ItemName"]);
                    txtItemStd.Text = SysConvert.ToString(dt.Rows[0]["ItemStd"]);
                    txtMWidth.Text = SysConvert.ToDecimal(dt.Rows[0]["MWidth"]).ToString();
                    txtMWeight.Text = SysConvert.ToDecimal(dt.Rows[0]["MWeight"]).ToString();
                    drpItemClassID.EditValue = SysConvert.ToInt32(dt.Rows[0]["ItemClassID"]);
                  
                }
            }
        }

        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus == FormStatus.新增)
                {
                   
                    ProductCommon.FormNoIniSet(txtFormNo, "WH_LYForm", "FormNo", 0);
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