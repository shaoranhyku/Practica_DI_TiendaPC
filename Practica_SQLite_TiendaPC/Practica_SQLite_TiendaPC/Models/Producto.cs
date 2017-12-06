using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_SQLite_TiendaPC.Models
{
    /// <summary>
    /// Representa un producto.
    /// </summary>
    /// <remarks>
    /// Representa un producto. Es padre de todos los tipos productos que podemos encontrar
    /// en nuestra base de datos.
    /// </remarks>
    public class Producto
    {
        /// <summary>
        /// Id con el que el producto se identificará en la base de datos.
        /// </summary>
        [PrimaryKey, MaxLength(20)]
        public string Id { get; set; }
        /// <summary>
        /// Nombre del producto.
        /// </summary>
        [Unique, MaxLength(30)]
        public string Nombre { get; set; }
        /// <summary>
        /// Precio del producto.
        /// </summary>
        public double Precio { get; set; }
    }
}
