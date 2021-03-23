using System.Threading.Tasks;
using TransactionManagementSystem.Data.Models;

namespace TransactionManagementSystem.Service.Interfaces
{
    public interface IClientService
    {
        /// <summary>
        /// Returns true, if given client already exists in database.
        /// Otherwise, returns false.
        /// </summary>
        Task<bool> Exists(Client client);
        /// <summary>
        /// Returns true, if client with given id already exists in database.
        /// Otherwise, returns false.
        /// </summary>
        Task<bool> Exists(long clientId);
        /// <summary>
        /// Returns true, if only one client with given name exists in database.
        /// </summary>
        Task<bool> Exists(string fullName);

        /// <summary>
        /// Adds given client to database.
        /// </summary>
        Task Create(Client client);
        Task<Client> Create(string fullName);

        Task<Client> GetById(long clientId);
        Task<Client> GetByFullName(string fullName);
    }
}