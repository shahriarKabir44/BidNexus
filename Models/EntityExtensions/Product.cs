namespace BidNexus.Models
{
    public partial class Product
    {
        public static Product GetNew(int id = 0)
        {
            var obj = new Product();

            obj.Id = 0;
            obj.Name = string.Empty;
            obj.CategoryId = 0;
            obj.BidStartTime = DateTime.Now;
            obj.BidEndTime = null;
            obj.PriceStartFrom = 0f;
            obj.ImgUrl = null;
            obj.Description = null;
            obj.IsDeleted = false;
            obj.CreateBy = 0;
            obj.UpdateDate = DateTime.Now;
            obj.UpdateBy = 0;
            obj.StatusEnumId = 0;

            obj.CreateDate=DateTime.Now;
            return obj;
        }
    }
}
