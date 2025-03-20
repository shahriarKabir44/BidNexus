using BidNexus.Models;

namespace BidNexus.Jsons
{
    public class ProductJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
    }

    public static partial class EntityMapper
    {
        public static void Map(this Product entity, ProductJson toJson)
        {
            toJson.Id = entity.Id;
            toJson.Name = entity.Name;
            toJson.CategoryId = entity.CategoryId;
            toJson.BidStartTime = entity.BidStartTime;
            toJson.BidEndTime = entity.BidEndTime;
            toJson.PriceStartFrom = entity.PriceStartFrom;
            toJson.ImgUrl = entity.ImgUrl;
            toJson.Description = entity.Description;
            toJson.IsDeleted = entity.IsDeleted;
            toJson.CreateBy = entity.CreateBy;
            toJson.UpdateDate = entity.UpdateDate;
            toJson.UpdateBy = entity.UpdateBy;
            toJson.StatusEnumId = entity.StatusEnumId;
            toJson.CreateDate=entity.CreateDate;
        }
        public static void Map(this ProductJson json, Product toEntity)
        {
            toEntity.Id = json.Id;
            toEntity.Name = json.Name;
            toEntity.CategoryId = json.CategoryId;
            toEntity.BidStartTime = json.BidStartTime;
            toEntity.BidEndTime = json.BidEndTime;
            toEntity.PriceStartFrom = json.PriceStartFrom;
            toEntity.ImgUrl = json.ImgUrl;
            toEntity.Description = json.Description;
            toEntity.IsDeleted = json.IsDeleted;
            toEntity.CreateBy = json.CreateBy;
            toEntity.UpdateDate = json.UpdateDate;
            toEntity.UpdateBy = json.UpdateBy;
            toEntity.StatusEnumId = json.StatusEnumId;
            toEntity.CreateDate=json.CreateDate;
        }
    }
}
