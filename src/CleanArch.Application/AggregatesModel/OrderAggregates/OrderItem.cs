// ./src/CleanArch.Application/AggregatesModel/OrderAggregates/OrderItem.cs

namespace CleanArch.Application.AggregatesModel.OrderAggregates;

/// <summary>
/// Entity
/// </summary>
public class OrderItem
{
    private OrderItem(Product product, int quantity)
    {
        Id = Guid.NewGuid();
        Product = product;
        Quantity = quantity;
    }

    public Guid Id { get; private set; }
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal Cost => Product.Price * Quantity;

    public void UpdateQuantity(int quantity) => Quantity = quantity;

    public static OrderItem NewOrderItem(Product product, int quantity) =>
        new(product, quantity);
}