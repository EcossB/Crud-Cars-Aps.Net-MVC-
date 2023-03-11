using Microsoft.AspNetCore.Mvc;
using Segundo_parcial_CRUD.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Segundo_parcial_CRUD.Models.ViewModels;
using Microsoft.CodeAnalysis.VisualBasic;

namespace Segundo_parcial_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbmvcscContext _DBcontext; //aqui el _DBcontext lo que esta tomando referencia de nuestras tablas.

        public HomeController(DbmvcscContext context)
        {
            _DBcontext = context;
        }

        public IActionResult Index()
        {
            List<Auto> list = _DBcontext.Autos.Include(c => c.oEstatus).ToList(); //el include lo que hace es que me agrega el dato del fk
            return View(list);
        }



        [HttpGet] //este metodo es tipo get
        public IActionResult Auto_Detalle(int idAuto)
        {
            AutoVM oautoVM = new AutoVM(){
                oAuto = new Auto(),
                oListaEstatus = _DBcontext.Vhestatuses.Select(estatus => new SelectListItem(){
                    Text = estatus.Descripcion,
                    Value = estatus.Idestatus.ToString()

                }).ToList()
            };

            if (idAuto != 0)
            {
                oautoVM.oAuto = _DBcontext.Autos.Find(idAuto);
            }

            return View(oautoVM);
        }

        [HttpPost] //este metodo es para poder guardar lo vehuivulos en nuestra base de datos
        public IActionResult Auto_Detalle(AutoVM oautoVM)
        {

            if (oautoVM.oAuto.Idauto == 0) //aqui le digo que si el id del auto es igual a 0 es para crear uno nuevo
            {
                _DBcontext.Autos.Add(oautoVM.oAuto); //aqui vamos a nuestra DB y agregamos el parameto que nos da el VM
            }
            else
            {
                _DBcontext.Autos.Update(oautoVM.oAuto);
            }

            _DBcontext.SaveChanges();

            return RedirectToAction("index", "Home"); //cuando se termine de guardar la lista de empleados redirige a la pagina principal.
        }


        [HttpGet]
        public IActionResult Eliminar( int idAuto)
        {
            Auto oAuto = _DBcontext.Autos.Include(e => e.oEstatus).Where(a => a.Idauto == idAuto).FirstOrDefault();

            return View(oAuto);
        }

        [HttpPost]
        public IActionResult Eliminar(Auto oAuto)
        {
            _DBcontext.Autos.Remove(oAuto);
            _DBcontext.SaveChanges();

            return RedirectToAction("index", "Home");
        }



        [HttpGet]
        public IActionResult login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult login(string user, string password)
        {
            var User = _DBcontext.Users.SingleOrDefault(u => u.Email == user && u.Password == password);

            if (User == null)
            {
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
                return View();
            }


            return RedirectToAction("Index", "Home");
        }

    }

}