namespace MyCapitalAPI.Models.AssetModel
{
	public class AddAssetRequest
	{
		public string Name { get; set; }	
		public string Type { get; set; }
		public decimal Amount { get; set; }
		public char Category { get; set; }

		public string Symbol { get; set; }

		public DateTime TimeStamp { get; set; }

	}
}
