using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using BlocNotasCurso.ViewModel.Base;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    public class RegistroViewModel : GeneralViewModel
    {
        public ICommand cmdRegistro { get; set; }

        public string UsernameLabel { get { return "Username"; } }
        public string PasswordLabel { get { return "Password"; } }
        public string NombreLabel { get { return "Nombre"; } }
        public string ApellidosLabel { get { return "Apellidos"; } }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        private Usuario _usuario = new Usuario();
        public RegistroViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            cmdRegistro = new Command(GuardarUsuario);
        }

        private async void GuardarUsuario()
        {
            try
            {
                IsBusy = true;
                var r = await _servicio.AddUsuario(_usuario);
                if (r != null)
                    await _navigator.PushModalAsync<PrincipalViewModel>();
                else
                {
                    var a = "";
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}