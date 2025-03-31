using System.Net.Http.Json;
using Core;

namespace webapp2.Service;

public class BikeServiceServer : IBikeService
{
    private string serverUrl = "http://localhost:5284";

    private HttpClient client;
    
    public BikeServiceServer(HttpClient client)
    {
        this.client = client;
    }

    public async Task<BEBike[]> GetAll()
    {
        return await client.GetFromJsonAsync<BEBike[]>($"{serverUrl}/api/bike");
    }

    public async Task Add(BEBike bike)
    {
        await client.PostAsJsonAsync<BEBike>($"{serverUrl}/api/bike", bike);
    }

    public async Task DeleteById(int id)
    {
        await client.DeleteAsync($"{serverUrl}/api/bike/{id}");
    }
}