using SportsStore.Domain;
namespace SportsStore.Infrastructure
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
{
    new Product { Name = "Kayak", Description = "A boat for one person", Category = "Watersports", Price = 275M,ImageUrl="/images/9.png" },
    new Product { Name = "Lifejacket", Description = "Protective and fashionable", Category = "Watersports", Price = 48.95M,ImageUrl="/images/8.png" },
    new Product { Name = "Soccer Ball", Description = "FIFA-approved size and weight", Category = "Soccer", Price = 19.50M,ImageUrl="/images/7.png" },
    new Product { Name = "Corner Flags", Description = "Give your playing field a professional touch", Category = "Soccer", Price = 34.95M,ImageUrl="/images/6.png" },
    new Product { Name = "Stadium", Description = "Flat-packed 35,000-seat stadium", Category = "Soccer", Price = 79500M,ImageUrl="/images/5.png" },
    new Product { Name = "Thinking Cap", Description = "Improve brain efficiency by 75%", Category = "Chess", Price = 16M,ImageUrl="/images/4.png" },
    new Product { Name = "Unsteady Chair", Description = "Secretly give your opponent a disadvantage", Category = "Chess", Price = 29.95M,ImageUrl="/images/3.png" },
    new Product { Name = "Human Chess Board", Description = "A fun game for the family", Category = "Chess", Price = 75M,ImageUrl="/images/2.png" },
    new Product { Name = "Bling Bling King", Description = "Gold-plated king", Category = "Chess", Price = 1200M,ImageUrl="/images/1.png" }
}.AsQueryable();
    }
}
