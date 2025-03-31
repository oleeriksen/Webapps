using Core;

namespace webapp2.Service;

public class BikeServiceMock : IBikeService
{
    private List<BEBike> bikes = new();
    
    public async Task<BEBike[]> GetAll()
    {
        return bikes.ToArray();
    }

    public async Task Add(BEBike bike)
    {
        int max = 0;
        if (bikes.Count > 0)
            max = bikes.Select(b => b.Id).Max();
        bike.Id = max + 1;
        bikes.Add(bike);
    }

    public async Task DeleteById(int id)
    {
        bikes.RemoveAll(bike => bike.Id == id);
    }
}