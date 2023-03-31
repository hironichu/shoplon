using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Shoplon.Business.Model.Clients
{
    /// <summary>
    /// Model de base d'un client
    /// </summary>
    public class ClientBaseDTO
    {
        /// <summary>
        /// L'email d'un client.
        /// </summary>
        /// <value>
        /// The name of the departement.
        /// </value>
        public string? Email { get; set; } = null;

        /// <summary>
        /// Le hash du mot de passe d'un client.
        /// </summary>
        /// <value>
        /// The departement french code.
        /// </value>
        public string? Password { get; set; } = null;
    }
}

