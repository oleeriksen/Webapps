using Core;

namespace webapp2.Service;

public interface IBikeService
{
    Task<BEBike[]> GetAll();
    Task Add(BEBike bike);
    Task DeleteById(int id);
}