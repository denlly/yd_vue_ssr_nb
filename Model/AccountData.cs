using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model
{
	/// <summary>
	/// Account:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AccountData
	{
        public AccountData()
		{}
		#region Model
		private int _accountid;
		private string _username;
		private string _password;
		private int _userole;
		private string _ownerclass;
		private string _ownergroup;
		private string _ooderclass;
		/// <summary>
		/// 
		/// </summary>
		public int AccountID
		{
			set{ _accountid=value;}
			get{return _accountid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 用户权限(0 教务处 1进修处 2班主任 4组长)
		/// </summary>
		public int UseRole
		{
			set{ _userole=value;}
			get{return _userole;}
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
		public string ooderclass
		{
			set{ _ooderclass=value;}
			get{return _ooderclass;}
		}
		#endregion Model

	}    
}
