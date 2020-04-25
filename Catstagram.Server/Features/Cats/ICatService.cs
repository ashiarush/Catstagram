namespace Catstagram.Server.Features.Cats
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICatService
    {
        Task<int> Create(string imageUrl, string description, string userId);
        Task<IEnumerable<CatListingResponseModel>> ByUser(string userId);
    }
}
