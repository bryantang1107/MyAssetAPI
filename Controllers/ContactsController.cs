using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
	//[] --> Web annotation 
	[ApiController] //to let .net know that this is an API controller not MVC controller
	[Route("api/contacts")] //name of route
	//alternative
	//[Route("api/[controller]")] --> replace "controller" with contacts
	public class ContactsController : Controller
	{
		private readonly ContactsAPIDbContext dbContext;
		public ContactsController(ContactsAPIDbContext dbContext) //inject db context
		{
			this.dbContext= dbContext;
		}
		//api route: api/contacts/Contacts (method name is removed)
		[HttpGet]
		public async Task<IActionResult> GetContacts()
		{
			
			return Ok(await dbContext.Contacts.ToListAsync()); //use Ok to return IActionResult datatype
			//IActionResult expects response code : 2XX, 4XX, 5XX
		}

		[HttpGet]
		[Route("{id:guid}")] //dynamic query param, type safety: on
		public async Task<IActionResult> GetContact([FromRoute] Guid id)
		{
			Contact? contact = await dbContext.Contacts.FindAsync(id); //may return null, hence ?
			if (contact == null) return NotFound();
			
			return Ok(contact);
		}

		//Best Practice:
		//create modal (request object) for each type of request (to cater different use case)
		//AddContactRequest --> insert
		//UpdateContactRequest --> update 
		//achieve separation of code

		[HttpPost]
		public async Task<IActionResult> AddContact(AddContactRequest addContactRequest) //using async function, IActionResult must be wrapped inside Task
		{
			var contact = new Contact()
			{
				Id = Guid.NewGuid(),
				Address = addContactRequest.Address,
				Email = addContactRequest.Email,
				FullName = addContactRequest.FullName,
				Phone = addContactRequest.Phone
			};

			await dbContext.Contacts.AddAsync(contact); //insert contact object into Contacts table
			await dbContext.SaveChangesAsync();

			return Ok(contact);
		}

		[HttpPut]
		[Route("{id:guid}")] //dynamic query param, type safety: on
		public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
			//by default if api route contains query param, it will be in sequence
			//eg: api/contacts/:id, api controller method UpdateContact(id, requestObject)
		{
			Contact? contact = await dbContext.Contacts.FindAsync(id); //may return null, hence ?
			if (contact == null) return NotFound();
			contact.Email = updateContactRequest.Email;
			contact.FullName = updateContactRequest.FullName;
			contact.Phone = updateContactRequest.Phone;
			contact.Address = updateContactRequest.Address;

			await dbContext.SaveChangesAsync();
			return Ok(contact);
		}

		[HttpDelete]
		[Route("{id:guid}")] //dynamic query param, type safety: on
		public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
		{
			Contact? contact = await dbContext.Contacts.FindAsync(id); //may return null, hence ?
			if (contact == null) return NotFound();

			dbContext.Remove(contact);
			await dbContext.SaveChangesAsync();
			return Ok(contact);
		}
	}
}
