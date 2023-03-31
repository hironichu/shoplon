using Api.Shoplon.Data.Entities.Model;
using Api.Shoplon.Data.Repository.Contract;

namespace Api.Shoplon.Data.Repository.Contract
{
    public interface IRepositoryClient : IGenericRepository<Client>
    {
        /// <summary>
        /// Cette méthode permet de récupérer un client par son mail
        /// </summary>
        /// <param name="email">l'email du client</param>
        /// <returns></returns>
        Task<Client> GetClientByEmailAsync(string email);
    }
}
