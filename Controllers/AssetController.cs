using ContactsAPI.Data;
using ContactsAPI.Models.AssetModel;
using ContactsAPI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCapitalAPI.Models.AssetModel;

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
		public async Task<IActionResult> GetAsset([FromRoute] Guid id) //get asset based on id
		{
			Asset[] asset = await dbContext.Assets.Where(a => a.User.Id== id).ToArrayAsync();
			return Ok(asset);

		}

		[HttpPost]
		public async Task<IActionResult> AddAsset(AddAssetRequest addAssetRequest) //using async function, IActionResult must be wrapped inside Task
		{
			var asset = new Asset()
			{
				Id = addAssetRequest.User.Id,
				Symbol = addAssetRequest.Symbol,
				Name = addAssetRequest.Name,
				Type = addAssetRequest.Type,
				Amount = addAssetRequest.Amount,
				Category = addAssetRequest.Category,
				TimeStamp= DateTime.Now,
			};

			await dbContext.Assets.AddAsync(asset); //insert contact object into Contacts table
			await dbContext.SaveChangesAsync();

			return Ok(asset);
		}
	}
}
