
using Api.Shoplon.Business.Service.Contract;
using Api.Shoplon.Business.Model.Clients;
using Api.Shoplon.Data.Entities.Model;
using Api.Shoplon.Data.Repository.Contract;
namespace Api.Shoplon.Business.Service
{
    public class ServiceClient : IServiceClient
    {

        private readonly IRepositoryClient _repositoryClient;


        public ServiceClient(IRepositoryClient repositoryClient)
        {
            _repositoryClient = repositoryClient;
        }




        /// <summary>
        /// Creates the departement.
        /// </summary>
        /// <param name="departementToAdd">The departement to add.</param>
        /// <returns></returns>
        public async Task<ClientReadDTO> CreateClientAsync(ClientAddDTO clientToAdd)
        {
            Client newClient = new Client()
            {
                Email = clientToAdd.Email ?? "",
                Password = clientToAdd.Password ?? "",
            };

            var client = await _repositoryClient.CreateElementAsync(newClient).ConfigureAwait(false);

            return Mapper.TransformClientToDTO(client);
        }

        /// <summary>
        /// Gets the departement by name asynchronous.
        /// </summary>
        /// <param name="departementName">Name of the departement.</param>
        /// <returns></returns>
        public async Task<ClientReadDTO> GetClientByEmailAsync(string email)
        {
            var client = await _repositoryClient.GetClientByEmailAsync(email).ConfigureAwait(false);
            return Mapper.TransformClientToDTO(client);
        }

        /// <summary>
        /// Cette méthode permet de récupérer la liste des départements.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClientReadDTO>> GetListClientAsync()
        {
            var departements = await _repositoryClient.GetAllAsync().ConfigureAwait(false);

            List<ClientReadDTO> departementDtos = new();

            foreach (var departement in departements)
            {
                departementDtos.Add(Mapper.TransformClientToDTO(departement));
            }

            return departementDtos;
        }
    }
}

