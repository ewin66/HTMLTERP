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

        #region ����
        private const string APack = "APack";
        private const string BOutWH = "BOutWH";
        #endregion
        /// <summary>
        /// ��ȡ�豸������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadISN_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckExistenceISN())
                {
                    if (DialogResult.Yes != this.ShowConfirmMessage("��ǰ��δ�������ݣ�ϵͳ�����ȴ���ǰ�ε��룬�Ƿ�Ҫ�������룿"))
                    {
                        return;
                    }
                }
                List<string> ScanISN = ReadBoxISN.ReadSCanISN();//��ȡ�豸������
                foreach (string ISN in ScanISN)
                {
                    if(ISN==APack||ISN==BOutWH)
                    {
                        continue;
                    }
                    if (!CheckBoxISN.CheckUse(ISN))//У�������Ƿ�
                    {
                        return;
                    }
                    if (!CheckBoxISN.CheckPackISN(ISN))//У�������Ƿ��Ѿ������
                    {
                        return;
                    }
                  
                }
                InsertISN(ScanISN);//���뵽���ݿ���
                ClearScanISN();//����豸������
                BindScanISN();//�󶨶�������

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// �������������
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
            //if (DialogResult.Yes != this.ShowConfirmMessage("���Ϊ���ɻָ�������ȷ�����"))
            //{
            //    return;
            //}

            ReadINIFile read = new ReadINIFile("ParamSet.ini");
            string defaultPath = "";// new ParamSetRule().RShowStr((int)ParamSet.ɨ�������ļ���Ĭ��·��);
            if (defaultPath == string.Empty)
            {
                defaultPath = @"D:\DATA.TXT";
            }
            string ScanPath = read.ReadString("ScanBarCode", "ScanPath", defaultPath); //Ĭ��·��

            SysFile.DeleteFile(defaultPath);
        }

        /// <summary>
        /// У���Ƿ���δ���������
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
        /// ��δ����ɨ����������
        /// </summary>
        private void BindScanISN()
        {
            string sql = "SELECT * FROM WO_ISNTemp WHERE Status=1 ORDER BY Sort ASC ";
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanInWH_Load(object sender, EventArgs e)
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//������UI
            ProcessGrid.BindGridColumn(gridView2, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView2, this.FormListAID, this.FormListBID);//������UI
            ProcessGrid.BindGridColumn(gridView3, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView3, this.FormListAID, this.FormListBID);//������UI
            
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
        /// װ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPack_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM WO_ISNTemp WHERE Status=1 ORDER BY Sort ASC ";
            DataTable dt = SysUtils.Fill(sql);//��ȡ��װ������
            DataTable dttemp = new DataTable();
            if (CheckISNRule(dt, out dttemp))//����У��ϸ������װ����
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
        /// У���������
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
            foreach (DataRow dr in p_ISN.Rows)//ѭ������δ�����������������
            {
               
                if (Index == 1)//����ǵ�һ��
                {
                    if (dr["ISN"].ToString() == BOutWH)//����ǳ����־
                    {
                        this.ShowMessage("���ζ�ȡ�����������۳�������ݣ��뵽����������");

                        return false;
                    }
                    if (dr["ISN"].ToString() != APack)//���������������־����Ҫ����ж�
                    {
                        if (dr["ISN"].ToString().Length != 12 || dr["ISN"].ToString().Substring(0, 1) != "S")//������ǳ���������򱨴���
                        {
                            this.ShowMessage("���ζ�ȡ����������쳣������" + Index + dr["ISN"].ToString());

                            return false;
                        }
                        //��ʾ�Զ����Ͽ�ʼװ���־
                        if (DialogResult.Yes != this.ShowConfirmMessage("ֱ�Ӽ�⵽��ƥ���룬δ�ҵ�������־�����Ƿ��Զ����ϰ�װ��⣿"))
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
                    else//����ǰ�װ����־����
                    {
                        dr["PackIndex"] = PackIndex;
                        PackIndex++;
                        dr["Sort"] = Index;
                        Index++;
                        p_dttemp.ImportRow(dr);
                    }

                }
                else//������ǵ�һ������
                {

                    if (dr["ISN"].ToString() == BOutWH)//����ǳ����־
                    {
                        this.ShowMessage("���ζ�ȡ�����������۳�������ݣ��뵽����������");

                        return false;
                    }
                    if (dr["ISN"].ToString() != APack)//���������������־��һ���ǲ�ƥ���룬��Ų��䲼ƥ�ű�
                    {
                        if (dr["ISN"].ToString().Length != 12 || dr["ISN"].ToString().Substring(0, 1) != "S")//������ǳ���������򱨴���
                        {
                            this.ShowMessage("���ζ�ȡ����������쳣������" + Index + dr["ISN"].ToString());

                            return false;
                        }
                        dr["PackIndex"] = PackIndex;
                        dr["Sort"] = Index;
                        Index++;
                        p_dttemp.ImportRow(dr);
                    }
                    else//����ǰ�װ����־���룬��ֱ�ӵ���һ��
                    {
                        dr["PackIndex"] = PackIndex;
                        PackIndex++;
                        dr["Sort"] = Index;
                        Index++;
                        p_dttemp.ImportRow(dr);
                    }
                }
            }
            //��ʾ��װ���������ƥ��
            if (DialogResult.Yes != this.ShowConfirmMessage("���β�����" + (PackIndex - 1) + "��" + (Index - PackIndex - 1) + "ƥ��,�Ƿ��ύ�����"))
            {
                return false;
            }
            return true;
        }

        #region ��װ��

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
        /// ��У��ϸ������ְ�����������״̬����Ϊ�Ѿ�װ��,�����ö�Ӧ��������������λ��
        /// </summary>
        /// <param name="p_PackISN"></param>
        /// <param name="sqlTrans"></param>
        private void InsertPackISN(DataTable p_PackISN, IDBTransAccess sqlTrans)
        {
            PackISNRule rule = new PackISNRule();
            PackISNDtsRule rule2 = new PackISNDtsRule();
            DataRow[] packs = p_PackISN.Select("ISN=" + SysString.ToDBString(APack));//���ҵ���Ӧ������
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
        /// ��ȡ����İ�װ���
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