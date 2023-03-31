using Api.Shoplon.Data.Repository;
using Api.Shoplon.Data.Context.Contract;
using Api.Shoplon.Data.Entities.Model;
using Api.Shoplon.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.Shoplon.Data.Repository
{
    public class RepositoryContact : GenericRepository<Contact>, IRepositoryContact
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryOrder"/> class.
        /// </summary>
        /// <param name="shoplonContext">The shoplon context.</param>
        public RepositoryContact(IShoplonContext shoplonContext) : base(shoplonContext)
        {
        }


        /// <summary>
        /// Cette méthode permet de récupérer d'une entree contact par sont ID
        /// </summary>
        /// <param name="id">ID du produit</param>
        /// <returns></returns>
        public async Task<Contact?> GetContactByIDAsync(int id)
        {
            return await _shoplonContext.Contacts.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer un produit par son prenom
        /// </summary>
        /// <param name="nom">Nom du produit</param>
        /// <returns></returns>
        public async Task<Contact?> GetProductByFirstNameAsync(string name)
        {
            //TODO(Hironichu) Replace this with valid search
            return await _shoplonContext.Contacts.FirstOrDefaultAsync(x => x.FirstName == name).ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer un produit par son nom
        /// </summary>
        /// <param name="nom">Nom du produit</param>
        /// <returns></returns>
        public async Task<Contact?> GetProductByLastNameAsync(string lastname)
        {
            //TODO(Hironichu) Replace this with valid search
            return await _shoplonContext.Contacts.FirstOrDefaultAsync(x => x.LastName == lastname).ConfigureAwait(false);
        }


    }
}

