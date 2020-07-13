using DataAccessLayer.InterFace;

namespace DataAccessLayer.Implementation
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
