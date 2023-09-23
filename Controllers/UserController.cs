using ContactsAPI.Data;
using ContactsAPI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
    //[] --> Web annotation 
    [ApiController] //to let .net know that this is an API controller not MVC controller
	[Route("api/contacts")] //name of route
							//alternative
							//[Route("api/[controller]")] --> replace "controller" with contacts
	public class UserController : Controller
	{
		private readonly ContactsAPIDbContext dbContext;
		public UserController(ContactsAPIDbContext dbContext) //inject db context
		{
			this.dbContext = dbContext;
		}
		//api route: api/contacts/Contacts (method name is removed)
		[HttpGet]
		public async Task<IActionResult> GetContacts()
		{

			return Ok(await dbContext.Users.ToListAsync()); //use Ok to return IActionResult datatype
															   //IActionResult expects response code : 2XX, 4XX, 5XX
		}

		[HttpGet]
		[Route("{id:guid}")] //dynamic query param, type safety: on
		public async Task<IActionResult> GetUser([FromRoute] Guid id)
		{
			User? user = await dbContext.Users.FindAsync(id); //may return null, hence ?
			if (user == null) return NotFound();

			return Ok(user);
		}

		//Best Practice:
		//create modal (request object) for each type of request (to cater different use case)
		//AddContactRequest --> insert
		//UpdateContactRequest --> update 
		//achieve separation of code

		[HttpPost]
		public async Task<IActionResult> AddContact(AddUserRequest addContactRequest) //using async function, IActionResult must be wrapped inside Task
		{
			var user = new User()
			{
				Id = Guid.NewGuid(),
				Email = addContactRequest.Email,
				FirstName = addContactRequest.FirstName,
				LastName = addContactRequest.LastName,
				Phone = addContactRequest.Phone
			};

			await dbContext.Users.AddAsync(user); //insert contact object into Contacts table
			await dbContext.SaveChangesAsync();

			return Ok(user);
		}

		[HttpPut]
		[Route("{id:guid}")] //dynamic query param, type safety: on
		public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateUserRequest updateContactRequest)
		//by default if api route contains query param, it will be in sequence
		//eg: api/contacts/:id, api controller method UpdateContact(id, requestObject)
		{
			User? user = await dbContext.Users.FindAsync(id); //may return null, hence ?
			if (user == null) return NotFound();
			user.Email = updateContactRequest.Email;
			user.FirstName = updateContactRequest.FirstName;
			user.LastName = updateContactRequest.LastName;
			user.Phone = updateContactRequest.Phone;

			await dbContext.SaveChangesAsync();
			return Ok(user);
		}

		[HttpDelete]
		[Route("{id:guid}")] //dynamic query param, type safety: on
		public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
		{
			User? user = await dbContext.Users.FindAsync(id); //may return null, hence ?
			if (user == null) return NotFound();

			dbContext.Remove(user);
			await dbContext.SaveChangesAsync();
			return Ok(user);
		}
	}
}
