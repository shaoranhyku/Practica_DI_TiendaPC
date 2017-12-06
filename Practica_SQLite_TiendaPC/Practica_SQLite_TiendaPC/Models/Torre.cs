using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_SQLite_TiendaPC.Models
{
    /// <summary>
    /// Representa una torre de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Representa una torre de nuestra base de datos, por lo que es una tupla de la tabla
    /// torre.
    /// </remarks>
    [Table("torre")]
    public class Torre : Producto
    {

        override
        public string ToString()
        {
            return Nombre;
        }
    }
}
