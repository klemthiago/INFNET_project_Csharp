using ProjetoINFNET.Domain.Interfaces.Domain;
using ProjetoINFNET.UI.Web.ViewModels;
using ProjetoINFNET.UI.Web.Util;
using System.Web.Mvc;

namespace ProjetoINFNET.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServiceDomain _userServiceDomain;
        public AccountController(IUserServiceDomain userServiceDomain)
        {
            _userServiceDomain = userServiceDomain;
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var usuario = _userServiceDomain.LogaUsuario(viewModel.Email, viewModel.Password);
            if(usuario == null)
            {
                ModelState.AddModelError("", "Email ou Senha incorretos!");
                return View(viewModel);
            }

            SessionManager.UsuarioLogado = usuario;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logoff()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}