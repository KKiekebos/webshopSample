using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using WebshopSample.Controllers;
using WebshopSample.Models;
using WebshopSample.Repositories;
using Xunit;

namespace WebshopSample.ControllerTests
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
        private readonly ProductController sut;

        public ProductControllerTests()
        {
            sut = new ProductController(productRepository.Object);
        }

        [Fact]
        public void GetProducts_ShouldReturnProducts()
        {
            // Arrange
            List<Product> products = [
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
            }];
            productRepository.Setup(m => m.GetProducts()).Returns(products);

            // Act
            var result = sut.GetProducts();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(products);
        }

        [Fact]
        public void GetProducts_WithNoProducts_ShouldReturn404()
        {
            // Act
            var result = sut.GetProducts();

            // Assert
            result.Result.Should().BeOfType<NotFound>();
        }

        [Fact]
        public void GetProductById_ShouldReturnProduct()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            Product product = new()
            {
                Id = Guid.NewGuid(),
                Name = "Gifkikker",
                Description = "Gifkikker bier",
                Category = ProductCategory.Beer,
                Options = ["single bottle", "6-pack", "crate"],
                Image = "image"
            };

            productRepository.Setup(m => m.GetProductById(id)).Returns(product);

            // Act
            var result = sut.GetProductById(id.ToString());

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(product);
        }

        [Fact]
        public void GetProductById_WithNoProduct_ShouldReturn404()
        {
            // Act
            var result = sut.GetProductById(Guid.NewGuid().ToString());

            // Assert
            result.Result.Should().BeOfType<NotFound>();
        }

        [Fact]
        public void GetProductById_WithNullOrWhiteSpaceId_ShouldReturn400()
        {
            // Act
            var result = sut.GetProductById(" ");

            // Assert
            result.Result.Should().BeOfType<BadRequest>();
        }

        [Fact]
        public void GetProductById_WithInvlaidId_ShouldReturn400()
        {
            // Act
            var result = sut.GetProductById("Not a guid");

            // Assert
            result.Result.Should().BeOfType<BadRequest>();
        }
    }
}
