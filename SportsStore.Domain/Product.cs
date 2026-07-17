namespace SportsStore.Domain
{
    public class Product
    {
        public int ProductID {  get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string Category {  get; set; }

        public string ? ImageUrl { get; set; }


    }
}
