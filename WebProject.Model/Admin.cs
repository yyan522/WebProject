using System;
namespace WebProject.Model
{
	/// <summary>
	/// Admin
	/// </summary>
	[Serializable]
	public partial class Admin
	{
		public Admin()
		{}
		/// <summary>
		///
		/// </summary>
		public Int32 Id {get;set;}
		/// <summary>
		///
		/// </summary>
		public String UserName {get;set;}
		/// <summary>
		///
		/// </summary>
		public String Password {get;set;}
	}
}

