using ContactsAPI.Models.AssetModel;
using ContactsAPI.Models.ExpenseModel;
using ContactsAPI.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
    public class ContactsAPIDbContext : DbContext
	{
		public ContactsAPIDbContext(DbContextOptions options) : base(options)
		{
			//options --> will get from Program.cs (can use In Memory, or directly connect to MSSQL)
		}

		public DbSet<User> Users { get; set; } //Users --> table name

		public DbSet<Asset> Assets { get; set; }

		public DbSet<Expense> Expenses { get; set; }
	}
}
