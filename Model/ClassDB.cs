using System;
namespace Model
{
	/// <summary>
	/// ClassDB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ClassDB
	{
		public ClassDB()
		{}
		#region Model
		private int _id;
		private string _classname;
		private string _addate;
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
		public string classname
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string addate
		{
			set{ _addate=value;}
			get{return _addate;}
		}
		#endregion Model

	}
}

