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
using System.Collections;

namespace MLTERP
{
    /// <summary>
    /// 功能：客户管理明细
    /// 作者：章文强
    /// 日期：2012-04-18
    /// 操作：新增
    /// </summary>
    public partial class frmVendorEdit : frmAPBaseUIFormEdit
    {
        public frmVendorEdit()
        {
            InitializeComponent();
        }

        bool DutyViewFlg = false;

        #region 自定义虚方法定义[需要修改]     
        public string[] itemstr ={ "长大衣", "短大衣", "套装", "裙子", "裤子", "其他" };

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            //设置物品信息
            Vendor entity = new Vendor();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();

            HTDataFormNo = entity.VendorID;

            txtAddress.Text = entity.Address.ToString();
            txtArea.Text = entity.Area.ToString();
            txtCountry.Text = entity.Country.ToString();
            txtFax.Text = entity.Fax.ToString();
            txtInDate.DateTime = entity.InDate;
            txtPassword.Text = entity.Password.ToString();
            txtTel.Text = entity.Tel.ToString();
            txtVendorAttn.Text = entity.VendorAttn.ToString();
            txtVendorID.Text = entity.VendorID.ToString();
            txtVendorName.Text = entity.VendorName.ToString();
            txtVendorNameEn.Text = entity.VendorNameEn.ToString();
            txtWebUrl.Text = entity.WebUrl.ToString();
            drpInSaleOP.EditValue = entity.InSaleOP.ToString();
            drpUseableFlag.EditValue = entity.UseableFlag;
            //drpVendorTypeID.EditValue = entity.VendorTypeID;
            drpWebFlag.EditValue = entity.WebFlag;
            txtQueryAccount.Text = entity.QueryAccount.ToString();
            txtFree1.Text = entity.Free1.ToString();
            txtFree2.Text = entity.Free2.ToString();
            txtContact.Text = entity.Contact.ToString();
            drpVendorLevel.EditValue = entity.VendorLevel.ToString();

            drpPayMothodFlag.EditValue = entity.PayMethodFlag;

            txtCHBrand.Text = entity.CHBrand.ToString();
            txtENBrand.Text = entity.ENBrand.ToString();
            txtAge1.Text = entity.age1.ToString();
            txtAge2.Text = entity.age2.ToString();
            txtSJFG.Text = entity.SJFG.ToString();
            txtLimitAmount.Text = entity.LimitAmount.ToString();
            txtSHXAmount.Text = entity.SHXAmount.ToString();
            txtLimitDayNum.Text = entity.LimitDayNum.ToString();
            if (entity.PF == 1)
            {
                chkPF.Checked = true;
            }
            else
            {
                chkPF.Checked = false;
            }

            if (entity.DL == 1)
            {
                chkDL.Checked = true;
            }
            else
            {
                chkDL.Checked = false;
            }

            if (entity.ZY == 1)
            {
                chkZY.Checked = true;
            }
            else
            {
                chkZY.Checked = false;
            }
            txtMPrice1.Text = entity.MPrice1.ToString();
            txtMPrice2.Text = entity.MPrice2.ToString();
            txtMPrice3.Text = entity.MPrice3.ToString();
            txtMPrice4.Text = entity.MPrice4.ToString();
            txtMainSale.Text = entity.MainSale.ToString();



            txtAlibaba.Text = entity.Alibaba;
            txtQQ.Text = entity.QQ;
            txtZhangHao.Text = entity.ZhangHao;


            entity.Mobile = txtMobile.Text.Trim();
            entity.EMail = txtEMail.Text.Trim();
            entity.Province = txtProvince.Text.Trim();


            if (!findFlag)
            {

            }
            //绑定明细信息
            BindGrid();// 绑定客户联系人
            BindGrid2();// 绑定客户归属业务员
            BindGrid3();
            BindGrid4();
            BindPic();
            SetCheckVendorType(drpVendorTypeID);

        }


        #region 客户类型处理
        /// <summary>
        /// 设置所属公司类型
        /// </summary>
        private void SetCheckVendorType(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList)
        {
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                p_CheckList.SetItemCheckState(i, CheckState.Unchecked);
            }

