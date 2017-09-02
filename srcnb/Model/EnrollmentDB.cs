using System;
namespace Model
{
	/// <summary>
	/// EnrollmentDB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnrollmentDB
	{
		public EnrollmentDB()
		{}
		#region Model
		private int _id;
		private string _candnum;
		private string _stuname;
		private string _sex;
		private int? _age;
		private string _datebirth;
		private string _hometown;
		private string _ethnic;
		private string _marstatus;
		private float? _wage;
		private string _positions;
		private string _titles;
		private string _workunit;
		private string _mobilenum;
		private string _unmaiadd;
		private string _zipcode;
		private string _commadd;
		private string _whenerework;
		private string _whenerejpart;
		private string _degree;
		private string _graduatesch;
		private string _schoolsystem;
		private string _professname;
		private string _graduationyear;
		private float? _politheoryscore;
		private float? _journalscore;
		private float? _englishscore;
		private float? _eqscores;
		private float? _totalscore;
		private string _imgurl;
		private string _ownerclass;
		private string _ownergroup;
		private string _oorderclass;
		private string _ownerdirection;
		private string _owneraccount;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 考号
		/// </summary>
		public string CandNum
		{
			set{ _candnum=value;}
			get{return _candnum;}
		}
		/// <summary>
		/// 姓名
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
		/// 
		/// </summary>
		public int? age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 出生日期
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
		/// 婚否
		/// </summary>
		public string Marstatus
		{
			set{ _marstatus=value;}
			get{return _marstatus;}
		}
		/// <summary>
		/// 工资
		/// </summary>
		public float? Wage
		{
			set{ _wage=value;}
			get{return _wage;}
		}
		/// <summary>
		/// 职务
		/// </summary>
		public string positions
		{
			set{ _positions=value;}
			get{return _positions;}
		}
		/// <summary>
		/// 职称
		/// </summary>
		public string Titles
		{
			set{ _titles=value;}
			get{return _titles;}
		}
		/// <summary>
		/// 现工作单位
		/// </summary>
		public string workunit
		{
			set{ _workunit=value;}
			get{return _workunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MobileNum
		{
			set{ _mobilenum=value;}
			get{return _mobilenum;}
		}
		/// <summary>
		/// 单位通讯地址
		/// </summary>
		public string Unmaiadd
		{
			set{ _unmaiadd=value;}
			get{return _unmaiadd;}
		}
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string Zipcode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 本人通讯地址
		/// </summary>
		public string commadd
		{
			set{ _commadd=value;}
			get{return _commadd;}
		}
		/// <summary>
		/// 何时、何地参加工作
		/// </summary>
		public string Whenerework
		{
			set{ _whenerework=value;}
			get{return _whenerework;}
		}
		/// <summary>
		/// 何时何地入党
		/// </summary>
		public string Whenerejpart
		{
			set{ _whenerejpart=value;}
			get{return _whenerejpart;}
		}
		/// <summary>
		/// 学历
		/// </summary>
		public string Degree
		{
			set{ _degree=value;}
			get{return _degree;}
		}
		/// <summary>
		/// 毕业学校
		/// </summary>
		public string Graduatesch
		{
			set{ _graduatesch=value;}
			get{return _graduatesch;}
		}
		/// <summary>
		/// 学制
		/// </summary>
		public string Schoolsystem
		{
			set{ _schoolsystem=value;}
			get{return _schoolsystem;}
		}
		/// <summary>
		/// 专业名称
		/// </summary>
		public string Professname
		{
			set{ _professname=value;}
			get{return _professname;}
		}
		/// <summary>
		/// 毕业年月
		/// </summary>
		public string GraduationYear
		{
			set{ _graduationyear=value;}
			get{return _graduationyear;}
		}
		/// <summary>
		/// 政治理论分数
		/// </summary>
		public float? Politheoryscore
		{
			set{ _politheoryscore=value;}
			get{return _politheoryscore;}
		}
		/// <summary>
		/// 论文分数
		/// </summary>
		public float? Journalscore
		{
			set{ _journalscore=value;}
			get{return _journalscore;}
		}
		/// <summary>
		/// 英语总分
		/// </summary>
		public float? Englishscore
		{
			set{ _englishscore=value;}
			get{return _englishscore;}
		}
		/// <summary>
		/// 折合分数
		/// </summary>
		public float? Eqscores
		{
			set{ _eqscores=value;}
			get{return _eqscores;}
		}
		/// <summary>
		/// 总成绩
		/// </summary>
		public float? Totalscore
		{
			set{ _totalscore=value;}
			get{return _totalscore;}
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
		/// 所属班
		/// </summary>
		public string ownerclass
		{
			set{ _ownerclass=value;}
			get{return _ownerclass;}
		}
		/// <summary>
		/// 所属组
		/// </summary>
		public string ownergroup
		{
			set{ _ownergroup=value;}
			get{return _ownergroup;}
		}
		/// <summary>
		/// 所属班次
		/// </summary>
		public string oorderclass
		{
			set{ _oorderclass=value;}
			get{return _oorderclass;}
		}
		/// <summary>
		/// 所属方向
		/// </summary>
		public string ownerdirection
		{
			set{ _ownerdirection=value;}
			get{return _ownerdirection;}
		}
		/// <summary>
		/// 所属班主任
		/// </summary>
		public string owneraccount
		{
			set{ _owneraccount=value;}
			get{return _owneraccount;}
		}
		#endregion Model

	}
}

