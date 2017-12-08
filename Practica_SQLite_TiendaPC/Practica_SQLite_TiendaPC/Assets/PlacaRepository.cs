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
    /// Repositorio que nos permite conectar con la tabla placa de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Esta clase contiene metodos para conectarse con nuestra base de datos y acceder a la tabla
    /// placa.
    /// </remarks>
    public class PlacaRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public PlacaRepository(string dbPath)
        {
           
            conn = new SQLiteAsyncConnection(dbPath);
         
            conn.CreateTableAsync<Placa>().Wait();
        }

        /// <summary>
        /// Agrega una placa a la base de datos
        /// </summary>
        /// <remarks>
        /// Permite agregar una placa a la base de datos.
        /// </remarks>
        /// <param name="placa">Placa que queremos añadir</param>
        /// <returns>Tarea de añadir una placa</returns>
        public async Task AgregarPlaca(Placa placa)
        {
            int result = 0;
            try
            {
                result = await conn.InsertAsync(placa);
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

            conn.DropTableAsync<Placa>().Wait();
            conn.CreateTableAsync<Placa>().Wait();

        }

        /// <summary>
        /// Permite obtener una lista con todas las placas de la base de datos.
        /// </summary>
        /// <remarks>
        /// Se conecta con la tabla placa de la base de datos y obtiene todas las tuplas transformadas
        /// a objetos placa.
        /// </remarks>
        /// <returns>
        /// Lista de placas de la base de datos.
        /// </returns>
        public async Task<List<Placa>> ObtenerPlacas()
        {
            List<Placa> listaPlacas;
            try
            {
                listaPlacas = await conn.Table<Placa>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaPlacas = new List<Placa>();
            }
            
            return listaPlacas;

        }
    }
}