            string sql = string.Empty;
            sql = "SELECT VendorTypeID FROM Data_VendorTypeDts WHERE VendorID=" + SysString.ToDBString(txtVendorID.Text);
            DataTable dt = SysUtils.Fill(sql);

            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < p_CheckList.ItemCount; i++)
                {
                    if (dr["VendorTypeID"].ToString() == p_CheckList.GetItemValue(i).ToString())//
                    {
                        p_CheckList.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }


            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                if (this.FormListAID.ToString() == p_CheckList.GetItemValue(i).ToString())//
                {
                    p_CheckList.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }


        /// <summary>
        /// 设置所属公司类型默认值
        /// </summary>
        private void SetCheckVendorTypeDefault(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList)
        {
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                p_CheckList.SetItemCheckState(i, CheckState.Unchecked);
            }


                for (int i = 0; i < p_CheckList.ItemCount; i++)
                {
                    if (this.FormListAID.ToString() == p_CheckList.GetItemValue(i).ToString())//
                    {
                        p_CheckList.SetItemCheckState(i, CheckState.Checked);
                    }
                }
        }
        /// <summary>
        /// 获得公司类型
        /// </summary>
        /// <returns></returns>
        private ArrayList GetEntityDtsVendorType(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                if (p_CheckList.GetItemCheckState(i) == CheckState.Checked)
                {
                    VendorTypeDts entity=new VendorTypeDts();
                    entity.VendorID = txtVendorID.Text.Trim();
                    entity.VendorTypeID=SysConvert.ToInt32(p_CheckList.GetItemValue(i));
                    al.Add(entity);
                   

                }
            }
            return al;
        }
        #endregion

        private void BindPic()
        {
            string sql = "SELECT * FROM Data_VendorFile WHERE MainID=" + SysString.ToDBString(HTDataID);
            sql += " ORDER BY Seq";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (SysConvert.ToInt32(dt.Rows[i]["FileTypeID"]) == i + 1)
                    {
                        switch (i + 1)
                        {
                            case 1:
                                img1.Image = TemplatePic.ByteToImage((byte[])dt.Rows[i]["Context"]);
                                txtRemark1.Text = SysConvert.ToString(dt.Rows[i]["Remark"]);
                                break;
                            case 2:
                                img2.Image = TemplatePic.ByteToImage((byte[])dt.Rows[i]["Context"]);
                                txtRemark2.Text = SysConvert.ToString(dt.Rows[i]["Remark"]);
                                break;
                            case 3:
                                img3.Image = TemplatePic.ByteToImage((byte[])dt.Rows[i]["Context"]);
                                txtRemark3.Text = SysConvert.ToString(dt.Rows[i]["Remark"]);
                                break;
                            case 4:
                                img4.Image = TemplatePic.ByteToImage((byte[])dt.Rows[i]["Context"]);
                                txtRemark4.Text = SysConvert.ToString(dt.Rows[i]["Remark"]);
                                break;
                            case 5:
                                img5.Image = TemplatePic.ByteToImage((byte[])dt.Rows[i]["Context"]);
                                txtRemark5.Text = SysConvert.ToString(dt.Rows[i]["Remark"]);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }


        private void BindGrid3()
        {
            VendorAddressRule rule = new VendorAddressRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView3));

            gridView3.GridControl.DataSource = dt;
            gridView3.GridControl.Show();
        }

        /// <summary>
        /// 绑定客户联系人
        /// </summary>
        private void BindGrid()
        {
            VendorContactRule rule = new VendorContactRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 绑定客户归属业务员
        /// </summary>
        private void BindGrid2()
        {

            VendorSaleOPRule rule = new VendorSaleOPRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView2));
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }


        private void BindGrid4()
        {

            VendorNewsRule rule = new VendorNewsRule();
            DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView4));
            
            
            gridView4.GridControl.DataSource = dt;
            gridView4.GridControl.Show();

           
        }




        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            VendorRule rule = new VendorRule();
            Vendor entity =GetVendor();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(gridControl3, p_Flag);
            drpVendorLevel.Text = SysConvert.ToString(ProductParamSet.GetStrValueByID(5025));
            
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5021)))//客户编号自动生成
            {
                ProductCommon.FormNoCtlEditSet(txtVendorID, "Data_Vendor", "VendorID", this.FormListAID, p_Flag);
            }
        }

        public override string SetToolButtonPosStatus(string p_IDValue, string p_TableName)
        {
            if (DutyViewFlg && !FParamConfig.LoginHTFlag)
            {
                return SetToolButtonPosStatus(p_IDValue, p_TableName, "ID", "AND InSaleOP="+SysString.ToDBString(FParamConfig.LoginID));
            }
            else
            {
                return base.SetToolButtonPosStatus(p_IDValue, p_TableName);
            }
        }
        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {

            this.HTDataTableName = "Data_Vendor";
            this.HTDataDts = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[3] { gridView2, gridView3, gridView4 };
            this.SetPosCondition = " AND VendorTypeID IN(0," + this.FormListAID + ")";
            Common.BindDOP(drpInSaleOP, true);//绑定开发业务员
            //Common.BindDVendorType(drpVendorTypeID, true);//绑定客户类型

            Common.BindVendorType(drpVendorTypeID, 0, false);
            Common.BindPayMethod(drpPayMothodFlag, true);

            SetTabIndex(0, groupControlMainten);
            Common.BindOP(drpOPID, true);
         
            Common.BindPicNum(drpPicNum, true);
            if (FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核2))
            {
                DutyViewFlg = true;
            }

            Common.BindCLS(drpVendorLevel, "Data_Vendor", "VendorLevel", true);
           // DutyViewFlg = FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核2);
            SetVendorShow();

        }

        private void SetVendorShow()
        {
            //switch (FormListAID)
            //{
            //    case (int)EnumVendorType.工厂:
            //        lbVendorAttn.Text = "工厂简称";
            //        lbVendorEn.Text = "工厂英文名";
            //        lbVendorID.Text = "工厂编号";
            //        lbVendorName.Text = "工厂全称";
            //        break;

            //    case (int)EnumVendorType.检测机构:
            //        lbVendorAttn.Text = "检测机构简称";
            //        lbVendorEn.Text = "检测机构英文名";
            //        lbVendorID.Text = "检测机构编号";
            //        lbVendorName.Text = "检测机构全称";
            //        break;

            //    case (int)EnumVendorType.客户:
            //        lbVendorAttn.Text = "客户简称";
            //        lbVendorEn.Text = "客户英文名";
            //        lbVendorID.Text = "客户编号";
            //        lbVendorName.Text = "客户全称";
            //        break;

            //    case (int)EnumVendorType.快递公司:
            //        lbVendorAttn.Text = "快递公司简称";
            //        lbVendorEn.Text = "快递公司英文名";
            //        lbVendorID.Text = "快递公司编号";
            //        lbVendorName.Text = "快递公司全称";
            //        break;

            //    case (int)EnumVendorType.物流公司:
            //        lbVendorAttn.Text = "物流公司简称";
            //        lbVendorEn.Text = "物流公司英文名";
            //        lbVendorID.Text = "物流公司编号";
            //        lbVendorName.Text = "物流公司全称";
            //        break;

            //}
        }

        /// <summary>
        /// 新增初始化
        /// </summary>
        public override void IniInsertSet()
        {
            //drpVendorTypeID.EditValue = FormListAID;
            SetCheckVendorTypeDefault(drpVendorTypeID);
            drpInSaleOP.EditValue = FParamConfig.LoginID;
            drpUseableFlag.EditValue = 1;
            txtVendorID_DoubleClick(null, null);
            txtInDate.DateTime = DateTime.Now.Date;

            for (int i = 0; i < itemstr.Length; i++)
            {
                {
                    gridView4.SetRowCellValue(i, "Item", itemstr[i].ToString());
                }
            }
            
        }

       
        #endregion

        #region 新增修改删除
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtVendorID.Text.Trim() == "")
            {
                this.ShowMessage("请输入编码");
                txtVendorID.Focus();
                return false;
            }

            if (txtVendorAttn.Text.Trim() == "")
            {
                this.ShowMessage("请输入简称");
                txtVendorAttn.Focus();
                return false;
            }
            if (txtVendorName.Text.Trim() == "")
            {
                this.ShowMessage("请输入全称");
                txtVendorName.Focus();
                return false;
            }
            //if (txtContact.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入联系人");
            //    txtContact.Focus();
            //    return false;
            //}
            //if (txtTel.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入手机");
            //    txtTel.Focus();
            //    return false;
            //}

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            VendorRule rule = new VendorRule();
            Vendor entity = GetVendor();
            VendorContact[] entityVendorContact = GetVendorContact();
            VendorSaleOP[] entityVendorSaleOP = GetVendorSaleOP();
            VendorAddress[] entityAddress = GetVendorAddress();
            VendorNews[] entityNews =GetVendorNews();
            ArrayList entityVendorType = GetEntityDtsVendorType(drpVendorTypeID);
            rule.RAdd(entity, entityVendorContact, entityVendorSaleOP, entityAddress, entityNews, entityVendorType);
            return entity.ID;
            
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            VendorRule rule = new VendorRule();
            Vendor entity = GetVendor();
            VendorContact[] entityVendorContact = GetVendorContact();
            VendorSaleOP[] entityVendorSaleOP = GetVendorSaleOP();
            VendorAddress[] entityAddress = GetVendorAddress();
            VendorNews[] entityNews = GetVendorNews();
            ArrayList entityVendorType = GetEntityDtsVendorType(drpVendorTypeID);
            rule.RUpdate(entity, entityVendorContact, entityVendorSaleOP, entityAddress, entityNews, entityVendorType);
        }

        private VendorAddress[] GetVendorAddress()
        {
            int Num = 0;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                if (SysConvert.ToString(gridView3.GetRowCellValue(i, "Address")) != string.Empty)
                {
                    Num++;
                }
            }
            VendorAddress[] entitydts = new VendorAddress[Num];
            int index = 0;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                if (SysConvert.ToString(gridView3.GetRowCellValue(i, "Address")) != string.Empty)
                {
                    entitydts[index] = new VendorAddress();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();


                    entitydts[index].Address = SysConvert.ToString(gridView3.GetRowCellValue(i, "Address"));
                   

                    index++;

                }
            }
            return entitydts;
        }


        private VendorNews[] GetVendorNews()
        {
            int Num = 0;
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                if (SysConvert.ToString(gridView4.GetRowCellValue(i, "Item")) != string.Empty)
                {
                    Num++;
                }
            }
            VendorNews[] entitydts = new VendorNews[Num];
            int index = 0;
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                if (SysConvert.ToString(gridView4.GetRowCellValue(i, "Item")) != string.Empty)
                {
                    entitydts[index] = new VendorNews();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();

                    entitydts[index].Item = SysConvert.ToString(gridView4.GetRowCellValue(i, "Item"));
                    entitydts[index].ItemPrice = SysConvert.ToString(gridView4.GetRowCellValue(i, "ItemPrice"));


                    index++;

                }
            }
            return entitydts;
        }

       
        /// <summary>
        /// 获取客户实体
        /// </summary>
        /// <returns></returns>
        private Vendor GetVendor()
        {
            Vendor entity = new Vendor();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.VendorID = txtVendorID.Text.Trim();
            entity.VendorAttn = txtVendorAttn.Text.Trim();
            entity.VendorName = txtVendorName.Text.Trim();
            entity.VendorNameEn = txtVendorNameEn.Text.Trim();
            //entity.VendorTypeID =SysConvert.ToInt32(drpVendorTypeID.EditValue);
            entity.VendorTypeID = this.FormListAID;//GetCheckVendorType(drpVendorTypeID);

            entity.Tel = txtTel.Text.Trim();
            entity.Fax = txtFax.Text.Trim();
            entity.Address = txtAddress.Text.Trim();
            entity.UseableFlag = SysConvert.ToInt32(drpUseableFlag.EditValue);
            entity.Password = txtPassword.Text.Trim();
            entity.Country = txtCountry.Text.Trim();
            entity.InDate = txtInDate.DateTime;
            entity.InSaleOP = SysConvert.ToString(drpInSaleOP.EditValue);
            entity.Area = txtArea.Text.Trim();
            entity.WebUrl = txtWebUrl.Text.Trim();
            entity.WebFlag = SysConvert.ToInt32(drpWebFlag.EditValue);
            entity.QueryAccount = txtQueryAccount.Text.Trim();
            entity.Free1 = SysConvert.ToString(txtFree1.Text.Trim());
            entity.Free2 = SysConvert.ToString(txtFree2.Text.Trim());
            entity.Contact = txtContact.Text.Trim();

            entity.CHBrand = txtCHBrand.Text.Trim();
            entity.ENBrand = txtENBrand.Text.Trim();
            entity.age1 = SysConvert.ToInt32(txtAge1.Text.Trim());
            entity.age2 = SysConvert.ToInt32(txtAge2.Text.Trim());
            entity.SJFG = txtSJFG.Text.Trim();
            entity.MainSale = txtMainSale.Text.Trim();
            entity.MPrice1 = txtMPrice1.Text.Trim();
            entity.MPrice2 = txtMPrice2.Text.Trim();
            entity.MPrice3 = txtMPrice3.Text.Trim();
            entity.MPrice4 = txtMPrice4.Text.Trim();
            entity.PF = SysConvert.ToInt32(chkPF.Checked);
            entity.DL = SysConvert.ToInt32(chkDL.Checked);
            entity.ZY = SysConvert.ToInt32(chkZY.Checked);
            entity.VendorLevel = SysConvert.ToString(drpVendorLevel.EditValue);
            entity.LimitAmount = SysConvert.ToDecimal(txtLimitAmount.Text, 2);
            entity.SHXAmount = SysConvert.ToDecimal(txtSHXAmount.Text, 2);
            entity.LimitDayNum = SysConvert.ToInt32(txtLimitDayNum.Text);

            entity.QQ = txtQQ.Text.Trim();
            entity.Alibaba = txtAlibaba.Text.Trim();
            entity.MainBusiness = txtMainBusiness.Text.Trim();
            entity.ZhangHao = txtZhangHao.Text.Trim();

            entity.PayMethodFlag = SysConvert.ToInt32(drpPayMothodFlag.EditValue);

            entity.EMail = txtEMail.Text.Trim();
            entity.Province = txtProvince.Text.Trim();
            entity.Mobile = txtMobile.Text.Trim();


            return entity;

        }

        /// <summary>
        /// 获取客户联系人实体
        /// </summary>
        /// <returns></returns>
        private VendorContact[] GetVendorContact()
        {
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "Name")) != string.Empty)
                {
                    Num++;
                }
            }
            VendorContact[] entitydts = new VendorContact[Num];
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToString(gridView1.GetRowCellValue(i, "Name")) != string.Empty)
                {
                    entitydts[index] = new VendorContact();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();


                    entitydts[index].Code = SysConvert.ToString(gridView1.GetRowCellValue(i, "Code"));
                    entitydts[index].Name = SysConvert.ToString(gridView1.GetRowCellValue(i, "Name"));
                    entitydts[index].FL = SysConvert.ToString(gridView1.GetRowCellValue(i, "FL"));
                    entitydts[index].TEL = SysConvert.ToString(gridView1.GetRowCellValue(i, "TEL"));
                    entitydts[index].FAX = SysConvert.ToString(gridView1.GetRowCellValue(i, "FAX"));
                    entitydts[index].Mobil = SysConvert.ToString(gridView1.GetRowCellValue(i, "Mobil"));
                    entitydts[index].SubTel = SysConvert.ToString(gridView1.GetRowCellValue(i, "SubTel"));
                    entitydts[index].Dep = SysConvert.ToString(gridView1.GetRowCellValue(i, "Dep"));
                    entitydts[index].Remark = SysConvert.ToString(gridView1.GetRowCellValue(i, "Remark"));
                    entitydts[index].Birthday = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "Birthday"));
                    entitydts[index].SpecialDay = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "SpecialDay"));

                    entitydts[index].TELTwo = SysConvert.ToString(gridView1.GetRowCellValue(i, "TELTwo")); //邱超添加
                    entitydts[index].TELThree = SysConvert.ToString(gridView1.GetRowCellValue(i, "TELThree"));
                    entitydts[index].QQ = SysConvert.ToString(gridView1.GetRowCellValue(i, "QQ"));
                    entitydts[index].Email = SysConvert.ToString(gridView1.GetRowCellValue(i, "Email"));
                    entitydts[index].FreeStr = SysConvert.ToString(gridView1.GetRowCellValue(i, "FreeStr"));
              

                   
                    index++;
                    
                }
            }
            return entitydts;
        }


        /// <summary>
        /// 获取客户业务归属
        /// </summary>
        /// <returns></returns>
        private VendorSaleOP[] GetVendorSaleOP()
        {
            int Num = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "OPID")) != string.Empty)
                {
                    Num++;
                }
            }
            VendorSaleOP[] entitydts = new VendorSaleOP[Num];
            int index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "OPID")) != string.Empty)
                {
                    entitydts[index] = new VendorSaleOP();
                    entitydts[index].MainID = HTDataID;
                    entitydts[index].Seq = i + 1;
                    entitydts[index].SelectByID();


                    entitydts[index].OPID = SysConvert.ToString(gridView2.GetRowCellValue(i, "OPID"));
                    entitydts[index].Remark = SysConvert.ToString(gridView2.GetRowCellValue(i, "Remark"));
                    entitydts[index].ContactTime = SysConvert.ToDateTime(gridView2.GetRowCellValue(i, "ContactTime"));
                    entitydts[index].ContactDts = SysConvert.ToString(gridView2.GetRowCellValue(i, "ContactDts"));
                    entitydts[index].DFContact = SysConvert.ToString(gridView2.GetRowCellValue(i, "DFContact"));
                    entitydts[index].HXTrack = SysConvert.ToString(gridView2.GetRowCellValue(i, "HXTrack"));
                    entitydts[index].FreeStr = SysConvert.ToString(gridView2.GetRowCellValue(i, "FreeStr"));
                    
                    index++;

                }
            }
            return entitydts;
        }


        
        #endregion

        private void btnPicNewBrowsing_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("请先保存数据");
                    return;
                }
                if (SysConvert.ToString(drpPicNum.EditValue) == "")
                {
                    this.ShowMessage("请选择上传图片类型");
                    drpPicNum.Focus();
                    return;
                }

                openFileDialog1.Filter = "JPG文件(*.jpg)|*.jpg|GIF文件(*.gif)|*.gif|BMP文件(*.bmp)|*.bmp|全部文件(*.*)|*.*";
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    int PicNum = SysConvert.ToInt32(drpPicNum.EditValue);
                    string filenamerount = openFileDialog1.FileName;
                    switch (PicNum)
                    {
                        case 1:

                            img1.Image = Image.FromFile(filenamerount);
                            break;
                        case 2:

                            img2.Image = Image.FromFile(filenamerount);
                            break;
                        case 3:

                            img3.Image = Image.FromFile(filenamerount);
                            break;
                        case 4:

                            img4.Image = Image.FromFile(filenamerount);
                            break;
                        case 5:

                            img5.Image = Image.FromFile(filenamerount);
                            break;
                        default:
                            break;
                    }


                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnPicSave_Click(object sender, EventArgs e)
        {

            if (HTDataID != 0)
            {
                if (SysConvert.ToInt32(drpPicNum.EditValue) == 0)
                {
                    this.ShowMessage("请选择图片存放位置");
                    drpPicNum.Focus();
                    return;
                }
                VendorFileRule rule = new VendorFileRule();
                VendorFile entity = GetSVendorFile();
                rule.RSave(entity, HTDataID);
                this.ShowInfoMessage("图片存放成功");
                BindPic();
            }
            else
            {
                this.ShowMessage("请先保存基础资料");
                return;
            }
        }

        private VendorFile GetSVendorFile()
        {
            VendorFile entity = new VendorFile();
            int picNum = SysConvert.ToInt32(drpPicNum.EditValue);
            switch (picNum)
            {
                case 1:
                    if (img1.Image != null)
                    {

                        entity.Context = TemplatePic.ImageToByte(img1.Image);
                        entity.FileTypeID = picNum;
                        entity.FileLength = SysConvert.ToDecimal(img1.Image.Width);
                        entity.UploadOPID = FParamConfig.LoginID;
                        entity.UploadTime = DateTime.Now.Date;
                        entity.Remark = txtRemark1.Text.Trim();

                    }
                    break;
                case 2:
                    if (img2.Image != null)
                    {

                        entity.Context = TemplatePic.ImageToByte(img2.Image);
                        entity.FileTypeID = picNum;
                        entity.FileLength = SysConvert.ToDecimal(img2.Image.Width);
                        entity.UploadOPID = FParamConfig.LoginID;
                        entity.UploadTime = DateTime.Now.Date;
                        entity.Remark = txtRemark2.Text.Trim();

                    }
                    break;
                case 3:
                    if (img3.Image != null)
                    {

                        entity.Context = TemplatePic.ImageToByte(img3.Image);
                        entity.FileTypeID = picNum;
                        entity.FileLength = SysConvert.ToDecimal(img3.Image.Width);
                        entity.UploadOPID = FParamConfig.LoginID;
                        entity.UploadTime = DateTime.Now.Date;
                        entity.Remark = txtRemark3.Text.Trim();
                    }
                    break;
                case 4:
                    if (img4.Image != null)
                    {

                        entity.Context = TemplatePic.ImageToByte(img4.Image);
                        entity.FileTypeID = picNum;
                        entity.FileLength = SysConvert.ToDecimal(img4.Image.Width);
                        entity.UploadOPID = FParamConfig.LoginID;
                        entity.UploadTime = DateTime.Now.Date;
                        entity.Remark = txtRemark4.Text.Trim();
                    }
                    break;
                case 5:
                    if (img5.Image != null)
                    {

                        entity.Context = TemplatePic.ImageToByte(img5.Image);
                        entity.FileTypeID = picNum;
                        entity.FileLength = SysConvert.ToDecimal(img5.Image.Width);
                        entity.UploadOPID = FParamConfig.LoginID;
                        entity.UploadTime = DateTime.Now.Date;
                        entity.Remark = txtRemark5.Text.Trim();
                    }
                    break;
                default:
                    break;
            }
            return entity;

        }

        private void btnPicDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("请先保存客户主数据");
                    return;
                }
                if (SysConvert.ToInt32(drpPicNum.EditValue) == 0)
                {
                    this.ShowMessage("请选择删除的图片");
                    drpPicNum.Focus();
                    return;
                }
                string sql = "DELETE Data_VendorFile WHERE MainID="+HTDataID;
                sql += " AND Seq="+SysConvert.ToInt32(drpPicNum.EditValue);
                SysUtils.ExecuteNonQuery(sql);
                BindPic();
                this.ShowInfoMessage("图片删除成功");
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

        private void btnAddNews_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < itemstr.Length; i++)
            {
                {
                    gridView4.SetRowCellValue(i, "Item", itemstr[i].ToString());
                }
            }
        }

        /// <summary>
        /// 控制自动生成客户编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVendorID_DoubleClick(object sender, EventArgs e)
        {
            try
            {


                if (HTFormStatus == FormStatus.新增 && SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5021)))
                {
                    ProductCommon.FormNoIniSet(txtVendorID, "Data_Vendor", "VendorID", this.FormListAID);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void txtVendorAttn_EditValueChanged(object sender, EventArgs e)
        {
            txtVendorNameEn.Text = Common.GetFirstPinyin(txtVendorAttn.Text.Trim());
        }

        

       

       

        

       
    }
}