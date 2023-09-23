using ContactsAPI.Data;
using ContactsAPI.Models.AssetModel;
using ContactsAPI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
	[ApiController] 
	[Route("api/asset")] 
	public class AssetController : Controller
	{
		private readonly ContactsAPIDbContext dbContext;
		public AssetController(ContactsAPIDbContext dbContext) //inject db context
		{
			this.dbContext = dbContext;
		}
		[HttpGet]
		[Route("{id:guid}")]
		public async Task<IActionResult> GetUser([FromRoute] Guid id)
		{
			Asset? asset = await dbContext.Assets.FindAsync(id);
			if (asset == null) return NotFound();

			return Ok(asset);
		}

	}
}
