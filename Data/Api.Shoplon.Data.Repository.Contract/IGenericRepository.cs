using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Shoplon.Data.Repository.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Cette méthode permet de récupérer la liste des éléments de T
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Cette méthode permet de récupérer d'un element de T par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de T.</param>
        /// <returns></returns>
        Task<T> GetByKeyAsync(object id);

        /// <summary>
        ///  Cette méthode permet de créer un élement dans la table T
        /// </summary>
        /// <param name="element">Le nouveau element à insérer dans la table T</param>
        /// <returns></returns>
        Task<T> CreateElementAsync(T element);

        /// <summary>
        ///  Cette méthode permet de modifier un élement de T
        /// </summary>
        /// <param name="element">L'element à mettre à jour</param>
        /// <returns></returns>
        Task<T> UpdateElementAsync(T element);

        /// <summary>
        ///  Cette méthode permet de supprimer un element dans T
        /// </summary>
        /// <param name="element">L'élément à supprimer</param>
        /// <returns></returns>
        Task<T> DeleteElementAsync(T element);

    }
}

