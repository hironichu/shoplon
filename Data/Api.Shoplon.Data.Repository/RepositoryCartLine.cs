using Api.Shoplon.Data.Repository;
using Api.Shoplon.Data.Context.Contract;
using Api.Shoplon.Data.Entities.Model;
using Api.Shoplon.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.Shoplon.Data.Repository
{
    public class RepositoryCartLine : GenericRepository<CartLine>, IRepositoryCartLine
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryPayment"/> class.
        /// </summary>
        /// <param name="meteoContext">The meteo context.</param>
        public RepositoryCartLine(IShoplonContext shoplonContext) : base(shoplonContext)
        {
        }


        /// <summary>
        /// Cette méthode permet de récupérer une ligne de panier avec son ID
        /// </summary>
        /// <param name="id">ID du produit</param>
        /// <returns></returns>
        public async Task<CartLine?> GetPaymentByIDAsync(int id)
        {
            return await _shoplonContext.CartLines.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer une ligne du panier d'un utilisateur
        /// </summary>
        /// <param name="nom">Nom du produit</param>
        /// <returns></returns>
        public async Task<CartLine?> GetCartLineByClientIDAsync(int lineid, int ClientID)
        {
            return await _shoplonContext.CartLines.FirstOrDefaultAsync(x => x.Id == lineid && x.Client.Id == ClientID).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer tout le panier d'un utilisateur
        /// </summary>
        /// <param name="nom">Nom du produit</param>
        /// <returns></returns>
        public List<CartLine> GetAllCartAsync(int Clientid)
        {
            return _shoplonContext.CartLines.Where(x => x.Client.Id == Clientid).ToList();
        }

    }
}

