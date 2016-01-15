using System;
using System.Net.Http.Headers;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    public class LoginViewModel : GeneralViewModel
    {
        public ICommand cmdLogin { get; set; }
        public ICommand cmdRegistro { get; set; }

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

        public LoginViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            cmdLogin = new Command(IniciarSesion);
            cmdRegistro = new Command(NuevoUsuario);
        }

        private async void NuevoUsuario()
        {
            await _navigator.PopToRootAsync();
            await _navigator.PushAsync<RegistroViewModel>(viewModel =>
            {
                Titulo = "Nuevo Usuario";
            });
        }


        private async void IniciarSesion()
        {
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(_usuario);
                if (us != null)
                {
                    await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        Titulo = "Pantalla principal";
                    });
                }
                else
                {
                    var qfd = "";
                }
                // TODO aqui navegariamos a la pantalla principal o dariamos error
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}