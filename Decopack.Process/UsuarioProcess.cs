using Decopack.Services.Contracts;
using Decopack.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.Servicios;

namespace Decopack.Process
{
    public class UsuarioProcess : ProcessComponent
    {

        IUsuarioService UsuarioService = Framework.Common.ServiceFactory.Get<IUsuarioService>();

        public IList<Usuario> Listar()
        {
            return UsuarioService.ListarTodos();
        }

        public Usuario Crear(Usuario Usuario)
        {

            return UsuarioService.Create(Usuario);
        }

        public bool Edit(Usuario Usuario)
        {
            return UsuarioService.Edit(Usuario);
        }

        public Usuario GetByID(int ID)
        {
            return UsuarioService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return UsuarioService.Delete(ID);
        }
    }
}
