using System;
namespace Model
{
	/// <summary>
	/// GraPersonlistDB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GraPersonlistDB
	{
		public GraPersonlistDB()
		{}
		#region Model
		private int _id;
		private string _printbatch;
		private string _gname;
		private string _granum;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string printbatch
		{
			set{ _printbatch=value;}
			get{return _printbatch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gname
		{
			set{ _gname=value;}
			get{return _gname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string granum
		{
			set{ _granum=value;}
			get{return _granum;}
		}
		#endregion Model

	}
}

