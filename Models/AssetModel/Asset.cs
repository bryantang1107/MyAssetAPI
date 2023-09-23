using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsAPI.Models.AssetModel
{
	public class Asset
	{
		public Guid Id { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		[Column(TypeName = "decimal (18,2)")] //explicitly specify data type using data annotation
		public decimal Amount { get; set; }
		public char Category { get; set; }
		//data return from public api

		//user foreign key 


	}
}
