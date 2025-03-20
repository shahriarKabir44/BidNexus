using BidNexus.Models;

namespace BidNexus.Repository
{
    public class ProductRepository : IBaseRepository<Product>, IDisposable
    {
        private BidNexusContext DbInstance;

        public void Dispose()
        {
             
        }

        public ProductRepository(BidNexusContext instance)
        {
            DbInstance = instance;
        }
        public Product? GetById(int id, out string error)
        {
            error = "";
            try
            {
                return DbInstance.Products.Find(id);
            }
            catch (Exception e)
            {
                error = e.GetBaseException().Message;
                return null;
            }
        }

        public bool Upsert(ref Product dest, Product newObj, out string error)
        {
            error = "";
            bool isNewObj = false;
            if (!IsValidToSave(newObj, out error))
            {
                return false;
            }
            var objToSave = GetById(newObj.Id, out error);
            if (objToSave == null)
            {
                objToSave = Product.GetNew();
                isNewObj = true;
            }

            if (isNewObj)
            {
                DbInstance.Products.Add(objToSave);
            }

            objToSave.Id = newObj.Id;
            objToSave.Name = newObj.Name;
            objToSave.CategoryId = newObj.CategoryId;
            objToSave.BidStartTime = newObj.BidStartTime;
            objToSave.BidEndTime = newObj.BidEndTime;
            objToSave.PriceStartFrom = newObj.PriceStartFrom;
            objToSave.ImgUrl = newObj.ImgUrl;
            objToSave.Description = newObj.Description;
            objToSave.IsDeleted = newObj.IsDeleted;
            objToSave.CreateBy = newObj.CreateBy;
            objToSave.UpdateDate = DateTime.Now;
            objToSave.UpdateBy = newObj.UpdateBy; //todo: implement JWT
            objToSave.StatusEnumId = newObj.StatusEnumId;
            objToSave.CreateDate = newObj.CreateDate;
            dest = objToSave;
            return true;
        }

        public bool IsValidToSave(Product src, out string error)
        {
            error = "";


            return true;
        }

        public bool Delete(int id, out string error)
        {
            error = "";
            try
            {
                var entity = DbInstance.Products.Find(id);
                if (entity == null)
                {
                    error = "Product Not Found!";
                    return false;
                }

                if (DbInstance.Bids.Any(x => x.ProductId == id))
                {
                    error = "Bid Exists For This Product!";
                    return false;
                }

                DbInstance.Products.Remove(entity);
            }
            catch (Exception e)
            {
                error = e.GetBaseException().Message;
                return false;
            }

            return true;
        }
    }
}
