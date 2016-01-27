using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TIGE.DAL;
using TIGE.Models;

namespace TIGE.Controllers
{
    [Authorize(Roles = "Administrador, Super")]
    public class EventosController : Controller
    {
        private TIGEContext db = new TIGEContext();
        private ApplicationUserManager _userManager;

        public EventosController()
        {
        }

        public EventosController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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

        // GET: Eventos
        public ActionResult Index()
        {
            var eventoes = db.Eventos.Include(e => e.Instituicao);
            return View(eventoes.ToList());
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Eventos/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.InstituicaoID = new SelectList(db.Instituicoes, "InstituicaoID", "Nome");

            var user = await UserManager.FindByNameAsync(User.Identity.Name);
            if (User.IsInRole("Administrador"))
            {
                ViewBag.InstituicaoID = new SelectList(db.Instituicoes.Where(m => m.InstituicaoID == user.InstituicaoID),
                    "InstituicaoID", "Nome");
            }
            else if (User.IsInRole("Super"))
            {
                ViewBag.InstituicaoID = new SelectList(db.Instituicoes.OrderBy(m => m.Nome),
                    "InstituicaoID", "Nome");
            }

            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Descricao,Inscritivel,Tipo,InstituicaoID")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Eventos.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoID = new SelectList(db.Instituicoes, "InstituicaoID", "Nome", evento.InstituicaoID);
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoID = new SelectList(db.Instituicoes, "InstituicaoID", "Nome", evento.InstituicaoID);
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventoID,Nome,Descricao,Inscritivel,InstituicaoID")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoID = new SelectList(db.Instituicoes, "InstituicaoID", "Nome", evento.InstituicaoID);
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventos.Find(id);
            db.Eventos.Remove(evento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
