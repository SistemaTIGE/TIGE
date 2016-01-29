using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIGE.DAL;
using TIGE.ViewModels.Gerenciamento;

namespace TIGE.Controllers.Gerenciamento
{
    public class RolesController : Controller
    {
        private TIGEContext db = new TIGEContext();

        #region Dependency Injection
        private ApplicationUserManager _userManager;

        public RolesController()
        {

        }

        public RolesController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        // GET: Roles
        public ActionResult Index()
        {
            List<RoleIndexViewModel> model = new List<RoleIndexViewModel>();
            var roles = db.Roles.OrderBy(m => m.Name).ToList();

            foreach (var role in roles)
                model.Add(new RoleIndexViewModel
                {
                    Name = role.Name,
                    UserCount = role.Users.Count
                });

            return View(model);
        }

        // GET: Roles/Toggle
        public ActionResult Toggle()
        {
            ViewBag.RoleOrigem = new SelectList(db.Roles.OrderBy(m => m.Name).ToList(), "Name", "Name");
            ViewBag.RoleDestino = ViewBag.RoleOrigem;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Toggle(ChangeRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(m => m.Email.Equals(model.Email, StringComparison.CurrentCultureIgnoreCase))
                    .FirstOrDefault();
                UserManager.RemoveFromRole(user.Id, model.RoleOrigem);
                UserManager.AddToRole(user.Id, model.RoleDestino);

                return RedirectToAction(nameof(RolesController.Index));
            }

            ViewBag.RoleOrigem = new SelectList(db.Roles.OrderBy(m => m.Name).ToList(), "Name", "Name", model.RoleOrigem);
            ViewBag.RoleDestino = new SelectList(db.Roles.OrderBy(m => m.Name).ToList(), "Name", "Name", model.RoleDestino);

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                    _userManager.Dispose();
                else if (db != null)
                    db.Dispose();

                _userManager = null;
                db = null;
            }

            base.Dispose(disposing);
        }
    }
}