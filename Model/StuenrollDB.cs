using System;
namespace Model
{
	/// <summary>
	/// StuenrollDB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StuenrollDB
	{
		public StuenrollDB()
		{}
		#region Model
		private int _id;
		private string _stuname;
		private string _sex;
		private string _datebirth;
		private string _hometown;
		private string _ethnic;
		private string _education;
		private string _whenwork;
		private string _whenjpart;
		private string _gradschprofe;
		private string _workunitpos;
		private string _stuphone;
		private string _orgphone;
		private string _workexpertra;
		private string _imgurl;
		private string _ownerclass;
		private string _ownergroup;
		private string _oorderclass;
		private string _ownerdirection;
		private string _owneraccount;
		private string _roomno;
		private string _roomtelephone;
		private string _gradcernum;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 学员姓名
		/// </summary>
		public string stuname
		{
			set{ _stuname=value;}
			get{return _stuname;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 出生年月
		/// </summary>
		public string Datebirth
		{
			set{ _datebirth=value;}
			get{return _datebirth;}
		}
		/// <summary>
		/// 籍贯
		/// </summary>
		public string Hometown
		{
			set{ _hometown=value;}
			get{return _hometown;}
		}
		/// <summary>
		/// 民族
		/// </summary>
		public string Ethnic
		{
			set{ _ethnic=value;}
			get{return _ethnic;}
		}
		/// <summary>
		/// 文化程度
		/// </summary>
		public string Education
		{
			set{ _education=value;}
			get{return _education;}
		}
		/// <summary>
		/// 参加工作时间
		/// </summary>
		public string Whenwork
		{
			set{ _whenwork=value;}
			get{return _whenwork;}
		}
		/// <summary>
		/// 入党时间
		/// </summary>
		public string Whenjpart
		{
			set{ _whenjpart=value;}
			get{return _whenjpart;}
		}
		/// <summary>
		/// 毕业学校以及专业
		/// </summary>
		public string Gradschprofe
		{
			set{ _gradschprofe=value;}
			get{return _gradschprofe;}
		}
		/// <summary>
		/// 工作单位以及职务
		/// </summary>
		public string Workunitpos
		{
			set{ _workunitpos=value;}
			get{return _workunitpos;}
		}
		/// <summary>
		/// 学员电话号
		/// </summary>
		public string StuPhone
		{
			set{ _stuphone=value;}
			get{return _stuphone;}
		}
		/// <summary>
		/// 组织部们电话号
		/// </summary>
		public string OrgPhone
		{
			set{ _orgphone=value;}
			get{return _orgphone;}
		}
		/// <summary>
		/// 工作简历以及培训情况
		/// </summary>
		public string WorkExpertra
		{
			set{ _workexpertra=value;}
			get{return _workexpertra;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgurl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ownerclass
		{
			set{ _ownerclass=value;}
			get{return _ownerclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ownergroup
		{
			set{ _ownergroup=value;}
			get{return _ownergroup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string oorderclass
		{
			set{ _oorderclass=value;}
			get{return _oorderclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ownerdirection
		{
			set{ _ownerdirection=value;}
			get{return _ownerdirection;}
		}
		/// <summary>
		/// 所属老师
		/// </summary>
		public string owneraccount
		{
			set{ _owneraccount=value;}
			get{return _owneraccount;}
		}
		/// <summary>
		/// 房号
		/// </summary>
		public string RoomNo
		{
			set{ _roomno=value;}
			get{return _roomno;}
		}
		/// <summary>
		/// 房话
		/// </summary>
		public string Roomtelephone
		{
			set{ _roomtelephone=value;}
			get{return _roomtelephone;}
		}
		/// <summary>
		/// 毕业证编号 
		/// </summary>
		public string Gradcernum
		{
			set{ _gradcernum=value;}
			get{return _gradcernum;}
		}
		#endregion Model

	}
}

