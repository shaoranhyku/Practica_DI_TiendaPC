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
    /// Repositorio que nos permite conectar con la tabla microprocesador de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Esta clase contiene metodos para conectarse con nuestra base de datos y acceder a la tabla
    /// microprocesador.
    /// </remarks>
    public class MicroprocesadorRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public MicroprocesadorRepository(string dbPath)
        {
            
            conn = new SQLiteAsyncConnection(dbPath);
            
            conn.CreateTableAsync<Microprocesador>().Wait();
        }

        /// <summary>
        /// Agrega un microprocesador a la base de datos
        /// </summary>
        /// <remarks>
        /// Permite agregar un microprocesador a la base de datos.
        /// </remarks>
        /// <param name="procesador">Microprocesador que queremos añadir</param>
        /// <returns>Tarea de añadir una microprocesador</returns>
        public async Task AgregarMicroprocesador(Microprocesador procesador)
        {
            int result = 0;
            try
            {
                result = await conn.InsertAsync(procesador);
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

            conn.DropTableAsync<Microprocesador>().Wait();
            conn.CreateTableAsync<Microprocesador>().Wait();

        }

        /// <summary>
        /// Permite obtener una lista con todos los microprocesadores de la base de datos.
        /// </summary>
        /// <remarks>
        /// Se conecta con la tabla microprocesadores de la base de datos y obtiene todas las tuplas transformadas
        /// a objetos microprocesadores.
        /// </remarks>
        /// <returns>
        /// Lista de microprocesadores de la base de datos.
        /// </returns>
        public async Task<List<Microprocesador>> ObtenerMicroprocesadores()
        {
            List<Microprocesador> listaMicroprocesadores;
            try
            {
                listaMicroprocesadores = await conn.Table<Microprocesador>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaMicroprocesadores = new List<Microprocesador>();
            }
            
            return listaMicroprocesadores;

        }
    }
}
