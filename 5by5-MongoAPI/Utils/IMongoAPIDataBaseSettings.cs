namespace _5by5_MongoAPI.Utils
{
    public interface IMongoAPIDataBaseSettings
    {
        string CustomerCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}