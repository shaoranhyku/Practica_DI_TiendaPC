using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_SQLite_TiendaPC.Models
{
    /// <summary>
    /// Representa el componente microprocesador de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Representa el componente microprocesador de nuestra base de datos, por lo que es una tupla de la tabla
    /// microprocesador.
    /// </remarks>
    [Table("microprocesador")]
    public class Microprocesador : Producto
    {

        override
        public string ToString()
        {
            return Nombre;
        }
    }
}
