using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrimbleAPI.Models;

namespace TrimbleAPI.Services
{
    public interface IEmployeeCollectionService : ICollectionService<Employee>
    {
        Task<List<Employee>> GetEmployeeByTeamLeaderId(Guid teamLeaderId);
    }
}
