using System;
namespace Model
{
	/// <summary>
	/// DiplomaDB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DiplomaDB
	{
		public DiplomaDB()
		{}
		#region Model
		private int _id;
		private string _startgrdnum;
		private string _gradcardbody;
		private string _graduatime;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 起始毕业证编号
		/// </summary>
		public string startgrdnum
		{
			set{ _startgrdnum=value;}
			get{return _startgrdnum;}
		}
		/// <summary>
		/// 毕业证正文
		/// </summary>
		public string Gradcardbody
		{
			set{ _gradcardbody=value;}
			get{return _gradcardbody;}
		}
		/// <summary>
		/// 毕业时间
		/// </summary>
		public string Graduatime
		{
			set{ _graduatime=value;}
			get{return _graduatime;}
		}
		#endregion Model

	}
}

