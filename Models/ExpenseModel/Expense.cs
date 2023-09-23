namespace ContactsAPI.Models.ExpenseModel
{
	public class Expense
	{
		public Guid TrxRefNo { get; set; }	
		public String Category { get; set; }
		public String Notes { get; set; }

		public String PaymentType { get; set; }

		public decimal Amount { get; set; }

	}
}
