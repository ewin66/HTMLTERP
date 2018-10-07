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
    public partial class frmAddressList : frmAPBaseUIForm
    {
        public frmAddressList()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;

            if (txtDVendorID.Text.Trim() != "")
            {
                tempStr += " AND DVendorID LIKE " + SysString.ToDBString("%" + txtDVendorID.Text.Trim() + "%");
            }
            if (txtDVendorAttn.Text.Trim() != "")
            {
                tempStr += " AND DVendorAttn LIKE " + SysString.ToDBString("%" + txtDVendorAttn.Text.Trim() + "%");
            }
            if (txtDVendorName.Text.Trim() != "")
            {
                tempStr += " AND DVendorName LIKE " + SysString.ToDBString("%" + txtDVendorName.Text.Trim() + "%");
            }
            if (txtDContact.Text.Trim() != "") 
            {
                tempStr += "AND Contact LIKE " + SysString.ToDBString("%" + txtDContact.Text.Trim() + "%");
            }

          //  tempStr += " AND  isnull(DefaultFlag,0)=0";
           // tempStr += " ORDER BY OPID";

            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            AddressListRule rule = new AddressListRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            AddressListRule rule = new AddressListRule();
            AddressList entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_AddressList";
            this.HTDataList = gridView1;

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private AddressList EntityGet()
        {
            AddressList entity = new AddressList();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}