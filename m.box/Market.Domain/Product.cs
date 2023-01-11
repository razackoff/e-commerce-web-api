namespace Market.Domain
{
    public class Product
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        /*public Product(Guid userId, string name, string description, decimal price)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            Description = description;
            Price = price;
        }*/

    }
}
