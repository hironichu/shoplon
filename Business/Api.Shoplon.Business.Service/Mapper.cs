using Api.Shoplon.Data.Entities.Model;
using Api.Shoplon.Business.Model;
using Api.Shoplon.Business.Model.Clients;

namespace Api.Shoplon.Business.Service
{
    public static class Mapper
    {
        /// <summary>
        /// Cette méthode permet de transformer un département Entity en département DTO.
        /// </summary>
        /// <param name="departement">The departement.</param>
        /// <returns></returns>
        public static ClientReadDTO TransformClientToDTO(Client client)
        {
            ClientReadDTO clientRead = new ClientReadDTO()
            {
                Id = client.Id,
                Email = client.Email,
                Password = client.Password
            };

            return clientRead;
        }
    }
}


