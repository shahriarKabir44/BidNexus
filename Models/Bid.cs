using System;
using System.Collections.Generic;

namespace BidNexus.Models;

public partial class Bid
{
    public int Id { get; set; }

    public int BidderId { get; set; }

    public int ProductId { get; set; }

    public float Price { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual UserAccount Bidder { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
