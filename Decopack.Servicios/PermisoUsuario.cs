using Decopack.Servicios.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios
{
    public class Permisousuario
    {
        private Usuario _usuario;
        public Usuario usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
            }
        }

        private Rolpermiso _permiso;
        public Rolpermiso permiso
        {
            get
            {
                return _permiso;
            }
            set
            {
                _permiso = value;
            }
        }
    }

}
