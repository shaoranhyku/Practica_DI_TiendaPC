using Practica_SQLite_TiendaPC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace Practica_SQLite_TiendaPC.ViewModels
{
    class AdminPageViewModel : INotifyPropertyChanged
    {
        //Mensaje de bienvenida
        private String mensajeBienvenida;
        //Usuario actual
        private Usuario usuario;
        //Lista de pedidos
        private List<ListaPedidoItem> listaPedidos;

        public AdminPageViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            InicializarValores();
        }

        /// <summary>
        /// Mensaje de bienvenida.
        /// </summary>
        public string MensajeBienvenida
        {
            get
            {
                return mensajeBienvenida;
            }
            set
            {
                if (mensajeBienvenida != value)
                {
                    mensajeBienvenida = value;
                    OnPropertyChanged("MensajeBienvenida");
                }
            }
        }

        /// <summary>
        /// Lista de pedidos realizados.
        /// </summary>
        public List<ListaPedidoItem> ListaPedidos
        {
            get
            {
                return listaPedidos;
            }
            set
            {
                if (listaPedidos != value)
                {
                    listaPedidos = value;
                    OnPropertyChanged("ListaPedidos");
                }
            }
        }

        #region Elementos Interfaz INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        /// <summary>
        /// Cierra la sesión del usuario actual.
        /// </summary>
        /// <remarks>
        /// Cierra la sesión del usuario actual, devolviendolo a la pantalla de login.
        /// </remarks>
        public void Desconectar()
        {
            App.Current.MainPage = new MainPage();
        }

        /// <summary>
        /// Inicializa los campos.
        /// </summary>
        /// <remarks>
        /// Da un valor inicial a los valores que han sido bindeados con el View.
        /// </remarks>
        public async void InicializarValores()
        {
            MensajeBienvenida = String.Format("Bienvenido {0}", usuario.Nombre);

            List<Usuario> ListaUsuario = new List<Usuario>(await App.UsuarioRepo.ObtenerUsuarios());
            List<Placa> ListaPlaca = new List<Placa>(await App.PlacaRepo.ObtenerPlacas());
            List<Microprocesador> ListaProcesador = new List<Microprocesador>(await App.MicroRepo.ObtenerMicroprocesadores());
            List<Torre> ListaTorre = new List<Torre>(await App.TorreRepo.ObtenerTorres());
            List<Memoria> ListaMemoria = new List<Memoria>(await App.MemoriaRepo.ObtenerMemorias());
            List<TarjetaGrafica> ListaTarjetaGrafica = new List<TarjetaGrafica>(await App.GraficaRepo.ObtenerTarjetasGraficas());
            List<Pedido> ListaPedidosId =  new List<Pedido>(await App.PedidoRepo.ObtenerPedidos());
            List<ListaPedidoItem> ListaCompleta = new List<ListaPedidoItem>();
            
            foreach(Pedido pedido in ListaPedidosId)
            {
                ListaCompleta.Add(new ListaPedidoItem()
                {
                    NombreUsuario = ListaUsuario.SingleOrDefault(t => t.CodUsuario == pedido.IdUsuario).Nombre,
                    NombrePlaca = ListaPlaca.SingleOrDefault(t => t.Id == pedido.IdPlaca).Nombre,
                    NombreMicroprocesador = ListaProcesador.SingleOrDefault(t => t.Id == pedido.IdMicroprocesador).Nombre,
                    NombreTorre = ListaTorre.SingleOrDefault(t => t.Id == pedido.IdTorre).Nombre,
                    NombreMemoria = ListaMemoria.SingleOrDefault(t => t.Id == pedido.IdMemoria).Nombre,
                    NombreTarjetaGrafica = ListaTarjetaGrafica.SingleOrDefault(t => t.Id == pedido.IdTarjetaGrafica).Nombre,
                    PrecioPedido = ListaPlaca.SingleOrDefault(t => t.Id == pedido.IdPlaca).Precio +
                    ListaProcesador.SingleOrDefault(t => t.Id == pedido.IdMicroprocesador).Precio +
                    ListaTorre.SingleOrDefault(t => t.Id == pedido.IdTorre).Precio +
                    ListaMemoria.SingleOrDefault(t => t.Id == pedido.IdMemoria).Precio +
                    ListaTarjetaGrafica.SingleOrDefault(t => t.Id == pedido.IdTarjetaGrafica).Precio
                }
                );
            }

            ListaPedidos = ListaCompleta;
        }

        /// <summary>
        /// Actualiza los precios de los productos.
        /// </summary>
        /// <remarks>
        /// Borra todos los productos e introduce los productos que aparecen en el fichero XML.
        /// </remarks>
        public async void ActualizarPrecios(Page actualPage)
        {
            List<Memoria> nuevaListaMemoria = new List<Memoria>();
            List<Microprocesador> nuevaListaMicroprocesador = new List<Microprocesador>();
            List<Placa> nuevaListaPlaca = new List<Placa>();
            List<TarjetaGrafica> nuevaListaTarjetaGrafica = new List<TarjetaGrafica>();
            List<Torre> nuevaListaTorre = new List<Torre>();

            var assembly = typeof(AdminPageViewModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Practica_SQLite_TiendaPC.Data.Precios.xml");
            StreamReader objReader = new StreamReader(stream);
            var doc = XDocument.Load(stream);

            foreach (XElement element in doc.Root.Element("Memorias").Elements())
            {
                nuevaListaMemoria.Add(new Memoria
                {
                    Id = element.Element("ID").Value,
                    Nombre = element.Element("NOMBRE").Value,
                    Precio = double.Parse(element.Element("PRECIO").Value)
                });
            }

            foreach (XElement element in doc.Root.Element("Procesadores").Elements())
            {
                nuevaListaMicroprocesador.Add(new Microprocesador
                {
                    Id = element.Element("ID").Value,
                    Nombre = element.Element("NOMBRE").Value,
                    Precio = double.Parse(element.Element("PRECIO").Value)
                });
            }

            foreach (XElement element in doc.Root.Element("Placas").Elements())
            {
                nuevaListaPlaca.Add(new Placa
                {
                    Id = element.Element("ID").Value,
                    Nombre = element.Element("NOMBRE").Value,
                    Precio = double.Parse(element.Element("PRECIO").Value)
                });
            }

            foreach (XElement element in doc.Root.Element("Graficas").Elements())
            {
                nuevaListaTarjetaGrafica.Add(new TarjetaGrafica
                {
                    Id = element.Element("ID").Value,
                    Nombre = element.Element("NOMBRE").Value,
                    Precio = double.Parse(element.Element("PRECIO").Value)
                });
            }

            foreach (XElement element in doc.Root.Element("Torres").Elements())
            {
                nuevaListaTorre.Add(new Torre
                {
                    Id = element.Element("ID").Value,
                    Nombre = element.Element("NOMBRE").Value,
                    Precio = double.Parse(element.Element("PRECIO").Value)
                });
            }

            App.MemoriaRepo.BorrarTabla();

            foreach (Memoria memoria in nuevaListaMemoria)
            {
                await App.MemoriaRepo.AgregarMemoria(memoria);
            }

            App.MicroRepo.BorrarTabla();

            foreach (Microprocesador procesador in nuevaListaMicroprocesador)
            {
                
                await App.MicroRepo.AgregarMicroprocesador(procesador);
            }

            App.PlacaRepo.BorrarTabla();

            foreach (Placa placa in nuevaListaPlaca)
            {
                await App.PlacaRepo.AgregarPlaca(placa);
            }

            App.GraficaRepo.BorrarTabla();

            foreach (TarjetaGrafica grafica in nuevaListaTarjetaGrafica)
            {
                await App.GraficaRepo.AgregarTarjetaGrafica(grafica);
            }

            App.TorreRepo.BorrarTabla();

            foreach (Torre torre in nuevaListaTorre)
            {
                await App.TorreRepo.AgregarTorre(torre);
            }

            actualPage.DisplayAlert("Precios actualizados correctamente.", "", "Aceptar");
            App.Current.MainPage = new AdminPage(usuario);

        }

    }
}
