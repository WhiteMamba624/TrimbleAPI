using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrimbleAPI.Models;
using TrimbleAPI.Settings;

namespace TrimbleAPI.Services
{
    public class EmployeeCollectionService :IEmployeeCollectionService
    {
        private readonly IMongoCollection<Employee> _employee;
        public EmployeeCollectionService(IMongoDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);

            _employee = database.GetCollection<Employee>(settings.EmployeeCollectionName);

        }

        public async Task<List<Employee>> GetAll()
        {
            IAsyncCursor<Employee> result = await _employee.FindAsync(filter => true);
            return result.ToList();
        }

        public async Task<Employee> Get(Guid id)
        {
            IAsyncCursor<Employee> result = await _employee.FindAsync(employee => employee.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<bool> Create(Employee employee)
        {
            await _employee.InsertOneAsync(employee);
            return true;
        }

        public async Task<bool> Update(Guid id, Employee employee)
        {
            employee.Id = id;
            var result = await _employee.ReplaceOneAsync(item => employee.Id == id, employee);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _employee.InsertOneAsync(employee);
                return false;
            }
            return true;

        }

        public async Task<bool> Delete(Guid id)
        {
            DeleteResult result = await _employee.DeleteOneAsync(employee => employee.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Employee>> GetEmployeeByTeamLeaderId(Guid teamLeaderId)
        {
            return (await _employee.FindAsync(employee => employee.TeamLeaderId == teamLeaderId)).ToList();
        }

    }
}
