using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrimbleAPI.Settings
{
   public interface IMongoDBSettings
    {
        string EmployeeCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
