using Practica_SQLite_TiendaPC.Models;
using Practica_SQLite_TiendaPC.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica_SQLite_TiendaPC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        private UserPageViewModel viewModel;

        public UserPage(Usuario usuario)
        {
            InitializeComponent();

            viewModel = new UserPageViewModel(usuario);

            BindingContext = viewModel;

            pckPlaca.SelectedIndexChanged += comprobarComponentes;
            pckProcesador.SelectedIndexChanged += comprobarComponentes;
            pckTorre.SelectedIndexChanged += comprobarComponentes;
            pckMemoria.SelectedIndexChanged += comprobarComponentes;
            pckTarjetaGrafica.SelectedIndexChanged += comprobarComponentes;

            btnAceptar.Clicked += agregarComponentes;
            btnConfirmar.Clicked += realizarPedidoAsync;
        }

        #region Eventos

        /// <summary>
        /// Realiza el pedido de los productos seleccionados.
        /// </summary>
        /// <remarks>
        /// Añade a la tabla pedido una tupla con los datos de los productos seleccionados y
        /// el usuario que lo ha realizado. Luego, muestra un mensaje y vuelve a cargar la página.
        /// </remarks>
        /// <param name="sender">Objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void realizarPedidoAsync(object sender, EventArgs e)
        {
            viewModel.RealizarPedido(this);
        }

        /// <summary>
        /// Comprueba que se haya seleccionado todos los productos.
        /// </summary>
        /// <remarks>
        /// Comprueba que todos los selectores de productos tienen un producto seleccionado.
        /// </remarks>
        /// <param name="sender">Objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void comprobarComponentes(object sender, EventArgs e)
        {
            viewModel.ComprobarComponentes();
        }

        /// <summary>
        /// Agrega los componentes seleccionados a la lista.
        /// </summary>
        /// <remarks>
        /// Toma los valores de los productos seleccionados, los agrega a una lista y asocia tal lista
        /// a la ViewList, además de actualizar el precio total del pedido actual.
        /// </remarks>
        /// <param name="sender">Objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void agregarComponentes(object sender, EventArgs e)
        {
            viewModel.AgregarComponentes();
        }

        #endregion

    }
        
}