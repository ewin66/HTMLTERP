using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HttSoft.Framework;
using HttSoft.FrameFunc;  
using Microsoft.Win32;


namespace HTERP
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                SysStart();//启动
                
                /*检测自动更新标志BEGIN*/
                bool outCheckUpdateFlag = false;
                if (FParamConfig.SystemDBConnType == 1)//如果是传统模式检测自动更新
                {
                    CheckAutoUpdate(out outCheckUpdateFlag);
                    if (outCheckUpdateFlag)
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    outCheckUpdateFlag=false;
                }
                /*检测自动更新标志END*/
                if (!outCheckUpdateFlag)
                {
                    frmLogin3 frmLogin = new frmLogin3();//显示登录窗体
                    frmLogin.ShowDialog();

                    if (!FParamConfig.LoginFlag)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        SysStartEnd();
                        Application.EnableVisualStyles(); //样式设置 
                        //Application.SetCompatibleTextRenderingDefault(false); //样式设置 
                        frmSplash3 sp = new frmSplash3(); //启动窗体 
                        sp.Show(); //显示启动窗体 
                        context = new ApplicationContext();
                        context.Tag = sp;
                        Application.Idle += new EventHandler(Application_Idle); //注册程序运行空闲去执行主程序窗体相应初始化代码 
                        Application.Run(context);

                        //Application.Run(new frmStart());
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("启动异常，系统退出" + Environment.NewLine + E.Message);
                Application.Exit();
            }
        }

        private static ApplicationContext context;

        //初始化等待处理函数 
        private static void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(Application_Idle);
            if (context.MainForm == null)
            {
                //Main mw = new Main();
                frmStart mw = new frmStart();
                context.MainForm = mw;
                mw.Init(); //主窗体要做的初始化事情在这里，该方法在主窗体里应该申明为public 
                frmSplash3 sp = (frmSplash3)context.Tag;
                sp.Close(); //关闭启动窗体 
                mw.Show(); //启动主程序窗体 
            }
        }
        /// <summary>
        /// 系统启动配置信息
        /// </summary>
        private static void SysStart()
        {
            FParamConfig.FormUIFlag = true;
            FParamConfig.SystemName = "恒泰ERP系统";
            FParamConfig.HTDBToolFlag = false;
            FParamConfig.SystemApType = 1;
            FParamConfig.Version = "1.0";//系统版本	
            FParamConfig.SystemTestDBFlag = true;

            FParamConfig.DBRegRoot = RegistryHive.CurrentUser;//当前用户
            FParamConfig.DBRegSubKey = "Software\\Httsoft\\ProductML";//注册表根路径

            FParamConfig.SystemSplashTitle = "恒泰面料ERP";
            FParamConfig.SystemSplashTitleEn = "Httsoft Fabric ERP";
            SystemConfiguration.SystemAPType = APType.Windows;//设置系统配置信息
            SystemConfiguration.SystemDBName = "数据库";//数据库名称
            SystemConfiguration.SystemDBType = DBType.MSSQL;//数据库类型
            SystemConfiguration.LanguageType = Language.Simplified;//程序语言
            SystemConfiguration.SystemMsgSource = MsgSourceType.Framework;//系统提示信息来源
            SystemConfiguration.FrameworkLogFile = "Log.txt";//出错文件Log位置
            SystemConfiguration.DevelopDate = new DateTime(2018,7,14);
            FParamConfig.QueryDayNum = 30;//设置查询日期间隔
            FParamConfig.QueryDayNum = 60;
            FParamConfig.GridRowNum = 150;
            FParamConfig.SystemDBConnType = 2;//配置文件方式 1/2:数据库/服务端
            FParamConfig.SysMessageType = 0;//消息提醒类型设置

            FrameCommon.UseNewOpenType = true;//启用新的打开方式

            frmStart frmicon = new frmStart();
            FParamConfig.SystemIcon = frmicon.Icon;
            frmicon.Dispose();
        }

        /// <summary>
        /// 自动更新
        /// </summary>
        private static void CheckAutoUpdate(out bool outflag)
        {
            if (!FCommon.SetDBFirst())//设置数据库连接串
            {
                //设置没有通过[检测是否没有读取到数据库服务器]

                MessageBox.Show("数据库连接失败");
                frmSetDB frm = new frmSetDB();
                frm.ShowDialog();
            }

            //if (FParamConfig.DBConnFlag == false)//判断数据库是否连接上了
            //{
            //    frmSetDB frm = new frmSetDB();
            //    frm.ShowDialog();
            //}

            outflag = false;

            if (FParamConfig.DBConnFlag)
            {
                string sql = "SELECT TOP 1 Version FROM Sys_Version WHERE AllowFlag='1' ORDER BY ReleaseDate DESC";//查找最新的版本
                System.Data.DataTable dt = SysUtils.Fill(sql);
                string lastversion = string.Empty;
                if (dt.Rows.Count != 0)
                {
                    lastversion = dt.Rows[0][0].ToString().ToUpper();//找出最新版程序
                }

                if (FParamConfig.Version.ToUpper() != lastversion)
                {
                    string StrExe = Application.StartupPath + @"\AutoUpdate.exe";
                    if (System.IO.File.Exists(StrExe))
                    {
                        outflag = true;
                        System.Diagnostics.Process.Start(StrExe);
                    }
                }
            }
        }


        /// <summary>
        /// 系统启动配置信息
        /// </summary>
        public  static void SysStartEnd()
        {
            FParamConfig.CompanyID = "公司";

            //string sql = string.Empty;
            //sql = "SELECT * FROM Sys_ParamSet WHERE ID BETWEEN 6001 AND  6050";//面料码单参数控件范围
            //HttSoft.UCFab.UCFabParamSet.FabUIParamSetDt = SysUtils.Fill(sql);

            #region 第二数据库
            SystemConfiguration.SystemDBNameSecond = "图片数据库";
            //SystemConfiguration.ConnectStringSecond = "server=198.168.6.235;database=HTERPPic;uid=sa;pwd=lt@2013";
            //SystemConfiguration.ConnectStringSecond = "server=HTTSOFT01;database=HTERPPic;uid=sa;pwd=sa";
            //SystemConfiguration.ConnectStringSecond = "server=192.168.0.202,1533;database=HTERPPic;uid=sa;pwd=sa.2005";
            //ParamSetRule rule = new ParamSetRule();
             
            //FParamConfig.CompanyID = "公司";
            //Common.InitCompanyType();
            //#region 第二数据库
            //SystemConfiguration.SystemDBNameSecond = "图片数据库";
            ////SystemConfiguration.ConnectStringSecond = "server=192.168.1.102;database=fserppic;uid=sa;pwd=sa";
            //ParamSetRule rule = new ParamSetRule();
            ////string secondserver = rule.RShowStrByID((int)ParamSetEnum.图片服务器名字);
            ////string seconddatabase = rule.RShowStrByID((int)ParamSetEnum.图片数据库名字);
            ////string seconduser = rule.RShowStrByID((int)ParamSetEnum.图片数据库用户名);
            ////string secondpassword = rule.RShowStr((int)ParamSetEnum.图片数据库密码);
            //SystemConfiguration.SystemDBNameSecond = "图片数据库";//数据库名称
           // SystemConfiguration.ConnectStringSecond = rule.RShowStrByCode((int)ParamSetEnum.图片数据库连接串);//"server=" + secondserver + ";database=" + seconddatabase + ";uid=" + seconduser + ";pwd=" + secondpassword;
            #endregion
        }
    }
}