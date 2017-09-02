using System;
using System.ComponentModel.DataAnnotations;
namespace Model
{
	/// <summary>
	/// OrderClassDB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderClassDB
	{
		public OrderClassDB()
		{}
		#region Model
		private int _id;
		private string _ordclassname;
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
        [Required]
		public string ordclassname
		{
			set{ _ordclassname=value;}
			get{return _ordclassname;}
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

