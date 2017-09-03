using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Book:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Book
	{
		public Book()
		{}
		#region Model
		//private int _id;
		private string _bookno;
		private string _bookimg;
		private string _bookname;
		private string _bookdesc;
		/// <summary>
		/// 
		/// </summary>
		//public int ID
		//{
		//	set{ _id=value;}
		//	get{return _id;}
		//}
		/// <summary>
		/// 
		/// </summary>
		public string BookNO
		{
			set{ _bookno=value;}
			get{return _bookno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BookImg
		{
			set{ _bookimg=value;}
			get{return _bookimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BookName
		{
			set{ _bookname=value;}
			get{return _bookname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BookDesc
		{
			set{ _bookdesc=value;}
			get{return _bookdesc;}
		}
		#endregion Model

	}
}

