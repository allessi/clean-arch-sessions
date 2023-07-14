// ./src/CleanArch.UnitTests/AggregatesModel/OrderAggregates/CustomerTests.cs

using Bogus;
using CleanArch.Application.AggregatesModel.OrderAggregates;
using FluentAssertions;
using Xunit;

namespace CleanArch.UnitTests.AggregatesModel.OrderAggregates;

/// <summary>
/// Customer Entity Tests
/// </summary>
public class CustomerTests
{
    [Fact]
    public void Should_Instantiate_Customer_With_FirstName()
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
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.FirstName.Should().Be(firstName);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_LastName()
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
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.LastName.Should().Be(lastName);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_Shipping_Street()
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
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.ShippingAddress.Street.Should().Be(street);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_Shipping_State()
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
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.ShippingAddress.State.Should().Be(state);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_Shipping_City()
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
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.ShippingAddress.City.Should().Be(city);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_Shipping_ZipCode()
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
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.ShippingAddress.ZipCode.Should().Be(zipCode);
    }

    [Fact]
    public void Should_Instantiate_Customer_With_Generated_Id()
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
        Customer customer =  Customer.NewCustomer(firstName, lastName, shippingAddress);
    
        // Then
        customer.CustomerId.Should().NotBeEmpty();
    }
}