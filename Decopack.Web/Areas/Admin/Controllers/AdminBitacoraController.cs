using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.Process;

namespace Decopack.Web.Areas.Admin.Controllers
{
    
    public class AdminBitacoraController : Controller
    {
        // GET: Admin/AdminBitacora
        public ActionResult Index()
        {
            //BitacoraProcess
            BitacoraProcess BitacoraProcess = new BitacoraProcess();

            return View(BitacoraProcess.ListarTodos());
        }


    }
}
