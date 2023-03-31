using Api.Shoplon.Business.Model.Clients;

namespace Api.Shoplon.Business.Service.Contract
{
    public interface IServiceClient
    {
        /// <summary>
        /// Creates a client.
        /// </summary>
        /// <param name="departementToAdd">The client to add.</param>
        /// <returns></returns>
        Task<ClientReadDTO> CreateClientAsync(ClientAddDTO clientToAdd);

        /// <summary>
        /// Cette méthode permet de récupérer la liste des clients.
        /// </summary>
        /// <returns></returns>
        Task<List<ClientReadDTO>> GetListClientAsync();

        /// <summary>
        /// Gets the client by email asynchronous.
        /// </summary>
        /// <param name="email">Email of the client.</param>
        /// <returns></returns>
        Task<ClientReadDTO> GetClientByEmailAsync(string email);

    }
}

