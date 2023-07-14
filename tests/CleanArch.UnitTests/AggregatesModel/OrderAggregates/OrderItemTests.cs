// ./src/CleanArch.UnitTests/AggregatesModel/OrderAggregates/OrderItemTests.cs

using Bogus;
using CleanArch.Application.AggregatesModel.OrderAggregates;
using FluentAssertions;
using Xunit;

namespace CleanArch.UnitTests.AggregatesModel.OrderAggregates;

/// <summary>
/// Order Item Entity Tests
/// </summary>
public class OrderItemTests
{
    [Fact]
    public void Should_Instantiate_OrderItem_With_Product()
    {
        // Given
        Faker faker = new("en");

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
    
        // When
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
        
        // Then
        item.Product.Should().NotBeNull();
    }

    [Fact]
    public void Should_Instantiate_OrderItem_With_Quantity()
    {
        // Given
        Faker faker = new("en");

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
    
        // When
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
        
        // Then
        item.Quantity.Should().Be(quantity);
    }

    [Fact]
    public void Should_Instantiate_OrderItem_WithCost_Equal_Price_x_Quantity()
    {
        // Given
        Faker faker = new("en");

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
    
        // When
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
        
        // Then
        item.Cost.Should().Be(price * quantity);
    }

    [Fact]
    public void Should_OrderItem_Be_Able_To_Update_Quantity()
    {
        // Given
        Faker faker = new("en");

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
        var newQuantity = faker.Random.Int(1, 10);
    
        // When
        item.UpdateQuantity(newQuantity);

        // Then
        item.Quantity.Should().Be(newQuantity);
    }

    [Fact]
    public void Should_OrderItem_Update_Cost_When_Update_Quantity()
    {
        // Given
        Faker faker = new("en");

        var name = faker.Commerce.ProductName();
        var price = faker.Random.Decimal(10m, 100m);
        Product product =  Product.NewProduct(name, price);

        var quantity = faker.Random.Int(1, 10);
        OrderItem item = OrderItem.NewOrderItem(product, quantity);
        var newQuantity = faker.Random.Int(1, 10);
    
        // When
        item.UpdateQuantity(newQuantity);

        // Then
        item.Cost.Should().Be(price * newQuantity);
    }
}