// ./src/CleanArch.Application/AggregatesModel/OrderAggregates/Address.cs

namespace CleanArch.Application.AggregatesModel.OrderAggregates;

/// <summary>
/// Value object
/// </summary>
public record Address(string Street, string City, string State, string ZipCode);