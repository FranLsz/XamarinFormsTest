﻿using System;
using System.Threading.Tasks;
using BlocNotasCurso.Model;

namespace BlocNotasCurso.Service
{
    public interface IServicioDatos
    {
        #region Usuario

        Task<Usuario> ValidarUsuario(Usuario us);

        Task<Usuario> AddUsuario(Usuario us);

        Task<Usuario> UpdateUsuario(Usuario us, string id);

        Task DeleteUsuario(string id);

        #endregion
    }
}