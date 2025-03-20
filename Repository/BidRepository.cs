using BidNexus.Models;
using System;

namespace BidNexus.Repository
{
    public class BidRepository : IBaseRepository<Bid>
    {
        private BidNexusContext DbInstance;

        public BidRepository(BidNexusContext instance)
        {
            DbInstance = instance;
        }

        public Bid? GetById(int id, out string error)
        {
            error = "";
            try
            {
                return DbInstance.Bids.Find(id);
            }
            catch (Exception e)
            {
                error = e.GetBaseException().Message;
                return null;
            }
        }

        public bool Upsert(ref Bid dest, Bid source, out string error)
        {
            error = "";
            bool isNewObj = false;
            if (!IsValidToSave(source, out error))
            {
                return false;
            }

            var objToSave = GetById(source.Id, out error);
            if (objToSave == null)
            {
                objToSave = Bid.GetNew();
                isNewObj = true;
            }

            if (isNewObj)
            {
                DbInstance.Bids.Add(objToSave);
            }

            objToSave.Id = source.Id;
            objToSave.BidderId = source.BidderId;
            objToSave.ProductId = source.ProductId;
            objToSave.Price = source.Price;
            objToSave.CreateDate = source.CreateDate;

            dest = objToSave;
            return true;
        }

        public bool IsValidToSave(Bid src, out string error)
        {
            error = "";
            // Add validation logic here if needed
            return true;
        }

        public bool Delete(int id, out string error)
        {
            error = "";
            try
            {
                var entity = DbInstance.Bids.Find(id);
                if (entity == null)
                {
                    error = "Bid Not Found!";
                    return false;
                }

                DbInstance.Bids.Remove(entity);
                return true;
            }
            catch (Exception e)
            {
                error = e.GetBaseException().Message;
                return false;
            }
        }
    }
}