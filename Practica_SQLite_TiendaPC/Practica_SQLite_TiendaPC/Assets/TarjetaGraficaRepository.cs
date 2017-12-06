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
    /// Repositorio que nos permite conectar con la tabla tarjeta grafica de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Esta clase contiene metodos para conectarse con nuestra base de datos y acceder a la tabla
    /// tarjeta grafica.
    /// </remarks>
    public class TarjetaGraficaRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public TarjetaGraficaRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<TarjetaGrafica>().Wait();
        }

        /// <summary>
        /// Permite obtener una lista con todas las tarjetas graficas de la base de datos.
        /// </summary>
        /// <remarks>
        /// Se conecta con la tabla tarjeta grafica de la base de datos y obtiene todas las tuplas transformadas
        /// a objetos tarjeta grafica.
        /// </remarks>
        /// <returns>
        /// Lista de tarjetas graficas de la base de datos.
        /// </returns>
        public async Task<List<TarjetaGrafica>> GetAllTarjetaGraficaAsync()
        {
            List<TarjetaGrafica> listaTarjetasGraficas;
            try
            {
                listaTarjetasGraficas = await conn.Table<TarjetaGrafica>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaTarjetasGraficas = new List<TarjetaGrafica>();
            }
            
            return listaTarjetasGraficas;

        }
    }
}
