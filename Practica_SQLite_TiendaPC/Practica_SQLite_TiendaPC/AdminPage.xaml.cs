using Practica_SQLite_TiendaPC.Models;
using Practica_SQLite_TiendaPC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica_SQLite_TiendaPC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        private AdminPageViewModel viewModel;

        public AdminPage(Usuario usuario)
        {
            InitializeComponent();

            viewModel = new AdminPageViewModel(usuario);

            BindingContext = viewModel;

            btnDesconectar.Clicked += Desconectar;
            btnPrecios.Clicked += ActualizarPrecios;
        }

        private void ActualizarPrecios(object sender, EventArgs e)
        {
            viewModel.ActualizarPrecios(this);
        }

        private void Desconectar(object sender, EventArgs e)
        {
            viewModel.Desconectar();
        }
    }
}