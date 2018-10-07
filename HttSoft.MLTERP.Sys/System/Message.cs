using System;

namespace HttSoft.MLTERP.Sys
{
	/// <summary>
	/// 提示信息枚举类型(随各系统不同而变化)
	/// </summary>
	public enum Message
	{
		///System Message
		/// <summary>
		/// Default Out Information(If not found message id)
		/// </summary>
		CommonDefault=10000,
		/// <summary>
		/// Before delete alert mesage
		/// </summary>
		CommonDelete=10001,
		/// <summary>
		/// After save data success alert message
		/// </summary>
		CommonSaveAccess=10002,
		/// <summary>
		/// Grid change Index Error Information
		/// </summary>
		CommonGridPage=10003,
		/// <summary>
		/// Inlegal Route
		/// </summary>
		CommonRouteError=10004,
		/// <summary>
		/// Session Lost
		/// </summary>
		CommonSession=10005,
		/// <summary>
		/// Insert
		/// </summary>
		CommonDBInsert=10020,
		/// <summary>
		/// Update
		/// </summary>
		CommonDBUpdate=10021,
		/// <summary>
		/// Delete
		/// </summary>
		CommonDBDelete=10022,
		/// <summary>
		/// sql error 547
		/// </summary>
		CommonSqlExceptionA=10023,
		/// <summary>
		/// sql error 2627
		/// </summary>
		CommonSqlExceptionB=10024,
		/// <summary>
		/// Connect database fail
		/// </summary>
		CommonDBConnect=10025,
		/// <summary>
		/// Close database fail
		/// </summary>
		CommonDBClose=10026,
		/// <summary>
		/// Execute sql fail
		/// </summary>
		CommonDBSQL=10027,
		/// <summary>
		/// Execute procedure fail
		/// </summary>
		CommonDBProcedure=10028,
		/// <summary>
		/// connection string is null
		/// </summary>
		CommonDBConnectString=10029,
		/// <summary>
		/// DataBase Type not set
		/// </summary>
		CommonDBType=10030,
		
	}
}
