namespace Catstagram.Server.Features.Cats
{
    using Catstagram.Server.Features.Cats.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICatService
    {
        Task<int> Create(string imageUrl, string description, string userId);
        Task<IEnumerable<CatListingServiceModel>> ByUser(string userId);
        Task<CatDetailsServiceModel> Details(int id);
    }
}
