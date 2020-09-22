using Decopack.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.EE;

namespace Decopack.Web.Areas.Admin.Controllers
{
    public class IntegridadController : Controller
    {
        int contador;
        // GET: Admin/ControldeCambios
        public ActionResult Index()
        {
            var biz = new ProductoProcess();
            var Producto = biz.ListarAPI();
            var productosm = new List<Producto>();

            foreach (var item in Producto)
            {
                if (item.DVH == Decopack.Servicios.Seguridad.GenerarSHA(string.Format("{0}{1}{2}{3}", item.Nombre, item.Precio, item.Estado, item.Descripcion)))
                {
                    contador = +1;
                }
                else
                {
                    productosm.Add(item);
                }
            }

            if (contador == Producto.Count)
            {
                ViewBag.advertencia = "Los datos no sufrieron modificaciones";
            }
            else
            {
                ViewBag.advertencia = "Se modificaron los codigos: ";
                foreach (var item in productosm)
                {
                    ViewBag.advertencia = string.Format(ViewBag.advertencia + " {0} ", item.Id);
                }
            }


            return View(Producto);
        }
   

    }
}
