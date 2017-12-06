using Practica_SQLite_TiendaPC.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Practica_SQLite_TiendaPC
{
    public partial class App : Application
    {
        public static MemoriaRepository MemoriaRepo { get; set; }
        public static MicroprocesadorRepository MicroRepo { get; set; }
        public static PedidoRepository PedidoRepo { get; set; }
        public static PlacaRepository PlacaRepo { get; set; }
        public static TarjetaGraficaRepository GraficaRepo { get; set; }
        public static TorreRepository TorreRepo { get; set; }
        public static UsuarioRepository UsuarioRepo { get; set; }

        public App(string filename)
        {
            InitializeComponent();

            MemoriaRepo = new MemoriaRepository(filename);
            MicroRepo = new MicroprocesadorRepository(filename);
            PedidoRepo = new PedidoRepository(filename);
            PlacaRepo = new PlacaRepository(filename);
            GraficaRepo = new TarjetaGraficaRepository(filename);
            TorreRepo = new TorreRepository(filename);
            UsuarioRepo = new UsuarioRepository(filename);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
