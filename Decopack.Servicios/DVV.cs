using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios
{
    public class DVV
    {
        private string _entidad;

        public string entidad
        {
            get
            {
                return _entidad;
            }
            set
            {
                _entidad = value;
            }
        }

        private string _dvv;

        public string dvv
        {
            get
            {
                return _dvv;
            }
            set
            {
                _dvv = value;
            }
        }
    }

}
