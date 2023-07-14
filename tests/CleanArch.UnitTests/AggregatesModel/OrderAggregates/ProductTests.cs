// ./src/CleanArch.UnitTests/AggregatesModel/OrderAggregates/ProductTests.cs

using Bogus;
using CleanArch.Application.AggregatesModel.OrderAggregates;
using FluentAssertions;
using Xunit;

namespace CleanArch.UnitTests.AggregatesModel.OrderAggregates;

/// <summary>
/// Product Entity Test
/// </summary>
public class ProductTests
{
    [Fact]
    public void Should_Instantiate_Product_With_Name()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
    
        // When
        Product product =  Product.NewProduct(name, price);
    
        // Then
        product.Name.Should().Be(name);
    }

    [Fact]
    public void Should_Instantiate_Product_With_Price()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
    
        // When
        Product product =  Product.NewProduct(name, price);
    
        // Then
        product.Price.Should().Be(price);
    }

    [Fact]
    public void Should_Instantiate_Product_With_Generated_Id()
    {
        // Given
        Faker faker = new("en");
        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
    
        // When
        Product product =  Product.NewProduct(name, price);
    
        // Then
        product.Id.Should().NotBeEmpty();
    }
}