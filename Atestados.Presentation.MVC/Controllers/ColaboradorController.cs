using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Presentation.MVC.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Atestados.Presentation.MVC.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorAppServices _colaboradorAppServices;
        private readonly ISetorAppServices _setorAppServices;
        private readonly IUnidadeAppServices _unidadeAppServices;

        public ColaboradorController(
            IColaboradorAppServices colaboradorAppServices,
            ISetorAppServices setorAppServices,
            IUnidadeAppServices unidadeAppServices)
        {
            _colaboradorAppServices = colaboradorAppServices;
            _setorAppServices = setorAppServices;
            _unidadeAppServices = unidadeAppServices;
        }
        // GET: Colaborador
        public ActionResult Index()
        {
            var colaboradorViewModel = Mapper.Map<ICollection<Colaborador>, ICollection<ColaboradorViewModel>>
                (_colaboradorAppServices.GetAll());
            return View(colaboradorViewModel);
        }

        // GET: Colaborador/Details/5
        public ActionResult Details(int id)
        {
            var colaboradorViewModel = Mapper.Map<Colaborador, ColaboradorViewModel>
                (_colaboradorAppServices.GetById(id));
            return View(colaboradorViewModel);
        }

        // GET: Colaborador/Create
        public ActionResult Create()
        {
            ViewBag.SetorId = new SelectList(_setorAppServices.GetAll(), "SetorId", "Nome");
            ViewBag.UnidadeId = new SelectList(_unidadeAppServices.GetAll(), "UnidadeId", "Nome");

            return View();
        }

        // POST: Colaborador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ColaboradorViewModel colaborador)
        {
            if (ModelState.IsValid)
            {
                var colaboradorDomain = Mapper.Map<ColaboradorViewModel, Colaborador>(colaborador);
                _colaboradorAppServices.Add(colaboradorDomain);

                return RedirectToAction("Index");
            }

            return View(colaborador);
        }

        // GET: Colaborador/Edit/5
        public ActionResult Edit(int id)
        {
            var colaboradorViewModel = Mapper.Map<Colaborador, ColaboradorViewModel>
                (_colaboradorAppServices.GetById(id));

            ViewBag.SetorId = 
                new SelectList(_setorAppServices.GetAll(), "SetorId", "Nome", colaboradorViewModel.SetorId);
            ViewBag.UnidadeId = 
                new SelectList(_unidadeAppServices.GetAll(), "UnidadeId", "Nome", colaboradorViewModel.UnidadeId);

            return View(colaboradorViewModel);
        }

        // POST: Colaborador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ColaboradorViewModel colaborador)
        {
            if (ModelState.IsValid)
            {
                var colaboradorDomain = Mapper.Map<ColaboradorViewModel, Colaborador>(colaborador);
                _colaboradorAppServices.Update(colaboradorDomain);

                return RedirectToAction("Index");
            }

            return View(colaborador);
        }

        // GET: Colaborador/Delete/5
        public ActionResult Delete(int id)
        {
            var colaboradorViewModel = Mapper.Map<Colaborador, ColaboradorViewModel>
                (_colaboradorAppServices.GetById(id));
            return View(colaboradorViewModel);
        }

        // POST: Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var colaborador = _colaboradorAppServices.GetById(id);
            _colaboradorAppServices.Delete(colaborador);

            return RedirectToAction("Index");
        }
    }
}
