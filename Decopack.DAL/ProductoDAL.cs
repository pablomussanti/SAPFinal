using Decopack.EE;
using Safari.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.DAL
{
    public partial class ProductoDAL : DataAccessComponent, IRepository<Producto>
    {
        public Producto Create(Producto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> Read()
        {
            throw new NotImplementedException();
        }

        public Producto ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
