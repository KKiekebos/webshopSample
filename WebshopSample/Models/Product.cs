namespace WebshopSample.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Options { get; set; }

        public string Image { get; set; }

        public ProductCategory Category { get; set; }
    }
}
