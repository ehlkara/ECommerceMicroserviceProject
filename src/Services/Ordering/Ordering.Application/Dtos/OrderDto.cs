using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos;

public record OrderDto(
    Guid Id, 
    Guid CustomerId, 
    string OrderName, 
    AddressDto ShipppingAddress, 
    AddressDto BillingAddress, 
    PaymentDto payment,
    OrderStatus Status, 
    List<OrderItemDto> OrderItems);
