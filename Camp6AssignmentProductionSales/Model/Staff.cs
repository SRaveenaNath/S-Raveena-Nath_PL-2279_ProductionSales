using System;
using System.Collections.Generic;

namespace Camp6AssignmentProductionSales.Model;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool Active { get; set; }

    public int StoreId { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
