using System;
using Api.Shoplon.Data.Entities.Model;

namespace Api.Shoplon.Data.Repository.Contract
{
    public interface IRepositoryOrder : IGenericRepository<Order>
    {
        /// <summary>
        /// Cette méthode permet de récupérer une commande par son ID
        /// </summary>
        /// <param name="id">ID de la commande</param>
        /// <returns>Order</returns>
        Task<Order> GetOrderByIDAsync(int id);
    }
}