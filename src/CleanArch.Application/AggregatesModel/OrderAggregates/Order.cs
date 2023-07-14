// ./src/CleanArch.Application/AggregatesModel/OrderAggregates/Order.cs

namespace CleanArch.Application.AggregatesModel.OrderAggregates;

/// <summary>
/// Aggregate Root
/// </summary>
public class Order
{
    private readonly List<OrderItem> orderItems = new();

    private Order(
        string firstName, 
        string lastName, 
        Address shippingAddress)
    {
        Id = Guid.NewGuid();
        Customer = Customer.NewCustomer(firstName, lastName, shippingAddress);
    }

    public Guid Id { get; set; }
    public Customer Customer { get; set; }
    public decimal TotalCost => orderItems.Sum(_ => _.Cost);
    public IReadOnlyCollection<OrderItem> OrderItems => orderItems.AsReadOnly();

    public void AddItem(string productName, decimal productPrice, int quantity)
    {
        var existentItem = orderItems.FirstOrDefault(item => 
            item.Product.Name == productName && item.Product.Price == productPrice);

        if (existentItem is not null )
        {
            existentItem.UpdateQuantity(quantity + existentItem.Quantity);
            return;
        }

        var product = Product.NewProduct(productName, productPrice);
        var orderItem = OrderItem.NewOrderItem(product, quantity);
        orderItems.Add(orderItem);

        Validate();
    }

    public void RemoveOrderItem(Guid itemId)
    {
        var item = orderItems.FirstOrDefault(item => item.Id == itemId) ?? throw new OrderItemNotFoundException();
        orderItems.Remove(item);

        Validate();
    }

    public void UpdateItemQuantity(Guid itemId, int quantity)
    {
        var item = orderItems.FirstOrDefault(_ => _.Id == itemId) ?? throw new OrderItemNotFoundException();
        item.UpdateQuantity(quantity);

        Validate();
    }

    public Dictionary<string, string>? Errors { get; set; }

    public static Order NewOrder(
        string firstName, 
        string lastName, 
        Address shippingAddress)
    {
        Order instance = new (firstName, lastName, shippingAddress);

        Validate();

        return instance;
    }

    private static void Validate()
    {
        // TODO: Here we need to validate if all the Order aggregate is valid
        //       this method need to be called in every public method, 
        //       after change the aggregate
    }
}