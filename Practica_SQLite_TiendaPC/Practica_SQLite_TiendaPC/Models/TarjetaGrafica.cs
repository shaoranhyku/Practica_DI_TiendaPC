using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_SQLite_TiendaPC.Models
{
    /// <summary>
    /// Representa una tarjeta grafica de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Representa una tarjeta grafica de nuestra base de datos, por lo que es una tupla de la tabla
    /// tarjeta grafica.
    /// </remarks>
    [Table("tarjetagrafica")]
    public class TarjetaGrafica : Producto
    {

        override
        public string ToString()
        {
            return Nombre;
        }
    }
}
