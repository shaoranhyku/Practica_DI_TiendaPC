using Practica_SQLite_TiendaPC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practica_SQLite_TiendaPC.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        #region Campos
        //Nombre del usuario
        private string nombreUsuario = "";
        //Contraseña del usuario
        private string contraUsuario = "";
        //Mensaje de error
        private string mensajeError = "";
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string NombreUsuario
        {
            get
            {
                return nombreUsuario;
            }
            set
            {
                if (nombreUsuario != value)
                {
                    if(value != null && value.Length <=4)
                    {
                        nombreUsuario = value;
                    }
                    OnPropertyChanged("NombreUsuario");
                }
            }
        }
        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string ContraUsuario
        {
            get
            {
                return contraUsuario;
            }
            set
            {
                if (contraUsuario != value)
                {
                    if (value != null && value.Length <= 10)
                    {
                        contraUsuario = value;
                    }
                    OnPropertyChanged("ContraUsuario");
                }
            }
        }
        /// <summary>
        /// Mensaje de error.
        /// </summary>
        public string MensajeError
        {
            get
            {
                return mensajeError;
            }
            set
            {
                if (mensajeError != value)
                {
                    mensajeError = value;
                    OnPropertyChanged("MensajeError");
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
        public async void Login()
        {
            if (ComprobarCamposLogin())
            {
                List<Usuario> usuarios = new List<Usuario>(await App.UsuarioRepo.ObtenerUsuarios());

                Usuario usuarioResultado = usuarios.SingleOrDefault(t => t.CodUsuario == NombreUsuario);

                if (usuarioResultado == null)
                {
                    MensajeError = "El usuario no existe.";
                }
                else if(usuarioResultado.Contra != contraUsuario)
                {
                    MensajeError = "Contraseña incorrecta.";
                }
                else if (usuarioResultado.Tipo == "usuario")
                {
                    App.Current.MainPage = new UserPage(usuarioResultado);
                }
                else if (usuarioResultado.Tipo == "admin")
                {
                    App.Current.MainPage = new AdminPage(usuarioResultado);
                }
            }
        }

        /// <summary>
        /// Comprueba los datos introducidos en los campos para iniciar sesión.
        /// </summary>
        /// <remarks>
        /// Comprueba que los datos introducidos en los campos lblNombreUsuario y lblContraUsuario
        /// son válidos, es decir, que no sean campos vacios o nulos.
        /// </remarks>
        /// <returns>
        /// Si ambos campos no son nulos o vacios, devuelve false.
        /// En caso contrario, devuelve true.
        /// </returns>
        private bool ComprobarCamposLogin()
        {
            bool esCorrecto = true;
            if (String.IsNullOrEmpty(NombreUsuario) && String.IsNullOrEmpty(ContraUsuario))
            {
                MensajeError = "Debe introducir codigo de usuario y contraseña.";
                esCorrecto = false;
            }
            else if (String.IsNullOrEmpty(NombreUsuario))
            {
                MensajeError = "Debe introducir codigo de usuario.";
                esCorrecto = false;
            }
            else if (String.IsNullOrEmpty(ContraUsuario))
            {
                MensajeError = "Debe introducir contraseña.";
                esCorrecto = false;
            }
            else
            {
                MensajeError = "";
            }

            return esCorrecto;
        }
        #endregion

    }
}
