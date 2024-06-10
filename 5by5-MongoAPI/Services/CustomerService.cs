using _5by5_MongoAPI.Models;
using _5by5_MongoAPI.Utils;
using MongoDB.Driver;

namespace _5by5_MongoAPI.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(IMongoAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _customers = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public List<Customer> Get() =>
            _customers.Find(customer => true).ToList();

        public Customer Get(string id) =>
            _customers.Find<Customer>(customer => customer.Id == id).FirstOrDefault();

        public Customer Post(Customer customer)
        {
            _customers.InsertOne(customer);
            return customer;
        }

        public Customer Update(Customer customerIn)
        {
            _customers.ReplaceOne(c => c.Id == customerIn.Id, customerIn);
            return customerIn;
        }

        public void Delete(string id) => _customers.DeleteOne(c => c.Id == id);
    }
}