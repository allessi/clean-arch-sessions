using System;
using System.Linq;
using Bogus;
using CleanArch.Application.AggregatesModel.OrderAggregates;
using FluentAssertions;
using Xunit;

namespace CleanArch.UnitTests.AggregatesModel.OrderAggregates;

/// <summary>
/// Order Aggregate Root Tests
/// </summary>
public class OrderTests
{
    [Fact]
    public void Should_Instantiate_Order_With_Customer_FirstName()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);

        // When
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);

        // Then
        order.Customer.FirstName.Should().Be(firstName);
    }

    [Fact]
    public void Should_Instantiate_Order_With_Customer_LastName()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);

        // When
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);

        // Then
        order.Customer.LastName.Should().Be(lastName);
    }

    [Fact]
    public void Should_Instantiate_Order_With_Customer_Shipping_Street()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);

        // When
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);

        // Then
        order.Customer.ShippingAddress.Street.Should().Be(street);
    }

    [Fact]
    public void Should_Instantiate_Order_With_Customer_Shipping_City()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);

        // When
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);

        // Then
        order.Customer.ShippingAddress.City.Should().Be(city);
    }

    [Fact]
    public void Should_Instantiate_Order_With_Customer_Shipping_State()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);

        // When
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);

        // Then
        order.Customer.ShippingAddress.State.Should().Be(state);
    }

    [Fact]
    public void Should_Instantiate_Order_With_Customer_Shipping_ZipCode()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        Address shippingAddress = new(street, city, state, zipCode);

        // When
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);

        // Then
        order.Customer.ShippingAddress.ZipCode.Should().Be(zipCode);
    }

    [Fact]
    public void Should_AddItem_To_OrderItems()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        var productName = faker.Commerce.ProductName();
        var productPrice = faker.Random.Decimal(0m, 15m);
        var quantity = faker.Random.Int(1, 10);

        Address shippingAddress = new(street, city, state, zipCode);
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);

        // When
        order.AddItem(productName, productPrice, quantity);

        // Then
        order.OrderItems.Should().Contain(item =>
            item.Product.Name == productName &&
            item.Product.Price == productPrice &&
            item.Quantity == quantity);
    }

    [Fact]
    public void Should_Update_Quantity_AddItem_Existent_In_OrderItems()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        var productName = faker.Commerce.ProductName();
        var productPrice = faker.Random.Decimal(0m, 15m);
        var quantity = faker.Random.Int(1, 10);

        Address shippingAddress = new(street, city, state, zipCode);
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);
        order.AddItem(productName, productPrice, quantity);

        // When
        order.AddItem(productName, productPrice, quantity);

        // Then
        order.OrderItems.Should().Contain(item =>
            item.Product.Name == productName &&
            item.Product.Price == productPrice &&
            item.Quantity == (quantity * 2));
    }

    [Fact]
    public void Should_AddItem_If_Exists_With_Another_Price_In_OrderItems()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        var productName = faker.Commerce.ProductName();
        var productPrice = faker.Random.Decimal(0m, 10m);
        var quantity = faker.Random.Int(1, 10);
        var productNewPrice = faker.Random.Decimal(11m, 15m);

        Address shippingAddress = new(street, city, state, zipCode);
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);
        order.AddItem(productName, productPrice, quantity);

        // When
        order.AddItem(productName, productNewPrice, quantity);

        // Then
        order.OrderItems.Should().SatisfyRespectively(
            first =>
            {
                first.Product.Name.Should().Be(productName);
                first.Product.Price.Should().Be(productPrice);
            },
            second =>
            {
                second.Product.Name.Should().Be(productName);
                second.Product.Price.Should().Be(productNewPrice);
            });
    }

    [Fact]
    public void Should_Sum_Total_Cost()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        var productName = faker.Commerce.ProductName();
        var productPrice = faker.Random.Decimal(0m, 10m);
        var quantity = faker.Random.Int(1, 10);
        var productNewPrice = faker.Random.Decimal(11m, 15m);
        var expected = (quantity * productPrice) + (quantity * productNewPrice);

        Address shippingAddress = new(street, city, state, zipCode);
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);

        // When
        order.AddItem(productName, productPrice, quantity);
        order.AddItem(productName, productNewPrice, quantity);

        // Then
        order.TotalCost.Should().Be(expected);
    }

    [Fact]
    public void Should_Be_Able_To_Remove_OrderItem()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        var productName = faker.Commerce.ProductName();
        var productPrice = faker.Random.Decimal(0m, 10m);
        var quantity = faker.Random.Int(1, 10);
        _ = faker.Random.Decimal(11m, 15m);

        Address shippingAddress = new(street, city, state, zipCode);
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);
        order.AddItem(productName, productPrice, quantity);
        var firstOrder = order.OrderItems.First();

        // When
        order.RemoveOrderItem(firstOrder.Id);

        // Then
        order.OrderItems.Should().HaveCount(0);
    }

    [Fact]
    public void Should_Throw_OrderItemNotFoundException_RemovingOrderItem_When_Item_Id_Do_Not_Exists()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        var productName = faker.Commerce.ProductName();
        var productPrice = faker.Random.Decimal(0m, 10m);
        var quantity = faker.Random.Int(1, 10);
        var productNewPrice = faker.Random.Decimal(11m, 15m);

        Address shippingAddress = new(street, city, state, zipCode);
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);
        order.AddItem(productName, productPrice, quantity);
        var firstOrder = order.OrderItems.First();

        // When
        order.Invoking(_ => _.RemoveOrderItem(Guid.NewGuid()))
        // Then
            .Should()
            .Throw<OrderItemNotFoundException>()
            .WithMessage("Order item not found.");
    }

    [Fact]
    public void Should_Throw_OrderItemNotFoundException_UpdatingItemQuantity_When_Item_Id_Do_Not_Exists()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        var productName = faker.Commerce.ProductName();
        var productPrice = faker.Random.Decimal(0m, 10m);
        var quantity = faker.Random.Int(1, 10);
        var productNewPrice = faker.Random.Decimal(11m, 15m);

        Address shippingAddress = new(street, city, state, zipCode);
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);
        order.AddItem(productName, productPrice, quantity);
        var firstOrder = order.OrderItems.First();
        var newQuantity = faker.Random.Int(1, 10);

        // When
        order.Invoking(_ => _.UpdateItemQuantity(Guid.NewGuid(), newQuantity))
        // Then
            .Should()
            .Throw<OrderItemNotFoundException>()
            .WithMessage("Order item not found.");
    }

    [Fact]
    public void Should_Be_Able_To_Update_Item_Quantity()
    {
        // Given
        Faker faker = new("en");
        var firstName = faker.Person.FirstName;
        var lastName = faker.Person.LastName;
        var street = faker.Address.StreetAddress();
        var city = faker.Address.City();
        var state = faker.Address.State();
        var zipCode = faker.Address.ZipCode();
        var productName = faker.Commerce.ProductName();
        var productPrice = faker.Random.Decimal(0m, 10m);
        var quantity = faker.Random.Int(1, 10);
        var productNewPrice = faker.Random.Decimal(11m, 15m);

        Address shippingAddress = new(street, city, state, zipCode);
        Order order = Order.NewOrder(firstName, lastName, shippingAddress);
        order.AddItem(productName, productPrice, quantity);
        var firstOrder = order.OrderItems.First();
        var newQuantity = faker.Random.Int(1, 10);

        // When
        order.UpdateItemQuantity(firstOrder.Id, newQuantity);

        // Then
        order.OrderItems.Should().SatisfyRespectively(
            first => first.Quantity.Should().Be(newQuantity));
    }
}