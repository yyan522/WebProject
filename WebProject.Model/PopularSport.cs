using System;
namespace WebProject.Model
{
	/// <summary>
	/// PopularSport
	/// </summary>
	[Serializable]
	public partial class PopularSport
	{
		public PopularSport()
		{}
		/// <summary>
		///
		/// </summary>
		public Int32 Id {get;set;}
		/// <summary>
		///
		/// </summary>
		public Int32 CategoryId {get;set; }
		/// <summary>
		///
		/// </summary>
		public String CategoryName { get; set; }
		/// <summary>
		///
		/// </summary>
		public String Name {get;set;}
		/// <summary>
		///
		/// </summary>
		public String Remark {get;set;}
		/// <summary>
		///
		/// </summary>
		public String Client {get;set;}
		/// <summary>
		///
		/// </summary>
		public DateTime AddDate {get;set;}
		/// <summary>
		///
		/// </summary>
		public String ImgPath1 {get;set;}
		/// <summary>
		///
		/// </summary>
		public String ImgPath2 {get;set;}
		/// <summary>
		///
		/// </summary>
		public String ImgPath3 {get;set;}
	}
}

