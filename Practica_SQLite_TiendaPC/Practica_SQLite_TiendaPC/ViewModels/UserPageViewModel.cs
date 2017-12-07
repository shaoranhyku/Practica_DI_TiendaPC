using Practica_SQLite_TiendaPC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Practica_SQLite_TiendaPC.ViewModels
{
    class UserPageViewModel : INotifyPropertyChanged
    {
        #region Campos
        //Lista de placas bases
        private List<Placa> listaPlaca;
        //Lista de procesadores
        private List<Microprocesador> listaProcesador;
        //Lista de torres
        private List<Torre> listaTorre;
        //Lista de memorias
        private List<Memoria> listaMemoria;
        //Lista de tarjetasgraficas
        private List<TarjetaGrafica> listaTarjetaGrafica;
        //Lista de productos
        private List<Producto> pedidoActual;
        //Indice seleccionado de placa
        private int indicePlaca;
        //Indice seleccinado de procesador
        private int indiceProcesador;
        //Indice seleccionado de torre
        private int indiceTorre;
        //Indice seleccionado de memoria
        private int indiceMemoria;
        //Indice seleccionado de tarjeta grafica
        private int indiceTarjetaGrafica;
        //Mensaje de bienvenida
        private String mensajeBienvenida;
        //Estado del boton aceptar
        private bool estadoAceptar;
        //Estado del boton confirmar
        private bool estadoConfirmar;
        //Precio total del pedido
        private double precioTotal;
        //Usuario actual
        private Usuario usuario;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor del view model de la vista UserPage.
        /// </summary>
        /// <param name="usuario">Usuario actual.</param>
        public UserPageViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            InicializarValores();
            
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Lista de placas bases.
        /// </summary>
        public List<Placa> ListaPlaca
        {
            get
            {
                return listaPlaca;
            }
            set
            {
                if (listaPlaca != value)
                {
                    listaPlaca = value;
                    OnPropertyChanged("ListaPlaca");
                }
            }
        }
        /// <summary>
        /// Lista de microprocesadores.
        /// </summary>
        public List<Microprocesador> ListaProcesador
        {
            get
            {
                return listaProcesador;
            }
            set
            {
                if (listaProcesador != value)
                {
                    listaProcesador = value;
                    OnPropertyChanged("ListaProcesador");
                }
            }
        }
        /// <summary>
        /// Lista de torres.
        /// </summary>
        public List<Torre> ListaTorre
        {
            get
            {
                return listaTorre;
            }
            set
            {
                if (listaTorre != value)
                {
                    listaTorre = value;
                    OnPropertyChanged("ListaTorre");
                }
            }
        }
        /// <summary>
        /// Lista de memorias.
        /// </summary>
        public List<Memoria> ListaMemoria
        {
            get
            {
                return listaMemoria;
            }
            set
            {
                if (listaMemoria != value)
                {
                    listaMemoria = value;
                    OnPropertyChanged("ListaMemoria");
                }
            }
        }
        /// <summary>
        /// Lista de tarjetas graficas.
        /// </summary>
        public List<TarjetaGrafica> ListaTarjetaGrafica
        {
            get
            {
                return listaTarjetaGrafica;
            }
            set
            {
                if (listaTarjetaGrafica != value)
                {
                    listaTarjetaGrafica = value;
                    OnPropertyChanged("ListaTarjetaGrafica");
                }
            }
        }
        /// <summary>
        /// Indice acutal de placa.
        /// </summary>
        public int IndicePlaca
        {
            get
            {
                return indicePlaca;
            }
            set
            {
                if (indicePlaca != value)
                {
                    indicePlaca = value;
                    OnPropertyChanged("IndicePlaca");
                }
            }
        }
        /// <summary>
        /// Indice actual de procesador.
        /// </summary>
        public int IndiceProcesador
        {
            get
            {
                return indiceProcesador;
            }
            set
            {
                if (indiceProcesador != value)
                {
                    indiceProcesador = value;
                    OnPropertyChanged("IndiceProcesador");
                }
            }
        }
        /// <summary>
        /// Indice actual de torre.
        /// </summary>
        public int IndiceTorre
        {
            get
            {
                return indiceTorre;
            }
            set
            {
                if (indiceTorre != value)
                {
                    indiceTorre = value;
                    OnPropertyChanged("IndiceTorre");
                }
            }
        }
        /// <summary>
        /// Indice actual de memoria.
        /// </summary>
        public int IndiceMemoria
        {
            get
            {
                return indiceMemoria;
            }
            set
            {
                if (indiceMemoria != value)
                {
                    indiceMemoria = value;
                    OnPropertyChanged("IndiceMemoria");
                }
            }
        }
        /// <summary>
        /// Indice actual de tarjeta grafica
        /// </summary>
        public int IndiceTarjetaGrafica
        {
            get
            {
                return indiceTarjetaGrafica;
            }
            set
            {
                if (indiceTarjetaGrafica != value)
                {
                    indiceTarjetaGrafica = value;
                    OnPropertyChanged("IndiceTarjetaGrafica");
                }
            }
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
        /// Estado del boton aceptar.
        /// </summary>
        public bool EstadoAceptar
        {
            get
            {
                return estadoAceptar;
            }
            set
            {
                if (estadoAceptar != value)
                {
                    estadoAceptar = value;
                    OnPropertyChanged("EstadoAceptar");
                }
            }
        }
        /// <summary>
        /// Estado del boton confirmar.
        /// </summary>
        public bool EstadoConfirmar
        {
            get
            {
                return estadoConfirmar;
            }
            set
            {
                if (estadoConfirmar != value)
                {
                    estadoConfirmar = value;
                    OnPropertyChanged("EstadoConfirmar");
                }
            }
        }
        /// <summary>
        /// Precio total del producto actual.
        /// </summary>
        public double PrecioTotal
        {
            get
            {
                return precioTotal;
            }
            set
            {
                if (precioTotal != value)
                {
                    precioTotal = value;
                    OnPropertyChanged("PrecioTotal");
                }
            }
        }
        /// <summary>
        /// Lista de productos del pedido actual.
        /// </summary>
        public List<Producto> PedidoActual
        {
            get
            {
                return pedidoActual;
            }
            set
            {
                if (pedidoActual != value)
                {
                    pedidoActual = value;
                    OnPropertyChanged("PedidoActual");
                }
            }
        }
        #endregion

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

        #region Metodos

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
        /// Comprueba que se haya seleccionado todos los productos.
        /// </summary>
        /// <remarks>
        /// Comprueba que todos los selectores de productos tienen un producto seleccionado.
        /// En caso afirmativo, habilita el botón de aceptar. Si no, lo desabilita.
        /// </remarks>
        public void ComprobarComponentes()
        {
            if (IndicePlaca != -1 &&
                IndiceProcesador != -1 &&
                IndiceTorre != -1 &&
                IndiceMemoria != -1 &&
                IndiceTarjetaGrafica != -1)
            {
                EstadoAceptar = true;
            }
            else
            {
                EstadoAceptar = false;
            }
        }
        /// <summary>
        /// Agrega los componentes seleccionados a la lista.
        /// </summary>
        /// <remarks>
        /// Toma los valores de los productos seleccionados, los agrega a una lista y asocia tal lista
        /// a la ViewList, además de actualizar el precio total del pedido actual.
        /// </remarks>
        public void AgregarComponentes()
        {
            List<Producto> componentes = new List<Producto>();

            componentes.Add(ListaPlaca.ElementAt(IndicePlaca));
            componentes.Add(ListaProcesador.ElementAt(IndiceProcesador));
            componentes.Add(ListaTorre.ElementAt(IndiceTorre));
            componentes.Add(ListaMemoria.ElementAt(IndiceMemoria));
            componentes.Add(ListaTarjetaGrafica.ElementAt(IndiceTarjetaGrafica));

            PedidoActual = componentes;
            EstadoConfirmar = true;

            PrecioTotal = ListaPlaca.ElementAt(IndicePlaca).Precio +
            ListaProcesador.ElementAt(IndiceProcesador).Precio +
            ListaTorre.ElementAt(IndiceTorre).Precio +
            ListaMemoria.ElementAt(IndiceMemoria).Precio +
            ListaTarjetaGrafica.ElementAt(IndiceTarjetaGrafica).Precio;
        }
        /// <summary>
        /// Realiza el pedido de los productos seleccionados.
        /// </summary>
        /// <remarks>
        /// Añade a la tabla pedido una tupla con los datos de los productos seleccionados y
        /// el usuario que lo ha realizado. Luego, muestra un mensaje y vuelve a cargar la página.
        /// </remarks>
        public async void RealizarPedido(Page actualPage)
        {
            await App.PedidoRepo.AddNewPedidoAsync(usuario.CodUsuario,
                ListaPlaca.ElementAt(IndicePlaca).Id,
                ListaProcesador.ElementAt(IndiceProcesador).Id,
                ListaTorre.ElementAt(IndiceTorre).Id,
                ListaMemoria.ElementAt(IndiceMemoria).Id,
                ListaTarjetaGrafica.ElementAt(IndiceTarjetaGrafica).Id);

            actualPage.DisplayAlert("Pedido realizado correctamente.", "", "Aceptar");
            App.Current.MainPage = new UserPage(usuario);
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
            ListaPlaca = new List<Placa>(await App.PlacaRepo.GetAllPlacaAsync());
            ListaProcesador = new List<Microprocesador>(await App.MicroRepo.GetAllMicroprocesadorAsync());
            ListaTorre = new List<Torre>(await App.TorreRepo.GetAllTorreAsync());
            ListaMemoria = new List<Memoria>(await App.MemoriaRepo.GetAllMemoriaAsync());
            ListaTarjetaGrafica = new List<TarjetaGrafica>(await App.GraficaRepo.GetAllTarjetaGraficaAsync());
            IndicePlaca = -1;
            IndiceProcesador = -1;
            IndiceTorre = -1;
            IndiceMemoria = -1;
            IndiceTarjetaGrafica = -1;
        }
        #endregion

    }
}
