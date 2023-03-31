using Api.Shoplon.Business.Model.Clients;
using Api.Shoplon.Business.Service.Contract;
using Api.Shoplon.Data.Entities;
using Api.Shoplon.Data.Repository.Contract;
using Microsoft.AspNetCore.Mvc;


namespace Api.Meteo.Applications.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        /// <summary>
        /// Le service de departement
        /// </summary>
        private readonly IServiceClient _serviceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartementsController"/> class.
        /// </summary>
        /// <param name="serviceDepartement">The service departement.</param>
        public ClientController(IServiceClient serviceDepartement)
        {
            _serviceClient = serviceDepartement;
        }



        // GET: api/Clientsxx
        /// <summary>
        /// Ressource pour récupérer la liste des départements
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<ClientReadDTO>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> ClientListAsync()
        {
            var clients = await _serviceClient.GetListClientAsync().ConfigureAwait(false);

            return Ok(clients);
        }

        [HttpGet("{email}")]
        [ProducesResponseType(typeof(ClientReadDTO), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> ClientByEmailAsync(string email)
        {
            var client = await _serviceClient.GetClientByEmailAsync(email).ConfigureAwait(false);

            return Ok(client);
        }


        /// <summary>
        /// Ressource pour créer un nouveau Client
        /// </summary>
        /// <param name="client">les information du nouveau déparytement.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(ClientAddDTO), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> CreateClientAsync(ClientBaseDTO client)
        {
            if (client == null)
                return Problem("Les informations du client sont vide");

            if(string.IsNullOrWhiteSpace(client.Email) || string.IsNullOrWhiteSpace(client.Password))
                return Problem("L'email ou le mot de passe est null ou vide");


            //var clientToAdd = new Client()
            //{
            //    Name = departement.Test,
            //    Code = departement.Hercule
            //};
            //var departementAdded = await _serviceClient.CreateClientAsync(clientToAdd).ConfigureAwait(false);
            //return Ok(departementAdded);
            return Ok(null);
        }
    }
}

