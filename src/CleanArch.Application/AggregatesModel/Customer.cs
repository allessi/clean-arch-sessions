// ./src/CleanArch.Application/AggregatesModel/OrderAggregates/Customer.cs

namespace CleanArch.Application.AggregatesModel.OrderAggregates;

/// <summary>
/// Entity
/// </summary>
public class Customer
{
    private Customer(
        string firstName, 
        string lastName, 
        Address shippingAddress)
    {
        CustomerId = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        ShippingAddress = shippingAddress;
    }

    public Guid CustomerId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Address ShippingAddress { get; private set; }

    public static Customer NewCustomer(
        string firstName, 
        string lastName, 
        Address shippingAddress)
    {
        return new (firstName, lastName, shippingAddress);
    }
}