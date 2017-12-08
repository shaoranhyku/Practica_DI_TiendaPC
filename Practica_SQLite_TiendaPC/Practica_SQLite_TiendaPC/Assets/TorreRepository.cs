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
    /// Repositorio que nos permite conectar con la tabla torre de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Esta clase contiene metodos para conectarse con nuestra base de datos y acceder a la tabla
    /// torre.
    /// </remarks>
    public class TorreRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public TorreRepository(string dbPath)
        {
      
            conn = new SQLiteAsyncConnection(dbPath);
     
            conn.CreateTableAsync<Torre>().Wait();
        }

        /// <summary>
        /// Agrega una torre a la base de datos
        /// </summary>
        /// <remarks>
        /// Permite agregar una torre a la base de datos.
        /// </remarks>
        /// <param name="torre">Torre que queremos añadir</param>
        /// <returns>Tarea de añadir una torre</returns>
        public async Task AgregarTorre(Torre torre)
        {
            int result = 0;
            try
            {
                result = await conn.InsertAsync(torre);
            }
            catch (Exception ex)
            {
            }

        }

        /// <summary>
        /// Borra los registros de la tabla.
        /// </summary>
        /// <remarks>
        /// Borra la tabla de la base de datos y la vuelve a crear.
        /// </remarks>
        /// <returns>Tarea de borrar la tabla</returns>
        public void BorrarTabla()
        {

            conn.DropTableAsync<Torre>().Wait();
            conn.CreateTableAsync<Torre>().Wait();

        }

        /// <summary>
        /// Permite obtener una lista con todas las torres de la base de datos.
        /// </summary>
        /// <remarks>
        /// Se conecta con la tabla torre de la base de datos y obtiene todas las tuplas transformadas
        /// a objetos torre.
        /// </remarks>
        /// <returns>
        /// Lista de torres de la base de datos.
        /// </returns>
        public async Task<List<Torre>> ObtenerTorres()
        {
            List<Torre> listaTorres;
            try
            {
                listaTorres = await conn.Table<Torre>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaTorres = new List<Torre>();
            }
            
            return listaTorres;

        }
    }
}
