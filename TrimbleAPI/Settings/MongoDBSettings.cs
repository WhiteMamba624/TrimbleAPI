using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrimbleAPI.Settings
{
    public class MongoDBSettings : IMongoDBSettings
    {
       public string EmployeeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
