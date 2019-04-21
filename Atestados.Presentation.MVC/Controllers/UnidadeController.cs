using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Presentation.MVC.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Atestados.Presentation.MVC.Controllers
{
    public class UnidadeController : Controller
    {
        private readonly IUnidadeAppServices _unidadeAppServices;

        public UnidadeController(IUnidadeAppServices unidadeAppServices)
        {
            _unidadeAppServices = unidadeAppServices;
        }

        // GET: Unidade
        public ActionResult Index()
        {
            var unidadeViewModel = Mapper.Map<ICollection<Unidade>, ICollection<UnidadeViewModel>>
                (_unidadeAppServices.GetAll());
            return View(unidadeViewModel);
        }

        // GET: Unidade/Details/5
        public ActionResult Details(int id)
        {
            var unidadeViewModel = Mapper.Map<Unidade, UnidadeViewModel>
                (_unidadeAppServices.GetById(id));
            return View(unidadeViewModel);
        }

        // GET: Unidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unidade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UnidadeViewModel unidade)
        {
            if (ModelState.IsValid)
            {
                var unidadeDomain = Mapper.Map<UnidadeViewModel, Unidade>(unidade);
                _unidadeAppServices.Add(unidadeDomain);

                return RedirectToAction("Index");
            }

            return View(unidade);
        }

        // GET: Unidade/Edit/5
        public ActionResult Edit(int id)
        {
            var unidadeViewModel = Mapper.Map<Unidade, UnidadeViewModel>
                (_unidadeAppServices.GetById(id));
            return View(unidadeViewModel);
        }

        // POST: Unidade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UnidadeViewModel unidade)
        {
            if (ModelState.IsValid)
            {
                var unidadeDomain = Mapper.Map<UnidadeViewModel, Unidade>(unidade);
                _unidadeAppServices.Update(unidadeDomain);

                return RedirectToAction("Index");
            }

            return View(unidade);
        }

        // GET: Unidade/Delete/5
        public ActionResult Delete(int id)
        {
            var unidadeViewModel = Mapper.Map<Unidade, UnidadeViewModel>
                (_unidadeAppServices.GetById(id));
            return View(unidadeViewModel);
        }

        // POST: Unidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var unidade = _unidadeAppServices.GetById(id);
            _unidadeAppServices.Delete(unidade);

            return RedirectToAction("Index");
        }
    }
}
