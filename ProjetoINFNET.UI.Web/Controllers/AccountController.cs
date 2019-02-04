using ProjetoINFNET.Domain.Interfaces.Domain;
using ProjetoINFNET.UI.Web.ViewModels;
using ProjetoINFNET.UI.Web.Util;
using System.Web.Mvc;
using System.Linq;
using System;

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

        [HttpGet]
        public ActionResult Register()
        {
            var viewModel = new RegisterViewModel();
            viewModel.ComboPerfilUsuario = _userServiceDomain.RecuperaTodosPerfisAtivos().Select(x => new SelectListItem { Text = x.PerfilNome, Value = Convert.ToString(x.IdPerfilUsuario) });
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            viewModel.ComboPerfilUsuario = _userServiceDomain.RecuperaTodosPerfisAtivos().Select(x => new SelectListItem { Text = x.PerfilNome, Value = Convert.ToString(x.IdPerfilUsuario) });

            var usuarioExistente = _userServiceDomain.RecuperarUsuarioPorEmail(viewModel.Email);
            if(usuarioExistente != null)
            {
                ModelState.AddModelError("", "E-mail esta sendo utilizado");
                return View(viewModel);
            }

            _userServiceDomain.CadastraUsuario(
                new Domain.Entities.Usuario
                {
                    Nome = viewModel.Nome,
                    DataCadastro = DateTime.Now,
                    Email = viewModel.Email,
                    IdPerfilUsuario = viewModel.IdPerfilUsuario,
                    Senha = viewModel.senha,
                    SenhaKey = Functions.GetRandomString()
                });

            return RedirectToAction("Index", "Home");
        }
    }
}