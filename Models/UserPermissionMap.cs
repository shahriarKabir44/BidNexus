using System;
using System.Collections.Generic;

namespace BidNexus.Models;

public partial class UserPermissionMap
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PermissionId { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
