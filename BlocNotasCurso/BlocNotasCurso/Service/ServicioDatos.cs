
using System;
using System.Linq;
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


        public async Task<Usuario> ValidarUsuario(Usuario us)
        {
            var tabla = client.GetTable<Usuario>();
            var data = await tabla.CreateQuery().
                Where(o => o.Username == us.Username && o.Password == us.Password).
                ToListAsync();

            return !data.Any() ? null : data[0];
        }

        public async Task<Usuario> AddUsuario(Usuario us)
        {
            var tabla = client.GetTable<Usuario>();
            var data = await tabla.CreateQuery().Where(o => o.Username == us.Username).ToListAsync();

            if (data.Any())
                throw new Exception("Usuario ya registrado");

            try
            {
                await tabla.InsertAsync(us);
            }
            catch (Exception e)
            {
                throw new Exception("Error al registrar el usario");
            }

            return us;
        }

        public async Task<Usuario> UpdateUsuario(Usuario us, string id)
        {
            var tabla = client.GetTable<Usuario>();
            var data = await tabla.CreateQuery().Where(o => o.Username == us.Username).ToListAsync();

            if (data.Any())
                throw new Exception("Usuario ya registrado");

            try
            {
                await tabla.InsertAsync(us);
            }
            catch (Exception e)
            {
                throw new Exception("Error al registrar el usario");
            }

            return us;
        }

        public Task DeleteUsuario(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
