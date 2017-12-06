using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_SQLite_TiendaPC.Models
{
    /// <summary>
    /// Representa un pedido de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Representa un pedido de nuestra base de datos, por lo que es una tupla de la tabla
    /// pedido.
    /// </remarks>
    [Table("pedido")]
    public class Pedido
    {
        /// <summary>
        /// Identificador del pedido
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int IdPedido { get; set; }
        /// <summary>
        /// Identificador del usuario que ha realizado el pedido
        /// </summary>
        [MaxLength(4)]
        public string IdUsuario { get; set; }
        /// <summary>
        /// Identificador de la placa que se ha comprado en el pedido
        /// </summary>
        [MaxLength(20)]
        public string IdPlaca { get; set; }
        /// <summary>
        /// Identificador del microprocesador que se ha comprado en el pedido
        /// </summary>
        [MaxLength(20)]
        public string IdMicroprocesador { get; set; }
        /// <summary>
        /// Identificador de la torre que se ha comprado en el pedido
        /// </summary>
        [MaxLength(20)]
        public string IdTorre { get; set; }
        /// <summary>
        /// Identificador de la memoria que se ha comprado en el pedido
        /// </summary>
        [MaxLength(20)]
        public string IdMemoria { get; set; }
        /// <summary>
        /// Identificador de la tarjeta grafica que se ha comprado en el pedido
        /// </summary>
        [MaxLength(20)]
        public string IdTarjetaGrafica { get; set; }
    }
}
