namespace ContactsAPI.Models.UserModel
{
	public class User
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public long Phone { get; set; }
	}
}

