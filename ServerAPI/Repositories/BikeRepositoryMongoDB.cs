using Core;
using MongoDB.Driver;

namespace ServerAPI.Repositories;

public class BikeRepositoryMongoDB:IBikeRepository
{
    private IMongoClient client;
        private IMongoCollection<BEBike> collection;

        public BikeRepositoryMongoDB()
		{
            var password = ""; //add
            var mongoUri = $"mongodb+srv://olee58:{password}@cluster0.olmnqak.mongodb.net/?retryWrites=true&w=majority";

            

            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                    "Atlas cluster. Check that the URI includes a valid " +
                    "username and password, and that your IP address is " +
                    $"in the Access List. Message: {e.Message}");
                Console.WriteLine(e);
                Console.WriteLine();
                return;
            }

            // Provide the name of the database and collection you want to use.
            // If they don't already exist, the driver and Atlas will create them
            // automatically when you first write data.
            var dbName = "myDatabase";
            var collectionName = "bike";

            collection = client.GetDatabase(dbName)
               .GetCollection<BEBike>(collectionName);

        }

        public void Add(BEBike item)
        {
            var max = 0;
            if (collection.Count(Builders<BEBike>.Filter.Empty) > 0)
            {
                max = collection.Find(Builders<BEBike>.Filter.Empty).SortByDescending(r => r.Id).Limit(1).ToList()[0].Id;
            }
            item.Id = max + 1;
            // alternative:
            //int newid = Guid.NewGuid().GetHashCode();
            //item.Id = newid;
            collection.InsertOne(item);
           
        }

        public void DeleteById(int id){
            var deleteResult = collection
                .DeleteOne(Builders<BEBike>.Filter.Where(r => r.Id == id));
        }

        public BEBike[] GetAll()
        {
           return collection.Find(Builders<BEBike>.Filter.Empty).ToList().ToArray();
        }

        /*public BEBike[] GetAllByShop(string brand)
        {
            var filter = Builders<BEBike>.Filter.Where(r => r.Brand.Equals(brand));
            return collection.Find(filter).ToList().ToArray();

        }*/

        public void UpdateItem(BEBike item)
        {
            /*
            var updateDef = Builders<BEBike>.Update
                 .Set(x => x.Amount, item.Amount)
                 .Set(x => x.Description, item.Description)
                 .Set(x => x.Done, item.Done);
            collection.UpdateOne(x => x.Id == item.Id, updateDef);
            */
        }
 
}