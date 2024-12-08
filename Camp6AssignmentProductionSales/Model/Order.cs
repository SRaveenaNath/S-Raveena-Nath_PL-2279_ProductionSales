using System;
using System.Collections.Generic;

namespace Camp6AssignmentProductionSales.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public string? OrderStatus { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int StoreId { get; set; }

    public int StaffId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Staff Staff { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
