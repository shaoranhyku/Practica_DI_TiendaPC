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
    /// Repositorio que nos permite conectar con la tabla pedido de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Esta clase contiene metodos para conectarse con nuestra base de datos y acceder a la tabla
    /// pedido.
    /// </remarks>
    public class PedidoRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public PedidoRepository(string dbPath)
        {
           
            conn = new SQLiteAsyncConnection(dbPath);
         
            conn.CreateTableAsync<Pedido>().Wait();
        }

        /// <summary>
        /// Permite añadir un pedido a la tabla pedido.
        /// </summary>
        /// <remarks>
        /// Realiza una conexión con la tabla pedido de nuestra base de datos,
        /// añadiendo una tupla con los parametros dados.
        /// </remarks>
        /// <param name="idUsuario">Id del usuario que realiza el pedido.</param>
        /// <param name="idPlaca">Id de la placa comprada en el pedido.</param>
        /// <param name="idMicroprocesador">Id del microprocesador comprada en el pedido.</param>
        /// <param name="idTorre">Id de la torre comprada en el pedido.</param>
        /// <param name="idMemoria">Id de la memoria comprada en el pedido.</param>
        /// <param name="idTarjetaGrafica">Id de la tarjeta grafica comprada en el pedido.</param>
        /// <returns>Tarea de añadir la tupla a la base de datos.</returns>
        public async Task AddNewPedidoAsync(string idUsuario, string idPlaca, string idMicroprocesador, string idTorre, string idMemoria, string idTarjetaGrafica)
        {
            int result = 0;
            try
            {
                result = await conn.InsertAsync(new Pedido { IdUsuario = idUsuario, IdPlaca = idPlaca , IdMicroprocesador = idMicroprocesador, IdTorre = idTorre, IdMemoria = idMemoria, IdTarjetaGrafica = idTarjetaGrafica});

                StatusMessage = string.Format("{0} record(s) added [Usuario: {1}, Placa: {2}, Microprocesador: {3}, Torre: {4}, Memoria: {5}, Tarjeta Grafica: {6})", result, idUsuario, idPlaca, idMicroprocesador, idTorre, idMemoria, idTarjetaGrafica);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add. Error: {1}", ex.Message);
            }

        }

        /// <summary>
        /// Permite obtener una lista con todos los pedidos de la base de datos.
        /// </summary>
        /// <remarks>
        /// Se conecta con la tabla pedido de la base de datos y obtiene todas las tuplas transformadas
        /// a objetos pedido.
        /// </remarks>
        /// <returns>
        /// Lista de pedidos de la base de datos.
        /// </returns>
        public async Task<List<Pedido>> GetAllPedidoAsync()
        {
            List<Pedido> listaPedidos;
            try
            {
                listaPedidos = await conn.Table<Pedido>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaPedidos = new List<Pedido>();
            }
            
            return listaPedidos;

        }
    }
}
