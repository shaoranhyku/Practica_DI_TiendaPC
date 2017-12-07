using Practica_SQLite_TiendaPC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_SQLite_TiendaPC.ViewModels
{
    class AdminPageViewModel : INotifyPropertyChanged
    {
        //Mensaje de bienvenida
        private String mensajeBienvenida;
        //Usuario actual
        private Usuario usuario;
        //Lista de pedidos
        private List<Pedido> listaPedidos;

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
        public List<Pedido> ListaPedidos
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
            //TODO: Hacer una lista de pedido donde se vean los nombre y no los ID
            ListaPedidos =  new List<Pedido>(await App.PedidoRepo.GetAllPedidoAsync());

        }

        /// <summary>
        /// Actualiza los precios de los productos.
        /// </summary>
        /// <remarks>
        /// Borra todos los productos e introduce los productos que aparecen en el fichero XML.
        /// </remarks>
        public async void ActualizarPrecios()
        {
            //TODO: Leer fichero, borrar tablas y crear los nuevos productos

        }

    }
}
