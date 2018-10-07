using System;
//using HttSoft.Framework;

namespace HttSoft.HTERP.Sys
{
	/// <summary>
	/// PageConst 的摘要说明。
	/// </summary>
	public sealed class PageConst
	{
		#region 数据库相关常量WinForm
		/// <summary>
		/// 数据库服务器名称
		/// </summary>
		public const string DBServer="Server";

		/// <summary>
		/// 数据库名称
		/// </summary>
		public const string DBDataBase="DataBase";

		/// <summary>
		/// 连接数据库帐号
		/// </summary>
		public const string DBAccount="Account";

		/// <summary>
		/// 连接数据库密码
		/// </summary>
		public const string DBPassword="Password";		
		#endregion

		#region 定义全局对象名
		/// <summary>
		/// 当前用户ID
		/// </summary>
		public const string USERID="UserID";

		/// <summary>
		/// 当前用户名称
		/// </summary>
		public const string USERName="USERName";
		

		/// <summary>
		/// 登陆者帐号
		/// </summary>
		public const string USERACCOUNT="USERAccount";

		/// <summary>
		/// 性别
		/// </summary>
		public const string USERGENDER="UserGender";
        
		/// <summary>
		/// 实体ID
		/// </summary>
		public const string ID="ID";

		/// <summary>
		/// 附件id
		/// </summary>
		public const string ATTACHMENTID="AttachmentID";

		/// <summary>
		/// 帐号角色
		/// </summary>
		public const string USERACTOR="UserActor";

		/// <summary>
		/// 全屏Cookie
		/// </summary>
		public const string FullScreen="FullScreen";

		/// <summary>
		/// Actor Cookie
		/// </summary>
		public const string ClientActor="ClientActor";

		
		/// <summary>
		/// 默认样式员工
		/// </summary>
		public const string DefaultUIOP="SYS";
		#endregion

		#region WebService提示信息相关

		public const string WSCallNoRight="查询数据发生异常\r\n发生此错误的可能原因是您没有使用本查询服务的权限\r\n请尝试重新登录系统再执行本查询";
		#endregion

		#region 用来传输参数的常量
		/// <summary>
		/// 页面操作状态
		/// </summary>
		public const string PAGESTATUS="PageStatus";

		/// <summary>
		/// 实体Code
		/// </summary>
		public const string CODE="Code";

		/// <summary>
		/// 日期
		/// </summary>
		public const string DATE="Date";

		/// <summary>
		/// 出错信息
		/// </summary>
		public const string ERROR="Error";

		/// <summary>
		/// 登录标志
		/// </summary>
		public const string LOGINFLAG="LoginFlag";

		/// <summary>
		/// 预警类型
		/// </summary>
		public const string AlarmType="AlarmType";
		#endregion		

		#region ActiveRpoert相关

		/// <summary>
		/// 报表类型ID
		/// </summary>
		public const string ReportTypeID="ReportTypeID";

		/// <summary>
		/// 报表主记录ID
		/// </summary>
		public const string ReportMainID="ReportMainID";
		#endregion

		#region 定义DataGrid、DataList分页排序相关常量
		/// <summary>
		/// 每页数据大小
		/// </summary>
		public const string PageSize="PageSize";
		/// <summary>
		/// 页码
		/// </summary>
		public const string PageIndex="PageIndex";

		/// <summary>
		/// 总页数
		/// </summary>
		public const string PageCount="PageCount";

		/// <summary>
		/// 排序字段名称
		/// </summary>
		public const string SortField="SortField";

		/// <summary>
		/// 排序方向ASC / DESC
		/// </summary>
		public const string SortName="SortName";

		#endregion		
	}
}
