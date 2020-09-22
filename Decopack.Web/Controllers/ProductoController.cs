using Decopack.EE;
using Decopack.Process;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.Servicios;
using Decopack.Servicios.Bitacora;

namespace Decopack.Web.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;


            ViewBag.CurrentFilter = searchString;

            var ep = new ProductoProcess();


            IEnumerable<Producto> Productos = ep.ListarAPI();

            if (!string.IsNullOrEmpty(searchString))
                Productos = Productos.Where(s => s.Nombre.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    Productos = Productos.OrderByDescending(s => s.Nombre);
                    break;
                case "Date":
                    Productos = Productos.OrderBy(s => s.Id);
                    break;
                default:
                    Productos = Productos.OrderBy(s => s.Nombre);
                    break;
            }


            //return View(clientes.ToList());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Productos.ToPagedList(pageNumber, pageSize));


            //var ep = new EspecieProcess();
            //var lista = ep.ListarAPI();
            //return View(lista);
        }




        //var biz = new ProductoProcess();
        //var lista = biz.ListarAPI();
        //return View(lista);
    


        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            try
            {
                producto.Estado = "Disponible";
                producto.DVH = Decopack.Servicios.Seguridad.GenerarSHA(string.Format("{0}{1}{2}{3}", producto.Nombre, producto.Precio, producto.Estado, producto.Descripcion));

                var biz = new ProductoProcess();

                if (producto.Precio == 0)
                {
                    throw new Exception();
                }

                var model = biz.AgregarAPI(producto);

                return RedirectToAction("Index");


            }
            catch
            {
                Bitacora bitacora = new Bitacora();
                bitacora.descripcion = "Producto";
                bitacora.tipo = "Crear";
                bitacora.user = "pepe";
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new ProductoProcess();
            var Producto = biz.GetByID(id);
            return View(Producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(Producto producto1)
        {
            try
            {
                var biz = new ProductoProcess();
                var producto = biz.GetByID(producto1.Id);
                producto.Nombre = producto1.Nombre;
                producto.Precio = producto1.Precio;
                producto.Descripcion = producto1.Descripcion;
                producto.DVH = Decopack.Servicios.Seguridad.GenerarSHA(string.Format("{0}{1}{2}{3}", producto.Nombre, producto.Precio, producto.Estado, producto.Descripcion));
                if (producto.Precio == 0)
                {
                    throw new Exception();
                }
                bool result = biz.Edit(producto);

                if (result) { return RedirectToAction("Index"); }
                else { return View(); }
            }
            catch (Exception)
            {
                Bitacora bitacora = new Bitacora();
                bitacora.descripcion = "Producto";
                bitacora.tipo = "Editar";
                bitacora.user = "pepe";
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new ProductoProcess();
            var Producto = biz.GetByID(id);
            return View(Producto);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(Producto producto1)
        {
            try
            {
                var biz = new ProductoProcess();
                var producto = biz.GetByID(producto1.Id);

                if (producto.Estado == "Disponible")
                {
                    producto.Estado = "No Disponible";
                }
                else
                {
                    producto.Estado = "Disponible";
                }
                producto.DVH = Decopack.Servicios.Seguridad.GenerarSHA(string.Format("{0}{1}{2}{3}", producto.Nombre, producto.Precio, producto.Estado, producto.Descripcion));
                bool result = biz.Edit(producto);

                if (result) { return RedirectToAction("Index"); }
                else { return View(); }
            }
            catch
            {
                Bitacora bitacora = new Bitacora();
                bitacora.descripcion = "Producto";
                bitacora.tipo = "Eliminar/ReActivar";
                bitacora.user = "pepe";
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }
    }
}
