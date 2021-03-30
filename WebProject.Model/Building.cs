using System;
namespace WebProject.Model
{
	/// <summary>
	/// Building
	/// </summary>
	[Serializable]
	public partial class Building
	{
		public Building()
		{}
		/// <summary>
		///
		/// </summary>
		public Int32 Id {get;set;}
		/// <summary>
		///
		/// </summary>
		public String BuildName {get;set;}
		/// <summary>
		///
		/// </summary>
		public String Address {get;set;}
		/// <summary>
		///
		/// </summary>
		public String lng {get;set;}
		/// <summary>
		///
		/// </summary>
		public String lat {get;set;}
		/// <summary>
		///
		/// </summary>
		public DateTime AddDate {get;set;}
	}
}

