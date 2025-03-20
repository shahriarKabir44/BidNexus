using BidNexus.Models;

namespace BidNexus.Jsons
{
    public class BidJson
    {
        public int Id { get; set; }
        public int BidderId { get; set; }
        public int ProductId { get; set; }
        public float Price { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public static partial class EntityMapper
    {
        public static void Map(this Bid entity, BidJson toJson)
        {
            toJson.Id = entity.Id;
            toJson.BidderId = entity.BidderId;
            toJson.ProductId = entity.ProductId;
            toJson.Price = entity.Price;
            toJson.CreateDate = entity.CreateDate;
        }

        public static void Map(this BidJson json, Bid toEntity)
        {
            toEntity.Id = json.Id;
            toEntity.BidderId = json.BidderId;
            toEntity.ProductId = json.ProductId;
            toEntity.Price = json.Price;
            toEntity.CreateDate = json.CreateDate;
        }
    }
}