using Decopack.Servicios.Composite;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios
{

    public class Usuario : IEntity
    {

        public int Id { get; set; }

        private string _user;

        public string user
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }

        private string _contraseña;

        public string contraseña
        {
            get
            {
                return _contraseña;
            }
            set
            {
                _contraseña = value;
            }
        }

        private string _estadobloqueado;

        public string estadobloqueado
        {
            get
            {
                return _estadobloqueado;
            }
            set
            {
                _estadobloqueado = value;
            }
        }

        public override string ToString()
        {
            return user;
        }

        private List<Rolpermiso> _rolpermiso = new List<Rolpermiso>();
        public List<Rolpermiso> rolpermiso
        {
            get
            {
                return _rolpermiso;
            }
            set
            {
                _rolpermiso = value;
            }
        }
    }

}
