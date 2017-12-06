using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_SQLite_TiendaPC.Models
{
    /// <summary>
    /// Representa un usuario de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Representa un usuario de nuestra base de datos, por lo que es una tupla de la tabla
    /// usuario.
    /// </remarks>
    [Table("usuario")]
    public class Usuario
    {
        /// <summary>
        /// Codigo con el que se identificará el usuario y podrá hacer login.
        /// </summary>
        [PrimaryKey, MaxLength(4)]
        public string CodUsuario { get; set; }
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        [MaxLength(50)]
        public string Nombre { get; set; }
        /// <summary>
        /// Contraseña del usuario con la que podrá hacer login.
        /// </summary>
        [MaxLength(10)]
        public string Contra { get; set; }
        /// <summary>
        /// Tipo de usuario. Puede ser usuario o administrador.
        /// </summary>
        [MaxLength(7)]
        public string Tipo { get; set; }
    }
}
