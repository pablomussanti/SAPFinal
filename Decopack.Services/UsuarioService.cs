﻿using Decopack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.Servicios;
using Decopack.BLL;

namespace Decopack.Services
{
    public class UsuarioServicio : IUsuarioService
    {
        public List<Usuario> ListarTodos()
        {
            UsuarioBLL UsuarioBLL = new UsuarioBLL();
            return UsuarioBLL.ListarTodos();
        }

        public Usuario Create(Usuario Usuario)
        {
            UsuarioBLL UsuarioBLL = new UsuarioBLL();
            return UsuarioBLL.Create(Usuario);
        }

        public bool Edit(Usuario Usuario)
        {
            UsuarioBLL UsuarioBLL = new UsuarioBLL();
            return UsuarioBLL.Edit(Usuario);
        }

        public Usuario GetByID(int ID)
        {
            UsuarioBLL UsuarioBLL = new UsuarioBLL();
            return UsuarioBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            UsuarioBLL UsuarioBLL = new UsuarioBLL();
            return UsuarioBLL.Delete(ID);
        }
    }
}
