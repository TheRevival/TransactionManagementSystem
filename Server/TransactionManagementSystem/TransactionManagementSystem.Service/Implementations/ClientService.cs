using System.Linq;
using System.Threading.Tasks;
using TransactionManagementSystem.Data;
using TransactionManagementSystem.Data.Models;
using TransactionManagementSystem.Service.Interfaces;

namespace TransactionManagementSystem.Service.Implementations
{
    public class ClientService : IClientService
    {
        private readonly TransactionManagementSystemDbContext _db;

        public ClientService(TransactionManagementSystemDbContext db)
        {
            _db = db;
        }
        
        public async Task<bool> Exists(Client client)
        {
            return await _db.Clients.FindAsync(client.Id) is not null;
        }

        public async Task<bool> Exists(long clientId)
        {
            return await _db.Clients.FindAsync(clientId) is not null;
        }

        public async Task<bool> Exists(string fullName)
        {
            throw new System.NotImplementedException();
        }

        public async Task Create(Client client)
        {
            throw new System.NotImplementedException();
        }

        public Task<Client> Create(string fullName)
        {
            throw new System.NotImplementedException();
        }

        public Task<Client> GetById(long clientId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Client> GetByFullName(string fullName)
        {
            throw new System.NotImplementedException();
        }
    }
}