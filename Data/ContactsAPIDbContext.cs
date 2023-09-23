using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
	public class ContactsAPIDbContext : DbContext
	{
		public ContactsAPIDbContext(DbContextOptions options) : base(options)
		{
			//options --> will get from Program.cs (can use In Memory, or directly connect to MSSQL)
		}

		public DbSet<Contact> Contacts { get; set; } //Contacts --> table name
	}
}
