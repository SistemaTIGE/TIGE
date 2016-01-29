using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TIGE.DAL;
using TIGE.Models;
using TIGE.ViewModels.Gerenciamento;

namespace TIGE.Controllers.Gerenciamento
{
    [Authorize(Roles = "Super")]
    public class InstituicoesController : Controller
    {
        private TIGEContext db = new TIGEContext();

        // GET: Instituicoes
        public ActionResult Index()
        {
            return View(db.Instituicoes.ToList());
        }

        // GET: Instituicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // GET: Instituicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instituicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CriarInstituicaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var instituicao = new Instituicao
                {
                    Nome = viewModel.Nome
                };
                db.Instituicoes.Add(instituicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Instituicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }

            var viewModel = new EditarInstituicaoViewModel
            {
                InstituicaoID = instituicao.InstituicaoID,
                Nome = instituicao.Nome
            };
            return View(viewModel);
        }

        // POST: Instituicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditarInstituicaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Encontra a entrada e modifica o nome
                var instituicao = db.Instituicoes.Find(viewModel.InstituicaoID);
                instituicao.Nome = viewModel.Nome;
                // Estado da entrada 'Modificado' e salva alterações no banco
                db.Entry(instituicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Instituicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instituicao instituicao = db.Instituicoes.Find(id);
            db.Instituicoes.Remove(instituicao);
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
