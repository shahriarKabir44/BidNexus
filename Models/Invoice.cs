using System;
using System.Collections.Generic;

namespace BidNexus.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int BidderId { get; set; }

    public int BidId { get; set; }

    public DateTime CreateDate { get; set; }

    public float TotalAmount { get; set; }

    public int? PaymentMethodId { get; set; }

    public int SellerId { get; set; }

    public byte StatusEnumId { get; set; }

    public virtual User Bidder { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual User Seller { get; set; } = null!;
}
