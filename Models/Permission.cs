using System;
using System.Collections.Generic;

namespace BidNexus.Models;

public partial class Permission
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? PermissionJson { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreateBy { get; set; }

    public DateTime UpdateDate { get; set; }

    public int UpdateBy { get; set; }

    public virtual ICollection<UserPermissionMap> UserPermissionMaps { get; set; } = new List<UserPermissionMap>();
}
