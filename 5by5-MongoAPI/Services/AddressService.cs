using _5by5_MongoAPI.Models;
using _5by5_MongoAPI.Utils;
using MongoDB.Driver;

namespace _5by5_MongoAPI.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _addresses;

        public AddressService(IMongoAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _addresses = database.GetCollection<Address>(settings.AddressCollectionName);
        }

        public List<Address> Get() =>
            _addresses.Find(address => true).ToList();

        public Address Get(string id) =>
            _addresses.Find<Address>(address => address.Id == id).FirstOrDefault();

        public Address Create(Address address)
        {
            _addresses.InsertOne(address);
            return address;
        }
    }
}