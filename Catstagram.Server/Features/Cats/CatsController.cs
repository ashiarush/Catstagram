namespace Catstagram.Server.Features.Cats
{
    using Catstagram.Server.Features.Cats.Models;
    using Catstagram.Server.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Infrastructure.WebConstants;

    [Authorize]
    public class CatsController : ApiController
    {
        private readonly ICatService catService;

        public CatsController(ICatService catService) => this.catService = catService;

        [HttpGet]
        public async Task<IEnumerable<CatListingServiceModel>> Mine()
        {
            var userId = this.User.GetId();
            return await this.catService.ByUser(userId);
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id)
        => await this.catService.Details(id);

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetId();
            var id = await catService.Create(
                                            model.ImageUrl,
                                            model.Description,
                                            userId);

            return Created(nameof(this.Create), id);
        }
        [HttpPut]
        public async Task<ActionResult<int>> Update(UpdateCatRequestModel model)
        {
            var userId = this.User.GetId();
            var updated = await catService.Update(
                                            model.Id,
                                            model.Description,
                                            userId);

            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }
        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var userId = this.User.GetId();

            var deleted = await this.catService.Delete(id, userId);

            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
