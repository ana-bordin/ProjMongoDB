namespace ProjMongoDB.Utils
{
    public interface IProjMongoDBAPIDataBaseSettings
    {
        string CustomerCollectionName { get; set; }
        string AddressCollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
