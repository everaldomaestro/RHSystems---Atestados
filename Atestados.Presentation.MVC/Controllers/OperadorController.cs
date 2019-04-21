using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Presentation.MVC.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Atestados.Presentation.MVC.Controllers
{
    public class OperadorController : Controller
    {
        private readonly IOperadorAppServices _operadorAppServices;
        private readonly ISetorAppServices _setorAppServices;
        private readonly IUnidadeAppServices _unidadeAppServices;

        public OperadorController(
            IOperadorAppServices operadorAppServices,
            ISetorAppServices setorAppServices,
            IUnidadeAppServices unidadeAppServices)
        {
            _operadorAppServices = operadorAppServices;
            _setorAppServices = setorAppServices;
            _unidadeAppServices = unidadeAppServices;
        }

        // GET: Operador
        public ActionResult Index()
        {
            var operadorViewModel = Mapper.Map<ICollection<Operador>, ICollection<OperadorViewModel>>
                (_operadorAppServices.GetAll());
            return View(operadorViewModel);
        }

        // GET: Operador/Details/5
        public ActionResult Details(int id)
        {
            var operadorViewModel = Mapper.Map<Operador, OperadorViewModel>
                (_operadorAppServices.GetById(id));
            return View(operadorViewModel);
        }

        // GET: Operador/Create
        public ActionResult Create()
        {
            ViewBag.SetorId = new SelectList(_setorAppServices.GetAll(), "SetorId", "Nome");
            ViewBag.UnidadeId = new SelectList(_unidadeAppServices.GetAll(), "UnidadeId", "Nome");

            return View();
        }

        // POST: Operador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OperadorViewModel operador)
        {
            if (ModelState.IsValid)
            {
                var operadorDomain = Mapper.Map<OperadorViewModel, Operador>(operador);
                _operadorAppServices.Add(operadorDomain);

                return RedirectToAction("Index");
            }

            return View(operador);
        }

        // GET: Operador/Edit/5
        public ActionResult Edit(int id)
        {
            var operadorViewModel = Mapper.Map<Operador, OperadorViewModel>
                (_operadorAppServices.GetById(id));

            ViewBag.SetorId =
                new SelectList(_setorAppServices.GetAll(), "SetorId", "Nome", operadorViewModel.SetorId);
            ViewBag.UnidadeId =
                new SelectList(_unidadeAppServices.GetAll(), "UnidadeId", "Nome", operadorViewModel.UnidadeId);

            return View(operadorViewModel);
        }

        // POST: Operador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OperadorViewModel operador)
        {
            if (ModelState.IsValid)
            {
                var operadorDomain = Mapper.Map<OperadorViewModel, Operador>(operador);
                _operadorAppServices.Update(operadorDomain);

                return RedirectToAction("Index");
            }

            return View(operador);
        }

        // GET: Operador/Delete/5
        public ActionResult Delete(int id)
        {
            var operadorViewModel = Mapper.Map<Operador, OperadorViewModel>
                (_operadorAppServices.GetById(id));
            return View(operadorViewModel);
        }

        // POST: Operador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var operador = _operadorAppServices.GetById(id);
            _operadorAppServices.Delete(operador);

            return RedirectToAction("Index");
        }
    }
}