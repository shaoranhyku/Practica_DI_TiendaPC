using Practica_SQLite_TiendaPC.Models;
using Practica_SQLite_TiendaPC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Practica_SQLite_TiendaPC
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();

            viewModel = new MainPageViewModel();

            BindingContext = viewModel;

            btnLogin.Clicked += BtnLoginClick;
        }

        #region Eventos

        /// <summary>
        /// Intenta iniciar sesión en la aplicación tomando los valores introducidos en los campos.
        /// </summary>
        /// <remarks>
        /// Con los valores introducidos en los campos intenta iniciar sesión. Comprobará que los valores 
        /// no son nulos o vacios. Traerá los datos de la base de datos y comprobará si el usuario existe.
        /// Si el usuario no existe, se actualizará el mensaje de error.
        /// Si el usuario existe y es un usuario normal, se cambiará la página por la página de usuario
        /// para realizar pedidos.
        /// Si el usuario existe y es un administrador, se cambiará la página por la página de administrados
        /// para comprobar pedidos y actualizar precios.
        /// </remarks>
        /// <param name="sender"> Objeto que lanza el evento </param>
        /// <param name="e"> Argumentos del evento </param>
        private void BtnLoginClick(object sender, EventArgs e)
        {
            viewModel.Login();
        }

        #endregion
    }
}
