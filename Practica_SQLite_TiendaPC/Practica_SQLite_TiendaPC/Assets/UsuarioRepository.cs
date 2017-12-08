using Practica_SQLite_TiendaPC.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_SQLite_TiendaPC.Assets
{
    /// <summary>
    /// Repositorio que nos permite conectar con la tabla usuario de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Esta clase contiene metodos para conectarse con nuestra base de datos y acceder a la tabla
    /// usuario.
    /// </remarks>
    public class UsuarioRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public UsuarioRepository(string dbPath)
        {
       
            conn = new SQLiteAsyncConnection(dbPath);

            conn.CreateTableAsync<Usuario>().Wait();
        }

        /// <summary>
        /// Permite obtener una lista con todos los usuarios de la base de datos.
        /// </summary>
        /// <remarks>
        /// Se conecta con la tabla usuario de la base de datos y obtiene todas las tuplas transformadas
        /// a objetos usuario.
        /// </remarks>
        /// <returns>
        /// Lista de usuarios de la base de datos.
        /// </returns>
        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            List<Usuario> listaUsuarios;
            try
            {
                listaUsuarios = await conn.Table<Usuario>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaUsuarios = new List<Usuario>();
            }
            
            return listaUsuarios;

        }
    }
}
