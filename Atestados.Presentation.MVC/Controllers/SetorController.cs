using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Presentation.MVC.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Atestados.Presentation.MVC.Controllers
{
    public class SetorController : Controller
    {
        private readonly ISetorAppServices _setorAppServices;

        public SetorController(ISetorAppServices setorAppServices)
        {
            _setorAppServices = setorAppServices;
        }

        // GET: Setor
        public ActionResult Index()
        {
            var setorViewModel = Mapper.Map<ICollection<Setor>, ICollection<SetorViewModel>>
                (_setorAppServices.GetAll());
            return View(setorViewModel);
        }

        // GET: Setor/Details/5
        public ActionResult Details(int id)
        {
            var setorViewModel = Mapper.Map<Setor, SetorViewModel>
                (_setorAppServices.GetById(id));
            return View(setorViewModel);
        }

        // GET: Setor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SetorViewModel setor)
        {
            if (ModelState.IsValid)
            {
                var setorDomain = Mapper.Map<SetorViewModel, Setor>(setor);
                _setorAppServices.Add(setorDomain);

                return RedirectToAction("Index");
            }

            return View(setor);
        }

        // GET: Setor/Edit/5
        public ActionResult Edit(int id)
        {
            var setorViewModel = Mapper.Map<Setor, SetorViewModel>
                (_setorAppServices.GetById(id));
            return View(setorViewModel);
        }

        // POST: Setor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SetorViewModel setor)
        {
            if (ModelState.IsValid)
            {
                var setorDomain = Mapper.Map<SetorViewModel, Setor>(setor);
                _setorAppServices.Update(setorDomain);

                return RedirectToAction("Index");
            }

            return View(setor);
        }

        // GET: Setor/Delete/5
        public ActionResult Delete(int id)
        {
            var setorViewModel = Mapper.Map<Setor, SetorViewModel>
                (_setorAppServices.GetById(id));
            return View(setorViewModel);
        }

        // POST: Setor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var setor = _setorAppServices.GetById(id);
            _setorAppServices.Delete(setor);

            return RedirectToAction("Index");
        }
    }
}
