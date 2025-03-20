namespace BidNexus.Models
{
    public partial class Bid
    {
        public static Bid GetNew(int id = 0)
        {
            var obj = new Bid
            {
                Id = 0,
                BidderId = 0,
                ProductId = 0,
                Price = 0f,
                CreateDate = DateTime.Now
            };
            return obj;
        }
    }
}