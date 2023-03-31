using Api.Shoplon.Data.Repository;
using Api.Shoplon.Data.Context.Contract;
using Api.Shoplon.Data.Entities.Model;
using Api.Shoplon.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.Shoplon.Data.Repository
{
    public class RepositoryOrderLine : GenericRepository<Contact>, IRepositoryOrderLine
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryOrder"/> class.
        /// </summary>
        /// <param name="shoplonContext">The shoplon context.</param>
        public RepositoryOrderLine(IShoplonContext shoplonContext) : base(shoplonContext)
        {
        }


        /// <summary>
        /// Cette méthode permet de récupérer d'une ligne de commande par sont ID
        /// </summary>
        /// <param name="id">ID du produit</param>
        /// <returns></returns>
        public async Task<OrderLine?> GetByIDAsync(int id)
        {
            return await _shoplonContext.OrderLines.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer tout les produit d'une commande depuis son ID
        /// </summary>
        /// <param name="nom">Id de la commande</param>
        /// <returns></returns>
        public List<OrderLine> GetAllByorderID(int orderID)
        {

            return _shoplonContext.OrderLines.Where(x => x.Order.Id == orderID).ToList();
        }



    }
}

