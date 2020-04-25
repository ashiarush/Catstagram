namespace Catstagram.Server.Features.Cats
{
    using Data;
    using Data.Models;
    using System.Threading.Tasks;

    public class CatService : ICatService
    {
        private readonly CatstagramDbContext data;

        public CatService(CatstagramDbContext data)
        {
            this.data = data;
        }
        public async Task<int> Create(string imageUrl, string description, string userId)
        {
            var cat = new Cat()
            {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.data.Add(cat);
            await this.data.SaveChangesAsync();

            return cat.Id;
        }
    }
}
