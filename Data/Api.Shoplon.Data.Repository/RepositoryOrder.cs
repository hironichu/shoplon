using Api.Shoplon.Data.Repository;
using Api.Shoplon.Data.Context.Contract;
using Api.Shoplon.Data.Entities.Model;
using Api.Shoplon.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.Shoplon.Data.Repository
{
    public class RepositoryOrder : GenericRepository<Order>, IRepositoryOrder
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryOrder"/> class.
        /// </summary>
        /// <param name="meteoContext">The meteo context.</param>
        public RepositoryOrder(IShoplonContext shoplonContext) : base(shoplonContext)
        {
        }


        /// <summary>
        /// Cette méthode permet de récupérer un produit par sont ID
        /// </summary>
        /// <param name="id">ID du produit</param>
        /// <returns></returns>
        public async Task<Order?> GetOrderByIDAsync(int id)
        {
            return await _shoplonContext.Orders.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer un produit par la date
        /// </summary>
        /// <param name="nom">Nom du produit</param>
        /// <returns></returns>
        public async Task<Order?> GetProductByNameAsync(DateOnly date)
        {
            //TODO(Hironichu) Replace this with valid search
            return await _shoplonContext.Orders.FirstOrDefaultAsync(x => x.Date == date).ConfigureAwait(false);
        }



    }
}

