using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_SQLite_TiendaPC.Models
{
    /// <summary>
    /// Representa una placa de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Representa una placa de nuestra base de datos, por lo que es una tupla de la tabla
    /// placa.
    /// </remarks>
    [Table("placa")]
    public class Placa : Producto
    {

        override
        public string ToString()
        {
            return Nombre;
        }
    }


}
