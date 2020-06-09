using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios.Bitacora
{

    public abstract class Bitacorageneral
    {
        private DateTime _fecha;

        public DateTime fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }

        private string _descripcion;

        public string descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        private string _tipo;

        public string tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
            }
        }

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
    }

}
