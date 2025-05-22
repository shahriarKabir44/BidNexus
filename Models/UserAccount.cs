using System;
using System.Collections.Generic;

namespace BidNexus.Models;

public partial class UserAccount
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? ProfileImgUrl { get; set; }

    public string? Address { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreateBy { get; set; }

    public DateTime UpdateDate { get; set; }

    public int UpdateBy { get; set; }

    public bool IsDeleted { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public byte UserTypeEnumId { get; set; }

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<UserPermissionMap> UserPermissionMaps { get; set; } = new List<UserPermissionMap>();
}
