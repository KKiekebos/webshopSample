using WebshopSample.Models;

namespace WebshopSample.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products =
        [
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Gifkikker",
                Description = "Gifkikker bier",
                Category = ProductCategory.Beer,
                Options = ["single bottle", "6-pack", "crate"],
                Image = "image"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Pizzabodem",
                Description = "Kant en klare pizza bodem",
                Category = ProductCategory.PizzaIngredient,
                Options = ["Italiaans", "gluten vrij"],
                Image = "image"
            },            
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Pizza snijder",
                Description = "Een handige pizza snijder",
                Category = ProductCategory.PizzaTool,
                Options = [],
                Image = "image"
            },            
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Tomaten",
                Description = "Tomaten in blik",
                Category = ProductCategory.PizzaIngredient,
                Options = [],
                Image = "image"
            },            
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Pizza borden",
                Description = "Borden groot genoeg voor een hele pizza",
                Category = ProductCategory.PizzaTool,
                Options = [],
                Image = "image"
            },            
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Kaas",
                Description = "Kaas die goed smelt",
                Category = ProductCategory.PizzaIngredient,
                Options = ["Koe kaas", "Geitenkaas", "Buffelkaas", "Vegan kaas"],
                Image = "image"
            },            
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Pizzaschep",
                Description = "Een schep om de pizza uit de oven te halen",
                Category = ProductCategory.PizzaTool,
                Options = [],
                Image = "image"
            }
        ];

        public Product? GetProductById(Guid id)
        {
            return products.Find(p => p.Id == id);
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
