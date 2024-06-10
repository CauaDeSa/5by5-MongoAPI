namespace _5by5_MongoAPI.Utils
{
    public class MongoAPIDataBaseSettings : IMongoAPIDataBaseSettings
    {
        public string CustomerCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}