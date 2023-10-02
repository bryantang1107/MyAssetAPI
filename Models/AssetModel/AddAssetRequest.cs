namespace MyCapitalAPI.Models.AssetModel;
using ContactsAPI.Models.UserModel;
public class AddAssetRequest
{
	public User User { get; set; } //how to add foreign key data
	public string Name { get; set; }	
	public string Type { get; set; }
	public decimal Amount { get; set; }
	public char Category { get; set; }

	public string Symbol { get; set; }

	public DateTime TimeStamp { get; set; }

}
