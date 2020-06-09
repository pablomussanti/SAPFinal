using Decopack.EE;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.Services.Contracts.Requests;
using Decopack.Services.Contracts.Responses;

namespace Decopack.Process
{
   public class ProductoProcess : ProcessComponent
    {


        public IList<Producto> ListarAPI()
        {
            var response = HttpGet<ListarTodosProductoResponse>("api/Producto/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Producto AgregarAPI(Producto Producto)
        {

            AgregarProductoResponse dto = new AgregarProductoResponse();
            dto.Result = Producto;
            var request = HttpPost("api/Producto/Agregar", dto, MediaType.Json);
            return request.Result;
        }
    }
}
