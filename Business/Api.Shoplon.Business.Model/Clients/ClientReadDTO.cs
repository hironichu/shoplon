using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Shoplon.Business.Model.Clients
{
    /// <summary>
    /// Model d'affichage d'un client
    /// </summary>
    /// <seealso cref="Api.Meteo.Business.Model.Clients.ClientReadDTO" />
    public class ClientReadDTO : ClientBaseDTO
    {
        /// <summary>
        /// L'identifiant d'un client.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

    }
}
