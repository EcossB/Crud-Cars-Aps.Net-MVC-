using Microsoft.AspNetCore.Mvc;
using Segundo_parcial_CRUD.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using Segundo_parcial_CRUD.Models.ViewModels;

namespace Segundo_parcial_CRUD.Controllers
{
    public class AccederController : Controller
    {

        private readonly DbmvcscContext _DBcontext; //aqui el _DBcontext lo que esta tomando referencia de nuestras tablas.

        public AccederController(DbmvcscContext context)
        {
            _DBcontext = context;
        }

  
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(UserVm model)
        {
            if(ModelState.IsValid)
            {
                var User = from m in _DBcontext.Users select m;
                User = User.Where(s => s.Email.Contains(model.oUser.Email));
                if (User.Count() > 0)
                {
                    if(User.First().Password == model.oUser.Password)
                    {
                        return RedirectToAction("Success");
                    }
                }
            }
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Fail()
        {
            return View();
        }
    }
}
