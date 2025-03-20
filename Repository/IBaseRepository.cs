using BidNexus.Models;

namespace BidNexus.Repository
{


    public interface IBaseRepository<T> where T : class
    {
         T? GetById(int id ,out string error);
        bool Upsert(ref T dest,T source, out string error);
        bool Delete(int id, out string error);
    }


}
