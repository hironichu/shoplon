using Api.Shoplon.Data.Repository;
using Api.Shoplon.Data.Context.Contract;
using Api.Shoplon.Data.Entities.Model;
using Api.Shoplon.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.Shoplon.Data.Repository
{
    public class RepositoryPayment : GenericRepository<Product>, IRepositoryPayment
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryPayment"/> class.
        /// </summary>
        /// <param name="meteoContext">The meteo context.</param>
        public RepositoryPayment(IShoplonContext shoplonContext) : base(shoplonContext)
        {
        }


        /// <summary>
        /// Cette méthode permet de récupérer un produit par sont ID
        /// </summary>
        /// <param name="id">ID du produit</param>
        /// <returns></returns>
        public async Task<Payment?> GetPaymentByIDAsync(int id)
        {
            return await _shoplonContext.Payments.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer un paiement avec le numero de commande
        /// </summary>
        /// <param name="nom">Nom du produit</param>
        /// <returns></returns>
        public async Task<Payment?> GetPaymentByOrderIDAsync(int id)
        {
            return await _shoplonContext.Payments.FirstOrDefaultAsync(x => x.Order.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer tout les paiement d'un utilisateur
        /// </summary>
        /// <param name="nom">Nom du produit</param>
        /// <returns></returns>
        public List<Payment> GetAllPaymentsAsync(int Clientid)
        {
            return _shoplonContext.Payments.Where(x => x.Client.Id == Clientid).ToList();
        }

    }
}

