using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsAPI.Models.ExpenseModel
{
	public class Expense
	{
		public Guid Id { get; set; }	
		public String Category { get; set; }
		public String Notes { get; set; }

		public String PaymentType { get; set; }
		[Column(TypeName = "decimal (18,2)")]
		public decimal Amount { get; set; }

	}
}
