using System;
using System.Collections.Generic;

namespace BidNexus.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public DateTime BidStartTime { get; set; }

    public DateTime? BidEndTime { get; set; }

    public float PriceStartFrom { get; set; }

    public string? ImgUrl { get; set; }

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public int CreateBy { get; set; }

    public DateTime UpdateDate { get; set; }

    public int UpdateBy { get; set; }

    public byte StatusEnumId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? History { get; set; }

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
}
