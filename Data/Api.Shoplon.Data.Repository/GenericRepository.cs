using System.Collections.Generic;
using Api.Shoplon.Data.Context.Contract;
using Api.Shoplon.Data.Entities;
using Api.Shoplon.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.Shoplon.Data.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Le context de connexion à la base de données
        /// </summary>
        protected readonly IShoplonContext _shoplonContext;

        /// <summary>
        /// La table correspondant à l'objet T
        /// </summary>
        private readonly DbSet<T> _table;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="shoplonContext">The Shoplon context.</param>
        protected GenericRepository(IShoplonContext shoplonContext)
        {
            _shoplonContext = shoplonContext;
            _table = _shoplonContext.Set<T>();
        }

        /// <summary>
        /// Cette méthode permet de récupérer la liste des éléments de T
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync().ConfigureAwait(false);
        }


        /// <summary>
        /// Cette méthode permet de récupérer d'un element de T par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de T.</param>
        /// <returns></returns>
        public async Task<T> GetByKeyAsync(object id)
        {
            return await _table.FindAsync(id).ConfigureAwait(false);
        }

        /// <summary>
        ///  Cette méthode permet de créer un élement dans la table T
        /// </summary>
        /// <param name="element">Le nouveau element à insérer dans la table T</param>
        /// <returns></returns>
        public async Task<T> CreateElementAsync(T element)
        {
            var elementAdded = await _table.AddAsync(element).ConfigureAwait(false);
            await _shoplonContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        ///  Cette méthode permet de modifier un élement de T
        /// </summary>
        /// <param name="element">L'element à mettre à jour</param>
        /// <returns></returns>
        public async Task<T> UpdateElementAsync(T element)
        {
            var elementUpdated = _table.Update(element);
            await _shoplonContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }


        /// <summary>
        ///  Cette méthode permet de supprimer un element dans T
        /// </summary>
        /// <param name="element">L'élément à supprimer</param>
        /// <returns></returns>
        public async Task<T> DeleteElementAsync(T element)
        {
            var elementDeleted = _table.Remove(element);
            await _shoplonContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            throw new NotImplementedException();
        }


        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}

