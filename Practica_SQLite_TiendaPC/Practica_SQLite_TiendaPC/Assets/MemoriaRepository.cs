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
    /// Repositorio que nos permite conectar con la tabla memoria de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Esta clase contiene metodos para conectarse con nuestra base de datos y acceder a la tabla
    /// memoria.
    /// </remarks>
    public class MemoriaRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public MemoriaRepository(string dbPath)
        {
            
            conn = new SQLiteAsyncConnection(dbPath);
            
            conn.CreateTableAsync<Memoria>().Wait();
        }

        /// <summary>
        /// Permite obtener una lista con todas las memorias de la base de datos.
        /// </summary>
        /// <remarks>
        /// Se conecta con la tabla memoria de la base de datos y obtiene todas las tuplas transformadas
        /// a objetos memoria.
        /// </remarks>
        /// <returns>
        /// Lista de memorias de la base de datos.
        /// </returns>
        public async Task<List<Memoria>> GetAllMemoriaAsync()
        {
            List<Memoria> listaMemorias;
            try
            {
                listaMemorias = await conn.Table<Memoria>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaMemorias = new List<Memoria>();
            }
            
            return listaMemorias;

        }
    }
}
