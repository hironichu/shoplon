using Api.Shoplon.Data.Repository;
using Api.Shoplon.Data.Context.Contract;
using Api.Shoplon.Data.Entities.Model;
using Api.Shoplon.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.Shoplon.Data.Repository
{
    public class RepositoryClient : GenericRepository<Client>, IRepositoryClient
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryDepartement"/> class.
        /// </summary>
        /// <param name="meteoContext">The meteo context.</param>
        public RepositoryClient(IShoplonContext shoplonContext) : base(shoplonContext)
        {
        }

        /// <summary>
        /// Cette méthode permet de récupérer un client par son email
        /// </summary>
        /// <param name="email">l'email du client</param>
        /// <returns></returns>
        public async Task<Client?> GetClientByEmailAsync(string email)
        {
            return await _shoplonContext.Clients.FirstOrDefaultAsync(x => x.Email == email).ConfigureAwait(false);
        }





    }
}

