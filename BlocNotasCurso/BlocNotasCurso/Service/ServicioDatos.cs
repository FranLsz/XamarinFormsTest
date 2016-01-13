
using System.Threading.Tasks;
using BlocNotasCurso.Model;
using BlocNotasCurso.Util;
using Microsoft.WindowsAzure.MobileServices;

namespace BlocNotasCurso.Service
{
    public class ServicioDatos : IServicioDatos
    {
        private MobileServiceClient client;


        public ServicioDatos()
        {
            client = new MobileServiceClient(Cadenas.UrlServicio, Cadenas.TokenServicio);
        }


        public Task<Usuario> ValidarUsuario(Usuario us)
        {
            throw new System.NotImplementedException();
        }

        public Task<Usuario> AddUsuario(Usuario us)
        {
            throw new System.NotImplementedException();
        }

        public Task<Usuario> UpdateUsuario(Usuario us, string id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUsuario(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
