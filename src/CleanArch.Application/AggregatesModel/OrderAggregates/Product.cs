// ./src/CleanArch.Application/AggregatesModel/OrderAggregates/Product.cs

namespace CleanArch.Application.AggregatesModel.OrderAggregates;

/// <summary>
/// Entity
/// </summary>
public class Product
{
    private Product(string name, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public static Product NewProduct(string name, decimal price) =>
        new (name, price);
}