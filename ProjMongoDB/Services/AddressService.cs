using MongoDB.Driver;
using ProjMongoDB.Models;
using ProjMongoDB.Utils;

namespace ProjMongoDBAPI.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;

        public AddressService(IProjMongoDBAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }
        public List<Address> GetAll() => _address.Find(address => true).ToList();

        public Address Get(string id) => _address.Find<Address>(address => address.Id == id).FirstOrDefault();
      
        public Address Create(Address address)
        {
            _address.InsertOne(address);
            return address;
        }




        //public void Update(string id, Address addressIn) =>
        //    _address.ReplaceOne(address => address.Id == id, addressIn);

        //public void Remove(Address addressIn) =>
        //    _address.DeleteOne(address => address.Id == addressIn.Id);

        //public void Remove(string id) => 
        //    _address.DeleteOne(address => address.Id == id);
    }
}
