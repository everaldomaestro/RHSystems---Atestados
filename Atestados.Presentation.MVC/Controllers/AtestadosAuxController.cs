using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Presentation.MVC.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Atestados.Presentation.MVC.Controllers
{
    public class AtestadosAuxController : Controller
    {
        private readonly IAtestadosAuxAppServices _atestadosAuxAppServices;

        public AtestadosAuxController(IAtestadosAuxAppServices atestadosAuxAppServices)
        {
            _atestadosAuxAppServices = atestadosAuxAppServices;
        }

        // GET: AtestadosAux
        public ActionResult Index()
        {
            var atestadosAuxViewModel = Mapper.Map<ICollection<AtestadosAux>, ICollection<AtestadosAuxViewModel>>
                (_atestadosAuxAppServices.GetAll());
            return View(atestadosAuxViewModel);
        }

        // GET: AtestadosAux/Details/5
        public ActionResult Details(int id)
        {
            var atestadosAuxViewModel = Mapper.Map<AtestadosAux, AtestadosAuxViewModel>
                (_atestadosAuxAppServices.GetById(id));
            return View(atestadosAuxViewModel);
        }

        // GET: AtestadosAux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AtestadosAux/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AtestadosAuxViewModel atestadosAux)
        {
            if (ModelState.IsValid)
            {
                var atestadosAuxDomain = Mapper.Map<AtestadosAuxViewModel, AtestadosAux>(atestadosAux);
                _atestadosAuxAppServices.Add(atestadosAuxDomain);

                return RedirectToAction("Index");
            }

            return View(atestadosAux);
        }

        // GET: AtestadosAux/Edit/5
        public ActionResult Edit(int id)
        {
            var atestadosAuxViewModel = Mapper.Map<AtestadosAux, AtestadosAuxViewModel>
                (_atestadosAuxAppServices.GetById(id));
            return View(atestadosAuxViewModel);
        }

        // POST: AtestadosAux/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AtestadosAuxViewModel atestadosAux)
        {
            if (ModelState.IsValid)
            {
                var atestadosAuxDomain = Mapper.Map<AtestadosAuxViewModel, AtestadosAux>(atestadosAux);
                _atestadosAuxAppServices.Update(atestadosAuxDomain);

                return RedirectToAction("Index");
            }

            return View(atestadosAux);
        }

        // GET: AtestadosAux/Delete/5
        public ActionResult Delete(int id)
        {
            var atestadosAuxViewModel = Mapper.Map<AtestadosAux, AtestadosAuxViewModel>
                (_atestadosAuxAppServices.GetById(id));
            return View(atestadosAuxViewModel);
        }

        // POST: AtestadosAux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var atestadosAux = _atestadosAuxAppServices.GetById(id);
            _atestadosAuxAppServices.Delete(atestadosAux);

            return RedirectToAction("Index");
        }
    }
}
