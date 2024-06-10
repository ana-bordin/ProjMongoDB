using MongoDB.Driver;
using ProjMongoDB.Models;
using ProjMongoDB.Utils;
using System.Net;

namespace ProjMongoDBAPI.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IProjMongoDBAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public List<Customer> GetAll() => _customer.Find(customer => true).ToList();

        public Customer Get(string id) => _customer.Find<Customer>(customer => customer.Id == id).FirstOrDefault();

        public Customer Create(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public Customer Update(Customer customer)
        {
            _customer.ReplaceOne(c => c.Id == customer.Id, customer);
            return customer;
        }

        public void Delete(string id)
        {          
            _customer.DeleteOne(c => c.Id == id);
        }

    }
}
