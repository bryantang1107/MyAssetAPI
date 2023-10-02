namespace ContactsAPI.Models.UserModel;
using ContactsAPI.Models.AssetModel;
public class User
{
	public Guid Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public long Phone { get; set; }

	public DateTime TimeStamp { get; set; }

	//establish 1-M relationship
	//ICollection is not editable
	public ICollection<Asset> Assets { get; set; }
}


