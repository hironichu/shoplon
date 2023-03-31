using Api.Shoplon.Data.Repository;
using Api.Shoplon.Data.Context.Contract;
using Api.Shoplon.Data.Entities.Model;
using Api.Shoplon.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.Shoplon.Data.Repository
{
    public class RepositoryProduct : GenericRepository<Product>, IRepositoryProduct
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryOrder"/> class.
        /// </summary>
        /// <param name="meteoContext">The meteo context.</param>
        public RepositoryProduct(IShoplonContext shoplonContext) : base(shoplonContext)
        {
        }


        /// <summary>
        /// Cette méthode permet de récupérer un produit par sont ID
        /// </summary>
        /// <param name="id">ID du produit</param>
        /// <returns></returns>
        public async Task<Product?> GetProductByIDAsync(int id)
        {
            return await _shoplonContext.Products.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer un produit par son nom
        /// </summary>
        /// <param name="nom">Nom du produit</param>
        /// <returns></returns>
        public async Task<Product?> GetProductByNameAsync(string name)
        {
            //TODO(Hironichu) Replace this with valid search
            return await _shoplonContext.Products.FirstOrDefaultAsync(x => x.Name == name).ConfigureAwait(false);
        }



    }
}

