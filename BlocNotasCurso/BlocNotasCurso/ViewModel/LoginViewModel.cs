using System.Net.Http.Headers;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;

namespace BlocNotasCurso.ViewModel
{
    public class LoginViewModel : GeneralViewModel
    {
        private ICommand cmdLogin;
        private ICommand cmdRegistro;

        public string TituloIniciar { get { return "Iniciar sesión"; } }
        public string TituloRegistro { get { return "Nuevo usuario"; } }
        public string TituloLogin { get { return "Nombre de usuario"; } }
        public string TituloPassword { get { return "Contraseña"; } }

        private Usuario _usuario = new Usuario();
        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public LoginViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio{ }

    }
}