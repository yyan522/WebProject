using System;
namespace WebProject.Model
{
	/// <summary>
	/// Category
	/// </summary>
	[Serializable]
	public partial class Category
	{
		public Category()
		{}
		/// <summary>
		///
		/// </summary>
		public Int32 Id {get;set;}
		/// <summary>
		///
		/// </summary>
		public String Name {get;set;}
	}
}

