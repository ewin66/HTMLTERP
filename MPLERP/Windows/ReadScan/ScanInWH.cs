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
using DevExpress.XtraGrid.Views.Base;


namespace MLTERP
{
    public partial class ScanInWH : BaseForm
    {
        public ScanInWH()
        {
            InitializeComponent();
        }

        #region 变量
        private const string APack = "APack";
        private const string BOutWH = "BOutWH";
        #endregion
        /// <summary>
        /// 读取设备中数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadISN_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckExistenceISN())
                {
                    if (DialogResult.Yes != this.ShowConfirmMessage("有前次未处理数据，系统建议先处理前次导入，是否要继续导入？"))
                    {
                        return;
                    }
                }
                List<string> ScanISN = ReadBoxISN.ReadSCanISN();//读取设备中数据
                foreach (string ISN in ScanISN)
                {
                    if(ISN==APack||ISN==BOutWH)
                    {
                        continue;
                    }
                    if (!CheckBoxISN.CheckUse(ISN))//校验条码是否
                    {
                        return;
                    }
                    if (!CheckBoxISN.CheckPackISN(ISN))//校验条码是否已经打包了
                    {
                        return;
                    }
                  
                }
                InsertISN(ScanISN);//插入到数据库中
                ClearScanISN();//清除设备中数据
                BindScanISN();//绑定读入数据

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 插入读出的条码
        /// </summary>
        /// <param name="ScanISN"></param>
        private void InsertISN(List<string> ScanISN)
        {
            try
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();
                    ISNTempRule rule = new ISNTempRule();
                    int index = 1;
                    foreach (string ISN in ScanISN)
                    {
                        ISNTemp entity = new ISNTemp(sqlTrans);
                        entity.ISN = ISN;
                        entity.Status = 1;
                        entity.Sort = index;
                        entity.ImportTime = DateTime.Now;
                        rule.RAdd(entity, sqlTrans);
                        index++;
                    }
                    sqlTrans.CommitTrans();
                }
                catch (Exception TE)
                {
                    sqlTrans.RollbackTrans();
                    throw TE;
                }
            }
            catch (BaseException)
            {
                throw;
            }
            catch (Exception E)
            {
                throw new BaseException(E.Message);
            }
        }

        private void ClearScanISN()
        {
            //if (DialogResult.Yes != this.ShowConfirmMessage("清除为不可恢复操作，确定清除"))
            //{
            //    return;
            //}

            ReadINIFile read = new ReadINIFile("ParamSet.ini");
            string defaultPath = "";// new ParamSetRule().RShowStr((int)ParamSet.扫描条码文件的默认路径);
            if (defaultPath == string.Empty)
            {
                defaultPath = @"D:\DATA.TXT";
            }
            string ScanPath = read.ReadString("ScanBarCode", "ScanPath", defaultPath); //默认路径

            SysFile.DeleteFile(defaultPath);
        }

        /// <summary>
        /// 校验是否有未处理的条码
        /// </summary>
        /// <returns></returns>
        private bool CheckExistenceISN()
        {
            string sql = "SELECT ID FROM WO_ISNTemp WHERE Status=1";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 绑定未处理扫描数据数据
        /// </summary>
        private void BindScanISN()
        {
            string sql = "SELECT * FROM WO_ISNTemp WHERE Status=1 ORDER BY Sort ASC ";
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanInWH_Load(object sender, EventArgs e)
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//设置列UI
            ProcessGrid.BindGridColumn(gridView2, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView2, this.FormListAID, this.FormListBID);//设置列UI
            ProcessGrid.BindGridColumn(gridView3, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView3, this.FormListAID, this.FormListBID);//设置列UI
            
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);
            gridViewBindEventA1(gridView2);
            gridView2.OptionsBehavior.ShowEditorOnMouseUp = false;
            BindScanISN();
            BindPack();
        }

        private void gridViewRowChanged1(object sender)
        {
            try
            {
                BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                int ID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle,"ID"));
                BindPackDts(ID);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 装箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPack_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM WO_ISNTemp WHERE Status=1 ORDER BY Sort ASC ";
            DataTable dt = SysUtils.Fill(sql);//读取待装箱数据
            DataTable dttemp = new DataTable();
            if (CheckISNRule(dt, out dttemp))//条码校验合格后插入包装表中
            {
                try
                {
                    IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                    try
                    {
                        sqlTrans.OpenTrans();

                        InsertPackISN(dttemp, sqlTrans);

                        sqlTrans.CommitTrans();
                    }
                    catch (Exception TE)
                    {
                        sqlTrans.RollbackTrans();
                        throw TE;
                    }
                }
                catch (BaseException)
                {
                    throw;
                }
                catch (Exception E)
                {
                    throw new BaseException(E.Message);
                }
            }

            BindScanISN();
            BindPack();

        }

        /// <summary>
        /// 校验条码规则
        /// </summary>
        /// <returns></returns>
        private bool CheckISNRule(DataTable p_ISN, out DataTable p_dttemp)
        {
            p_dttemp = p_ISN.Clone();
            int PackIndex = 1;
            int Index = 1;
            if (!p_dttemp.Columns.Contains("PackIndex"))
            {
                p_dttemp.Columns.Add("PackIndex", typeof(int));
            }
            if (!p_ISN.Columns.Contains("PackIndex"))
            {
                p_ISN.Columns.Add("PackIndex", typeof(int));
            }
            foreach (DataRow dr in p_ISN.Rows)//循环本次未处理条码整理好数据
            {
               
                if (Index == 1)//如果是第一个
                {
                    if (dr["ISN"].ToString() == BOutWH)//如果是出库标志
                    {
                        this.ShowMessage("本次读取的数据是销售出库的数据，请到出库界面操作");

                        return false;
                    }
                    if (dr["ISN"].ToString() != APack)//如果不是入库操作标志则需要检查判断
                    {
                        if (dr["ISN"].ToString().Length != 12 || dr["ISN"].ToString().Substring(0, 1) != "S")//如果不是常规的条码则报错返回
                        {
                            this.ShowMessage("本次读取的条码出现异常条码行" + Index + dr["ISN"].ToString());

                            return false;
                        }
                        //提示自动补上开始装箱标志
                        if (DialogResult.Yes != this.ShowConfirmMessage("直接检测到布匹条码，未找到操作标志条码是否自动补上包装入库？"))
                        {
                            return false;
                        }
                        DataRow drnew = p_dttemp.NewRow();
                        drnew["PackIndex"] = PackIndex;
                        PackIndex++;
                        drnew["ISN"] = APack;
                        drnew["Sort"] = Index;
                        Index++;
                        p_dttemp.Rows.Add(drnew);
                    }
                    else//如果是包装入库标志条码
                    {
                        dr["PackIndex"] = PackIndex;
                        PackIndex++;
                        dr["Sort"] = Index;
                        Index++;
                        p_dttemp.ImportRow(dr);
                    }

                }
                else//如果不是第一个条码
                {

                    if (dr["ISN"].ToString() == BOutWH)//如果是出库标志
                    {
                        this.ShowMessage("本次读取的数据是销售出库的数据，请到出库界面操作");

                        return false;
                    }
                    if (dr["ISN"].ToString() != APack)//如果不是入库操作标志则一定是布匹条码，箱号不变布匹号变
                    {
                        if (dr["ISN"].ToString().Length != 12 || dr["ISN"].ToString().Substring(0, 1) != "S")//如果不是常规的条码则报错返回
                        {
                            this.ShowMessage("本次读取的条码出现异常条码行" + Index + dr["ISN"].ToString());

                            return false;
                        }
                        dr["PackIndex"] = PackIndex;
                        dr["Sort"] = Index;
                        Index++;
                        p_dttemp.ImportRow(dr);
                    }
                    else//如果是包装入库标志条码，则直接到下一箱
                    {
                        dr["PackIndex"] = PackIndex;
                        PackIndex++;
                        dr["Sort"] = Index;
                        Index++;
                        p_dttemp.ImportRow(dr);
                    }
                }
            }
            //提示共装多少箱多少匹布
            if (DialogResult.Yes != this.ShowConfirmMessage("本次操作共" + (PackIndex - 1) + "箱" + (Index - PackIndex - 1) + "匹布,是否提交打包？"))
            {
                return false;
            }
            return true;
        }

        #region 包装绑定

        private void BindPack()
        {
            string sql = "SELECT 0 SelectFlag,* FROM WO_PackISN WHERE ISNULL(SubmitFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }

        private void BindPackDts(int p_ID)
        {
            string sql = "SELECT * FROM WO_PackISNDts WHERE ID="+p_ID;
            DataTable dt = SysUtils.Fill(sql);
            gridView3.GridControl.DataSource = dt;
            gridView3.GridControl.Show();
        }

        #endregion
        /// <summary>
        /// 将校验合格的条码分包，并将条码状态设置为已经装箱,并设置对应的条码所在箱子位置
        /// </summary>
        /// <param name="p_PackISN"></param>
        /// <param name="sqlTrans"></param>
        private void InsertPackISN(DataTable p_PackISN, IDBTransAccess sqlTrans)
        {
            PackISNRule rule = new PackISNRule();
            PackISNDtsRule rule2 = new PackISNDtsRule();
            DataRow[] packs = p_PackISN.Select("ISN=" + SysString.ToDBString(APack));//先找到对应的箱数
            foreach (DataRow dr in packs)
            {
                PackISN pack = new PackISN(sqlTrans);
                pack.PackDate = DateTime.Now;
                pack.PackOPID = FParamConfig.LoginName;
                pack.PackISNS = GetPackCode("P" + pack.PackDate.ToString("yyMMdd"), sqlTrans);//BaseCode;
                rule.RAdd(pack, sqlTrans);
                DataRow[] packISN = p_PackISN.Select("ISN<>" + SysString.ToDBString(APack) + " AND PackIndex=" + SysString.ToDBString(dr["PackIndex"].ToString()));
                int Seq = 1;
                foreach (DataRow drdts in packISN)
                {
                    PackISNDts dts = new PackISNDts(sqlTrans);
                    dts.ID = pack.ID;
                    dts.Seq = Seq;
                    Seq++;
                    dts.ISN = drdts["ISN"].ToString();
                    rule2.RAdd(dts, sqlTrans);
                    string ISN = "UPDATE WO_Fabric SET PackFlag=1,BoxID=" + pack.ID + " WHERE ISN=" + SysString.ToDBString(dts.ISN);
                    sqlTrans.ExecuteNonQuery(ISN);
                }
            }

            string sql = "UPDATE WO_ISNTemp SET Status=2 WHERE Status=1";
            sqlTrans.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取当天的包装箱号
        /// </summary>
        /// <param name="BaseCode"></param>
        /// <returns></returns>
        private string GetPackCode(string BaseCode, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT MAX(PackISNS) PackISNS FROM WO_PackISN WHERE PackISNS LIKE" + SysString.ToDBString(BaseCode+"%");
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count!=0)
            {
                string packCode = dt.Rows[0]["PackISNS"].ToString();
                if (packCode == string.Empty)
                {
                    return BaseCode + "0001";
                }
                else
                {
                    int Index = SysConvert.ToInt32(packCode.Substring(7, 4));

                    return BaseCode + SysString.LongToStr(Index + 1, 4);
                }
            }

            return BaseCode+"0001";
        }


        private void btnInWH_Click(object sender, EventArgs e)
        {

        }

      
    }
}